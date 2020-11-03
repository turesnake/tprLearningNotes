// ================================================================//
//                 unity3D shader codes
// ================================================================//
// 由于历史原因，unity存在多套 API，尽可能记录下来


// ---------------------------------------------- //
//        pos:   OS -> HCS
// ---------------------------------------------- //
void builtin_vert(){
    float4 posHCS = UnityObjectToClipPos( posOS );// param: float3/float4
}
// ---------------------- //
void urp_vert(){
    float4 posHCS = TransformObjectToHClip( posOS );// param: float3  
}

// ---------------------------------------------- //
//        pos:   OS -> WS
// ---------------------------------------------- //
void builtin_vert(){
    float3 posWS = mul(unity_ObjectToWorld, posOS).xyz;
}
// ---------------------- //
void urp_vert(){
    float3 posWS = TransformObjectToWorld( posOS.xyz );// param: float3 
}

// ---------------------------------------------- //
//    pos: OS -> SS (screen-space)
// ---------------------------------------------- //
// builtin, srp 中，函数名相同
void both_vert(){
    float4 posSS = ComputeScreenPos( posOS );// param: float4 
}
void both_frag(){
    float2 wcoord = posSS.xy / posSS.w; // [0,1]
}


// ---------------------------------------------- //
//      normal: OS -> WS
// ---------------------------------------------- //
void builtin_vert(){
    float3 normalWS = UnityObjectToWorldNormal( normalOS );// param: float3 
}
// ---------------------- //
void urp_vert(){
    float3 normalWS = TransformObjectToWorldNormal( normalOS );// param: float3 
}


// ---------------------------------------------- //
//     viewDir: calc in WS 
// ---------------------------------------------- //
void builtin_frag(){
    fixed3 viewDir = normalize( UnityWorldSpaceViewDir( posWS ) );// param: obj posWS: float3 
}
// ---------------------- //
void urp_vert(){
    fixed3 viewDir = normalize( _WorldSpaceCameraPos - posWS );
    // _WorldSpaceCameraPos: UnityInput.hlsl
    // 一个全局变量，系统会自动向其写入值
}


// ---------------------------------------------- //
//      sample Texture 2D
// ---------------------------------------------- //
// ---------- builtin ------------ //
sample2D _XXX;
void builtin_frag(){
    float4 color = tex2D( _XXX, uv );
}

// ---------- hlsl ------------ //
Texture2D   _TexA; 
Texture2D   _TexB; 
Texture2D   _TexC;
SamplerState  sampler_TexA;

void hlsl_frag(){
    float4 colorA = _TexA.Sample( sampler_TexA, uv );
    float4 colorB = _TexB.Sample( sampler_TexA, uv );
    float4 colorC = _TexC.Sample( sampler_TexA, uv );
}

// ---------- urp ------------ //
TEXTURE2D ( _Tex ); 
SAMPLER ( sampler_Tex );

void urp_frag(){
    float4 color = SAMPLE_TEXTURE2D( _Tex, sampler_Tex, uv );
}


// ---------------------------------------------- //
//         ambient
// ---------------------------------------------- //
// 获得一个 简易的环境光
// 只在 builtin 内见过被使用
void both_frag(){
    fixed3 albedo;
    fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
    // UNITY_LIGHTMODEL_AMBIENT
    // builtin, urp, hdrp 都定义了，且内容一致
}



// ---------------------------------------------- //
//      light datas
// ---------------------------------------------- //
// ---------- builtin ------------ //
void builtin_frag(){
    float4 light_color = _LightColor0;
    // _LightColor0 在不同 pass 中，代表不同的光（一个pass，只处理一个光）
}

// ---------- urp ------------ //
// light datas 源自 ForwardLights.cs  
// 之后传入 urp: Input.hlsl 是一群格式为 "_XXX" 的变量，
// 最后，可在 urp: Lighting.hlsh 中找到 现成的函数：
Light GetMainLight();
Light GetMainLight(float4 shadowCoord);
Light GetAdditionalPerObjectLight(int perObjectLightIndex, float3 positionWS);
Light GetAdditionalLight(uint i, float3 positionWS);



// ---------------------------------------------- //
//   
// ---------------------------------------------- //




// ---------------------------------------------- //
//   
// ---------------------------------------------- //

















