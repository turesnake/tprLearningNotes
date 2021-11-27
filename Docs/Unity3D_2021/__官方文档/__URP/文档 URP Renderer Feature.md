# ================================================================ #
#        URP Renderer Feature   (11.0)
# ================================================================ #

A "Renderer Feature" is an asset that lets you add extra Render passes to a "URP Renderer" and configure their behavior.


# Render Objects:
    urp 包含的 pre-built Renderer Feature;
    是一种半成品 Renderer Feature, 可以快速配置和使用;



# ------------------------------------- #
#      Render Objects Renderer Feature
# ------------------------------------- #
-- 在 project 窗口中, 选择一个 Renderer 对象, 比如 "Forward Renderer";

-- 在它的 inspector 中, 点击最下方的 "Add Renderer Feature", 选择 Render Objects;

这个小界面中的各元素:

# Name (string框)
edit the name of the feature.

# Event (多选)
想要绑定到哪个 event 上, 从而设置 本功能被执行的 时间节点;

# ------ Filters ------:
这一块让你配置: which objects this Renderer Feature renders.

# Queue (二选一)
选择渲染哪一种物体:
-- Opaque:
-- Transparent:

# Layer Mask (bit-mask)
32-bits;
此处被选中的 layers 中的物体, 会被 Renderer Feature 渲染;


# LightMode Tags (一组 strings)
# 在文档中叫此变量: Pass Names
# 猜测是发生了改动
如果一个 shader 的一个 pass 拥有 pass tag: "LightMode";
本 Renderer Feature 只渲染 那些 "LightMode" 的值于 此处的 "LightMode Tags" 中的成员 相同的 passes


# ------ Overrides -------:

# Material (绑定槽)
用此处的 material, 去覆盖物体自己携带的;

# Depth (单选)
设置本 Renderer Feature 是如何影响和使用 depth buffer 的;
Renderer Feature 在渲染物体时, 是否将 dpeth 写入 depth buffer;

# Stencil (单选)
本 Renderer Feature 是否处理 stencil buffer 中的值;

# Camera (单选)

---
    文档中描述:
    启用此设置, 将更新:
    Field of View: 
        在渲染物体时, Renderer Feature 使用此处的 fov值, 而不是 camera 中提供的;

    Position Offset: 
        在渲染物体时, Renderer Feature 对这些物体的 pos 做一定偏移;

    Restore: 
        在执行完这个 Renderer Feature 的 render passes 之后, 会将 original Camera matrices 复原回来;

---
    unity editor 中小窗口解释:
    覆写 camera matrices; 启用此设置 会让 camera 使用 透视矩阵;
    (感觉不太对...)


# ================================================================ #
#       How to add a Renderer Feature to a Renderer   (11.0)
# ================================================================ #

-- 在 project 窗口中, 选择一个 Renderer 对象, 比如 "Forward Renderer";

-- 在它的 inspector 中, 点击最下方的 "Add Renderer Feature", 

-- 可以回去查看 project 窗口, 那个 父级 Renderer 对象下面, 现在挂着一个新的 Renderer Feature 对象;










