## ============================================================================ #
#   stencil test:
#                     ShaderLab command: Stencil
## ============================================================================ #
和 gpu 得 stencil buffer 相关.

stencil buffer 为 framebuffer 中得每个像素, 存储一个 8-bit 值. 
在执行 pix shader 之前, gpu 可以将这个像素中得 stencil buffer 中的值, 和某个参考值做比较, 这个过程就叫做 stencil test.

stencil buffer 中的初始值位 0;


如果 stencil test 通过了(成功了), gpu 再执行 depth test. 
如果 stencil test 没通过, 这个像素得剩余计算都会被跳过 (放弃执行)

这一意味着, 你可以把 stencil buffer 当作一个 mask, 来告诉 gpu 哪些像素需要绘制,哪些不需要.

通常使用 stencil buffer 来实现类似: 入口, 镜子 之类的东西.
另外, 当渲染 硬阴影时, 或当使用 constructive solid geometry (CSG) 技术时 (用布尔运算来消切堆叠一个物体). 也会用到 stencil buffer.

# Render pipeline compatibility
全支持

# Usage
此 command 会改变 render state. 
在 pass 和 SubShader 上都能使用.

可使用 Stencil command 来做两件不同的事:
-1- 配置 stencil test
-2- 设置 gpu 该往 stencil buffer 中写入什么值.

你可以在一次 stencil command 中同时完成这两件事. 
但更常见的做法是: 创建一个 shader object, 它将屏幕上一部分区域 遮蔽掉, 阻止其它 shader object 向其中绘制内容. 
为了实现这一点, 针对第一个 shader object, 要让它在这个 屏幕区域 永远通过 stencil test, 并且能写入 stencil buffer. 
然后配置剩余的 shader objects, 让它们不能通过这个 屏幕区域的 stencil test.

使用 Ref, ReadMask, Comp 参数来配置 stencil test.
使用 Ref, WriteMask, Pass, Fail, ZFail 参数来配置 stecil write operation.

# stencil test 公式:
(ref & readMask) comparisonFunction (stencilBufferValue & readMask)

配置格式:
# --
Stencil
{
    Ref <ref>
    ReadMask <readMask>
    WriteMask <writeMask>
    Comp <comparisonOperation>
    Pass <passOperation>
    Fail <failOperation>
    ZFail <zFailOperation>
    CompBack <comparisonOperationBack>
    PassBack <passOperationBack>
    FailBack <failOperationBack>
    ZFailBack <zFailOperationBack>
    CompFront <comparisonOperationFront>
    PassFront <passOperationFront>
    FailFront <failOperationFront>
    ZFailFront <zFailOperationFront>
}
# ==
注意,以上每一项都是 可选的


# -------- #
# ref 的可写值:
    0~255 的整型值, 默认为 0.

    参考值.
    gpu 拿 stencil buffer 中某像素的值, 和 这个参考值做比较.
    具体比较规则, 记录在 comparisonOperation 参数中.

    此值被 readmask 或 writeMask 遮蔽, 具体哪个取决于是正在执行 读操作 还是 写操作.

    gpu 也能将这个 参考值 写入 stencil buffer 中, 如果 参数: Pass, Fail 或 ZFail 的值为 "Replace"

# -------- #
# readMask 的可写值:
    0~255 的整型值, 默认为 255.

    当执行 stencil test 时, gpu 使用这个参数作为 掩码.
    (作为掩码, 255 意味着 8个bit 上读取, 值为0的位, 表示这一位 不被读取)

    执行如下功能:
    (Ref & readMask) comparisonFunction (stencilBufferValue & readMask)
    ---

    也就是说, 这个 mask 先同时作用于 ref 和 buffer目标值,
    然后再比较两者;


# -------- #
# writeMask 的可写值:
    0~255 的整型值, 默认为 255.

    当 gpu 想要向 stencil buffer 写入值时, 使用这个参数作为 掩码.
    (作为掩码, 255 意味着 8个bit 上都写 1, 猜测是表示 全通过.)

    类似其它掩码, 此掩码指定了, 8位中的哪些 bits 能被 写入操作所影响.
    比如, 值为0 表示所有位 都不能写入,  而不是意味着 stencil buffer 将被写入 0.

# -------- #
# comparisonOperation
# comparisonOperationFront
# comparisonOperationBack
# 的可写值:
    比较操作
    ( 具体可用值在下方: Comparison operation values 中 )
    默认值为 "Always"

    在 stencil test 中, gpu 作用在所有像素上的 操作.

    comparisonOperation 这个 stencil test 会作用在所有 pix 中, 无论它们 是否朝向相机.
    如果除了 comparisonOperationBack and comparisonOperationFront, 还定义了comparisonOperation, 那么 comparisonOperation 的值, 将覆盖上面两个定义.

# -------- #
# passOperation 
# passOperationFront
# passOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    如果一个像素同时通过了 stencil test 和 depth test. 
    gpu 将在这个像素上执行的操作.

    passOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 passOperationBack and passOperationFront, 还定义了 passOperation, 那么 passOperation 的值, 将覆盖上面两个定义.

# -------- #
# failOperation 
# failOperationFront
# failOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    当一个像素 没通过 stencil test, 
    gpu 将在这个像素上执行的操作.

    failOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 failOperationBack and failOperationFront, 还定义了 failOperation, 那么 failOperation 的值, 将覆盖上面两个定义.

# -------- #
# zFailOperation
# zFailOperationFront
# zFailOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    若一个像素 通过了 stencil test, 但没通过 depth test,
    gpu 将在这个像素上执行的操作.

    zFailOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 zFailOperation and zFailOperation, 还定义了 zFailOperation, 那么 zFailOperation 的值, 将覆盖上面两个定义.


# =============== #
# Comparison operation values
在 c# 中, 这些值被 Rendering.CompareFunction enum 表达.

[以下这些操作都是针对单个像素的]

# Never 
    stencil test 永远不成功
# Less
    当 参考值 小于 stencil buffer 中的值, 则 stencil test 成功
# Equal
    当 参考值 等于 stencil buffer 中的值, 则 stencil test 成功
# LEqual
    当 参考值 小于等于 stencil buffer 中的值, 则 stencil test 成功
# Greater
    当 参考值 大于 stencil buffer 中的值, 则 stencil test 成功
# NotEqual
    当 参考值 不等于 stencil buffer 中的值, 则 stencil test 成功
# GEqual
    当 参考值 大于等于 stencil buffer 中的值, 则 stencil test 成功
# Always
    stencil test 永远成功 (永远能通过)


# =============== #
# Stencil operation values
在 c# 中, 这些值被 Rendering.Rendering.StencilOp enum 表达.

[以下这些操作都是针对单个像素的]

# Keep
    保留 stencil buffer 中的当前值
# Zero
    将 0 写入 stencil buffer
# Replace
    将 参考值 Ref 写入 stencil buffer
# IncrSat
    将 stencil buffer 中当前值 +1, 如果这个值已经是 255了, 则维持在 255
# DecrSat
    将 stencil buffer 中当前值 -1, 如果这个值已经是 0了, 则维持在 0
# Invert
    将 stencil buffer 中当前值 的8个bit 全部反转
    注意:
        当配合 Cull Off 使用时, 
        一个 frag 将被测试两次, 正向面一次, 反向面一次;
        每一次进入 标记为 Invert 的这个分支, 都会执行一次翻转;
        如果进入两次, 就会执行两次翻转, (等于被抵消了)
        ---
        延迟渲染使用了这个技术
# IncrWrap
    将 stencil buffer 中当前值 +1, 如果这个值已经是 255了, 则将其变为 0
# DecrWrap
    将 stencil buffer 中当前值 -1, 如果这个值已经是 0了, 则将其变为 255


# ===== 应用举例 1 ===== #
# --
Stencil
{
    Ref 2           // 参考值为 2
    Comp Always     // stencil test 永远能通过
    Pass Replace    // 既然 stencil test 已经默认通过了,
                    // 那么只要 depth test 能通过,
                    // 就能把 参考值 2 写入 stencil buffer
}    
# ==
只要这个 pass/SubShader 能渲染到的屏幕区域, 都会在 对应的 stencil buffer 中写入 2, 作为标记.

若想防止 后续 shader 绘制到 render target 的 此区域,
或 限制它们, 让它们仅能绘制到此区域,
就可用此设置.


# ===== 应用举例 2 ===== #
# --
Stencil
{
    Ref 2       // 参考值为 2
    Comp Less   // 当 参考值 2 小于 stencil buffer 中的值, 
                // 则 stencil test 成功
} 
# ==
如果只想绘制 render target 中的 没有被 masked 的区域,
可用此设置.




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#    不推荐在 OnRenderImage() 中调用的 shader 中, 测试 stencil
# ---------------------------------------------- #

因为这些 shader pass 的 stencil buffer 并不是继承之前 渲染的 pass 的;
这些 buffer 被清零了;

想要做测试,  更简易在那种 撑满一整个 screen 的 quad 上的 shader 中做;







