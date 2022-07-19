#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        Shader pass type for Unity's lighting pipeline.
        This corresponds to "LightMode" tag in the shader pass, see Pass tags.

        这些类型 感觉和 光照类型 有关

    */
    public enum PassType
    {
        //
        // 摘要:
        //     Regular shader pass that does not interact with lighting.
        Normal = 0,
        //
        // 摘要:
        //     Legacy vertex-lit shader pass.
        Vertex = 1,
        //
        // 摘要:
        //     Legacy vertex-lit shader pass, with mobile lightmaps.
        VertexLM = 2,
        //
        // 摘要:
        //     Legacy vertex-lit shader pass, with desktop (RGBM) lightmaps.
        VertexLMRGBM = 3,
        //
        // 摘要:
        //     Forward rendering base pass.
        ForwardBase = 4,
        //
        // 摘要:
        //     Forward rendering additive pixel light pass.
        ForwardAdd = 5,
        //
        // 摘要:
        //     Legacy deferred lighting (light pre-pass) base pass.
        LightPrePassBase = 6,
        //
        // 摘要:
        //     Legacy deferred lighting (light pre-pass) final pass.
        LightPrePassFinal = 7,
        //
        // 摘要:
        //     Shadow caster & depth texure shader pass.
        ShadowCaster = 8,
        //
        // 摘要:
        //     Deferred Shading shader pass.
        Deferred = 10,
        //
        // 摘要:
        //     Shader pass used to generate the albedo and emissive values used as input to
        //     lightmapping.
        Meta = 11,
        //
        // 摘要:
        //     Motion vector render pass.
        MotionVectors = 12,
        //
        // 摘要:
        //     Custom scriptable pipeline.
        ScriptableRenderPipeline = 13,
        //
        // 摘要:
        //     Custom scriptable pipeline when lightmode is set to default unlit or no light
        //     mode is set.
        ScriptableRenderPipelineDefaultUnlit = 14
    }
}

