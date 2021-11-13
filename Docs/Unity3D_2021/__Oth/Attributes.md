# ================================================================//
#                  unity3d  Attributes
# ================================================================//

unity 自定义的 Attributes 有两套：
- API -UnityEngine - Attributes
- API -UnityEditor - Attributes

还有微软自带的:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/



# ----------------------------------------------#
# [System.Serializable]
# class

Indicates that a class can be serialized. This class cannot be inherited.
标明这个 class 的实例 是可以被 序列化的, 序列化后会变成一串某种格式的字节数据, 可以存入硬盘,或传入 stream,


当一个 class 标注自己为 序列化, 它的所有 非函数成员(不管是不是 public) 都会被序列化. 
(注: unity 仅对 public 成员序列化, 见下文 SerializeField )
但这个配置是自动的,如果想要精细化管理一个 class  的序列化细节, 可继承 ISerializable 接口. 

你也可以给此 class 的某个成员,标注 [NonSerializedAttribute], 表面此变量不参与序列化. 
比如那个 变量自己包含了 指针 之类的, 就算序列化了也没有意义的数据, 就可用此 attribute


就算这个 class 已经继承了接口: ISerializable, 也要将它标注 [System.Serializable], 来指示 "自己可以序列化"


# ---
unity 中, 继承自 MonoBehaviour 的 class 将自动被标记序列化, 这些 class 中的 public 成员, 会可序列化.
它的 private 成员, 需要显式标记 [SerializeField] 才能被序列化

unity 中, 不继承于 MonoBehaviour 的 class, 如果想要被序列化, 需要为此 class 标记: [System.Serializable]

unity 中的序列化, 通常用于 "会出现在 Inspector 中的各种变量".  



# ----------------------------------------------#
# [SerializeField]
# class,field

unity 仅对 public 成员序列化, 若希望 private 成员被私有化, 就需要为它标注 [SerializeField]
这意味着当 unity 在 editor 中存储一个场景时, 这个变量会被写入文件. 


将一个 成员标注为 [SerializeField], 且如果它的 class 在 Inspector 中可见,
那么这个 private 成员, 也将在 Inspector 中可见




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
# [ContextMenu("tpr3")]   
# void CustomContext(){}
作用于一个 非静态方法上，且这个方法，在一个 comp script 中( MonoBehaviour )
将此 script，绑定到 go 上后，可以在 component 面板右上角下拉菜单(三个点)中，
发现名为 "tpr3" 的按钮。
点击此按钮，将执行 本函数的功能



# ----------------------------------------------#
# [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
# public class Grid : MonoBehaviour {}
绑定本脚本的 go, 需要携带指定的 组件






# ----------------------------------------------#
# ContextMenuItem
# ...


# ----------------------------------------------#
# [NativeHeaderAttribute("AAA.h")]
# [NativeHeader("BBB.h")]
# ...
感觉像是声明了 原生c++代码的 头文件...
可以定义很多个





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







