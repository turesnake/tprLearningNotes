//
//========================= l_signal_func.h ==========================
//                         -- NET --
//                                        创建 -- 2018.07.24
//                                        修改 -- 2018.07.24
//----------------------------------------------------------
//   signal ／ 信号
//   APUE 第 10 章
//----------------------------

#include <signal.h>

//-- signal 是老函数，提供不可靠的信号语义，
//  提供此函数主要是为了向后兼容 要求此旧语义的应用程序。新应用程序不应使用 这些不可靠信号。
void ( *signal(int signo, void (*func)(int)) )(int);
    //------- 声明解析 ----------//
    // signal 函数拥有 2个参数：
    //  -- int signo,
    //  -- void (*func)(int)
    //        此处的 参数 func 是一个函数指针，指向的函数声明为 void (*)(int)
    // signal 的返回值：
    //  -- void (*)(int)
    //        也是一个 函数指针，且和 参数 func 的类型一样。
    //--------------------------//

    //-- param: signo 信号名（比如 SIGABRT）
    //-- param: func
        // -- SIG_IGN 
        //      向内核表示 忽略此信号（ signo ）（ 除了 SIGKILL, SIGSTOP ）
        // -- SIG_DFL
        //      接到信号 signo 后，执行系统默认动作
        // -- 当接到此信号后要调用的 函数的地址
        //      手动设置 信号 signo 的 信号处理函数（ signal handler ）/ 信号捕捉函数（ signal-catching function ）

    //------- 简化 signal 函数的表达 --------
    // typedef void Sigfunc(int);
    // Sigfunc *signal( int, Sigfunc * );

    //--------- signal 函数的 缺点 ---------
    //-- 想要通过 signal函数来获得 信号的原有 处理方式，就得先给它 随便指定一个 新的处理方式，这很不方便。
    //   可以用 sigaction 函数 来更为方便的实现这一功能。

    //--------- fork --------------
    //  fork 创建的 子进程 将继承 父进程的 信号处理方式。

    //--------- exec -------------
    // exec 启动一个新进程，它的所有信号都被设置为 默认动作。

    //--------- shell 后台运行的进程 -----
    //  后台进程 被创建时，其 中断和退出信号 的处理方式 都被设置为 忽略
    //  不然，一个 ctl+C, 就能吧 前台和后台的所有进程 都关闭，这显然时不对的。

    //-- return
    //-- 成功，返回之前的 信号处理配置。
    //      注意，并不是 参数 func 表示的 处理方式，而是 该信号原本的 处理方式（常量／函数指针）
    //-- 失败，返回 SIG_ERR


#include <signal.h>

//-- 将信号发送给 进程或进程组，
int kill( pid_t pid, int signo );

    //-- param: pid:
    //-1-  pid > 0
        //    将该信号 发生给 pid 的进程
    //-2-  pid == 0
        //    将该信号，发送给 与发送者进程 同属一个进程组的 所有进程（这些进程的进程 组id 等于 发送进程的 进程 组id）
        //    而且是 发送进程 有权限 向其发送信号 的进程。
        //    此处的 “所有进程” 不包括 实现定义的 系统进程集。（比如内核进程 和 init 进程（pid==1））
    //-3-  pid < 0
        //    将该信号 发送给 进程 组id为 pid的绝对值 ，且发送进程有权限向其发送信号的 所有进程。
    //-4-  pid == -1
        //    将该信号 发送给 发送进程 有权限向其发送信号的 所有进程。
        //    此处的 “所有进程” 不包括 实现定义的 系统进程集。（比如内核进程 和 init 进程（pid==1））
    
    //--- 由于 进程发送信号 需要权限，root用户 可以向 任何进程发送信号。
    //--- 对于 非root用户，规则是， 发送者的 实际用户id 或 有效用户id，必须等于 接受者的 实际用户id 或 有效用户id
    //--- 特例。如果被发送的信号是 SIGCONT，则进程可将它 发送给 属于同一会话的 任一其他进程。
    
    //-- param: signo
    //-- signo == 0 时， 0是 空信号，如果发送空信号，则kill仍执行正常的 错误检测，但不发送信号。
    //   这通常用来 确定一个特定的进程是否仍然存在。
    //   如果向一个 不存在的进程发送空信号，则 kill 返回 -1. errno 被设置为 ESRCH.
    //   需要注意的是，这个 pid会被其它进程使用，此时这种检测就不灵了。
    //   而且，这个方法不是 原子级操作，在kill 向调用者返回结果的窗口，刚刚还存在的 目标进程可能突然终止了
    //   所以这种检测 意义不大。

//-- 进程向自己发送信号
int raise( int signo );
    //-- 调用  raise(signo);
    //-- 等价于 kill( getpid(), signo );

    //-- 两函数的 return
    //-- 成功，返回 0
    //-- 出错，返回 -1

#include <unistd.h>

//-- 设置一个 定时器，当定时器超时时，产生 SIGALRM 信号，
//-- 如果 忽略或不捕捉 此信号，则其默认动作是：终止 调用alarm函数的 进程。
unsigned int alarm( unsigned int seconds );

    //-- 每个进程 只有一个 闹钟时间，如果在 调用 alarm 时，之前已经 调用一次，且之前设置的 闹钟时间还没超时
    //-- 则 把前一次闹钟时间的 余值 作为本次 alarm 函数调用的 返回值。
    //-- 之前注册的闹钟时间则被 新值代替。
    //      也就是说，前一次已经作废了，把前一次的余留时间 作为 alarm函数返回值 返回出来，
    //      然后把唯一的闹钟 更新为 这次设置的时间。

    //-- 如果上一次 alarm 调用尚未超时，且本次调用的 参数 seconds 设为 0.
    //      则取消上一次 闹钟，且将 上一次闹钟 余留时间，作为本次 alarm 返回值。

    //------ 尽管 SIGALRM 的默认动作是 终止进程，但大多数使用闹钟的进程 会捕捉 此信号。
    //-- 如果此进程 要终止，则在终止之前，它可以执行所需的 清理操作
    //-- 如果 进程想要 捕捉 SIGALRM 信号，则必须在 调用 alarm 之前，安装此信号的 处理程序。

    //-- param: seconds
    //--  定时 秒数。
    //    时间到达时，信号由 内核产生，

    //-- return:
    //-- 返回 0
    //      当上次闹钟时间 已经用完时，或者没有上次闹钟时。
    //--以前设置的闹钟时间的 余留秒数。
    //      当上次闹钟时间 尚未用完时。


#include <unistd.h>

//-- 使得 调用者进程 挂起，直到 捕捉到一个 信号。
int pause(void);

    //-- 只有执行一个 信号处理程序，并从其返回，pause才返回。

    //-- return:
    //-- 返回 -1，errno 设置为 EINTR



#include <signal.h>
//-- 以下几个函数 都是 宏， 在名前添加 '_' 来规避编译器错误

//-- 信号集 set。 1-bit 容纳 1个信号。 假设系统有 31 个信号。则可以用 u32 来实现 sigset_t。

int _sigemptyset( sigset_t *set );
    //-- 初始化 由 set 指向的信号集，清除其中所有信号。将 set 设置为 0 （每 1 bit 都设置为 0）

int _sigfillset( sigset_t *set );
    //-- 初始化 由 set 指向的 信号集，使其包括 所有信号，将 set 中每1bit 都设置为 1

    //-- 所有应用程序在 使用信号集前，要对该信号集 调用 sigemptyset 或 sigfillset 一次。
    //-- 这是因为 C编译程序 将不赋初值的 外部变量 和静态变量都初始化为 0，


//------ 一旦已经初始化 一个信号集，下面就可以 在 该信号集中 增减 特定的信号 -------

int _sigaddset( sigset_t *set, int signo );
    //-- 将信号 signo 添加到 信号集 set 中。 将 signo 对应的 位 设置为 1.

int _sigdelset( sigset_t *set, int signo );
    //-- 从信号集 set 中 删除一个 信号。将 signo 对应的 位 设置为 0.

    //-- 4个函数的 return
    //-- 成功，返回 0
    //-- 出错，返回 -1
    //      如果出错是因为 参数 signo 是无效值，则 设置 errno 位 EINVAL

int _sigismember( const sigset_t *set, int signo );

    //-- 测试 信号集 set 中，signo 对应的 位， 是 1 还是 0.

    //-- return
    //-- 真，返回 1
    //-- 假，返回 0


#include <signal.h>

//-- 信号屏蔽字： 规定了 一个进程的 当前阻塞而不能传递给 该进程的 信号集

//-- 检测或更改 一个进程的 信号屏蔽值。或同时进行检测和更改 进程的 信号屏蔽字
int sigprocmask( int how, const sigset_t *set, sigset_t *oset );
    //-- 此函数仅用来处理 单线程进程。 多线程进程中信号 的屏蔽 使用 另一个函数 12.8

    //-- param: oset
    //     若 oset 是 非空指针，那么 进程的 当前信号屏蔽字 通过 oset 返回。
    //     注意，返回的是 更新前的 屏蔽字，即 old set

    //-- param: set
    //     若 set 是 非空指针，则参数 how 指示 如何修改 当前信号 屏蔽字
    //     若 set 是 空指针，则 不改变 该进程的 信号屏蔽字， 此时的 how 也无意义了

    //-- param: how
    //-1-  SIG_BLOCK
        //   该进程 新的信号屏蔽字 是 其当前信号屏蔽字 和 set 指向信号集 的并集。
        //   set 包含了 希望阻塞的 附加信号
    //-2-  SIG_UNBLOCK
        //   该进程 新的信号屏蔽字 是 其当前信号屏蔽字 和 set 指向信号集 的交集。
        //   set 包含了 希望解除阻塞的 信号
    //-3-  SIG_SETMASK
        //   该进程 新的信号屏蔽字 是 set 指向的值。

    //--------------
    //  调用 本函数后，如果有任何 未决的，不再阻塞的信号（也就是 在本函数返回之前，已经身处信号队列中的 未阻塞信号）
    //  则在 本函数返回前，至少将 它们其中之一 递送给 该进程。

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1


#include <signal.h>

//-- pending -- 未决
//-- 通过 参数 set，返回 一个信号集。此信号集是 调用进程的 当前 未决 的，也是阻塞的信号。
int sigpending( sigset_t *set );

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1


#include <signal.h>

//----------------------
struct sigaction{
    void (*sa_hanlder)(int);  //-- 信号处理函数 的函数指针，或 SIG_IGN, SIG_DFL
    sigset_t sa_mask;         //-- 额外的 阻塞信号集
    int  sa_flags;            //-- 信号选项／option， 10.16
    void (*_sa_sigaction)(int, siginfo_t*, void*);  //-- alternate handler ／ 替代的 信号处理程序
};          //-- sa_sigaction 是个宏，我们暂时在此名前加‘_’,已规避 被编译器错误。
            //-- sa_hanlder 和 sa_sigaction 都是 信号处理程序，之所以要 设置两种，是因为 ，
            //-- sa_sigaction 拥有 更多参数，可以提供更精细的 操作。

//------ 用法 --------
// 通常，按下列方式 调用信号处理程序：
//    void handler( int signo );
// 但如果设置了 SA_SIGINFO 标志，则按下列方式 调用 信号处理程序。
//    void handler( int signo, siginfo_t *info, void *context );

    //--- 当更改信号动作时，如果 sa_handler 字段包含一个 信号捕捉函数的地址（不是常量 SIG_IGN, SIG_DFL）
    //  则 sa_mask 字段说明一个 信号集，在调用 该信号捕捉函数之前， 这一信号集 要加到 进程的 信号屏蔽字中
    //  仅当 从信号捕捉函数 返回时，再将 进程的信号屏蔽字恢复为 原先值。
    //  这样，在调用 信号处理程序时，就能阻塞某些信号。
    //  在 信号处理程序被调用时，操作系统 建立的 新信号屏蔽字 包括 正被递送的信号。
    //  因此保证了 在处理一个给定的信号时，如果这种信号再次发生，那么它会被阻塞到对前一个信号的处理结束为止。
    //  若同一种信号多次发生，通常不会将它们加入队列，如果在某个信号被阻塞时，它发生了5次，
    //  那么对这种信号解除阻塞后，其信号处理函数 通常只会被 调用 一次。

    //  一旦对 给定的信号 设置了一个动作，那么在调用 sigaction 显式改变它之前，该设置就一直有效。

    //------- sa_flags / 信号选项 ----------
    //-1- SA_INTERRUPT  
        //   由此信号中断的系统调用 不自动重启动
        //   与 SA_RESTART 相对立
    //-2- SA_NOCLDSTOP
        //   若 signo 时 SOGCHLD， 当子进程停止（作业控制），不产生此信号。
        //   当子进程终止时，仍旧产生此信号（ 但请参阅下面的 SA_NOCLDWAIT ）
        //   若已设置此标志，则当停止的进程 继续运行时，不产生 SIGCHLD 信号
    //-3- SA_NOCLDWAIT
        //   若 signo 时 SOGCHLD，则当调用进程的子进程终止时，不创建 僵尸进程。
        //   若 调用者进程 随后调用 wait，则阻塞到它所有 子进程 都终止，此时返回 -1 。error 设置为 ECHILD  10.7
    //-4- SA_NODEFER
        //   当捕捉到此信号时，在执行其信号捕捉函数时，系统不自动阻塞此信号（除非 sa_mask 包含此信号）
        //   注意，此种类型的操作 对应于 早期的不可靠信号
    //-5- SA_ONSTACK
        //   若用 sigaltstack(2) 已声明了一个替换栈，则此信号递送给 替换栈上的 进程
    //-6- SA_RESETHAND
        //   在此信号捕捉函数的入口处，将此信号的处理方式重置为 SIG_DFL，并清除 SA_SIGINFO 标志。
        //   注意，此种类型的信号 对应于 早期的 不可靠信号。但是，不能重制 SIGILL, SIGTRAP 这两个信号的配置
        //   设置此标志 使 sigaction 的行为 如同 设置了 SA_NODEFER 标志
    //-7- SA_RESTART
        //   由此信号中断的 系统调用自动重启动 10.5
        //   与 SA_INTERRUPT 相对立
    //-8- SA_SIGINFO
        //   此选项对信号处理程序提供了 附加信息，一个指向 siginfo 结构的指针 以及一个 指向 进程上下文标示符的 指针。
        //   此时，信号处理程序 将是 sa_sigaction 字段 指向的

    //------- sa_sigaction 字段 是一个 替代的信号处理程序 ----------
    // 当在 sigaction 结构中使用 SA_SIGINFO 标志时，使用 sa_sigaction 字段指向的 信号处理程序
    // 部分实现 可能将 sa_sigaction 字段 和 sa_hanlder 字段 使用同一存储区。所以 应用只能一次使用 其中之一。

//----------------------------
//-- 包含了 信号产生的原因 等信息
// 大致内容，不全。
struct siginfo{
    int    si_signo;  // 信号
    int    si_errno;  // 如果不为0，就是 errno常量 <errno.h>
    int    si_code;   // additional info(取决于 signal)
    pid_t  si_pid;    // 发送者进程的 pid
    uid_t  si_uid;    // 发送者 用户 真实用户id
    void  *si_addr;   // address that caused the fault ／ 故障的根源地址（地址可能不准确）
    int    si_status; // exit value or 信号
    union  sigval si_value; // 程序特殊值 application-specific value
    //...//
};

//-- sigval union 联合 包含下列 字段。
//      int sival_int;
//      void *sival_ptr;


//-- 检查或修改（或检查并修改） 与指定信号相关联的 处理动作。
//-- 此函数 取代了 signal。
int sigaction( int signo, const struct sigaction *act, struct sigaction *oact );

    //-- param: signo
        //  需要 检测或修改其具体动作的 信号

    //-- param: act
        //  若 act 非空，则将 信号 signo 的动作 改为 act 指向的
        //  act结构的 sa_flags 字段 指定对信号进行处理的 各个选项。

    //-- param: oact
        //  oldact
        //  若 oact 非空，则将 该信号 原有动作 经由 oact 返回出来。

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1


//-------------------------
// setjmp，longjmp 可以实现 从信号处理程序 向 主程序 的跳转。
// 也就是说，有相当一部分 信号处理程序，不是通过常规的 exit返回到 主程序的
// 而是通过 longjmp 硬跳回去的。
// 但是，longjmp 有一个缺陷，当捕捉到某个信号，进入此信号的处理函数，这个信号会被自动加入 进程的 信号屏蔽字中。
// 这能阻止，后来产生的 同类型信号，再次打断 当前的 信号处理函数。
// 但是，当通过 longjmp 跳回 主程序时，此进程的 信号屏蔽字 该如何处理？
// 在 linux 中，并不恢复 原来的 信号屏蔽字。 此时就需要 一对新函数：

#include <setjmp.h>

int sigsetjmp( sigjmp_buf env, int savemask );

    //-- 比 setjmp 多了个参数 savemask
    //     如果 savemask 非0，则 sigsetjmp 在 env中保存进程的 当前 信号屏蔽字。
    //     而且 其对应的 setlongjmp 也会 从 参数 env 中 回复保存的 信号屏蔽字。

    //-- return:
    //-- 若直接调用，返回 0
    //-- 若从 setlongjmp 返回，返回 非0（ 返回的值是 setlongjmp 的参数 val ）

void siglongjmp( sigjmp_buf env, int val );



#include <signal.h>

//-- 原子操作
//-- 先将 进程的 信号屏蔽字 设置为 参数 sigmask 指向的值。
//-- 然后使进程休眠。（从而等待之前被阻塞的 信号 发送到 本进程上来）
int sigsuspend( const sigset_t *sigmask );

    //-- 在 本函数 触发的 休眠期间，一个 未阻塞的信号发生，且这个信号被设置了 处理函数
    //-- 此时将会进入这个 信号处理函数。 如果这个 处理函数正常结束并返回（而不是通过 siglongjmp 跳回）
    //-- 那么，紧随 处理函数的返回，是个 sigsuspend 函数本身也将返回。
    //-- 在返回之前，sigsuspend 函数 会将 进程的 信号屏蔽字 设置回 当初的值 （而不是 参数 sigmask 指定的值）
    //-- 这种形式的返回 永远只有一个 结果：

    //-- return
    //-- 返回 -1， 并将 errno 设置为 EINTR。（以此表示，sigsuspend 函数是被一个 信号中断 从而导致返回的）

    //-- sigsuspend 函数的 常规返回永远只会返回 -1。（不然就是不返回,利用 siglongjmp 跳走了）


#include <stdlib.h>

//-- 使程序异常终止。
//-- 此函数 将 SIGABRT 信号 发送给 调用者进程（进程不应该 忽略此信号）
//-- APUE - p-292 有一个 POSIX.1 版的 abort函数的 实现，可以读一下。
void abort(void);

    //-- return
    //-- 没有返回值


#include <unistd.h>

unsigned int sleep( unsigned int seconds );

    //-- return
    //-- 0
    //-- 未休眠完的 秒数


#include <time.h>

int nanosleep( const struct timespec *reqtp, struct timespec *remtp );

    //-- return
    //-- 若正常休眠 到时间结束，返回 0
    //-- 若出错，返回 -1

#include <time.h>

int clock_nanosleep( clockid_t clock_id, int flags, const struct timespec *reqtp, struct timespec *remtp );

    //-- return
    //-- 若正常休眠 到时间结束，返回 0
    //-- 若出错，返回 错误码

#include <signal.h>

int sigqueue( pid_t pid, int signo, const union sigval value );

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1

#include <signal.h>

void psignal( int signo, const char *msg );


#include <signal.h>

void psiginfo( const siginfo_t *info, const char *msg );


#include <string.h>

char *strsignal( int signo );


#include <signal.h>

int sig2str( int signo, char *str );

int str2sig( const char *str, int *signop );

    //-- 两函数 return
    //-- 成功，返回 0
    //-- 出错，返回 -1























