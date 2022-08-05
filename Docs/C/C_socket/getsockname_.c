// ================================================================ #
//                    getsockname / getpeername
// ================================================================ #
//  UNPV -- 94 page



#include <sys/socket.h>


//
//
//


//-- 返回 与某个套接字关联的 本地协议地址／sockaddr
int getsockname( int sockfd, struct sockaddr *localaddr, socklen_t *addrlen );

    //-- 在一个没有调用 bind 的 tcp客户端上，connect成功返回后，
    //   getsockname 用于返回 由 客户端主机内核 赋予该次连接的 本地ip地址和 本地端口号。

    //-- 在以 端口号0 调用 bind后（告知客户端本地内核 自动匹配 本地端口）
    //   getsockname 用于返回 由 客户端主机内核 赋予的 本地端口号。

    //-- 用于获取 某套接字的 地址族。

    //-- 在一个 以 通配地址 调用 bind 的 tcp服务器上，与某个客户的连接一旦成功 
    //   getsockname 可用于返回 由 服务器主机内核 赋予 该连接的 本地ip地址。
    //   此时，参数 loacladdr 必须是 已连接sockfd，而不是 监听sockfd。


//-- 返回 与某个套接字关联的 外地协议地址／sockaddr
int getpeername( int sockfd, struct sockaddr *peeraddr, socklen_t *addrlen );

    //-- 一个并发服务器执行 exec后，只能通过 getpeername 来获得 客户身份。
    //   在 非并发服务器中，accept就能获得 客户地址。
    //   在并发服务器中，accept 之后会伴随 fork。大部分情况还会调用 exec载入新的 服务器程序
    //   这次载入会覆盖掉 accept 获得 客户地址，已经 connfd
    //   connfd 通常作为 exec参数 传递给 新加载的 服务器程序，而 客户地址则完全丢失了，
    //   此时就需要 getpeername 来重新获得。


    //-- 两个函数的 return
    //-- 成功，返回 0
    //-- 出错，返回 -1




















