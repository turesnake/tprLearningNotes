#ifndef UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED
#define UNIVERSAL_SIMPLE_LIT_PASS_INCLUDED

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"

// PI in Macros.hlsl

static const float3 baseColor = float3( 0.9, 0.4, 0.1 );
static const float MinDistanceToSurface = 0.01;
static const int MaxRaymarchingTimes = 200;


// 从 “检测边界” 到 ball center 的距离因子 [1,+inf]
// 用它 乘以 ball radius, 能获得实际的 “检测区半径值” pix
// ---
// 能控制 metaball 的粘稠程度 
static const float detectBorder = 23.7;
static const float invertDetectBorder = 1/detectBorder;

// 暂时无用
//float4 _QuadBasePosWS; //xyz posWS

static const float ballNum = 3;
// VectorArray 不能被写进 Properties 中
float4 _BallPosesWS[ballNum];// xyz:posWS, w:radius


// tmp light
static const int lightNum = 3;
static const float3 lightDirsWS[lightNum] = {
    normalize(float3( 0.4, 1, -0.3 )),
    normalize(float3( -0.7, -0.5, -0.1 )),
    normalize(float3( 0.3, -0.2, -0.4 ))
};

static const float3 lightColors[lightNum] = {
    float3( 0.9, 0.8, 1 ),
    float3( 0.3, 0.2, 0.1 ),
    float3( 0.1, 0.2, 0.05 )
};





struct Attributes
{
    float4 positionOS    : POSITION;
    float3 normalOS      : NORMAL;
    float4 tangentOS     : TANGENT;
    float2 texcoord      : TEXCOORD0;
    float2 lightmapUV    : TEXCOORD1;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};


struct Varyings
{
    float2 uv                       : TEXCOORD0; // uv in texture 
    DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 1);

    float3 posWS                    : TEXCOORD2;    // xyz: posWS

#ifdef _NORMALMAP
    float4 normal                   : TEXCOORD3;    // xyz: normal, w: viewDir.x
    float4 tangent                  : TEXCOORD4;    // xyz: tangent, w: viewDir.y
    float4 bitangent                : TEXCOORD5;    // xyz: bitangent, w: viewDir.z
#else
    float3  normal                  : TEXCOORD3;
    float3 viewDir                  : TEXCOORD4;
#endif

    half4 fogFactorAndVertexLight   : TEXCOORD6; // x: fogFactor, yzw: vertex light

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    float4 shadowCoord              : TEXCOORD7;
#endif

    float4 positionCS               : SV_POSITION;
    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};




void InitializeInputData(Varyings input, half3 normalTS, out InputData inputData)
{
    inputData.positionWS = input.posWS;

#ifdef _NORMALMAP // 测试表面，此 keyword 并未被声明 
    half3 viewDirWS = half3(input.normal.w, input.tangent.w, input.bitangent.w);
    inputData.normalWS = TransformTangentToWorld(normalTS,
        half3x3(input.tangent.xyz, input.bitangent.xyz, input.normal.xyz));
#else
    half3 viewDirWS = input.viewDir;
    inputData.normalWS = input.normal;
#endif

    inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
    viewDirWS = SafeNormalize(viewDirWS);

    inputData.viewDirectionWS = viewDirWS;

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    inputData.shadowCoord = input.shadowCoord;
#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
    inputData.shadowCoord = TransformWorldToShadowCoord(inputData.positionWS);
#else
    inputData.shadowCoord = float4(0, 0, 0, 0);
#endif

    inputData.fogCoord = input.fogFactorAndVertexLight.x;
    inputData.vertexLighting = input.fogFactorAndVertexLight.yzw;
    inputData.bakedGI = SAMPLE_GI(input.lightmapUV, input.vertexSH, inputData.normalWS);
    inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);
    inputData.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUV);
}





///////////////////////////////////////////////////////////////////////////////
//                           Metaball                        
///////////////////////////////////////////////////////////////////////////////

// ------------------------------------ //
// bounding sphere: "边界范围球" 纯粹的球，用 pos 和 半径定义
// metaball: 一个不定形的有机体，具备多变的表面
//     通常，metaball 的边界，会小于单纯的 bounding sphere 的边界


// f(x) = 6*X^5 - 15*X^4 + 10*X^3
// 
// 一个得到广泛应用的 差值平滑曲线函数
// 最早是由 Ken Perlin 提出，用来在生成 Simplex Noise 时，获得更平滑的曲线
// 这个函数有个特点：f(0)=0; f(1)=1; f'(0)=0, f'(1)=0
// 这意味着，当 x 位于 0 和 1 处时，f(x)的 导数是0，它趋于一条水平线
// 这使得它能 平缓地将 节点的左右侧曲线段 连接起来
// 它比原来的曲线 3*X^2-2*X^3; 在 0，1 位置更加平滑
// --
// 而且这个函数是对称的（对称点位于 f(0.5) 处）
// f'(0.5) = 15/8


// 0.5333 是什么？
// 就是 f'(0.5) 的取反: 1/(15/8) = 8/15 = 0.5333;
// ---
// Inigo Quilez 对 0.5333的解释:
// The maxium slope p"(x)=0 happens in the middle x=1/2, and its value is 
// p'(1/2) = 15/8. Therefore the  minimum distance to a metaball (in metaball canonical 
// coordinates 正则坐标系 ) is at least 8/15 = 0.533333


// 计算 步进点 到 模型表面的 距离
// 
// -- 若 rayPoint 位于所有 bounding sphere 体外：
//    则返回 rayPoint 到最近的 bounding sphere 表面的距离 + 0.1
//    (用额外的 0.1 来让 rayPoint 彻底进入 bounding sphere 体内，而不是停留在表面上)
// -- 若 rayPoint 位于至少一个 bounding sphere 的体内（但不在 metaball 体内）：
//    则返回 rayPoint 到 metaball 表面 的距离
// -- 若 rayPoint 以及位于 metaball 体内
//    则返回一个 负数
// 
float distanceToSurface_2( float3 rayPoint ){
    
    int innBallNum = 0; // 统计 rayPoint 在几个 bounding sphere 体内

    // 累计所有 metaball 的衰减值。
    // 衰减值: f(0,1)->[1,0]; 且被平滑过。
    //    当 rayPoint 接近 bounding sphere 边界，衰减值 无限接近0
    //    当 rayPoint 接近 bounding sphere 球心，衰减值 无限接近1
    float totalFalloff = 0.0;
    float dmin = 1e20; // rayPoint 到 所有 bounding sphere 边界的最近距离 pix (init with inf+)

    // track Lipschitz constant 利普希茨常数
    // The h is the weight for metaball’s falloff: metaball衰减的权重值
    // and it also scales normalized distance back to world coordinates
    float h = 1.0;  // [1, inf+]
 
    for( int i=0; i<ballNum; i++ ){// each bounding sphere

        float db = length( _BallPosesWS[i].xyz - rayPoint );// 绝对距离值 pix
        if( db < _BallPosesWS[i].w ){
            // --- rayPoint 在当前 bounding sphere 体内 --- //
            // do metaball field calculation

            float x = db/_BallPosesWS[i].w; // 以半径为单位的 距离值 [0,1]

            totalFalloff += 1.0 - x*x*x*(x*(x*6.0-15.0)+10.0); // (平滑函数见前部注释)
            innBallNum += 1;
            
            // 找出影响最大的 权重值 （根据 sphere radius）
            h = max( h, 0.5333*_BallPosesWS[i].w ); // (0.5333 见前部注解)

        }else{
            // --- rayPoint 在当前 bounding sphere 体外 --- //
            dmin = min( dmin, db - _BallPosesWS[i].w );
        }
    }

    // add just big enough to push the ray into the blob 
    // when the ray hit the bounding sphere.
    // ---
    // 如果不增加这个额外值，ray point 很可能在数次 marching 后，停留在 bounding sphere 的边界上，
    // 这不是我们想要的， 我们想让 ray point 彻底进入 圆球 的体内
    // ---
    // 如果没有这一步，就不可能有上方 "db < blobs[i].w" 这个情况的出现
    // ---
    // 此行代码 仅对 没有进入任何 bounding spheres 的 ray point 有效
    // 如果它已经在体内里，则 变量 d 会在下面代码中被复写（使此行失效）
    float d = dmin + 0.1;
 
    if( innBallNum > 0 ){ 
        // 从 bounding sphere raius，向内收缩一段距离，变成 metaball 的边界半径
        // [0, 0.5]
        float threshold = 0.2; 

        // 计算 rayPoint 到 metaball 表面 的距离值
        // 当 totalFalloff > threshold, 将算出负数，即：rayPoint 已经位于 metaball 体内（此负数 会被层层返回上去）
        // 当 totalFalloff < threshold, 就意味着 rayPoint 已经离 metaball 表面 越来越近了
        // ---
        // h 用来修正这个值（只能放大）: scales normalized distance back to world coordinates
        d = h * ( threshold - totalFalloff );
    }
 
    // return the updated distance for the next marching step 
    return d;
}




// ret.x: t
// ret.y: isHit: 0-false, 1-true
float2 raymarching( float3 rayOriginWS, float3 rayDirWS ){

    float t = 0;
    // max t when ray hit far plane
    float max_t = abs( _ProjectionParams.z / TransformWorldToViewDir(rayDirWS,true).z );

    float  d; // distance form rayPoint to metaball surface each time
    float3 X; // rayPoint
    bool isHit = false;
    
    for( int i=0; i<MaxRaymarchingTimes; i++ ){
        X = rayOriginWS + rayDirWS * t;
        // d 可能被计算出负值，表示 rayPoint 已经在 metaball 体内
        // 此时会被当成 “接近 metaball 表面” 一样处理
        d = distanceToSurface_2(X);
        isHit = (d < MinDistanceToSurface);
        if( isHit || (t > max_t)){ 
            break; 
        }
        t += d;
    }
    return float2( t, isHit ? 1 : 0 );
}


// 
// 很奇怪，目前的 法线效果 存在瑕疵
// 
// 高效的，计算 hitPoint 法线 的方法（就是有点难懂）
// param: hitPos: 在 metaball 表面（也可能在体内）
float3 calc_normal( float3 hitPos ){

    // 这个方法求的法线，好像是位于 WS，
    // 但是它的初始值，为什么看起来像是位于 TS ???
	float3 nor = float3(0.0, 0.0001, 0.0);

	for( int i = 0; i < ballNum; i++ ){
        // frag 距离 sphere 的距离值 pix
		float db = length( _BallPosesWS[i].xyz - hitPos );
        // 以 sphere radius 为单位的 距离值 [0,1] 超出的夹回 0,1
        // 如果 frag 并不在此 sphere 体内，x=1，
        // 这会导致此次算出的 nor = 0;
		float x = clamp( db / _BallPosesWS[i].w, 0.0, 1.0 );
        // 此函数是 f(x) = 6*X^5 - 15*X^4 + 10*X^3 的 一阶导数
        // f(0)=0; f(1)=0; f(0.5)=1.875 {峰值}
        // 当 p 非常小时，此 sphere 贡献的向量 越小 
		float p = x*x*(30.0*x*x - 60.0*x + 30.0);
        // p/radius 是用来计算 当前 提供的法线的 权重值的（相对于最终生成的法线）
        // p 越大，贡献越大，这意味着，当 hitPos 接近 sphere 半径的一半时，贡献的 nor 最大
        // radius 越大，贡献越小
		nor += normalize(hitPos - _BallPosesWS[i].xyz) * (p / _BallPosesWS[i].w);

        // 就算改成这种 "暴力近似版" 最终视觉上的差异也很小
        // 也许官方实现仅仅是为了 “视觉上更好”，而没有别的意义
        //nor += normalize(hitPos - _BallPosesWS[i].xyz) * ((1-x) / _BallPosesWS[i].w);
        //nor += normalize(hitPos - _BallPosesWS[i].xyz) * (1-x);
	}

	return normalize(nor);
}





///////////////////////////////////////////////////////////////////////////////
//                  Vertex and Fragment functions                            //
///////////////////////////////////////////////////////////////////////////////

// Used in Standard (Simple Lighting) shader
Varyings LitPassVertexSimple(Attributes input)
{
    Varyings output = (Varyings)0;

    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_TRANSFER_INSTANCE_ID(input, output);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

    VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
    VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
    half3 viewDirWS = GetWorldSpaceViewDir(vertexInput.positionWS);
    half3 vertexLight = VertexLighting(vertexInput.positionWS, normalInput.normalWS);
    half fogFactor = ComputeFogFactor(vertexInput.positionCS.z);

    // = (tex.xy) * tex_ST.xy + tex_ST.zw
    output.uv = TRANSFORM_TEX(input.texcoord, _BaseMap); // uv in texture 
    output.posWS.xyz = vertexInput.positionWS;
    output.positionCS = vertexInput.positionCS;

#ifdef _NORMALMAP
    output.normal = half4(normalInput.normalWS, viewDirWS.x);
    output.tangent = half4(normalInput.tangentWS, viewDirWS.y);
    output.bitangent = half4(normalInput.bitangentWS, viewDirWS.z);
#else
    output.normal = NormalizeNormalPerVertex(normalInput.normalWS);
    output.viewDir = viewDirWS;
#endif

    OUTPUT_LIGHTMAP_UV(input.lightmapUV, unity_LightmapST, output.lightmapUV);
    OUTPUT_SH(output.normal.xyz, output.vertexSH);

    output.fogFactorAndVertexLight = half4(fogFactor, vertexLight);

#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    output.shadowCoord = GetShadowCoord(vertexInput);
#endif

    return output;
}



// Used for StandardSimpleLighting shader
float4 LitPassFragmentSimple(Varyings input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

    // uv in texture, NOT uvSS
    float2 uv = input.uv;
    half4 diffuseAlpha = SampleAlbedoAlpha(uv, TEXTURE2D_ARGS(_BaseMap, sampler_BaseMap));
    half3 diffuse = diffuseAlpha.rgb * _BaseColor.rgb;

    half alpha = diffuseAlpha.a * _BaseColor.a;
    // 此处禁止 clip
    //AlphaDiscard(alpha, _Cutoff);

    #ifdef _ALPHAPREMULTIPLY_ON
        diffuse *= alpha;
    #endif

    half3 normalTS = SampleNormal(uv, TEXTURE2D_ARGS(_BumpMap, sampler_BumpMap));
    half3 emission = SampleEmission(uv, _EmissionColor.rgb, TEXTURE2D_ARGS(_EmissionMap, sampler_EmissionMap));
    half4 specular = SampleSpecularSmoothness(uv, alpha, _SpecColor, TEXTURE2D_ARGS(_SpecGlossMap, sampler_SpecGlossMap));
    half smoothness = specular.a;

    InputData inputData;
    InitializeInputData(input, normalTS, inputData);

    //half4 color = UniversalFragmentBlinnPhong(inputData, diffuse, specular, smoothness, emission, alpha);
    //color.rgb = MixFog(color.rgb, inputData.fogCoord);
    //color.a = OutputAlpha(color.a, _Surface);
    //return color;

    // ================================================ //
    //                  Our Job
    // ================================================ //
    // 已知数据
    // inputData.viewDirectionWS = SafeNormalize(input.viewDir);
    // GetCurrentViewPosition() -- cameraPosWS
    // _ProjectionParams.z -- far plane depth
    // ...

    //float3 viewPosWS = GetCurrentViewPosition();
    float3 rayOriginWS = GetCurrentViewPosition();
    float3 rayDirWS = -normalize( inputData.viewDirectionWS );


    // ------------------------------ //
    //          Raymarching
    // ------------------------------ //
    float3 color = float3( 0.1, 0.2, 0.35 );// default color

    float2 ret = raymarching( rayOriginWS, rayDirWS );
    if( ret.y > 0.5 ){// isHit

        float3 hitPosWS = rayOriginWS + rayDirWS * ret.x;
        float3 hitNormalWS = calc_normal( hitPosWS );

        // ----- 一组临时的光 ----- //
        float3 lc = float3( 0,0,0 );
        for( int i=0; i<lightNum; i++ ){
            lc += lightColors[i] * saturate( dot( lightDirsWS[i], hitNormalWS ) );
        }
        color = lc;
    }

    return float4( color, 1 );

}

#endif
