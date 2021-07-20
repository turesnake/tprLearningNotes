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
LOD - level of detial

# Overview
这是为 subshader 分配的 lod 值. 此值指示了 本 SubShader 的 计算要求有多高.

在运行时,可以为单个 shader object 设置 LOD 值, 也可为所有 shader objects 设置 LOD值. 
LOD值 较低的 SubShader 会被优先执行.

注意: shader LOD 和 mesh LOD 是存在不同的:
-- shader LOD 和相机的距离无关. 
-- unity不会自动计算 shader LOD. 必须手动设置 shader LOD 的最大值.

# Overview  (是的有两个...)
使用 LOD 技术来对 不同硬件的 shader性能做微调. 
当用户的硬件理论上能支持 此 SubShader,但又不能很好地运行它时, 此技术会很管用.

# Render pipeline compatibility
全支持

# Using the LOD block
# --
LOD 100

注意: 在 shader 代码块中, 必须按照 各个 SubShader LOD 递减地顺序,放置 SubShaders.
(LOD 值大的放前面)
这是因为 unity 总是会选中第一个 符合要求的 SubShader, 如果 LOD 值小的放前面, 那么大值的将永远不会被选中.

# Using the SubShader LOD value with C# code
使用  Shader.maximumLOD, 设置某个 shader object 的 LOD最大值
使用  Shader.globalMaximumLOD, 设置所有 shader objects 的 LOD最大值.

默认, 系统中未设置 全局最大 LOD 值.

# Code examples
# --
Shader "Examples/ExampleLOD"
{
    SubShader
    {
        LOD 200

        Pass
        {}
    }

    SubShader
    {
        LOD 100

        Pass
        {}
    }
}

# LOD values for Unity’s built-in shaders
针对 Unity’s built-in shaders:
-- 100
        Unlit/Texture
        Unlit/Color
        Unlit/Transparent
        Unlit/Transparent Cutout
-- 300
        Standard
        Standard (Specular Setup)
        Autodesk Interactive

# LOD values for legacy shaders
针对  Unity’s built-in legacy shaders:
-- 100  
        VertexLit
-- 150  
        Decal
        Reflective VertexLit
-- 200  
        Diffuse
-- 250
        Diffuse Detail
        Reflective Bumped Unlit
        Reflective Bumped VertexLit
-- 300
        Bumped
        Specular
-- 400
        Bumped Specular
-- 500
        Parallax
-- 600 
        Parallax Specular 


## =========================================================== #
#     ShaderLab: defining a Pass
## =========================================================== #

# Overview
pass 包含: 设置 gpu state 的指令, 运行在 gpu 上的 shader program.
passes 之间的工作可以很不相同, 

注意: 在基于 srp 的渲染管线中, 可使用 RenderStateBlock 来改变 gpu 的 render state. 这样就不需要额外新建一个 pass 了

# Render pipeline compatibility
全支持

# Using the Pass block
在 pass 代码块中, 你可以:
--
    设置 pass 的 name
--
    设置 tags
--
    执行 ShaderLab commands
--
    添加 shader codes

你还可以定义两种特殊类型的 passes, 使用 UsePass or GrabPass commands.

# --
Pass
{
    <optional: name>
    <optional: tags>
    <optional: commands>
    <optional: shader code>
}

代码示范:
# --
Shader "Examples/SinglePass"
{
    SubShader
    {
        Pass
        {                
              Name "ExamplePassName"
              Tags { "ExampleTagKey" = "ExampleTagValue" }

              // ShaderLab commands go here.

              // HLSL code goes here.
        }
    }
}

## =========================================================== #
#     ShaderLab: assigning a name to a Pass
## =========================================================== #
pass 可以拥有自己的 name, 在 UsePass command, 以及一些 c# API 中,需要通过 pass name 来寻找 pass. 

在 Frame Debugger 面板中,也会显示 pass 的 name.

# Render pipeline compatibility
全支持

# Using the Name block
# --
Name "ExampleNamedPass"

在内部, unity 会将此 name 转为 全大写字母. 当你想要在 ShaderLab 代码中引用此名字,需要用 全大写格式: "aaa" -> "AAA"

若在同一个 SubShader 中,存在多个 同名的 pass, unity 会使用第一个 pass.

# Using the Pass name with C# scripts
使用 
    Material.FindPass, 
    Material.GetPassName, 
    ShaderData.Pass.Name.
来获得 pass 的name

注意: 
    Material.GetShaderPassEnabled 
    Material.SetShaderPassEnabled 
这两函数 并不依靠 name 来寻找 pass. 相反, 它们凭借 LightMode tag 值来寻找 pass.

代码示范:
# --
Shader "Examples/ContainsNamedPass"
{
    SubShader
    {
        Pass
        {    
              Name "ExampleNamedPass"
              ...
        }
    }
}

在 c# 中寻找这个 pass:
# --
using UnityEngine;

public class GetPassName : MonoBehaviour
{
    // 此脚本需要挂载在一个 拥有 MeshRenderer component 的 go 上
    
    void Start() {
        var material = GetComponent<MeshRenderer>().material;

        // 找到 active SubShader 中第一个 pass 的 name
        var passName = material.GetPassName(0);

        // 打印 pass name
        Debug.Log(passName);
    }
}


## =========================================================== #
#     ShaderLab: assigning tags to a Pass
## =========================================================== #
pass tag 是一个 键值对.

# Overview
unity 使用预定义的 tags 来检测 如何(以及何时)渲染给定的 pass.
你也可以自定义 tags, 且用 c# 访问它们.

最常用的 预定义 pass tag 是 [LightMode] tag. 它在所有渲染管线中都管用.
剩余的 pass tags , 在不同的管线中功能不同. 

# Render pipeline compatibility
全支持

# Using the Tags block
SubShader 和 pass 都拥有自己的 tags, 两者毫不相关, 混用是无效的.

# Using Pass tags with C# scripts
使用  Shader.FindPassTagValue 查找 pas tag 的值.
此函数针对 unity 预定义 pass tags, 已经你自定义的 pass tags 都管用.

注意: 有些 API 直接作用于 [LightMode] pass tag, 下文会提及.

# LightMode tag 
是一个 预定义 pass tag, unity 用它来获知:
    -- 是否在给定的帧中执行这个 pass.
    -- 在一帧的什么时间点 执行
    -- 如何处理 output

注意: 这个 [LightMode] pass tag 和 LightMode enum 是不同的.

后者是 light inspector 中的一个 数据, 可选择: Realtime, Mixed, Baked.
控制了 光源 何时计算光照.

每一种 渲染管线 都用到了 [LightMode] pass tag, 不过在每种管线中, 它可选的 预定义值 是不同的.

在 build-in 管线中, 若不设置 [LightMode] pass tag, 这个 pass 将不会执行任何 光照计算 和 阴影计算. 此结果等同于将 [LightMode] 设置为 "Always".

在 srp 管线中, 可使用 "SRPDefaultUnlit" 值来指代那些 没有设置 [LightMode] pass tag 的 passes.

# Syntax and valid values

# Using the LightMode tag with C# scripts
使用函数 Material.SetShaderPassEnabled and ShaderTagId, 并拿 [LightMode] pass tag 作为参数 来获知 unity 如何处理给定的 pass

在 srp 中, 可创建 [LightMode] pass tag 的自定义值. 然后在  ScriptableRenderContext.DrawRenderers 函数中, 确定要执行哪些 passes. 


## =========================================================== #
#   ShaderLab: Predefined Pass tags in the Built-in Render Pipeline
## =========================================================== #

# ---------------- #
# LightMode tag valid values
built-in 管线的, 已整理在 shader.md 中
urp  管线的,     已整理在 shader_urp.md 中


# ---------------- #
# PassFlags tag
在 built-in 管线中, 使用 [PassFlags] pass tag 来指定 unity 提供哪些数据给 pass.

可选值:
-- OnlyDirectional
    仅在 built-in 管线, Forward rendering, [LightMode] 被设置为 "ForwardBase" 的 pass 中, 才能设置此 pass tag 值.

    当设置 "PassFlags" = "OnlyDirectional" :

    unity 仅将 主直射光 和 遮蔽/light probe 数据 提供给此 pass. 
    这意味着, 非重要光源 的数据 不会被传递给 顶点光 或 球谐 shader 变量.

代码示范:
# --
Shader "Examples/ExamplePassFlag"
{
    SubShader
    {
        Pass
        {    
            Tags 
            { 
                "LightMode" = "ForwardBase"
                "PassFlags" = "OnlyDirectional" 
            }
            ...
        }
    }
}


# ---------------- #
# RequireOptions tag
在 built-in 管线中, [RequireOptions] pass tag 基于 project settings 启用/禁用 一个 pass.

可选值:
-- SoftVegetation
    只有在  QualitySettings-softVegetation 开启时,此 pass 会被渲染


## =========================================================== #
#   ShaderLab: adding shader programs
## =========================================================== #
使用 hlsl 来写.

# Render pipeline compatibility
-- HLSLPROGRAM  全支持
-- HLSLINCLUDE  全支持

# Types of shader code blocks
为了添加 hlsl code, 可使用如下类型的 shader code block:
-- HLSLPROGRAM
-- CGPROGRAM
-- HLSLINCLUDE
-- CGINCLUDE

# HLSL and CG prefixes 两种前缀的区别
HLSL 和 CG 开头的 代码块的区别是:
--
    以 CG 开头的代码块, 默认下 它们自动包含 unity built-in shader include files. 这能方便你的 shader 的编写. 
--
    以 HLSL 开头的代码块, 默认下 它们不自动包含 unity built-in shader include files. 所以你必须手动包含 你想要的 库文件. 


# PROGRAM and INCLUDE suffixes 两种后缀的区别
--
    以 PROGRAM 结尾的代码块, 被称为 shader program blocks.
    你使用它们来编写 shader programs. 你将 hlsl 代码写入其中, 
--
    以 INCLUDE 结尾的代码块, 被称为 shader include blocks.
    你使用它们在 相同的 源文件的 不同 shader program blocks 之间共享 公共代码.
    你写入这个块中的代码 将被共享. 


# Using a shader program block
样式:
# --
HLSLPROGRAM
    [source code for shader programs, written in HLSL]
ENDHLSL

代码略...

# Using a shader include block
样式:
# --
HLSLINCLUDE
    [HLSL code that you want to share]
ENDHLSL

代码示范:
# --
Shader "Examples/ExampleShader"
{
    SubShader
    {
        // 要共享的代码
        HLSLINCLUDE
            ...
        ENDHLSL

        Pass
        {                
              Name "ExampleFirstPassName"
              Tags { "LightMode" = "ExampleLightModeTagValue" }

              // ShaderLab commands to set the render state go here

              HLSLPROGRAM
                // 此处的 hlsl 代码, 会自动包含 上面的 共享代码
                ...
              ENDHLSL
        }

        Pass
        {                
              Name "ExampleSecondPassName"
              Tags { "LightMode" = "ExampleLightModeTagValue" }

              // ShaderLab commands to set the render state go here

              HLSLPROGRAM
                // 此处的 hlsl 代码, 会自动包含 上面的 共享代码
                ...
              ENDHLSL
        }
    }
}


## =========================================================== #
#     ShaderLab: commands
## =========================================================== #

shaderLab commands 被分为几种类型:
# =1= 
    设置 gpu render state 的 commands
# =2=
    为了特殊目的, 新建一个 pass 的 commands
# =3=
    Legacy “fixed function style” commands
    允许你 不用 hlsl 就能创建 shader programgs
    (感觉没什么用)

可以使用 Category 块, 将数个 shaderLab commands 组合到一起去.


# =1= Commands for setting render state
使用下列 commands:
    -- 在 pass 块内 设置 pass 的 render state.
    -- 或在 SubShader 块内 设置此 SubShader 的 render state
     (将影响此 SubShader 所包含的所有 passes)
列举:
-- AlphaToMask: 
            sets the alpha-to-coverage mode.
-- Blend: 
            enables and configures alpha blending.
-- BlendOp: 
            sets the operation used by the Blend command.
-- ColorMask: 
            sets the color channel writing mask.
-- Conservative: 
            保守模式的光栅化
            enables and disables conservative rasterization
-- Cull: 
            sets the polygon culling mode.
-- Offset: 
            sets the polygon depth offset.
-- Stencil: 
            configures the stencil test, and what to write to the stencil buffer.
-- ZClip: 
            sets the depth clip mode.
-- ZTest: 
            sets the depth testing mode.
-- ZWrite: 
            sets the depth buffer writing mode.

# =2= Pass commands
-- UsePass:
            定义一个pass, 它从另一个 shader object 的一个 命名的 pass 中导入内容
-- GrabPass:
            新建一个 pass, 它将 屏幕中的内容 抓取 到一个 texture 中.
            以便在后续 pass 中使用它.

# =3= Legacy “fixed function style” commands
略

## =========================================================== #
#    ShaderLab: grouping commands with the Category block 
## =========================================================== #

使用 Category 块 来集中管理 "能设置 render state 的 commands", 

举例: 你的 shader object 可能拥有数个 SubShaders, 每一个都需要添加 Blend 设置.
此时可使用 Category 块 来如下实现:
# --
Shader "example" {

Category {
    Blend One One
    SubShader {
        // ...
    }
    SubShader {
        // ...
    }
    // ...
}

}

Category 块 并不影响 shader性能. 它和 "复制黏贴相同的代码" 是一样的行为.


## =========================================================== #
#    ShaderLab command: AlphaToMask
## =========================================================== #
启用/禁用 gpu 中的  alpha-to-coverage 模式.


# 知乎解释:
基于 MSAA 技术, 以 8x 为例, 在一个 pix 内采样8次, 但后面执行的 着色计算不是8次(次数取决于 8次采样 收集到的 物体数量 ) 
alpha-to-coverage 技术则在 msaa 基础上加了一层操作:

详细过程：对于每个 frag，计算每个 sample 的 coverage。运行 pixel shader得到alpha。以 8x samples 的 framebuffer 为例，如果一个 frag 的 alpha 是0.25，那么那么就以某种 pattern 丢掉 6 次采样, 只向 framebuffer 的两个 sample 上写入shading 结果。最后利用 multi-sample framebuffer 的 resample 过程来获得半透明的近似。

这样一来，只要没有太多的透明像素重叠在一起，近似效果还是足够好的（如果几何复杂度太高，这么做会引入大量的 aliasing ）。

如果我们不使用数学方法来解释的话，可以这么理解：alpha to coverage 本质上把一个透明的 frag 变成了不透明但是只 cover 了一部分像素的 frag。而我们知道渲染不透明的东西是无关顺序的，所以 alpha coverage 也无关顺序。
# 知乎解释 ~完~

当你使用 MSAA 伴随 alpha test 时, 会出现大量伪影, Alpha-to-coverage 可以消除它. 尤其是一些 vegetation shaders.

如果你并未开启 MSAA, 然后你还使用了 Alpha-to-coverage, 其结果是未定义的.
不同的显卡和 图形API 对此的处理手段 各不相同.

# Render pipeline compatibility
都支持

# Usage
此 command 修改了 render state. 
此 command 既可被设置为 pass, 也可被设置给 SubShader

# -- AlphaToMask On
    开启 Alpha-to-coverage 模式

# -- AlphaToMask Off
    关闭



## =========================================================== #
#    ShaderLab command: Blend
## =========================================================== #

决定了 gpu 如何组合 "pix shader 输出的 颜色值" 和 "render target 中已有的值".

此 command 的具体功能, 取决于 blending operation 的设置, 可在 BlendOp command 中设置. 

注意,尽管所有显卡和 图形API 都支持 blending 功能, 但有些 blending operation 的使用是受到限制的.

启用 blending 会关闭掉一些 gpu 的优化, 可能会导致性能下降.

# Render pipeline compatibility
全支持


# Usage
pass 中 和 SubShader 中都可用.

如果 blending 被开启, 以下事情会发生:
--
    若使用了 BlendOp command, blending operation 就会被设置到 那个值.
    否则( BlendOp command 没有被调用 ) 则 blending operation 会被设置成默认值: Add.
--
    若 blending operation 为 Add, Sub, RevSub, Min, or Max,
    gpu 就将 frag shader 的输出值, 乘以 source factor
--
    若 blending operation 为 Add, Sub, RevSub, Min, or Max,
    gpu 就将 render target 中同像素位置的值, 乘以 destination factor.
--
    gpu 对上面两步得到的值, 执行 blending operation 中记录的操作.

# - blending 公式为:
finalValue = operation( 
                sourceFactor * sourceValue,  
                destinationFactor * destinationValue
            )

在这个公式中:
-- finalValue 
        最终计算出来的值, 将写入目标 buffer
-- sourceFactor 
        是个系数, 定义在 Blend command 中.
-- destinationFactor
        是个系数, 定义在 Blend command 中.
-- destinationValue 
        目标buffer 中已经存在的值 (如 render target 中)
-- operation 
        就是 lending operation.


# ----------------- #
写法格式:
# ==
    Blend <state>

    如: Blend Off
    针对 默认 render target, 禁用 blending 功能
    此为 默认值

# ==
    Blend <render target> 
            <state>

    如: Blend 1 Off
    功能同上, 不过是针对 指定的 render target

# ==
    Blend <source factor> <destination factor>

    如: Blend One Zero
    针对默认 render target,启用 blending 功能.
    设置两个 blend factors, (RGBA)

# ==
    Blend <render target> 
            <source factor> <destination factor>

    如: Blend 1 One Zero
    同上条, 不过是针对 指定的 render target

# ==
    Blend <source factor RGB> <destination factor RGB>, 
           <source factor alpha> <destination factor alpha>

    如: Blend One Zero, Zero One
    针对默认 render target,启用 blending 功能.
    设置两个 blend factors, 不过这次把 RGB 和 Alpha 分开设置

# ==
    Blend <render target> 
            <source factor RGB> <destination factor RGB>, 
            <source factor alpha> <destination factor alpha>

    如: Blend 1 One Zero, Zero One
    同上条, 不过是针对 指定的 render target

注意:
-1- 
    想要能指定 render target, 需要 OpenGL 4.0+, GL_ARB_draw_buffers_blend, or OpenGL ES 3.2.
-2-
    最后一种中,将 RGB 和 Alpha 分开设置的写法, 和 advanced OpenGL blending operations 不兼容.

# ----------------- #
# 变量 render target 的可用值:
需要为 整型, 0~7, 代表 render target idx.


# ----------------- #
# 变量 state 的可用值:
-- Off
    意为 禁用 blending 功能.

# ----------------- #
# 变量 factor 的可用值:
这些值都很直观,就不解释了:
-- One
-- Zero
-- SrcColor
-- SrcAlpha
-- DstColor
-- DstAlpha
-- OneMinusSrcColor
-- OneMinusSrcAlpha
-- OneMinusDstColor
-- OneMinusDstAlpha

其中, 
Src 表示 从 pix shader 中输出的颜色值
Dst 表示 位于 render target 中已经存在的颜色值


# =============== #
# 一些常见的写法:
# --
Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency
Blend One OneMinusSrcAlpha      // Premultiplied transparency
Blend One One                   // Additive
Blend OneMinusDstColor One      // Soft additive
Blend DstColor Zero             // Multiplicative
Blend DstColor SrcColor          // 2x multiplicative


## =========================================================== #
#    ShaderLab command: BlendOp
## =========================================================== #
指定 Blend command 会用到的 blending operation
想要这个 command 起效, 必须在 同pass, 同Subshader 中, 存在匹配的 Blend command.

不是每个 blending operation 在每个显卡中都能起效, 效果同时取决于 显卡和 图形API. 
当允许自己不支持的 blending operation 时, 不同的 图形API 的反应是不同的:
-- GL 会跳过这个 不支持的 operation
-- Vulkan and Metal 会将 operation 退回默认的 Add.

# Render pipeline compatibility
都支持

# Usage
可用在 pass 中, 也可用在 SubShader 中.

代码格式:
BlendOp <operation>

# Valid parameter values
可用的值:
# -- Add
        src + dst
# -- Sub
        src - dst
# -- RevSub
        dst - src
# -- Min
        min(src, dst)
# -- Max
        max(src, dst)
# -- LogicalClear
        逻辑操作:  Clear: (0)   清零
# -- LogicalSet
        逻辑操作:  Set:  (1)      设为:1
# -- LogicalCopy
        逻辑操作:  Copy:  (s)     使用 src
# -- LogicalCopyInverted
        逻辑操作:  Copy inverted:  (!s)  使用 !s
# -- LogicalNoop
        逻辑操作:  Noop:   (d)
# -- LogicalInvert
        逻辑操作:  Invert:  (!d)
# -- LogicalAnd
        逻辑操作:  And:   (s & d)
# -- LogicalNand
        逻辑操作:  Nand:   !(s & d)
# -- LogicalOr
        逻辑操作:  Or:   (s | d)
# -- LogicalNor
        逻辑操作:  Nor:   !(s | d)
# -- LogicalXor
        逻辑操作:  Xor:   (s ^ d)
# -- LogicalEquiv
        逻辑操作:   Equivalence:   !(s ^ d)
# -- LogicalAndReverse
        逻辑操作:   Reverse And:   (s & !d)
# -- LogicalAndInverted
        逻辑操作:   Inverted And:   (!s & d)
# -- LogicalOrReverse
        逻辑操作:   Reverse Or:   (s | !d)
# -- LogicalOrInverted
        逻辑操作:   Inverted Or:  (!s | d)
# -- Multiply
        高级OpenGL操作: 
# -- Screen
        高级OpenGL操作: 
# -- Overlay
        高级OpenGL操作: 
# -- Darken
        高级OpenGL操作: 
# -- Lighten
        高级OpenGL操作: 
# -- ColorDodge
        高级OpenGL操作: 
# -- ColorBurn
        高级OpenGL操作: 
# -- HardLight
        高级OpenGL操作: 
# -- SoftLight
        高级OpenGL操作: 
# -- Difference
        高级OpenGL操作: 
# -- Exclusion
        高级OpenGL操作: 
# -- HSLHue
        高级OpenGL操作: 
# -- HSLSaturation
        高级OpenGL操作: 
# -- HSLColor
        高级OpenGL操作: 
# -- HSLLuminosity
        高级OpenGL操作: 


注意:
-1-
    Min, Max 在 OpenGL ES 2 中需要  GL_EXT_blend_minmax
-2-
    逻辑操作 需要满足: DX 11.1+ or Vulkan.
-3-
    高级OpenGL操作 需要满足:
        GLES3.1 AEP+, 
        GL_KHR_blend_equation_advanced, 
        or GL_NV_blend_equation_advanced.
    它们只能和 标准的 RGBA blending 一起使用
    它们不兼容 "RGB 和 Alpha 分离设置的写法"


## =========================================================== #
#    ShaderLab command: ColorMask
## =========================================================== #
设置 颜色通道写入掩码, 以防止 gpu 写入 render target 中的 通道.

默认下, gpu 写入全部通道 (RGBA). 在某些情况下,你希望某个通道内的原有信息 不被修改. 比如: 你禁止颜色写入 "无颜色的阴影". 另一个用途是 完全禁止颜色写入, 这样你就能将用数据填充一个 buffer, 而不写入其它 buffers. 比如, 你想填充 stencil buffer, 而不写入 render target.

# Render pipeline compatibility
全支持

# Usage

# -- 
    ColorMask <channels>

    例如: ColorMask RGB
    写入默认 render target 的 RGB 这三个通道.

# --
    ColorMask <channels> <render target>

    例如: ColorMask RGB 2
    写入给定 render target 的 RGB 这三个通道

# Valid parameter values

# -------- #
# render target:
可写入 0~7 的整数, 表示 render target idx

# channels:
-- 0
    允许写入 RGBA 所有通道

-- R/G/B/A/
    标出了哪个通道,就能写入哪个通道
    4个通道可任意组合.


## =========================================================== #
#    ShaderLab command: Conservative
## =========================================================== #
启用/禁用 保守光栅化

在传统光栅化过程中, 通过在 一个像素内多次采样来判断 它是否属于某个 三角形.

"保守光栅化" 意味着, 只要这个像素 和 三角形沾边, 就判定此像素 属于 这个三角形.
这在需要确定性时很管用, 比如在执行 occlusion culling 时, 由gpu执行的碰撞检测, 以及 可见性检测.

保守光栅化 意味着 gpu 要为这个三角形 分配更多的 frags. 这会在后面导致更多的 frag shader 的调用, 进而影响性能.

# Render pipeline compatibility
全支持

# Usage 

调用 SystemInfo.supportsConservativeRaster 来检查 硬件支持情况. 
不支持此 保守光栅化 的 硬件, 会忽略本 command.

# -- Conservative True
    开启 保守光栅化

# -- Conservative False
    关闭

此 command 需要满足 DX 11.3+, or GL_NV_conservative_raster


## =========================================================== #
#    ShaderLab command: Cull
## =========================================================== #
设置 gpu 需要 cull 的多边形. 通常是 朝向相机的面, 或背向的面.

cull 会提高渲染性能. 

默认,gpu 执行 背面cull. 

# Render pipeline compatibility
全支持

# Usage
pass / SubShader 都能写

# -- Cull Back
    剔除背面,
    默认值

# -- Cull Front
    剔除正面

# -- Cull Off
    完全不剔除 (正反面都绘制)
    用于特殊目的,比如 透明物体, 双面墙 等等.


## =========================================================== #
#    ShaderLab command: Offset
## =========================================================== #
在 gpu 中设置 depth bias.

通常用来避免 shadowmap 中的 自遮挡现象, 或称为 暗斑.

想要设置特定几何体的 depth bias, 要么使用本 command, 要么使用  RenderStateBlock. 

想要设置 可影响所有几何体的 全局 depth bias, 使用  CommandBuffer.SetGlobalDepthBias. 

如果 局部和全局的都设置了, 则会在 全局 bias 的基础上, 再累加 局部 bias.

如果你直接修改 Light Inspectr 中的 bias 和 normal bias 两值, 也可得到相似的结果(缓解自遮挡), 然而, 这种方法的工作原理 是不一样的, 而且它并不改变 gpu 的 render state.

# Render pipeline compatibility
全支持

# Usage
# -- 
    Offset <factor>, <units>
    
    例如: Offset 1, 1

# factor 可用的值:
float值, [-1.0, 1.0]
    调整 z-斜率 (或: 深度斜率) 的最大值.
    为每个多边形 生成可变的 depth offset

    不与 近平面/远平面 平行的 多边形, 就会拥有 z-斜率.
    针对这些 多边形, 调整它们的斜率 来避免 某些伪影

# units 可用的值:
float值, [-1.0, 1.0]
    调整 "最小可分辨深度缓冲区值", 来生成一个 constant depth offset.
    "最小可分辨深度缓冲区值"( 1 units ) 因设备而异.

    若设为负数, 就是让 gpu 把 多边形画得 更靠近相机. 
    反之, 就是远离 相机


常见的配置:
# --
Offset -1, -1
    把本几何体 绘制得 靠近相机.


## =========================================================== #
#    ShaderLab command: Stencil
## =========================================================== #
和 gpu 得 stencil buffer 相关.

stencil buffer 为 framebuffer 中得每个像素, 存储一个 8-bit 值. 
在执行 pix shader 之前, gpu 可以将这个像素中得 stencil buffer 中得值, 和某个参考值做比较, 这个过程就叫做 stencil test.

如果 stencil test 通过了(成功了), gpu 再执行 depth test. 
如果 stencil test 没通过, 这个像素得剩余计算都会被跳过 (放弃执行)

这一意味着, 你可以把 stencil buffer 当作一个 mask, 来告诉 gpu 哪些像素需要绘制,哪些不需要.

通常使用 stencil buffer 来实现类似: 入口, 镜子 之类的东西.
另外, 当渲染 硬阴影时, 或当使用 constructive solid geometry (CSG) 技术时 (用布尔运算来消切堆叠一个物体). 也会用到 stencil buffer.

# Render pipeline compatibility
全支持

# Usage
此 command 会改变 render state. 
在 pass 和 SubShader 上都能使用.

可使用 Stencil command 来做两件不同的事:
-1- 配置 stencil test
-2- 设置 gpu 该往 stencil buffer 中写入什么值.

你可以在一次 stencil command 中同时完成这两件事. 
但更常见的做法是: 创建一个 shader object, 它将屏幕上一部分区域 遮蔽掉, 阻止其它 shader object 向其中绘制内容. 
为了实现这一点, 针对第一个 shader object, 要让它在这个 屏幕区域 永远通过 stencil test, 并且能写入 stencil buffer. 
然后配置剩余的 shader objects, 让它们不能通过这个 屏幕区域的 stencil test.

使用 Ref, ReadMask, Comp 参数来配置 stencil test.
使用 Ref, WriteMask, Pass, Fail, ZFail 参数来配置 stecil write operation.

# stencil test 公式:
(ref & readMask) comparisonFunction (stencilBufferValue & readMask)

配置格式:
# --
Stencil
{
    Ref <ref>
    ReadMask <readMask>
    WriteMask <writeMask>
    Comp <comparisonOperation>
    Pass <passOperation>
    Fail <failOperation>
    ZFail <zFailOperation>
    CompBack <comparisonOperationBack>
    PassBack <passOperationBack>
    FailBack <failOperationBack>
    ZFailBack <zFailOperationBack>
    CompFront <comparisonOperationFront>
    PassFront <passOperationFront>
    FailFront <failOperationFront>
    ZFailFront <zFailOperationFront>
}
# ==
注意,以上每一项都是 可选的


# -------- #
# ref 的可写值:
    0~255 的整型值, 默认为 0.

    参考值.
    gpu 拿 stencil buffer 中某像素的值, 和 这个参考值做比较.
    具体比较规则, 记录在 comparisonOperation 参数中.

    此值被 readmask 或 writeMask 遮蔽, 具体哪个取决于是正在执行 读操作 还是 写操作.

    gpu 也能将这个 参考值 写入 stencil buffer 中, 如果 参数: Pass, Fail 或 ZFail 的值为 "Replace"

# -------- #
# readMask 的可写值:
    0~255 的整型值, 默认为 255.

    当执行 stencil test 时, gpu 使用这个参数作为 掩码.
    (作为掩码, 255 意味着 8个bit 上都写 1, 猜测是表示 全通过.)

    观察上方的 stencil test 公式.

# -------- #
# writeMask 的可写值:
    0~255 的整型值, 默认为 255.

    当 gpu 想要向 stencil buffer 写入值时, 使用这个参数作为 掩码.
    (作为掩码, 255 意味着 8个bit 上都写 1, 猜测是表示 全通过.)

    类似其它掩码, 此掩码指定了, 8位中的哪些 bits 能被 写入操作所影响.
    比如, 值为0 表示所有位 都不能写入,  而不是意味着 stencil buffer 将被写入 0.

# -------- #
# comparisonOperation
# comparisonOperationFront
# comparisonOperationBack
# 的可写值:
    比较操作
    ( 具体可用值在下方: Comparison operation values 中 )
    默认值为 "Always"

    在 stencil test 中, gpu 作用在所有像素上的 操作.

    comparisonOperation 这个 stencil test 会作用在所有 pix 中, 无论它们 是否朝向相机.
    如果除了 comparisonOperationBack and comparisonOperationFront, 还定义了comparisonOperation, 那么 comparisonOperation 的值, 将覆盖上面两个定义.

# -------- #
# passOperation 
# passOperationFront
# passOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    如果一个像素同时通过了 stencil test 和 depth test. 
    gpu 将在这个像素上执行的操作.

    passOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 passOperationBack and passOperationFront, 还定义了 passOperation, 那么 passOperation 的值, 将覆盖上面两个定义.

# -------- #
# failOperation 
# failOperationFront
# failOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    当一个像素 没通过 stencil test, 
    gpu 将在这个像素上执行的操作.

    failOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 failOperationBack and failOperationFront, 还定义了 failOperation, 那么 failOperation 的值, 将覆盖上面两个定义.

# -------- #
# zFailOperation
# zFailOperationFront
# zFailOperationBack
# 的可写值:
    一个 stencil 操作,
    ( 具体可用值在下方: Stencil operation values 中 )
    默认值为 "Keep"

    若一个像素 通过了 stencil test, 但没通过 depth test,
    gpu 将在这个像素上执行的操作.

    zFailOperation 作用在所有像素上, 无论它们是否朝向相机, 
    如果除了 zFailOperation and zFailOperation, 还定义了 zFailOperation, 那么 zFailOperation 的值, 将覆盖上面两个定义.


# =============== #
# Comparison operation values
在 c# 中, 这些值被 Rendering.CompareFunction enum 表达.

[以下这些操作都是针对单个像素的]

# Never 
    stencil test 永远不成功
# Less
    当 参考值 小于 stencil buffer 中的值, 则 stencil test 成功
# Equal
    当 参考值 等于 stencil buffer 中的值, 则 stencil test 成功
# LEqual
    当 参考值 小于等于 stencil buffer 中的值, 则 stencil test 成功
# Greater
    当 参考值 大于 stencil buffer 中的值, 则 stencil test 成功
# NotEqual
    当 参考值 不等于 stencil buffer 中的值, 则 stencil test 成功
# GEqual
    当 参考值 大于等于 stencil buffer 中的值, 则 stencil test 成功
# Always
    stencil test 永远成功 (永远能通过)


# =============== #
# Stencil operation values
在 c# 中, 这些值被 Rendering.Rendering.StencilOp enum 表达.

[以下这些操作都是针对单个像素的]

# Keep
    保留 stencil buffer 中的当前值
# Zero
    将 0 写入 stencil buffer
# Replace
    将 参考值 写入 stencil buffer
# IncrSat
    将 stencil buffer 中当前值 +1, 如果这个值已经是 255了, 则维持在 255
# DecrSat
    将 stencil buffer 中当前值 -1, 如果这个值已经是 0了, 则维持在 0
# Invert
    将 stencil buffer 中当前值 的8个bit 全部反转
# IncrWrap
    将 stencil buffer 中当前值 +1, 如果这个值已经是 255了, 则将其变为 0
# DecrWrap
    将 stencil buffer 中当前值 -1, 如果这个值已经是 0了, 则将其变为 255


# ===== 应用举例 1 ===== #
# --
Stencil
{
    Ref 2           // 参考值为 2
    Comp Always     // stencil test 永远能通过
    Pass Replace    // 既然 stencil test 已经默认通过了,
                    // 那么只要 depth test 能通过,
                    // 就能把 参考值 2 写入 stencil buffer
}    
# ==
只要这个 pass/SubShader 能渲染到的屏幕区域, 都会在 对应的 stencil buffer 中写入 2, 作为标记.

若想防止 后续 shader 绘制到 render target 的 此区域,
或 限制它们, 让它们仅能绘制到此区域,
就可用此设置.


# ===== 应用举例 2 ===== #
# --
Stencil
{
    Ref 2       // 参考值为 2
    Comp Less   // 当 参考值 2 小于 stencil buffer 中的值, 
                // 则 stencil test 成功
} 
# ==
如果只想绘制 render target 中的 没有被 masked 的区域,
可用此设置.


## =========================================================== #
#    ShaderLab command: UsePass
## =========================================================== #
此 command 可以将 另一个 以命名的 shader object 中的 已命名的 pass 的内容, 插入到 本地. 
以此来复用源代码.

# Render pipeline compatibility
全支持

# Usage
# 格式:
# -- UsePass "Shader object name/PASS NAME IN UPPERCASE"

    如果 已命名的 shader object 包含多个 SubShaders, uity 遍历这些 SubShaders 直到寻找到第一个 "包含给定名字的 pass" 的 SubShader.

    如果一个 SubShader, 拥有多个 相同名字的 passes. unity 选择最后一个 目标名字的 pass

    如果 unity 未能找到 目标名字的 pass, 它将会把这个 material 标记为 error material.

# 示范:
# --
Shader "Examples/ContainsNamedPass"
{
    SubShader
    {
        Pass
        {    
            Name "ExampleNamedPass"
            ...
        }
    }
}
# ==
在上面代码中, 我们准备了一个 命名的 pass

# -- 
Shader "Examples/UsesNamedPass"
{
    SubShader
    {
        UsePass "Examples/ContainsNamedPass/EXAMPLENAMEDPASS"
    }
}
# ==
我们来寻找上方的那个 pass, 注意: pass name 要全大写

路径中可以有多个 "/" 来表达目录层次关系.


## =========================================================== #
#    ShaderLab command: GrabPass
## =========================================================== #
此 command 新建一种特殊类型的 pass, 它能 抓取 当前 framebuffer 中的内容,
放入一个 texture 中. 以便后续的 passes 来使用这个 texture.

这个 command 会显著提高 cpu 和 gpu 的帧时间(性能被降低).
若不是在 快速原型中, 通常不要使用此 command !!!! 并尝试以其它方式来实现你想要的效果.

若你确实使用了本 command, 尽量减少 抓取屏幕 的次数, 要么通过减少使用此 command, 要么使用 "将屏幕抓取到 已命名的texture 中的 signature (签名)" (如果能用的话)

# Render pipeline compatibility
只有 built-in 管线支持.

# Usage
在 SubShader 块中使用本 command

GrabPass 只在 framebuffer 中工作, 不能将其用于其它 render target, 比如 depth buffer.

此 command 有两种格式, 它们的功能不相同, 并有不同的性能影响. 使用 带名字的texture 版本 能显著降低 屏幕抓取的次数, 从而降低对性能的影响.

# 格式:
# -- GrabPass { }
    抓取 framebuffer 中的内容, 放入一个 texture, 这样你能在 同 SubShader 的后续 passes 中 访问这个 texture.

    使用 "_GrabTexture" 为名来 指向这个 texture.

    当你选用这个格式时, 每当 unity 渲染一个 "包含此 command 的" batch时, 都会执行 屏幕抓取操作. 这意味着就算在 同一帧内, 也会抓取数次: 每一batch 抓取一次.

# -- GrabPass { "ExampleTextureName" }
    将抓取的内容放入一个 texture, 这样你能在 本帧之内, 后续的多个 SubShader 的 passes 中,访问这个 texture.

    texture 的名字由用户提供.

    当使用此格式, 在一帧中, 当 unity 第一次遇到一个 batch, 此 bacth 包含了这个 "带名字的" command 时, 才执行 抓取操作.
    意味着 一帧抓取一次.

# Examples
# --
Shader "GrabPassInvert"
{
    SubShader
    {

        GrabPass { "_BackgroundTexture" }

        // 在此 pass 中可以使用这个 texture
        Pass
        {
            // 毕竟是个 texture, 要做纹理设置
            sampler2D _BackgroundTexture;
            ...
        }
    }
}


## =========================================================== #
#    ShaderLab command: ZClip
## =========================================================== #
设置 gpu depth clip mode. 
它决定了 gpu 如何处理 超出 近平面/远平面 的 frags

此 command 对 渲染"stencil shadow" 很有用. 这样就不需要对 超出 远平面的 几何体 做特殊处理, 从而减少 render 操作.

然而,此 command 会导致 错误的 "Z顺序"

# Render pipeline compatibility
全支持

# Usage
此 command 改写了 render state, 在 pass/SubShader 中都能使用

# -- ZClip True
默认设置
将 depth clip mode 设置为 [clip]

    超出的 frags 全部被 "抛弃了" (不执行后续渲染工作)

# -- ZClip False
将 depth clip mode 设置为 [clamp]

    那些比 近平面 更近的 frags, 将被 clamp 到 近平面 这个深度
    那些比 远平面 更远的 frags, 将被 clamp 到 远平面 这个深度

    当你正在渲染 "stencil shadow", 可以用此设置


# 关于 stencil shadow
这是一个 正在退出历史舞台的 阴影算法.
它只能制作由 几何体投射 的阴影, 且阴影边界非常锐利.
它的质量也 受到 屏幕分辨率的影响.

暂不展开.


## =========================================================== #
#    ShaderLab command: ZTest
## =========================================================== #
设置 几何体 通过/未通过 depth test 的检测条件.

depth test 允许 gpu 拥有 "Early-Z" 功能, 以便在 渲染管线的早期阶段将 几何体 筛选掉, 同时确保 几何体 的正确排序. 

可使用本 command 来实现类似 object occlusion 之类的 视觉效果.

# Render pipeline compatibility
全支持

# Usage
此 command 改写了 render state, 在 pass/SubShader 中都能使用

# 格式
ZTest [operation]

# ---------- #
# 参数 operation 可用值:

# Less
    只有当 几何体深度值 小于 "depth buffer 现有值", 此几何体才会被绘制 (靠近相机)
# LEqual
    只有当 几何体深度值 小于等于 "depth buffer 现有值", 此几何体才会被绘制 
# Equal
    只有当 几何体深度值 等于 "depth buffer 现有值", 此几何体才会被绘制 
# GEqual
    只有当 几何体深度值 大于等于 "depth buffer 现有值", 此几何体才会被绘制 
# Greater
    只有当 几何体深度值 大于 "depth buffer 现有值", 此几何体才会被绘制 
# NotEqual
    只有当 几何体深度值 不等于 "depth buffer 现有值", 此几何体才会被绘制 
# Always
    不执行 depth test. 任何深度的几何体都会被绘制


## =========================================================== #
#    ShaderLab command: ZWrite
## =========================================================== #
在渲染时, 设置 depth buffer 的内容是否被更新.
通常, 实心物 要开启 zwrite
半透明物 要关闭 zwrite.

# Render pipeline compatibility
全支持

# Usage
此 command 改写了 render state, 在 pass/SubShader 中都能使用

# -- ZWrite On
    开启写入

# -- ZWrite Off
    禁止写入






# ------------------------ END ----------------------------- #