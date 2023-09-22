#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Bindings;

namespace UnityEditor;

//
// Summary:
//     Build target group.
[NativeType(Header = "Editor/Src/BuildPipeline/BuildTargetPlatformSpecific.h")]
public enum BuildTargetGroup
{
    //
    // Summary:
    //     Unknown target.
    Unknown = 0,
    //
    // Summary:
    //     PC (Windows, Mac, Linux) target.
    Standalone = 1,

    //
    // Summary:
    //     Mac/PC webplayer target.
    // [Obsolete("WebPlayer was removed in 5.4, consider using WebGL", true)]
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // WebPlayer = 2,

    //
    // Summary:
    //     OBSOLETE: Use iOS. Apple iOS target.
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("Use iOS instead (UnityUpgradable) -> iOS", true)]
    // iPhone = 4,

    //
    // Summary:
    //     Apple iOS target.
    iOS = 4,


    // [Obsolete("PS3 has been removed in >=5.5")]
    // PS3 = 5,

    // [Obsolete("XBOX360 has been removed in 5.5")]
    // XBOX360 = 6,


    //
    // Summary:
    //     Android target.
    Android = 7,
    //
    // Summary:
    //     WebGL.
    WebGL = 13,
    //
    // Summary:
    //     Windows Store Apps target.
    WSA = 14,


    // [Obsolete("Use WSA instead")]
    // Metro = 14,
    // [Obsolete("Use WSA instead")]
    // WP8 = 15,
    // [Obsolete("BlackBerry has been removed as of 5.4")]
    // BlackBerry = 16,
    // [Obsolete("Tizen has been removed in 2017.3")]
    // Tizen = 17,
    // [Obsolete("PSP2 is no longer supported as of Unity 2018.3")]
    // PSP2 = 18,


    //
    // Summary:
    //     Sony Playstation 4 target.
    PS4 = 19,


    // [Obsolete("PSM has been removed in >= 5.3")]
    // PSM = 20,

    //
    // Summary:
    //     Microsoft Xbox One target.
    XboxOne = 21,

    // [Obsolete("SamsungTV has been removed as of 2017.3")]
    // SamsungTV = 22,

    //
    // Summary:
    //     Nintendo 3DS target.
    // [Obsolete("Nintendo 3DS support is unavailable since 2018.1")]
    // N3DS = 23,
    // [Obsolete("Wii U support was removed in 2018.1")]
    // WiiU = 24,

    //
    // Summary:
    //     Apple's tvOS target.
    tvOS = 25,

    // [Obsolete("Facebook support was removed in 2019.3")]
    // Facebook = 26,

    //
    // Summary:
    //     Nintendo Switch target.
    Switch = 27,
    Lumin = 28,
    //
    // Summary:
    //     Google Stadia target.
    Stadia = 29,

    //
    // Summary:
    //     CloudRendering target.
    // [Obsolete("CloudRendering is deprecated, please use LinuxHeadlessSimulation (UnityUpgradable) -> LinuxHeadlessSimulation", false)]
    // CloudRendering = 30,

    //
    // Summary:
    //     LinuxHeadlessSimulation target.
    LinuxHeadlessSimulation = 30,


    // [Obsolete("GameCoreScarlett is deprecated, please use GameCoreXboxSeries (UnityUpgradable) -> GameCoreXboxSeries", false)]
    // GameCoreScarlett = 31,


    GameCoreXboxSeries = 31,
    GameCoreXboxOne = 32,
    //
    // Summary:
    //     Sony Playstation 5 target.
    PS5 = 33,
    EmbeddedLinux = 34
}


