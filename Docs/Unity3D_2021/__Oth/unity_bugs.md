# ================================================================ #
#                    unity3d 使用 bug 综合
# ================================================================ #



# ----------------------------------------------#
#            Omnisharp 下载慢
# ----------------------------------------------#
可以暂时性关闭 自动更新（但需要定期手动解锁一下，让它更新）

菜单 首选项 - 设置 - 查找:"Omnisharp.path" - 修改设置
将 "omnisharp.path": "latest", 改成某个固定的版本：
目前暂时设置为 "1.37.1-beta.51"
	暂时管用

为了保证项目长期问题，最好定期允许 omnisharp 升级一次...



# ----------------------------------------------#
#   The reference assemblies for .NETFramework,Version=v4.7.1 were not found
# ----------------------------------------------#
当出现这个问题时，说明最新版的 omnisharp 已经下载完毕并正常运行了。


# Mac 版方案:

记录中，这个bug 是通过 升级 mono 解决的

前往：
https://www.mono-project.com/download/stable/

下载最新的 mono，重新安装

------------------
如果还不能搞定，
请把 vscode 中的 C#插件 回滚到 上一版本。
目前，2020_0823
可行版本为 1.23.0


# Win 版方案:
我们需要根据提示，真的去下载要求版本的 .net Framework (比如说，4.7.1)
而且，因为系统中往往已经安装了更高版本的 .net Framework， 直接下载安装常规版，
会被拒绝安装
此时的方案是：下载 同版本的 开发版，这是允许安装的




# ----------------------------------------------#
#   Frame Debug 窗口 无法正确显示 shadowmap depth texture 内容
# ----------------------------------------------#
不管做什么操作, depth texture 都是全黑的.
但是这个 texture 的内容并没有错, 它能支持后续的 shadow 绘制.
仅仅是不在 Frame Debug 窗口中显出出来.

原因在于: 2020.3.12f1c1(LTS) 这个版本存在bug, 它的 Frame Debug 就是无法显示 
depth texture.

换成某个 2021版本就好了 




# ----------------------------------------------#
#   按照 pachage 时报错, 提示无法修改 资源或目录
# ----------------------------------------------#

一种原因是: vs/vscode 等编辑器锁定了这些目录的 读写权.
将 vscode 等编辑器关闭后, 再按照 package, 就没问题了. 




# ----------------------------------------------#
# The animation state could not be played because it couldn’t be found!
# ----------------------------------------------#

https://www.unity3dtips.com/zh/the-animation-state-could-not-be-played-because-it-couldnt-be-found/

在 debug 模式下打开 animationclip 文件, 勾选 legacy, 就可以了


# ----------------------------------------------#
#        不管开啥场景, 都不停地报 "null..." (空引用错误)
# ----------------------------------------------#

# 可能是 Animator 窗口挂了,  此时重启此窗口, 或者重启 unity 就好了;



# ----------------------------------------------#
#   Resolve of invalid GC handle
# ----------------------------------------------#

Resolve of invalid GC handle. The handle is from a previous domain. The resolve operation is skipped.
UnityEngine.GUILayout:Window (int,UnityEngine.Rect,UnityEngine.GUI/WindowFunction,string,UnityEngine.GUIStyle,UnityEngine.GUILayoutOption[])



https://blog.terresquall.com/2023/03/how-to-fix-the-resolve-of-invalid-gc-handle-error-in-unity/






