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






