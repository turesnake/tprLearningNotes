# =========================================================== #
#       C# Job System
# =========================================================== #
job system 允许你编写 简单且高性能的 多线程代码, 它可与 unity engine 交互,
以提高 游戏性能.

可以将 job system 和 Entity Component System (ECS) 结合使用.
ECS 是一种架构, 它能编写 简洁且高效的全平台机器码.

# =========================================================== #
#       C# Job System Overview
# =========================================================== #

# How the C# Job System works

编写多线程代码 能获得高性能收益. 比如较高的帧率. 
将 Burst 编译器 和 job 结合使用 可提高 代码生成质量, 它还能降低 移动设备的耗电量.

C# Job System 的一个重要方面是,它与 unity native job system 相结合. 
用户写的代码 和 unity 共享 worker threads.
这种合作避免了生成超出 cpu cores 数量的线程, 后者会导致 cpu资源的争夺.

推荐收看:
https://www.youtube.com/watch?v=kwnb9Clh2Is&t=1s


# =========================================================== #
#      What is multithreading?
# =========================================================== #

略...

为避免频繁地创建并销毁 线程,可以使用 线程池. 即便如此,同一时间地活跃线程仍然很多. 过多线程导致地 cpu资源争夺, 会引发频繁地 context switching.


# =========================================================== #
#      What is a job system?
# =========================================================== #
job system 通过创建 job 而不是 线程, 来实现多线程编程.
(tprpix 用的就是 job system)

一个 job system 在多个 cpu核心间,管理一组 worker threads.
通常,为每个 cpu逻辑核心 分配一个 worker thread, 以避免 context switching.
(当然,它还是会为 操作系统 和 其他专用程序 保留部分核心) 

job system 将一个 job 推入 job queue, worker threads 从 queue 中取出这些 job,并执行它们.

job system 管理 dependencies:
http://tutorials.jenkov.com/ood/understanding-dependencies.html

并确保 job 以适当地顺序被执行.

# What is a job?
一个 job,就是一个 小代码片段. job 可以是 self-contained(独立的), 也可以 依赖于另一个 job, 需要其他 job 完成之后,自己再执行.

# What are job dependencies?
复杂系统中地 job 不能总要求是 独立的, 一个 job 常常为另一个 job 准备数据. job 知道这层关系,并且 support dependencies 来使得这一切能运作. job system 要保证 相互依赖的 job 间的正确运行顺序和时机.


# =========================================================== #
#     The safety system in the C# Job System
# =========================================================== #

# Race conditions
当编写 多线程代码, 总存在风险会导致 race conditions. 
当一个操作的输出 依赖于 另一个超出它控制的操作的时机 时, race condition 就会发生.

race condition 并不总是 bug, 但它是 不确定性行为的 来源. 当一个 race condition 确实引发了一个 bug, 查找出根源是很困难的, 因为它依赖于时机, 所以你只能罕见地再次复现这个 bug. 

race condition 是 多线程编程的最大挑战.

# Safety system
unity c# job system 能查出所有潜在的 race condition, 保护你免于 bug.

比如: 如果主线程向 job 传入一个 引用. 我们是无法保证, 在子线程处理此job,向这个引用写入数据时,主线程是不是在读取这个引用. 这个行为将导致 race conditon.

c# job system 的做法是, 向job传入 数据的 copy,而不是引用. 这隔离了数据.

job system 的着这种复制行为, 意味着 job 只能访问 Blittable types(c# 中的术语). 这种类型在 managed(托管) 和 原生代码 之间传递时 无需 转换.

c# job system 可以用 memcpy (c/c++中的函数) 复制 Blittable types, 并将这个数据在 托管和原生unity代码 间传递. 在 "调度"job时,它使用 memcpy 将数据写入 原生内存, 且在执行时, 允许 托管代码 访问这些数据.


# =========================================================== #
#     NativeContainer
# =========================================================== #
如前文,复制数据的缺点是, 它还隔离了 每个job的结果. 为克服它, 你需要将结果存储在一种被称为 "NativeContainer" 的共享内存 中.

# What is a NativeContainer?
一个 nativecontainer 是一个托管的值类型,它提供一个相对安全的 对原始内存的 c# wrapper(包装). 它包含一个 指针, 指向一个 unmanaged allocation(未托管分配器).
当和 unity c# job system 一起使用时, 一个 NativeContainer 允许一个 job 与 主线程 共享一个数据, 而不是工作在一个 数据的copy 上.

# What types of NativeContainer are available?
Unity 附带了一个名为 NativeArray 的 NativeContainer。您也可以使用 NativeSlice 操作 NativeArray，从特定位置获取特定长度的 NativeArray 子集。

注意, ECS 可以扩展 Unity.Collections namespace, 以 include 其他类型的
NativeContainer:

-- NativeList - 可调整大小的 NativeArray。
-- NativeHashMap - 键/值对。
-- NativeMultiHashMap - 每个键有多个值。
-- NativeQueue - 先进先出 (FIFO) 队列。

# NativeContainer and the safety system
safety system 内置于所有 NativeContainer 类型中, 它会跟踪在 NativeContainer 中读写的内容。

注意: 在 NativeContainer 上的所有 safety check(安全检查) (比如: 边界越界检查, 取消分配检查, race condition检查) 只能在 unity editor 和 play mode 下进行.

这个 safety system 的一部分是:  DisposeSentinel and AtomicSafetyHandle
DisposeSentinel 检查内存泄漏, 如果你不正确释放内存,将获得 error. 内存泄漏发生很长时间后才会触发内存泄漏错误。

使用 AtomicSafetyHandle 可以在代码中转移 NativeContainer 的所有权。
例如，如果两个调度的 job 正在写入相同的 NativeArray，则 safety system 会抛出一个异常，并显示一条明确的错误消息，说明问题的原因和解决方法。调度违规的 job 时， safety system 会抛出此异常。

在这种情况下，可以调度具有依赖关系的 job 。第一个 job 可以写入 NativeContainer，一旦该 job 完成执行，下一个 job 就可以安全地读取和写入相同的 NativeContainer。从主线程访问数据时，读写限制也适用。
安全系统允许多个 job 并行读取相同的数据。

默认情况下，当 job 可以访问 NativeContainer 时，该 job 便具有读写访问权限。此配置可能会降低性能。
C# job system 不允许在一个 job 正在写入 NativeContainer 的同时再调度另一个 job 对其进行写访问。

如果作业不需要写入 NativeContainer，请用 [ReadOnly] 属性标记 NativeContainer，如下所示：

[ReadOnly]
public NativeArray<int> input;

在上面的示例中，允许多个 job 同时对 NativeArray 进行只读访问。

注意：
从 job 中访问 static 数据 是没有任何保护的。访问静态数据时会绕过所有 safety system，并可能导致 Unity 崩溃。如需了解更多信息，请参阅:
C# Job System tips and troubleshooting.

# NativeContainer Allocator
创建 NativeContainer 时，必须指定所需的内存分配类型。分配类型取决于 job 运行的时间长度。因此，可以定制分配以便在每种情况下获得最佳性能。

可以使用三种 Allocator 类型进行 NativeContainer 内存分配和释放。在实例化 NativeContainer 时需要指定适当的一种类型。

-1- Allocator.Temp 
    具有最快的分配速度。此类型适用于寿命为一帧或更短的分配。不应该使用 Temp 将 NativeContainer 分配传递给作业。在从方法调用（例如 MonoBehaviour.Update 或从原生代码到托管代码的任何其他回调）返回之前，还需要调用 Dispose 方法。

-2- Allocator.TempJob 
    它的分配速度比 Temp 慢，但比 Persistent 快。此类型适用于寿命为四帧的分配，并具有线程安全性。如果没有在四帧内对其执行 Dispose 方法，console 会输出一条从 native code 生成的警告。大多数小的 job 都使用这种 NativeContainer 分配类型。

-3- Allocator.Persistent 
    它是最慢的分配，但可以在您所需的任意时间内持续存在，如果有必要，可以在整个应用程序的生命周期内存在。此分配器是直接调用 malloc 的封装器。持续时间较长的 job 可以使用这种 NativeContainer 分配类型。在非常注重性能的情况下不应使用 Persistent。

举例:

NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

注意：上例中的数字 1 表示 NativeArray 的大小。在此例子中只有一个数组元素（因为只会在 result 中存储一个数据）。


# =========================================================== #
#     Creating jobs
# =========================================================== #

要创建 job，必须实现 IJob 接口。借助 IJob，可以调度一个 job,它与其它正在运行的 job 并行运行.

注意：“job” 是 Unity 中对于任何实现 IJob 接口的 struct 的统称。

要创建作业，你需要：
-- 创建一个 struct, 它继承于 IJob 接口。
-- 添加该 job 使用的成员变量（ blittable 类型,或 NativeContainer 类型）
-- 在 struct 中实现一个名为 Execute 的方法, 并在其中实现 job 主体内容

在执行 job 时, Execute 方法在一个 cpu核心上 运行一次.

注意：在设计 job 时，请记住它们是对数据copy 进行操作，除非使用到了 NativeContainer。因此，从主线程中的 job 访问数据的唯一方法是写入 NativeContainer。

# An example of a simple job definition

// Job adding two floating point values together
public struct MyJob : IJob
{
    public float a;
    public float b;
    public NativeArray<float> result;

    public void Execute()
    {
        result[0] = a + b;
    }
}


# =========================================================== #
#     Scheduling jobs
# =========================================================== #

为了在主线程中 "调度" 一个 job,你必须:
-- 实例化 该 job
-- 填充 job 的数据
-- 调用 Schedule 方法
    (IJobExtensions.Schedule)

声明:
public static Unity.Jobs.JobHandle Schedule(
        T jobData, 
        Unity.Jobs.JobHandle dependsOn
        );


调用 Schedule 会把 job 压入 job queue 中, 以便在后续合适的时间点 执行它们.
一旦 Schedule, 你不就能再 阻碍这个 job 了.

注意: 在主线程中,你只能调用 Schedule 方法.



# An example of scheduling a job

// Create a native array of a single float to store the result. This 
// example waits for the job to complete for illustration purposes
NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

// Set up the job data
// 这个 MyJob 在上文 已经声明了
MyJob jobData = new MyJob();
jobData.a = 10;
jobData.b = 10;
jobData.result = result;

// Schedule the job
JobHandle handle = jobData.Schedule();

// Wait for the job to complete
handle.Complete();

// All copies of the NativeArray point to the same memory, 
// you can access the result in "your" copy of the NativeArray
float aPlusB = result[0];

// Free the memory allocated by the result array
result.Dispose();

# =========================================================== #
#     JobHandle and dependencies
# =========================================================== #

调用 Schedule 方法将返回一个 JobHandle 类型对象. 
你也可以在 job 代码中使用 JobHandle, 当作其他 job 的 dependency (依赖项)
如果一个 job 依赖于另一个 job 的运行结果. 你可以把第一个 job 返回的 JobHandle
项 当作一个参数 传入第二个 job 的 Schedule 方法中:

JobHandle firstJobHandle = firstJob.Schedule();
secondJob.Schedule(firstJobHandle);

# Combining dependencies
如果一个 job 存在数个 dependencies, 可使用 JobHandle.CombineDependencies 方法来将它们组合. 这个方法输入 一组 JobHandle, 返回一个合成后的 JobHandle,
可以直接将这个 方法 写在 Schedule 的参数位置上:

NativeArray<JobHandle> handles = new NativeArray<JobHandle>(numJobs, Allocator.TempJob);

JobHandle jh = JobHandle.CombineDependencies(handles);

# Waiting for jobs in the main thread
在主线程上调用 Jobhandle 的 Complete 方法, 可以强制主线程等待 job 直到它执行完毕. 当 Complete 方法返回后,就意味着 可以在主线程上完全的访问 job 使用的 NativeContainer 了.

注意:
当你在 schedule 一个 job 时,他不会被立即执行. 调用 Complete 还能刷新 内存缓存中的 jobs, 启动执行流程. 在一个 JobHandle 上调用 Complete, 会将这个 job 的  NativeContainer 的所有权 交还给 主线程. 
此外，也可以通过在 jb依赖关系中的 JobHandle 上调用 Complete 来将所有权交还给主线程。
例如，可以在 jobA 上调用 Complete，也可以在依赖于 jobA 的 jobB 上调用 Complete。两种方式都会使 jobA 使用的 NativeContainer 类型在调用 Complete 之后可以在主线程上安全地访问。

否则,如果你不需要访问这些数据, 你需要显式地 刷新批次, 通过调用 static方法:
JobHandle.ScheduleBatchedJobs, 声明:

public static void ScheduleBatchedJobs();

请注意，调用此方法会对性能产生负面影响。

# An example of multiple jobs and dependencies

# Job code:
// Job adding two floating point values together
public struct MyJob : IJob
{
    public float a;
    public float b;
    public NativeArray<float> result;

    public void Execute()
    {
        result[0] = a + b;
    }
}

// Job adding one to a value
public struct AddOneJob : IJob
{
    public NativeArray<float> result;
    
    public void Execute()
    {
        result[0] = result[0] + 1;
    }
}

# Main thread code:
// Create a native array of a single float to store the result in. 
// This example waits for the job to complete
NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

// Setup the data for job #1
MyJob jobData = new MyJob();
jobData.a = 10;
jobData.b = 10;
jobData.result = result;

// Schedule job #1
JobHandle firstHandle = jobData.Schedule();

// Setup the data for job #2
AddOneJob incJobData = new AddOneJob();
incJobData.result = result; // 两 job 使用相同的 NativeContainer

// Schedule job #2
// 确认依赖关系
JobHandle secondHandle = incJobData.Schedule(firstHandle);

// Wait for job #2 to complete
// 尽管仅调用了 job2 的 Complete, 但其实也要求 job1 先完成执行
secondHandle.Complete();

// All copies of the NativeArray point to the same memory, 
// you can access the result in "your" copy of the NativeArray
float aPlusB = result[0];

// Free the memory allocated by the result array
result.Dispose();


# =========================================================== #
#     ParallelFor jobs
# =========================================================== #
在 shceduling jobs 时, 一个 job 只能执行一个任务.
但在游戏中,往往需要对大量物体执行相同的任务, 有一种额外的 job 类型,
称作 IJobParallelFor 能处理此问题.

注意: “ParallelFor” job 是 Unity 中对于任何实现 IJobParallelFor 接口
的 struct 的统称。

ParallelFor job 使用一个 NativeArray 作为其数据源. ParallelFor jobs 在多个 cpu核心上运行. 每个核心都有一个 job, 每个 job 处理 工作量的一部分.
IJobParallelFor 的行为类似于 IJob, 但并不是调用单个 Execute 方法，而是对数据源中的每一项都调用一次 Execute 方法. 在 Execute 方法中,存在一个 整形参数, 它是一个 idx, 用于访问和操作 job 实现中的数据源的单个元素。

# An example of a ParallelFor job definition:

struct IncrementByDeltaTimeJob: IJobParallelFor
{
    public NativeArray<float> values;
    public float deltaTime;

    public void Execute (int index)
    {
        float temp = values[index];
        temp += deltaTime;
        values[index] = temp;
    }
}































