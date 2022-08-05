# ================================================================ #
#               Compute Shader
# ================================================================ #

https://docs.unity3d.com/2021.1/Documentation/Manual/class-ComputeShader.html



# ====================================== #
#   手机兼容性:
https://zhuanlan.zhihu.com/p/68886986



# ------------------- #
# numthreads
https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/sm5-attributes-numthreads

通常被写在一个 compute shader 的 kernel 的头部, 比如:

[numthreads(64,1,1)]
void CSMain (uint3 id : SV_DispatchThreadID)
{
    ...
}

上面的 CSMain() 就是一个 kernel, 头部的 numthreads 则定义了它的布局: 一个一维数组;


# -- tpr 猜测:
# -- 



# cs_4_x 版的 compute shader, z值最大只能为 1,   x*y*z 最大个数不能超过 768;
# cs_5_0 版的 compute shader, z值最大只能为 64,  x*y*z 最大个数不能超过 1024;





# ------------------- #
# thread:
    假设:
        numthreads 为: (3,2,1)
        Dispatch 参数为 ( kernelIndex, 5, 3, 2 )
    则:
        3x2x1 中的每一个 元素, 就是一个 thread;
        ---
        有点类似 vertex shader 中的每一个 顶点;


# ------------------- #
# thread group:
# threadGroup
    假设:
        numthreads 为: (3,2,1)
        Dispatch 参数为 ( kernelIndex, 5, 3, 2 )
    则:
        那么一个 (3,2,1) 矩阵, 就是一个 threadGroup;
        而本次 Dispatch, 要一次性处理 5x3x2=30 个 threadGroup;


# ------------------- #
# group:
    假设:
        numthreads 为: (3,2,1)
        Dispatch 参数为 ( kernelIndex, 5, 3, 2 )
    则:
        本次 Dispatch 需要处理的所有 threads, ( 5x3x2 x 3x2x1 个 ) 为一个 group;









