//
//========================= l_file_and_direct.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.19
//                                        修改 -- 2018.06.19
//----------------------------------------------------------
//   专门存放 文件和目录 模块 的 函数。 
//    APUE 第 4 章
//
//---------------------------------

#ifndef _NET_FILE_AND_DIRECT_H_
#define _NET_FILE_AND_DIRECT_H_

#include  "restrict.h" //-- 解释 关键词 restrict


//---------------------------------------------
//-- 不同系统 实现不同，大致形式如下
struct stat{
    mode_t  st_mode;  //-- file type & mode ( permissions
    ino_t   st_ino;   //-- inode number ( serial number
    dev_t   st_dev;   //-- device number ( file system
    dev_t   st_rdev;  //-- device number for special files
    nlink_t st_nlink; //-- number of links
    uid_t   st_uid;   //-- user id of owner
    gid_t   st_gid;   //-- group id of owner
    off_t   st_size;  //-- size in bytes, for regular files
    struct timespec st_atime; //-- time for last access
    struct timespec st_mtime; //-- time for last modification 
    struct timespec st_ctime; //-- time for last file status change
    blksize_t  st_blksize; //-- best IO block size
    blkcnt_t   st_blocks;  //-- number of disk blocks allocated
};


//--------------- 时间结构，包含 秒，纳秒
struct timespec{
    //...//
    time_t tv_sec;   //-- 秒
    long   tv_nsec;  //-- 纳秒
    //...//
};


//---------------------------------------------
//-- 4 个 stat 函数
//-- 获得 目标文件的 信息结构。
#include  <sys/stat.h>

//-- 通过参数 buf 返回 pathname指向的文件 的 信息结构。
int stat( const char *pathname, struct stat *buf );
        //--  常见的 使用 stat函数 的 shell命令就是 ls -l
        //--  反过来，想要知道 stat 能获得什么，可以观察下 ls 命令。

        //-- 将 符号链接 和 原文件 视为 同一文件（都看作 原文件）

int fstat( int fd, struct stat* buf );
        //-- 通过 描述符 fd 指向 目标文件

int lstat( const char *pathname, struct stat *buf );
        //-- 类似 stat，但是当 目标文件 是一个 符号链接时：
        //-- stat函数 返回 链接的那个文件的 信息。
        //-- 而本函数 返回 符号链接 本身的 有关信息

int fstatat( int fd, const char *pathname, struct stat *buf, int flag );
        //-- 参数 fd -- 当前打开目录
        //-- 参数 pathname -- 相对路径名（相对与 当前打开目录 fd）
        //-- 参数 flag -- (详见 APUE-74) 控制着 是否跟随一个符号链接。
        //   默认情况             -- 返回 符号链接 指向的那个文件的 信息
        //   AT_SYMLINK_NOFOLLOW -- 返回 符号链接 本身的信息
        //   AT_FDCMD            -- 此时，参数 pathname 是一个 相对路径名。（没说明白）

        //-- param： buf：
        //      用户提供一个 struct stat 结构对象给 函数，函数填写它并返回给用户。

        //-- 4 个函数的 return
        //-- 成功，返回 0
        //-- 出错，返回 -1

//---------------------------------------------
//-- 确认 文件类型／mode 的 宏函数
//-- 参数为 stat 数据结构中的 项 st_mode 包含了 文件类型信息。
//     可以用 以下 7 个宏函数 来确定文件类型。
//     这些 宏函数的参数是 stat结构中的 st_mode 元素。
#include  <sys/stat.h>

// S_ISREG();  //-- 是否为 常规文件
// S_ISDIR();  //-- 是否为 目录文件
// S_ISCHR();  //-- 是否为 字符特殊文件
// S_ISBLK();  //-- 是否为 块特殊文件
// S_ISFIFO();  //-- 是否为 管道 或 FIFO
// S_ISLINK();  //-- 是否为 符号链接
// S_ISSOCK();  //-- 是否为 套接字／socket


//---------------------------------
//-- 3 个 额外的 文件类型，可以用 以下 3 个宏函数 来确认
//-- 这些 宏函数的参数是 指向 state结构 的指针。 
//-- !!! 但是，linux 不讲 这 3 种 表示为 文件。所以此段无效 !!!

//  S_TYPEISMQ();   //-- 是否为 消息队列
//  S_TYPEISSEM();  //-- 是否为 信号量
//  S_TYPEISSHM();  //-- 是否为 共享存储对象


//---------------------------------------------
//-- 访问权限 测试
#include  <unistd.h>

int access( const char* pathname, int mode );

        //-- 参数 mode：
        //-- F_OK -- 测试文件 是否已存在

        //-- R_OK -- 测试 读 权限
        //-- W_OK -- 测试 写 权限
        //-- X_OK -- 测试 执行 权限
            //-- 此 3 位  可通过 按位或 组合。

int faccessat( int fd, const char* pathname, int mode, int flag );

        //-- 当参数 pathname 为 绝对路径名，或者 fd 为 AT_FDCWD 且 pathname 为 相对路径名 时：
        //-- 本函数 与 access 函数 功能相同。
        //--

        //-- 参数 flag 用于 改变 本函数的 行为：
        //-- 如果 flag 为 AT_EACCESS, 
        //-- 访问检查用的是 调用者进程的 有效用户id 和 有效组id。而不是 实际用户id 和 实际组id。

        //-- 两个函数的 return
        //-- 成功，返回 0
        //-- 出错，返回 -1


//---------------------------------------------
//--  文件模式创建屏蔽字
#include  <sys/stat.h>

mode_t umask( mode_t cmask );
        //-- 为 进程 设置 文件模式创建屏蔽字。并返回 之前的值。

        //-- 参数 cmask  由 以下 9 个 访问权限位 按位或 组合而成
        // S_IRUSR
        // S_IWUSR
        // S_IXUSR

        // S_IRGRP
        // S_IWGRP
        // S_IXGRP

        // S_IROTH
        // S_IWOTH
        // S_IXOTH

        //-- return
        //-- 返回 之前的 文件模式创建屏蔽字 （并不是本次设置的）


//---------------------------------------------
//--  更改 现有文件的 访问权限
#include  <sys/stat.h>

int chmod( const char* pathname, mode_t mode );

int fchmod( int fd, mode_t mode );

int fchmodat( int fd, const char* pathname, mode_t mode, int flag );
        //-- 当 pathname 为 绝对路径，或者，参数fd 为 AT_FDCWD 且 pathname 为 相对路径 时
        //-- 本函数 与 chmod 函数 功能相同

        //-- 参数 flag 用于 改变 fchmodat 的行为。
        //-- 当设置了 AT_SYMLINK_NOFOLLOW 标志时，本函数 并不跟随 符号链接。

        //-- 3个函数的 return
        //-- 成功，返回 0
        //-- 出错，返回 -1


//---------------------------------------------
//-- 更改 文件的 用户id 和 组id
#include  <unistd.h>

int chown( const char* pathname, uid_t owner, gid_t group );

int fchown( int fd, uid_t owner, gid_t group );
        //-- 使用 参数fd，意味着 这个文件 已经打开。
        //-- 这意味着 本函数 不能用于 改变 符号链接。

int fchownat( int fd, const char* pathname, uid_t owner, gid_t group, int flag );

int lchown( const char* pathname, uid_t owner, gid_t group );

        //-- lchown 和 fchownat 函数 更改 符号链接本身，而不是它们指向的 原文件

        //-- 如果 参数 owner 和 参数 group 某一个为 -1，则其对应的 id 不改变。

        //-- 4个函数的 renturn
        //-- 成功，返回 0
        //-- 出错，返回 -1













#endif

