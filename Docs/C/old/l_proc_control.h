//
//========================= l_proc_control.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.18
//                                        修改 -- 2018.06.18
//----------------------------------------------------------
//   专门存放 进程控制 模块 的 函数。 
//    APUE 第 8 章
//
//---------------------------------

#ifndef _NET_PROC_CTL_H_
#define _NET_PROC_CTL_H_

//---------------------------------
//-- 获得 进程标示符 pid
#include  <unistd.h>
pid_t getpid();
        //-- return
        //-- 返回 当前进程的 pid

pid_t getppid();
        //-- return
        //-- 返回 当前进程的 父进程 的 pid

uid_t getuid();
        //-- return
        //-- 返回 当前进程的 用户id  uid

uid_t geteuid();
        //--return
        //-- 返回 当前进程的 有效 用户id euid

gid_t getgid();
        //-- return
        //-- 返回 当前进程的 实际组id gid

gid_t getegid();
        //-- return
        //-- 返回 当前进程的 有效 组id egid


//---------------------------------
//-- fork
#include  <unistd.h>

pid_t fork();
        //-- fork 并不 复制 代码段。 代码段 是父子进程共享的。

        //-- 在实际应用中，常在 调用 fork后，立即调用 exec。
        //-- 这意味着，fork中 的复制内存段 的行为 意义不大。
        //-- 所以很多 OS系统，并不真的 复制 父进程的 内存数据。
        //-- 而是用 写时复制／copy-on-write 来 动态管理。
        //-- fork之后，子进程还是在访问 父进程的物理地址，只有在真的发生内存修改时，
        //-- 才会为 子进程 分配 对应的 内存段。此时，内核只会为 修改区域的 那部分内存 制作副本
        //-- 副本通常为 1页 大小。 （4KB ？？？ ）

        //-- 父子进程 的 stdin,stdout,stderr 三个 fd 其实指向 相同的 file desc 表项
        //-- 这意味着， 两进程的 三个标准流 并不是真的独立的。
        //-- 一种策略是， 父进程等待子进程 exit 后再执行。
        //-- 如果要 两进程 同时运行，父子进程 应该各自关闭自己不需要使用的 fd， 或者重新设置流
        //-- 这一策略 常在 网络服务器中 使用。
    

        //-- return
        //-- 子进程: 
        //     成功，返回 0 。 
        //     出错，没有子进程，自然也没有返回值。
        //-- 父进程: 
        //     成功，返回 子进程ID。 
        //     出错，返回 -1.


//---------------------------------
//-- wait
#include  <sys/wait.h>
pid_t wait( int *statloc );
        //-- 调用本函数之后，调用者进程 会自动进入 阻塞状态
        //-- 一直到其 某和子进程 exit。

pid_t waitpid( pid_t pid, int* statloc, int options );
        //-- 可用于 等待 特定 子进程的 exit。根据 参数pid

        //-- 不同于 wait, 本函数的调用者进程 并不会 立即进入 阻塞状态，
        //-- 而是 根据 参数 options 来做不同处理

        //-- 参数 pid：
        //-- pid == -1;  等待任一 子进程，此时和 wait 等效。 
        //-- pid > 0;    等待 参数pid 指向的 进程 的exit。
        //-- pid == 0;   等待 和调用者进程 拥有相同 组id 的 任一子进程。
        //-- pid < -1;   等于 组id等于 参数pid的绝对值 的 任一子进程。

        //-- 参数 options 详见 APUE p-193

        //-- 两函数中的 参数statloc 是用来 接收 status 用的。 
        //-- 如果将 statloc 设置为 空指针。 则不会接收 status。（但也不会出错）

        //-- 两个函数的 return
        //-- 成功， 返回 进程pid。
        //-- 出错，返回 0 或 -1.


int waitid( idtype_t idtype, id_t id, siginfo_t* infop, int options );
        //-- 与 waitpid 类似，参数布局上有区别，详见 APUE p-194

        //-- return:
        //-- 成功，返回 0
        //-- 出错，返回 -1

#include  <sys/types.h>
#include  <sys/wait.h>
#include  <sys/time.h>
#include  <sys/resource.h>

pid_t wait3( int* statloc, int options, struct rusage* rusage );

pid_t wait4( pid_t pid, int* statloc, int options, struct rusage* rusage );

        //-- 参数 rusage 允许内核返回 由终止进程 及其所有子进程 使用的 资源情况。

        //-- return:
        //-- 成功，返回 进程id pid
        //-- 出错， 返回 -1

//---------------------------------------------
//-- 7 个 exec 函数
//-- 命名规律： 
//--   l 表示 list。  参数示例： ( pathname, char* arg0, char* arg1,... char* argn, (char*)0 )
//--   v 表示 vector。 需要调用者 手动制作一个 参数指针数组
//--   e 多一个参数 envp, 可以传递一个 指向 环境字符串指针数组 的 指针。
//--     没有 e 的函数，则使用 调用者进程 中的 environ变量，为新程序复制现有的环境。 
//--   p 取 文件名 filename 作为参数
//--   f 取 文件描述符 fd 作为参数
#include  <unistd.h>

//------- 取 路径名 作为参数 -------
int execl( const char* pathname, const char* arg0, ... ); //-- 以 空指针 结尾 ／ (char*)0

int execv( const char* pathname, char* const argv[] );

int execle( const char* pathname, const char* arg0, ... ); //-- 以 空指针 结尾 ／ (char*)0
        //-- 参数示例: ( pathname, char* arg0, char* arg1, ... char* argn, (char*)0, char* envp );
        //-- 在 空指针 后面，还有一个 参数 envp

int execve( const char* pathname, char* const argv[], char* const envp[] );
        //-- 7 个函数中，真正的 系统调用。其余的 都是 库函数。

//-------- 取 文件名 filename 作为参数 -------
int execlp( const char* filename, const char* argv0, ... ); //-- 以 空指针 结尾 ／ (char*)0

int execvp( const char* filename, char* const argv[] );

        //-- 参数 filename
        //-- 如果 filename 中包含 '/'，就把它当成 路径名。
        //-- 否则，就根据 环境变量 PATH 来确定 目录（进而连接生成 完整的 路径名）
        //-- PATH,（见 APUE-168）。包含可执行文件的 路径前缀列表
        //-- 如果 通过 PATH 找到一个 可执行文件，但该文件 不是由 链接器 产生的 可执行文件
        //-- 则认为 此文件 是一个 shell脚本。 于是试图调用 /bin/sh, 并以 filename 作为 shell 的输入。
        //-- 

//-------- 取 文件描述符 fd 作为参数 -------
int fexecve( int fd, char* const argv[], char* const envp[] );
        //-- 通过 pathname 和 filename 都存在一个寻找 目标可执行文件 的过程
        //-- 直接通过 fd 来寻找会 精确很多，代价是 需要 调用者进程 提前搞到 目标可执行文件的 fd

        //-- 7 个函数的 return
        //-- 出错，返回 -1，
        //-- 成功，不返回。（直接跳转到 新的程序中去了）



//---------------------------------------------
//-- 特权 更改
//--
#include  <unistd.h>

int setuid( uid_t uid );
        //-- 设置 实际用户id， 和 有效用户id

int setgid( gid_t gid );
        //-- 设置 实际组id， 和 有效组id

        //-- 两函数的 return
        //-- 成功，返回 0。
        //-- 出错，返回 -1.

















#endif

