# ================================================================ #
#                          Blender 使用技巧
# ================================================================ #



# ===================================== #
#        使用 maya 风格的 操作
# ------------------------------------- #

Editor - Preferences - Keymap
中部最上面有个选框, 默认是 "Blender", 下拉改成 "Industry Compatible"




# ----------------------------------------------#
#              渲染设置
# ----------------------------------------------#
开启 blender 项目后，务必在：
Scene:
Color Management:
View Transform
	设置它为 Standard
	默认值为 Flimic
----
若不修改此项，最终颜色会始终不准


# ++++++++++++++++++++++++++++++++++++++++++++++#
#            确保所有 面 法线正确
# ++++++++++++++++++++++++++++++++++++++++++++++#
- edit mode
- 按a，全选所有面
- Mesh - Normals - Recalculate Outside
	此时会修正所有面的 法线



# ++++++++++++++++++++++++++++++++++++++++++++++#
#             如何为单独的面上色
# ++++++++++++++++++++++++++++++++++++++++++++++#
-- 在 edit mode
-- 选中单独的面
-- 新建一个 material，
-- 点击 material 面板上的 Assign 按钮
	将材质赋予 目标面


# ----------------------------------------------#
#        如何制作类似 塞尔达 的卡通渲染风
# ----------------------------------------------#
-- 选用 Emission 自发光节点
	此时为面设置的颜色，就是最终呈现色
-- 通过:
	Diffuse BSDF,
	Shader to RGBA,
	ColorRamp,
	Emission,
	Material Output,
	这套流程，可以制作，具备多层明暗变化
	且可自定义不同阶层颜色的 
	卡通渲染风格


# ----------------------------------------------#
#        如何渲染 pxel 图形
# ----------------------------------------------#
-- Render.Film.Fliter Size = 0.01 px
	将此值降为最小，从而实现 色块边缘彻底 像素化
	---
	记得勾选 Transparent:
	可以不渲染背景，适合出 角色渲染图

-- Output.Dimensions
	将 xy 值改为 64*64 这种小尺寸
	剩余选项也都可以设置，且很简单
	
-- Output.Output
	选择输出path，
	记得勾选 Overwrite, file Extensions
	将 Compression 设置为 0 （不启用图像压缩）

-- 选择顶部窗口的 Render - Render Animation
	或者 ctrl F12
	来实现实际渲染工作 



# ----------------------------------------------#
#              动画制作 - 最简方法
# ----------------------------------------------#
--1-- 选择要做动画的 obj
--2-- 在 timeline 上选择目标帧
--3-- 调整目标obj 的参数（position，location等）
--4-- “插入关键帧”
	快捷键 "I", 再选择对应的选项
	比如，Rotation
	-------
	一个关键帧 制作完毕
	-------
	然后可以去制作下一个关键帧


========
编辑动画帧曲线：
-- 按 a，全选 关键帧
-- 按 t，弹出面板，可以设置 过度曲线类型

======== 从数据上，手动设置关键帧 ======
鼠标移到某个数据上，按 i，设置关键帧


# ----------------------------------------------#
#      如何在单个文件内，制作多个 动画动作
# ----------------------------------------------#

-- 打开 Dope sheet 面板
-- 选择它的 子面板：Action Editor
	在其中，可以看见当前动作名，修改之，
	再点选右侧的 盾牌按钮（F按钮）
	用来保存这个动作
-- 然后正式制作这个动作


== 如何删除一个动作
-- 打开 Outliner 面板
	它会展示当前 .blender 文件的构成
	在里面，你可以删除 某个 动作



# ----------------------------------------------#
#        简易 烘焙 法线贴图
# ----------------------------------------------#

# ----------------------------------------------#
#          pose 模式 姿势全面恢复
# ----------------------------------------------#
进入 pose 模式, 对骨骼做任意 位移 旋转.
想要恢复时:
-- 按 a 键 全选所有 bone
-- 按 alt+R, 复位旋转, 
	  alt+G  复位位移 
	  alt+S  复位缩放



# ----------------------------------------------#
#        
# ----------------------------------------------#









