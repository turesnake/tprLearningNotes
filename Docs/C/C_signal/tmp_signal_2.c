
//-- sleep 2 ---

#include <setjmp.h>
#include <signal.h>
#include <unistd.h>

static jmp_buf env_alrm; //-- jmp节点

static void sig_alrm( int signo ){
    longjmp( env_alrm, 1 ); //-- 返回 1
}

unsigned int sleep2( unsigned int seconds ){

    if( signal(SIGALRM, sig_alrm) == SIG_ERR ){
        return( seconds ); //-- signal 调用失败，退出 sleep1 函数。
    }

    if( setjmp(env_alrm) == 0 ){
        alarm( seconds );
        pause();
    }

    return( alarm(0) );
}

