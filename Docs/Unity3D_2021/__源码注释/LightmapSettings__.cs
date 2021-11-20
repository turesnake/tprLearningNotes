#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        摘要:
        Stores lightmaps of the Scene.

        一个场景可以存储数张 lightmaps, renderer 组件 可以使用这些 lightmaps;

    */
    [NativeHeaderAttribute("Runtime/Graphics/LightmapSettings.h")]
    [StaticAccessorAttribute("GetLightmapSettings()")]
    public sealed class LightmapSettings : Object
    {
        

        //     Lightmap array.
        public static LightmapData[] lightmaps { get; set; }


        /*
            摘要:
            NonDirectional or CombinedDirectional Specular lightmaps rendering mode.

            注意:

                this property is only serialized when building the player. 
                
                In all the other cases it's the responsibility of the Unity lightmapping system 
                (or a custom script that brings external lightmapping data) 
                to set it when the Scene loads or playmode is entered.
                ---
                在其他情况下, 应该由 unity 的 lightmapping系统 (或用户自定义的, 能提供 lightmapping 信息的 脚本)
                在 场景被加载时, 或 playmode 被 entered 时, 来设置本变量的值;

            enum:
            -- NonDirectional:
            -- CombinedDirectional:  有第二张 map 信息; (存储 方向性信息 )
        */
        public static LightmapsMode lightmapsMode { get; set; }
        

        /*
            摘要:
            Baked Light Probe data.

            当前激活的所有 scenes 中, 所有的 烘焙好的 lightprobe 信息, 都存储在这一个 实例中;

            Use this property to swap between pre-baked LightProbes objects at runtime.
        */
        public static LightProbes lightProbes { get; set; }

        /*
        [Obsolete("Use lightmapsMode instead.", false)]
        public static LightmapsModeLegacy lightmapsModeLegacy { get; set; }
        [Obsolete("Use QualitySettings.desiredColorSpace instead.", false)]
        public static ColorSpace bakedColorSpace { get; set; }
        */

    }
}

