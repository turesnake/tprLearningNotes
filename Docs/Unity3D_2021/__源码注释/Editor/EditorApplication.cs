#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor.SceneManagement;
using UnityEditor.Scripting;
using UnityEditor.Scripting.ScriptCompilation;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.TestTools;

namespace UnityEditor;

//
// Summary:
//     Main Application class.
[NativeHeader("Editor/Src/ScriptCompilation/ScriptCompilationPipeline.h")]
[NativeHeader("Runtime/BaseClasses/TagManager.h")]
[StaticAccessor("EditorApplicationBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Editor/Src/ProjectVersion.h")]
[NativeHeader("Editor/Mono/EditorApplication.bindings.h")]
[NativeHeader("Runtime/Input/TimeManager.h")]
[NativeHeader("Runtime/Camera/RenderSettings.h")]
public sealed class EditorApplication
{
    //
    // Summary:
    //     Delegate to be called for every visible list item in the ProjectWindow on every
    //     OnGUI event.
    //
    // Parameters:
    //   guid:
    //
    //   selectionRect:
    public delegate void ProjectWindowItemCallback(string guid, Rect selectionRect);

    //
    // Summary:
    //     Delegate to be called for every visible list item in the HierarchyWindow on every
    //     OnGUI event.
    //
    // Parameters:
    //   instanceID:
    //
    //   selectionRect:
    public delegate void HierarchyWindowItemCallback(int instanceID, Rect selectionRect);

    //
    // Summary:
    //     Delegate to be called from EditorApplication callbacks.
    public delegate void CallbackFunction();

    //
    // Summary:
    //     Delegate to be called from EditorApplication contextual inspector callbacks.
    //
    //
    // Parameters:
    //   menu:
    //     The contextual menu which is about to be shown to the user.
    //
    //   property:
    //     The property for which the contextual menu is shown.
    public delegate void SerializedPropertyCallbackFunction(GenericMenu menu, SerializedProperty property);

    internal static UnityAction projectWasLoaded;

    internal static UnityAction editorApplicationQuit;

    //
    // Summary:
    //     Delegate for OnGUI events for every visible list item in the ProjectWindow.
    public static ProjectWindowItemCallback projectWindowItemOnGUI;

    //
    // Summary:
    //     Delegate for OnGUI events for every visible list item in the HierarchyWindow.
    public static HierarchyWindowItemCallback hierarchyWindowItemOnGUI;

    internal static CallbackFunction refreshHierarchy;

    internal static CallbackFunction dirtyHierarchySorting;

    //
    // Summary:
    //     Delegate for generic updates.
    public static CallbackFunction update;

    private static DelegateWithPerformanceTracker<CallbackFunction> m_UpdateEvent = new DelegateWithPerformanceTracker<CallbackFunction>("EditorApplication.update");

    private static EventWithPerformanceTracker<Func<bool>> m_WantsToQuitEvent = new EventWithPerformanceTracker<Func<bool>>("EditorApplication.wantsToQuit");

    private static EventWithPerformanceTracker<Action> m_QuittingEvent = new EventWithPerformanceTracker<Action>("EditorApplication.quitting");

    //
    // Summary:
    //     Delegate which is called once after all inspectors update.
    public static CallbackFunction delayCall;

    private static DelegateWithPerformanceTracker<CallbackFunction> m_DelayCallEvent = new DelegateWithPerformanceTracker<CallbackFunction>("EditorApplication.delayCall");

    private static EventWithPerformanceTracker<Action> m_HierarchyChangedEvent = new EventWithPerformanceTracker<Action>("EditorApplication.hierarchyChanged");

    //
    // Summary:
    //     A callback to be raised when an object in the hierarchy changes. Each time an
    //     object is (or a group of objects are) created, renamed, parented, unparented
    //     or destroyed this callback is raised.
    [Obsolete("Use EditorApplication.hierarchyChanged")]
    public static CallbackFunction hierarchyWindowChanged;

    private static EventWithPerformanceTracker<Action> m_ProjectChangedEvent = new EventWithPerformanceTracker<Action>("EditorApplication.projectChanged");

    //
    // Summary:
    //     Callback raised whenever the state of the Project window changes.
    [Obsolete("Use EditorApplication.projectChanged")]
    public static CallbackFunction projectWindowChanged;

    //
    // Summary:
    //     Callback raised whenever the contents of a window's search box are changed.
    public static CallbackFunction searchChanged;

    internal static CallbackFunction assetLabelsChanged;

    internal static CallbackFunction assetBundleNameChanged;

    //
    // Summary:
    //     Delegate for changed keyboard modifier keys.
    public static CallbackFunction modifierKeysChanged;

    private static EventWithPerformanceTracker<Action<PauseState>> m_PauseStateChangedEvent = new EventWithPerformanceTracker<Action<PauseState>>("EditorApplication.pauseStateChanged");

    private static EventWithPerformanceTracker<Action<PlayModeStateChange>> m_PlayModeStateChangedEvent = new EventWithPerformanceTracker<Action<PlayModeStateChange>>("EditorApplication.playModeStateChanged");

    [Obsolete("Use EditorApplication.playModeStateChanged and/or EditorApplication.pauseStateChanged")]
    public static CallbackFunction playmodeStateChanged;

    internal static CallbackFunction globalEventHandler;

    internal static Func<bool> doPressedKeysTriggerAnyShortcut;

    internal static CallbackFunction windowsReordered;

    //
    // Summary:
    //     Callback raised whenever the user contex-clicks on a property in an Inspector.
    public static SerializedPropertyCallbackFunction contextualPropertyMenu;

    //
    // Summary:
    //     Is editor currently in play mode?
    public static extern bool isPlaying
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Is editor either currently in play mode, or about to switch to it? (Read Only)
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    public static extern bool isPlayingOrWillChangePlaymode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("IsPlayingOrWillEnterExitPlaymode")]
        get;
    }

    //
    // Summary:
    //     Is editor currently paused?
    [StaticAccessor("GetApplication().GetPlayerLoopController()", StaticAccessorType.Dot)]
    public static extern bool isPaused
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("IsPaused")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetPaused")]
        set;
    }

    //
    // Summary:
    //     Is editor currently compiling scripts? (Read Only)
    public static bool isCompiling => EditorCompilationInterface.IsCompiling();

    //
    // Summary:
    //     True if the Editor is currently refreshing the AssetDatabase.
    public static extern bool isUpdating
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Is editor currently connected to Unity Remote 4 client app.
    public static extern bool isRemoteConnected
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Returns the scripting runtime version currently used by the Editor.
    [Obsolete("ScriptingRuntimeVersion has been deprecated in 2019.3 due to the removal of legacy mono")]
    public static ScriptingRuntimeVersion scriptingRuntimeVersion => ScriptingRuntimeVersion.Latest;

    [StaticAccessor("ScriptingManager", StaticAccessorType.DoubleColon)]
    internal static extern bool useLibmonoBackendForIl2cpp
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("UseLibmonoBackendForIl2cpp")]
        get;
    }

    //
    // Summary:
    //     Path to the Unity editor contents folder. (Read Only)
    public static extern string applicationContentsPath
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetApplicationContentsPath", IsThreadSafe = true)]
        get;
    }

    //
    // Summary:
    //     Returns the path to the Unity editor application. (Read Only)
    public static extern string applicationPath
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetApplicationPath", IsThreadSafe = true)]
        get;
    }

    internal static extern bool isBuildingAnyResources
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("IsBuildingAnyResources")]
        get;
    }

    internal static extern bool isPackageManagerDisabled
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("IsPackageManagerDisabled")]
        get;
    }

    internal static extern string userJavascriptPackagesPath
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Returns true if the current project was created as a temporary project.
    public static extern bool isTemporaryProject
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("IsTemporaryProject")]
        get;
    }

    internal static extern UnityEngine.Object tagManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction]
        get;
    }

    internal static extern UnityEngine.Object renderSettings
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction]
        get;
    }

    //
    // Summary:
    //     The time since the editor was started. (Read Only)
    public static extern double timeSinceStartup
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction]
        get;
    }

    internal static extern string windowTitle
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
        get;
    }

    //
    // Summary:
    //     Is true if the currently open Scene in the editor contains unsaved modifications.
    [Obsolete("Use Scene.isDirty instead. Use EditorSceneManager.GetScene API to get each open scene")]
    public static bool isSceneDirty => SceneManager.GetActiveScene().isDirty;

    //
    // Summary:
    //     The path of the Scene that the user has currently open (Will be an empty string
    //     if no Scene is currently open). (Read Only)
    [Obsolete("Use EditorSceneManager to see which scenes are currently loaded")]
    public static string currentScene
    {
        get
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.IsValid())
            {
                return activeScene.path;
            }

            return "";
        }
        set
        {
        }
    }

    internal static event CallbackFunction tick;

    public static event Func<bool> wantsToQuit
    {
        add
        {
            m_WantsToQuitEvent.Add(value);
        }
        remove
        {
            m_WantsToQuitEvent.Remove(value);
        }
    }

    public static event Action quitting
    {
        add
        {
            m_QuittingEvent.Add(value);
        }
        remove
        {
            m_QuittingEvent.Remove(value);
        }
    }

    public static event Action hierarchyChanged
    {
        add
        {
            m_HierarchyChangedEvent.Add(value);
        }
        remove
        {
            m_HierarchyChangedEvent.Remove(value);
        }
    }

    public static event Action projectChanged
    {
        add
        {
            m_ProjectChangedEvent.Add(value);
        }
        remove
        {
            m_ProjectChangedEvent.Remove(value);
        }
    }

    public static event Action<PauseState> pauseStateChanged
    {
        add
        {
            m_PauseStateChangedEvent.Add(value);
        }
        remove
        {
            m_PauseStateChangedEvent.Remove(value);
        }
    }

    public static event Action<PlayModeStateChange> playModeStateChanged
    {
        add
        {
            m_PlayModeStateChangedEvent.Add(value);
        }
        remove
        {
            m_PlayModeStateChangedEvent.Remove(value);
        }
    }

    internal static event Action<bool> focusChanged;

    internal static event Action<ApplicationTitleDescriptor> updateMainWindowTitle;

    //
    // Summary:
    //     Load the given level in play mode.
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.LoadSceneInPlayMode instead.")]
    public static void LoadLevelInPlayMode(string path)
    {
        LoadSceneParameters loadSceneParameters = default(LoadSceneParameters);
        loadSceneParameters.loadSceneMode = LoadSceneMode.Single;
        LoadSceneParameters parameters = loadSceneParameters;
        EditorSceneManager.LoadSceneInPlayMode(path, parameters);
    }

    //
    // Summary:
    //     Load the given level additively in play mode.
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.LoadSceneInPlayMode instead.")]
    public static void LoadLevelAdditiveInPlayMode(string path)
    {
        LoadSceneParameters loadSceneParameters = default(LoadSceneParameters);
        loadSceneParameters.loadSceneMode = LoadSceneMode.Additive;
        LoadSceneParameters parameters = loadSceneParameters;
        EditorSceneManager.LoadSceneInPlayMode(path, parameters);
    }

    //
    // Summary:
    //     Load the given level in play mode asynchronously.
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.LoadSceneAsyncInPlayMode instead.")]
    public static AsyncOperation LoadLevelAsyncInPlayMode(string path)
    {
        LoadSceneParameters loadSceneParameters = default(LoadSceneParameters);
        loadSceneParameters.loadSceneMode = LoadSceneMode.Single;
        LoadSceneParameters parameters = loadSceneParameters;
        return EditorSceneManager.LoadSceneAsyncInPlayMode(path, parameters);
    }

    //
    // Summary:
    //     Load the given level additively in play mode asynchronously
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.LoadSceneAsyncInPlayMode instead.")]
    public static AsyncOperation LoadLevelAdditiveAsyncInPlayMode(string path)
    {
        LoadSceneParameters loadSceneParameters = default(LoadSceneParameters);
        loadSceneParameters.loadSceneMode = LoadSceneMode.Additive;
        LoadSceneParameters parameters = loadSceneParameters;
        return EditorSceneManager.LoadSceneAsyncInPlayMode(path, parameters);
    }

    //
    // Summary:
    //     Open another project.
    //
    // Parameters:
    //   projectPath:
    //     The path of a project to open.
    //
    //   args:
    //     Arguments to pass to command line.
    public static void OpenProject(string projectPath, params string[] args)
    {
        OpenProjectInternal(projectPath, args);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void OpenProjectInternal(string projectPath, string[] args);

    //
    // Summary:
    //     Saves all serializable assets that have not yet been written to disk (eg. Materials).
    [Obsolete("Use AssetDatabase.SaveAssets instead (UnityUpgradable) -> AssetDatabase.SaveAssets()", true)]
    public static void SaveAssets()
    {
    }

    //
    // Summary:
    //     Switches the editor to Play mode.
    public static void EnterPlaymode()
    {
        isPlaying = true;
    }

    //
    // Summary:
    //     Switches the editor to Edit mode.
    public static void ExitPlaymode()
    {
        isPlaying = false;
    }

    //
    // Summary:
    //     Perform a single frame step.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication().GetPlayerLoopController()", StaticAccessorType.Dot)]
    public static extern void Step();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern bool IsInitialized();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern string GetLicenseType();

    //
    // Summary:
    //     Prevents loading of assemblies when it is inconvenient.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    public static extern void LockReloadAssemblies();

    //
    // Summary:
    //     Must be called after LockReloadAssemblies, to reenable loading of assemblies.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    public static extern void UnlockReloadAssemblies();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern bool CanReloadAssemblies();

    //
    // Summary:
    //     Invokes the menu item in the specified path.
    //
    // Parameters:
    //   menuItemPath:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool ExecuteMenuItem(string menuItemPath);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool ValidateMenuItem(string menuItemPath);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool ExecuteMenuItemOnGameObjects(string menuItemPath, GameObject[] objects);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool ExecuteMenuItemWithTemporaryContext(string menuItemPath, UnityEngine.Object[] objects);

    //
    // Summary:
    //     Sets the path that Unity should store the current temporary project at, when
    //     the project is closed.
    //
    // Parameters:
    //   path:
    //     The path that the current temporary project should be relocated to when closing
    //     it.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    public static extern void SetTemporaryProjectKeepPath(string path);

    //
    // Summary:
    //     Exit the Unity editor application.
    //
    // Parameters:
    //   returnValue:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Exit(int returnValue);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern void SetSceneRepaintDirty();

    //
    // Summary:
    //     Normally, a player loop update will occur in the editor when the Scene has been
    //     modified. This method allows you to queue a player loop update regardless of
    //     whether the Scene has been modified.
    public static void QueuePlayerLoopUpdate()
    {
        SetSceneRepaintDirty();
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UpdateSceneIfNeeded();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern void UpdateMainWindowTitle();

    //
    // Summary:
    //     Plays system beep sound.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("UnityBeep")]
    public static extern void Beep();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void CloseAndRelaunch(string[] arguments);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void RequestCloseAndRelaunchWithCurrentArguments();

    internal static void RestartEditorAndRecompileScripts()
    {
        EditorCompilationInterface.Instance.DeleteScriptAssemblies();
        RequestCloseAndRelaunchWithCurrentArguments();
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern void FileMenuNewScene();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [ThreadSafe]
    internal static extern void SignalTick();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    internal static extern void UpdateInteractionModeSettings();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("GetProjectVersion().Write")]
    internal static extern void WriteVersion();

    [RequiredByNativeCode]
    private static void Internal_ProjectWasLoaded()
    {
        projectWasLoaded?.Invoke();
    }

    [RequiredByNativeCode]
    private static bool Internal_EditorApplicationWantsToQuit()
    {
        if (!m_WantsToQuitEvent.hasSubscribers)
        {
            return true;
        }

        foreach (Func<bool> item in m_WantsToQuitEvent)
        {
            try
            {
                if (!item())
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarningFormat("EditorApplication.wantsToQuit: Exception raised during quit event." + Environment.NewLine + "Check the exception error's callstack to find out which event handler threw the exception.");
                Debug.LogException(ex);
                if (InternalEditorUtility.isHumanControllingUs)
                {
                    string stackTrace = ex.StackTrace;
                    StringBuilder stringBuilder = new StringBuilder("An exception was thrown here:");
                    stringBuilder.AppendLine(Environment.NewLine);
                    stringBuilder.AppendLine(stackTrace.Substring(0, stackTrace.IndexOf(Environment.NewLine)));
                    if (!EditorUtility.DisplayDialog("Error while quitting", stringBuilder.ToString(), "Ignore", "Cancel Quit"))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private static void Internal_EditorApplicationQuit()
    {
        VersionControlManager.Deactivate();
        foreach (Action item in m_QuittingEvent)
        {
            item();
        }

        editorApplicationQuit?.Invoke();
        ScriptCompilers.Cleanup();
    }

    //
    // Summary:
    //     Can be used to ensure repaint of the ProjectWindow.
    public static void RepaintProjectWindow()
    {
        foreach (ProjectBrowser allProjectBrowser in ProjectBrowser.GetAllProjectBrowsers())
        {
            allProjectBrowser.Repaint();
        }
    }

    public static void RepaintAnimationWindow()
    {
        foreach (AnimEditor allAnimationWindow in AnimEditor.GetAllAnimationWindows())
        {
            allAnimationWindow.Repaint();
        }
    }

    //
    // Summary:
    //     Can be used to ensure repaint of the HierarchyWindow.
    public static void RepaintHierarchyWindow()
    {
        refreshHierarchy?.Invoke();
    }

    //
    // Summary:
    //     Set the hierarchy sorting method as dirty.
    public static void DirtyHierarchyWindowSorting()
    {
        dirtyHierarchySorting?.Invoke();
    }

    internal static Action CallDelayed(CallbackFunction action, double delaySeconds = 0.0)
    {
        DateTime startTime = DateTime.Now;
        CallbackFunction delayedHandler = null;
        delayedHandler = delegate
        {
            if (!((DateTime.Now - startTime).TotalSeconds < delaySeconds))
            {
                tick -= delayedHandler;
                action();
            }
        };
        tick += delayedHandler;
        if (delaySeconds == 0.0)
        {
            SignalTick();
        }

        return delegate
        {
            tick -= delayedHandler;
        };
    }

    internal static string GetDefaultMainWindowTitle(ApplicationTitleDescriptor desc)
    {
        string text = ((Application.platform == RuntimePlatform.OSXEditor) ? (desc.activeSceneName + " - " + desc.projectName) : (desc.projectName + " - " + desc.activeSceneName));
        if (!string.IsNullOrEmpty(desc.targetName))
        {
            text = text + " - " + desc.targetName;
        }

        text = text + " - Unity " + desc.unityVersion;
        if (!string.IsNullOrEmpty(desc.licenseType))
        {
            text = text + " " + desc.licenseType;
        }

        if (desc.codeCoverageEnabled)
        {
            text = text + " " + L10n.Tr("[CODE COVERAGE]");
        }

        return text;
    }

    [RequiredByNativeCode]
    internal static string BuildMainWindowTitle()
    {
        string activeSceneName = L10n.Tr("Untitled");
        if (!string.IsNullOrEmpty(SceneManager.GetActiveScene().path))
        {
            activeSceneName = Path.GetFileNameWithoutExtension(SceneManager.GetActiveScene().path);
        }

        ApplicationTitleDescriptor applicationTitleDescriptor = new ApplicationTitleDescriptor(isTemporaryProject ? PlayerSettings.productName : Path.GetFileName(Path.GetDirectoryName(Application.dataPath)), InternalEditorUtility.GetUnityDisplayVersion(), activeSceneName, GetLicenseType(), BuildPipeline.GetBuildTargetGroupDisplayName(BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget)), Coverage.enabled);
        applicationTitleDescriptor.title = GetDefaultMainWindowTitle(applicationTitleDescriptor);
        EditorApplication.updateMainWindowTitle?.Invoke(applicationTitleDescriptor);
        return applicationTitleDescriptor.title;
    }

    [RequiredByNativeCode]
    internal static void Internal_CallUpdateFunctions()
    {
        if (update == null)
        {
            return;
        }

        foreach (CallbackFunction item in m_UpdateEvent.UpdateAndInvoke(update))
        {
            item();
        }
    }

    [RequiredByNativeCode]
    internal static void Internal_InvokeTickEvents()
    {
        EditorApplication.tick?.Invoke();
    }

    [RequiredByNativeCode]
    internal static void Internal_CallDelayFunctions()
    {
        CallbackFunction value = delayCall;
        delayCall = null;
        foreach (CallbackFunction item in m_DelayCallEvent.UpdateAndInvoke(value))
        {
            item();
        }
    }

    internal static void Internal_SwitchSkin()
    {
        EditorGUIUtility.Internal_SwitchSkin();
    }

    internal static void RequestRepaintAllViews()
    {
        UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(GUIView));
        for (int i = 0; i < array.Length; i++)
        {
            GUIView gUIView = (GUIView)array[i];
            gUIView.Repaint();
        }
    }

    private static void Internal_CallHierarchyHasChanged()
    {
        hierarchyWindowChanged?.Invoke();
        foreach (Action item in m_HierarchyChangedEvent)
        {
            item();
        }
    }

    [RequiredByNativeCode]
    private static void Internal_CallProjectHasChanged()
    {
        projectWindowChanged?.Invoke();
        foreach (Action item in m_ProjectChangedEvent)
        {
            item();
        }
    }

    internal static void Internal_CallSearchHasChanged()
    {
        searchChanged?.Invoke();
    }

    internal static void Internal_CallAssetLabelsHaveChanged()
    {
        assetLabelsChanged?.Invoke();
    }

    internal static void Internal_CallAssetBundleNameChanged()
    {
        assetBundleNameChanged?.Invoke();
    }

    private static void Internal_PauseStateChanged(PauseState state)
    {
        playmodeStateChanged?.Invoke();
        foreach (Action<PauseState> item in m_PauseStateChangedEvent)
        {
            item(state);
        }
    }

    private static void Internal_PlayModeStateChanged(PlayModeStateChange state)
    {
        playmodeStateChanged?.Invoke();
        foreach (Action<PlayModeStateChange> item in m_PlayModeStateChangedEvent)
        {
            item(state);
        }
    }

    private static void Internal_CallKeyboardModifiersChanged()
    {
        modifierKeysChanged?.Invoke();
    }

    private static void Internal_CallWindowsReordered()
    {
        windowsReordered?.Invoke();
    }

    [RequiredByNativeCode]
    private static bool DoPressedKeysTriggerAnyShortcutHandler()
    {
        if (doPressedKeysTriggerAnyShortcut != null)
        {
            return doPressedKeysTriggerAnyShortcut();
        }

        return false;
    }

    [RequiredByNativeCode]
    private static void Internal_CallGlobalEventHandler()
    {
        globalEventHandler?.Invoke();
        WindowLayout.MaximizeGestureHandler();
        Event.current = null;
    }

    [RequiredByNativeCode]
    private static void Internal_FocusChanged(bool isFocused)
    {
        EditorApplication.focusChanged?.Invoke(isFocused);
    }

    [MenuItem("File/New Scene %n", priority = 150)]
    private static void FireFileMenuNewScene()
    {
        if (CommandService.Exists("Menu/File/NewSceneTemplate"))
        {
            CommandService.Execute("Menu/File/NewSceneTemplate");
        }
        else
        {
            FileMenuNewScene();
        }
    }

    internal static void TogglePlaying()
    {
        isPlaying = !isPlaying;
        InternalEditorUtility.RepaintAllViews();
    }

    //
    // Summary:
    //     Create a new Scene.
    [Obsolete("Use EditorSceneManager.NewScene (NewSceneSetup.DefaultGameObjects)")]
    public static void NewScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
    }

    //
    // Summary:
    //     Create a new absolutely empty Scene.
    [Obsolete("Use EditorSceneManager.NewScene (NewSceneSetup.EmptyScene)")]
    public static void NewEmptyScene()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }

    //
    // Summary:
    //     Opens the Scene at path.
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.OpenScene")]
    public static bool OpenScene(string path)
    {
        if (!isPlaying)
        {
            return EditorSceneManager.OpenScene(path).IsValid();
        }

        throw new InvalidOperationException("EditorApplication.OpenScene() cannot be called when in the Unity Editor is in play mode.");
    }

    //
    // Summary:
    //     Opens the Scene at path additively.
    //
    // Parameters:
    //   path:
    [Obsolete("Use EditorSceneManager.OpenScene")]
    public static void OpenSceneAdditive(string path)
    {
        if (Application.isPlaying)
        {
            Debug.LogWarning("Exiting playmode.\nOpenSceneAdditive was called at a point where there was no active scene.\nThis usually means it was called in a PostprocessScene function during scene loading or it was called during playmode.\nThis is no longer allowed. Use SceneManager.LoadScene to load scenes at runtime or in playmode.");
        }

        Scene sourceScene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.MergeScenes(sourceScene, activeScene);
    }

    //
    // Summary:
    //     Save the open Scene.
    //
    // Parameters:
    //   path:
    //     The file path to save at. If empty, the current open Scene will be overwritten,
    //     or if never saved before, a save dialog is shown.
    //
    //   saveAsCopy:
    //     If set to true, the Scene will be saved without changing the currentScene and
    //     without clearing the unsaved changes marker.
    //
    // Returns:
    //     True if the save succeeded, otherwise false.
    [Obsolete("Use EditorSceneManager.SaveScene")]
    public static bool SaveScene()
    {
        return EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "", saveAsCopy: false);
    }

    //
    // Summary:
    //     Save the open Scene.
    //
    // Parameters:
    //   path:
    //     The file path to save at. If empty, the current open Scene will be overwritten,
    //     or if never saved before, a save dialog is shown.
    //
    //   saveAsCopy:
    //     If set to true, the Scene will be saved without changing the currentScene and
    //     without clearing the unsaved changes marker.
    //
    // Returns:
    //     True if the save succeeded, otherwise false.
    [Obsolete("Use EditorSceneManager.SaveScene")]
    public static bool SaveScene(string path)
    {
        return EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), path, saveAsCopy: false);
    }

    //
    // Summary:
    //     Save the open Scene.
    //
    // Parameters:
    //   path:
    //     The file path to save at. If empty, the current open Scene will be overwritten,
    //     or if never saved before, a save dialog is shown.
    //
    //   saveAsCopy:
    //     If set to true, the Scene will be saved without changing the currentScene and
    //     without clearing the unsaved changes marker.
    //
    // Returns:
    //     True if the save succeeded, otherwise false.
    [Obsolete("Use EditorSceneManager.SaveScene")]
    public static bool SaveScene(string path, bool saveAsCopy)
    {
        return EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), path, saveAsCopy);
    }

    //
    // Summary:
    //     Ask the user if they want to save the open Scene.
    [Obsolete("Use EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo")]
    public static bool SaveCurrentSceneIfUserWantsTo()
    {
        return EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [Obsolete("This function is internal and no longer supported")]
    internal static bool SaveCurrentSceneIfUserWantsToForce()
    {
        return false;
    }

    //
    // Summary:
    //     Explicitly mark the current opened Scene as modified.
    [Obsolete("Use EditorSceneManager.MarkSceneDirty or EditorSceneManager.MarkAllScenesDirty")]
    public static void MarkSceneDirty()
    {
        EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
}



