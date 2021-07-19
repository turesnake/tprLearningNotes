# ================================================================ #
#            unity3d shader 使用技巧
# ================================================================ #
大部分内容 适用于 built-in shader。


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

# _Object2World -> unity_ObjectToWorld  [uniform mat4]

# _LightMatrix0 -> unity_WorldToLight  [float4x4]



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
        可选项：
        Opaque
        TransparentCutout
        Transparent
        ...

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

        built-in管线 可选项：
            Always [Default] 
                - 总是执行此渲染，不考虑任何光照
            ForwardBase 
                - 用于 Forward 渲染，使用：遮蔽，主直射光，逐顶点光/球谐光，lightmaps
            ForwardAdd
                - 用于 Forward 渲染，使用：额外的逐像素光，每个灯一个 pass
            Deferred
                - 用于 Deferred 渲染，渲染 G-buffer
            ShadowCaster  
                - 将物体深度值写入 shadowmap，或 depth texture
            MotionVectors
                - 计算每个物体的 Motion Vectors
            PrepassBase
                - 用于 legacy Deferred 光照，渲染 法线 和 镜反指数
            PrepassFinal
                - 用于 legacy Deferred 光照，结合 textures，光照信息，荧光信息，计算最终的颜色值
            Vertex
                - 当物体没使用 lightmap 时，用于 legacy 顶点光照渲染。应用所有顶点灯光
            VertexLMRGBM
                - 当物体使用 lightmap 时，且平台的 lightmap 是 RGBM 格式时（PC/主机），用于 legacy 顶点光照渲染。
            VertexLM
                - 当物体使用 lightmap 时，且平台的 lightmap 是 double-LDR 格式时（移动端），用于 legacy 顶点光照渲染。
            Meta  
                - 此pass 不用于 传统渲染，仅用于 光照烘焙 或 实时GI。
        ----
        也可自定义一个 LightMode tag

        ---- 文档介绍 ----
        LightMode 是一个 预定义 Pass tag。在一帧中，unity 用它来决定：
        -1- “是否执行此 Pass”
        -2- “何时执行”
        -3- “unity 该如何处理其 output” 

        每条渲染管线都适用此 tag，不过各个名称的 LightMode tag 在不同管线中效果是有区别的。

        在 built-in 管线中，如果你不设置一个 LightMode tag，unity在执行此 pass 时将不考虑任何 光照 和 阴影。
        这个行为和使用 “Always” LightMode 是一样的。

        在 srp 中，可使用 “SRPDefaultUnlit” 值来引用没有 LightMode 标记过的 pass。 



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
        缓解 shadowmap 中的 自遮挡 问题.


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
#             切线空间  （ TBN空间 ） [右手坐标系]
#                tangent Space
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
#     通过 (手工制作的) 灰度图，生成 法线贴图
# ---------------------------------------------- #
-- 随便做一张 正方形的灰色的图，放入unity
-- 在 Inspector 中，
    TextureType: Normal map
    Create from GrayScale: Yes
    - apple
----------
如何将这张图导出？
    暂时没学会...



# ---------------------------------------------- #
#        #pragma shader_feature _XXX     
# ---------------------------------------------- #
Material Keywords:
检查 参数变量 _XXX，是否被定义在 material's active keywords list 中
根据检测结果，编译出不同的 shader 版本，携带/不携带 关键字：_XXX
以便在后续代码中 通过:
    #if defined(_XXX)
    #endif
来实现分支语句
------
注意，被检测的这个参数变量 _XXX 并不是在本语句中被 定义的，而是在之前的流程中，
比如外部的 inspector 面板中 




# ---------------------------------------------- #
#       纹理 和 采样
#       sample2D _Tex;
#       tex2D( _Tex, uv );
#       ----------------
#       Texture2D     _Tex; 
#       SamplerState  sampler_Tex;    
# ---------------------------------------------- #
# sample2D _XXX;
# float4 color = tex2D( _XXX, uv );
在简单模式下，可以使用这套语句来实现 纹理采样。
此时，textures 和 samplers 是成对出现的

# ------- hlsl --------
# Texture2D     _Tex; 
# SamplerState  sampler_Tex; 
# float4 color = _Tex.Sample( sampler_Tex, uv );
但在很多显卡API中，支持的 texture 数量，和 sampler 数量是不同的
- sampler 数量往往更少
此时，为了写出更灵活的 shader，就会把 两者 分开来写。

- manual 搜索： Using sampler states

- 注意，SamplerState 语句中声明的变量名，有格式要求

- 这种语法，不支持部分 陈旧平台
  使用 #pragma target 3.5 来屏蔽旧版本

# -----
通过这种语法，我们可以用一个 sampler，访问数个 texture:
    Texture2D   _TexA; 
    Texture2D   _TexB; 
    Texture2D   _TexC;
    SamplerState  sampler_TexA;

    float4 colorA = _TexA.Sample( sampler_TexA, uv );
    float4 colorB = _TexB.Sample( sampler_TexA, uv );
    float4 colorC = _TexC.Sample( sampler_TexA, uv );

# ------- urp 2D --------
# TEXTURE2D ( _Tex ); 
# SAMPLER ( sampler_Tex );
# float4 color = SAMPLE_TEXTURE2D( _Tex, sampler_Tex, uv );
在 catlike 教程中，使用了这组宏。
它们被定义在:
    D3D11.hlsl 
    GLCore.hlsl
    GLES2.hlsl
    GLES3.hlsl
    Metal.hlsl
    Switch.hlsl
    Vulkan.hlsl
文件内，
实质上和 上一种 hlsl 用法，是一样的...


# ------- urp 3D --------
# TEXTURE3D ( _Tex ); 
# SAMPLER ( sampler_Tex );
# float4 color = SAMPLE_TEXTURE3D( _Tex, sampler_Tex, uvw );
和 2D 差不多



# ------- urp shadow texture --------
# TEXTURE2D_SHADOW( _Tex );
# SAMPLER_CMP( sampler_Tex );

在大部分平台，TEXTURE2D_SHADOW 和通用的 TEXTURE2D 没什么区别（少数平台有区别）

而 SAMPLER_CMP 则和 SAMPLER 确实不一样，
因为 SAMPLER 并不会针对 depth 数据做 滤波。而 shadow map 存储的正是 depth 数据




# ------- SamplerState 变量的 命名规则 -----
texture filtering mode:
    “Point”, “Linear”，“Trilinear”
texture wrap mode:
    “Clamp”, “Repeat”, “Mirror”, “MirrorOnce”
depth comparison:
    “Compare”

通过上述 构词选项，可以组合出:
    sampler_point_repeat
这样的名字。

- 具体细节参考 manual: Using sampler states




# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#   为什么 传入 frag() 的 方向向量，要做 normaliz     
# ---------------------------------------------- #
即便这些 方向向量，在 vert 中已经是 normalized， 
当它们经过 中间的 插值运算，被分配到每个 像素后，它们已经不是 normal-vector 了







# ---------------------------------------------- #
#             
# ---------------------------------------------- #


# ---------------------------------------------- #
#             
# ---------------------------------------------- #



# ---------------------------------------------- #
#             
# ---------------------------------------------- #





