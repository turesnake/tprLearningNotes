// 从 Material inspector 端提供一个 常规 texture, 提供固有颜色值
// 学习 texture 的绑定 和 采样

Shader "tpr/tprURP_001b_texture_color"
{
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" // 目标 texture
    }

    SubShader
    {
        Tags{
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 100

        Pass
        {

            Name "tpr_texture_color"

            HLSLPROGRAM

            #pragma vertex vert 
            #pragma fragment frag 

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // 声明一个 texture sampler pair
            TEXTURE2D( _BaseMap );   SAMPLER( sampler_BaseMap );

            // 为支持 SRP Batcher 功能, 所有 material properties 都要被整合进 cbuffer 中
            // 参数是 cbuffer 的名字
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
            CBUFFER_END


            struct Attributes{
                float4 posOS : POSITION;
                float2 uv    : TEXCOORD0;
            };

            struct Varyings{
                float4 posHCS : SV_POSITION;
                float2 uv     : TEXCOORD0;
            };


            Varyings vert( Attributes i ){
                Varyings o;
                o.posHCS = TransformObjectToHClip( i.posOS.xyz );


                // #define TRANSFORM_TEX(tex, name) ((tex.xy) * name##_ST.xy + name##_ST.zw)

                // 将顶点的  2D uv值 (参数i.uv) 施加上 _BaseMap_ST 的影响 (texture: tiling 和 offset 值)
                // 返回顶点的 调整过的 uv 值
                // 此宏的目的仅仅是 施加 "tex"_ST 的修正
                // 如果你的 texture 未设置 tiling 和 offset 修正, 可以不用调用此宏

                o.uv = TRANSFORM_TEX( i.uv, _BaseMap );
                return o;
            }


            half4 frag( Varyings i ) : SV_Target{

                // SAMPLE_TEXTURE2D 宏 在每个平台的 include .hlsl 文件中都被单独定义了一次
                // 比如在: 
                //      D3D11.hlsl
                //      GLCore.hlsl
                //      GLES3.hlsl
                //      Metal.hlsl
                // 等文件中
                // 但实际上, 它也只是另一个函数的封装, 就是做一次常规的 采样 操作
                half4 color = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, i.uv );
                return color;
            }

            ENDHLSL
        }
    }


}