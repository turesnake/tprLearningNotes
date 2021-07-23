// 显示最基础的 UV 法线信息
Shader "tpr/tprURP_001c_UV"
{
    Properties{}
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "RenderPipeline"="UniversalPipeline" // Must have in urp
        }
        LOD 100
        
        //--------------// 
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
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
                // 在 catlike 中，此 normal 变量被标注为 VAR_NORMAL 
                // 这似乎是一个 用户自定义的 名字，暂不知其为何起效...
                float3 normalWS   : TEXCOORD0;
                
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip( v.positionOS.xyz );  
                o.normalWS = TransformObjectToWorldNormal( v.normalOS );
                return o;
            }

            float4 frag ( v2f i ) : SV_Target
            {
                float3 normalWS = normalize(i.normalWS); // MUST normalize !!!

                float3 color = normalWS * 0.5 + 0.5;
                //float3 color = normalWS;
                return float4( color, 1.0 );
            }

            ENDHLSL
        }

    }
}