// pix_BlinnPhong (lambert + specular)

// 名义上，可以实现更细腻的光照效果，但本 shader 暂不支持 法线贴图
// 这意味着如果用它来渲染 一个 低模球体，这个球体仍然是 块面分明的 

// 只支持一盏 平行光 （scene 默认光）
// 额外灯光 一律不支持

Shader "tpr/tpr_003_BlinnPhong"
{
    Properties
    {
        _Diffuse ("Diffuse", Color) = ( 1.0, 1.0, 1.0, 1.0 )
        // 控制 高光反射颜色
        _Specular ("Specular", Color) = ( 1.0, 1.0, 1.0, 1.0 )
        // 控制 高光区域大小
        _Gloss ("Gloss", Range(8.0, 256.0)) = 20.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

  
        Pass
        {

            Tags{
                "LightMode" = "ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            #include "UnityLightingCommon.cginc" 
                // _LightColor0

            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            struct appdata{
                // 用模型空间的 顶点坐标，来填充 vertex
                float4 vertex : POSITION;
                // 用模型空间的 法线方向向量，填充 normal
                // 每个分量的范围 [-1.0, 1.0]
                float3 normal : NORMAL;
            };


            struct v2f{
                float4 posHCS : SV_POSITION;
                fixed3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };        


            v2f vert ( appdata v ){
                v2f o;
                // obj-space to clip-space
                o.posHCS = UnityObjectToClipPos( v.vertex );
                // vertex.normal, obj-space to world-space
                o.worldNormal = UnityObjectToWorldNormal( v.normal );
                // obj-space to world-space
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                //--- lambert ---//

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

                fixed3 worldNormal = normalize( i.worldNormal );// MUST normalize !!!

                // 在 world-space 下，输入一个点pos，获得 从此点到光源 的 方向向量 [仅 前向渲染] 
                fixed3 worldLightDir = normalize( UnityWorldSpaceLightDir(i.worldPos) );// MUST normalize !!!


                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * 
                    saturate( dot( worldNormal, worldLightDir ) );

                //--- specular ---//
            
                // 在 world-space 下，输入一个点pos，获得 从此点到camera 的 方向向量
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(i.worldPos) );// MUST normalize !!!

                fixed3 halfDir = normalize( worldLightDir + viewDir );

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * 
                    pow( max(0.0, dot(worldNormal, halfDir)), _Gloss );
                    
                fixed3 color = ambient + diffuse + specular;

                return fixed4(
                    color,
                    1.0
                );
            }

            ENDCG
        }
        
    }
    Fallback "Specular"
}
