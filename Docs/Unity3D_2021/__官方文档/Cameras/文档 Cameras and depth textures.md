# ================================================================ #
#       Cameras and depth textures
# ================================================================ #


一个 camera 可以创建一个: depth, depth+normals, or motion vector texture; 这是最小的  G-Buffrs, 通常用于: 后处理, 自定义的 光照 等;

在 depth texture 中, pix 的值区间为 [0,1], 且为非线性分布;
基于项目的配置 和 平台, 数值的size 通常为 32-bits 或 16-bits;

从 depth texture 中直接读取的值, 是一个高精度的 区间为 [0,1] 的值; 如果你想获得 "起始于 camera pos 的 distance 值", 或 "线性的 0-1 值", 可用本文后方提到的 宏来获得;

大部分现代平台和 图形库都支持 depth texture, 少数要求如下:
-- 
    Direct3D 11+ (Windows), OpenGL 3+ (Mac/Linux), OpenGL ES 3.0+ (iOS), Metal (iOS) and consoles like PS4/Xbox One all support depth textures.
--
    OpenGL ES 2.0 (Android) requires GL_OES_depth_texture extension to be present.
    (需要一个拓展)
--
    WebGL requires WEBGL_depth_texture extension.
    (需要一个拓展)

可在脚本端使用 "Camera.depthTextureMode" 变量来启用 Camera’s depth Texture mode; 
你还可以手动创建一个类似的 texture, 使用 Shader Replacement feature:
https://docs.unity3d.com/2021.1/Documentation/Manual/SL-ShaderReplacement.html

有三种可能的 depth texture mode:
-- 
    DepthTextureMode.Depth:
        a depth texture.
--
    DepthTextureMode.DepthNormals:
        depth and view-space-normals packed into one texture.*
-- 
    DepthTextureMode.MotionVectors:
        per-pixel screen space motion of each screen texel for the current frame. Packed into a RG16 texture.

这些是 flags, 可以组合使用;

# --------------------------- 
#  DepthTextureMode.Depth texture:

This builds a screen-sized depth texture.

使用 shadow caster 那个 shader 来生成 camera 的 depth texture;

所以, 如果一个物体的 shader 不支持 shader caster,( 在 subshaders 和 fallback 中都不存在 shadercaster pass, ) 那么这个物体也不会出现在 depth texture 中; (因为它没法将自己渲染进 depth texture)

--
    让你的 shader 的 fallback 支持某个 shadercaster pass
--
    若在使用 surface shaders, ... 一些配置 ... 

注意:
只有 "不透明物体" (render queue<=2500) 会被渲染进 depth texture;


# --------------------------- 
#  DepthTextureMode.DepthNormals texture:

生成一个 screen-sized 32 bit (8 bit/channel) texture;

-- view-space-normals 会被编码进 R&G 通道, 
-- depth 被编码进 B&A 通道; 

Normals are encoded using Stereographic projection, 
depth is 16 bit value packed into two 8 bit channels.

----
UnityCG.cginc 文件中的  DecodeDepthNormal() 函数可以解码此数据,
得到的 depth 数据在 [0,1] 区间;

关于这个 format 的用例, 参考:
https://docs.unity3d.com/2021.1/Documentation/Manual/SL-ShaderReplacement.html


# --------------------------- 
#  DepthTextureMode.MotionVectors texture:

This builds a screen-sized RG16 (16-bit float/channel) texture,

where screen-space-pixel-motion is encoded into the R&G channels.

The pixel-motion is encoded in screen UV space.

从这个 texture 中采样得到的数值, 位于 [-1,1] 区间; This will be the UV offset from the last frame to the current frame.


# ====================
#  Tips & Tricks

...

在有些情况下, depth texture 可能直接源自 native Z buffer;
如果在你的项目的 depth texture 中看到 异常, make sure that the shaders that use it do not write into the Z buffer (use ZWrite Off).

# ====================
#  Shader variables

Depth textures 会被 unity 设置为 global shader property, 以便被 shader 代码访问到;
_CameraDepthTexture 能让你访问到 main depth texture;

_CameraDepthTexture 总是关联到 camera’s primary depth texture;

相反,
可以使用 _LastCameraDepthTexture 关联到 the last depth texture rendered by any camera;

MotionVectors 版则关联到 _CameraMotionVectorsTexture;

# ====================
#  Under the hood
... 未翻译 ...




















