
// ================================================================//
//                   strerror / perror
// ================================================================//

//== 和 errno 相关的 两个函数。

#include  <string.h>

//-- 根据 参数 errnum，返回对应的 出错消息字符串 指针。
char* strerror( int errnum );
    //-- 传入参数 errnum 的多半为 errno。

    //-- return:
    //-- 返回指向 消息字符串的 指针。



#include <stdio.h>

//-- perror 基于 errno 当前值。在 stderr 上生成一条 出错消息。
void perror( const char *msg );
    //-- 首先输出，由参数 msg 指向的字符串。
    //-- 然后是一个 冒号，一个空格，然后是 errno对应的 出错消息。

    //-- 通过 perror函数，我们可以 定制 出错消息。
    //-- 比如，向参数 msg 传入 当前程序 路径名，由此 获得更精确的 出错消息。


// ----------------------- //
//         使用 范例
// ----------------------- //

#include <errno.h> //-- EACCES / ENOENT

//-- 假设此程序路径名为 /home/tom/a.bin 
int main_( int argc, char* argv[] ){

    //...
    fprintf( stderr, "EACCES: %s.\n", strerror( EACCES ) );
        //-- 预期输出:
        //   EACCES: Permission denied.
        //-- 通过 strerror 函数，将 errno 常量 EACCES 对应的 出错消息字符串
        //   合成到 参数二 字符串中，并将它 输出到流 stderr。

    //...
    errno = ENOENT;
    perror( argv[0] );
    exit(0);
        //-- 预期输出：
        //   /home/tom/a.bin: No such file or directory.
        //-- 首先人为改写 errno 的值。（不知道 此做法是否 合适）
        //   然后 通过 perror 函数，将 参数，即 本程序 路径名
        //   添加到 出错消息字符串中，这段消息会被 终端打印出来。
        //-- 此法可以 丰富 出错消息，很管用。

}



