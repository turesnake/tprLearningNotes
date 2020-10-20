// texture + pix_BlinnPhong (lambert + specular)


// 只支持一盏 平行光 （scene 默认光）
// 额外灯光 一律不支持

Shader "tpr/tpr_004_Texture"
{
    Properties
    {
        _MainTex ( "Main Tex", 2D ) = "white" {}
        
        _Color ("Diffuse", Color) = ( 1.0, 1.0, 1.0, 1.0 )

        _BumpMap ("Normal Map", 2D) = "bump" {}
            // "bump" 是 unity 内置法线纹理
        _BumpScale ("Bump Scale", Float) = 1.0
            // 控制 凹凸 强度，若为0，表示 法线贴图 不起作用

        // 控制 高光反射颜色
        _Specular ("Specular", Color) = ( 1.0, 1.0, 1.0, 1.0 )

        // 控制 高光区域大小
        _Gloss ("Gloss", Range(8.0, 256.0)) = 20.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100


        //-------------------------------//
        //       diffuse 贴图
        //-------------------------------//
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

            // Properties 
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _Specular;
            float _Gloss;


            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;

            };

            struct v2f{
                float4 pos : SV_POSITION;
                fixed3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };        


            v2f vert ( appdata v ){
                v2f o;
                // vertex.pos, obj-space to clip-space
                o.pos = UnityObjectToClipPos( v.vertex );
                // vertex.normal, obj-space to world-space
                o.worldNormal = UnityObjectToWorldNormal( v.normal );
                // vertex.pos, obj-space to world-space
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                o.uv = TRANSFORM_TEX( v.texcoord, _MainTex );
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                //--- lambert ---//

                fixed3 worldNormal = normalize( i.worldNormal );

                // 在 world-space 下，输入一个点pos，获得 从此点到光源 的 方向向量 [仅 前向渲染] 
                fixed3 worldLightDir = normalize( UnityWorldSpaceLightDir(i.worldPos) );

                // use the texture to sample the diffuse color
                fixed3 albedo = tex2D(_MainTex, i.uv).rgb * _Color.rgb;

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                fixed3 diffuse = _LightColor0.rgb * albedo * 
                    saturate( dot( worldNormal, worldLightDir ) );

                //--- specular ---//
                // 在 world-space 下，输入一个点pos，获得 从此点到camera 的 方向向量
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(i.worldPos) );

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


        //-------------------------------//
        //      法线贴图: 统一为 切线空间
        //-------------------------------//
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

            // Properties 
            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;

            fixed4 _Color;
            fixed4 _Specular;
            float _Gloss;


            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f{
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                    // uv.xy 存储 材质纹理坐标
                    // uv.zw 存储 法线纹理坐标
                fixed3 lightDir : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
            };        

            v2f vert ( appdata v ){
                v2f o;
                // vertex.pos, obj-space to clip-space
                o.pos = UnityObjectToClipPos( v.vertex );

                o.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;// 材质贴图坐标
                o.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;// 法线贴图坐标

                // 直接用现成宏, 它会自动定义一个 rotation 的矩阵
                TANGENT_SPACE_ROTATION; 

                // 将 lightDir 从 obj-space 转换到 tangent-space
                o.lightDir = mul( rotation, ObjSpaceLightDir(v.vertex) ).xyz;
                // 将 viewDir 从 obj-space 转换到 tangent-space
                o.viewDir = mul( rotation, ObjSpaceViewDir(v.vertex) ).xyz;
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                fixed3 tangentLightDir = normalize( i.lightDir );
                fixed3 tangentViewDir = normalize( i.viewDir );

                // 采样 法线纹素
                fixed4 packedNormal = tex2D( _BumpMap, i.uv.zw );

                fixed3 tangentNormal;

                tangentNormal = UnpackNormal( packedNormal );
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(
                    1.0 - saturate(dot( tangentNormal.xy, tangentNormal.xy ))
                );

                // 采样 材质纹素
                fixed3 albedo = tex2D(_MainTex, i.uv.xy ).rgb * _Color.rgb;

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                fixed3 diffuse = _LightColor0.rgb * albedo * 
                    saturate( dot( tangentNormal, tangentLightDir ) );

                //--- specular ---//
                fixed3 halfDir = normalize( tangentLightDir + tangentViewDir );

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * 
                    pow( max(0.0, dot( tangentNormal, halfDir)), _Gloss );

                fixed3 color = ambient + diffuse + specular;

                return fixed4(
                    color,
                    1.0
                );
            }

            ENDCG
        }


        //-------------------------------//
        //      法线贴图: 统一为 world空间
        //-------------------------------//
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

            // Properties 
            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;

            fixed4 _Color;
            fixed4 _Specular;
            float _Gloss;


            struct appdata{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f{
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                    // uv.xy 存储 材质纹理坐标
                    // uv.zw 存储 法线纹理坐标

                // 矩阵，从 tangent-space 转换到 world-space
                // 只存储 前3行
                float4 TtoW0 : TEXCOORD1;
                float4 TtoW1 : TEXCOORD2;
                float4 TtoW2 : TEXCOORD3;
            };        

            v2f vert ( appdata v ){
                v2f o;
                // vertex.pos, obj-space to clip-space
                o.pos = UnityObjectToClipPos( v.vertex );

                o.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;// 材质贴图坐标
                o.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;// 法线贴图坐标

                float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
                fixed3 worldNormal = UnityObjectToWorldNormal( v.normal );
                fixed3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
                fixed3 worldBinormal = cross( worldNormal, worldTangent ) * v.tangent.w;

                // 组装矩阵
                o.TtoW0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
                o.TtoW1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
                o.TtoW2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );

                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                float3 worldPos = float3( i.TtoW0.w, i.TtoW1.w, i.TtoW2.w );

                fixed3 lightDir = normalize( UnityWorldSpaceLightDir(worldPos) );
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(worldPos) );

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

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

                fixed3 diffuse = _LightColor0.rgb * albedo * 
                    saturate( dot( bump, lightDir ) );

                //--- specular ---//
                fixed3 halfDir = normalize( lightDir + viewDir );

                fixed3 specular = _LightColor0.rgb * _Specular.rgb * 
                    pow( max(0.0, dot( bump, halfDir)), _Gloss );

                fixed3 color = ambient + diffuse + specular;
                return fixed4(
                    color,
                    1.0
                );
            }

            ENDCG
        }
        
        

        /*
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
                float4 pos : SV_POSITION;
                fixed3 worldNormal : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };        


            v2f vert ( appdata v ){
                v2f o;
                // vertex.pos, obj-space to clip-space
                o.pos = UnityObjectToClipPos( v.vertex );
                // vertex.normal, obj-space to world-space
                o.worldNormal = UnityObjectToWorldNormal( v.normal );
                // vertex.pos, obj-space to world-space
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
            
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target{

                //--- lambert ---//

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

                fixed3 worldNormal = normalize( i.worldNormal );

                // {old} fixed3 worldLightDir = normalize( _WorldSpaceLightPos0.xyz );
                // 在 world-space 下，输入一个点pos，获得 从此点到光源 的 方向向量 [仅 前向渲染] 
                fixed3 worldLightDir = normalize( UnityWorldSpaceLightDir(i.worldPos) );


                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * 
                    saturate( dot( worldNormal, worldLightDir ) );

                //--- specular ---//
                
                // {old} fixed3 viewDir = normalize( _WorldSpaceCameraPos.xyz - i.worldPos.xyz );
                // 在 world-space 下，输入一个点pos，获得 从此点到camera 的 方向向量
                fixed3 viewDir = normalize( UnityWorldSpaceViewDir(i.worldPos) );

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
        */
        
    }
    Fallback "Specular"
}
