//
//========================= l_byte_order.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.21
//                                        修改 -- 2018.06.21
//----------------------------------------------------------
//   专门存放 字节序 方面的 函数
//
//----------------------------
#ifndef _NET_BYTE_ORDER_H_
#define _NET_BYTE_ORDER_H_

//------- 置空 restrict 关键词 ------
#include "../restrict.h" 


//----------------------------------------------------------------//
//                         字节排序函数
//----------------------------------------------------------------//

//-- 此处的 l 是个历史产物，即便在 64-bit机器中，下列 l相关的函数，忍表示 32-bit
//-- 以下 4个函数 其实是 宏。若不注释掉将引发语法问题
//#include  <arpa/inet.h>
//#include  <netinet/in.h> 

//    uint32_t htonl( uint32_t hostint32 );

//    uint16_t htons( uint16_t hostint16 );

        //-- 两函数 return
        //-- 返回 网络 字节序，大端

//    uint32_t ntohl( uint32_t netint32 );

//    uint16_t ntohs( uint16_t netint16 );

        //-- 两函数 return
        //-- 返回 主机 字节序，事机器而定，在 386-linux 环境中，是 小端
    

//----------------------------------------------------------------//
//                         字节操纵函数
//----------------------------------------------------------------//

/*

#include  <string.h>

//--- Berkeley 系列 ---

void bzero( void* dest, size_t nbytes );
        //-- memset 的一个特殊版，将 数据全写为0

void bcopy( const void* src, void* dst, size_t nbytes );
        //-- 类似 memcpy函数，但是 参数 src, dst 顺序 是相反的。
        //-- 当 源数据串 和 目标数据串 重叠，bcopy 可以正确处理， 
        //-- 而 memcpy则不能，其结果是不可知的。此时需要用 memmove函数代替。

int bcmp( const void* ptr1, const void* ptr2, size_t nbytes  );
        //-- 类似 memcmp 函数

        //-- return
        //-- 相等，返回 0
        //-- 不相等，返回 非0 （memcmp 存在更精确的返回值，不知道 bcmp 是否一样？？？ ）


//--- ANSI C 系列 ---

void* memset( void *dst, int val, size_t len );

void* memcpy( void *dst, void *src, size_t nbytes );
        //-- 当 源数据串 和 目标数据串 重叠，memcpy 不可以正确处理
        //-- 此时改用 bcpy, 或 memmove 函数

int memcmp( const void* ptr1, const void* ptr2, size_t nbytes );

        //-- return
        //-- 若相等，返回 0
        //-- 若不同，根据 两值第一个不等字节，分别返回 <0 or >0 的值
        //-- 比较的假设是，两参数的 第一不等字节 都是 unsigned char 的前提下完成的。

*/

//----------------------------------------------------------------//
//                         地址转换函数
//----------------------------------------------------------------//

/*

//-- 在 ascii格式的 点分十进制数串 和 网络字节序（大端）的二进制格式 之间 转换 网际协议地址。
#include  <arpa/inet.h>

int inet_aton( const char* strptr, struct in_addr* addrptr );
        //-- 将 点分十进制数串 的字符串 strptr， 转换为 二进制格式 网络字节序／大端 IPv4地址，存入 addrptr

        //-- 如果参数 addrptr 为空，函数仍然能运行，但将无法保存 转换后的值。
        //-- 但是能通过 返回值，来检测 输入 字符串的 有效性。

        //-- return
        //-- 若 字符串有效，返回 1
        //-- 若 字符串无效，返回 0

in_addr_t inet_addr( const char* strptr );
        //-- 功能与 inet_aton 相同。但是 转换后的值 通过返回值来 获得。

        //-- 由于 INADDR_NONE 被用作 出错标志。所以此函数 无法处理 255.255.255.255 这个地址。
        //-- 这个地址是 IPv4 的有限广播地址

        //-- 所以， *** 此函数 已经被 弃用 ***

        //-- return
        //-- 若 字符串有效，返回 32-bit 二进制网络字节序／大端 的 IPv4地址
        //-- 若 字符串无效，返回 INADDR_NONE （ 255.255.255.255 ）

char* inet_ntoa( struct in_addr inaddr );
        //-- 将 二进制格式 网络字节序／大端 IPv4地址，转换为 点分十进制数串 字符串。

        //-- 参数 inaddr 是一个 数据结构对象，而不是 指针。 这是很罕见的。
        //-- 可能是因为 struct in_addr 结构本身就只有 4-byte大，正好是 参数大小，这种设置才成立

        //-- 该函数 获得的 字符串  实际存储在 静态内存中，这意味着 此函数是 不可重入的 ？？？
        //-- 可重入，这个概念 似乎和 线程 有关。

        //-- return
        //-- 返回一个指针，指向一个 点分十进制 数串。


//------------------------------------
//-- 新一代 地址转换函数
//-- 这两个 新函数 对 IPv4, IPv6 地址 都适用。
//-- p -- 表示 表达／presentation -- ascii
//-- n -- 表示 数值／numeric      -- 二进制格式 网络字节序／大端
int inet_pton( int family, const char* strptr, void* addrptr );
        //-- 从参数 strptr 获得输入，转换后，存入 参数 addrptr

        //-- 参数 family。 可为： AF_INET, AF_INET6.
        //-- 若将 family 设为 其他值，两函数 都返回 出错，且将 errno 设置为 EAFNOSUPPORT.

        //-- return
        //-- 成功，返回 1.
        //-- 若 参数 strptr指向的 表达式 无效，返回 0。
        //-- 若 出错， 返回 -1.

const char* inet_ntop( int family, const void* addrptr, char* strptr, socklen_t size );
        //-- 从参数 addrptr 获得输入，转换后，存入 参数 strptr

        //-- 参数 strptr 不可以是 空指针。

        //-- 参数 size 表示 strptr 的存储区大小，常被设为 INET_ADDRSTRLEN, INET6_ADDRSTRLEN <netinet/in.h>
        //-- 如果 参数 len 被设置得太小，不足以容纳 转换后数据，本函数将返回一个 空指针，且设置 errno 为 ENOSPC

        //-- return
        //-- 成功，返回 指向 转换后数据字符串 的指针
        //-- 出错，返回 NULL. （比如当 参数 size 太小时）




#include  <netinet/in.h> 
#define INET_ADDRSTRLEN  16 //-- IPv4 点分十进制 字符串 大小
#define INET6_ADDRSTRLEN 46 //-- IPv6 点分十进制 字符串 大小

*/





#endif



