# ================================================================ #
#              c#  资源管理
# ================================================================ #


# --------------------- #
# 核心文章: Profiler深挖-图解内存管理(10)
https://developer.unity.cn/projects/5d3bb5b2edbc2a001f766eeb



# --------------------- #


# unity 托管堆:
https://developer.unity.cn/projects/5d306218edbc2a001f385a85



# CloseHandle()
https://docs.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle


# 接口: IDisposable
https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0

IDisposable.Dispose() 需要由 继承了 IDisposable 接口的类型 的 消费者自己去调用;
比如, 当一个 obj 被使用完毕后, 需要显式调用它的 Dispose() 函数:
    -1-
        使用完毕后, 显式调用 Dispose();
    -2-
        包含在 using 括号内
    -3-
        包含在 try/finally 括号内


# Implement a Dispose method
https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose



# GC.WaitForPendingFinalizers()
https://docs.microsoft.com/en-us/dotnet/api/system.gc.waitforpendingfinalizers?view=net-6.0




# SafeHandle 
https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.safehandle?view=net-6.0








