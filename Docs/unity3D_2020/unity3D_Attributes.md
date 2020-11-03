# ================================================================//
#                  unity3d  Attributes
# ================================================================//

unity 自定义的 Attributes 有两套：
- API -UnityEngine - Attributes
- API -UnityEditor - Attributes





# ----------------------------------------------#
# [SerializeField]
# class,field



# ----------------------------------------------#
# [AddComponentMenu("tpr/AA")]   
# public class AA : MonoBehaviour   {   }
在 component 面板中，添加一个可选按钮（含目录）。具体目录被配置在 唯一参数中
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
将此 script，绑定到 go 上后，可以在 component 面板右上角下拉菜单中，
发现名为 "tpr3" 的按钮。
点击此按钮，将执行 本函数的功能


# ----------------------------------------------#
# ContextMenuItem
# ...















