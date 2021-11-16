#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        A set of values that Unity uses to override the GPU's "render state".

        "render state":
            就是 shader 中设定的:
                -- blend src dst;
                -- blend op
                -- cull
                -- ZClip
                -- Offset
                -- Conservative
            等配置指令;
        
        现在我们可以在 cpu 脚本端 设置这些数据, 并且覆写 gpu 中的设置;
        (猜测 是覆写 那些写在 shader 中的配置)


        当你正在调用 ScriptableRenderContext.DrawRenderers() 时, 你可使用本类实例作为参数,
        去覆写 部分/全部 物体的 render state;

        注意:
            必须要设置 本类的 mask 成员, to tell Unity which parts of the "render state" to override to apply. 
            比如, 若想使用  blendState 中的值, 那么 mask 中就必须包含 RenderStateMask.Blend;

            注意, 这样做还不能完全设置 blendState, 但是 mask 必须包含 RenderStateMask.Blend;
            这样, 覆写才会发生;

    */
    public struct RenderStateBlock : IEquatable<RenderStateBlock>
    {
        /*
            摘要:
            Creates a new render state block with the specified mask.

            All states are initialized to their default values.
            
            参数:
            mask:
                Specifies which parts of the render state that is overriden.
        */
        public RenderStateBlock(RenderStateMask mask);

        
        // 摘要:
        //     Specifies the new blend state.
        public BlendState blendState { get; set; }
        
        // 摘要:
        //     Specifies the new raster state.
        public RasterState rasterState { get; set; }
        
        // 摘要:
        //     Specifies the new depth state.
        public DepthState depthState { get; set; }
        
        // 摘要:
        //     Specifies the new stencil state.
        public StencilState stencilState { get; set; }
        

        //  就是 stencil test 中的那个 Ref 值
        public int stencilReference { get; set; }

        
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