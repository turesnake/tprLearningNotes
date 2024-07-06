# ================================================= #
#      c#   struct  字节数
# ================================================= #


# 内存对齐
c# struct memory alignment


# 填充字节
padding bytes

memory padding/alignment



# ======================================= #
#       内存 填充 规则
# ======================================= #

会找出 struct 中字节最大的那个变量, 比如 int(4), long(8) 这种, 以它为单位尺寸去为 struct 分配内存,
所以如果 struct 中存在 long, 那么最后size 就会是 8 的整数倍;

# [StructLayout(LayoutKind.Sequential, Pack=4)]
通过 Pack 变量, 可以指定这个 struct 的 单位尺寸大小, 哪怕里面有 long...





# ------------------------------- #
#     目前使用的 查字节数 方法
# ------------------------------- #

using System.Runtime.InteropServices;
int size = Marshal.SizeOf(typeof(T));




# ------------------------------- #
#   [StructLayout(LayoutKind.Sequential)]
# ------------------------------- #

using System.Runtime.InteropServices;
[StructLayout(LayoutKind.Sequential)]
public struct AA 
{
    ...
}


用于指定结构体（struct）的布局方式。在这种情况下，LayoutKind.Sequential表示结构体的字段在内存中按照声明的顺序依次排列，不会进行重新排序或优化。

编译器会按照结构体中字段的声明顺序来分配内存，确保字段的顺序在内存中保持一致。这可以确保结构体的内存布局和字段的顺序一致，适用于需要与非托管代码进行交互或需要精确控制内存布局的场景。

对于具有复杂字段布局或需要与外部系统进行交互的结构体，使用[StructLayout(LayoutKind.Sequential)]特性能够确保结构体的字段在内存中按照声明顺序排列，而不受到编译器的优化或重新排列的影响。

总之，[StructLayout(LayoutKind.Sequential)]特性指定了结构体的顺序布局方式为顺序布局，确保结构体的字段在内存中按照声明的顺序依次排列。





# ======================================= #
#            一些测试
# ======================================= #


# 紧密排列, size = 16; 符合纸面预期
    public struct AB
    {
        int a;
        int b;
        long c;
    }


# 没有字节对齐, 没紧密排列, size = 24;
    public struct AA
    {
        int a;
        long b;
        int c;
    }
中间的 long 打破了对齐









































