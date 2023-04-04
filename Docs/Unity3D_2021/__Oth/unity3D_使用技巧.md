# ================================================================ #
#                       unity3d 使用技巧
# ================================================================ #




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


# ----------------------------------------------#
#    如何在运行时 生成 GameObj/Prefab 实例 ?
#    复制gameobj
#    
# ----------------------------------------------#

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
#       两个 Vector 之间的乘法
# ---------------------------------------------- #
Vector3 Scale(Vector3 a, Vector3 b);

得到 new Vector3( a.x*b.x, a.y*b.y, a.z*b.z );



# ---------------------------------------------- #
#     float3x4 中, 手动实现 TRS() 函数
# ---------------------------------------------- #

在原生 unity 代码中, 存在便捷的 Matrix4x4.TRS 函数:

[code]	Matrix4x4 TRS( Vector3 pos, Quaternion q, Vector3 s );

在 jobs 系统中, 为了优化改用 Mathematics 库, 其中有 float4x4 版的 TRS 函数:

[code]	float4x4 TRS( float3 pos, quaternion q, float3 s );

为了进一步优化, 可把最后一行 (0,0,0,1) 省略. 改用 float3x4,
但 float3x4 并没有现成的 TRS 函数, 我们需要手动实现:

	float3x3 r = float3x3(rootPart.worldRotation) * objectScale;
	float3x4 matrix = float3x4( r.c0, r.c1, r.c2, position );



# ---------------------------------------------- #
#          Gradient  渐变色编辑器
# ---------------------------------------------- #
一个非常方便的 inspector 渐变色 编辑器;
在脚本中添加:

[SerializeField]
Gradient gradient;

然后就能在 inspector 中手动编辑. 

回到脚本中, 可调用 gradient.Evaluate( time ) 来获得某个颜色
此处 参数 time 是一个 [0,1] 值



# ---------------------------------------------- #
#          Weyl Sequences 随机数
# ---------------------------------------------- #

	frac( i * 0.381f )

用一组 [0,+inf] 的整数数列, 逐项乘以 0.381, 然后取其小数, 得到:

0.000, 0.381, 0.762, 0.143, 0.524, 0.905, 0.286, 0.667, 0.048, 0.429, 
0.810, 0.191, 0.572, 0.953, 0.334, 0.715, 0.096, 0.477, 0.858, 0.239, 0.620, 
0.001, 0.382, 0.763, 0.144, 0.525.


这是一组随机数列, 每 21 个元素循环一次, 每一轮循环, 都比前一轮循环 大 0.001
所以 也不算真正的循环. 

是一种廉价的实现 随机数的方式. 



# ---------------------------------------------- #
#       在 scene 场景中 同步 camera 视角
# ---------------------------------------------- #
在 scene 场景中选择中意的视角,
选中 Hierarchy 中的 camera,
点击: GameObject - Aligh With View 

此时, 目标 camera 的视角就被同步了. 




# ---------------------------------------------- #
#       UNITY_EDITOR
# ---------------------------------------------- #

说明当前在 unity editor 平台运行, 而不是打包后的 ios, 安卓平台;

而不是之前错误理解的: "在 editor 非 play 状态"...

# 想要在 editor 平台判断 当前是否在运行 play, 可访问 Application.isPlaying 变量;
	注意, 当在一个 ScriptableObject 实例的 OnEnable() 函数体内访问 Application.isPlaying 时, 将获得 false;
	具体原因请在全局查找 Application.cs 内的注释;

# 以下代码有同等效果:
	[Conditional("UNITY_EDITOR")]
	void OnDrawGizmos()
	{
    	// ...
	}


# ----------------------------------------------#
#      shader 被哪些 materials 使用了 ?
#      查找项目中 shader 的使用
# ----------------------------------------------#
shader 会被 不同的 material 使用, 我们想找出这些 materials;

--
	去 shader 的 .meta 文件里, 拿到 guid;

--
	在 vscode 搜索中, 锁定 *.mat 文件, 然后搜索这个 guid;
	就能搜到所有的 materials 文件;



# ---------------------------------------------- #
#    如何计算 camera 的 near plane half extends ( 近平面尺寸 )
# ---------------------------------------------- #
假设我们要计算的 近平面 half extends 为:

	Vector3 halfExtends;

则:
	halfExtends.y =
				camera.nearClipPlane *
				Mathf.Tan(0.5f * Mathf.Deg2Rad * camera.fieldOfView);
	
	halfExtends.x = halfExtends.y * camera.aspect;

	halfExtends.z = 0f;

# 这个信息位于 camera-space;

# 通常被用作 Physics.BoxCast() 的一个参数;



# ----------------------------------------------#
#  快速进入 play 模式:
#    	Enter Play Mode Options (Experimental)
# ----------------------------------------------#

Project Settings -> Editor -> Enter Play Mode Settings

https://www.jianshu.com/p/226d557ab226



# ----------------------------------------------#
#    安卓打包, 在 OpenGLES3 和 Vulkan 之间如何切换
# ----------------------------------------------#
project settings -- Player -- Other settings -- "Auto Graphic API"
	取消打勾;

然后在下方新增的窗口中, 把需要的图形库, 比如 OpenGLES3, 拖到最上方去;



# ----------------------------------------------#
#    点击屏幕, 如何防止 UI 层 和 obj层 的穿透问题
# ----------------------------------------------#
若想只点击 ui 层, 不点击屏下的 obj 层, 可以:

	using UnityEngine.EventSystems;

    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    //EventSystem.current.否则返回false
    if( Physics.Raycast(ray, out RaycastHit hit) && !EventSystem.current.IsPointerOverGameObject() )
    {
        ...
    }

# 核心: EventSystem.current.IsPointerOverGameObject()



# ----------------------------------------------#
#   自定义脚本, 如何在 inspector 上开放 event 绑定
# ----------------------------------------------#
https://forum.unity.com/threads/how-to-select-a-callback-function-for-your-script-from-the-editor.295550/


# UnityEvent 
更简单一些, 缺点是无法传参数
https://blog.csdn.net/qq_39735878/article/details/105863133





# ----------------------------------------------#
#   将 world-space 物体坐标, 投影到 screen-space 上
#   同时克服 cinemachine 带来的晃动问题
# ----------------------------------------------#

# -1-
	Camera.WorldToScreenPoint() 执行坐标系转换;

# -2-
	上述计算放在 LateUpdate() 中;

# -3-
	同时 在 project settings - Script Execution Order 面板中, 添加本脚本, 
	将本脚本时序排在 cinemachine 的后面;
	---
	这个修改会出现在目标 cs脚本对应的 meta 文件里, 变量为 executionOrder;
	---
	(也可通过添加 [DefaultExecutionOrder(115)] attribute 来实现 )


这样依赖转换得到的 坐标就不晃动了



# ----------------------------------------------#
#   Animation 界面不显示 sample 信息
# ----------------------------------------------#
https://answers.unity.com/questions/1642306/dont-have-sample-on-animation-windows.html

右上角 设置里可开启




# ----------------------------------------------#
#   非递归地遍历 gameobj 的 子 gameobjs
# ----------------------------------------------#

	GetComponentsInChildren() 会递归所有 子孙节点

	若只想遍历 子节点, 可使用:
	---
	foreach (Transform tf in someGameObj.transform)
    {
		...
	}
	---

	注意, 必须使用 Transform, 不能使用 var


# Transform.Find() 也有相似的 功能




# ----------------------------------------------#
#    使用 LoadSceneAsync 异步加载场景时,  new GameObject 可能存在的问题
# ----------------------------------------------#

LoadSceneAsync() 不回立刻返回新场景, 但新场景内的脚本可能已经调用了 new GameObject();

如果 new go 没有设置自己的 parent, 则它可能被创建在 old scene 中.
然后如果你在新建场景后, 删除掉 old scene, 则可能把 new go 连带删除掉...





# ----------------------------------------------#
#   tag 检测: Component.CompareTag()
# ----------------------------------------------#

直接使用 tag == "Dog" 会引发 GC, 改用 CompareTag();





# ----------------------------------------------#
#   multi tags
# ----------------------------------------------#
如何为一个 gameobj 设置多个 tags:

# -1-:
	制作一个 脚本, 绑定到 gameobj 上, 可以自定义 tags;
	===
	缺点:
		-1-: 为每个 gameobj 绑定一个脚本存在成本, 比如说场景里的海量物件, 每个都要绑定;
		-2-: 每次检查 gameobj 时都调用 getcomponent 存在成本;
				尤其是当 每帧都要用探针检查多个 go, 然后获取它的 tags 时;

# -2-:
	tag 本质是 string, 使用 bitmask 思维, 做成 "Dog-Red" 这种复合 tag, 然后检测....
	===
	缺点:
		-1-: tag 数量会碰撞




# ----------------------------------------------#
#      Behaviour.isActiveAndEnabled
# ----------------------------------------------#

Reports whether a GameObject and its associated Behaviour is active and enabled.

A GameObject can be active or inactive. Similarly, a Behaviour can be enabled or disabled. 
If a GameObject is active and has an enabled behaviour then isActiveAndEnabled will return true. Otherwise false is returned.

Note: value is ReadOnly.
To determine whether GameObject is active, isActiveAndEnabled uses the equivalent of activeInHierarchy.





# ----------------------------------------------#
#    如何在 inspector 中暴露 interface
# ----------------------------------------------#

https://stackoverflow.com/questions/64122920/how-to-work-around-unity-not-displaying-interfaces-in-the-inspector


	public abstract class BaseTool : MonoBehaviour 
	{ 
		public abstract void Use(); 
	} 


	public class Equipment : BaseTool 
	{ 
		public override void Use()
		{ 
			...
		}
	} 

# 就是将一个普通的 MonoBehaviour class 实现为 抽象类, 这样就能要求一些需要被强制实现的 函数,
	用这个办法来模拟一个 interface,
	同时还支持被暴露在 inspector 中.....




# ----------------------------------------------#
#   当 shader 找不到 hlsl 文件 时
# ----------------------------------------------#
但明明那个文件存在在那里,

# 此时右键 shader 文件, "Reimport" 即可





# ----------------------------------------------#
#   当场景在运行时 被修改后, 如何保存这个场景
# ----------------------------------------------#

https://www.bilibili.com/video/BV1QM411W7Jb/?vd_source=df0fa6bb68b75a198c4c3f59ce640962

这个方法目前暂没走通, 有点问题





# ----------------------------------------------#
#     tag layer 修改后存储在哪:
# ----------------------------------------------#

TagManager.asset




# ----------------------------------------------#
#         Alpha Is Transparency
# ----------------------------------------------#

https://zhuanlan.zhihu.com/p/340754532

https://zhuanlan.zhihu.com/p/344751308







