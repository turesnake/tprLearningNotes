// 显示模型的 法线信息
//
Shader "Unlit/tpr_001_uv_color"
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
                fixed4 c = 0;
                c.rgb = i.worldNormal*0.5 + 0.5;
                    // 将每个分量，从 [-1.0,1.0] -> [0.0,1.0]
                return c;
            }
            ENDCG
        }
    }
}
