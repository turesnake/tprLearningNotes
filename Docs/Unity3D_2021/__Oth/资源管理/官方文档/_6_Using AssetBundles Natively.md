# ===================================================== #
#         Using AssetBundles Natively (本机使用)
# ===================================================== #

本地 ab包 可使用 4 套 api;
基于 将要加载到的平台, build阶段使用的压缩模式, 这几个 api 存在不同的表现;

这些是将 ab包 加载到内存的函数;
(而不是从 ab包 将 asset 资源加载到内存的函数)


# 当然, 此页面中还包含了如何从 ab包中 加载 asset 资源的方法;


# ----------------------------------------------- #
#    -1- AssetBundle.LoadFromMemoryAsync()
# ----------------------------------------------- #

...


# ----------------------------------------------- #
#    -2- AssetBundle.LoadFromFile()
# ----------------------------------------------- #

...

如果 ab包是 未压缩的/LZ4压缩模式的, 则能将 ab包 直接加载到内存 (应该是head信息);

如果 ab包 是 LZMA 模式的, 则需要先对 ab包执行 "重压缩" 操作, 然后再将其 head 信息加载到内存中;

# Note: 
On Android devices with Unity 5.3 or older, this API will fail when trying to load AssetBundles from the Streaming Assets path. This is because the contents of that path will reside inside a compressed .jar file. Unity 5.4 and newer can use this API call with Streaming Assets just fine.
--
在 安卓平台, unity 5.3 之前的版本, 从  Streaming Assets path 中加载 ab包将导致 失败;
这是因为该路径的内容将驻留在压缩的 .jar 文件中。

unity 5.4 之后的版本已经解决此问题;


# ----------------------------------------------- #
#    -3- UnityWebRequestAssetBundle
# ----------------------------------------------- #

... 文档中有详细的应用步骤 ...
    涉及函数有:
        -- UnityWebRequestAssetBundle.GetAssetBundle()
        -- DownloadHandlerAssetBundle.GetContent()


# =========================================================================



# ----------------------------------------------- #
#    Loading AssetBundle Manifests
# ----------------------------------------------- #
Loading AssetBundle manifests can be incredibly useful. Especially when dealing with AssetBundle dependencies.

    AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
    AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    string[] dependencies = manifest.GetAllDependencies("KKK"); //Pass the name of the bundle you want the dependencies for.
    foreach(string dependency in dependencies)
    {
        AssetBundle.LoadFromFile(Path.Combine(assetBundlePath, dependency));
    }
    ---
    像普通 ab包 那样将 .manifests 文件加载到内存,
    然后从中提取出 AssetBundleManifest 类型数据;
    ---
    将 ab包 "KKK" 依赖的所有 ab包 都加载到内存中 (加载ab包的 head 信息)

# 注意:
# 我们只需把 asset 依赖的所有 ab包 加载到内存中, 
而不需要吧 asset 依赖的所有 "位于其他ab包中的 assets" 加载到内存中, unity 会自动去获得这些依赖的 assets, 并自动加载它们;



# ----------------------------------------------- #
#    Managing Loaded AssetBundles 
# ----------------------------------------------- #
   
# Addressable Assets 包提供了一套现成的系统来管理 "ab包的加载,依赖 和 assets";
unity 推荐大家直接用此包, 而不是自己编写系统;

Unity does not automatically unload Objects when they are removed from the active scene
. Asset cleanup is triggered at specific times, and it can also be triggered manually.

当 objs(猜测为资源obj) 被从当前 scene 中移除时, unity 不会自动卸载它们;
在特定的时间会触发 asset 清理工作, 当然它也可被手动调用;

# AssetBundle management 的最核心问题是
#  -1- 何时调用  AssetBundle.Unload(bool) 或 AssetBundle.UnloadAsync(bool);
#  -2- 以及该给这组函数传递 true 还是 false;

... 更多细节用法 ...

























