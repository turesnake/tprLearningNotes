/*
    绘制 dst mesh
*/
Shader "tpr/DstDraw"
{
    Properties
    {
    }



    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline"}

        Pass
        {
            Name "Grass" 

            Cull Back //use default culling because this shader is billboard 
            ZTest Less
            ZWrite On // tpr 
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // -------------------------------------
            // Universal Render Pipeline keywords
            // When doing custom shaders you most often want to copy and paste these #pragmas
            // These multi_compile variants are stripped from the build depending on:
            // 1) Settings in the URP Asset assigned in the GraphicsSettings at build time
            //       e.g If you disabled AdditionalLights in the asset then all _ADDITIONA_LIGHTS variants will be stripped from build
            // 2) Invalid combinations are stripped. e.g variants with _MAIN_LIGHT_SHADOWS_CASCADE but not _MAIN_LIGHT_SHADOWS are invalid and therefore stripped.

            //#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            //#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE

            //#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            //#pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS

            //#pragma multi_compile _ _SHADOWS_SOFT

            // -------------------------------------
            // Unity defined keywords
            //#pragma multi_compile_fog
            // -------------------------------------

            // 必须支持 SV_InstanceID input system value
            #pragma require instancing


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            

            struct Attributes
            {
                float4 positionOS   : POSITION;
            };

            struct Varyings
            {
                float4 positionCS  : SV_POSITION;
                half3 color        : COLOR;
            };

            // 需符合 4x4-bytes 字节对齐:
            struct Vertex
            {
                float4 pos;
            };

            CBUFFER_START(UnityPerMaterial)

                StructuredBuffer<Vertex> _VertexBuffer;

            CBUFFER_END





           
            Varyings vert(Attributes IN, uint id : SV_VertexID)
            {
                Varyings OUT = (Varyings)0;


                float3 posOS = _VertexBuffer[id].pos.xyz;
                float3 positionWS = posOS;

                OUT.positionCS = TransformWorldToHClip(positionWS);


                OUT.color = float3( 0, 0, 1 );

                return OUT;
            }




            half4 frag(Varyings IN) : SV_Target
            {
                return half4(IN.color,1);
            }



            ENDHLSL
        }

        //copy pass, change LightMode to ShadowCaster will make grass cast shadow
        //copy pass, change LightMode to DepthOnly will make grass render into _CameraDepthTexture
    }
}