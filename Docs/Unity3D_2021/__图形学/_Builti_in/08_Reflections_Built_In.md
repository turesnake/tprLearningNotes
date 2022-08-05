# ================================================================ #
#                    Reflection Built-In
# ================================================================ #


# ++++++++++++++++++++++++++++++++++++++++++++++ #
#          各种零碎的 源码值, 宏 的分析   (11.0 版)
# ---------------------------------------------- #


# --------------------- #
# TextureCube unity_SpecCube0;
    存储了 skybox cube map;

    包含的信息是 HDR 的 (RGBM格式), 会比较亮;

    -----

    不光存储 skybox cube map;
    如果设置了 反射探针, 那么它还能同时包含 反射探针的信息;



# --------------------- #
# float4 unity_SpecCube0_ProbePosition;
    xyz: 反射探针 posWS
    w:   反射探针 是否开启 box projection (w>0 表示开启)



# --------------------- #
# UNITY_SAMPLE_TEXCUBE(...)
例如:
    float3 envSample = UNITY_SAMPLE_TEXCUBE (unity_SpecCube0, i.normal );

可以从一个 cube texture 上用方向向量采样;


# --------------------- #
#     RGBM 格式
HDR 的一种存储格式, RGB分量存储颜色, M分量存储一个 magnitude factor (幅度因子),

# 如何从这个 格式中提取出 gamma 空间中的 rgb 颜色:
    首先, unity_SpecCube0_HDR 的 xy分量 存储了两个 辅助值, 在这里记为 x,y;

-- 项目在 线性颜色模式:
    先计算: x*(M^y)
    然后用这个值, 去乘以 RGBM 格式中的 rgb 三个分量,
    得到最终的 颜色值;

-- 项目在 gamma 模式:
    先计算: x*M
    然后用这个值, 去乘以 RGBM 格式中的 rgb 三个分量,
    得到最终的 颜色值;

# DecodeHDR(...) 实现了这个过程;


# --------------------- #
# UNITY_SAMPLE_TEXCUBE
# UNITY_SAMPLE_TEXCUBE_LOD

采样 cubemap texture, 第二种支持指定 lvl 信息;
比如:
    float4 envSample = UNITY_SAMPLE_TEXCUBE_LOD(
		unity_SpecCube0, reflectionDir, roughness * UNITY_SPECCUBE_LOD_STEPS
	);

可看到, 第三个参数是个 float 值 (所有能在两个 lvl 之间做插值)
roughness: [0,1]

# UNITY_SPECCUBE_LOD_STEPS
    通常为 6, 表示 lvl 总体级数;
    也可用户自定义:
    用户自定义 需要写在所有 include 系统文件之前;

# --------------------- #
# Unity_GlossyEnvironment()

可以一步到位计算出 间接光的镜反部分;
具体用法:

    Unity_GlossyEnvironmentData envData;
	envData.roughness = 1 - _Smoothness;
	envData.reflUVW = reflectionDir;
	indirectLight.specular = Unity_GlossyEnvironment(
		UNITY_PASS_TEXCUBE(unity_SpecCube0), unity_SpecCube0_HDR, envData
	);

在此函数内容, 它将访问 unity_SpecCube0, 获得 天空盒+反射探针 的信息;


# --------------------- #
# BoxProjectedCubemapDirection(...)
    传入 原始的反射向量, 
    --
        若 反射探针开启了 box projection, 此函数会修改这个 反射向量, 
        使其变得更为真实,
    --
        若未开启, 则直接返回原本的 反射向量;


# --------------------- #
# 宏: UNITY_SPECCUBE_BLENDING
    确认目标平台是否支持 反射探针 之间的混合;

# --
    在 catlike 描述中, 此宏始终被定义, 只是值为 1 还是 0 的区别,
    所以他采用:
        #if UNITY_SPECCUBE_BLENDING
    通过判断值来获得信息;

# --
    但在 11.0 源码中, 此宏不再持续存在,
    所以要改成如下用法:
        #if defined(UNITY_SPECCUBE_BLENDING)


# --------------------- #
# 宏: UNITY_SPECCUBE_BOX_PROJECTION
    确认平台是否支持 反射探针的 box projection 功能;
    ---
    和上一个宏一样, 在使用上, catlike 和 源码也存在点分歧;
    在 11.0 源码中, 此宏不再持续存在,
    所以要改成如下用法:
        #if defined( UNITY_SPECCUBE_BOX_PROJECTION )


# ------------------------------------ #
#   支持 反射探针 和 skybox 之间的混合
# ------------------------------------ #
catlike 用代码实现了 两个反射探针之间的 混合,
使得物体可以在两个 反射探针的区间之间 柔和地过度;

其实 反射探针 和 skybox 之间也可实现过度:
    设置 go - mesh Renderer - Reflection Probes 为 Blend Probes and Skybox;



# ------------------------------------ #
#   增加 反射探针 在 bake 时的 反射次数:
# ------------------------------------ #
Lighting Inspector:
    Environment - Bounces 选项;

支持 [1,5], 能支持一些效果很有限的 相互反射;







