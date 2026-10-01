

TextMeshPro 是在 3d mesh 中显示字体的组件,

选中组件 - Font Asset: 此时会索引到这个 font 资源,
打开它, 可以看到体内有个 mat, 右键 mat 复制一份, 取名后缀 "-outline";
虽然这个新 mat 在 font 资源体外, 但可用

然后回到 TextMeshPro, 在 Font Asset 下一行看到 Material Preset, 点开选择绑定新的 mat;

然后往下翻, 找到这个 mat 的配置:
    Face 字体本身
    Outline: 外轮廓线, 条件 thickness 看看效果


































