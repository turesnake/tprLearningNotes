# ================================================================ #
#                  unity3d  Attributes
# ================================================================ #

unity 自定义的 Attributes 有两套：
- API -UnityEngine - Attributes
- API -UnityEditor - Attributes

还有微软自带的:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/



# ----------------------------------------------#
# [System.Serializable]   见文件 "序列化.md"
# class


# ----------------------------------------------#
# [SerializeField]    见文件 "序列化.md"
# class,field


# ----------------------------------------------#
# [AddComponentMenu("tpr/AA")]   
# public class AA : MonoBehaviour   {   }
在 Inspector - component 面板中，添加一个可选按钮（含目录）。具体目录被配置在 唯一参数中
可以将其作为一个 script component，添加到 obj 上


# ----------------------------------------------#
# [CreateAssetMenu(fileName = "aoa.asset",menuName="tpr/AA")]   
# public class AA : ScriptableObject {}
在 Assert 面板中，添加一个可选按钮（含目录）。具体目录被配置在 参数：menuName 中。

当我们按下这个按钮，会在项目 assert 目录中，创建一个 script-obj assert
这个文件的默认名，被配置在 参数：fileName 中




# ----------------------------------------------#
# [ColorUsage(true,true)]    
# public Color colorA;
为 Color 变量，配置一个 色环取色器。
参数：
    bool showAlpha
    bool hdr

旧版本的参数，如 Brightness, ExposureValue 已被废弃


# ----------------------------------------------#
# [TagField]   
# public string canTriggerTag;

会在 inspector 上变成一个 tag 选择器, 然后本质上还是拿的 string 值



# ----------------------------------------------#
# [Header("角色名字")]
# public float m_name;

变量上方的黑体文字


# ----------------------------------------------#
# [Tooltip("注释")]
# public float m_MinTime;

鼠标放到 inspector 的变量上后, 自动显示的注释



# ----------------------------------------------#
# [ContextMenu("tpr3")]   
# void CustomContext(){}
作用于一个 非静态方法上，且这个方法，在一个 comp script 中( MonoBehaviour )
将此 script，绑定到 go 上后，可以在 component 面板右上角下拉菜单(三个点)中，
发现名为 "tpr3" 的按钮。
点击此按钮，将执行 本函数的功能



# ----------------------------------------------#
# [RequireComponent(typeof(MeshRenderer))] 
# [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
# public class Grid : MonoBehaviour {}
必须协同绑定另一个组件, 若在绑定本组件时发现没有目标组件, 会自动绑定一个


# ----------------------------------------------#
# [HideInInspector] public bool isInTrackNode = false; 
虽然是 public 的, 但不显示在 inspector 上;



# ----------------------------------------------#
# [DisallowMultipleComponent] class ...
在本go 中, 本组件只允许挂载一个;


# ----------------------------------------------#
# ContextMenuItem
# ...


# ----------------------------------------------#
# [NativeHeaderAttribute("AAA.h")]
# [NativeHeader("BBB.h")]
# ...
感觉像是声明了 原生c++代码的 头文件...
可以定义很多个



# ----------------------------------------------#
# [DefaultExecutionOrder(115)]

可以指定这个脚本的 script execution order
其效果和在 -1-: project settings 面板中; -2-: meta文件设置中 是一样的;

唯一缺点是, 使用本 attribute 来设置, 无法被登记到 script execution order 表中去, 有点不透明;


# ----------------------------------------------#
# ExecuteInEditMode

在 editor 模式下 本脚本也能起效;

# ----------------------------------------------#
# ExecuteAlways
https://docs.unity3d.com/ScriptReference/ExecuteAlways.html

Makes instances of a script always execute, both as part of Play Mode and when editing.





# ============================================== #
#                    微软自带
# ============================================== #
当一个 attribute 绑定到代码实体上后, 可在运行时,通过 reflection 访问它:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection

attribute 为你的代码添加 metadata. 

可以自定义 attribute:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes

一个 代码对象可被绑定数个 attributes

针对部分 attributes, 同一个 attribute, 可被多次绑定到同一个 代码对象上.

按照习惯,所有 attribute 的名字都要以 "Attribute" 结尾. 但在调用它时,这个后缀不写也是允许的. 两者时等价的(仅在使用时)







