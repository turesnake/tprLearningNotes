#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;

namespace UnityEditor
{
    /*
        Asset Bundle building options.

        建造 ab包 时的选项;

        通常作为 BuildPipeline.BuildAssetBundle() or BuildPipeline.BuildAssetBundles() 的参数;


    */
    [Flags]
    public enum BuildAssetBundleOptions
    {
        
        /*
            Build assetBundle without any special option.
            --
            This bundle option uses LZMA Format compression, which is a single compressed LZMA stream of serialized data files. 
            LZMA compression requires that the entire bundle is decompressed before it’s used. 
            This results in the smallest possible file size but a slightly longer load time due to the decompression. 
            It is worth noting that when using this BuildAssetBundleOptions, in order to use any assets from the bundle the entire bundle must be uncompressed initially.
            ---
            使用 LZMA 压缩模式, 会把整个 ab资源压缩到一起,
            ---
            这个策略能让 ab包的体积尽可能地小, 但会导致 加载时解压缩的时间变长;
            ---
            当需要使用 ab包中的某个 asset 资源时, 需要先把整个 ab包的资源加载到内存, 同时解压缩它, 然后才能使用某个具体的 asset;

            Once the bundle has been decompressed, it will be recompressed on disk using LZ4 compression which doesn’t require the entire bundle 
            be decompressed before using assets from the bundle. 
            This is best used when a bundle contains assets such that to use one asset from the bundle would mean all assets are going to be loaded. 
            Packaging all assets for a character or scene are some examples of bundles that might use this.

            Using LZMA compression is only recommended for the initial download of an AssetBundle from an "off-site host"(异地主机) due to the smaller file size. 
            LZMA compressed asset bundles loaded through "UnityWebRequestAssetBundle" are automatically recompressed to LZ4 compression and cached on the local file system. 
            If you download and store the bundle through other means, you can recompress it with the AssetBundle.RecompressAssetBundleAsync API.
            ---
            一旦这个 ab包被解压缩, 它会在硬盘上 再次用 LZ4 模式压缩起来; (LZ4模式中, 每个文件单独压缩)

            LZMA 模式特别适合: 使用 ab包中的某个 asset, 而这个 asset 又依赖这个 ab包中的其他几乎所有 assets; 所有需要事先将整个 ab包都加载到内存中;
            ---
            只推荐在如下模式中使用 LZMA:
                当从 异地主机 第一次下载一个 ab包时, 为了让 ab包体积最小化, 此时可将 ab包制作成 LZMA 模式, 
                使用 "UnityWebRequestAssetBundle" api 下载的 LZMA 压缩过的 ab包 会被自动 重新压缩为 LZ4模式, 然后存储在 本地文件系统中;
                如果你是通过其他方式 下载和存储 ab包的, 可使用 AssetBundle.RecompressAssetBundleAsync() 来重压缩它;
        */
        None = 0,

        /*
            Don't compress the data when creating the AssetBundle.
            Uncompressed bundles are faster to build and load, but, because they are larger, take longer to download. Uncompressed AssetBundles are 16-byte aligned.
            ---
            未压缩版 build 和 加载 耗时更短;  但是因为尺寸变大了, 需要更多 下载时间;
            未压缩版数据 16-bytes 对齐;
        */
        UncompressedAssetBundle = 1,

        
        //     Includes all dependencies.
        //  文档中没看到...
        CollectDependencies = 2,
        
        
        //
        // 摘要:
        //     Forces inclusion of the entire asset.
        CompleteAssets = 4,


        /*
            Do not include type information within the AssetBundle.
            Specifying this flag will make an AssetBundle susceptible(易受影响) to script or Unity version changes, 
            but will make the file smaller and a bit faster to load. 
            This flag affects only AssetBundles for platforms that have type information included by default. 
            Type information must be present for Web platforms, therefore Unity will reject to build an AssetBundle if you specify this flag 
            when building for BuildTarget.WebPlayer, for example.
            ----
            不将数据的 类型信息 写入 ab包;
            启用此配置后, ab包将受到 脚本 和 unity 版本的影响; 但会使文件变小, 加速变快;
            ...
        */
        DisableWriteTypeTree = 8,



        /* 
            Deterministic: 确定性的

            Builds an assetbundle using a hash for the id of the object stored in the assetbundle.
            ---
            使用 "存储在 ab包 中的" objs 的 id 的 hash值 构建 ab包;

            This allows you to rebuild an assetbundle and reference assets in it directly. 
            When rebuilding the assetbundle the objects in it are guaranteed to have the same id after rebuilding the assetbundle. 
            Due to it being a 32 bit hash space, if you have a lot of objects in the asset bundle it will increase the potential for hash conflicts. 
            Unity will give an error and not build the asset bundle in that case.
            ---
            当重构一个 ab包时, 它的 objs 的 id 将被保证还是原来的那个;
            如果 ab包内的资源数量太多, hash 值可能会发生冲突; 

            The hash is based on the GUID of the asset and the local id of the object in the asset. 
            ---
            hash 的生成 基于 guid 和 local id;

            DeterministicAssetBundle are also slower to load from than normal asset bundles, 
            this is because the threaded background loading API usually expects objects to be ordered in a way that makes reading reduce seeking. 
            With DeterministicAssetBundles that is not possible.
            ---
            DeterministicAssetBundle 加载速度会变慢; 这是因为 线程后台加载api 希望 ab包中的 objs 能以 "读取时减少查找的形式" 来排序;
            但 DeterministicAssetBundles 无法实现这一点;

            Note: This feature is always enabled. -- 此特效始终被开启;
        */ 
        DeterministicAssetBundle = 16,


        /* 
            Force rebuild the assetBundles.
            This allows you to rebuild the assetBundle even if none of the included assets have changed.
            ---
            就算 ab包中没有资源被更新, 但只要启用了此 flag, 则打包函数 一定会 rebuild ab包;
        */
        ForceRebuildAssetBundle = 32,


        /*
            Ignore the type tree changes when doing the "incremental build check" (增量构建检查).
            ---
            在执行 增量构建检查 时, 忽略掉 类型树 的变化信息;

            With this flag set, if the included assets haven't change but type trees have changed, the target assetBundle will not be rebuilt.
            ---
            使用此 flag 后, 如果 assets 没有改变, 但 type-trees 信息发生了变化, 则调用 build 函数时, 目标ab包 不会被重构;
        */
        IgnoreTypeTreeChanges = 64,



        /*
            Append the hash to the assetBundle name.
            This allows you to append the hash to the assetBundle name. 
            ---
        */
        AppendHashToAssetBundleName = 128,

        
        /*
            Use chunk-based LZ4 compression when creating the AssetBundle.
            This allows realtime decompression when reading data from the AssetBundle. 
            AssetBundles created with this option are stored in compressed form after download (both in disk cache or memory).
            ---
            当从这种 ab包 读取数据时, 将执行 实时解压 (猜测是从 ab包 载入 obj资源 时)
            这种 ab资源 在从服务器下载下来之后, 将以 压缩的形式 存储在 硬盘 或 内存;
        */
        ChunkBasedCompression = 256,


        /* 
            严格模式;

            Do not allow the build to succeed if any errors are reporting during it.

            Without this flag, non-fatal errors(非致命error) - such as a failure to compile a shader for a particular platform - 
            will not cause the build to fail, but may result in incorrect behaviour at runtime.
            ---
            只要在这个 ab包的 build 阶段出现任何 error, 都会导致本次 build 终止;
            比如, 如果一个 shader 在编译到目标平台时发生错误, 这属于 "非致命error", 平时不会导致 ab包的 build 失败, 但开启此模式后就会;
        */
        StrictMode = 512,


        /*
            Do a dry run build.
            This allows you to do a dry run build for the AssetBundles but not actually build them. 
            With this option enabled, BuildPipeline.BuildAssetBundles() still returns an AssetBundleManifest object 
            which contains valid AssetBundle dependencies and hashes.
            ---
            执行 试验性 build;

            执行 build 过程, 最后还从 BuildPipeline.BuildAssetBundles() 中返回一个 AssetBundleManifest 对象, 里面包含有效的 ab以来信息 和 hash值;
            但是并没有真的生成一个 ab包 文件;
        */
        DryRunBuild = 1024,



        /*
            Disables Asset Bundle LoadAsset by file name.

            Asset Bundles by default have three ways to look up the same asset: (1)full asset path, (2)asset file name, and (3)asset file name with extension. 
            The full path is serialized into Asset Bundles, while file name and file name with extension are generated when an Asset Bundle is loaded from file.
            ---
            通常, ab包 有三种方式去查找一个 asset 资源:
                -1- asset 的完整path;              -- 被序列化进 ab包;
                -2- asset 的文件name, 不带扩展名;   -- 当从文件中加载一个 ab包 时, 才被生成; 
                -3- asset 的文件name, 带扩展名;     -- 当从文件中加载一个 ab包 时, 才被生成; 


            Example: 
                -- "Assets/Prefabs/Player.prefab", 
                -- "Player"
                -- "Player.prefab"

            This option will set a flag on Asset Bundles to prevent creating the asset file name lookup. 
            This option saves runtime memory and loading performance for asset bundles.
            ---
            使用此 flag 的 build函数, 构造出来的 ab包, 将在 "从文件加载到内存" 中时, 不再自动生成 asset name lookup 系统; 
            也就是对应的上述第二种 查找表: "name 不带扩展名";

            以节省运行时内存 和 加载 ab包 时的性能负担;
        */
        DisableLoadAssetByFileName = 4096,

        
        /*
            Disables Asset Bundle LoadAsset by file name with extension.
            --
            和上面的 "DisableLoadAssetByFileName" 相似, 不过这次是不自动生成: -3- asset 的文件name, 带扩展名 的 lookup表;
        */
        DisableLoadAssetByFileNameWithExtension = 8192,

        
        /*
            Removes the Unity Version number in the Archive File & Serialized File headers during the build.
            ---
            在 build ab包期间, 将 "Unity Version number" 从 Archive File & Serialized File headers 中移除掉;
        */
        AssetBundleStripUnityVersion = 32768,


        //     Enable asset bundle protection.
        //   文档里没看到描述...
        EnableProtection = 65536
    }
}

