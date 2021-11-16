#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Values for the "blend state".

        "blend state"
        就是类似 shader 中 blend src, dst; blend op 这种指令 的功能;
        猜测:
            是从 cpu脚本端, 来实现这了 blend 指令的设置工作;
            这样在 shader 端就不需要写了;

    */
    public struct RenderTargetBlendState : IEquatable<RenderTargetBlendState>
    {
        /*
            构造函数,  就是用来配置 本类中的那个 成员的;
        */
        public RenderTargetBlendState(
            ColorWriteMask writeMask = ColorWriteMask.All, 
            BlendMode sourceColorBlendMode = BlendMode.One, 
            BlendMode destinationColorBlendMode = BlendMode.Zero, 
            BlendMode sourceAlphaBlendMode = BlendMode.One, 
            BlendMode destinationAlphaBlendMode = BlendMode.Zero, 
            BlendOp colorBlendOperation = BlendOp.Add, 
            BlendOp alphaBlendOperation = BlendOp.Add
        );

        
        // 摘要:
        //     Default values for the blend state.
        public static RenderTargetBlendState defaultValue { get; }


        /*
            摘要:
            Specifies which color components will get written into the target framebuffer.

            enum:
            -- Alpha = 1,
            -- Blue = 2,
            -- Green = 4,
            -- Red = 8,
            -- All = 15;  Write all components (R, G, B and Alpha).
        */
        public ColorWriteMask writeMask { get; set; }


        // 摘要:
        //     Blend factor used for the color (RGB) channel of the source.
        public BlendMode sourceColorBlendMode { get; set; }

        
        // 摘要:
        //     Blend factor used for the color (RGB) channel of the destination.
        public BlendMode destinationColorBlendMode { get; set; }

        
        // 摘要:
        //     Blend factor used for the alpha (A) channel of the source.
        public BlendMode sourceAlphaBlendMode { get; set; }
        

        // 摘要:
        //     Blend factor used for the alpha (A) channel of the destination.
        public BlendMode destinationAlphaBlendMode { get; set; }
        

        // 摘要:
        //     Operation used for blending the color (RGB) channel.
        public BlendOp colorBlendOperation { get; set; }

        
        // 摘要:
        //     Operation used for blending the alpha (A) channel.
        public BlendOp alphaBlendOperation { get; set; }



        public bool Equals(RenderTargetBlendState other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(RenderTargetBlendState left, RenderTargetBlendState right);
        public static bool operator !=(RenderTargetBlendState left, RenderTargetBlendState right);
    }
}

