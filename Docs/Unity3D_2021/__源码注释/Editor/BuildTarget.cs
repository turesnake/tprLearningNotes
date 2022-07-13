#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion


namespace UnityEditor
{
    /*
        Target build platform.

        可使用 EditorUserBuildSettings.activeBuildTarget 获得本次 build 操作选择的 目标平台;

        
    */
    [NativeTypeAttribute("Runtime/Serialize/SerializationMetaFlags.h")]
    public enum BuildTarget
    {
        NoTarget = -2,
        //
        // 摘要:
        //     OBSOLETE(过时的): Use iOS. Build an iOS player.
        iPhone = -1,
        BB10 = -1,
        MetroPlayer = -1,
        //
        // 摘要:
        //     Build a macOS standalone (Intel 64-bit).
        StandaloneOSX = 2,
        StandaloneOSXUniversal = 3,
        //
        // 摘要:
        //     Build a macOS Intel 32-bit standalone. (This build target is deprecated)
        StandaloneOSXIntel = 4,
        //
        // 摘要:
        //     Build a Windows standalone.
        StandaloneWindows = 5,
        //
        // 摘要:
        //     Build a web player. (This build target is deprecated. Building for web player
        //     will no longer be supported in future versions of Unity.)
        WebPlayer = 6,
        //
        // 摘要:
        //     Build a streamed web player.
        WebPlayerStreamed = 7,
        //
        // 摘要:
        //     Build an iOS player.
        iOS = 9,
        PS3 = 10,
        XBOX360 = 11,
        //
        // 摘要:
        //     Build an Android .apk standalone app.
        Android = 13,
        //
        // 摘要:
        //     Build a Linux standalone.
        StandaloneLinux = 17,
        //
        // 摘要:
        //     Build a Windows 64-bit standalone.
        StandaloneWindows64 = 19,
        //
        // 摘要:
        //     WebGL.
        WebGL = 20,
        //
        // 摘要:
        //     Build an Windows Store Apps player.
        WSAPlayer = 21,
        //
        // 摘要:
        //     Build a Linux 64-bit standalone.
        StandaloneLinux64 = 24,
        //
        // 摘要:
        //     Build a Linux universal standalone.
        StandaloneLinuxUniversal = 25,
        WP8Player = 26,
        //
        // 摘要:
        //     Build a macOS Intel 64-bit standalone. (This build target is deprecated)
        StandaloneOSXIntel64 = 27,
        BlackBerry = 28,
        Tizen = 29,
        PSP2 = 30,
        //
        // 摘要:
        //     Build a PS4 Standalone.
        PS4 = 31,
        PSM = 32,
        //
        // 摘要:
        //     Build a Xbox One Standalone.
        XboxOne = 33,
        SamsungTV = 34,
        //
        // 摘要:
        //     Build to Nintendo 3DS platform.
        N3DS = 35,
        WiiU = 36,
        //
        // 摘要:
        //     Build to Apple's tvOS platform.
        tvOS = 37,
        //
        // 摘要:
        //     Build a Nintendo Switch player.
        Switch = 38,
        Lumin = 39,
        //
        // 摘要:
        //     Build a Stadia standalone.
        Stadia = 40,
        //
        // 摘要:
        //     Build a CloudRendering standalone.
        CloudRendering = 41,
        GameCoreScarlett = 42,
        GameCoreXboxSeries = 42,
        GameCoreXboxOne = 43,
        //
        // 摘要:
        //     Build to PlayStation 5 platform.
        PS5 = 44,
        EmbeddedLinux = 45
    }
}

