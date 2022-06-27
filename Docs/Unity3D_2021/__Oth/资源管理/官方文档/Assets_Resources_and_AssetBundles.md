# ================================================================ #
#              Assets_Resources_and_AssetBundles
# ================================================================ #


大部分源自:
https://learn.unity.com/tutorial/assets-resources-and-assetbundles?_ga=2.131386636.20088139.1655605355-597440040.1625213567#


# =================================== #
#               GUID
# =================================== #

# Globally Unique Identifier, 全局唯一标识符;
这个概念和通用, 以下仅介绍 unity 中的 guid;

当一个项目资源 asset, 比如一个 texture 文件, 被导入 unity 项目时, unity 会自动为它新建一个 .meta 文件;
然后在这个 .meta 文件中, 会自动新建一个 guid, 比如这样:

    guid: d14234ab73cee47468a8184b025e73ed

这个 guid 是这个资源的全局 唯一id; (安装某些说法, 这个 guid 甚至在不同的项目里也是不同的)

# --------------------------------------- #
# -1- 当这个资源被移动到别的目录下时, guid 不会被改变;


# -2- 如果手动从目录中删除一个 asset 的 guid, 然后再次唤醒 unity, 然后 unity 新建的 guid 还是原来那个值;

这是因为:

The Unity Editor has a map of specific file paths to known File GUIDs. A map entry is recorded whenever an Asset is loaded or imported. The map entry links the Asset's specific path to the Asset's File GUID. If the Unity Editor is open when a .meta file goes missing and the Asset's path does not change, the Editor can ensure that the Asset retains the same File GUID.
-----
unity editor 自己维护一个 map, 绑定一个 asset 的 path 和它的 guid; 如果这个 asset 的 .meta 文件丢失了, 但这个 asset 文件本身的 path 不变, 那么 unity就能确定这个 asset 没发生变化, 那么就会再次为它新建一个 .meta 文件, 并分配原来的那个 guid;

If the .meta file is lost while the Unity Editor is closed, or the Asset's path changes without the .meta file moving along with the Asset, then all references to Objects within that Asset will be broken.
-----
但是当 unity editor 处于关闭状态时 .meta 文件发生丢失, 
或者 asset 文件自己修改了 path, 而且没有带上原来的 .meta 文件一起修改, 那么之前的引用就都被破坏掉了;


# -------------------------- #
# 何时 需要手动修改 guid ?
(没太看明白...)
-1-
    有时两个项目使用了同一个资源, 然后每个项目都为其设置了独立的, 两个不同的 guid, 但却指向同一个资源文件, 这可能会造成问题;
-2-
    有时我们手动复制了一个项目, 连带着这个项目里的所有 .meta 文件也复制了一份, 此时这两个项目里的 同名资源的 guid 是相同的;
    而这可能不是我们想看到的; (我们希望两个项目里的资源, 拥有各自独立的 guid)


# -------------------------- #
# 如何修改 guid ?
打开 .meta 文件, 手动改写几位即可, 不过这只能改写这一个文件的 guid;

如果你想改写一阵组 guid, 或者一个资源文件连带所有和它关联的资源文件的 guid, 可用工具 GUID Regenerator.;

# -------------------------- #
# 可使用 AssetDatabase.GUIDToAssetPath( guid ) 来获得一个 guid 对应的资源的 path;
    看起来好像很有效;
    但是 AssetDatabase 仅在 editor 中起效;




# =================================== #
#          Local ID
# =================================== #

# 指的是一个 object 在一个 asset 资源内部的 局部id;

比如一个 material 文件, 用 文本编辑器打开它, 可以看到:

    --- !u!21 &2100000

这个 & 符号后面的就是 local id;

由于一个 asset 内可以包含数个 objects, 所有想要定位一个 object, 需要同时用上 guid (定位这个 asset) 和 object 的 local id;





# =================================== #
#         Instance ID
# =================================== #
运行时倚重 guid 的成本有点高, 因为 guid 之间的比较的运算的负担很重;
在运行时, unity 维护一个 cache, 来讲改用了 Instance ID 系统; 
在运行时, 此系统 维护一个 cache, 能将 guid + local id 转换为一种 整型值: Instance ID;

在内部, 这个 cache 被称为 PersistentManager;

并在新对象注册到 cache 时以简单的、单调递增的顺序分配 (id);

cache 维护一个 map, 一边连接 Instance ID, guid 和 local id, 另一边连接当前内存中的 obj 实例本体; 这使得 UnityEngine.Objects 之间可以方便地相互关联;

解析一个 instance id 引用, 可快速地获得对应的 已经加载到内存中的 obj实例;
万一这个实例尚未被加载到内存中, 那也能通过关联的 guid 和 local id 快速获得相关 assets,
然后 unity 在 运行时即刻 加载这个 obj;

----
在最开始, Instance ID cache 的初始化需要 (1)项目在初始阶段就需要的 objs (也就是 built Scenes 中引用到的那些 ); (2) Resources 目录中包含的所有 objs;

随后, 更多的 cache entry 会在运行时被添加到 cache 中, 比如从 AssetBundles 中加载的 objs 
(举例: 当在脚本中调用: var myTexture = new Texture2D(1024, 768); 一个 asset 就在运行时被创建了 )

只有当那个 asset bundle 被卸载时, 对应的 instance id entry 才会从 cache 中被移除;
后面当这个 asset bundle 被再次加载时, 会重新建立一个新的 instance id 映射entry;

在某些平台, 某些 events 可能会导致 obj 的内存不足; 比如在 ios, 当 app 被 suspended(悬起), 图形 assets 可能会从 显存中被卸载; 如果这些 obj 源自 已经卸载的 AssetBundle，Unity 将无法重新加载 objs 的源数据。 对这些 obj 的任何现有引用也将无效。此时, 场景将获得 无效的 meshes 和 品红色的 texture;

# 注意:
不能在运行时查询 asset 文件的 guid;


# =================================== #
#         MonoScripts
# =================================== #
MonoScripts 只包含定位 特定 script class 所需的信息。

MonoScripts 包含 3 个 string: assembly name, class name, and namespace.

在打包一个项目时, unity 会将所有的 脚本文件都打包进一个 mono assemblies:
--
    Plugins 目录之外的 c#脚本 将被打包进 Assembly-CSharp.dll 文件;
    Plugins 目录内的 c#脚本 文件, 将被打包进 Assembly-CSharp-firstpass.dll;

此处还可查看这个网页:
(define custom managed assemblies):
https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html?_ga=2.163907644.20088139.1655605355-597440040.1625213567


这些 assemblies 将在 app 的启动运行阶段被加载;

这也是为什么所有的 assetBundle, 或 scene, 或 prefab, 都不真的包含 脚本本体; 

The latter three time costs are generally invariant regardless of whether the hierarchy is being cloned from an existing hierarchy or is being loaded from storage. However, the time to read the source data increases linearly with the number of Components and GameObjects serialized into the hierarchy, and is also multiplied by the speed of the data source.

.... 暂略 ...


# =================================== #
#     4.AssetBundle fundamentals
# =================================== #

# --------------------------------- #
#   4.2. AssetBundle layout
一个 assetbundle 包含两部分:
    -- 一个 header;
    -- data segment;

header 包含 assetbundle 的信息数据, 包括 its identifier, compression type, and a manifest;

# manifest:
manifest 是个 lookup table, 每个 entry 以 obj 的 name 为 key; 其值为一个 byte index,
可以到 data segment 中找到 obj 的资源;

大部分平台中, 这个 lookup table 用 平衡二叉树 来实现; windows 和 osx/ios 平台使用 红黑树 来实现;

# data segment:
将 assets 序列化进 assetbundle, 就得到了 data segment 中的数据,这些是 raw data(原始数据); 若选择 LZMA 为压缩方案, 所有 序列化的 assets 组成的 byte array 将被整个的压缩; 若选择 LZ4 方案, 每个 asset 的字节块, 将被独立压缩;
若不选择压缩方案, 则直接存储 原始数据;


# --------------------------------- #
#    4.3. Loading AssetBundles
# --------------------------------- #
有4套独立的 api 来导入 assetbundle, 这4套之间的差异, 基于以下两个评判标注:
-1-
    选择了哪种压缩方案: LZMA, LZ4 还是不压缩
-2-
    要加载 assetbundle 的平台是哪一个;

这些 api 是:
# -- AssetBundle.LoadFromMemory()      异步, unity 5.3.3 中的名字
# -- AssetBundle.LoadFromMemoryAsync() 异步, 新名字
    不推荐使用

# -- AssetBundle.LoadFromFile()  异步
从硬盘和sd卡中加载 LZ4 或 未压缩的 assetbundle 的高性能 api;

在 桌面主机, pc, 和移动端, 本 api 只会加载 assetbundle 的 header 数据, 然后让剩余数据留在 硬盘中; 只有当 AssetBundle.Load() 这种加载函数被调用时, obj 资源才会被加载; (另一种触发条件是: 这个 obj 的 instance id 被 dereferenced 时, (取消引用))

这种模式不会消耗多余的内存;
在 unity editor 模式中, 本 api 会将 assetbundle 的所有资源都加载到内存, 


        这是最推荐的函数;


# -- UnityWebRequest's DownloadHandlerAssetBundle

# -- WWW.LoadFromCacheOrDownload (unity 5.6 后存在)




# ------------------------------------------------- #
#     4.4. Loading Assets From AssetBundles
# ------------------------------------------------- #
可以使用 三套 api 来将 UnityEngine.Objects 从 assetbunldes 中加载到内存中; 
它们都有 同步/异步 版本;

它们的 同步版 总是比 异步版 快;

# -- AssetBundle.LoadAsset() / AssetBundle.LoadAssetAsync()
基础款;


# -- AssetBundle.LoadAllAssets() / AssetBundle.LoadAllAssetsAsync()
用于加载 数个独立的 UnityEngine.Objects;

只有当一个 assetbunble 中的 大部分/或全部 objs 都需要被加载时, 才该使用本组函数;
与另外两套相比, LoadAllAssets() 要快于 数次独立地调用 LoadAsset();

Therefore, if the number of assets to be loaded is large, but less than 66% of the AssetBundle needs to be loaded at a single time, consider splitting the AssetBundle into multiple smaller bundles and using LoadAllAssets.
---
因此, 如果我们一次要加载非常多的 assets, (记住, 数个 assets 可以被捆绑打包成 assetbundle ) 但是由这些 assets (以及更多其他 assets) 构成的那个巨大的 assetbunble, 又只需被用到 66% 时, (此时, 完整地加载这个巨型的 assetbundle 显然是不划算的, 毕竟只需用到它的一部分资源);
此时, 我们应该把这个巨型 assetbundle 拆成很多个 小的 assetbundles, 然后调用 LoadAllAssets() 去加载其中的若干个;


# -- AssetBundle.LoadAssetWithSubAssets() / AssetBundle.LoadAssetWithSubAssetsAsync()
此 api 应该用来加载 "复合型 asset", 它们内部嵌套了多个 objs, (比如 FBX 文件, 内部还嵌套了 .anim 文件; 再比如 sprite atlas, 内部嵌套了数个 sprites )

If the Objects that need to be loaded all come from the same Asset, but are stored in an AssetBundle with many other unrelated(无关的) Objects, then use this API.
---

# ------------------------------------------------- #
#        4.4.1. Low-level loading details
# ------------------------------------------------- #
UnityEngine.Object 的加载工作在 主线程 之外执行：从 job线程的存储 中读取对象的数据。

除开 unity 系统的那些 线程敏感 的部分(比如脚本,图形), 剩余的一切资源的 转换 都将在 job线程 中执行;
比如: 从 mesh 资源中创建 VBOs, 或者 解压 textures;

5.3 以来, obj加载被 并行化了; 在数个 job线程 中 deserialized(反序列化), 处理 和 集成 objs,

当一个 obj 完成了自己的加载, 它的 Awake 将被调用, 然后从下一帧开始, 它就能被 unity引擎 使用了;

同步版的 AssetBundle 加载方法们会将 主线程 阻塞, 直到加载工作完成; 它们还会将 obj 加载这个过程做 时间切片 (time-slice), 以使得 Object integration 不会占用 帧时间内的 一定毫秒数; 
这个可在 Application.backgroundLoadingPriority 中设置;


从 5.2 开始, 在帧时间限制(上面那个变量) 到达之前, 数个 obj 会执行加载; 

假设所有其他因素都相同，异步函数们 将始终比 它们的同步版 耗费更长的时间来完成，
因为在 "发出异步调用" 和 "对象可被引擎使用" 之间, 最短也要延迟 1 帧时间;


# ------------------------------------------------- #
#       4.4.2. AssetBundle dependencies
# ------------------------------------------------- #
基于不同的 运行时环境, assetbundles 之间的 相互依赖关系 可被两套 api 来自动追踪;
-1-
    在 unity editor 模式中, 可使用 AssetDatabase API;
    还能使用 AssetImporter API 来访问和改变 assetbundle 的 assignments and dependencies (分配和依赖)

-2-
    At runtime, Unity provides an optional API to load the dependency information generated during an AssetBundle build via a ScriptableObject-based AssetBundleManifest API.
    ---
    "AssetBundleManifest" API;
    暂时没能翻出来...
    --- 机翻:
    在运行时，Unity 提供了一个可选的 API，用于通过 AssetBundleManifest API 加载, 
    在 AssetBundle 构建期间生成的依赖信息。
    这个 api 基于 ScriptableObject;


Because an Object is loaded when its Instance ID is first dereferenced, and because an Object is assigned a valid Instance ID when its AssetBundle is loaded, the order in which AssetBundles are loaded is not important. Instead, it is important to load all AssetBundles that contain dependencies of an Object before loading the Object itself. 
---
Unity will not attempt to automatically load any child AssetBundles when a parent AssetBundle is loaded.
---
当一个 obj dereferenced 它的 instance id 时, 它会立即被重新加载;
当一个 obj 所在的 assetbundle 被加载时, 它会被分配一个 instance id;
因为上面这两个原因, 使得 到底哪个 assetbundle 会被先加载 变得不那么重要了;
反而, 在加载一个 obj 本体之前, 应该先将它依赖的所有的 assetbundles 都先加载进来 (当前, 加载的只是这些 assetbundles 的头文件)

当一个 父 assetbundle 被加载后, unity 不会自动去加载任何它的 子 assetbundles;
(没怎么懂... 应该是说, 除非 obj 需要, 不然不主动加载 子 assetbundles )

# 举例:
有两个 ab包, 包1 中存放了一个 material, 包2 中存放了一张 texture, 那个 material 依赖那张 texture;

在这个案例中, 若想把 material 从它的 ab包中加载出来, 必须先把它依赖的 ab包2 先加载到内存中;

这不意味着, ab包2 必须在 ab包1 之前被加载, 或者必须 显式地把 texture 从 ab包2 中加载出来; 只要能保证, 在加载 material 这个 obj 之前, 先加载 ab包2 (的头部) 就可以了;

但是, unity 是不会自动去加载 ab包2 的, 这个必须用脚本手动调用;

关于更多依赖关系, 看此文:
https://docs.unity3d.com/Manual/AssetBundles-Dependencies.html?_ga=2.91118746.1050821994.1655689056-997589975.1645524223


# ------------------------------------------------- #
#         4.4.3. AssetBundle manifests
# ------------------------------------------------- #

当使用 BuildPipeline.BuildAssetBundles() 执行 ab包的打包活动时, unity 会生成一个 记录了 ab包的依赖信息的 .manifests 的文件; 

本质上 .manifests 也是一个 ab包, 和目标 ab 包放置在同路径下, 而且同名; 
它只包含了一个类型为 "AssetBundleManifest" 的 obj;

这个 .manifests ab包 可以像普通 ab包一样被 loaded, cached 或 unloaded;

"AssetBundleManifest" 包含: 

-- "GetAllAssetBundles()" 
    to list all AssetBundles built concurrently with the manifest
    -- 列出和本 .manifests 文件同时构建的所有 ab包;
        ---
        没看明白...


-- "GetAllDependencies()"
    获得目标 ab包 的所有依赖的 子ab包 和 孙ab包, 可一直嵌套下去;
    也就是说, 可以得知这个 ab包依赖的所有 子孙ab包; 全部获得, 不管嵌套得多么复杂 

-- "GetDirectDependencies()"
    只获得 目标ab包 所依赖的 子级ab包; 

注意, 这些函数都会分配 string arrays, 所有不要在运行时中 性能敏感的时间段使用它们;


# ------------------------------------------------- #
#         4.4.4. Recommendations
# ------------------------------------------------- #

最好在主场景 或重要场景加载之前, 尽可能多地预先加载资源;

...


# ============================================================= #
#            5.AssetBundle usage patterns
# ============================================================= #


# ------------------------------------------------- #
#     5.1 Managing loaded Assets
# ------------------------------------------------- #

当 obj 从当前场景中被移除后, unity 不会主动去卸载它们;
资源清理 会在特定的时候点被触发, 它也可以被手动触发;

一个 ab包占用的内存往往很小, 比如 几十kb; 但是很多个 ab包占用的内存就会变得很大;

由于大多数项目都支持玩家 重玩某一关卡; 此时就要合理管理何时加载和卸载一个 ab包;
如果一个 ab包卸载不当, 会导致内存中出现 重复资源;

核心在于 AssetBundle.Unload( bool unloadAllLoadedObjects ) 中的参数;
--
    参数为 false:
    加载到的 内存中的 ab包 会被卸载;
    但是从这个 ab包中加载出来的那些 objs 资源, 不会被卸载, 它们还可以被继续使用;
    ---
    但是这会使得这些被加载出来的 objs 和它们的 ab包 脱绑;
    如果再次加载这个 ab包, unity 不会在旧的 objs 和 新的 ab包 之间建立联系;
    如果此时, 调用 AssetBundle.LoadAsset() 从新的 ab包中加载 obj资源, 此时 unity不会意识到 内存中已经存在一份 目标obj 资源了, 而会重新加载一份, 从而造成 资源的重复;

-- 
    参数为 true:
    加载到内存中的 ab包, 以及从这个 ab包中加载出来的 objs资源, 都会被卸载掉;
    使用不当会出问题;
    ---
    但是这种使用 比 AssetBundle.Unload( false ) 更安全, 至少不会导致 obj资源的重复导入;

如何保证 obj资源 不被重复加载:
-1-:
    在程序生命周期种, 定义合适的 ab卸载时间点;
    这是最简单的方案;

-2-:
    手动管理:
    记录每个 obj资源的 引用计数; 然后仅在一个 ab包的所有 objs 都不被使用时, 才卸载这个 ab包(以及从它加载出来的所有 objs资源)


如果必须要使用 AssetBundle.Unload( false ), 那么每个独立的 obj资源, 必须用以下两种方式去卸载:
-1-:
    消除一个目标 obj资源的所有 引用, 包括 场景种的引用, 和 代码中的引用; 当这个达成时, 调用: Resources.UnloadUnusedAssets();

-2-:
    以 non-additively 模式加载一个 scene; 当这个 scene 被卸载时, 它对 obj资源的引用都会被清楚, 然后还会自动调用 Resources.UnloadUnusedAssets();


在关卡之前合理地释放资源 和 加载新资源; 这是最简单的方法, 但不见得通用;

最好以 "是否会同时加载卸载" 为条件去将 不同的 objs资源 合成 ab包;

# ---
如果 ab包已经被卸载了, 但它的某个 obj资源又需要被加载到内存, 此时这个 reload 操作会 fail, 然后这个被 fail 加载出来的 obj, 会在 edior 平台的 hierachy 中以 (Missing) Object 的形式存在;


# ------------------------------------------------- #
#           5.2. Distribution
# ------------------------------------------------- #
有两种方式将 项目的 ab包 分发给 客户端:
-1-
    跟着程序一起被安装;          (主机常见)
-2-
    在安装完程序之后, 在被下载;  (移动端常见)


适当的架构允许在安装后 将新的 或 修改的内容 修补到您的项目中，
而不管 AssetBundle 最初是如何交付的 (同时还是延迟)

请查看: "Patching with AssetBundles" 已翻译;


# ------------------------------------------------- #
#        5.2.1. Shipped with project
# ------------------------------------------------- #
将 ab包 和 项目放在一起, 是最简单的方式, 这避免了管理下载的代码;
常见用法:
-1-
    放在一起的 ab包, 可存储到 Streaming Assets 中;

-2-
    To ship an initial revision of updatable content. This is commonly done to save end-users time after their initial install or to serve as the basis for later patching.
    ---
    发布可更新内容的初始修订版。通常这样做是为了节省最终用户在初始安装后的时间，或者作为以后修补的基础。
    ---
    此时不该使用 Streaming Assets, 
    当然, 如果不想写一个 下载和cache系统, 那么:
    then an initial revision of updatable content can be loaded into the Unity cache from Streaming Assets (See the Cache Priming section, below).


# ------------------------------------------------- #
#        5.2.1.1. Streaming Assets
# ------------------------------------------------- #
最简单的 将资源 (包括ab包) 合并进 app安装 的方式, 是将这些资源存入 /Assets/StreamingAssets/  目录;, 然后再执行 项目的 build 工作; 

任何在 StreamingAssets 目录中的数据, 都会在 build 过程中被复制进最终的 app 里;

可使用 Application.streamingAssetsPath 来获得 这个目录的 完整path; 
然后就能调用 AssetBundle.LoadFromFile() 来加载这些资源;

# 安装平台:
这些被放在 StreamingAssets 目录中的 资源 将被存入 APK 中, 如果这些资源被压缩了, 则要花更多时间来加载它们; 

存储在 APK 中的文件, 可改用不同的 存储算法; 不同的 unity 版本会使用不同的算法;
可使用 7-zip 来打开 APK, 来确认文件是否被压缩;
如果是压缩的, 那么可以肯定 AssetBundle.LoadFromFile() 会执行得比较慢;
此时可改用 UnityWebRequest.GetAssetBundle();  (这个函数被移除了...)

后面的略...

Alternatively, you can export your Gradle project and add an extension to your AssetBundles at build time. You can then edit the build.gradle file and add that extension to the noCompress section. Once done, you should be able to use AssetBundle.LoadFromFile() without having to pay the decompression performance cost.
---
此外, 你可以导出你的 Gradle 项目, 并在 build 阶段添加一个 扩展到你的 ab包中...

待续...

注意:
在有些平台, 如果app 的 ab包需要在安装之后 再被更新, StreamingAssets 是不可被写入的, 此时要改用  WWW.LoadFromCacheOrDownload, 或写一个自定义的 downloader;


# ------------------------------------------------- #
#          5.2.2. Downloaded post-install
# ------------------------------------------------- #
移动平台偏好 在安装之后再去更新 ab包, 
在很多平台, app 的 二进制文件必须经历一个 昂贵且漫长的 重新认证的过程; 
所以, 为 post-install 开发一个好的系统至关重要。

最简单的方式是: 将需要更新的 ab包 放在一个 web服务器上, 然后通过 UnityWebRequest 传递它们; unity 会自动在本地硬盘上 cache 这些下载的 ab包;


If the downloaded AssetBundle is LZMA compressed, the AssetBundle will be stored in the cache either as uncompressed or re-compressed as LZ4 (dependent on the Caching.compressionEnabled setting), for faster loading in the future. If the downloaded bundle is LZ4 compressed, the AssetBundle will be stored compressed.
---
如果下载的 AssetBundle 是 LZMA 压缩的，则 AssetBundle 将像 LZ4 一样未压缩或重新压缩（取决于 Caching.compressionEnabled 设置）存储在缓存中，以便将来更快地加载。如果下载的包是 LZ4 压缩的，则 AssetBundle 将被压缩存储。

如果 cache 文件满了, unity 会移除 最近加载的 ab包;

推荐使用 UnityWebRequest, 当要求较高时, 可自制一个系统;

...

# ------------------------------------------------- #
#         5.2.3. Built-in caching
# ------------------------------------------------- #

...

# ------------------------------------------------- #
#        5.2.3.1. Cache Priming
# ------------------------------------------------- #

...

# ------------------------------------------------- #
#        5.2.4. Custom downloaders
# ------------------------------------------------- #

# ------------------------------------------------- #
#        5.2.4.1. Downloading
# ------------------------------------------------- #

...
...

# ------------------------------------------------- #
#       5.3. Asset Assignment Strategies
# ------------------------------------------------- #












