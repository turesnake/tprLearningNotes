#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    
    // 摘要:
    //     Used by CommandBuffer.SetShadowSamplingMode.
    public enum ShadowSamplingMode
    {
        
        // 摘要:
        //      Default shadow sampling mode: sampling with a comparison filter.

        //      此时,
        //          texture, sampler 声明方式: UNITY_DECLARE_SHADOWMAP(_Shadowmap);
        //          采样格式: UNITY_SAMPLE_SHADOW(_Shadowmap, half3(uv, depth_for_comparison));
        //      注意, 都是 built-in管线的 宏...
        CompareDepths = 0,
        
        // 摘要:
        //     Shadow sampling mode for sampling the depth value.

        //      此时,
        //          texture, sampler 声明方式: sampler2D _Shadowmap;
        //          采样格式: tex2D(_Shadowmap, uv).r;.
        //      感觉都是 hlsl 原生指令...
        RawDepth = 1,
        
        // 摘要:
        //     In ShadowSamplingMode.None, depths are not compared. Use this value if a Texture
        //     is not a shadowmap.
        None = 2
    }
}

