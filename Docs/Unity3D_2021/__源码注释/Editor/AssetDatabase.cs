#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEditor
{
    //
    // 摘要:
    //     An Interface for accessing assets and performing operations on assets.
    [NativeHeaderAttribute("Modules/AssetDatabase/Editor/Public/AssetDatabasePreventExecution.h")]
    [NativeHeaderAttribute("Editor/Src/PackageUtility.h")]
    [NativeHeaderAttribute("Editor/Src/VersionControl/VC_bindings.h")]
    [NativeHeaderAttribute("Runtime/Core/PreventExecutionInState.h")]
    [NativeHeaderAttribute("Editor/Src/Application/ApplicationFunctions.h")]
    [NativeHeaderAttribute("Modules/AssetDatabase/Editor/Public/AssetDatabase.h")]
    [NativeHeaderAttribute("Modules/AssetDatabase/Editor/Public/AssetDatabaseUtility.h")]
    [NativeHeaderAttribute("Modules/AssetDatabase/Editor/ScriptBindings/AssetDatabase.bindings.h")]
    [StaticAccessorAttribute("AssetDatabaseBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
    public sealed class AssetDatabase
    {
        //
        // 摘要:
        //     Callback raised whenever a package import successfully completes that lists the
        //     items selected to be imported.
        public static Action<string[]> onImportPackageItemsCompleted;

        public AssetDatabase();

        //
        // 摘要:
        //     Changes during Refresh if anything has changed that can invalidate any artifact.
        public static uint GlobalArtifactDependencyVersion { get; }
        //
        // 摘要:
        //     The desired number of processes to use when importing assets, during an asset
        //     database refresh.
        public static int DesiredWorkerCount { get; set; }
        //
        // 摘要:
        //     Gets the refresh import mode currently in use by the asset database.
        public static RefreshImportMode ActiveRefreshImportMode { get; set; }
        //
        // 摘要:
        //     Changes whenever a new artifact is added to the artifact database.
        public static uint GlobalArtifactProcessedVersion { get; }

        public static event Action<CacheServerConnectionChangedParameters> cacheServerConnectionChanged;
        public static event ImportPackageFailedCallback importPackageFailed;
        public static event ImportPackageCallback importPackageCancelled;
        public static event ImportPackageCallback importPackageCompleted;
        public static event ImportPackageCallback importPackageStarted;

        //
        // 摘要:
        //     Adds objectToAdd to an existing asset identified by assetObject.
        //
        // 参数:
        //   objectToAdd:
        //
        //   assetObject:
        public static void AddObjectToAsset(UnityEngine.Object objectToAdd, UnityEngine.Object assetObject);
        //
        // 摘要:
        //     Adds objectToAdd to an existing asset at path.
        //
        // 参数:
        //   objectToAdd:
        //     Object to add to the existing asset.
        //
        //   path:
        //     Filesystem path to the asset.
        [NativeThrowsAttribute]
        public static void AddObjectToAsset([NotNullAttribute("ArgumentNullException")] UnityEngine.Object objectToAdd, string path);
        //
        // 摘要:
        //     Decrements an internal counter which Unity uses to determine whether to allow
        //     automatic AssetDatabase refreshing behavior.
        [FreeFunctionAttribute("ApplicationAllowAutoRefresh")]
        public static void AllowAutoRefresh();
        //
        // 摘要:
        //     Get the GUID for the asset at path.
        //
        // 参数:
        //   path:
        //     Filesystem path for the asset.
        //
        //   options:
        //     Specifies whether this method should return a GUID for recently deleted assets.
        //     The default value is AssetPathToGUIDOptions.IncludeRecentlyDeletedAssets.
        //
        // 返回结果:
        //     GUID.
        public static string AssetPathToGUID(string path, [UnityEngine.Internal.DefaultValue("AssetPathToGUIDOptions.IncludeRecentlyDeletedAssets")] AssetPathToGUIDOptions options);
        //
        // 摘要:
        //     Get the GUID for the asset at path.
        //
        // 参数:
        //   path:
        //     Filesystem path for the asset.
        //
        //   options:
        //     Specifies whether this method should return a GUID for recently deleted assets.
        //     The default value is AssetPathToGUIDOptions.IncludeRecentlyDeletedAssets.
        //
        // 返回结果:
        //     GUID.
        public static string AssetPathToGUID(string path);
        //
        // 摘要:
        //     Checks the availability of the Cache Server.
        //
        // 参数:
        //   ip:
        //     The IP address of the Cache Server.
        //
        //   port:
        //     The Port number of the Cache Server.
        //
        // 返回结果:
        //     Returns true when Editor can connect to the Cache Server. Returns false otherwise.
        [FreeFunctionAttribute("AcceleratorClientCanConnectTo")]
        public static bool CanConnectToCacheServer(string ip, ushort port);
        //
        // 摘要:
        //     Checks if Unity can open an asset in the Editor.
        //
        // 参数:
        //   instanceID:
        //     The instance ID of the asset.
        //
        // 返回结果:
        //     Returns true if Unity can successfully open the asset in the Editor, otherwise
        //     returns false.
        [FreeFunctionAttribute("::CanOpenAssetInEditor")]
        public static bool CanOpenAssetInEditor(int instanceID);
        //
        // 摘要:
        //     Query whether an Asset file can be opened for editing in version control and
        //     is not exclusively locked by another user or otherwise unavailable.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being available for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered available for edit by the selected version control
        //     system.
        public static bool CanOpenForEdit(string assetOrMetaFilePath, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        public static void CanOpenForEdit(string[] assetOrMetaFilePaths, List<string> outNotEditablePaths, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusQueryOptions = StatusQueryOptions.UseCachedIfPossible);
        //
        // 摘要:
        //     Query whether an Asset file can be opened for editing in version control and
        //     is not exclusively locked by another user or otherwise unavailable.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being available for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered available for edit by the selected version control
        //     system.
        [ExcludeFromDocs]
        public static bool CanOpenForEdit(UnityEngine.Object assetObject);
        //
        // 摘要:
        //     Query whether an Asset file can be opened for editing in version control and
        //     is not exclusively locked by another user or otherwise unavailable.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being available for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered available for edit by the selected version control
        //     system.
        public static bool CanOpenForEdit(UnityEngine.Object assetObject, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        //
        // 摘要:
        //     Query whether an Asset file can be opened for editing in version control and
        //     is not exclusively locked by another user or otherwise unavailable.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being available for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered available for edit by the selected version control
        //     system.
        [ExcludeFromDocs]
        public static bool CanOpenForEdit(string assetOrMetaFilePath);
        [ExcludeFromDocs]
        public static bool CanOpenForEdit(UnityEngine.Object assetObject, out string message);
        public static bool CanOpenForEdit(UnityEngine.Object assetObject, out string message, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        public static bool CanOpenForEdit(string assetOrMetaFilePath, out string message, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        [ExcludeFromDocs]
        public static bool CanOpenForEdit(string assetOrMetaFilePath, out string message);
        //
        // 摘要:
        //     Clears the importer override for the asset.
        //
        // 参数:
        //   path:
        //     Asset path.
        [FreeFunctionAttribute("AssetDatabase::ClearImporterOverride")]
        public static void ClearImporterOverride(string path);
        //
        // 摘要:
        //     Removes all labels attached to an asset.
        //
        // 参数:
        //   obj:
        public static void ClearLabels(UnityEngine.Object obj);
        //
        // 摘要:
        //     Closes an active cache server connection. If no connection is active, then it
        //     does nothing.
        [FreeFunctionAttribute("AcceleratorClientCloseConnection")]
        public static void CloseCacheServerConnection();
        //
        // 摘要:
        //     Is object an asset?
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool Contains(UnityEngine.Object obj);
        //
        // 摘要:
        //     Is object an asset?
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool Contains(int instanceID);
        //
        // 摘要:
        //     Duplicates the asset at path and stores it at newPath.
        //
        // 参数:
        //   path:
        //     Filesystem path of the source asset.
        //
        //   newPath:
        //     Filesystem path of the new asset to create.
        //
        // 返回结果:
        //     Returns true if the copy operation is successful or false if part of the process
        //     fails.
        public static bool CopyAsset(string path, string newPath);
        //
        // 摘要:
        //     Creates a new native Unity asset.
        //
        // 参数:
        //   asset:
        //     Object to use in creating the asset.
        //
        //   path:
        //     Filesystem path for the new asset.
        [NativeThrowsAttribute]
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kGatheringDependenciesFromSourceFile, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be created during gathering of import dependencies")]
        public static void CreateAsset([NotNullAttribute("ArgumentNullException")] UnityEngine.Object asset, string path);
        //
        // 摘要:
        //     Creates a new folder, in the specified parent folder. The parent folder string
        //     must start with the "Assets" folder, and all folders within the parent folder
        //     string must already exist. For example, when specifying "AssetsParentFolder1Parentfolder2/",
        //     the new folder will be created in "ParentFolder2" only if ParentFolder1 and ParentFolder2
        //     already exist.
        //
        // 参数:
        //   parentFolder:
        //     The path to the parent folder. Must start with "Assets/".
        //
        //   newFolderName:
        //     The name of the new folder.
        //
        // 返回结果:
        //     The GUID of the newly created folder, if the folder was created successfully.
        //     Otherwise returns an empty string.
        public static string CreateFolder(string parentFolder, string newFolderName);
        //
        // 摘要:
        //     Deletes the specified asset or folder.
        //
        // 参数:
        //   path:
        //     Project relative path of the asset or folder to be deleted.
        //
        // 返回结果:
        //     Returns true if the asset has been successfully removed, false if it doesn't
        //     exist or couldn't be removed.
        public static bool DeleteAsset(string path);
        public static bool DeleteAssets(string[] paths, List<string> outFailedPaths);
        //
        // 摘要:
        //     Increments an internal counter which Unity uses to determine whether to allow
        //     automatic AssetDatabase refreshing behavior.
        [FreeFunctionAttribute("ApplicationDisallowAutoRefresh")]
        public static void DisallowAutoRefresh();
        //
        // 摘要:
        //     Exports the assets identified by assetPathNames to a unitypackage file in fileName.
        //
        // 参数:
        //   assetPathNames:
        //
        //   fileName:
        //
        //   flags:
        //
        //   assetPathName:
        public static void ExportPackage(string assetPathName, string fileName);
        //
        // 摘要:
        //     Exports the assets identified by assetPathNames to a unitypackage file in fileName.
        //
        // 参数:
        //   assetPathNames:
        //
        //   fileName:
        //
        //   flags:
        //
        //   assetPathName:
        public static void ExportPackage(string assetPathName, string fileName, ExportPackageOptions flags);
        //
        // 摘要:
        //     Exports the assets identified by assetPathNames to a unitypackage file in fileName.
        //
        // 参数:
        //   assetPathNames:
        //
        //   fileName:
        //
        //   flags:
        //
        //   assetPathName:
        [NativeThrowsAttribute]
        public static void ExportPackage(string[] assetPathNames, string fileName, [UnityEngine.Internal.DefaultValue("ExportPackageOptions.Default")] ExportPackageOptions flags);
        //
        // 摘要:
        //     Exports the assets identified by assetPathNames to a unitypackage file in fileName.
        //
        // 参数:
        //   assetPathNames:
        //
        //   fileName:
        //
        //   flags:
        //
        //   assetPathName:
        [ExcludeFromDocs]
        public static void ExportPackage(string[] assetPathNames, string fileName);
        //
        // 摘要:
        //     Creates an external Asset from an object (such as a Material) by extracting it
        //     from within an imported asset (such as an FBX file).
        //
        // 参数:
        //   asset:
        //     The sub-asset to extract.
        //
        //   newPath:
        //     The file path of the new Asset.
        //
        // 返回结果:
        //     An empty string if Unity has successfully extracted the Asset, or an error message
        //     if not.
        [NativeThrowsAttribute]
        public static string ExtractAsset(UnityEngine.Object asset, string newPath);
        //
        // 摘要:
        //     Search the asset database using the search filter string.
        //
        // 参数:
        //   filter:
        //     The filter string can contain search data. See below for details about this string.
        //
        //   searchInFolders:
        //     The folders where the search will start.
        //
        // 返回结果:
        //     Array of matching asset. Note that GUIDs will be returned. If no matching assets
        //     were found, returns empty array.
        public static string[] FindAssets(string filter, string[] searchInFolders);
        //
        // 摘要:
        //     Search the asset database using the search filter string.
        //
        // 参数:
        //   filter:
        //     The filter string can contain search data. See below for details about this string.
        //
        //   searchInFolders:
        //     The folders where the search will start.
        //
        // 返回结果:
        //     Array of matching asset. Note that GUIDs will be returned. If no matching assets
        //     were found, returns empty array.
        public static string[] FindAssets(string filter);
        public static void ForceReserializeAssets(IEnumerable<string> assetPaths, ForceReserializeAssetsOptions options = ForceReserializeAssetsOptions.ReserializeAssetsAndMetadata);
        //
        // 摘要:
        //     Forcibly load and re-serialize the given assets, flushing any outstanding data
        //     changes to disk.
        //
        // 参数:
        //   assetPaths:
        //     The paths to the assets that should be reserialized. If omitted, will reserialize
        //     all assets in the project.
        //
        //   options:
        //     Specify whether you want to reserialize the assets themselves, their .meta files,
        //     or both. If omitted, defaults to both.
        public static void ForceReserializeAssets();
        //
        // 摘要:
        //     Forces the Editor to use the desired amount of worker processes. Unity will either
        //     spawn new worker processes or shut down idle worker processes to reach the desired
        //     number.
        [FreeFunctionAttribute("AssetDatabase::ForceToDesiredWorkerCount")]
        public static void ForceToDesiredWorkerCount();
        //
        // 摘要:
        //     Creates a new unique path for an asset.
        //
        // 参数:
        //   path:
        public static string GenerateUniqueAssetPath(string path);
        //
        // 摘要:
        //     Return all the AssetBundle names in the asset database.
        //
        // 返回结果:
        //     Array of asset bundle names.
        public static string[] GetAllAssetBundleNames();
        public static string[] GetAllAssetPaths();
        //
        // 摘要:
        //     Given an assetBundleName, returns the list of AssetBundles that it depends on.
        //
        // 参数:
        //   assetBundleName:
        //     The name of the AssetBundle for which dependencies are required.
        //
        //   recursive:
        //     If false, returns only AssetBundles which are direct dependencies of the input;
        //     if true, includes all indirect dependencies of the input.
        //
        // 返回结果:
        //     The names of all AssetBundles that the input depends on.
        public static string[] GetAssetBundleDependencies(string assetBundleName, bool recursive);
        //
        // 摘要:
        //     Returns the hash of all the dependencies of an asset.
        //
        // 参数:
        //   path:
        //     Path to the asset.
        //
        //   guid:
        //     GUID of the asset.
        //
        // 返回结果:
        //     Aggregate hash.
        public static Hash128 GetAssetDependencyHash(string path);
        //
        // 摘要:
        //     Returns the hash of all the dependencies of an asset.
        //
        // 参数:
        //   path:
        //     Path to the asset.
        //
        //   guid:
        //     GUID of the asset.
        //
        // 返回结果:
        //     Aggregate hash.
        public static Hash128 GetAssetDependencyHash(GUID guid);
        //
        // 摘要:
        //     Returns the path name relative to the project folder where the asset is stored.
        //
        // 参数:
        //   assetObject:
        [FreeFunctionAttribute("::GetAssetOrScenePath")]
        public static string GetAssetOrScenePath(UnityEngine.Object assetObject);
        //
        // 摘要:
        //     Returns the path name relative to the project folder where the asset is stored.
        //
        // 参数:
        //   instanceID:
        //     The instance ID of the asset.
        //
        //   assetObject:
        //     A reference to the asset.
        //
        // 返回结果:
        //     The asset path name, or null, or an empty string if the asset does not exist.
        public static string GetAssetPath(UnityEngine.Object assetObject);


        /*
            摘要:
                Returns the path name relative to the project folder where the asset is stored.

                !!! 如在 editor 脚本中:
                var selectedPath = AssetDatabase.GetAssetPath( Selection.activeObject.GetInstanceID() );
                得到:
                    selectedPath = Assets/000_tpr/40_fbx_optimize/cube001.fbx  -- 当选中一个资源文件时
                    selectedPath = Assets/000_tpr/40_fbx_optimize/fbxs         -- 当选中一个目录时

                此时可继续得到 full path:

                    string fullPath = Path.Combine( Application.dataPath, selectedPath ); // 注意, 此处用的结合符是 "\\", 而参数 path 中则用了 "/"
                    fullPath = fullPath.Replace("/", "\\");


            
            参数:
            instanceID:
                The instance ID of the asset.
            
            assetObject:
                A reference to the asset.
            
            返回结果:
                The asset path name, or null, or an empty string if the asset does not exist.
        */
        public static string GetAssetPath(int instanceID);
        //
        // 摘要:
        //     Gets the path to the asset file associated with a text .meta file.
        //
        // 参数:
        //   path:
        [FreeFunctionAttribute("AssetDatabase::AssetPathFromTextMetaFilePath")]
        public static string GetAssetPathFromTextMetaFilePath(string path);
        //
        // 摘要:
        //     Returns an array containing the paths of all assets marked with the specified
        //     Asset Bundle name.
        //
        // 参数:
        //   assetBundleName:
        public static string[] GetAssetPathsFromAssetBundle(string assetBundleName);
        //
        // 摘要:
        //     Get the Asset paths for all Assets tagged with assetBundleName and named assetName.
        //
        // 参数:
        //   assetBundleName:
        //
        //   assetName:
        public static string[] GetAssetPathsFromAssetBundleAndAssetName(string assetBundleName, string assetName);
        //
        // 摘要:
        //     Gets the importer types associated with a given Asset type.
        //
        // 参数:
        //   path:
        //     The Asset path.
        //
        // 返回结果:
        //     Returns an array of importer types that can handle the specified Asset.
        [FreeFunctionAttribute("AssetDatabase::GetAvailableImporterTypes")]
        public static Type[] GetAvailableImporterTypes(string path);
        [NativeThrowsAttribute]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public static UnityEngine.Object GetBuiltinExtraResource(Type type, string path);
        public static T GetBuiltinExtraResource<T>(string path) where T : UnityEngine.Object;
        //
        // 摘要:
        //     Retrieves an icon for the asset at the given asset path.
        //
        // 参数:
        //   path:
        public static Texture GetCachedIcon(string path);
        //
        // 摘要:
        //     Gets the IP address of the Cache Server in Editor Settings.
        //
        // 返回结果:
        //     Returns the IP address of the Cache Server in Editor Settings. Returns empty
        //     string if IP address is not set in Editor settings.
        [FreeFunctionAttribute]
        public static string GetCacheServerAddress();
        //
        // 摘要:
        //     Gets the Cache Server Download option from Editor Settings.
        //
        // 返回结果:
        //     Returns true when Download from the Cache Server is enabled. Returns false otherwise.
        [FreeFunctionAttribute("AssetDatabase::GetCacheServerEnableDownload")]
        public static bool GetCacheServerEnableDownload();
        //
        // 摘要:
        //     Gets the Cache Server Upload option from Editor Settings.
        //
        // 返回结果:
        //     Returns true when Upload to the Cache Server is enabled. Returns false otherwise.
        [FreeFunctionAttribute("AssetDatabase::GetCacheServerEnableUpload")]
        public static bool GetCacheServerEnableUpload();
        //
        // 摘要:
        //     Gets the Cache Server Namespace prefix set in Editor Settings.
        //
        // 返回结果:
        //     Returns the Namespace prefix for the Cache Server.
        [FreeFunctionAttribute("AssetDatabase::GetCacheServerNamespacePrefix")]
        public static string GetCacheServerNamespacePrefix();
        //
        // 摘要:
        //     Gets the Port number of the Cache Server in Editor Settings.
        //
        // 返回结果:
        //     Returns the Port number of the Cache Server in Editor Settings. Returns 0 if
        //     Port number is not set in Editor Settings.
        [FreeFunctionAttribute]
        public static ushort GetCacheServerPort();
        //
        // 摘要:
        //     Gets the IP address of the Cache Server currently in use by the Editor.
        //
        // 返回结果:
        //     Returns a string representation of the current Cache Server IP address.
        [FreeFunctionAttribute]
        public static string GetCurrentCacheServerIp();


        //
        // 摘要:
        //     Returns an array of all the assets that are dependencies of the asset at the
        //     specified pathName. Note: GetDependencies() gets the Assets that are referenced
        //     by other Assets. For example, a Scene could contain many GameObjects with a Material
        //     attached to them. In this case, GetDependencies() will return the path to the
        //     Material Assets, but not the GameObjects as those are not Assets on your disk.
        //
        // 参数:
        //   pathName:
        //     The path to the asset for which dependencies are required.
        //
        //   recursive:
        //     Controls whether this method recursively checks and returns all dependencies
        //     including indirect dependencies (when set to true), or whether it only returns
        //     direct dependencies (when set to false).
        //
        // 返回结果:
        //     The paths of all assets that the input depends on.
        public static string[] GetDependencies(string pathName);
        public static string[] GetDependencies(string pathName, bool recursive);


        //
        // 摘要:
        //     Returns an array of the paths of assets that are dependencies of all the assets
        //     in the list of pathNames that you provide. Note: GetDependencies() gets the Assets
        //     that are referenced by other Assets. For example, a Scene could contain many
        //     GameObjects with a Material attached to them. In this case, GetDependencies()
        //     will return the path to the Material Assets, but not the GameObjects as those
        //     are not Assets on your disk.
        //
        // 参数:
        //   pathNames:
        //     The path to the assets for which dependencies are required.
        //
        //   recursive:
        //     Controls whether this method recursively checks and returns all dependencies
        //     including indirect dependencies (when set to true), or whether it only returns
        //     direct dependencies (when set to false).
        //
        // 返回结果:
        //     The paths of all assets that the input depends on.
        public static string[] GetDependencies(string[] pathNames);
        public static string[] GetDependencies(string[] pathNames, bool recursive);


        //
        // 摘要:
        //     Returns the name of the AssetBundle that a given asset belongs to.
        //
        // 参数:
        //   assetPath:
        //     The asset's path.
        //
        // 返回结果:
        //     Returns the name of the AssetBundle that a given asset belongs to. See the method
        //     description for more details.
        [NativeThrowsAttribute]
        public static string GetImplicitAssetBundleName(string assetPath);
        //
        // 摘要:
        //     Returns the name of the AssetBundle Variant that a given asset belongs to.
        //
        // 参数:
        //   assetPath:
        //     The asset's path.
        //
        // 返回结果:
        //     Returns the name of the AssetBundle Variant that a given asset belongs to. See
        //     the method description for more details.
        [NativeThrowsAttribute]
        public static string GetImplicitAssetBundleVariantName(string assetPath);
        //
        // 摘要:
        //     Returns the type of the override importer.
        //
        // 参数:
        //   path:
        //     Asset path.
        //
        // 返回结果:
        //     Importer type.
        [FreeFunctionAttribute("AssetDatabase::GetImporterOverride")]
        public static Type GetImporterOverride(string path);
        //
        // 摘要:
        //     Returns all labels attached to a given asset.
        //
        // 参数:
        //   obj:
        public static string[] GetLabels(UnityEngine.Object obj);
        public static string[] GetLabels(GUID guid);
        //
        // 摘要:
        //     Returns the type of the main asset object at assetPath.
        //
        // 参数:
        //   assetPath:
        //     Filesystem path of the asset to load.
        public static Type GetMainAssetTypeAtPath(string assetPath);
        //
        // 摘要:
        //     Given a path to a directory in the Assets folder, relative to the project folder,
        //     this method will return an array of all its subdirectories.
        //
        // 参数:
        //   path:
        [NativeThrowsAttribute]
        public static string[] GetSubFolders([NotNullAttribute("ArgumentNullException")] string path);



        // [Obsolete("GetTextMetaDataPathFromAssetPath has been renamed to GetTextMetaFilePathFromAssetPath (UnityUpgradable) -> GetTextMetaFilePathFromAssetPath(*)")]
        // public static string GetTextMetaDataPathFromAssetPath(string path);


        //
        // 摘要:
        //     Gets the path to the text .meta file associated with an asset.
        //
        // 参数:
        //   path:
        //     The path to the asset.
        //
        // 返回结果:
        //     The path to the .meta text file or an empty string if the file does not exist.
        [FreeFunctionAttribute("AssetDatabase::TextMetaFilePathFromAssetPath")]
        public static string GetTextMetaFilePathFromAssetPath(string path);
        //
        // 摘要:
        //     Gets an object's type from an Asset path and a local file identifier.
        //
        // 参数:
        //   assetPath:
        //     The Asset's path.
        //
        //   localIdentifierInFile:
        //     The object's local file identifier.
        //
        // 返回结果:
        //     The object's type.
        public static Type GetTypeFromPathAndFileID(string assetPath, long localIdentifierInFile);
        //
        // 摘要:
        //     Return all the unused assetBundle names in the asset database.
        public static string[] GetUnusedAssetBundleNames();
        //
        // 摘要:
        //     Get the GUID for the asset at path.
        //
        // 参数:
        //   path:
        //     Filesystem path for the asset. All paths are relative to the project folder.
        //
        // 返回结果:
        //     The GUID of the asset. An all-zero GUID denotes an invalid asset path.
        public static GUID GUIDFromAssetPath(string path);
        //
        // 摘要:
        //     Gets the corresponding asset path for the supplied GUID, or an empty string if
        //     the GUID can't be found.
        //
        // 参数:
        //   guid:
        //     The GUID of an asset.
        //
        // 返回结果:
        //     Path of the asset relative to the project folder.
        public static string GUIDToAssetPath(GUID guid);
        //
        // 摘要:
        //     Gets the corresponding asset path for the supplied GUID, or an empty string if
        //     the GUID can't be found.
        //
        // 参数:
        //   guid:
        //     The GUID of an asset.
        //
        // 返回结果:
        //     Path of the asset relative to the project folder.
        public static string GUIDToAssetPath(string guid);
        //
        // 摘要:
        //     Import asset at path.
        //
        // 参数:
        //   path:
        //
        //   options:
        [ExcludeFromDocs]
        public static void ImportAsset(string path);
        //
        // 摘要:
        //     Import asset at path.
        //
        // 参数:
        //   path:
        //
        //   options:
        public static void ImportAsset(string path, [UnityEngine.Internal.DefaultValue("ImportAssetOptions.Default")] ImportAssetOptions options);
        //
        // 摘要:
        //     Imports package at packagePath into the current project.
        //
        // 参数:
        //   packagePath:
        //
        //   interactive:
        public static void ImportPackage(string packagePath, bool interactive);
        [FreeFunctionAttribute("AssetDatabase::IsAssetImportProcess")]
        public static bool IsAssetImportWorkerProcess();
        //
        // 摘要:
        //     Checks whether the Cache Server is enabled in Project Settings.
        //
        // 返回结果:
        //     Returns true when the Cache Server is enabled. Returns false otherwise.
        [FreeFunctionAttribute("AssetDatabase::IsCacheServerEnabled")]
        public static bool IsCacheServerEnabled();
        //
        // 摘要:
        //     Checks connection status of the Cache Server.
        //
        // 返回结果:
        //     Returns true when Editor is connected to the Cache Server. Returns false otherwise.
        [FreeFunctionAttribute("AcceleratorClientIsConnected")]
        public static bool IsConnectedToCacheServer();
        //
        // 摘要:
        //     Reports whether Directory Monitoring is enabled.
        //
        // 返回结果:
        //     Returns true when Directory Monitoring is enabled. Returns false otherwise.
        [FreeFunctionAttribute("AssetDatabase::IsDirectoryMonitoringEnabled")]
        public static bool IsDirectoryMonitoringEnabled();
        //
        // 摘要:
        //     Determines whether the Asset is a foreign Asset.
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool IsForeignAsset(int instanceID);
        //
        // 摘要:
        //     Determines whether the Asset is a foreign Asset.
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool IsForeignAsset(UnityEngine.Object obj);
        //
        // 摘要:
        //     Is asset a main asset in the project window?
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        [FreeFunctionAttribute("AssetDatabase::IsMainAsset")]
        public static bool IsMainAsset(int instanceID);
        //
        // 摘要:
        //     Is asset a main asset in the project window?
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool IsMainAsset(UnityEngine.Object obj);
        //
        // 摘要:
        //     Returns true if the main asset object at assetPath is loaded in memory.
        //
        // 参数:
        //   assetPath:
        //     Filesystem path of the asset to load.
        public static bool IsMainAssetAtPathLoaded(string assetPath);
        public static bool IsMetaFileOpenForEdit(UnityEngine.Object assetObject, out string message, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        [ExcludeFromDocs]
        public static bool IsMetaFileOpenForEdit(UnityEngine.Object assetObject, out string message);
        //
        // 摘要:
        //     Query whether an asset's metadata (.meta) file is open for edit in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose metadata status you wish to query.
        //
        //   message:
        //     Returns a reason for the asset metadata not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset's metadata is considered open for edit by the selected version
        //     control system.
        public static bool IsMetaFileOpenForEdit(UnityEngine.Object assetObject, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        //
        // 摘要:
        //     Query whether an asset's metadata (.meta) file is open for edit in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose metadata status you wish to query.
        //
        //   message:
        //     Returns a reason for the asset metadata not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset's metadata is considered open for edit by the selected version
        //     control system.
        [ExcludeFromDocs]
        public static bool IsMetaFileOpenForEdit(UnityEngine.Object assetObject);
        //
        // 摘要:
        //     Determines whether the Asset is a native Asset.
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool IsNativeAsset(int instanceID);
        //
        // 摘要:
        //     Determines whether the Asset is a native Asset.
        //
        // 参数:
        //   obj:
        //
        //   instanceID:
        public static bool IsNativeAsset(UnityEngine.Object obj);
        //
        // 摘要:
        //     Query whether an Asset file is open for editing in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered open for edit by the selected version control
        //     system.
        public static bool IsOpenForEdit(string assetOrMetaFilePath, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        public static bool IsOpenForEdit(string assetOrMetaFilePath, out string message, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        [ExcludeFromDocs]
        public static bool IsOpenForEdit(string assetOrMetaFilePath, out string message);
        public static bool IsOpenForEdit(UnityEngine.Object assetObject, out string message, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        [ExcludeFromDocs]
        public static bool IsOpenForEdit(UnityEngine.Object assetObject, out string message);
        //
        // 摘要:
        //     Query whether an Asset file is open for editing in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered open for edit by the selected version control
        //     system.
        [ExcludeFromDocs]
        public static bool IsOpenForEdit(string assetOrMetaFilePath);
        //
        // 摘要:
        //     Query whether an Asset file is open for editing in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered open for edit by the selected version control
        //     system.
        [ExcludeFromDocs]
        public static bool IsOpenForEdit(UnityEngine.Object assetObject);
        //
        // 摘要:
        //     Query whether an Asset file is open for editing in version control.
        //
        // 参数:
        //   assetObject:
        //     Object representing the asset whose status you wish to query.
        //
        //   assetOrMetaFilePath:
        //     Path to the asset file or its .meta file on disk, relative to project folder.
        //
        //   message:
        //     Returns a reason for the asset not being open for edit.
        //
        //   statusOptions:
        //     Options for how the version control system should be queried. These options can
        //     effect the speed and accuracy of the query. Default is StatusQueryOptions.UseCachedIfPossible.
        //
        // 返回结果:
        //     True if the asset is considered open for edit by the selected version control
        //     system.
        public static bool IsOpenForEdit(UnityEngine.Object assetObject, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusOptions);
        public static void IsOpenForEdit(string[] assetOrMetaFilePaths, List<string> outNotEditablePaths, [UnityEngine.Internal.DefaultValue("StatusQueryOptions.UseCachedIfPossible")] StatusQueryOptions statusQueryOptions = StatusQueryOptions.UseCachedIfPossible);
        //
        // 摘要:
        //     Does the asset form part of another asset?
        //
        // 参数:
        //   obj:
        //     The asset Object to query.
        //
        //   instanceID:
        //     Instance ID of the asset Object to query.
        [FreeFunctionAttribute("AssetDatabase::IsSubAsset")]
        public static bool IsSubAsset(int instanceID);
        //
        // 摘要:
        //     Does the asset form part of another asset?
        //
        // 参数:
        //   obj:
        //     The asset Object to query.
        //
        //   instanceID:
        //     Instance ID of the asset Object to query.
        public static bool IsSubAsset(UnityEngine.Object obj);
        //
        // 摘要:
        //     Given a path to a folder, returns true if it exists, false otherwise.
        //
        // 参数:
        //   path:
        //     The path to the folder.
        //
        // 返回结果:
        //     Returns true if the folder exists.
        [FreeFunctionAttribute("AssetDatabase::IsFolderAsset")]
        public static bool IsValidFolder(string path);
        //
        // 摘要:
        //     Returns all sub Assets at assetPath.
        //
        // 参数:
        //   assetPath:
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kGatheringDependenciesFromSourceFile, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be loaded while dependencies are being gathered, as these assets may not have been imported yet.")]
        public static UnityEngine.Object[] LoadAllAssetRepresentationsAtPath(string assetPath);


        /*
            Returns the first asset object of type type at given path assetPath.

            ----
            感觉并不是加载一个 ab包资源, 而只是加载一个常规类型的资源, 比如一个 .png;
            

            Some asset files may contain multiple objects. (such as a Maya file which may contain multiple Meshes and GameObjects). 
            All paths are relative to the project folder, for example: "Assets/MyTextures/hello.png".
            
            Note:
                The assetPath parameter is not case sensitive. --- 参数 path 大小写不敏感; 
                ALL asset names and paths in Unity use forward slashes, even on Windows. --- 都是用 '/'

            参数:
            assetPath:
                Path of the asset to load.
            type:
                Data type of the asset.
            
            返回结果:
                The asset matching the parameters.
                This returns only an asset object that is visible in the Project view. If the asset is not found LoadAssetAtPath returns Null.
                ---
                调用本函数只返回一个 "项目视角 可见的" asset 对象, 若找不到, 返回 null
        */
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kGatheringDependenciesFromSourceFile, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be loaded while dependencies are being gathered, as these assets may not have been imported yet.")]
        public static UnityEngine.Object[] LoadAllAssetsAtPath(string assetPath);
        public static T LoadAssetAtPath<T>(string assetPath) where T : UnityEngine.Object;
        
        [NativeThrowsAttribute]
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kGatheringDependenciesFromSourceFile, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be loaded while dependencies are being gathered, as these assets may not have been imported yet.")]
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kDomainBackup, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be loaded while domain backup is running, as this will change the underlying state.")]
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
        public static UnityEngine.Object LoadAssetAtPath(string assetPath, Type type);





        //
        // 摘要:
        //     Returns the main asset object at assetPath. The "main" Asset is the Asset at
        //     the root of a hierarchy (such as a Maya file which may contain multiples meshes
        //     and GameObjects).
        //
        // 参数:
        //   assetPath:
        //     Filesystem path of the asset to load.
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kGatheringDependenciesFromSourceFile, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Assets may not be loaded while dependencies are being gathered, as these assets may not have been imported yet.")]
        public static UnityEngine.Object LoadMainAssetAtPath(string assetPath);
        //
        // 摘要:
        //     Makes a file open for editing in version control.
        //
        // 参数:
        //   path:
        //     Specifies the path to a file relative to the project root.
        //
        // 返回结果:
        //     true if Unity successfully made the file editable in the version control system.
        //     Otherwise, returns false.
        public static bool MakeEditable(string path);
        public static bool MakeEditable(string[] paths, string prompt = null, List<string> outNotEditablePaths = null);
        //
        // 摘要:
        //     Move an asset file (or folder) from one folder to another.
        //
        // 参数:
        //   oldPath:
        //     The path where the asset currently resides.
        //
        //   newPath:
        //     The path which the asset should be moved to.
        //
        // 返回结果:
        //     An empty string if the asset has been successfully moved, otherwise an error
        //     message.
        public static string MoveAsset(string oldPath, string newPath);
        public static bool MoveAssetsToTrash(string[] paths, List<string> outFailedPaths);
        //
        // 摘要:
        //     Moves the specified asset or folder to the OS trash.
        //
        // 参数:
        //   path:
        //     Project relative path of the asset or folder to be deleted.
        //
        // 返回结果:
        //     Returns true if the asset has been successfully removed, false if it doesn't
        //     exist or couldn't be removed.
        public static bool MoveAssetToTrash(string path);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        [FreeFunctionAttribute("::OpenAsset")]
        public static bool OpenAsset(int instanceID, int lineNumber, int columnNumber);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        public static bool OpenAsset(int instanceID, [UnityEngine.Internal.DefaultValue("-1")] int lineNumber);
        //
        // 摘要:
        //     Opens the asset(s) with associated application(s).
        //
        // 参数:
        //   objects:
        public static bool OpenAsset(UnityEngine.Object[] objects);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        public static bool OpenAsset(UnityEngine.Object target, int lineNumber, int columnNumber);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        [ExcludeFromDocs]
        public static bool OpenAsset(int instanceID);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        public static bool OpenAsset(UnityEngine.Object target, [UnityEngine.Internal.DefaultValue("-1")] int lineNumber);
        //
        // 摘要:
        //     Opens the asset with associated application.
        //
        // 参数:
        //   instanceID:
        //
        //   lineNumber:
        //
        //   columnNumber:
        //
        //   target:
        [ExcludeFromDocs]
        public static bool OpenAsset(UnityEngine.Object target);



        
        /*
            摘要:
                Import any changed assets.
                This will import any assets that have changed their content modification data or have been added-removed to the project folder.
                This method implicitly triggers an asset garbage collection (see Resources.UnloadUnusedAssets).

            
            参数:
            options:
        */
        [ExcludeFromDocs]
        public static void Refresh();
        public static void Refresh([UnityEngine.Internal.DefaultValue("ImportAssetOptions.Default")] ImportAssetOptions options);



        // [Obsolete("Please use AssetDatabase.Refresh instead", true)]public static void RefreshDelayed(ImportAssetOptions options);
        // [Obsolete("Please use AssetDatabase.Refresh instead", true)]public static void RefreshDelayed();


        //
        // 摘要:
        //     Apply pending Editor Settings changes to the Asset pipeline.
        [FreeFunctionAttribute]
        public static void RefreshSettings();
        //
        // 摘要:
        //     Allows you to register a custom dependency that Assets can be dependent on. If
        //     you register a custom dependency, and specify that an Asset is dependent on it,
        //     then the Asset will get re-imported if the custom dependency changes.
        //
        // 参数:
        //   dependency:
        //     Name of dependency. You can use any name you like, but because these names are
        //     global across all your Assets, it can be useful to use a naming convention (eg
        //     a path-based naming system) to avoid clashes with other custom dependency names.
        //
        //   hashOfValue:
        //     A Hash128 value of the dependency.
        [FreeFunctionAttribute("AssetDatabase::RegisterCustomDependency")]
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kPreventCustomDependencyChanges, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Custom dependencies can only be removed when the assetdatabase is not importing.")]
        public static void RegisterCustomDependency(string dependency, Hash128 hashOfValue);
        //
        // 摘要:
        //     Calling this function will release file handles internally cached by Unity. This
        //     allows modifying asset or meta files safely thus avoiding potential file sharing
        //     IO errors.
        [FreeFunctionAttribute("AssetDatabase::UnloadAllFileStreams")]
        public static void ReleaseCachedFileHandles();
        //
        // 摘要:
        //     Remove the assetBundle name from the asset database. The forceRemove flag is
        //     used to indicate if you want to remove it even it's in use.
        //
        // 参数:
        //   assetBundleName:
        //     The assetBundle name you want to remove.
        //
        //   forceRemove:
        //     Flag to indicate if you want to remove the assetBundle name even it's in use.
        [FreeFunctionAttribute("AssetDatabase::RemoveAssetBundleByName")]
        public static bool RemoveAssetBundleName(string assetBundleName, bool forceRemove);
        //
        // 摘要:
        //     Removes object from its asset (See Also: AssetDatabase.AddObjectToAsset).
        //
        // 参数:
        //   objectToRemove:
        [FreeFunctionAttribute("AssetDatabase::RemoveObjectFromAsset")]
        public static void RemoveObjectFromAsset([NotNullAttribute("ArgumentNullException")] UnityEngine.Object objectToRemove);
        //
        // 摘要:
        //     Remove all the unused assetBundle names in the asset database.
        [FreeFunctionAttribute("AssetDatabase::RemoveUnusedAssetBundleNames")]
        public static void RemoveUnusedAssetBundleNames();
        //
        // 摘要:
        //     Rename an asset file.
        //
        // 参数:
        //   pathName:
        //     The path where the asset currently resides.
        //
        //   newName:
        //     The new name which should be given to the asset.
        //
        // 返回结果:
        //     An empty string, if the asset has been successfully renamed, otherwise an error
        //     message.
        public static string RenameAsset(string pathName, string newName);
        //
        // 摘要:
        //     Resets the internal cache server connection reconnect timer values. The default
        //     delay timer value is 1 second, and the max delay value is 5 minutes. Everytime
        //     a connection attempt fails it will double the delay timer value, until a maximum
        //     time of the max value.
        [FreeFunctionAttribute("AcceleratorClientResetReconnectTimer")]
        public static void ResetCacheServerReconnectTimer();
        //
        // 摘要:
        //     Writes all unsaved changes to the specified asset to disk.
        //
        // 参数:
        //   obj:
        //     The asset object to be saved, if dirty.
        //
        //   guid:
        //     The guid of the asset to be saved, if dirty.
        [FreeFunctionAttribute("AssetDatabase::SaveAssetIfDirty")]
        public static void SaveAssetIfDirty(GUID guid);
        //
        // 摘要:
        //     Writes all unsaved changes to the specified asset to disk.
        //
        // 参数:
        //   obj:
        //     The asset object to be saved, if dirty.
        //
        //   guid:
        //     The guid of the asset to be saved, if dirty.
        public static void SaveAssetIfDirty(UnityEngine.Object obj);
        //
        // 摘要:
        //     Writes all unsaved asset changes to disk.
        [FreeFunctionAttribute("AssetDatabase::SaveAssets")]
        public static void SaveAssets();
        public static void SetImporterOverride<T>(string path) where T : ScriptedImporter;
        //
        // 摘要:
        //     Replaces that list of labels on an asset.
        //
        // 参数:
        //   obj:
        //
        //   labels:
        public static void SetLabels(UnityEngine.Object obj, string[] labels);
        //
        // 摘要:
        //     Specifies which object in the asset file should become the main object after
        //     the next import.
        //
        // 参数:
        //   mainObject:
        //     The object to become the main object.
        //
        //   assetPath:
        //     Path to the asset file.
        [NativeThrowsAttribute]
        public static void SetMainObject([NotNullAttribute("ArgumentNullException")] UnityEngine.Object mainObject, string assetPath);
        //
        // 摘要:
        //     Starts importing Assets into the Asset Database. This lets you group several
        //     Asset imports together into one larger import. Note: Calling AssetDatabase.StartAssetEditing()
        //     places the Asset Database in a state that will prevent imports until AssetDatabase.StopAssetEditing()
        //     is called. This means that if an exception occurs between the two function calls,
        //     the AssetDatabase will be unresponsive. Therefore, it is highly recommended that
        //     you place calls to AssetDatabase.StartAssetEditing() and AssetDatabase.StopAssetEditing()
        //     inside either a try..catch block, or a try..finally block as needed.
        [FreeFunctionAttribute("AssetDatabase::StartAssetImporting")]
        public static void StartAssetEditing();
        //
        // 摘要:
        //     Stops importing Assets into the Asset Database. This lets you group several Asset
        //     imports together into one larger import. Note: Calling AssetDatabase.StartAssetEditing()
        //     places the Asset Database in a state that will prevent imports until AssetDatabase.StopAssetEditing()
        //     is called. This means that if an exception occurs between the two function calls,
        //     the AssetDatabase will be unresponsive. Therefore, it is highly recommended that
        //     you place calls to AssetDatabase.StartAssetEditing() and AssetDatabase.StopAssetEditing()
        //     inside either a try..catch block, or a try..finally block as needed.
        [FreeFunctionAttribute("AssetDatabase::StopAssetImporting")]
        public static void StopAssetEditing();
        public static bool TryGetGUIDAndLocalFileIdentifier<T>(LazyLoadReference<T> assetRef, out string guid, out long localId) where T : UnityEngine.Object;
        public static bool TryGetGUIDAndLocalFileIdentifier(int instanceID, out string guid, out long localId);
        public static bool TryGetGUIDAndLocalFileIdentifier(UnityEngine.Object obj, out string guid, out long localId);


        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Please use the overload of this function that uses a long data type for the localId parameter, because this version can return a localID that has overflowed. This can happen when called on objects that are part of a Prefab.", true)]
        // public static bool TryGetGUIDAndLocalFileIdentifier(int instanceID, out string guid, out int localId);
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Please use the overload of this function that uses a long data type for the localId parameter, because this version can return a localID that has overflowed. This can happen when called on objects that are part of a Prefab.", true)]
        // public static bool TryGetGUIDAndLocalFileIdentifier(UnityEngine.Object obj, out string guid, out int localId);


        //
        // 摘要:
        //     Removes custom dependencies that match the prefixFilter.
        //
        // 参数:
        //   prefixFilter:
        //     Prefix filter for the custom dependencies to unregister.
        //
        // 返回结果:
        //     Number of custom dependencies removed.
        [FreeFunctionAttribute("AssetDatabase::UnregisterCustomDependencyPrefixFilter")]
        [PreventExecutionInStateAttribute(UnityEditor.AssetDatabasePreventExecution.kPreventCustomDependencyChanges, UnityEngine.Bindings.PreventExecutionSeverity.PreventExecution_ManagedException, "Custom dependencies can only be removed when the assetdatabase is not importing.")]
        public static uint UnregisterCustomDependencyPrefixFilter(string prefixFilter);
        //
        // 摘要:
        //     Checks if an asset file can be moved from one folder to another. (Without actually
        //     moving the file).
        //
        // 参数:
        //   oldPath:
        //     The path where the asset currently resides.
        //
        //   newPath:
        //     The path which the asset should be moved to.
        //
        // 返回结果:
        //     An empty string if the asset can be moved, otherwise an error message.
        public static string ValidateMoveAsset(string oldPath, string newPath);
        //
        // 摘要:
        //     Writes the import settings to disk.
        //
        // 参数:
        //   path:
        public static bool WriteImportSettingsIfDirty(string path);


        // [Obsolete("Method GetAssetBundleNames has been deprecated. Use GetAllAssetBundleNames instead.")]
        // public string[] GetAssetBundleNames();

        //
        // 摘要:
        //     Options for controlling the Editor's use of parallel processes when it imports
        //     assets during an asset database refresh.
        public enum RefreshImportMode
        {
            //
            // 摘要:
            //     All assets are imported in the Editor process, and sequentially.
            InProcess = 0,
            //
            // 摘要:
            //     As many assets as possible are imported in parallel, in import worker processes.
            //     Importer queues and dependencies reported by the importer are respected.
            OutOfProcessPerQueue = 1
        }

        //
        // 摘要:
        //     Delegate to be called from AssetDatabase.ImportPackage callbacks. packageName
        //     is the name of the package that raised the callback.
        //
        // 参数:
        //   packageName:
        public delegate void ImportPackageCallback(string packageName);
        //
        // 摘要:
        //     Delegate to be called from AssetDatabase.ImportPackage callbacks. packageName
        //     is the name of the package that raised the callback. errorMessage is the reason
        //     for the failure.
        //
        // 参数:
        //   packageName:
        //
        //   errorMessage:
        public delegate void ImportPackageFailedCallback(string packageName, string errorMessage);
    }
}

