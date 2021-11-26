#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     This enum describes what should be done on the render target when the GPU is
    //     done rendering into it.
    public enum RenderBufferStoreAction//RenderBufferStoreAction__RR
    {
        //
        // 摘要:
        //     The RenderBuffer contents need to be stored to RAM. If the surface has MSAA enabled,
        //     this stores the non-resolved surface.
        Store = 0,
        //
        // 摘要:
        //     Resolve the (MSAA'd) surface. Currently only used with the RenderPass API.
        Resolve = 1,
        //
        // 摘要:
        //     Resolve the (MSAA'd) surface, but also store the multisampled version. Currently
        //     only used with the RenderPass API.
        StoreAndResolve = 2,
        //
        // 摘要:
        //     The contents of the RenderBuffer are not needed and can be discarded. Tile-based
        //     GPUs will skip writing out the surface contents altogether, providing performance
        //     boost.
        DontCare = 3
    }
}

