#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Events;

namespace UnityEngine
{
    //
    // 摘要:
    //     Access to application run-time data.
    [NativeHeaderAttribute("Runtime/Network/NetworkUtility.h")]
    [NativeHeaderAttribute("Runtime/PreloadManager/PreloadManager.h")]
    [NativeHeaderAttribute("Runtime/PreloadManager/LoadSceneOperation.h")]
    [NativeHeaderAttribute("Runtime/Export/Application/Application.bindings.h")]
    [NativeHeaderAttribute("Runtime/Utilities/Argv.h")]
    [NativeHeaderAttribute("Runtime/Utilities/URLUtility.h")]
    [NativeHeaderAttribute("Runtime/Misc/BuildSettings.h")]
    [NativeHeaderAttribute("Runtime/Misc/PlayerSettings.h")]
    [NativeHeaderAttribute("Runtime/Logging/LogSystem.h")]
    [NativeHeaderAttribute("Runtime/Input/InputManager.h")]
    [NativeHeaderAttribute("Runtime/File/ApplicationSpecificPersistentDataPath.h")]
    [NativeHeaderAttribute("Runtime/Input/TargetFrameRate.h")]
    [NativeHeaderAttribute("Runtime/Input/GetInput.h")]
    [NativeHeaderAttribute("Runtime/Application/ApplicationInfo.h")]
    [NativeHeaderAttribute("Runtime/Application/AdsIdHandler.h")]
    [NativeHeaderAttribute("Runtime/Misc/Player.h")]
    [NativeHeaderAttribute("Runtime/BaseClasses/IsPlaying.h")]
    [NativeHeaderAttribute("Runtime/Misc/SystemInfo.h")]
    public class Application//Application__RR
    {
        public Application();

        //
        // 摘要:
        //     Returns the name of the store or package that installed the application (Read
        //     Only).
        public static string installerName { get; }
        //
        // 摘要:
        //     Returns application version number (Read Only).
        public static string version { get; }
        //
        // 摘要:
        //     The version of the Unity runtime used to play the content.
        public static string unityVersion { get; }
        //
        // 摘要:
        //     The URL of the document. For WebGL, this a web URL. For Android, iOS, or Universal
        //     Windows Platform (UWP) this is a deep link URL. (Read Only)
        public static string absoluteURL { get; }
        //
        // 摘要:
        //     Contains the path to a temporary data / cache directory (Read Only).
        public static string temporaryCachePath { get; }
        //
        // 摘要:
        //     (Read Only) Contains the path to a persistent data directory.
        public static string persistentDataPath { get; }
        //
        // 摘要:
        //     Returns application identifier at runtime. On Apple platforms this is the 'bundleIdentifier'
        //     saved in the info.plist file, on Android it's the 'package' from the AndroidManifest.xml.
        public static string identifier { get; }
        //
        // 摘要:
        //     The path to the StreamingAssets folder (Read Only).
        public static string streamingAssetsPath { get; }
        //
        // 摘要:
        //     Returns true when Unity is launched with the -batchmode flag from the command
        //     line (Read Only).
        public static bool isBatchMode { get; }
        //
        // 摘要:
        //     The name of the level that was last loaded (Read Only).
        [Obsolete("Use SceneManager to determine what scenes have been loaded")]
        public static string loadedLevelName { get; }
        //
        // 摘要:
        //     Returns a GUID for this build (Read Only).
        public static string buildGUID { get; }
        //
        // 摘要:
        //     Whether the player currently has focus. Read-only.
        public static bool isFocused { get; }

        /*
            Returns true when called in any kind of built Player, or when called in the Editor in Play Mode (Read Only).

            In a built Player, this method will always return true.
            In the Editor, it will return true if the Editor is in Play Mode.

            Note: In the Editor for ScriptableObject assets, this property will return false in OnEnable. 
            After reloading the domain, when reloading assemblies, Unity invokes OnEnable on all ScriptableObject instances. 
            This happens before isPlaying is set to true.
            ---
            注意, 如果在一个 ScriptableObject 资源的 OnEnable() 函数内访问本变量, 将获得 false;
            这是因为, 在 重加载 domain 之后, 在重加载资源集的时候, unity 会调用所有 ScriptableObject 实例的 OnEnable() 函数,
            但是此时 isPlaying 还没有被设置为 true; 所有会获得 false;

        */
        public static bool isPlaying { get; }


        //
        // 摘要:
        //     Indicates whether Unity's webplayer security model is enabled.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Application.webSecurityEnabled is no longer supported, since the Unity Web Player is no longer supported by Unity", true)]
        public static bool webSecurityEnabled { get; }
        //
        // 摘要:
        //     Contains the path to the game data folder on the target device (Read Only).
        public static string dataPath { get; }
        //
        // 摘要:
        //     Returns application install mode (Read Only).
        public static ApplicationInstallMode installMode { get; }
        //
        // 摘要:
        //     Returns application running in sandbox (Read Only).
        public static ApplicationSandboxType sandboxType { get; }
        //
        // 摘要:
        //     Returns application product name (Read Only).
        public static string productName { get; }
        [Obsolete("use Application.isEditor instead")]
        public static bool isPlayer { get; }
        //
        // 摘要:
        //     Returns the type of Internet reachability currently possible on the device.
        public static NetworkReachability internetReachability { get; }
        //
        // 摘要:
        //     The language the user's operating system is running in.
        public static SystemLanguage systemLanguage { get; }
        //
        // 摘要:
        //     Is the current Runtime platform a known console platform.
        public static bool isConsolePlatform { get; }


        /*
            Is the current Runtime platform a known mobile platform.

            Currently this returns true if the app is running on Android, iOS or WSA.
            Note: On "Universal Windows Platform tablets" are treated as desktop machines, 
            so this property returns true only when running on phones and IoT device family devices.
        */
        public static bool isMobilePlatform { get; }


        //
        // 摘要:
        //     Returns the platform the game is running on (Read Only).
        public static RuntimePlatform platform { get; }
        //
        // 摘要:
        //     Checks whether splash screen is being shown.
        [Obsolete("This property is deprecated, please use SplashScreen.isFinished instead")]
        public static bool isShowingSplashScreen { get; }
        //
        // 摘要:
        //     Returns true if application integrity can be confirmed.
        public static bool genuineCheckAvailable { get; }
        //
        // 摘要:
        //     Returns false if application is altered in any way after it was built.
        public static bool genuine { get; }
        //
        // 摘要:
        //     Priority of background loading thread.
        public static ThreadPriority backgroundLoadingPriority { get; set; }
        //
        // 摘要:
        //     Returns the path to the console log file, or an empty string if the current platform
        //     does not support log files.
        public static string consoleLogPath { get; }
        //
        // 摘要:
        //     Obsolete. Use Application.SetStackTraceLogType.
        [Obsolete("Use SetStackTraceLogType/GetStackTraceLogType instead")]
        public static StackTraceLogType stackTraceLogType { get; set; }
        //
        // 摘要:
        //     Specifies the frame rate at which Unity tries to render your game.
        public static int targetFrameRate { get; set; }
        //
        // 摘要:
        //     A unique cloud project identifier. It is unique for every project (Read Only).
        public static string cloudProjectId { get; }
        //
        // 摘要:
        //     Return application company name (Read Only).
        public static string companyName { get; }
        //
        // 摘要:
        //     How many bytes have we downloaded from the main unity web stream (Read Only).
        [Obsolete("Streaming was a Unity Web Player feature, and is removed. This property is deprecated and always returns 0.")]
        public static int streamedBytes { get; }
        //
        // 摘要:
        //     Is some level being loaded? (Read Only) (Obsolete).
        [Obsolete("This property is deprecated, please use LoadLevelAsync to detect if a specific scene is currently loading.")]
        public static bool isLoadingLevel { get; }
        //
        // 摘要:
        //     Should the player be running when the application is in the background?
        public static bool runInBackground { get; set; }
        //
        // 摘要:
        //     Are we running inside the Unity editor? (Read Only)
        public static bool isEditor { get; }
        //
        // 摘要:
        //     The total number of levels available (Read Only).
        [Obsolete("Use SceneManager.sceneCountInBuildSettings")]
        public static int levelCount { get; }
        //
        // 摘要:
        //     Note: This is now obsolete. Use SceneManager.GetActiveScene instead. (Read Only).
        [Obsolete("Use SceneManager to determine what scenes have been loaded")]
        public static int loadedLevel { get; }

        public static event Action<bool> focusChanged;
        public static event LowMemoryCallback lowMemory;
        public static event UnityAction onBeforeRender;
        public static event Func<bool> wantsToQuit;
        public static event LogCallback logMessageReceivedThreaded;
        public static event LogCallback logMessageReceived;
        public static event Action<string> deepLinkActivated;
        public static event Action quitting;
        public static event Action unloading;

        //
        // 摘要:
        //     Cancels quitting the application. This is useful for showing a splash screen
        //     at the end of a game.
        [FreeFunctionAttribute("GetInputManager().CancelQuitApplication")]
        [Obsolete("CancelQuit is deprecated. Use the wantsToQuit event instead.")]
        public static void CancelQuit();
        //
        // 摘要:
        //     Can the streamed level be loaded?
        //
        // 参数:
        //   levelName:
        [FreeFunctionAttribute("Application_Bindings::CanStreamedLevelBeLoaded")]
        public static bool CanStreamedLevelBeLoaded(string levelName);
        //
        // 摘要:
        //     Can the streamed level be loaded?
        //
        // 参数:
        //   levelIndex:
        public static bool CanStreamedLevelBeLoaded(int levelIndex);
        //
        // 摘要:
        //     Captures a screenshot at path filename as a PNG file.
        //
        // 参数:
        //   filename:
        //     Pathname to save the screenshot file to.
        //
        //   superSize:
        //     Factor by which to increase resolution.
        [Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
        public static void CaptureScreenshot(string filename, int superSize);
        //
        // 摘要:
        //     Captures a screenshot at path filename as a PNG file.
        //
        // 参数:
        //   filename:
        //     Pathname to save the screenshot file to.
        //
        //   superSize:
        //     Factor by which to increase resolution.
        [Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
        public static void CaptureScreenshot(string filename);
        [Obsolete("Use Object.DontDestroyOnLoad instead")]
        public static void DontDestroyOnLoad(Object o);
        //
        // 摘要:
        //     Calls a function in the web page that contains the WebGL Player.
        //
        // 参数:
        //   functionName:
        //     Name of the function to call.
        //
        //   args:
        //     Array of arguments passed in the call.
        [Obsolete("Application.ExternalCall is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
        public static void ExternalCall(string functionName, params object[] args);
        //
        // 摘要:
        //     Execution of a script function in the contained web page.
        //
        // 参数:
        //   script:
        //     The Javascript function to call.
        [Obsolete("Application.ExternalEval is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
        public static void ExternalEval(string script);
        [Obsolete("Use UnityEngine.Diagnostics.Utils.ForceCrash")]
        public static void ForceCrash(int mode);
        //
        // 摘要:
        //     Returns an array of feature tags in use for this build.
        [FreeFunctionAttribute("GetBuildSettings().GetBuildTags")]
        public static string[] GetBuildTags();
        //
        // 摘要:
        //     Get stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
        //
        // 参数:
        //   logType:
        [FreeFunctionAttribute("GetStackTraceLogType")]
        public static StackTraceLogType GetStackTraceLogType(LogType logType);
        //
        // 摘要:
        //     How far has the download progressed? [0...1].
        //
        // 参数:
        //   levelName:
        [Obsolete("Streaming was a Unity Web Player feature, and is removed. This function is deprecated and always returns 1.0.")]
        public static float GetStreamProgressForLevel(string levelName);
        //
        // 摘要:
        //     How far has the download progressed? [0...1].
        //
        // 参数:
        //   levelIndex:
        [Obsolete("Streaming was a Unity Web Player feature, and is removed. This function is deprecated and always returns 1.0 for valid level indices.")]
        public static float GetStreamProgressForLevel(int levelIndex);
        //
        // 摘要:
        //     Is Unity activated with the Pro license?
        [FreeFunctionAttribute("GetBuildSettings().GetHasPROVersion")]
        public static bool HasProLicense();
        //
        // 摘要:
        //     Check if the user has authorized use of the webcam or microphone in the Web Player.
        //
        // 参数:
        //   mode:
        [FreeFunctionAttribute("Application_Bindings::HasUserAuthorization")]
        public static bool HasUserAuthorization(UserAuthorization mode);
        //
        // 摘要:
        //     Returns true if the given object is part of the playing world either in any kind
        //     of built Player or in Play Mode.
        //
        // 参数:
        //   obj:
        //     The object to test.
        //
        // 返回结果:
        //     True if the object is part of the playing world.
        [FreeFunctionAttribute]
        public static bool IsPlaying([NotNullAttribute("NullExceptionObject")] Object obj);
        //
        // 摘要:
        //     Note: This is now obsolete. Use SceneManager.LoadScene instead.
        //
        // 参数:
        //   index:
        //     The level to load.
        //
        //   name:
        //     The name of the level to load.
        [Obsolete("Use SceneManager.LoadScene")]
        public static void LoadLevel(int index);
        //
        // 摘要:
        //     Note: This is now obsolete. Use SceneManager.LoadScene instead.
        //
        // 参数:
        //   index:
        //     The level to load.
        //
        //   name:
        //     The name of the level to load.
        [Obsolete("Use SceneManager.LoadScene")]
        public static void LoadLevel(string name);
        //
        // 摘要:
        //     Loads a level additively.
        //
        // 参数:
        //   index:
        //
        //   name:
        [Obsolete("Use SceneManager.LoadScene")]
        public static void LoadLevelAdditive(int index);
        //
        // 摘要:
        //     Loads a level additively.
        //
        // 参数:
        //   index:
        //
        //   name:
        [Obsolete("Use SceneManager.LoadScene")]
        public static void LoadLevelAdditive(string name);
        //
        // 摘要:
        //     Loads the level additively and asynchronously in the background.
        //
        // 参数:
        //   index:
        //
        //   levelName:
        [Obsolete("Use SceneManager.LoadSceneAsync")]
        public static AsyncOperation LoadLevelAdditiveAsync(string levelName);
        //
        // 摘要:
        //     Loads the level additively and asynchronously in the background.
        //
        // 参数:
        //   index:
        //
        //   levelName:
        [Obsolete("Use SceneManager.LoadSceneAsync")]
        public static AsyncOperation LoadLevelAdditiveAsync(int index);
        //
        // 摘要:
        //     Loads the level asynchronously in the background.
        //
        // 参数:
        //   index:
        //
        //   levelName:
        [Obsolete("Use SceneManager.LoadSceneAsync")]
        public static AsyncOperation LoadLevelAsync(int index);
        //
        // 摘要:
        //     Loads the level asynchronously in the background.
        //
        // 参数:
        //   index:
        //
        //   levelName:
        [Obsolete("Use SceneManager.LoadSceneAsync")]
        public static AsyncOperation LoadLevelAsync(string levelName);
        //
        // 摘要:
        //     Opens the URL specified, subject to the permissions and limitations of your app’s
        //     current platform and environment. This is handled in different ways depending
        //     on the nature of the URL, and with different security restrictions, depending
        //     on the runtime platform.
        //
        // 参数:
        //   url:
        //     The URL to open.
        [FreeFunctionAttribute("OpenURL")]
        public static void OpenURL(string url);
        [FreeFunctionAttribute("GetInputManager().QuitApplication")]
        public static void Quit(int exitCode);
        //
        // 摘要:
        //     Quits the player application.
        //
        // 参数:
        //   exitCode:
        //     An optional exit code to return when the player application terminates on Windows,
        //     Mac and Linux. Defaults to 0.
        public static void Quit();
        [Obsolete("Application.RegisterLogCallback is deprecated. Use Application.logMessageReceived instead.")]
        public static void RegisterLogCallback(LogCallback handler);
        [Obsolete("Application.RegisterLogCallbackThreaded is deprecated. Use Application.logMessageReceivedThreaded instead.")]
        public static void RegisterLogCallbackThreaded(LogCallback handler);
        [FreeFunctionAttribute("GetAdsIdHandler().RequestAdsIdAsync")]
        public static bool RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback delegateMethod);
        //
        // 摘要:
        //     Request authorization to use the webcam or microphone on iOS.
        //
        // 参数:
        //   mode:
        [FreeFunctionAttribute("Application_Bindings::RequestUserAuthorization")]
        public static AsyncOperation RequestUserAuthorization(UserAuthorization mode);
        //
        // 摘要:
        //     Set an array of feature tags for this build.
        //
        // 参数:
        //   buildTags:
        [FreeFunctionAttribute("GetBuildSettings().SetBuildTags")]
        public static void SetBuildTags(string[] buildTags);
        //
        // 摘要:
        //     Set stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
        //
        // 参数:
        //   logType:
        //
        //   stackTraceType:
        [FreeFunctionAttribute("SetStackTraceLogType")]
        public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);
        //
        // 摘要:
        //     Unloads the Unity Player.
        [FreeFunctionAttribute("Application_Bindings::Unload")]
        public static void Unload();
        //
        // 摘要:
        //     Unloads all GameObject associated with the given Scene. Note that assets are
        //     currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.
        //
        // 参数:
        //   index:
        //     Index of the Scene in the PlayerSettings to unload.
        //
        //   scenePath:
        //     Name of the Scene to Unload.
        //
        // 返回结果:
        //     Return true if the Scene is unloaded.
        [Obsolete("Use SceneManager.UnloadScene")]
        public static bool UnloadLevel(string scenePath);
        //
        // 摘要:
        //     Unloads all GameObject associated with the given Scene. Note that assets are
        //     currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.
        //
        // 参数:
        //   index:
        //     Index of the Scene in the PlayerSettings to unload.
        //
        //   scenePath:
        //     Name of the Scene to Unload.
        //
        // 返回结果:
        //     Return true if the Scene is unloaded.
        [Obsolete("Use SceneManager.UnloadScene")]
        public static bool UnloadLevel(int index);

        //
        // 摘要:
        //     Delegate method for fetching advertising ID.
        //
        // 参数:
        //   advertisingId:
        //     Advertising ID.
        //
        //   trackingEnabled:
        //     Indicates whether user has chosen to limit ad tracking.
        //
        //   errorMsg:
        //     Error message.
        public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMsg);
        //
        // 摘要:
        //     This is the delegate function when a mobile device notifies of low memory.
        public delegate void LowMemoryCallback();
        //
        // 摘要:
        //     Use this delegate type with Application.logMessageReceived or Application.logMessageReceivedThreaded
        //     to monitor what gets logged.
        //
        // 参数:
        //   condition:
        //
        //   stackTrace:
        //
        //   type:
        public delegate void LogCallback(string condition, string stackTrace, LogType type);
    }
}

