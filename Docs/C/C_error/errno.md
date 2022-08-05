

# ================================================================ #
#                          errno
# ================================================================ #

errno 全局变量，记录最后一次出错的 错误类型。

-1- 如果没有出错，errno的值 不会被 例程清除。（也就是说，errno中总是会有一个值的）
    所以，仅当 函数的返回值 指明出错时，才去检查 errno的值。

-2- 任何函数都不会将 errno 的值设置为0.
    且 errno 的所有常量 都不为 0

# ----------------------------------
#错误 大致分为两类，致命性 和 非致命性。

#-- 致命性 错误：
    无法执行 恢复动作。可将 出错消息 打印到终端，或写入 日志文件。然后退出

#-- 非致命性 错误：
    多数是暂时的，比如资源短缺。当系统中活动减少后，这种错误 将不会发生。
    
    与资源相关的 非致命性错误 包括：
        EAGAIN, ENFILE, ENOBUFS, ENOLCK, ENOSPC, EWOULDBLOCK, 
        ENOMEM (有些时候)
        EBUSY (当它指明共享资源正在使用时，也可被视作 非致命性错误)
        EINTR (当它中断 一个 慢速系统调用时，可将它视为 非致命性错误)

    对于 资源相关的 非致命性错误 的典型 恢复操作是 延迟一段时间，然后重试。


# ----------------------------------

#  man 3 errno
    大部分 errno 原有值 都可查询到。




# ======================= #
#       errno 常量
# ======================= #

#  EADDRINUSE      
    Address already in use (POSIX.1)
    地址已经被使用了。
        常见触发函数：
        bind

#  ECONNABORTED
    Connection aborted (POSIX.1)
    连接终止
        常见触发函数：
        accept

#  EPROTO
    Protocol error (POSIX.1)
    协议出错。
        常见触发函数：
        accept

#  EINTR           
    Interrupted function call (POSIX.1); see signal(7).
    中断函数调用。
        常见触发函数：
        pause();

#  EINVAL          
    Invalid argument (POSIX.1)
    参数无效。（适合适用于很多 场合）
        

#  ENAMETOOLONG
    Filename too long (POSIX.1)
    若 常量 _POSIX_NO_TRUNC 有效。
        则在 整个路径名超过 PATH_MAX，或 文件名超过 NAME_MAX 时
        open / openat函数 出错返回， 并将 errno 设置为 ENAMETOOLONG

#  ESRCH
    ESRCH           
    No such process (POSIX.1)
        常用触发函数：
        kill( pid_t pid, int signo )
            当 signo 设为0，且 pid指向的进程不存在时
            kill 将返回 -1，errno 被设置为 ESRCH.


#   ESPIPE          
    Invalid seek (POSIX.1)
    如果 文件描述符 指向的是一个管道，FIFO，或 网络套接字，
        则 lseek 返回 -1，并将 errno 设置为 ESPIPE


#   EPIPE
    Broken pipe (POSIX.1-2001).
    如果 管道／FIFO／tcp 的 读进程已经终止，
    此时调用 write 向其 写入数据，写进程将收到 SIGPIPE 信号
    同时，write 调用返回 -1， 并将 errno 设置为 ESPIPE



#   ENOENT          
    No such file or directory (POSIX.1)
    没有 目标文件 或 目录
    当调用 open 打开一个 已存在的文件，但其实没有这个文件时
        出现此 errno


#   EIO
    Input/output error (POSIX.1)
    IO 错误















