//
//========================= l_stdio.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.14
//                                        修改 -- 2018.06.14
//----------------------------------------------------------
//   专门存放 标准IO库 的 函数
//    这些函数大部分是祖传的，需要充分熟悉它们
//
//----------------------------

#ifndef _NET_STDIO_H_
#define _NET_STDIO_H_

//------- 置空 restrict 关键词 ------
#include "restrict.h" 


//-----------------------------------------|
//                FILE
//-----------------------------------------|
// 一个数据结构，包含 标准IO库 为 管理流需要的所有信息：
// 包括 用于实际IO的 文件描述符， 指向用于该流缓冲区的指针
// 缓冲区长度， 当前在缓冲区中的字符数 以及出错标志等
//
//--- 我们称 指向 FILE对象的 指针（FILE*），为 “文件指针”。

//-----------------------------------------
#include  <stdio.h>
#include  <wchar.h>
int fwide( FILE *fp, int mode );
        //-- return:
        //-- 若流是 宽定向，返回正值。
        //-- 若流是 字节定向，返回负值。
        //-- 若流是 未定向的，返回 0


//-----------------------------------------
// 调用 下列某一函数 来 更改 流的 缓冲类型
// 确保在 流 已经被 打开后，且在对此流执行任何操作之前 调用本函数。
#include  <stdio.h>
void setbuf( FILE *restrict fp, char *restrict buf );
        //-- 使用本函数 打开 or 关闭 缓冲机制。
        //-- 为了带缓冲进行IO，参数 buf 必须指向一个 长度为 BUFSIZE 的缓冲区（定义在 <stdio.h>中）
        //-- 此函数执行后，目标流就变成了 全缓冲。
        //-- 但是如果 目标流 与 终端设备相关， 某些系统 可将此流 设置为 行缓冲
        //-- 若想 关闭缓冲， 将 buf 设置为 NULL

void setbuffer( FILE *restrict fp, char *restrict buf, size_t size );
        //-- 类似 setbuf函数。多设置了参数 size， 以取代默认值 BUFSIZE


int setvbuf( FILE *restrict fp, char *restrict buf, int mode, size_t size );
        //-- 本函数 可 更精确地 说明 所需的 缓冲类型。通过参数 mod
            //-- _IOFBF:  全缓冲。
            //-- _IOLBF:  行缓冲。
            //            针对以上两种情况：
            //            此时，buf 和 size 可选择性指定一个缓冲区 及其长度。
            //            如果此时 buf == NULL， 标准IO库 将 自动为该流 分配适当长度的缓冲区
            //            适当长度为 BUFSIZE
            //            指代终端设备的 流 默认属于此类

            //-- _IONBF:  不带缓冲。 
            //            此时将忽略 buf，size 参数。
            //            stderr 默认属于此类，从而保证错误能立即输出

        //-- return:
        //-- 成功，返回 0
        //-- 出错，返回 非0




//-----------------------------------------
//-- 强制冲洗一个 流.
//-- 默认场景 是用来 刷新 输出缓冲区。
//-- 也可刷新 输入缓冲区，这将丢弃业已缓冲的 输入数据
//-- 当关闭 某个流时，将自动刷新其 stdio缓冲区
#include  <stdio.h>
int fflush( FILE *fp );
        //-- 使得 流fp 所有未写数据 都被传送至 内核。
        //-- 当 fp == NULL， 此函数将导致 所有 输出流 被 冲洗

        //-- return:
        //-- 成功，返回 0
        //-- 出错，返回 EOF (通常为 -1 )


//-----------------------------------------
//-- 打开一个 标准IO流
#include  <stdio.h>
FILE* fopen(   const char *restrict pathname, const char *restrict type );
        //-- 打开 pathname 的指定的文件
        //--

FILE* freopen( const char *restrict pathname, const char *restrict type, FILE *restrict fp );
        //-- 在一个指定的 流（fp） 上打开一个指定的文件（pathname）。
        //-- 若该流已经打开，则先关闭该流。若该流已经定向，则使用 freopen 清除该定向。
        //-- 此函数 用于将一个 指定的文件 打开为一个预定义的流：stdin，stdout，stderr

FILE* fdopen(  int fd, const char *type );
        //-- 取一个已存在的 文件描述符（fd）。
        //-- 并使一个标准的 IO流 与 该描述符相结合。

        //-- 本函数 常用于 由创建管道 和 网络通信通道函数 返回的 描述符
        //-- 因为 这些特殊类型的文件 不能用 标准IO函数 fopen 打开，
        //-- 所以 必须先调用 设备专用函数 以获得一个 文件描述符fd，
        //-- 然后用 fdopen 使一个 标准IO流 和 该描述符fd 相结合。

        //-- 参数 type, 指定对该 IO流 的读写方式。详见 《APUE》- p119。

        //-- 三个函数的 return：
        //-- 成功，返回 文件指针。
        //-- 出错，返回 NULL


//-----------------------------------------
//-- 关闭一个 已打开的 标准IO流
#include  <stdio.h>
int fclose( FILE *fp );
        //-- 关闭流之前，会自动冲洗 输出数据。 缓冲区的 输入数据被丢弃／
        //-- 如果 stdio库 为此流 自动分配了一个 缓冲区，则释放此缓冲区。

        //-- 当一个进程 正常终止时（比如调用 exit函数，或从main函数返回）则所有带 未写缓冲数据的 
        //-- stdio流都被冲洗，所有打开的 stdio流 都被关闭

        //-- return:
        //-- 成功，返回 0. 
        //-- 出错，返回 EOF(通常为 -1 )


//-----------------------------------------
//-- 每次从 一个流 读取 一个 字符。
#include  <stdio.h>
int getc( FILE *fp );
        //-- 实现常为 宏。 意味着 参数最好不要是表达式，不然此表达式可能被计算多次。
int fgetc( FILE *fp );
        //-- 实现一定为 函数。

int getchar();

        //-- 三个函数的 return：
        //-- 成功，返回下一个 字符。 此字符类型从 unsigned char 自动转换为 int (为了兼容 EOF／-1。)
        //-- 若已到达 文件尾端 或 出错，返回 EOF。


//-----------------------------------------
//-- 由于上文的 getc / fgetc / getchar 函数在返回 -1时
//-- 不能区分是 到达文件尾，还是出错 导致。
//-- 所以用 下文的 2个函数来 检测。
#include  <stdio.h>
int ferror( FILE *fp );
int feof( FILE *fp );

        //-- 二个函数的 return：
        //-- 若 检测到 出错，返回 非0（真），
        //-- 若 检测到 未出错，返回 0

void clearerr( FILE *fp );
        //-- 每个流的 FILE对象中 存在两个标志。
        //-- 出错标志。
        //-- 文件结束标志。
        //-- 本函数 清除 这两个标志

//-----------------------------------------
//-- 将一个字符 压送回流中。
int ungetc( int c, FILE *fp );
        //-- 压送回流的 字符c，不能是 EOF
        //-- 但如果此时已到达 文件尾，仍可 回送 一个字符c。此时流 末尾变成 c,后跟 EOF
        //-- 因为 一次成功的 ungetc 会清除 该流 原有的 EOF。


//-----------------------------------------
//-- 每次 将 一个 字符 写入 一个流 
int putc( int c, FILE *fp );
        //-- 实现为 红
int fputc( int c, FILE *fp );
        //-- 实现为 函数
int putchar( int c );

        //-- 三个函数的 return：
        //-- 成功，返回 c。
        //-- 出错，返回 EOF。

//-----------------------------------------
//-- 每次从 流 读取 一行 字符
#include  <stdio.h>
char* fgets( char *restrict buf, int n, FILE *restrict fp );
        //-- param:
        //-- buf: 存放 读取字符的 buf
        //-- n:  buf 的尺寸。 以此限制 读取的行长度
            //   实际读取的 字符数 不超过 n-1. 因为最后一字节是 NULL,尾后0
        //-- fp: 目标流

char* gets( char *buf );
        //-- 默认目标流为 stdin
        //-- 此函数 会造成 buf 的溢出, 不推荐使用

        //-- 两个函数的 return：
        //-- 成功，返回 buf
        //-- 若 到达文件尾端，或 出错， 返回 NULL。

//-----------------------------------------
//-- 每次 将 一行 字符 写入 一个流
#include  <stdio.h>
int fputs( const char *restrict str, FILE *restrict fp );
        //-- 将一个 以 NULL(0) 结尾的 字符串 写入 指定流。尾端的 NULL 不写入

int puts( const char *str );
        //-- 默认目标流为 stdout
        //-- 本函数是安全的，但仍不推荐使用

        //-- 两个函数的 return：
        //-- 成功，返回 非负值
        //-- 出错，返回 EOF。

//-----------------------------------------
//-- 二进制IO。 比如读写一些 元素／数据结构 时
//-- 以下两个函数，只能用于 同一个系统上的 数据读写。
//-- 在不同系统间 交换二进制数据的 实际方法是 使用互认的 规范格式。
#include  <stdio.h>
size_t fread( void *restrict ptr, size_t size, size_t nobj, FILE *restrict fp );

size_t fwrite( const void *restrict ptr, size_t size, size_t nobj, FILE *restrict fp );

        //-- 两个函数的 param:
        //  ptr  -- buf 指针
        //  size -- 单个 元素／数据结构对象 的 大小
        //  nobj -- 元素／数据结构对象 的个数
        //  fp   -- 目标流

        //-- 两个函数的 return:
        //-- 读写的 元素／数据结构对象 的 个数
        //-- 对于 fread。如果 返回值 小于 参数nobj。 可能是 到达文件尾，也可能遇到错误，应再调用 ferror检查
        //-- 对于 fwrite。如果 返回值 小于 参数nobj。则一定遇到错误


//-----------------------------------------
//-- 定位流
#include  <stdio.h>

//-- 对于 二进制文件，其 文件位置指示器 是从 文件起始位置开始，以字节为单位 度量的偏移值。
//-- 可以通俗的理解为 文件光标
//--

//-- 以下2函数，假定 文件位置 可以存放在 一个 long变量中。
long ftell( FILE* fp );

        //-- return:
        //-- 成功，返回当前 文件位置指示。
        //-- 出错，返回 -1L。

int fseek( FILE* fp, long offset, int whence );

        //-- param:
        //-- fp     -- 目标流
        //-- offset -- 将 文件位置指示器 设置为 此值。
        //-- whence -- 与 lseek相同：
                    // SEEK_SET: 从 文件起始位置 开始计算
                    // SEEK_CUR: 从 当前文件位置 开始计算
                    // SEEK_END: 从 文件尾端     开始计算
                        //-- 部分系统 对 SEEK_END 有不同设计，目前只关注 unix系统。

        //-- 以上两函数的 return:
        //-- 成功，返回 0。
        //-- 出错，返回 -1.

void  rewind( FILE* fp );
        //-- 将 文件位置指针／文件光标 指向目标流的 起始位置。


//-------------------------------------------
//-- 与 ftell / fseek 函数类似，区别在于，文件偏移量／文件光标 不需要是 long类型了，改用 off_t类型
off_t ftello( FILE *fp );

int fseeko( FILE *fp, off_t offset, int whence );

        //-- 以上两函数的 return:
        //-- 与 ftell / fseek 函数 相同


//-------------------------------------------
//-- 使用一个 抽象数据结构 fpos_t 来记录 文件位置／文件光标。
//-- fpos_t 可以根据需要 定义为一个足够大的数。
int fgetpos( FILE *restrict fp, fpos_t *restrict pos );
        //-- 将 目标文件位置指示器 的当前值 存入 参数pos 指向的对象中

int fsetpos( FILE *fp, const fpos_t *pos );

        //-- 以上两函数的 return:
        //-- 成功，返回 0. 
        //-- 失败，返回 非0. 



/*
//-----------------------------------------
//-- 格式化输出. 版本1: 参数用: ...
#include  <stdio.h>

int printf( const char *restrict fmt, ... );
        //-- 将 格式化数据 写到 stdout

int fprintf( FILE *restrict fp, const char *restrict fmt, ... );
        //-- 将 格式化数据 写到 指定流 fp
        //-- 使用前 需要 调用 fdopen函数，将 文件描述符fd 转换为 文件指针 FILE

int dprintf( int fd, const char *restrict fmt, ... );
        //-- 将 格式化数据 写到 指定文件描述符 fd
        //-- 使用前 不 需要 调用 fdopen函数，将 文件描述符fd 转换为 文件指针 FILE

        //-- 以上三函数的 return:
        //-- 成功，返回 输出字符 个数
        //-- 输出错误，返回 负值。

int sprintf( char *restrict buf, const char *restrict fmt, ... );
        //-- 将 格式化字符 送入 buf。 
        //-- 会自动在 字符串尾端 添加 NULL字节，但此NULL字节 不包括在 返回值中。

        //-- 此函数 可能造成 buf 的 溢出。所以不够安全

        //-- return:
        //-- 成功，返回存入 buf 的 字符数。（ 不包含 自动添加的 null字节／尾后0 ）
        //-- 编码错误，返回 负值

int snprintf( char *restrict buf, size_t n, const char *restrict fmt, ... );
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
*/



//-----------------------------------------
//-- 获得一个 流 的 文件描述符fd
#include  <stdio.h>
int fileno( FILE *fp );

        //-- return:
        //-- 与 目标流 相关联的 文件描述符 fd。


//-----------------------------------------
//-- 创建 临时文件
#include  <stdio.h>
char* tmpnam( char* ptr );
        //-- 每次调用此函数，都将产生一个 与现有文件名不同的 有效路径名
        //-- 极限调用次数是 TMP_MAX. 定义在 <stdio.h>中

        //-- 参数 ptr 用来存放 新创建的 路径名（和返回值功能一样）。
        //-- 若 ptr == NULL; 则产生的 路径名 会放在一个 预设的 静态区中
        //   这个区可能会被后面新的如今名 覆盖，所以 我们要自行保存这个 路径名的 副本。
        //-- 若 ptr != NULL; 则确保这个指针指向的 空间大小 至少为 L_tmpnam。定义在 <stdio.h>中

        //-- 此函数的一个缺点是，生成 新的唯一路径名 和 用该名字创建文件 之间 并非原子级
        //-- 另一个进程 可能在 这个时间窗口中 用 相同的名字创建文件。
        //-- 因此应该使用 tmpfile / mkstemp 函数。 在这方面，它们是安全的。

        //-- return:
        //-- 指向 新创建的 路径名的 指针

FILE* tmpfile();
        //-- 创建一个 临时 二进制文件 (类型为 wb+)
        //-- 在关闭 该文件，或 程序结束时，将自动删除 这种文件。
        //-- unix 并不区分 二进制文件 和 字符文件。

        //-- 此函数的 实现思路：
        //-- 先调用 tmpnam 产生一个 唯一路径名
        //-- 然后，用 该路径名 创建一个文件。并立即 unlink 它。
        //-- 对一个文件 unlink 并不删除其内容，关闭此文件 才会删除，
        //-- 关闭文件可以是 显式关闭，也可以在 进程终止时 自动进行。

        //-- return:
        //-- 成功，返回 文件指针 FILE
        //-- 出错，返回 NULL



char* mkdtemp( char* temp_late );
        //-- 创建一个 目录，它有唯一的名字
        //-- 名字是 通过 temp_late 字符串 进行选择的。
        //-- 此字符串 后6字节 设置为 xxxxxx 的路径名。
        //-- 函数 将 这些 占位符 替换为 不同的字符 来 构建一个 唯一路径名

        //-- 此目录使用下列 访问权限位集: S_IRUSR | S_IWUSR | S_IXUSR

        //-- return:
        //-- 成功，返回 指向 目录名 的指针。
        //        同时还会 修改参数 temp_late 指向的字符串 为 当前生产的 唯一路径名
        //-- 出错，返回 NULL


int mkstemp( char* temp_late );
        //-- 创建一个 文件，它有唯一的名字. 并 open 此文件
        //-- 命名规则 和 mkdtemp 一致

        //-- 此文件使用下列 访问权限位集: S_IRUSR | S_IWUSR

        //-- 与 tmpfile 不同，本函数创建的 临时文件 不会自动删除。
        //-- 如果希望从 文件系统命名空间中 删除此文件，必须手动对其 unlink

        //-- return:
        //-- 成功，返回 文件描述符 fd。以读写方式打开
        //        同时还会 修改参数 temp_late 指向的字符串 为 当前生产的 唯一路径名
        //-- 出错，返回 -1

//-----------------------------------------
//-- 内存流
#include  <stdio.h>
FILE* fmemopen( void *restrict buf, size_t size, const char *restrict type );
        //-- 本函数 允许调用者 提供 内存流使用的 缓冲区 
        
        //-- param:
        //-- buf  -- 调用者提供的 buf
        //           如果 参数 buf 为空，函数将自动分配 size字节的 缓冲区，
        //           此时，当流关闭时，缓冲区会被释放 
        //-- size -- 指定了 缓冲区 大小-字节数
        //-- type -- 控制如何使用 流

        //-- return:
        //-- 成功，返回 流指针／文件指针 FILE*
        //-- 错误，返回 NULL


FILE* open_memstream( char** bufp, size_t* sizep );
        //-- 创建的流 面向 单字节。
        //-- 与 fmemopen 的不同：
            //-- 创建的 流 只能 写打开
            //-- 不能指定自己的 缓冲区，但可通过 bufp, sizep 访问 缓冲区 地址 和 大小。
            //-- 关闭流后 需要自行释放 缓冲区
            //-- 对流添加字节，会增加缓冲区大小

#include  <wchar.h>
#include  <stdio.h>
FILE* open_wmemstream( wchar_t** bufp, size_t* sizep );
        //-- 创建的流 面向 宽字节。
        //-- 特点 与 open_memstream 一致。

        //-- 两个函数的return:
        //-- 成功，返回 流指针 FILE*
        //-- 出错，返回 NULL










#endif

