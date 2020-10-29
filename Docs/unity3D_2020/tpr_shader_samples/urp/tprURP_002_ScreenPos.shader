// 将屏幕空间 所有像素，映射为一个 [0,1] 的区间 [left-bottom]
// 非常实用的技术，可以做各种 debug 测试
// ---
// 两种方法的 效果 是一摸一样的 
Shader "tpr/tprURP_002_ScreenPos"
{
    Properties{}
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "RenderPipeline"="UniversalPipeline" // urp 才会用到
        }
        LOD 100
        
        //--------------// 
        //  方法1
        // 最简单的实现，但存在缺陷，frag 的参数受到了限制
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            // 包含 hlsl 常用变量和宏，
            // 也 include 了其它 .hlsl 文件。
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Debug.hlsl" 
            #include "tpr_Debug.hlsl"


            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip( v.vertex.xyz );       
                return o;
            }

            // 缺点，限制了参数
            float4 frag ( float4 sp : VPOS ) : SV_Target
            {
                float2 posSS = sp.xy / _ScreenParams.xy; // [0,1]
                return float4( posSS, 0.0, 1.0 );
            }

            ENDHLSL
        }
        


        //--------------// 
        //  方法2
        // 使用 ComputeScreenPos() 函数，Core.hlsl
        // 更好的版本
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            // 包含 hlsl 常用变量和宏，
            // 也 include 了其它 .hlsl 文件。
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Debug.hlsl" 
            #include "tpr_Debug.hlsl"


            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 posSS : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip( v.vertex.xyz );  
                o.posSS = ComputeScreenPos( o.pos ); // Core.hlsl
                return o;
            }

            // 缺点，限制了 参数
            float4 frag ( v2f i ) : SV_Target
            {
                float2 wcoord = i.posSS.xy / i.posSS.w; // 延迟的 齐次除法
                return float4( wcoord, 0.0, 1.0 );
            }

            ENDHLSL
        }

    }
}