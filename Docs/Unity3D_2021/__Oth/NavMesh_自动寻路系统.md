# ============================================================ #
#                 NavMesh 自动寻路系统
# ============================================================ #


# NavMesh 
NavMesh 是一张 网格(mesh), 表示当前关卡(level) 中所有可到达区域;
它由数个 convex polygon (凸多边形) 拼合而成;


# 寻路算法:
    (一部分是猜想)
    首先确定 src 和 dst 自己所在的 convex polygon, 
    然后先计算出路径需要通过哪些 polygons, 
    (这个过程有点类似在棋盘格上寻找路径, 只不过 棋盘格 被替换为了 polygons)

    unity 使用的算法: A* (pronounced “A star”) Algorithm;


#  A* Algorithm
    https://en.wikipedia.org/wiki/A*_search_algorithm




































