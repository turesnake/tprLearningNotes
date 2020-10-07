//
//========================= basicfunc.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.12
//                                        修改 -- 2018.06.12
//----------------------------------------------------------
//   linux 中的 常规基础函数
//   本文件 不应被 任何 文件 包含
//
//----------------------------
#ifndef _NET_BASICFUNC_H_
#define _NET_BASICFUNC_H_


//-----------------------------------
#include  <string.h>

void* memset( void* s, int c, size_t n );
        //-- 用法和 tos中的 memset_pm 函数基本一致
        //-- param: s -- 目标地址指针
        //-- param: c -- 填充物
        //-- param: n -- 填充数量（bytes）
        //-- return: -- 指向 s 的指针。（不常用）



//-----------------------------------
// syslog是Linux系统默认的日志守护进程
// 默认的syslog配置文件是/etc/syslog.conf文件
// 任何希望生成日志信息的程序都可以向 syslog 接口呼叫生成该信息
//
#include  <syslog.h>

void openlog( const char *ident, int option, int facility );
        //-- 可选，如果不调用本函数，将在 第一次调用 syslog 时自动调用本函数

void syslog( int priority, const char *format, ... );
        //-- 
        //--
        //--

void closelog();
        //-- 可选的。
        //-- 关闭 曾被用于和 syslogd 守护进程 进行通信的 描述符

int setlogmask( int maskpri );


//-----------------------------------
// 类型转换函数
// 伪随机数生成函数
// 内存分配函数
// 进程控制函数
#include  <stdlib.h>

void exit( int status );




//------------------------------------
#include  <errno.h>
#include  <string.h> //-- 暂时未明白为什么要捆绑 加载此文件

char *strerror( int errnum );
        //-- 最常见的用法是: strerror(errno);
        //-- errno 作为全局变量，记录了上一次出错的类型
        //-- 但是 errno 只是个 int 值。
        //-- strerror(errno) 能自动获得 对应的错误信息
        //-- 返回一个 字符串指针。这个字符串就是 错误信息


//------------------------------------
#include  <stdio.h>

int  fflush( FILE *stream );
        //-- 强制冲洗一个流。使此流所有未写的数据都被传送至内核
        //-- 若 stream 是 NULL， 则此语句将导致 所有输出流被冲洗









#endif
