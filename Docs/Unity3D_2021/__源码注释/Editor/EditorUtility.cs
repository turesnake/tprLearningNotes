#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;

namespace UnityEditor
{
    //
    // 摘要:
    //     Editor utility functions.
    [NativeHeaderAttribute("Runtime/Shaders/ShaderImpl/ShaderUtilities.h")]
    [NativeHeaderAttribute("Editor/Mono/EditorUtility.bindings.h")]
    [NativeHeaderAttribute("Editor/Mono/MonoEditorUtility.h")]
    public class EditorUtility
    {
        public EditorUtility();

        public static bool audioMasterMute { get; set; }
        //
        // 摘要:
        //     True if there are any compilation error messages in the log.
        public static bool scriptCompilationFailed { get; }

        [Obsolete("Use BuildPipeline.BuildAssetBundle instead")]
        public static bool BuildResourceFile(UnityEngine.Object[] selection, string pathName);
        //
        // 摘要:
        //     Clears the default parent GameObject from either a specific Scene or the active
        //     Scene.
        //
        // 参数:
        //   scene:
        //     Specify a Scene to clear the default parent object for a specific Scene. If a
        //     Scene is not specified, this method clears the default parent object for the
        //     active Scene.
        public static void ClearDefaultParentObject();
        //
        // 摘要:
        //     Clears the default parent GameObject from either a specific Scene or the active
        //     Scene.
        //
        // 参数:
        //   scene:
        //     Specify a Scene to clear the default parent object for a specific Scene. If a
        //     Scene is not specified, this method clears the default parent object for the
        //     active Scene.
        public static void ClearDefaultParentObject(Scene scene);
        //
        // 摘要:
        //     Clear target's dirty flag.
        //
        // 参数:
        //   target:
        public static void ClearDirty([NotNullAttribute("ArgumentNullException")] UnityEngine.Object target);
        //
        // 摘要:
        //     Removes the progress bar.
        [FreeFunctionAttribute("ClearProgressbarLegacy")]
        public static void ClearProgressBar();
        //
        // 摘要:
        //     Collect all objects in the hierarchy rooted at each of the given objects.
        //
        // 参数:
        //   roots:
        //     Array of objects where the search will start.
        //
        // 返回结果:
        //     Array of objects heirarchically attached to the search array.
        public static UnityEngine.Object[] CollectDeepHierarchy(UnityEngine.Object[] roots);
        //
        // 摘要:
        //     Calculates and returns a list of all assets the assets listed in roots depend
        //     on.
        //
        // 参数:
        //   roots:
        [NativeThrowsAttribute]
        public static UnityEngine.Object[] CollectDependencies(UnityEngine.Object[] roots);
        [Obsolete("Use UnityEditor.Compilation.AssemblyBuilder instead", true)]
        public static string[] CompileCSharp(string[] scripts, string[] references, string[] defines, string outputAssembly);
        //
        // 摘要:
        //     Compress a cubemap texture.
        //
        // 参数:
        //   texture:
        //
        //   format:
        //
        //   quality:
        public static void CompressCubemapTexture(Cubemap texture, TextureFormat format, TextureCompressionQuality quality);
        //
        // 摘要:
        //     Compress a cubemap texture.
        //
        // 参数:
        //   texture:
        //
        //   format:
        //
        //   quality:
        public static void CompressCubemapTexture([NotNullAttribute("ArgumentNullException")] Cubemap texture, TextureFormat format, int quality);
        //
        // 摘要:
        //     Compress a texture.
        //
        // 参数:
        //   texture:
        //
        //   format:
        //
        //   quality:
        public static void CompressTexture(Texture2D texture, TextureFormat format, TextureCompressionQuality quality);
        //
        // 摘要:
        //     Compress a texture.
        //
        // 参数:
        //   texture:
        //
        //   format:
        //
        //   quality:
        public static void CompressTexture([NotNullAttribute("ArgumentNullException")] Texture2D texture, TextureFormat format, int quality);
        //
        // 摘要:
        //     Copy all settings of a Unity Object.
        //
        // 参数:
        //   source:
        //
        //   dest:
        [FreeFunctionAttribute("CopySerialized")]
        public static void CopySerialized([NotNullAttribute("NullExceptionObject")] UnityEngine.Object source, [NotNullAttribute("NullExceptionObject")] UnityEngine.Object dest);
        //
        // 摘要:
        //     Copy all settings of a Unity Object to a second Object if they differ.
        //
        // 参数:
        //   source:
        //
        //   dest:
        public static void CopySerializedIfDifferent(UnityEngine.Object source, UnityEngine.Object dest);
        //
        // 摘要:
        //     Copies the serializable fields from one managed object to another.
        //
        // 参数:
        //   source:
        //     The object to copy data from.
        //
        //   dest:
        //     The object to copy data to.
        [FreeFunctionAttribute("CopyScriptSerialized")]
        public static void CopySerializedManagedFieldsOnly([NotNullAttribute("ArgumentNullException")] object source, [NotNullAttribute("ArgumentNullException")] object dest);
        [Obsolete("The concept of creating a completely empty Prefab has been discontinued. You can however use PrefabUtility.SaveAsPrefabAsset with an empty GameObject.", false)]
        public static UnityEngine.Object CreateEmptyPrefab(string path);
        //
        // 摘要:
        //     Creates a game object with HideFlags and specified components.
        //
        // 参数:
        //   name:
        //
        //   flags:
        //
        //   components:
        public static GameObject CreateGameObjectWithHideFlags(string name, HideFlags flags, params Type[] components);
        //
        // 摘要:
        //     Displays or updates a progress bar that has a cancel button.
        //
        // 参数:
        //   title:
        //
        //   info:
        //
        //   progress:
        public static bool DisplayCancelableProgressBar(string title, string info, float progress);
        public static void DisplayCustomMenu(Rect position, GUIContent[] options, Func<int, bool> checkEnabled, int selected, SelectMenuItemFunction callback, object userData, bool showHotkey = false);
        public static void DisplayCustomMenu(Rect position, GUIContent[] options, int selected, SelectMenuItemFunction callback, object userData, bool showHotkey);
        public static void DisplayCustomMenu(Rect position, GUIContent[] options, int selected, SelectMenuItemFunction callback, object userData);
        public static void DisplayCustomMenuWithSeparators(Rect position, string[] options, bool[] enabled, bool[] separator, int[] selected, SelectMenuItemFunction callback, object userData);
        
        
        //
        // 摘要:
        //     This method displays a modal dialog.
        //
        // 参数:
        //   title:
        //     The title of the message box.
        //
        //   message:
        //     The text of the message.
        //
        //   ok:
        //     Label displayed on the OK dialog button.
        //
        //   cancel:
        //     Label displayed on the Cancel dialog button.
        //
        // 返回结果:
        //     Returns true if the user clicks the OK button. Returns false otherwise.
        [FreeFunctionAttribute("DisplayDialog")]
        public static bool DisplayDialog(string title, string message, string ok, [UnityEngine.Internal.DefaultValue("\"\"")] string cancel);
        //
        // 摘要:
        //     This method displays a modal dialog that lets the user opt-out of being shown
        //     the current dialog box again.
        //
        // 参数:
        //   title:
        //     The title of the message box.
        //
        //   message:
        //     The text of the message.
        //
        //   ok:
        //     Label displayed on the OK dialog button.
        //
        //   cancel:
        //     Label displayed on the Cancel dialog button.
        //
        //   dialogOptOutDecisionType:
        //     The type of opt-out decision a user can make.
        //
        //   dialogOptOutDecisionStorageKey:
        //     The unique key setting to store the decision under.
        //
        // 返回结果:
        //     true if the user clicks the ok button, or previously opted out. Returns false
        //     if the user cancels or closes the dialog without making a decision.
        public static bool DisplayDialog(string title, string message, string ok, DialogOptOutDecisionType dialogOptOutDecisionType, string dialogOptOutDecisionStorageKey);
        //
        // 摘要:
        //     This method displays a modal dialog.
        //
        // 参数:
        //   title:
        //     The title of the message box.
        //
        //   message:
        //     The text of the message.
        //
        //   ok:
        //     Label displayed on the OK dialog button.
        //
        //   cancel:
        //     Label displayed on the Cancel dialog button.
        //
        // 返回结果:
        //     Returns true if the user clicks the OK button. Returns false otherwise.
        [ExcludeFromDocs]
        public static bool DisplayDialog(string title, string message, string ok);
        //
        // 摘要:
        //     This method displays a modal dialog that lets the user opt-out of being shown
        //     the current dialog box again.
        //
        // 参数:
        //   title:
        //     The title of the message box.
        //
        //   message:
        //     The text of the message.
        //
        //   ok:
        //     Label displayed on the OK dialog button.
        //
        //   cancel:
        //     Label displayed on the Cancel dialog button.
        //
        //   dialogOptOutDecisionType:
        //     The type of opt-out decision a user can make.
        //
        //   dialogOptOutDecisionStorageKey:
        //     The unique key setting to store the decision under.
        //
        // 返回结果:
        //     true if the user clicks the ok button, or previously opted out. Returns false
        //     if the user cancels or closes the dialog without making a decision.
        public static bool DisplayDialog(string title, string message, string ok, [UnityEngine.Internal.DefaultValue("\"\"")] string cancel, DialogOptOutDecisionType dialogOptOutDecisionType, string dialogOptOutDecisionStorageKey);
        //
        // 摘要:
        //     Displays a modal dialog with three buttons.
        //
        // 参数:
        //   title:
        //     Title for dialog.
        //
        //   message:
        //     Purpose for the dialog.
        //
        //   ok:
        //     Dialog function chosen.
        //
        //   cancel:
        //     Close dialog with no operation.
        //
        //   alt:
        //     Choose alternative dialog purpose.
        //
        // 返回结果:
        //     Returns the id of the chosen button. The ids are 0, 1 or 2 corresponding to the
        //     ok, cancel and alt buttons respectively.
        [FreeFunctionAttribute("DisplayDialogComplex")]
        public static int DisplayDialogComplex(string title, string message, string ok, string cancel, string alt);
        //
        // 摘要:
        //     Displays a popup menu.
        //
        // 参数:
        //   position:
        //
        //   menuItemPath:
        //
        //   command:
        public static void DisplayPopupMenu(Rect position, string menuItemPath, MenuCommand command);
        //
        // 摘要:
        //     Displays or updates a progress bar.
        //
        // 参数:
        //   title:
        //
        //   info:
        //
        //   progress:
        [FreeFunctionAttribute("DisplayProgressbarLegacy")]
        public static void DisplayProgressBar(string title, string info, float progress);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ExtractOggFile has no effect anymore", false)]
        public static bool ExtractOggFile(UnityEngine.Object obj, string path);
        [FreeFunctionAttribute("FindAssetWithKlass", ThrowsException = true)]
        [Obsolete("Use AssetDatabase.LoadAssetAtPath", false)]
        public static UnityEngine.Object FindAsset(string path, Type type);
        [Obsolete("Use PrefabUtility.GetOutermostPrefabInstanceRoot if source is a Prefab instance or source.transform.root.gameObject if source is a Prefab Asset object.", false)]
        public static GameObject FindPrefabRoot(GameObject source);
        //
        // 摘要:
        //     Brings the project window to the front and focuses it.
        [RequiredByNativeCodeAttribute]
        public static void FocusProjectWindow();
        [FreeFunctionAttribute("FormatBytes")]
        public static string FormatBytes(long bytes);
        //
        // 摘要:
        //     Returns a text for a number of bytes.
        //
        // 参数:
        //   bytes:
        public static string FormatBytes(int bytes);
        [Obsolete("Use AssetDatabase.GetAssetPath", false)]
        public static string GetAssetPath(UnityEngine.Object asset);
        //
        // 摘要:
        //     This method displays a modal dialog that lets the user opt-out of being shown
        //     the current dialog box again.
        //
        // 参数:
        //   dialogOptOutDecisionType:
        //     The type of opt-out decision a user can make.
        //
        //   dialogOptOutDecisionStorageKey:
        //     The unique key setting to store the decision under.
        //
        // 返回结果:
        //     true if the user previously opted out of seeing the dialog associated with dialogOptOutDecisionStorageKey.
        //     Returns false if the user did not yet opt out.
        public static bool GetDialogOptOutDecision(DialogOptOutDecisionType dialogOptOutDecisionType, string dialogOptOutDecisionStorageKey);
        //
        // 摘要:
        //     Returns an integer that indicates the number of times the specified object's
        //     serialized properties have changed.
        //
        // 参数:
        //   instanceID:
        //     The object's instance ID.
        //
        //   target:
        //     The object.
        [NativeMethodAttribute("GetDirtyIndex")]
        public static int GetDirtyCount(int instanceID);
        //
        // 摘要:
        //     Returns an integer that indicates the number of times the specified object's
        //     serialized properties have changed.
        //
        // 参数:
        //   instanceID:
        //     The object's instance ID.
        //
        //   target:
        //     The object.
        public static int GetDirtyCount(UnityEngine.Object target);
        //
        // 摘要:
        //     Is the object enabled (0 disabled, 1 enabled, -1 has no enabled button).
        //
        // 参数:
        //   target:
        [FreeFunctionAttribute("GetObjectEnabled")]
        public static int GetObjectEnabled(UnityEngine.Object target);
        [Obsolete("Use PrefabUtility.GetCorrespondingObjectFromSource.", false)]
        public static UnityEngine.Object GetPrefabParent(UnityEngine.Object source);
        [Obsolete("Use PrefabUtility.GetPrefabAssetType and PrefabUtility.GetPrefabInstanceStatus to get the full picture about Prefab types.", false)]
        public static PrefabType GetPrefabType(UnityEngine.Object target);
        //
        // 摘要:
        //     Translates an instance ID to a reference to an object.
        //
        // 参数:
        //   instanceID:
        public static UnityEngine.Object InstanceIDToObject(int instanceID);
        [Obsolete("Use PrefabUtility.InstantiatePrefab", false)]
        public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object target);
        [FreeFunctionAttribute("InvokeDiffTool")]
        public static string InvokeDiffTool(string leftTitle, string leftFile, string rightTitle, string rightFile, string ancestorTitle, string ancestorFile);
        //
        // 摘要:
        //     Gets a boolean value that indicates whether the specified object has changed
        //     since the last time it was saved.
        //
        // 参数:
        //   instanceID:
        //     The object's instance ID.
        //
        //   target:
        //     The object.
        //
        // 返回结果:
        //     True if the object has changed; otherwise false.
        public static bool IsDirty(UnityEngine.Object target);
        //
        // 摘要:
        //     Gets a boolean value that indicates whether the specified object has changed
        //     since the last time it was saved.
        //
        // 参数:
        //   instanceID:
        //     The object's instance ID.
        //
        //   target:
        //     The object.
        //
        // 返回结果:
        //     True if the object has changed; otherwise false.
        public static bool IsDirty(int instanceID);
        //
        // 摘要:
        //     Determines if an object is stored on disk.
        //
        // 参数:
        //   target:
        public static bool IsPersistent(UnityEngine.Object target);
        //
        // 摘要:
        //     Gets a boolean value. This value indicates whether your CPU is unable to execute
        //     Unity natively and is running an emulated version.
        [FreeFunctionAttribute("IsRunningUnderCPUEmulation", IsThreadSafe = true)]
        public static bool IsRunningUnderCPUEmulation();
        public static bool LoadWindowLayout(string path);
        //
        // 摘要:
        //     Human-like sorting.
        //
        // 参数:
        //   a:
        //
        //   b:
        public static int NaturalCompare(string a, string b);
        //
        // 摘要:
        //     Displays the "open file" dialog and returns the selected path name.
        //
        // 参数:
        //   title:
        //
        //   directory:
        //
        //   extension:
        public static string OpenFilePanel(string title, string directory, string extension);
        //
        // 摘要:
        //     Displays the "open file" dialog and returns the selected path name.
        //
        // 参数:
        //   title:
        //     Title for dialog.
        //
        //   directory:
        //     Default directory.
        //
        //   filters:
        //     File extensions in form { "Image files", "png,jpg,jpeg", "All files", "*" }.
        public static string OpenFilePanelWithFilters(string title, string directory, string[] filters);
        //
        // 摘要:
        //     Displays the "open folder" dialog and returns the selected path name.
        //
        // 参数:
        //   title:
        //
        //   folder:
        //
        //   defaultName:
        [FreeFunctionAttribute("RunOpenFolderPanel")]
        public static string OpenFolderPanel(string title, string folder, string defaultName);
        //
        // 摘要:
        //     Open properties editor for an Object.
        //
        // 参数:
        //   obj:
        //     The editor will should the properties of the Object.
        public static void OpenPropertyEditor(UnityEngine.Object obj);
        [FreeFunctionAttribute("OpenWithDefaultApp")]
        public static void OpenWithDefaultApp(string fileName);
        [Obsolete("Use PrefabUtility.RevertPrefabInstance.", false)]
        public static bool ReconnectToLastPrefab(GameObject go);
        [Obsolete("Use PrefabUtility.SaveAsPrefabAsset or PrefabUtility.SaveAsPrefabAssetAndConnect with a path instead.", false)]
        public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab);
        [Obsolete("Use PrefabUtility.SaveAsPrefabAsset with a path instead.", false)]
        public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab, ReplacePrefabOptions options);
        //
        // 摘要:
        //     The Unity Editor reloads script assemblies asynchronously on the next frame.
        //     This resets the state of all the scripts, but Unity does not compile any code
        //     that has changed since the previous compilation.
        [StaticAccessorAttribute("GetApplication()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public static void RequestScriptReload();
        [Obsolete("Use PrefabUtility.RevertObjectOverride.", false)]
        public static bool ResetToPrefabState(UnityEngine.Object source);
        [FreeFunctionAttribute("RevealInFinder")]
        public static void RevealInFinder(string path);
        //
        // 摘要:
        //     Displays the "save file" dialog and returns the selected path name.
        //
        // 参数:
        //   title:
        //
        //   directory:
        //
        //   defaultName:
        //
        //   extension:
        public static string SaveFilePanel(string title, string directory, string defaultName, string extension);
        public static string SaveFilePanelInProject(string title, string defaultName, string extension, string message, string path);
        //
        // 摘要:
        //     Displays the "save file" dialog in the Assets folder of the project and returns
        //     the selected path name.
        //
        // 参数:
        //   title:
        //
        //   defaultName:
        //
        //   extension:
        //
        //   message:
        public static string SaveFilePanelInProject(string title, string defaultName, string extension, string message);
        //
        // 摘要:
        //     Displays the "save folder" dialog and returns the selected path name.
        //
        // 参数:
        //   title:
        //
        //   folder:
        //
        //   defaultName:
        [FreeFunctionAttribute("RunSaveFolderPanel")]
        public static string SaveFolderPanel(string title, string folder, string defaultName);
        //
        // 摘要:
        //     Sets this camera to allow animation of materials in the Editor.
        //
        // 参数:
        //   camera:
        //
        //   animate:
        public static void SetCameraAnimateMaterials([NotNullAttribute("ArgumentNullException")] Camera camera, bool animate);
        //
        // 摘要:
        //     Sets the global time for this camera to use when rendering.
        //
        // 参数:
        //   camera:
        //
        //   time:
        public static void SetCameraAnimateMaterialsTime([NotNullAttribute("ArgumentNullException")] Camera camera, float time);
        //
        // 摘要:
        //     Set custom diff tool settings.
        //
        // 参数:
        //   path:
        //     Diff tool path.
        //
        //   twoWayDiff:
        //     Two - way diff command line.
        //
        //   threeWayDiff:
        //     Three - way diff command line.
        //
        //   mergeCommand:
        //     Merge command line.
        //
        //   forceEnableCustomTool:
        //     Sets Custom Tool as current active Revision Control Diff/Merge tool.
        public static void SetCustomDiffTool(string path, string twoWayDiff, string threeWayDiff, string mergeCommand, bool forceEnableCustomTool = false);
        //
        // 摘要:
        //     Sets the default parent object for the active Scene.
        //
        // 参数:
        //   defaultParentObject:
        //     The GameObject to set as the default parent object.
        public static void SetDefaultParentObject(GameObject defaultParentObject);
        //
        // 摘要:
        //     This method displays a modal dialog that lets the user opt-out of being shown
        //     the current dialog box again.
        //
        // 参数:
        //   dialogOptOutDecisionType:
        //     The type of opt-out decision a user can make.
        //
        //   dialogOptOutDecisionStorageKey:
        //     The unique key setting to store the decision under.
        //
        //   optOutDecision:
        //     The unique key setting to store the decision under.
        public static void SetDialogOptOutDecision(DialogOptOutDecisionType dialogOptOutDecisionType, string dialogOptOutDecisionStorageKey, bool optOutDecision);
        //
        // 摘要:
        //     Marks target object as dirty.
        //
        // 参数:
        //   target:
        //     The object to mark as dirty.
        [FreeFunctionAttribute("EditorUtility::SetDirtyObjectOrScene")]
        public static void SetDirty([NotNullAttribute("ArgumentNullException")] UnityEngine.Object target);
        //
        // 摘要:
        //     Set the enabled state of the object.
        //
        // 参数:
        //   target:
        //
        //   enabled:
        [FreeFunctionAttribute("SetObjectEnabled")]
        public static void SetObjectEnabled(UnityEngine.Object target, bool enabled);
        //
        // 摘要:
        //     Set the Scene View selected display mode for this Renderer.
        //
        // 参数:
        //   renderer:
        //
        //   renderState:
        public static void SetSelectedRenderState(Renderer renderer, EditorSelectedRenderState renderState);
        //
        // 摘要:
        //     Sets whether the selected Renderer's wireframe will be hidden when the GameObject
        //     it is attached to is selected.
        //
        // 参数:
        //   renderer:
        //
        //   enabled:
        [Obsolete("Use EditorUtility.SetSelectedRenderState", false)]
        public static void SetSelectedWireframeHidden(Renderer renderer, bool enabled);
        [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead", false)]
        public static void UnloadUnusedAssets();
        [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead", false)]
        public static void UnloadUnusedAssetsIgnoreManagedReferences();
        //
        // 摘要:
        //     Unloads assets that are not used.
        //
        // 参数:
        //   ignoreReferencesFromScript:
        //     When true delete assets even if linked in scripts.
        public static void UnloadUnusedAssetsImmediate();
        public static void UnloadUnusedAssetsImmediate(bool includeMonoReferencesAsRoots);
        //
        // 摘要:
        //     Updates the global shader properties to use when rendering.
        //
        // 参数:
        //   time:
        //     Time to use. -1 to disable.
        [FreeFunctionAttribute("ShaderLab::UpdateGlobalShaderProperties")]
        public static void UpdateGlobalShaderProperties(float time);
        [FreeFunctionAttribute("WarnPrefab")]
        public static bool WarnPrefab(UnityEngine.Object target, string title, string warning, string okButton);

        public delegate void SelectMenuItemFunction(object userData, string[] options, int selected);
    }
}
