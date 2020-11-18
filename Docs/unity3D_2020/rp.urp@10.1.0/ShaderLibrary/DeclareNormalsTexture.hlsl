#ifndef UNITY_DECLARE_NORMALS_TEXTURE_INCLUDED
#define UNITY_DECLARE_NORMALS_TEXTURE_INCLUDED
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

TEXTURE2D_X_FLOAT(_CameraNormalsTexture);
SAMPLER(sampler_CameraNormalsTexture);


// xyz: [-1,1] 单位向量
float3 SampleSceneNormals(float2 uv)
{
    return UnpackNormalOctRectEncode(SAMPLE_TEXTURE2D_X(_CameraNormalsTexture, sampler_CameraNormalsTexture, UnityStereoTransformScreenSpaceTex(uv)).xy) * 
            float3(1.0, 1.0, -1.0);
}

// 暂不明其用法
float3 LoadSceneNormals(uint2 uv)
{
    return UnpackNormalOctRectEncode(LOAD_TEXTURE2D_X(_CameraNormalsTexture, uv).xy) * float3(1.0, 1.0, -1.0);
}
#endif
