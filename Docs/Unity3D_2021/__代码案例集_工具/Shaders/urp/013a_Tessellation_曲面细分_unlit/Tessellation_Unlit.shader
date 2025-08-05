/*
    urp hlsl 格式下, 最简单的 Tessellation 曲面细分 shader;

    todo: 没支持 shadow 等其它 pass

*/
Shader "tpr/tessellation_unlit"
{
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {} // 颜色 texture, 其实相关性不大

        _TessellationEdgeLength("Tessellation Edge Length", Range(5, 500)) = 50.0 // 曲面细分条件, 大致对应 三角形边长在屏幕空间的像素长度
        
        // Noise 3D 表现:
        _VolumeTex("Volume Texture", 3D) = "" {}  // 3D texture 
        _Move("_Move", Vector) = (1, 1, 1, 0)  // uv3d 运动
        _NoiseScale("_NoiseScale", Float) = 1.0 // 噪声尺寸
        _Amplitude("_Amplitude", Float) = 1.0 // 震幅
    }

    SubShader
    {
        Tags{
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 300

        Pass
        {

            Name "tpr_texture_color"

            HLSLPROGRAM

            #pragma target 4.6

            #pragma vertex MyTessellationVertexProgram 
            #pragma hull MyHullProgram
			#pragma domain MyDomainProgram
            #pragma fragment frag 

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            

            // 声明一个 texture sampler pair
            TEXTURE2D( _BaseMap );   SAMPLER( sampler_BaseMap );
            TEXTURE3D(_VolumeTex);   SAMPLER(sampler_VolumeTex);

            // 为支持 SRP Batcher 功能, 所有 material properties 都要被整合进 cbuffer 中
            // 参数是 cbuffer 的名字
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                float _TessellationEdgeLength;
                //--
                float4 _Move;
                float _NoiseScale;
                float _Amplitude;
            CBUFFER_END


            
            struct VertexData
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
            };


            struct InterpolatorsVertex
            { 
                float4 posHCS : SV_POSITION;
                float2 uv     : TEXCOORD0;
            };


            #include "Tessellation.hlsl"


            half4 frag( InterpolatorsVertex i ) : SV_Target
            {       
                half4 color = SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, i.uv );   
                return color;
            }


            ENDHLSL
        }
    }


}