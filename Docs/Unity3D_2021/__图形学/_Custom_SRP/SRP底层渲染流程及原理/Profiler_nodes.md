# ================================================================ #
#            Profiler_nodes
# ================================================================ #
记录 Profiler - timeline 这个面板中, 各个 nodes 的具体信息.


# ---------------- #
# 如何在 build 好的 app 中检测 profiler ?
在 build 界面, 勾选: 
--    Development Build
--    Autoconnect Profiler
然后实际运行这个 app, 然后回到 unity 中, 打开 profiler, 会发现它正在监视 app 的运行,
等待数秒后,可以点击 那个 红点, 停止 profiler 的收集, 然后就能拖动 竖白线, 检查特定帧的信息.
此时可以把 app 关掉.



# ============================== #
# -- CullSceneDynamicObjects

针对场景中的 动态物体 进行 cull (剔除) 操作.

会调用数个 job 来并行执行此操作, 每个 job 负责一小组物体的 renderer, 
将这组中, 未被剔除的 renderer 的 idx 记录在一张 IndexList 的对应区域内.
这个区域的 后半段会被全部写 0, 表示有一部分 renderer 已经被 cull 了.

因为每个 job 只需在自己所属的 renderer小组, 以及那段有限的 IndexList 区间内工作,
所以互补干预, job 之间是彻底线程安全的. 无需线程锁



# ============================== #
# -- CullSceneDynamicObjectsCombineJob

上面的 CullSceneDynamicObjects 结束后, 那些 0 是散落在整个 IndexList 各个区域的.
此时需要对 IndexList 做一次完整的排序, 将所有非0值,都排到 数组的 前部去.

这个 node 通常紧跟 CullSceneDynamicObjects.

# -- 奇怪的是, 这个 node 也有若干个, 对应于 CullSceneDynamicObjects 的个数
为什么这个 重排操作, 也需要 多线程 jobs 来执行 ?



# ============================== #
# Shadows.CullShadowCastersDirectional
# Shadows.CullShadowCastersWithoutUmbra
# Shadows.CullShadowCastersDirectionalDetail

当场景中存在 "可以产生阴影的" 的光源 (可能主要是平行光), 也存在可以 投射阴影 的 物体时 (shadowCaster)
对这些 shaderCasters 进行的 cull 操作.

在视频中, 这个过程被称为 "针对阴影的 cull", 但是显然很含糊.

unity 会为每一个 能产生阴影的 光源, 分配一个 job 去执行此工作.

# -- Shadows.CullShadowCastersDirectionalDetail
如果把所有 renderer inspector 的 cast shadows 选项设置为: Off,
这个 node 的耗时会下降很多.



# ============================== #
# ExtractRenderNodeQueue

cpu 内存中的 renderer 数据是 分散存储的, 不利于快速访问. 拿着上文已经整理好的 IndexList,
把记录在这个 IndexList 中的 renderer 数据, 每一个都复制到一个 RenderNode 的数据结构中.
这是一个 扁平化的, 值类型的数据结构. 其实还包括 renderer 中的内部组件(引用) 的数据, 都会被提取出来, 展平,
放入 RenderNode;
RenderNode 中所有数据都在内存上 连续存储

RenderNode 的目的在于, 我们只要拿着一个 RenderNode 实例,就能获得所有想要的数据, 以此来绘制这个 renderer;

--------

由 RenderNodes 组成的队列, 就叫 RenderNodeQueue. 这个 queue 是线程安全的, 可被拿来做 多线程渲染.

因为这个过程中存在 巨量的 内存复制, 所以它的耗时 往往会非常大.

减小此 node 耗时的办法, 就是降低场景中 可见的 renderer 的数量


# ============================== #
# PrepareDrawRenderersCommand

这个 node 没在 profiler 中画出来, 通常, 它在 RenderLoop.Sort 前面

遍历所有 RenderNode，然后找到里面所有的 Material，再遍历每个 Material 找到里面可以用的 Pass， 
根据每个 Pass 去生成一个 ScriptableLoopObjectData（简称 ObjectData）



# ============================== #
# RenderLoop.Sort

在上方 所有的 ObjectData 生成后，再对这些 ObjectData 进行一个 排序，
就可以得到一个确定的渲染顺序。 再针对这些 ObjectData， 逐一进行渲染


# ============================== #
# ScriptableRenderLoopDrawDispatch  派遣




# ============================== #
# RenderLoopNewBatcher.Draw

Per Object large buffer部分，里面8个小方块就代表着8个小的 buffer， 
意味着一次的batch里面有8次的draw call。 
每个draw call都需要一个小 的 buffer， 会把我们引擎内部一些内置的数据（比如unity_ObjectToWorld） 填充进去。 
然后我们为每个 Object 准备这些小buffer， 然后组成一个大buffer， 最 后把这个大buffer一次性的传到GPU上。 

在 draw 这个 node 中, 
需要遍历每一个 objectData, 判断它能否和前面一个进行 batch, 如果能,就 batch,
如果不能,就立刻进入到 SRPBatcher.Flush 阶段, 执行真正的 buffer 填充工作.


# ============================== #
# SRPBatcher.Flush

填充 gpu 中 per obj large buffer 中的, 一个batch 中的每一个小 buffer


# ============================== #
# -- EditorLoop

仅在 Editor 模式才存在的, 如果检测 build 好的 app, 将不存在这些 node
运行性能也会好很多. 




















