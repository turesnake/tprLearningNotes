
// ===================================================================== #
//      
// ===================================================================== #
//   字节操纵函数
//---------------------


#include  <string.h>


//-----------------------//
//      ANSI C 系列 
//-----------------------//

void* memset( void *dst, int val, size_t len );

void* memcpy( void *dst, void *src, size_t nbytes );
        //-- 当 源数据串 和 目标数据串 重叠，memcpy 不可以正确处理
        //-- 此时改用 bcpy, 或 memmove 函数

int memcmp( const void* ptr1, const void* ptr2, size_t nbytes );

        //-- return
        //-- 若相等，返回 0
        //-- 若不同，根据 两值第一个不等字节，分别返回 <0 or >0 的值
        //-- 比较的假设是，两参数的 第一不等字节 都是 unsigned char 的前提下完成的。


//-----------------------//
//     Berkeley 系列 
//-----------------------//

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














