# ================================================================ #
#                URP 12.1.6  za
# ================================================================ #


# ---------------------------------- #
#   depth priming
This property determines when Unity performs depth priming.
Depth Priming can improve GPU frame timings by reducing the number of pixel shader executions. 

The performance improvement depends on the amount of overlapping pixels in the opaque pass and the complexity of the pixel shaders that Unity can skip by using depth priming.


The feature has an upfront memory and performance cost. The feature uses a depth prepass to determine which pixel shader invocations Unity can skip, and the feature adds the depth prepass if it's not available yet.


The options are:
• Disabled: Unity does not perform depth priming.
• Auto: If there is a Render Pass that requires a depth prepass, Unity performs the depth prepass and depth priming.
• Forced: Unity always performs depth priming. To do this, Unity also performs a depth prepass for every render pass. NOTE: depth priming is disabled at runtime on certain hardware (Tile Based Deferred Rendering) regardless of this setting.

On Android, iOS, and Apple TV, Unity performs depth priming only in the Forced mode. On tiled GPUs, which are common to those platforms, depth priming might reduce performance when combined with MSAA.
-------------------

移动端 还是设置为 Disabled 比较好;





# ---------------------------------- #
#   _DBUFFER
定义于 DBuffer.hlsl 中, 

和 decal system 有关, 就是在模型在再额外叠一层 细节材质 (有结构, 能和光交互), 类似泥土, 水塘等


# ---------------------------------- #
#   BUILTIN_TARGET_API
没找到它的信息




# ---------------------------------- #
#  REQUIRES_WORLD_SPACE_POS_INTERPOLATOR
由 Shadows.hlsl 定义, 
只要用到 阴影, 就需要 positionWS



# ---------------------------------- #
# CLUSTERED
猜测都和 "集群渲染" 有关;
就是使用 数台机器来渲染, 大概率和 游戏无关...



# ---------------------------------- #
# _ADDITIONAL_LIGHTS_VERTEX
旧版本中为 _VERTEX_LIGHTS,  即: add光的 顶点光照, 不太用到...


# ---------------------------------- #
# _SURFACE_TYPE_TRANSPARENT

大概: 如果: 当前为 "半透明" 渲染 (clip不算, 那被算作是 实心的) 时, 此宏被定义;


# ---------------------------------- #
# REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
需要计算: float4 shadowCoord;

一般在计算 平行光阴影 时要用到;




# ---------------------------------- #
# SHADER_STAGE_RAY_TRACING
" shader 阶段的 光追"

没能在 urp 源码中找到任何 来源...

# UNITY_RAY_TRACING_GLOBAL_RESOURCES
一样... 
字面意思: 光追全局资源;

个人猜测:
    目前阶段还没启用 光追,  这些代码都是为未来的版本做准备的


# ---------------------------------- #
# SHADER_STAGE_COMPUTE
2018.2 开始支持 compute shader


# ---------------------------------- #
# SHADER_TARGET
就是 4.5, 5.0 model 那堆东西;
一般这个宏会被定义为 45, 50 等 整形值;


# ---------------------------------- #
# ProbeVolume
就是 LPPV


# ---------------------------------- #
# UNITY_UNIFIED_SHADER_PRECISION_MODEL
  
"统一 shader 精度模型"  (猜测是 4.5 之类的东西)
https://docs.unity3d.com/ScriptReference/Rendering.BuiltinShaderDefine.UNITY_UNIFIED_SHADER_PRECISION_MODEL.html

如果在 player settings 中设置 "Shader Precision Model" 为 Unified (统一的), 此 enum flag 将会被开启;
    注意, 一共有两个选项:
        -- Use platform defaults for sampler precision
        -- Use full sampler precision by default, lower precision explicitly declared
        
    第二个选项, 就是 "Unified" 模式;

Mobile targets prefer lower precision by default to improve performance, 
but your rendering pipeline may prefer using unified precision model and to optimize against lower precision cases explicitly.
移动平台为了提高性能, 默认会使用 低精度;
但你的管线可要求使用 统一精度, 然后具体到要使用 低精度的地方, 再显式声明;



# ---------------------------------- #
# UNITY_COMPILER_HLSL
是否使用 hlsl 编译器, 通常为是.



# ---------------------------------- #
# UNITY_COMPILER_DXC
 是否使用 微软的 新的 shader 编译器 DXC

#   DXC
https://forum.unity.com/threads/unity-is-adding-a-new-dxc-hlsl-compiler-backend-option.1086272/

微软旧的 shader 编译器为 FXC,  DXC 要快一些, 也支持一些 FXC 不支持的 shader 特性;  但 DXC 还存在一些问题, unity 团队正在努力中;

当然, 目前 unity 的默认编译器任然是 FXC;

https://docs.google.com/document/d/1yHARKE5NwOGmWKZY2z3EPwSz5V_ZxTDT8RnRl521iyE/edit#

# 如何使用 DXC
在 pass 的 HLSLPROGRAM/ENDHLSL 块内, 写入:
    #pragma use_dxc

事实上, urp 12.1.6 中没有 shader 使用了这行代码;
相反, 有些 shader 写入了:

    #pragma never_use_dxc
    //Particle shaders rely on "write" to CB syntax which is not supported by DXC



# ---------------------------------- #
# min16float
# min16float2 ... 等很多拓展类型

https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/using-hlsl-minimum-precision



# ---------------------------------- #
# wave intrinsics 
# lane
https://docs.microsoft.com/en-us/samples/microsoft/directx-graphics-samples/d3d12-shader-model-6-wave-intrinsics-sample-uwp/

是 model 6 的一组新的 intrinsics 函数; (内置函数?)

They enable operations across lanes in the SIMD processor cores, helping the performance of certain algorithms such as culling and packing sparse data sets.
culling 和 packing 稀疏数据集;

# 有关 wave intrinsics
https://github.com/Microsoft/DirectXShaderCompiler/wiki/Wave-Intrinsics

支持在 SIMD 架构中,用一个处理器同时处理 多个 threads;




# ---------------------------------- #
# Common.hlsl 
中藏了很多现成的 好的函数, 应该整理一下;
平时用到可以直接去找...





# ---------------------------------- #
# PLATFORM_SUPPORT_GATHER
#        GATHER

# GATHER_TEXTURE2D 一个宏

texture.Gather(samplerName, coord2);

https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-to-gather

Gets the four samples (red component only) that would be used for bilinear interpolation when sampling a texture.

为了双线性插值;








