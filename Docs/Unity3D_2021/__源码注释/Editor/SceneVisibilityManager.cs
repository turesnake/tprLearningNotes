#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor;


/*
    在 Unity 编辑器中，SceneVisibilityManager 是用于管理场景中对象的可见性和可选性的类。它提供了一些方法，可以让开发者在场景编辑器中临时隐藏或禁用对某些对象的选择。
    这在处理复杂场景时特别有用，比如避免意外选择某些对象，或者专注于特定对象的编辑。
*/

//
// Summary:
//     Manages Scene Visibility in the editor.
public class SceneVisibilityManager : ScriptableSingleton<SceneVisibilityManager>
{
    internal class ShortcutContext : IShortcutToolContext
    {
        public bool active
        {
            get
            {
                EditorWindow focusedWindow = EditorWindow.focusedWindow;
                if (focusedWindow != null)
                {
                    return focusedWindow.GetType() == typeof(SceneView) || focusedWindow.GetType() == typeof(SceneHierarchyWindow);
                }

                return false;
            }
        }
    }

    internal enum SceneVisState
    {
        AllHidden,
        AllVisible,
        Mixed
    }

    internal enum ScenePickingState
    {
        PickingDisabledAll,
        PickingEnabledAll,
        Mixed
    }

    private static ShortcutContext s_ShortcutContext;

    private static readonly List<GameObject> m_RootBuffer = new List<GameObject>();

    private List<Scene> m_SelectedScenes = new List<Scene>();

    internal bool enableSceneVisibility
    {
        get
        {
            return SceneVisibilityState.visibilityActive;
        }
        set
        {
            SceneVisibilityState.visibilityActive = value;
        }
    }

    internal bool enableScenePicking
    {
        get
        {
            return SceneVisibilityState.pickingActive;
        }
        set
        {
            SceneVisibilityState.pickingActive = value;
        }
    }

    public static event Action visibilityChanged;

    public static event Action pickingChanged;

    internal static event Action<bool> currentStageIsIsolated;

    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        Undo.undoRedoPerformed = (Undo.UndoRedoCallback)Delegate.Combine(Undo.undoRedoPerformed, new Undo.UndoRedoCallback(UndoRedoPerformed));
        EditorSceneManager.newSceneCreated += EditorSceneManagerOnNewSceneCreated;
        EditorSceneManager.sceneSaving += EditorSceneManagerOnSceneSaving;
        EditorSceneManager.sceneSaved += EditorSceneManagerOnSceneSaved;
        EditorSceneManager.sceneOpening += EditorSceneManagerOnSceneOpening;
        EditorSceneManager.sceneOpened += EditorSceneManagerOnSceneOpened;
        EditorSceneManager.sceneClosing += EditorSceneManagerOnSceneClosing;
        EditorApplication.playModeStateChanged += EditorApplicationPlayModeStateChanged;
        ScriptableSingleton<StageNavigationManager>.instance.afterSuccessfullySwitchedToStage += StageNavigationManagerAfterSuccessfullySwitchedToStage;
        SceneVisibilityState.internalStructureChanged = (Action)Delegate.Combine(SceneVisibilityState.internalStructureChanged, new Action(InternalStructureChanged));
        PreviewSceneStage previewSceneStage = ScriptableSingleton<StageNavigationManager>.instance.currentStage as PreviewSceneStage;
        SceneVisibilityState.ForceDataUpdate();
        s_ShortcutContext = new ShortcutContext();
        EditorApplication.delayCall = (EditorApplication.CallbackFunction)Delegate.Combine(EditorApplication.delayCall, (EditorApplication.CallbackFunction)delegate
        {
            ShortcutIntegration.instance.contextManager.RegisterToolContext(s_ShortcutContext);
        });
    }

    private static void InternalStructureChanged()
    {
        ScriptableSingleton<SceneVisibilityManager>.instance.VisibilityChanged();
        ScriptableSingleton<SceneVisibilityManager>.instance.PickableContentChanged();
    }

    private static void EditorSceneManagerOnSceneOpened(Scene scene, OpenSceneMode mode)
    {
        if (mode == OpenSceneMode.Single)
        {
            SceneVisibilityState.isolation = false;
        }

        if (mode == OpenSceneMode.Additive && ScriptableSingleton<StageNavigationManager>.instance.currentStage is MainStage)
        {
            Undo.ClearUndo(SceneVisibilityState.GetInstance());
        }
    }

    internal static void StageNavigationManagerAfterSuccessfullySwitchedToStage(Stage newStage)
    {
        RevertIsolationCurrentStage();
        SceneVisibilityState.ForceDataUpdate();
        if (newStage is MainStage)
        {
            SceneVisibilityState.CleanTempScenes();
        }
    }

    private static void EditorApplicationPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            SceneVisibilityState.GeneratePersistentDataForAllLoadedScenes();
        }
    }

    private static void EditorSceneManagerOnSceneSaved(Scene scene)
    {
        SceneVisibilityState.OnSceneSaved(scene);
    }

    private static void EditorSceneManagerOnSceneSaving(Scene scene, string path)
    {
        SceneVisibilityState.OnSceneSaving(scene, path);
    }

    private static void EditorSceneManagerOnSceneOpening(string path, OpenSceneMode mode)
    {
        RevertIsolationCurrentStage();
        if (mode == OpenSceneMode.Single)
        {
            SceneVisibilityState.GeneratePersistentDataForAllLoadedScenes();
        }
    }

    private static void EditorSceneManagerOnSceneClosing(Scene scene, bool removingScene)
    {
        if (!BuildPipeline.isBuildingPlayer)
        {
            SceneVisibilityState.GeneratePersistentDataForLoadedScene(scene);
        }
    }

    private static void EditorSceneManagerOnNewSceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode)
    {
        if (mode == NewSceneMode.Single)
        {
            SceneVisibilityState.GeneratePersistentDataForAllLoadedScenes();
        }

        SceneVisibilityState.ClearScene(scene);
    }

    private static void UndoRedoPerformed()
    {
        SceneVisibilityState.ForceDataUpdate();
    }

    //
    // Summary:
    //     Hides all GameObjects.
    public void HideAll()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Hide All");
        HideAllNoUndo();
    }

    private void HideAllNoUndo()
    {
        Stage currentStage = ScriptableSingleton<StageNavigationManager>.instance.currentStage;
        for (int i = 0; i < currentStage.sceneCount; i++)
        {
            HideNoUndo(currentStage.GetSceneAt(i));
        }
    }

    //
    // Summary:
    //     Disables picking on all GameObjects.
    public void DisableAllPicking()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Disable All Picking");
        DisableAllPickingNoUndo();
    }

    private void DisableAllPickingNoUndo()
    {
        PreviewSceneStage previewSceneStage = ScriptableSingleton<StageNavigationManager>.instance.currentStage as PreviewSceneStage;
        if (previewSceneStage != null)
        {
            Scene scene = previewSceneStage.scene;
            SceneVisibilityState.EnablePicking(previewSceneStage.scene);
            SceneVisibilityState.DisablePicking(scene);
        }
        else
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                DisablePicking(SceneManager.GetSceneAt(i));
            }
        }
    }

    //
    // Summary:
    //     Shows a GameObject, or an array of GameObjects, and its descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to show.
    //
    //   gameObjects:
    //     Array of GameObjects to show.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void Show(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Show GameObject");
        SceneVisibilityState.SetGameObjectHidden(gameObject, isHidden: false, includeDescendants);
    }

    //
    // Summary:
    //     Hides a GameObject, or an Array of GameObjects, and their descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to hide.
    //
    //   gameObjects:
    //     Array of GameObjects to hide.
    //
    //   includeDescendants:
    //     Whether to also hide descendants.
    public void Hide(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Hide GameObject");
        SceneVisibilityState.SetGameObjectHidden(gameObject, isHidden: true, includeDescendants);
    }

    //
    // Summary:
    //     Disables picking on a GameObject, or an Array of GameObjects, and their descendants.
    //
    //
    // Parameters:
    //   gameObject:
    //     GameObject on which to disable picking.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    //
    //   gameObjects:
    //     Array of GameObjects on which to disable picking.
    public void DisablePicking(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Disable Picking GameObject");
        SceneVisibilityState.SetGameObjectPickingDisabled(gameObject, pickingDisabled: true, includeDescendants);
    }

    //
    // Summary:
    //     Enables picking on a GameObject, or an array of GameObjects, and its descendants.
    //
    //
    // Parameters:
    //   includeDescendants:
    //     Whether to include descendants.
    //
    //   gameObject:
    //     GameObject on which to enable picking.
    //
    //   gameObjects:
    //     Array of GameObjects on which to enable picking.
    public void EnablePicking(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Enable Picking GameObject");
        SceneVisibilityState.SetGameObjectPickingDisabled(gameObject, pickingDisabled: false, includeDescendants);
    }

    [Shortcut("Scene Visibility/Show All", null)]
    internal static void ShowAllShortcut()
    {
        ScriptableSingleton<SceneVisibilityManager>.instance.ShowAll();
    }

    //
    // Summary:
    //     Shows all GameObjects.
    public void ShowAll()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Show All");
        Stage currentStage = ScriptableSingleton<StageNavigationManager>.instance.currentStage;
        for (int i = 0; i < currentStage.sceneCount; i++)
        {
            Show(currentStage.GetSceneAt(i), sendContentChangedEvent: false);
        }
    }

    //
    // Summary:
    //     Enables picking on all GameObjects.
    public void EnableAllPicking()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Enable All Picking");
        PreviewSceneStage previewSceneStage = ScriptableSingleton<StageNavigationManager>.instance.currentStage as PreviewSceneStage;
        if (previewSceneStage != null)
        {
            SceneVisibilityState.EnablePicking(previewSceneStage.scene);
            return;
        }

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            EnablePickingNoUndo(SceneManager.GetSceneAt(i));
        }
    }

    private void Show(Scene scene, bool sendContentChangedEvent)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            SceneVisibilityState.ShowScene(scene);
            if (sendContentChangedEvent)
            {
                VisibilityChanged();
            }
        }
    }

    private void EnablePickingNoUndo(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            SceneVisibilityState.EnablePicking(scene);
        }
    }

    //
    // Summary:
    //     Shows all GameObjects in scene.
    //
    // Parameters:
    //   scene:
    //     Scene containing GameObjects to show.
    public void Show(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            Undo.RecordObject(SceneVisibilityState.GetInstance(), "Show Scene");
            Show(scene, sendContentChangedEvent: true);
        }
    }

    //
    // Summary:
    //     Enables picking on all GameObjects in a Scene.
    //
    // Parameters:
    //   scene:
    //     Scene containing GameObjects on which to enable picking.
    public void EnablePicking(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            Undo.RecordObject(SceneVisibilityState.GetInstance(), "Enable Picking Scene");
            EnablePickingNoUndo(scene);
        }
    }

    private void HideNoUndo(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            SceneVisibilityState.ShowScene(scene);
            scene.GetRootGameObjects(m_RootBuffer);
            SceneVisibilityState.SetGameObjectsHidden(m_RootBuffer.ToArray(), isHidden: true, includeChildren: true);
        }
    }

    internal void DisablePickingNoUndo(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            SceneVisibilityState.EnablePicking(scene);
            scene.GetRootGameObjects(m_RootBuffer);
            SceneVisibilityState.SetGameObjectsPickingDisabled(m_RootBuffer.ToArray(), pickingDisabled: true, includeChildren: true);
        }
    }

    //
    // Summary:
    //     Hides all GameObjects in a scene.
    //
    // Parameters:
    //   scene:
    //     Scene containing GameObjects to hide.
    public void Hide(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            Undo.RecordObject(SceneVisibilityState.GetInstance(), "Hide Scene");
            HideNoUndo(scene);
        }
    }

    //
    // Summary:
    //     Disables picking on all GameObjects in a Scene.
    //
    // Parameters:
    //   scene:
    //     Scene containing GameObjects on which to disable picking.
    public void DisablePicking(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            Undo.RecordObject(SceneVisibilityState.GetInstance(), "Disable Picking Scene");
            DisablePickingNoUndo(scene);
        }
    }

    //
    // Summary:
    //     Checks the hidden state of a GameObject and, optionally, its descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to check.
    //
    //   includeDescendants:
    //     Specify true to check the GameObject and all its descendants. Set to false to
    //     check the GameObject.
    //
    // Returns:
    //     When includeDescendants is true, this method returns true when the GameObject
    //     and all its descendants are hidden. When includeDescendants is false, this method
    //     returns true when the GameObject is hidden.
    public bool IsHidden(GameObject gameObject, bool includeDescendants = false)
    {
        if (includeDescendants)
        {
            return SceneVisibilityState.IsHierarchyHidden(gameObject);
        }

        return SceneVisibilityState.IsGameObjectHidden(gameObject);
    }

    public bool IsHidden(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        scene.GetRootGameObjects(m_RootBuffer);
        foreach (GameObject item in m_RootBuffer)
        {
            if (!SceneVisibilityState.IsHierarchyHidden(item))
            {
                return false;
            }
        }

        return true;
    }

    //
    // Summary:
    //     Checks the picking state of a GameObject and, optionally, its descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to check.
    //
    //   includeDescendants:
    //     Specify true to check the GameObject and all its descendants. Set to false to
    //     check the GameObject.
    //
    // Returns:
    //     When includeDescendants is true, this method returns true when the GameObject
    //     and all its descendants have picking disabled. When includeDescendants is false,
    //     this method returns true when the GameObject has picking disabled.
    public bool IsPickingDisabled(GameObject gameObject, bool includeDescendants = false)
    {
        if (includeDescendants)
        {
            return SceneVisibilityState.IsHierarchyPickingDisabled(gameObject);
        }

        return SceneVisibilityState.IsGameObjectPickingDisabled(gameObject);
    }

    internal bool IsSelectable(GameObject go)
    {
        return IsSelectable(go, includeDescendants: false);
    }

    internal bool IsSelectable(GameObject go, bool includeDescendants)
    {
        return !IsPickingDisabled(go, includeDescendants) && !IsHidden(go, includeDescendants);
    }

    public bool IsPickingDisabled(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        scene.GetRootGameObjects(m_RootBuffer);
        foreach (GameObject item in m_RootBuffer)
        {
            if (!SceneVisibilityState.IsHierarchyPickingDisabled(item))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsIgnoredBySceneVisibility(GameObject go)
    {
        HideFlags hideFlags = HideFlags.HideInHierarchy;
        return (go.hideFlags & hideFlags) != 0;
    }

    //
    // Summary:
    //     Checks whether root GameObjects, and all their descendants, are hidden in a Scene.
    //
    //
    // Parameters:
    //   scene:
    //     Scene to check.
    //
    // Returns:
    //     Returns true if all root GameObjects of the Scene and all their descendants are
    //     hidden.
    public bool AreAllDescendantsHidden(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        if (scene.rootCount == 0)
        {
            return false;
        }

        scene.GetRootGameObjects(m_RootBuffer);
        foreach (GameObject item in m_RootBuffer)
        {
            if (IsIgnoredBySceneVisibility(item) || SceneVisibilityState.IsHierarchyHidden(item))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    //
    // Summary:
    //     Checks whether all the descendants of a GameObject have picking disabled.
    //
    // Parameters:
    //   scene:
    //     Scene to check.
    //
    // Returns:
    //     Returns true if all descendants have picking disabled.
    public bool IsPickingDisabledOnAllDescendants(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        if (scene.rootCount == 0)
        {
            return false;
        }

        scene.GetRootGameObjects(m_RootBuffer);
        foreach (GameObject item in m_RootBuffer)
        {
            if (IsIgnoredBySceneVisibility(item) || SceneVisibilityState.IsHierarchyPickingDisabled(item))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    //
    // Summary:
    //     Checks whether any descendants are hidden.
    //
    // Parameters:
    //   scene:
    //     Scene to check.
    //
    // Returns:
    //     Returns true when at least one hidden descendant is found.
    public bool AreAnyDescendantsHidden(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        return SceneVisibilityState.HasHiddenGameObjects(scene);
    }

    //
    // Summary:
    //     Checks whether any descendants have picking disabled.
    //
    // Parameters:
    //   scene:
    //     Scene to check.
    //
    // Returns:
    //     Returns true when at least one descendant with picking disabled is found.
    public bool IsPickingDisabledOnAnyDescendant(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded)
        {
            return false;
        }

        return SceneVisibilityState.ContainsGameObjectsWithPickingDisabled(scene);
    }

    internal SceneVisState GetSceneVisibilityState(Scene scene)
    {
        if (AreAllDescendantsHidden(scene))
        {
            return SceneVisState.AllHidden;
        }

        if (AreAnyDescendantsHidden(scene))
        {
            return SceneVisState.Mixed;
        }

        return SceneVisState.AllVisible;
    }

    internal ScenePickingState GetScenePickingState(Scene scene)
    {
        if (IsPickingDisabledOnAllDescendants(scene))
        {
            return ScenePickingState.PickingDisabledAll;
        }

        if (IsPickingDisabledOnAnyDescendant(scene))
        {
            return ScenePickingState.Mixed;
        }

        return ScenePickingState.PickingEnabledAll;
    }

    //
    // Summary:
    //     Shows a GameObject, or an array of GameObjects, and its descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to show.
    //
    //   gameObjects:
    //     Array of GameObjects to show.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void Show(GameObject[] gameObjects, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Show GameObjects");
        SceneVisibilityState.SetGameObjectsHidden(gameObjects, isHidden: false, includeDescendants);
    }

    //
    // Summary:
    //     Hides a GameObject, or an Array of GameObjects, and their descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to hide.
    //
    //   gameObjects:
    //     Array of GameObjects to hide.
    //
    //   includeDescendants:
    //     Whether to also hide descendants.
    public void Hide(GameObject[] gameObjects, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Hide GameObjects");
        SceneVisibilityState.SetGameObjectsHidden(gameObjects, isHidden: true, includeDescendants);
    }

    //
    // Summary:
    //     Disables picking on a GameObject, or an Array of GameObjects, and their descendants.
    //
    //
    // Parameters:
    //   gameObject:
    //     GameObject on which to disable picking.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    //
    //   gameObjects:
    //     Array of GameObjects on which to disable picking.
    public void DisablePicking(GameObject[] gameObjects, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Disable Picking GameObjects");
        SceneVisibilityState.SetGameObjectsPickingDisabled(gameObjects, pickingDisabled: true, includeDescendants);
    }

    //
    // Summary:
    //     Enables picking on a GameObject, or an array of GameObjects, and its descendants.
    //
    //
    // Parameters:
    //   includeDescendants:
    //     Whether to include descendants.
    //
    //   gameObject:
    //     GameObject on which to enable picking.
    //
    //   gameObjects:
    //     Array of GameObjects on which to enable picking.
    public void EnablePicking(GameObject[] gameObjects, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Enable Picking GameObjects");
        SceneVisibilityState.SetGameObjectsPickingDisabled(gameObjects, pickingDisabled: false, includeDescendants);
    }

    //
    // Summary:
    //     Isolates a GameObject and its descendants.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to isolate.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void Isolate(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Isolate GameObject");
        IsolateCurrentStage();
        HideAllNoUndo();
        SceneVisibilityState.SetGameObjectHidden(gameObject, isHidden: false, includeDescendants);
    }

    //
    // Summary:
    //     Isolates an Array of GameObjects and their descendants.
    //
    // Parameters:
    //   gameObjects:
    //     Array of GameObjects to isolate.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void Isolate(GameObject[] gameObjects, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Isolate GameObjects");
        IsolateCurrentStage();
        HideAllNoUndo();
        SceneVisibilityState.SetGameObjectsHidden(gameObjects, isHidden: false, includeDescendants);
    }

    private void VisibilityChanged()
    {
        SceneVisibilityManager.visibilityChanged?.Invoke();
    }

    private void PickableContentChanged()
    {
        SceneVisibilityManager.pickingChanged?.Invoke();
    }

    //
    // Summary:
    //     Toggles the visible state of a GameObject.
    //
    // Parameters:
    //   gameObject:
    //     GameObject on which to toggle visibility.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void ToggleVisibility(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Visibility");
        SceneVisibilityState.SetGameObjectHidden(gameObject, !SceneVisibilityState.IsGameObjectHidden(gameObject), includeDescendants);
    }

    //
    // Summary:
    //     Toggles the picking ability of a GameObject.
    //
    // Parameters:
    //   gameObject:
    //     GameObject on which to toggle picking ability.
    //
    //   includeDescendants:
    //     Whether to include descendants.
    public void TogglePicking(GameObject gameObject, bool includeDescendants)
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Picking");
        SceneVisibilityState.SetGameObjectPickingDisabled(gameObject, !SceneVisibilityState.IsGameObjectPickingDisabled(gameObject), includeDescendants);
    }

    //
    // Summary:
    //     Checks whether all the descendants of a GameObject are hidden.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to check.
    //
    // Returns:
    //     Returns true if all descendants are hidden.
    public bool AreAllDescendantsHidden(GameObject gameObject)
    {
        return SceneVisibilityState.AreAllChildrenHidden(gameObject);
    }

    //
    // Summary:
    //     Checks whether all the descendants are visible.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to check.
    //
    // Returns:
    //     Returns true if all descendants of the GameObject are visible.
    public bool AreAllDescendantsVisible(GameObject gameObject)
    {
        return SceneVisibilityState.AreAllChildrenVisible(gameObject);
    }

    //
    // Summary:
    //     Checks whether root GameObjects, and all their descendants, have picking disabled
    //     in a scene.
    //
    // Parameters:
    //   gameObject:
    //     GameObject to check.
    //
    // Returns:
    //     Returns true if all root GameObjects of the Scene and all their descendants have
    //     picking disabled.
    public bool IsPickingDisabledOnAllDescendants(GameObject gameObject)
    {
        return SceneVisibilityState.IsPickingDisabledOnAllChildren(gameObject);
    }

    //
    // Summary:
    //     Checks whether all the descendants are pickable.
    //
    // Parameters:
    //   gameObject:
    //     GameObject on which to do the check.
    //
    // Returns:
    //     Returns true if all descendants of the GameObject are pickable.
    public bool IsPickingEnabledOnAllDescendants(GameObject gameObject)
    {
        return SceneVisibilityState.IsPickingEnabledOnAllChildren(gameObject);
    }

    //
    // Summary:
    //     Checks whether the current stage is in Isolation mode.
    //
    // Returns:
    //     Returns true if current stage is in Isolation mode. Otherwise, returns false.
    public bool IsCurrentStageIsolated()
    {
        return SceneVisibilityState.isolation;
    }

    private void IsolateCurrentStage()
    {
        SceneVisibilityState.isolation = true;
        SceneVisibilityManager.currentStageIsIsolated?.Invoke(obj: true);
    }

    //
    // Summary:
    //     Exits Isolation Mode.
    public void ExitIsolation()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Exit Isolation");
        RevertIsolationCurrentStage();
    }

    private static void RevertIsolationCurrentStage()
    {
        SceneVisibilityState.isolation = false;
        SceneVisibilityManager.currentStageIsIsolated?.Invoke(obj: false);
    }

    [Shortcut("Scene Visibility/Toggle Selection Visibility", null)]
    private static void ToggleSelectionVisibility()
    {
        bool flag = true;
        GameObject[] gameObjects = Selection.gameObjects;
        foreach (GameObject gameObject in gameObjects)
        {
            if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsHidden(gameObject))
            {
                break;
            }

            flag = false;
        }

        ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes.Clear();
        SceneHierarchyWindow lastInteractedHierarchyWindow = SceneHierarchyWindow.lastInteractedHierarchyWindow;
        if (flag && (bool)lastInteractedHierarchyWindow)
        {
            lastInteractedHierarchyWindow.GetSelectedScenes(ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes);
            foreach (Scene selectedScene in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
            {
                if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsHidden(selectedScene))
                {
                    break;
                }

                flag = false;
            }
        }

        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Selection Visibility");
        SceneVisibilityState.SetGameObjectsHidden(Selection.gameObjects, flag, includeChildren: false);
        foreach (Scene selectedScene2 in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
        {
            if (flag)
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.Hide(selectedScene2);
            }
            else
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.Show(selectedScene2);
            }
        }
    }

    [Shortcut("Scene Visibility/Toggle Selection And Descendants Visibility", typeof(ShortcutContext), KeyCode.H, ShortcutModifiers.None)]
    private static void ToggleSelectionAndDescendantsVisibility()
    {
        bool flag = true;
        GameObject[] gameObjects = Selection.gameObjects;
        foreach (GameObject gameObject in gameObjects)
        {
            if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsHidden(gameObject))
            {
                break;
            }

            flag = false;
        }

        ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes.Clear();
        SceneHierarchyWindow lastInteractedHierarchyWindow = SceneHierarchyWindow.lastInteractedHierarchyWindow;
        if (flag && (bool)lastInteractedHierarchyWindow)
        {
            lastInteractedHierarchyWindow.GetSelectedScenes(ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes);
            foreach (Scene selectedScene in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
            {
                if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsHidden(selectedScene))
                {
                    break;
                }

                flag = false;
            }
        }

        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Selection And Descendants Visibility");
        SceneVisibilityState.SetGameObjectsHidden(Selection.gameObjects, flag, includeChildren: true);
        foreach (Scene selectedScene2 in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
        {
            if (flag)
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.Hide(selectedScene2);
            }
            else
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.Show(selectedScene2);
            }
        }
    }

    [Shortcut("Scene Picking/Toggle Picking On Selection And Descendants", typeof(ShortcutContext), KeyCode.L, ShortcutModifiers.None)]
    private static void ToggleSelectionAndDescendantsPicking()
    {
        ToggleSelectionPicking(includeChildren: true);
    }

    [Shortcut("Scene Picking/Toggle Picking On Selection", null)]
    internal static void ToggleSelectionPickable()
    {
        ToggleSelectionPicking(includeChildren: false);
    }

    private static void ToggleSelectionPicking(bool includeChildren)
    {
        bool flag = true;
        GameObject[] gameObjects = Selection.gameObjects;
        foreach (GameObject gameObject in gameObjects)
        {
            if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsPickingDisabled(gameObject))
            {
                break;
            }

            flag = false;
        }

        ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes.Clear();
        SceneHierarchyWindow lastInteractedHierarchyWindow = SceneHierarchyWindow.lastInteractedHierarchyWindow;
        if (flag && (bool)lastInteractedHierarchyWindow)
        {
            lastInteractedHierarchyWindow.GetSelectedScenes(ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes);
            foreach (Scene selectedScene in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
            {
                if (!ScriptableSingleton<SceneVisibilityManager>.instance.IsPickingDisabled(selectedScene))
                {
                    break;
                }

                flag = false;
            }
        }

        string text = (includeChildren ? "Toggle Selection And Descendants Picking" : "Toggle Selection Pickable");
        Undo.RecordObject(SceneVisibilityState.GetInstance(), text);
        SceneVisibilityState.SetGameObjectsPickingDisabled(Selection.gameObjects, flag, includeChildren);
        foreach (Scene selectedScene2 in ScriptableSingleton<SceneVisibilityManager>.instance.m_SelectedScenes)
        {
            if (flag)
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.DisablePicking(selectedScene2);
            }
            else
            {
                ScriptableSingleton<SceneVisibilityManager>.instance.EnablePicking(selectedScene2);
            }
        }

        if ((bool)lastInteractedHierarchyWindow)
        {
            EditorApplication.RepaintHierarchyWindow();
        }
    }

    [Shortcut("Scene Visibility/Exit Isolation", null)]
    private static void ExitIsolationShortcut()
    {
        ScriptableSingleton<SceneVisibilityManager>.instance.ExitIsolation();
    }

    [Shortcut("Scene Visibility/Toggle Isolation On Selection And Descendants", typeof(ShortcutContext), KeyCode.H, ShortcutModifiers.Shift)]
    private static void ToggleIsolateSelectionAndDescendantsShortcut()
    {
        ScriptableSingleton<SceneVisibilityManager>.instance.ToggleIsolateSelectionAndDescendants();
    }

    internal void ToggleIsolateSelectionAndDescendants()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Isolation on Selection And Children");
        if (!IsCurrentStageIsolated())
        {
            IsolateCurrentStage();
            HideAllNoUndo();
            if (Selection.gameObjects.Length != 0)
            {
                SceneVisibilityState.SetGameObjectsHidden(Selection.gameObjects, isHidden: false, includeChildren: true);
            }

            m_SelectedScenes.Clear();
            SceneHierarchyWindow lastInteractedHierarchyWindow = SceneHierarchyWindow.lastInteractedHierarchyWindow;
            if (!lastInteractedHierarchyWindow)
            {
                return;
            }

            lastInteractedHierarchyWindow.GetSelectedScenes(m_SelectedScenes);
            {
                foreach (Scene selectedScene in m_SelectedScenes)
                {
                    Show(selectedScene);
                }

                return;
            }
        }

        RevertIsolationCurrentStage();
    }

    [Shortcut("Scene Visibility/Toggle Isolation on Selection", null)]
    private static void ToggleIsolateSelectionShortcut()
    {
        ScriptableSingleton<SceneVisibilityManager>.instance.ToggleIsolateSelection();
    }

    internal void ToggleIsolateSelection()
    {
        Undo.RecordObject(SceneVisibilityState.GetInstance(), "Toggle Isolation on Selection");
        if (!IsCurrentStageIsolated())
        {
            IsolateCurrentStage();
            HideAllNoUndo();
            if (Selection.gameObjects.Length != 0)
            {
                SceneVisibilityState.SetGameObjectsHidden(Selection.gameObjects, isHidden: false, includeChildren: false);
            }

            m_SelectedScenes.Clear();
            SceneHierarchyWindow lastInteractedHierarchyWindow = SceneHierarchyWindow.lastInteractedHierarchyWindow;
            if (!lastInteractedHierarchyWindow)
            {
                return;
            }

            lastInteractedHierarchyWindow.GetSelectedScenes(m_SelectedScenes);
            {
                foreach (Scene selectedScene in m_SelectedScenes)
                {
                    Show(selectedScene);
                }

                return;
            }
        }

        RevertIsolationCurrentStage();
    }

    internal void ToggleScene(Scene scene, SceneVisState visibilityState)
    {
        if (visibilityState == SceneVisState.AllVisible || visibilityState == SceneVisState.Mixed)
        {
            Hide(scene);
        }
        else
        {
            Show(scene);
        }
    }
}
