#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{

    /*
        摘要:
        Describes different types of camera.

        The Unity Editor sets the type of a camera based on what it is used for. 

        enum: Game, SceneView, Preview, VR, Reflection
    */
    [Flags]
    public enum CameraType//CameraType__
    {
        
        // 摘要:
        //     Used to indicate a regular in-game camera.
        Game = 1,

        /*
            Used to indicate that a camera is used for rendering the Scene View in the Editor.
            这个 camera 用来渲染 editor 中的 scene 窗口;
        */
        SceneView = 2,


        /*
            Used to indicate a camera that is used for rendering previews in the Editor.
            这个 camera 用来渲染 editor 中的那些 预览小窗口; 比如预览 模型的;

            如果在 Hierarchy 中选中一个 camera go, 然后在 scene 窗口中看到的那个小窗口, 那个不属于 Preview,
            它只是 Game 窗口的复制, 它仍然属于 Game mode;
        */
        Preview = 4,


    
        //  Used to indicate that a camera is used for rendering VR (in edit mode) in the Editor.
        VR = 8,

        /*
            Used to indicate a camera that is used for rendering reflection probes.
            这个 camera 用来渲染 反射探针的;
        */
        Reflection = 16
    }
}

