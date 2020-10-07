//
//========================= l_UNPV_func.h ==========================
//                           -- NET --
//                                        创建 -- 2018.07.18
//                                        修改 -- 2018.07.18
//----------------------------------------------------------
//     《 UNIX网络编程 》 自定义 函数
//  制作这些函数的主要目的是，避免 代码与协议 相关。
//  实现能在 IPv4 IPv6 通用的 函数。
//----------------------------


#include  <sys/socket.h>

char* sock_ntop( const struct sockaddr *sockaddr, socklen_t addrlen );
    //-- inet_ntop 函数的 通用函数
    //-- 为了避免 代码与协议 相关。

    //-- return:
    //-- 成功，返回 非空指针
    //-- 错误，返回 NULL

int sock_bind_wild( int sockfd, int family );

int sock_cmp_addr( const struct sockaddr *sockaddr1,
                    const struct sockaddr *sockaddr2, socklen_t addrlen );

int sock_cmp_addr( const struct sockaddr *sockaddr1,
                    const struct sockaddr *sockaddr2, socklen_t addrlen );

int sock_get_port( cconst struct sockaddr *sockaddr, socklen_t addrlen );

char *sock_ntop_host( const struct sockaddr *sockaddr, socklen_t addrlen );

void sock_set_addr( const struct sockaddr *sockaddr, socklen_t addrlen, void *ptr );

void sock_set_port( const struct sockaddr *sockaddr, socklen_t addrlen, int port );

void sock_set_wild( struct sockaddr *sockaddr, socklen_t addrlen );




ssize_t readn( int filedes, void *buff, size_t nbytes );

ssize_t written( int filedes, const void *buff, size_t nbytes );

ssize_t readline( int filedes, void *buff, size_t maxlen );




















