# ================================================================ #
#                   Z buffer
#                  depth buffer
# ================================================================ #


# 目前的认识：
- Manul: 
    Using Depth Textures

- Z-buffer 和 depth buffer
    
    但它们存储的值好像是不用的, 前者存储的是 z值, 它并不是最原始的 深度值


- z-value 就是 z-buffer 中，每个像素的 值
    取值范围在 [0,1]
    通常使用 32 or 16 bits 存储
    OpenGL - usesReversedZBuffer=false:
        near = 0f;
        far  = 1f;

    (但在一些版本较新的 mac 系统中, 可能unity 自动使用的 meta, 而不是 opengl. 所以 此值 = true )

    绝大多数平台(含:Mac.Metal) - usesReversedZBuffer=true:
        near = 1f;
        far  = 0f;
        可以把它看作是 默认设置了...


- z-value 的值并非线性的：
    而是基于这个公式：
            (1/n) - (1/z)
    f(z) = ------------------
            (1/n) - (1/f)
    （非官方源）
    其中：
        n: near;
        f: far;
        z: 从 z-buffer 中采样出的数值
    这意味着，z-value 中的 0.5，并不意味是区间[0,1] 的中点
    若是主流的 ReversedZBuffer=true，
    值为0.5 的位置，通常比 中点 更接近 camera 


- 想要从上述 非线性区间，转换到线性的区间，需要使用如下函数：

    - LinearEyeDepth()
        转换成线性的 Eye-Space 区间 [near,far]
            这是最直观的区间，数值单位就是 unity World-Space 通用单位
            或者说，就是 WS 中 平截头体 中的 near-far 区间
        具体可google: 
            DecodeDepthNormal/Linear01Depth/LinearEyeDepth explanations
        ---
        takes the depth buffer value and converts it into world scaled view space depth.
        The original depth texture 0.0 will become the far plane distance value, 
        and 1.0 will be the near clip plane.
        So now with the value you get from the linear eye depth function
        1 is a surface that is 1 unit from the camera’s pivot along the camera’s z axis.
        A value of 100 is 100 units, 200 is 200 units

    - Linear01Depth()
        转换成 [0,1] 线性区间：
            0:cameraPos，1:far 
            在这个空间中，near平面，被表示为 near/far 
        不管 usesReversedZBuffer 是否为 true，
        此函数的计算 始终成立
        ---
        mostly just makes the non-linear 1.0 to 0.0 range be a linear 0.0 to 1.0, 
        so 0.5 really is half way between the camera and far plane.





# _CameraDepthTexture
一个 shader 中的全局变量，存储本文提及的 z-buffer 

在 urp 中，在 camera inspector - Depth Texture 可设置
若将其设置为：Use pipeline setting
则进一步依赖 urp settings: Depth Texture 勾选框
如果 这个功能被开启了，
管线会生成 camera's dpeth, 且将其绑定到 _CameraDepthTexture 变量上


# SAMPLE_DEPTH_TEXTURE
对于大部分 非GLES2 平台:
#define SAMPLE_DEPTH_TEXTURE( textureName, samplerName, coord2 )          
    SAMPLE_TEXTURE2D( textureName, samplerName, coord2 ).r

其实就是一个常规的 2D texture 采样操作，只不过仅仅返回第一个分量:r 




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
    (OpenGL)
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

# Mac 10.15
    此值 = true;
    猜测是因为，使用的图形库是 Metal，而不是 OpenGL
    ---
    这也意味着，几乎绝大多数平台，此值都为 true 了



# ----------------------------------------------#
#              _ZBufferParams
# ----------------------------------------------#
Manual:
    Used to linearize Z buffer values

# if SystemInfo.usesReversedZBuffer = true:
_ZBufferParams:
    x = (far/near) - 1
    y = 1
    z = (1/near) - (1/far)
    w = 1/far
- 这是大多数平台 的 主要格式

# if SystemInfo.usesReversedZBuffer = false:
_ZBufferParams:
    x = 1 - (far/near)
    y = far/near 
    z = x/far = (1/far) - (1/near)
    w = y/far = 1/near
- 这是 manual 中记录的格式

# 为什么会被设计成这样 ？？？
当我们分别将 两种版本的 值，送入函数 
    LinearEyeDepth()
    Linear01Depth()
发现了有趣的现象：
    不管 SystemInfo.usesReversedZBuffer 是否为 true
    这两个函数 都能稳定地工作, 调用方将无法察觉到这层差异;



# ----------------------------------------------#
#           LinearEyeDepth
#           Linear01Depth
#           的替代版实现
# ----------------------------------------------#
这两个函数都要求 一个 shadow caster pass 事先生成好 z-buffer 数据（此观点不一定准确）
我们其实可以用一种更便捷的方法来实现它:

# ret vert(){
#     o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;
# }
乘法的前者，获得顶点在 view-space 中的 pos（且 z轴翻转了，是正的）
乘法的后者，值为 1/far

这个计算将获得一个区间值 [0,1]
0: camera pos
1: far

它的效果恰恰和 Linear01Depth() 相同

然后我们可以到 frag() 中，获得每个像素的 映射值




# ----------------------------------------------#
#             
# ----------------------------------------------#




