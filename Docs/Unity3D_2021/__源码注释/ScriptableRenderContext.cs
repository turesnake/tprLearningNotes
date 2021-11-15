#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using Unity.Collections;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Defines state and drawing commands that custom render pipelines use.
        ---

        简称 "context"

        它在  “客户端脚本代码” 和 “unity底层图形代码（可能为c++）” 之间做连接。
        使用此 context API 来 调度和执行 渲染指令。


        当你定义了一个 自定义渲染管线, 可使用本类实例来 schedule and submit state updates and drawing commands to the GPU.

        在一个 RenderPipeline.Render() callback 函数内, 针对每个 camera, 可先后执行
        -- culls objects that the render pipeline doesn't need to render (see CullingResults)
        -- 调用数次 ScriptableRenderContext.DrawRenderers() 以及 ScriptableRenderContext.ExecuteCommandBuffer(),
            用来: 
            set up global Shader properties
            change render targets
            dispatch compute shaders
            other rendering tasks
        -- 调用 ScriptableRenderContext.Submit() 真的要求执行以上命令;


        NativeHeaderAttribute: 感觉像是声明了 原生c++代码的 头文件...
    */
    [NativeHeaderAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
    [NativeHeaderAttribute("Modules/UI/Canvas.h")]
    [NativeHeaderAttribute("Modules/UI/CanvasManager.h")]
    [NativeTypeAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
    public struct ScriptableRenderContext : IEquatable<ScriptableRenderContext>
    {

        // 摘要:
        //     Emits(发射) UI geometry for rendering for the specified camera.
        //
        // 参数:
        //   camera:
        //     Camera to emit the geometry for.
        [FreeFunctionAttribute("UI::GetCanvasManager().EmitGeometryForCamera")]
        public static void EmitGeometryForCamera(Camera camera);

        
        // 摘要:
        //     Emits UI geometry into the Scene view for rendering.
        //
        // 参数:
        //   cullingCamera:
        //     Camera to emit the geometry for.
        [FreeFunctionAttribute("UI::GetCanvasManager().EmitWorldGeometryForSceneView")]
        public static void EmitWorldGeometryForSceneView(Camera cullingCamera);



        /*
            Schedules the beginning of a new render pass. Only one render pass can be active at any time.

            按照文档描述, render pass 非常适合用来实现 延迟渲染;
            且文档给出了一个 详细的使用 代码案例;

            ------
            render pass 提供了一种在 srp 的上下文中 切换 render target 的新方法;

            和 SetRenderTargets 函数相反, render pass 指定了一次渲染的 明确开始和结束点;
            同时还显式 load/store actions on the rendering surfaces.

            还可以在同一个 render pass 中, 运行数个 subpasses, 此时, frag shader 可以读取当前 render pass 中的 pix 值;
            这允许在 tile-based GPUs 上高效实现数种 渲染方法, 比如 延迟渲染;

            Render passes are natively implemented on Metal (iOS) and Vulkan, 
            但是通过 仿真(emulation), 此API 可在几乎所有 渲染后端上 运行;
            (using legacy SetRenderTargets calls and reading the current pixel values via texel fetches).

            render pass 有以下限制:
            -- 所有的 attachments (附件) 必须拥有相同的 分辨率 和 MSAA 采样数量
            -- 前面的 subpasses 的渲染结果, 尽在同一个 screen-space pix coord 之内可访问,
                通过 shader 中的 UNITY_READ_FRAMEBUFFER_INPUT(x) 宏;
                在 render pass 结束之前，attachments 不能绑定为 texture 或以其他方式;

            - iOS Metal does not allow reading from the Z-Buffer, 
                so an additional render target is needed to work around that

            - The maximum amount of attachments allowed per render pass is currently 8 + depth, 
                but note that various GPUs may have stricter limits.


            参数:
            width / height:
                The width / height of the render pass surfaces in pixels.

            samples:
                MSAA sample count; set to 1 to disable antialiasing.

            attachments:
                Array of color attachments to use within this render pass. 
                The values in the array are copied immediately.

            depthAttachmentIndex:
                The index of the attachment to be used as the depth/stencil buffer 
                for this render pass, or -1 to disable depth/stencil.

        */
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



        /*

        
        */
        public CullingResults Cull(ref ScriptableCullingParameters parameters);
        
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
        
        /*
            摘要:
                Schedules the drawing of the skybox.
            参数:
            camera: 
                Camera to draw the skybox for. 
                根据 camera.ClearFlag 来决定本函数具体绘制什么;
                但并不通过此参数来判断 skybox 的绘制方向; 
                ---
                想要设置这个 观察天空的方向, 必须先设置 view-matrix:
                    context.SetupCameraProperties(camera);
        */
        public void DrawSkybox(Camera camera);
        
        // 摘要:
        //     Draw the UI overlay.
        //
        // 参数:
        //   camera:
        //     The camera of the current view.
        public void DrawUIOverlay(Camera camera);
        
        // 摘要:
        //     Schedules the drawing of a wireframe overlay for a given Scene view Camera.
        //
        // 参数:
        //   camera:
        //     The Scene view Camera to draw the overlay for.
        public void DrawWireOverlay(Camera camera);
        
        // 摘要:
        //     Schedules the end of a currently active render pass.
        public void EndRenderPass();
        
        // 摘要:
        //     Schedules the end of the currently active sub pass.
        public void EndSubPass();

        public bool Equals(ScriptableRenderContext other);
        public override bool Equals(object obj);

        /*
            摘要:
                Schedules the execution of a custom graphics Command Buffer. 
                安排 commandbuffer 的 执行(而不是现在就执行)

            在调用此函数时, context 将 commandbuffer的参数 注册到自己的 内部指令列表中,
            这些 command 的执行(包含 custom cb),实际在 ScriptableRenderContext.Submit 被调用期间执行

            若在 commandbuffer 中定义了 管线的一些属性,而这些属性会影响到 draw call,
            则要确保在 调用其他 context method 之前(如:DrawRenderers, DrawShadows),先调用本函数 
 
            参数:
                commandBuffer: Specifies the Command Buffer to execute.
        */
        public void ExecuteCommandBuffer(CommandBuffer commandBuffer);
        
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
        
        // 摘要:
        //     Schedules an invocation of the OnRenderObject callback for MonoBehaviour scripts.
        public void InvokeOnRenderObjectCallback();
        

        /*
            摘要:
                Schedules the setup of Camera specific global Shader variables.
                将 camera 的 specific global shader variables (如 unity_MatrixVP 等信息) 传递给 context
                ---
                因为 camera 内部只有一个顶点, 所以猜测省略了 OS->WS 这层转换;
                直接使用 unity_MatrixVP 矩阵就能得到 camera 在 CS 中的状态;
                所以, 此矩阵包含了 camera 的 坐标, 朝向, 视锥体 等信息

            参数:
            camera:
                Camera to setup shader variables for.
            stereoSetup:
                Set up the stereo shader variables and state.
                不是 vr 直接使用第二种函数重载
            eye:
                The current eye to be rendered.
                仅用于 vr
        */
        public void SetupCameraProperties(Camera camera, bool stereoSetup, int eye);
        public void SetupCameraProperties(Camera camera, bool stereoSetup = false);

        
        // 摘要:
        //     Schedules a fine-grained (细粒度) beginning of stereo rendering on the ScriptableRenderContext.
        // 参数:
        //   camera:
        //     Camera to enable stereo rendering on.
        //
        //   eye:
        //     The current eye to be rendered.
        public void StartMultiEye(Camera camera);
        
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
        
        // 摘要:
        //     Schedules a stop of stereo rendering on the ScriptableRenderContext.
        //
        // 参数:
        //   camera:
        //     Camera to disable stereo rendering on.
        public void StopMultiEye(Camera camera);
        
        /*
            摘要:
               Submits all the scheduled commands to the rendering loop for execution.
               真正的 "提交" commands
        */
        public void Submit();

        public static bool operator ==(ScriptableRenderContext left, ScriptableRenderContext right);
        public static bool operator !=(ScriptableRenderContext left, ScriptableRenderContext right);
    }
}