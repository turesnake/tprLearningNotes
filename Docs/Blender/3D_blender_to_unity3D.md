# ================================================= #
#      3D素材，从 blender 导入 unity
# ================================================= #


# ---------------------------------------- #
#             坐标系适配
# ---------------------------------------- #
!EXPERIMENTAL! Apply Transform 选项无法搞定 Armature
的坐标系问题

本方法更值得选用：
-- 解除 mesh-bone 父子关系
	先选 mesh，后选 bone，alt+p, 
	clear parent and keep transformation

-- 先后选中 mesh，bone，然后 x轴 旋转-90 度
	
-- ctrl+A， 选 rotation，

-- 保持两者选中的情况下，再次修改 x轴 旋转 90 度

-- 先后选中 mesh，bone，
	ctrl+p - Armature Deform
	---
	此时可以进入 pose 模式，看看之前绑定的 骨骼是否还正确

-- 导出为 fbx
	- 不选 !EXPERIMENTAL! Apply Transform
	- Apply Scale: FBX unit Scale

=====
结果
此时，armature 坐标系正确了
但是其体内的 bones，坐标系都出现了错乱
好像也不能这么说，因为其实在 blender 中，这些骨骼的坐标系
也是按照这个 方式排列的




# ---------------------------------------- #
#       blender 中的 ik 信息
# ---------------------------------------- #
blender 中的 ik，无法传递进 unity

但是借助 ik 实现的 动画动作，可以被保存为一个单独的文件，
传输进 unity，并且正确地在 unity 中驱动 模型和bone 运动


# ---------------------------------------- #
#       blender 中的 bones 信息
# ---------------------------------------- #
如果不在 blender 中设置 ik，
bones 似乎可以被传递进 unity。

每一根 bone，在 unity 中变成了两个空节点，一头一尾
尾部作为 头部的 子节点存在。

单独修改 一根 bone 的 尾节点 是无效的。

但是，单独修改 一根 bone 的 头节点 却是可行的。
这个 头节点，代表了这个 bone，还连接着 相关的 mesh 顶点

尝试收集一些机器人 



# ---------------------------------------- #
#       blender 中的 形态键信息/ Sharp Keys
# ---------------------------------------- #
形态键 可以用来实现 任意可能性的 模型状态切换。
是学习的重点

-- 将 fbx 文件 导入 unity 后，
	需要在 fbx 文件的 Inspector 面板中，
	Model 区，勾选 Import BlenderShapes 选项 ！！！
	===
	此时，如果讲一个 模型拖动到 场景中，我们会发现
	这个 go 的 Skinned Mesh Renderer 组件中
	多了一个：BlenderShapes: "key 1" 或者别的名字 的变量。
	这意味着，这个 Sharp Key 的信息是公开的，我们可以在代码中，手动驱动它。


-- 此外，如果我们已经借助 形态键，在 blender 制作好的动画，包括 mesh 的顶点变形
	那么这个动画，可以直接在 unity 中正常播放
	

-- 但是如果在 unity 中，直接旋转某个bone，则不会触发形态键效果
	也许需要在脚本中，同步改写相关 Sharp Key 变量的值才行






# ---------------------------------------- #
#       blender 中的 constrains 信息
# ---------------------------------------- #

unity 中曾记录支持 constrains 信息 的导入

可以查一下具体怎么支持的
...



# ---------------------------------------- #
#  在研发阶段，频繁修改和导入 fbx 文件非常麻烦
#  尤其是需要重新绑定很多 unity 中的配置时
#  -------------
#  尝试该用 .blender 文件
#  .blender 文件的修改 和导入 unity 
# ---------------------------------------- #
-1- .blender 文件也需要执行 fbx 文件那样的 坐标系调整
	也就是让所有 mesh 和 armature，rotation 都变成 (90,0,0)
	scale 为 (1,1,1)

-2- 为 vscode 添加两个插件
	-- Unity3D Meta Files Wather
	-- vscode-meta (这个可能最重要)
	这样一来，我们就能只用在 vscode 中 增减 Assert 目录中的 资源文件了
	插件会自动帮我们 添加/更新 .meta 文件

-3- 针对一个 .blender 文件做修改（在任何平台的 blender 软件中）
	将这个修改过的 .blender 文件，拖入 vscode 管理的项目目录中
	就完成了 .blender 文件 的更新

====
这个方法是最理想的，我们可以在 win 中修改模型，在 mac 中管理项目和编写代码



～～～～～～～～～ 目前的进度：～～～～～～～～～～



--- 已经成功使用 final ik，
	可以尝试使用现有的技术，来制作一个 步行机器人


--- 在 final ik 演示中，展示了一种效果：
	角色循环播放一个固定的动画，在此期间，还能额外通过 ik
	来影响这个动画


--- 查看 .fbx 文件的编程格式


--- Mesh Renderer 和 Skinned Mesh Renderer
	两者有什么区别
	---
	Skinned Mesh Renderer 专门用于 骨骼动画
	所以，一个没有设置 bone 的模型，只会触发 Mesh Renderer


--- 尝试在 blender 中 练习 sculpting, 并且熟悉整个建模流程
	实现材质贴图
	实现发现贴图
	并能成功在 unity 中显示

--- 基于制作的模型，在 unity 中为其打光 




