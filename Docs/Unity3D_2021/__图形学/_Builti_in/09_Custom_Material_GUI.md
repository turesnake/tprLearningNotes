# ================================================================ #
#                    Custom Material GUI
# ================================================================ #


# ++++++++++++++++++++++++++++++++++++++++++++++ #
#         自定义 Material GUI 步骤:
# ---------------------------------------------- #

# -1-
    自定义一个 class:
    public class TPRShaderGUI : ShaderGUI {...}

    在里面实现 callback:

        public override void OnGUI (MaterialEditor editor, 
                                    MaterialProperty[] properties
	    ){...}

    从而自定义 material 界面绘制细节;

# -2-
    在目标 shader 中添加:
    
        CustomEditor "TPRShaderGUI"

    指定 自定义class 名字, (有时是路径)




# ++++++++++++++++++++++++++++++++++++++++++++++ #
#         unity 函数 常用变量 简述
# ---------------------------------------------- #


# ================================ #
# class GUIContent;
    包含一个 GUI element 的各种信息;

    常常作为如下函数的参数出现, 很常见;

可容纳:
-- string text;
-- Texture image;
-- string tooltip;
    提示信息, 鼠标悬停后会自动浮现;





# ================================ #
#  MaterialEditor.TexturePropertySingleLine(...)
    在一行内绘制信息, 最多可绘制三个元素

# 声明:
Rect TexturePropertySingleLine( GUIContent label, 
                                MaterialProperty textureProp, 
                                MaterialProperty extraProperty1,    // 可选
                                MaterialProperty extraProperty2);   // 可选





# ================================ #
#  ShaderGUI.FindProperty(...)

    从目标 material 拥有的 properties 中, 找出想要的那个;

# 声明:
static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties);
static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties, bool propertyIsMandatory);

# params:
    -- string propertyName:

    -- MaterialProperty[] properties:
        通常可传入: 从回调函数 ShaderGUI.OnGUI() 中获得的一个 参数,

    -- bool propertyIsMandatory (可选)

# ret:
    -- MaterialProperty
        想要找的 目标property



# ================================ #
#  MaterialEditor.TextureScaleOffsetProperty(...)

    绘制目标 texture 的 tiling 和 ofset 信息;



# ================================ #
# MaterialEditor.ShaderProperty(...)

    暂: 用来绘制一些 property, 比如 单float 值之类的,


# ================================ #
# int EditorGUI.indentLevel;

    可以控制一个 gui 元素的缩进, 如下操作:

    EditorGUI.indentLevel += 2; // 执行缩进
    // 执行绘制 图元
    EditorGUI.indentLevel -= 2; // 恢复到原状态




# ================================ #
# EditorGUILayout.EnumPopup(..);
    显示一个 enum 弹出小窗口 (其实是个选项栏)
    让用户可在 material inspector 上修改此值;
    ---
    此函数返回一个 Enum 类型值, 就是用户选择的新选型, 可将其 cast 为
    我们需要的 枚举类型, 以此来实现, 用户对这个 选择栏 的选择功能;



# ================================ #
#          回撤操作
# void MaterialEditor.RegisterPropertyChangeUndo( string label );
    Call this when you change a material property. It will add an undo for the action.

    然后就能在 editor 界面上, 使用 ctrl+z 来回撤操作;



# ================================ #
# bool EditorGUILayout.Toggle(...)
    制作一个 勾选框, 返回值就是 用户是否勾选了


