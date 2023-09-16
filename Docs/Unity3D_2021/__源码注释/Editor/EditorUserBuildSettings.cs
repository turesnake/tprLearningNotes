#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Bindings;

namespace UnityEditor;

//
// Summary:
//     User build settings for the Editor
[NativeHeader("Editor/Src/EditorUserBuildSettings.h")]
[StaticAccessor("GetEditorUserBuildSettings()", StaticAccessorType.Dot)]
public class EditorUserBuildSettings : UnityEngine.Object
{
    private const string kSettingWaitForManagedDebugger = "WaitForManagedDebugger";

    private const string kSettingManagedDebuggerFixedPort = "ManagedDebuggerFixedPort";

    //
    // Summary:
    //     Triggered in response to SwitchActiveBuildTarget.
    [Obsolete("UnityEditor.activeBuildTargetChanged has been deprecated.Use UnityEditor.Build.IActiveBuildTargetChanged instead.")]
    public static Action activeBuildTargetChanged;

    internal static extern AppleBuildAndRunType appleBuildAndRunType
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern string appleDeviceId
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The currently selected build target group.
    public static extern BuildTargetGroup selectedBuildTargetGroup
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern EmbeddedLinuxArchitecture selectedEmbeddedLinuxArchitecture
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedEmbeddedLinuxArchitecture")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedEmbeddedLinuxArchitecture")]
        set;
    }

    public static extern bool remoteDeviceInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern string remoteDeviceAddress
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern string remoteDeviceUsername
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern string remoteDeviceExports
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern string pathOnRemoteDevice
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The currently selected target for a standalone build.
    public static extern BuildTarget selectedStandaloneTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedStandaloneTarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedStandaloneTargetFromBindings")]
        set;
    }

    internal static extern StandaloneBuildSubtarget selectedStandaloneBuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedStandaloneBuildSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedStandaloneBuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     Desktop standalone build subtarget.
    public static extern StandaloneBuildSubtarget standaloneBuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetActiveStandaloneBuildSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetActiveStandaloneBuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     PS4 Build Subtarget.
    public static extern PS4BuildSubtarget ps4BuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedPS4BuildSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedPS4BuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     Specifies which version of PS4 hardware to target.
    public static extern PS4HardwareTarget ps4HardwareTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetPS4HardwareTarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetPS4HardwareTarget")]
        set;
    }

    //
    // Summary:
    //     Are null references actively validated?
    public static extern bool explicitNullChecks
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Are divide by zero's actively validated?
    public static extern bool explicitDivideByZeroChecks
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Are array bounds actively validated?
    public static extern bool explicitArrayBoundsChecks
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Build submission materials.
    public static extern bool needSubmissionMaterials
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Build data compressed with PSArc.
    [Obsolete("EditorUserBuildSettings.compressWithPsArc is obsolete and has no effect. It will be removed in a subsequent Unity release.")]
    public static bool compressWithPsArc
    {
        get
        {
            return false;
        }
        set
        {
        }
    }

    //
    // Summary:
    //     Force installation of package, even if error.
    public static extern bool forceInstallation
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Places the package on the outer edge of the disk.
    public static extern bool movePackageToDiscOuterEdge
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Compress files in package.
    public static extern bool compressFilesInPackage
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Whether the standalone player is built in headless mode.
    [Obsolete("Use EditorUserBuildSettings.standaloneBuildSubtarget instead.")]
    public static bool enableHeadlessMode
    {
        get
        {
            return standaloneBuildSubtarget == StandaloneBuildSubtarget.Server;
        }
        set
        {
            standaloneBuildSubtarget = (value ? StandaloneBuildSubtarget.Server : StandaloneBuildSubtarget.Player);
        }
    }

    //
    // Summary:
    //     Is build script only enabled.
    public static extern bool buildScriptsOnly
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Xbox Build subtarget.
    public static extern XboxBuildSubtarget xboxBuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedXboxBuildSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedXboxBuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     When building an Xbox One Streaming Install package (makepkg.exe) The layout
    //     generation code in Unity will assign each Scene and associated assets to individual
    //     chunks. Unity will mark Scene 0 as being part of the launch range, IE the set
    //     of chunks required to launch the game, you may include additional Scenes in this
    //     launch range if you desire, this specifies a range of Scenes (starting at 0)
    //     to be included in the launch set.
    public static extern int streamingInstallLaunchRange
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The currently selected Xbox One Deploy Method.
    public static extern XboxOneDeployMethod xboxOneDeployMethod
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedXboxOneDeployMethod")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedXboxOneDeployMethod")]
        set;
    }

    //
    // Summary:
    //     The currently selected Xbox One Deploy Drive.
    public static extern XboxOneDeployDrive xboxOneDeployDrive
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedXboxOneDeployDrive")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedXboxOneDeployDrive")]
        set;
    }

    //
    // Summary:
    //     Windows account username associated with PC share folder.
    [Obsolete("xboxOneUsername is deprecated, it is unnecessary and non-functional.")]
    public static string xboxOneUsername { get; set; }

    //
    // Summary:
    //     Network shared folder path e.g. MYCOMPUTER\SHAREDFOLDER\.
    [Obsolete("xboxOneNetworkSharePath is deprecated, it is unnecessary and non-functional.")]
    public static string xboxOneNetworkSharePath { get; set; }

    public static string xboxOneAdditionalDebugPorts { get; set; }

    //
    // Summary:
    //     Sets the XBox to reboot and redeploy when the deployment fails.
    public static bool xboxOneRebootIfDeployFailsAndRetry { get; set; }

    //
    // Summary:
    //     Android platform options.
    public static extern MobileTextureSubtarget androidBuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedAndroidBuildTextureSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedAndroidBuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     WebGL Build subtarget.
    public static extern WebGLTextureSubtarget webGLBuildSubtarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWebGLBuildTextureSubtarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWebGLBuildSubtarget")]
        set;
    }

    //
    // Summary:
    //     ETC2 texture decompression fallback on Android devices that don't support ETC2.
    public static extern AndroidETC2Fallback androidETC2Fallback
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedAndroidETC2Fallback")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedAndroidETC2Fallback")]
        set;
    }

    public static extern AndroidBuildSystem androidBuildSystem
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    public static extern AndroidBuildType androidBuildType
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Use deprecated Android SDK tools to pack application.
    [Obsolete("androidUseLegacySdkTools has been deprecated. It does not have any effect.")]
    public static extern bool androidUseLegacySdkTools
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Set to true to create a symbols.zip file in the same location as the .apk or
    //     .aab file.
    [Obsolete("androidCreateSymbolsZip has been deprecated. Use androidCreateSymbols property")]
    public static bool androidCreateSymbolsZip
    {
        get
        {
            return androidCreateSymbols != AndroidCreateSymbols.Disabled;
        }
        set
        {
            androidCreateSymbols = (value ? AndroidCreateSymbols.Public : AndroidCreateSymbols.Disabled);
        }
    }

    //
    // Summary:
    //     Specifies the type of symbol package to create.
    public static extern AndroidCreateSymbols androidCreateSymbols
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern string androidDeviceSocketAddress
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern string androidCurrentDeploymentTargetId
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Sets and gets target device type for the application to run on when building
    //     to Windows Store platform.
    [Obsolete("EditorUserBuildSettings.wsaSubtarget is obsolete and has no effect. It will be removed in a subsequent Unity release.")]
    public static WSASubtarget wsaSubtarget
    {
        get
        {
            return WSASubtarget.AnyDevice;
        }
        set
        {
        }
    }

    [Obsolete("EditorUserBuildSettings.wsaSDK is obsolete and has no effect.It will be removed in a subsequent Unity release.")]
    public static extern WSASDK wsaSDK
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSASDK")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSASDK")]
        set;
    }

    //
    // Summary:
    //     The build type for the Universal Windows Platform.
    public static extern WSAUWPBuildType wsaUWPBuildType
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSAUWPBuildType")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSAUWPBuildType")]
        set;
    }

    //
    // Summary:
    //     Sets and gets target UWP SDK to build Windows Store application against.
    public static extern string wsaUWPSDK
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSAUWPSDK")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSAUWPSDK")]
        set;
    }

    public static extern string wsaMinUWPSDK
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSAMinUWPSDK")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSAMinUWPSDK")]
        set;
    }

    public static extern string wsaArchitecture
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSAArchitecture")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSAArchitecture")]
        set;
    }

    //
    // Summary:
    //     Sets and gets Visual Studio version to build Windows Store application with.
    public static extern string wsaUWPVisualStudioVersion
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSAUWPVSVersion")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSAUWPVSVersion")]
        set;
    }

    //
    // Summary:
    //     Specifies the Windows DevicePortal connection address of the device to deploy
    //     and launch the UWP app on when using Build and Run.
    public static extern string windowsDevicePortalAddress
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetWindowsDevicePortalAddress")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetWindowsDevicePortalAddress")]
        set;
    }

    //
    // Summary:
    //     Specifies the Windows DevicePortal username for the device to deploy and launch
    //     the UWP app on when using Build and Run.
    public static extern string windowsDevicePortalUsername
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetWindowsDevicePortalUsername")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetWindowsDevicePortalUsername")]
        set;
    }

    //
    // Summary:
    //     Specifies the Windows DevicePortal password for the device to deploy and launch
    //     the UWP app on when using Build and Run.
    public static string windowsDevicePortalPassword { get; set; }

    //
    // Summary:
    //     Sets and gets the Windows device to launch the UWP app when using Build and Run.
    public static extern WSABuildAndRunDeployTarget wsaBuildAndRunDeployTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSelectedWSABuildAndRunDeployTarget")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSelectedWSABuildAndRunDeployTarget")]
        set;
    }

    //
    // Summary:
    //     The override for the maximum texture size when importing assets.
    public static extern int overrideMaxTextureSize
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The asset importing override of texture compression.
    public static extern OverrideTextureCompression overrideTextureCompression
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The currently active build target.
    public static extern BuildTarget activeBuildTarget
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    internal static extern BuildTargetGroup activeBuildTargetGroup
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     DEFINE directives for the compiler.
    public static extern string[] activeScriptCompilationDefines
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetActiveScriptCompilationDefinesBindingMethod")]
        get;
    }

    //
    // Summary:
    //     Enables a development build.
    public static extern bool development
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies code generation option for IL2CPP.
    public static extern Il2CppCodeGeneration il2CppCodeGeneration
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Use prebuilt JavaScript version of Unity engine.
    [Obsolete("Building with pre-built Engine option is no longer supported.", true)]
    public static bool webGLUsePreBuiltUnityEngine
    {
        get
        {
            return false;
        }
        set
        {
        }
    }

    //
    // Summary:
    //     Start the player with a connection to the profiler.
    public static extern bool connectProfiler
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Enables Deep Profiling support in the player.
    public static extern bool buildWithDeepProfilingSupport
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Enable source-level debuggers to connect.
    public static extern bool allowDebugging
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Sets the Player to wait for player connection on player start.
    public static extern bool waitForPlayerConnection
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Export Android Project for use with Android Studio/Gradle.
    public static extern bool exportAsGoogleAndroidProject
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Set to true to build an Android App Bundle (aab file) instead of an apk. The
    //     default value is false.
    public static extern bool buildAppBundle
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Symlink runtime libraries with an iOS Xcode project.
    [Obsolete("EditorUserBuildSettings.symlinkLibraries is obsolete. Use EditorUserBuildSettings.symlinkSources instead (UnityUpgradable) -> [UnityEditor] EditorUserBuildSettings.symlinkSources", false)]
    public static bool symlinkLibraries
    {
        get
        {
            return symlinkSources;
        }
        set
        {
            symlinkSources = value;
        }
    }

    //
    // Summary:
    //     Symlink sources when generating the project.
    public static extern bool symlinkSources
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern bool symlinkTrampoline
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The scheme Xcode uses to run this project.
    public static extern XcodeBuildConfig iOSXcodeBuildConfig
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetIOSXcodeBuildConfig")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetIOSXcodeBuildConfig")]
        set;
    }

    //
    // Summary:
    //     The scheme Xcode uses to run this project.
    public static extern XcodeBuildConfig macOSXcodeBuildConfig
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetMacOSXcodeBuildConfig")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetMacOSXcodeBuildConfig")]
        set;
    }

    //
    // Summary:
    //     Scheme with which the project will be run in Xcode.
    [Obsolete("iOSBuildConfigType is obsolete. Use iOSXcodeBuildConfig instead (UnityUpgradable) -> iOSXcodeBuildConfig", true)]
    public static iOSBuildType iOSBuildConfigType
    {
        get
        {
            return (iOSBuildType)iOSXcodeBuildConfig;
        }
        set
        {
            iOSXcodeBuildConfig = (XcodeBuildConfig)value;
        }
    }

    public static extern bool switchCreateRomFile
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetCreateRomFileForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetCreateRomFileForSwitch")]
        set;
    }

    public static extern bool switchEnableRomCompression
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetEnableRomCompressionForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetEnableRomCompressionForSwitch")]
        set;
    }

    public static extern bool switchSaveADF
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetSaveADFForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetSaveADFForSwitch")]
        set;
    }

    public static extern SwitchRomCompressionType switchRomCompressionType
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetRomCompressionTypeForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetRomCompressionTypeForSwitch")]
        set;
    }

    public static extern int switchRomCompressionLevel
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetRomCompressionLevelForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetRomCompressionLevelForSwitch")]
        set;
    }

    public static extern string switchRomCompressionConfig
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetRomCompressionConfigForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetRomCompressionConfigForSwitch")]
        set;
    }

    public static extern bool switchNVNGraphicsDebugger
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetNVNGraphicsDebuggerForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetNVNGraphicsDebuggerForSwitch")]
        set;
    }

    public static extern bool generateNintendoSwitchShaderInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetGenerateNintendoSwitchShaderInfo")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetGenerateNintendoSwitchShaderInfo")]
        set;
    }

    public static extern bool switchNVNShaderDebugging
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetNVNShaderDebugging")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetNVNShaderDebugging")]
        set;
    }

    [Obsolete("switchNVNDrawValidation is deprecated, use switchNVNDrawValidation_Heavy instead.")]
    public static bool switchNVNDrawValidation
    {
        get
        {
            return switchNVNDrawValidation_Heavy;
        }
        set
        {
            switchNVNDrawValidation_Heavy = value;
        }
    }

    public static extern bool switchNVNDrawValidation_Light
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetNVNDrawValidationLight")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetNVNDrawValidationLight")]
        set;
    }

    public static extern bool switchNVNDrawValidation_Heavy
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetNVNDrawValidationHeavy")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetNVNDrawValidationHeavy")]
        set;
    }

    public static extern bool switchEnableHeapInspector
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetEnableHeapInspectorForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetEnableHeapInspectorForSwitch")]
        set;
    }

    public static extern bool switchEnableDebugPad
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetEnableDebugPadForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetEnableDebugPadForSwitch")]
        set;
    }

    public static extern bool switchRedirectWritesToHostMount
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetRedirectWritesToHostMountForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetRedirectWritesToHostMountForSwitch")]
        set;
    }

    public static extern bool switchHTCSScriptDebugging
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetHTCSScriptDebuggingForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetHTCSScriptDebuggingForSwitch")]
        set;
    }

    public static extern bool switchUseLegacyNvnPoolAllocator
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetUseLegacyNvnPoolAllocatorForSwitch")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetUseLegacyNvnPoolAllocatorForSwitch")]
        set;
    }

    internal static SwitchShaderCompilerConfig switchShaderCompilerConfig
    {
        [NativeMethod("GetSwitchShaderCompilerConfig")]
        get
        {
            get_switchShaderCompilerConfig_Injected(out var ret);
            return ret;
        }
        [NativeMethod("SetSwitchShaderCompilerConfig")]
        set
        {
            set_switchShaderCompilerConfig_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Place the built player in the build folder.
    public static extern bool installInBuildFolder
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Instructs the player to wait for managed debugger to attach before executing
    //     any script code.
    public static bool waitForManagedDebugger
    {
        get
        {
            return GetPlatformSettings("Editor", "WaitForManagedDebugger") == "true";
        }
        set
        {
            SetPlatformSettings("Editor", "WaitForManagedDebugger", value.ToString().ToLower());
        }
    }

    //
    // Summary:
    //     Force the port used by the managed debugger. Default is 0 which means platform-specific
    //     auto-selection of a port.
    public static int managedDebuggerFixedPort
    {
        get
        {
            if (int.TryParse(GetPlatformSettings("Editor", "ManagedDebuggerFixedPort"), out var result) && 0 < result && result <= 65535)
            {
                return result;
            }

            return 0;
        }
        set
        {
            SetPlatformSettings("Editor", "ManagedDebuggerFixedPort", value.ToString().ToLower());
        }
    }

    //
    // Summary:
    //     Force full optimizations for script complilation in Development builds.
    [Obsolete("forceOptimizeScriptCompilation is obsolete - will always return false. Control script optimization using the 'IL2CPP optimization level' configuration in Player Settings / Other.")]
    public static bool forceOptimizeScriptCompilation => false;

    [Obsolete("androidDebugMinification is obsolete. Use PlayerSettings.Android.minifyDebug and PlayerSettings.Android.minifyWithR8.")]
    public static AndroidMinification androidDebugMinification
    {
        get
        {
            if (PlayerSettings.Android.minifyDebug)
            {
                return (!PlayerSettings.Android.minifyWithR8) ? AndroidMinification.Proguard : AndroidMinification.Gradle;
            }

            return AndroidMinification.None;
        }
        set
        {
            PlayerSettings.Android.minifyDebug = value != AndroidMinification.None;
            PlayerSettings.Android.minifyWithR8 = value == AndroidMinification.Gradle;
        }
    }

    [Obsolete("androidReleaseMinification is obsolete. Use PlayerSettings.Android.minifyRelease and PlayerSettings.Android.minifyWithR8.")]
    public static AndroidMinification androidReleaseMinification
    {
        get
        {
            if (PlayerSettings.Android.minifyRelease)
            {
                return (!PlayerSettings.Android.minifyWithR8) ? AndroidMinification.Proguard : AndroidMinification.Gradle;
            }

            return AndroidMinification.None;
        }
        set
        {
            PlayerSettings.Android.minifyRelease = value != AndroidMinification.None;
            PlayerSettings.Android.minifyWithR8 = value == AndroidMinification.Gradle;
        }
    }

    private EditorUserBuildSettings()
    {
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("GetSelectedSubTargetFor")]
    internal static extern int GetSelectedSubtargetFor(BuildTarget target);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetSelectedSubTargetFor")]
    internal static extern void SetSelectedSubtargetFor(BuildTarget target, int subtarget);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("GetActiveSubTargetFor")]
    internal static extern int GetActiveSubtargetFor(BuildTarget target);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetActiveSubTargetFor")]
    internal static extern void SetActiveSubtargetFor(BuildTarget target, int subtarget);

    internal static Compression GetCompressionType(BuildTargetGroup targetGroup)
    {
        return (Compression)GetCompressionTypeInternal(targetGroup);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("GetSelectedCompressionType")]
    private static extern int GetCompressionTypeInternal(BuildTargetGroup targetGroup);

    internal static void SetCompressionType(BuildTargetGroup targetGroup, Compression type)
    {
        SetCompressionTypeInternal(targetGroup, (int)type);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetSelectedCompressionType")]
    private static extern void SetCompressionTypeInternal(BuildTargetGroup targetGroup, int type);

    //
    // Summary:
    //     Select a new build target to be active.
    //
    // Parameters:
    //   target:
    //     Target build platform.
    //
    //   targetGroup:
    //     Build target group.
    //
    // Returns:
    //     True if the build target was successfully switched, false otherwise (for example,
    //     if license checks fail, files are missing, or if the user has cancelled the operation
    //     via the UI).
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SwitchActiveBuildTargetSync")]
    public static extern bool SwitchActiveBuildTarget(BuildTargetGroup targetGroup, BuildTarget target);

    //
    // Summary:
    //     Select a new build target to be active during the next Editor update.
    //
    // Parameters:
    //   targetGroup:
    //     Target build platform.
    //
    //   target:
    //     Build target group.
    //
    // Returns:
    //     True if the build target was successfully switched, false otherwise (for example,
    //     if license checks fail, files are missing, or if the user has cancelled the operation
    //     via the UI).
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SwitchActiveBuildTargetAsync")]
    public static extern bool SwitchActiveBuildTargetAsync(BuildTargetGroup targetGroup, BuildTarget target);

    public static bool SwitchActiveBuildTarget(NamedBuildTarget namedBuildTarget, BuildTarget target)
    {
        return BuildPlatforms.instance.BuildPlatformFromNamedBuildTarget(namedBuildTarget).SetActive(target);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SwitchActiveBuildTargetSyncNoCheck")]
    internal static extern bool SwitchActiveBuildTargetNoCheck(BuildTargetGroup targetGroup, BuildTarget target);

    //
    // Summary:
    //     Get the current location for the build.
    //
    // Parameters:
    //   target:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetBuildLocation(BuildTarget target);

    //
    // Summary:
    //     Set a new location for the build.
    //
    // Parameters:
    //   target:
    //
    //   location:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetBuildLocation(BuildTarget target, string location);

    //
    // Summary:
    //     Set platform specifc Editor setting.
    //
    // Parameters:
    //   platformName:
    //     The name of the platform.
    //
    //   name:
    //     The name of the setting.
    //
    //   value:
    //     Setting value.
    public static void SetPlatformSettings(string platformName, string name, string value)
    {
        string buildTargetGroupName = BuildPipeline.GetBuildTargetGroupName(BuildPipeline.GetBuildTargetByName(platformName));
        SetPlatformSettings(buildTargetGroupName, platformName, name, value);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetPlatformSettings(string buildTargetGroup, string buildTarget, string name, string value);

    //
    // Summary:
    //     Returns value for platform specifc Editor setting.
    //
    // Parameters:
    //   platformName:
    //     The name of the platform.
    //
    //   name:
    //     The name of the setting.
    public static string GetPlatformSettings(string platformName, string name)
    {
        string buildTargetGroupName = BuildPipeline.GetBuildTargetGroupName(BuildPipeline.GetBuildTargetByName(platformName));
        return GetPlatformSettings(buildTargetGroupName, platformName, name);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetPlatformSettings(string buildTargetGroup, string platformName, string name);

    //
    // Summary:
    //     Select a new build target to be active.
    //
    // Parameters:
    //   target:
    //     Target build platform.
    //
    //   targetGroup:
    //     Build target group.
    //
    // Returns:
    //     True if the build target was successfully switched, false otherwise (for example,
    //     if license checks fail, files are missing, or if the user has cancelled the operation
    //     via the UI).
    [Obsolete("Please use SwitchActiveBuildTarget(BuildTargetGroup targetGroup, BuildTarget target)")]
    public static bool SwitchActiveBuildTarget(BuildTarget target)
    {
        return SwitchActiveBuildTarget(BuildPipeline.GetBuildTargetGroup(target), target);
    }

    internal static void Internal_ActiveBuildTargetChanged()
    {
        if (activeBuildTargetChanged != null)
        {
            activeBuildTargetChanged();
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void get_switchShaderCompilerConfig_Injected(out SwitchShaderCompilerConfig ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void set_switchShaderCompilerConfig_Injected(ref SwitchShaderCompilerConfig value);
}

