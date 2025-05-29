using UnityEngine;
using System;



/*
    展示 c# 析构过程相关函数
*/
public class ReleaseShow : IDisposable
{   

    // 标记对象是否已被释放
    bool _disposed = false;


    /*
        需外部代码显式调用;
        内容通常是 卸载非托管资源
    */
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        // 用户自己实现;
        // ...

        _disposed = true;        
    }

    /*
        析构函数; c# GC 自动调用;
        .NET（包括 C#）的垃圾回收器采用的是“追踪式、分代”GC（Generational, Mark-and-Sweep & Compacting）

        追踪式 GC
            从根（static 变量、栈上的引用、CPU 寄存器等）开始“标记”所有可达对象，未被标记的即为“垃圾”；
            对这些垃圾对象统一进行回收，并压缩堆空间，消除内存碎片。

        分代（Generations）
            把堆分为 Gen0、Gen1、Gen2（大对象堆 LOH）三代；
            新创建的对象先放 Gen0，经过几次幸存下来才晋升到更高级别；
            因为大多数对象存活时间都很短，GC 通常只扫描 Gen0，大大提高性能。

        为什么不用引用计数？
            “引用计数”会在每次引用赋值或释放时更新计数，开销高；
            无法自动处理“循环引用”——两个对象互相引用，计数永远不会降到零；
            追踪式 GC 不受循环引用影响，可以一次性解决所有不可达对象。

        补充：
            在 COM 互操作时，.NET 会为 RCW（Runtime-Callable Wrapper）维护一个引用计数，背后调用 COM 接口的 AddRef/Release，但这仅限于 COM 对象，不是 .NET GC 的通用机制。
            你可以通过 GC.Collect() 强制触发一次 GC，但一般建议让运行时自己根据内存压力决定何时回收。
            总之，C# 用的是基于标记－清除＋分代压缩的追踪式 GC，而非引用计数。
    
    */
    ~ReleaseShow()
    {
        // 确保当用户忘记调用 Dispose() 时，非托管资源最终能被释放。
        Dispose();
    }
}




