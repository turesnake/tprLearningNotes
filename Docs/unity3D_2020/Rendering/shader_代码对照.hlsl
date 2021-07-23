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
    // param: float4 posCC in vert (尚未做齐次除法)
    float4 posSS = ComputeScreenPos( posCS );
}
void both_frag(){
    float2 wcoord = posSS.xy / posSS.w; // [0,1]
}

还有一个思路是使用 VPOS semantic, 可以在全局搜索这个词来查找用法.


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
//            Sample 
//            Texture 2D
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


// ---------- urp shadow texture ------------ //
TEXTURE2D_SHADOW( _Tex );
SAMPLER_CMP( sampler_Tex );
float v = SAMPLE_TEXTURE2D_SHADOW( _Tex, sampler_Tex, posSTS );

// 在大部分平台，TEXTURE2D_SHADOW 和通用的 TEXTURE2D 没什么区别（少数平台有区别）

// 而 SAMPLER_CMP 则和 SAMPLER 确实不一样，
// 因为 SAMPLER 并不会针对 depth 数据做 滤波。而 shadow map 存储的正是 depth 数据

// posSTS: Shadow-Tile-Space


#define TEXTURE2D_ARGS(textureName, samplerName)  textureName, samplerName
// 除了 GLES2 平台， 在其它平台中， 此宏 仅用来包装一组 函数参数，
// 通常出现在 函数调用端


#define TEXTURE2D_SHADOW_PARAM(textureName, samplerName) TEXTURE2D(textureName), SAMPLER_CMP(samplerName)
// 除了 GLES2 平台， 在其它平台中， 此宏 用来在 函数的形参列表中
// 就地定义一组 tex参数
// 通常和 上面的 TEXTURE2D_ARGS 联合使用 




// ---------------------------------------------- //
//          SAMPLE_TEXTURE2D_SHADOW
// ---------------------------------------------- //
// 在大部分平台，
SAMPLE_TEXTURE2D_SHADOW( _Tex, sampler_Tex, posSTS ) = 
    Tex.SampleCmpLevelZero( sampler_Tex, (posSTS).xy, (posSTS).z)

// 而 SampleCmpLevelZero，是一个 hlsl 函数：
// Samples a texture and compares the result to a comparison value. 
// This function is identical to calling SampleCmp on mipmap level 0 only.

float Object.SampleCmp(
    SamplerComparisonState S,
    float Location,
    float CompareValue,
    [int Offset]
);

// 具体解读为：
// 针对像素坐标 posSTS, 以其.xy值为 uv坐标，去 _Tex 中采样，
// 将采样获得的值，与 posSTS.z 做比较。

// 一个推断：posSTS.xyz 取值范围是 [0,1]
// 因为要符合 UV 坐标系 的规则



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

















