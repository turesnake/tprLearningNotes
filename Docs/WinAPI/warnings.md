
# ==== 默认使用 clang =====


# ============= 被推荐的 选项 ==============

-Werror -- 将 warnings 当作 errors 来处理
-pedantic-errors -- 不等于 -Werror -pedantic
-Wall -- 
-Wextra --
-Wconversion --
-Wsign-conversion --


# ============= 目前遇到的问题：=============
	-Wnonportable-system-include-path
	-Wc++98-compat
	-Wc++98-compat-pedantic
	-Wzero-as-null-pointer-constant
	-Wold-style-cast
	-Wsign-conversion
	-Wshorten-64-to-32
	-Wreserved-id-macro
	-Wlanguage-extension-token
	-Wdocumentation
	-Wglobal-constructors   (需要全局变量 析构函数)
	-Wexit-time-destructors (需要exit时 析构函数)
	-Wdocumentation
	-Wshadow 
		(whenever a local variable shadows another local variable)
		(局部变量名 和 更高一级范围的变量名 重名)
	-Wcovered-switch-default
	-Wunused-parameter
	-Wgnu-anonymous-struct （glm中，使用了老式的 匿名struct）
	-Wfloat-equal (glm中，直接用==,!=来对比浮点数，是不安全的	)
	-Wmissing-prototypes (没有声明直接定义)
	-Wnested-anon-types 
		(anonymous types declared in an anonymous struct are an extension)
		(glm,嵌套出现 匿名 struct)
	-Wswitch-enum (enum中某个元素未被 switch 处理时)


# ================== 解决方案 ================
-Wno-c++98-compat
	关闭 -Wc++98-compat 警告

-Wno-global-constructors
	关闭 -Wglobal-constructors 警告
	但是最好不要这么做。
	目前为止， 全局变量式的 stl容器，似乎不是一个值得推荐的方案

	最好的方案是，将它们封装为一个 RAII 结构，这样，在自动析构时
	存在一个 显性的 析构过程
	---
	也有信息说，这个问题是不重要的，它仅仅意味着，全局变量会在 程序退出后再被销毁
	这会导致 程序退出时间变长。

-Wno-documentation
	关闭 -Wdocumentation


















