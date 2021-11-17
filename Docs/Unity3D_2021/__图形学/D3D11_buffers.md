# ================================================================//
#                  D3D11 buffers
# ================================================================//
先放置一些零散信息...



A buffer is created as an unstructured resource. 
所以, a buffer cannot contain any mipmap levels, 
在读取一个 buffer 时无法对其 滤波, 也无法对其执行 multisampled


# ============================================== #
#             Vertex Buffer
# ---------------------------------------------- #

顶点数据包含: pos, color, texture coords, 法线, 等等;

...
                                     

# ============================================== #
#             Index Buffer
# ---------------------------------------------- #

Index buffers contain integer offsets into vertex buffers 
and are used to render primitives more efficiently. 

每个 index 是 16-bit or 32-bit, 每个 index 指向 Vertex Buffer 中的一个 顶点数据;

...


# ============================================== #
#            Constant Buffer
# ---------------------------------------------- #


A constant buffer 允许你高效的将 shader constants data 提供给 渲染管线;

可用来存储 the results of the stream-output stage. 

它看起来就像是一个 "只存储了一个元素的" vertex buffer, 
(或者说, 看起来像一个 struct 的实例)



# ============================================== #
#              structured buffer
# ---------------------------------------------- #
这个 buffer 中的每一个元素, 都是一个 struct 的实例;

比如先在 hlsl 中定义一个 struct:
    struct AA
    {
        float4 Color;
        float4 Normal;
        bool isAwesome;
    };

然后就能在 hlsl 中声明一个 structured buffer:

    StructuredBuffer<AA> mySB;   // 这是一个 只读 buffer
    RWStructuredBuffer<A> mySB2; // 支持读写

此处声明的这两个 buffer, 有点类似 array, 可以用 [idx] 去访问它的元素:

    float4 myColor = mySb[27].Color;




# ============================================== #
#            Byte Address Buffer
# ---------------------------------------------- #
# 没怎么看懂...

a buffer whose contents are addressable by a byte offset.
这个 buffer 的内容可通过 字节偏移量 来寻址。

通常, buffer 中每个元素 stride (步长) 为 S, 个数为 N, 从而可以定位 idx: S*N;

Byte Address Buffer, 也可被成为 raw buffer,  
uses a "byte value offset" from the beginning of the buffer to access data. 

这个 "byte value" 必须是 4 的倍数; 也被称为 DWORD aligned (双字节对齐)
如果它不是 4 的倍数, 其行为是未定义的;
----

Shader model 5 引入了用于访问 "read-only byte address buffer" 和 "read-write byte address buffer"
的 obj

一个 byte address buffer 的内容被设计为一个 32-bits uint 值;
如果 buffer 中的值不是真的 uint, 就是用类似 asfloat() 的函数去读取它;



# ============================================== #
#           Append and Consume Buffer
# ---------------------------------------------- #
An append and consume buffer is a special type of an unordered resource 
that supports adding and removing values from the end of a buffer similar to the way a stack works.

其实是两种 buffer, 类似 stack, 可以在这个 buffer 的尾部 添加或删除数据;

它们必须是一个 structured buffer;

-- AppendStructuredBuffer
-- ConsumeStructuredBuffer



















