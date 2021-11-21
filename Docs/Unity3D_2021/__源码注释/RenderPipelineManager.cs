#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Render Pipeline manager.
    public static class RenderPipelineManager
    {
        //
        // 摘要:
        //     Returns the instance of the current RenderPipeline.
        public static RenderPipeline currentPipeline { get; }

        public static event Action<ScriptableRenderContext, List<Camera>> beginContextRendering;
        public static event Action<ScriptableRenderContext, List<Camera>> endContextRendering;
        public static event Action<ScriptableRenderContext, Camera[]> beginFrameRendering;
        public static event Action<ScriptableRenderContext, Camera> beginCameraRendering;
        public static event Action<ScriptableRenderContext, Camera[]> endFrameRendering;
        public static event Action<ScriptableRenderContext, Camera> endCameraRendering;
    }
}

