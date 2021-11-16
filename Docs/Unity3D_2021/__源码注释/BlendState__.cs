#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Values for the blend state.

        最多可以存储 8 个 render target 的 blend states

    */
    public struct BlendState : IEquatable<BlendState>
    {
        //
        // 摘要:
        //     Creates a new blend state with the specified values.
        //
        // 参数:
        //   separateMRTBlend:
        //     Determines whether each render target uses a separate blend state.
        //
        //   alphaToMask:
        //     Turns on alpha-to-coverage.
        public BlendState(bool separateMRTBlend = false, bool alphaToMask = false);

        
        // 摘要:
        //     Default values for the blend state.
        public static BlendState defaultValue { get; }


        // 摘要:
        //     Blend state for render target #.
        public RenderTargetBlendState blendState7 { get; set; }
        public RenderTargetBlendState blendState6 { get; set; }
        public RenderTargetBlendState blendState5 { get; set; }
        public RenderTargetBlendState blendState4 { get; set; }
        public RenderTargetBlendState blendState3 { get; set; }
        public RenderTargetBlendState blendState2 { get; set; }
        public RenderTargetBlendState blendState1 { get; set; }
        public RenderTargetBlendState blendState0 { get; set; }


        /*
            摘要:
            Turns on "alpha-to-coverage".

            这是一个 抗锯齿技术, 可在笔记中查找此关键词
        */
        public bool alphaToMask { get; set; }


        /*
            摘要:
            Determines whether each render target uses a separate blend state.

            若为 true:      每个 render target 使用各自的 blend states
            若为 false:     所有 render targte 都是用 blendState0;
        */
        public bool separateMRTBlendStates { get; set; }

        

        public override bool Equals(object obj);
        public bool Equals(BlendState other);
        public override int GetHashCode();

        public static bool operator ==(BlendState left, BlendState right);
        public static bool operator !=(BlendState left, BlendState right);
    }
}

