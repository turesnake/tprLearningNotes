#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        This enum describes what should be done on the render target 
        when the GPU is done rendering into it.

        When the GPU is done rendering into a render target, 
        this setting specifies the action that should be performed on the rendering results. 

        Tile-based GPUs may get performance advantage if the store action is DontCare. 
        For example, this setting can be useful if the depth buffer contents are not needed after rendering the frame.

        Please note that not all platforms have load/store actions, so this setting might be ignored at runtime. 
        Generally mobile-oriented graphics APIs (OpenGL ES, Metal) take advantage of these settings.
        ---

        当 gpu 已经将渲染结果写入 render target 中之后, "我们还需要对 render target 做些什么?"

        "Tile-based GPUs" 的 store action 如果被设置为 "DontCare", 可能会获得性能提高;

    */
    public enum RenderBufferStoreAction//RenderBufferStoreAction__
    {
        /*
            The RenderBuffer contents need to be stored to RAM. 
            If the surface has MSAA enabled, this stores the non-resolved surface.

            非常含糊, 无法准确理解, 是不是指: 
                "将显存中 RenderBuffer 的数据, 写入 RAM(内存) 中"
                但这个理解 和使用场合不符;
            猜测:
                将这个 renderbuffer 中的数据存储下来, 
                (存储在本 texture 中, 或是别的地方, 这里没讲清楚 ), 
                这样就能在下一次激活一个新的 render target 时, 能从它那里 "load" 到这份数据; 
                (这个 loaded render target 需要设置为 "RenderBufferLoadAction.Load" )
        */
        Store = 0,

        /*
            Resolve the (MSAA'd) surface. 
            Currently only used with the RenderPass API.

            非常含糊, 无法准确理解;

            猜测:
                对 renderbuffer 中的数据执行 msaa 运算;
        */
        Resolve = 1,

        /*
            Resolve the (MSAA'd) surface, but also store the multisampled version. 
            Currently only used with the RenderPass API.

            非常含糊, 无法准确理解;

            猜测:
                对 renderbuffer 中的数据执行 msaa 运算; 然后再将这个结果 存储起来;
                (存储在本 texture 中, 或是别的地方, 这里没讲清楚 ), 
                这样就能在下一次激活一个新的 render target 时, 能从它那里 "load" 到这份数据; 
                (这个 loaded render target 需要设置为 "RenderBufferLoadAction.Load" )
        */
        StoreAndResolve = 2,

        /*
            The contents of the RenderBuffer are not needed and can be discarded. 
            Tile-based GPUs will skip writing out the surface contents altogether, providing performance boost.

            渲染结果不被需求, 被 discard;
        */
        DontCare = 3
    }
}

