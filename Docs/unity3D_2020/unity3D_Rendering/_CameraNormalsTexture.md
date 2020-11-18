# ================================================================//
#                   _CameraNormalsTexture
# ================================================================//
urp 10.0 开始支持 _CameraNormalsTexture


# ----------------------------------------------#
#               如何使用它
# ----------------------------------------------#
首先新建一个 Renderer Feature
    在 AddRenderPasses() 中添加：
    m_ScriptablePass.ConfigureInput( ScriptableRenderPassInput.Normal );

复制一套 Lit shader组文件，
    或者别的已经实现了 DepthNormals pass 的 shader
    在 frag() 中，已经配置好了 InputData 实例 inputData，

inputData.normalizedScreenSpaceUV
    就是 屏幕空间的 uv 坐标值

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"


float3 normalVal = SampleSceneNormals(uv);
    xyz: [-1,1]
    此时返回的是一个 单位向量（分量中存在负值）
    想要显示它，需要做 nm*0.5+0.5 的操作








