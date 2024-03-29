
// ================================================================ #
//             getenv / putenv / setenv / unsetenv / 
// ================================================================ #


//---------------------------------
//-- 环境变量值。
//-- 环境字符串： name=value 
#include  <stdlib.h> 

//-- 每个程序 都接收一张 环境表。是一个 字符指针数组。
//-- 每个指针，指向一个以null结束的 字符串。
//-- 全局变量 environ ，则指向 当前进程所绑定的  环境表。
//-- 尽量使用 getenv, 而不要直接访问 environ. 
extern char** environ; 

char* getenv( const char* name );
        //-- 根据参数 name，获得 环境变量中，对应的 value 的指针。
        //-- 

        //-- return:
        //-- 若找到，返回 指向与 name 关联的 value 的指针
        //-- 若未找到， 返回 NULL。

int putenv( char* str );
        //-- str 为 形式为 name=value 的字符串。 将其放入 环境表中
        //-- 如果 name 已经存在，则先删除 其原来的定义。

        //-- 本函数 并不会为 str这个字符串 分配存储空间，而是直接让 环境表中的对应指针指向它。
        //-- 这一实现的 潜在风险是，如果 str 这个字符串是在 函数栈中临时创建的，
        //-- 那么等 函数返回后，这个 字符串就失效了。

        //-- return: 
        //-- 成功，返回 0
        //-- 出错，返回 非0

int setenv( const char* name, const char* value, int rewrite );
        //-- 首先在 环境表中查找是否存在 name 指向的那一项。
        //-- 如果不存在，则添加一项 新的环境字符串，其name设置为 参数name的值，其value设置为 参数value的值。
        //-- 如果 此name指向的项 已经存在，则观察 参数 rewrite： 
        //--    当 rewrite 非0时： 则用 value的值 代替 此环境字符串 中原有的 value值。
        //--    当 rewrite 为0时： 则维持原状，且不报错。

        //-- 与 putenv 不同，本函数 会主动分配存储空间 来存放 新的 环境字符串。

int unsetenv( const char* name );
        //-- 删除 name 指向的那一项。 
        //-- 如果不存在 name那项。则什么也不做，也不报错

        //-- 两个函数 return：
        //-- 成功，返回 0. 
        //-- 出错，返回 -1.


