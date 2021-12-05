#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        This enum describes what should be done on the render target when it is activated (loaded).

        When the GPU starts rendering into a render target, 
        this setting specifies the action that should be performed on the existing contents of the surface. 

        Tile-based GPUs may get performance advantage if the load action is "Clear" or "DontCare". 
        用户要尽可能避免使用 "RenderBufferLoadAction.Load";
        
        Please note that not all platforms have load/store actions, so this setting might be ignored at runtime. 
        Generally mobile-oriented graphics APIs (OpenGL ES, Metal) take advantage of these settings.
        ---

        当激活了一个 render target, 该如何处理它的旧数据; 是要加载这些旧数据, 还是清除它们, 还是彻底无视之;
    */
    public enum RenderBufferLoadAction//RenderBufferLoadAction__
    {
        /*
            When this RenderBuffer is activated, preserve the existing contents of it. This
            setting is expensive on tile-based GPUs and should be avoided whenever possible.

            保留 renderBuffer 中的旧数据, 此操作对于 tile-based GPUs 来说很昂贵, 要尽可能避免使用;
        */
        Load = 0,

        /*
            Upon activating the render buffer, clear its contents. 
            Currently only works together with the RenderPass API.

            将 render buffer 中的数据彻底删除; 
        */
        Clear = 1,

        /*
            When this RenderBuffer is activated, the GPU is instructed not to care about
            the existing contents of that RenderBuffer. On tile-based GPUs this means that
            the RenderBuffer contents do not need to be loaded into the tile memory, providing
            a performance boost.

            彻底不关心 renderBuffer 中的旧数据;

            对于 tile-based GPUs 来说, 旧数据不需要被加载进 "tile memory", 能提高性能;
        */
        DontCare = 2
    }
}

