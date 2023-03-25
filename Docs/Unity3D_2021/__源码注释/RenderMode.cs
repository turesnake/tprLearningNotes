#region 程序集 UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UIModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     RenderMode for the Canvas.
    public enum RenderMode
    {
        //
        // 摘要:
        //     Render at the end of the Scene using a 2D Canvas.
        ScreenSpaceOverlay = 0,
        //
        // 摘要:
        //     Render using the Camera configured on the Canvas.
        ScreenSpaceCamera = 1,
        //
        // 摘要:
        //     Render using any Camera in the Scene that can render the layer.
        WorldSpace = 2
    }
}

