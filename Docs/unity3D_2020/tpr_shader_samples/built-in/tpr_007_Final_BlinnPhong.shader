

// shadow
// multi lights
// texture: diffuse, normal
// pix_BlinnPhong (lambert + specular)


// opaque 物体，完整版 BlinnPhong


Shader "tpr/tpr_007_Final_BlinnPhong"
{
    Properties
    {
        _Color ("Diffuse", Color) = ( 1,1,1,1 )
        _MainTex ("Main Tex", 2D) = "white" {}

        _BumpMap ("Normal Map", 2D) = "bump" {}
        _BumpScale ("Bump Scale", Float) = 1.0
            // 控制 凹凸 强度，若为0，表示 法线贴图 不起作用

        // 控制 高光反射颜色
        _Specular ("Specular Color", Color) = ( 1,1,1,1 )
        // 控制 高光区域大小
        _Gloss ("Gloss", Range(8.0, 256.0)) = 20.0
    }
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "Queue"="Geometry"
        }
        LOD 100
  
        //-----------------------------// 
        // 处理场景中，对本物体影响最大的 平行光
        // 如果没有平行光，此pass 会处理一个 全黑色的平行光
        Pass
        {
            Tags{
                "LightMode" = "ForwardBase"
            }

            CGPROGRAM

            // // 保证在 base pass 中访问到正确的 光照信息
            #pragma multi_compile_fwdbase

            #pragma vertex vert
            #pragma fragment frag

            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            // 计算阴影时，需要用到的 信息
			#include "AutoLight.cginc"

            //--- Properties ---//
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;

            fixed4 _Specular;
            float _Gloss;

            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT; 
                float4 texcoord : TEXCOORD0; // diffuse tex
            };


            struct v2f{
                float4 pos : SV_POSITION;
                // uv.xy 存储 材质纹理坐标
                // uv.zw 存储 法线纹理坐标
                float4 uv : TEXCOORD0;
                    
                // 法线转换矩阵: tangent-space -> world-space
                // 切线空间的 xyz轴对应：TBN向量
                // 因为是用来转换方向的，所以 只存储 前3行
                float4 TtoW0 : TEXCOORD1;
                float4 TtoW1 : TEXCOORD2;
                float4 TtoW2 : TEXCOORD3;
                    
                // 声明了一个 用来对 shadowmap 采样的坐标: _ShadowCoord，类型为 unityShadowCoord4
                // 参数用来分配一个新的 TEXCOORD_
                // 在此处，轮到 2: TEXCOORD2
                SHADOW_COORDS(4)  
            };        


            v2f vert ( appdata v ){
                v2f o;
                o.pos = UnityObjectToClipPos( v.vertex );

                o.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;// 材质贴图坐标
                o.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;// 法线贴图坐标

                // 定义变量 binormal; (好像没用上)
                TANGENT_SPACE_ROTATION;

                float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
                fixed3 worldNormal = UnityObjectToWorldNormal( v.normal );
                fixed3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
                fixed3 worldBinormal = cross( worldNormal, worldTangent ) * v.tangent.w;

                // 组装矩阵
                // w分量 是 为了节省空间凑进去的，和 方向变换矩阵无关
                // 方向变换矩阵，只需要 3x3 即可
                // ---
                // 将 3个竖向量，看作 转换后的空间的 xyz单位向量，
                // 下面这组操作就能被理解了
                o.TtoW0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
                o.TtoW1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
                o.TtoW2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );

                // 宏，自动计算 o._ShadowCoord 的值
                TRANSFER_SHADOW(o);
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                float3 worldPos = float3( i.TtoW0.w, i.TtoW1.w, i.TtoW2.w );
                fixed3 lightDir = normalize( UnityWorldSpaceLightDir(worldPos) );// MUST normalize !!!
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(worldPos) );// MUST normalize !!!

                // 采样 法线纹素
                // UnpackNormal: 将从 normal texture 直接采样得到的 float4 值，解包，得到具体的 normalDir 向量
                fixed3 bump = UnpackNormal( tex2D( _BumpMap, i.uv.zw ) );
                bump.xy *= _BumpScale;
                // 在 xy分量 被缩放后，为了维持 bump 仍是个 单位向量
                // 手工计算出 z分量
                bump.z = sqrt( 1.0 - saturate(dot( bump.xy, bump.xy )) );

                // 执行矩阵乘法
                // 将 法线向量，从 tangent-space 转换到 world-space
                bump = normalize( half3(
                    // 将 矩阵的 横向量 和 目标竖向量 做点积，是一种简便表达
                    dot( i.TtoW0.xyz, bump ),
                    dot( i.TtoW1.xyz, bump ),
                    dot( i.TtoW2.xyz, bump )
                ));


                // 采样 材质纹素
                fixed3 albedo = tex2D(_MainTex, i.uv.xy ).rgb * _Color.rgb;

                //--- lambert ---//
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                fixed3 diffuse = _LightColor0.rgb * albedo * saturate( dot( bump, lightDir ) );

                //--- specular ---//
                fixed3 halfDir = normalize( lightDir + viewDir );
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow( max(0.0, dot(bump, halfDir)), _Gloss );

                // 宏，自动生成变量 atten, 他是 old_atten * shadow
                // 这个值将被 unity 自动计算
                UNITY_LIGHT_ATTENUATION( atten, i, worldPos );
                    
                fixed3 color = ambient + (diffuse + specular) * atten;
                return fixed4(
                    color,
                    1.0
                );
            }

            ENDCG
        }

        //-----------------------------//  
        // 除了 主平行光 之外的其它 important 光
        // 在 数量范围内，有几盏，此pass 就被执行几次，每一次对应一个光源
        // 支持的 灯光数量
        // Quality - Pixel Light Count 值为多少，本pass 就支持多少个 副光
        // 
        // 不再计算 环境光 ambient
        // 且支持多种光照类型（包含平行光）
        Pass
        {
            Tags{
                "LightMode" = "ForwardAdd"
            }

            // 光源之间做简单的 线性叠加
            Blend One One 
            //Blend SrcAlpha One

            CGPROGRAM

            // 保证在 add pass 中访问到正确的 光照信息
            //#pragma multi_compile_fwdadd
            // 额外支持 多种光源的 shadow
            #pragma multi_compile_fwdadd_fullshadows

            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
			#include "AutoLight.cginc"


            // 以下部分 和 base pass 中几乎一摸一样
            // 唯一不同在于，add pass 不需要计算 ambient 光照了


            //--- Properties ---//
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;

            fixed4 _Specular;
            float _Gloss;

            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT; 
                float4 texcoord : TEXCOORD0; // diffuse tex
            };


            struct v2f{
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                    // uv.xy 存储 材质纹理坐标
                    // uv.zw 存储 法线纹理坐标
                float4 TtoW0 : TEXCOORD1;
                float4 TtoW1 : TEXCOORD2;
                float4 TtoW2 : TEXCOORD3;
                    // 矩阵，从 tangent-space 转换到 world-space
                    // 只存储 前3行
                SHADOW_COORDS(4)
                    // 声明了一个 用来对 shadowmap 采样的坐标: _ShadowCoord，类型为 unityShadowCoord4
                    // 参数用来分配一个新的 TEXCOORD_
                    // 在此处，轮到 2: TEXCOORD2
            };        


            v2f vert ( appdata v ){
                v2f o;
                o.pos = UnityObjectToClipPos( v.vertex );

                o.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;// 材质贴图坐标
                o.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;// 法线贴图坐标

                // 定义变量 binormal; (好像没用上)
                TANGENT_SPACE_ROTATION;

                float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
                fixed3 worldNormal = UnityObjectToWorldNormal( v.normal );
                fixed3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
                fixed3 worldBinormal = cross( worldNormal, worldTangent ) * v.tangent.w;

                // 组装矩阵
                o.TtoW0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
                o.TtoW1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
                o.TtoW2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );

                // 宏，自动计算 o._ShadowCoord 的值
                TRANSFER_SHADOW(o);
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                float3 worldPos = float3( i.TtoW0.w, i.TtoW1.w, i.TtoW2.w );
                fixed3 lightDir = normalize( UnityWorldSpaceLightDir(worldPos) );// MUST normalize !!!
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(worldPos) );// MUST normalize !!!

                // 采样 法线纹素
                fixed3 bump = UnpackNormal( tex2D( _BumpMap, i.uv.zw ) );
                bump.xy *= _BumpScale;
                bump.z = sqrt(
                    1.0 - saturate(dot( bump.xy, bump.xy ))
                );
                // 执行矩阵乘法
                // 将 法线向量，从 tangent-space 转换到 world-space
                bump = normalize( half3(
                    dot( i.TtoW0.xyz, bump ),
                    dot( i.TtoW1.xyz, bump ),
                    dot( i.TtoW2.xyz, bump )
                ));


                // 采样 材质纹素
                fixed3 albedo = tex2D(_MainTex, i.uv.xy ).rgb * _Color.rgb;

                //--- lambert ---//
                fixed3 diffuse = _LightColor0.rgb * albedo * saturate( dot( bump, lightDir ) );

                //--- specular ---//
                fixed3 halfDir = normalize( lightDir + viewDir );
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow( max(0.0, dot(bump, halfDir)), _Gloss );

                // 宏，自动生成变量 atten, 他是 old_atten * shadow
                // 这个值将被 unity 自动计算
                UNITY_LIGHT_ATTENUATION( atten, i, worldPos );
                    
                fixed3 color = (diffuse + specular) * atten;
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
