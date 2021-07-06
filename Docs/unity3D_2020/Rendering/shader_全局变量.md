# ============================================== //
#      源自 CPU 端的全局变量，都在哪 ？
# ---------------------------------------------- //
 可以通过搜索 Shader.PropertyToID(" 得知：


# urp: ForwardLights.cs
    _MainLightPosition              : float4
    _MainLightColor                 : half4
    _AdditionalLightsCount          : half4

    _AdditionalLightsBuffer         : StructuredBuffer<LightData>
    _AdditionalLightsIndices        : StructuredBuffer<int> 

    _AdditionalLightsPosition       : float4
    _AdditionalLightsColor          : half4
    _AdditionalLightsAttenuation    : half4
    _AdditionalLightsSpotDir        : half4
    _AdditionalLightsOcclusionProbes    : half4


# urp: PostProcessUtils.cs
    _Grain_Texture          : tex 2D
    _Grain_Params           : float2
    _Grain_TilingParams     : float4
    _BlueNoise_Texture      : tex 2D
    _Dithering_Params       : float4


# urp: UniversalRenderPipeline.cs
    _GlossyEnvironmentColor     : half4
    _SubtractiveShadowColor     : half4

    _Time               : float4
    _SinTime            : float4
    _CosTime            : float4
    unity_DeltaTime     : float4
    _TimeParameters     : float4

# urp: UniversalRenderPipelineCore.cs
    _ScaledScreenParams     : float4 
    _WorldSpaceCameraPos    : float3
    _ScreenParams           : float4
    _ProjectionParams       : float4
    _ZBufferParams          : float4
    unity_OrthoParams       : float4

    unity_MatrixV               : float4x4
    glstate_matrix_projection   : float4x4
    unity_MatrixVP              : float4x4

    unity_MatrixInvV        : float4x4
    unity_MatrixInvVP       : float4x4

    unity_CameraProjection      : float4x4
    unity_CameraInvProjection   : float4x4
    unity_WorldToCamera         : float4x4
    unity_CameraToWorld         : float4x4
    

# urp: Passes/ AdditionalLightsShadowCasterPass.cs
    _AdditionalLightsWorldToShadow
    _AdditionalShadowParams
    _AdditionalShadowOffset0
    _AdditionalShadowOffset1
    _AdditionalShadowOffset2
    _AdditionalShadowOffset3
    _AdditionalShadowmapSize

    _AdditionalShadowsBuffer
    _AdditionalShadowsIndices

# urp: Passes/ ColorGradingLutPass.cs
    _Lut_Params
    _ColorBalance
    _ColorFilter
    _ChannelMixerRed
    _ChannelMixerGreen
    _ChannelMixerBlue
    _HueSatCon
    _Lift
    _Gamma
    _Gain
    _Shadows
    _Midtones
    _Highlights
    _ShaHiLimits
    _SplitShadows
    _SplitHighlights
    _CurveMaster
    _CurveRed
    _CurveGreen
    _CurveBlue
    _CurveHueVsHue
    _CurveHueVsSat
    _CurveLumVsSat
    _CurveSatVsSat


# urp: Passes/ CopyColorPass.cs
    _SampleOffset


# urp: Passes/ CopyDepthPass.cs
    _ScaleBiasRT

# urp: Passes/ DrawObjectsPass.cs
    _DrawObjectPassData

# urp: Passes/ MainLightShadowCasterPass.cs
    _MainLightWorldToShadow
    _MainLightShadowParams
    _CascadeShadowSplitSpheres0
    _CascadeShadowSplitSpheres1
    _CascadeShadowSplitSpheres2
    _CascadeShadowSplitSpheres3
    _CascadeShadowSplitSphereRadii
    _MainLightShadowOffset0
    _MainLightShadowOffset1
    _MainLightShadowOffset2
    _MainLightShadowOffset3
    _MainLightShadowmapSize

# urp: Passes/ PostProcessPass.cs
    "_BloomMipUp" + i
    "_BloomMipDown" + i

    _TempTarget
    _TempTarget2

    _StencilRef
    _StencilMask

    _FullCoCTexture
    _HalfCoCTexture
    _DofTexture
    _CoCParams
    _BokehKernel
    _PongTexture
    _PingTexture

    _Metrics
    _AreaTexture
    _SearchTexture
    _EdgeTexture
    _BlendTexture

    _ColorTexture
    _Params
    _MainTexLowMip
    _Bloom_Params
    _Bloom_RGBM
    _Bloom_Texture
    _LensDirt_Texture
    _LensDirt_Params
    _LensDirt_Intensity
    _Distortion_Params1
    _Distortion_Params2
    _Chroma_Params
    _Vignette_Params1
    _Vignette_Params2
    _Lut_Params
    _UserLut_Params
    _InternalLut
    _UserLut

    _FullscreenProjMat


# urp: Passes/ SceneViewDepthCopy.cs
    _ScaleBiasRT



