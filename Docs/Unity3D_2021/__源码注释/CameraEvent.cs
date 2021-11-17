
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Defines a place in camera's rendering to attach Rendering.CommandBuffer objects to.

        用于 built-in 管线 Camera.AddCommandBuffer() 中。
        代表的是 built-in 管线中，能将 commandbuffer 插入的 时间点

        由此可观察 built-in 管线的 渲染流程

    */
    public enum CameraEvent
    {
        //
        // 摘要:
        //     Before camera's depth texture is generated.
        BeforeDepthTexture = 0,
        //
        // 摘要:
        //     After camera's depth texture is generated.
        AfterDepthTexture = 1,
        //
        // 摘要:
        //     Before camera's depth+normals texture is generated.
        BeforeDepthNormalsTexture = 2,
        //
        // 摘要:
        //     After camera's depth+normals texture is generated.
        AfterDepthNormalsTexture = 3,
        //
        // 摘要:
        //     Before deferred rendering G-buffer is rendered.
        BeforeGBuffer = 4,
        //
        // 摘要:
        //     After deferred rendering G-buffer is rendered.
        AfterGBuffer = 5,
        //
        // 摘要:
        //     Before lighting pass in deferred rendering.
        BeforeLighting = 6,
        //
        // 摘要:
        //     After lighting pass in deferred rendering.
        AfterLighting = 7,
        //
        // 摘要:
        //     Before final geometry pass in deferred lighting.
        BeforeFinalPass = 8,
        //
        // 摘要:
        //     After final geometry pass in deferred lighting.
        AfterFinalPass = 9,
        //
        // 摘要:
        //     Before opaque objects in forward rendering.
        BeforeForwardOpaque = 10,
        //
        // 摘要:
        //     After opaque objects in forward rendering.
        AfterForwardOpaque = 11,
        //
        // 摘要:
        //     Before image effects that happen between opaque & transparent objects.
        BeforeImageEffectsOpaque = 12,
        //
        // 摘要:
        //     After image effects that happen between opaque & transparent objects.
        AfterImageEffectsOpaque = 13,
        //
        // 摘要:
        //     Before skybox is drawn.
        BeforeSkybox = 14,
        //
        // 摘要:
        //     After skybox is drawn.
        AfterSkybox = 15,
        //
        // 摘要:
        //     Before transparent objects in forward rendering.
        BeforeForwardAlpha = 16,
        //
        // 摘要:
        //     After transparent objects in forward rendering.
        AfterForwardAlpha = 17,
        //
        // 摘要:
        //     Before image effects.
        BeforeImageEffects = 18,
        //
        // 摘要:
        //     After image effects.
        AfterImageEffects = 19,
        //
        // 摘要:
        //     After camera has done rendering everything.
        AfterEverything = 20,
        //
        // 摘要:
        //     Before reflections pass in deferred rendering.
        BeforeReflections = 21,
        //
        // 摘要:
        //     After reflections pass in deferred rendering.
        AfterReflections = 22,
        //
        // 摘要:
        //     Before halo and lens flares.
        BeforeHaloAndLensFlares = 23,
        //
        // 摘要:
        //     After halo and lens flares.
        AfterHaloAndLensFlares = 24
    }
}