//
//========================= l_fsio.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.17
//                                        修改 -- 2018.06.17
//----------------------------------------------------------
//   不带缓冲的 文件IO
//   APUE 第三章
//----------------------------

#ifndef _NET_FSIO_H_
#define _NET_FSIO_H_

#include <unistd.h>
//-- 三个 fd 常量。
//  STDIN_FILENO   == 0
//  STDOUT_FILENO  == 1
//  STDERR_FILENO  == 2


#include <fcntl.h>

//-- 打开 或 创建一个 文件。
int open( const char *path, int oflag, ... ); //-- mode_t mode

int openat( int fd, const char *path, int oflag, ... ); //-- mode_t mode

    //-- param: ... 省略的 第三个参数是 mode_t mode.
    //      也就是 文件的 访问权限。 4.5 介绍

    //-- param： fd 与 path：
        //   --  如果 path 是绝对路径名，则 fd参数被忽略，此时 openat 和 open 一样。 
        //   --  如果 path 是相对路径名，则 fd 指出 相对路径名 在文件系统中的 开始地址。
        //         fd参数是通过 打开 相对路径名 所在的目录 来获得的（目录的 fd） 
        //   --  如果 path 指定 相对路径名，fd 具有 特殊值 AT_FDCWD.
        //         此时，路径名 在当前工作目录中获取，

            //----- 设置 openat 函数的 目的 ---------
            // -1- 让 线程 可以使用 相对路径名 打开目录中的文件，而不再只能打开当前工作目录。
            //      同一进程中的 所有线程 共享 相同的 当前工作目录，因此很难让 同一进程的不同线程
            //      在同一时间 工作在不同的目录中，
            // -2- 避免 time-of-check-to-time-of-use／TOCTTOU 错误

            //----- TOCTTOU 错误 ------
            //  如果有两个基于文件的函数调用，第二个调用依赖第一个调用的结果，那么程序是脆弱的
            //  因为两个调用不是 原子操作，两个调用之间，文件可能改变。造成第一个调用的结果不再有效
            //  

    //-- param： oflag -- 选项。(文件状态标志) 用下列数个常量 ‘或’运算 得到：
    //-- 这些常量定义在 <fcntl.h>： (文件状态标志)

    //=========== 以下 5 个常量，必须指定一个，且只能指定一个 (文件状态标志) =======
    // O_RDONLY   只读打开  值常为0
    // O_WRONLY   只写打开  值常为1
    // O_RDWR     读写打开  值常为2
    // O_EXEC     只执行打开
    // O_SEARCH   只搜索打开（用于打开 目录）
            //        用于打开目录时，验证目录的 搜索权限.
            //        对目录的后续操作就不需要再检查 搜索权限了
            //        Linux 暂不支持 此常量

    //=========== 以下 常量 为可选 (文件状态标志) =========
    // O_APPEND      每次写时 都追加到 文件尾端
            //          如果不设置此值，当前偏移量 会被默认设置为 0
            //          此标志 下的读写 是一次 原子操作。
    // O_CLOEXEC     把 FD_CLOEXEC 常量设置为 文件描述符标志 3.14
    // O_CREAT       若此文件不存在，则创建它。
            //          使用此选项时，open／openat函数需同时说明 参数3:mode 
            //          用 mode 指定该新文件的 访问权限位。 4.5
    // O_DIRECTORY   如果 path 引用的 不是目录，则此次open调用出错。
    // O_EXCL        如果同时指定了 O_CREAT,而文件已经存在，则出错
            //          用此可以测试一个文件 是否存在。如果不存在，则创建此文件。这使 测试和创建 两者成为一个 原子操作
            //          3.11 介绍 原子操作。
    // O_NOCTTY     如果 path 引用的是 终端设备，则不将 该设备分配 作为此进程的 控制终端。
            //          9.6 介绍 控制终端。
    // O_NOFOLLOW   如果 path 引用的是一个 符号链接，则出错。 4.17 符号链接
    // O_NONBLOCK   如果 path 引用的是一个 FIFO，块特殊文件，字符特殊文件，
            //          则此选项 为文件的本次打开操作 和 后续IO操作 设置 非阻塞方式。 14.2 说明此工作模式。
    // O_SYNC       使每次 write 等待物理IO操作完成，
            //          包括由该write操作引起的 文件属性更新所需要的IO.3.14 使用此选项
    // O_TRUNC      若此文件存在，而且为 只写／读写 成功打开，则将其长度截断为0
    // O_TTY_INIT   若打开一个 尚未打开的终端设备，设置 非标准 termios 参数值，
            //          使其符合 single unix specification。 18章 讨论 终端IO的 termios 结构。

    //============ 以下 2 常量 为可选，single unix specification ／ POSIX.1 (文件状态标志) =========
    // O_DSYNC    使每次 write 要等待 物理IO操作完成。
            //         但如果该操作 并不影响 读取刚写入的数据，则不需等待 文件属性被更新。
    // O_RSYNC    使 每一个 以 文件描述符 作为参数进行的 read 操作等待。
            //         直到 所有对 文件同一部分挂起的 写操作都完成。
            //         linux 中的 O_RSYNC 和 O_SYNC 相同。

    //-- 两函数 return
    //-- 成功，返回 文件描述符
    //-- 出错，返回 -1.

    //------------------------------------
    // 如果 传入的 文件名长度 超过 NAME_MAX， linux 会返回出错。
    // 若 常量 _POSIX_NO_TRUNC 有效。
    //    则在 整个路径名超过 PATH_MAX，或 文件名超过 NAME_MAX 时
    //    出错返回， 并将 errno 设置为 ENAMETOOLONG


#include <fcntl.h>

//-- 创建一个 新文件
int creat( const char *path, mode_t mode );
    //-- 此函数等效于 open( path, O_WRONLY | O_CREAT | O_TRUNC, mode );
    //      由此看出 creat 是存在缺陷的，无法 立即 read 新创建的文件
    //   可以用 open( path, O_RDWR | O_CREAT | O_TRUNC, mode ); 代替 creat

        //-- 在 早期 unix 中，open函数 无法创建新文件，所以需要 creat函数
        //   现在 主要用 open，已经不需要 creat 了。

    //==== 此函数 不推荐使用 ====

    //-- return
    //-- 成功，返回 为只写 打开的 文件描述符。
    //-- 出错，返回 -1.


#include <unistd.h>

//-- 关闭一个 打开的文件
int close( int fd );

    //-- 关闭一个文件，会释放 该进程加在文件上的 所有记录锁 14.3

    //-- 当一个进程终止时，内核会自动关闭它所有的打开文件。
    //   很多程序利用这一功能 来 省略 close 调用。

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1


#include <unistd.h>

//-- 为一个打开的文件 设置 当前偏移量
//-- lseek 名字中的 ‘l’ 表示 长整形。是个历史遗留
off_t lseek( int fd, off_t offset, int whence );
    //-- lseek 仅将当前 文件偏移量 记录在 内核中，并不直接 改写到 文件记录中（所以也没有 IO操作）
    //-- 然后，可以调用 read／write 来使用新设置的 文件当前偏移量。

    //-- 新设的 文件偏移量 可大于 当前长度。此时，对该文件的写 将加长该文件。并在文件中构造一个空洞 
    //-- 位于文件中，但没有写过的字节，都被读作0
    //-- 文件中的空洞 并不要求在磁盘上 占用存储区。当定位到超出文件尾端之后的 写 时，
    //-- 对于新写的数据 需要分配磁盘，对于原文件尾端 和 新开始写位置之前的部分，不需分配磁盘块
    //--

    //-- param: offset:
    //-- 对于普通文件，offset 必须是 非复值。（部分特殊情况在下文呈现。） 

    //-- param: whence：
    //-1- SEEK_SET   将 当前偏移量 设置为 距 文件开头 offset 个字节处 (绝对偏移量)
    //-2- SEEK_CUR   将 当前偏移量 自加 offset 个字节。 （相对于当前位置的偏移量）
            //         此时的 参数 offset 可为 正负或0。
    //-3- SEEK_END   将 当前偏移量 设置为 文件当前长度 加 offset 个字节 （相对于文件尾的偏移量）
            //         此时的 参数 offset 可为 正负或0。

    //-- return
    //-- 成功，返回 新的 当前偏移量
    //-- 出错，返回 -1
    //     由于 偏移量 也可能是负数（某些情况下）所以检测对错时，不要检测 <0,而要检测 ==-1

        //----------- 确定 文件的 当前偏移量 ----------
        // off_t currpos;
        // currpos = lseek( fd, 0, SEEK_CUR );
        //     这样，currpos 就是 文件当前偏移量。
        //     也可用此法 来确定 目标文件 是否可以设置 偏移量
        //         如果文件描述符 指向的是一个管道，FIFO，或 网络套接字，
        //         则 lseek 返回 -1，并将 errno 设置为 ESPIPE


#include <unistd.h>

//-- 从已打开的文件 fd 中读取数据，存入 buf中
//-- read 从文件的 当前偏移量处 开始。成功返回后，当前偏移量 增加 实际读到的字节数。
ssize_t read( int fd, void *buf, size_t nbytes );

    //-- 参数 nbytes -- 指定要读取的 数据字节数 （实际读取数 可能少于此值）

    //-- 以下情况 将使 实际读取字节数 少于 nbytes：
    //-1- 读普通文件时，在读到 nbytes之前 已到达文件尾端。
    //    一个文件拥有 20字节数据，若将 nbytes设为 100，第一次read返回 20，第二次read返回 0。
    //-2- 当从 终端设备 读取时，一次只能读取一行。
    //-3- 当从 网络读时，网络中的 缓冲机制可能造成 返回值小于 nbytes
    //-4- 当从 管道／FIFO 读时，如果管道内 包含的字节少于 nbytes时，read只会返回 实际读到的字节数
    //-5- 当从某些 面向记录的设置（磁带）读取时，一次最多返回一个记录
    //-6- 当一信号造成中断，此时已经读取了部分数据时。

    //-- return
    //-- 成功:
    //    常规 -- 返回 读到的 字节数
    //    若到文件尾 -- 返回 0
    //-- 出错，返回 -1


#include <unistd.h>

//-- 向打开的文件 fd 写入 buf中的数据 nbytes字节。
//-- 从文件的 当前偏移量处 开始写，如果调用 open时 制定了 O_APPEND 选项
//   则在每次写时，将文件 当前偏移量 设置为 文件结尾处（也就是尾后添加模式）
//   一次成功写入后，该文件偏移量增加 实际写的字节数
ssize_t write( int fd, const void *buf, size_t nbytes );

    //-- return
    //-- 成功，返回 已写入的 字节数
    //      返回值 通常等于 nbytes。若不相等，则表示出错。
    //      出错的常见原因：磁盘已满，或者超过了 给定进程的 文件长度限制。
    //-- 出错，返回 -1.


#include <unistd.h>

//-- 原子操作 read。 比 read 函数多了 参数 offset
//-- 大致 等价于 调用 lseek 后再调用 read。
//  微小区别：
// -1- 调用 pread 时，无法中断其 定位 和 读操作
// -2- 不会更新当前文件偏移量
ssize_t pread( int fd, void *buf, size_t nbytes, off_t offset );

    //-- return
    //-- 成功:
    //    常规 -- 返回 读到的 字节数
    //    若到文件尾 -- 返回 0
    //-- 出错，返回 -1


//-- 原子操作 write。 比 write 函数多了 参数 offset
//-- 大致 等价于 调用 lseek 后再调用 write。
//  微小区别：
// -1- 调用 pwrite 时，无法中断其 定位 和 读操作
// -2- 不会更新当前文件偏移量
ssize_t pwrite( int fd, const void *buf, size_t nbytes, off_t offset );

    //-- return
    //-- 成功，返回 已写入的 字节数
    //-- 出错，返回 -1.


#include <unistd.h>

//-- 复制一个现有的 文件描述符    
//-- 这俩函数 返回的 新文件描述符 和 参数 fd 共享一个 文件表项实体。 
//-- 是 原子操作
int dup( int fd );
    //-- 等效于:
    //-- fcntl( fd, F_DUPFD, 0 ); 

    //-- 返回的 新的 文件描述符 是 当前可用的 最小数值。

//-- 是 原子操作
int dup2( int fd, int fd2 );
    //-- 等效于:
    //-- close( fd2 );
    //-- fcntl( fd, F_DUPFD, fd2 );

    //-- 可以通过参数 fd2 指定 新 文件描述符的 值。
    //-- 如果 fd2 已经 被打开，则 dup2 会先将其关闭
    //-- 如果 fd2 等于 fd，则 dup2 返回 fd2，且不关闭它。
    //      否则 fd2 的 FD_CLOEXEC 文件描述符 就被清除
    //      这样，fd2 在进程调用 exec 时是打开状态。

    //-- 两函数 return
    //-- 成功，返回 新的文件描述符
    //-- 出错，返回 -1.


#include <unistd.h>

//-- 使得 磁盘中 实际文件 与 内存缓冲区中 文件 内容一致 的 3 个函数。

int fsync( int fd );
    //-- 只 冲洗／flush 参数 fd 指定的 文件。并且等待 写操作完成后，fsync函数才返回。
    //-- 可用于 数据库。数据库需要确保 修改过的块 立即写到 磁盘上。


int fdatasync( int fd );
    //-- 类似于 fsync， 但只影响文件的 数据部分，而 除了数据部分，fsync 还会更新文件的属性
    //-- FreeBSD 8.0 不支持  fdatasync。 linux 支持。

    //-- 两函数 return
    //-- 成功，返回 0
    //-- 出错，返回 -1.

//-- 仅仅 将 所有 修改过的 块缓冲区 排入 写队列，返回就返回。并不等待 实际写操作的完成
void sync();
    //-- 守护进程 update 周期性地 调用 sync 函数（一般 30秒一次）。
    //-- 以确保 定期冲洗／flush 内核的块缓冲区。
    //-- shell 命令 sync 也调用 函数 sync。


#include <fcntl.h>

//-- 改变 已经打开的文件 fd 的属性
int fcntl( int fd, int cmd, ... ); //-- int arg 
            //-- 第三个参数有时是 int类型，有时是 指向一个结构的指针。

    //==== fcntl 拥有 5 种功能： =====
    //-1-  复制一个已有的描述符：     cmd = F_DUPFD 或 F_DUPFD_CLOEXEC 
    //-2-  获取／设置 文件描述符标志： cmd = F_GETFD 或 F_SETFD
    //-3-  获取／设置 文件状态标志： cmd = F_GETFL 或 F_SETFL
    //-4-  获取／设置 异步IO所有权： cmd = F_GETOWN 或 F_SETOWN
    //-5-  获取／设置 记录锁：      cmd = F_GETLK 或 F_SETLK 或 F_SETLKW
    
    //-- 两函数 return
    //-- 成功，依赖 cmd 而不同
    //-- 出错，返回 -1.

    //============= cmd 解释 ================
    //-1-  F_DUPFD
        // 复制 文件描述符fd，新文件描述符 作为函数值返回。
        // 返回值 一般是 大于等于 第三参数 的 最小值。（fcntl的 第三参数 此时用来设置 返回值 下限）
        // 新描述符 与 fd 共享一个 文件表项。但是，新描述符有它自己的一套 文件描述符标志
        // 其 FD_CLOEXEC 文件描述符标志 被清除，这表示 该描述符 在 exec 时仍有效。

    //-2-  F_DUPFD_CLOEXEC
        // 复制 文件描述符fd，设置 与 新描述符 关联的 FD_CLOEXEC 文件描述符标志 的值
        // 返回 新文件描述符。

    //-3-  F_GETFD
        // 返回 fd 的文件描述符标志。 
        // 当前 只定义了 一个 FD_CLOEXEC

    //-4-  F_SETFD
        // 设置 fd 的 文件描述符标志， 新标志 按 第 3 个参数设置（int）

    //-5-  F_GETFL
        // 返回 fd 的文件状态标志

    //-6-  F_SETFL
        // 将 fd 的文件状态标志 设置为 第三参数的值（int）
        // 可以更改的标志是: O_APPEND, O_NONBLOCK, O_SYNC, O_DSYNC, O_RSYNC, O_FSYNC, O_ASYNC

    //-7-  F_GETOWN
        //  获取 当前接收 SIGIO, SIGURG 信号的 进程id 或 进程组id
        //  14.5.2 论述 这两种 异步IO信号。

    //-8-  F_SETOWN
        //  设置 接收 SIFIO 和 SIGURG 信号的 进程id 或 进程组ID
        //  正的 arg 指定一个进程id，负的arg表示 等于arg绝对值的 一个进程组id

    //============= FD_CLOEXEC 文件描述符标志 ================
    //  很多现有的 与 文件描述符标志 有关的程序 并不使用 常量 FD_CLOEXEC
    //  而是将此标志 设置为 0（系统默认，在exec时不关闭），或 1（在exec时关闭）
    //======================================================


    //============ 文件状态标志 =============
    //---- 和 open 函数中 用的 是一个东西 ----
    //-1-  O_RDONLY   只读打开
    //-2-  O_WRONLY   只写打开 
    //-3-  O_RDWR     读写打开
    //-4-  O_EXEC     只执行打开
    //-5-  O_SEARCH   只搜索打开目录
    //-6-  O_APPEND    追加写
    //-7-  O_NONBLOCK  非阻塞模式  
    //-8-  O_SYNC      等待写完成（数据和属性）
    //-9-  O_DSYNC     等到写完成（仅数据）
    //-10- O_RSYNC     同步读和写
    //-11- O_FSYNC     等待写完成（ 仅 FreeBSD,MacOSX ）
    //-12- O_ASYNC     异步IO （ 仅 FreeBSD,MacOSX ）
    //-----------------------------------
    //--  5 个访问方式标志：O_RDONLY，O_WRONLY，O_RDWR，O_EXEC，O_SEARCH 并不各自占1位。
    //     这 5 个值互斥，一个 文件的访问模式 只能取 5 个中的 1 个。
    //     此时，首先用 屏蔽字 O_ACCMODE 取得 访问方式位。然后将结果 与这 5 个中的每一个相比较
    //=======================================





#include <unistd.h>     //-- system V 系统 --
#include <sys/ioctl.h>  //-- BSD 和 Linux 系统 --

#include <termios.h>  //-- 额外的头文件，当使用 ioctl函数 实现 终端IO时。

//-- IO操作的杂物箱，终端IO 是 ioctl 使用最多的地方。
int ioctl( int fd, int request, ... );
    //-- 第三个省略的参数 常常 指向一个变量 或 结构的指针。

    //-- 每个 设备驱动程序 可定义 自己专用的 一组 ioctl 命令
    //-- 系统为 不同种类的 设备 提供 通用的 ioctl 命令

    //-- 18.12 将 说明 使用 ioctl 获取和设置 终端窗口大小
    //-- 19.7  使用 ioctl 访问伪终端的高级功能。

    //-- 两函数 return
    //-- 出错，返回 -1.
    //-- 成功，返回 其它值


#endif

