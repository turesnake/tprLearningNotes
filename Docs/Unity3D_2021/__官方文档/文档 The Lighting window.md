# ================================================================ #
#        The Lighting window
# ================================================================ #


... 未翻译...


# ================================ #
#  The Environment tab
# ================================ #

# Built-in Render Pipeline and Universal Render Pipeline
在这两个管线中, Lighting - Environment 窗口中显示的内容是相同的: 共分为两部分:
- Environment
- Other settings

# ------------------------------ #
# Environment

包含类似 skybox, diffuse lighting 和 reflection 之类的信息;

# Skybox Material
    ...

# Sun Source
    ...
    若设为 None, 场景中亮度最大的 平行光 就会被自动选中;
    Render Mode 被设为 Not Important 的光源将不参与此选择; 

# Realtime Shadow Color
    在 Subtractive Lighting Mode 中, unity 用来渲染 实时阴影 的 颜色;

    Subtractive 模式已在另一个文件中翻译; 简单讲, 它是一种非常简陋的 全局光照方案, 它把 lightmap 和 shadowmap 合并成了一张图;

# ==== Environment Lighting =======:
这一块用来控制 Ambient light;

# Source:
    ambient light 的源头:
    -- Skybox
    -- Gradient
    -- Color

# Intensity Multiplier: (面板中第一个)
    设置 ambient light 的亮度; 区间为 [0,8]
    默认值为 1;
    ---
    改写此值 需要重渲染 lightmap 等烘焙信息;

# ==== Environment Reflections =======:
此段包含 "反射探针的烘培的 全局设置", 已经影响 "全局反射" 的设置;

# Source:
    -- Skybox:
        选择 skybox 为反射源;
    -- Custom:
        选择一个 自定义的 cubemap 作为反射源;

# Resolution:
    当上方的 Source 选择为 Skybox 时, 设置其 cubemap
    的分辨率;

# Compression:
    存储反射信息的 texture 是否被压缩;
    默认选择 Auto;
    即: 如果 compression format is suitable, 就压缩;

# Intensity Multiplier: (面板中第二个)
    反射源在 反射接收体 上可见的程度。
    ---
    改写此值 不会重渲染 lightmap 等烘焙信息;

# Bounces:
    ...
    若设为 1, then Unity only takes the initial reflection (from the skybox or cube map specified in the Reflection Source property) into account.


... 暂未翻译 ...



















































