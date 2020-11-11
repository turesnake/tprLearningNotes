# ================================================================//
#                   Z buffer
#                  depth buffer
# ================================================================//






# --- 需要查看的 代码 ---
// Z buffer to linear 0..1 depth
loat Linear01Depth( float z );

// Z buffer to linear depth
float LinearEyeDepth( float z );



# _CameraDepthTexture
一个 shader 中的全局变量，

在 urp 中，在 camera inspector - Depth Texture 可设置
若将其设置为：Use pipeline setting
则进一步依赖 urp settings: Depth Texture 勾选框
如果 这个功能被开启了，
管线会生成 camera's dpeth, 且将其绑定到 _CameraDepthTexture 变量上






# ----------------------------------------------#
#        SystemInfo.usesReversedZBuffer
# ----------------------------------------------#
# true
    大部分图形库（非 OpenGL）
    0: far plane
    1: near plane
    ---
    精度更高

# false
    OpenGL
    0: near plane
    1: far plane
    ---
    理解起来比较直观，但存在性能缺陷

# ---
平时不需要关心此 反转操作
但当需要 手动处理 Clip-Space 时，需要用到

# 在源代码中可知：
Currently CullResults ComputeDirectionalShadowMatricesAndCullingPrimitives() doesn't
apply z reversal to projection matrix. We need to do it manually here.



# ----------------------------------------------#
#             
# ----------------------------------------------#


