
#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEditor.Rendering
{
    //
    // 摘要:
    //     A struct that represents graphics settings for a given build target and.
    public struct TierSettings//TierSettings__RR
    {
        //
        // 摘要:
        //     The Standard Shader Quality.
        public ShaderQuality standardShaderQuality;
        //
        // 摘要:
        //     The format to use for the HDR buffer.
        public CameraHDRMode hdrMode;
        //
        // 摘要:
        //     Whether to use Reflection Probes Box Projection.
        public bool reflectionProbeBoxProjection;
        //
        // 摘要:
        //     Whether to enable Reflection Probes Blending.
        public bool reflectionProbeBlending;
        //
        // 摘要:
        //     Whether to enable High Dynamic Range (HDR) rendering.
        public bool hdr;
        //
        // 摘要:
        //     Whether to sample a Detail Normal Map, if assigned.
        public bool detailNormalMap;
        //
        // 摘要:
        //     Whether to use cascaded shadow maps.
        public bool cascadedShadowMaps;
        //
        // 摘要:
        //     Whether Unity should try to use 32-bit shadow maps, where possible.
        public bool prefer32BitShadowMaps;
        //
        // 摘要:
        //     Whether Light Probe Proxy Volume should be used.
        public bool enableLPPV;
        //
        // 摘要:
        //     Whether to enable Semitransparent Shadows.
        public bool semitransparentShadows;
        //
        // 摘要:
        //     The rendering path to use.
        public RenderingPath renderingPath;
        //
        // 摘要:
        //     The RealtimeGICPUUsage to use.
        public RealtimeGICPUUsage realtimeGICPUUsage;
    }
}