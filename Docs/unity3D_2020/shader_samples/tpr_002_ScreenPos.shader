// 依据每个像素点，在 screen 中的位置，呈现不同的颜色
//
Shader "tpr/tpr_002_ScreenPos"
{
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        //--- [1] VPOS ---//
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata{
                float4 vertex : POSITION;
            };
            struct v2f{
                float4 pos : SV_POSITION;
            };        

            // 尽管在这个呈现中，我们并没有真的用上 vert() 传递给 frag() 的数据
            // 但 vert() 仍然是必须的
            // 否则各个 定点 将无法被很好的处理
            v2f vert ( appdata i ){
                v2f o;
                o.pos = UnityObjectToClipPos( i.vertex );
                return o;
            }

            // 参数 VPOS: 
            // 类型为 float4
            // 具体描述参见 《u-入门精要》P-91
            // ------
            // _ScreenParams
            // 记录了 屏幕当前分辨率
            fixed4 frag( float4 sp : VPOS ) : SV_Target{
                return fixed4(
                    sp.xy / _ScreenParams.xy,
                    0.0,
                    1.0
                );
            }

            ENDCG
        }

        //--- [2] ComputeScreenPos ---//
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata{
                float4 vertex : POSITION;
            };
            struct v2f{
                float4 pos : SV_POSITION;
                float4 scrPos : TEXCOORD0;
            };        

            v2f vert ( appdata i ){
                v2f o;
                o.pos = UnityObjectToClipPos( i.vertex );
                o.scrPos = ComputeScreenPos( o.pos );
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{
                float2 wcoord = i.scrPos.xy / i.scrPos.w;
                return fixed4( wcoord, 0.0, 1.0 );
            }

            ENDCG
        }


    }
}
