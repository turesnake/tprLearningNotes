#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{

    /*
        摘要:
        Values for Camera.clearFlags, determining what to clear when rendering a Camera.
    */
    public enum CameraClearFlags
    {
        
        /*
            Clear with the skybox.
            If a skybox is not set up, the Camera will clear with a Camera.backgroundColor
        */
        Skybox = 1,


        // 这个居然在文档中直接没有
        Color = 2,


        //  Clear with a background color. "Camera.backgroundColor"
        SolidColor = 2,


        /*
            Clear only the depth buffer.
            只清除 上一帧的 depth 数据, 而 color buffer 数据完全不清理;
        */
        Depth = 3,


        /*
            Don't clear anything.
            啥也不清理, 彻底保留上一帧的 depth 数据 和 color 数据;
        */
        Nothing = 4
    }
}

