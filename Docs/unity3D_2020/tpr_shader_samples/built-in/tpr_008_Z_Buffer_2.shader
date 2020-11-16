// 
// 功能和 008 shader 完全一致
// 不过这个实现 不依赖于前置的 shadow caster pass
// ---
// 如果流程中已经实现了 shadow caster pass，则推荐使用 008
// 如果没有，则推荐使用 本示范
// ---
// 这个方法只能用来 验证 depth 信息的 实现过程，并不具备多少实际意义
// 之所以需要 depth-buffer，本质上是为了获得 “全局信息”
// 光凭 frag() 无法得知相邻像素的信息，
// 但如果我们事先通过一个 pass，将必要信息存储在一个 texture 中
// 那么这个限制就被突破了：
// 任何 frag 都可以通过 向 texture 采样，来获得 相邻区域的 信息
// 以此来实现各种效果
// 
Shader "tpr/tpr_009_Z_Buffer_2"
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

            struct v2f
            {
                float4 pos : SV_POSITION;
                float  depth : TEXCOORD1;
            };

            v2f vert ( appdata_base v )
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                // 以下三种写法的功能是完全一致的
                // <-1->
                //o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;
                // <-2->
                //o.depth = -UnityObjectToViewPos(v.vertex).z * _ProjectionParams.w;
                // <-3->
                o.depth = COMPUTE_DEPTH_01;

                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                return float4( i.depth, i.depth, i.depth, 1.0 );
            }
            ENDCG
        }
        
    
    }
}