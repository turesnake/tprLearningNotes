# ================================================================//
#                           theme
# ================================================================//
vscode 自制 主题。

# ------- 目录 ------- #
vscode 的 自定义主题存放目录：
    ~/.vscode/extensions/
在 mac ／ linux 下皆有效。


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





