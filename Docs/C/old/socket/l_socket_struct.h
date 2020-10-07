//
//========================= l_socket_struct.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.20
//                                        修改 -- 2018.06.20
//----------------------------------------------------------
//   socket 方面的 所有 数据结构
//
//----------------------------
#ifndef _NET_SOCKET_STRUCT_H_
#define _NET_SOCKET_STRUCT_H_


//----------------------------------------------------------------//
//                            IPv4
//----------------------------------------------------------------//

//--  32-bit IPv4 地址。
//--  因为历史原因，它被 封装了一层.
//--  本数据结构 早期 是一个 联合。现在已 简化为 一个 只容纳一个元素的 数据结构。
#include  <netinet/in.h>
struct in_addr{
    in_addr_t s_addr;  //-- u32 net字节排序（大端）
}; //-- 4-bytes


//-------------------
//-- IPv4 套接字地址 结构
//-- 此结构 只在 给定主机上使用，并不在网络中传递。
struct sockaddr_in{
    uint8_t      sin_len;     //-- u8. 本数据结构的 长度 == 16-bytes
    sa_family_t  sin_family;  //-- u8. AF_INET
    in_port_t    sin_port;    //-- u16. 端口号 net字节排序（大端）

    struct in_addr sin_addr;  //-- 32-bit。 IPv4 地址。嵌套在一个 数据结构中

    char         sin_zero[8]; //-- 未使用，保留。
}; //-- 16-bytes



//-------------------
//-- 通用套接字地址 结构
//-- 这个结构 是 真正被当作参数 的结构，用在各种 socket函数中。
#include  <sys/socket.h>
struct sockaddr{
    uint8_t      sa_len;      //-- u8.
    sa_family_t  sa_family;   //-- u8. 
    char         sa_data[14]; //--
}; //-- 16-bytes


//----------------------------------------------------------------//
//                            IPv6
//----------------------------------------------------------------//

//--  128-bit IPv6 地址。
#include  <netinet/in.h>
struct in6_addr{
    uint8_t s6_addr_[16]; //-- 128-bit，net字节排序（大端）
    //      s6_addr -- 正确的元素名字，但是会报错。
}; //-- 16-bytes

#define SIN6_LEN 

struct sockaddr_in6{
    uint8_t      sin6_len;      //-- u8. 本数据结构的 长度 == 28-bytes
    sa_family_t  sin6_family;   //-- u8. AF_INET6
    in_port_t    sin6_port;     //-- u16. 端口号 net字节排序（大端）

    uint32_t     sin6_flowinfo; //-- u32. 低 20-bit 是流标／flow label. 高 12-bit 保留
    
    //--为了确保 64-bit 对齐。 
    //-- 且让 sin6_addr 出现在 新的 64-bit对齐段 的头部

    struct in6_addr sin6_addr;  //-- 16-bytes。 IPv6 地址。嵌套在一个 数据结构中
 
    uint32_t     sin6_scope_id; //-- u32. 对于具备范围的地址／scoped address
                                //-- 本元素 标示其范围／scope。
                                //-- 最常见的是 链路局部地址／link-local address 的
                                //-- 接口索引 / interface index
}; //-- 28-bytes


//----------------------------------------------------------------//
//                            new 
//----------------------------------------------------------------//

//-- 新的 通用套接字地址 结构
//-- 足以容纳 系统所支持的 任何套接字地址结构
#include  <netinet/in.h>

struct sockaddr_storage{
    uint8_t      ss_len;    //-- u8. 本数据结构的长度。 视具体实现而定
    sa_family_t  ss_family; //-- u8. address family: AF_INET, AF_INET6
        
    //-- 还有一些元素，视具体实现而定，但是它们对 用户进程 是透明的，无法访问。
    //-- a -- 满足 所有地址结构的 对齐要求
    //-- b -- 足够大，能够容纳 支持的 任何地址结构。
};



















#endif


