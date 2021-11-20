#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;

namespace UnityEngine
{
    /*
        摘要:
        Data of a lightmap.

    */
    [NativeHeaderAttribute("Runtime/Graphics/LightmapData.h")]
    [UsedByNativeCodeAttribute]
    public sealed class LightmapData
    {
        public LightmapData();

        /*
        [Obsolete("Use lightmapColor property (UnityUpgradable) -> lightmapColor", false)]
        public Texture2D lightmapLight { get; set; }
        */


        /*
            摘要:
             Lightmap storing color of incoming light.
             第一张 map
        */
        public Texture2D lightmapColor { get; set; }


        /*
            摘要:
            Lightmap storing dominant direction of incoming light.
            第二张 map
        */
        public Texture2D lightmapDir { get; set; }


        /*
            摘要:
            Texture storing occlusion mask per light (ShadowMask, up to four lights).
            4个通道存储 4个光源的 遮蔽性信息;
            texel 值:
            -- 1f: 表示可见, 无遮蔽
            -- 0f: 表示不可见, 全遮蔽;
        */
        public Texture2D shadowMask { get; set; }



        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property LightmapData.lightmap has been deprecated. Use LightmapData.lightmapColor instead (UnityUpgradable) -> lightmapColor", true)]
        public Texture2D lightmap { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property LightmapData.lightmapFar has been deprecated. Use LightmapData.lightmapColor instead (UnityUpgradable) -> lightmapColor", true)]
        public Texture2D lightmapFar { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property LightmapData.lightmapNear has been deprecated. Use LightmapData.lightmapDir instead (UnityUpgradable) -> lightmapDir", true)]
        public Texture2D lightmapNear { get; set; }
        */


    }
}

