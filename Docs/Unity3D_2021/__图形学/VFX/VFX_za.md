# ================================================================ #
#                         VFX  za
# ================================================================ #
Visual Effect Graph





# ---------------------------------------------- #
#            Point Caches
# ---------------------------------------------- #
https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@12.1/manual/point-cache-in-vfx-graph.html

是一个 asset 文件, 可以设置粒子在 init 状态时的信息, 比如 pos;
也可用 "Set Position (Shape: Mesh)" 节点替代它, 但是为啥咱没有...

此文件后缀为 .pCache

# 生成器:
https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@12.1/manual/point-cache-bake-tool.html

# 使用教程:
https://www.youtube.com/watch?v=j1R1Uelroco


使用起来非常简单, 但是似乎只能从一个固定的 mesh 上生成;



# ---------------------------------------------- #
#           将粒子们 吸引到一个点, 或远离一个点
# ---------------------------------------------- #
https://www.youtube.com/watch?v=3EsITXwhlF4




# ---------------------------------------------- #
#       如何采样 texture, 如何获得 uv
# ---------------------------------------------- #

# 基础教程
https://www.youtube.com/watch?v=ZokxsnfIZF0




# ---------------------------------------------- #
#        vector field
# ---------------------------------------------- #
有点类似 flow map, 可以控制空间中每个位置的 驱动信息,
让途径此位置的 粒子 按照一定规则去行动;




# ---------------------------------------------- #
#       subgraph
# ---------------------------------------------- #
有点类似一个 函数;

https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@12.1/manual/Subgraph.html










