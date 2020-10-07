
// ================================================================//
//                           connect
// ================================================================//
// UNPV -- 80 page

#include  <sys/socket.h>

//-- tcp客户 用 connect 建立与 tcp服务器的 连接。
//  将激发 三路握手过程。 且仅在连接建立成功，或出错时 返回
//
int connect( int sockfd, const struct sockaddr *servaddr, socklen_t addrlen );
    //== sockfd
    //  由 socket函数返回的 socket套接字

    //== servaddr
    //  指向 服务器sockaddr 的指针

    //== addrlen
    //  服务器sockaddr 的大小

    //-- return
    //-- 成功，返回 0
    //-- 出错，返回 -1
    //
    //  -1- 若 tcp客户没有收到 SYN分节的响应，返回 ETIMEDOUT 。
    //      举例：
    //      客户发送 SYN，若无响应则等待6s，再发送一个。
    //      若仍无响应等待24s，后再发送一个。
    //      若总共等75s后，仍未响应，返回本错误。
    //
    //  -2- 若 tcp客户 SYN 的响应是 RST（复位），
    //      则表明该服务器在我们指定的端口上没有进程在等待 connect
    //      比如：服务器当前不在运行。
    //      这是一种 硬件错误／hard error
    //      客户一收到 RST 就马上返回 ECONNREFUSED
    //      
    //      RST 是 tcp在发生错误时发送的 一种 tcp分节。
    //      产生 RST 的三个条件：
    //          1. 收到客户的 SYN，但目标端口上没有正在 监听的服务器
    //          2. tcp 想取消一个 已有连接。
    //          3. tcp 接收到 一个根本不存在的 连接上的 分节
    //
    //  -3- 若 tcp客户发送的 SYN 在中间某路由器上 引发一个 "destination unreachable"
    //      的 ICMP 错误，则认为是一种 软错误／soft error
    //      客户主机第一时间 保存该信息，并按第一种情况所述的时间间隔，再发送 SYN，
    //      若在某个规定时间，比如75s，后仍未收到响应，则把保存的 ICMP错误信息
    //      作为 EHOSTUNREACH 或 ENETUNREACD 返回给进程。 
    //      以下两种情况也有可能：
    //          1. 按照本地系统的转发表，根本没有到达远程系统的路径
    //          2. connect调用 根本不等待就返回


    //--- 若 connect失败，则本 sock套接字不再可用，必须关闭
    //  不能对这样的 sockfd 再次使用 connect
    
    //  每次 connect 失败后，都必须 close当前 sockfd，
    //  然后 重现调用 socket









