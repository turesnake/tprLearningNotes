# ================================================================//
#                  ScriptableRenderPass
# ================================================================//
基于 urp.10.1.0


# Render Texture
    在运行时动态创建和填充的 texture
    可以作为 render 的 target 来使用
    可以指挥一个 camera，将渲染的内容，写入这个 rt
    然后在后续流程中，像使用常规 texture 一样去使用这个 rt
    ---
    可以在 Asserts 面板手动创建一个实例：
        Create - Render Texture 

# RenderTargetIdentifier
    Identifies a RenderTexture for a CommandBuffer.

    rt 可以有数种方法来  identified
    如 rt obj，BuiltinRenderTextureType，
    或 a temporary render texture with a name

    本class 用来 identify 这些 rt，且提供一些通用化操作，比如 比较是否相同 等等

# RenderTargetHandle
    URP对RenderTargetIdentifier的一个封装
    自动生成-保存 propertyID， 避免多次 hash 计算
    真正用rt的时候，才会创建RenderTargetIdentifier

    static readonly RenderTargetHandle CameraTarget;
        当前 camera 默认 render tgt

    void Init(string shaderProperty);
        输入 rt name，本class 自动生成其 propertyID，并缓存起来

    RenderTargetIdentifier Identifier();
        为 ConfigureTarget 提供目标参数时, 可以作为参数使用.

# ScriptableRendererFeature
    在 Asserts 面板，可以直接创建一个实例模版：
        Create - Rendering - U..R..P.. - Renderer Feature
    我们只需在这个 模版基础上，拓展自己的 内容即可


# RenderTextureDescriptor [struct]
    This struct contains all the information required to create a RenderTexture. 
    It can be copied, cached, and reused to easily create RenderTextures 
    that all share the same properties.


# ScriptableRenderer 
    implements a rendering strategy. 
    It describes how culling and lighting works and the effects supported.

    .cameraColorTarget
    .cameraDepthTarget
    从 urp.10.0 起:
    It's only valid to call cameraColorTarget in the scope of ScriptableRenderPass
    Otherwise the pipeline camera target texture might have not been created 
    or might have already been disposed.


# RenderingData




# ----------------------------------------------#
#    ScriptableRenderer.cameraColorTarget
#    ScriptableRenderer.cameraDepthTarget
# ----------------------------------------------#
这是两个 properties
它们必须在 Pass 的几个 指定的 methods 中调用，否则：
    You can only call cameraColorTarget inside the scope of a ScriptableRenderPass. 
    Otherwise the pipeline camera target texture might have not been created 
    or might have already been disposed.

为了解决这一点，可以把 ScriptableRenderer 的 ref
暂存在 pass 实例的 变量中
然后在类似：
    Configure
    OnCameraSetup
函数中调用


# ----------------------------------------------#
#               Blit
# ----------------------------------------------#
Add a blit command to the context for execution. 
This changes the active render target in the ScriptableRenderer to destination.
（ 将 renderer 的 active render target 设置为 dst ）

# Blit( cmd, src, dst );
    仅将一块数据，从 src，传输到 dst 中
    不做任何处理

# Blit( cmd, src, dst, mat, passIdx );
    将一块数据，从 src，传输到 dst 中
    同时调用 参数传入的 mat.shader.pass
    用它来处理数据


# ----------------------------------------------#
#          
# ----------------------------------------------#

