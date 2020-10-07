//
//========================= restrict.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.14
//                                        修改 -- 2018.06.14
//----------------------------------------------------------
//   所有 用到 restrict 关键词的 h文件，都可以包含本文件
//    
//----------------------------

#ifndef _NET_RESTRICT_H_
#define _NET_RESTRICT_H_

//-------------------------------------------------
//             restrict 是什么
// 是C语言中的一种 类型限定符／type qualifiers。
// 用于告诉编译器，对象已经被指针所引用，
// 不能通过除该指针外 所有其他方式 修改对象的内容
//-------------------------------------------------
//  为了避免报错，在此暂且将 关键词restrict 置空
#define restrict
        //-- 此后，restrict 关键词 等于 无
//-------------------------------------------------




#endif

