// 如何从一个 3d texture 文件上采样
Shader "tpr/showNoise3D"
{
    Properties
    {
        _VolumeTex("Volume Texture", 3D) = "" {}  // 3D texture 
        _NoiseScale("_NoiseScale", Float) = 1.0
        _Move("_Move", Vector) = (1, 1, 1, 0)
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
            TEXTURE3D(_VolumeTex);   SAMPLER(sampler_VolumeTex);

            float _NoiseScale;
            float4 _Move;


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
                float3 posOS : TEXCOORD1;
            };


            Varyings vert( Attributes i )
            {
                Varyings o;
                o.posHCS = TransformObjectToHClip( i.posOS.xyz );


                // !!! VS 中可以采样, 但需要使用 LOD 版本的采样函数;

                // #define TRANSFORM_TEX(tex, name) ((tex.xy) * name##_ST.xy + name##_ST.zw)

                // 将顶点的  2D uv值 (参数i.uv) 施加上 _BaseMap_ST 的影响 (texture: tiling 和 offset 值)
                // 返回顶点的 调整过的 uv 值
                // 此宏的目的仅仅是 施加 "tex"_ST 的修正
                // 如果你的 texture 未设置 tiling 和 offset 修正, 可以不用调用此宏
                o.uv = TRANSFORM_TEX( i.uv.xy, _BaseMap );
                o.posOS = i.posOS.xyz;
                return o;
            }



            float4 frag( Varyings i ) : SV_Target
            {
                // 一个不断运动的 uv3D:
                float3 uv3D = i.posOS.xyz;
                float3 flowUV = uv3D / _NoiseScale + _Time.x * _Move.xyz;

                // 采样 3D texture;
                float3 noise = SAMPLE_TEXTURE3D(_VolumeTex, sampler_VolumeTex, flowUV).xyz; 

                float4 color = 1;
                color.rgb = noise;
                return color;
            }


            ENDHLSL
        }
    }


}