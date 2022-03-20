
# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#            post processing 与 Multi-Cameras 的兼容:
#                如何 同屏显示多个 cameras
# ---------------------------------------------------------------- #

若在场景中设置多个 camera, 并调整它们的 viewport rect 来安排显示位置和尺寸,
当不开启 post processing 时, 一切正常, 但一旦开启, 最终画面将只会显示
最后一个 camera 的画面, 而且是一个拉伸过的画面.

这主要是因为, 在每次执行完:

    buffer.SetRenderTarget()

之后, 当前的 viewport 数据都会被清空为初始值,
此时我们需要紧跟其后调用:

    buffer.SetViewport(camera.pixelRect);

然后再调用:

    buffer.DrawProcedural() 等绘制指令.



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#            post processing 与 Multi-Cameras 的兼容:
#                如何 嵌套多层 cameras, 
#          且上层的 camera 不渲染背景, 只渲染物体 和 半透明的 bloom 效果 
# ---------------------------------------------------------------- #

# 其实还存在第三个要求: 放在最底层的 camera, 能彻底覆盖 rt 内存上原有的数据

整个过程很复杂, 建议跟着 catlike 教程 走一遍...





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#              camera 之间的渲染顺序
# ---------------------------------------------------------------- #

# -1- 优先渲染 目标为 render texture 的 cameras, 再渲染 目标为 显示器 的 cameras

# -2- 在第一条基础上, camera Inspector: Depth 值越低, 越优先渲染





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                旧方案:  Culling Masks
#                          cullingmask
#                新方案:  Rendering Layer Mask
#                          RenderingLayerMask
# ---------------------------------------------------------------- #

# +++++++++++++++++++++++++++++++++++ 
# --- 旧方案: Culling Masks:
每个物体可以设置自己所属的  Layer, (Inspector 右上方, static 下方)
然后每个 camera, light 都可选择 自己能影响的 layers (可复选)
并剔除掉 无关的 layers 中的物体.
这个 culling mask 操作发生在 渲染的 culling 阶段:


# ----- 旧方案的 大 BUG: ----- #
# 平行光 的 culling mask, 只能剔除阴影, 无法剔除光照

# Point/Spot 光的 culling mask:
#   -1- 若启用 rp: useLightsPerObject, 既能剔除阴影, 又能剔除光照
#   -2- 若禁用 rp: useLightsPerObject, 还是只能剔除阴影, 无法剔除光照

    因为只有当 unity 在将 per-object light indices 传输给 gpu 时, 光源的 culling mask 才被执行.
    所以如果不启用 LightsPerObject 技术, 这个 culling mask 功能就不完整.

    至于它为什么始终无法剔除 平行光 对物体的 光照影响, 是因为 unity 默认 平行光影响所有物体. 
    但它又能剔除掉 平行光的 阴影...

    这个问题我们无法解决, HDRP 直接不支持 针对 lights 的 culling mask.

#   作为替代, unity 为 srp 提供了 Rendering layer Mask


# +++++++++++++++++++++++++++++++++++ 
# --- 新方案: Rendering layer Mask:
# 优点:
# -1- 一个物体 可以设置 多个 Rendering layers, 不仅仅一个
# -2- Rendering layer 仅用于渲染(光照计算,阴影), 而 普通的 object-Layer 还被用于 物理引擎. 

Rendering layer 同时出现在 物体 和 light 两个 inspector 中, 


# --- catlike 选择覆写 Rendering layer 中的那些名字
-1- 
    彻底覆写 RenderPipelineAsset.renderingLayerMaskNames 这个只读属性(getter)
    这个方法对 物体 是管用的,
    但是对 light 无效.
        但这只出现在 catlike 选择的 unity 版本中, 在后续更新版本中, 这个问题被修复了... 

    catlike 的修复代码 似乎造成了更大的 麻烦

    暂时先不管这些, 至少还能用...



    












