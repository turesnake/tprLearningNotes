# ================================================================//
#                   资源管理 za
# ================================================================//
仅 家中记录, 未来要被合并;

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




















