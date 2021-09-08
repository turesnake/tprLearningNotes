# ================================================================//
#                       unity3d 使用技巧
# ================================================================//




# ----------------------------------------------#
#             名词翻译
# ----------------------------------------------#


# ----------------------------------------------#
#             文档阅读 书签
# ----------------------------------------------#
== 已阅读完毕的部分
-- Working in Unity - Installing Unity
-- Working in Unity - Unity's Interface
-- Working in Unity - Creating GameObj
-- Graphics - Meshes... - Mesh Components
-- URP
	


== 有待未来展开阅读：
	Working in Unity - Creating GameObj - Prefabs


～～ 正在阅读：
- Importing
- Scripting - C# Job System





# ----------------------------------------------#
#               等待学习的...
# ----------------------------------------------#
-- 如何用脚本 实现一个 component
-- 什么是动画中的 行为树
-- 普通go中的 Mesh Filter, 和 Mesh Renderer 
	分别是干什么的

-- DOCS 部分知识，包含：
	- Entity Component system
	- burst compiler
	- c# job system



# ----------------------------------------------#
#               unity 文档
# ----------------------------------------------#
程序已经自带了 全套文档。
直接点击某个 component 右上角的 问号 就能访问



# ----------------------------------------------#
#           osx 和 win 的文件配置问题  
# ----------------------------------------------#
mac上编辑后的unity文件，只需 Assets 和 ProjectSettings 两个文件夹的内容
替换掉 win版 unity文件中的同名文件夹。 程序就能自动匹配。


# ----------------------------------------------#
#             美术素材清晰度
# ----------------------------------------------#
当不需要平滑处理，想要保留像素图的锯齿时，
可以在 inspector -> filter mode -> point(no filter)  即可

# ----------------------------------------------#
#             2d项目 的图层 顺序
# ----------------------------------------------#
在 sorting layer 中调整，
首先在sorting layer 中 创建几个层
然后在不同对象的 sprite render 中 的 sorting layer 里设置，
此外还可以在下行的 order in layer 中设置 在单个图层里不同物体间的顺序


# ----------------------------------------------#
#      vscode 关键词高亮，omnisharp 失败
# ----------------------------------------------#
在用 vscode 打开脚本后，
如果提示 omnisharp 失败，且失败信息写着：
	.NETFramework,Version=v4.7.1 were not found
---
此时可能是 mono 版本太低了，重装一个 stable 版本的最新版即可


# ----------------------------------------------#
#           Assert 中 资源的复制
# ----------------------------------------------#
在 Assert 中选中资源，
	Edit - Duplicate
	此操作可以 复制大多数 资源


# ----------------------------------------------#
#           图片素材，像素风模糊
# ----------------------------------------------#
  原始图片素材的 inspector:
  	Filter Mode -> Point(no filter)


# ----------------------------------------------#
#             GetComponent
# ----------------------------------------------#
--1-- Transform tf = GetComponent<Transform>();
--2-- Transform tf = GetComponent("Transform") as Transform;
	----
	官方推荐第一种写法（带<>的），性能更优。
	在某些情况下，比如访问绑定的 script脚本，则只能用第二种方法


# ----------------------------------------------#
#             SQLiteUnityKit
# ----------------------------------------------#
一个夸平台的 sqlite 工具包
（原始工具包里，不包含 win 上的dll，需要自己补充一个）

-- 这个插件要求 用户事先将一个 xxx.db 文件
	放入 Assets/StreamingAssets/ 目录中



# ----------------------------------------------#
#            摄像机视角调整
# ----------------------------------------------#
-1- 手动调整 scene 中画面视角
	或者，双击 hierarchy 中某个 obj，来让视角 “注视” 它
-2- 选择要调整的 camera
-3- 菜单 - Game Object - Align with View
	目标摄像机，视角将和 当前画面同步




# ----------------------------------------------#
#            color space
# ----------------------------------------------#
共两种：
	-- Gamma
		部分移动设备，只支持 gamma 模式
		缺点是，亮部过爆，整体油腻
	-- Linear
		中间色调表现比较充足，亮度细节保留较多


修改方式：
	edit - project settings - color space 中

PBR 最好在 linear 模式中运行



# ----------------------------------------------#
#           Layer / layermask 使用
# ----------------------------------------------#
-1- 需要用 laymask + raycast 做射线检测时，
	不管是要检测的 layer，还是要屏蔽的 layer，
	都不要设置为 0:Default
	---
	0:Default 是无法被 mask 的

-2- 如果想要针对 第8层，其实要设置 mask 为 9...



# ----------------------------------------------#
#             Prefabs
# ----------------------------------------------#
将一个 gameobj 拖动到 Project 窗口中, 就能制作一个 prefabs 实例

一个 prefab asset, 自己拥有固定的数据, 比如 transform 组件, 
可点击 Project 窗口中的某个 prefab asset 查看. 

一个在 Hierarchy 窗口中的 prefabs 实例, 可以复写这些默认值, 被复写的值, 往往会标记为 黑体字.
修改 prefab asset, 可影响 场景中所有 它的实例, 当然, 那些复写了这个数据的 实例除外:
当一个实例 复写了某一个数据, 这个数据就不再和 prefab asset 相互绑定了. 


# --- 如何在运行时 生成 GameObj/Prefab 实例 ?

# --
Object.Instantiate( goTransform );
# ==
	参数可用 目标go 或 prefab 的 transform, 

本质上这个函数通用度很高:
	T Instantiate<T>(T original) where T : Object;

只要传入一个 Object 类成员, 它都能给你复制, 返回值也是对应类型. 



# ---------------------------------------------- #
#       VSync (垂直同步) in Game 窗口
# ---------------------------------------------- #
可单独设置 Game 窗口运行时的垂直同步,

在左上角, 设置分辨率的条目中, 点选 VSync 

注意, 想要此功能起效, 不能在运行时同时显示 Scene 和 Game 两个窗口


# ---------------------------------------------- #
#       VSync (垂直同步) in build app
# ---------------------------------------------- #
Project Settings - Quality - Other - VSync Count;

# -- Dont VSync
	关闭垂直同步

# -- Every V Blank
	逐帧垂直同步, 例如在 60HZ显示器上, fps 会被锁为 60;

# -- Every Second V Blank
	每两帧垂直同步一次, 例如在 60HZ显示器上, fps 会被锁为 30;



# ---------------------------------------------- #
#       Awake 
#		Start 
#		Updata 之间的区别
# ---------------------------------------------- #

# -- Awake
	类似于 constructor 构造函数
	会在本类的 成员 被新建完毕后,调用


# -- Start
	只有在 本组件的 Update 函数被 第一次调用之前, Start 函数才会被调用
	(无论这个 组件是否有 update 函数)
	如果一个 组件在运行时的某一时刻被新建, 它的第一个 update 会在下一帧被调用. 
	 


# -- Update


# ---------------------------------------------- #
#       两个 Vector 之间的乘法
# ---------------------------------------------- #
Vector3 Scale(Vector3 a, Vector3 b);

得到 new Vector3( a.x*b.x, a.y*b.y, a.z*b.z );


# ---------------------------------------------- #
#		MonoBehaviour.
#       OnEnable()
#		OnDisable()
#		OnValidate()
# ---------------------------------------------- #

# -- OnEnable()
	本组件每次在 editor 中热更新后 (也包括 刚启动的 Awake() 时),
	进入 enable 状态的一瞬间, 会调用此函数

# -- OnDisable()
	被正式销毁时, 也包含每次 editor 热更新时的 重置

	当 behaviour 类实例 被设置为 disabled 时, 此函数被调用.
	当 obj 被销毁时, 此函数也被调用.

	and can be used for any cleanup code. 
	When scripts are reloaded after compilation has finished, OnDisable will be called, 
	followed by an OnEnable after the script has been loaded.


# -- OnValidate()
	只在 editor 模式中有意义的函数, 当一个 脚本被 loaded, 或当一个变量在 inspector 中被修改时,
	此函数被调用.

	所以, 这个函数的内容, 可围绕那个刚在 inspector 中被修改的 变量展开, 比如, 修正它的范围.

	注意:
		不应在此函数中做别的事情,比如:
		新建obj, 调用其它 非线程安全的 unity api. 
		---
		因为 此函数可能不会在 main thread 中被调用, 而是在类似于 loading thread 中.

		不该在此处 执行 camera rendering 操作. 而是应该 add a listener to EditorApplication.update; 
		and perform the rendering during the next Editor Update call.











