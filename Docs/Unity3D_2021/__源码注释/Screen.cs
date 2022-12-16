
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UnityEngine
{
    //
    // 摘要:
    //     Provides access to display information.
    public sealed class Screen
    {
        public Screen();

        //
        // 摘要:
        //     Set this property to one of the values in FullScreenMode to change the display
        //     mode of your application.
        public static FullScreenMode fullScreenMode { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property GetResolution has been deprecated. Use resolutions instead (UnityUpgradable) -> resolutions", true)]
        public static Resolution[] GetResolution { get; }
        //
        // 摘要:
        //     The display information associated with the display that the main application
        //     window is on.
        public static DisplayInfo mainWindowDisplayInfo { get; }
        //
        // 摘要:
        //     The position of the top left corner of the main window relative to the top left
        //     corner of the display.
        public static Vector2Int mainWindowPosition { get; }
        //
        // 摘要:
        //     The current brightness of the screen.
        public static float brightness { get; set; }
        //
        // 摘要:
        //     A power saving setting, allowing the screen to dim some time after the last active
        //     user interaction.
        public static int sleepTimeout { get; set; }
        //
        // 摘要:
        //     Specifies logical orientation of the screen.
        public static ScreenOrientation orientation { get; set; }
        //
        // 摘要:
        //     Enables auto-rotation to landscape right.
        public static bool autorotateToLandscapeRight { get; set; }
        //
        // 摘要:
        //     Enables auto-rotation to landscape left
        public static bool autorotateToLandscapeLeft { get; set; }
        //
        // 摘要:
        //     Enables auto-rotation to portrait, upside down.
        public static bool autorotateToPortraitUpsideDown { get; set; }
        //
        // 摘要:
        //     Enables auto-rotation to portrait.
        public static bool autorotateToPortrait { get; set; }
        //
        // 摘要:
        //     Returns a list of screen areas that are not functional for displaying content
        //     (Read Only).
        public static Rect[] cutouts { get; }
        //
        // 摘要:
        //     Returns the safe area of the screen in pixels (Read Only).
        public static Rect safeArea { get; }
        //
        // 摘要:
        //     Enable cursor locking
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Cursor.lockState and Cursor.visible instead.", false)]
        public static bool lockCursor { get; set; }
        //
        // 摘要:
        //     Enables full-screen mode for the application.
        public static bool fullScreen { get; set; }
        //
        // 摘要:
        //     Returns all full-screen resolutions that the monitor supports (Read Only).
        public static Resolution[] resolutions { get; }
        //
        // 摘要:
        //     The current screen resolution (Read Only).
        public static Resolution currentResolution { get; }
        //
        // 摘要:
        //     The current DPI of the screen / device (Read Only).
        public static float dpi { get; }
        //
        // 摘要:
        //     The current height of the screen window in pixels (Read Only).
        public static int height { get; }
        //
        // 摘要:
        //     The current width of the screen window in pixels (Read Only).
        public static int width { get; }
        //
        // 摘要:
        //     Should the cursor be visible?
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property showCursor has been deprecated. Use Cursor.visible instead (UnityUpgradable) -> UnityEngine.Cursor.visible", true)]
        public static bool showCursor { get; set; }

        public static void GetDisplayLayout(List<DisplayInfo> displayLayout);
        public static AsyncOperation MoveMainWindowTo(in DisplayInfo display, Vector2Int position);
        //
        // 摘要:
        //     Switches the screen resolution.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   fullscreen:
        //
        //   preferredRefreshRate:
        //
        //   fullscreenMode:
        public static void SetResolution(int width, int height, bool fullscreen);
        //
        // 摘要:
        //     Switches the screen resolution.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   fullscreen:
        //
        //   preferredRefreshRate:
        //
        //   fullscreenMode:
        public static void SetResolution(int width, int height, bool fullscreen, [Internal.DefaultValue("0")] int preferredRefreshRate);
        //
        // 摘要:
        //     Switches the screen resolution.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   fullscreen:
        //
        //   preferredRefreshRate:
        //
        //   fullscreenMode:
        public static void SetResolution(int width, int height, FullScreenMode fullscreenMode);
        //
        // 摘要:
        //     Switches the screen resolution.
        //
        // 参数:
        //   width:
        //
        //   height:
        //
        //   fullscreen:
        //
        //   preferredRefreshRate:
        //
        //   fullscreenMode:
        public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, [Internal.DefaultValue("0")] int preferredRefreshRate);
    }
}

