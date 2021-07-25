#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     A set of values used to override the render state. Note that it is not enough
    //     to set e.g. blendState, but that mask must also include RenderStateMask.Blend
    //     for the override to occur.
    public struct RenderStateBlock : IEquatable<RenderStateBlock>
    {
        //
        // 摘要:
        //     Creates a new render state block with the specified mask.
        //
        // 参数:
        //   mask:
        //     Specifies which parts of the render state that is overriden.
        public RenderStateBlock(RenderStateMask mask);

        //
        // 摘要:
        //     Specifies the new blend state.
        public BlendState blendState { get; set; }
        //
        // 摘要:
        //     Specifies the new raster state.
        public RasterState rasterState { get; set; }
        //
        // 摘要:
        //     Specifies the new depth state.
        public DepthState depthState { get; set; }
        //
        // 摘要:
        //     Specifies the new stencil state.
        public StencilState stencilState { get; set; }
        //
        // 摘要:
        //     The value to be compared against and/or the value to be written to the buffer
        //     based on the stencil state.
        public int stencilReference { get; set; }
        //
        // 摘要:
        //     Specifies which parts of the render state that is overriden.
        public RenderStateMask mask { get; set; }

        public bool Equals(RenderStateBlock other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(RenderStateBlock left, RenderStateBlock right);
        public static bool operator !=(RenderStateBlock left, RenderStateBlock right);
    }
}