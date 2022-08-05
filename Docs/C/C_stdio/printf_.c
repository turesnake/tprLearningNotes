
// ================================================================ #
//                   printf 系列函数
// ================================================================ #

//-----------------------------------------
//-- 格式化输出. 版本1: 参数用: ...
#include  <stdio.h>

int printf( const char *fmt, ... );
        //-- 将 格式化数据 写到 stdout

int fprintf( FILE *fp, const char *fmt, ... );
        //-- 将 格式化数据 写到 指定流 fp
        //-- 使用前 需要 调用 fdopen函数，将 文件描述符fd 转换为 文件指针 FILE

int dprintf( int fd, const char *fmt, ... );
        //-- 将 格式化数据 写到 指定文件描述符 fd
        //-- 使用前 不 需要 调用 fdopen函数，将 文件描述符fd 转换为 文件指针 FILE

        //-- 以上三函数的 return:
        //-- 成功，返回 输出字符 个数
        //-- 输出错误，返回 负值。

int sprintf( char *buf, const char *fmt, ... );
        //-- 将 格式化字符 送入 buf。 
        //-- 会自动在 字符串尾端 添加 NULL字节，但此NULL字节 不包括在 返回值中。

        //-- 此函数 可能造成 buf 的 溢出。所以不够安全

        //-- return:
        //-- 成功，返回存入 buf 的 字符数。（ 不包含 自动添加的 null字节／尾后0 ）
        //-- 编码错误，返回 负值

int snprintf( char *buf, size_t n, const char *fmt, ... );
        //-- 为了解决 sprintf 函数的 溢出风险，推出的 安全版本
        //-- 显式定义了 buf 长度 n。 超出界限的 字符 都被丢弃。

        //-- return:
        //-- 若 缓冲区足够大，返回 将要存入 buf 的字符数。（ 不包含 自动添加的 null字节／尾后0 ）
        //-- 若 编码出错，返回 负值


//-----------------------------------------
//-- 格式化输出. 版本2: 参数用: va_list
//-- 这 5 个函数 和 版本1 的 5 个函数 用法类似。
#include  <stdarg.h>
#include  <stdio.h>

int vprintf( const char *restrict fmt, va_list arg );

int vfprintf( FILE *restrict fp, const char *restrict fmt, va_list arg );

int vdprintf( int fd, const char *restrict fmt, va_list arg );

int vsprintf( char *restrict buf, const char *restrict fmt, va_list arg );

int vsnprintf( char *restrict buf, size_t n, const char *restrict fmt, va_list arg );















