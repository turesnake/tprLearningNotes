
// ================================================================//
//                           socket
// ================================================================//
//  UNPV -- 77 page

#include  <sys/socket.h>

int socket( int family, int type, int protocol );

    //-- return:
    //-- 成功，返回 socket描述符／sockfd，非负值
    //-- 出错，返回 -1

    //==== family ====
    //-- AF_INET
    //          IPv4协议
    //-- AF_INET6
    //          IPv6协议
    //-- AF_LOCAL
    //          Unix域协议
    //-- AF_ROUTE
    //          路由套接字，是内核中路由表的接口
    //-- AF_KEY
    //          密钥套接字
    //          用于支持基于加密的安全性。是内核中，密钥表的接口
    //          UNPV-19章

    //==== type ====
    //-- SOCK_STREAM
    //      字节流套接字，比如 tcp
    //-- SOCK_DGRAM
    //      数据报套接字，比如 udp
    //-- SOCK_SEQPACKET
    //      有序分组套接字
    //-- SOCK_RAW
    //      原始套接字
    //-- SOCK_PACKET
    //      仅仅 linux 支持，UNPV-78 page
    //

    //==== protocol ====
    //-- 0
    //          默认值--常用
    //-- IPPROTO_CP
    //          tcp传输协议
    //-- IPPROTO_UDP
    //          udp传输协议
    //-- IPPROTO_SCTP
    //          sctp传输协议



// ======================== //
//       AF_ 与 PF_
// ======================== //
// UNPV-79page

// 两值常常相等，多数时刻使用 AF_

//-- AF_  地址族

//-- PF_  协议族














