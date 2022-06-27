# ===================================================== #
#           AssetBundle compression
# ===================================================== #

# 默认情况下, unity 会使用 LZMA 来 build ab包; 
# 并在其第一次加载到 游戏平台本机 后, 将其 重压缩 为 LZ4 模式;



# ------------------------------- #
#     AssetBundle cache
# ------------------------------- #
unity 维护两个 cache:
# -- The Memory Cache:
    存储在内存中的 无压缩 cache;

# -- The Disk Cache:
    存储在硬盘中的 (应该已经 重压缩 过的) cache, 使用的 压缩格式下面再说;

由于 Memory Cache 消耗巨量内存, 因此除非真的需要频繁地访问这个 ab包中的所有资源, 否则不该选用 Memory Cache, 而该使用 Disk Cache;

如果你向 uwr (UnityWebRequest) 传递了一个 version 参数, unity 将选用 Disk Cache; 如果不提供这个 version 参数, 则 unity 将使用 Memory Cache;
这个 version 参数可以是一个 version, 也可以是一个 hash 值;

... 暂略, 需要翻译 ...

















