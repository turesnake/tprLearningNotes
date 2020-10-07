//
//========================= l_stdarg.c ==========================
//                         -- NET --
//                                        创建 -- 2018.06.12
//                                        修改 -- 2018.06.12
//----------------------------------------------------------
//   stdarg 模块的 用法
//
//----------------------------

#include  <stdio.h>
#include  <stdarg.h> 
        //-- 让 函数能接受 可变参数 



//==========================================================
//                      basic_stdarg
//-----------------------------------------------------------
//   stdarg 的基本用法。
void  basic_stdarg( int arg1, ... ){

    va_list ap;
        //-- 指向 各个 参数的 指针。
        //-- ap 的初始值是 未定义 的。也不需要定义

    int val;

    va_start( ap, arg1 );
            //-- 初始化 ap，让它指向 arg1 之后一个参数的 地址
            //-- arg1 是 第一个 可变参数 之前的一个参数。

        val = va_arg( ap, int );
            //-- 返回 ap 当前指向的 参数的 内容
            //-- 然后，指针ap将 后移 若干-bytes（根据 参数2的类型）
            //-- 此例中，ap 后移 4-bytes
            //-- va_arg函数 需要 显式 提供 参数类型，才能获得 返回值
            //-- 这是 stdarg 模块 的缺陷
        
    va_end(ap);
            //-- 结束可变参数的获取。释放 ap
            //-- 之后的 ap 的值 是不可预测的，不要使用它

    printf("arg1 = %d. val = %d. \n", arg1, val );

}












