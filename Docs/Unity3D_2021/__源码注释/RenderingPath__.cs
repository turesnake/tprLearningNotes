#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Rendering path of a Camera.

        前向渲染, 延迟渲染 之类的
    */
    public enum RenderingPath//RenderingPath__
    {
        
        //   Use Player Settings.
        //   set in the Player Settings
        UsePlayerSettings = -1,

        /*
            All objects rendered by this camera will be rendered as Vertex-Lit objects.
        */
        VertexLit = 0,

        
        //     Forward Rendering.   前向渲染
        Forward = 1,
        
        //     Deferred Lighting (Legacy). 旧的
        DeferredLighting = 2,


        /*
            Deferred Shading.  延迟渲染

            Due to use of multiple render targets, it requires GPU with MRT support.

            不支持 正交透视模式
        */
        DeferredShading = 3
    }
}

