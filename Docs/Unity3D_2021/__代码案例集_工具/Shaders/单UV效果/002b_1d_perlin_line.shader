

Shader "TPR/record1"
{

    Properties
    {
        // 1: One
        [Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend("Src Blend", float) = 1
        [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend("Dst Blend", float) = 1
    }


    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Transparent"
            "Queue"     = "Transparent"
        }

        LOD 100


        Blend [_SrcBlend] [_DstBlend]
        ZTest   Always
        ZWrite  Off
		Cull    Off

        Pass
        {
            Name "tpr_unlit" 

            HLSLPROGRAM

            #pragma vertex      vert 
            #pragma fragment    frag 
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"


            //TEXTURE2D(_TargetTex);  SAMPLER(sampler_TargetTex);
            #define PI     3.1415926
            #define TWO_PI 6.2831852

            CBUFFER_START(UnityPerMaterial)
                //...
            CBUFFER_END


            struct Attributes
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
            };


            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD1;
            };


            // ================================================================================= // 

            // x 在区间[t1,t2] 中, 求区间[s1,s2] 中同比例的点的值;
            float remap( float t1, float t2, float s1, float s2, float x )
            {
                return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
            }


            //  1 out, 1 in...
            float hash11(float p)
            {
                p = frac(p * .1031);
                p *= p + 33.33;
                p *= p + p;
                return frac(p);
            }
            
            
           
            // ================================================================================= // 

            Varyings vert( Attributes input )
            {
                Varyings output = (Varyings)0;
                output.positionHCS = TransformObjectToHClip( input.vertex.xyz ); 
                output.uv = input.uv;
                return output;
            }


            float4 frag( Varyings input ) : SV_Target
            {

                float time = _Time.y % 1000; // 约束精度;
                time *= 5;
                float2 uv = input.uv;
                float2 pos = uv * 12;

                // ------------------------------------------ // 

                float t = pos.x + 99.5;

                float h1 = hash11( floor(t) ); //[0,1]
                float h2 = hash11( ceil(t) );  //[0,1]
                float k = remap( 0, 1, h1, h2, smoothstep( 0,1, frac(t) ) ); //[0,1]


                float offset = abs( uv.y - k);
                float c = (offset<0.01) ? 0.9 : 0; // 画出曲线

                return float4( c, c, c, 1 );


            }

            ENDHLSL
        }
    }


}
