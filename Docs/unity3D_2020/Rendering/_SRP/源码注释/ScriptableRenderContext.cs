
// ScriptableRenderContext 
// 简略笔记

#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using Unity.Collections;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Defines state and drawing commands that custom render pipelines use.
    [NativeHeaderAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
    [NativeHeaderAttribute("Modules/UI/Canvas.h")]
    [NativeHeaderAttribute("Modules/UI/CanvasManager.h")]
    [NativeTypeAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
    public struct ScriptableRenderContext : IEquatable<ScriptableRenderContext>
    {
        //
        // 摘要:
        //     Emits UI geometry for rendering for the specified camera.
        //
        // 参数:
        //   camera:
        //     Camera to emit the geometry for.
        [FreeFunctionAttribute("UI::GetCanvasManager().EmitGeometryForCamera")]
        public static void EmitGeometryForCamera(Camera camera);
        //
        // 摘要:
        //     Emits UI geometry into the Scene view for rendering.
        //
        // 参数:
        //   cullingCamera:
        //     Camera to emit the geometry for.
        [FreeFunctionAttribute("UI::GetCanvasManager().EmitWorldGeometryForSceneView")]
        public static void EmitWorldGeometryForSceneView(Camera cullingCamera);
        public void BeginRenderPass(int width, int height, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1);
        public ScopedRenderPass BeginScopedRenderPass(int width, int height, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1);
        public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, bool isDepthStencilReadOnly = false);
        public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, bool isDepthReadOnly, bool isStencilReadOnly);
        public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthReadOnly, bool isStencilReadOnly);
        public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthStencilReadOnly = false);
        public void BeginSubPass(NativeArray<int> colors, bool isDepthReadOnly, bool isStencilReadOnly);
        public void BeginSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthStencilReadOnly = false);
        public void BeginSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthReadOnly, bool isStencilReadOnly);
        public void BeginSubPass(NativeArray<int> colors, bool isDepthStencilReadOnly = false);
        public CullingResults Cull(ref ScriptableCullingParameters parameters);
        //
        // 摘要:
        //     Schedules the drawing of a subset of Gizmos (before or after post-processing)
        //     for the given Camera.
        //
        // 参数:
        //   camera:
        //     The camera of the current view.
        //
        //   gizmoSubset:
        //     Set to GizmoSubset.PreImageEffects to draw Gizmos that should be affected by
        //     postprocessing, or GizmoSubset.PostImageEffects to draw Gizmos that should not
        //     be affected by postprocessing. See also: GizmoSubset.
        public void DrawGizmos(Camera camera, GizmoSubset gizmoSubset);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, NativeArray<ShaderTagId> renderTypes, NativeArray<RenderStateBlock> stateBlocks);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock stateBlock);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, NativeArray<ShaderTagId> tagValues, NativeArray<RenderStateBlock> stateBlocks);
        public void DrawShadows(ref ShadowDrawingSettings settings);
        //
        // 摘要:
        //     Schedules the drawing of the skybox.
        //
        // 参数:
        //   camera:
        //     Camera to draw the skybox for.
        public void DrawSkybox(Camera camera);
        //
        // 摘要:
        //     Draw the UI overlay.
        //
        // 参数:
        //   camera:
        //     The camera of the current view.
        public void DrawUIOverlay(Camera camera);
        //
        // 摘要:
        //     Schedules the drawing of a wireframe overlay for a given Scene view Camera.
        //
        // 参数:
        //   camera:
        //     The Scene view Camera to draw the overlay for.
        public void DrawWireOverlay(Camera camera);
        //
        // 摘要:
        //     Schedules the end of a currently active render pass.
        public void EndRenderPass();
        //
        // 摘要:
        //     Schedules the end of the currently active sub pass.
        public void EndSubPass();
        public bool Equals(ScriptableRenderContext other);
        public override bool Equals(object obj);

        //
        // 摘要:
        //     Schedules the execution of a custom graphics Command Buffer. 

        // 安排 commandbuffer 的 执行(而不是现在就执行)

        // 在调用此函数时, context 将 commandbuffer的参数 注册到自己的 内部指令列表中,
        // 这些 command 的执行(包含 custom cb),实际在 ScriptableRenderContext.Submit 被调用期间执行

        // 若在 commandbuffer 中定义了 管线的一些属性,而这些属性会影响到 draw call,
        // 则要确保在 调用其他 context method 之前(如:DrawRenderers, DrawShadows),先调用本函数 
 
        // 参数:
        //   commandBuffer:
        //     Specifies the Command Buffer to execute.
        public void ExecuteCommandBuffer(CommandBuffer commandBuffer);
        //
        // 摘要:
        //     Schedules the execution of a Command Buffer on an async compute queue. The ComputeQueueType
        //     that you pass in determines the queue order.
        //
        // 参数:
        //   commandBuffer:
        //     The CommandBuffer to be executed.
        //
        //   queueType:
        //     Describes the desired async compute queue the supplied CommandBuffer should be
        //     executed on.
        public void ExecuteCommandBufferAsync(CommandBuffer commandBuffer, ComputeQueueType queueType);
        public override int GetHashCode();
        //
        // 摘要:
        //     Schedules an invocation of the OnRenderObject callback for MonoBehaviour scripts.
        public void InvokeOnRenderObjectCallback();
        //
        // 摘要:
        //     Schedules the setup of Camera specific global Shader variables.
        //
        // 参数:
        //   camera:
        //     Camera to setup shader variables for.
        //
        //   stereoSetup:
        //     Set up the stereo shader variables and state.
        //
        //   eye:
        //     The current eye to be rendered.
        public void SetupCameraProperties(Camera camera, bool stereoSetup, int eye);
        //
        // 摘要:
        //     Schedules the setup of Camera specific global Shader variables.
        //
        // 参数:
        //   camera:
        //     Camera to setup shader variables for.
        //
        //   stereoSetup:
        //     Set up the stereo shader variables and state.
        //
        //   eye:
        //     The current eye to be rendered.
        public void SetupCameraProperties(Camera camera, bool stereoSetup = false);
        //
        // 摘要:
        //     Schedules a fine-grained beginning of stereo rendering on the ScriptableRenderContext.
        //
        // 参数:
        //   camera:
        //     Camera to enable stereo rendering on.
        //
        //   eye:
        //     The current eye to be rendered.
        public void StartMultiEye(Camera camera);
        //
        // 摘要:
        //     Schedules a fine-grained beginning of stereo rendering on the ScriptableRenderContext.
        //
        // 参数:
        //   camera:
        //     Camera to enable stereo rendering on.
        //
        //   eye:
        //     The current eye to be rendered.
        public void StartMultiEye(Camera camera, int eye);
        //
        // 摘要:
        //     Schedule notification of completion of stereo rendering on a single frame.
        //
        // 参数:
        //   camera:
        //     Camera to indicate completion of stereo rendering.
        //
        //   eye:
        //     The current eye to be rendered.
        //
        //   isFinalPass:
        public void StereoEndRender(Camera camera, int eye);
        //
        // 摘要:
        //     Schedule notification of completion of stereo rendering on a single frame.
        //
        // 参数:
        //   camera:
        //     Camera to indicate completion of stereo rendering.
        //
        //   eye:
        //     The current eye to be rendered.
        //
        //   isFinalPass:
        public void StereoEndRender(Camera camera);
        //
        // 摘要:
        //     Schedule notification of completion of stereo rendering on a single frame.
        //
        // 参数:
        //   camera:
        //     Camera to indicate completion of stereo rendering.
        //
        //   eye:
        //     The current eye to be rendered.
        //
        //   isFinalPass:
        public void StereoEndRender(Camera camera, int eye, bool isFinalPass);
        //
        // 摘要:
        //     Schedules a stop of stereo rendering on the ScriptableRenderContext.
        //
        // 参数:
        //   camera:
        //     Camera to disable stereo rendering on.
        public void StopMultiEye(Camera camera);
        
        //
        // 摘要:
        //     Submits all the scheduled commands to the rendering loop for execution.
        public void Submit();

        public static bool operator ==(ScriptableRenderContext left, ScriptableRenderContext right);
        public static bool operator !=(ScriptableRenderContext left, ScriptableRenderContext right);
    }
}