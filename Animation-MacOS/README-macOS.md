# Animation for macOS

This is a native AppKit port of the original Win32 GDI animation sample. The
original sources and bitmap assets are retained in this folder for reference.

Build and launch from Terminal:

```sh
make run
```

The app draws the supplied bitmaps in a 640 × 480 window. It preserves the
Windows source's frame-based movement: the light advances 20 pixels per update,
and the magnet angle is computed from elapsed milliseconds at 0.1 degrees per
millisecond. After 10 seconds, both objects use the same updater, as in the
original object loop.
