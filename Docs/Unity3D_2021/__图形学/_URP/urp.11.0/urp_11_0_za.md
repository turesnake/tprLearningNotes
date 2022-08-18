# ================================================================ #
#                URP 11.0 za
# ================================================================ #


# ---------------------------------- #
#   RenderPipelineAsset 实例是谁
访问: "UniversalRenderPipelineAsset" class, 全局唯一的 "RenderPipelineAsset" 派生类

# ---------------------------------- #
#   RenderPipeline  实例是谁
访问: "UniversalRenderPipeline" class, 全局唯一的 "RenderPipeline" 派生类

# ---------------------------------- #
#   RenderPipelineAsset 窗口的编辑界面由谁控制:

class UniversalRenderPipelineAssetEditor;


# ---------------------------------- #
#   material inspector 窗口由谁来布局 ?
如果绑定的是 Lit shader, 那么可访问 "LitGUI" class, 它负责此工作;


# ---------------------------------- #
# asset
位于:
UniversalRenderPipeline__RR_2 中
是个 static property;



# ---------------------------------- #
#  screen space shadow

"UniversalRenderPipeline.InitializeShadowData()" 的官方注释中明确表示,
urp 不再使用 screen space shadow;

同时在 "ShadowData" struct 的注释中也明确表示:
    this feature was replaced by new 'ScreenSpaceShadows' renderer feature"


# ---------------------------------- #
#   "offscreen"
有点迷, 先收集有限的信息:

# -1- "ForwardRenderer.Setup()" 中:
    此处的意思为:
        如果 camera 指定了 render target, 而不是直接渲染进 screen, 就叫做 "offscreen"



# ---------------------------------- #
#   GetShadowTransform()
和 catlike 中的 "ConvertToAtlasMatrix()" 存在一点出入,
缺少了一步运算, 这一步运算, 在 urp 中, 最后是怎么补上的 ?


# ---------------------------------- #
#     "depth surface"
一般指 color render texture 的 depth 部分; 




# ======================================== #
#   曲线信息 如何被传入 shader  ?
# ======================================== #
参考: class TextureCurve;

它能将一个 curve 转换为一个 texture2d (w=128,h=1),
将曲线图的 x轴[0,1] 区间均匀分为 128份,
每个节点计算自己的 y轴值, 存入对用的 texel.r 通道;

到了 shader 中对这个 texture 做插值即可;







# ======================================== #
#    urp 中出现的 通用算法
# ======================================== #

# AdditionalLightsShadowCasterPass.InsertionSort();
双指针算法




# ======================================== #
#  迷一样的 "BuiltinRenderTextureType.CameraTarget"
# ======================================== #
信息很零散:

# --- 如果 一个 depth Attachment 表明自己绑定的是 "BuiltinRenderTextureType.CameraTarget",
往往说明, depth 会被存储在 color rt 的 "depth surface" 区域中;



# ======================================== #
#   depth prepass 和 depth copy
#   "_CameraDepthAttachment" 和 "_CameraDepthTexture"
#   "_CameraDepthAttachment" 和 "_CameraOpaqueTexture"
# ======================================== #


# 前置注意:
#   在 12.6 中发现 copy depth pass (copydepth) 可在某些情况下, 放在 trnasparents 之后执行.....


# 何时使用 depth prepass: (requiresDepthPrepass)
    && camra or asset 需要 depth texture, 但环境(平台+camera) 又不支持 depth copy 操作;
    ||  若 camera 被用于  editor: scene 窗口, 或 预览窗口;
    ||  存在某个 render pass, 它在 "渲染不透明物" 之前被执行, 同时它需要 depth 或 normal texture 作为 input;
    ||  存在某个 render pass, 需要提前计算好 normal texture 当作 input;

# createDepthTexture 成立条件:
    && camra or asset 需要 depth texture, 且没有使用 depth preapss;
    || 当前 camera 是 base, 且不属于 stack 中最后一个;
    || 是延迟渲染

# 何时使用 depth copy pass: (requiresDepthCopyPass)
    (大致表达)
    && camra or asset 需要 depth texture
    && 但没有使用 depth prepass;


# "_CameraDepthAttachment":   (depth 数据临时存放处)
    这是一个 render texture;

    如果一个 ForwardRenderer 启用了 createDepthTexture (查看上文成立条件),
    那么 renderer 会将 "_CameraDepthAttachment" 设为默认的 depth 数据 render target;

    一些主 render pass, 比如: 
        RenderOpaqueForwardPass, 
        DrawSkyboxPass,
    会将自己生成的 depth 数据写入 "_CameraDepthAttachment" 中;
    (这些 render pass 不会定义自己的 render target, 而是沿用 renderer 的配置)
    ---
    然后会执行 depth copy pass, 将本 rt 的数据, 复制到 "_CameraDepthTexture" 中;
    ---
    最后, 本 rt 一般不会被 后续的 pass 直接访问;


# "_CameraDepthTexture":   (最终的 depth texture)
    这是一个 render texture:

    创建方式:
    -1- depth prepass 可以一步到位生成它;
    -2- 在渲染完 skybox 之后, 
        depth copy pass 会把已经生成好的 depth 数据. 
        从 "_CameraDepthAttachment" 复制进 "_CameraDepthTexture";

    之后的所有 pass, 都能使用本 rt 中的 depth 数据;
    ---
    如果 depth prepass 和 depth copy pass 都未执行,
    那么 base camera 会主动创建一个 "_CameraDepthTexture", 并写上默认值: "far plane val"
    (这个值具体是 0 还是 1, 视平台而定)
    


# createColorTexture 成立条件:
    && 存在 renderFeature, 且没有 Hololens
    && 不是预览窗口
    || 需要创建 "intermediate color render texture"
    || 存在某个 render pass, 需要提前计算好 color texture 当作 input;



# "_CameraDepthAttachment" (opaque color 数据临时存放处)
# "_CameraOpaqueTexture"   (最终的 opaque color texture)
    和上面那对 depth rt 关系类似;
    ---
    唯一的不同时, 中间态 opaque color 数据不一定会被写入 "_CameraDepthAttachment",
    也可能写入默认的 "BuiltinRenderTextureType.CameraTarget",
    但最终一定会被复制进 "_CameraOpaqueTexture";


# "_CameraColorAttachmentA" , "_CameraColorAttachmentB"
这是在 12.1 版中, 代替原来的 "_CameraOpaqueTexture" (或另一个... 未考证...)

这组 rt 由 class RenderTargetBufferSystem 维护;




# ======================================== #
#  最复杂的函数: ScriptableRenderer.SetRenderPassAttachments()
# ======================================== #
一个难点是 clear flags, 非常复杂




# ======================================== #
#      render passes 执行时刻
# ======================================== #

# BeforeRendering = 0,

# BeforeRenderingShadows = 50,
                                        m_MainLightShadowCasterPass
                                        m_AdditionalLightsShadowCasterPass

# AfterRenderingShadows = 100,

------------------------------------------------------------------------------------

# BeforeRenderingPrePasses = 150,
                                        m_DepthPrepass          
                                        m_DepthNormalPrepass
                                        colorGradingLutPass
                                            内部含有后处理:
                                                ChannelMixer
                                                ColorAdjustments
                                                ColorCurves
                                                LiftGammaGain
                                                ShadowsMidtonesHighlights
                                                SplitToning
                                                Tonemapping   ?
                                                WhiteBalance

# AfterRenderingPrePasses = 200,

# BeforeRenderingOpaques = 250,
                                        m_RenderOpaqueForwardPass

# AfterRenderingOpaques = 300,

------------------------------------------------------------------------------------

# BeforeRenderingSkybox = 350,
                                        m_DrawSkyboxPass

# AfterRenderingSkybox = 400,
                                        m_CopyDepthPass
                                        m_CopyColorPass

# BeforeRenderingTransparents = 450,
                                        m_TransparentSettingsPass
                                        m_RenderTransparentForwardPass

# AfterRenderingTransparents = 500,

# BeforeRenderingPostProcessing = 550,
                                        m_OnRenderObjectCallbackPass
                                        postProcessPass

                                            内部含有后处理:
                                                SMAA
                                                DepthOfField
                                                MotionBlur
                                                PaniniProjection
                                                Bloom
                                                LensDistortion
                                                ChromaticAberration
                                                Vignette
                                                ColorLookup
                                                ColorAdjustments ?
                                                Tonemapping      ?
                                                FilmGrain        ?



# AfterRenderingPostProcessing = 600,

------------------------------------------------------------------------------------

# AfterRendering = 1000,
                                        m_CapturePass (忽略此功能)

                                        +1:
                                            finalPostProcessPass
                                                内部含有 AA: FXAA

                                            m_FinalBlitPass

                                                触发条件:
                                                    stack 中全体 camera 的 "后处理" 都关掉





# ======================================== #
#    bug:
#        SampleSceneNormals()
#        _CameraNormalsTexture
# ======================================== #

float3 SampleSceneNormals(float2 uv)

在 mac 中存在问题, 具体查看源码处注解;










