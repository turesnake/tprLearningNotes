# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#           shadowmap "自阴影" 的消除技术
# ---------------------------------------------------------------- #

catlike 中共使用了如下几个技术:
    -- Const Depth Bias
    -- Slope Bias
    -- Normal Bias

其中, 以 normal bias 起主力作用, 
再用 slope bias 来消除 由 normal bias 导致的 "墙根处地面出现暗影" 这个问题. 


# ======================= #
#     Const Depth Bias
由:
void CommandBuffer.SetGlobalDepthBias(float bias, float slopeBias);
的一号参数: bias 设置:

# 按照 文档描述:
    缩放 gpu的 "最小可解析 depth buffer 值", 以生成一个 const depth offset. 
    随着设备的不同, "最小可解析 depth buffer 值" 也不同.
    若此值为负, 绘制的深度值 将靠近相机, 反之则远离相机.

# 按照 catlike 描述:
    若把此值设置为 正数, 则在将 shadow caster 的深度值写入 depth buffer 时, 
    写入的 深度值 会被 推离 light (反之靠近).

    实现代码为:
        buffer.SetGlobalDepthBias(50000f, 0f);
		ExecuteBuffer();
		context.DrawShadows(ref shadowSettings);
		buffer.SetGlobalDepthBias(0f, 0f);

    在调用 DrawShadows() 前设置, 在调用后又立马清零.
    这个 depth 偏移 发生在 clip-space, 参数 50000 乘以一个 "极小值". 
    这个 "极小值" 的大小, 取决于 shadowmap 所选用的精确格式. 

    此处参数被设置为 50000, 只是用来做示范. 并不是 建议值.
    此值设置的过大,将导致 "彼得潘" 现象. 

    在 catlike 后续内容中,  此值暂时被设置为 0


两份文件的描述是不同的.其中 catlike 的描述更容易理解.

具体描述, 在笔记中查找: "const_drpth_bias.jpg"


# ======================= #
#     Slope Bias
由:
void CommandBuffer.SetGlobalDepthBias(float bias, float slopeBias);
的二号参数: slopeBias 设置:

# 按照 文档描述:
    缩放 "最大 Z-slope 值", (此值又名 "depth slope")
    从而为每个 多边形的面, 生成一个可变的 depth offset.

    任何不平行于 光源的近平面/远平面 的多边形三角面, 都存在 z slope.
    也恰恰是这些面存在 "自阴影" 伪影. 

# 按照 catlike 描述:
    此参数需要被设置为 正数.
    使用此参数来 缩放: clip-space的, 沿着XY轴的 深度值导数/slope 的最大值.

    当一个面正对着光照方向, 那么这个面的受到的 修正 为 0.
    当一个面的法线 与 光照方向 几乎垂直时, 这个面受到的 修正将为无限大.

    所以, 这个参数的 推荐值 要小的多,比如 3 这种.

    这个参数很有效, 但不够直观, 需要多次尝试, 才能在 "自阴影" 和 "彼得潘" 之间做到平衡, 

此处描述的 slopeBias 的原理, 几乎和 RTR 一书中描述的是一样的.

# 位于 Light inspector 上的 调节因子
    Light inspector 中自带一个名为 Bias 的滑块, 它可取值:[0.0, 2.0]
    这个变量 原本用来控制 unity built-in 风格的 clip-space depth bias 的
    (其实就是 const depth bias)
    ---
    在我们这个 SRP 中, 它暂时是无用的. 我们用它来 控制 catlike 版的 slop Bias 强弱.

    直接使用此变量 来当作参数:
        this.buffer.SetGlobalDepthBias( 0f, light.slopeScaleBias );
        ExecuteBuffer();
        this.context.DrawShadows( ref shadowSettings );
        this.buffer.SetGlobalDepthBias( 0f, 0f );


    

# ======================= #
#     Normal Bias 

catlike 实现的 Normal Bias, 其原理 和 unity 自带的并不一样.

# catlike 版的思路: 
    在第二pass, 针对 shadowmap 的采样过程中,
    人为地让 frag 沿着自己的法线方向, 向模型外侧膨胀一段距离, 
    然后拿着这个 偏移(膨胀) 过的 posWS, 去 depth buffer 中采样. 以此来消除 "自阴影".

# 偏移的基础单位: texelSize
    frag 该沿着法线 向外侧膨胀多少距离?

    一个合理的值是: depth buffer 中每个 texel 的尺寸.
    由于 一个 cascade-tile 恰好覆盖它所对应的 cullingSphere 的尺寸,
    所以 texelSize = cullingSphere.radius * 2 / tileSize.
    被除的是 一个 tile 在长宽方向上, 所拥有的 texel 个数.

    此外, 在最坏情况下, 还要考虑 沿 texel 对角线分布的情况, 所以就人为乘以了 根号2

# 位于 Light inspector 上的 调节因子
    Light inspector 中自带一个名为 Normal Bias 的滑块, 它可取值:[0.0, 3.0]
    这个变量 原本用来控制 unity built-in 风格的 world-space shrinking normal bias.
    ("shrinking normal bias" 的思路是: 将 shadow caster 模型缩小)
    ---
    在我们这个 SRP 中, 它暂时是无用的. 我们用它来 控制 catlike 版的 Normal Bias 强弱.

    这个值默认被设置为 1.0

# normal bias 的缺点
    由于 所有的 frag 都向外膨胀了一小段距离, 最后导致 "墙壁脚下附近的地面" 也会出现阴影.
    哪怕它们都处理 光照之下. 这是因为, 墙壁上的每个 frag 都外凸了一段距离, 使得墙根下的地面
    反而变得 "位于阴影中了"

    解决它的办法就是 额外添加 slope bias 技术. 

# 如果后面开启了 PCF
    那么, PCF在将阴影柔边的同时, 会反过来增加 "自阴影". 此时需要和 Normal bias 联动
    同时提高 normal bias 的强度


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#            "阴影中的空间" 问题, 和
#            shadow Pancaking 技术
# ---------------------------------------------------------------- #

# shadow Pancaking 技术的由来:
在pass 1 中, 将 shadow caster 的深度值写入 depth buffer 的过程中.
会尽可能地把 光源的 近平面 向远处推. 从而能压缩 近平面-远平面 之间的深度差值,
进而提高 每个 depth buffer texel 所记录的 深度值的精度.

但如果某个 shadow caster (或它的一部分), 并不在 相机视野中, 那么它有可能位于 
光源的 近平面之外, 进而被 clip 掉. (逐frag)(光源视野的 frag, 即 texel)

然后这些被 clip 的 shadow caster 的一部分, 往往会在阴影中产生一个空洞.

解决方案就是把这些 在 近平面之外的 caster 的一部分, 将它们的 depth 全部 clamp 为 近平面的深度值.
也就是把它们都 压扁了 (压成了一个 薄饼)

请在 vert shader 中写入:

# --
#if UNITY_REVERSED_Z
    // 超出近平面的 depth, 要比 1 更大
    output.positionCS.z = min( output.positionCS.z, output.positionCS.w * UNITY_NEAR_CLIP_VALUE );
#else 
    // 超出近平面的 depth, 要比 -1 更大
    output.positionCS.z = max( output.positionCS.z, output.positionCS.w * UNITY_NEAR_CLIP_VALUE );
#endif 
# ==

# 解释
    使用 shadow Pancaking 技术来解决 "阴影中空洞" 问题
    ---
    原理就是将 shadow caster 中, 超出 近平面的那部分模型 压缩为一张 薄饼 贴在近平面上.
    (将它们的 .z 值全部统一为 近平面的深度值)
    ---
    UNITY_NEAR_CLIP_VALUE 
        它记录的是 深度值, 即: .z/.w 这个值:
        -- D3D 风格平台值为 1.0
        -- OpenGL 风格平台值为 -1.0

    ---
    为什么乘以 .w 值 ?
        因为 clip-space 空间中的 z值 不够直观, 但当它执行 齐次除法(除w) 后, 就能变成 NDC 中的值.
        所以反过来 乘以 .W 值, 保证 .z 值符合 clip-space 中的规定.

    ---
    clip-space 的 .z 值区间:
        -- 启用 reversed-z 的平台:          [near, 0]
        -- 无 reversed-z, D3D风格的平台:    [0, far]
        -- 无 reversed-z, OpenGL风格的平台: [-near, far]



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#            "特别长的物体, 远端的阴影会消失" 问题
# ---------------------------------------------------------------- #

一些 特别长的物体, 它们的阴影 有时不完整, 会出现断裂.

因为这些物体的一部分, 被 light 平截头体的 近平面 clip 掉了.

通过将 light 的近平面 朝向 light 的反方向 移动, 这种错误就会被修复.

缺点: 由此生产的 depth buffer 的精度降低了, (可在 Frame Debug 中观察到变化)

# 实现:
可通过: Light.shadowNearPlane 直接获得 light inspector 中 Near Plane 滑块的值 [0.1, 10]

然后将此值传入 ComputeDirectionalShadowMatricesAndCullingPrimitives() 第六个参数.

实现起来挺方便的.

但每个 light ,都要根据自己的实际表现, 去手动调出一个合适的值 (越小越好)


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
# 04 Directional Shadows:
#               PCF
# ---------------------------------------------------------------- #

catlike 使用的 PCF 和 202 中介绍的 PCF 存在区别.
在 catlike 中, 只在目标点周围, 收集一组符合 tent 滤波器 规律的采样点. 
每个采样点的权重是不同的. 也许是想借此减少 采样数量. 
---
不对, 按照 202 描述, 加权值 算是可选项



# PCF 会使得 "自阴影" 问题恶化
    此时需要将 pcf 的强度, 和 normal bias 的强度进行联动

# 和 normal bias 的联动, 又会使得 "墙根地面的暗影" 问题复现




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#               Culling Bias
# ---------------------------------------------------------------- #
cascade shadowmap 的一个缺点是, 针对一个光源, 需要重复渲染多张 depth buffer (tiles)

如果某个 shadow caster, 我们能确保它一定出现在小的 cullingsphere 体内, 那么我们就能从
大的 cullingsphere 的渲染过程中将它 剔除掉, 以此减少 运算量. (shadow caster 越少越好)

可直接修改:
    splitData.shadowCascadeBlendCullingFactor
来实现.
此变量可赋予值: [0.0, 1.0], 赋予的值越大, 它执行的 剔除操作就越猛烈.

当然, 过度剔除也是有缺点的, 比如那些恰好处于 两层 cullingsphere 交界处的 caster, 它造成的投影就会出现问题.

我们选择将这个值 和 settings.directional.cascadeFade 值 关联起来. 为其赋予一个稍微合理的值.




