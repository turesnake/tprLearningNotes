// 软粒子的 核心技术:
// 将本 shader 用在一个面片上, 这个面片插入到物体中, 面片和物体相近的地方, 要半透明隐藏起来;
// 
// 方法就是计算 面片 vs深度 [near,far] 和 深度图中的 depth 信息之间的差值;
// 差值越小, 说明越 contact, 越应该半透明隐藏起来;
//

Shader "tpr/tpr_kkkkkkk"
{
    Properties
    {
        [MainColor] _BaseColor("Color", Color) = (1, 1, 1, 1) // 颜色来源之一
    }

    SubShader
    {
        Tags{
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        LOD 100

        Pass
        {

            Name "tpr_unlit"

            HLSLPROGRAM

            #pragma vertex vert 
            #pragma fragment frag 

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // 为支持 SRP Batcher 功能, 所有 material properties 都要被整合进 cbuffer 中
            // 参数是 cbuffer 的名字
            CBUFFER_START(UnityPerMaterial)
                half4  _BaseColor;
            CBUFFER_END


            TEXTURE2D_X_FLOAT(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);


            // --------------------------------------------

            struct Attributes{
                float4 posOS : POSITION;
            };

            struct Varyings{
                float4 posHCS : SV_POSITION;
                float3 posVS : TEXCOORD1;
                float4 posNDC : TEXCOORD2;
            };

            Varyings vert( Attributes i )
            {
                Varyings o;                
                VertexPositionInputs vertexInput = GetVertexPositionInputs(i.posOS.xyz);
                o.posHCS = vertexInput.positionCS;
                o.posNDC = vertexInput.positionNDC; // 位于 ShaderVariablesFunctions.hlsl
                o.posVS = vertexInput.positionVS;
                return o;
            }


            half4 frag( Varyings i ) : SV_Target
            {
                float2 uvSS = i.posNDC.xy / i.posNDC.w; // 延迟的 齐次除法
                //return float4( uvSS, 0.0, 1.0 );

                half depthTex = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, uvSS).r;
                half depth01 = Linear01Depth(depthTex, _ZBufferParams);
                float depth  = LinearEyeDepth(depthTex, _ZBufferParams); // lsc 取出线性视深度,即摄影机空间的z坐标

                float dep_diff = abs(depth + i.posVS.z);
                //float alpha_scale = (dep_diff - 1.0f) / 1.0f;

                float t = dep_diff;
                return float4( t,t,t, 1 );
            }

            ENDHLSL
        }
    }


}
