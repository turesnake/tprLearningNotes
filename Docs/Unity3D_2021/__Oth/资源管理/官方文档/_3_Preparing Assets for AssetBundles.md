# ===================================================== #
#         Preparing Assets for AssetBundles
# ===================================================== #

存在几种 分配资源到 ab包的策略;

# -------------------------------- #
#    Logical Entity Grouping
# -------------------------------- #
基于 资源所属的 逻辑功能 来分块;
比如:
    -- 将 ui系统的所有 textures 和 layouts 放一起;
    -- 将一个角色的 models 和 .anim 文件放一起;
    -- 讲一个场景的某个区域的 textures 和 models 放一起;


Logical Entity Grouping 很适合来管理 DLC 资源的分块;
因为你需要更新的内容, 都被放在一起了, 当需要更新一个角色时, 无需再去更新其他的 ab包; 

# 此策略的挑战在于:
开发者需要非常熟悉每个 ab包 的使用场合, 何时, 如何使用它们;


# -------------------------------- #
#      Type Grouping
# -------------------------------- #
将 相同相似类型 的资源打包到一起;
比如音频文件, 本地语言文件 等;

此策略 能更好地支持 多平台发布:
比如:
--
    如果你的音频文件, 在 ios 和 win 上使用了相同的 settings 配置, 那么你可以把这些 音频文件打成一个 ab包, 然后在 ios 和 win 上使用这同一个 ab包;
--
    由于 shader 一定是根据目标平台编译的, 用于 ios 的 shader 将无法用于 win;
    此时, 你就需要分别对 ios版 shaders 和 win版shaders 打两个包;
--
    In addition, this method is great for making your AssetBundles compatible with more unity player versions as textures compression formats and settings change less frequently than something like your code scripts
 or prefabs
.


# -------------------------------- #
#   Concurrent Content Grouping
# -------------------------------- #
将那些 "在同一时间段被加载卸载的资源" 打包到一起;

比如, 同一关内被使用的资源;

你要确保, 一个 ab包里的所有 asset, 都要尽可能在同一时间段内被使用; 否则, 你会加载很多相互依赖的 ab包, 但每个ab包中, 又仅仅使用一部分 assets 资源; 从而造成加载时间的浪费;

本策略特别适合: 按场景去打包; 比如, 一个 ab包 包含了某个场景的所有 资源;


# -------------------------------- #
#   总结
# -------------------------------- #
以上的不同策略 可以混合使用;

# --
    需要被频繁跟新的 obj资源, 和不需要频繁跟新的 obj资源,
    要被分到 不同的 ab包中去;

# --
    将需要被同时导入的资源, 分到一起去, 比如一个模型的 mesh, texture 和 .anim 文件;

# --
    if you notice multiple objects across multiple AssetBundles are dependant on a single asset from a completely different AssetBundle, move the dependency to a separate AssetBundle.
    ---
    If several AssetBundles are referencing the same group of assets in other AssetBundles, it may be worth pulling those dependencies into a shared AssetBundle to reduce duplication.
    ---
    没看太明白...

# --
    如果两个 asset资源, 一定不会在同一时间被使用到, 比如 中配资源 和 高配资源, 请确保它们一定不要在同一个 ab包内;

# --
    Consider splitting apart an AssetBundle if less that 50% of that bundle is ever frequently loaded at the same time
    ---
    如果一个 ab包, 每次加载后使用到的资源不超过 50%, 请拆包;

# --
    如果两个包, 内涵资源数量很小(5-10个), 但又经常被同时加载, 考虑将它们 合包;

# --
    如果一堆资源, 它们只是同一个 obj 的不同 version 的资源, 考虑使用 "AssetBundle Variants";



































