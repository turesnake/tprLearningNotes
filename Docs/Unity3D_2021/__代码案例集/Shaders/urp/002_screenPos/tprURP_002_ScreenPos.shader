// 将屏幕空间 所有像素，映射为一个 [0,1] 的区间 [left-bottom]
// 非常实用的技术，可以做各种 debug 测试
// 
//    目前罗列了 四种方法:
//    具体原理可查找: "如何获得像素的 posSS 屏幕空间坐标"
//  
//
Shader "tpr/tprURP_002_ScreenPos"
{
    Properties{}
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "RenderPipeline"="UniversalPipeline" // Must have in urp
        }
        LOD 100
        
        // ========================== // 
        //         -方法-1-
        // ========================== // 

        // 最简单的实现，但存在缺陷，frag 的参数受到了限制
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            // 包含 hlsl 常用变量和宏，
            // 也 include 了其它 .hlsl 文件。
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Debug.hlsl" 
            #include "tpr_Debug.hlsl"


            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 posHCS : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.posHCS = TransformObjectToHClip( v.vertex.xyz );       
                return o;
            }

            // 缺点，限制了参数
            float4 frag ( float4 sp : VPOS ) : SV_Target
            {
                float2 posSS = sp.xy / _ScreenParams.xy; // [0,1]
                return float4( posSS, 0.0, 1.0 );
            }

            ENDHLSL
        }
        


        // ========================== // 
        //        -方法- 2,3,4-
        // ========================== // 

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert_1
            #pragma fragment frag_1

            // 包含 hlsl 常用变量和宏，
            // 也 include 了其它 .hlsl 文件。
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Debug.hlsl" 
            #include "tpr_Debug.hlsl"


            struct appdata
            {
                float4 vertex : POSITION;
            };


            // ========================== // 
            //         -方法-2-
            // ========================== // 
            // --- 8.2.0 --- //
            // ComputeScreenPos 在 11.0 中已经是个 废弃函数

            struct v2f_2
            {
                float4 posHCS : SV_POSITION;
                float4 posSS : TEXCOORD0;
            };
             
            v2f_2 vert_2 (appdata v)
            {
                v2f_2 o;
                o.posHCS = TransformObjectToHClip( v.vertex.xyz ); 
                // 函数以废弃
                o.posSS = ComputeScreenPos( o.posHCS ); // 8.2.0 版本中, 位于Core.hlsl
                return o;
            }


            float4 frag_2 ( v2f_2 i ) : SV_Target
            {
                float2 uvSS = i.posSS.xy / i.posSS.w; // 延迟的 齐次除法
                return float4( uvSS, 0.0, 1.0 );
            }



            // ========================== // 
            //         -方法-3-
            // ========================== //
            // --- 11.0 --- // 

            struct v2f_3
            {
                float4 posHCS : SV_POSITION;
                float4 posNDC : TEXCOORD2;
            };

            v2f_3 vert_3 (appdata v)
            {
                v2f_3 o;
                o.posHCS = TransformObjectToHClip( v.vertex.xyz ); 

                // GetVertexPositionInputs 函数一口气生成好 vertex 需要的所有 pos: WS, VS, HCS, NDS
                o.posNDC = GetVertexPositionInputs(i.posOS).positionNDC; // 位于 ShaderVariablesFunctions.hlsl

                return o;
            }


            float4 frag_3 ( v2f_3 i ) : SV_Target
            {
                float2 uvSS = i.posNDC.xy / i.posNDC.w; // 延迟的 齐次除法
                return float4( uvSS, 0.0, 1.0 );
            }


            // ========================== // 
            //         -方法-4-
            // ========================== //
            // --- 11.0 --- // 

            struct v2f_4
            {
                float4 posHCS : SV_POSITION;
                float3 posNDC : TEXCOORD2;
            };

            v2f_4 vert_4 (appdata v)
            {
                v2f_4 o;
                o.posHCS = TransformObjectToHClip( v.vertex.xyz ); 

                // 此函数的参数 要先把 w项除掉
                // 这是因为 这个函数的 源码存在 bug 
                o.posNDC = ComputeNormalizedDeviceCoordinatesWithZ( o.posHCS.xyz/ o.posHCS.w );
          
                return o;
            }


            float4 frag_4 ( v2f_4 i ) : SV_Target
            {
                
                float2 uvSS = i.posNDC.xy; // 延迟的 齐次除法
                return float4( uvSS, 0.0, 1.0 );
            }


            ENDHLSL
        }

    }
}