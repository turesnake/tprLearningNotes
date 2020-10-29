// 显示模型的 法线信息
//
Shader "tpr/tpr_001_uv_color"
{
    Properties
    {
        // not used
        [NoScaleOffset]_MainTex ("Texture", 2D) = "red" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        //------------------------// 
        //      法线信息 方法:1
        //------------------------// 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f{
                half3 worldNormal : TEXCOORD0;
                float4 pos : SV_POSITION;
            };        

            v2f vert ( appdata i ){
                v2f o;
                o.pos = UnityObjectToClipPos( i.vertex );
                o.worldNormal = UnityObjectToWorldNormal( i.normal );
                    // 简单将 obj-space 法线，转换为 world-space 的法线
                    // normal: float3, [-1.0,1.0]
                return o;
            }

            fixed4 frag ( v2f i ) : SV_Target{
                float3 normalWS = normalize(i.worldNormal);// MUST normalize !!!
                fixed4 c = 0;
                c.rgb = normalWS*0.5 + 0.5;
                    // 将每个分量，从 [-1.0,1.0] -> [0.0,1.0]
                return c;
            }
            ENDCG
        }


        //------------------------// 
        //      法线信息 方法:2
        //------------------------// 
        // 其实和 方法1 没啥本质区别
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata{
                // 用模型空间的 顶点坐标，来填充 vertex
                float4 vertex : POSITION;
                // 用模型空间的 法线方向向量，填充 normal
                // 每个分量的范围 [-1.0, 1.0]
                float3 normal : NORMAL;
            };


            struct v2f{
                float4 pos : SV_POSITION;
                fixed3 color : COLOR0;
            };        

            v2f vert ( appdata v ){
                v2f o;
                o.pos = UnityObjectToClipPos( v.vertex );
                // 把 normal 向量，每个分量的取值范围，
                // 从 [-1.0, 1.0] 映射为 [0.0, 1.0]
                // 注意，这个实现中，法线数据 是 模型空间的 法线
                // 而不是 世界空间的
                // 想要转换，需要 UnityObjectToWorldNormal 函数
                o.color = v.normal * 0.5 + fixed3( 0.5, 0.5, 0.5 );
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{
                return fixed4(
                    i.color,
                    1.0
                );
            }

            ENDCG
        }


        //------------------------// 
        //      切线   Tangent
        //      副法线 Binormal
        //------------------------// 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                    // tangent.xyz 是个单位向量，指向 UV坐标系的 U轴
                    // tangent.w   要么是 -1， 要么是 1
            };

            struct v2f{
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };        

            v2f vert ( appdata v ){
                v2f o;
                o.pos = UnityObjectToClipPos( v.vertex );

                //-- tangent --//
                //o.color = v.tangent * 0.5 + fixed4( 0.5, 0.5, 0.5, 0.5 );

                //-- binormal --//
                float3 binormal = cross( v.normal, v.tangent.xyz ) * v.tangent.w;
                    // 切线空间 TBN空间
                    // tangent.w 要么是 -1, 要么是 1，用来调整 binormal 的方向
                o.color.xyz = binormal * 0.5 + 0.5;
                    // 将分量从 [-1.0,1.0] 映射为 [0.0,1.0]
                o.color.w = 1.0;
                
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{
                return i.color;
            }

            ENDCG
        }




    }
}
