

# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#               shadow Mask channel index 是怎么得到的 ?
# ---------------------------------------------------------------- #

只有设置为 Mixed 的光, 才会生成 lightmap(ShadowMask). 

lightmap(ShadowMask) 在单个 texel 上最多允许存储 4 份数据(rgba).

原则上, 场景中支持 shadowmask 的平行光数量可以有无限多个. 只要这些光保证不会 "过度重叠". 
即, 单个 texel 内不会超过 4 个支持 shadowmask 的光.

如果某个 texel 内的 shadowmask 光数量超过 4 个, unity 会按照重要性留下4个光, 将它们的 shadow 信息
存储到 四个通道中. 剩余的光, 其模式会被强制修改为 Baked.

#  针对这些保留下来的光, unity 为它们中的每一个, 分配一个固定的 shadowMask channel index {0,1,2,3}
#  注意: 这个 channel index 是针对 光源的, 而不是针对 frag
#  此数据存储在:
#           LightBakingOutput.occlusionMaskChannel
#  上. 

    还有一个相似的概念, lightProbe(occlusion) channel index, 它被存储在:

            LightBakingOutput.probeOcclusionLightIndex
        
    中, 但 catlike 未使用此数据, 而是沿用了上面的 shadowMask channel index 数据. 


# 这个设计看起来是有问题的:
    它无法保证 存储最优. 他只能粗略地保留 一部分光源信息. 





# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#              lightProbe(Occlusion)
# ---------------------------------------------------------------- #

# -1-
    在 DrawingSettings.perObjectData 中添加: 
        PerObjectData.OcclusionProbe

    让 unity 为每个动态物体, 根据当前 lightProbes 四面体中的位置,
    计算出它的 shadow 插值. 

    注意, 每个动态物体, 只被分配到一个 单一的 shadow 值.
    (如果这个物体很大, 需要更细腻的 shadow 信息, 可改用 LPPVs )

# -2-
    这个值被 unity 写在:

        gpu - UnityPerDraw -  unity_ProbesOcclusion 中,
    
    和 lightmap(ShadowMask) 中的每个 texel 数据一样, 它也是一个 float4 数据,
    它最多存储了 4 份 shadow 数据. (针对 4 个光源)

# -3-
    catlike 选择使用上方的: LightBakingOutput.occlusionMaskChannel
    来访问这个 float4 数据. 

    毕竟在 gpu 中, 也是 逐个光源 地去计算光照信息的. 




