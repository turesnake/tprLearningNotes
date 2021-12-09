
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{


    /*
        Defines set by editor when compiling shaders, based on the target platform and GraphicsTier.

        当编译 shaders, 由 editor 设置的一组 "Defines"; 

    */
    public enum BuiltinShaderDefine//BuiltinShaderDefine__RR
    {
       
        //     UNITY_NO_DXT5nm is set when compiling shader for platform that do not support
        //     DXT5NM, meaning that normal maps will be encoded in RGB instead.
        UNITY_NO_DXT5nm = 0,
        
        //     UNITY_NO_RGBM is set when compiling shader for platform that do not support RGBM,
        //     so dLDR will be used instead.
        UNITY_NO_RGBM = 1,

        UNITY_USE_NATIVE_HDR = 2,

        /*
            "UNITY_ENABLE_REFLECTION_BUFFERS" is set when "deferred shading" renders reflection probes in deferred mode. 
            With this option set, reflections are rendered into a per-pixel buffer. 
            This is similar to the way lights are rendered into a per-pixel buffer. 
            "UNITY_ENABLE_REFLECTION_BUFFERS" is on by default when using deferred shading, 
            but you can turn it off by setting “No support” for the Deferred Reflections shader option in Graphics Settings. 
            When the setting is off, reflection probes are rendered per-object, similar to the way forward rendering works.

            See Also: "BuiltinShaderType.DeferredReflections".
        */
        UNITY_ENABLE_REFLECTION_BUFFERS = 3,

        /*
            UNITY_FRAMEBUFFER_FETCH_AVAILABLE is set when compiling shaders for platforms
            where framebuffer fetch is potentially available.
            ---
            可以从 framebuffer 中提取数据 ?
        */
        UNITY_FRAMEBUFFER_FETCH_AVAILABLE = 4,
        
        //     UNITY_ENABLE_NATIVE_SHADOW_LOOKUPS enables use of built-in shadow comparison
        //     samplers on OpenGL ES 2.0.
        UNITY_ENABLE_NATIVE_SHADOW_LOOKUPS = 5,
        
        /*
            UNITY_METAL_SHADOWS_USE_POINT_FILTERING is set if shadow sampler should use point filtering on iOS Metal.

            See Also: "PlayerSettings.iOS.forceHardShadowsOnMetal"
        */
        UNITY_METAL_SHADOWS_USE_POINT_FILTERING = 6,

        UNITY_NO_CUBEMAP_ARRAY = 7,
        //
        // 摘要:
        //     UNITY_NO_SCREENSPACE_SHADOWS is set when screenspace cascaded shadow maps are
        //     disabled.
        UNITY_NO_SCREENSPACE_SHADOWS = 8,
        //
        // 摘要:
        //     UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS is set when Semitransparent Shadows
        //     are enabled.
        UNITY_USE_DITHER_MASK_FOR_ALPHABLENDED_SHADOWS = 9,
        //
        // 摘要:
        //     UNITY_PBS_USE_BRDF1 is set if Standard Shader BRDF1 should be used.
        UNITY_PBS_USE_BRDF1 = 10,
        //
        // 摘要:
        //     UNITY_PBS_USE_BRDF2 is set if Standard Shader BRDF2 should be used.
        UNITY_PBS_USE_BRDF2 = 11,
        //
        // 摘要:
        //     UNITY_PBS_USE_BRDF3 is set if Standard Shader BRDF3 should be used.
        UNITY_PBS_USE_BRDF3 = 12,
        //
        // 摘要:
        //     UNITY_NO_FULL_STANDARD_SHADER is set if Standard shader BRDF3 with extra simplifications
        //     should be used.
        UNITY_NO_FULL_STANDARD_SHADER = 13,
        //
        // 摘要:
        //     UNITY_SPECCUBE_BLENDING is set if Reflection Probes Box Projection is enabled.
        UNITY_SPECCUBE_BOX_PROJECTION = 14,
        //
        // 摘要:
        //     UNITY_SPECCUBE_BLENDING is set if Reflection Probes Blending is enabled.
        UNITY_SPECCUBE_BLENDING = 15,
        //
        // 摘要:
        //     UNITY_ENABLE_DETAIL_NORMALMAP is set if Detail Normal Map should be sampled if
        //     assigned.
        UNITY_ENABLE_DETAIL_NORMALMAP = 16,
        //
        // 摘要:
        //     SHADER_API_MOBILE is set when compiling shader for mobile platforms.
        SHADER_API_MOBILE = 17,
        //
        // 摘要:
        //     SHADER_API_DESKTOP is set when compiling shader for "desktop" platforms.
        SHADER_API_DESKTOP = 18,
        //
        // 摘要:
        //     UNITY_HARDWARE_TIER1 is set when compiling shaders for GraphicsTier.Tier1.
        UNITY_HARDWARE_TIER1 = 19,
        //
        // 摘要:
        //     UNITY_HARDWARE_TIER2 is set when compiling shaders for GraphicsTier.Tier2.
        UNITY_HARDWARE_TIER2 = 20,
        //
        // 摘要:
        //     UNITY_HARDWARE_TIER3 is set when compiling shaders for GraphicsTier.Tier3.
        UNITY_HARDWARE_TIER3 = 21,
        //
        // 摘要:
        //     UNITY_COLORSPACE_GAMMA is set when compiling shaders for Gamma Color Space.
        UNITY_COLORSPACE_GAMMA = 22,
        //
        // 摘要:
        //     UNITY_LIGHT_PROBE_PROXY_VOLUME is set when Light Probe Proxy Volume feature is
        //     supported by the current graphics API and is enabled in the. You can only set
        //     a Graphics Tier in the Built-in Render Pipeline.
        UNITY_LIGHT_PROBE_PROXY_VOLUME = 23,
        //
        // 摘要:
        //     UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS is set automatically for platforms
        //     that don't require full floating-point precision support in fragment shaders.
        UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS = 24,
        //
        // 摘要:
        //     UNITY_LIGHTMAP_DLDR_ENCODING is set when lightmap textures are using double LDR
        //     encoding to store the values in the texture.
        UNITY_LIGHTMAP_DLDR_ENCODING = 25,
        //
        // 摘要:
        //     UNITY_LIGHTMAP_RGBM_ENCODING is set when lightmap textures are using RGBM encoding
        //     to store the values in the texture.
        UNITY_LIGHTMAP_RGBM_ENCODING = 26,
        //
        // 摘要:
        //     UNITY_LIGHTMAP_FULL_HDR is set when lightmap textures are not using any encoding
        //     to store the values in the texture.
        UNITY_LIGHTMAP_FULL_HDR = 27,
        //
        // 摘要:
        //     Is virtual texturing enabled and supported on this platform.
        UNITY_VIRTUAL_TEXTURING = 28,
        //
        // 摘要:
        //     Unity enables UNITY_PRETRANSFORM_TO_DISPLAY_ORIENTATION when Vulkan pre-transform
        //     is enabled and supported on the target build platform.
        UNITY_PRETRANSFORM_TO_DISPLAY_ORIENTATION = 29,
        //
        // 摘要:
        //     Unity enables UNITY_ASTC_NORMALMAP_ENCODING when DXT5nm-style normal maps are
        //     used on Android, iOS or tvOS.
        UNITY_ASTC_NORMALMAP_ENCODING = 30,
        //
        // 摘要:
        //     SHADER_API_ES30 is set when the Graphics API is OpenGL ES 3 and the minimum supported
        //     OpenGL ES 3 version is OpenGL ES 3.0.
        SHADER_API_GLES30 = 31,
        //
        // 摘要:
        //     Unity sets UNITY_UNIFIED_SHADER_PRECISION_MODEL if, in Player Settings, you set
        //     Shader Precision Model to Unified.
        UNITY_UNIFIED_SHADER_PRECISION_MODEL = 32
    }
}

