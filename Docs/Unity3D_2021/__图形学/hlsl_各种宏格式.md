# ================================================================ #
#               hlsl 的各种宏格式:
# ================================================================ #
具体查看:
https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-appendix-preprocessor


# 全部宏格式:
#define
#elif
#else
#endif
#error
#if
#ifdef
#ifndef
#include
#line
#pragma
#undef



# ---------------------------------------------- #
#    #define
# ---------------------------------------------- #

# -1-:
#define identifier [token-string]

    token-string:
        可以为 keyword, 常量, 或语句;
        ---
        此值也可为空, 比如:

            #define AAA

        此时, 标识符: AAA 依然被定义了, 
        此时可用: #if defined, #ifdef, 和 #ifndef 指令检测 AAA 的存在;


# -2-:
#define identifier( argument0, ... , argumentN-1 ) [token-string]

    定义 宏函数,
    暂略...


# ---------------------------------------------- #
# 三种方式的比较:
#       #ifdef AAA
#       #if defined (AAA)
#       #if AAA
# ---------------------------------------------- #

# ------------:
#   #ifdef AAA
#   #if defined (AAA)
这两种是等价的, 都是用来判断 AAA 是否存在, AAA 有没有值无所谓, 只要被定义了就行;

# ------------:
#   #if AAA
只有当 AAA 为true, 或不为0 时, 此表达式才成立


# +++++++ 举例 ++++++++ #
# ==:
    #define AA 
    #define INT_0 	 0
    #define INT_1 	 1
    #define INT_3 	 3
    #define FLOAT_0  0.0
    #define FLOAT_2  2.0
    #define STRING_  "abc"
    #define BOOL_1   true   // 虽然被定义了, 但后面的值无法被解释
                            // 但此宏可被赋值给一个 bool 类型变量;
    #define BOOL_2   True   // 虽然被定义了, 但后面的值无法被解释
    #define BOOL_3   TRUE   // 虽然被定义了, 但后面的值无法被解释
    #define BOOL_4   (2>1)  // 这才是真正有效的 bool 宏


    #ifdef NN       -- false
    #ifdef AA       == true
    #ifdef INT_0    == true
    #ifdef INT_1    == true
    #ifdef INT_3    == true
    #ifdef FLOAT_0  == true
    #ifdef FLOAT_2  == true
    #ifdef STRING_  == true
    #ifdef BOOL_1   == true
    #ifdef BOOL_2   == true
    #ifdef BOOL_3   == true
    #ifdef BOOL_4   == true

    #if NN       -- fasle
    #if AA       -- 报错, 无效询问语句, 无法判断真假
    #if INT_0    -- false
    #if INT_1    == true   非0 即为真
    #if INT_3    == true   非0 即为真
    #if FLOAT_0  -- 报错, 无效询问语句, 无法判断真假
    #if FLOAT_2  -- 报错, 无效询问语句, 无法判断真假
    #if STRING_  -- 报错, 无效询问语句, 无法判断真假
    #if BOOL_1   -- false
    #if BOOL_2   -- false
    #if BOOL_3   -- false
    #if BOOL_4   == true    唯一真正的 真假值























