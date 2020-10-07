
//-- sleep 1 ---

#include <signal.h>
#include <unistd.h>

//-- SIGALRM 信号 处理程序
static void sig_alrm( int signo ){
    //-- 什么也不做 --//
}

unsigned int sleep1( unsigned int seconds ){

    if( signal(SIGALRM, sig_alrm) == SIG_ERR ){
        return(seconds); //-- signal 调用失败，退出 sleep1 函数。
    }
    alarm( seconds );  //-- 开启闹钟，时间为 seconds
    pause();           //-- 挂起本进程直到 第一个信号。但这个信号不一定是 上面的闹钟引发的
    return( alarm(0) ); //-- 若返回 0，表示 是本次闹钟发出的信号（一切正常）。
}                       //-- 若返回非0，表示 其它信号 出发了 pause 的返回。












