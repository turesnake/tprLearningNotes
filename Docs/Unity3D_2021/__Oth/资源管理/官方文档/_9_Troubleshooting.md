# ===================================================== #
#           Troubleshooting
# ===================================================== #

使用 ab包 的一些问题:

# ------------------------------------ #
#        Asset Duplication
# ------------------------------------ #
Unity 5’s AssetBundle system will discover all dependencies of an Object when the Object is built into an AssetBundle. 
This is done using the Asset Database. This dependency information is used to determine the set of Objects that will be included in an AssetBundle.
---
unity 5 的 ab系统会在一个 obj 被打包进一个 ab包时, 自动发现这个 obj 的所有依赖信息;
这是使用 Asset Database 完成的;
...

Objects that are explicitly assigned to an AssetBundle will only be built into that AssetBundle. An Object is “explicitly assigned” when that Object’s AssetImporter has its assetBundleName property set to a non-empty string.
---
“explicitly assigned” 值得是, 在 inspector 的 AssetImporter 面板中, 手动设置这个 asset 的 "assetBundle" 选项;

然后, 这个 obj资源 就只会被 built 进这个 ab包中;


Any Object that is not explicitly assigned in an AssetBundle will be included in all AssetBundles that contain 1 or more Objects that reference the untagged Object.
---
如果这个 obj A 没有通过上述手动方式设置自己的 ab包, 那么只有别的任何一个 obj资源 依赖于这个 obj A, 那么这个 obj A 就会被打包进这个 ab包中;
若有多个 ab包中的 objs 依赖 obj A, 那么这个 obj A 资源就会出现在多个 ab包中; 
# 从而导致了 资源的重复;
    这些重复的 obj A 资源将被看做出 不同的资源, 拥有不同的 id;

有几种办法可以定位这个问题:
-1-:
    让不同 ab包中的 assets, 不共享资源;
    不太容易实现;

-2-:
    "Segment AssetBundles" 使得共享资源的两个 ab包 不会在同一时间段被加载使用;
    某些关卡游戏也许可以使用;
    但仍然造成了 ab包总体资源的浪费;

-3-:
    确保所有 "被依赖的资源" 都设置了它们的目标 ab包;
    这能最大程度的降低 Asset Duplication, 但是也增加了复杂度;


In Unity 5, Object dependencies are tracked via the AssetDatabase API, located in the UnityEditor namespace. As the namespace implies, this API is only available in the Unity Editor and not at runtime. "AssetDatabase.GetDependencies()" can be used to locate all of the immediate dependencies of a specific Object or Asset. Note that these dependencies may have their own dependencies. Additionally, the AssetImporter API can be used to query the AssetBundle to which any specific Object is assigned.
---

By combining the AssetDatabase and AssetImporter APIs, it is possible to write an Editor script that ensures that all of an AssetBundle’s direct or indirect dependencies are assigned to AssetBundles, or that no two AssetBundles share dependencies that have not been assigned to an AssetBundle. Due to the memory cost of duplicating assets, it is recommended that all projects have such a script.

# ------------------------------------ #
#       Sprite Atlas Duplication
# ------------------------------------ #
关于 Sprite Atlas 的;

Any automatically-generated sprite atlas will be assigned to the AssetBundle containing the Sprite Objects from which the sprite atlas was generated. 
---
任何自动生成的 Sprite Atlas 都将被分配进一个 ab中, 内含的资源是 构建这个 Sprite Atlas 时所使用到的那些 Sprite 资源;
(这些 Sprite 是一个个独立的类似 texture 的资源)

If the sprite Objects are assigned to multiple AssetBundles, then the sprite atlas will not be assigned to an AssetBundle and will be duplicated.

If the Sprite Objects are not assigned to an AssetBundle, then the sprite atlas will also not be assigned to an AssetBundle.

To ensure that sprite atlases are not duplicated, check that all sprites tagged into the same sprite atlas are assigned to the same AssetBundle.

...


# ------------------------------------ #
#       Android Textures
# ------------------------------------ #

Due to heavy device fragmentation in the Android ecosystem, it is often necessary to compress textures into several different formats. While all Android devices support ETC1, ETC1 does not support textures with alpha channels. Should an application not require OpenGL ES 2 support, the cleanest way to solve the problem is to use ETC2, which is supported by all Android OpenGL ES 3 devices.
---
由于 Android 生态系统中 设备碎片化严重，通常需要将 texture 压缩成几种不同的格式;

... 没细看, 需要细看 ...


# ------------------------------------ #
#      iOS File Handle Overuse
# ------------------------------------ #

Unity 5.3.2p2 之后, 这个问题被搞定了;










































































