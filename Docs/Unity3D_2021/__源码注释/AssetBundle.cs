#region 程序集 UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AssetBundleModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngineInternal;

namespace UnityEngine
{
    //
    // 摘要:
    //     AssetBundles let you stream additional assets via the UnityWebRequest class and
    //     instantiate them at runtime. AssetBundles are created via BuildPipeline.BuildAssetBundle.
    [ExcludeFromPreset]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleLoadFromManagedStreamAsyncOperation.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
    [NativeHeaderAttribute("Runtime/Scripting/ScriptingExportUtility.h")]
    [NativeHeaderAttribute("Runtime/Scripting/ScriptingObjectWithIntPtrField.h")]
    [NativeHeaderAttribute("Runtime/Scripting/ScriptingUtility.h")]
    [NativeHeaderAttribute("AssetBundleScriptingClasses.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleSaveAndLoadHelper.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleUtility.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleLoadAssetUtility.h")]
    [NativeHeaderAttribute("Runtime/VirtualFileSystem/ArchiveFileSystem/Protection/ArchiveStorageDecrypt.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleLoadFromFileAsyncOperation.h")]
    [NativeHeaderAttribute("Modules/AssetBundle/Public/AssetBundleLoadFromMemoryAsyncOperation.h")]
    public class AssetBundle : Object
    {
        //
        // 摘要:
        //     Controls the size of the shared AssetBundle loading cache. Default value is 1MB.
        public static uint memoryBudgetKB { get; set; }
        [Obsolete("mainAsset has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public Object mainAsset { get; }
        //
        // 摘要:
        //     Return true if the AssetBundle is a streamed Scene AssetBundle.
        public bool isStreamedSceneAssetBundle { get; }

        //
        // 摘要:
        //     Loads an asset bundle from a disk.
        //
        // 参数:
        //   path:
        //     Path of the file on disk See Also: UnityWebRequestAssetBundle.GetAssetBundle,
        //     DownloadHandlerAssetBundle.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method CreateFromFile has been renamed to LoadFromFile (UnityUpgradable) -> LoadFromFile(*)", true)]
        public static AssetBundle CreateFromFile(string path);
        //
        // 摘要:
        //     Asynchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method CreateFromMemory has been renamed to LoadFromMemoryAsync (UnityUpgradable) -> LoadFromMemoryAsync(*)", true)]
        public static AssetBundleCreateRequest CreateFromMemory(byte[] binary);
        //
        // 摘要:
        //     Synchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        //     Array of bytes with the AssetBundle data.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method CreateFromMemoryImmediate has been renamed to LoadFromMemory (UnityUpgradable) -> LoadFromMemory(*)", true)]
        public static AssetBundle CreateFromMemoryImmediate(byte[] binary);
        //
        // 摘要:
        //     To use when you need to get a list of all the currently loaded Asset Bundles.
        //
        // 返回结果:
        //     Returns IEnumerable<AssetBundle> of all currently loaded Asset Bundles.
        public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles();
        public static AssetBundle LoadFromFile(string path);
        public static AssetBundle LoadFromFile(string path, uint crc);
        //
        // 摘要:
        //     Synchronously loads an AssetBundle from a file on disk.
        //
        // 参数:
        //   path:
        //     Path of the file on disk.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
        //     then the content will be compared against the checksum before loading it, and
        //     give an error if it does not match.
        //
        //   offset:
        //     An optional byte offset. This value specifies where to start reading the AssetBundle
        //     from.
        //
        // 返回结果:
        //     Loaded AssetBundle object or null if failed.
        public static AssetBundle LoadFromFile(string path, uint crc, ulong offset);
        public static AssetBundleCreateRequest LoadFromFileAsync(string path);
        public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc);
        //
        // 摘要:
        //     Asynchronously loads an AssetBundle from a file on disk.
        //
        // 参数:
        //   path:
        //     Path of the file on disk.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
        //     then the content will be compared against the checksum before loading it, and
        //     give an error if it does not match.
        //
        //   offset:
        //     An optional byte offset. This value specifies where to start reading the AssetBundle
        //     from.
        //
        // 返回结果:
        //     Asynchronous create request for an AssetBundle. Use AssetBundleCreateRequest.assetBundle
        //     property to get an AssetBundle once it is loaded.
        public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc, ulong offset);
        public static AssetBundle LoadFromMemory(byte[] binary);
        //
        // 摘要:
        //     Synchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        //     Array of bytes with the AssetBundle data.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
        //     then the content will be compared against the checksum before loading it, and
        //     give an error if it does not match.
        //
        // 返回结果:
        //     Loaded AssetBundle object or null if failed.
        public static AssetBundle LoadFromMemory(byte[] binary, uint crc);
        //
        // 摘要:
        //     Asynchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        //     Array of bytes with the AssetBundle data.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
        //     then the content will be compared against the checksum before loading it, and
        //     give an error if it does not match.
        //
        // 返回结果:
        //     Asynchronous create request for an AssetBundle. Use AssetBundleCreateRequest.assetBundle
        //     property to get an AssetBundle once it is loaded.
        public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary, uint crc);
        public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary);
        //
        // 摘要:
        //     Synchronously loads an AssetBundle from a managed Stream.
        //
        // 参数:
        //   stream:
        //     The managed Stream object. Unity calls Read(), Seek() and the Length property
        //     on this object to load the AssetBundle data.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content.
        //
        //   managedReadBufferSize:
        //     You can use this to override the size of the read buffer Unity uses while loading
        //     data. The default size is 32KB.
        //
        // 返回结果:
        //     The loaded AssetBundle object or null when the object fails to load.
        public static AssetBundle LoadFromStream(Stream stream, uint crc, uint managedReadBufferSize);
        public static AssetBundle LoadFromStream(Stream stream, uint crc);
        public static AssetBundle LoadFromStream(Stream stream);
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc);
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream);
        //
        // 摘要:
        //     Asynchronously loads an AssetBundle from a managed Stream.
        //
        // 参数:
        //   stream:
        //     The managed Stream object. Unity calls Read(), Seek() and the Length property
        //     on this object to load the AssetBundle data.
        //
        //   crc:
        //     An optional CRC-32 checksum of the uncompressed content.
        //
        //   managedReadBufferSize:
        //     You can use this to override the size of the read buffer Unity uses while loading
        //     data. The default size is 32KB.
        //
        // 返回结果:
        //     Asynchronous create request for an AssetBundle. Use AssetBundleCreateRequest.assetBundle
        //     property to get an AssetBundle once it is loaded.
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc, uint managedReadBufferSize);
        //
        // 摘要:
        //     Asynchronously recompress a downloaded/stored AssetBundle from one BuildCompression
        //     to another.
        //
        // 参数:
        //   inputPath:
        //     Path to the AssetBundle to recompress.
        //
        //   outputPath:
        //     Path to the recompressed AssetBundle to be generated. Can be the same as inputPath.
        //
        //   method:
        //     The compression method, level and blocksize to use during recompression. Only
        //     some BuildCompression types are supported (see note).
        //
        //   expectedCRC:
        //     CRC of the AssetBundle to test against. Testing this requires additional file
        //     reading and computation. Pass in 0 to skip this check. Unity does not compute
        //     a CRC when the source and destination BuildCompression are the same, so no CRC
        //     verification takes place (see note).
        //
        //   priority:
        //     The priority at which the recompression operation should run. This sets thread
        //     priority during the operation and does not effect the order in which operations
        //     are performed. Recompression operations run on a background worker thread.
        public static AssetBundleRecompressOperation RecompressAssetBundleAsync(string inputPath, string outputPath, BuildCompression method, uint expectedCRC = 0, ThreadPriority priority = ThreadPriority.Low);
        //
        // 摘要:
        //     Set the 16-bytes key for AssetBundle Decryption. Set NULL will remove the key
        //     from memory.
        //
        // 参数:
        //   password:
        [FreeFunctionAttribute("SetAssetBundleDecryptKey")]
        public static void SetAssetBundleDecryptKey(string password);
        //
        // 摘要:
        //     Unloads all currently loaded AssetBundles.
        //
        // 参数:
        //   unloadAllObjects:
        //     Determines whether the current instances of objects loaded from AssetBundles
        //     will also be unloaded.
        [FreeFunctionAttribute("UnloadAllAssetBundles")]
        public static void UnloadAllAssetBundles(bool unloadAllObjects);
        [Obsolete("This method is deprecated.Use GetAllAssetNames() instead.", false)]
        public string[] AllAssetNames();
        //
        // 摘要:
        //     Check if an AssetBundle contains a specific object.
        //
        // 参数:
        //   name:
        [NativeMethodAttribute("Contains")]
        public bool Contains(string name);
        //
        // 摘要:
        //     Return all asset names in the AssetBundle.
        [NativeMethodAttribute("GetAllAssetNames")]
        public string[] GetAllAssetNames();
        //
        // 摘要:
        //     Return all the Scene asset paths (paths to *.unity assets) in the AssetBundle.
        [NativeMethodAttribute("GetAllScenePaths")]
        public string[] GetAllScenePaths();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
        public Object Load(string name);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
        public Object Load<T>(string name);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
        public Object[] LoadAll();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
        public T[] LoadAll<T>() where T : Object;
        //
        // 摘要:
        //     Loads all assets contained in the asset bundle that inherit from type T.
        public Object[] LoadAllAssets();
        public T[] LoadAllAssets<T>() where T : Object;
        //
        // 摘要:
        //     Loads all assets contained in the asset bundle that inherit from type.
        //
        // 参数:
        //   type:
        public Object[] LoadAllAssets(Type type);
        //
        // 摘要:
        //     Loads all assets contained in the asset bundle that inherit from T asynchronously.
        public AssetBundleRequest LoadAllAssetsAsync();
        //
        // 摘要:
        //     Loads all assets contained in the asset bundle that inherit from type asynchronously.
        //
        // 参数:
        //   type:
        public AssetBundleRequest LoadAllAssetsAsync(Type type);
        public AssetBundleRequest LoadAllAssetsAsync<T>();
        //
        // 摘要:
        //     Loads asset with name of type T from the bundle.
        //
        // 参数:
        //   name:
        public Object LoadAsset(string name);
        public T LoadAsset<T>(string name) where T : Object;
        //
        // 摘要:
        //     Loads asset with name of a given type from the bundle.
        //
        // 参数:
        //   name:
        //
        //   type:
        [TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
        public Object LoadAsset(string name, Type type);
        //
        // 摘要:
        //     Asynchronously loads asset with name of a given type from the bundle.
        //
        // 参数:
        //   name:
        //
        //   type:
        public AssetBundleRequest LoadAssetAsync(string name, Type type);
        public AssetBundleRequest LoadAssetAsync<T>(string name);
        //
        // 摘要:
        //     Asynchronously loads asset with name of a given T from the bundle.
        //
        // 参数:
        //   name:
        public AssetBundleRequest LoadAssetAsync(string name);
        //
        // 摘要:
        //     Loads asset and sub assets with name of a given type from the bundle.
        //
        // 参数:
        //   name:
        //
        //   type:
        public Object[] LoadAssetWithSubAssets(string name, Type type);
        public T[] LoadAssetWithSubAssets<T>(string name) where T : Object;
        //
        // 摘要:
        //     Loads asset and sub assets with name of type T from the bundle.
        //
        // 参数:
        //   name:
        public Object[] LoadAssetWithSubAssets(string name);
        //
        // 摘要:
        //     Loads asset with sub assets with name of a given type from the bundle asynchronously.
        //
        // 参数:
        //   name:
        //
        //   type:
        public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type);
        public AssetBundleRequest LoadAssetWithSubAssetsAsync<T>(string name);
        //
        // 摘要:
        //     Loads asset with sub assets with name of type T from the bundle asynchronously.
        //
        // 参数:
        //   name:
        public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name);


        /*
        // 摘要:
        //     Unloads an AssetBundle freeing its data.
        //
        // 参数:
        //   unloadAllLoadedObjects:
        //     Determines whether the current instances of objects loaded from the AssetBundle
        //     will also be unloaded.
        */
        [NativeMethodAttribute("Unload")]
        [NativeThrowsAttribute]
        public void Unload(bool unloadAllLoadedObjects);


        //
        // 摘要:
        //     Unloads assets in the bundle.
        //
        // 参数:
        //   unloadAllLoadedObjects:
        //
        // 返回结果:
        //     Asynchronous unload request for an AssetBundle.
        [NativeMethodAttribute("UnloadAsync")]
        [NativeThrowsAttribute]
        public AsyncOperation UnloadAsync(bool unloadAllLoadedObjects);
    }
}

