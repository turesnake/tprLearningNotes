# ================================================================ #
#         Universal Render Pipeline Asset   (11.0)
# ================================================================ #

...

你可以创建多个 urp asset 实例, 每个实例做不同配置, 然后在不同的实例之间做切换;
比如, 一个渲染阴影, 一个不渲染阴影;


下面是 inspector 上可见部分的 详细介绍:

# ---------------------------------- #
#       General
# ---------------------------------- #
此部为 core part;

# Depth Texture (单选)
若启用, urp 会在 所有不透明物体渲染完成后 (一般为渲染完 skybox 之后) 将 camera 的 depth 数据渲染进一张 texture,

可在 渲染完 skybox 之后,
在 shader 中访问 "_CameraDepthTexture" 来访问此数据;

URP then uses this depth texture by default for all Cameras in your Scene. 

--
可在 camera inspector 中覆写此设置;


# Opaque Texture (单选)
若启用, urp 会在 所有不透明物体渲染完成后 (一般为渲染完 skybox 之后)
将 camera 当前 color buffer 的数据, 复制一份到一个 texture 中;

可在 渲染完 skybox 之后, 在 shader 中访问 "_CameraOpaqueTexture" 来获得此 "opaque color 数据";

这个十分类似 built-in 管线中的 "GrabPass" 功能;

你可以在随后的 "处理半透明物体的 shader" 中, 使用这张 OpaqueTexture 来实现一些效果, 比如 毛玻璃, 水体折射, 热浪 等;

--
可在 camera inspector 中覆写此设置;

# Opaque Downsampling (多选)
若上面 启用了 "Opaque Texture", 本变量会变亮;

可用本变量来设置 Opaque Texture 的采样模式:

-- None:
    Produces a copy of the opaque pass in the same resolution as the camera.

-- 2x Bilinear:
    Produces a half-resolution image with bilinear filtering.

-- 4x Box:
    Produces a quarter-resolution image with box filtering. This produces a softly blurred copy.

-- 4x Bilinear:
    Produces a quarter-resolution image with bi-linear filtering.

# Terrain Holes (单选)
若禁用此项,
urp 将移除所有 "Terrain hole Shader variants",
以节省 build 时间;


# ---------------------------------- #
#       Quality
# ---------------------------------- #
此部控制 urp 的 quality level; 

# HDR (单选)
为每个 camera 启用 HDR;

--
可在 camera inspector 中覆写此设置;

# MSAA (多选)
为每个 camera 设置相同的 MSAA 配置;


-- Disabled:
-- 2x:
    每个像素做 2 次采样;
-- 4x:
-- 8x:

---
可在 camera inspector 中覆写此设置;

注意:
在 移动平台 不支持 "RenderBufferStoreAction.StoreAndResolve" 操作; 此时如果 勾选了上面的 "Opaque Texture" 选项, urp 将会不再使用 MSAA 功能;


# Render Scale (滑块 [0,2], 默认1)
缩放 render target 的 分辨率; 
本设置只能改变 game 渲染的 分辨率, 不能影响 UI 渲染;


# ---------------------------------- #
#       Lighting
# ---------------------------------- #
These settings affect the lights in your Scene.

如果你禁用某几个选项, 在 shader 中对应的 keyword 就会被禁用, 进而影响 shader variants 的生成;

如果你确定某些功能一定不会被本游戏用到, 那么禁用它们可以缩短项目的 build 时间;

# Main Light (二选)
影响平行光; 
在 Lighting Inspector 中的 "Sun Source" 变量上, 可以绑定具体的 主平行光;
若不手动绑定, urp 会将场景中当前最亮的 平行光 当作 Main Light;

-- Disable:
    不再渲染 主平行光, 就算你在 Lighting Inspector 中明确绑定了一个;

-- Per Pixel:
    默认值, 逐像素 主平行光;

# Cast Shadows (单选)
    需启用 Main Light;
让 主平行光 cast shadow;


# Shadow Resolution (多选)
    需启用 Main Light;
shadowmap texture 的分辨率 (边长)


# Additional Lights (多选)
-- Disable:
-- Per Vertex:
-- Per Pixel:

# Per Object Limit (滑杆 [0,8], 默认4)
    需启用 Additional Lights:
每个go 可同时受到 几个 Additional Lights 的照射;


# Cast Shadows (单选)
    需启用 Additional Lights:

一说是只有 spot光 能投影, 一说是没这个限制;
尚未做测试;

# Shadow Resolution (多选)
    需启用 Additional Lights:
shadowmap 的分辨率, 这张 shadowmap 要被分成 4x4 共 16份;

一说是只支持 Additional Lights 中的平行光投射阴影;



# ---------------------------------- #
#       Shadows
# ---------------------------------- #

# Max Distance (设置float)
超出此 distance, 不再渲染 shadow;
本值以 米 为单位; 
且无视下方 "Working Unit" 选择的值;

# Working Unit (二选一)
shadow cascade distances 这个值代表了啥;

也就是下方 "Split" 值的含义;

-- Metric:

-- Percent:

# Cascade Count (滑杆 [1,4])
支持的 cascade 的级数; 


# Depth Bias (滑杆 [0,10], 默认 1)

# Normal Bias  (滑杆 [0,10], 默认 1)

# Soft Shadows (单选)
软阴影需要 多次采样, 和 滤波;

当启用, Unity 使用如下 filtering method:
-- Desktop platforms: 5x5 tent filter, 
-- mobile platforms: 4 tap filter.

软阴影对性能冲击很高;



# ---------------------------------- #
#       Post-processing
# ---------------------------------- #
用来微调 全局 后处理设置;

# Post Processing  程序里没找到...
This check box turns post-processing on (check box selected) or off (check box cleared) for the current URP asset.
If you clear this check box, Unity excludes post-processing shaders and textures from the build, unless one of the following conditions is true:
Other assets in the build refer to the assets related to post-processing.
A different URP asset has the Post Processing property enabled.

# Post Process Data 程序里没找到...
The asset containing references to shaders and Textures that the Renderer uses for post-processing.
Note: Changes to this property are necessary only for advanced customization use cases.


# Grading Mode (二选一)

-- LDR:
    Unity applies a limited range of "color grading" after tonemapping.

-- HDR:
    Unity applies "color grading" before tonemapping.


# LUT Size (设置int值, 默认 32)
Set the size of the internal and external LUTs, that the urp uses for color grading.

在开始 "color grading" 计算之前, 这个值必须是固定的, 不能改的;


# ---------------------------------- #
#          Advanced
# ---------------------------------- #

# SRP Batcher (单选)


# Dynamic Batching (单选)
适合不支持 GPU Instancing 的平台, 

通常为禁用;

可在运行时更改;

# Mixed Lighting (单选)
启用时支持 Light Mode: Mixed;

to tell the pipeline to include mixed lighting shader variants in the build.

# Debug Level (二选一)

-- Disabled:
    Debugging is disabled. This is the default.

-- Profiling:
    Makes the rp provide detailed information tags, which you can see in the FrameDebugger.


# Shader Variant Log Level (多选)
Set the level of information about "Shader Stripping" and "Shader Variants" you want to display when Unity finishes a build. 

-- Disabled:
    Unity doesn’t log anything.
-- Only URP Shaders:
-- All Shaders:

You can see the information in Console panel when your build has finished.


# ---------------------------------- #
#        Adaptive Performance
# ---------------------------------- #
当安装了 "Adaptive Performance package", 本模块才会出现;


# Use Adaptive Performance  (单选)
Select this check box to enable the Adaptive Performance functionality, which adjusts the rendering quality at runtime.










