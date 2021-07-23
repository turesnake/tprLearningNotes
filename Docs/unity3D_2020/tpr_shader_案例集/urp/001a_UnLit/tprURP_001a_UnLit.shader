// 最简单的 shader, 将几何体 涂上一种单一的颜色 (可以是 shader 内设置, 也可以从 Material inspector 中获得)

Shader "tpr/tprURP_001a_UnLit"
{
    Properties
    {
        [MainColor] _BaseColor("Color", Color) = (1, 1, 1, 1) // 颜色来源之一
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


            struct Attributes{
                float4 posOS : POSITION;
            };

            struct Varyings{
                float4 posHCS : SV_POSITION;
            };

            Varyings vert( Attributes i ){
                Varyings o;
                o.posHCS = TransformObjectToHClip( i.posOS.xyz );
                return o;
            }


            half4 frag( Varyings i ) : SV_Target{
                //half4 color = half4( 0.2, 0.4, 0, 1 );
                half4 color = half4( _BaseColor.xyz, 1 );
                return color;
            }

            ENDHLSL
        }
    }


}
