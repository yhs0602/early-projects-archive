#!/usr/bin/env python3
"""Capture and restore filesystem timestamps for files tracked by Git."""

from __future__ import annotations

import argparse
import datetime as dt
import hashlib
import json
import os
import platform
import shutil
import stat
import subprocess
import sys
import tempfile
from typing import Any

FORMAT_VERSION = 1
DEFAULT_MANIFEST = "metadata/file-times.json"


def git(args: list[str], root: bytes, check: bool = True) -> subprocess.CompletedProcess[bytes]:
    result = subprocess.run(
        [b"git", *(os.fsencode(arg) for arg in args)],
        cwd=root,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
    )
    if check and result.returncode:
        raise RuntimeError(os.fsdecode(result.stderr).strip() or "Git command failed.")
    return result


def find_root() -> bytes:
    result = subprocess.run(
        ["git", "rev-parse", "--show-toplevel"],
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        check=False,
    )
    if result.returncode:
        raise RuntimeError(result.stderr.decode("utf-8", "replace").strip() or "Run inside a Git repository.")
    return result.stdout.rstrip(b"\r\n")


def safe_relative_path(value: str) -> bytes:
    path = os.fsencode(value)
    if os.path.isabs(path):
        raise ValueError("Path must be relative to the repository.")
    path = os.path.normpath(path)
    if path == b".." or path.startswith(b".." + os.sep.encode()):
        raise ValueError("Path escapes the repository.")
    return path


def timestamp_ns(info: os.stat_result, name: str) -> int:
    ns_name = name + "_ns"
    if hasattr(info, ns_name):
        return int(getattr(info, ns_name))
    return int(round(getattr(info, name) * 1_000_000_000))


def creation_ns(info: os.stat_result) -> int | None:
    value = getattr(info, "st_birthtime", None)
    return None if value is None else int(round(value * 1_000_000_000))


def file_digest(path: bytes, kind: str) -> tuple[str, int]:
    info = os.lstat(path)
    if kind == "symlink":
        if not stat.S_ISLNK(info.st_mode):
            raise ValueError("Expected a symbolic link.")
        contents = os.readlink(path)
        return hashlib.sha256(contents).hexdigest(), len(contents)
    if not stat.S_ISREG(info.st_mode):
        raise ValueError("Expected a regular file.")

    digest = hashlib.sha256()
    size = 0
    with open(path, "rb") as source:
        before = os.fstat(source.fileno())
        while True:
            block = source.read(1024 * 1024)
            if not block:
                break
            digest.update(block)
            size += len(block)
        after = os.fstat(source.fileno())

    fields = ("st_dev", "st_ino", "st_size")
    if any(getattr(before, field) != getattr(after, field) for field in fields):
        raise RuntimeError("File changed while it was being read.")
    if timestamp_ns(before, "st_mtime") != timestamp_ns(after, "st_mtime"):
        raise RuntimeError("File changed while it was being read.")
    return digest.hexdigest(), size


def indexed_paths(root: bytes, excluded_path: bytes, include_untracked: bool) -> list[bytes]:
    raw = git(["ls-files", "--stage", "-z"], root).stdout
    result: list[bytes] = []
    for entry in raw.split(b"\0"):
        if not entry:
            continue
        metadata, path = entry.split(b"\t", 1)
        mode, _blob, stage = metadata.split(b" ", 2)
        if stage != b"0":
            raise RuntimeError("Resolve index conflicts before capturing timestamps.")
        if mode == b"160000":
            continue
        path = safe_relative_path(os.fsdecode(path))
        if path != excluded_path:
            result.append(path)
    if include_untracked:
        others = git(["ls-files", "--others", "--exclude-standard", "-z"], root).stdout
        for path in others.split(b"\0"):
            if path:
                path = safe_relative_path(os.fsdecode(path))
                if path != excluded_path:
                    result.append(path)
    return sorted(set(result))


def resolve_manifest(root: bytes, value: str) -> tuple[bytes, bytes]:
    relative = safe_relative_path(value)
    return relative, os.path.join(root, relative)


def capture(args: argparse.Namespace) -> int:
    root = find_root()
    manifest_rel, manifest_abs = resolve_manifest(root, args.manifest)
    records: list[dict[str, Any]] = []

    for relative in indexed_paths(root, manifest_rel, args.include_untracked):
        absolute = os.path.join(root, relative)
        try:
            info = os.lstat(absolute)
            kind = "symlink" if stat.S_ISLNK(info.st_mode) else "file"
            digest, size = file_digest(absolute, kind)
            if size != info.st_size:
                raise RuntimeError("File changed while it was being read.")
            records.append(
                {
                    "path": os.fsdecode(relative),
                    "kind": kind,
                    "size": size,
                    "sha256": digest,
                    "atime_ns": timestamp_ns(info, "st_atime"),
                    "mtime_ns": timestamp_ns(info, "st_mtime"),
                    "birthtime_ns": creation_ns(info),
                }
            )
        except (OSError, RuntimeError, ValueError) as error:
            raise RuntimeError(f"Could not capture {os.fsdecode(relative)!r}: {error}") from error

    head_result = git(["rev-parse", "--verify", "HEAD"], root, check=False)
    head = head_result.stdout.decode("ascii", "replace").strip() if head_result.returncode == 0 else None
    document = {
        "format_version": FORMAT_VERSION,
        "captured_at_utc": dt.datetime.now(dt.timezone.utc).isoformat(),
        "repository_head": head,
        "timestamp_fields": ["atime_ns", "mtime_ns", "birthtime_ns"],
        "files": records,
    }

    os.makedirs(os.path.dirname(manifest_abs), exist_ok=True)
    fd, temporary = tempfile.mkstemp(prefix=b".file-times-", suffix=b".tmp", dir=os.path.dirname(manifest_abs))
    try:
        with os.fdopen(fd, "w", encoding="utf-8", newline="\n") as output:
            json.dump(document, output, ensure_ascii=True, indent=2, sort_keys=True)
            output.write("\n")
        os.replace(temporary, manifest_abs)
    except BaseException:
        try:
            os.unlink(temporary)
        except FileNotFoundError:
            pass
        raise

    print(f"Captured timestamps for {len(records)} files.")
    print(f"Manifest: {os.fsdecode(manifest_abs)}")
    if head is None:
        print("No commit exists yet; the manifest records the current index and included untracked files.")
    return 0


def set_creation_time(path: bytes, value_ns: int, setfile: str) -> None:
    local_time = dt.datetime.fromtimestamp(value_ns / 1_000_000_000)
    formatted = local_time.strftime("%m/%d/%Y %H:%M:%S")
    result = subprocess.run(
        [setfile, "-d", formatted, os.fsdecode(path)],
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True,
        check=False,
    )
    if result.returncode:
        raise RuntimeError(result.stderr.strip() or result.stdout.strip() or "SetFile failed.")


def restore(args: argparse.Namespace) -> int:
    root = find_root()
    _manifest_rel, manifest_abs = resolve_manifest(root, args.manifest)
    with open(manifest_abs, "r", encoding="utf-8") as source:
        document = json.load(source)
    if document.get("format_version") != FORMAT_VERSION or not isinstance(document.get("files"), list):
        raise RuntimeError("Unsupported or invalid timestamp manifest.")

    setfile = shutil.which("SetFile") if platform.system() == "Darwin" else None
    needs_creation = any(item.get("birthtime_ns") is not None for item in document["files"])
    if needs_creation and setfile is None:
        print("Warning: SetFile is unavailable; creation times cannot be restored.", file=sys.stderr)

    restored = skipped = errors = 0
    warned_creation = False
    for item in document["files"]:
        try:
            relative = safe_relative_path(item["path"])
            absolute = os.path.join(root, relative)
            kind = item["kind"]
            digest, size = file_digest(absolute, kind)
            if digest != item["sha256"] or size != item["size"]:
                print(f"Skipped changed file: {os.fsdecode(relative)}", file=sys.stderr)
                skipped += 1
                continue

            birth = item.get("birthtime_ns")
            if birth is not None:
                if setfile is None:
                    if not warned_creation:
                        print("Warning: creation times were not restored.", file=sys.stderr)
                        warned_creation = True
                else:
                    try:
                        set_creation_time(absolute, int(birth), setfile)
                    except (OSError, RuntimeError, ValueError) as error:
                        print(f"Could not restore creation time for {os.fsdecode(relative)}: {error}", file=sys.stderr)
                        errors += 1

            os.utime(
                absolute,
                ns=(int(item["atime_ns"]), int(item["mtime_ns"])),
                follow_symlinks=(kind != "symlink"),
            )
            restored += 1
        except (KeyError, OSError, RuntimeError, ValueError, TypeError) as error:
            name = item.get("path", "<invalid manifest entry>") if isinstance(item, dict) else "<invalid entry>"
            print(f"Could not restore {name!r}: {error}", file=sys.stderr)
            errors += 1

    print(f"Restored timestamps for {restored} files; skipped {skipped}; errors {errors}.")
    return 1 if skipped or errors else 0


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    commands = parser.add_subparsers(dest="command", required=True)
    for name, handler in (("capture", capture), ("restore", restore)):
        command = commands.add_parser(name)
        if name == "capture":
            command.add_argument("--include-untracked", action="store_true", help="also capture non-ignored untracked files")
        command.add_argument(
            "--manifest",
            default=DEFAULT_MANIFEST,
            help=f"manifest path relative to the repository (default: {DEFAULT_MANIFEST})",
        )
        command.set_defaults(handler=handler)
    args = parser.parse_args()
    try:
        return args.handler(args)
    except (OSError, RuntimeError, ValueError, json.JSONDecodeError) as error:
        print(f"Error: {error}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
