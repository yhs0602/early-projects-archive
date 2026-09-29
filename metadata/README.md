# Git timestamp backup

Git does not store ordinary file creation, access, or modification times. The
script at tools/preserve_git_times.py saves timestamps to
metadata/file-times.json. That JSON file is committed alongside the files; it
does not contain file contents.

## First commit

Capture untracked project files before staging so their access times are
recorded before Git reads them:

    python3 tools/preserve_git_times.py capture --include-untracked
    git add -A
    git commit

The capture skips its own manifest. Review the staged paths before committing.

## Later commits and restore

Stage later edits, then refresh the manifest and commit it with those edits:

    git add <changed paths>
    python3 tools/preserve_git_times.py capture
    git add metadata/file-times.json
    git commit

After checkout, run this from anywhere inside the repository:

    python3 tools/preserve_git_times.py restore

The script restores access and modification times for files whose contents
still match the manifest. On macOS, it also uses SetFile to restore creation
times when the filesystem permits it. A filesystem or OS that cannot set
creation times may leave those times unchanged.
