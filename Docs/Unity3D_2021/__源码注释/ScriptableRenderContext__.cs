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


        在你的自定义渲染管线, 使用本类实例来 schedule and submit "state updates" and "drawing commands" to the GPU.

        在一个 RenderPipeline.Render() callback 函数内, 针对每个 camera, 可先后执行
        -- culls objects that the render pipeline doesn't need to render (see CullingResults)
        -- 调用数次 ScriptableRenderContext.DrawRenderers() 以及 ScriptableRenderContext.ExecuteCommandBuffer(),
            用来: 
            set up global Shader properties
            change render targets
            dispatch compute shaders
            other rendering tasks
        -- 调用 ScriptableRenderContext.Submit() 真的要求执行以上命令;
        =======

        [NativeHeaderAttribute]: 感觉像是声明了 原生c++代码的 头文件...
    */
    [NativeHeaderAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
    [NativeHeaderAttribute("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
    [NativeHeaderAttribute("Modules/UI/Canvas.h")]
    [NativeHeaderAttribute("Modules/UI/CanvasManager.h")]
    [NativeTypeAttribute("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
    public struct ScriptableRenderContext /*ScriptableRenderContext__*/
        : IEquatable<ScriptableRenderContext>
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

            未在 urp, hdrp, catlike srp 中看到此函数被使用;

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
        public void BeginRenderPass(
            int width, int height, 
            int samples, 
            NativeArray<AttachmentDescriptor> attachments, 
            int depthAttachmentIndex = -1
        );
        
        
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
            执行真正的 camera Cull 操作;
            并返回: 可见对象: 物体, 光源, 反射探针; 这些信息被整合为一个 CullingResults 实例;

            Culling results 和本类实例 "context" 是相互绑定的;
            一旦此次 render loop 结束, 存储 Culling results 的内存也将得到释放;

            参数:
            parameters
                Parameters for culling.
                由于这是一个 struct, 直接当参数传入会引发 复制, 所以最好选择 ref 方式传入
        */
        public CullingResults Cull(ref ScriptableCullingParameters parameters);
        


        /*
            摘要:
            Schedules the drawing of a subset of Gizmos (before or after post-processing) for the given Camera.
            绘制 Gizmos 中的一部分;
            
            参数:
            camera:
                The camera of the current view.
            
            gizmoSubset:
                enum:
                -- PreImageEffects:
                        draw Gizmos that should be affected by postprocessing;
                        should be rendered before ImageEffects.
                -- PostImageEffects:
                        draw Gizmos that should not be affected by postprocessing.
                        should be rendered after ImageEffects.
        */
        public void DrawGizmos(Camera camera, GizmoSubset gizmoSubset);



        /*
            Schedules the drawing of a set of visible objects, and optionally overrides the GPU's render state.

            渲染指定的一组 可见物体, 同时还向本类体内的 command list 中添加一系列 commands;
            这些 commands 最后会在 ScriptableRenderContext.Submit() 调用中, 被全部执行;
            ---

            指定渲染命令的同时, 还能 use one or more RenderStateBlock structs 
            to override the GPU's render state in the following ways:
            --
                向本函数的 stateBlock, 传入单个render state 信息;
                unity 使用这 单个信息, 去覆写 "本次函数调用将要渲染的 所有物体"
            -- 
                You can use the stateBlocks parameter to provide an array of RenderStateBlock structs, 
                and the renderTypes parameter to provide an array of values for the SubShader Tag with a name of RenderType. 
                For each element in the renderTypes array, if Unity finds geometry with a SubShader Tag name of RenderType 
                and a matching value, it uses the render state defined in the corresponding element of the stateBlocks array. 
                If there are multiple matches, Unity uses the first one. If an element in the renderTypes array has the 
                default value for ShaderTagId, Unity treats this as a catch-all and uses the corresponding render state for 
                all geometry.

                向本函数的 stateBlocks 参数, 传入一个 RenderStateBlock array;
                向本函数的 renderTypes 参数, 传入一个 ShaderTagId array,
                    针对这个 array 中的每一个 ShaderTagId 的 name 值,
                    unity 都会区查找到一个 "RenderType" tag 值 等于这个 name 值 的 SubShader;

                    这个查找 会针对 "本次函数调用涉及的所有可见物体" 去执行;

                    如果某个物体 含有这个 SubShader, unity 就会去 参数 stateBlocks 的同位置中获得一个
                    RenderStateBlock 实例, 用这个数据, 来覆写这个物体的 SubShader 中的 render states;

                    如果从这个物体中找到好几个符合的 SubShader,  unity 使用第一个的 idx;

                    如果 renderTypes array 中的某个元素是 ShaderTagId 的 "默认值"
                    (没找到, 猜测是 ShaderTagId.None )
                    unity 会把这个 idx 处的 stateBlocks 信息, 作用到 "本次函数调用涉及的所有可见物体" 身上去;

            -- 
                You can use the stateBlocks parameter to provide an array of RenderStateBlock structs, 
                and use the tagName, tagValues, and isPassTagName parameters to specify the name and values 
                of any SubShader Tag or Pass Tag. For each element in the tagNames and tagValues arrays, 
                Unity identifies geometry with a matching SubShader Tag or Pass Tag name and value, 
                and applies the render state defined in the corresponding element of the stateBlocks array. 
                If there are multiple matches, Unity uses the first one. If an element in the tagValues has the 
                default value for ShaderTagId, Unity treats this as a catch-all and uses the corresponding render 
                state for all geometry.

                ---
                可向本函数参数 stateBlocks 传入 一组 RenderStateBlock 值;
                然后向参数 tagName, tagValues, isPassTagName, 指定一组符合要求的 "SubShader or pass";
"
                针对每一个 "本次函数调用涉及的所有可见物体", unity 都会找出它含有的 符合上述要求的 "SubShader or pass",
                然后使用对应idx 的 stateBlocks 中的信息, 去覆写这个 "SubShader or pass" 的 render states;

                和上一种方法类似, 
                    如果从这个物体中找到好几个符合的 SubShader,  unity 使用第一个的 idx;

                    如果 renderTypes array 中的某个元素是 ShaderTagId 的 "默认值"
                    (没找到, 猜测是 ShaderTagId.None )
                    unity 会把这个 idx 处的 stateBlocks 信息, 作用到 "本次函数调用涉及的所有可见物体" 身上去;

            参数:
            cullingResults:
                The set of visible objects to draw. 

            drawingSettings:
                A struct that describes how to draw the objects.
                描述了:
                -- how to sort visible objects (sortingSettings)
                -- which shader passes to use (shaderPassName).

            filteringSettings:
                对 "可见物体" 的过滤, 只有其中一部分会被渲染;
                此 class 已在另一文件中翻译;

            stateBlock:
                A set of values that Unity uses to override the GPU's render state.

                此参数实例 存储了各个 render target 的 "render states",
                "render states" 其实就是 shader 中的 ZClip, ZWrite, Stencil test 那堆指令;

                使用此参数, 可以覆写 物体 material shader 中设置好的 "render states";
                还能用 此参数内的 mask 来指定覆写哪几种 指令;

            tagName:
                The name of a SubShader Tag or Pass Tag.
                用下面的 isPassTagName 来做选择;

                注意, 这是一个 tag 的 "name" (key)

            isPassTagName:
                -- true,  tagName specifies a Pass Tag. 
                -- false, tagName specifies a SubShader Tag.

            tagValues:
                An array of ShaderTagId structs, 
                where the name is the value of a given SubShader Tag or Pass Tag.

                注意, 这是一个 tag 的 "value", (和上面的 tagName 对应)

            renderTypes:
                An array of ShaderTagId structs, 
                where the name is the value of a SubShader Tag that has the name "RenderType".
                ---
                这个 array 中的每一个 ShaderTagId 所存储的 name 值, 
                它都对应一个存在的 SubShader, 要求这个 SubShader 的 tag: "RenderType" 的值, 
                和这个 name 中记录的是相同的;
                ---
                用这个办法来 存储和传递一组 SubShaders 信息;

                也就是说, 本参数中存储的是一组 SubShader 的 cpu端id;

            stateBlocks:
                An array of structs that describe which parts of the GPU's render state to override.

        */
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, NativeArray<ShaderTagId> renderTypes, NativeArray<RenderStateBlock> stateBlocks);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings);
        public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock stateBlock);
        public void DrawRenderers(
            CullingResults cullingResults, 
            ref DrawingSettings drawingSettings, 
            ref FilteringSettings filteringSettings, 
            ShaderTagId tagName, 
            bool isPassTagName, 
            NativeArray<ShaderTagId> tagValues, 
            NativeArray<RenderStateBlock> stateBlocks
        );
        
        
        /*
            Schedules the drawing of shadow casters for a single Light.

            Please note that in the case of DrawShadows called multiple times for the same light and using split spheres, 
            shadow casters whose shadow volumes are fully covered by an earlier split will be discarded in following splits 
            for performance reasons. One should thus use the split with the smallest index in case of split overlaps.
            ---
            如果一个光源选择了 cull sphere 版的 cascade shadowmap,(通常是平行光)
            那么针对每一个 cascade split, 都要调用一次 本函数;

            如果一个物体(renderer), 在上一次 调用本函数时, 被完全包裹在当时的那个 cull sphere 中 (而不是一部分露在边界上)
            那么这个物体, 会在之后的所有 DrawShadows() 函数调用中, 都被剔除掉; 
            这是一种 提高性能的机制;

            为了迎合这种机制, 我们必须安排好 cascade split 的调用次序:
            先针对 最小 cull sphere 的那个 split 来调用本函数;
            然后逐次增大;
        */
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

        

        /*
            摘要:
            Schedules the drawing of a wireframe(线框) overlay for a given Scene view Camera.

            此函数仅在 editor 中工作, 
            而且要把 Camera.cameraType 设置为 SceneView,
            把 SceneView.CameraMode.drawMode 设置为 TexturedWire;

            否则, 本函数不做任何工作;

            To draw gizmos on top of the wireframe overlay in your Scene view
            先调用本函数, 再调用 DrawGizmos();

            参数:
            camera:
                The Scene view Camera to draw the overlay for.
        */
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
        

        /*
            摘要:
            Schedules an invocation of the OnRenderObject callback for MonoBehaviour scripts.

            This method triggers MonoBehaviour.OnRenderObject();
            ---
            调用此函数来 触发 callback: MonoBehaviour.OnRenderObject();

            You should typically call this function after the Camera renders the Scene 
            but before adding post-processing.
        */
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
        public void StereoEndRender(Camera camera);
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