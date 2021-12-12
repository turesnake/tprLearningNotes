#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        Provides access to a display / screen for rendering operations.
        Multi-display rendering is available on PC (Windows/Mac/Linux), iOS and Android.

        Use the Display class to operate on the displays themselves, 
        and "Camera.targetDisplay" to set up cameras for rendering to individual displays.

        See Also: "Camera.targetDisplay", "Canvas.targetDisplay"
    */
    [NativeHeaderAttribute("Runtime/Graphics/DisplayManager.h")]
    [UsedByNativeCodeAttribute]
    public class Display//Display__RR
    {
        //
        // 摘要:
        //     The list of currently connected displays.
        public static Display[] displays;

      
        // Main Display.
        // 等同于: Display.displays[0].
        public static Display main { get; }


        /*
            True when doing a blit to the back buffer requires manual color space conversion.
            This property indicates whether the back buffer requires manual color space conversion 
            from linear color space to sRGB in order to blit to it. 
            The back buffer requires this if you are using linear color space 
            and the back buffer does not support automatic conversion to sRGB.
            ---
            如果你选择了 linear 工作流, 同时 backbuffer 并不支持 "自动将 线性颜色转换为 sRGB值" 这个功能,
            而且你正要把 一组 linear 数据, 从某个 render texture 上 blit 到 backbuffer 上去;
            那么本变量 就要设置为 true;

            在 urp 中, 当本值为 true, 会启用 keyword: _LINEAR_TO_SRGB_CONVERSION
                以便在 shader 中手动实现 "linear->sRGB" 转换;
        */
        public bool requiresSrgbBlitToBackbuffer { get; }


        //
        // 摘要:
        //     True when the back buffer requires an intermediate texture to render.
        public bool requiresBlitToBackbuffer { get; }
        //
        // 摘要:
        //     Gets the state of the display and returns true if the display is active and false
        //     if otherwise.
        public bool active { get; }
        //
        // 摘要:
        //     Depth RenderBuffer.
        public RenderBuffer depthBuffer { get; }
        //
        // 摘要:
        //     Color RenderBuffer.
        public RenderBuffer colorBuffer { get; }
        //
        // 摘要:
        //     Vertical native display resolution.
        public int systemHeight { get; }
        //
        // 摘要:
        //     Horizontal native display resolution.
        public int systemWidth { get; }
        //
        // 摘要:
        //     Horizontal resolution that the display is rendering at.
        public int renderingWidth { get; }
        //
        // 摘要:
        //     Vertical resolution that the display is rendering at.
        public int renderingHeight { get; }

        public static event DisplaysUpdatedDelegate onDisplaysUpdated;

        [Obsolete("MultiDisplayLicense has been deprecated.", false)]
        public static bool MultiDisplayLicense();
        //
        // 摘要:
        //     Query relative mouse coordinates.
        //
        // 参数:
        //   inputMouseCoordinates:
        //     Mouse Input Position as Coordinates.
        public static Vector3 RelativeMouseAt(Vector3 inputMouseCoordinates);
        //
        // 摘要:
        //     This overloaded function available for Windows allows specifying desired Window
        //     Width, Height and Refresh Rate.
        //
        // 参数:
        //   width:
        //     Desired Width of the Window (for Windows only. On Linux and Mac uses Screen Width).
        //
        //   height:
        //     Desired Height of the Window (for Windows only. On Linux and Mac uses Screen
        //     Height).
        //
        //   refreshRate:
        //     Desired Refresh Rate.
        public void Activate(int width, int height, int refreshRate);
        //
        // 摘要:
        //     Activate an external display. Eg. Secondary Monitors connected to the System.
        public void Activate();
        //
        // 摘要:
        //     Set rendering size and position on screen (Windows only).
        //
        // 参数:
        //   width:
        //     Change Window Width (Windows Only).
        //
        //   height:
        //     Change Window Height (Windows Only).
        //
        //   x:
        //     Change Window Position X (Windows Only).
        //
        //   y:
        //     Change Window Position Y (Windows Only).
        public void SetParams(int width, int height, int x, int y);
        //
        // 摘要:
        //     Sets rendering resolution for the display.
        //
        // 参数:
        //   w:
        //     Rendering width in pixels.
        //
        //   h:
        //     Rendering height in pixels.
        public void SetRenderingResolution(int w, int h);

        public delegate void DisplaysUpdatedDelegate();
    }
}

