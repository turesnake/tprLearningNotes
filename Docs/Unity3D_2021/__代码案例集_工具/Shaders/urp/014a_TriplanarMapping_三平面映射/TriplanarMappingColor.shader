/*
    三平面映射采样

*/
Shader "tpr/Triplanar Mapping Color"
{
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" // 目标 texture
        _TextureScale("_TextureScale", Float) = 1.0
        _TriplannarBlendSharpness("_TriplannarBlendSharpness", Float) = 1.0
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
                float _TextureScale;
                float _TriplannarBlendSharpness;
            CBUFFER_END


            struct Attributes{
                float4 posOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float2 uv    : TEXCOORD0;
            };

            struct Varyings{
                float4 posHCS : SV_POSITION;
                float2 uv     : TEXCOORD0;
                //--
                float3  positionOS          : TEXCOORD1;
                float3  normalOS          : TEXCOORD2;
                //--
                float3 positionWS        : TEXCOORD3;
                float3  normalWS          : TEXCOORD4;
            };


            Varyings vert( Attributes input )
            {
                Varyings o;
                // #define TRANSFORM_TEX(tex, name) ((tex.xy) * name##_ST.xy + name##_ST.zw)
                o.uv = TRANSFORM_TEX( input.uv, _BaseMap ); 
                //--
                o.positionWS = TransformObjectToWorld( input.posOS.xyz );
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
                o.normalWS = normalInput.normalWS;  
                //--
                o.posHCS = TransformObjectToHClip( input.posOS.xyz );
                o.positionOS = input.posOS.xyz;
                o.normalOS = input.normalOS;
                return o;
            }


            half4 frag( Varyings input ) : SV_Target
            {

                float3 pos = input.positionWS;
                float2 yUV = pos.xz / _TextureScale;
                float2 xUV = pos.zy / _TextureScale;
                float2 zUV = pos.xy / _TextureScale;

                float3 yDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, yUV );
                float3 xDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, xUV );
                float3 zDiff = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, zUV );

                // 三平面边界过度锐利度
                float3 blendWeights = pow( abs(input.normalOS), _TriplannarBlendSharpness );
                // 此处不能用 normalize(), 否则交界处会出现白边;
                blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);

                float3 color = xDiff * blendWeights.x + yDiff * blendWeights.y + zDiff * blendWeights.z;
                //---
                return float4( color.x, color.y, color.z, 1 );
            }

            ENDHLSL
        }
    }


}