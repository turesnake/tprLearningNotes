// 
// 将 z-buffer 信息呈现出来
// 首先依赖一条 shadow caster pass 来生成 z-buffer 数据
// 然后在 主 pass 中，根据 screenPos->uv 来针对 z-buffer 采样
// 最后将采样数据 写到 mesh 表面上
// 如果最终的画面 全黑 or 全白，尝试缩小 camera 的 near-far 间距
// 使其正好覆盖 scene 中的所有 meshs
//
// ---
// 上述描述不够精确：在 urp 中，是依赖 DepthOnly pass 来实现 camera depth buffer 的写入工作的
// 为什么在 builtin 中，是 shadow caster pass ?
// 
Shader "tpr/tpr_008_Z_Buffer"
{
    Properties{}
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

            // 变相等于使用了 sampler2D
            UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthTexture);

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 scrPos : TEXCOORD0;
            };

            v2f vert ( appdata_base v )
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.scrPos = ComputeScreenPos( o.pos ); 
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {

                // --- <1> ---
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.scrPos.xy/i.scrPos.w );


                // --- <2> ---
                // SAMPLE_DEPTH_TEXTURE_PROJ
                //     本质就是使用 tex2Dproj
                //
                // tex2Dproj
                //     和 常规的 tex2D 的区别在于
                //     在正式采样之前，tex2Dproj 会主动执行 uv.xy/uv.w 这个 齐次除法 的操作
                //     就像 <1> 中手动实现的那样
                //
                // UNITY_PROJ_COORD 几乎没做什么操作
                //
                //float depth = SAMPLE_DEPTH_TEXTURE_PROJ( _CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos) );


                float ldepth = Linear01Depth(depth);
                
                return float4( ldepth, ldepth, ldepth, 1.0 );


            }
            ENDCG
        }


        

        // 一个最简单的 ShadowCaster pass
        Pass 
        {
            Tags { "LightMode" = "ShadowCaster" }

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #pragma target 2.0
            #pragma multi_compile_shadowcaster
        
            #include "UnityCG.cginc"

            struct v2f {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        




    }
}