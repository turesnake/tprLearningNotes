# ================================================================ #
#            unity3d shader 使用技巧
# ================================================================ #


# ---------------------------------------------- #
#             杂乱的信息
# ---------------------------------------------- #

# --- 官方文档位置 --- #
查找:
    Graphics - Meshes,Materials,Shaders and Textures -
    Writing Shaders - Shader Reference
    ---
或者直接查找：
    "Shader Reference"
-----
实际的语法在: 
    Shader Reference - ShaderLab Syntax 中


# -------- #
# 旧shader 和 URP 的兼容性
    文档中的有些写法，在 URP 中是不兼容的
    可以先在 传统项目中，完成 shader 的学习...
 


# -------- #
无法在运行时， 额外生成新的 shader 文件，
    然后还指望它能被编译运行。
    这个过程必须提前在 app 编译阶段完成


# -------- #
# : FallBack "VertexLit"
    （此语句 放在 SubShader{} 语句块 的后面）
    表示：
    万一上面的几个 SubShader 都不能用，
    使用 "VertexLit" 指向的 shader 程序来替代


# -------- #
# : CustomEditor "name"
    自由定义 material inspector 的显示结果


# -------- #
Usepass “Specular/FORWARD”
    复用一个 别处定义的 pass 代码块
    ---
    可以通过 Name “MyPassName” 来为一个 pass 起名字



# ---------------------------------------------- #
#      URP 自带的 shaders 文件在哪里 ？
# ---------------------------------------------- #
查找目录：
    [项目] - Library - PackageCache - 
    com.unity.render-pipelines.universal@8.2.0 -
    Shaders:


# ---------------------------------------------- #
#         Library - ShaderCache
#               清理缓存
# ---------------------------------------------- #
在项目编辑期间，ShaderCache 目录中会缓存 编译好的 shader 中间件
随着项目的扩大，这个目录的尺寸也会碰撞。
可以放心地删除它。


# ---------------------------------------------- #
#            Properties 
# ---------------------------------------------- #
其实是 Material properties 
它们 不会显示在 当前 shader 文件的 Inspector 面板
而是在与其绑定的 Mat 的 Inspector 面板 上。


_MainTex:
    以此命名的 属性变量，默认为 mat 的 main texture

_Color:
    以此命名的 属性变量，默认为 mat 的 main color

# --
texture propertie，一般拥有一些捆绑的信息：
    它们将被存储为 一些额外的 properties：

    [TexName]_ST，类型为 float4，
        表示 texture 的 tiling, offset 信息
        ---
    [TexName]_TexelSize，类型为 float4：
        表示 texture 尺寸信息。
        ---
    [TexName]_HDR, 类型为 float4：
        ...



# ============================================== #
#                SubShaders
# ---------------------------------------------- #
格式：
    Subshader { [Tags] [CommonState] Passdef [Passdef ...] }

可以在一个 shader 文件中实现数个 SubShaders
实际运行时，程序会自动使用，当前硬件支持的，排在第一位的那一个。

每个 SubShader 都是一组 passes 的集合（至少包含一个）
实际渲染时，这些 passes 都会被调用一遍。
pass 数量越多，开销越大。



# === 零碎知识点 === #
# ------ #
# : LOD
    "level of detail"
    查找: ShaderLab: SubShader LOD value
    ---
    为本 SubShader 设置一个 LOD 值，
    实际运行时，当发现机器性能无法满足这个 LOD 值的要求，
    将放弃此 SubShader， 改用下方的 其它 SubShaders
    ---
    值越高，意味着本 SubShader 越耗费算力。
    通常定义 100 即可


# ------ #
# : Tags
    Tags { "TagName1" = "Value1" "TagName2" = "Value2" }
    定义一组键值对，有一些是 unity 自定义的，这些不能被定义在 pass 语句块中。
    ( pass语句块中，也有它自己的 Tags )
    :
#   "Queue" = "Transparent"
        可选项：
        Background         - 1000
        Geometry (default) - 2000
        AlphaTest          - 2450
        Transparent        - 3000
        Overlay            - 4000
        不光可以选择这几项，还可以写为：Geometry+1, 来获得 2001.
        实现更精细化的 queue 次序管理
#   "RenderType" = "Opaque"

#   "DisableBatching"
        可选项：True, False(default), LODFading
#   "ForceNoShadowCasting"
        可选项：
        True  - obj 不会生成投影
        False
#   "IgnoreProjector"
        可选项：
        True  - obj 不会受到 Projectors 的影响（Projector 在 URP 中无法使用）
        False
#   "CanUseSpriteAtlas"
        2D sprite 才会用到

#   "PreviewType"
        可选项： Sphere(default), "Plane", "Skybox"
        表示 material inspector 中预览的 模型类型

    


# ============================================== #
#                  pass
# ---------------------------------------------- #
一共三种 pass：
    Pass(default) - 渲染目标 obj 一次
    UsePass       - 借用另一个 pass （ pass name 写为 全大写字母 ）
    GrabPass      - 将 obj 渲染到一个 texture 上，为后续 pass 做准备

主要格式：
    Pass { [Name and Tags] [RenderSetup] }



# === 零碎知识点 === #

# ------ #
# : Name “thisPassName”
    可以让其它 shader，借用此 pass：
        UsePass "XXX/MyShader/THISPASSNAME"
    注意，尽管我们定义的 name 可以是任意 大小写字母
    但在 UsePass 调用时，pass name 必须全大写


# ------ #
# : Render states
    一些 配置设置
#   Cull Back
        可选: 
            Back(default) - 只渲染正面
            Front         - 只渲染背面
            Off           - 两面都渲染
        Set polygon culling mode
#   ZTest LEqual
        可选: Less | Greater | LEqual(default) | GEqual | Equal | NotEqual | Always
        Set depth buffer testing mode.
#   ZWrite On
        可选: 
            On(default) - 写入 depth buffer
            Off         - 不写入（如，渲染半透明物体）
        Set depth buffer writing mode.
#   Offset Factor, Units
        需要两个参数，
        Set Z buffer depth offset
        这样，原本两个处于同一深度的 obj，因为 Offset 设置得不同，最后也会出现前后关系
        可以让一些 obj 始终处于前方


#   Blend
        ...
#   ColorMask RGB
        可选: 
        RGBA(default) - 写入全部四个通道
        A             - 只写入 alpha 通道
        0             - 所有通道都不写入
        any combination of R, G, B, A -
        ---
        Set color channel writing mask


# ------ #
# : CGPROGRAM ... ENDCG
    pass 中的主体内容，全部编写在这两个 关键词锁定的区间内。

# ------ #
# : #pragma vertex vert
# : #pragma fragment frag
    表示，本 pass 包含一个名为 vert 的 vertex-program
    和一个名为 frag 的 fragment-program
    （有点类似 GLSL 中的 .vs, .fs 文件）

# ------ #
# : #include "UnityCG.cginc"
    导入了一些 常规函数和变量名，可以简化程序编写

# ------ #
# : struct v2f
    "vertex to fragment" 
    一些需要在 vs，fs 之间传输的数据，
    通常，v2f 是 vert 函数的 返回值，frag 函数的 参数
    

# ---------------------------------------------- #
#         CGPROGRAM / HLSLPROGRAM   
# ---------------------------------------------- #
2019年起，unity 全面换用 HLSL，原本的 Cg 语言只剩下一点 关键词和扩展

使用 CGPROGRAM 还是 HLSLPROGRAM，区别在于 unity 将自动 include 的文件不同。



# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


