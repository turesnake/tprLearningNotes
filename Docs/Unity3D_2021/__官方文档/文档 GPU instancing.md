# ================================================================ #
#       GPU instancing
# ================================================================ #
这是一篇 2017 年的 旧文档.
只翻译 其中一部分内容 ...


# ---------------------------------- #
# Introduction
使用少量 drawcalls, 一次性的, 将一个 mesh 绘制很多份. 
此技术适用于 建筑,树木,草, 或任何需要出府出现的 物体.

一个 mesh 会被重复绘制很多次, 单每一次都可配置不同的 parameters
(比如不同的颜色, scale, transform 变换矩阵 等 )


# ---------------------------------- #
# Adding instancing to your Materials
如果一个 material 支持 GPU Instancing, 会显出一个 Enable Instancing
的勾选框. 


# GPU Instancng 有以下限制:
--  unity 会自动选择 instancing 的 MeshRenderer 组件,
    以及 Graphics.DrawMesh 的调用.

    SkinnedMeshRenderer 不支持此技术. 

--  在单次 GPU Instancing 中, 只有使用了相同 mesh, 相同 material
    的 go 才会被 batch 到一起. 
    场景中使用的 mesh 越少, material 越少, 对此技术的支持越好.
    
    为了支持 丰富多彩的 instances, 可在go脚本中 添加 per-instance data (下一小节会介绍)

还可在脚本中调用 
Graphics.DrawMeshInstanced 
Graphics.DrawMeshInstancedIndirect 
来执行 GPU Instancing; 

# GPU Instancing 在如下平台和 api 中被支持:
    DirectX 11 and DirectX 12 on Windows

    OpenGL Core 4.1+/ES3.0+ on Windows, macOS, Linux, and Android

    Metal on macOS and iOS

    Vulkan on Windows, Linux and Android

    PlayStation 4 and Xbox One

    WebGL (requires WebGL 2.0 API)


# ---------------------------------- #
# Adding per-instance data

涉及 MaterialPropertyBlock 的应用.

...略...

# ---------------------------------- #
# Shader modifications
暂略, 未翻译以下几项的内容

# -- #pragma multi_compile_instancing

# -- UNITY_VERTEX_INPUT_INSTANCE_ID

# -- UNITY_INSTANCING_BUFFER_START(name) /                  
    UNITY_INSTANCING_BUFFER_END(name)

# -- UNITY_DEFINE_INSTANCED_PROP(float4, _Color)

# -- UNITY_SETUP_INSTANCE_ID(v);

# -- UNITY_TRANSFER_INSTANCE_ID(v, o);

# -- UNITY_ACCESS_INSTANCED_PROP(arrayName, color)


# ---------------------------------- #
# Advanced GPU instancing tips

# Batching priority
略

# Graphics.DrawMeshInstanced
略

# Graphics.DrawMeshInstancedIndirect

... 略...


# ====================================== #
# #pragma instancing_options
# ---------------------------------- #

# - #pragma instancing_options forcemaxcount:batchSize
# - #pragma instancing_options maxcount:batchSize
    在大部分平台, unity 自动计算 instancing data array size
    通过对目标设备的 最大 cbuffer size 除以 
    "包含 逐instance 所有 properties" 的 struct 的size.
    通常, 你不需要考虑 batch size. 但在部分平台(Vulkan, Xbox One and Switch) 人需要一个 固定值的 array size. 此时可使用 maxcount
    来指定 这些平台的 batch size. 在别的平台, 这个配置会被忽略.

    如果你想对所有平台都设置 batch size, 使用 forcemaxcount 

# - #pragma instancing_options assumeuniformscaling
    告诉unity, 本shader 相关的所有 instances 都使用 统一缩放(xyz)

# - #pragma instancing_options nolodfade
    阻止 unity 将 GPU Instancing 用于 LOD fade value

# - #pragma instancing_options nolightprobe
    阻止 unity 将 GPU Instancing 用于 light probe 
    (也包含它们的 遮蔽信息)
    如果你确定没有 go 同时使用 GPU Instancing 和 light probes
    可使用此指令 来提升性能.

# - #pragma instancing_options nolightmap
    阻止 unity 将 GPU Instancing 用于 Lightmap ST (atlas information) values.
    如果你确定没有 go 同时使用 GPU Instancing 和 lightmaps
    可使用此指令 来提升性能.


# - #pragma instancing_options procedural:FunctionName
    用来指示 unity 生成用于 Graphics.DrawMeshInstancedIndirect
    的附加变体. 

    在 vertex shader stage 初期, unity 将调用这个函数
    (名字定义在 FunctionName 这个位置)

    要手动设置 instance 数据, 就像你将 逐instance 数据添加到 shader 中那样, 将 逐instance数据 添加到这个函数中. 

    如果任何 获取的 instance properties 会出现在 fragment shader 中,
    那么这个函数在 fragment shader 的开始位置 也会被调用一遍.


...未完...








