

Shader "TPR/show histogram"
{

    Properties
    {
        
    }


    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType"    = "Transparent"
            "Queue"         = "Transparent"
        }

        LOD 100


        Blend   One Zero
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


            CBUFFER_START(UnityPerMaterial)

                // compute shader 准备的 128 个元素, 
                StructuredBuffer<uint> _HistogramData; 
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
                float4 positionNDC  : TEXCOORD2;
            };


            // ================================================================================= // 

            // x 在区间[t1,t2] 中, 求区间[s1,s2] 中同比例的点的值;
            float remap( float t1, float t2, float s1, float s2, float x )
            {
                return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
            }

            float Luminance_2(float3 linearRgb)
            {
                return dot(linearRgb, float3(0.2126729, 0.7151522, 0.0721750));
                //return dot(linearRgb, float3(0.299, 0.587, 0.114));
            }

            float Gamma22ToLinear(float c)
            {
                return PositivePow(c, 2.2);
            }

            float LinearToGamma22(float c)
            {
                return PositivePow(c, 0.454545454545455);
            }


           
            // ================================================================================= // 

            Varyings vert( Attributes input )
            {
                Varyings output = (Varyings)0;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.vertex.xyz);
                output.positionHCS = vertexInput.positionCS;
                output.positionNDC = vertexInput.positionNDC;
                output.uv = input.uv;
                return output;
            }


            float4 frag( Varyings input ) : SV_Target
            {
                //float t = _Time.y % 1000; // 约束精度;
                float2 posSS = input.positionNDC.xy / input.positionNDC.w; // [0,1]
        
                //float2 uv = posSS; // 直接使用屏幕空间pos. 
                float2 uv = input.uv;


                int id = (int)floor(uv.x * 128);
                //int id = (int)floor(uv.x * 64);

                float val = (float)_HistogramData[id]; // [0,255] 上限可能很高,..... 假设为 20000
                val = saturate(val/15000); // [0,1]


                float c = lerp( 0, 0.6, smoothstep( -0.01, 0.01, uv.y-val ) );

                return float4( c, c, c, 1 );
                
            }

            ENDHLSL
        }
    }


}
