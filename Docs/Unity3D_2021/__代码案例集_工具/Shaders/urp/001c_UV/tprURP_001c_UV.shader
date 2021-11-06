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
               

                float3 color = float3( 0,0,0 );

                // =============================== // 
                //              -1-
                // ------------------------------- //
                // 直接打印 法线信息, 部分角度的 法线分量为负数, 此时会呈现出 黑色
                //color = i.normalWS;

                // =============================== // 
                //              -2-
                // ------------------------------- //
                // 改良版, 所有角度都被映射到颜色了
                // 这一版是存在问题的, 因为被插值后的法线, 其实已经不是 归一化的了
                color = i.normalWS * 0.5 + 0.5;

                // =============================== // 
                //              -3-
                // ------------------------------- //
                // 可用来检测和显示 法线是否是 归一化的.
                // 黑色表示 归一化了, 灰色白色表示 没有归一化.
                // 将此段代码用于 unity 自带的球体上,会看到一个个 黑网格
                //color = abs(length(i.normalWS) - 1.0) * 10.0;

                
                return float4( color, 1.0 );
            }

            ENDHLSL
        }

    }
}