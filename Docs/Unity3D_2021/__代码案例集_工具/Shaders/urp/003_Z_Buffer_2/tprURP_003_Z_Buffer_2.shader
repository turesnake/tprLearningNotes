// 显示 z-buffer 信息
// 不过这个实现 不依赖于前置的 depth only pass
// ---
// 这个方法只能用来 验证 depth 信息的 实现过程，并不具备多少实际意义
// 之所以需要 depth-buffer，本质上是为了获得 “全局信息”
// 光凭 frag() 无法得知相邻像素的信息，
// 但如果我们事先通过一个 pass，将必要信息存储在一个 texture 中
// 那么这个限制就被突破了：
// 任何 frag 都可以通过 向 texture 采样，来获得 相邻区域的 信息
// 以此来实现各种效果
// 
Shader "Unlit/tprURP_003_Z_Buffer_2"
{
    Properties{
        [MainTexture] _BaseMap("Base Map (RGB) Smoothness / Alpha (A)", 2D) = "white" {}
        [MainColor]   _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _Cutoff("Alpha Clipping", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "RenderPipeline"="UniversalPipeline" // Must have in urp
            //"LightMode" = "UniversalForward"
        }

        LOD 100
        
        //--------------// 
        // 依赖 shadow casterpass，显示 z-buffer 信息
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityInput.hlsl"


            struct appdata
            {
                float4 positionOS : POSITION;
            };
            

            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float  depth : TEXCOORD0; // camera depth
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip( v.positionOS.xyz );  

                // 实现方法 和 builtin 一致
                float3 positionWS = TransformObjectToWorld(v.positionOS.xyz);
                o.depth = - TransformWorldToView(positionWS).z * _ProjectionParams.w;

                return o;
            }


            float4 frag ( v2f i ) : SV_Target
            {
                return float4( i.depth, i.depth, i.depth, 1.0 );
            }

            ENDHLSL
        }


    }
}


