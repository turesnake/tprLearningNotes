# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                   Fade Transition Width 
# ---------------------------------------------------------------- #

# ------------------------------ #
# 如何调出 Fade Transition Width 
不管是 2019版, 还是 2021版, 其调出方式都是一样的:

-- 点击进入 LOD Group component
-- Fade Mode 设置为 Cross Fade
-- 关闭 Animate cross-fading
-- 点击 分段图中, 具体某一段 LOD, 比如 LOD 0 
    此时会在下方自动摊开一个 小窗口, 里面就会出现 Fade Transition Width 滑块


# 若不设置  Fade Transition Width 滑块,
    shader 中 keyword: LOD_FADE_CROSSFADE 是不会被启用的  


# ------------------------------ #
#   Fade Transition Width 的含义

每一个 LOD N 区域, 都可设置自己的 Fade Transition Width 值.  [0.0, 1.0]
如期字面意思, 此值表示 "fade过渡带" 的分布比例(分布宽度):
(从右边界 朝向 左边界分布)

对于 左侧区的物体(本体), unity_LODFade: [  1 <- 0 ]
对于 右侧区的物体(前体), unity_LODFade: [ -1 <- 0 ]

注:
左侧表示 相机靠近, 右侧表示 相机远离. 




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                       fresnel 项
# ---------------------------------------------------------------- #

catlike 教程中, 针对物体的边界处 (此时观察夹角最大, 菲涅尔效应最强), 
任何材质在此处的 镜反率 都会提高.

当 environment map 记录的光照信息 恰好符合 此物体的周边环境时, 使用此方法制作的
fresnel 项会表现得很自然.
但当 environment map 记录的信息不是很匹配时 (很常见), 此时得 fresnel 项就会显得很奇怪,
且夺人眼球.



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#               环境光 镜反部分: 天空盒, 反射探针
# ---------------------------------------------------------------- #

# unity_SpecCube0:

    在这个 cubemap 中,存储 天空盒的 镜面反射光信息

        TEXTURECUBE( unity_SpecCube0 );
        SAMPLER( samplerunity_SpecCube0 );

    这份数据 unity 已经帮我们准备好了. 只要提取即可.

    奇怪的是, 在 catlike 中, 还使用此 数据 完成了 对 反射探针的数据的 获取,
    有待进一步学习...



# unity_SpecCube1:
    有的文章说, 这个 cubemap 存储 离物体最近的反射探针 的信息.

    但 catlike 中未提及.

    此变量只存在于 旧版 shader 源码中 (CGIncludes)
    在 Core, URP, HDRP 11.0 三个源码库中, 都只有 unity_SpecCube0,







