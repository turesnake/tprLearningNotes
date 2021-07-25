// LightEvent
// 简略笔记 

// 用于 built-in 管线 Light.AddCommandBuffer() 中。
// 代表的是 built-in 管线中，能将 commandbuffer 插入的 时间点

// 由此可观察 built-in 管线的 渲染流程



#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Defines a place in light's rendering to attach Rendering.CommandBuffer objects
    //     to.
    public enum LightEvent
    {
        //
        // 摘要:
        //     Before shadowmap is rendered.
        BeforeShadowMap = 0,
        //
        // 摘要:
        //     After shadowmap is rendered.
        AfterShadowMap = 1,
        //
        // 摘要:
        //     Before directional light screenspace shadow mask is computed.
        BeforeScreenspaceMask = 2,
        //
        // 摘要:
        //     After directional light screenspace shadow mask is computed.
        AfterScreenspaceMask = 3,
        //
        // 摘要:
        //     Before shadowmap pass is rendered.
        BeforeShadowMapPass = 4,
        //
        // 摘要:
        //     After shadowmap pass is rendered.
        AfterShadowMapPass = 5
    }
}