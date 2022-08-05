
// ================================================================ #
//                   scanf 系列函数
// ================================================================ #



//-----------------------------------------
//-- 格式化 输入. 版本1: 参数用: ...
//-- 与 格式化输出 相逆 的过程：从流／buf 中读取数据，并将读出的数据,
//-- 按照 fmt 的格式解析。然后把对应的 数据，存入 fmt 之后的 参数中。
//-- fmt 之后的 可变参数 多半是些 指针／地址，用来存放 获得的 数据
#include  <stdio.h>

int scanf( const char *restrict fmt, ... );

int fscanf( FILE *restrict fp, const char *restrict fmt, ... );

int sscanf( const char *restrict buf, const char *restrict fmt, ... );

        //-- 以上三函数的 return:
        //-- 成功，返回 成功读入的 数据项数。也就是 fmt 中指明的 那几个 元素
        //        这个值 不一定等于 fmt 后面的参数的个数。 
        //-- 若输入出错，或在任一转换前遇到 文件尾，返回 EOF

//-----------------------------------------
//-- 格式化输入. 版本2: 参数用: va_list
//-- 用法 和 版本1 类似
#include  <stdarg.h>
#include  <stdio.h>

int vscanf( const char *restrict fmt, va_list arg );

int vfscanf( FILE *restrict fp, const char *restrict fmt, va_list arg );

int vsscanf( const char *restrict buf, const char *restrict fmt, va_list arg );



