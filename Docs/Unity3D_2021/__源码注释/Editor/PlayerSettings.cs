#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.iOS;
using UnityEngine.Rendering;

namespace UnityEditor
{
    //
    // 摘要:
    //     Player Settings is where you define various parameters for the final game that
    //     you will build in Unity. Some of these values are used in the Resolution Dialog
    //     that launches when you open a standalone game.
    [NativeClassAttribute(null)]
    [NativeHeaderAttribute("Runtime/Misc/BuildSettings.h")]
    [NativeHeaderAttribute("Editor/Mono/PlayerSettings.bindings.h")]
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettingsSplashScreen.h")]
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
    [StaticAccessorAttribute("GetPlayerSettings()")]
    public sealed class PlayerSettings : UnityEngine.Object//PlayerSettings__RR
    {
        //
        // 摘要:
        //     Enable frame timing statistics.
        public static bool enableFrameTimingStats { get; set; }
        //
        // 摘要:
        //     Restrict standalone players to a single concurrent running instance.
        public static bool forceSingleInstance { get; set; }
        //
        // 摘要:
        //     Use DXGI Flip Model Swapchain for D3D11
        public static bool useFlipModelSwapchain { get; set; }
        //
        // 摘要:
        //     Specifies whether the application requires OpenGL ES 3.1 support.
        [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
        public static bool openGLRequireES31 { get; set; }
        //
        // 摘要:
        //     Specifies whether the application requires OpenGL ES 3.1 AEP support.
        [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
        public static bool openGLRequireES31AEP { get; set; }
        //
        // 摘要:
        //     Specifies whether the application requires OpenGL ES 3.2 support.
        [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
        public static bool openGLRequireES32 { get; set; }

        //
        // 摘要:
        //     The image to display in the Resolution Dialog window.
        // [Obsolete("resolutionDialogBanner has been removed.", false)]
        // public static Texture2D resolutionDialogBanner { get; set; }

        //
        // 摘要:
        //     Virtual Reality specific splash screen.
        [StaticAccessorAttribute("GetPlayerSettings().GetSplashScreenSettings()")]
        public static Texture2D virtualRealitySplashScreen { get; set; }

        //
        // 摘要:
        //     The bundle identifier of the iPhone application.
        // [Obsolete("iPhoneBundleIdentifier is deprecated. Use PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS) instead.")]
        // public static string iPhoneBundleIdentifier { get; set; }

        //
        // 摘要:
        //     If enabled, allows the user to switch between full screen and windowed mode using
        //     OS specific keyboard short cuts.
        public static bool allowFullscreenSwitch { get; set; }
        //
        // 摘要:
        //     Set to true to exact version matching for strong named assemblies.
        public static bool assemblyVersionValidation { get; set; }
        //
        // 摘要:
        //     Suppresses common C# warnings.
        public static bool suppressCommonWarnings { get; set; }
        //
        // 摘要:
        //     Allow 'unsafe' C# code code to be compiled for predefined assemblies.
        public static bool allowUnsafeCode { get; set; }

        //
        // 摘要:
        //     Set to true to make Unity use Roslyn reference assemblies when compiling scripts.
        //     Enabled by default.
        // [Obsolete("Use of reference assemblies is always enabled")]
        // public static bool useReferenceAssemblies { get; set; }

        //
        // 摘要:
        //     Allows you to enable or disable incremental mode for garbage collection.
        public static bool gcIncremental { get; set; }
        //
        // 摘要:
        //     Password used for interacting with the Android Keystore.
        public static string keystorePass { get; set; }
        //
        // 摘要:
        //     Password for the key used for signing an Android application.
        public static string keyaliasPass { get; set; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static string xboxTitleId { get; set; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static string xboxImageXexFilePath { get; }

        //
        // 摘要:
        //     The scripting runtime version setting. Change this to set the version the Editor
        //     uses and restart the Editor to apply the change.
        // [Obsolete("ScriptingRuntimeVersion has been deprecated in 2019.3 due to the removal of legacy mono")]
        // public static ScriptingRuntimeVersion scriptingRuntimeVersion { get; set; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static string xboxSpaFilePath { get; }


        //
        // 摘要:
        //     On Windows, show the application in the background if Fullscreen Windowed mode
        //     is used.
        public static bool visibleInBackground { get; set; }
        //
        // 摘要:
        //     Switch display to HDR mode (if available).
        public static bool useHDRDisplay { get; set; }
        public static bool defaultIsNativeResolution { get; set; }
        //
        // 摘要:
        //     Enable Retina support for macOS.
        public static bool macRetinaSupport { get; set; }
        //
        // 摘要:
        //     If enabled, your game will continue to run after lost focus.
        public static bool runInBackground { get; set; }
        //
        // 摘要:
        //     Defines if fullscreen games should darken secondary displays.
        public static bool captureSingleScreen { get; set; }
        //
        // 摘要:
        //     Write a log file with debugging information.
        public static bool usePlayerLog { get; set; }
        //
        // 摘要:
        //     Use resizable window in standalone player builds.
        public static bool resizableWindow { get; set; }
        //
        // 摘要:
        //     Pre bake collision meshes on player build.
        public static bool bakeCollisionMeshes { get; set; }
        //
        // 摘要:
        //     Enable receipt validation for the Mac App Store.
        public static bool useMacAppStoreValidation { get; set; }
        //
        // 摘要:
        //     The number of bits in each color channel for swap chain buffers. (Direct3D 11
        //     and Direct3D 12 mode).
        public static D3DHDRDisplayBitDepth D3DHDRBitDepth { get; set; }

        //
        // 摘要:
        //     Define how to handle fullscreen mode in macOS standalones.
        // [Obsolete("macFullscreenMode is deprecated, use fullScreenMode instead")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static MacFullscreenMode macFullscreenMode { get; set; }

        //
        // 摘要:
        //     Define how to handle fullscreen mode in Windows standalones (Direct3D 11 mode).
        // [Obsolete("d3d11FullscreenMode is deprecated, use fullScreenMode instead")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static D3D11FullscreenMode d3d11FullscreenMode { get; set; }


        //
        // 摘要:
        //     Platform agnostic setting to define fullscreen behavior. Not all platforms support
        //     all modes.
        [NativePropertyAttribute("FullscreenMode")]
        public static FullScreenMode fullScreenMode { get; set; }

        //
        // 摘要:
        //     Enable Virtual Reality support on the current build target.
        // [Obsolete("This API is obsolete, and should no longer be used. Please use XRManagerSettings in the XR Management package instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static bool virtualRealitySupported { get; set; }


        //
        // 摘要:
        //     Enable 360 Stereo Capture support on the current build target.
        public static bool enable360StereoCapture { get; set; }

        //
        // 摘要:
        //     Should Unity support single-pass stereo rendering?
        // [Obsolete("singlePassStereoRendering will be deprecated. Use stereoRenderingPath instead.")]
        // public static bool singlePassStereoRendering { get; set; }


        //
        // 摘要:
        //     Active stereo rendering path
        public static StereoRenderingPath stereoRenderingPath { get; set; }

        //
        // 摘要:
        //     Protect graphics memory.
        // [Obsolete("protectGraphicsMemory is deprecated. This field has no effect.", false)]
        // public static bool protectGraphicsMemory { get; set; }

        //
        // 摘要:
        //     Stops or allows audio from other applications to play in the background while
        //     your Unity application is running.
        public static bool muteOtherAudioSources { get; set; }


        //
        // 摘要:
        //     Define how to handle fullscreen mode in Windows standalones (Direct3D 9 mode).
        // [Obsolete("d3d9FullscreenMode is deprecated, use fullScreenMode instead")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static D3D9FullscreenMode d3d9FullscreenMode { get; set; }


        //
        // 摘要:
        //     If enabled, the game will default to fullscreen mode.
        // [Obsolete("(defaultIsFullScreen is deprecated, use fullScreenMode instead")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static bool defaultIsFullScreen { get; set; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxGenerateSpa { get; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxDeployKinectResources { get; }

        //
        // 摘要:
        //     Remove unused Engine code from your build (IL2CPP-only).
        public static bool stripEngineCode { get; set; }
        //
        // 摘要:
        //     Default screen orientation for mobiles.
        [NativePropertyAttribute("DefaultScreenOrientation")]
        public static UIOrientation defaultInterfaceOrientation { get; set; }
        //
        // 摘要:
        //     Is auto-rotation to portrait supported?
        [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static bool allowedAutorotateToPortrait { get; set; }
        //
        // 摘要:
        //     Is auto-rotation to portrait upside-down supported?
        [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static bool allowedAutorotateToPortraitUpsideDown { get; set; }
        //
        // 摘要:
        //     Is auto-rotation to landscape right supported?
        [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static bool allowedAutorotateToLandscapeRight { get; set; }
        //
        // 摘要:
        //     Is auto-rotation to landscape left supported?
        [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static bool allowedAutorotateToLandscapeLeft { get; set; }
        //
        // 摘要:
        //     Let the OS autorotate the screen as the device orientation changes.
        [NativePropertyAttribute("UseAnimatedAutoRotation")]
        public static bool useAnimatedAutorotation { get; set; }
        //
        // 摘要:
        //     32-bit Display Buffer is used.
        public static bool use32BitDisplayBuffer { get; set; }

        //
        // 摘要:
        //     Deprecated. Use PlayerSettings.GetManagedStrippingLevel and PlayerSettings.SetManagedStrippingLevel
        //     instead.
        // [Obsolete("strippingLevel is deprecated, Use PlayerSettings.GetManagedStrippingLevel()/PlayerSettings.SetManagedStrippingLevel() instead. StripByteCode and UseMicroMSCorlib are no longer supported.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static StrippingLevel strippingLevel { get; set; }


        /*
            When enabled, preserves the alpha value in the framebuffer to support rendering over native UI on Android.
        */
        public static bool preserveFramebufferAlpha { get; set; }


        //
        // 摘要:
        //     Should unused Mesh components be excluded from game build?
        public static bool stripUnusedMeshComponents { get; set; }
        //
        // 摘要:
        //     Enable mip stripping for all platforms.
        public static bool mipStripping { get; set; }
        //
        // 摘要:
        //     Is the advanced version being used?
        [NativePropertyAttribute("hasAdvancedVersion", UnityEngine.Bindings.TargetType.Field)]
        [StaticAccessorAttribute("GetBuildSettings()")]
        public static bool advancedLicense { get; }
        //
        // 摘要:
        //     Additional AOT compilation options. Shared by AOT platforms.
        public static string aotOptions { get; set; }
        //
        // 摘要:
        //     The default cursor for your application.
        public static Texture2D defaultCursor { get; set; }
        //
        // 摘要:
        //     Default cursor's click position in pixels from the top left corner of the cursor
        //     image.
        public static Vector2 cursorHotspot { get; set; }
        //
        // 摘要:
        //     Accelerometer update frequency.
        public static int accelerometerFrequency { get; set; }
        //
        // 摘要:
        //     Is multi-threaded rendering enabled?
        public static bool MTRendering { get; set; }

        //
        // 摘要:
        //     Deprecated. Use PlayerSettings.GetApiCompatibilityLevel and PlayerSettings.SetApiCompatibilityLevel
        //     instead.
        // [Obsolete("apiCompatibilityLevel is deprecated. Use PlayerSettings.GetApiCompatibilityLevel()/PlayerSettings.SetApiCompatibilityLevel() instead.")]
        // public static ApiCompatibilityLevel apiCompatibilityLevel { get; set; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxEnableGuest { get; }

        //
        // 摘要:
        //     Returns if status bar should be hidden. Supported on iOS only; on Android, the
        //     status bar is always hidden.
        [NativePropertyAttribute("UIStatusBarHidden")]
        public static bool statusBarHidden { get; set; }
        //
        // 摘要:
        //     The application identifier for the currently selected build target.
        public static string applicationIdentifier { get; set; }

        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxDeployKinectHeadOrientation { get; set; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxDeployKinectHeadPosition { get; set; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static Texture2D xboxSplashScreen { get; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static int xboxAdditionalTitleMemorySize { get; set; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxEnableKinect { get; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxEnableKinectAutoTracking { get; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static bool xboxEnableSpeech { get; }
        // [Obsolete("Xbox 360 has been removed in >=5.5")]
        // public static uint xboxSpeechDB { get; }


        //
        // 摘要:
        //     Application bundle version shared between iOS & Android platforms.
        [NativePropertyAttribute("ApplicationVersion")]
        public static string bundleVersion { get; set; }
        //
        // 摘要:
        //     Enable GPU skinning on capable platforms.
        [NativePropertyAttribute("GPUSkinning")]
        public static bool gpuSkinning { get; set; }
        //
        // 摘要:
        //     Selects the graphics job mode to use on platforms that support both Native and
        //     Legacy graphics jobs.
        public static GraphicsJobMode graphicsJobMode { get; set; }
        public static bool xboxPIXTextureCapture { get; }
        //
        // 摘要:
        //     Xbox 360 Avatars.
        public static bool xboxEnableAvatar { get; }
        public static int xboxOneResolution { get; }
        //
        // 摘要:
        //     Enables internal profiler.
        public static bool enableInternalProfiler { get; set; }
        //
        // 摘要:
        //     Sets the crash behavior on .NET unhandled exception.
        public static ActionOnDotNetUnhandledException actionOnDotNetUnhandledException { get; set; }
        //
        // 摘要:
        //     Are ObjC uncaught exceptions logged?
        public static bool logObjCUncaughtExceptions { get; set; }
        //
        // 摘要:
        //     Enables CrashReport API.
        public static bool enableCrashReportAPI { get; set; }
        //
        // 摘要:
        //     Enable graphics jobs (multi threaded rendering).
        public static bool graphicsJobs { get; set; }

        //
        // 摘要:
        //     Defines the behaviour of the Resolution Dialog on product launch.
        // [Obsolete("displayResolutionDialog has been removed.", false)]
        // public static ResolutionDialogSetting displayResolutionDialog { get; set; }


        //
        // 摘要:
        //     Default vertical dimension of web player window.
        public static int defaultWebScreenHeight { get; set; }
        //
        // 摘要:
        //     Default horizontal dimension of web player window.
        public static int defaultWebScreenWidth { get; set; }
        //
        // 摘要:
        //     Applies the display rotation during rendering.
        public static bool vulkanEnablePreTransform { get; set; }


        //
        // 摘要:
        //     Use software command buffers for building rendering commands on Vulkan.
        // [Obsolete("Vulkan SW command buffers are deprecated, vulkanUseSWCommandBuffers will be ignored.")]
        // public static bool vulkanUseSWCommandBuffers { get; set; }


        //
        // 摘要:
        //     Delays acquiring the swapchain image until after the frame is rendered.
        public static bool vulkanEnableLateAcquireNextImage { get; set; }
        //
        // 摘要:
        //     Set number of swapchain buffers to be used with Vulkan renderer
        public static uint vulkanNumSwapchainBuffers { get; set; }
        //
        // 摘要:
        //     Enables Graphics.SetSRGBWrite() on Vulkan renderer.
        public static bool vulkanEnableSetSRGBWrite { get; set; }

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Use PlayerSettings.applicationIdentifier instead (UnityUpgradable) -> UnityEditor.PlayerSettings.applicationIdentifier", true)]
        // public static string bundleIdentifier { get; set; }
        // [Obsolete("mobileRenderingPath is ignored, use UnityEditor.Rendering.TierSettings with UnityEditor.Rendering.SetTierSettings/GetTierSettings instead", false)]
        // public static RenderingPath mobileRenderingPath { get; set; }

        //
        // 摘要:
        //     Which rendering path is enabled?
        // [Obsolete("renderingPath is ignored, use UnityEditor.Rendering.TierSettings with UnityEditor.Rendering.SetTierSettings/GetTierSettings instead", false)]
        // public static RenderingPath renderingPath { get; set; }

        //
        // 摘要:
        //     Describes the reason for access to the user's location data.
        // [Obsolete("Use PlayerSettings.iOS.locationUsageDescription instead (UnityUpgradable) -> UnityEditor.PlayerSettings/iOS.locationUsageDescription", false)]
        // public static string locationUsageDescription { get; set; }

        // [Obsolete("targetIOSGraphics is ignored, use SetGraphicsAPIs/GetGraphicsAPIs APIs", false)]
        // public static TargetIOSGraphics targetIOSGraphics { get; set; }

        //
        // 摘要:
        //     Should Direct3D 11 be used when available?
        // [Obsolete("Use UnityEditor.PlayerSettings.SetGraphicsAPIs/GetGraphicsAPIs instead")]
        // public static bool useDirect3D11 { get; set; }

        // [Obsolete("targetGlesGraphics is ignored, use SetGraphicsAPIs/GetGraphicsAPIs APIs", false)]
        // public static TargetGlesGraphics targetGlesGraphics { get; set; }

        //
        // 摘要:
        //     First level to have access to all Resources.Load assets in Streamed Web Players.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Use AssetBundles instead for streaming data", true)]
        // public static int firstStreamedLevelWithResources { get; set; }

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("The option alwaysDisplayWatermark is deprecated and is always false", true)]
        // public static bool alwaysDisplayWatermark { get; set; }

        //
        // 摘要:
        //     Enables Metal API validation in the Editor.
        [NativePropertyAttribute("MetalAPIValidation")]
        public static bool enableMetalAPIValidation { get; set; }

        //
        // 摘要:
        //     Should player render in stereoscopic 3d on supported hardware?
        // [Obsolete("Use VREditor.GetStereoDeviceEnabled instead")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static bool stereoscopic3D { get; set; }

        //
        // 摘要:
        //     The name of your company.
        public static string companyName { get; set; }
        //
        // 摘要:
        //     Default vertical dimension of stand-alone player window.
        public static int defaultScreenHeight { get; set; }
        //
        // 摘要:
        //     Default horizontal dimension of stand-alone player window.
        public static int defaultScreenWidth { get; set; }



        /*
            Set the rendering color space for the current project.
            面板设置: inspector - settings - Player - color space
        */
        public static ColorSpace colorSpace { get; set; }



        public static Guid productGUID { get; }

        //
        // 摘要:
        //     A unique cloud project identifier. It is unique for every project (Read Only).
        // [Obsolete("cloudProjectId is deprecated, use CloudProjectSettings.projectId instead")]
        // public static string cloudProjectId { get; }

        //
        // 摘要:
        //     The style to use for the builtin Unity splash screen.
        // [NativePropertyAttribute("SplashScreenLogoStyle")]
        // [Obsolete("Use PlayerSettings.SplashScreen.unityLogoStyle instead")]
        // [StaticAccessorAttribute("GetPlayerSettings().GetSplashScreenSettings()")]
        // public static SplashScreenStyle splashScreenStyle { get; set; }

        //
        // 摘要:
        //     Should the builtin Unity splash screen be shown?
        // [Obsolete("Use PlayerSettings.SplashScreen.show instead")]
        // [StaticAccessorAttribute("GetPlayerSettings().GetSplashScreenSettings()")]
        // public static bool showUnitySplashScreen { get; set; }

        //
        // 摘要:
        //     The name of your product.
        public static string productName { get; set; }
        //
        // 摘要:
        //     Defines whether the BlendShape weight range in SkinnedMeshRenderers is clamped.
        public static bool legacyClampBlendShapeWeights { get; set; }

        //
        // 摘要:
        //     Gets an array of additional compiler arguments set for a specific BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     The BuildTargetGroup to get the compiler arguments for.
        //
        // 返回结果:
        //     Returns an array with the compiler arguments associated with a BuildTargetGroup.
        [NativeMethodAttribute("GetAdditionalCompilerArgumentsForGroup")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static string[] GetAdditionalCompilerArgumentsForGroup(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     IL2CPP build arguments.
        [NativeMethodAttribute("c_str")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly().additionalIl2CppArgs")]
        public static string GetAdditionalIl2CppArgs();
        //
        // 摘要:
        //     Gets .NET API compatibility level for specified BuildTargetGroup.
        //
        // 参数:
        //   buildTargetGroup:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static ApiCompatibilityLevel GetApiCompatibilityLevel(BuildTargetGroup buildTargetGroup);
        //
        // 摘要:
        //     Get the application identifier for the specified platform.
        //
        // 参数:
        //   targetGroup:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static string GetApplicationIdentifier(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Gets the BuildTargetPlatformGroup architecture.
        //
        // 参数:
        //   targetGroup:
        [NativeMethodAttribute("GetPlatformArchitecture")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static int GetArchitecture(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Returns the default ScriptingImplementation used for the given platform group.
        //
        // 参数:
        //   targetGroup:
        //     The platform group to retrieve the scripting backend for.
        //
        // 返回结果:
        //     A ScriptingImplementation object that describes the default scripting backend
        //     used on that platform.
        [FreeFunctionAttribute("GetDefaultScriptingBackendForGroup")]
        public static ScriptingImplementation GetDefaultScriptingBackend(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Get graphics APIs to be used on a build platform.
        //
        // 参数:
        //   platform:
        //     Platform to get APIs for.
        //
        // 返回结果:
        //     Array of graphics APIs.
        [NativeMethodAttribute("GetPlatformGraphicsAPIs")]
        public static GraphicsDeviceType[] GetGraphicsAPIs(BuildTarget platform);
        //
        // 摘要:
        //     Returns the list of assigned icons for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   kind:
        public static Texture2D[] GetIconsForTargetGroup(BuildTargetGroup platform);
        //
        // 摘要:
        //     Returns the list of assigned icons for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   kind:
        public static Texture2D[] GetIconsForTargetGroup(BuildTargetGroup platform, IconKind kind);
        //
        // 摘要:
        //     Returns a list of icon sizes for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   kind:
        public static int[] GetIconSizesForTargetGroup(BuildTargetGroup platform);
        //
        // 摘要:
        //     Returns a list of icon sizes for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   kind:
        public static int[] GetIconSizesForTargetGroup(BuildTargetGroup platform, IconKind kind);
        //
        // 摘要:
        //     Gets compiler configuration used when compiling generated C++ code for a particular
        //     BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     Build target group.
        //
        // 返回结果:
        //     Compiler configuration.
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static Il2CppCompilerConfiguration GetIl2CppCompilerConfiguration(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Does IL2CPP platform use incremental build?
        //
        // 参数:
        //   targetGroup:
        [NativeMethodAttribute("GetPlatformIncrementalIl2CppBuild")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static bool GetIncrementalIl2CppBuild(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Returns the ManagedStrippingLevel used for the given platform group.
        //
        // 参数:
        //   targetGroup:
        //     The target platform group whose code stripping level you want to retrieve.
        //
        // 返回结果:
        //     The managed code stripping level set for the specified build target platform
        //     group.
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static ManagedStrippingLevel GetManagedStrippingLevel(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Check if multithreaded rendering option for mobile platform is enabled.
        //
        // 参数:
        //   targetGroup:
        //     Mobile platform (Only iOS, tvOS and Android).
        //
        // 返回结果:
        //     Return true if multithreaded rendering option for targetGroup platform is enabled.
        public static bool GetMobileMTRendering(BuildTargetGroup targetGroup);
        //
        // 摘要:
        //     Returns the NormalMapEncoding used for the given platform group.
        //
        // 参数:
        //   targetGroup:
        //     The target platform group whose normal map encoding you want to retrieve.
        //
        //   platform:
        //
        // 返回结果:
        //     The NormalMapEncoding for the given platform group.
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static NormalMapEncoding GetNormalMapEncoding(BuildTargetGroup platform);
        //
        // 摘要:
        //     Returns the list of available icon slots for the specified platform and PlatformIconKind|kind.
        //
        // 参数:
        //   platform:
        //     The full list of platforms that support this API and the supported icon kinds
        //     can be found in PlatformIconKind|icon kinds.
        //
        //   kind:
        //     Each platform supports a different set of PlatformIconKind|icon kinds. These
        //     can be found in the specific platform namespace (for example iOSPlatformIconKind.
        public static PlatformIcon[] GetPlatformIcons(BuildTargetGroup platform, PlatformIconKind kind);
        //
        // 摘要:
        //     Returns the assets that will be loaded at start up in the player and be kept
        //     alive until the player terminates.
        //
        // 返回结果:
        //     The assets to be preloaded.
        public static UnityEngine.Object[] GetPreloadedAssets();

        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyBool(string name);

        //
        // 摘要:
        //     Returns a PlayerSettings named bool property (with an optional build target it
        //     should apply to).
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        //
        // 返回结果:
        //     The current value of the property.
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static bool GetPropertyBool(string name, BuildTargetGroup target);

        //
        // 摘要:
        //     Returns a PlayerSettings named int property (with an optional build target it
        //     should apply to).
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        //
        // 返回结果:
        //     The current value of the property.
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static int GetPropertyInt(string name, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static int GetPropertyInt(string name);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalBool(string name, ref bool value);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalBool(string name, ref bool value, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalInt(string name, ref int value);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalInt(string name, ref int value, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalString(string name, ref string value, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static bool GetPropertyOptionalString(string name, ref string value);

        //
        // 摘要:
        //     Returns a PlayerSettings named string property (with an optional build target
        //     it should apply to).
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        //
        // 返回结果:
        //     The current value of the property.
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static string GetPropertyString(string name, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static string GetPropertyString(string name);



        //
        // 摘要:
        //     Gets the scripting framework for a BuildTargetPlatformGroup.
        //
        // 参数:
        //   targetGroup:
        [NativeMethodAttribute("GetPlatformScriptingBackend")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static ScriptingImplementation GetScriptingBackend(BuildTargetGroup targetGroup);
        public static void GetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup, out string[] defines);

        /*
            摘要:
                Get user-specified symbols for script compilation for the given build target group.

                会得到类似:
                    "ENABLE_CRIWARE_ADX;STEAMWORKS_NET;DREAMTECK_SPLINES" 的一串字符串,
                    内涵了 程序代码中主动声明的 一些 宏


            
            参数:
              targetGroup:
        */
        [NativeMethodAttribute("GetUserScriptingDefineSymbolsForGroup")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static string GetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup);



        //
        // 摘要:
        //     Gets the active shader precision model.
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()")]
        public static ShaderPrecisionModel GetShaderPrecisionModel();
        //
        // 摘要:
        //     Get stack trace logging options.
        //
        // 参数:
        //   logType:
        [NativeMethodAttribute("GetStackTraceType")]
        public static StackTraceLogType GetStackTraceLogType(LogType logType);
        //
        // 摘要:
        //     Retrieve all icon kinds supported by the specified platform.
        //
        // 参数:
        //   platform:
        public static PlatformIconKind[] GetSupportedIconKindsForPlatform(BuildTargetGroup platform);
        //
        // 摘要:
        //     Returns a value of a custom template variable.
        //
        // 参数:
        //   name:
        //     Name of the variable.
        //
        // 返回结果:
        //     The current value of the custom template variable.
        public static string GetTemplateCustomValue(string name);
        //
        // 摘要:
        //     Is a build platform using automatic graphics API choice?
        //
        // 参数:
        //   platform:
        //     Platform to get the flag for.
        //
        // 返回结果:
        //     Should best available graphics API be used.
        [NativeMethodAttribute("GetPlatformAutomaticGraphicsAPIs")]
        public static bool GetUseDefaultGraphicsAPIs(BuildTarget platform);

        //
        // 摘要:
        //     Returns whether or not Virtual Reality Support is enabled for a given BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     The BuildTargetGroup to return the value for.
        //
        // 返回结果:
        //     True if Virtual Reality Support is enabled.
        // [Obsolete("This API is deprecated and will be removed prior to shipping 2020.2", false)]
        // public static bool GetVirtualRealitySupported(BuildTargetGroup targetGroup);

        //
        // 摘要:
        //     Is virtual texturing enabled.
        //
        // 返回结果:
        //     True if virtual texturing is enabled, false otherwise.
        [NativeMethodAttribute("GetVirtualTexturingSupportEnabled")]
        [StaticAccessorAttribute("GetPlayerSettings()")]
        public static bool GetVirtualTexturingSupportEnabled();
        [StaticAccessorAttribute("GetPlayerSettings()")]
        public static bool GetWsaHolographicRemotingEnabled();
        //
        // 摘要:
        //     Returns whether or not the specified aspect ratio is enabled.
        //
        // 参数:
        //   aspectRatio:
        [NativeMethodAttribute("AspectRatioEnabled")]
        public static bool HasAspectRatio(AspectRatio aspectRatio);
        //
        // 摘要:
        //     Sets additional compiler arguments for a BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     The BuildTargetGroup to set the additional compiler arguments for.
        //
        //   additionalCompilerArguments:
        //     An array of the additional compiler arguments.
        public static void SetAdditionalCompilerArgumentsForGroup(BuildTargetGroup targetGroup, string[] additionalCompilerArguments);


        /*
            IL2CPP build arguments.

            可在一个 editor 目录下的 cs代码里实现一个 static 函数, (可在 unity 主界面调用的那种), 然后在这个函数内调用本 函数,

            若向本函数的 string 参数传入一个 "" (空string), 则会抹除之前的所有配置;

            参数:
            additionalArgs:



        */
        [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static void SetAdditionalIl2CppArgs(string additionalArgs);



        //
        // 摘要:
        //     Sets .NET API compatibility level for specified BuildTargetGroup.
        //
        // 参数:
        //   buildTargetGroup:
        //
        //   value:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetApiCompatibilityLevel(BuildTargetGroup buildTargetGroup, ApiCompatibilityLevel value);
        //
        // 摘要:
        //     Set the application identifier for the specified platform.
        //
        // 参数:
        //   targetGroup:
        //
        //   identifier:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetApplicationIdentifier(BuildTargetGroup targetGroup, string identifier);
        //
        // 摘要:
        //     Sets the BuildTargetPlatformGroup architecture.
        //
        // 参数:
        //   targetGroup:
        //
        //   architecture:
        [NativeMethodAttribute("SetPlatformArchitecture")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetArchitecture(BuildTargetGroup targetGroup, int architecture);
        //
        // 摘要:
        //     Enables the specified aspect ratio.
        //
        // 参数:
        //   aspectRatio:
        //
        //   enable:
        public static void SetAspectRatio(AspectRatio aspectRatio, bool enable);
        //
        // 摘要:
        //     Sets the graphics APIs used on a build platform.
        //
        // 参数:
        //   platform:
        //     Platform to set APIs for.
        //
        //   apis:
        //     Array of graphics APIs.
        public static void SetGraphicsAPIs(BuildTarget platform, GraphicsDeviceType[] apis);
        //
        // 摘要:
        //     Assign a list of icons for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   icons:
        //
        //   kind:
        public static void SetIconsForTargetGroup(BuildTargetGroup platform, Texture2D[] icons);
        //
        // 摘要:
        //     Assign a list of icons for the specified platform.
        //
        // 参数:
        //   platform:
        //
        //   icons:
        //
        //   kind:
        public static void SetIconsForTargetGroup(BuildTargetGroup platform, Texture2D[] icons, IconKind kind);
        //
        // 摘要:
        //     Sets compiler configuration used when compiling generated C++ code for a particular
        //     BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     Build target group.
        //
        //   configuration:
        //     Compiler configuration.
        public static void SetIl2CppCompilerConfiguration(BuildTargetGroup targetGroup, Il2CppCompilerConfiguration configuration);
        //
        // 摘要:
        //     Sets incremental build flag.
        //
        // 参数:
        //   targetGroup:
        //
        //   enabled:
        [NativeMethodAttribute("SetPlatformIncrementalIl2CppBuild")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetIncrementalIl2CppBuild(BuildTargetGroup targetGroup, bool enabled);
        //
        // 摘要:
        //     Sets the managed code stripping level for specified BuildTargetGroup.
        //
        // 参数:
        //   BuildTargetGroup:
        //     The platform build target group whose stripping level you want to set.
        //
        //   ManagedStrippingLevel:
        //     The desired managed code stripping level.
        //
        //   targetGroup:
        //
        //   level:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetManagedStrippingLevel(BuildTargetGroup targetGroup, ManagedStrippingLevel level);
        //
        // 摘要:
        //     Enable or disable multithreaded rendering option for mobile platform.
        //
        // 参数:
        //   targetGroup:
        //     Mobile platform (Only iOS, tvOS and Android).
        //
        //   enable:
        public static void SetMobileMTRendering(BuildTargetGroup targetGroup, bool enable);
        //
        // 摘要:
        //     Sets the normal map encoding for the given platform.
        //
        // 参数:
        //   targetGroup:
        //     The platform build target group whose normal map encoding you want to set.
        //
        //   normalMapEncoding:
        //     The desired normal map encoding.
        //
        //   platform:
        //
        //   encoding:
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetNormalMapEncoding(BuildTargetGroup platform, NormalMapEncoding encoding);
        //
        // 摘要:
        //     Assign a list of icons for the specified platform and icon kind.
        //
        // 参数:
        //   type:
        //     Each platform supports a different set of PlatformIconKind|icon kinds. These
        //     can be found in the specific platform namespace (for example iOSPlatformIconKind).
        //
        //   platform:
        //     The full list of platforms that support this API the supported kinds can be found
        //     in PlatformIconKind|icon kinds.
        //
        //   icons:
        //     All available PlatformIcon slots must be retrieved with GetPlatformIcons.
        //
        //   kind:
        public static void SetPlatformIcons(BuildTargetGroup platform, PlatformIconKind kind, PlatformIcon[] icons);
        //
        // 摘要:
        //     Assigns the assets that will be loaded at start up in the player and be kept
        //     alive until the player terminates.
        //
        // 参数:
        //   assets:
        public static void SetPreloadedAssets(UnityEngine.Object[] assets);

        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyBool(string name, bool value, BuildTarget target);

        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyBool(string name, bool value);

        //
        // 摘要:
        //     Sets a PlayerSettings named bool property.
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   value:
        //     Value of the property (bool).
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static void SetPropertyBool(string name, bool value, BuildTargetGroup target);

        //
        // 摘要:
        //     Sets a PlayerSettings named int property.
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   value:
        //     Value of the property (int).
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static void SetPropertyInt(string name, int value, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyInt(string name, int value);
        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyInt(string name, int value, BuildTarget target);
        //
        // 摘要:
        //     Sets a PlayerSettings named string property.
        //
        // 参数:
        //   name:
        //     Name of the property.
        //
        //   value:
        //     Value of the property (string).
        //
        //   target:
        //     BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown
        //     to apply to all targets).
        // [Obsolete("Use explicit API instead.")]
        // [StaticAccessorAttribute("PlayerSettingsBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        // public static void SetPropertyString(string name, string value, BuildTargetGroup target);
        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyString(string name, string value, BuildTarget target);
        // [Obsolete("Use explicit API instead.")]
        // public static void SetPropertyString(string name, string value);
        //
        // 摘要:
        //     Sets the scripting framework for a BuildTargetPlatformGroup.
        //
        // 参数:
        //   targetGroup:
        //
        //   backend:
        [NativeMethodAttribute("SetPlatformScriptingBackend")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetScriptingBackend(BuildTargetGroup targetGroup, ScriptingImplementation backend);
        //
        // 摘要:
        //     Set user-specified symbols for script compilation for the given build target
        //     group.
        //
        // 参数:
        //   targetGroup:
        //     The name of the group of devices.
        //
        //   defines:
        //     Symbols for this group can be passed as an array or as a string separated by
        //     semicolons.
        public static void SetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup, string[] defines);
        //
        // 摘要:
        //     Set user-specified symbols for script compilation for the given build target
        //     group.
        //
        // 参数:
        //   targetGroup:
        //     The name of the group of devices.
        //
        //   defines:
        //     Symbols for this group can be passed as an array or as a string separated by
        //     semicolons.
        public static void SetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup, string defines);
        //
        // 摘要:
        //     Sets the shader precision model.
        //
        // 参数:
        //   model:
        //     The new precision model to use.
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()")]
        public static void SetShaderPrecisionModel(ShaderPrecisionModel model);
        //
        // 摘要:
        //     Set stack trace logging options. Note: calling this function will implicitly
        //     call Application.SetStackTraceLogType.
        //
        // 参数:
        //   logType:
        //
        //   stackTraceType:
        [NativeMethodAttribute("SetStackTraceType")]
        public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);
        //
        // 摘要:
        //     Sets a value of a custom template variable.
        //
        // 参数:
        //   name:
        //     Name of the variable.
        //
        //   value:
        //     Value of the custom template variable.
        public static void SetTemplateCustomValue(string name, string value);
        //
        // 摘要:
        //     Should a build platform use automatic graphics API choice.
        //
        // 参数:
        //   platform:
        //     Platform to set the flag for.
        //
        //   automatic:
        //     Should best available graphics API be used?
        public static void SetUseDefaultGraphicsAPIs(BuildTarget platform, bool automatic);

        //
        // 摘要:
        //     Sets whether or not Virtual Reality Support is enabled for a given BuildTargetGroup.
        //
        // 参数:
        //   targetGroup:
        //     The BuildTargetGroup to set the value for.
        //
        //   value:
        //     The value to set, true to enable, false to disable.
        // [Obsolete("This API is deprecated and will be removed prior to shipping 2020.2", false)]
        // public static void SetVirtualRealitySupported(BuildTargetGroup targetGroup, bool value);

        //
        // 摘要:
        //     Enable virtual texturing.
        //
        // 参数:
        //   enabled:
        //     True to enable, false to disable.
        [NativeMethodAttribute("SetVirtualTexturingSupportEnabled")]
        [StaticAccessorAttribute("GetPlayerSettings()")]
        public static void SetVirtualTexturingSupportEnabled(bool enabled);
        [StaticAccessorAttribute("GetPlayerSettings()")]
        public static void SetWsaHolographicRemotingEnabled(bool enabled);

        //
        // 摘要:
        //     Where Unity takes input from (subscripbes to events).
        public enum WSAInputSource
        {
            //
            // 摘要:
            //     Subscribe to CoreWindow events.
            CoreWindow = 0,
            //
            // 摘要:
            //     Create Independent Input Source and receive input from it.
            IndependentInputSource = 1,
            //
            // 摘要:
            //     Subscribe to SwapChainPanel events.
            SwapChainPanel = 2
        }
        //
        // 摘要:
        //     Image types, supported by Windows Store Apps.
        public enum WSAImageType
        {
            PackageLogo = 1,
            SplashScreenImage = 2,
            UWPSquare44x44Logo = 31,
            UWPSquare71x71Logo = 32,
            UWPSquare150x150Logo = 33,
            UWPSquare310x310Logo = 34,
            UWPWide310x150Logo = 35
        }
        //
        // 摘要:
        //     Various image scales, supported by Windows Store Apps.
        public enum WSAImageScale
        {
            Target16 = 16,
            Target24 = 24,
            Target32 = 32,
            Target48 = 48,
            _80 = 80,
            _100 = 100,
            _125 = 125,
            _140 = 140,
            _150 = 150,
            _180 = 180,
            _200 = 200,
            _240 = 240,
            Target256 = 256,
            _400 = 400
        }
        public enum WSATargetFamily
        {
            Desktop = 0,
            Mobile = 1,
            Xbox = 2,
            Holographic = 3,
            Team = 4,
            IoT = 5,
            IoTHeadless = 6
        }
        public enum WSACapability
        {
            EnterpriseAuthentication = 0,
            InternetClient = 1,
            InternetClientServer = 2,
            MusicLibrary = 3,
            PicturesLibrary = 4,
            PrivateNetworkClientServer = 5,
            RemovableStorage = 6,
            SharedUserCertificates = 7,
            VideosLibrary = 8,
            WebCam = 9,
            Proximity = 10,
            Microphone = 11,
            Location = 12,
            HumanInterfaceDevice = 13,
            AllJoyn = 14,
            BlockedChatMessages = 15,
            Chat = 16,
            CodeGeneration = 17,
            Objects3D = 18,
            PhoneCall = 19,
            UserAccountInformation = 20,
            VoipCall = 21,
            Bluetooth = 22,
            SpatialPerception = 23,
            InputInjectionBrokered = 24,
            Appointments = 25,
            BackgroundMediaPlayback = 26,
            Contacts = 27,
            LowLevelDevices = 28,
            OfflineMapsManagement = 29,
            PhoneCallHistoryPublic = 30,
            PointOfService = 31,
            RecordedCallsFolder = 32,
            RemoteSystem = 33,
            SystemManagement = 34,
            UserDataTasks = 35,
            UserNotificationListener = 36,
            GazeInput = 37
        }
        public enum WSAApplicationForegroundText
        {
            Light = 1,
            Dark = 2
        }
        public enum WSADefaultTileSize
        {
            NotSet = 0,
            Medium = 1,
            Wide = 2
        }
        public enum WSAApplicationShowName
        {
            NotSet = 0,
            AllLogos = 1,
            NoLogos = 2,
            StandardLogoOnly = 3,
            WideLogoOnly = 4
        }

        //
        // 摘要:
        //     Describes File Type Association declaration.
        public struct WSAFileTypeAssociations
        {
            //
            // 摘要:
            //     Localizable string that will be displayed to the user as associated file handler.
            public string name;
            //
            // 摘要:
            //     Supported file types for this association.
            public WSASupportedFileType[] supportedFileTypes;
        }
        //
        // 摘要:
        //     Describes supported file type for File Type Association declaration.
        [RequiredByNativeCodeAttribute]
        public struct WSASupportedFileType
        {
            //
            // 摘要:
            //     The 'Content Type' value for the file type's MIME content type. For example:
            //     'image/jpeg'. Can also be left blank.
            public string contentType;
            //
            // 摘要:
            //     File type extension. For ex., .myUnityGame
            public string fileType;
        }
        //
        // 摘要:
        //     A single logo that is shown during the Splash Screen. Controls the Sprite that
        //     is displayed and its duration.
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettingsSplashScreen.h")]
        public struct SplashScreenLogo
        {
            //
            // 摘要:
            //     The Unity logo Sprite.
            public static Sprite unityLogo { get; }
            //
            // 摘要:
            //     The Sprite that is shown during this logo. If this is null, then no logo will
            //     be displayed for the duration.
            public Sprite logo { get; set; }
            //
            // 摘要:
            //     The total time in seconds for which the logo is shown. The minimum duration is
            //     2 seconds.
            public float duration { get; set; }

            [ExcludeFromDocs]
            public static SplashScreenLogo Create(float duration);
            [ExcludeFromDocs]
            public static SplashScreenLogo Create();
            //
            // 摘要:
            //     Creates a new Splash Screen logo with the provided duration and logo Sprite.
            //
            // 参数:
            //   duration:
            //     The total time in seconds that the logo will be shown. Note minimum time is 2
            //     seconds.
            //
            //   logo:
            //     The logo Sprite to display.
            //
            // 返回结果:
            //     The new logo.
            public static SplashScreenLogo Create([UnityEngine.Internal.DefaultValue("k_MinLogoTime")] float duration, [UnityEngine.Internal.DefaultValue("null")] Sprite logo);
            [ExcludeFromDocs]
            public static SplashScreenLogo CreateWithUnityLogo();
            //
            // 摘要:
            //     Creates a new Splash Screen logo with the provided duration and the unity logo.
            //
            // 参数:
            //   duration:
            //     The total time in seconds that the logo will be shown. Note minimum time is 2
            //     seconds.
            //
            // 返回结果:
            //     The new logo.
            public static SplashScreenLogo CreateWithUnityLogo([UnityEngine.Internal.DefaultValue("k_MinLogoTime")] float duration);
        }

        //
        // 摘要:
        //     Windows Mixed Reality specific Player Settings.
        // [Obsolete("This API is deprecated and will be removed in 2020.2.", false)]
        // public static class VRWindowsMixedReality
        // {
        //     //
        //     // 摘要:
        //     //     Set the requested depth buffer format to either 16Bit or 24Bit.
        //     [Obsolete("This API is deprecated and will be removed in 2020.2.", false)]
        //     public static DepthBufferFormat depthBufferFormat { get; set; }
        //     //
        //     // 摘要:
        //     //     Toggle support for sharing the depth buffer between Unity and the OS. This allows
        //     //     for stability improvements when running in Windows Mixed Reality. For immersive
        //     //     headsets this allows the operating system to reproject the rendered scene when
        //     //     there is a loss of accuracy in tracking. For Holographic headsets this allows
        //     //     for the operating system to automatically set a focus point along the plane that
        //     //     intersects the most content in your scene. See Also:
        //     [Obsolete("This API is deprecated and will be removed in 2020.2.", false)]
        //     public static bool depthBufferSharingEnabled { get; set; }

        //     //
        //     // 摘要:
        //     //     Enumeration providing valid values for PlayerSettings.VRWindowsMixedReality.depthBufferFormat.
        //     [Obsolete("This API is deprecated and will be removed in 2020.2.", false)]
        //     public enum DepthBufferFormat
        //     {
        //         //
        //         // 摘要:
        //         //     Set the Windows Mixed Reality depth buffer to 16 bits of depth. This will decrease
        //         //     the amount of memory (and possibly increase performance) at the expense of depth
        //         //     testing and precision.
        //         DepthBufferFormat16Bit = 0,
        //         //
        //         // 摘要:
        //         //     Set the Windows Mixed Reality depth buffer to 24 bits of depth. This will improve
        //         //     depth testing and precision at the expense of more memory.
        //         DepthBufferFormat24Bit = 1
        //     }
        // }
        //
        // 摘要:
        //     tvOS specific player settings.
        [NativeHeaderAttribute("Editor/Src/EditorUserBuildSettings.h")]
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings()")]
        public class tvOS
        {
            public tvOS();

            //
            // 摘要:
            //     Active tvOS SDK version used for build.
            public static tvOSSdkVersion sdkVersion { get; set; }
            //
            // 摘要:
            //     The build number of the bundle
            public static string buildNumber { get; set; }
            //
            // 摘要:
            //     Deployment minimal version of tvOS.
            // [Obsolete("targetOSVersion is obsolete. Use targetOSVersionString instead.", false)]
            // public static tvOSTargetOSVersion targetOSVersion { get; set; }
            //
            // 摘要:
            //     Deployment minimal version of tvOS.
            public static string targetOSVersionString { get; set; }
            //
            // 摘要:
            //     Application requires extended game controller.
            public static bool requireExtendedGameController { get; set; }
        }
        //
        // 摘要:
        //     Nintendo Switch Player settings.
        [NativeHeaderAttribute("Editor/Mono/PlayerSettingsSwitch.bindings.h")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public sealed class Switch
        {
            public Switch();

            [NativePropertyAttribute("switchApplicationErrorCodeCategory", UnityEngine.Bindings.TargetType.Function)]
            public static string applicationErrorCodeCategory { get; set; }
            [NativePropertyAttribute("switchAllowsRuntimeAddOnContentInstall", UnityEngine.Bindings.TargetType.Field)]
            public static bool isRuntimeAddOnContentInstallEnabled { get; set; }
            [NativePropertyAttribute("switchAllowsVideoCapturing", UnityEngine.Bindings.TargetType.Field)]
            public static bool isVideoCapturingEnabled { get; set; }
            // [NativePropertyAttribute("switchAllowsScreenshot", UnityEngine.Bindings.TargetType.Field)]
            // [Obsolete("isAllowsScreenshot was renamed to isScreenshotEnabled")]
            // public static bool isAllowsScreenshot { get; set; }
            [NativePropertyAttribute("switchAllowsScreenshot", UnityEngine.Bindings.TargetType.Field)]
            public static bool isScreenshotEnabled { get; set; }
            [NativePropertyAttribute("switchParentalControl", UnityEngine.Bindings.TargetType.Field)]
            public static bool isUnderParentalControl { get; set; }
            public static string[] localCommunicationIds { get; set; }
            [NativePropertyAttribute("switchRatingsMask", UnityEngine.Bindings.TargetType.Field)]
            public static int ratingsMask { get; set; }
            public static int cardSpecClock { get; set; }
            public static int cardSpecSize { get; set; }
            [NativePropertyAttribute("switchApplicationAttribute", UnityEngine.Bindings.TargetType.Field)]
            public static ApplicationAttribute applicationAttribute { get; set; }
            [NativePropertyAttribute("switchUserAccountSaveDataJournalSize", UnityEngine.Bindings.TargetType.Field)]
            public static int userAccountSaveDataJournalSize { get; set; }
            [NativePropertyAttribute("switchUserAccountSaveDataSize", UnityEngine.Bindings.TargetType.Field)]
            public static int userAccountSaveDataSize { get; set; }
            [NativePropertyAttribute("switchMicroSleepForYieldTime", UnityEngine.Bindings.TargetType.Field)]
            public static int switchMicroSleepForYieldTime { get; set; }
            [NativePropertyAttribute("switchLogoType", UnityEngine.Bindings.TargetType.Field)]
            public static LogoType logoType { get; set; }
            [NativePropertyAttribute("switchSupportedLanguagesMask", UnityEngine.Bindings.TargetType.Field)]
            public static int supportedLanguages { get; set; }
            [NativePropertyAttribute("switchDataLossConfirmation", UnityEngine.Bindings.TargetType.Field)]
            public static bool isDataLossConfirmationEnabled { get; set; }
            [NativePropertyAttribute("switchUserAccountLockEnabled", UnityEngine.Bindings.TargetType.Field)]
            public static bool isUserAccountLockEnabled { get; set; }
            // [NativePropertyAttribute("switchDataLossConfirmation", UnityEngine.Bindings.TargetType.Field)]
            // [Obsolete("isDataLossConfirmation was renamed to isDataLossConfirmationEnabled")]
            // public static bool isDataLossConfirmation { get; set; }
            [NativePropertyAttribute("switchSupportedNpadStyles", UnityEngine.Bindings.TargetType.Field)]
            public static SupportedNpadStyle supportedNpadStyles { get; set; }
            [NativePropertyAttribute("switchPlayerConnectionEnabled", UnityEngine.Bindings.TargetType.Field)]
            public static bool playerConnectionEnabled { get; set; }
            [NativePropertyAttribute("switchNetworkInterfaceManagerInitializeEnabled", UnityEngine.Bindings.TargetType.Field)]
            public static bool networkInterfaceManagerInitializeEnabled { get; set; }
            [NativePropertyAttribute("switchSocketInitializeEnabled", UnityEngine.Bindings.TargetType.Field)]
            public static bool socketInitializeEnabled { get; set; }
            [NativePropertyAttribute("switchSocketBufferEfficiency", UnityEngine.Bindings.TargetType.Field)]
            public static int socketBufferEfficiency { get; set; }
            [NativePropertyAttribute("switchUdpReceiveBufferSize", UnityEngine.Bindings.TargetType.Field)]
            public static int udpReceiveBufferSize { get; set; }
            [NativePropertyAttribute("switchUdpSendBufferSize", UnityEngine.Bindings.TargetType.Field)]
            public static int udpSendBufferSize { get; set; }
            [NativePropertyAttribute("switchTcpAutoReceiveBufferSizeMax", UnityEngine.Bindings.TargetType.Field)]
            public static int tcpAutoReceiveBufferSizeMax { get; set; }
            [NativePropertyAttribute("switchTcpAutoSendBufferSizeMax", UnityEngine.Bindings.TargetType.Field)]
            public static int tcpAutoSendBufferSizeMax { get; set; }
            [NativePropertyAttribute("switchTcpInitialReceiveBufferSize", UnityEngine.Bindings.TargetType.Field)]
            public static int tcpInitialReceiveBufferSize { get; set; }
            [NativePropertyAttribute("switchTcpInitialSendBufferSize", UnityEngine.Bindings.TargetType.Field)]
            public static int tcpInitialSendBufferSize { get; set; }
            [NativePropertyAttribute("switchSocketConfigEnabled", UnityEngine.Bindings.TargetType.Field)]
            public static bool socketConfigEnabled { get; set; }
            [NativePropertyAttribute("switchSupportedNpadCount", UnityEngine.Bindings.TargetType.Field)]
            public static int supportedNpadCount { get; set; }
            [NativePropertyAttribute("switchIsHoldTypeHorizontal", UnityEngine.Bindings.TargetType.Field)]
            public static bool isHoldTypeHorizontal { get; set; }
            [NativePropertyAttribute("switchNativeFsCacheSize", UnityEngine.Bindings.TargetType.Field)]
            public static int nativeFsCacheSize { get; set; }
            public static int[] ratingAgeArray { get; set; }
            [NativePropertyAttribute("switchTouchScreenUsage", UnityEngine.Bindings.TargetType.Field)]
            public static TouchScreenUsage touchScreenUsage { get; set; }
            [NativePropertyAttribute("switchStartupUserAccount", UnityEngine.Bindings.TargetType.Field)]
            public static StartupUserAccount startupUserAccount { get; set; }
            [NativePropertyAttribute("switchDisplayVersion", UnityEngine.Bindings.TargetType.Function)]
            public static string displayVersion { get; set; }
            public static string releaseVersion { get; set; }
            [StaticAccessorAttribute("PlayerSettings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
            public static int defaultSwitchQueueComputeMemory { get; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int queueComputeMemory { get; set; }
            [StaticAccessorAttribute("PlayerSettings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
            public static int minimumSwitchQueueControlMemory { get; }
            [StaticAccessorAttribute("PlayerSettings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
            public static int defaultSwitchQueueControlMemory { get; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int queueControlMemory { get; set; }
            [StaticAccessorAttribute("PlayerSettings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
            public static int minimumSwitchQueueCommandMemory { get; }
            [StaticAccessorAttribute("PlayerSettings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
            public static int defaultSwitchQueueCommandMemory { get; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int queueCommandMemory { get; set; }
            [NativePropertyAttribute("switchSystemResourceMemory", UnityEngine.Bindings.TargetType.Field)]
            public static int systemResourceMemory { get; set; }
            [NativePropertyAttribute("switchUseGOLDLinker", UnityEngine.Bindings.TargetType.Field)]
            public static bool useSwitchGOLDLinker { get; set; }
            [NativePropertyAttribute("switchLTOSetting", UnityEngine.Bindings.TargetType.Field)]
            public static int switchLTOSetting { get; set; }
            [NativePropertyAttribute("switchUseCPUProfiler", UnityEngine.Bindings.TargetType.Field)]
            public static bool useSwitchCPUProfiler { get; set; }
            [NativePropertyAttribute("switchSocketConcurrencyLimit", UnityEngine.Bindings.TargetType.Field)]
            public static int socketConcurrencyLimit { get; set; }
            [NativePropertyAttribute("switchSocketAllocatorPoolSize", UnityEngine.Bindings.TargetType.Field)]
            public static int socketAllocatorPoolSize { get; set; }
            [NativePropertyAttribute("switchSocketMemoryPoolSize", UnityEngine.Bindings.TargetType.Field)]
            public static int socketMemoryPoolSize { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int NVNShaderPoolsGranularity { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int NVNDefaultPoolsGranularity { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int NVNOtherPoolsGranularity { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int NVNMaxPublicTextureIDCount { get; set; }
            [NativePropertyAttribute("switchLogoHandling", UnityEngine.Bindings.TargetType.Field)]
            public static LogoHandling logoHandling { get; set; }
            [NativePropertyAttribute("switchPresenceGroupId", UnityEngine.Bindings.TargetType.Function)]
            public static string presenceGroupId { get; set; }
            [NativePropertyAttribute("switchMainThreadStackSize", UnityEngine.Bindings.TargetType.Field)]
            public static int mainThreadStackSize { get; set; }
            public static string legalInformationPath { get; set; }
            public static string accessibleURLPath { get; set; }
            public static string manualHTMLPath { get; set; }
            public static Texture2D[] smallIcons { get; set; }
            [NativePropertyAttribute("switchUseNewStyleFilepaths", UnityEngine.Bindings.TargetType.Field)]
            public static bool useNewStyleFilepaths { get; set; }
            public static Texture2D[] icons { get; set; }
            public static string[] titleNames { get; set; }
            [NativePropertyAttribute("switchNSODependencies", UnityEngine.Bindings.TargetType.Function)]
            public static string nsoDependencies { get; set; }
            [NativePropertyAttribute("switchApplicationID", UnityEngine.Bindings.TargetType.Function)]
            public static string applicationID { get; set; }
            public static string NMETAOverrideFullPath { get; }
            public static string NMETAOverride { get; set; }
            [NativePropertyAttribute("switchScreenResolutionBehavior", UnityEngine.Bindings.TargetType.Field)]
            public static ScreenResolutionBehavior screenResolutionBehavior { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int NVNMaxPublicSamplerIDCount { get; set; }
            public static string[] publisherNames { get; set; }
            [NativePropertyAttribute("switchUseMicroSleepForYield", UnityEngine.Bindings.TargetType.Field)]
            public static bool switchUseMicroSleepForYield { get; set; }

            public static int GetRatingAge(RatingCategories category);

            public enum ScreenResolutionBehavior
            {
                Manual = 0,
                OperationMode = 1,
                PerformanceMode = 2,
                Both = 3
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum Languages
            {
                AmericanEnglish = 0,
                BritishEnglish = 1,
                Japanese = 2,
                French = 3,
                German = 4,
                LatinAmericanSpanish = 5,
                Spanish = 6,
                Italian = 7,
                Dutch = 8,
                CanadianFrench = 9,
                Portuguese = 10,
                Russian = 11,
                SimplifiedChinese = 12,
                TraditionalChinese = 13,
                Korean = 14,
                BrazilianPortuguese = 15
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum StartupUserAccount
            {
                None = 0,
                Required = 1,
                RequiredWithNetworkServiceAccountAvailable = 2
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum TouchScreenUsage
            {
                Supported = 0,
                Required = 1,
                None = 2
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum LogoHandling
            {
                Auto = 0,
                Manual = 1
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum LogoType
            {
                LicensedByNintendo = 0,
                DistributedByNintendo = 1,
                Nintendo = 2
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum ApplicationAttribute
            {
                None = 0,
                Demo = 1
            }
            //
            // 摘要:
            //     Player Settings for the Nintendo Switch platform.
            public enum RatingCategories
            {
                CERO = 0,
                GRACGCRB = 1,
                GSRMR = 2,
                ESRB = 3,
                ClassInd = 4,
                USK = 5,
                PEGI = 6,
                PEGIPortugal = 7,
                PEGIBBFC = 8,
                Russian = 9,
                ACB = 10,
                OFLC = 11,
                IARCGeneric = 12
            }
            [Flags]
            public enum SupportedNpadStyle
            {
                FullKey = 2,
                Handheld = 4,
                JoyDual = 16,
                JoyLeft = 256,
                JoyRight = 65536
            }
        }
        //
        // 摘要:
        //     Interface to splash screen player settings.
        [NativeHeaderAttribute("Editor/Mono/PlayerSettingsSplashScreen.bindings.h")]
        [StaticAccessorAttribute("GetPlayerSettings().GetSplashScreenSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public class SplashScreen
        {
            public SplashScreen();

            //
            // 摘要:
            //     The height of splash slogan image on the splash ads.
            [NativeNameAttribute("SloganHeight")]
            public static int sloganHeight { get; set; }
            //
            // 摘要:
            //     Set this to true to display the Splash Slogan image on the splash ads.
            [NativeNameAttribute("ShowSplashAdsSlogan")]
            public static bool showSplashAdsSlogan { get; set; }
            //
            // 摘要:
            //     The ADS game id for IOS platform on ADS publisher portal.
            [NativeNameAttribute("AdsIosGameId")]
            public static string adsIosGameId { get; set; }
            //
            // 摘要:
            //     The ADS game id for Android platform on ADS publisher portal.
            [NativeNameAttribute("AdsAndroidGameId")]
            public static string adsAndroidGameId { get; set; }
            //
            // 摘要:
            //     Set this to true to display the Splash Ads be shown when the application is launched.
            [NativeNameAttribute("ShowUnitySplashAds")]
            public static bool showSplashAds { get; set; }
            //
            // 摘要:
            //     The style to use for the Unity logo during the Splash Screen.
            [NativeNameAttribute("SplashScreenLogoStyle")]
            public static UnityLogoStyle unityLogoStyle { get; set; }
            //
            // 摘要:
            //     Set this to true to show the Unity logo during the Splash Screen. Set it to false
            //     to disable the Unity logo. Note: Disabling the Unity logo requires a Plus/Pro
            //     license.
            [NativeNameAttribute("ShowUnitySplashLogo")]
            public static bool showUnityLogo { get; set; }
            //
            // 摘要:
            //     Set this to true to display the Splash Screen be shown when the application is
            //     launched. Set it to false to disable the Splash Screen. Note: Disabling the Splash
            //     Screen requires a Plus/Pro license.
            [NativeNameAttribute("ShowUnitySplashScreen")]
            public static bool show { get; set; }
            //
            // 摘要:
            //     In order to increase contrast between the background and the logos, an overlay
            //     color modifier is applied. The overlay opacity is the strength of this effect.
            //     Note: Reducing the value below 0.5 requires a Plus/Pro license.
            [NativeNameAttribute("SplashScreenOverlayOpacity")]
            public static float overlayOpacity { get; set; }
            //
            // 摘要:
            //     Determines how the Unity logo should be drawn, if it is enabled. If no Unity
            //     logo exists in [logos] then the draw mode defaults to PlayerSettings.SplashScreen.DrawMode.UnityLogoBelow|DrawMode.UnityLogoBelow.
            [NativeNameAttribute("SplashScreenDrawMode")]
            public static DrawMode drawMode { get; set; }
            //
            // 摘要:
            //     The background color shown if no background Sprite is assigned. Default is a
            //     dark blue RGB(34.44,54).
            [NativeNameAttribute("SplashScreenBackgroundColor")]
            public static Color backgroundColor { get; set; }
            //
            // 摘要:
            //     Determines whether Unity applies a blur effect to the background Sprite on the
            //     Splash Screen.
            public static bool blurBackgroundImage { get; set; }
            //
            // 摘要:
            //     The background Sprite that is shown in portrait mode.
            public static Sprite backgroundPortrait { get; set; }
            //
            // 摘要:
            //     The background Sprite that is shown in landscape mode. Also shown in portrait
            //     mode if backgroundPortrait is null.
            public static Sprite background { get; set; }
            //
            // 摘要:
            //     The target zoom (from 0 to 1) for the logo when it reaches the end of the logo
            //     animation's total duration. Only used when animationMode is PlayerSettings.SplashScreen.AnimationMode.Custom|AnimationMode.Custom.
            [NativeNameAttribute("SplashScreenLogoZoom")]
            public static float animationLogoZoom { get; set; }
            //
            // 摘要:
            //     The target zoom (from 0 to 1) for the background when it reaches the end of the
            //     SplashScreen animation's total duration. Only used when animationMode is PlayerSettings.SplashScreen.AnimationMode.Custom|AnimationMode.Custom.
            [NativeNameAttribute("SplashScreenBackgroundZoom")]
            public static float animationBackgroundZoom { get; set; }
            //
            // 摘要:
            //     The type of animation applied during the splash screen.
            [NativeNameAttribute("SplashScreenAnimation")]
            public static AnimationMode animationMode { get; set; }
            //
            // 摘要:
            //     The collection of logos that is shown during the splash screen. Logos are drawn
            //     in ascending order, starting from index 0, followed by 1, etc etc.
            [NativeNameAttribute("SplashScreenLogos")]
            public static SplashScreenLogo[] logos { get; set; }

            //
            // 摘要:
            //     Determines how the Unity logo should be drawn, if it is enabled.
            public enum DrawMode
            {
                //
                // 摘要:
                //     The Unity logo is drawn in the lower portion of the screen for the duration of
                //     the Splash Screen, while the PlayerSettings.SplashScreen.logos are shown in the
                //     centre.
                UnityLogoBelow = 0,
                //
                // 摘要:
                //     The Unity logo is shown sequentially providing it exists in the PlayerSettings.SplashScreen.logos
                //     collection.
                AllSequential = 1
            }
            //
            // 摘要:
            //     The type of animation applied during the Splash Screen.
            public enum AnimationMode
            {
                //
                // 摘要:
                //     No animation is applied to the Splash Screen logo or background.
                Static = 0,
                //
                // 摘要:
                //     Animates the Splash Screen with a simulated dolly effect.
                Dolly = 1,
                //
                // 摘要:
                //     Animates the Splash Screen using custom values from PlayerSettings.SplashScreen.animationBackgroundZoom
                //     and PlayerSettings.SplashScreen.animationLogoZoom.
                Custom = 2
            }
            //
            // 摘要:
            //     The style to use for the Unity logo during the Splash Screen.
            public enum UnityLogoStyle
            {
                //
                // 摘要:
                //     A dark Unity logo with a light background.
                DarkOnLight = 0,
                //
                // 摘要:
                //     A white Unity logo with a dark background.
                LightOnDark = 1
            }
        }
        //
        // 摘要:
        //     Player Settings for the PlayStation®4.
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public sealed class PS4
        {
            public PS4();

            [NativePropertyAttribute("ps4ScriptOptimizationLevel", false, UnityEngine.Bindings.TargetType.Field)]
            public static int scriptOptimizationLevel { get; set; }
            [NativePropertyAttribute("ps4Audio3dVirtualSpeakerCount", false, UnityEngine.Bindings.TargetType.Field)]
            public static int audio3dVirtualSpeakerCount { get; set; }
            [NativePropertyAttribute("ps4UseAudio3dBackend", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool useAudio3dBackend { get; set; }
            [NativePropertyAttribute("ps4ReprojectionSupport", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool reprojectionSupport { get; set; }
            [NativePropertyAttribute("ps4ProGarlicHeapSize", false, UnityEngine.Bindings.TargetType.Field)]
            public static int proGarlicHeapSize { get; set; }
            [NativePropertyAttribute("ps4GarlicHeapSize", false, UnityEngine.Bindings.TargetType.Field)]
            public static int garlicHeapSize { get; set; }
            [NativePropertyAttribute("ps4DownloadDataSize", false, UnityEngine.Bindings.TargetType.Field)]
            public static int downloadDataSize { get; set; }
            [NativePropertyAttribute("ps4UseLowGarlicFragmentationMode", true, UnityEngine.Bindings.TargetType.Field)]
            public static bool useLowGarlicFragmentationMode { get; set; }
            [NativePropertyAttribute("ps4pnGameCustomData", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool pnGameCustomData { get; set; }
            [NativePropertyAttribute("ps4pnPresence", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool pnPresence { get; set; }
            [NativePropertyAttribute("ps4pnSessions", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool pnSessions { get; set; }
            [NativePropertyAttribute("ps4NPtitleDatPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string NPtitleDatPath { get; set; }
            [NativePropertyAttribute("ps4PatchChangeinfoPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PatchChangeinfoPath { get; set; }
            [NativePropertyAttribute("ps4PatchLatestPkgPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PatchLatestPkgPath { get; set; }
            [NativePropertyAttribute("ps4PatchPkgPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PatchPkgPath { get; set; }
            [NativePropertyAttribute("ps4PatchDayOne", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool patchDayOne { get; set; }
            [NativePropertyAttribute("ps4pnFriends", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool pnFriends { get; set; }
            [NativePropertyAttribute("ps4ExtraSceSysFile", false, UnityEngine.Bindings.TargetType.Function)]
            public static string ExtraSceSysFile { get; set; }
            [NativePropertyAttribute("ps4SocialScreenEnabled", false, UnityEngine.Bindings.TargetType.Field)]
            public static int socialScreenEnabled { get; set; }
            [NativePropertyAttribute("ps4attribMoveSupport", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attribMoveSupport { get; set; }
            [NativePropertyAttribute("ps4GPU800MHz", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool gpu800MHz { get; set; }
            [NativePropertyAttribute("ps4AllowPS5Detection", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool allowPS5Detection { get; set; }
            [NativePropertyAttribute("ps4CompatibilityPS5", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool compatibilityPS5 { get; set; }
            [NativePropertyAttribute("ps4attribVROutputEnabled", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attribVROutputEnabled { get; set; }
            [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
            public static int playerPrefsMaxSize { get; set; }
            [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
            public static bool resetTempFolder { get; set; }
            [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
            public static bool enableApplicationExit { get; set; }
            [NativePropertyAttribute("ps4attribUserManagement", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attribUserManagement { get; set; }
            [NativePropertyAttribute("ps4IncludedModules", false, UnityEngine.Bindings.TargetType.Field)]
            public static string[] includedModules { get; set; }
            [NativePropertyAttribute("ps4contentSearchFeaturesUsed", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool contentSearchFeaturesUsed { get; set; }
            [NativePropertyAttribute("ps4videoRecordingFeaturesUsed", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool videoRecordingFeaturesUsed { get; set; }
            [NativePropertyAttribute("ps4attribCpuUsage", false, UnityEngine.Bindings.TargetType.Field)]
            public static int attribCpuUsage { get; set; }
            [NativePropertyAttribute("ps4disableAutoHideSplash", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool disableAutoHideSplash { get; set; }
            [NativePropertyAttribute("ps4attribExclusiveVR", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attribExclusiveVR { get; set; }
            [NativePropertyAttribute("ps4attribShareSupport", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attribShareSupport { get; set; }
            [NativePropertyAttribute("ps4attrib3DSupport", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool attrib3DSupport { get; set; }
            [NativePropertyAttribute("ps4attribEyeToEyeDistanceSettingVR", false, UnityEngine.Bindings.TargetType.Field)]
            public static PlayStationVREyeToEyeDistanceSettings attribEyeToEyeDistanceSettingVR { get; set; }
            [NativePropertyAttribute("ps4ShareOverlayImagePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string ShareOverlayImagePath { get; set; }
            [NativePropertyAttribute("ps4PrivacyGuardImagePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PrivacyGuardImagePath { get; set; }
            [NativePropertyAttribute("ps4AppVersion", false, UnityEngine.Bindings.TargetType.Function)]
            public static string appVersion { get; set; }
            [NativePropertyAttribute("ps4MasterVersion", false, UnityEngine.Bindings.TargetType.Function)]
            public static string masterVersion { get; set; }
            [NativePropertyAttribute("ps4AppType", false, UnityEngine.Bindings.TargetType.Field)]
            public static int appType { get; set; }
            [NativePropertyAttribute("ps4Category", false, UnityEngine.Bindings.TargetType.Field)]
            public static PS4AppCategory category { get; set; }
            [NativePropertyAttribute("ps4ContentID", false, UnityEngine.Bindings.TargetType.Function)]
            public static string contentID { get; set; }
            [NativePropertyAttribute("ps4UseResolutionFallback", false, UnityEngine.Bindings.TargetType.Field)]
            public static bool useResolutionFallback { get; set; }
            [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
            public static bool restrictedAudioUsageRights { get; set; }
            [NativePropertyAttribute(TargetType = UnityEngine.Bindings.TargetType.Field)]
            public static bool playerPrefsSupport { get; set; }
            [NativePropertyAttribute("ps4ShareFilePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string ShareFilePath { get; set; }
            [NativePropertyAttribute("monoEnv", false, UnityEngine.Bindings.TargetType.Function)]
            public static string monoEnv { get; set; }
            [NativePropertyAttribute("ps4ApplicationParam4", false, UnityEngine.Bindings.TargetType.Field)]
            public static int applicationParameter4 { get; set; }
            [NativePropertyAttribute("ps4ApplicationParam3", false, UnityEngine.Bindings.TargetType.Field)]
            public static int applicationParameter3 { get; set; }
            [NativePropertyAttribute("ps4ApplicationParam2", false, UnityEngine.Bindings.TargetType.Field)]
            public static int applicationParameter2 { get; set; }
            [NativePropertyAttribute("ps4ApplicationParam1", false, UnityEngine.Bindings.TargetType.Field)]
            public static int applicationParameter1 { get; set; }
            [NativePropertyAttribute("ps4ParentalLevel", false, UnityEngine.Bindings.TargetType.Field)]
            public static int parentalLevel { get; set; }
            [NativePropertyAttribute("ps4NPTitleSecret", false, UnityEngine.Bindings.TargetType.Function)]
            public static string npTitleSecret { get; set; }
            [NativePropertyAttribute("ps4NPAgeRating", false, UnityEngine.Bindings.TargetType.Field)]
            public static int npAgeRating { get; set; }
            [NativePropertyAttribute("ps4Passcode", false, UnityEngine.Bindings.TargetType.Function)]
            public static string passcode { get; set; }
            [NativePropertyAttribute("ps4NPTrophyPackPath")]
            public static string npTrophyPackPath { get; set; }
            [NativePropertyAttribute("ps4RemotePlayKeyAssignment", false, UnityEngine.Bindings.TargetType.Field)]
            public static PS4RemotePlayKeyAssignment remotePlayKeyAssignment { get; set; }
            [NativePropertyAttribute("ps4PlayTogetherPlayerCount", false, UnityEngine.Bindings.TargetType.Field)]
            public static int playTogetherPlayerCount { get; set; }
            [NativePropertyAttribute("ps4BGMPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string BGMPath { get; set; }
            [NativePropertyAttribute("ps4SaveDataImagePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string SaveDataImagePath { get; set; }
            [NativePropertyAttribute("ps4IconImagesFolder", false, UnityEngine.Bindings.TargetType.Function)]
            public static string iconImagesFolder { get; set; }
            [NativePropertyAttribute("ps4StartupImagesFolder", false, UnityEngine.Bindings.TargetType.Function)]
            public static string startupImagesFolder { get; set; }
            [NativePropertyAttribute("ps4StartupImagePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string StartupImagePath { get; set; }
            [NativePropertyAttribute("ps4BackgroundImagePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string BackgroundImagePath { get; set; }
            [NativePropertyAttribute("ps4PronunciationSIGPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PronunciationSIGPath { get; set; }
            [NativePropertyAttribute("ps4RemotePlayKeyMappingDir", false, UnityEngine.Bindings.TargetType.Function)]
            public static string remotePlayKeyMappingDir { get; set; }
            [NativePropertyAttribute("ps4PronunciationXMLPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PronunciationXMLPath { get; set; }
            [NativePropertyAttribute("ps4VideoOutBaseModeInitialWidth", false, UnityEngine.Bindings.TargetType.Field)]
            public static int videoOutBaseModeInitialWidth { get; set; }
            public static string SdkOverride { get; set; }
            [Obsolete("videoOutResolution is deprecated. Use PlayerSettings.PS4.videoOutInitialWidth and PlayerSettings.PS4.videoOutReprojectionRate to control initial display resolution and reprojection rate.")]
            public static int videoOutResolution { get; set; }
            [NativePropertyAttribute("ps4VideoOutInitialWidth", false, UnityEngine.Bindings.TargetType.Field)]
            public static int videoOutInitialWidth { get; set; }
            [NativePropertyAttribute("ps4VideoOutPixelFormat", false, UnityEngine.Bindings.TargetType.Field)]
            public static int videoOutPixelFormat { get; set; }
            [NativePropertyAttribute("ps4ParamSfxPath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string paramSfxPath { get; set; }
            [NativePropertyAttribute("ps4EnterButtonAssignment", false, UnityEngine.Bindings.TargetType.Field)]
            public static PS4EnterButtonAssignment enterButtonAssignment { get; set; }
            [NativePropertyAttribute("ps4VideoOutReprojectionRate", false, UnityEngine.Bindings.TargetType.Field)]
            public static int videoOutReprojectionRate { get; set; }

            //
            // 摘要:
            //     Remote Play key assignment.
            public enum PS4RemotePlayKeyAssignment
            {
                //
                // 摘要:
                //     No Remote play key assignment.
                None = -1,
                //
                // 摘要:
                //     Remote Play key layout configuration A.
                PatternA = 0,
                //
                // 摘要:
                //     Remote Play key layout configuration B.
                PatternB = 1,
                //
                // 摘要:
                //     Remote Play key layout configuration C.
                PatternC = 2,
                //
                // 摘要:
                //     Remote Play key layout configuration D.
                PatternD = 3,
                //
                // 摘要:
                //     Remote Play key layout configuration E.
                PatternE = 4,
                //
                // 摘要:
                //     Remote Play key layout configuration F.
                PatternF = 5,
                //
                // 摘要:
                //     Remote Play key layout configuration G.
                PatternG = 6,
                //
                // 摘要:
                //     Remote Play key layout configuration H.
                PatternH = 7
            }
            //
            // 摘要:
            //     PS4 enter button assignment.
            public enum PS4EnterButtonAssignment
            {
                //
                // 摘要:
                //     Circle button.
                CircleButton = 0,
                //
                // 摘要:
                //     Cross button.
                CrossButton = 1,
                SystemDefined = 2
            }
            //
            // 摘要:
            //     PS4 application category.
            public enum PS4AppCategory
            {
                //
                // 摘要:
                //     Application.
                Application = 0,
                Patch = 1,
                Remaster = 2
            }
            public enum PlayStationVREyeToEyeDistanceSettings
            {
                PerUser = 0,
                ForceDefault = 1,
                DynamicModeAtRuntime = 2
            }
        }
        //
        // 摘要:
        //     Xbox One Specific Player Settings.
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public sealed class XboxOne
        {
            public XboxOne();

            [NativePropertyAttribute("XboxOneEnableGPUVariability", UnityEngine.Bindings.TargetType.Field)]
            public static bool EnableVariableGPU { get; set; }
            [NativePropertyAttribute("XboxOneDisableKinectGpuReservation")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool DisableKinectGpuReservation { get; set; }
            [NativePropertyAttribute("XboxEnablePIXSampling")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool EnablePIXSampling { get; set; }
            [NativePropertyAttribute("XboxOneGameOsOverridePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string GameOsOverridePath { get; set; }
            [NativePropertyAttribute("XboxOnePackagingOverridePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string PackagingOverridePath { get; set; }
            [NativePropertyAttribute("XboxOnePackageEncryption", UnityEngine.Bindings.TargetType.Field)]
            public static XboxOneEncryptionLevel PackagingEncryption { get; set; }
            [NativePropertyAttribute("XboxOnePackageUpdateGranularity", UnityEngine.Bindings.TargetType.Field)]
            public static XboxOnePackageUpdateGranularity PackageUpdateGranularity { get; set; }
            [NativePropertyAttribute("XboxOneOverrideIdentityName", false, UnityEngine.Bindings.TargetType.Function)]
            public static string OverrideIdentityName { get; set; }
            [NativePropertyAttribute("XboxOneEnable7thCore")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool Enable7thCore { get; set; }
            [NativePropertyAttribute("XboxOneOverrideIdentityPublisher", false, UnityEngine.Bindings.TargetType.Function)]
            public static string OverrideIdentityPublisher { get; set; }
            [NativePropertyAttribute("XboxOneIsContentPackage", UnityEngine.Bindings.TargetType.Field)]
            public static bool IsContentPackage { get; set; }
            [NativePropertyAttribute("XboxOneEnhancedXboxCompatibilityMode", UnityEngine.Bindings.TargetType.Field)]
            public static bool EnhancedXboxCompatibilityMode { get; set; }
            [NativePropertyAttribute("XboxOneVersion", false, UnityEngine.Bindings.TargetType.Function)]
            public static string Version { get; set; }
            [NativePropertyAttribute("XboxOneDescription", false, UnityEngine.Bindings.TargetType.Function)]
            public static string Description { get; set; }
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static string[] SocketNames { get; }
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static string[] AllowedProductIds { get; }
            public static uint PersistentLocalStorageSize { get; set; }
            [NativePropertyAttribute("XboxOneEnableTypeOptimization")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool EnableTypeOptimization { get; set; }
            [NativePropertyAttribute("XboxOneAppManifestOverridePath", false, UnityEngine.Bindings.TargetType.Function)]
            public static string AppManifestOverridePath { get; set; }
            [NativePropertyAttribute("XboxOnePresentImmediateThreshold")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static uint PresentImmediateThreshold { get; set; }
            [Obsolete("Mono script compiler is no longer supported.")]
            public static ScriptCompiler scriptCompiler { get; set; }
            [NativePropertyAttribute("XboxOneSCId", false, UnityEngine.Bindings.TargetType.Function)]
            public static string SCID { get; set; }
            [NativePropertyAttribute("XboxOneTitleId", false, UnityEngine.Bindings.TargetType.Function)]
            public static string TitleId { get; set; }
            [NativePropertyAttribute("XboxOneContentId", false, UnityEngine.Bindings.TargetType.Function)]
            public static string ContentId { get; set; }
            [NativePropertyAttribute("XboxOneSandboxId", false, UnityEngine.Bindings.TargetType.Function)]
            [Obsolete("SandboxId is obsolete please remove")]
            public static string SandboxId { get; set; }
            [NativePropertyAttribute("XboxOneUpdateKey", false, UnityEngine.Bindings.TargetType.Function)]
            public static string UpdateKey { get; set; }
            [NativePropertyAttribute("XboxOneProductId", false, UnityEngine.Bindings.TargetType.Function)]
            public static string ProductId { get; set; }
            [NativePropertyAttribute("XboxOneLoggingLevel")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static XboxOneLoggingLevel defaultLoggingLevel { get; set; }
            [NativePropertyAttribute("XboxOneXTitleMemory", UnityEngine.Bindings.TargetType.Field)]
            public static int XTitleMemory { get; set; }
            [NativePropertyAttribute("XboxOneMonoLoggingLevel")]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int monoLoggingLevel { get; set; }

            [NativeMethodAttribute("AddXboxOneAllowedProductId")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool AddAllowedProductId(string id);
            [NativeMethodAttribute("GetXboxOneCapability")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool GetCapability(string capability);
            [NativeMethodAttribute("GetXboxOneGameRating")]
            [Obsolete("Starting May 11th 2020 any new base game submission releasing digital only, digital and disc, or disc only, should not include a ratings element in the AppxManifest. This ratings policy update applies to all Xbox supported ratings. New base submissions that come in on or after this date will be rejected by your Microsoft Representative if a ratings element is present.", false)]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static int GetGameRating(string name);
            public static void GetSocketDefinition(string name, out string port, out int protocol, out int[] usages, out string templateName, out int sessionRequirment, out int[] deviceUsages);
            [NativeMethodAttribute("GetXboxOneLanguage")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool GetSupportedLanguage(string language);
            [NativeMethodAttribute("RemoveXboxOneAllowedProductId")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void RemoveAllowedProductId(string id);
            [NativeMethodAttribute("RemoveXboxOneSocketDefinition")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void RemoveSocketDefinition(string name);
            [NativeMethodAttribute("SetXboxOneCapability")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void SetCapability(string capability, bool value);
            [NativeMethodAttribute("SetXboxOneGameRating")]
            [Obsolete("Starting May 11th 2020 any new base game submission releasing digital only, digital and disc, or disc only, should not include a ratings element in the AppxManifest. This ratings policy update applies to all Xbox supported ratings. New base submissions that come in on or after this date will be rejected by your Microsoft Representative if a ratings element is present.", false)]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void SetGameRating(string name, int value);
            [NativeMethodAttribute("SetXboxOneSocketDefinition")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void SetSocketDefinition(string name, string port, int protocol, int[] usages, string templateName, int sessionRequirment, int[] deviceUsages);
            [NativeMethodAttribute("SetXboxOneLanguage")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void SetSupportedLanguage(string language, bool enabled);
            [NativeMethodAttribute("UpdateXboxOneAllowedProductId")]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnlyForUpdate()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static void UpdateAllowedProductId(int idx, string id);
        }
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        public sealed class Lumin
        {
            public Lumin();

            [NativePropertyAttribute("LuminIconModelFolderPath")]
            public static string iconModelFolderPath { get; set; }
            [NativePropertyAttribute("LuminIconPortalFolderPath")]
            public static string iconPortalFolderPath { get; set; }
            [NativePropertyAttribute("LuminCertificatePath")]
            public static string certificatePath { get; set; }
            [NativePropertyAttribute("LuminSignPackage")]
            public static bool signPackage { get; set; }
            [NativePropertyAttribute("LuminIsChannelApp")]
            public static bool isChannelApp { get; set; }
            [NativePropertyAttribute("LuminVersionCode")]
            public static int versionCode { get; set; }
            [NativePropertyAttribute("LuminVersionName")]
            public static string versionName { get; set; }
        }
        //
        // 摘要:
        //     Facebook specific Player settings.
        [Obsolete("Facebook support was removed in 2019.3", true)]
        public class Facebook
        {
            public Facebook();

            public static string sdkVersion { get; set; }
            public static string appId { get; set; }
            public static bool useCookies { get; set; }
            public static bool useStatus { get; set; }
            public static bool useFrictionlessRequests { get; set; }
        }
        //
        // 摘要:
        //     iOS specific player settings.
        [NativeHeaderAttribute("Editor/Src/EditorUserBuildSettings.h")]
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public class iOS
        {
            public iOS();

            //
            // 摘要:
            //     Status bar style.
            [NativePropertyAttribute("UIStatusBarStyle")]
            public static iOSStatusBarStyle statusBarStyle { get; set; }
            //
            // 摘要:
            //     Application behavior when entering background.
            public static iOSAppInBackgroundBehavior appInBackgroundBehavior { get; set; }
            //
            // 摘要:
            //     Supported background execution modes (when appInBackgroundBehavior is set to
            //     iOSAppInBackgroundBehavior.Custom).
            [NativePropertyAttribute("IOSAppInBackgroundBehavior")]
            public static iOSBackgroundMode backgroundModes { get; set; }
            //
            // 摘要:
            //     Should hard shadows be enforced when running on (mobile) Metal.
            [NativePropertyAttribute("IOSMetalForceHardShadows")]
            public static bool forceHardShadowsOnMetal { get; set; }
            //
            // 摘要:
            //     Should insecure HTTP downloads be allowed?
            [NativePropertyAttribute("IOSAllowHTTPDownload")]
            public static bool allowHTTPDownload { get; set; }
            //
            // 摘要:
            //     Set this property with your Apple Developer Team ID. You can find this on the
            //     Apple Developer website under <a href="https:developer.apple.comaccount#membership">
            //     Account > Membership </a> . This sets the Team ID for the generated Xcode project,
            //     allowing developers to use the Build and Run functionality. An Apple Developer
            //     Team ID must be set here for automatic signing of your app.
            public static string appleDeveloperTeamID { get; set; }
            //
            // 摘要:
            //     A provisioning profile Universally Unique Identifier (UUID) that Xcode will use
            //     to build your iOS app in Manual Signing mode.
            public static string iOSManualProvisioningProfileID { get; set; }
            //
            // 摘要:
            //     A provisioning profile Universally Unique Identifier (UUID) that Xcode will use
            //     to build your tvOS app in Manual Signing mode.
            public static string tvOSManualProvisioningProfileID { get; set; }
            //
            // 摘要:
            //     A ProvisioningProfileType that will be set when building a tvOS Xcode project.
            [NativePropertyAttribute("tvOSManualProvisioningProfileType")]
            public static ProvisioningProfileType tvOSManualProvisioningProfileType { get; set; }
            //
            // 摘要:
            //     A ProvisioningProfileType that will be set when building an iOS Xcode project.
            [NativePropertyAttribute("iOSManualProvisioningProfileType")]
            public static ProvisioningProfileType iOSManualProvisioningProfileType { get; set; }
            //
            // 摘要:
            //     Set this property to true for Xcode to attempt to automatically sign your app
            //     based on your appleDeveloperTeamID.
            public static bool appleEnableAutomaticSigning { get; set; }
            //
            // 摘要:
            //     Describes the reason for access to the user's camera.
            [NativePropertyAttribute("CameraUsageDescription")]
            public static string cameraUsageDescription { get; set; }
            //
            // 摘要:
            //     Describes the reason for access to the user's location data.
            [NativePropertyAttribute("LocationUsageDescription")]
            public static string locationUsageDescription { get; set; }
            //
            // 摘要:
            //     Describes the reason for access to the user's microphone.
            [NativePropertyAttribute("MicrophoneUsageDescription")]
            public static string microphoneUsageDescription { get; set; }
            //
            // 摘要:
            //     Application should show ActivityIndicator when loading.
            [NativePropertyAttribute("IOSAppInBackgroundBehavior")]
            public static iOSShowActivityIndicatorOnLoading showActivityIndicatorOnLoading { get; set; }
            //
            // 摘要:
            //     Specifies whether the home button should be hidden in the iOS build of this application.
            [NativePropertyAttribute("HideHomeButton")]
            public static bool hideHomeButton { get; set; }
            //
            // 摘要:
            //     Defer system gestures until the second swipe on specific edges.
            public static SystemGestureDeferMode deferSystemGesturesMode { get; set; }
            //
            // 摘要:
            //     An array of URL Schemes that are supported by the app.
            [NativePropertyAttribute("iOSURLSchemes", false, UnityEngine.Bindings.TargetType.Field)]
            public static string[] iOSUrlSchemes { get; set; }
            //
            // 摘要:
            //     RequiresFullScreen maps to Apple's plist build setting UIRequiresFullScreen,
            //     which is used to opt out of being eligible to participate in Slide Over and Split
            //     View for iOS 9.0 multitasking.
            [NativePropertyAttribute("UIRequiresFullScreen")]
            public static bool requiresFullScreen { get; set; }
            //
            // 摘要:
            //     Application should exit when suspended to background.
            [Obsolete("exitOnSuspend is deprecated, use appInBackgroundBehavior", false)]
            public static bool exitOnSuspend { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use Screen.SetResolution at runtime", true)]
            public static iOSTargetResolution targetResolution { get; set; }
            //
            // 摘要:
            //     Determines iPod playing behavior.
            [Obsolete("Use PlayerSettings.muteOtherAudioSources instead (UnityUpgradable) -> UnityEditor.PlayerSettings.muteOtherAudioSources", false)]
            public static bool overrideIPodMusic { get; set; }
            //
            // 摘要:
            //     iOS application display name.
            [NativePropertyAttribute("ProductName")]
            public static string applicationDisplayName { get; set; }
            //
            // 摘要:
            //     The build number of the bundle
            public static string buildNumber { get; set; }
            //
            // 摘要:
            //     Indicates whether application will use On Demand Resources (ODR) API.
            [NativePropertyAttribute("UseOnDemandResources")]
            public static bool useOnDemandResources { get; set; }
            //
            // 摘要:
            //     Disable Depth and Stencil Buffers.
            public static bool disableDepthAndStencilBuffers { get; set; }
            //
            // 摘要:
            //     Active iOS SDK version used for build.
            public static iOSSdkVersion sdkVersion { get; set; }
            //
            // 摘要:
            //     Deployment minimal version of iOS.
            [Obsolete("OBSOLETE warning targetOSVersion is obsolete, use targetOSVersionString")]
            public static iOSTargetOSVersion targetOSVersion { get; set; }
            //
            // 摘要:
            //     Deployment minimal version of iOS.
            [NativePropertyAttribute("iOSTargetOSVersion")]
            public static string targetOSVersionString { get; set; }
            //
            // 摘要:
            //     Targeted device.
            public static iOSTargetDevice targetDevice { get; set; }
            //
            // 摘要:
            //     Icon is prerendered.
            [NativePropertyAttribute("UIPrerenderedIcon")]
            public static bool prerenderedIcon { get; set; }
            //
            // 摘要:
            //     Application requires persistent WiFi.
            [NativePropertyAttribute("UIRequiresPersistentWiFi")]
            public static bool requiresPersistentWiFi { get; set; }
            //
            // 摘要:
            //     Script calling optimization.
            public static ScriptCallOptimizationLevel scriptCallOptimization { get; set; }

            //
            // 摘要:
            //     Sets the mode which will be used to generate the app's launch screen Interface
            //     Builder (.xib) file for iPad.
            //
            // 参数:
            //   type:
            public static void SetiPadLaunchScreenType(iOSLaunchScreenType type);
            //
            // 摘要:
            //     Sets the mode which will be used to generate the app's launch screen Interface
            //     Builder (.xib) file for iPhone.
            //
            // 参数:
            //   type:
            public static void SetiPhoneLaunchScreenType(iOSLaunchScreenType type);
            //
            // 摘要:
            //     Sets the image to display on screen when the game launches for the specified
            //     iOS device.
            //
            // 参数:
            //   image:
            //
            //   type:
            public static void SetLaunchScreenImage(Texture2D image, iOSLaunchScreenImageType type);
        }
        //
        // 摘要:
        //     Android specific player settings.
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public class Android
        {
            public Android();

            //
            // 摘要:
            //     Select which devices are allowed to run the Android application (all devices,
            //     mobile phones, tablets, and TV devices only, or Chrome OS devices only).
            public static AndroidTargetDevices androidTargetDevices { get; set; }
            //
            // 摘要:
            //     Android splash screen scale mode.
            public static AndroidSplashScreenScale splashScreenScale { get; set; }
            //
            // 摘要:
            //     Enable application signing with a custom keystore.
            [NativePropertyAttribute("androidUseCustomKeystore", UnityEngine.Bindings.TargetType.Function)]
            public static bool useCustomKeystore { get; set; }
            //
            // 摘要:
            //     Android keystore name.
            public static string keystoreName { get; set; }
            //
            // 摘要:
            //     Android keystore password.
            public static string keystorePass { get; set; }
            //
            // 摘要:
            //     Android key alias name.
            public static string keyaliasName { get; set; }
            //
            // 摘要:
            //     Android key alias password.
            public static string keyaliasPass { get; set; }
            //
            // 摘要:
            //     Create a separate APK for each CPU architecture.
            public static bool buildApkPerCpuArchitecture { get; set; }
            //
            // 摘要:
            //     License verification flag.
            public static bool licenseVerification { get; }
            //
            // 摘要:
            //     Application should show ActivityIndicator when loading.
            public static AndroidShowActivityIndicatorOnLoading showActivityIndicatorOnLoading { get; set; }
            //
            // 摘要:
            //     Choose how content is drawn to the screen.
            public static AndroidBlitType blitType { get; set; }
            //
            // 摘要:
            //     Maximum aspect ratio which is supported by the application.
            public static float maxAspectRatio { get; set; }
            //
            // 摘要:
            //     Start in fullscreen mode.
            public static bool startInFullscreen { get; set; }
            //
            // 摘要:
            //     Extends rendering layout into display cutout area, utilizing all of the available
            //     screen space.
            public static bool renderOutsideSafeArea { get; set; }
            //
            // 摘要:
            //     Use R8 to perform minification.
            [NativePropertyAttribute("AndroidMinifyWithR8", UnityEngine.Bindings.TargetType.Function)]
            public static bool minifyWithR8 { get; set; }
            //
            // 摘要:
            //     Enable to minify release build.
            [NativePropertyAttribute("AndroidMinifyRelease", UnityEngine.Bindings.TargetType.Function)]
            public static bool minifyRelease { get; set; }
            //
            // 摘要:
            //     Use APK Expansion Files.
            public static bool useAPKExpansionFiles { get; set; }
            //
            // 摘要:
            //     A set of CPU architectures for the Android build target.
            public static AndroidArchitecture targetArchitectures { get; set; }
            //
            // 摘要:
            //     Un-check to disable Chrome OS's default behaviour of converting mouse and touchpad
            //     input events into touchscreen input events.
            public static bool chromeosInputEmulation { get; set; }
            //
            // 摘要:
            //     Enable support for Google ARCore on supported devices.
            public static bool ARCoreEnabled { get; set; }
            //
            // 摘要:
            //     Android target device.
            [Obsolete("Use targetArchitectures instead. (UnityUpgradable) -> targetArchitectures", false)]
            public static AndroidTargetDevice targetDevice { get; set; }
            //
            // 摘要:
            //     Disable Depth and Stencil Buffers.
            public static bool disableDepthAndStencilBuffers { get; set; }
            //
            // 摘要:
            //     24-bit Depth Buffer is used.
            [Obsolete("use24BitDepthBuffer is deprecated, use disableDepthAndStencilBuffers instead.")]
            public static bool use24BitDepthBuffer { get; set; }
            //
            // 摘要:
            //     The default horizontal size of the Android Player window in pixels.
            public static int defaultWindowWidth { get; set; }
            //
            // 摘要:
            //     The default vertical size of the Android Player window in pixels.
            public static int defaultWindowHeight { get; set; }
            //
            // 摘要:
            //     The minimum horizontal size of the Android Player window in pixels.
            public static int minimumWindowWidth { get; set; }
            //
            // 摘要:
            //     The minimum vertical size of the Android Player window in pixels.
            public static int minimumWindowHeight { get; set; }
            //
            // 摘要:
            //     Indicates whether Android Player build of your application support a resizable
            //     window.
            public static bool resizableWindow { get; set; }
            //
            // 摘要:
            //     The display mode for Android Player builds of your application.
            public static FullScreenMode fullscreenMode { get; set; }
            //
            // 摘要:
            //     Android bundle version code.
            public static int bundleVersionCode { get; set; }
            //
            // 摘要:
            //     The minimum API level required for your application to run.
            public static AndroidSdkVersions minSdkVersion { get; set; }
            //
            // 摘要:
            //     The target API level of your application.
            public static AndroidSdkVersions targetSdkVersion { get; set; }
            //
            // 摘要:
            //     Preferred application install location.
            public static AndroidPreferredInstallLocation preferredInstallLocation { get; set; }
            //
            // 摘要:
            //     Force internet permission flag.
            public static bool forceInternetPermission { get; set; }
            //
            // 摘要:
            //     Force SD card permission.
            public static bool forceSDCardPermission { get; set; }
            //
            // 摘要:
            //     Provide a build that is Android TV compatible.
            public static bool androidTVCompatibility { get; set; }
            //
            // 摘要:
            //     Publish the build as a game rather than a regular application. This option affects
            //     devices running Android 5.0 Lollipop and later.
            public static bool androidIsGame { get; set; }
            //
            // 摘要:
            //     Enable to minify debug build.
            [NativePropertyAttribute("AndroidMinifyDebug", UnityEngine.Bindings.TargetType.Function)]
            public static bool minifyDebug { get; set; }
            //
            // 摘要:
            //     Enable optimized frame pacing.
            public static bool optimizedFramePacing { get; set; }
        }
        //
        // 摘要:
        //     Windows Store Apps specific player settings.
        [NativeHeaderAttribute("Editor/Mono/PlayerSettingsWSA.bindings.h")]
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("PlayerSettingsBindings::WSA", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public sealed class WSA
        {
            public WSA();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileWideLogo { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeLargeTile140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeLargeTile { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeLargeTile80 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSmallTile180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSmallTile140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSmallTile { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSmallTile80 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileSmallLogo180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileSmallLogo140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileSmallLogo { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileSmallLogo80 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileWideLogo180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileWideLogo140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeLargeTile180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSplashScreenImage { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSplashScreenImageScale140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeSplashScreenImageScale180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSplashScreenImageScale140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSplashScreenImage { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneWideTile240 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneWideTile140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneWideTile { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneMediumTile240 { get; set; }
            //
            // 摘要:
            //     Enable/Disable low latency presentation API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("PlayerSettings.enableLowLatencyPresentationAPI is deprecated. It is now always enabled.", true)]
            public static bool enableLowLatencyPresentationAPI { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneMediumTile140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSmallTile240 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSmallTile140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSmallTile { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneAppIcon240 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneAppIcon140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneAppIcon { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneMediumTile { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileWideLogo80 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileLogo180 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileLogo140 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string packageLogo240 { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string packageLogo180 { get; set; }
            //
            // 摘要:
            //     Sets AlphaMode on the swap chain to DXGI_ALPHA_MODE_PREMULTIPLIED.
            [NativePropertyAttribute("wsaTransparentSwapchain", UnityEngine.Bindings.TargetType.Field)]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static bool transparentSwapchain { get; set; }
            public static string packageName { get; set; }
            public static string packageLogo { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("PlayerSettings.WSA.commandLineArgsFile is deprecated", true)]
            public static string commandLineArgsFile { get; set; }
            [NativePropertyAttribute("metroCertificatePath", UnityEngine.Bindings.TargetType.Field)]
            [StaticAccessorAttribute("GetPlayerSettings().GetEditorOnly()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static string certificatePath { get; }
            public static string certificateSubject { get; }
            public static string certificateIssuer { get; }
            public static string applicationDescription { get; set; }
            public static string tileShortName { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string phoneSplashScreenImageScale240 { get; set; }
            [NativePropertyAttribute("metroMediumTileShowName", UnityEngine.Bindings.TargetType.Field)]
            public static bool mediumTileShowName { get; set; }
            [NativePropertyAttribute("metroTileShowName", UnityEngine.Bindings.TargetType.Field)]
            public static WSAApplicationShowName tileShowName { get; set; }
            [NativePropertyAttribute("metroWideTileShowName", UnityEngine.Bindings.TargetType.Field)]
            public static bool wideTileShowName { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileLogo { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string storeTileLogo80 { get; set; }
            public static Color? splashScreenBackgroundColor { get; set; }
            [NativePropertyAttribute("metroLargeTileShowName", UnityEngine.Bindings.TargetType.Field)]
            public static bool largeTileShowName { get; set; }
            public static Version packageVersion { get; set; }
            [NativePropertyAttribute("metroLastRequiredScene", UnityEngine.Bindings.TargetType.Field)]
            public static int lastRequiredScene { get; set; }
            public static DateTime? certificateNotAfter { get; }
            //
            // 摘要:
            //     Where Unity gets input from.
            [NativePropertyAttribute("metroInputSource", UnityEngine.Bindings.TargetType.Field)]
            [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
            public static WSAInputSource inputSource { get; set; }
            //
            // 摘要:
            //     Enable/Disable independent input source feature.
            [Obsolete("PlayerSettings.WSA.enableIndependentInputSource is deprecated. Use PlayerSettings.WSA.inputSource.", false)]
            public static bool enableIndependentInputSource { get; set; }
            [NativePropertyAttribute("metroTileBackgroundColor", UnityEngine.Bindings.TargetType.Field)]
            public static Color tileBackgroundColor { get; set; }
            [NativePropertyAttribute("metroTileForegroundText", UnityEngine.Bindings.TargetType.Field)]
            public static WSAApplicationForegroundText tileForegroundText { get; set; }
            [NativePropertyAttribute("metroDefaultTileSize", UnityEngine.Bindings.TargetType.Field)]
            public static WSADefaultTileSize defaultTileSize { get; set; }
            [NativePropertyAttribute("metroSupportStreamingInstall", UnityEngine.Bindings.TargetType.Field)]
            public static bool supportStreamingInstall { get; set; }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()", true)]
            public static string packageLogo140 { get; set; }

            public static bool GetCapability(WSACapability capability);
            public static bool GetTargetDeviceFamily(WSATargetFamily family);
            public static string GetVisualAssetsImage(WSAImageType type, WSAImageScale scale);
            public static void SetCapability(WSACapability capability, bool value);
            [NativeThrowsAttribute]
            public static bool SetCertificate(string path, string password);
            public static void SetTargetDeviceFamily(WSATargetFamily family, bool value);
            public static void SetVisualAssetsImage(string image, WSAImageType type, WSAImageScale scale);

            //
            // 摘要:
            //     Windows Store Apps declarations.
            public static class Declarations
            {
                //
                // 摘要:
                //     Registers this application to be a default handler for specified URI scheme name.
                //     For example: if you specify myunitygame, your application can be run from other
                //     applications via the URI scheme myunitygame:. You can also test this using the
                //     Windows "Run" dialog box (invoked with Windows + R key). For more information
                //     https:msdn.microsoft.comlibrarywindowsappshh779670https:msdn.microsoft.comlibrarywindowsappshh779670.
                public static string protocolName { get; set; }
                //
                // 摘要:
                //     Set information for file type associations. For more information - https:msdn.microsoft.comlibrarywindowsappshh779671https:msdn.microsoft.comlibrarywindowsappshh779671.
                public static WSAFileTypeAssociations fileTypeAssociations { get; set; }
            }
        }
        //
        // 摘要:
        //     WebGL specific player settings.
        [NativeHeaderAttribute("Editor/Mono/PlayerSettingsWebGL.bindings.h")]
        public sealed class WebGL
        {
            public WebGL();

            [NativePropertyAttribute("webGLWasmStreaming", UnityEngine.Bindings.TargetType.Field)]
            [Obsolete("wasmStreaming Property deprecated. WebAssembly streaming will be automatically used when decompressionFallback is disabled and vice versa.", true)]
            public static bool wasmStreaming { get; set; }
            //
            // 摘要:
            //     Enables generation of debug symbols file in the build output directory.
            [NativePropertyAttribute("webGLDebugSymbols", UnityEngine.Bindings.TargetType.Field)]
            public static bool debugSymbols { get; set; }
            //
            // 摘要:
            //     Enables using MD5 hash of the uncompressed file contents as a filename for each
            //     file in the build.
            [NativePropertyAttribute("webGLNameFilesAsHashes", UnityEngine.Bindings.TargetType.Field)]
            public static bool nameFilesAsHashes { get; set; }
            //
            // 摘要:
            //     CompressionFormat defines the compression type that the WebGL resources are encoded
            //     to.
            [NativePropertyAttribute("webGLCompressionFormat", UnityEngine.Bindings.TargetType.Field)]
            public static WebGLCompressionFormat compressionFormat { get; set; }
            //
            // 摘要:
            //     Allows you to specify the WebGLLinkerTarget|web build format that is used when
            //     you build your project.
            [NativePropertyAttribute("webGLLinkerTarget", UnityEngine.Bindings.TargetType.Field)]
            public static WebGLLinkerTarget linkerTarget { get; set; }
            //
            // 摘要:
            //     Enable Multithreading support.
            [NativePropertyAttribute("webGLThreadsSupport", UnityEngine.Bindings.TargetType.Field)]
            public static bool threadsSupport { get; set; }
            [Obsolete("useWasm Property deprecated. Use linkerTarget instead")]
            public static bool useWasm { get; set; }
            [NativePropertyAttribute("webGLUseEmbeddedResources", UnityEngine.Bindings.TargetType.Field)]
            public static bool useEmbeddedResources { get; set; }
            [NativePropertyAttribute("webGLAnalyzeBuildSize", UnityEngine.Bindings.TargetType.Field)]
            public static bool analyzeBuildSize { get; set; }
            //
            // 摘要:
            //     Path to the WebGL template asset.
            [NativePropertyAttribute("WebGLTemplate")]
            public static string template { get; set; }
            [NativePropertyAttribute("WebGLModulesDirectory")]
            public static string modulesDirectory { get; set; }
            [NativePropertyAttribute("WebGLEmscriptenArgs")]
            public static string emscriptenArgs { get; set; }
            //
            // 摘要:
            //     Enables automatic caching of unityweb files.
            [NativePropertyAttribute("webGLDataCaching", UnityEngine.Bindings.TargetType.Field)]
            public static bool dataCaching { get; set; }
            //
            // 摘要:
            //     Exception support for WebGL builds.
            [NativePropertyAttribute("webGLExceptionSupport", UnityEngine.Bindings.TargetType.Field)]
            public static WebGLExceptionSupport exceptionSupport { get; set; }
            //
            // 摘要:
            //     Memory size for WebGL builds in Megabyte.
            [NativePropertyAttribute("webGLMemorySize", UnityEngine.Bindings.TargetType.Field)]
            public static int memorySize { get; set; }
            //
            // 摘要:
            //     Include decompression fallback code for build files in the loader.
            [NativePropertyAttribute("webGLDecompressionFallback", UnityEngine.Bindings.TargetType.Field)]
            public static bool decompressionFallback { get; set; }
            //
            // 摘要:
            //     The trapping mode for WebAssembly code.
            [NativePropertyAttribute("webGLWasmArithmeticExceptions", UnityEngine.Bindings.TargetType.Field)]
            public static WebGLWasmArithmeticExceptions wasmArithmeticExceptions { get; set; }
        }
        [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
        [StaticAccessorAttribute("GetPlayerSettings()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public class macOS
        {
            public macOS();

            public static string buildNumber { get; set; }
            [NativePropertyAttribute("MacAppStoreCategory")]
            public static string applicationCategoryType { get; set; }
            [NativePropertyAttribute("CameraUsageDescription")]
            public static string cameraUsageDescription { get; set; }
            [NativePropertyAttribute("MicrophoneUsageDescription")]
            public static string microphoneUsageDescription { get; set; }
            [NativePropertyAttribute("BluetoothUsageDescription")]
            public static string bluetoothUsageDescription { get; set; }
        }
    }
}

