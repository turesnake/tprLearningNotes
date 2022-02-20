# ================================================================//
#                           theme
# ================================================================//
vscode 自制 主题。

记录: "workbench.colorCustomizations":{} 中可设置的所有数据:
https://blog.csdn.net/dscn15848078969/article/details/107578108



https://blog.csdn.net/sinat_39620217/article/details/115618730

https://code.visualstudio.com/api/references/theme-color


https://juejin.cn/post/6844903826017763335


# ------- 目录 ------- #
vscode 的 自定义主题存放目录：
    ~/.vscode/extensions/
在 mac ／ linux 下皆有效。

win:
	用户/Administrator/.vscode/extensions/


# ------- 制作 ------- #
-- 在 ~/.vscode/extensions/ 目录下新建目录： theme-tpr-0.0.1
-- 在新目录下，新建：
    package.json
    themes/


# ------- package.json 内容 ------- #
{
	"name": "theme-tpr",
	"displayName": "theme-tpr",
	"description": "--tapir--",
	"version": "0.0.1",
	"publisher": "tpr",
	"engines": {
		"vscode": "*"
    },
    "categories": [
        "Themes"
    ],
	"contributes": {
		"themes": [
			{
				"label": "--tpr--",
				"uiTheme": "vs-dark",
				"path": "./themes/tpr-color-theme.json"
			}
		]
	}
}

# ------- themes 目录中 内容 ------- #
tpr-color-theme.json
(也可以是 tmTheme 格式的)

可以在：
http://tmtheme-editor.herokuapp.com/#!/editor/theme/Monokai
网站中制作，

也可以套用原有的文件。


# =========================== #
将整套文件 制作完毕后，重启 vscode ，即可调用 自制的 主题。




# ================================================================//
#            方法二
# ================================================================//

可以直接改写 theme 的原始 json 文件, 然后重启 vscode 即可使用;

不过这个方法十分繁琐, 毕竟每次调整都要重启才行;

但是实际上 一个完整的 theme 的配置非常复杂...




# ================================================================//
#        -3- 当前的选择
# ================================================================//
暂时选择 theme:
	Community Material Theme High Contrast

然后点击 vscode 左下角齿轮, 选择 "设置", 再点击右上角的一个图标 "打开设置",
(图标: 一张纸, 有个回车箭头)
分别编写:
	"workbench.colorCustomizations":{},
	"editor.tokenColorCustomizations":{}

两个框, 设置一些 元素前景色背景色 和 编辑区的 不同文字的颜色;




# -------------------------------------- #
# "textMateRules": "scope" 中可以设置的值:
# -------------------------------------- #


	"entity.other.attribute-name",// 注释中参数name
	"entity.name.tag" // 注释中, 一个段落的名字

	"entity.name.type.class", //class names

	"entity.name.function" // 函数名

	


-- 标点符号:
	"punctuation.definition.string.begin"// 字符串左侧双引号
	"punctuation.separator" // 分割符号, 比如 : , =
	"punctuation.terminator" // 结尾符号 ;


	"storage.modifier" //修饰符: public internal private static const override readonly sealed









