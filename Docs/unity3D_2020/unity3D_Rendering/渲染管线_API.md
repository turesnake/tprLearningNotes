# ================================================================//
#                    unity3d 渲染管线 API
# ================================================================//
SRP
涉及的 API 有点多，适当记录下...

主要是 cpu 端的


# ----------------------------------------------#
#               
# ----------------------------------------------#



# ----------------------------------------------#
#               
# ----------------------------------------------#



# ----------------------------------------------#
#            CullingResults [class]   
# ----------------------------------------------#
rp 会针对每一个 camera，执行  Culling 操作。
CullingResults 实例，就是这个 Culling 的产物:
    cullingResults = context.Cull( ref ScriptableCullingParameters p );
    
它记录了 通过 culling 的: visible objects, lights, reflection probes.

当一轮 render loop 结束时，cullingResults 的内存会被释放。

# 主要包含的数据：
visible objs...
    理论上有，但 API 中未提及

NativeArray<VisibleLight> visibleLights;

NativeArray<VisibleLight> visibleOffscreenVertexLights;
    有些 light 虽然不可见，但它照射到了 可见的obj

NativeArray<VisibleReflectionProbe> visibleReflectionProbes;





# ----------------------------------------------#
#               
# ----------------------------------------------#




# ----------------------------------------------#
#            ShadowSplitData   [class]
# ----------------------------------------------#
directional light 通常存在 perspective aliasing 的问题，
即：近处的 shadow，比远处的 更容易锯齿化。

为了解决这个问题，unity 使用了 Shadow Cascades 技术。
将 shadow map 按照由近及远的顺序，切割成数段，每一段使用不同精度（分辨率）的map

当调用 ComputeDirectionalShadowMatricesAndCullingPrimitives(),
将获得一个 ShadowSplitData 实例，里面就包含 cascade 相关的数据

本 class 实例，只记录 单个光 的单个 cascade 区间 的信息。




# ----------------------------------------------#
#          SortingSettings    [class] 
# ----------------------------------------------#





# ----------------------------------------------#
#            ShaderTagId     [struct]
# ----------------------------------------------#
ShaderTagId sId = new ShaderTagId("SRPDefaultUnlit");

通过一个 name，查找出它对应的 id 值。

# 这个 name 到底是什么 ？？？
目前看来，这些 name 好像是 系统预定的（不是玩家自己随意写的）
已经发现的 name 有：

    SRPDefaultUnlit

    // 旧的 names
    Always  
    ForwardBase
    PrepassBase
    Vertex
    VertexLMRGBM
    VertexLM

    Lightweight2D
    Universal2D
    NormalsRendering

    DepthOnly
    UniversalForward
    LightweightForward
    UniversalPipeline

    CustomLit



# ----------------------------------------------#
#               
# ----------------------------------------------#

# ----------------------------------------------#
#               
# ----------------------------------------------#

