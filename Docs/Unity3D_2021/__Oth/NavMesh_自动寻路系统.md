# ============================================================ #
#                 NavMesh 自动寻路系统
# ============================================================ #


# 额外装了新版的 AI Navmesh 系统



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




# ----------------------------------------- #
#      常见 api
# ----------------------------------------- #

# -- NavMeshAgent.SetDestination(point3.position);

    给 agent 设置 next tgt pos, 然后 agent 会朝向这个点运动


# -- bool NavMesh.SamplePosition( Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask );
     给任意坐标,找到 NavMesh 上离它最近的可行走点:
     --
     sourcePosition:   原始 目标 pos,不要求在网格上
    maxDistance:搜索半径,超出这个距离找不到点就返回 false
    areaMask:限定只在哪些 NavMesh Area 里找(通常传 NavMesh.AllAreas)
    找到后 hit.position 就是网格上最近的合法点


# -- NavMeshAgent.Warp — 真正的瞬移(不是寻路走过去):
    直接把 agent 瞬移到 newPosition,前提是这个点必须在 NavMesh 上(或很接近),否则会失败或修正位置
    和直接改 transform.position 的区别是:Warp 会正确重置 agent 内部的路径状态、NavMeshQueryFilter 等,不会导致 agent 卡死或状态错乱;直接改 transform 则容易让 agent 内部坐标和实际位置脱节
    ===
    !! 这个甚至能在两个隔绝的 layer 之间瞬跳


# 代码示范:
    if( NavMesh.SamplePosition( point1.position, out NavMeshHit hit, 100f, NavMesh.AllAreas ))
    {
        navMeshAgent.Warp(hit.position);
    }
    else
    {
        // maxDistance 内没有可行走网格,需要放大搜索范围或报错
        Debug.LogError($"传送失败");
    }



















