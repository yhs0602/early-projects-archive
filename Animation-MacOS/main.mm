#import <Cocoa/Cocoa.h>

#include <chrono>
#include <cmath>

@interface AnimationView : NSView {
@private
    NSImage *_lightImage;
    NSImage *_magnetImage;
    NSTimer *_animationTimer;
    std::chrono::steady_clock::time_point _startTime;
    double _elapsedSeconds;
    CGFloat _lightX;
    CGFloat _magnetX;
    CGFloat _magnetAngle;
    BOOL _magnetUsesLightUpdater;
}
@end

@implementation AnimationView

- (instancetype)initWithFrame:(NSRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        NSURL *lightURL = [[NSBundle mainBundle] URLForResource:@"light" withExtension:@"bmp"];
        NSURL *magnetURL = [[NSBundle mainBundle] URLForResource:@"magnet" withExtension:@"bmp"];
        _lightImage = lightURL ? [[NSImage alloc] initWithContentsOfURL:lightURL] : nil;
        _magnetImage = magnetURL ? [[NSImage alloc] initWithContentsOfURL:magnetURL] : nil;
        _startTime = std::chrono::steady_clock::now();
        _elapsedSeconds = 0.0;
        _lightX = 100.0;
        _magnetX = 200.0;
        _magnetAngle = 0.0;
        _magnetUsesLightUpdater = NO;

        _animationTimer = [NSTimer timerWithTimeInterval:1.0 / 60.0
                                                  target:self
                                                selector:@selector(animationTick:)
                                                userInfo:nil
                                                 repeats:YES];
        [[NSRunLoop mainRunLoop] addTimer:_animationTimer forMode:NSRunLoopCommonModes];
    }
    return self;
}

- (BOOL)isFlipped
{
    return YES;
}

- (void)animationTick:(NSTimer *)timer
{
    (void)timer;
    const auto now = std::chrono::steady_clock::now();
    _elapsedSeconds = std::chrono::duration<double>(now - _startTime).count();

    // Match AnimUpdate::Update: dx is added once per update call, without
    // scaling by elapsed time. The Windows loop does not refresh lastTick, so
    // its magnet angle is derived from total time since startup.
    _lightX += 20.0;
    if (_magnetUsesLightUpdater) {
        // Both objects now reference the same updater; the original object loop
        // advances that shared position once for each object per frame.
        _lightX += 20.0;
        _magnetX = _lightX;
        _magnetAngle = 0.0;
    } else {
        const double elapsedMilliseconds =
            std::chrono::duration<double, std::milli>(now - _startTime).count();
        _magnetAngle = std::fmod(0.1 * elapsedMilliseconds, 360.0);
    }

    [self setNeedsDisplay:YES];

    // UpdateObjects runs after drawing in the Windows message loop.
    if (_elapsedSeconds > 10.0) {
        _magnetUsesLightUpdater = YES;
    }
}

- (void)drawImage:(NSImage *)image atPoint:(NSPoint)point rotation:(CGFloat)degrees
{
    if (!image) {
        return;
    }

    [NSGraphicsContext saveGraphicsState];
    NSAffineTransform *transform = [NSAffineTransform transform];
    [transform translateXBy:point.x yBy:point.y];
    [transform rotateByDegrees:degrees];
    [transform concat];
    [image drawAtPoint:NSZeroPoint
              fromRect:NSZeroRect
             operation:NSCompositingOperationSourceOver
              fraction:1.0];
    [NSGraphicsContext restoreGraphicsState];
}

- (void)drawRect:(NSRect)dirtyRect
{
    [[NSColor whiteColor] setFill];
    NSRectFill(dirtyRect);

    [self drawImage:_lightImage atPoint:NSMakePoint(_lightX, 100.0) rotation:0.0];
    [self drawImage:_magnetImage
            atPoint:NSMakePoint(_magnetX, 100.0)
           rotation:_magnetAngle];
}

@end

@interface AnimationAppDelegate : NSObject <NSApplicationDelegate> {
@private
    NSWindow *_window;
}
@end

@implementation AnimationAppDelegate

- (void)applicationDidFinishLaunching:(NSNotification *)notification
{
    (void)notification;
    const NSRect contentRect = NSMakeRect(0.0, 0.0, 640.0, 480.0);
    const NSWindowStyleMask style = NSWindowStyleMaskTitled |
                                    NSWindowStyleMaskClosable |
                                    NSWindowStyleMaskMiniaturizable |
                                    NSWindowStyleMaskResizable;
    _window = [[NSWindow alloc] initWithContentRect:contentRect
                                         styleMask:style
                                           backing:NSBackingStoreBuffered
                                             defer:NO];
    [_window setTitle:@"Animation"];
    [_window setBackgroundColor:[NSColor whiteColor]];

    AnimationView *view = [[AnimationView alloc] initWithFrame:[[_window contentView] bounds]];
    [view setAutoresizingMask:NSViewWidthSizable | NSViewHeightSizable];
    [_window setContentView:view];
    [_window center];
    [_window makeKeyAndOrderFront:nil];
    [NSApp activateIgnoringOtherApps:YES];
}

- (BOOL)applicationShouldTerminateAfterLastWindowClosed:(NSApplication *)sender
{
    (void)sender;
    return YES;
}

@end

int main(int argc, const char *argv[])
{
    (void)argc;
    (void)argv;
    @autoreleasepool {
        NSApplication *application = [NSApplication sharedApplication];
        [application setActivationPolicy:NSApplicationActivationPolicyRegular];
        AnimationAppDelegate *delegate = [[AnimationAppDelegate alloc] init];
        [application setDelegate:delegate];
        [application run];
    }
    return 0;
}
