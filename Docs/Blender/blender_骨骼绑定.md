# ================================================================ #
#                          Blender 骨骼 使用技巧
# ================================================================ #


# -- 绑定后, armature 自动变成 mesh 的 parent


# -- 绑定发生后, mesh 子层会多出一个 armature modifers, 它指向关联的 armature


# -- 绑定发生后, mesh 子层多出 vertex groups目录, 里面放了所有能影响这个 mesh 的 bone 的权重信息;
	就算后面修改了 各节点的层次结构, 这个绑定信息也不会变


# -- Armature - Pose 节点:
	是 Armature 对象内部的一个属性集合，它记录了：
		每根骨骼在 Pose Mode 中的当前位置、旋转、缩放
		骨骼的约束（IK、FK 等）
		骨骼的自定义属性

	当你在 Pose Mode 中旋转骨骼时，你改变的就是 Pose 数据。这就是为什么：
		你可以随意调整骨骼姿态而不破坏原始结构
		可以创建多个 Action 动画，每个都基于同一个 Armature

	在 object/ edit mode, Pose 下是空的
	在 Pose mode, Pose 节点下会显示全套骨骼的信息


# -- Armature - (一个火柴人拿着球) 的节点  骨骼节点
	和 Pose 对称, 这是 骨骼节点
	在 object/edit mode, 它显示






# ----------------------------------------------#
#                 基础 技巧 流程
# ----------------------------------------------#

# --- 创建骨骼：
	在 obj 模式，左上角 add 下拉菜单，选择 Armature
	会在原点，新建一个 armature
	---
	在 obj 模式，确定bone pos后，
	进入 edit 模式，此时，可以拖动 bone 的小端，来设置小端的pos
	---

# --- 生成一节次级骨节点:
	edit 模式，选中小端，armature - extrude; (可开启对齐工具后使用)
	---
	不应在整副骨架制作完毕前，绑定到模型


# --- 如何让 bone 在物体前面
	obj模式, 选中 bone, 到右侧一个 "人形"面板(Armature) -> ViewPort Display ->  启用 In Front


# --- 制作镜向bone：
	在 edit 模式，选中目标bone，
	在右侧 工具面板（第一个: 螺丝刀+扳手）：
	Options:
	点选 X-Axis Mirrr 
	---
	然后，选中目标 bone 节点，
	快捷键 "shift+E", 向两侧生成对称的 bone
	----
# (非快捷键 实现法)
	开启 snap吸附, 手动从 parent bone 拉出两个 子bone, 先让它们对称
	然后用缩放工具来调整它们在 x轴的位置


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
	(通常不是脚掌, 而是小腿 leg 那个 bone)
	然后，创建ik ( Inverse Kinematics - Add IK to Bone )，此时只有一个选项： 
	to active bone
	点选之后，自动创建一个，指向 armature root节点的 ik关系
	---
	然后，选中 黄绿色的那个，已经被设置了 ik 的bone（不是额外的一节小的）
	进入 Bone Constraint 面板( 骨头上绕着一个圈 )，调整 chain length 参数，
	比如，调为2，让其指向正确的 绑定点。
	这个数字可以多调调, 每调一个, 就在 原地(pose模式) 拉动下 下面的小骨头,
	看看现在 黄绿色骨头 跟着谁在动 
	
	---
	这样，一个 有效的 反向 ik 就绑定完成


然后是配置: 膝盖指向的 pole target:
	在膝盖位置新建一个 bone, 取名 knee, 让 knee 解除 parent,
	朝向膝盖前方, 让它位于 膝盖前方,
	让 upleg 微微前曲, 这样不至于后面反向弯曲
	---
	点击 设置 ik 的那个 leg bone, 在 IK constrain 面板中, 
	同时将 pole target 和下面的 bone 都指向这个 knee,
	然后修改 pole angle 到合适的角度, 
	---
	现在 knee bone 可以控制 膝盖朝向了
	===
	然后可以选择把 knee 的 parent 设为那个 ik bone;




	---
	这个绑定是 单独的，另一个leg还需要绑定一次



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



# =============================== #
#     重置 pose 中骨骼姿势
# =============================== #
进入 blender 操作模式:
	选中 armature, 进入 pose;
	点 A, 全选所有 bone;
	alt + R: 恢复 rotation
	alt + S: 恢复 scale
	alt + G: 恢复 location

这样所有 bone 就回到初始值了

也可单选某个 bone 来恢复



# =============================== #
#     显示每个 bone 三轴信息
# =============================== #
选 armature, 进入 edit mode, 选中一个 bone
右侧的 bone 面板, viewport display, 勾选 Axis, 就能看到了




# =============================== #
#     连接 父子两个 bone
# =============================== #
选中 armature, 进入 edit mode,
选中 子bone (不是头尾点, 而是那个杆子),
到右侧 properties -> Bone (骨头标准) 面板: -> Relations -> 勾选 "Connect"

就能和 parent bone 连上了





# ================================================ #
#           如何绑定骨骼 , 刷权重, 导出
# ================================================ #

# -- 绑定
obj模式, 先选armature, 再shift选mesh:
	然后: object - parent - armature deform - with auto weights  自动刷权重
	---

# -- 刷权重:
obj模式, 选mesh, weight paint mode,
右侧 properties菜单, 选 三角形 data页签, 可以在里面选择要刷的bone, 然后再刷


# == 导出:
绑定好后, 父节点是 armature, mesh在子节点, 此时选择 最顶层 armature, 右键 select hierachy,
然后 export fbx:
	-- limit to: selected objects
	-- object types: 
		armature
		mesh
	-- 勾选 apply transform
	-- armature 内保持默认, 保持默认勾选 add leaf bones
导出;



# ========= 约束器：copy location/rotation/scale ========
	一种比 parent关系更加强大的 约束
	不仅可以绑定位置，还可以关联 缩放旋转
	推荐


# ************************************************
----- 将整副骨架，绑定到模型  (old)
	（这一段讲得很乱，旧文档...）
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







