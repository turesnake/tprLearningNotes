//  依赖 depth only pass，显示 z-buffer 信息
// 
Shader "Unlit/tprURP_003_Z_Buffer"
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
            "LightMode" = "UniversalForward"
        }

        LOD 100
        
        //--------------// 
        // 依赖 depth only pass，显示 z-buffer 信息
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"


            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
                half _Cutoff;
            CBUFFER_END


            struct appdata
            {
                float4 positionOS : POSITION;
            };
            
            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float4 positionSS : TEXCOORD0; // screen space 
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip( v.positionOS.xyz );  
                o.positionSS = ComputeScreenPos( o.positionCS );
                return o;
            }

            float4 frag ( v2f i ) : SV_Target
            {
                float2 uv = i.positionSS.xy/i.positionSS.w;
                
                // 两种写法都有效
                // <-1->
                float depth = SampleSceneDepth( uv );
                // <-2->
                //float depth = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, uv).r;

                float ldepth = Linear01Depth( depth, _ZBufferParams );

                return float4( ldepth, ldepth, ldepth, 1.0 );
            }
            ENDHLSL
        }


        //--------------// 
        // depth only pass
        // 直接借用现成的，不做修改
        Pass
        {
            Tags{"LightMode" = "DepthOnly"}

            ZWrite On
            ZTest LEqual
            Cull[_Cull]

            ZWrite On
            ColorMask 0
            Cull[_Cull]

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0

            #pragma vertex DepthOnlyVertex
            #pragma fragment DepthOnlyFragment

            // -------------------------------------
            // Material Keywords
            #pragma shader_feature _ALPHATEST_ON
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            // 这部分可以被封装为一个 "Input.hlsl" 文件
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseMap_ST;
                half4 _BaseColor;
                half _Cutoff;
            CBUFFER_END

            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"

            ENDHLSL
        }
        

    }
}

