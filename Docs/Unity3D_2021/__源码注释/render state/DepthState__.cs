#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Values for the depth state.

        Use this with RenderStateBlock and ScriptableRenderContext.DrawRenderers() 
        to override the GPU's render state.

        本类内容相当于 shader 中的:
            -- ZTest
            -- ZWrite
        

    */
    public struct DepthState : IEquatable<DepthState>
    {
        
        public DepthState(
            bool writeEnabled = true, 
            CompareFunction compareFunction = CompareFunction.Less 
        );

        
        // 摘要:
        //     Default values for the depth state.
        public static DepthState defaultValue { get; }

        /*
            摘要:
            Controls whether pixels from this object are written to the depth buffer.

            用于 ZWrite 指令
        */
        public bool writeEnabled { get; set; }

        /*
            摘要:
            How should depth testing be performed.

            用于 ZTest 指令
        */
        public CompareFunction compareFunction { get; set; }



        public bool Equals(DepthState other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(DepthState left, DepthState right);
        public static bool operator !=(DepthState left, DepthState right);
    }
}
