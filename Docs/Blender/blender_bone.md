# ================================================================//
#                          Blender 骨骼 使用技巧
# ================================================================//


# ----------------------------------------------#
#                 基础技巧
# ----------------------------------------------#

---- 创建骨骼：
	在 obj 模式，左上角 add 下拉菜单，选择 Armature
	会在原点，新建一个 armature
	---
	在 obj 模式，确定bone pos后，
	进入 edit 模式，此时，可以拖动 bone 的小端，来设置小端的pos
	---
	edit 模式，选中小端，按 "E", 在小端上，生成一节次级bone。
	---
	不应在整副骨架制作完毕前，绑定到模型
	===

----- 如何让 bone 在物体前面
	obj模式, 选中 bone, 到右侧一个 "人形"面板. ViewPort Display,  启用 In Front


----- 制作镜向bone：
	在 edit 模式，选中目标bone，
	在右侧 工具面板（螺丝刀+扳手）：
	Options:
	点选 X-Axis Mirrr 
	---
	然后，选中目标 bone 节点，
	快捷键 "shift+E", 向两侧生成对称的 bone


----- 创建反向关节：
	在 pose 模式中，选中某个 子bone，
	然后点选窗口左上角的 Pose 按钮
	下拉菜单中选中:
	Inverse Kinematics: 
	Add IK to Bone:
	To new empty obj
	---
	一个反向关节就创建好了
	---
	只能在 obj 模式，点选 那个 十字形的 ik-obj，才能移动它
	=====
	但是，这种 empty obj 式的 ik 并不是我们需要的，
	我们需要一种更有效的 ik：

	====== 2 ======
	假设，我们为角色腿部制作 ik：
	在腿部底端，额外生成一节，指向下方的 bone，
	在这个 bone 的 Bone 面板中，将其原有的 parent 设置删除：
		选择这个 末端bone，再选择 root-bone，
		alt+p, 解除parent绑定关系
	现在，这个 bone，不再绑定与 原有的 leg bone
	---
	在 pos 模式，先点选这个独立的小bone，再点选 其上面一节leg bone
	然后，创建ik ( Inverse Kinematics - Add IK to Bone )，此时只有一个选项： 
	to active bone
	点选之后，自动创建一个，只向 总bone系统 base节点的 ik关系
	---
	然后，选中 黄绿色的那个，已经被设置了 ik 的bone（不是额外的一节小的）
	进入 constraint 面板( 骨头上绕着一个圈 )，调整 chain length 参数，
	比如，调为2，让其指向正确的 绑定点。
	这个数字可以多调调, 每调一个, 就在 原地(pose模式) 拉动下 下面的小骨头,
	看看现在 黄绿色骨头 跟着谁在动 
	
	---
	这样，一个 有效的 反向 ik 就绑定完成
	---
	这个绑定是 单独的，另一个leg还需要绑定一次


----- 恢复 关节 设置：
	当之 pos 模式 改动一个 关节后，想要恢复初始值：
	alt + R: 恢复 rotation
	alt + S: 恢复 scale
	alt + G: 恢复 location


----- 为数个 bone，创建 root bone
	选中任意 bone，
	关闭 X-Axis Mirror
	要不然会创建2根 root 关节
	---
	需要在 角色胯部，腰部一根，和大腿根2根 bone
	这个3角交叉点，生成一个新 bone，指向 角色后方，名为 root
	---
	点选旧的三个bone，最后点选 root bone
	然后 ctrl + P, 设置父子关系
	然后选择 keep offset 


----- 将手部 ik关节（额外小bone）绑定到 neck bone 上
	这样，当上半身活动时，手部就不会被固定在半空中
	---
	先选择，手部ik关节，最后选择 neck 关节，
	ctrl + p, 选择 keep offset
	---

----- 为手部的 ik关节，添加外部的 控制器关节
	打开 X-Axis Mirror
	---
	edit 模式，复制 hand ik关节一份，拖动到 身体后侧
	先选 新的控制器关节，再选ik关机
	ctrl + shift + C, 选择 Copy Location
	此时，ik关节会发生位移
	---
	在 constraint 面板，将连个 space 设置为 local space
	===



----- 为背部关节，添加 约束 constraint
	在 pos 模式，先选择下端关节，再选上面一节
	ctrl + shift + C 
	弹出： 添加约束面板
	选择： child of
	---
	此时添加成功，但是 目标bone 会发生变动
	---
	然后在 add bone constraint 面板
	点击 set inverse 按钮
	上文出现的变动就消失了
	====
	back bone 有很多节，需要做很多次绑定
	注意，每一次，都是将某一根，绑定到最底部的那根上去（而不是紧挨着的下面一根）

------ 为 尾部关节，制作 体外控制器
	edit 模式，角色后方，用 光标 curser，在后方确定一个点
	然后 ctrl + A, 创建一个新的独立的bone
	---
	先选 新的控制bone，再选 root
	set parent：keep offset
	这样，当移动 root时，这个背部控制器关节，也会跟着移动
	---
	先选 控制器，再选 back.1 关节（不是 root）
	ctrl + shift + C, 选择 Copy Rotation
	此时，ik关节会发生位移
	---
	在 constraint 面板，将连个 space 设置为 local space
	===


------ 拿掉 所有单纯 控制类关节 的对模型的绑定效果
	每个 控制类关节，取消其 context. Deform 选项


# ************************************************
----- 将整副骨架，绑定到模型 
	（这一段讲得很乱，建议直接看后方描述...）
# ************************************************

	在 obj 模式，先点选 模型，然后点选 骨架
	然后 ctrl + p 绑定，选择：
	with automatic weights 选项
	---
	如果，模型由很多 obj 组成
	绑定骨架和 单个obj时，不应选 with automatic weights
	应该选 bone 
	---
	暂未测试 ...


------ 如何进入 weight paint 模式
	在 obj 模式，先选骨架，在选模型
	然后选择 weight paint 模式


======= 如何为机器人 绑定骨骼 =======
--1-- 将机器人所有 obj，ctrl + J 合并为一个 obj
--2-- 先选模型，再选 bone， 
	ctrl + P, 选择 with automatic weights
	实施绑定
	---
	此时，很多顶点的权重值还不准确

--3-- 一种适用于 机器人的，快速修改 骨骼权重值的方法：
	骨骼权重值，其实被写进了 每个骨骼关节的 Vertex Groups 中
	---
	选择 模型，进入 edit 模式
	通过 ctrl+L, 全选一个 arm 的所有顶点
	在右侧 object data 面板：Vertex Groups 中
	针对对应的 骨骼关节群组。
	weight 设为1，点 Assign，绘制权重值
	然后 ctrl + I, 反选。点 remove， 清楚此骨骼对其他 模型顶点的绘制
	===
	这种方法，特别适合 类似 minecraft 式的 动画



======== 如何将一个 独立的模型，绑定到一个 bone关节 =======
	edit 模式，选择目标 关节
	---
	进入 obj 模式，先选目标模型，再选 bone
	然后 ctrl + p: Bone
	就能成功绑定
	---
	诀窍在于，要先在 edit 模式，选中目标关节
	---
	很容易
	===


========= 约束器：copy location/rotation/scale ========
	一种比 parent关系更加强大的 约束
	不仅可以绑定位置，还可以关联 缩放旋转
	推荐




# ----------------------------------------------#
#            对骨骼绑定的 深入思考
# ----------------------------------------------#
---
在最基本的实现中，复选择多个 mesh，然后选择 骨骼，
点击 ctrl+p, 选择任意一项 骨骼绑定。

其实都会为每个 mesh，创建一组 Vertex Groups 数据
此时点开 任何一个 mesh 的 右侧 “三节点”属性面板，查看 Vertex Groups 区。
都会看见，刚刚绑定的所有 bones 都出现了。


然后，我们选定目标 mesh，从 Vertex Groups 栏中，选择一根 bone，
直接进入 Weight Paint 模式，可以看见，每一根bone，当前刷的权重值
（此时，我们可以在 右侧 Vertex Groups 选择不同的 bone，来查看它的 权重信息）

也可以重刷 这根 bone 的权重信息。

----
这才是最容易理解的 骨骼绑定操作


# ----------------------------------------------#
#          形态键: Shape Keys
# ----------------------------------------------#





# ----------------------------------------------#
#            keymesh 插件
# ----------------------------------------------#







