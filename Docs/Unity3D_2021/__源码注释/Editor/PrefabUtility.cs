#region Assembly UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEditor.Utils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Bindings;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace UnityEditor;

//
// Summary:
//     Utility class for any Prefab related operations.
[NativeHeader("Editor/Mono/Prefabs/PrefabUtility.bindings.h")]
[NativeHeader("Editor/Src/Prefabs/PrefabConnection.h")]
[NativeHeader("Editor/Src/Prefabs/PrefabInstance.h")]
[NativeHeader("Editor/Src/Prefabs/Prefab.h")]
[NativeHeader("Editor/Src/Prefabs/PrefabCreation.h")]
public sealed class PrefabUtility
{
    internal static class GameObjectStyles
    {
        public static Texture2D gameObjectIcon = EditorGUIUtility.LoadIconRequired("UnityEngine/GameObject Icon");

        public static Texture2D prefabIcon = EditorGUIUtility.LoadIconRequired("Prefab Icon");
    }

    //
    // Summary:
    //     Delegate for method that is called after Prefab instances in the Scene have been
    //     updated.
    //
    // Parameters:
    //   instance:
    public delegate void PrefabInstanceUpdated(GameObject instance);

    internal enum SaveVerb
    {
        Save,
        Apply
    }

    internal enum OverrideOperation
    {
        Apply,
        Revert
    }

    internal static class Analytics
    {
        public enum ApplyScope
        {
            PropertyOverride,
            ObjectOverride,
            AddedComponent,
            RemovedComponent,
            AddedGameObject,
            EntirePrefab
        }

        public enum ApplyTarget
        {
            OnlyTarget,
            Outermost,
            Innermost,
            Middle
        }

        [Serializable]
        private class EventData
        {
            public ApplyScope applyScope;

            public bool userAction;

            public string activeGUIView;

            public ApplyTarget applyTarget;

            public int applyTargetCount;
        }

        public static void SendApplyEvent(ApplyScope applyScope, UnityEngine.Object instance, string applyTargetPath, InteractionMode interactionMode, DateTime startTime, bool defaultOverrideComparedToSomeSources)
        {
            TimeSpan duration = DateTime.UtcNow.Subtract(startTime);
            EventData eventData = new EventData();
            eventData.applyScope = applyScope;
            eventData.userAction = interactionMode == InteractionMode.UserAction;
            eventData.activeGUIView = GUIView.GetTypeNameOfMostSpecificActiveView();
            List<UnityEngine.Object> applyTargets = GetApplyTargets(instance, defaultOverrideComparedToSomeSources);
            if (applyTargets == null)
            {
                eventData.applyTarget = ApplyTarget.OnlyTarget;
                eventData.applyTargetCount = 0;
            }
            else if (applyTargets.Count <= 1)
            {
                eventData.applyTarget = ApplyTarget.OnlyTarget;
                eventData.applyTargetCount = applyTargets.Count;
            }
            else
            {
                eventData.applyTargetCount = applyTargets.Count;
                int num = -1;
                for (int i = 0; i < applyTargets.Count; i++)
                {
                    if (AssetDatabase.GetAssetPath(applyTargets[i]) == applyTargetPath)
                    {
                        num = i;
                        break;
                    }
                }

                if (num == 0)
                {
                    eventData.applyTarget = ApplyTarget.Outermost;
                }
                else if (num == applyTargets.Count - 1)
                {
                    eventData.applyTarget = ApplyTarget.Innermost;
                }
                else
                {
                    eventData.applyTarget = ApplyTarget.Middle;
                }
            }

            UsabilityAnalytics.SendEvent("prefabApply", startTime, duration, isBlocking: true, eventData);
        }
    }

    //
    // Summary:
    //     Disposable helper struct for automatically loading the contents of a Prefab file,
    //     saving the contents and unloading the contents again.
    public struct EditPrefabContentsScope : IDisposable
    {
        //
        // Summary:
        //     File path of the Prefab asset.
        public readonly string assetPath;

        //
        // Summary:
        //     The root GameObject of the Prefab contents.
        public readonly GameObject prefabContentsRoot;

        //
        // Parameters:
        //   assetPath:
        //     File path of a Prefab Asset.
        public EditPrefabContentsScope(string assetPath)
        {
            this.assetPath = assetPath;
            prefabContentsRoot = LoadPrefabContents(assetPath);
        }

        public void Dispose()
        {
            SaveAsPrefabAsset(prefabContentsRoot, assetPath);
            UnloadPrefabContents(prefabContentsRoot);
        }
    }

    private const string kMaterialExtension = ".mat";

    internal const string kDummyPrefabStageRootObjectName = "Prefab Mode in Context";

    //
    // Summary:
    //     Unity calls this method automatically when Prefab instances in the Scene have
    //     been updated.
    public static PrefabInstanceUpdated prefabInstanceUpdated;

    private static DelegateWithPerformanceTracker<PrefabInstanceUpdated> m_PrefabInstanceUpdated = new DelegateWithPerformanceTracker<PrefabInstanceUpdated>("PrefabUtility.prefabInstanceUpdated");

    internal static event Action<GameObject, string> savingPrefab;

    internal static event Action prefabInstanceModificationCacheCleared;

    internal static event Action<GameObject> prefabInstanceUnpacked;

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern UnityEngine.Object GetCorrespondingObjectFromSource_internal([NotNull("ArgumentNullException")] UnityEngine.Object obj);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern UnityEngine.Object GetCorrespondingObjectFromSourceInAsset_internal([NotNull("ArgumentNullException")] UnityEngine.Object obj, [NotNull("ArgumentNullException")] UnityEngine.Object prefabAssetHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern UnityEngine.Object GetCorrespondingObjectFromSourceAtPath_internal([NotNull("ArgumentNullException")] UnityEngine.Object obj, string prefabAssetPath);

    //
    // Summary:
    //     Retrieves the enclosing Prefab for any object contained within.
    //
    // Parameters:
    //   targetObject:
    //     An object contained within a Prefab object.
    //
    // Returns:
    //     The Prefab the object is contained in.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [Obsolete("Use GetPrefabInstanceHandle for Prefab instances. Handles for Prefab Assets has been discontinued.")]
    public static extern UnityEngine.Object GetPrefabObject(UnityEngine.Object targetObject);

    //
    // Summary:
    //     Retrieves the PrefabInstance object for the outermost Prefab instance the provided
    //     object is part of.
    //
    // Parameters:
    //   instanceComponentOrGameObject:
    //     An object from the Prefab instance.
    //
    // Returns:
    //     The Prefab instance handle.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    public static extern UnityEngine.Object GetPrefabInstanceHandle(UnityEngine.Object instanceComponentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern UnityEngine.Object GetPrefabAssetHandle(UnityEngine.Object assetComponentOrGameObject);

    //
    // Summary:
    //     Determines whether the object Prefab asset contains any MonoBehaviours with missing
    //     SerializeReference types.
    //
    // Parameters:
    //   componentOrGameObject:
    //     An object which is part of a Prefab asset.
    //
    //   assetComponentOrGameObject:
    //
    // Returns:
    //     Returns true if there are missing SerializeReference types directly within a
    //     Prefab asset excluding nested Prefab.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [NativeThrows]
    public static extern bool HasManagedReferencesWithMissingTypes(UnityEngine.Object assetComponentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern GameObject GetPrefabInstanceRootGameObject(UnityEngine.Object instanceComponentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern GameObject GetPrefabAssetRootGameObject(UnityEngine.Object assetComponentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern bool HasObjectOverride(UnityEngine.Object componentOrGameObject, bool includeDefaultOverrides = false);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern bool HasPrefabInstanceNonDefaultOverrides_CachedForUI_Internal(GameObject gameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern void ClearPrefabInstanceNonDefaultOverridesCache_Internal(GameObject gameObject);

    //
    // Summary:
    //     Extracts all modifications that are applied to the Prefab instance compared to
    //     the parent Prefab.
    //
    // Parameters:
    //   targetPrefab:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    public static extern PropertyModification[] GetPropertyModifications(UnityEngine.Object targetPrefab);

    //
    // Summary:
    //     Assigns all modifications that are applied to the Prefab instance compared to
    //     the parent Prefab.
    //
    // Parameters:
    //   targetPrefab:
    //
    //   modifications:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    public static extern void SetPropertyModifications(UnityEngine.Object targetPrefab, PropertyModification[] modifications);

    //
    // Summary:
    //     Returns true if the given Prefab instance has any overrides.
    //
    // Parameters:
    //   instanceRoot:
    //     The root GameObject of the Prefab instance to check.
    //
    //   includeDefaultOverrides:
    //     Set to true to consider default overrides as overrides too.
    //
    // Returns:
    //     Returns true if there are any overrides.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool HasPrefabInstanceAnyOverrides(GameObject instanceRoot, bool includeDefaultOverrides);

    //
    // Summary:
    //     Instantiate an asset that is referenced by a Prefab and use it on the Prefab
    //     instance.
    //
    // Parameters:
    //   targetObject:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeHeader("Editor/Src/Prefabs/AttachedPrefabAsset.h")]
    [FreeFunction]
    public static extern UnityEngine.Object InstantiateAttachedAsset([NotNull("NullExceptionObject")] UnityEngine.Object targetObject);

    //
    // Summary:
    //     Causes modifications made to the Prefab instance to be recorded.
    //
    // Parameters:
    //   targetObject:
    //     Object to process.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern void RecordPrefabInstancePropertyModifications([NotNull("NullExceptionObject")] UnityEngine.Object targetObject);

    //
    // Summary:
    //     Force re-merging all Prefab instances of this Prefab.
    //
    // Parameters:
    //   targetObject:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [NativeThrows]
    [Obsolete("MergeAllPrefabInstances is deprecated. Prefabs are merged automatically. There is no need to call this method.")]
    public static extern void MergeAllPrefabInstances(UnityEngine.Object targetObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [NativeThrows]
    private static extern void MergePrefabInstance_internal([NotNull("ArgumentNullException")] UnityEngine.Object gameObjectOrComponent);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [NativeThrows]
    private static extern GameObject[] FindAllInstancesOfPrefab_internal([NotNull("NullExceptionObject")] GameObject prefabRoot, int sceneHandle);

    //
    // Summary:
    //     Deprecated. As of 2018.3 this method does nothing.
    //
    // Parameters:
    //   targetObject:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    [Obsolete("The concept of disconnecting Prefab instances has been deprecated.")]
    public static extern void DisconnectPrefabInstance(UnityEngine.Object targetObject);

    //
    // Summary:
    //     This function will unpack the given Prefab instance using the behaviour specified
    //     by unpackMode.
    //
    // Parameters:
    //   instanceRoot:
    //     Root GameObject of the Prefab instance.
    //
    //   unpackMode:
    //     The unpack mode to use.
    //
    // Returns:
    //     Array of GameObjects representing roots of unpacked Prefab instances.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [NativeThrows]
    public static extern GameObject[] UnpackPrefabInstanceAndReturnNewOutermostRoots(GameObject instanceRoot, PrefabUnpackMode unpackMode);

    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static UnityEngine.Object InstantiatePrefab_internal(UnityEngine.Object target, Scene destinationScene, Transform parent)
    {
        return InstantiatePrefab_internal_Injected(target, ref destinationScene, parent);
    }

    //
    // Summary:
    //     Loads a Prefab Asset at a given path into a given preview Scene and returns the
    //     root GameObject of the Prefab.
    //
    // Parameters:
    //   scene:
    //     The Scene to load the contents into.
    //
    //   prefabPath:
    //     The path of the Prefab Asset to load the contents of.
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    public static void LoadPrefabContentsIntoPreviewScene(string prefabPath, Scene scene)
    {
        LoadPrefabContentsIntoPreviewScene_Injected(prefabPath, ref scene);
    }

    //
    // Summary:
    //     Connects the source Prefab to the game object.
    //
    // Parameters:
    //   go:
    //     The disconnected GameObject that you want to reconnect.
    //
    //   sourcePrefab:
    //     The source Prefab to connect to the GameObject.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [Obsolete("Use RevertPrefabInstance. Prefabs instances can no longer be connected to Prefab Assets they are not an instance of to begin with.")]
    [NativeThrows]
    public static extern GameObject ConnectGameObjectToPrefab([NotNull("ArgumentNullException")] GameObject go, [NotNull("ArgumentNullException")] GameObject sourcePrefab);

    //
    // Summary:
    //     Retrieves the topmost GameObject that has the same Prefab parent as target.
    //
    // Parameters:
    //   target:
    //     The GameObject to use in the search.
    //
    // Returns:
    //     The GameObject at the root of the Prefab.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    [Obsolete("FindRootGameObjectWithSameParentPrefab is deprecated, please use GetOutermostPrefabInstanceRoot instead.")]
    public static extern GameObject FindRootGameObjectWithSameParentPrefab([NotNull("NullExceptionObject")] GameObject target);

    //
    // Summary:
    //     Returns the root GameObject of the Prefab instance if that root Prefab instance
    //     is a parent of the Prefab.
    //
    // Parameters:
    //   target:
    //     GameObject to process.
    //
    // Returns:
    //     Return the root game object of the Prefab Asset.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("FindInstanceRootGameObject", IsFreeFunction = true)]
    [Obsolete("FindValidUploadPrefabInstanceRoot is deprecated, please use GetOutermostPrefabInstanceRoot instead.")]
    public static extern GameObject FindValidUploadPrefabInstanceRoot([NotNull("NullExceptionObject")] GameObject target);

    //
    // Summary:
    //     Connects the game object to the Prefab that it was last connected to.
    //
    // Parameters:
    //   go:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    [Obsolete("Use RevertPrefabInstance.")]
    public static extern bool ReconnectToLastPrefab([NotNull("NullExceptionObject")] GameObject go);

    //
    // Summary:
    //     Resets the properties of the component or game object to the parent Prefab state.
    //
    //
    // Parameters:
    //   obj:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    [Obsolete("Use RevertObjectOverride.")]
    public static extern bool ResetToPrefabState(UnityEngine.Object obj);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("PrefabUtilityBindings::ResetToPrefabState", IsFreeFunction = true)]
    private static extern bool RevertObjectOverride_Internal(UnityEngine.Object obj);

    //
    // Summary:
    //     Is this component added to a Prefab instance as an override?
    //
    // Parameters:
    //   component:
    //     The component to check.
    //
    // Returns:
    //     True if the component is an added component.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsAddedComponentOverride([NotNull("ArgumentNullException")] UnityEngine.Object component);

    //
    // Summary:
    //     Reverts all overrides on a Prefab instance.
    //
    // Parameters:
    //   instanceRoot:
    //     The root of the Prefab instance.
    //
    //   action:
    //     The interaction mode for this action.
    //
    //   go:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [Obsolete("Use the overload that takes an InteractionMode parameter.")]
    [FreeFunction]
    public static extern bool RevertPrefabInstance([NotNull("ArgumentNullException")] GameObject go);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("RevertPrefabInstance", IsFreeFunction = true)]
    private static extern bool RevertPrefabInstance_Internal([NotNull("ArgumentNullException")] GameObject go);

    //
    // Summary:
    //     Retrieves the root GameObject of the Prefab that the supplied GameObject is part
    //     of.
    //
    // Parameters:
    //   source:
    //     The object to check.
    //
    // Returns:
    //     The Prefab root.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    [Obsolete("Use GetOutermostPrefabInstanceRoot if source is a Prefab instance or source.transform.root.gameObject if source is a Prefab Asset object.")]
    public static extern GameObject FindPrefabRoot([NotNull("ArgumentNullException")] GameObject source);

    internal static GameObject CreateVariant(GameObject assetRoot, string path)
    {
        if (assetRoot == null)
        {
            throw new ArgumentNullException("The inputObject is null");
        }

        if (!IsPartOfPrefabAsset(assetRoot))
        {
            throw new ArgumentException("Given input object is not a prefab asset");
        }

        if (assetRoot.transform.root.gameObject != assetRoot)
        {
            throw new ArgumentException("Object to create variant from has to be a Prefab root");
        }

        if (path == null)
        {
            throw new ArgumentNullException("The path is null");
        }

        string assetPath = AssetDatabase.GetAssetPath(assetRoot);
        if (Paths.AreEqual(path, assetPath, ignoreCase: true))
        {
            throw new ArgumentException("Creating a variant of an object into the source file of the input object is not allowed");
        }

        if (!Paths.IsValidAssetPath(path, ".prefab"))
        {
            throw new ArgumentException("Given path is not valid: '" + path + "'");
        }

        return CreateVariant_Internal(assetRoot, path);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("CreateVariant", IsFreeFunction = true)]
    private static extern GameObject CreateVariant_Internal([NotNull("ArgumentNullException")] GameObject original, string path);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern GameObject SavePrefab_Internal([NotNull("ArgumentNullException")] GameObject root, string path, bool connectToInstance, out bool success);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern GameObject ApplyPrefabInstance_Internal([NotNull("ArgumentNullException")] GameObject root);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern GameObject SaveAsPrefabAsset_Internal([NotNull("ArgumentNullException")] GameObject root, string path, out bool success);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern GameObject SaveAsPrefabAssetAndConnect_Internal([NotNull("ArgumentNullException")] GameObject root, string path, out bool success);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern GameObject SavePrefabAsset_Internal([NotNull("ArgumentNullException")] GameObject root, out bool success);

    internal static void AddGameObjectsToPrefabAndConnect(GameObject[] gameObjects, UnityEngine.Object targetPrefab)
    {
        if (gameObjects == null)
        {
            throw new ArgumentNullException("gameObjects");
        }

        if (gameObjects.Length == 0)
        {
            throw new ArgumentException("gameObjects array is empty");
        }

        if (targetPrefab == null)
        {
            throw new ArgumentNullException("targetPrefab");
        }

        if (!IsPartOfPrefabAsset(targetPrefab))
        {
            throw new ArgumentException("Target Prefab has to be a Prefab Asset");
        }

        UnityEngine.Object @object = null;
        UnityEngine.Object prefabAssetHandle = GetPrefabAssetHandle(targetPrefab);
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == null)
            {
                throw new ArgumentException("GameObject in input 'gameObjects' array is null");
            }

            if (EditorUtility.IsPersistent(gameObject))
            {
                throw new ArgumentException("Game object is part of a prefab");
            }

            UnityEngine.Object parentPrefabInstance = GetParentPrefabInstance(gameObject);
            if (parentPrefabInstance == null)
            {
                throw new ArgumentException("GameObject is not (directly) parented under a target Prefab instance.");
            }

            if (@object == null)
            {
                @object = parentPrefabInstance;
                if (!IsPrefabInstanceObjectOf(gameObject.transform.parent, prefabAssetHandle))
                {
                    throw new ArgumentException("GameObject is not parented under a target Prefab instance.");
                }
            }
            else if (parentPrefabInstance != @object)
            {
                throw new ArgumentException("GameObjects must be parented under the same Prefab instance.");
            }

            if (IsPartOfNonAssetPrefabInstance(gameObject))
            {
                GameObject correspondingObjectFromSource = GetCorrespondingObjectFromSource(gameObject);
                UnityEngine.Object prefabAssetHandle2 = GetPrefabAssetHandle(correspondingObjectFromSource);
                if (prefabAssetHandle == prefabAssetHandle2)
                {
                    throw new ArgumentException("GameObject is already part of target prefab");
                }
            }
        }

        string targetPrefabGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(targetPrefab));
        if (!VerifyNestingFromScript(gameObjects, targetPrefabGUID, null))
        {
            throw new ArgumentException("Cyclic nesting detected");
        }

        AddGameObjectsToPrefabAndConnect_Internal(gameObjects, targetPrefab);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("AddGameObjectsToPrefabAndConnect", IsFreeFunction = true)]
    private static extern void AddGameObjectsToPrefabAndConnect_Internal([NotNull("ArgumentNullException")] GameObject[] gameObjects, [NotNull("ArgumentNullException")] UnityEngine.Object prefab);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("VerifyNestingFromScript", IsFreeFunction = true)]
    private static extern bool VerifyNestingFromScript([NotNull("ArgumentNullException")] GameObject[] gameObjects, [NotNull("ArgumentNullException")] string targetPrefabGUID, UnityEngine.Object prefabInstance);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    internal static extern Component[] GetRemovedComponents([NotNull("ArgumentNullException")] UnityEngine.Object prefabInstance);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [StaticAccessor("PrefabUtilityBindings", StaticAccessorType.DoubleColon)]
    private static extern void SetRemovedComponents([NotNull("ArgumentNullException")] UnityEngine.Object prefabInstance, [NotNull("ArgumentNullException")] Component[] removedComponents);

    //
    // Summary:
    //     Returns true if the given object is part of any kind of Prefab.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the object s part of a Prefab.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfAnyPrefab([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Prefab Asset.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True is the object is part of a Prefab Asset.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfPrefabAsset([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Prefab instance.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the object is part of a Prefab instance.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfPrefabInstance([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Prefab instance and not part of
    //     an asset.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the object is part of a Prefab instance that's not inside a Prefab Asset.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfNonAssetPrefabInstance([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern bool IsInstanceIDPartOfNonAssetPrefabInstance(int componentOrGameObjectInstanceID);

    //
    // Summary:
    //     Returns true if the given object is part of a regular Prefab instance or Prefab
    //     Asset.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the given object is part of a regular Prefab instance or Prefab Asset.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfRegularPrefab([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Model Prefab Asset or Model Prefab
    //     instance.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the given object is part of a Model Prefab.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfModelPrefab([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Prefab Variant Asset or Prefab
    //     Variant instance.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the given object is part of a Prefab Variant.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfVariantPrefab([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Is this object part of a Prefab that cannot be edited?
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the object is part of a Prefab that cannot be edited.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPartOfImmutablePrefab([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of an instance where the PrefabInstance
    //     object is missing but the given object has a valid corresponding object.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a GameObject or component.
    //
    // Returns:
    //     True if the instance is disconnected.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsDisconnectedFromPrefabAsset([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);

    //
    // Summary:
    //     Returns true if the given object is part of a Prefab instance but the source
    //     asset is missing.
    //
    // Parameters:
    //   instanceComponentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the given object is part of a Prefab instance but the source asset is
    //     missing.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern bool IsPrefabAssetMissing([NotNull("ArgumentNullException")] UnityEngine.Object instanceComponentOrGameObject);

    //
    // Summary:
    //     Retrieves the GameObject that is the root of the outermost Prefab instance the
    //     object is part of.
    //
    // Parameters:
    //   componentOrGameObject:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     The outermost Prefab instance root.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern GameObject GetOutermostPrefabInstanceRoot([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);


    /*
        Summary:
            Retrieves the GameObject that is the root of the nearest Prefab instance the object is part of.
            如果一个 go/component 位于一个 prefab 内, 则返回它所属的最近的一个 prefab;
            否则就返回 null
        
        Parameters:
        componentOrGameObject:
            The object to check. Must be a component or GameObject.
        
        Returns:
            The nearest Prefab instance root.
    */
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    public static extern GameObject GetNearestPrefabInstanceRoot([NotNull("ArgumentNullException")] UnityEngine.Object componentOrGameObject);



    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern GameObject GetOriginalSourceOrVariantRoot([NotNull("ArgumentNullException")] UnityEngine.Object instanceOrAsset);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern GameObject GetOriginalSourceRootWhereGameObjectIsAdded([NotNull("ArgumentNullException")] GameObject gameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("PrefabUtilityBindings::ApplyPrefabAddedComponent", IsFreeFunction = true, ThrowsException = true)]
    private static extern void ApplyAddedComponent([NotNull("ArgumentNullException")] Component addedComponent, [NotNull("ArgumentNullException")] UnityEngine.Object applyTargetPrefabObject);

    //
    // Summary:
    //     Returns true if the given modification is considered a PrefabUtility.IsDefaultOverride|default
    //     override.
    //
    // Parameters:
    //   modification:
    //     The modification for the property in question.
    //
    // Returns:
    //     True if the property is a default override.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("PrefabUtilityBindings::IsDefaultOverride", IsFreeFunction = true)]
    public static extern bool IsDefaultOverride(PropertyModification modification);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern bool CheckIfAddingPrefabWouldResultInCyclicNesting(UnityEngine.Object prefabAssetThatIsAddedTo, UnityEngine.Object prefabAssetThatWillBeAdded);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern bool WasCreatedAsPrefabInstancePlaceholderObject(UnityEngine.Object componentOrGameObject);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction]
    internal static extern void ShowCyclicNestingWarningDialog();

    [RequiredByNativeCode]
    internal static void ExtractSelectedObjectsFromPrefab()
    {
        HashSet<string> hashSet = new HashSet<string>();
        string text = null;
        UnityEngine.Object[] objects = Selection.objects;
        foreach (UnityEngine.Object @object in objects)
        {
            string assetPath = AssetDatabase.GetAssetPath(@object);
            if (text == null)
            {
                text = EditorUtility.SaveFolderPanel("Select Materials Folder", FileUtil.DeleteLastPathNameComponent(assetPath), "");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }

                text = FileUtil.GetProjectRelativePath(text);
            }

            string text2 = ((@object is Material) ? ".mat" : string.Empty);
            string path = FileUtil.CombinePaths(text, @object.name) + text2;
            path = AssetDatabase.GenerateUniqueAssetPath(path);
            string value = AssetDatabase.ExtractAsset(@object, path);
            if (string.IsNullOrEmpty(value))
            {
                hashSet.Add(assetPath);
            }
        }

        foreach (string item in hashSet)
        {
            AssetDatabase.WriteImportSettingsIfDirty(item);
            AssetDatabase.ImportAsset(item, ImportAssetOptions.ForceUpdate);
        }
    }

    internal static void ExtractMaterialsFromAsset(UnityEngine.Object[] targets, string destinationPath)
    {
        HashSet<string> hashSet = new HashSet<string>();
        foreach (UnityEngine.Object @object in targets)
        {
            AssetImporter assetImporter = @object as AssetImporter;
            UnityEngine.Object[] array = (from x in AssetDatabase.LoadAllAssetsAtPath(assetImporter.assetPath)
                                          where x.GetType() == typeof(Material)
                                          select x).ToArray();
            UnityEngine.Object[] array2 = array;
            foreach (UnityEngine.Object object2 in array2)
            {
                string path = FileUtil.CombinePaths(destinationPath, object2.name) + ".mat";
                path = AssetDatabase.GenerateUniqueAssetPath(path);
                string value = AssetDatabase.ExtractAsset(object2, path);
                if (string.IsNullOrEmpty(value))
                {
                    hashSet.Add(assetImporter.assetPath);
                }
            }
        }

        foreach (string item in hashSet)
        {
            AssetDatabase.WriteImportSettingsIfDirty(item);
            AssetDatabase.ImportAsset(item, ImportAssetOptions.ForceUpdate);
        }
    }

    internal static void GetObjectListFromHierarchy(HashSet<int> hierarchyInstanceIDs, GameObject gameObject)
    {
        Transform transform = null;
        List<Component> list = new List<Component>();
        gameObject.GetComponents(list);
        hierarchyInstanceIDs.Add(gameObject.GetInstanceID());
        foreach (Component item in list)
        {
            if (item == null)
            {
                throw new Exception($"Component on GameObject '{gameObject.name}' is invalid");
            }

            if (item is Transform)
            {
                transform = item as Transform;
            }
            else
            {
                hierarchyInstanceIDs.Add(item.GetInstanceID());
            }
        }

        if (!(transform == null))
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GetObjectListFromHierarchy(hierarchyInstanceIDs, transform.GetChild(i).gameObject);
            }
        }
    }

    internal static void CollectAddedObjects(GameObject gameObject, HashSet<int> hierarchyInstanceIDs, List<UnityEngine.Object> danglingObjects)
    {
        Transform transform = null;
        List<Component> list = new List<Component>();
        if (hierarchyInstanceIDs.Contains(gameObject.GetInstanceID()))
        {
            gameObject.GetComponents(list);
            foreach (Component item in list)
            {
                if (item is Transform)
                {
                    transform = item as Transform;
                }
                else if (!(item == null) && !hierarchyInstanceIDs.Contains(item.GetInstanceID()))
                {
                    danglingObjects.Add(item);
                }
            }

            if (!(transform == null))
            {
                int childCount = transform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    CollectAddedObjects(transform.GetChild(i).gameObject, hierarchyInstanceIDs, danglingObjects);
                }
            }
        }
        else
        {
            danglingObjects.Add(gameObject);
        }
    }

    private static void RegisterNewObjects(GameObject newHierarchy, HashSet<int> hierarchyInstanceIDs, string actionName)
    {
        List<UnityEngine.Object> list = new List<UnityEngine.Object>();
        CollectAddedObjects(newHierarchy, hierarchyInstanceIDs, list);
        HashSet<Type> hashSet = new HashSet<Type>();
        hashSet.Add(typeof(Transform));
        HashSet<Type> hashSet2 = hashSet;
        bool flag = false;
        GameObject gameObject = null;
        while (list.Count > 0 && !flag)
        {
            flag = true;
            for (int i = 0; i < list.Count; i++)
            {
                UnityEngine.Object @object = list[i];
                if (@object is Component)
                {
                    Component component = (Component)@object;
                    if (component.gameObject != gameObject)
                    {
                        hashSet = new HashSet<Type>();
                        hashSet.Add(typeof(Transform));
                        hashSet2 = hashSet;
                        gameObject = component.gameObject;
                    }
                }

                object[] customAttributes = @object.GetType().GetCustomAttributes(typeof(RequireComponent), inherit: true);
                bool flag2 = true;
                object[] array = customAttributes;
                for (int j = 0; j < array.Length; j++)
                {
                    RequireComponent requireComponent = (RequireComponent)array[j];
                    if ((requireComponent.m_Type0 != null && !hashSet2.Contains(requireComponent.m_Type0)) || (requireComponent.m_Type1 != null && !hashSet2.Contains(requireComponent.m_Type1)) || (requireComponent.m_Type2 != null && !hashSet2.Contains(requireComponent.m_Type2)))
                    {
                        flag2 = false;
                        break;
                    }
                }

                if (flag2)
                {
                    Undo.RegisterCreatedObjectUndoToFrontOfUndoQueue(@object, actionName);
                    if (@object is Component)
                    {
                        hashSet2.Add(@object.GetType());
                    }

                    list.RemoveAt(i);
                    i--;
                    flag = false;
                }
            }
        }

        Debug.Assert(list.Count == 0, "Dangling components have unfulfilled dependencies");
        foreach (UnityEngine.Object item in list)
        {
            Undo.RegisterCreatedObjectUndoToFrontOfUndoQueue(item, actionName);
        }
    }

    private static void ThrowExceptionIfNotValidPrefabInstanceObject(UnityEngine.Object prefabInstanceObject, bool isApply)
    {
        if (!(prefabInstanceObject is GameObject) && !(prefabInstanceObject is Component))
        {
            throw new ArgumentException("Calling apply or revert methods on an object which is not a GameObject or Component is not supported.", "prefabInstanceObject");
        }

        if (prefabInstanceObject == null)
        {
            throw new NullReferenceException("Cannot apply or revert object. Object is null.");
        }

        if (!IsPartOfPrefabInstance(prefabInstanceObject))
        {
            throw new ArgumentException("Calling apply or revert methods on an object which is not part of a Prefab instance is not supported.", "prefabInstanceObject");
        }

        if (isApply)
        {
            ThrowExceptionIfInstanceIsPersistent(prefabInstanceObject);
        }
    }

    private static void ThrowExceptionIfAllPrefabInstanceObjectsAreInvalid(UnityEngine.Object[] prefabInstanceObjects, bool isApply)
    {
        foreach (UnityEngine.Object @object in prefabInstanceObjects)
        {
            if (@object != null && (@object is GameObject || @object is Component) && IsPartOfPrefabInstance(@object) && (!isApply || !EditorUtility.IsPersistent(@object)))
            {
                return;
            }
        }

        throw new ArgumentException("Cannot apply or revert on any of the objects. Attempt with individual objects for details.", "prefabInstanceObjects");
    }

    private static void ThrowExceptionIfInstanceIsPersistent(UnityEngine.Object prefabInstanceObject)
    {
        if (EditorUtility.IsPersistent(prefabInstanceObject))
        {
            throw new ArgumentException("Calling apply methods on an instance which is part of a Prefab Asset is not supported.", "prefabInstanceObject");
        }
    }

    //
    // Summary:
    //     Retrieves the root GameObjects for all instances of the Prefab asset with root
    //     prefabRoot found in all currently loaded scenes. If prefabRoot is not a valid
    //     Prefab asset root GameObject, an ArgumentException is thrown.
    //
    // Parameters:
    //   prefabRoot:
    //     The root GameObject of a Prefab asset.
    //
    //   scene:
    //     The scene to search for Prefab instances. The scene you specify must be valid
    //     and loaded.
    //
    // Returns:
    //     The root GameObjects for all instances of the Prefab asset with root prefabRoot.
    public static GameObject[] FindAllInstancesOfPrefab(GameObject prefabRoot)
    {
        return FindAllInstancesOfPrefab_internal(prefabRoot, 0);
    }

    //
    // Summary:
    //     Retrieves the root GameObjects for all instances of the Prefab asset with root
    //     prefabRoot found in all currently loaded scenes. If prefabRoot is not a valid
    //     Prefab asset root GameObject, an ArgumentException is thrown.
    //
    // Parameters:
    //   prefabRoot:
    //     The root GameObject of a Prefab asset.
    //
    //   scene:
    //     The scene to search for Prefab instances. The scene you specify must be valid
    //     and loaded.
    //
    // Returns:
    //     The root GameObjects for all instances of the Prefab asset with root prefabRoot.
    public static GameObject[] FindAllInstancesOfPrefab(GameObject prefabRoot, Scene scene)
    {
        if (!scene.IsValid())
        {
            throw new ArgumentException("Input scene is not valid: Could not be found.");
        }

        return FindAllInstancesOfPrefab_internal(prefabRoot, scene.handle);
    }

    //
    // Summary:
    //     Forces a Prefab instance to merge with changes from the Prefab Asset.
    //
    // Parameters:
    //   instanceRoot:
    //     Root of Prefab instance to update.
    public static void MergePrefabInstance(GameObject instanceRoot)
    {
        MergePrefabInstance_internal(instanceRoot);
    }

    //
    // Summary:
    //     Reverts all overrides on a Prefab instance.
    //
    // Parameters:
    //   instanceRoot:
    //     The root of the Prefab instance.
    //
    //   action:
    //     The interaction mode for this action.
    //
    //   go:
    public static void RevertPrefabInstance(GameObject instanceRoot, InteractionMode action)
    {
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceRoot, isApply: false);
        bool flag = IsDisconnectedFromPrefabAsset(instanceRoot);
        GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(instanceRoot);
        string text = "Revert Prefab Instance";
        HashSet<int> hierarchyInstanceIDs = null;
        if (action == InteractionMode.UserAction)
        {
            hierarchyInstanceIDs = new HashSet<int>();
            GetObjectListFromHierarchy(hierarchyInstanceIDs, outermostPrefabInstanceRoot);
            Undo.RegisterFullObjectHierarchyUndo(outermostPrefabInstanceRoot, text);
        }

        RevertPrefabInstance_Internal(outermostPrefabInstanceRoot);
        if (action == InteractionMode.UserAction)
        {
            RegisterNewObjects(outermostPrefabInstanceRoot, hierarchyInstanceIDs, text);
            if (flag)
            {
                Undo.RegisterCreatedObjectUndo(GetPrefabInstanceHandle(outermostPrefabInstanceRoot), text);
            }
        }
    }

    //
    // Summary:
    //     Applies all overrides on a Prefab instance to its Prefab Asset.
    //
    // Parameters:
    //   instanceRoot:
    //     The root of the given Prefab instance.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyPrefabInstance(GameObject instanceRoot, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceRoot, isApply: true);
        using (new AtomicUndoScope())
        {
            GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(instanceRoot);
            bool flag = GetPrefabInstanceHandle(outermostPrefabInstanceRoot) == null;
            string text = "Apply instance to prefab";
            UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(outermostPrefabInstanceRoot);
            HashSet<int> hierarchyInstanceIDs = null;
            if (action == InteractionMode.UserAction)
            {
                Undo.RegisterFullObjectHierarchyUndo(correspondingObjectFromSource, text);
                Undo.RegisterFullObjectHierarchyUndo(outermostPrefabInstanceRoot, text);
                hierarchyInstanceIDs = new HashSet<int>();
                GetObjectListFromHierarchy(hierarchyInstanceIDs, correspondingObjectFromSource as GameObject);
            }

            ApplyPrefabInstance(outermostPrefabInstanceRoot);
            if (action == InteractionMode.UserAction)
            {
                RegisterNewObjects(correspondingObjectFromSource as GameObject, hierarchyInstanceIDs, text);
                if (flag)
                {
                    UnityEngine.Object prefabInstanceHandle = GetPrefabInstanceHandle(outermostPrefabInstanceRoot);
                    Assert.IsNotNull(prefabInstanceHandle);
                    Undo.RegisterCreatedObjectUndo(prefabInstanceHandle, text);
                }
            }
        }

        Analytics.SendApplyEvent(Analytics.ApplyScope.EntirePrefab, instanceRoot, null, action, utcNow, defaultOverrideComparedToSomeSources: false);
    }

    private static void MapObjectReferencePropertyToSourceIfApplicable(SerializedProperty property, string assetPath)
    {
        UnityEngine.Object objectReferenceValue = property.objectReferenceValue;
        if (!(objectReferenceValue == null))
        {
            objectReferenceValue = GetCorrespondingObjectFromSourceAtPath(objectReferenceValue, assetPath);
            if (objectReferenceValue != null)
            {
                property.objectReferenceValue = objectReferenceValue;
            }
        }
    }

    private static bool WarnIfInAnimationMode(OverrideOperation overrideOperation, InteractionMode action)
    {
        if (!AnimationMode.InAnimationMode())
        {
            return false;
        }

        switch (action)
        {
            case InteractionMode.AutomatedAction:
                switch (overrideOperation)
                {
                    case OverrideOperation.Apply:
                        throw new InvalidOperationException("Cannot apply overriden properties in Animation Mode.");
                    case OverrideOperation.Revert:
                        throw new InvalidOperationException("Cannot revert overriden properties in Animation Mode.");
                }

                break;
            case InteractionMode.UserAction:
                {
                    string message = L10n.Tr("Overriden properties cannot be applied or reverted when in Animation Mode.\n\nDisable Animation Mode and try again.");
                    switch (overrideOperation)
                    {
                        case OverrideOperation.Apply:
                            EditorUtility.DisplayDialog(L10n.Tr("Cannot apply property override to Prefab"), message, L10n.Tr("OK"));
                            break;
                        case OverrideOperation.Revert:
                            EditorUtility.DisplayDialog(L10n.Tr("Cannot revert property override"), message, L10n.Tr("OK"));
                            break;
                    }

                    break;
                }
        }

        return true;
    }

    //
    // Summary:
    //     Applies a single overridden property on a Prefab instance to the Prefab Asset
    //     at the given asset path.
    //
    // Parameters:
    //   instanceProperty:
    //     The SerializedProperty representing the property to apply.
    //
    //   assetPath:
    //     The path of the Prefab Asset to apply to.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyPropertyOverride(SerializedProperty instanceProperty, string assetPath, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        UnityEngine.Object targetObject = instanceProperty.serializedObject.targetObject;
        ThrowExceptionIfNotValidPrefabInstanceObject(targetObject, isApply: true);
        if (!WarnIfInAnimationMode(OverrideOperation.Apply, action))
        {
            ApplyPropertyOverrides(targetObject, instanceProperty, assetPath, allowApplyDefaultOverride: true, action);
            Analytics.SendApplyEvent(Analytics.ApplyScope.PropertyOverride, targetObject, assetPath, action, utcNow, IsPropertyOverrideDefaultOverrideComparedToAnySource(instanceProperty));
        }
    }

    private static void ApplyPropertyOverrides(UnityEngine.Object prefabInstanceObject, SerializedProperty optionalSingleInstanceProperty, string assetPath, bool allowApplyDefaultOverride, InteractionMode action)
    {
        if (WarnIfInAnimationMode(OverrideOperation.Apply, action))
        {
            return;
        }

        UnityEngine.Object correspondingObjectFromSourceAtPath = GetCorrespondingObjectFromSourceAtPath(prefabInstanceObject, assetPath);
        if (correspondingObjectFromSourceAtPath == null)
        {
            return;
        }

        SerializedObject prefabSourceSerializedObject = new SerializedObject(correspondingObjectFromSourceAtPath);
        List<SerializedObject> list = new List<SerializedObject>();
        HashSet<SerializedObject> changedObjects = new HashSet<SerializedObject>();
        HandleApplySingleProperties(prefabInstanceObject, optionalSingleInstanceProperty, assetPath, correspondingObjectFromSourceAtPath, prefabSourceSerializedObject, list, changedObjects, allowApplyDefaultOverride, action);
        AssetDatabase.StartAssetEditing();
        try
        {
            Action<SerializedObject> action2 = delegate (SerializedObject serializedObject)
            {
                if (changedObjects.Contains(serializedObject) && ((action == InteractionMode.UserAction) ? serializedObject.ApplyModifiedProperties() : serializedObject.ApplyModifiedPropertiesWithoutUndo()))
                {
                    SaveChangesToPrefabFileIfPersistent(serializedObject);
                    if (action == InteractionMode.UserAction)
                    {
                        Undo.FlushUndoRecordObjects();
                    }
                }
            };
            if (list.Count > 0)
            {
                action2(list[0]);
                for (int num = list.Count - 1; num > 0; num--)
                {
                    action2(list[num]);
                }
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
        }
    }

    private static void HandleApplySingleProperties(UnityEngine.Object prefabInstanceObject, SerializedProperty optionalSingleInstanceProperty, string assetPath, UnityEngine.Object prefabSourceObject, SerializedObject prefabSourceSerializedObject, List<SerializedObject> serializedObjects, HashSet<SerializedObject> changedObjects, bool allowApplyDefaultOverride, InteractionMode action)
    {
        bool isObjectOnRootInAsset = IsObjectOnRootInAsset(prefabInstanceObject, assetPath);
        SerializedProperty serializedProperty = null;
        SerializedProperty serializedProperty2 = null;
        if (optionalSingleInstanceProperty != null)
        {
            serializedProperty = GetArrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset(optionalSingleInstanceProperty, prefabSourceSerializedObject, action, out var cancel);
            if (cancel)
            {
                return;
            }

            if (serializedProperty == null)
            {
                serializedProperty = optionalSingleInstanceProperty.Copy();
            }

            serializedProperty2 = serializedProperty.GetEndProperty();
        }
        else
        {
            SerializedObject serializedObject = new SerializedObject(prefabInstanceObject);
            serializedProperty = serializedObject.GetIterator();
        }

        bool allowWarnAboutApplyingPartsOfManagedReferences = serializedProperty.isReferencingAManagedReferenceField;
        bool skipRestOfProperties;
        if (!serializedProperty.hasVisibleChildren)
        {
            if (serializedProperty.prefabOverride)
            {
                ApplySinglePropertyAndRemoveOverride(serializedProperty, prefabSourceSerializedObject, assetPath, isObjectOnRootInAsset, singlePropertyOnly: true, allowWarnAboutApplyingPartsOfManagedReferences, allowApplyDefaultOverride, serializedObjects, changedObjects, action, out skipRestOfProperties);
            }

            return;
        }

        if (serializedProperty.prefabOverride && serializedProperty.propertyType == SerializedPropertyType.ManagedReference)
        {
            allowWarnAboutApplyingPartsOfManagedReferences = false;
            ApplySinglePropertyAndRemoveOverride(serializedProperty, prefabSourceSerializedObject, assetPath, isObjectOnRootInAsset, singlePropertyOnly: false, allowWarnAboutApplyingPartsOfManagedReferences, allowApplyDefaultOverride, serializedObjects, changedObjects, action, out skipRestOfProperties);
        }

        HashSet<long> hashSet = new HashSet<long>();
        bool enterChildren = serializedProperty.hasVisibleChildren;
        while (serializedProperty.Next(enterChildren) && (serializedProperty2 == null || !SerializedProperty.EqualContents(serializedProperty, serializedProperty2)))
        {
            bool flag = serializedProperty.propertyType == SerializedPropertyType.ManagedReference;
            bool skipRestOfProperties2 = false;
            if (serializedProperty.prefabOverride && (flag || !serializedProperty.hasVisibleChildren))
            {
                ApplySinglePropertyAndRemoveOverride(serializedProperty, prefabSourceSerializedObject, assetPath, isObjectOnRootInAsset, singlePropertyOnly: false, allowWarnAboutApplyingPartsOfManagedReferences, allowApplyDefaultOverride, serializedObjects, changedObjects, action, out skipRestOfProperties2);
            }

            if (skipRestOfProperties2)
            {
                break;
            }

            enterChildren = ((!flag) ? serializedProperty.hasVisibleChildren : (hashSet.Add(serializedProperty.managedReferenceId) && serializedProperty.hasVisibleChildren));
        }
    }

    private static void SaveChangesToPrefabFileIfPersistent(SerializedObject serializedObject)
    {
        if (!EditorUtility.IsPersistent(serializedObject.targetObject))
        {
            return;
        }

        GameObject gameObject = serializedObject.targetObject as GameObject;
        if (gameObject == null)
        {
            Component component = serializedObject.targetObject as Component;
            if (component != null)
            {
                gameObject = component.gameObject;
            }
        }

        if (gameObject != null)
        {
            SavePrefabAsset(gameObject.transform.root.gameObject);
        }
    }

    private static SerializedProperty GetArrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset(SerializedProperty optionalSingleInstanceProperty, SerializedObject prefabSourceSerializedObject, InteractionMode action, out bool cancel)
    {
        cancel = false;
        string propertyPath = optionalSingleInstanceProperty.propertyPath;
        int length = optionalSingleInstanceProperty.propertyPath.Length;
        int num = 0;
        while (num < length)
        {
            int num2 = propertyPath.IndexOf(".Array.data[", num);
            if (num2 < 0)
            {
                return null;
            }

            string propertyPath2 = propertyPath.Substring(0, num2);
            int num3 = num2 + ".Array.data[".Length;
            int num4 = propertyPath.IndexOf(']', num3) - num3;
            SerializedProperty serializedProperty = optionalSingleInstanceProperty.serializedObject.FindProperty(propertyPath2);
            SerializedProperty serializedProperty2 = prefabSourceSerializedObject.FindProperty(propertyPath2);
            if (serializedProperty2 == null)
            {
                WarnIfApplyingManagedReferenceFieldIsNotPossible(optionalSingleInstanceProperty, null, action);
                cancel = true;
                return null;
            }

            if (serializedProperty.arraySize > serializedProperty2.arraySize)
            {
                string text = propertyPath.Substring(num3, num4);
                if (!int.TryParse(text, out var result))
                {
                    Debug.LogError("Misformed arrayElementIndexString " + text);
                    return serializedProperty;
                }

                if (result >= serializedProperty2.arraySize)
                {
                    if (action == InteractionMode.UserAction && !EditorUtility.DisplayDialog("Mismatching array size", $"The property is part of an array element which does not exist in the source Prefab because the corresponding array there is shorter. Do you want to apply the entire array '{serializedProperty.displayName}'?", "Apply Array", "Cancel"))
                    {
                        cancel = true;
                        return null;
                    }

                    return serializedProperty;
                }
            }

            num = num2 + ".Array.data[".Length + num4 + 1;
        }

        return null;
    }

    private static void ApplySinglePropertyAndRemoveOverride(SerializedProperty instanceProperty, SerializedObject prefabSourceSerializedObject, string assetPath, bool isObjectOnRootInAsset, bool singlePropertyOnly, bool allowWarnAboutApplyingPartsOfManagedReferences, bool allowApplyDefaultOverride, List<SerializedObject> serializedObjects, HashSet<SerializedObject> changedObjects, InteractionMode action, out bool skipRestOfProperties)
    {
        skipRestOfProperties = false;
        if (!allowApplyDefaultOverride && isObjectOnRootInAsset && IsPropertyOverrideDefaultOverrideComparedToAnySource(instanceProperty))
        {
            if (singlePropertyOnly)
            {
                if (action == InteractionMode.AutomatedAction)
                {
                    Debug.LogWarning("Cannot apply default-override property, since it is protected from being applied or reverted.");
                }
                else
                {
                    EditorUtility.DisplayDialog(L10n.Tr("Cannot apply default-override property"), L10n.Tr("Default-override properties are protected from being applied or reverted."), L10n.Tr("OK"));
                }
            }

            return;
        }

        SerializedProperty serializedProperty = prefabSourceSerializedObject.FindProperty(instanceProperty.propertyPath);
        if (serializedProperty == null)
        {
            bool cancel;
            SerializedProperty arrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset = GetArrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset(instanceProperty, prefabSourceSerializedObject, InteractionMode.AutomatedAction, out cancel);
            if (arrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset != null)
            {
                prefabSourceSerializedObject.CopyFromSerializedProperty(arrayPropertyIfGivenPropertyIsPartOfArrayElementInInstanceWhichDoesNotExistInAsset);
                changedObjects.Add(prefabSourceSerializedObject);
                serializedProperty = prefabSourceSerializedObject.FindProperty(instanceProperty.propertyPath);
                if (serializedProperty == null)
                {
                    Debug.LogError("ApplySingleProperty full array copy error: SerializedProperty could not be found for " + instanceProperty.propertyPath + ". Please report a bug.");
                    return;
                }
            }
        }

        if (allowWarnAboutApplyingPartsOfManagedReferences && WarnIfApplyingManagedReferenceFieldIsNotPossible(instanceProperty, serializedProperty, action))
        {
            skipRestOfProperties = true;
            return;
        }

        if (serializedProperty == null)
        {
            Debug.LogError("ApplySinglePropertyAndRemoveOverride error: Unhandled situation for " + instanceProperty.propertyPath + ". Please report a bug.");
            skipRestOfProperties = true;
            return;
        }

        if (instanceProperty.propertyType == SerializedPropertyType.ManagedReference)
        {
            serializedProperty.managedReferenceValue = instanceProperty.managedReferenceValue;
        }
        else
        {
            prefabSourceSerializedObject.CopyFromSerializedProperty(instanceProperty);
        }

        changedObjects.Add(prefabSourceSerializedObject);
        if (serializedProperty.propertyType == SerializedPropertyType.ObjectReference)
        {
            MapObjectReferencePropertyToSourceIfApplicable(serializedProperty, assetPath);
            if (serializedProperty.objectReferenceValue != null && !EditorUtility.IsPersistent(serializedProperty.objectReferenceValue))
            {
                if (singlePropertyOnly)
                {
                    if (action == InteractionMode.AutomatedAction)
                    {
                        Debug.LogWarning("Cannot apply reference to scene object that is not part of apply target prefab.");
                    }
                    else
                    {
                        EditorUtility.DisplayDialog(L10n.Tr("Cannot apply reference to object in scene"), L10n.Tr("A reference to an object in the scene cannot be applied to the Prefab asset."), L10n.Tr("OK"));
                    }
                }

                return;
            }
        }

        if (serializedObjects.Count == 0)
        {
            serializedObjects.Add(prefabSourceSerializedObject);
        }

        UnityEngine.Object targetObject = instanceProperty.serializedObject.targetObject;
        UnityEngine.Object targetObject2 = prefabSourceSerializedObject.targetObject;
        UnityEngine.Object @object = targetObject;
        int num = 1;
        while (@object != targetObject2)
        {
            SerializedObject serializedObject;
            if (num >= serializedObjects.Count)
            {
                serializedObject = new SerializedObject(@object);
                serializedObjects.Add(serializedObject);
            }
            else
            {
                serializedObject = serializedObjects[num];
            }

            SerializedPropertyType propertyType = instanceProperty.propertyType;
            if (propertyType == SerializedPropertyType.ArraySize)
            {
                serializedObject.CopyFromSerializedProperty(instanceProperty);
            }

            SerializedProperty serializedProperty2 = serializedObject.FindProperty(instanceProperty.propertyPath);
            if (serializedProperty2 != null && serializedProperty2.prefabOverride)
            {
                serializedProperty2.prefabOverride = false;
                changedObjects.Add(serializedObject);
            }

            if (serializedProperty2 == null)
            {
                Debug.LogError("ApplySingleProperty clear overrides error: SerializedProperty could not be found for " + instanceProperty.propertyPath + ". Please report a bug.");
            }

            @object = GetCorrespondingObjectFromSource(@object);
            num++;
        }
    }

    internal static void RevertPropertyOverrides(SerializedProperty[] instanceProperties, InteractionMode action)
    {
        if (WarnIfInAnimationMode(OverrideOperation.Revert, action))
        {
            return;
        }

        foreach (SerializedProperty instanceProperty in instanceProperties)
        {
            if (WarnIfRevertingManagedReferenceIsNotPossible(instanceProperty, action))
            {
                return;
            }
        }

        foreach (SerializedProperty instanceProperty2 in instanceProperties)
        {
            RevertPropertyOverride(instanceProperty2, action);
        }
    }

    //
    // Summary:
    //     Revert a single property override on a Prefab instance.
    //
    // Parameters:
    //   action:
    //     The interaction mode for this action.
    //
    //   instanceProperty:
    //     The SerializedProperty representing the property to revert.
    public static void RevertPropertyOverride(SerializedProperty instanceProperty, InteractionMode action)
    {
        if (WarnIfInAnimationMode(OverrideOperation.Revert, action))
        {
            return;
        }

        ThrowExceptionIfAllPrefabInstanceObjectsAreInvalid(instanceProperty.serializedObject.targetObjects, isApply: false);
        if (!WarnIfRevertingManagedReferenceIsNotPossible(instanceProperty, action))
        {
            instanceProperty.prefabOverride = false;
            if (action == InteractionMode.UserAction)
            {
                instanceProperty.serializedObject.ApplyModifiedProperties();
            }
            else
            {
                instanceProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }
    }

    private static bool WarnIfApplyingManagedReferenceFieldIsNotPossible(SerializedProperty instanceProperty, SerializedProperty sourceProperty, InteractionMode action)
    {
        if (!instanceProperty.isReferencingAManagedReferenceField)
        {
            return false;
        }

        if (sourceProperty != null)
        {
            if (instanceProperty.managedReferencePropertyPath != sourceProperty.managedReferencePropertyPath)
            {
                string text = L10n.Tr("Mismatching Objects");
                string text2 = L10n.Tr("Cannot apply SerializeReference field since the Prefab instance is referencing a new object compared to the Prefab Asset.\n\nThis means that the changes from the Prefab Asset cannot be merged back to the Prefab instance.\n\nYou can apply the root of the field or the entire component");
                if (action == InteractionMode.AutomatedAction)
                {
                    throw new InvalidOperationException(text + ": " + text2 + "(instance property " + instanceProperty.managedReferencePropertyPath + ", asset property " + sourceProperty.managedReferencePropertyPath + ")");
                }

                EditorUtility.DisplayDialog(text, text2, L10n.Tr("OK"));
                return true;
            }
        }
        else if (!string.IsNullOrEmpty(instanceProperty.managedReferencePropertyPath))
        {
            string text3 = L10n.Tr("Mismatching Types");
            string text4 = L10n.Tr("Cannot apply a SerializeReference sub field when the type from the Prefab instance is different from the Prefab Asset.\n\nYou can apply the root of the field or the entire component");
            if (action == InteractionMode.AutomatedAction)
            {
                throw new InvalidOperationException(text3 + ": " + text4);
            }

            EditorUtility.DisplayDialog(text3, text4, L10n.Tr("OK"));
            return true;
        }

        return false;
    }

    private static bool WarnIfRevertingManagedReferenceIsNotPossible(SerializedProperty instanceProperty, InteractionMode action)
    {
        if (!instanceProperty.isReferencingAManagedReferenceField)
        {
            return false;
        }

        UnityEngine.Object targetObject = instanceProperty.serializedObject.targetObject;
        UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(targetObject);
        SerializedObject serializedObject = new SerializedObject(correspondingObjectFromSource);
        SerializedProperty serializedProperty = serializedObject.FindProperty(instanceProperty.propertyPath);
        string text = "";
        string text2 = "";
        if (serializedProperty != null)
        {
            if (instanceProperty.managedReferencePropertyPath != serializedProperty.managedReferencePropertyPath)
            {
                text2 = L10n.Tr("Mismatching Objects");
                text = L10n.Tr("Cannot revert a single SerializeReference field since the Prefab instance is referencing a new object compared to the Prefab Asset.\n\nThis means that the entire object is considered an override, cannot revert parts of it.\n\nYou can revert the root of the serialized reference or the entire component.");
            }
        }
        else
        {
            text2 = L10n.Tr("Mismatching Types");
            text = L10n.Tr("Cannot revert a parts of a SerializeReference property since the Prefab instance is referencing a different type compared to the Prefab Asset.\n\nYou can revert the root of the serialized reference or the entire component.");
        }

        bool flag = !string.IsNullOrEmpty(text);
        if (flag)
        {
            switch (action)
            {
                case InteractionMode.AutomatedAction:
                    throw new InvalidOperationException(text2 + ": " + text);
                case InteractionMode.UserAction:
                    EditorUtility.DisplayDialog(text2, text, L10n.Tr("OK"));
                    break;
            }
        }

        return flag;
    }

    //
    // Summary:
    //     Applies all overridden properties on a Prefab instance component or GameObject
    //     to the Prefab Asset at the given asset path.
    //
    // Parameters:
    //   instanceComponentOrGameObject:
    //     The object on the Prefab instance to apply.
    //
    //   assetPath:
    //     The path of the Prefab Asset to apply to.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyObjectOverride(UnityEngine.Object instanceComponentOrGameObject, string assetPath, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceComponentOrGameObject, isApply: true);
        if (WarnIfInAnimationMode(OverrideOperation.Apply, action))
        {
            return;
        }

        ApplyPropertyOverrides(instanceComponentOrGameObject, null, assetPath, allowApplyDefaultOverride: false, action);
        if (action == InteractionMode.UserAction)
        {
            Component component = instanceComponentOrGameObject as Component;
            if (component != null)
            {
                Component coupledComponent = component.GetCoupledComponent();
                if (coupledComponent != null)
                {
                    ApplyPropertyOverrides(coupledComponent, null, assetPath, allowApplyDefaultOverride: false, action);
                }
            }
        }

        Analytics.SendApplyEvent(Analytics.ApplyScope.ObjectOverride, instanceComponentOrGameObject, assetPath, action, utcNow, IsObjectOverrideAllDefaultOverridesComparedToOriginalSource(instanceComponentOrGameObject));
    }

    //
    // Summary:
    //     Reverts all overridden properties on a Prefab instance component or GameObject.
    //
    //
    // Parameters:
    //   action:
    //     The interaction mode for this action.
    //
    //   instanceComponentOrGameObject:
    //     The object on the Prefab instance to revert.
    public static void RevertObjectOverride(UnityEngine.Object instanceComponentOrGameObject, InteractionMode action)
    {
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceComponentOrGameObject, isApply: false);
        if (WarnIfInAnimationMode(OverrideOperation.Revert, action))
        {
            return;
        }

        if (action == InteractionMode.UserAction)
        {
            Undo.RegisterCompleteObjectUndo(instanceComponentOrGameObject, "Revert component property overrides");
        }

        RevertObjectOverride_Internal(instanceComponentOrGameObject);
        if (action != InteractionMode.UserAction)
        {
            return;
        }

        Component component = instanceComponentOrGameObject as Component;
        if (component != null)
        {
            Component coupledComponent = component.GetCoupledComponent();
            if (coupledComponent != null)
            {
                Undo.RegisterCompleteObjectUndo(coupledComponent, "Revert component property overrides");
                RevertObjectOverride_Internal(coupledComponent);
            }
        }
    }

    //
    // Summary:
    //     Applies the added component to the Prefab Asset at the given asset path.
    //
    // Parameters:
    //   action:
    //     The interaction mode for this action.
    //
    //   assetPath:
    //     The path of the Prefab Asset to apply to.
    //
    //   component:
    //     The added component on the Prefab instance to apply.
    public static void ApplyAddedComponent(Component component, string assetPath, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        if (component == null)
        {
            throw new ArgumentNullException("component", "Cannot apply added component. Component is null.");
        }

        if (!IsAddedComponentOverride(component))
        {
            throw new ArgumentException("Cannot apply added component. Component is not an added component override on a Prefab instance.", "component");
        }

        ThrowExceptionIfInstanceIsPersistent(component);
        try
        {
            GameObject correspondingObjectFromSourceAtPath = GetCorrespondingObjectFromSourceAtPath(component.gameObject, assetPath);
            if (correspondingObjectFromSourceAtPath == null)
            {
                return;
            }

            string name = "Apply Added Component";
            if (action == InteractionMode.UserAction)
            {
                string text = string.Join(", ", (from e in GetAddedComponentDependencies(component, OverrideOperation.Apply)
                                                 select ObjectNames.GetInspectorTitle(e)).ToArray());
                if (!string.IsNullOrEmpty(text))
                {
                    string message = string.Format(L10n.Tr("Can't apply added component {0} because it depends on {1}."), ObjectNames.GetInspectorTitle(component), text);
                    EditorUtility.DisplayDialog(L10n.Tr("Can't apply added component"), message, L10n.Tr("OK"));
                    return;
                }

                Undo.RegisterFullObjectHierarchyUndo(correspondingObjectFromSourceAtPath, name);
                Undo.RegisterFullObjectHierarchyUndo(component, name);
            }

            ApplyAddedComponent(component, correspondingObjectFromSourceAtPath);
            if (action == InteractionMode.UserAction)
            {
                Undo.RegisterCreatedObjectUndo(GetCorrespondingObjectFromOriginalSource(component), name);
                Component coupledComponent = component.GetCoupledComponent();
                if (coupledComponent != null)
                {
                    ApplyAddedComponent(coupledComponent, correspondingObjectFromSourceAtPath);
                    Undo.RegisterCreatedObjectUndo(GetCorrespondingObjectFromOriginalSource(coupledComponent), name);
                }
            }
        }
        catch (ArgumentException ex)
        {
            if (action != InteractionMode.UserAction)
            {
                throw ex;
            }

            EditorUtility.DisplayDialog(L10n.Tr("Can't add component"), ex.Message, L10n.Tr("OK"));
            Undo.RevertAllInCurrentGroup();
        }

        Analytics.SendApplyEvent(Analytics.ApplyScope.AddedComponent, component, assetPath, action, utcNow, defaultOverrideComparedToSomeSources: false);
    }

    //
    // Summary:
    //     Removes this added component on a Prefab instance.
    //
    // Parameters:
    //   component:
    //     The added component on the Prefab instance to revert.
    //
    //   action:
    //     The interaction mode for this action.
    public static void RevertAddedComponent(Component component, InteractionMode action)
    {
        if (component == null)
        {
            throw new ArgumentNullException("component", "Cannot revert added component. Component is null.");
        }

        if (!IsAddedComponentOverride(component))
        {
            throw new ArgumentException("Cannot revert added component. Component is not an added component override on a Prefab instance.", "component");
        }

        GameObject gameObject = component.gameObject;
        if (action == InteractionMode.UserAction)
        {
            string text = string.Join(", ", (from e in GetAddedComponentDependencies(component, OverrideOperation.Revert)
                                             select ObjectNames.GetInspectorTitle(e)).ToArray());
            if (!string.IsNullOrEmpty(text))
            {
                string message = string.Format(L10n.Tr("Can't revert added component {0} because {1} depends on it."), ObjectNames.GetInspectorTitle(component), text);
                EditorUtility.DisplayDialog(L10n.Tr("Can't revert added component"), message, L10n.Tr("OK"));
                return;
            }

            Component coupledComponent = component.GetCoupledComponent();
            Undo.DestroyObjectImmediate(component);
            if (coupledComponent != null)
            {
                Undo.DestroyObjectImmediate(coupledComponent);
            }
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(component);
        }

        MergePrefabInstance_internal(gameObject);
    }

    private static bool IsPrefabInstanceObjectOf(UnityEngine.Object instance, UnityEngine.Object source)
    {
        UnityEngine.Object @object = instance;
        while (@object != null)
        {
            if (@object == source)
            {
                return true;
            }

            if (GetPrefabAssetHandle(@object) == source)
            {
                return true;
            }

            @object = GetCorrespondingObjectFromSource(@object);
        }

        return false;
    }

    private static void RemoveRemovedComponentOverridesWhichAreNull(UnityEngine.Object prefabInstanceObject)
    {
        Component[] removedComponents = GetRemovedComponents(prefabInstanceObject);
        Component[] removedComponents2 = removedComponents.Where((Component c) => c != null).ToArray();
        SetRemovedComponents(prefabInstanceObject, removedComponents2);
    }

    //
    // Summary:
    //     Removes the component from the Prefab Asset which has the component on it.
    //
    // Parameters:
    //   instanceGameObject:
    //     The GameObject on the Prefab instance which the component has been removed from.
    //
    //
    //   assetComponent:
    //     The component on the Prefab Asset corresponding to the removed component on the
    //     instance.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyRemovedComponent(GameObject instanceGameObject, Component assetComponent, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceGameObject, isApply: true);
        if (assetComponent == null)
        {
            throw new ArgumentNullException("assetComponent", "Prefab source may not be null.");
        }

        string name = "Apply Prefab removed component";
        if (action == InteractionMode.UserAction)
        {
            string text = string.Join(", ", (from e in GetRemovedComponentDependencies(assetComponent, instanceGameObject, OverrideOperation.Apply)
                                             select ObjectNames.GetInspectorTitle(e)).ToArray());
            if (!string.IsNullOrEmpty(text))
            {
                string message = string.Format(L10n.Tr("Can't apply removed component {0} because {1} component in the Prefab Asset depends on it."), ObjectNames.GetInspectorTitle(assetComponent), text);
                EditorUtility.DisplayDialog(L10n.Tr("Can't apply removed component"), message, L10n.Tr("OK"));
                return;
            }

            Component coupledComponent = assetComponent.GetCoupledComponent();
            Undo.DestroyObjectUndoable(assetComponent, name);
            if (coupledComponent != null)
            {
                Undo.DestroyObjectUndoable(coupledComponent, name);
            }
        }
        else
        {
            GameObject gameObject = assetComponent.transform.root.gameObject;
            UnityEngine.Object.DestroyImmediate(assetComponent, allowDestroyingAssets: true);
            SavePrefabAsset(gameObject);
        }

        UnityEngine.Object prefabInstanceHandle = GetPrefabInstanceHandle(instanceGameObject);
        if (action == InteractionMode.UserAction)
        {
            Undo.RegisterCompleteObjectUndo(prefabInstanceHandle, name);
        }

        RemoveRemovedComponentOverridesWhichAreNull(prefabInstanceHandle);
        Analytics.SendApplyEvent(Analytics.ApplyScope.RemovedComponent, instanceGameObject, AssetDatabase.GetAssetPath(assetComponent), action, utcNow, defaultOverrideComparedToSomeSources: false);
    }

    private static void RemoveRemovedComponentOverride(UnityEngine.Object instanceObject, Component assetComponent)
    {
        Component[] removedComponents = GetRemovedComponents(instanceObject);
        int index = -1;
        for (int i = 0; i < removedComponents.Length; i++)
        {
            if (IsPrefabInstanceObjectOf(removedComponents[i], assetComponent))
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            Component[] removedComponents2 = removedComponents.Where((Component c) => c != removedComponents[index]).ToArray();
            SetRemovedComponents(instanceObject, removedComponents2);
        }
    }

    //
    // Summary:
    //     Adds this removed component back on the Prefab instance.
    //
    // Parameters:
    //   assetComponent:
    //     The removed component on the Prefab instance to revert.
    //
    //   action:
    //     The interaction mode for this action.
    //
    //   instanceGameObject:
    //     The GameObject on the Prefab instance which the component has been removed from.
    public static void RevertRemovedComponent(GameObject instanceGameObject, Component assetComponent, InteractionMode action)
    {
        ThrowExceptionIfNotValidPrefabInstanceObject(instanceGameObject, isApply: false);
        string name = "Revert Prefab removed component";
        UnityEngine.Object prefabInstanceHandle = GetPrefabInstanceHandle(instanceGameObject);
        if (action == InteractionMode.UserAction)
        {
            string text = string.Join(", ", (from e in GetRemovedComponentDependencies(assetComponent, instanceGameObject, OverrideOperation.Revert)
                                             select ObjectNames.GetInspectorTitle(e)).ToArray());
            if (!string.IsNullOrEmpty(text))
            {
                string message = string.Format(L10n.Tr("Can't revert removed component {0} because it depends on {1}."), ObjectNames.GetInspectorTitle(assetComponent), text);
                EditorUtility.DisplayDialog(L10n.Tr("Can't revert removed component"), message, L10n.Tr("OK"));
                return;
            }

            Undo.RegisterCompleteObjectUndo(instanceGameObject, name);
        }

        RemoveRemovedComponentOverride(prefabInstanceHandle, assetComponent);
        if (action != InteractionMode.UserAction)
        {
            return;
        }

        Component[] components = instanceGameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (IsPrefabInstanceObjectOf(component, assetComponent))
            {
                Undo.RegisterCreatedObjectUndo(component, name);
                break;
            }
        }

        Component coupledComponent = assetComponent.GetCoupledComponent();
        if (!(coupledComponent != null))
        {
            return;
        }

        RemoveRemovedComponentOverride(prefabInstanceHandle, coupledComponent);
        Component[] components2 = instanceGameObject.GetComponents<Component>();
        foreach (Component component2 in components2)
        {
            if (IsPrefabInstanceObjectOf(component2, coupledComponent))
            {
                Undo.RegisterCreatedObjectUndo(component2, name);
                break;
            }
        }
    }

    //
    // Summary:
    //     Applies the added GameObject to the Prefab Asset at the given asset path.
    //
    // Parameters:
    //   gameObject:
    //     The added GameObject on the Prefab instance to apply.
    //
    //   assetPath:
    //     The path of the Prefab Asset to apply to.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyAddedGameObject(GameObject gameObject, string assetPath, InteractionMode action)
    {
        ApplyAddedGameObjects(new GameObject[1] { gameObject }, assetPath, action);
    }

    //
    // Summary:
    //     Applies the added GameObjects to the Prefab Asset at the given asset path.
    //
    // Parameters:
    //   gameObjects:
    //     The added GameObjects on the Prefab instance to apply.
    //
    //   assetPath:
    //     The path of the Prefab Asset to apply to.
    //
    //   action:
    //     The interaction mode for this action.
    public static void ApplyAddedGameObjects(GameObject[] gameObjects, string assetPath, InteractionMode action)
    {
        DateTime utcNow = DateTime.UtcNow;
        if (gameObjects == null)
        {
            throw new ArgumentNullException("gameObjects", "Cannot apply added GameObjects. GameObjects array is null.");
        }

        if (!gameObjects.Any())
        {
            throw new ArgumentException("gameObjects", "No GameObjects in array.");
        }

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == null)
            {
                throw new ArgumentException("go", "Input GameObject is null.");
            }

            if (!IsAddedGameObjectOverride(gameObject))
            {
                throw new ArgumentException("go", "Cannot apply added GameObject. GameObject '" + gameObject.name + "' is not an added GameObject override on a Prefab instance.");
            }

            ThrowExceptionIfInstanceIsPersistent(gameObject);
        }

        if (gameObjects.Length > 1 && !HasSameParent(gameObjects))
        {
            throw new ArgumentException("gameObjects", "ApplyAddedGameObjects requires that GameObjects share the same parent.");
        }

        GameObject gameObject2 = gameObjects[0];
        Transform parent = gameObject2.transform.parent;
        if (parent == null)
        {
            return;
        }

        GameObject correspondingObjectFromSourceAtPath = GetCorrespondingObjectFromSourceAtPath(parent.gameObject, assetPath);
        if (correspondingObjectFromSourceAtPath == null)
        {
            return;
        }

        GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(parent);
        if (outermostPrefabInstanceRoot == null)
        {
            return;
        }

        GameObject gameObject3 = correspondingObjectFromSourceAtPath.transform.root.gameObject;
        string name = "Apply Added GameObject";
        if (action == InteractionMode.UserAction)
        {
            Undo.RegisterFullObjectHierarchyUndo(gameObject3, name);
            Undo.RegisterFullObjectHierarchyUndo(outermostPrefabInstanceRoot, name);
        }

        AddGameObjectsToPrefabAndConnect(gameObjects, correspondingObjectFromSourceAtPath);
        SavePrefabAsset(gameObject3);
        foreach (GameObject instanceOrAsset in gameObjects)
        {
            if (action == InteractionMode.UserAction)
            {
                GameObject correspondingObjectFromSourceInAsset = GetCorrespondingObjectFromSourceInAsset(instanceOrAsset, correspondingObjectFromSourceAtPath);
                if (correspondingObjectFromSourceInAsset != null)
                {
                    Undo.RegisterCreatedObjectUndoToFrontOfUndoQueue(correspondingObjectFromSourceInAsset, name);
                }
            }

            Analytics.SendApplyEvent(Analytics.ApplyScope.AddedGameObject, outermostPrefabInstanceRoot, assetPath, action, utcNow, defaultOverrideComparedToSomeSources: false);
        }

        EditorUtility.ForceRebuildInspectors();
    }

    internal static bool HasSameParent(GameObject[] gameObjects)
    {
        if (gameObjects == null || !gameObjects.Any() || gameObjects[0] == null)
        {
            throw new ArgumentException("gameObjects", "Array is invalid.");
        }

        Transform parent = gameObjects[0].transform.parent;
        if (parent == null)
        {
            throw new ArgumentException("goParent", "Object is a parentless root.");
        }

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.transform.parent != parent)
            {
                return false;
            }
        }

        return true;
    }

    //
    // Summary:
    //     Removes this added GameObject from a Prefab instance.
    //
    // Parameters:
    //   action:
    //     The interaction mode for this action.
    //
    //   gameObject:
    //     The added GameObject on the Prefab instance to revert.
    public static void RevertAddedGameObject(GameObject gameObject, InteractionMode action)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException("gameObject", "Cannot revert added GameObject. GameObject is null.");
        }

        if (!IsAddedGameObjectOverride(gameObject))
        {
            throw new ArgumentException("Cannot apply added GameObject. GameObject is not an added GameObject override on a Prefab instance.", "gameObject");
        }

        ThrowExceptionIfInstanceIsPersistent(gameObject);
        if (action == InteractionMode.UserAction)
        {
            Undo.DestroyObjectImmediate(gameObject);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(gameObject);
        }
    }

    //
    // Summary:
    //     Retrieves a list of objects with information about object overrides on the Prefab
    //     instance.
    //
    // Parameters:
    //   prefabInstance:
    //     The Prefab instance to get information about.
    //
    //   includeDefaultOverrides:
    //     If true, components will also be included even if they only contain overrides
    //     that are PrefabUtility.IsDefaultOverride|default overrides. False by default.
    //
    //
    // Returns:
    //     List of objects with information about object overrides.
    public static List<ObjectOverride> GetObjectOverrides(GameObject prefabInstance, bool includeDefaultOverrides = false)
    {
        return PrefabOverridesUtility.GetObjectOverrides(prefabInstance, includeDefaultOverrides);
    }

    //
    // Summary:
    //     Retrieves a list of PrefabUtility.AddedComponent objects which contain information
    //     about added component overrides on the Prefab instance.
    //
    // Parameters:
    //   prefabInstance:
    //     The Prefab instance to get information about.
    //
    // Returns:
    //     List of objects with information about added components.
    public static List<AddedComponent> GetAddedComponents(GameObject prefabInstance)
    {
        return PrefabOverridesUtility.GetAddedComponents(prefabInstance);
    }

    //
    // Summary:
    //     Returns a list of objects with information about removed component overrides
    //     on the Prefab instance.
    //
    // Parameters:
    //   prefabInstance:
    //     The Prefab instance to get information about.
    //
    // Returns:
    //     List of objects with information about removed components.
    public static List<RemovedComponent> GetRemovedComponents(GameObject prefabInstance)
    {
        return PrefabOverridesUtility.GetRemovedComponents(prefabInstance);
    }

    //
    // Summary:
    //     Retrieves a list of PrefabUtility.AddedGameObject objects which contain information
    //     about added GameObjects on the Prefab instance.
    //
    // Parameters:
    //   prefabInstance:
    //     The Prefab instance to get information about.
    //
    // Returns:
    //     List of objects with information about added GameObjects.
    public static List<AddedGameObject> GetAddedGameObjects(GameObject prefabInstance)
    {
        return PrefabOverridesUtility.GetAddedGameObjects(prefabInstance);
    }

    internal static void HandleApplyRevertMenuItems(string thingThatChanged, UnityEngine.Object instanceObject, Action<GUIContent, UnityEngine.Object> addApplyMenuItemAction, Action<GUIContent> addRevertMenuItemAction, bool isAllDefaultOverridesComparedToOriginalSource = false, int targetCount = 1)
    {
        if (targetCount == 1)
        {
            HandleApplyMenuItems(thingThatChanged, instanceObject, addApplyMenuItemAction, isAllDefaultOverridesComparedToOriginalSource);
        }

        HandleRevertMenuItem(thingThatChanged, addRevertMenuItemAction);
    }

    internal static void HandleApplyMenuItems(string thingThatChanged, UnityEngine.Object instanceOrAssetObject, Action<GUIContent, UnityEngine.Object> addApplyMenuItemAction, bool isAllDefaultOverridesComparedToOriginalSource = false, bool includeSelfAsTarget = false)
    {
        if (thingThatChanged == null)
        {
            thingThatChanged = string.Empty;
        }

        if (thingThatChanged != string.Empty)
        {
            thingThatChanged += "/";
        }

        List<UnityEngine.Object> applyTargets = GetApplyTargets(instanceOrAssetObject, isAllDefaultOverridesComparedToOriginalSource, includeSelfAsTarget);
        if (applyTargets == null || applyTargets.Count == 0)
        {
            return;
        }

        for (int i = 0; i < applyTargets.Count; i++)
        {
            UnityEngine.Object @object = applyTargets[i];
            GameObject rootGameObject = GetRootGameObject(@object);
            string format = L10n.Tr("Apply as Override in Prefab '{0}'");
            if (i == applyTargets.Count - 1)
            {
                format = L10n.Tr("Apply to Prefab '{0}'");
            }

            GUIContent arg = new GUIContent(thingThatChanged + string.Format(format, rootGameObject.name));
            addApplyMenuItemAction(arg, @object);
        }
    }

    internal static void HandleRevertMenuItem(string thingThatChanged, Action<GUIContent> addRevertMenuItemAction)
    {
        if (thingThatChanged == null)
        {
            thingThatChanged = string.Empty;
        }

        if (thingThatChanged != string.Empty)
        {
            thingThatChanged += "/";
        }

        GUIContent obj = new GUIContent(thingThatChanged + L10n.Tr("Revert"));
        addRevertMenuItemAction(obj);
    }

    private static UnityEngine.Object GetParentPrefabInstance(GameObject gameObject)
    {
        Transform parent = gameObject.transform.parent;
        if (parent == null)
        {
            return null;
        }

        return GetPrefabInstanceHandle(parent);
    }

    internal static GameObject GetGameObject(UnityEngine.Object componentOrGameObject)
    {
        GameObject gameObject = componentOrGameObject as GameObject;
        if (gameObject != null)
        {
            return gameObject;
        }

        Component component = componentOrGameObject as Component;
        if (component != null)
        {
            return component.gameObject;
        }

        return null;
    }

    internal static GameObject GetRootGameObject(UnityEngine.Object componentOrGameObject)
    {
        GameObject gameObject = GetGameObject(componentOrGameObject);
        if (gameObject == null)
        {
            return null;
        }

        return gameObject.transform.root.gameObject;
    }

    //
    // Summary:
    //     Is the GameObject the root of any Prefab instance?
    //
    // Parameters:
    //   gameObject:
    //     The GameObject to check.
    //
    // Returns:
    //     True if the GameObject is the root GameObject of any Prefab instance.
    public static bool IsAnyPrefabInstanceRoot(GameObject gameObject)
    {
        GameObject nearestPrefabInstanceRoot = GetNearestPrefabInstanceRoot(gameObject);
        return gameObject == nearestPrefabInstanceRoot;
    }

    //
    // Summary:
    //     Is the GameObject the root of a Prefab instance, excluding nested Prefabs?
    //
    // Parameters:
    //   gameObject:
    //     The GameObject to check.
    //
    // Returns:
    //     True if the GameObject is an outermost Prefab instance root.
    public static bool IsOutermostPrefabInstanceRoot(GameObject gameObject)
    {
        GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(gameObject);
        return gameObject == outermostPrefabInstanceRoot;
    }


    /*
        Summary:
            Retrieves the asset path of the nearest Prefab instance root the specified object is part of.
        
        Parameters:
        instanceComponentOrGameObject:
            An object in the Prefab instance to get the asset path of.
        
        Returns:
            The asset path.
    */
    public static string GetPrefabAssetPathOfNearestInstanceRoot(UnityEngine.Object instanceComponentOrGameObject)
    {
        return AssetDatabase.GetAssetPath(GetOriginalSourceOrVariantRoot(instanceComponentOrGameObject));
    }



    //
    // Summary:
    //     Retrieves the icon for the given GameObject.
    //
    // Parameters:
    //   gameObject:
    //     The GameObject to get an icon for.
    //
    // Returns:
    //     The icon for the GameObject.
    public static Texture2D GetIconForGameObject(GameObject gameObject)
    {
        if (IsAnyPrefabInstanceRoot(gameObject))
        {
            if (IsPrefabAssetMissing(gameObject))
            {
                return GameObjectStyles.prefabIcon;
            }

            string prefabAssetPathOfNearestInstanceRoot = GetPrefabAssetPathOfNearestInstanceRoot(gameObject);
            return (Texture2D)AssetDatabase.GetCachedIcon(prefabAssetPathOfNearestInstanceRoot);
        }

        return GameObjectStyles.gameObjectIcon;
    }

    //
    // Summary:
    //     Returns the parent asset object of source, or null if it can't be found.
    //
    // Parameters:
    //   obj:
    [Obsolete("Use GetCorrespondingObjectFromSource.")]
    public static UnityEngine.Object GetPrefabParent(UnityEngine.Object obj)
    {
        return GetCorrespondingObjectFromSource(obj);
    }

    //
    // Summary:
    //     Creates an empty Prefab at given path.
    //
    // Parameters:
    //   path:
    //     The asset path to use for the new empty Prefab.
    //
    // Returns:
    //     A reference to the new Prefab Asset.
    [Obsolete("The concept of creating a completely empty Prefab has been discontinued. You can however use SaveAsPrefabAsset with an empty GameObject.")]
    public static UnityEngine.Object CreateEmptyPrefab(string path)
    {
        if (Path.GetExtension(path) != ".prefab")
        {
            Debug.LogError("Create Prefab path must use .prefab extension");
            return null;
        }

        GameObject gameObject = new GameObject("EmptyPrefab");
        bool success;
        GameObject targetObject = SaveAsPrefabAsset(gameObject, path, out success);
        UnityEngine.Object.DestroyImmediate(gameObject);
        return GetPrefabObject(targetObject);
    }

    //
    // Summary:
    //     Use this function to save the version of an existing Prefab Asset that exists
    //     in memory back to disk.
    //
    // Parameters:
    //   asset:
    //     Any GameObject that is part of the Prefab Asset to save.
    //
    //   savedSuccessfully:
    //     The result of the save action, either successful or unsuccessful. Use this together
    //     with the console log to get more insight into the save process.
    //
    // Returns:
    //     The root GameObject of the saved Prefab Asset.
    public static GameObject SavePrefabAsset(GameObject asset)
    {
        bool savedSuccessfully;
        return SavePrefabAsset(asset, out savedSuccessfully);
    }

    public static GameObject SavePrefabAsset(GameObject asset, out bool savedSuccessfully)
    {
        if (asset == null)
        {
            throw new ArgumentNullException("Parameter prefabAssetGameObject is null");
        }

        if (IsPartOfModelPrefab(asset))
        {
            throw new ArgumentException("Can't save a Model Prefab");
        }

        if (IsPartOfImmutablePrefab(asset))
        {
            throw new ArgumentException("Can't save an immutable Prefab");
        }

        string assetPath = AssetDatabase.GetAssetPath(asset);
        if (string.IsNullOrEmpty(assetPath))
        {
            throw new ArgumentException("Can't save a Prefab instance");
        }

        GameObject gameObject = asset.transform.root.gameObject;
        if (gameObject != asset)
        {
            throw new ArgumentException("GameObject to save Prefab from must be a Prefab root");
        }

        return SavePrefabAsset_Internal(gameObject, out savedSuccessfully);
    }

    internal static void ValidatePath(GameObject instanceRoot, string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException("path is null or empty");
        }

        if (!Paths.IsValidAssetPath(path, ".prefab"))
        {
            throw new ArgumentException("Given path is not valid: '" + path + "'");
        }

        if (Directory.Exists(path))
        {
            throw new ArgumentException("Overwriting a folder with an Asset is not allowed: '" + path + "'");
        }

        string directoryName = Path.GetDirectoryName(path);
        bool rootFolder = false;
        bool immutable = false;
        bool assetFolderInfo = AssetDatabase.GetAssetFolderInfo(directoryName, out rootFolder, out immutable);
        if (assetFolderInfo && immutable)
        {
            throw new ArgumentException("Saving Prefab to immutable folder is not allowed: '" + path + "'");
        }

        if (directoryName.Length > 0 && !Directory.Exists(directoryName))
        {
            throw new ArgumentException("Given path does not exist: '" + path + "'");
        }

        if (assetFolderInfo)
        {
            string path2 = (Path.IsPathRooted(path) ? FileUtil.GetProjectRelativePath(path) : path);
            string targetPrefabGUID = AssetDatabase.AssetPathToGUID(path2);
            if (!VerifyNestingFromScript(new GameObject[1] { instanceRoot }, targetPrefabGUID, GetPrefabInstanceHandle(instanceRoot)))
            {
                throw new ArgumentException("Cyclic nesting detected");
            }
        }
    }

    private static void SaveAsPrefabAssetArgumentCheck(GameObject instanceRoot, string path)
    {
        if (instanceRoot == null)
        {
            throw new ArgumentNullException("Parameter root is null");
        }

        if (EditorUtility.IsPersistent(instanceRoot))
        {
            throw new ArgumentException("Can't save persistent object as a Prefab asset");
        }

        if (IsPrefabAssetMissing(instanceRoot))
        {
            throw new ArgumentException("Can't save Prefab instance with missing asset as a Prefab. You may unpack the instance and save the unpacked GameObjects as a Prefab.");
        }

        GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(instanceRoot);
        if ((bool)outermostPrefabInstanceRoot && outermostPrefabInstanceRoot != instanceRoot)
        {
            throw new ArgumentException("Can't save part of a Prefab instance as a Prefab");
        }

        ValidatePath(instanceRoot, path);
    }

    private static void ReplacePrefabArgumentCheck(GameObject root, string path)
    {
        if (root == null)
        {
            throw new ArgumentNullException("Parameter root is null");
        }

        ValidatePath(root, path);
    }

    [RequiredByNativeCode]
    private static GameObject ReplacePrefabAndRegisterUndo_Internal(GameObject instanceRoot, GameObject existingPrefabRoot, bool connectedAfterwards, string actionName)
    {
        if (existingPrefabRoot == null)
        {
            throw new ArgumentNullException("Parameter existingPrefabRoot is null");
        }

        if (!IsPartOfPrefabAsset(existingPrefabRoot))
        {
            throw new ArgumentException("Parameter existingPrefabRoot is not a Prefab asset");
        }

        string assetPath = AssetDatabase.GetAssetPath(existingPrefabRoot);
        ReplacePrefabArgumentCheck(instanceRoot, assetPath);
        HashSet<int> hierarchyInstanceIDs = new HashSet<int>();
        GetObjectListFromHierarchy(hierarchyInstanceIDs, existingPrefabRoot);
        Undo.RegisterFullObjectHierarchyUndo(existingPrefabRoot, actionName);
        bool success;
        GameObject gameObject = SavePrefab_Internal(instanceRoot, assetPath, connectedAfterwards, out success);
        if (!success)
        {
            return null;
        }

        RegisterNewObjects(gameObject, hierarchyInstanceIDs, actionName);
        Undo.RegisterCreatedObjectUndo(gameObject, actionName);
        return gameObject;
    }

    public static GameObject SaveAsPrefabAsset(GameObject instanceRoot, string assetPath, out bool success)
    {
        SaveAsPrefabAssetArgumentCheck(instanceRoot, assetPath);
        return SaveAsPrefabAsset_Internal(instanceRoot, assetPath, out success);
    }

    //
    // Summary:
    //     Use this function to create a Prefab Asset at the given path from the given GameObject,
    //     including any childen in the Scene without modifying the input objects.
    //
    // Parameters:
    //   instanceRoot:
    //     The GameObject to save as a Prefab Asset.
    //
    //   assetPath:
    //     The path to save the Prefab at.
    //
    //   success:
    //     The result of the save action, either successful or unsuccessful. Use this together
    //     with the console log to get more insight into the save process.
    //
    // Returns:
    //     The root GameObject of the saved Prefab Asset, if available.
    public static GameObject SaveAsPrefabAsset(GameObject instanceRoot, string assetPath)
    {
        bool success;
        return SaveAsPrefabAsset(instanceRoot, assetPath, out success);
    }

    //
    // Summary:
    //     Use this function to create a Prefab Asset at the given path from the given GameObject,
    //     including any children in the Scene and at the same time make the given GameObject
    //     into an instance of the new Prefab.
    //
    // Parameters:
    //   instanceRoot:
    //     The GameObject to save as a Prefab and make into a Prefab instance.
    //
    //   assetPath:
    //     The path to save the Prefab at.
    //
    //   action:
    //     The interaction mode to use for this action.
    //
    //   success:
    //     The result of the save action, either successful or unsuccessful. Use this together
    //     with the console log to get more insight into the save process.
    //
    // Returns:
    //     The root GameObject of the saved Prefab Asset, if available.
    public static GameObject SaveAsPrefabAssetAndConnect(GameObject instanceRoot, string assetPath, InteractionMode action)
    {
        bool success;
        return SaveAsPrefabAssetAndConnect(instanceRoot, assetPath, action, out success);
    }

    public static GameObject SaveAsPrefabAssetAndConnect(GameObject instanceRoot, string assetPath, InteractionMode action, out bool success)
    {
        SaveAsPrefabAssetArgumentCheck(instanceRoot, assetPath);
        string name = "Connect to Prefab";
        if (action == InteractionMode.UserAction)
        {
            Undo.RegisterFullObjectHierarchyUndo(instanceRoot, name);
        }

        GameObject result = SaveAsPrefabAssetAndConnect_Internal(instanceRoot, assetPath, out success);
        if (!success)
        {
            return null;
        }

        if (action == InteractionMode.UserAction)
        {
            Undo.RecordCreatedObject(GetPrefabInstanceHandle(instanceRoot), name);
        }

        return result;
    }

    internal static void ApplyPrefabInstance(GameObject instance)
    {
        if (instance == null)
        {
            throw new ArgumentNullException("instance");
        }

        if (IsPartOfModelPrefab(instance))
        {
            throw new ArgumentException("Can't apply to a Model Prefab");
        }

        if (IsPartOfImmutablePrefab(instance))
        {
            throw new ArgumentException("Can't apply to an immutable Prefab");
        }

        if (!IsPartOfNonAssetPrefabInstance(instance))
        {
            throw new ArgumentException("Provided GameObject is not a Prefab instance");
        }

        if (IsDisconnectedFromPrefabAsset(instance))
        {
            GameObject outermostPrefabInstanceRoot = GetOutermostPrefabInstanceRoot(instance);
            if (!(outermostPrefabInstanceRoot == instance) && GetCorrespondingObjectFromOriginalSource(instance) != GetCorrespondingObjectFromSource(instance))
            {
                throw new ArgumentException("Can't save Prefab from an object that originates from a nested Prefab");
            }
        }
        else
        {
            GameObject outermostPrefabInstanceRoot2 = GetOutermostPrefabInstanceRoot(instance);
            if (outermostPrefabInstanceRoot2 != instance)
            {
                throw new ArgumentException("GameObject to save Prefab from must be a Prefab root");
            }
        }

        GameObject correspondingObjectFromSource = GetCorrespondingObjectFromSource(instance);
        string assetPath = AssetDatabase.GetAssetPath(correspondingObjectFromSource);
        SaveAsPrefabAssetArgumentCheck(instance, assetPath);
        ApplyPrefabInstance_Internal(instance);
    }

    //
    // Summary:
    //     Creates a Prefab from a game object hierarchy.
    //
    // Parameters:
    //   path:
    //     The path where the Prefab is saved.
    //
    //   go:
    //     The GameObject that you want to create a Prefab from.
    //
    //   options:
    //
    // Returns:
    //     A reference to the created Prefab.
    [Obsolete("Use SaveAsPrefabAsset instead.")]
    public static GameObject CreatePrefab(string path, GameObject go)
    {
        return SaveAsPrefabAsset(go, path);
    }

    //
    // Summary:
    //     Creates a Prefab from a game object hierarchy.
    //
    // Parameters:
    //   path:
    //     The path where the Prefab is saved.
    //
    //   go:
    //     The GameObject that you want to create a Prefab from.
    //
    //   options:
    //
    // Returns:
    //     A reference to the created Prefab.
    [Obsolete("Use SaveAsPrefabAsset or SaveAsPrefabAssetAndConnect instead.")]
    public static GameObject CreatePrefab(string path, GameObject go, ReplacePrefabOptions options)
    {
        if ((options & ReplacePrefabOptions.ConnectToPrefab) != 0)
        {
            return SaveAsPrefabAssetAndConnect(go, path, InteractionMode.AutomatedAction);
        }

        return SaveAsPrefabAsset(go, path);
    }

    //
    // Summary:
    //     Instantiates the given Prefab in a given Scene.
    //
    // Parameters:
    //   target:
    //     Prefab Asset to instantiate.
    //
    //   destinationScene:
    //     Scene to instantiate the Prefab in.
    //
    //   assetComponentOrGameObject:
    //
    // Returns:
    //     The GameObject at the root of the Prefab.
    public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object assetComponentOrGameObject)
    {
        return InstantiatePrefab_internal(assetComponentOrGameObject, EditorSceneManager.GetTargetSceneForNewGameObjects(), null);
    }

    //
    // Summary:
    //     Instantiates the given Prefab in a given Scene.
    //
    // Parameters:
    //   target:
    //     Prefab Asset to instantiate.
    //
    //   destinationScene:
    //     Scene to instantiate the Prefab in.
    //
    //   assetComponentOrGameObject:
    //
    // Returns:
    //     The GameObject at the root of the Prefab.
    public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object assetComponentOrGameObject, Scene destinationScene)
    {
        return InstantiatePrefab_internal(assetComponentOrGameObject, destinationScene, null);
    }

    public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object assetComponentOrGameObject, Transform parent)
    {
        return InstantiatePrefab_internal(assetComponentOrGameObject, EditorSceneManager.GetTargetSceneForNewGameObjects(), parent);
    }

    //
    // Summary:
    //     Replaces the targetPrefab with a copy of the game object hierarchy go.
    //
    // Parameters:
    //   go:
    //
    //   targetPrefab:
    //
    //   replaceOptions:
    [Obsolete("Use SaveAsPrefabAsset with a path instead.")]
    public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab)
    {
        return ReplacePrefab(go, targetPrefab, ReplacePrefabOptions.Default);
    }

    //
    // Summary:
    //     Replaces the targetPrefab with a copy of the game object hierarchy go.
    //
    // Parameters:
    //   go:
    //
    //   targetPrefab:
    //
    //   replaceOptions:
    [Obsolete("Use SaveAsPrefabAsset or SaveAsPrefabAssetAndConnect with a path instead.")]
    public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab, ReplacePrefabOptions replaceOptions)
    {
        UnityEngine.Object prefabObject = GetPrefabObject(targetPrefab);
        if (prefabObject == null)
        {
            Debug.LogError("The object you are trying to replace does not exist or is not a Prefab.");
            return null;
        }

        if (!EditorUtility.IsPersistent(prefabObject))
        {
            Debug.LogError("The Prefab you are trying to replace is not a Prefab Asset but a Prefab instance. Please use PrefabUtility.GetCorrespondingObject().", targetPrefab);
            return null;
        }

        if (HideFlags.DontSaveInEditor == (HideFlags.DontSaveInEditor & go.hideFlags))
        {
            Debug.LogError("The root GameObject of the Prefab source cannot be marked with DontSaveInEditor as it would create an empty Prefab.", go);
            return null;
        }

        UnityEngine.Object prefabObject2 = GetPrefabObject(go);
        if (prefabObject2 != null && prefabObject2 == prefabObject)
        {
            Debug.LogError("A prefab asset cannot replace itself", go);
            return null;
        }

        string assetPath = AssetDatabase.GetAssetPath(prefabObject);
        ReplacePrefabArgumentCheck(go, assetPath);
        bool success = false;
        return SavePrefab_Internal(go, assetPath, (replaceOptions & ReplacePrefabOptions.ConnectToPrefab) != 0, out success);
    }

    internal static TObject GetCorrespondingConnectedObjectFromSource<TObject>(TObject componentOrGameObject) where TObject : UnityEngine.Object
    {
        if (IsDisconnectedFromPrefabAsset(GetGameObject(componentOrGameObject)))
        {
            return null;
        }

        return (TObject)GetCorrespondingObjectFromSource_internal(componentOrGameObject);
    }

    public static TObject GetCorrespondingObjectFromSource<TObject>(TObject componentOrGameObject) where TObject : UnityEngine.Object
    {
        return (TObject)GetCorrespondingObjectFromSource_internal(componentOrGameObject);
    }

    public static TObject GetCorrespondingObjectFromOriginalSource<TObject>(TObject componentOrGameObject) where TObject : UnityEngine.Object
    {
        return (TObject)GetCorrespondingObjectFromOriginalSource_Internal(componentOrGameObject);
    }

    internal static TObject GetCorrespondingObjectFromSourceInAsset<TObject>(TObject instanceOrAsset, UnityEngine.Object prefabAssetHandle) where TObject : UnityEngine.Object
    {
        return (TObject)GetCorrespondingObjectFromSourceInAsset_internal(instanceOrAsset, prefabAssetHandle);
    }

    public static TObject GetCorrespondingObjectFromSourceAtPath<TObject>(TObject componentOrGameObject, string assetPath) where TObject : UnityEngine.Object
    {
        return (TObject)GetCorrespondingObjectFromSourceAtPath_internal(componentOrGameObject, assetPath);
    }

    private static UnityEngine.Object GetCorrespondingObjectFromOriginalSource_Internal(UnityEngine.Object instanceOrAsset)
    {
        UnityEngine.Object @object = instanceOrAsset;
        if (!EditorUtility.IsPersistent(@object))
        {
            @object = GetCorrespondingObjectFromSource(@object);
            if (@object == null)
            {
                return null;
            }
        }

        while (true)
        {
            UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(@object);
            if (correspondingObjectFromSource == null)
            {
                break;
            }

            @object = correspondingObjectFromSource;
        }

        return @object;
    }

    //
    // Summary:
    //     Given an object, returns its Prefab type (None, if it's not a Prefab).
    //
    // Parameters:
    //   target:
    // [Obsolete("Use GetPrefabAssetType and GetPrefabInstanceStatus to get the full picture about Prefab types.")]
    // public static PrefabType GetPrefabType(UnityEngine.Object target)
    // {
    //     if (!IsPartOfAnyPrefab(target))
    //     {
    //         return PrefabType.None;
    //     }

    //     bool flag = IsPartOfModelPrefab(target);
    //     if (IsPartOfPrefabAsset(target))
    //     {
    //         if (flag)
    //         {
    //             return PrefabType.ModelPrefab;
    //         }

    //         return PrefabType.Prefab;
    //     }

    //     if (IsDisconnectedFromPrefabAsset(target))
    //     {
    //         UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(target);
    //         UnityEngine.Object prefabObject = GetPrefabObject(correspondingObjectFromSource);
    //         if (prefabObject == null)
    //         {
    //             return PrefabType.None;
    //         }

    //         if (flag)
    //         {
    //             return PrefabType.DisconnectedModelPrefabInstance;
    //         }

    //         return PrefabType.DisconnectedPrefabInstance;
    //     }

    //     if (IsPrefabAssetMissing(target))
    //     {
    //         return PrefabType.MissingPrefabInstance;
    //     }

    //     if (flag)
    //     {
    //         return PrefabType.ModelPrefabInstance;
    //     }

    //     return PrefabType.PrefabInstance;
    // }

    private static void Internal_CallPrefabInstanceUpdated(GameObject instance)
    {
        foreach (PrefabInstanceUpdated item in m_PrefabInstanceUpdated.UpdateAndInvoke(prefabInstanceUpdated))
        {
            item(instance);
        }
    }

    //
    // Summary:
    //     Is this GameObject added as a child to a Prefab instance as an override?
    //
    // Parameters:
    //   gameObject:
    //     The GameObject to check.
    //
    // Returns:
    //     True if the GameObject is an added GameObject.
    public static bool IsAddedGameObjectOverride(GameObject gameObject)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException("gameObject", "GameObject is null.");
        }

        Transform parent = gameObject.transform.parent;
        if (parent == null)
        {
            return false;
        }

        if (IsDisconnectedFromPrefabAsset(parent))
        {
            return false;
        }

        GameObject correspondingObjectFromSource = GetCorrespondingObjectFromSource(parent.gameObject);
        if (correspondingObjectFromSource == null)
        {
            return false;
        }

        GameObject correspondingObjectFromSource2 = GetCorrespondingObjectFromSource(gameObject);
        if (correspondingObjectFromSource2 == null)
        {
            return true;
        }

        return correspondingObjectFromSource2.transform.parent == null;
    }

    internal static bool IsAllAddedGameObjectOverrides(GameObject[] gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (!IsAddedGameObjectOverride(gameObject))
            {
                return false;
            }
        }

        return true;
    }

    [RequiredByNativeCode]
    private static void Internal_SavingPrefab(GameObject gameObject, string path)
    {
        if (PrefabUtility.savingPrefab != null)
        {
            PrefabUtility.savingPrefab(gameObject, path);
        }
    }

    [RequiredByNativeCode]
    private static void Internal_PrefabInstanceModificationCacheCleared()
    {
        if (PrefabUtility.prefabInstanceModificationCacheCleared != null)
        {
            PrefabUtility.prefabInstanceModificationCacheCleared();
        }
    }

    internal static bool PromptAndCheckoutPrefabIfNeeded(string assetPath, SaveVerb saveVerb)
    {
        return PromptAndCheckoutPrefabIfNeeded(new string[1] { assetPath }, saveVerb);
    }

    internal static bool PromptAndCheckoutPrefabIfNeeded(string[] assetPaths, SaveVerb saveVerb)
    {
        string arg = ((assetPaths.Length > 1) ? L10n.Tr("Prefabs") : L10n.Tr("Prefab"));
        bool flag = AssetDatabase.MakeEditable(assetPaths, string.Format((saveVerb == SaveVerb.Save) ? L10n.Tr("The version control requires you to check out the {0} before saving changes.") : L10n.Tr("The version control requires you to check out the {0} before applying changes."), arg));
        if (!flag)
        {
            EditorUtility.DisplayDialog(string.Format((saveVerb == SaveVerb.Save) ? L10n.Tr("Could not save {0}") : L10n.Tr("Could not apply to {0}"), arg), string.Format((saveVerb == SaveVerb.Save) ? L10n.Tr("It was not possible to check out the {0} so the save operation has been canceled.") : L10n.Tr("It was not possible to check out the {0} so the apply operation has been canceled."), arg), L10n.Tr("OK"));
        }

        return flag;
    }

    //
    // Summary:
    //     Unpacks a given Prefab instance so that it is replaced with the contents of the
    //     Prefab Asset while retaining all override values.
    //
    // Parameters:
    //   instanceRoot:
    //     The root of the Prefab instance to unpack.
    //
    //   unpackMode:
    //     Whether to unpack the outermost root or unpack completely.
    //
    //   action:
    //     The interaction mode to use for this action.
    public static void UnpackPrefabInstance(GameObject instanceRoot, PrefabUnpackMode unpackMode, InteractionMode action)
    {
        if (!IsPartOfNonAssetPrefabInstance(instanceRoot))
        {
            throw new ArgumentException("UnpackPrefabInstance must be called with a Prefab instance.");
        }

        if (!IsOutermostPrefabInstanceRoot(instanceRoot))
        {
            throw new ArgumentException("UnpackPrefabInstance must be called with a root Prefab instance GameObject.");
        }

        if (action == InteractionMode.UserAction)
        {
            string name = "Unpack Prefab instance";
            Undo.RegisterFullObjectHierarchyUndo(instanceRoot, name);
            GameObject[] array = UnpackPrefabInstanceAndReturnNewOutermostRoots(instanceRoot, unpackMode);
            GameObject[] array2 = array;
            foreach (GameObject instanceComponentOrGameObject in array2)
            {
                UnityEngine.Object prefabInstanceHandle = GetPrefabInstanceHandle(instanceComponentOrGameObject);
                if ((bool)prefabInstanceHandle)
                {
                    Undo.RegisterCreatedObjectUndo(prefabInstanceHandle, name);
                }
            }
        }
        else
        {
            UnpackPrefabInstanceAndReturnNewOutermostRoots(instanceRoot, unpackMode);
        }

        PrefabUtility.prefabInstanceUnpacked?.Invoke(instanceRoot);
    }

    //
    // Summary:
    //     Unpacks all instances of a given Prefab Asset root GameObject in all open scenes
    //     so that all instances are replaced with the contents of the Prefab Asset while
    //     retaining all override values.
    //
    // Parameters:
    //   prefabRoot:
    //     The root GameObject of a Prefab Asset used to find all Prefab instances in open
    //     scenes that should be unpacked.
    //
    //   unpackMode:
    //     Whether to unpack the outermost root or unpack completely.
    //
    //   action:
    //     The interaction mode to use for this action.
    public static void UnpackAllInstancesOfPrefab(GameObject prefabRoot, PrefabUnpackMode unpackMode, InteractionMode action)
    {
        GameObject[] array = FindAllInstancesOfPrefab(prefabRoot);
        GameObject[] array2 = array;
        foreach (GameObject instanceRoot in array2)
        {
            UnpackPrefabInstance(instanceRoot, unpackMode, action);
        }
    }

    internal static bool HasInvalidComponent(UnityEngine.Object gameObjectOrComponent)
    {
        if (gameObjectOrComponent == null)
        {
            return true;
        }

        if (gameObjectOrComponent is Component)
        {
            Component component = (Component)gameObjectOrComponent;
            gameObjectOrComponent = component.gameObject;
        }

        if (!(gameObjectOrComponent is GameObject))
        {
            return false;
        }

        GameObject gameObject = (GameObject)gameObjectOrComponent;
        TransformVisitor transformVisitor = new TransformVisitor();
        List<GameObject> list = new List<GameObject>();
        transformVisitor.VisitAll(gameObject.transform, PrefabOverridesUtility.CheckForInvalidComponent, list);
        return list.Count > 0;
    }

    //
    // Summary:
    //     Is this object part of a Prefab that cannot be applied to?
    //
    // Parameters:
    //   gameObjectOrComponent:
    //     The object to check. Must be a component or GameObject.
    //
    // Returns:
    //     True if the object is part of a Prefab that cannot be applied to.
    public static bool IsPartOfPrefabThatCanBeAppliedTo(UnityEngine.Object gameObjectOrComponent)
    {
        if (gameObjectOrComponent == null)
        {
            return false;
        }

        if (IsPartOfImmutablePrefab(gameObjectOrComponent))
        {
            return false;
        }

        if (!EditorUtility.IsPersistent(gameObjectOrComponent))
        {
            gameObjectOrComponent = GetCorrespondingObjectFromSource(gameObjectOrComponent);
        }

        if (HasInvalidComponent(gameObjectOrComponent))
        {
            return false;
        }

        if (HasManagedReferencesWithMissingTypes(gameObjectOrComponent))
        {
            return false;
        }

        return true;
    }

    //
    // Summary:
    //     Determines whether a Prefab instance is properly connected to its asset.
    //
    // Parameters:
    //   componentOrGameObject:
    //     An object that is part of a Prefab instance.
    //
    // Returns:
    //     The status of the Prefab instance.
    public static PrefabInstanceStatus GetPrefabInstanceStatus(UnityEngine.Object componentOrGameObject)
    {
        if (!IsPartOfNonAssetPrefabInstance(componentOrGameObject))
        {
            return PrefabInstanceStatus.NotAPrefab;
        }

        if (IsDisconnectedFromPrefabAsset(componentOrGameObject))
        {
            return PrefabInstanceStatus.Disconnected;
        }

        if (IsPrefabAssetMissing(componentOrGameObject))
        {
            return PrefabInstanceStatus.MissingAsset;
        }

        return PrefabInstanceStatus.Connected;
    }

    //
    // Summary:
    //     Retrieves an enum value indicating the type of Prefab Asset, such as Regular
    //     Prefab, Model Prefab and Prefab Variant.
    //
    // Parameters:
    //   componentOrGameObject:
    //     An object that is part of a Prefab Asset or Prefab instance.
    //
    // Returns:
    //     The type of Prefab.
    public static PrefabAssetType GetPrefabAssetType(UnityEngine.Object componentOrGameObject)
    {
        if (!IsPartOfAnyPrefab(componentOrGameObject))
        {
            return PrefabAssetType.NotAPrefab;
        }

        if (IsPrefabAssetMissing(componentOrGameObject))
        {
            return PrefabAssetType.MissingAsset;
        }

        if (IsPartOfModelPrefab(componentOrGameObject))
        {
            return PrefabAssetType.Model;
        }

        if (IsPartOfVariantPrefab(componentOrGameObject))
        {
            return PrefabAssetType.Variant;
        }

        return PrefabAssetType.Regular;
    }

    //
    // Summary:
    //     Loads a Prefab Asset at a given path into an isolated Scene and returns the root
    //     GameObject of the Prefab.
    //
    // Parameters:
    //   assetPath:
    //     The path of the Prefab Asset to load the contents of.
    //
    // Returns:
    //     The root of the loaded contents.
    public static GameObject LoadPrefabContents(string assetPath)
    {
        if (string.IsNullOrEmpty(assetPath))
        {
            throw new ArgumentNullException("assetPath", "Prefab Asset path is null or empty");
        }

        if (!File.Exists(assetPath))
        {
            throw new ArgumentException($"Path: {assetPath}, does not exist");
        }

        if (Path.GetExtension(assetPath) != ".prefab")
        {
            throw new ArgumentException($"Path: {assetPath}, is not a prefab file");
        }

        Scene scene = EditorSceneManager.OpenPreviewScene(assetPath, allocateSceneCullingMask: false);
        GameObject[] rootGameObjects = scene.GetRootGameObjects();
        if (rootGameObjects.Length != 1)
        {
            EditorSceneManager.ClosePreviewScene(scene);
            throw new ArgumentException($"Could not load Prefab contents at path {assetPath}. Prefabs should have exactly 1 root GameObject, {rootGameObjects.Length} was found.");
        }

        return rootGameObjects[0];
    }

    //
    // Summary:
    //     Releases the content from a Prefab previously loaded with LoadPrefabContents
    //     from memory.
    //
    // Parameters:
    //   contentsRoot:
    //     The root of the loaded Prefab contents.
    public static void UnloadPrefabContents(GameObject contentsRoot)
    {
        if (!EditorSceneManager.IsPreviewSceneObject(contentsRoot))
        {
            throw new ArgumentException("Specified object is not part of Prefab contents");
        }

        Scene scene = contentsRoot.scene;
        EditorSceneManager.ClosePreviewScene(scene);
    }

    internal static bool IsPropertyOverrideDefaultOverrideComparedToAnySource(SerializedProperty property)
    {
        if (property == null || !property.prefabOverride)
        {
            return false;
        }

        UnityEngine.Object targetObject = property.serializedObject.targetObject;
        if (!(targetObject is Transform) && !(targetObject is GameObject))
        {
            return false;
        }

        UnityEngine.Object @object = targetObject;
        UnityEngine.Object object2 = GetCorrespondingObjectFromSource(@object);
        if (object2 == null)
        {
            return false;
        }

        while (object2 != null)
        {
            UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(object2);
            if (correspondingObjectFromSource == null)
            {
                break;
            }

            @object = object2;
            object2 = correspondingObjectFromSource;
        }

        SerializedObject serializedObject = new SerializedObject(@object);
        return serializedObject.FindProperty(property.propertyPath).isDefaultOverride;
    }

    internal static bool HasPrefabInstanceNonDefaultOverrides_CachedForUI(GameObject gameObject)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException("gameObject");
        }

        return HasPrefabInstanceNonDefaultOverrides_CachedForUI_Internal(gameObject);
    }

    internal static void ClearPrefabInstanceNonDefaultOverridesCache(GameObject gameObject)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException("gameObject");
        }

        ClearPrefabInstanceNonDefaultOverridesCache_Internal(gameObject);
    }

    internal static bool IsObjectOverrideAllDefaultOverridesComparedToOriginalSource(UnityEngine.Object componentOrGameObject)
    {
        if (!(componentOrGameObject is Transform) && !(componentOrGameObject is GameObject))
        {
            return false;
        }

        UnityEngine.Object @object = componentOrGameObject;
        UnityEngine.Object object2 = GetCorrespondingObjectFromSource(@object);
        if (object2 == null)
        {
            return false;
        }

        while (object2 != null)
        {
            UnityEngine.Object correspondingObjectFromSource = GetCorrespondingObjectFromSource(object2);
            if (correspondingObjectFromSource == null)
            {
                break;
            }

            @object = object2;
            object2 = correspondingObjectFromSource;
        }

        SerializedObject serializedObject = new SerializedObject(componentOrGameObject);
        SerializedObject serializedObject2 = new SerializedObject(@object);
        SerializedProperty iterator = serializedObject.GetIterator();
        bool flag = false;
        while (iterator.Next(enterChildren: true))
        {
            if (iterator.prefabOverride)
            {
                if (!serializedObject2.FindProperty(iterator.propertyPath).isDefaultOverride)
                {
                    return false;
                }

                flag = true;
            }
        }

        if (!flag)
        {
            return false;
        }

        return true;
    }

    internal static bool IsObjectOnRootInAsset(UnityEngine.Object componentOrGameObject, string assetPath)
    {
        GameObject gameObject = GetGameObject(componentOrGameObject);
        GameObject correspondingObjectFromSourceAtPath = GetCorrespondingObjectFromSourceAtPath(gameObject, assetPath);
        if (correspondingObjectFromSourceAtPath == null)
        {
            return false;
        }

        return correspondingObjectFromSourceAtPath.transform.root == correspondingObjectFromSourceAtPath.transform;
    }

    internal static List<UnityEngine.Object> GetApplyTargets(UnityEngine.Object instanceOrAssetObject, bool isAllDefaultOverridesComparedToOriginalSource, bool includeSelfAsTarget = false)
    {
        List<UnityEngine.Object> list = new List<UnityEngine.Object>();
        GameObject gameObject = instanceOrAssetObject as GameObject;
        if (gameObject == null)
        {
            gameObject = (instanceOrAssetObject as Component).gameObject;
        }

        UnityEngine.Object @object = instanceOrAssetObject;
        if (!EditorUtility.IsPersistent(@object) || !includeSelfAsTarget)
        {
            @object = GetCorrespondingObjectFromSource(@object);
        }

        if (@object == null)
        {
            return list;
        }

        while (@object != null)
        {
            if (isAllDefaultOverridesComparedToOriginalSource)
            {
                GameObject gameObject2 = GetGameObject(@object);
                if (gameObject2.transform.root == gameObject2.transform)
                {
                    break;
                }
            }

            list.Add(@object);
            @object = GetCorrespondingObjectFromSource(@object);
        }

        return list;
    }

    internal static bool ProcessMultipleOverrides(GameObject prefabInstanceRoot, List<PrefabOverride> overrides, OverrideOperation operation, InteractionMode mode)
    {
        if (WarnIfInAnimationMode(operation, mode))
        {
            return false;
        }

        Dictionary<PrefabOverride, List<Component>> dictionary = new Dictionary<PrefabOverride, List<Component>>();
        List<PrefabOverride> list = new List<PrefabOverride>();
        List<PrefabOverride> list2 = new List<PrefabOverride>();
        List<PrefabOverride> list3 = new List<PrefabOverride>();
        HashSet<UnityEngine.Object> hashSet = new HashSet<UnityEngine.Object>();
        for (int i = 0; i < overrides.Count; i++)
        {
            PrefabOverride prefabOverride = overrides[i];
            if (prefabOverride == null)
            {
                continue;
            }

            bool flag = false;
            if (prefabOverride is RemovedComponent removedComponent)
            {
                List<Component> removedComponentDependencies = GetRemovedComponentDependencies(removedComponent.assetComponent, removedComponent.containingInstanceGameObject, operation);
                if (removedComponentDependencies.Count > 0)
                {
                    dictionary[prefabOverride] = removedComponentDependencies;
                    flag = true;
                }
            }

            if (prefabOverride is AddedComponent addedComponent)
            {
                List<Component> addedComponentDependencies = GetAddedComponentDependencies(addedComponent.instanceComponent, operation);
                if (addedComponentDependencies.Count > 0)
                {
                    dictionary[prefabOverride] = addedComponentDependencies;
                    flag = true;
                }
            }

            if (flag)
            {
                list3.Add(prefabOverride);
                continue;
            }

            if (prefabOverride is RemovedComponent)
            {
                list2.Add(prefabOverride);
            }
            else
            {
                list.Add(prefabOverride);
            }

            hashSet.Add(prefabOverride.GetObject());
        }

        bool flag2;
        do
        {
            flag2 = false;
            for (int num = list3.Count - 1; num >= 0; num--)
            {
                PrefabOverride prefabOverride2 = list3[num];
                List<Component> list4 = dictionary[prefabOverride2];
                bool flag3 = true;
                for (int j = 0; j < list4.Count; j++)
                {
                    if (!hashSet.Contains(list4[j]))
                    {
                        flag3 = false;
                        break;
                    }
                }

                if (flag3)
                {
                    if (prefabOverride2 is RemovedComponent)
                    {
                        list2.Add(prefabOverride2);
                    }
                    else
                    {
                        list.Add(prefabOverride2);
                    }

                    hashSet.Add(prefabOverride2.GetObject());
                    list3.RemoveAt(num);
                    flag2 = true;
                }
            }
        }
        while (flag2);
        if (list3.Count > 0)
        {
            string text = "";
            foreach (PrefabOverride item in list3)
            {
                List<Component> list5 = dictionary[item];
                foreach (Component item2 in list5)
                {
                    bool flag4 = (item is AddedComponent) ^ (operation == OverrideOperation.Revert);
                    text = text + "\n" + string.Format(flag4 ? L10n.Tr("{0} depends on {1}") : L10n.Tr("{0} is depended on by {1}"), ObjectNames.GetInspectorTitle(item.GetObject()), ObjectNames.GetInspectorTitle(item2));
                }
            }

            string text2 = null;
            string text3 = null;
            if (operation == OverrideOperation.Apply)
            {
                text3 = L10n.Tr("Can't apply selected overrides");
                text2 = L10n.Tr("Can't apply selected overrides due to dependencies with non-selected overrides:") + text;
            }
            else
            {
                text3 = L10n.Tr("Can't revert selected overrides");
                text2 = L10n.Tr("Can't revert selected overrides due to dependencies with non-selected overrides.") + text;
            }

            if (mode == InteractionMode.UserAction)
            {
                EditorUtility.DisplayDialog(text3, text2, L10n.Tr("OK"));
                return false;
            }

            throw new ArgumentException(text2);
        }

        if (operation == OverrideOperation.Apply)
        {
            if (mode == InteractionMode.UserAction)
            {
                string prefabAssetPathOfNearestInstanceRoot = GetPrefabAssetPathOfNearestInstanceRoot(prefabInstanceRoot);
                if (!PromptAndCheckoutPrefabIfNeeded(prefabAssetPathOfNearestInstanceRoot, SaveVerb.Apply))
                {
                    return false;
                }
            }

            for (int k = 0; k < list2.Count; k++)
            {
                list2[k].Apply(mode);
            }

            for (int l = 0; l < list.Count; l++)
            {
                list[l].Apply(mode);
            }
        }
        else
        {
            for (int m = 0; m < list.Count; m++)
            {
                list[m].Revert(mode);
            }

            for (int n = 0; n < list2.Count; n++)
            {
                list2[n].Revert(mode);
            }
        }

        return true;
    }

    internal static List<Component> GetAddedComponentDependencies(Component component, OverrideOperation op)
    {
        GameObject instanceGameObject = component.gameObject;
        List<Component> componentsToConsider = (from e in GetAddedComponents(instanceGameObject)
                                                select e.instanceComponent into e
                                                where e.gameObject == instanceGameObject
                                                select e).ToList();
        if (op == OverrideOperation.Apply)
        {
            return GetComponentsWhichThisDependsOn(component, componentsToConsider);
        }

        return GetComponentsWhichDependOnThis(component, componentsToConsider);
    }

    internal static List<Component> GetRemovedComponentDependencies(Component assetComponent, GameObject instanceGameObject, OverrideOperation op)
    {
        GameObject assetGameObject = assetComponent.gameObject;
        List<Component> componentsToConsider = (from e in GetRemovedComponents(instanceGameObject)
                                                select e.assetComponent into e
                                                where e.gameObject == assetGameObject
                                                select e).ToList();
        if (op == OverrideOperation.Apply)
        {
            return GetComponentsWhichDependOnThis(assetComponent, componentsToConsider);
        }

        return GetComponentsWhichThisDependsOn(assetComponent, componentsToConsider);
    }

    private static List<Component> GetComponentsWhichDependOnThis(Component component, List<Component> componentsToConsider)
    {
        List<Component> list = new List<Component>();
        Type type = component.GetType();
        for (int i = 0; i < componentsToConsider.Count; i++)
        {
            Component component2 = componentsToConsider[i];
            if (component2 == component)
            {
                continue;
            }

            object[] customAttributes = component2.GetType().GetCustomAttributes(typeof(RequireComponent), inherit: true);
            object[] array = customAttributes;
            for (int j = 0; j < array.Length; j++)
            {
                RequireComponent requireComponent = (RequireComponent)array[j];
                if ((requireComponent.m_Type0 == type || requireComponent.m_Type1 == type || requireComponent.m_Type2 == type) && !list.Contains(component2))
                {
                    list.Add(component2);
                }
            }
        }

        return list;
    }

    private static List<Component> GetComponentsWhichThisDependsOn(Component component, List<Component> componentsToConsider)
    {
        object[] customAttributes = component.GetType().GetCustomAttributes(typeof(RequireComponent), inherit: true);
        List<Component> list = new List<Component>();
        if (customAttributes.Count() == 0)
        {
            return list;
        }

        for (int i = 0; i < componentsToConsider.Count; i++)
        {
            Component component2 = componentsToConsider[i];
            if (component2 == component)
            {
                continue;
            }

            Type type = component2.GetType();
            object[] array = customAttributes;
            for (int j = 0; j < array.Length; j++)
            {
                RequireComponent requireComponent = (RequireComponent)array[j];
                if ((requireComponent.m_Type0 == type || requireComponent.m_Type1 == type || requireComponent.m_Type2 == type) && !list.Contains(component2))
                {
                    list.Add(component2);
                }
            }
        }

        return list;
    }

    [RequiredByNativeCode]
    private static void OnPrefabSavingEnded(long ticks)
    {
        TimeSpan timeSpan = new TimeSpan(ticks);
        DateTime startTime = DateTime.UtcNow.Subtract(timeSpan);
        UsabilityAnalytics.SendEvent("prefabSave", startTime, timeSpan, isBlocking: true, null);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern UnityEngine.Object InstantiatePrefab_internal_Injected(UnityEngine.Object target, ref Scene destinationScene, Transform parent);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void LoadPrefabContentsIntoPreviewScene_Injected(string prefabPath, ref Scene scene);
}


