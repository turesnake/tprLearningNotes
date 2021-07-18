## =========================================================== #
#     ShaderLab
## =========================================================== #
这是一种 shader 编程语言. 它的主要内容有:


## =========================================================== #
#     ShaderLab: defining a Shader object
## =========================================================== #

Shader "<name>"
{
    <optional: Material properties>
    <One or more SubShader definitions>
    <optional: custom editor>
    <optional: fallback>
}

示范:
# --
Shader "Examples/ShaderSyntax"
{
    CustomEditor = "ExampleCustomEditor"

    Properties
    {
        // Material property declarations go here
    }
    SubShader
    {
        // The code that defines the rest of the SubShader goes here

        Pass
        {
           // The code that defines the Pass goes here
        }
    }

    Fallback "ExampleFallbackShader"
}


## =========================================================== #
#     ShaderLab: defining material properties
## =========================================================== #
讲讲 Properties 部分的规则.
它定义了 在 material 中设置的 properties.

# Overview
material property 被 unity 当作 material asset 的一部分来存储.
这允许艺术家 新疆,编辑,分享 不同配置的 materials.

如果你使用 material property:
--
   通过调用 Material.SetFloat  之类的函数, 可以 get/set shader object 中的一个变量的值.
--
    在 material inspector 中查看/编辑值
--
    unity 会保存你的那些改动, 当作数据的一部分 存入 material asset 中, 
    所以它们能在各 sessions (阶段) 中 持续存在.


若不使用 material property, 通过调用 Material 类的函数, 你仍可以 get/set shader object 中的一个变量的值. 不过这些改变 不会在 sessions 间持续存在.

你可以不定义 material property.
-1- 如果你想彻底用 c# 脚本来 set shader property values,  
    (例如:你正在制作 procedural content 程序化内容) 
-2- 如果那个  properties 无法给设置进 material property
-3- 如果你不希望它们在 inspector 中被编辑


# Render pipeline compatibility
-- built-in rp:
    支持
-- urp:
-- hdrp:
-- custom srp:
    都支持.
    在上述三个新管线中,在 hlsl代码中, 必须将 每个material变量放入 CBUFFER, 为了 SRP Batcher 兼容性.

# Using the Properties block
Properties
{
    <Material property declaration>
    <Material property declaration>
}

# Material property declarations
 
[optional: attribute] name("display text in Inspector", type name) = default value

# - Material property declaration syntax by type

-- Integer
    在后台真的是一个 整型数据 
    _ExampleName ("Integer display name", Integer) = 1

-- Int (legacy)
    在后台其实是个 flaot, 已过时不推荐使用
    _ExampleName ("Int display name", Int) = 1

-- Float
    可用它设置 滑块的 最大值最小值:
    _ExampleName ("Float display name", Float) = 0.5
    _ExampleName ("Float with range", Range(0.0, 1.0)) = 0.5

-- Texture2D
    默认值:
        “white” (RGBA: 1,1,1,1)
        “black” (RGBA: 0,0,0,1)
        “gray”  (RGBA: 0.5,0.5,0.5,1)
        “bump”  (RGBA: 0.5,0.5,1,0.5)
        “red”   (RGBA: 1,0,0,1)
    如果在默认值的 string 为空,或者写入的值是无效的, 将被自动设置为 “gray”.
    注意: 这些默认 texure 值 在 inspector 中不可见
    _ExampleName ("Texture2D display name", 2D) = "" {}
    _ExampleName ("Texture2D display name", 2D) = "red" {}

-- Texture2DArray
    一组 texture 组成的 array
    _ExampleName ("Texture2DArray display name", 2DArray) = "" {}

-- Texture3D
    默认值是 “gray” (RGBA: 0.5,0.5,0.5,1) texture.
    _ExampleName ("Texture3D", 3D) = "" {}

-- Cubemap
    默认值是 “gray” (RGBA: 0.5,0.5,0.5,1) texture.
    _ExampleName ("Cubemap", Cube) = "" {}

-- Color
    一个 float4 值. inspector 中会显示一个 取色器.
    _ExampleName("Example color", Color) = (.25, .5, .5, 1)

-- Vector
    一个 float4 值.
    _ExampleName ("Example vector", Vector) = (.25, .5, .5, 1)


# - Material property attributes
Material property 声明, 可以拥有一个 可选的 attribute, 以告诉 unity 如何处理它们.

除了下面列举的 attributes 以外, 还可以使用相同的语法将一个 MaterialPropertyDrawer 添加进 Material property 中. 这能让你控制 material properties 在 inspector 中如何显示.

-- [Gamma]
    指示 float 或 vector property 使用 sRGB 值, 
    这意味着, 如果你项目的 颜色空间中 需要此值, 则必须将它和其它 sRGB 值 做转换.

-- [HDR]
    指示 texture 或 color property 使用 HDR 值.
    针对 texture, 如果为其分配一个 LDR, unity editor 将提出警告.
    针对 color, unity editor 使用 HDR颜色选择器 来编辑此值

-- [HideInInspector]
    让 editor 在 inspector 中隐藏此  property.

-- [MainTexture]
    material 的 主 texture. 
    可使用 Material.mainTexture 访问它.

    默认, 若名为 "_MainTex", 它将被当作 Main Texture.
    万一你给 texture 取得名字不是 "_MainTex", 但你希望它能成为 主 texture,
    那就要使用 MainTexture attribute

    如果多次使用此 attribute, 第一个是有效的, 后面的都将被忽略 attribute 附加的影响.

    注意: 当使用 texture streaming debugging view mode, 或 a custom debug tool. 被设为 MainTexture 的 texture 不会在 Game 窗口内可见.


-- [MainColor]
    设置 main color, 可用 Material.color 访问之.

    默认. 名为  _Color 的就是 主color. 

    若设置多个,第一个有效,后面的 attribute 附加的影响被忽略

-- [NoScaleOffset]
    用于 texture
    让 unity 隐藏这个 texture 在 inspector 中的  
    tiling and offset 调整选项.

-- [Normal]
    指示 此处绑定的 texture 应该是一张 法线贴图.
    若绑定错误, unity editor 将显示错误

-- [PerRendererData]
    指示 此处的 texture 会从  per-renderer data 中获得, 
    它的形式为 MaterialPropertyBlock.


# Using material properties with C# code
在脚本中, Material properties 被表示为  MaterialProperty 类.

使用  Material.GetFloat, Material.SetFloat 访问变量.
类似的函数还有,都在 Material 类中.
当使用 这些函数访问变量时, 不管是否为 material property, 都能访问到.

如何在 editor 中定制 properties 的视觉效果.
略...

# Using material properties to set variables in ShaderLab code
用  material property 的值, 赋值给 shaderLab 内 变量的值.

通过方括号 [] 来获得值: 

# --
Shader "Examples/MaterialPropertyShaderLab"
{
    Properties
    {
        _OffsetUnitScale ("Offset unit scale", Integer) = 1
    }
    SubShader
    {
        Pass
        {
            // Offset 是个指令,依赖两个参数, 
            // 第二个参数 从 material property 中获得
            Offset 0, [_OffsetUnitScale]

           ...
        }
    }
}


# Using material properties to set variables in HLSL code
想要在 hlsl 代码中使用这些 material properties

可以声明 同名字的变量.如:
# --

Shader "Examples/MaterialPropertyShaderLab"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Pass
        {
            float4 vert (float4 vertex : POSITION) : SV_POSITION
            { ... }

            // 要重新声明一边, 名字相同
            fixed4 _Color;

            fixed4 frag () : SV_Target
            { ... }
        }
    }
}


## =========================================================== #
#     ShaderLab: assigning a fallback
## =========================================================== #

# Render pipeline compatibility
所有渲染管线 都支持

# Using the Fallback block
-1-
    Fallback "ExampleOtherShader"
-2-
    Fallback Off
    不适用 fallback 功能, 若没找到能用的 subshader, 此material 将被标记为 error material.

## =========================================================== #
#     ShaderLab: assigning a custom editor
## =========================================================== #
用来 改造 material inspector 的显示效果的.

略....


## =========================================================== #
#     ShaderLab: defining a SubShader
## =========================================================== #

# Overview
略

# Render pipeline compatibility
全管线支持

# Using the SubShader block
在 SubShader 内部,可以:
--
    分配一个 LOD 值(level of detail) 
--
    分配 tags, 一种键值对
--
    添加 gpu指令 和 shader代码. 使用 ShaderLab commands
--
    定义 一或多个 passes,在 Pass 代码块中

# --
SubShader
{
    <optional: LOD>
    <optional: tags>
    <optional: commands>
    <One or more Pass definitions>
}

## =========================================================== #
#     ShaderLab: assigning tags to a SubShader
## =========================================================== #

# Overview
tags 是键值对, unity 使用预定义的 键和值 来检测: 如何 以及何时 使用给定的 SubShader, 你也可以自定义 SubShader tags.

可以从 c# 代码中 访问这些 tags

# Render pipeline compatibility
各个 预定义 tags:
-- [RenderPipeline]
    built-in: 不支持

-- [Queue]
    built-in: 不支持
    Custom SRP:
        你可以定义自己的 rendering order, 选择是否使用 render queue.
        查看 DrawingSettings 和 SortingCriteria.

-- [RenderType]
    全支持

-- [DisableBatching]
    全支持

-- [ForceNoShadowCasting]
    全支持:
    hdrp:
        这个只能关闭 常规阴影, 但无法关闭 contact shadows

-- [CanUseSpriteAtlas]
    全支持

-- [PreviewType]
    全支持

# Using the Tags block in a SubShader
注意, Subshader 和 Pass 都使用 tags, 但它们的工作是不相同的.
两者的混用是无效的.

# Using SubShader tags with C# code
使用  Material.GetTag() API, 可从 c# 脚本中查看 SubShader tags

示范代码 略...


# ------------------ #
# tag: RenderPipeline
它告诉 unity, 这个 SubShader 是否兼容 urp 或 hdrp.

-- Tags { "RenderPipeline" = "UniversalRenderPipeline" }
    只兼容 urp

-- Tags { "RenderPipeline" = "HighDefinitionRenderPipeline" }
    只兼容 hdrp

-- Tags { "RenderPipeline" = "XXX" }
    值为随便某个字符串(反正不是上面两个)
    urp 和 hdrp 都不兼容


# ------------------ #
# tag: Queue
此 tag 告诉 unity 要将哪个 render queue 用于本 subshader 所渲染的 几何体.
render queue 是决定Unity渲染几何体的顺序的因素之一。

# - Syntax and valid values
有两种用法:
-1- 使用一个 命名的 render queue
    “Queue” = “[queue name]”

-2- 一个 未命名的 render queue, 它没有名字, 
    但我们规定了它在整个渲染大流程中的位置. 通过:
    name + offset
    一个例子是 透明水体的渲染, 它的渲染在水体实心物体之后, 同时在其它 透明物 之前 (???)
    “Queue” = “[queue name] + [offset]”

# -- 已定义的 queue name:
-- Background
-- Geometry
-- AlphaTest
-- Transparent
-- Overlay

# -- offset
是一个整型. 

# - Using this tag with C# code
在 c#脚本中,可用  Shader.renderQueue 阅读 queue tag 的值.

默认, unity 按照 Subshader 中, queue tag 上记录的值 来确定 rendr queue.
但你可以在 material 层复写这个配置. 
-- 
    在 material inspector 中, 修改 Render Queue 选项.
    (甚至还可以修改后方的 具体数字,从而实现 name+offset 这个功能)
-- 
    在 c#脚本中, 使用  Material.renderQueue 来修改配置.

演示:
# --
Tags { "Queue" = "Transparent" }
Tags { "Queue" = "Geometry+1" }


# ------------------ #
# tag: RenderType

在 built-in 管线中,可在运行时更换 subshader. 这个技术依靠识别不同 subshader 的 RenderType 来实现.  
类似 "相机的 depth texture" 就是依靠这个技术来实现.

在 srp 中, 可使用一个 RenderStateBlock struct 来复写 shader object 的 render state. 可以使用 RenderType 来识别要复写的 subshader

可查看: ScriptableRenderContext.DrawRenderers


# ------------------ #
# tag: ForceNoShadowCasting
阻止本 subshader 关联的 几何体 投射阴影. (有时也阻止它接收阴影)
具体表现取决于 渲染管线 和 rendering path (前向渲染,延迟渲染 啥的)

当你正在使用 shader replacement, 但你又不希望 从另一个 subshader 那继承 shader pass 时, 使用此 tag 会很实用.

# 当 "ForceNoShadowCasting" = "True"
阻止接收阴影.

在 built-in 管线中, 在 Forward, Legacy Vertix Lit 和 Legacy Deferred rendering paths 中, unity 还阻止 几何体 接收 阴影.

在 HDRP 中, 这个 tag 无法阻止 几何体投射 contact shadows (接触阴影)

默认值为 "False"


# ------------------ #
# tag: DisableBatching
阻止几何体 使用 Dynamic Batching.

当 shader程序 执行 obj-space 上的操作时, 这个 tag 很有用. 
Dynamic Batching 会将所有 几何体 都转换进 world-space, 这意味着 shader程序 将无法访问 obj-space.  那些依赖 obj-space 的shader 将不能被正确的渲染. 

# - "DisableBatching" = "True"
    阻止

# - "DisableBatching" = "False"
    默认值

# - "DisableBatching" = "LODFading"
    和 LODGroup 相关. 
    推荐阅读: https://docs.unity.cn/Manual/class-LODGroup.html


# ------------------ #
# tag: IgnoreProjector
在 built-in 管线中.
控制 几何体 是否受到 Projectors 的影响. 
https://docs.unity.cn/2021.1/Documentation/Manual/class-Projector.html

这个 tag 很适合用来剔除 半透明物体, 因为 它们和 Projectors 并不兼容.

在 srp 管线中, 此 tag 无效.


# ------------------ #
# tag: PreviewType
指示 material inspector 中的 展示小窗口中, 用什么 几何体来展示 材质.

可选项:
-- Sphere
-- Plane
-- Skybox

# ------------------ #
# tag: CanUseSpriteAtlas
在使用  Legacy Sprite Packer 的项目中, 使用此 tag 来警告用户: 你的 shader 依赖于 原始 texture 坐标. 因此不应将其 texture 打包到 atlases 中。

感觉很冷门...


## =========================================================== #
#     ShaderLab: assigning a LOD value to a SubShader
## =========================================================== #






























