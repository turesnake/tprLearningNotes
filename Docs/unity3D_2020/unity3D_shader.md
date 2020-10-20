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
#           新旧变量/函数 升级名单
# ---------------------------------------------- #

# mul(UNITY_MATRIX_MVP,*) -> UnityObjectToClipPos(*)

# _Object2World -> unity_ObjectToWorld

# 

# ---------------------------------------------- #
#      URP 自带的 shaders 文件在哪里 ？
# ---------------------------------------------- #
查找目录：
    [项目] - Library - PackageCache - 
    com.unity.render-pipelines.universal@8.2.0 -
    Shaders:


# ---------------------------------------------- #
#           #pragma target 2.0
#    指定使用哪个版本的 HLSL shader model
# ---------------------------------------------- #
支持的版本有点低。。。目前大部分 unity 自带 shader 维持在 2.0
少数 达到 4.5

若不显示声明，默认为 2.5

想要实现 compute shader, 必须达到 4.5



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
# : Tags
    和 SubShaders 中的 Tags 类似
#   "LightMode" = "ForwardBase"
        可选项：
        Always
        ForwardBase
        ForwardAdd
        Deferred
        ShadowCaster
        MotionVectors
        PrepassBase
        PrepassFinal
        Vertex
        VertexLMRGBM
        VertexLM
#   "PassFlags" = "..."
        可选项：
        OnlyDirectional
#   "RequireOptions" = "..."
        可选项：
        SoftVegetation

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
#               SV_POSITION
# ---------------------------------------------- #

# vs 端的输出值
vs 函数的核心输出就是一个被标记为 SV_POSITION 的 pos 值：
它表示： 顶点的 齐次裁剪空间 坐标。
---
在透视模式下，此坐标的取值范围：
近平面：
    ( -Near, -Near, -Near, Near ) // 左下
    (  Near,  Near, -Near, Near ) // 右上
远平面：
    ( -Far, -Far, Far, Far ) // 左下
    (  Far,  Far, Far, Far ) // 右上

分析：w值 固定等于 -oldZ; 通常，w一定是个 正数，可以看作是 [Near,Far] 区间内
    然后，每个顶点pos 的 xyz 分量，基于自身的 w分量 而定：
    -w <= {x/y/z} <= w
---
这个输出值，尚未做 齐次除法（所以它的 w分量并未被 清为 1）


# fs 端的输入值
标记为 SV_POSITION 的 pos，对于 fs 来说，是没什么意义的。
请不要在 fs 中读取使用它（尽管我们可以读取）



# ---------------------------------------------- #
#               vs 常见输入值
# ---------------------------------------------- #
这些数据是 从 Mesh Render组件 中读取而来的。
在每一桢调用 draw call 时，Mesh Render组件 将它负责渲染的模型数据，
发送给 shader。

# POSITION
    float4
    顶点在 模型空间 中的坐标

# NORMAL
    float3 -- (单位向量)
    分量取值范围 [-1.0, 1.0]

# TANGENT
    float4 -- ( xyz 构成单位向量，w有时为 -1, 有时为 1 )!!!!
    分量取值范围 [-1.0, 1.0]
    目前为止，w值 是检测出来的，可能存在其它情况

# (binormal)
    float3 -- (单位向量)
    通过 NORMAL, TANGENT, 可以计算出 binormal：
        float3 binormal = cross( v.normal, v.tangent.xyz ) * v.tangent.w;
    我们看到它使用了 tangent 的 w 分量，来将最终的值 做翻转（或不翻）
    从之前的检测可知，w分量 有时为1，有时为-1

# TEXCOORD0 (1,2,3...)
    float4 

    xy分量，代表 uv坐标 [0.0, 1.0]
    z = 0
    w = 1;
    (以上仅为 测量值)


# COLOR COLOR0
    float4 



# ---------------------------------------------- #
#             _MainTex_ST
# ---------------------------------------------- #
格式： "纹理名_ST"
ST 的含义是 scale(缩放), translation(平移)

_MainTex_ST.xy: 缩放值，对应 material 界面中的 Tiling 

_MainTex_ST.zw: 平移值 ，对应 material 界面中的 offset




# ---------------------------------------------- #
#               切线空间  （ TBN空间 ）
# ---------------------------------------------- #
曲面（模型）上的一个点，以自身为原点，建立一个 切线坐标系：

#    Z轴 Normal:    是 曲面法线方向
#    X轴 Tangent:   是 此点在 UV坐标系中的 U轴方向
#    Y轴 Binormal: = cross( z,x ); (注意参数顺序) 此点在 UV坐标系中的 V轴方向
    ----
    xyz 三轴 关系符合 右手定则

为了便于记忆，我们称这个空间为 TBN空间 （对应 xyz 轴）


当某个点的 法线向量没有 扰动时，它记录在 法线贴图中的数据应该是 (0.5, 0.5, 1.0, 1.0)
解释起来就是：xy轴值都为0，z值为1，整个 法线向量，是个 单位向量。







# ---------------------------------------------- #
#             
# ---------------------------------------------- #


# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #


# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #

# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #




