# ================================================================ #
#                  D3D11 buffers
# ================================================================ #
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


# -------------------------------------------------------------------------------------------------------------- #


# =============================================== #
#      StructuredBuffer  的访问性能 怎么样 ?
# =============================================== #

目前的猜测, StructuredBuffer 是可能非常大的, 每次访问都只会读取 一个 cache line 到 本地缓存;


# --1-- 为提高访问性能, 务必手动管理 StructuredBuffer 中的 字节对齐问题;
    StructuredBuffer 内的元素 不会自动插入 padding, 而是一定紧密相连, 如果一个 元素长 5-bytes, 
    那么就会以 5*N 的状态紧密存储;
    ---
    但是 cache line 一定是字节对齐到 4x4-bytes 的,(float4 为一个单位), 
    所有一定要让 StructuredBuffer 中的元素, 字节对齐到 4x4-bytes;


# --------
# 在部分 安卓设备上, vs 可能不支持访问 StructuredBuffer;





# =============================================== #
#      StructuredBuffer  和  cbuffer
# =============================================== #

# cbuffer 特性:
    -- 存储自动 16-bytes 对齐 (一个 float4)
    -- 单个 cbuffer 的上限为 64kb (4096 个 float4 元素)
    -- coherent access patterns 
        (一致访问模式... 没太理解)
        tpr: 此处的 "一致", 似乎是对数据 "读写访问" 的一致性, 比如多线程访问时保证数据相同 ?



# StructuredBuffer 和 cbuffer 的性能比较;
https://developer.nvidia.com/content/how-about-constant-buffers
    按照此文说法, 如果 gpu 中的 array 完全符合 cbuffer 的要求, 那么从 StructuredBuffer 改为 cbuffer, 能提高很多性能;

------ 文中写道:
    As a warning, D3D 11 will unfortunately not allow you to create a resource with the flags to work as both a structured buffer and a constant buffer. 
    If you need both, you must create a second resource and use CopyResource() to move the data.
    ---
    (2015) d3d 11 可能不允许将同一份资源被同时当作 StructuredBuffer 和 cbuffer 来使用; (比如在生成端, 它是 StructuredBuffer, 在使用端, 它是 cbuffer)
    你必须再建立一个资源, 然后调用 CopyResource() 来移动它...
    ----
    微软说, 这个函数好像性能不太好... 不是很常用...

按照此文的意思, StructuredBuffer 的整体访问性能不如 cbuffer, 但好像也没有差到 texture 的程度;


# GPUs L1 caches
据说只有 16-kb, 那么是绝对装不下一个完整大小的 cbuffer 的;


# -----------------
#     perftest
# 测试了各种 资源类型的 性能....
https://github.com/sebbbi/perftest













