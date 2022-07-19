# ================================================================ #
#                  AssetsBundles 与 shader
# ================================================================ #


https://blog.unity.com/technology/stripping-scriptable-shader-variants


###
The shader compilation pipeline in Unity is a black box where each shader in the project is parsed to extract shader snippets before collecting the variant preprocessing instructions, such as multi_compile and shader_feature. This produces a list of compilation parameters, one per shader variant.
---
unity 中的 shader 编译管线是个黑盒, 在这里, 项目中的每一个 shader 会先被解析以提取 shader snippets, 然后 收集 变体预处理指令(如 multi_compile, shader_feature); 这会生成一个 编译参数列表 ，每个 shader 变体 一个;


###
These compilation parameters include the shader snippet, the graphics tier, the shader type, the shader keyword set, the pass type and name. Each of the set compilation parameters are used to produce a single shader variant.
---
这些编译参数 包含: shader snippet, graphics tier, shader type, shader keyword set, the pass type and name;  
每一组编译参数, 都可用来生成单个 shader 变体;


###
Consequently, Unity executes an automatic shader variant stripping pass based on two heuristics. Firstly, stripping is based on the Project Settings, for example, if Virtual Reality Supported is disabled then VR shader variants are systematically stripped. Second, the automatic stripping is based on the configuration of Shader Stripping section of the Graphics Settings.
---
随后, unity 自动执行一个 "自动 shader 变体剥离操作", 它基于两个启发式步骤:
(1) 首先, 基于 Project Settings 去执行剥离, 
    比如, 如果禁用了 VR, 那么相关的 shader 变体 就会被系统性剥离;
(2) 其次, 基于 Graphics Settings 的 Shader Stripping section 去执行 变体剥离;


###
Automatic shader variants stripping is based on build time restrictions. Unity can’t automatically select only the necessary shader variants at build time because those shader variants depend on runtime C# execution. For example, if a C# script adds a point light but there were no point lights at build time, then there is no way for the shader build pipeline to figure out that the Player would need a shader variant that does point light shading.
---
unity 无法在 build time 完成 shader 变体剥离, 因为剥离依赖 c# 运行时逻辑; 比如, build 时没有 点光源, 但运行时使用了, 那么 unity 就无法判断 是否可以剥离 点光源;


###
Here’s a list of shader variants with enabled keywords that get stripped automatically:
一下关键字的变体 将被自动剥离:

Lightmap modes: 
    LIGHTMAP_ON, 
    DIRLIGHTMAP_COMBINED, 
    DYNAMICLIGHTMAP_ON,
    LIGHTMAP_SHADOW_MIXING, 
    SHADOWS_SHADOWMASK

Fog modes: 
    FOG_LINEAR, 
    FOG_EXP, 
    FOG_EXP2

Instancing Variants: 
    INSTANCING_ON

Furthermore, when Virtual Reality support is disabled, the shader variants with the following built-in enabled keywords are stripped:
当 VR 被禁用, 使用如下 关键帧的 变体将被剥离;

    STEREO_INSTANCING_ON, 
    STEREO_MULTIVIEW_ON, 
    STEREO_CUBEMAP_RENDER_ON, 
    UNITY_SINGLE_PASS_STEREO

###
When automatic stripping is done, the shader build pipeline uses the remaining compilation parameter sets to schedule shader variant compilation in parallel, launching as many simultaneous compilations as the platform has CPU core threads.
---
当 自动剥离 工作结束后, 基于当前机器的 cpu 核心数量, shader build pipeline 使用剩余的 编译参数集 来并行编译 shader 变体们;


unity 2018.2 开始, 整个 shader pipeline 架构 在 变体编译 阶段之前 引入了一个新模块, 允许用户控制 变体的编译;
这个模块通过 c# callbacks 暴露给用户, 每个 shader snippet 都会执行这些 callbacks;


# === Scriptable shader variant stripping API ===
... 代码略...

# --- IPreprocessShaders.OnProcessShader()
https://docs.unity3d.com/ScriptReference/Build.IPreprocessShaders.OnProcessShader.html


# --- callbackOrder 
是个变量;

OnProcessShader() 在 "shader 变体编译" 之前被调用;

###
Each combination of a Shader, a ShaderSnippetData and ShaderCompilerData instances is an identifier for a single shader variant that the shader compiler will produce. To strip that shader variant, we only need to remove it from the ShaderCompilerData list.
---
Shader, ShaderSnippetData, 和 ShaderCompilerData 实例的每一种组合 都是一个 shader变体的 标识符; 想要移除那些变体, 只需从 ShaderCompilerData 中移除掉就行;


###
Every single shader variant that the shader compiler should generate will appear in this callback. When working on scripting the shader variants stripping, you need to first figure out which variants need removing, because they’re not useful for the project.
---
每个被 shader编译器 生成的 shader变体, 都会调用上面那个 callback;

# ========================================
# Results
# Shader variants stripping for a render pipeline


Furthermore, the Lightweight render pipeline for Unity 2018.2 has a "UI to automatically feed a stripping script" that can automatically strip up to 98% of the shader variants which we expect to be particularly valuable for mobile projects.
---
这个连接不见了...










# =============================================== #
#  keyword: 
#        _ADDITIONAL_LIGHT_SHADOWS 
#  如何被打进 ab包 ?
# =============================================== #

# 必须写为: #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
    不能缺少 '_'  !!!!!!!
    ---
    否则, 一旦这个关键字没有被定义(urp中), 所有带关键字的 pass 都将丢失; 



有时, 就算在 shader 变体收集器中定义了 keyword, 这个 keyword 也不会被打进 ab包;
严重的时候甚至会导致 整个 pass 的丢失;

# 这是因为:
    只要项目的 universalRP_High... 系列配置文件的 addLight Shadow 开关被打开了, 这个 keyword 就会被设置;
    反之, 只要这个开关被关闭了, 这个 keyword 就一定不会被 写入 shader, 哪怕你在 shader 变体收集器里定义了也不行;


这个剔除操作, 可能在 urp 的 ShaderPreprocessor.cs 文件 OnProcessShader() 函数中;


# ---------------------- #
#  universalRP_High... 配置文件中的 cast shadow 开关, 对应的 urp 源码是:

UniversalRenderPipelineAsset.cs -- supportsAdditionalLightShadows;


# =============================================== #
#  keyword: 
#        _ADDITIONAL_LIGHTS
#  如何被打进 ab包 ?
# =============================================== #
和上面的 _ADDITIONAL_LIGHT_SHADOWS 一样, 如果把 universalRP_High... 系列配置文件的 add光源开关 关闭, 
这个 关键词相关的 pass 也消失了......

# 必须写为: #pragma multi_compile _ _ADDITIONAL_LIGHTS
    不能缺少 '_'  !!!!!
    ---
    否则, 一旦这个关键字没有被定义(urp中), 所有带关键字的 pass 都将丢失; 





# =============================================== #
#      OnProcessShader 回调方法，为什么同一个 shader 会多次回调？
# =============================================== #

https://answer.uwa4d.com/question/61133b258f8c83424167271d


简单地理解，OnProcessShader 并不是一个“Shader资源“调用一次，而是一个 shader snippet 调用一次。
官网上的说法：Implement this interface to receive a callback before a shader snippet is compiled.
从这个函数的参数也可以看得出来，函数的一次调用，对应的是一个 Shader 的 一个 ShaderSnippetData。

OnProcessShader( Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data ) 
至于要理解清楚的话，这个问题本质就是概念的定义与理解问题了。
而对于 ”snippet“ 的定义，Unity官网的定义其实也有点矛盾，官方文档的说法与OnProcessShader函数用的概念是不一致的。

比如官方文档表示：An HLSL snippet must contain at least a vertex program and a fragment program. 也就是说：一个snippet至少包含一个 vertex program和一个fragment program。
(https://docs.unity3d.com/Manual/SL-PragmaDirectives.html)

而OnProcessShader函数的介绍文档中表示：Shader snippet: The HLSL input code with dependencies for a single shader stage. 也就是说：一个snippet 对应的就是一个stage（vertex, fragment等等）
(https://blog.unity.com/technology/stripping-scriptable-shader-variants)






