# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample:
(sm4)

    sample[_aoffimmi(u,v,w)] 
        dest[.mask],            
        srcAddress[.swizzle],   // A set of texture coordinates.
        srcResource[.swizzle],  // texture 寄存器
        srcSampler              // sampler 寄存器


源数据 可以是 除了 Buffers 以外的任何 资源类型;
(下面有解释)

srcAddress:
    提供了 执行采样所需的 纹理坐标集，代表了 texture空间中的一个 归一化的
    浮点数值, 区间[0,1];

    首先, address offset 会作用于 texture coordinates,
    然后, 根据 sampler state (s#) 中的设置,
    获得 Address wrapping modes, 比如:
    (wrap/mirror/clamp/border 等等, 
    这些机制作用于 超出 [0,1] 区间的 texture coordinates;

srcResource:
    是个 texture 寄存器 (t#)
    它只是一个 texture 的 占位符, 包含了被采样资源的 返回数据的类型;
    所有这些都在 Shader preamble (序言) 中被声明;

    被采样的实际资源 被绑定到 shader slot # (for t#).

srcSampler:
    是个 sampler 寄存器 (s).
    这是一个集合的 占位符, 集合内容包含:
    滤波模式, mipmap, 地址 warpping 模式;


硬件执行采样所需的信息集分为两个正交部分。
-1- 
    texture寄存器 提供 源数据 类型信息，例如, 纹理是否包含SRGB数据。
    它也关联了 被采样的实际内存;
-2-
    sampler寄存器 定义了 滤波模式等信息;

    
# --- Array Resources:
---
对于 Texture1D Arrays:
    srcAddress.g  决定了 arrays 中哪一个 slice 将被提取; 

    此值 始终被视为 缩放过的浮点值，而不是 normalized space for standard texture coordinates;
    
    然后, 一个 向 "最近的偶数" 取整 的操作 被作用于这个值,
    然后再被 clamp 到 可接受的 BufferArray 的某个区间;

---
对于 Texture2D Arrays:
    srcAddress.b 决定了 arrays 中哪一个 slice 将被提取; 


 # --- Address Offset:
    可选的后缀 [_aoffimmi(u,v,w)] 
    意为: (address offset by immediate integer)

    指定了 texture coords 需要被偏移一个整形值 (u,v,w)
    每个值占 4-bits, 区间 [-8,7];

    代表: texel space integer constant values.
    (猜测是偏移数个 texels, 所以是整数 )
    (这个 texel 是基于当前 mip lvl 而言的)

    这个修饰符能用于 Texture1D/2D Arrays 和 Texture3D,
    但不能用于 TextureCube.

    这个偏移值, 不会作用于 texture arrays lvl
    (也就是不能用来偏移 slice )

    _aoffimmi v,w 会被 Texture1Ds 忽略;
    _aoffimmi w   会被 Texture2Ds 忽略;

    先执行这个偏移, 然后再执行 Address wrapping modes 
    (wrap/mirror/clamp/border etc.)


# --- Return Type Control:
    采样返回值的格式, 由绑定到 srcResource 参数 (t#) 的资源格式 (DXGI_FORMAT*) 决定。

    例如，如果指定的 t# 绑定了格式为 DXGI_FORMAT_A8B8G8R8_UNORM_SRGB 的资源，则采样操作会将采样的 texel 从 gamma 2.0 转换为 1.0，应用过滤，
    然后结果将被作为 [0,1]区间的浮点数, 写入 dest 寄存器;

    返回值是 向量 (含4个分量)
    (如果某个组件不存在, 它将被赋予指定的默认值 )

    然后先实施 mask 修饰符,
    再实施 swizzle 修饰符;

    当使用 "点采样" 将一个采样的 32-bits 浮点数, 写入一个 32-bits寄存器时,
    it may or may not flush denormal values, but otherwise numbers are unmodified;
    ---
    这个指令可能会 刷新 denormal values (下文见注), 也可能不刷新;

    如果点采样 denormal values 的不确定性 是应用程序的一个问题，
    建议改用 ld 指令;
    此指令保证 被读取的 32-bits 值不会被修改;
    (不管它是不是 denormal 值)


# 注: 
# ~~ denormal values ~~:
# ~~ denormal number ~~:
    浮点数采用 科学计数法 来存储数值, 
    exponent 区用来存储 "有效数值", fraction区用来存储 指数部分; 比如:
        1.001 x 10^12 
    此处的 "有效数值" 就是 1.001; 这个部分的值通常不会以 0 开头,
    最小为 1.000000;
    这种数叫做: normalized number
    ---
    但是这种数有个缺点, 就是它能表达的 "无限接近0 的最小值" 是有极限的,
    比如:
        1.0 x 10^(-9999) 
    这样子, 不能更小了, 因为 右侧的指数部分写到最小了;

    ======
    denormal number 就是对这个问题的修正:
    它允许 "有效数值" 可以以 0 开头,比如:

        0.000001 x 10^(-9999) 
    
    可以看出, 右侧的指数部分不变, 但左侧的 "有效数值" 部分变得更小了;


# --- LOD Calculation:
    用于滤波的LOD 需要导数, 关于如何计算导数，请参见 deriv_rtx, deriv_rty 指令;
    sample 指令使用了 和 deriv* 指令相同的方式, 来隐式计算 texture
    coords 的导数;

    但这不会使用在 sample_l, 或 sample_d 两指令上;
    对于这两个指令, LOD, 或者导数, 都直接由 app程序 来提供;

    sample 指令的实现端可以选择:
    要么 2x2 像素共用同一个 LOD 值(包括导数值)
    要么 每个像素 独立运算;

# --- Miscellaneous Details:
    对于 Buffer & Texture1D, srcAddress.gba 是被无视的;
    对于 Texture1D Arrays,   srcAddress.ba 是被无视的;
    对于 Texture2Ds,         srcAddress.a 是被无视的;

    从没有绑定任何内容的 input slot 中提取数据, 将向所有分量写入 0;

# --- Restrictions:
---
    srcResource:
    必须是个 t# 寄存器; 不能是个 CBuffer;
    CBuffer 是不能被绑定到 t# 寄存器上的;
---
    srcSampler:
    必须是个 s# 寄存器;
---
    不允许对 srcResource, srcSampler 做相对寻址;
    (就是 +1, -1 这种)
---
    srcAddress 要么是个: temp (r#/x#),
    或: constantBuffer (cb#)
    或: input (v#) register
    或: immediate value(s).
---
    dest 要么是个: temp (r#/x#)
    或 output (o*#) 寄存器;
---
    _aoffimmi(u,v,w) 不能用于  TextureCubes.

# sammple 指令只被用于 fs;



# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample_b:
(sm4)

    sample_b[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource[.swizzle], 
        srcSampler, 
        srcLODBias.select_component // 额外多出来的参数


在选择 mip lvl 之前, 先用参数 srcLODBias 来计算 LOD;

The srcLODBias value is added to the computed LOD on a per-pixel basis, along with the sampler MipLODBias value, prior to the clamp to MinLOD and MaxLOD.

# 个人理解:
    就是用来影响 mip lvl 选择的...
    上下偏移几个 slice 这种...

# --- Restrictions
---
    和 sample 的限制基本类似;
---
    srcLODBias 的区间为 (-16.0f to 15.99f);
    超出其区间的值 将引发 "未定义行为";
---
    srcLODBias 要么是个标量, 要么是个向量的 单独分量;
    (反正必须是 单个标量值)


# sammple_b 指令只被用于 fs;


# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample_c:
(sm4)

    sample_c[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource.r,      // must be .r swizzle 
        srcSampler, 
        srcReferenceValue   // single component selected


此指令是提供给 Percentage-Closer Depth filtering (PCF) 的;
名字中的 c 表示 Comparison, "比较运算"

srcReferenceValue 要么是个标量, 要么是个向量的分量;

# 后面信息有点乱, 暂时没翻...


# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample_c_lz:
(sm4)

    sample_c_lz[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource.r, // must be .r swizzle 
        srcSampler, 
        srcReferenceValue // single component selected

行为和 sample_c 类似, 不过 LOD 被设为 0, 然后导数部分被忽略了;

"lz" 表示 0-lvl; 因为不需要 导数了, 此指令可用于 fs 以外的其它 shader;

如果 texture 带有 mipmap 信息, 则采样 0-lvl (最清晰的那张)
除非 sampler 制定了采样的 mip lvl, 
或者存在一个 LOD bias, 那就直接在 0-lvl 基础上做 偏移, 然后得到 lod-lvl 值;

因为不存在导数了, 各向异性滤波 和 各向同性滤波 的行为相同;

在 fs 中, 此指令可被用于 varying flow control 之中, 比如循环体,
此时, texture coords 是临时生成的, 
而 sample_c 指令不能用于此处;

如果 input slot 没有绑定到任何东西, 对它做提取操作, 将向所有分量写入 0;

----
    可用于: vs, gs, fs

# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample_d:
(sm4)

    sample_d[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource[.swizzle], 
        srcSampler, 
        srcXDerivatives[.swizzle], // 源地址在 x方向的导数
        srcYDerivatives[.swizzle]  // 源地址在 y方向的导数

通过额外的参数提供 x方向 和 y方向的导数; 这两个值位于: 归一化的 texture coordinate space;

srcXDerivatives 的 rgb分量, 提供: du/dx, dv/dx, dw/dx;
a分量被忽略;

srcYDerivatives 的 rgb分量, 提供: du/dy, dv/dy, dw/dy;
a分量被忽略;

在 fs 中, sample_d 不能在 2x2 像素内共享 LOD值, 必须逐像素独立计算; 

如果两个导数参数是在 fs 中生成的, 且包含 INF/NaN, sample_d 的行为可能和 sample 不一样, INF/NaN 可能会影响 LOD 值得计算;

如果 input slot 没有绑定到任何东西, 对它做提取操作, 将向所有分量写入 0;

# --- Restrictions:
---
    继承了 sample 指令的限制;
---
    srcXDerivatives, srcYDerivatives 必须是以下之一: 
        temp (r#/x#)
        constantBuffer (cb#), 
        input (v#) registers
        immediate value(s).

----
    可用于: vs, gs, fs


# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sample_l:
(sm4)

    sample_l[_aoffimmi(u,v,w)] 
        dest[.mask], 
        srcAddress[.swizzle], 
        srcResource[.swizzle], 
        srcSampler, 
        srcLOD.select_component // the LOD

直接提供了 LOD 值, 是个标量; 意味着不存在 各向异性; 此指令可用于各种 shader 程序中;

如果 srcLOD<=0, 就采样 mip lvl=0, (最大的那一层), with the magnify filter applied (if applicable based on the filter mode). 

因为 srcLOD 是浮点数, 所以如果 minify filter 是 LINEAR, 或者使用 各向异性滤波, 则其小数部分被用来在两个 mip lvl 之前做插值; 

本质了忽略了 地址导数, 所以 滤波是纯粹 各向同性的; 此时, 各向异性滤波 和 各向同性滤波 的行为一样;

Sampler states MIPLODBIAS and MAX/MINMIPLEVEL are honored.
(受到重视)

当在 fs 中被使用时, 每个像素独立计算自己的 LOD, 相邻像素之间不影响;

如果 input slot 没有绑定到任何东西, 对它做提取操作, 将向所有分量写入 0;

----
    可用于: vs, gs, fs

    
# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   sampleinfo:
(sm4.1)

    sampleinfo
        [_uint] 
        dest[.mask],          
        srcResource[.swizzle] // The shader resource.


此指令返回 "给定资源 或 光栅化器" 的样本数。

暂略...



# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ #
#   samplepos:
(sm4.1)

    samplepos 
        dest[.mask], 
        srcResource[.swizzle],       // The shader resource.
        sampleIndex (scalar operand) // The index of the sample.

暂略...














