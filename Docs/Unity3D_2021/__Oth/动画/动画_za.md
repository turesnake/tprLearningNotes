# ================================================================ #
#                    unity3d  动画系统  za
# ================================================================ #

存在一个旧的 动画系统，叫 Animation,
还有一个新的，叫 Mecanim



# ----------------------------------------------#
#            AnimationEvent
# ----------------------------------------------#
这个接口 允许用户 在代码中，为某个 animation clip 绑定 event
（而不是在 交互界面中）
详细方法 参见 官方 API文档

====
另一方面，AnimationEvent class 可以成为 anim callback 的 参数类型




# ----------------------------------------------#
#      如何用 滑块 来控制 animation clip 的播放
# ----------------------------------------------#
旧的基于 Animation 的方法已作废，
改用新的，基于 Animator 的方法：
	Animator ar = GetComponent<Animator>();
	ar.speed = 0;
	...
	void Update(){
		//ar.Play( “action1”, -1, f );
		ar.Play( 0, -1, f );
	}
	======
在这个方法中存在两个核心：
--1-- 将动画速度关为0，这样就不会再播放中出现抖动了
--2-- 每一帧都调用 animator.Play() 来修改当前动画帧（0.0～1.0）
	也可以优化为：只有需要改动帧时，才调用 Play() 来修改
	反正速度已经关闭。

-------
通过这套系统，就能和 blender 中的 形态键 组合起来，实现更复杂的动画，
同时保证 程序运行的效率。




# ----------------------------------------------#
#      animation clip 逻辑
# ----------------------------------------------#
xxx.anim 文件, 本质是个 yaml 语言写的信息文件; (animator 也是)

当我们为 一个 go(内涵多个子go) 制作了一个 animation clip 后, 比如一个双开门的旋转, 则在 .anim 文件内,
可在 "m_EulerCurves" 数组内 看到, anim 文件其实顶一个, 它将把某个 go 旋转的 关键帧数据;

# 每个 curve 数据, 通过自己的 path 值, 来锁定 操作对象go;
	--	如果 .anim 仅操作一个 go对象, 那么这个 path 就是空的,
		此时将这个 .anim 绑给任何 go, 都能正常地旋转那个 go;

	-- 如果 .anim 内操作了多个 go (通常是父go的子go们), 那么每个 path 里就会写上目标 go 的 name;
		如果修改了 prefab 中 子go 的name, .anim 文件就会找不到, 从而放弃播放这部分动画;
		进而出现问题;
		---
		反过来, 如果我们将这个 .anim 绑到另一个 prefab 上, 且它含有 同名的子go, 则能正确播放动画;

# 如果操作的 子go 存在层级, 比如孙子go, 是需要特别写出来的. 比如: 
	path: l/door_l;

	层级不对的话, .anim 也是找不到目标 go 的;




# ============================================================ #
#                 .anim clip 面板设置
# ============================================================ #
在 animator controller 中选中一个 animation clip, 然后在 inspector 中能看到的属性:

# ---------------------------#
#	speed
#  	修改 .anim 动画播放速度
.anim clip 上的 speed 值, 默认为 1, 表示正常速度, 大于1 时变快, 小于0 时倒放;
这个 speed 值不能被修改;

若想修改动画速度, 因开启下方的 Multiplier, 然后新建一个 变量, 比如 float scale,
然后在这个 Multiplier 中, 选中变量 scale;

而这个变量 scale, 是可直接在 脚本中被更改的;


# ---------------------------#
#	motion time
指定 动画播放的时间点, 0f 表示开始位置, 1f表示结束位置;


# ---------------------------#
#	cycle offset
0f表示开始位置, 1f表示结束位置;
将播放的起始位置偏移一个距离, 比如一个人行走动画, 先迈左腿后迈右腿; 
若将 cycle offset 设为 0.5, 则会从中间开始放, 先迈右腿后迈左腿;

# 注意:
就算这个动画被设置为 只播放一遍, 本变量被设置为 0.5 后, 也不会说只播放 后半部分, 而是会把前半部分再补上, 播放完完整的一遍;


# ---------------------------#
#	Foot IK
是一种使用了 IK (反向动力学) 的 动画校正机制;

https://www.bilibili.com/video/BV1v3411e7am/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962

可用此 IK Goal 系统, 开发出 脚部适应地形 的功能;

	Animator.SetIKPosition()
	Animator.SetIKPositionWeight()


# ---------------------------#
#	Write Defaults
Whether the AnimatorStates writes the default values for properties that are not animated by its motion.

https://www.bilibili.com/video/BV1WL411c7mK/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962

这个功能 最好 先别开;


# 简单来说就是:
在 animator 被调用 Onenable() 的一瞬间, (就是这个组件及其 go 都被设置为 active 的一瞬间 ), 
animator 组件会遍历自己内部包含的所有 .anim clip 文件, 查看它们都包含了哪些 properties,
并记录下 这些 properties 此时被设置为的值, 把这些值看作 "Defaults";


若在某个 .anim clip 播放过程中, 发现某个 property 并没有在这个 clip 中被设置值, 且这个 clip 开启了 "Write Defaults" 选项;
那么就会在需要访问这个 property 的 关键帧上, 用之前记录的  Defaults 值来替代当前值 (当前无值...)

# 在这儿机制中:
每次触发 onenable(), unity 都会重新设置 Defaults 值, 这个行为会导致很多 意外的效果;






# ============================================================ #
#                 transitions 动画转换 面板设置
# ============================================================ #
就是在两个 .anim clip 之间做的转换;

https://www.bilibili.com/video/BV1gL4y1g7uZ/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962

# ------------ #
# Sole

# ------------ #
# Mute
勾选了此值的 转换, 永远不会被执行

# ------------ #
# has Exit Time
默认为勾选
-- 若勾选:
	当 起始.anim 执行到 exit time 时, 将自动执行本转换;
	此处的 exit time 需要在下方设置;

-- 若不勾选:
	则需要在下发的 conditions 中手动设置 触发转换 的条件;


# ------------ #
#  Conditions
可同时设置多条 转换条件, 这些条件需要全部被满足时, 转换才算成立;

# 若想在数个条件中 满足其一 就能激活转换, 
则可在 起始.anim 和 目的.anim 之间设置多条 转换线, 每条线单独设置 判断条件, 即可;


# ------------ #
# Interruption source
	当从 a.anim 转换到 b.anim 时, 开启本功能后, 是可以触发某些条件来中断当前这个转换, 
	并立即进入新的 转换的; 

#  官方博客:
https://blog.unity.com/technology/wait-ive-changed-my-mind-state-machine-transition-interruptions


https://www.bilibili.com/video/BV1xq4y147pD/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962



# ============================================================ #
#                Root Motion
# ============================================================ #
有的 .anim 文件内定义了角色的 位移信息,
如果勾选了 animator 组件中的 "Apply Root Motion" 选项, 那么 .anim 文件内的位移信息 就会被作用到 角色身上;
也可以不勾选, 然后自己用脚本实现;

https://www.bilibili.com/video/BV1kZ4y1B7Tc/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962

说白了就是: 原本一个不开启 Root Motion 的位移动画, 会反复从 0 运动到 1, 然后再回来, 开启下以循环;
开启 Root Motion 后, 第二次循环时, 起始位置不再重置, 而是接上上一回合末尾帧的位置;

# 此外, 如果 prefab 发生了缩放, 勾选 root motion 后, 位移/旋转等 的值也会跟着缩放;
	比如原本从 0 运动到 1;
	缩放为 0.5 倍后, 运动将从 0 运动到 0.5;


# OnAnimatorMove()
	若在一个 Animator 组件所在的 go 上, 绑定一个脚本, 在此脚本内实现一个 message: OnAnimatorMove()

	那么 Animator 组件内的 "Apply Root Motion" 会被修改为 Handled by Script;

	此时, unity 就不会再用 动画 来驱动 go 的移动; (而由我们的 脚本来负责)


# ---------------
# Bake Into Pose:
https://www.bilibili.com/video/BV1fq4y1Y7Sz/?spm_id_from=pageDriver&vd_source=df0fa6bb68b75a198c4c3f59ce640962

# 注意, 以下描述是基于 generic 动画的 (非 Humanoid 动画)
# Humanoid 动画 原理上也是类似的, 不过 Humanoid 动画 没有 根骨骼 这个概念, 而是 unity 自己为我们计算的 "质心点" 这个概念;

	点击 fbx 文件, 可设置它的 .anim clip 的三个 root motion 信息:
	如果勾选, 表示:
    	不要将 骨骼根节点的 (y轴旋转/y轴位移/xz平面位移) 当作 root motion 的一部分来处理; 
		而是把它们 当作普通的 骨骼动画来处理;

默认情况下, 是不勾选这 三个选项的;
此时, 如果开启了 root motion 功能; 那么对 骨骼根节点 的 (y轴旋转/y轴位移/xz平面位移) 将不会作用在这个 根节点上,
而是作用在 角色本身身上;


# 用途 -1-: 角色越走越偏:
	比如, 存在一个 向前行走的动画, 但是在动画过程中, 其实根骨骼还发生了一点点 y轴旋转;
	此时如果不勾选 Bake Into Pose, 那么 根骨骼的 y轴旋转会被作用到 角色身上, 导致角色越走越歪;
	---
	勾选 Bake Into Pose 后, 角色就能笔直向前走了
	---
	此时还应把下方的 Based Upon 改选为 Original;

	===
	当然, 对于那些本来就需要转弯的动画, 比如 "原地转90度", 就不应该勾选 Bake Into Pose;


# y轴方向位移:
	跳跃类动作, 建议不勾选, 让角色跟着动画 上下位移;
	待机走路跑步, 建议勾选, 

# xz平面位移:
	待机动画建议勾选, 这样角色在播放待机动画时就不发生位移了;



# ============================================================ #
#     如何使用 别的 人形角色 制作的 动画文件
# ============================================================ #
选择目标 动画 fbx, 将其改为 humanoid, 选择外部的 avatar 文件, 

# 然后重点: 这个外部的 avatar, 不能是 我们要用的 本游戏角色的, 还是应该是 原动画角色的 (比如用它的 t-pose 版的)

然后配置好后, 可以将这个动画文件, 用到 我们本地 角色身上来;










