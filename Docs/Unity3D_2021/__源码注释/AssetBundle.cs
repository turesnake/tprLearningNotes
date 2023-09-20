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
    /*
        AssetBundles let you stream additional assets via the UnityWebRequest class and instantiate them at runtime. 
        AssetBundles are created via BuildPipeline.BuildAssetBundles()
        ---
        AssetBundles 允许你通过 UnityWebRequest class 流式地传输 其他资源 (additional assets), 并在运行时实例化它们;
        通过 BuildPipeline.BuildAssetBundles() 来创建 AssetBundles; 

        Note that bundles are not compatible between platforms. A bundle built for any of the standalone platforms can only be loaded on that platform but not others. 
        Further example, a bundle built for iOS is not compatible with Android and vice versa. One difference is shaders which are different between devices, as are textures.
        ---
        ab包 并不跨平台,  比如, shader 就不夸平台,  texture 也不夸平台(因为压缩格式不同)

    */
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

        // [Obsolete("mainAsset has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        // public Object mainAsset { get; }

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
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method CreateFromFile has been renamed to LoadFromFile (UnityUpgradable) -> LoadFromFile(*)", true)]
        // public static AssetBundle CreateFromFile(string path);

        //
        // 摘要:
        //     Asynchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method CreateFromMemory has been renamed to LoadFromMemoryAsync (UnityUpgradable) -> LoadFromMemoryAsync(*)", true)]
        // public static AssetBundleCreateRequest CreateFromMemory(byte[] binary);

        //
        // 摘要:
        //     Synchronously create an AssetBundle from a memory region.
        //
        // 参数:
        //   binary:
        //     Array of bytes with the AssetBundle data.
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method CreateFromMemoryImmediate has been renamed to LoadFromMemory (UnityUpgradable) -> LoadFromMemory(*)", true)]
        // public static AssetBundle CreateFromMemoryImmediate(byte[] binary);


        //
        // 摘要:
        //     To use when you need to get a list of all the currently loaded Asset Bundles.
        //
        // 返回结果:
        //     Returns IEnumerable<AssetBundle> of all currently loaded Asset Bundles.
        public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles();
        


        /*
            Synchronously loads an AssetBundle from a file on disk.
            从 ab包资源文件中, 加载一个 ab包信息(通常是它的head) 到内存中; 完成这步之后, 可从返回的 AssetBundle 实例中加载某个具体的 obj资源 到内存中;

            new bing:
                To use AssetBundle.LoadFromFile in Unity, you can load an asset bundle from a file on disk. 
                This API is highly efficient when loading uncompressed bundles from local storage. 
                If the bundle is uncompressed or chunk (LZ4) compressed, LoadFromFile will load the bundle directly from disk. 
                However, if the bundle is fully compressed (LZMA), it will first decompress the bundle before loading it into memory;
                ---
                就是从本地硬盘 直接读取 ab包资源;
            

            参数:
            path:
                Path of the file on disk.
            
            crc:
                An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
                then the content will be compared against the checksum before loading it, and
                give an error if it does not match.
                ---
                若向其写入 0, 则不做 crc 码的判断; 只有写入 非0值, 才会执行判断; 
            
            offset:
                An optional byte offset. This value specifies where to start reading the AssetBundle from.
            
            返回结果:
                Loaded AssetBundle object or null if failed.
        */
        public static AssetBundle LoadFromFile(string path);
        public static AssetBundle LoadFromFile(string path, uint crc);
        public static AssetBundle LoadFromFile(string path, uint crc, ulong offset);


        
        /*
            摘要:
                Asynchronously loads an AssetBundle from a file on disk.
            
            参数:
            path:
                Path of the file on disk.
            
            crc:
                An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
                then the content will be compared against the checksum before loading it, and
                give an error if it does not match.
            
            offset:
                An optional byte offset. This value specifies where to start reading the AssetBundle
                from.
            
            返回结果:
                Asynchronous create request for an AssetBundle. Use AssetBundleCreateRequest.assetBundle
                property to get an AssetBundle once it is loaded.
        */
        public static AssetBundleCreateRequest LoadFromFileAsync(string path);
        public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc);
        public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc, ulong offset);



        
        /*
            Synchronously create an AssetBundle from a memory region.
            
            参数:
            binary:
                Array of bytes with the AssetBundle data.
          
            crc:
               An optional CRC-32 checksum of the uncompressed content. If this is non-zero,
               then the content will be compared against the checksum before loading it, and
               give an error if it does not match.


           返回结果:
               Loaded AssetBundle object or null if failed.
        */
        public static AssetBundle LoadFromMemory(byte[] binary);
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
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc);
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream);
        public static AssetBundleCreateRequest LoadFromStreamAsync(Stream stream, uint crc, uint managedReadBufferSize);


        /*
            Asynchronously recompress a downloaded/stored AssetBundle from one BuildCompression to another.
            ---
            将一个 已经下载好的/存储好的 ab包, 从它的 build 压缩模式, "重压缩" 为另一种 runtime版的 BuildCompression 模式; 异步的;

            Method must be a BuildCompression whose name ends with Runtime, for example LZ4Runtime, otherwise an ArgumentException is thrown. 
            ---
            传入的 method 参数 必须为 runtime 版的 BuildCompression 类型, 否则会报错;

            When the destination BuildCompression is the same as the source, this becomes a copy operation internally, 
            and Unity does not compute a CRC of the uncompressed data. 
            Passing in a non-zero expectedCRC in this case raises a warning, and no CRC validation takes place.
            ---
            如果 重压缩格式 和 ab包原来的压缩格式是相同的, 那么本函数会变成一个 复制操作, 此时去计算 crc 值; 如果此时传入的 expectedCRC 非0, 将报warning;
        
        参数:
          inputPath:
            Path to the AssetBundle to recompress.
        
          outputPath:
            Path to the recompressed AssetBundle to be generated. Can be the same as inputPath.
        
          method:
            The compression method, level and blocksize to use during recompression. Only
            some BuildCompression types are supported (see note).
        
          expectedCRC:
            CRC of the AssetBundle to test against. Testing this requires additional file
            reading and computation. Pass in 0 to skip this check. Unity does not compute
            a CRC when the source and destination BuildCompression are the same, so no CRC
            verification takes place (see note).
            ---

          priority:
            The priority at which the recompression operation should run. This sets thread
            priority during the operation and does not effect the order in which operations
            are performed. Recompression operations run on a background worker thread.
            ---
            重压缩 会运行在一个异步的 后台线程上;
        */
        public static AssetBundleRecompressOperation RecompressAssetBundleAsync(
            string inputPath, string outputPath, BuildCompression method, uint expectedCRC = 0, ThreadPriority priority = ThreadPriority.Low
        );
        
        
        
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
        // [FreeFunctionAttribute("UnloadAllAssetBundles")]
        // public static void UnloadAllAssetBundles(bool unloadAllObjects);
        // [Obsolete("This method is deprecated.Use GetAllAssetNames() instead.", false)]
        // public string[] AllAssetNames();

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

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
        // public Object Load(string name);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
        // public Object Load<T>(string name);

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
        // public Object[] LoadAll();

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
        // public T[] LoadAll<T>() where T : Object;


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


        /*
            Loads asset with name of type T from the bundle.
            ---
            从一个 已经加载到内存中的 ab包中(通常仅加载了其 head 信息), 将目标 obj资源加载到 内存中;
            如果写入的参数有问题, 没有在 ab包中找到这个 obj资源, 则会报错, 同时返回 null;
        
            参数:
              name:
        */
        public Object LoadAsset(string name);
        public T LoadAsset<T>(string name) where T : Object;
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
            摘要:
                Unloads an AssetBundle freeing its data.


            When unloadAllLoadedObjects is false, compressed file data inside the bundle itself will be freed, but any instances of objects loaded from this bundle will remain intact. 
            After calling UnloadAsync on an AssetBundle, you cannot load any more objects from that bundle and other operations on the bundle 
            will throw InvalidOperationException.After calling UnloadAsync on an AssetBundle, 
            you cannot load any more objects from that bundle and other operations on the bundle will throw InvalidOperationException.


            When unloadAllLoadedObjects is true, all objects that were loaded from this bundle will be destroyed as well. 
            If there are GameObjects in your Scene referencing those assets, the references to them will become missing.


            !!! 建议本文档内查找: "5.1 Managing loaded Assets"


            参数为 false:
                加载到的 内存中的 ab包 会被卸载;
                但是从这个 ab包中加载出来的那些 objs 资源, 不会被卸载, 它们还可以被继续使用;
                ---
                但是这会使得这些被加载出来的 objs 和它们的 ab包 脱绑;
                如果再次加载这个 ab包, unity 不会在旧的 objs 和 新的 ab包 之间建立联系;
                如果此时, 调用 AssetBundle.LoadAsset() 从新的 ab包中加载 obj资源, 此时 unity不会意识到 内存中已经存在一份 目标obj 资源了, 而会重新加载一份, 从而造成 资源的重复;

            参数为 true:
                加载到内存中的 ab包, 以及从这个 ab包中加载出来的 objs资源, 都会被卸载掉;
                使用不当会出问题;
                ---
                但是这种使用 比 AssetBundle.Unload( false ) 更安全, 至少不会导致 obj资源的重复导入;

            参数:
            unloadAllLoadedObjects:
                Determines whether the current instances of objects loaded from the AssetBundle
                will also be unloaded.
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

