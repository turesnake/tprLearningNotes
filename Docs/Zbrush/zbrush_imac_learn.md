-------------------------  ------------------------------
------------------------- zbrush_imac ------------------------------

# 这个文件中的内容要被逐步整理出来

====================================================================

+++++++++++++++++++++++++ 破解版 BUG +++++++++++++++++++++++++

-- 在讲 zb窗口最小化，再还原后，顶层菜单按钮无法点击
	解法：将zb全屏，即可恢复
	有时仍会无效， 禁止在工作期间切换zb窗口

+++++++++++++++++++++++++ 基本操作 +++++++++++++++++++++++++

-- 空白处 左键拖拽
	旋转对象

-- alt+空白拖拽
	平移

-- alt+空白拖拽+释放alt
	缩放对象

-- 空白拖拽+shift
	矫正对象角度

-- 空格键
	打开绘画面板




+++++++++++++++++++++++++ IO +++++++++++++++++++++++++

-- 从 zb 输出 .obj 模型文件
	最好先用 ZRemesher 重新整理下 模型的 点线面：
	-- 勾选 Legacy(2018)
	-- Target Polygons Count 设置为 0.1
	-- 点击 ZRemesher
	====
	这样就能生成一个面数很低的 模型（相对于 zb）

-- 直接导入 blender
	然后可以在此基础上做一个 low poly 出来
	---

～～ 猜想
	也许可以直接在 zb 导出的 .obj 文件的基础上
	删减 模型的 点，从而精简面数






+++++++++++++++++++++++++ 部分快捷键 +++++++++++++++++++++++++

-- v
	切换对象前景色和背景色

-- ctrl+shit
	左侧出现框选按钮，可以选择性显示部分模型
	（恢复全模型显示：ctrl+shift+左键点击空白）

-- F
	最大化显示正在编辑的对象


-- Q
	绘画模式


+++++++++++++++++++++++++ 菜单按钮位置 +++++++++++++++++++++++++

-- Draw -> angle of view
	调整镜头广角

-- transform -> active symmetry
	激活对称 【重要！！！！！！】

-- preference -> hotkeys ->store按钮
	保存笔刷快捷键

-- preference -> config ->store config按钮
	保存界面设置




+++++++++++++++++++++++++ subtool 区按钮 +++++++++++++++++++++++++

-- append
	增加子模型

-- duplicate
	复制模型

-- split -> split hidden
	将隐藏的区域独立成新子模型
	ctrl+shift隐藏某一区域，然后按 split hidden 按钮

-- merge -> mergedown
	将上面的子模型合并进下面的子模型。

-- merge -> mergeVisible
	将所有可视子模型合并。

-- weld按钮 是否点亮
	此按钮在启动／点亮时，可以在合并时焊接相交处。关闭／熄灭状态则不焊接



+++++++++++++++++++++++++ 特定技巧 +++++++++++++++++++++++++

-- 眼球的镜像复制：
	放置好第一个眼球的位置，复制一个眼球。
	用deformation——mirror按钮。


-- 头发笔刷
	curve strap snap -> stoke面板 -> curve modifiers
	画 
	点一下其它模型。


-- 从遮罩中提取一层新subtool ->
	制作遮罩层 ->
	subtool ->
	extract ->
	accept

-- 调整移动笔刷的控制范围
	brush面板 -> auto masking -> mask by polygroups滑块。


-- 让画笔更流畅
	stroke面板 -> lazy mouse -> lazyradius滑块


-- 在同一轨道上绘画
	stroke -> laztmouse -> backtrack -> snap to track -> line

-- 在单一subtool内移动不同的原件
	按住ctrl。移动，


-- 同时移动多个subtool
	zplugin面板 -> transposemaster -> Tposemesh按钮


-- 翻转开放模型的正面
	display properties -> flip按钮。


-- 开放模型中显示双面
	display properties -> double按钮。


-- insertcylinder笔刷
	按住alt拖出柱体 -> 调整柱体 -> ctrl空白拖动两次。就能反向挖出一个空洞


-- 创建Z球
	adaptive skin面板 -> adaptive skin按钮

-- 创建Zsketch
	创建z球——zsketch面板——editsketch按钮——进入zsketch模式。
	（绘制中按alt可删除）
	打开unified skin面板——make nuified skin按钮


-- 柔滑选区边缘
	选好选区mask后，按住ctrl，左键点击模型。

-- 锐化选区边缘
	选好选区后。按住ctrl+alt按，左键点击模型。

-- 删除隐藏选区
	制作好隐藏选区后，geometry——modify topology——del hidden按钮删除隐藏。此时模型的边界是开放的。再点击close holes按钮。将模型填实（也可以重新填dynamesh。不过前者更为直接）

-- 在低模中制作流畅的选区边缘
	选区——polygroups面板——groupmasked后面的polishgl滑块。此滑块较大时。选区边缘减少锯齿更加流畅。最后点击groupmasked按钮。


-- 背景色渐变设置
	document——rang设置（0位关闭渐变）


-- 背景色设置
	document——back按钮。拖动按钮到任何颜色上。


-- 上色程序1
	tool——polypaint——colorize。点开rgb，关掉zadd——上色。

	展好UV，把zadd去掉，zrgb开开。tool>texture map>new tetr。这样就可以画了。
	画完了 点击tool>texture map>clone tetr ，点下texture>flip v，然后texture>export输出psd。


-- 导出高尺寸渲染图
	document面板——修改长宽尺寸——resize按钮——ctrl N新建视窗——重新拉出模型摆好位置——调整画面右侧的zoom滑块来缩小画布获得全面效果——返回document面板，export输出画面。

-- curve面板
	bend和snap
	snap开启时,curve笔刷绘制的subtool不会陷落到原有模型内部去、。
	bend作用在绘制之后的调整上，关闭bend时，拖动导轨线将移动整个subtool，开启bend时，只移动部分区域。














//---end---