# ================================================================ #
#           Input Field / Input Field (TextMeshPro)
# ================================================================ #
以下 API 以 TextMeshPro 版为主;
推荐使用 TextMeshPro 版;



# 这东西运行后, 不需要写啥代码, 它自己就能接受 外部输入;




# -------------------------------------- #
# --- 鼠标滚轮 控制 文本区 上下滚动 ---
unity 原始 UI 中的 Input Field 不支持 用边条滑块,鼠标拖动, 鼠标滚轮 滚动显示文本区...

TextMeshPro 版的 Input Field, 自动支持 鼠标滚轮,

# 滚轮滚动速度
可在脚本中通过 TMP_InputField.scrollSensitivity {get;set;} 来控制滚动速度;
此值默认为 1, 改为 3~5 即可;

# 滑块控制
可在 inspector - VerticalScrollbar 绑定一个 scrollbar 组件
这个组件可以放到 TMP_InputField 实例的子级;



# -------------------------------------- #
# --- 支持多行输入 ---
inspector: Line Type 设为 Multi Line NewLine;
    此时还支持用 回车键 换行;


# -------------------------------------- #
# --- 获取输入的文本 ---
直接读写 TMP_InputField.text, 很方便









