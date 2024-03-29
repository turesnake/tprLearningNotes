
// ================================================================ #
//                           bind
// ================================================================ #
//  UNPV -- 81 page

#include  <sys/socket.h>

//--- 把一个 本地 sockaddr 赋予 一个套接字。
//  进程可以把一特定 IP地址 绑定到 其 套接字上
//  不过这个 IP地址 必须属于 其所在主机的 网络接口之一
//
int bind( int sockfd, const struct sockaddr *addr, socklen_t len );
    //-- 可以为 套接字 指定 ip地址 或 端口。可以都指定，也可以只指定一项，也可以都不指定。

    //-- 如果 参数addr 包含的 端口 是0，说明 进程放弃指定端口，端口将由内核来分配
    //       此时，bind函数不返回所选择值，需要通过 getsockname 来返回 协议地址。

    //-- 如果 参数addr 包含的 ip地址是 通配地址，则说明进程放弃指定ip地址，ip地址将由 内核来分配
    //       此时，内核将等到 套接字已经连接tcp，或者已在套接字上发出数据包／udp时 
    //       才选择一个本地ip地址

    //-- IPV4 的 通配ip地址 即为: INADDR_ANY / 0.0.0.0 / 0


    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1
    //   -1- 错误码：EADDRINUSE  "address already in use"
    //












