




# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#            如何获得 lightMapUV   
# ---------------------------------------------------------------- #
这组值 unity 已经帮我们生成好了, 我们需要做的就是让 unity 再帮我们传入 gpu 中去

# --1--
在 context.DrawRenderers() 的准备工作: 配置 DrawingSettings 变量的过程中, 
设置:
    perObjectData = PerObjectData.Lightmaps

这样, unity 就会帮我们把 这组数据 传入 gpu

# --2--
然后为 主 Lit pass 增加一个 keyword:
    #pragma multi_compile _ LIGHTMAP_ON 

那些启用了 lightmap 的 gameobj, 会主动使用 启用了 LIGHTMAP_ON  的 shader variant

# --3--
在 struct Attributes 中, 可设置:

    float2 lightMapUV : TEXCOORD1; 

来获得这个具体的值 变量. 

在 cbuffer: UnityPerDraw 添加:

    CBUFFER_START(UnityPerDraw)
        ....
        float4  unity_LightmapST;
        float4  unity_DynamicLightmapST;
    CBUFFER_END

来获得 _ST 数据 (缩放和偏移) .
因为很多物体会被渲染进 同一张 lightmap, 每个物体 占据自己的 一块区域.
所以需要 _ST 数据来找到它们具体的位置.

然后,可把 _ST 信息计算进 UV 值:

    output.lightMapUV = input.lightMapUV * unity_LightmapST.xy + unity_LightmapST.zw;















