#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        摘要:
        The Render Settings contain values for a range of visual elements in your Scene,
        like fog and ambient light.

    */
    [NativeHeaderAttribute("Runtime/Camera/RenderSettings.h")]
    [NativeHeaderAttribute("Runtime/Graphics/QualitySettingsTypes.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [StaticAccessorAttribute("GetRenderSettings()", Bindings.StaticAccessorType.Dot)]
    public sealed class RenderSettings : Object
    {

        /*
        [Obsolete("Use RenderSettings.ambientIntensity instead (UnityUpgradable) -> ambientIntensity", false)]
        public static float ambientSkyboxAmount { get; set; }
        */


        /*
            Size of the Light halos.
            对于任何光来说, halo 的 size = 本值 * "Light.range";
        */
        public static float haloStrength { get; set; }

        /*
            Cubemap resolution for "default reflection".
            猜测: cubemap 单面的 边长 (pix单位)
        */
        public static int defaultReflectionResolution { get; set; }


        /*
            Default reflection mode.
            Unity can use a custom texture or generate a specular reflection texture from the skybox.

            enum:
            -- Skybox:
                    Default specular reflection cubemap is calculated from the current skybox.
            -- Custom:
                    You can specify cubemap that will be used as a default specular reflection.
        */
        public static DefaultReflectionMode defaultReflectionMode { get; set; }

        /*
            The number of times a reflection includes other reflections.

            定义计算反射的次数。在一个给定的 pass 中，scene 被渲染成一个 cubemap，
            并将前一 pass 中计算的 反射信息,  应用于反射对象。

            如果本值设置为 1，场景将被渲染 1 次，
            
            which means that a reflection will not be able to reflect another reflection 
            and reflective objects will show up black, when seen in other reflective surfaces.
            那些镜面光滑的物体看起来是黑色的, 因为它们无法接收别的物体投射过来
            的反射信息;
            
            如果本值设置为 2，场景将被渲染 2 次，此时镜面光滑的物体 在上面能看到的别的物体;
            但是这种 反射只转折了一次;

            比如当两个镜子相对放置时, 本变量数值较低时, 镜子里的反射次数 是有限的;
        */
        public static int reflectionBounces { get; set; }

        
        //     How much the skybox / custom cubemap reflection affects the Scene.
        public static float reflectionIntensity { get; set; }


        //     Custom specular reflection cubemap.
        //  Specifies a cubemap for use as a default specular reflection.
        public static Cubemap customReflection { get; set; }


        /*
            Custom or skybox ambient lighting data.

            "Skybox ambient lighting mode" 使用本 球谐探针 来计算 ambient. 
            你也可以自定义一个 球谐探针, 放入本变量;


            GI 系统会烘焙 ambient probe, 但是那些使用了 lightprobe 或 lightmap 的物体不会用到本探针的数据;
            只有当上述两种 gi 技术无法使用, 或无法发挥作用时, 本探针的数据 才会被拿去照亮 物体;


            调整本变量 不会影响到 实时/烘焙GI 的输入值; 我需要改去调整 "RenderSettings.ambientMode",
            比如设置为 "AmbientMode.Trilight";

            GI系统会将 得到的 ambient values 写入本变量, 这意味着 自定义的 ambient probe 也会被 GI系统 覆写;
        */
        public static SphericalHarmonicsL2 ambientProbe { get; set; }


        /*
            The light used by the "procedural skybox".

            如果本值没有被设置, 将自动使用场景中最亮的 平行光;
        */
        public static Light sun { get; set; }


        /*
            The global skybox to use.

            If you change the skybox in playmode, 
            你必须调用 "DynamicGI.UpdateEnvironment()" 来更新 ambient probe.
        */
        [NativePropertyAttribute("SkyboxMaterial")]
        public static Material skybox { get; set; }


        /*
            The color used for the sun shadows in the "Subtractive lightmode".

            "Subtractive lightmode":
            光照和阴影, 都被烘培进 lightmap;  常用于低性能设备;
        */
        public static Color subtractiveShadowColor { get; set; }

        
        //     The intensity of all flares (镜头光斑) in the Scene.
        public static float flareStrength { get; set; }

        
        //     Flat ambient lighting color.
        //  Flat ambient lighting mode uses color. It has the same value as "RenderSettings.ambientSkyColor"
        [NativePropertyAttribute("AmbientSkyColor")]
        public static Color ambientLight { get; set; }


        /*
            Ambient lighting coming from below. 来自下方的环境照明。

            "Trilight ambient lighing mode" uses this color to affect 朝下的 object parts.
        */
        public static Color ambientGroundColor { get; set; }

        /*
            Ambient lighting coming from the sides. 来自两侧的环境照明。

            "Trilight ambient lighing mode" uses this color to affect 面向侧面的 object parts.

            In "Flat ambient lighting mode", equator color is just the single ambient color, 
            and has the same value as "RenderSettings.ambientLight";
        */
        public static Color ambientEquatorColor { get; set; }

        
        //     Ambient lighting coming from above.
        //  "Trilight ambient lighing mode" uses this color to affect 朝上的 object parts.
        public static Color ambientSkyColor { get; set; }

        
        //     Ambient lighting mode.
        public static AmbientMode ambientMode { get; set; }


        /*
            The density of the exponential fog.

            Fog density is used by "FogMode.Exponential" and "FogMode.ExponentialSquared" modes.
        */
        public static float fogDensity { get; set; }



        //     The color of the fog.
        public static Color fogColor { get; set; }

        /*
            Fog mode to use.

            enum:
            -- Linear
            -- Exponential
            -- ExponentialSquared ()默认值
        */
        public static FogMode fogMode { get; set; }


        /*
            The starting/ending distance of linear fog.

            Fog start and end distances are used by "FogMode.Linear" fog mode.
        */
        [NativePropertyAttribute("LinearFogStart")]
        public static float fogStartDistance { get; set; }

        [NativePropertyAttribute("LinearFogEnd")]
        public static float fogEndDistance { get; set; }

        

        //     Is fog enabled?
        [NativePropertyAttribute("UseFog")]
        public static bool fog { get; set; }



        //     How much the light from the Ambient Source affects the Scene.
        public static float ambientIntensity { get; set; }
      

        //     The fade speed of all flares(镜头光斑) in the Scene.
        public static float flareFadeSpeed { get; set; }
    }
}

