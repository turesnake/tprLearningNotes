#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    /*
        Render Pipeline manager.

    */
    public static class RenderPipelineManager//RenderPipelineManager__RR
    {
        /*
            Returns the instance of the current RenderPipeline.
            This property is null until a camera render occurs. This can take up to four calls to Monobehaviour.Update().
            ---
            最多需要调用4次 "Monobehaviour.Update()";
        */
        public static RenderPipeline currentPipeline { get; }

        /*
            ---------------------------------------------------------------------------------------:
            用户实现的 "RenderPipeline" 派生类, 需要实现 "RenderPipeline.Render()" 实现体;
            在这个实现体内部, 起始位置, 会调用一次 "RenderPipeline.BeginContextRendering()",
            这个函数会触发并执行所有 绑定到本委托 的 cakkbacks; 

            urp, hdrp 都在 "Render()" 实现体内, 自动调用了 "BeginContextRendering()"; (可以去查看源码, 了解具体的 触发点;)
            而在你自己实现的 srp 中, 你需要手动调用 "BeginContextRendering()" 来触发这些 callbacks;
            ---
            本委托和下方的 "beginFrameRendering" 是相似的, 区别在于, 本委托不会引发 堆内存分配;(推荐行为)
        */
        public static event Action<ScriptableRenderContext, List<Camera>> beginContextRendering;
        /*
            同上, 在 "Render()" 实现体内, 在调用 "RenderPipeline.BeginContextRendering()" 时, 本委托绑定的 callbacks 被调用;
            ---
            本委托和下方的 "endFrameRendering" 相似, 区别在于, 本委托不会引发 堆内存分配;(推荐行为)
        */
        public static event Action<ScriptableRenderContext, List<Camera>> endContextRendering;

        /*
            ---------------------------------------------------------------------------------------:
            不推荐使用本组委托, 建议改用上方的 "XXXContextRendering" 系列, 本组委托会引发 堆内存分配 (不推荐)
            本组委托的存在是为了向下兼容;
        */
        public static event Action<ScriptableRenderContext, Camera[]> beginFrameRendering;
        public static event Action<ScriptableRenderContext, Camera[]> endFrameRendering;


        /*
            ---------------------------------------------------------------------------------------:
            同 "XXXContextRendering" 系列, 
            在 "Render()" 实现体内, 在调用 "RenderPipeline.BeginCameraRendering()" 时, 本委托绑定的 callbacks 被调用;
            ---
            针对单个 camera 的执行的;
        */
        public static event Action<ScriptableRenderContext, Camera> beginCameraRendering;
        // 同上, 略
        public static event Action<ScriptableRenderContext, Camera> endCameraRendering;
    }
}

