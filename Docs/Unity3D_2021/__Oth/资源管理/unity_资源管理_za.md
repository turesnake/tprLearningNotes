# ================================================================ #
#                    资源管理 za
# ================================================================ #


# ------------------------------ #
#       Resources 目录
# ------------------------------ #

建议全局查找: "Resources System"






# ------------------------------ #
#       AssetBundle
# ------------------------------ #


# ------------------------------ #
#     何时使用 ab包  (AssetBundle)
# ------------------------------ #

# from new bing:
    AssetBundles in Unity can be useful for various purposes such as:
    - Downloadable content (DLC)
    - Reducing initial install size
    - Loading assets optimized for the end-user’s platform
    - Reducing runtime memory pressure ³.

    For instance, if you have a game with a large number of assets, you can use `AssetBundles` to load only the assets that are required for a particular level or scene. 
    This can help reduce the initial download size of your game and improve performance by reducing memory usage ³.

    Another use case is when you want to provide additional content to your users after the initial release of your game. 
    You can create `AssetBundles` containing new levels, characters, or other content and make them available for download ³.
    ===



# ------------------------------ #
#   AssetDatabase.GetDependencies() 和 EditorUtility.CollectDependencies() 的区别
# ------------------------------ #
by weier

1。 前者不会返回内置资源，后者会返回
2。 前者不会返回重复的对象路径，后者会返回重复的对象
3。 前者提供了返回直接依赖的方法，后者没有，会返回所有依赖
注意，该方法 AssetDatabase.GetDependencies 可能会返回文件中存在的引用，但是实际上不需要的引用资源。最终的依赖资源还需要以 EditorUtility.CollectDependencies 的列表为准


# tpr:
    EditorUtility.CollectDependencies() 返回的有可能是 一个 prefab 的 组件; 
    ( 比如我们期望它返回一个 prefab 的 root go, 但其实它返回了 root go 的 transform 组件 )
    ---
    而组件的 InstanceID 和 主go 的 InstanceID 是不同的; 但拿着这两个 InstanceID 去调用 AssetDatabase.GetAssetPath(), 得到的 资源 path 却是相同的
    毕竟, 组件 和 主go 其实指向同一个 prefab 的 root节点;
    ---

    这意味着, 在这里直接依靠 CollectDependencies() 函数的返回值(UnityEngine.Object) 的 InstanceID 去识别资源 是不可靠的;
    ===
        -- 要么一路找到它的 root go 的 InstanceID
        -- 要么直接使用它的 assetPath



# ------------------------------ #
#    prefab 和  prefab variant 的区别
#     ( prefabVariant )
# ------------------------------ #

有点类似 继承, prefab variant 就是原 prefab 的派生类;
当 原 prefab 发生变化,  variant 体内的对应部分也会变化;

new bing:
    On the other hand, a Prefab Variant is a way to serialize overrides made to the original Prefab while still retaining the relationship to the master Prefab1. 
    It keeps track of the Prefab it is derived from and any changes (overrides) made to the original Prefab. 
    A Prefab Variant can have any other Prefab as its base, including Model Prefabs or other Prefab Variants.


# 代码创建 (冷门)

    To create a Prefab Variant, you can use the PrefabUtility.SaveAsPrefabAsset() function after instantiating the base Prefab with PrefabUtility.InstantiatePrefab()
    ---
   使用 PrefabUtility.InstantiatePrefab() 来实例化一个 prefab;
   使用 PrefabUtility.SaveAsPrefabAsset() 来将一个 prefab 实例创建为一个 variant 资源




# ------------------------------ #
#   string path = AssetDatabase.GetAssetPath( int instanceID )
# ------------------------------ #

在 editor, 拿到 Project 中的某个 Object (可以是一切可选的, 只要继承了 `UnityEngine.Object` 就行)

-1- 通过 tgt.GetInstanceID(); 拿到它的 instanceID  (通常这是一个正数, 因为它现在是 src obj, 不是 instance obj)
-2- 通过 AssetDatabase.GetAssetPath( instanceID ) 得到它的 asset path


# 当然, 也可以直接调用 AssetDatabase.GetAssetPath(UnityEngine.Object assetObject) 版的...




# ------------------------------ #
# (editor 模式), 一个 prefab 和 它的组件 的 InstanceID, 和 assetPath:
# ------------------------------ #

假设有个 prefab, 它和 它的transform组件 的 InstanceID 是不同的; (假设分别为 idA 和 idTF)

但是拿着这两个不同的 InstanceID, 去调用 `AssetDatabase.GetAssetPath()`, 得到的 资源 path 却是相同的;

再拿着这个 path, 调用 `AssetDatabase.LoadAssetAtPath<GameObject>()` 重新得到这个 prefab,(顺便转化为 GameObject 类型) 再访问它的 InstanceID, 则此值和上面的 idA 相同;

(以上这些都符合我们的预期)

# 即: editor 中, Assets 目录下的 资源的 InstanceID, 和它的主 GameObject 的 path 才是核心数据
    如果不消息拿到了它的组件的 InstanceID, 则最好搞到它的主 GameObject 的 InstanceID;







# ------------------------------------- #
#     如何管理 .spriteatlas 文件的 打包
# ------------------------------------- #
在 project 中新建的 sprite atlas 文件, 它的后缀就是 `.spriteatlas`,   和 .prefab 文件一样, 它也只是一个描述文件;







# ------------------------------------- #
#     如何管理 .playable 文件的 打包
# ------------------------------------- #




# ------------------------------------- #
#     如何管理 .timeline 文件的 打包
# ------------------------------------- #






