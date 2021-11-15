# ================================================================ #
#   Occlusion culling
# ================================================================ #

当一个物体完全被别的物体遮挡时 (基于 camera 视角), Occlusion Culling 操作 
能避免 unity 去渲染这些 "完全被遮挡" 的物体.

每一帧, Cameras 都会对场景中的 renderers 执行 culling 检测, 以检测它们是否
有必要被 剔除出 渲染. 默认, cameras 执行 frustum culling "平截头体 culling", 任何不在此 区域
内的 物体, 都将被剔除. 但是,  "平截头体culling" 并不检测 这个 物体是否 被另一个物体完全遮挡, 
此时就需要执行 Occlusion culling. 

tpr:
    从这个角度看, Occlusion culling 并不是 frustum culling,
    而是它的补充;

# When to use occlusion culling

想要确保 occlusion culling 是否能提高你项目的性能, 考虑以下步骤:
--
    把不必要的 渲染操作 节省掉, 能在 cpu 和 gpu 上同时获益.
    unity built-in occlusion culling  会消耗 cpu 的运算时间. 这部分时间 会和
    它节省的 cpu 运算时间 相抵消. 

    因此, 当因为过多的 渲染任务而出现 gpu 受限时, 此时使用 occlusion culling 能获得
    性能提高.
--
    unity 在运行时 将 occlusion culling data 加载入内存. 所以,确保自己有足够的 内存.
--
    当场景中的 各个区域 比较小,定义良好, 且为 不透明物体, 它们与其它区域分离得比较干净. 此时 occlusion culling 就能发挥最大作用. 
    比如 房间 和 走廊. 
-- 
    可用 occlusion culling 去剔除 动态物体, 但 动态物体 无法剔除 别的物体.
    如果你的场景是在运行时 临时生成出来的 (大部分物体是动态的), 那么 unty built-in
    occlusion culling 就不适合你的项目.

# How occlusion culling works
在 unity editor 阶段生成场景的 occlusion culling data, 
然后在 运行时 使用这些 data 来查明 camera 可以看到那些物体 (剩余的被剔除了).
生成这些 data 的过程被称为 baking.

当你在 bake occlusion culling data 时, unity 将场景分割为很多个 cells, 为每个 cell 生成 "描述它内部的几何体" 的数据, 以及 cells 之间的可见性.
然后, unity 会合并一些 cells, 以减少 整个生成的 data 的尺寸.

想要配置 baking 过程, 可在 Occlusion Culling window 中修改参数, 然后在场景中使用 Occlusion Areas. 

在运行时, unity 将这些 data 加载进内存. 并且对于每个启用了 occlusion culling property 的相机，它都会对 data 执行查询, 以确定该相机可以看到的内容. 

注意, 当 camera 的 occlusion culling 开启之后, camera 要同时执行: frustum culling 和 occlusion culling

# Additional resources
unity 使用 Umbra 库 来执行 occlusion culling. 
后续网页: Occlusion culling additional resources 中会提及. 


# ================================================================ #
#   Getting started with occlusion culling
# ================================================================ #
本文描述了: 如何配置你的 scene, 来启用 occlusion culling,
执行 bake, 最后看见效果.














































