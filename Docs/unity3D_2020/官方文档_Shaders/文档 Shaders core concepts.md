## =========================================================== #
#     Shaders core concepts
## =========================================================== #


## =========================================================== #
#     Shaders introduction
## =========================================================== #

# Types of shader
uniy 中的 shader 有 三大类:
-1- 最主流的 shader,是 图形管线的一部分. 
    通过使用 shader objects 来使用这种 shader
-2- Compute shaders 
-3- Ray tracing shaders

# Terminology 术语

-- shader or shader program: 
    就是最常见的 shader 程序

-- Shader object: 
    Shader class 的一个实例. 它封装一个 shader program 以及其它信息

-- ShaderLab: 
    一种用于编写shader的 Unity 特定语言

-- Shader Graph:
    用图来搭建 shader 程序

-- shader asset:
    项目中的一个拥有 .shader 后缀的 文件, 它定义一个 Shader object

-- Shader Graph asset:
    项目中的一个文件, 它定义一个 Shader object

## =========================================================== #
#     The Shader class
## =========================================================== #

[此段最好被制作成图]

Shader object 是  Shader class 的一个实例. 它封装 shader program 以及其它信息.
它允许你在 一个文件内定义多个 shader programs, 并且告诉 unity 如何使用它们.

# Render pipeline compatibility
shader object 在所有渲染管线中都可用

# Shader object fundamentals
一个 Shader pbject 包含若干个 shader programs, 一些修改 GPU配置的 指令
(它们被共称为 render state),以及一些信息,告诉 unity 如何使用 上述内容.

将 Shader object 和 material 一起使用, 来决定场景的表达.

# Assets
可用两种方式新建 Shader objects, 每种都有自己的 asset:
-1- 将 shader 代码写入一个 后缀为 .shader 的文件中
-2- 使用 Shader Graph 

不管用哪一种来创建, unity 都用相同的方式记录它们

# Inside a Shader object
内部将信息 组织成 SubShaders 和 Passes. 以此来将 shader program 组织成 shader variants.

# - Shader object
包含:
-- 关于自己的信息,比如 name
-- 一个可选的 fallback Shader object.
    如果当前 shader object 不可用,就用这个 fallback 版
-- 一或多个 SubShaders

你还可以定义额外的信息,比如 shared shader code, 或 是否使用 custom editor.

# - SubShaders
SubShaders 允许你将 Shader object 分割为数个部分, 以兼容不同的硬件,渲染管线, 运行时设置.

一个 SubShader 包含:
-- 此 SubShader 兼容的 硬件,渲染管线, 运行时设置
-- SubShader tags, 它们是些 键值对, 提供有关 SubShader 的信息
-- 一个或多个 Passes

你还可以定义额外的信息, 例如所有 passes 都通用的 render state. 

# - Passes
一个 pass 包含:
-- Pass tags, 键值对, 包含与 pass 相关的信息
-- 在运行它的 shader program 之前需要更新的 render state.
-- shader programs, 被组织为 一或多个 shader variants.

你还能定义额外的信息,比如 name. 

# - Shader variants
Pass 包含的 shader programs 被组织为若干个 shader variants. shader variants 之间共享 common code, 但在一个给定的 keyword 被设置为 enabled 或 disabled 时, 将获得不同的 功能.

一个 Pass 中的 shader variants 的数量, 取决于 你在 shader code 中定义了多少个 keywords, 以及目标平台. 
每个 pass 至少包含一个 shader variant.

# Order of operations during rendering
# 渲染期间的操作顺序
则是 unity 如何在所有渲染管线,使用 shader objects 渲染几何体 的高级描述.

在 unity 使用一个 shader object 之前:
-1- 
    unity 为 shader object 创建一个 SubShaders 的 list. 它先添加所有 位于 shader object 中的 SubShaders, 然后添加所有 位于 fallback shader object 中的 的 SubShaders.

当 unity 使用 shader object 渲染几何体时, 或者 shader LOD值, or 激活的渲染管线 发生改变时:

-1- 
    unity 便利 list 中的所有 SubShaders, 检测它们: 是否与当前硬件兼容, 高于还是低于 当前 shader LOD, 是否与激活的渲染管线兼容
-2- 
    如果 list 包含一或多个 符合上述条件的 SubShaders, 则选择其中的第一个. 将其选为 active SubShader
-3- 
    如果 list 中不包含任何符合的 SubShader:
    --1-- 
        如果 list 中存在 符合硬件兼容性的 SubShader(但它的 LOD 和 渲染管线 可能不符合) unity 会选择其中第一个, 设置其为 active SubShaer
    --2-- 
        如果连 硬件兼容 都完全没有符合的, unity 会将这个 material 标记为 error material.

unity 可以识别出 使用相同 shader variant 的几何体,并将它们组织成 batches, 以实现更有效的渲染. 
每帧一次,对于每一个几何体的 batch:
-1-
    unity 查明 active Subshader 中的哪些 passes 需要被执行, 并且在 一帧中的哪些时间点执行它们. 虽然渲染管线的不同, 这个过程也会出现差异
-2-
    针对需要渲染的每一个 pass:
    --1-- 
        如果当前 render state 和 pass中定义的 render state 不符, unity会按照 pass 中的信息 重设置 render state
    --2--
        GPU 使用相关的 shader variant 渲染 几何体.



## =========================================================== #
#       Shader assets
## =========================================================== #
讲述了 shader inspector 面板信息

# Compile and show code
-- 
    手动编译 选定的 图形API 的所有 shader variants. 在unity 中,只有等到 编译时刻, shader 才会针对所有 图形API 编译 所有的 shader variants.  你可以人工执行此过程, 来检查 errors. 
-- 
    检查所选平台的 已编译 shader 代码. 这在优化 shader 性能时非常有用；通常，你确实想知道生成了多少低级指令。
    可以把 生成的代码 粘贴到 GPU shader 性能分析工具上( AMD GPU ShaderAnalyzer or PVRShaderEditor. )


## =========================================================== #
#       Shader compilation
## =========================================================== #
每一次 build 你的 project, unity editor 都会把 当前 build 需要的 shaders 都编译一遍. 包含每个需要的 图形API 的所有 shader variants.

当你在 unity editor 内工作时, editor 不会一下子编译所有 shader variants, 因为这很费时.

相反, unity editor 执行以下操作:
-- 
    但导入一个 shader asset 时, 它会执行一些最小处理(比如 Surface Shader  generation)
-- 
    但需要显示一个 shader variant, 它会检查目录: Library/ShaderCache
--
    若在此目录中找到一个 先前编译好的 shader variant,而且它使用相同的源码(意味着源码后来未改变) 它就直接使用这个版本
--
    若没找到, 则当场编译这个需要的 shader variant, 并将其存入 cache 目录
    注意:
        若开启了 Asynchronous shader compilation, 上述过程则会在后台执行,同时显示一个 占位符shader.

shader 编译 是使用一个名为 UnityShaderCompiler 的进程来实行的. 可同时开启多个 UnityShaderCompiler 进程(通常一个 cpu核心 对应一个 进程)

但 editor 不在编译 shaders 时, UnityShaderCompiler 进程们 不执行任何任务,也不占用 计算机资源.

如果你的项目拥有一堆 shaders, 而且经常修改它们, 那么 cache目录: Library/ShaderCache 将会变得很大. 此时可以直接删除这个 目录, 之后 unity 会重编译这些文件.

在 player build time, 所有的 “not yet compiled” 的 shader variants 都将被编译, 它们都会位于 游戏数据中, 哪怕在 editor 中, 这些 variants 从未被使用过.


# Different shader compilers
不同的平台,使用不同的 shader 编译器:
-- 
    使用 DirectX 的平台, 使用 微软的 FXC HLSL compiler.
--
    使用 OpenGL (Core&ES) 的平台, 使用 微软的 FXC HLSL compiler,
    然后使用 HLSLcc 将字节码 转换为 GLSL
--
    使用 Metal 的平台, 使用 微软的  FXC HLSL compiler
    然后使用 HLSLcc 将字节码 转换为 Metal
--
    使用 Vulkan 的平台, 使用 微软的  FXC HLSL compiler
    然后使用 HLSLcc 将字节码 转换为 SPIR-V
--
    其它平台, 比如各种游戏主机,使用它们各自的 编译器
--
    Surface Shaders 在代码生成分析步骤, 使用 HLSL and MojoShader


你可以使用 pragma directives 配置各种 shader 编译设置.

# The Caching Shader Preprocessor
shader 编译涉及数个步骤, 第一步是 preprocessing(预处理). 在这一步, 一个名为 preprocessor 的程序, 为编译器准备 shader source code.

在 unity 之前的几个版本中, editor 使用编译器为当前平台提供的 preprocessor.
现在, 你也可以选择使用 Unity’s Caching Shader Preprocessor. 除非遇到的困难,否则你应该使用 Caching Shader Preprocessor.

Caching Shader Preprocessor 为 更快的 shader 导入和编译 做了优化, 它的加快了 25%. 它缓存 中间态预处理数据, 因此 editor 只需在 include 的文件发生修改时才会 解析它们. 这使得编译 同一个 shader 的数个 variants 的速度提高了. 
当一个项目的 shaders 使用了大量的 common include files 时, 使用 Caching Shader Preprocessor 将获得最大 性能提高.

不光提高了性能,  Caching Shader Preprocessor 还添加了一下特性:
--
    在 conditionals(猜测是条件分支语句) 中提供了 有限的 #pragma 指令的支持.
--
    对 #pragma warning 指令的支持
--
    对  #include_with_pragmas 指令的支持, 这允许你把 #pragma 指令放入 include 的文件内
--
    在 shader inspector 中的 Preprocess Only 选相框. 它允许你查看这个 shader asset 的 preprocessed source

想要对比  Caching Shader Preprocessor 和 旧版本的行为,可查看论坛:
https://forum.unity.com/threads/new-shader-preprocessor.790328/?_ga=2.140225331.1623209324.1626241396-597440040.1625213567&_gl=1*l0lnud*_ga*NTk3NDQwMDQwLjE2MjUyMTM1Njc.*_ga_1S78EFL1W5*MTYyNjQzMzg1Mi4xOC4xLjE2MjY0MzM4ODMuMA..


想要 开启或关闭 Caching Shader Preprocessor, 可通过:
    Project Settings - Editor - Shader Compilation - Caching Shader Preprocessor 选框
也可通过
    EditorSettings.cachingShaderPreprocessor API.

# Build time stripping 剥离
在 build 项目时, unity 可以检测出 某些 internal shader variants 并未被游戏使用到, 然后将它们从 build data 中 "strip" 掉. 

Build-time stripping 被用于:
--
    针对使用了 #pragma shader_feature 的 shader, unity 会自动检查它的 variants 是否被用到.  
    Standard shader 就使用这个
--
    处理 fog, lightmap modes 的 shader variants, 如果未在场景中被使用, 也将被剔除出 程序数据. 
    可在 Project settings - graphic 中修改配置
--
    你还可以手动识别 variants, 然后通过 OnProcessShader API 告诉 unity 去剔除掉它们.

以上几条的结合 通常能大大减少 shader data 的数据尺寸. 通常能从 几百MB 缩小为 几MB, 之后还能叠加 后续  packaging process 的压缩.


## =========================================================== #
#       Asynchronous shader compilation 异步
## =========================================================== #
这是一个 editor-only 特性, 可提高你的 工作流效率.

[白话:在_Editor_中异步编译_variant,以提高_Editor_编辑性能]

# Overview
shader objects 可包含 成千上万的 shader variants, 如果 editor 在 载入 shader object 时编译它的所有 variants, import process 会变得非常慢. 
相反, editor 在第一次遭遇这些 shader variants 时, 选择 按需编译它们,

编译这些 variants 可导致 editor 暂停 几ms 甚至 几秒, 具体时长取决于 图形API 和 shader object 的复杂度. 为了避免这种停顿, 可使用 Asynchronous shader compilation 在后台编译 shader variants, 同时使用 占位的 shader objects.

# How asynchronous shader compilation works
它这样工作:
-1-
    当 editor 第一次遇到 未编译的 variant, editor 将它添加进一个 job 线程中的 compilation queue 中. 
    editor 右下角的 进度条 显示了 compilation queue 的状态.
-2-
    当 shader variant 正在 loading, editor 使用一个 placeholder shader(占位shader) 来渲染界面中的 几何体, 通常这个 占位shader 会把物体绘制成 扁平的青色. 
-3-
    一旦 editor 完成 variant 的编译, 它就改用这个 variant 去渲染界面中的 几何体.

# Exceptions
-1-
    若使用  DrawProcedural or CommandBuffer.DrawProcedural 绘制几何体, editor 就不会使用 占位shader(青色),相反, editor 直接放弃渲染, 直到目标 variant 编译完成. 
-2-
    editor 不和 Blit 操作 一起使用 Asynchronous shader compilation, 这是为了保证在 大部分常规应用中 正确output.

# Enabling and disabling asynchronous shader compilation for your project

Asynchronous shader compilation 默认为开启.

设置方式:
    project settings - Editor - Asynchronous shader compilation 选框.

注意,上述方式的修改 仅在 Scene 和 Game 两个窗口中起效.
更多可看下方的 Custom Editor tools and asynchronous shader compilation.


# Enabling and disabling asynchronous shader compilation for specific rendering calls
在 c# 脚本中配置.

# - In an immediate scope
-1-
    在一个变量中暂存  ShaderUtil.allowAsyncCompilation 的状态
-2-
    在 call rendering commands 之前,先把 ShaderUtil.allowAsyncCompilation 设置为 false.
-3-
    Call the rendering commands.
-4-
    再把临时变量中的暂存值 放回 ShaderUtil.allowAsyncCompilation.

# - In a CommandBuffer scope
-1-
    调用 ShaderUtil.SetAsyncCompilation 设置为 false,
    随后加入 commandbuffer 的 commands 不会启用 asynchronous compilation 功能.
-2-
    将 commands 加入 commandbuffer 中
-3-
    调用  Shader.Util.RestoreAsyncCompilation 恢复状态

# - 代码示范:
// Create the CommandBuffer
CommandBuffer cmd = new CommandBuffer();

// Disable async compilation for subsequent commands
ShaderUtil.SetAsyncCompilation(cmd, false);

/// Enter your rendering commands that should 
// never use the placeholder shader
cmd.DrawMesh(...);

// Restore the old state
ShaderUtil.RestoreAsyncCompilation(cmd);


# Disabling asynchronous compilation for specific Shader objects

可以对特定的 shader objects 要求强制 同步编译.
如果正在使用 advanced rendering, 你可能会需要此功能.

为实现此, 将 #pragma editor_sync_compilation 指令添加到 shader 源码中.

# Detecting asynchronous shader compilation
可用 c# API 来显示 asynchronous shader compilation 的状态, 并在这个状态发生变化时 执行操作.

这在 advanced rendering 很管用, 如果 占位shader 污染了你的 生成代码, 可在编译彻底完成后, discard 那些被污染的数据, 然后用编译好的 variant 重新生成正确的数据.

如果你已经知道 你要处理的的 material 是哪个, 可使用 ShaderUtil.IsPassCompiled 来检查 variant 的编译状态, 当状态从 Uncompiled 变为 Compiled, 表示编译完成.

若不知道 你要处理的的 material 是哪个, 或存在多个 mats, 可使用 ShaderUtil.anythingCompiling 来检查 unity 是否正在 asynchronously 编译任何 variants.
当它从 true 改为 false, 意味着所有 编译工作都完成了.

# Advanced rendering in the Editor and asynchronous shader compilation

Advanced rendering 解决方案依赖于: 生成数据一次,然后在后续帧中复用它.
如果 editor 在这个过程中使用 占位shader 去渲染,会污染生成的数据. 如果这件事发生,你会在场景中看到 青色区域 或别的伪影., 即便在 vairiant 完成编译后 也依然存在.

为避免它,你可以:
-- Disable asynchronous shader compilation completely for your project
-- Disable asynchronous shader compilation for specific rendering calls
-- Disable asynchronous shader compilation for a specific Shader object
-- Detect when the source of the data pollution has finished compiling,
    然后重生成这些数据

(上面这些方法, 都在上文中提及)

# Custom Editor tools and asynchronous shader compilation
默认, asynchronous shader compilation 工作在 scene 和 game 窗口.
若希望将它用于 客制editor 工具中, 可在你的 客制工具中 通过 c# 来开启它.

为实现它, 可使用上文的:
Enabling and disabling asynchronous shader compilation for specific rendering calls

# - Customizing compile time rendering
可在你的 客制工具中, 使用 ShaderUtil.CompilePass, 替换掉默认的 占位shader,针对每个 material. 


## =========================================================== #
#       Shader loading
## =========================================================== #
默认, unity 的运行时 shader loading 行为是:
-1-
    当 unity 加载一个场景, 或使用 运行时资源加载, 它会将所有需要的 shader objects 加载到 cpu内存中.    
-2-
    unity第一次使用 variant 渲染几何体时, 它将该 variant 的数据传递到 图形驱动程序, 图形驱动 在 GPU 中创建该 variant 的代表. 并执行任何平台所需的 工作.

这样做的好处是:对于 variant, 不需要预先使用 GPU 内存,以及加载时间. 
缺点是,当 variant 第一次被使用时会存在卡顿, 因为此时 图形驱动 要在 gpu 上生成 shader program, 并执行任何附加工作.

# Prewarming shader variants 预热
为避免在 性能密集型时刻 出现上文的卡顿. unity 可要求 图形驱动在 variant 被使用之前 预先在 gpu 中创建代表, 这个行为就叫 Prewarming.

警告:在选择如何执行预热之前，请查看有关图形API支持的说明。在 DX12, Vulkan, and Metal 中,只有实验性的 ShaderWarmup API 是被全支持的, 因为它允许你指定一个 顶点格式. 使用其他方法可能会导致 工作和GPU内存 的浪费，而不会修复卡顿。

可用如下方式实现 预热:
--
    使用实验性 ShaderWarmup API 预热一个给定的 shader object 或 variant collection, (全图形API支持)
-- 
    在程序开始时 预热 shader variant collections, 通过将它们添加进 Preloaded shaders section of the Graphics Settings window.
    ( DX11,OpenGL 全支持, DX12, Vulkan,Metal 部分支持, 如果顶点布局和/或渲染目标设置与用于预热的数据不同，则图形驱动程序可能仍需要执行工作。 )
--
    使用 ShaderVariantCollection.WarmUp API 预热 shader variant collection, 
    ( DX11,OpenGL 全支持, DX12, Vulkan,Metal 部分支持, 如果顶点布局和/或渲染目标设置与用于预热的数据不同，则图形驱动程序可能仍需要执行工作。 )
--
    使用 Shader.WarmupAllShaders API 预热 当前在内存中的所有 shader objects 中的 所有 variants.
    ( DX11,OpenGL 全支持, DX12, Vulkan,Metal 部分支持, 如果顶点布局和/或渲染目标设置与用于预热的数据不同，则图形驱动程序可能仍需要执行工作。 )


# Profiler markers for shader loading
profiler marker 创建 "要发送到 GPU 的 shader variant 数据的表达" 是 Shader.Parse。
profiler marker 将 shader program 上传到 gpu, 并等待 gpu 执行任何需要的工作, 的是 CreateGPUProgram.

(没怎么看明白,好像就介绍了两个 api 函数)


## =========================================================== #
#       Shader variant collections
## =========================================================== #
一个 Shader variant collection 实际上是一个 cariants 的 list.
使用 collection 去预热 variants, 或者 确保 运行时需要,但在场景中没有被表示的的 variants, 不会被 剔除出 build.

# Creating a shader variant collection asset
--
    Projects面板 - 创建 shader - Shader Variant Collection
--
    editor 可以检查出, 但程序运行时 哪些 variants 是会被用到的, 然后自动将它们组成一个 collection. 

    相关信息和配置,显示在 project settings - graphic - shader Loading 区


# Viewing and editing a shader variant collection
当在 project面板中 选中一个 variants collection asset 时, 观察 inspector面板.

也可使用 ShaderVariantCollection API. 配置 collection asset.

# Prewarming a shader variant collection
上文讲过了


## =========================================================== #
#       Replacing shaders at runtime
## =========================================================== #
在 built-in 管线中, 可以叫 camera 在运行时更改 shader. 可用它来实现一些特效,比如: edge detection.

使用 Camera.RenderWithShader or Camera.SetReplacementShader 更改shader,
这两函数都需要参数: shader对象, replacementTag (是个string).

(这个 replacementTag 通常会被设置为 "RenderType", 表示它要检查这种 tag)

它是这样工作的: camera 依然渲染场景, objs 仍然在用它们的 mats, 但最终使用的 shader 发生了改变:
--
    若 replacementTag 为空, 那么场景中所有 物体都用 当前提供的 新 shader 来渲染
--
    若 replacementTag 非空, 则每个物体:
    -- 
        物体的 shader 将被询问 tag value
    --
        若此 shader 没有这个 tag, 这个物体不被渲染
    --
        在 替代者 shader 内, 检查各个 SubShaders, 找出和 replacementTag 的 tag 值相同的 subshader. 如果没找到,这个物体不被渲染
    --
        现在,使用这个找到的 subshader 来渲染 物体

举例,如果 “RenderType” 的值,比如  “Opaque”, “Transparent”, “Background”, “Overlay” 都存在, 你可以实现一个 替代者shader, 里面有个 subshader, 它拥有 RenderType=Solid tag. 这样, 它就只渲染 solid 物体.

其它 tag 的物体,因为没找到自己对应的 tag, 所以将不被渲染. 

通常,所有 built-in shader 都拥有  “RenderType” tag

# Lit shader replacement
当使用 shader替换 时, 将使用 配置在相机上的 render path 来渲染场景.
这意味着, 替代者shader 可包含 阴影 和 光照 passes(你可将 surface shaders 用作 替代者shader) 这在 渲染特殊效果 和 场景debug 时很管用.

# Shader replacement tags in built-in shaders
built-in shader 都有  “RenderType” tag, 可用来作为 替换 tag .这些 tag值如下:
--
    Opaque: most of the shaders (Normal, Self Illuminated, Reflective, terrain shaders).
--
    Transparent: most semitransparent shaders (Transparent, Particle, Font, terrain additive pass shaders).
--
    TransparentCutout: masked transparency shaders (Transparent Cutout, two pass vegetation shaders).
--
    Background: Skybox shaders.
--
    Overlay: Halo, Flare shaders.
--
    TreeOpaque: terrain engine tree bark.
--
    TreeTransparentCutout: terrain engine tree leaves.
--
    TreeBillboard: terrain engine billboarded trees.
--
    Grass: terrain engine grass.
--
    GrassBillboard: terrain engine billboarded grass.

# Built-in scene depth/normals texture
camera 本能地可以渲染 depth, depth+normals texture. 
在某些情况下, 这两个texture 可用 代替者shader 来渲染. 所以,在 shader 中设置正确的 “RenderType” tag 是很重要的.

# Code Example
指定 代替者shader

# --
void Start() {
    camera.SetReplacementShader (EffectShader, "RenderType");
}

这意味着, 代码中的 代替者shader: EffectShader, 自己需要设置  RenderType tag 值. 它长成这样:

# --
Shader "EffectShader" {
     SubShader {
         Tags { "RenderType"="Opaque" }
         Pass {
             ...
         }
     }
     SubShader {
         Tags { "RenderType"="SomethingElse" }
         Pass {
             ...
         }
     }
 ...
 }

在上例中, 场景中任何一个物体, 若它的原有 shader 的 Rendertype=“Opaque”, 它将被替换为 EffectShader 的 Opaque 段. 类似的还有 "SomethingElse".
若场景中有一个 shader, 它的  Rendertype="AAA", 而 "AAA" 在 EffectShader 并不存在, 那么 这物体将不被渲染.


## =========================================================== #
#       Compute shaders
## =========================================================== #
主要用于 gpgpu 运算. 
unity 中的 compute shader 和 DirectX 11 DirectCompute 技术很相似. 
各平台的支持情况为:
--
    Windows and Windows Store, with a DirectX 11 or DirectX 12 graphics API and Shader Model 5.0 GPU
--
    macOS and iOS -- using Metal graphics API
--
    Android, Linux and Windows platforms with Vulkan API
--
    Modern OpenGL platforms (OpenGL 4.3 on Linux or Windows; OpenGL ES 3.1 on Android). Note that Mac OS X does not support OpenGL 4.3
--
    Modern consoles (Sony PS4 and Microsoft Xbox One)

可在运行时,通过 SystemInfo.supportsComputeShaders 询问当前平台是否支持 compute shader.

# Compute shader Assets
是个后缀为 .compute 的文件, 它们用 DirectX 11 hlsl 语言编写. 

以下是个例子, 它将 output texture 写满红色:
# --
// test.compute
#pragma kernel FillWithRed

// Create a RenderTexture with enableRandomWrite flag and set it
// with cs.SetTexture
RWTexture2D<float4> res;

[numthreads(1,1,1)]
void FillWithRed (uint3 dtid : SV_DispatchThreadID)
{
    res[dtid.xy] = float4(1,0,0,1);
}


这个例子中只有一个 compute kernel, 它可被理解为一个函数. kernel 可以有多个. 

#pragma kernel 这一行后面不能跟 //注释语句

#pragma kernel 语句后可跟随一组 预处理宏, 它们会在 kernel
被编译时 被定义. 举例:
# --
#pragma kernel KernelOne SOME_DEFINE DEFINE_WITH_VALUE=1337
#pragma kernel KernelTwo OTHER_DEFINE
// ...


# Invoking compute shaders
在 c# 脚本中, 定义一个 ComputeShader 类的变量, 将其绑定到 那个 asset 上.
这允许你使用 ComputeShader.Dispatch 来调用这个 compute shader.

和 compute shader 关系较近的是  ComputeBuffer 类, 它可定义任意数据 buffer
(“structured buffer” in DX11 lingo).
也可从 compute shader 向 render texture 写入数据, 如果它们拥有  “random access” flag (“unordered access view” in DX11)
具体可查看  RenderTexture.enableRandomWrite 函数.

# Texture samplers in compute shaders
在 unity 中, texture 和 sampler 不是分开的objs. 想要使用它们, 必须遵守以下某一条规则:
--
    使用和 texture 相同的名字,在头部添加 "sampler", 
    如:
    Texture2D    MyTex
    SamplerState samplerMyTex
    这样,两者就被绑定了 (滤波/拓展/各向同性 等属性)
--
    使用一个 预定义的 sampler. sample 的名字必须包含:
    "Linear" or "Point" (for filter mode)
    以及 "Clamp" or "Repeat" (for wrap mode)
    如:
    SamplerState MyLinearClampSampler
    这个 sampler 拥有 线性滤波, 和 Clamp wrap mode.

更多信息请看:
https://docs.unity.cn/2021.1/Documentation/Manual/SL-SamplerStates.html


# Cross-platform support
使用 hlsl 编写 compute shader, unity 会将它转换为其它 图形API 语言.
同时,这里存在一些注意点:

# - Cross-platform best practices
DirectX 11 (DX11) 支持的很多 actions, 在别的平台上并不被支持 (比如 Metal or OpenGL ES). 因此，你应该始终确保 shader 在提供较少支持的平台上具有定义良好的行为，而不是仅在DX11上。有几件事需要考虑：

--
    "越界内存访问"是糟糕的. 
    当这样做时, DX11 在做 读操作时,会返回0. 当支持较少的平台此时可能会让 gpu crash.
    注意DX11特有的漏洞，缓冲区大小与线程组大小的倍数不匹配，试图从缓冲区的开头或结尾读取相邻的数据元素，以及类似的不兼容性。
--
    初始化你的资源.
    新的 buffer 和 texture 的内容是未定义的. 有的平台将它们清零, 有的则不会,甚至里面有 NaNs
--
    绑定你的 compute shader 声明的所有资源.
    即便你知道,在当前分支中 你的 shader 不会用到某些资源, 你仍然要确保它们的绑定.


# - Platform-specific differences
--
    Metal (for iOS and tvOS platforms) 在 texture 中不支持 atomic 操作. 
    它在 buffer 上也不支持 GetDimensions 询问.
    如果有需要, 应该将 buffer 的尺寸信息 当作一个 常数值, 手动传入 shader 中
    (而不是在 shader 中询问这个长度值)
--
    OpenGL ES 3.1 (for (Android, iOS, tvOS platforms) 单位时间只支持 4 个 compute buffers. 实际使用中往往需要更多的. 所以, 此时就需要把数据 组合进 struct 中, 而且为每种数据 单独搞一个 compute buffer.


# HLSL-only or GLSL-only compute shaders
也可阻止 unity 将 hlsl 源码转换为别的语言代码. 然后,为其它平台,手动编写 glsl代码.

下面的信息仅针对 HLSL-only or GLSL-only compute shader, 而不是针对 跨平台 shader. 
--
    由 CGPROGRAM and ENDCG 包裹的代码, 不支持 hlsl 平台
--
    由 GLSLPROGRAM and ENDGLSL 包裹的代码, 被当成 glsl源码, 这仅在 OpenGL or GLSL 平台工作. 
    还应注意，虽然自动转换的 shader 遵循缓冲区上的HLSL数据布局，但手动编写的GLSL着色器遵循GLSL布局规则。

# Variants and keywords
可使用:  #pragma multi_compile 和 #pragma multi_compile_local 指令 编译数个 variants. 这方面和常规 shader 一样. 这些指令会影响一个文件中的所有 kernel 函数.

注意, 常规shader 和 compute shader 共享 global keywords.
开启/关闭 一个  global keyword, 将影响所有 常规shader 和 compute shader.

使用函数:
    Shader.EnableKeyword, 
    Shader.DisableKeyword, 
    CommandBuffer.EnableKeyword,
    CommandBuffer.DisableKeyword
来 开启/关闭 这些 global keyword.

使用函数:
    ComputeShader.EnableKeyword
    ComputeShader.DisableKeyword
来 开启/关闭 compute shader 中的 局部 keywords.

使用:
    IPreprocessComputeShaders.OnProcessComputeShader
来将 compute shader variant 从 build 中剥离.
























