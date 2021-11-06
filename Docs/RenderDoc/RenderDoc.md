# ================================================================ #
#                   RenderDoc  杂
# ================================================================ #


# 本地安装路径:
    c - adminis... - AppData - Roaming - qrenderdoc 


# unity 中使用:
    在 sceme/game 窗口, 
    对准窗口栏右键单击, 选择 Load RenderDoc,
    此时窗口栏右侧出现一个 相机图标, 点选之
    跳出 renderDoc 界面;


# 上下翻转 texture:
    Texture Viewer - Zoom 后面有个绿色的上下箭头, 
    点击即可翻转;
    非常实用;


# ---------------------------------------------- #
#           Range Control
# ---------------------------------------------- #

# 按钮: 放大镜:
    可以把 黑白点的值, 重新映射到 选区 的两端, 以便你做更精确的操作

# 按钮: 魔术棒:
    自动查找当前 texture 中最大值最小值, 将他们设置为 选区 的两个端点的值

# 按钮: 回撤:
    恢复 选区两端点为 [0,1] 值;

# 按钮: 直方图:
    直方图显示, 非常方便;






# ---------------------------------------------- #
#        Texture Viewer - Overlay
# ---------------------------------------------- #
debug 利器: 可以显示 画面的 不同信息;



# ------------------------ #
#   显示:  Highlight Drawcall
显示本次 draw call 要绘制的区域


# ------------------------ #
#   显示:  Wireframe Mesh
显示 本次 draw call 绘制的 mesh 的线框;


# ------------------------ #
#   显示:  depth test

若通过 depth test, 此frag 显示 绿色;
若不通过, 显示红色;

如果某个像素被对象多次覆盖，只要其中有一次通过测试,
则此 frag 最终也会显示 绿色 (即: 失败识别是"保守"模式, 只要一次成功就算成功 )
# 注:
    啥叫多次覆盖呢:
    个人猜测是: 比如一个球体, 前后面都有三角形 覆盖此 frag, 这两个三角形都要做测试;
    假设排前面的三角形通过了, 排后面的失败了, 
    那么最终仍然判定这个 frag 通过了 stencil test;



# ------------------------ #
#   显示:  stencil test

若通过 stencil test, 显示绿色;
若不通过, 显示红色;

如果某个像素被对象多次覆盖，只要其中有一次通过测试,
则此 frag 最终也会显示 绿色 (即: 失败识别是"保守"模式, 只要一次成功就算成功 )
# 注:
    啥叫多次覆盖呢:
    个人猜测是: 比如一个球体, 前后面都有三角形 覆盖此 frag, 这两个三角形都要做测试;
    假设排前面的三角形通过了, 排后面的失败了, 
    那么最终仍然判定这个 frag 通过了 stencil test;


# ------------------------ #
#   显示:  Backface Cull
works as above but with backface culling

# ------------------------ #
#   显示:  Viewport/Scissor 
shows a colored overlay on the image that corresponds to the viewport and scissor regions.


# ------------------------ #
#   显示:  NaN/Inf/-ve display 

画面的主体部分, 通过特定的 luminance 计算 被显示为灰色:
    dot(col.xyz, float3(0.2126, 0.7152, 0.0722)).xxx

若某 frag 上存在 NaN, 它将被显示为 红色;
若某 frag 上存在 INF, 它将被显示为 绿色;
若某 frag 上存在 负值, 它将被显示为 蓝色;

注意, 只要 frag 所在的 texture 上的一个分量存在异常值, 它就会被标记出来;


# ------------------------ #
#   显示:  Clipping 

配合 Overlay 下方的 Range 栏一起使用;

若某frag 的值, 小于当前 Range Control 中的 black point 值, 将被显示红色;
若某frag 的值, 大于当前 Range Control 中的 white point 值, 将被显示绿色;

如果 range control 设置正确，或者与自定义 shader 可视化器结合使用，此功能可在识别无效范围时非常有用。


# ------------------------ #
#   显示:  Clear before Pass 

will act as if the current target had been cleared right before the current pass. This can sometimes make it easier to see the results of a draw, especially if it is blending and only makes a subtle change. If the current API does not have the concept of a pass, it is defined as all the drawcalls with the same set of render targets.
--
    If the current target is a render target, it is cleared to the Alpha background color.
--
    If the current target is a depth/stencil target, the behavior depends on the depth function for the current draw. If it is EQUAL, NOT EQUAL, or ALWAYS, the target is not cleared. If it is LESS or LESS EQUAL, it is cleared to 1. If it is GREATER or GREATER EQUAL, it is cleared to 0. Stencil is never cleared.

# ------------------------ #
#   显示:  Clear before Draw 

works similarly to the above overlay, but clearing immediately before the selected draw.

# ------------------------ #
#   显示:  Quad Overdraw (Pass) 

Overdraw:
    一个 frag 在渲染周期内, 被重复绘制了好几遍, 这个现象就叫 Overdraw;

此处以 2x2 frags 为一组, 来显示每组 frags 的 Overdraw 的 严重程度; 

will show a visualisation of the level of 2x2 quad overdraw in the ‘pass’ up to the selected draw. If the current API does not have the concept of a pass, it is defined as all the drawcalls with the same set of render targets.
---

可以观察到, 紫色表示 Overdraw 值比较低, 越蓝月亮, 说明值越高;
还可以看到, 两个相邻三角形的公共边, 总是会被重复绘制两次;


# ------------------------ #
#   显示:  Quad Overdraw (Draw) 

和上一条相同, 不过局限于 当前 drawcall 之内;


# ------------------------ #
#   显示:  Triangle Size (Pass) 

will show a visualisation of how much pixel area triangles in the meshes are covering in the ‘pass’ up to the selected draw, up to 4x4 pixels (16 square px) at most. If the current API does not have the concept of a pass, it is defined as all the drawcalls with the same set of render targets.


# ------------------------ #
#   显示:  Triangle Size (Draw) 
will show a similar visualisation to the above option, but limited only to the current drawcall.























































