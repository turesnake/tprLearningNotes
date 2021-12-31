# ================================================================ #
#               Case Study: ARM Mali G71 Bifrost
# ================================================================ #

因为是移动端显卡, 其侧重点在于 "节能" 而不是 "渲染性能";

使用 sort-middle 架构; 又称为 tiling architecture;

最多支持 32 个 unified shader engines; 共 384 个 ALU;

每个 shader engines, 拥有 12 个 ALU, 能在同一时刻执行 12 个 threads;
且在同一时刻, 最多持有 256 个 threads,(以供交换)

一个 shader engine 是 unified 的, 它能完成 compute, vertex, and
pixel shading 等各种任务; 

execution engine 还能执行超越函数(如 sin,cos);

当寄存器结果仅用作后续指令的输入时，这些单元还支持绕过寄存器内容。这样就不需要去访问 寄存器内容了, 以节省电能; 

此外, 在执行诸如 "texture读取" 等内存访问时, 可使用 quad manager 快速切换不同的 quad; 以降低延迟; (一次只交换 4 个 threads, 而不是 12 个)


# ------------------------ #
tiling architectures (sort-middle) 的核心思路是: 首先执行所有的 geometry processing, 以便得到每个 图元 的 posSS;

于此同时, 在 framebuffer 中创建一个 polygon list, 它含有多个指针, 每个指针指向一个 与当前 tile 重叠的 图元(通常为 三角形);

然后, 我们就知道, tile 中有哪些 图元需要处理; 这些 图元会被 栅格化, 被着色, 并将最终的着色结果存储在 on-chip tile memory 中;

当 tile 渲染完所有这些 图元, tile memory 中的数据将通过 L2 cache 写回外部 显存中, 上述设计 能有效减少 带宽使用;

然后, shader engine 再去处理下一个 tile, 直到把整个画面都绘制完毕; 


vertex shader 被分为两部分:
前半部分先计算 顶点的 pos, 然后根据这个信息, 将图元 分配给各个 tiles;
(一个图元, 比如三角形, 可能被分配给很多个 tiles)
最好, 在每个 tile 内部, (其实就是在 对应的 shader engine 内), 再去完成 vertex shader 的后半部分工作; 

一个 shader engine 会负责一个 tile 的所有绘制工作, 

tile memory:
tile 对应的小型 framebuffer, 存储 colors, depth, stencils 数据;
tile 通常很小, 比如 16x16; 
此机制的优势是:
在 fs 运行期间, 可以肆无忌惮地去访问 tile memory 中的数据, 因为是 片上缓存, 它的读写负担无比小; 这在传统架构中是无法比拟的;

甚至可以在 片上缓存上存储 buffer 的压缩版, 以此来增大对 缓存的利用率;


# ------------------------ #
Bifrost 支持 pixel local storage (PLS), 这是一种扩展, 通常被 sort-middle 架构所支持; 使用 PLS, 可在 fs 中访问 framebuffer(片上) 的 color 信息, 然后执行 custom blending 操作;
在传统架构中, blending 是显卡自动实现的, 无法被 自定义;

还可以在 tile memory 中存储每个像素的 自定义的 固定尺寸的 stucture 信息; 使用此方法可实现 延迟渲染; 

每个 Mali 架构, 都原生支持 MSAA, 以及 143 页中描述的 rotated grid supersampling (RGSS) 技术 (一个像素采样4次);

Sort-middle 架构能很好地兼容 抗锯齿技术; 只需要将 tile memory 扩容四倍, 就能支持 "4次采样" 的 AA 技术, 这在 传统架构中是不可行的;
(传统架构中, 要将整个 framebuffer 扩容 4 倍才行);

Mali Bifrost 架构还能对部分图元 有的选择用 multisampling, 对另一部分图元 选择用 supersampling; 比如, 叶子部分使用 SSAA, 剩余部分使用 MSAA;


# ------------------------ #
Bifrost 支持技术: transaction elimination; (交易消除);
如果本帧渲染的 tile 结果, 和上一帧相同, tile 通过 "checksum" 技术能检验出这件事, 然后省略掉本次 tile->显寸 的数据复制操作;

从而进一步减轻带宽负担;

对于有些休闲游戏来说, 此技术非常管用, 因为这些游戏的画面中, 有一部分区域始终是不变的;

G71 还支持技术: smart composition; 它也是一种 transaction elimination 技术,用于用户的 interface composition (界面组合 ?)
It can avoid reading, compositing, and writing a block of pixels if all sources are the same as the previous frame’s and the operations are the same.

# ------------------------ #
本架构还重度使用一些 底层节能技术, 如 clock gating and power gating;
管线中 未被使用的, 或者 inactive 的部分, 将被 shut down, 或者保持 idle 状态, 以此来节能;


# ------------------------ #
为了降低带宽, 一种 texture cache 拥有专业的 ASTC and ETC 解压缩单元;
简单说就是: 存储在 片上缓存内的数据 也是压缩过的, 取出后要解压缩;


# ------------------------ #
tiling architectures 的缺点:
整个场景中的数据需要倍传入 gpu 中, 以执行 tiling 操作, 然后将处理过的 几何信息流 送出内存;

所以, 本架构不适合执行 geometry shaders 和 tessellation; 
在 Mali 架构中, geometry shaders 和 tessellation 都在 gpu 软件层中被实现, Mali 最佳使用指南 甚至建议永不使用 geometry shader; 











