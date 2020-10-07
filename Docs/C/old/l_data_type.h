//
//========================= l_data_type.h ==========================
//                         -- NET --
//                                        创建 -- 2018.07.27
//                                        修改 -- 2018.07.27
//----------------------------------------------------------
//    基本系统数据类型 ／ primitive system data type 
//    APUE 第 2 章
//
//---------------------------------
//     !!!! 注意，此头文件，不能被任何项目引用，它将破坏宏的原有定义 !!!!

#include <sys/types.h>



#define  clock_t  
            //  时钟计数器 ／ 进程时间 1.10
#define  comp_t
            //  压缩的时钟 ticks （ POSIX.1 未定义 8.14
#define  dev_t
            //  设备号 （主，次） 4.24
#define  fd_set
            //  文件描述符 集 14.4.1
#define  fpos_t
            //  文件位置  5.10
#define  gid_t
            //  数值组id
#define  ino_t
            //  inode 号 4.14
#define  mode_t
            //  文件类型，文件创建模式 4.5
#define  nlink_t
            //  目录项的 链接计数 4.14
#define  off_t
            //  文件长度 和 偏移量（带符号）（ lseek， 3.6 ）
#define  pid_t
            //  进程id 和 进程组id（带符号）8.2 ／ 9.4
#define  pthread_t
            //  线程id 11.3
#define  ptrdiff_t
            //  两个指针相减的结果（带符号）
#define  rlim_t
            //  资源限制 7.11
#define  sig_atomic_t
            //  可以 原子性 地访问的 数据类型 10.15
#define  sigset_t
            //  信号集 10.11
#define  size_t
            //  对象（如字符串）长度（不带符号）  3.7
#define  ssize_t
            //  返回字节计数的函数（带符号的）（ read, write, 3.7 ）
#define  time_t
            //  日历时间的秒计数器 1.10
#define  uid_t
            //  数值 用户id
#define  wchar_t
            //  可以表示所有不用的 字符码



















