

# 官网介绍:
https://docs.unity3d.com/2021.3/Documentation/Manual/JobSystem.html







# ================================ #
# 一、普通计算类 Job 接口（最基础）
这些接口不依赖 GameObject，只处理数据，最常用也最推荐入门。

# - IJob:
    单线程 Job | 适用于一次性执行的任务，比如加工一批数据结果

# - IJobParallelFor:
    并行数组处理 | 每个索引独立执行，可在多核中均分负载
    --
    是游戏开发中用得最多的，特别是你有成千上万的独立粒子、AI、或数值计算时。

# - IJobParallelForBatch:
    批次并行处理 | 类似上面的，但一次处理一段（`beginIndex`~`endIndex`），降低调度开销




# ================================ #
# Unity 对象相关的 Job 接口
这些接口扩展用于操作 Transform、实体 (ECS) 或 物理 Job。


# - IJobParallelForTransform
    并行修改多个 Transform，比如批量移动物体 | 通过 `TransformAccessArray` 传入变换数据
    使用 IJobParallelForTransform 来加速大批量对象的移动或旋转处理。


# - IJobChunk
    ECS（实体组件系统）中使用的核心 Job 类型 | 用于遍历 Entity Chunk（Unity DOTS 中使用）


# - IJobEntity
    DOTS/ECS 的高级接口，用于直接迭代实体 | 更易用的 ECS Job 写法


# - IJobPhysics / IJobPhysicsParallelFor
    Unity Physics / Havok 的 Job 接口 | 专门用于物理世界的并行计算


# ================================ #
#  三、Job 依赖与组合类
这些接口提供更灵活的依赖控制、组合与自定义调度。


# - JobHandle
    控制 Job 依赖关系；你可以让 Job B 等待 Job A 完成

# - JobHandle.Complete()
    手动等待 Job 执行完毕

# - Job.WithCode() Job.WithBurst()
    （C# Job DSL） | C# 里简洁地声明 Job（在 Entities 包中常见



# ================================ #
#   四、常见的 Job 生态组件

# - *Burst 编译器**  [BurstCompile]
    将 Job 编译成高性能本机代码

# - `NativeArray`, `NativeList`, `NativeSlice`
    Job 可安全访问的原生内存容器

# - TransformAccessArray
    Job 中访问和修改 Transform 的安全方式

# - `Allocator.TempJob` / `Persistent`
    管理内存生命周期










































