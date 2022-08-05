# ================================================================ #
#               JavaScript in PhotoShop 使用技巧
# ================================================================ #


# ++++++++++++++++++++++++++++++++++++++++++++++#
#                    杂
# ++++++++++++++++++++++++++++++++++++++++++++++#

-- 如何用 ps 运行一个脚本
	“文件” - “脚本” - “浏览” - 目标文件(任意目录)
	---
	也可直接将 .jsx 文件拖动到 ps 中


-- alert("---koko---");
	弹出警示框

-- app.preferences.rulerUnits = Units.PIXELS; 
	设置 ps尺寸为 像素制
	最好写在 脚本开头


-- open(File("D:xxx.jpg"));
	大开一张现成的图片
	在win中，path 中的 "\" 记得改成 "\\",或者改用 "/"


-- open(File(openDialog()));
	让 ps 弹出一个窗口，叫你选择要打开的文件

-- var newDoc = app.documents.add();
-- var newDoc = app.documents.add( 800， 600 );
	新建一个 ps文件
	---
	参数是基于像素还是厘米，由 app.preferences.rulerUnits 决定


-- app.activeDocument.resizeImage("150%", "150%");
	修改 当前激活态文件 的 size。 

-- app.documents[0].artLayers.add();
	为某个 ps文件，新建一个 图层





# ---------------------------------------------- #
#       从文件中复制图层 到新建文件
# ---------------------------------------------- #

var olddoc = open(File("D:xxx.jpg"));
olddoc.activeLayer.copy();
		//- 复制当前活跃图层
var newdoc = app.documents.add(90,60);
		//- 新建ps文件，此处的 参数是 厘米 ...
newdoc.paste();
		//- 将之前复制的数据，粘贴到 新文件
olddoc.close(); 
		//- 关闭 旧文件



# ---------------------------------------------- #
#        新建文字图层，并设置文字内容
# ---------------------------------------------- #
-- var layer = doc.artLayers.add(); //- 新增图层
-- layer.kind = LayerKind.TEXT; //- 将目标图层改为 文字图层
-- var textItem = layer.textItem; //- 获得 文字图层的 文字obj
-- textItem.contents = "Hello, World"; //- 修改文字信息



# ---------------------------------------------- #
#                 active
# ---------------------------------------------- #
-- app.activeDocument = docs[i];
	docs 保存了之前建立的 document objRefs
	从中取出一个，设置其为 当前激活态 doc
	---
	只有激活态的 document，才能执行进一步操作


-- doc.activeLayer = doc.layers[0]
	设置某图层为 激活态图层

-- channel = new Array(doc.channels[0], doc.channels[2]);
	doc.activeChannels = channel;
	---
	设置激活态 通道



# ---------------------------------------------- #
#                   save
# ---------------------------------------------- #

//--- 保存为一张 png -----
app.documents.add();

pngFile = new File( "/Users/tom/Desktop/tmp_1.png" );
pngSaveOptions = new PNGSaveOptions();
pngSaveOptions.embedColorProfile = true; 
pngSaveOptions.formatOptions = FormatOptions.STANDARDBASELINE; 
pngSaveOptions.matte = MatteType.NONE;
pngSaveOptions.quality = 1;
app.activeDocument.saveAs(pngFile, pngSaveOptions, true,
               Extension.LOWERCASE);



# ---------------------------------------------- #
#                document obj
# ---------------------------------------------- #

-- doc.resizeImage( 1300, 900 );
	修改 ps文件 画布尺寸。原来的图形会被缩放拉升

-- doc.resizeCanvas( 60,50, AnchorPosition.BOTTOMLEFT );
	修改 ps文件 画布尺寸。原来的图形会被裁剪（没有拉升缩放）

-- doc.trim(TrimType.TOPLEFT, true, false, true, false)
	裁剪画布，但暂时没搞懂用法

-- doc.crop(new Array(100,200,400,500), 45, 20, 20);
	采集？ 不知道什么意思...

-- doc.flipCanvas(Direction.HORIZONTAL)
	将画布左右翻转

------ paste ------
ArtLayer Doc::paste( bool isIntoSelection_ );
	在目标doc 中新建一个 图层，黏贴进去 clipboard 中的数据。
	----
	paste 是 doc 独占的函数。
	可以在 单个doc内实现，也可在数个doc 间实现。
	----
	若参数 bool == true，且 selection is active
	数据将被粘贴到 selection（暂时没想明白用法...）
	----
	推荐的操作是，先paste，然后移动这个新图层



# ---------------------------------------------- #
#       ArtLayer obj / Layer Set obj
# ---------------------------------------------- #

------ create ArtLayer obj -------
var layer = doc.artLayers.add();
layer.name = "__koko__";
layer.blendMode = BlendMode.NORMAL; // 混合模式


------ create Layer Set obj -------
var layerSet = doc.layerSets.add()


------ move layerSet -------
-- 移动 图层目录，到目标图层的 下方
layerSet.move(layer, ElementPlacement.PLACEAFTER)
-- 移动 图层，到目标目录的 内部的底部
layer.move(layerSet, ElementPlacement.PLACEATEND)


--- 复制一个图层 进入 图层目录 ---
-- 新进入的图层，放在 目录最下方
var layer = doc.artLayers[0].duplicate(layerSet,
               ElementPlacement.PLACEATEND);


--- 将2个图层，link 到一起 ---
-- 似乎能一起移动...
layers[0].link( layers[1] );



----- 找到某个 layerSet 的引用 -----
-- 从 doc找
var layerSet = doc.layerSets.getByName("xxx");
-- 如果目标 目录 被嵌套在某个 目录下时
var layerSet = layerSet.layerSets.layerSets.getByName("xxx");


----- bounds -----
layer.bounds -- 
	[ 左上角off.xy, 右下角off.xy ] 共4个数据。(基于左上角)
	----
	通过这4个数据，不光可以快速计算出 图层的pos
	还可以得知图层的 size：
	图层的size，就是图层最小包围盒的尺寸（ps自动计算的）
	当我们 删除掉图层的一部分后，这个尺寸会发生变化
	--- 这一点超乎我们的预想，但意外的好用。
	当我们对目标图层，删除背景色之后，图层的 bounds 信息
	就是 目标图形裁剪框的尺寸。
	---
	bounds 还支持 Document, LayerSet, selection

----- translate -----
layer.translate( deltaX, deltaY );
	参数为需要移动的 偏移值。
	---
	注意，此函数在 cs6 中完美运行
	在 cc-2015 中存在问题 ..... 原因不明 ...
	---
	translate 还支持 layerSet, selection


# ---------------------------------------------- #
#              selection obj
# ---------------------------------------------- #
-- selection obj 从属于 document obj
	选区是 ps文件 独一的 对象

-- 无法新建 selection obj，只能使用 docObj 中现成的 


--- 生成一个选取（和图层无关）--
var shapeRef = [
    [0,0],
    [0,100],
    [100,100],
    [100,0]
]
doc.selection.select(shapeRef);


-------------------------
doc.selection.deselect(); //--- 取消选区
doc.selection.invert(); //--- 反转选区
doc.selection.expand(5)  //--- 扩大
doc.selection.contract(5)//--- 合并
doc.selection.feather(5) //--- 羽化


----- 对选区填充颜色 ------
doc.selection.fill( someColor, ColorBlendMode.VIVIDLIGHT,
25, false);

doc.selection.fill( someColor );
	// 最简单的填充


---- 将选区存储到通道，从通道读取选区 ----
--...

---- 全选 ----
doc.selection.selectAll();


---- 对选区自由变换／ ctl+T 的那个功能 ----
doc.selection.translate (deltaX, deltaY)


# ---------------------------------------------- #
#              channel obj
# ---------------------------------------------- #
...


# ---------------------------------------------- #
#                color object
# ---------------------------------------------- #
----
color = new RGBColor();
color.red = 20;
color.green = 50;
color.blue = 30;

----
var sColor = new SolidColor();
sColor.rgb.red = 20;
sColor.rgb.green = 90;
sColor.rgb.blue = 50;

---- 获得 拾色器前景色／背景色 ----
var foreColor = foregroundColor;
var backColor = backgroundColor;

---- 对比两种颜色 ----
if( color1.isEqual( color2 ) ){}


# ---------------------------------------------- #
#          Clipboard / 复制黏贴
# ---------------------------------------------- #
影响到 ArtLayer, Selection, and Document objs
剪贴的数据，可以在 单个 document，或者数个 document 间传递

------ 将选区中所有可见图层 一起复制（合并数据）-----
doc.selection.copy(true)



# ---------------------------------------------- #
#                 Action
# ---------------------------------------------- #

---- 调用一个已经在ps中制作好的 action ---
app.doAction("action_1","tom.ATN")
	//- param_1: 动作名 
	//- param_2: 动作所在文件夹名称



# ---------------------------------------------- #
#    Photoshop’s Document Object Model (DOM)
# ---------------------------------------------- #

-- Application: -- ps程序本体
	Documents collection: -- ps文件 集
		Document objects: -- ps文件
			ArtLayers collection,
			HistoryStates collection,
			Layers collection,
			Layersets collection,
			Channels collection


--- The following elements/collections exist in ps --
Art Layers -- 常规图层
TextItem -- 特殊的 Art Layers，
		 -- allows you to add type to an image
		 -- 在ps中，表现为 Art Layers 的 “属性图层”
Channels -- 通道
Color Samplers -- Color Sampler Tool
Count Items -- Count Tool
Documents
Layers
Layer Comps
Layer Sets -- 图层文件夹，存放 Art Layers 或其他 图层文件夹
History States -- 历史记录
Notifiers -- 为脚本绑定一个 event
Path Items -- 保存有关被绘制obj的info，比如形状，曲线
Sub Path Items -- 被 Path Items class 包含，
				-- 提供实际的 几何形状
Path Points -- 保存有关 Sub Path 中每个点的 信息

Text Fonts


--------------- class -------------
Selection -- 选择。

Document Info -- 存储有关 document 的元数据

Preferences -- access and set the user preference settings

Measurement Scale -- provides scripting support for the new Measurement Scale feature that allows you to set a scale for your document







# ---------------------------------------------- #
#        
# ---------------------------------------------- #



# ---------------------------------------------- #
#        
# ---------------------------------------------- #


















