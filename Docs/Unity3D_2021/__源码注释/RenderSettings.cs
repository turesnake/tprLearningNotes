#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     The Render Settings contain values for a range of visual elements in your Scene,
    //     like fog and ambient light.
    [NativeHeaderAttribute("Runtime/Camera/RenderSettings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/QualitySettingsTypes.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [StaticAccessorAttribute("GetRenderSettings()", Bindings.StaticAccessorType.Dot)]
    public sealed class RenderSettings : Object
    {
        [Obsolete("Use RenderSettings.ambientIntensity instead (UnityUpgradable) -> ambientIntensity", false)]
        public static float ambientSkyboxAmount { get; set; }
        //
        // 摘要:
        //     Size of the Light halos.
        public static float haloStrength { get; set; }
        //
        // 摘要:
        //     Cubemap resolution for default reflection.
        public static int defaultReflectionResolution { get; set; }
        //
        // 摘要:
        //     Default reflection mode.
        public static DefaultReflectionMode defaultReflectionMode { get; set; }
        //
        // 摘要:
        //     The number of times a reflection includes other reflections.
        public static int reflectionBounces { get; set; }
        //
        // 摘要:
        //     How much the skybox / custom cubemap reflection affects the Scene.
        public static float reflectionIntensity { get; set; }
        //
        // 摘要:
        //     Custom specular reflection cubemap.
        public static Cubemap customReflection { get; set; }
        //
        // 摘要:
        //     Custom or skybox ambient lighting data.
        public static SphericalHarmonicsL2 ambientProbe { get; set; }
        //
        // 摘要:
        //     The light used by the procedural skybox.
        public static Light sun { get; set; }
        //
        // 摘要:
        //     The global skybox to use.
        [NativePropertyAttribute("SkyboxMaterial")]
        public static Material skybox { get; set; }
        //
        // 摘要:
        //     The color used for the sun shadows in the Subtractive lightmode.
        public static Color subtractiveShadowColor { get; set; }
        //
        // 摘要:
        //     The intensity of all flares in the Scene.
        public static float flareStrength { get; set; }
        //
        // 摘要:
        //     Flat ambient lighting color.
        [NativePropertyAttribute("AmbientSkyColor")]
        public static Color ambientLight { get; set; }
        //
        // 摘要:
        //     Ambient lighting coming from below.
        public static Color ambientGroundColor { get; set; }
        //
        // 摘要:
        //     Ambient lighting coming from the sides.
        public static Color ambientEquatorColor { get; set; }
        //
        // 摘要:
        //     Ambient lighting coming from above.
        public static Color ambientSkyColor { get; set; }
        //
        // 摘要:
        //     Ambient lighting mode.
        public static AmbientMode ambientMode { get; set; }
        //
        // 摘要:
        //     The density of the exponential fog.
        public static float fogDensity { get; set; }
        //
        // 摘要:
        //     The color of the fog.
        public static Color fogColor { get; set; }
        //
        // 摘要:
        //     Fog mode to use.
        public static FogMode fogMode { get; set; }
        //
        // 摘要:
        //     The ending distance of linear fog.
        [NativePropertyAttribute("LinearFogEnd")]
        public static float fogEndDistance { get; set; }
        //
        // 摘要:
        //     The starting distance of linear fog.
        [NativePropertyAttribute("LinearFogStart")]
        public static float fogStartDistance { get; set; }
        //
        // 摘要:
        //     Is fog enabled?
        [NativePropertyAttribute("UseFog")]
        public static bool fog { get; set; }
        //
        // 摘要:
        //     How much the light from the Ambient Source affects the Scene.
        public static float ambientIntensity { get; set; }
        //
        // 摘要:
        //     The fade speed of all flares in the Scene.
        public static float flareFadeSpeed { get; set; }
    }
}

