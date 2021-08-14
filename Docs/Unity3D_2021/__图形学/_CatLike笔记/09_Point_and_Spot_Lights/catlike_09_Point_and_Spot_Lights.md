


# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#                  per-object light indices
# ---------------------------------------------------------------- #

当场景中每多一盏 平行光, 我们会把它分配给所有 frags. 这是合理的.

当场景中每多一盏 点光源/spot光, 就没必要把它分配给所有 frags 了, 因为一个 oth灯
的影响范围有效. 让无关的 frag 不去计算这个灯的 光照, 能显著提高性能.

实现此目的的方案有很多, 其中最简单的一种为: 
    per-object light indices

它是 unity 自动为我们提供的: 
    unity 记录了每个物体 所相关的 光源. 针对每个物体的 frag, 只要计算这些光源即可.

缺点就是: 如果某个物体特别大, 然后于它交集的光源数量特别多, 这个方法可能会出问题.
此外, 这个系统 bugs 很多, 不是很稳定. 

catlike 选择将它做成 一键开闭形. 


# GPU Instance:
会受到影响, 因为只有 unity_LightData, unity_LightIndices 两数据相同的 物体, 才会被打包到一起.

# SRP Batcher:
完全不受影响



# --------------------------------------- # 
# 开启此功能, 需要的工作:

# -1- 
#    在 DrawVisibleGeometry() 中, 为 drawingSettings.perObjectData
#    添加 lightsPerObjectFlags 
    这一步是为了让 unity 向 gpu 传输相关数据.
    这些数据存储在 UnityPerDraw 中:

        real4 unity_LightData;
        real4 unity_LightIndices[2];

    它们由 unity 自动装填.

# -2-
#    调用 cullingResults.GetLightIndexMap() 获得 indexMap    
#    这是一个 记录了场景中所有光源的 index 的 NativeArray
    这个数组的原始数据长这样: [0]=0, [1]=1, [2]=2... 可理解为,
    修改这个数组:
    把不想处理的光源全写 -1. 比如: 平行光, 不可见的 oth光源.
    而那些需要处理的 oth光源, 要在它们的位置上, 写上新的 index.
    这个index 是我们在 cpu 代码中 ( SetupLights()函数 ) 手动为这些 oth光 分配的
    这些新的 index 会被传入 gpu, 所以可以作为这些 oth光的 真正的 index.
    ---

#   然后, 我们需要手动把这些改写好的 indexMap 提交回去. 
#   并且 Dispose 掉申请的 NativeArray
    ---
    在此之后, 我猜测 unity 在后台, 为每一个物体, 挑选出前 8 个最重要的 oth光源
    (毕竟 平行光都被写入 -1 了), 将这 8个 oth光源的 index (我们分配的那个)
    写入 unity_LightIndices[2] 8 个元素中. 

    注意,不一定会填满 8 个数据, 可能少于 8 个

    然后 unity 还会把 物体相关的所有 "有效"光源数量, 写入 unity_LightData 中.
    这个值可能远远超过 8 这个值.
    (此处的 "有效", 是因为我们改写了 indexMap, 那些被标记为 -1 的光源都会 unity 被忽略)

# -3- 
#    进入 shader, 遍历 unity_LightIndices 中的元素( 0~8 个)
#    取出这些 oth光源的 index, 渲染它们. 


# -4- 
#    还可以把上面这些, 都包装进一个 shader variant 中
#    还可以组织成一个 一键开关, 来方便地取消这个功能. 毕竟它不太靠谱.
    这部分具体内容, 看 catlike 
















