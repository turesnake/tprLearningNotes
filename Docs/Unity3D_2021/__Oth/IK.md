# ================================================= #
#            Inverse Kinematics [IK]
#            -----------------------
#         目前特织 unity 插件 Final IK 的使用
# ================================================= #

如果发现 final ik 在 Scene 界面中的 图标和交互都不见了
记得 开启 Gizmos 按钮


# ---------------------------------------- #
#          所有 IK 类型 
# ---------------------------------------- #

-- Trigonometric IK
	最基础的IK，基于 三角函数 cos
	只支持三个关节


反向动力学（Inverse Kinematics） 和布娃娃系统的结合

-- CCDIK: Cyclic Coordinate Descent IK
	性能能高，但是链条形状不理想。
	CCD 并不关心 关节的长度
	适合 关节较少的机械物体，单链对象
	不适合处理 多分枝对象，此时应该使用 FABRIK


-- FABRIK: Forward and Backward Reaching IK
	在处理多关节链条时，可以让链条形状非常柔和
	迭代次数小于 CCD，但每回合迭代的耗时高于 CCD，尤其是添加了旋转角度限制时
	关节的长度可以在运行时被改动

	支持多分枝对象，不仅仅局限于单链




-- Multi-Effector FABRIK

-- Limb IK
	四肢IK，单独操作一个 手臂/腿
	仅限于 包含 3 个关节的 对象

-- Look At IK
-- Aim IK


-- FBIK: Full Body IK


# ---------------------------------------- #
#            IK 的性能
# ---------------------------------------- #
不管是 CCDIK 还是 BABRIK， 最好的优化就是减少链条上的关节数量



# ---------------------------------------- #
#         FABRIK 原理
#  Forward and Backward Reaching IK
# ---------------------------------------- #
FABRIK 通过若干次迭代来靠近目标
在每次迭代中

-1- 反向遍历
	从末梢关节开始，将关节对准目标，在瞄准线上滑动，让关节头到达目标点
	此时，关节尾节点，将会滑到一个新的位置
	将这个位置，作为next关节的 目标点。
	重复这个操作，直到遍历所有关节
	--
	最后，整个链条的root关节，也会在自己的瞄准线上，获得一个新位置
	由于我们不允许 root节点发生位移，所以还需要一次前向遍历：

-2- 前向遍历(一个比较快的版本)
	从 root关节开始，root关节并不会移动，但root关节在对齐到瞄准线后，
	自己的 头关节将到达一个新位置。
	这个新位置就是 next关节 尾节点的 新位置
	此时并不需要重新调整 第二根关节的角度。
	只需要将这个关机平移，让它的尾节点，对齐上一个关节的头节点
	---
	重复这个操作，直到遍历所有关节
	===
	当然，这个部分也存在其他实现方式，比如重新为每个关节寻找正确的角度...


-3- 以上组合就是一次迭代，此时，末梢关节将有效地靠近目标点，但几乎不会在一次迭代内立马到达

所以我们需要迭代多次，直到充分靠近为止。

在上面这个版本的介绍中，我们并没有处理每个关节的 rotation 信息，也就是它的旋转



# ---------------------------------------- #
#         rotation limit hinge
#         rotation limit angle
# ---------------------------------------- #
注意!!!
这些组件，还是只能绑定在 bone 上，而不是直接绑定在 mesh 上。

-- hinge 是 控制单个轴转动的，非常好使用
		注意，设置边界的时候，是基于 hinge 自身的 坐标系的
		这个坐标系，是吧 当前bone 的朝向，作为 x轴来生成的
		而不是基于 当前关节的角度。
		如果发现，hinge 默认轴 和 自己想要的不是一个方向
		可以点击主界面中的 Rotate display 90 degress 按钮
		---
		在制作机器人类的动画时，hinge 最常用

-- angle 是 控制 一个圆锥角内 运动的
	暂未正式使用过



# ---------------------------------------- #
#     如何正确使用 FABRIK root
# ---------------------------------------- #
--1-- 
	当我们在一个 go/bone 上绑定 FABRIK root 组件
	root 就会自动将这个 go/bone，看作是整个 chains 的 更节点
	---
	所以，我们最好在比如 armature/rootBone 之类的 bone 上绑定 root 组件

--2--
	root 中支持登记数条 chain，
	如果这些 chain 之间没有额外设置父子关系，
	那么它们都会将 --1-- 中的 go/bone
	当作新的 parent（哪怕在原始 armature 关系中不是这样的，也会被改过来）

--3-- 
	如果存在一个类似 Y字树杈一样的 chains结构，我们需要严格地制作3条 chain:
	-- 1 parent chain:
		从root，到分叉点为止，可以很短，比如只有一根bone
	-- 2 child chain:
		从 分叉点，到自身的终点
	------
	最后，要在 root组件面板中，在 parent chain 的 childs 属性中，登记好自己的childs
	===
	当整个 ik chains 配置成功后，每个节点都会显示 中灰色

--4-- 
	== chain.pull
		当本 chain 扮演 child 时，能拉动 parent 的强度有多大
		通过修改此值，可以让 子chain，拉着整个体系移动
	== chain.pin
		当本 chain 扮演 parent 时，能抗拒 child 拖拽的 强度有多大
		通过修改此值，可以减弱/屏蔽 child 的拖拽

--5-- parent bone ik 需要设置 target 吗？
	目前来看可以设置为 None。
	parent chain 应该完全被 child chain 拖着走


# ---------------------------------------- #
#   在使用 FABRIK root 时
#   如何才能 带着整个 机器人 移动
# ---------------------------------------- #
FABRIK root 通常被绑定在 Armature bone 上
在这个 root 组件中，取消: Fix Transforms 选项，
这个 Armature bone 就可以被拖着走了。


# ---------------------------------------- #
#   如何实现 胸腔的 水平扭动 和 前后左右倾斜
# ---------------------------------------- #
--
	制作两根串联的 chest bones:
		chest_pos
		chest_rotation
	上面一根绑定 胸腔的 mesh。
--
	在unity 中，用单独的一根ik关节，覆盖 两个 chest bones
	然后在 胸腔上方 新建一个 IKTgt 节点，
	通过管理这个 IKTgt，来实现 胸腔前后左右的 倾斜摇动
--
	在代码中，手动管理 chest_rotation 的 local.y 轴转动
	从而实现 整个上半身的 水平扭动
--
	如果上半身存在其他的 IKtgt，比如控制 两个手臂的
	应该将它们 设置为 bone: chest_rotation 的儿子
	这样，当 胸腔水平扭动时，这些 IKTgt 能跟着运动
	---
	另一种方案是，这个 IKTgt 彻底自由，跟着扭动的是 FixedAnchors


# ========================================= #
#               Script
# ========================================= #

==== 包管理
using RootMotion.FinalIK;

==== 如何管理 ik组件的 target 变量：
	FABRIK ik = go.GetComponent<FABRIK>();
	ik.solver.target = null;
	---
	这个 solver 的类型是: IKSolverFABRIK

	而我们需要的 目标变量 target,
	其实在更深的 IKSolverHeuristic 类中可找到

	大部分 面板上的参数，都可以去这个 IKSolverHeuristic 中查找











