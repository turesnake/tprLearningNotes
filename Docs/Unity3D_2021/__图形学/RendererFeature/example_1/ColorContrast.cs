using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// ======= ColorContrast ======
// Renderer Feature 的使用示范：
// 修改 画面颜色对比度

// 使用方式:
// 将 ColorContrast.shader 绑定到一个 mat 上
// 并将此 mat，绑定到 本 feature 实例中, 这样，我们就能使用这个 shader 
// ---
// 注意，这组 shader，mat 不应该用在别的任何地方, 比如把它绑定到一个 go 上，这样做是无效的
//（我们创建这组 mat，shader 的目的只是用它来处理数据，）
//（而不是用它来 渲染go）

// 最后, 去 ForwardRenderer inspector 中添加本 feature;

// 疑惑:
//  在 ForwardRenderer 中创建一个 render pass, 是不是会作用于每一个 camera 上 ???
//  目前检测看, 是这样的.....


public class ColorContrast : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        public Material mMat;  

        private RenderTargetIdentifier src { get; set; }
        private RenderTargetHandle dst { get; set; }

        // 临时 rt，做 blit 数据中转站
        RenderTargetHandle m_tmpColorTexture; 

        // .cameraColorTarget .cameraDepthTarget 必须在 pass 几个指定函数内被 call [urp.10.0]
        // 所以需要先把 renderer 暂存起来
        ScriptableRenderer srcRenderer;

        public CustomRenderPass(    RenderPassEvent event_, 
                                    Material mat_,
                                    float contrast_
        ){
            this.renderPassEvent = event_;
            this.mMat = mat_;
            mMat.SetFloat( "_Contrast", contrast_ );
            m_tmpColorTexture.Init("tmpColorTexture");
        }

        // self method
        public void Setup( ref ScriptableRenderer srcRenderer_, RenderTargetHandle dest)
        {
            this.srcRenderer = srcRenderer_;
            this.dst = dest;

            // ---------- 此处代码和本 render pass 的主题无关:
            // 调用此函数,表面本 render pass 需要在  normal texture 数据当作自己的 input 值;
            // urp 在得知此要求后, 会预先在 prepass 阶段执行 DepthNormalOnlyPass;
            ConfigureInput( ScriptableRenderPassInput.Normal );
        }


        /*
            在正式渲染一个 camera 之前, 本函数会被 renderer 调用 (比如 Forward Renderer);
            (另一说是) 在执行 render pass 之前, 本函数会被调用;

            可以在本函数中实现:
                -- configure render targets and their clear state
                -- create temporary render target textures

            如果本函数为空, 这个 render pass 会被渲染进 "active camera render target";

            永远不要调用 "CommandBuffer.SetRenderTarget()", 
            而要改用 "ScriptableRenderPass" 内的 "ConfigureTarget()", "ConfigureClear()" 函数;
            管线能保证高效地 "setup target" 和 "clear target";
        */
        /// <param name="cmd">CommandBuffer to enqueue rendering commands. This will be executed by the pipeline;
        ///                     将需要的 渲染指令 安排进 render queue; 
        /// </param>
        /// <param name="renderingData">Current rendering state information</param>
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            this.src = this.srcRenderer.cameraColorTarget;
        }

        
        /*
            可在本函数体内编写: 渲染逻辑本身, 也就是 用户希望本 render pass 要做的那些工作;
            使用参数 context 来发送 绘制指令, 执行 commandbuffers;
            不需要在本函数实现体内 调用 "ScriptableRenderContext.submit()", 渲染管线会在何时的时间点自动调用它;
        */
        /// <param name="context"> Use this render context to issue(发射) any draw commands during execution</param>
        /// <param name="renderingData">Current rendering state information</param>
        public override void Execute( ScriptableRenderContext context, ref RenderingData renderingData )
        {
            CommandBuffer cmd = CommandBufferPool.Get( "Feature_4_Pass" );

            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            // 不生成 z-buffer
            opaqueDesc.depthBufferBits = 0;
            
            // 这个 feature 的 核心:
            // 我们的目的是在整个 渲染流程 中，插入一个新 pass
            // 在这个 pass 中，获得当前渲染到一半的 rt，对其进行一次处理（mat.shader）
            // 然后把这个 rt，暂存到一个 tmpRt 中
            // 然后再把它 传输回 原来的位置：camera render target
            // ---
            // now, dst == RenderTargetHandle.CameraTarget
            // 不能读写同一个颜色target，创建一个临时的render Target去blit
            
            cmd.GetTemporaryRT( m_tmpColorTexture.id, opaqueDesc, FilterMode.Point );
            // 把一段数据，从 src，传递到 tmprt 
            // 且调用参数 mat.shader.pass 来处理
            Blit(cmd, src, m_tmpColorTexture.Identifier(), mMat, 0 );
            // 把一段数据，从 tmprt，又传递回 src
            // 且不做额外操作
            Blit(cmd, m_tmpColorTexture.Identifier(), src );
            

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }


        /*
            在完成渲染 camera 时, 本函数会被调用, 
            可在此函数体内释放本 render pass 新建的所有资源;
            本函数会清理 camera stack 中的所有 cameras;
        */
        /// <param name="cmd">Use this CommandBuffer to cleanup any generated data</param>
        public override void OnCameraCleanup( CommandBuffer cmd )
        {   
            // 释放 tmprt
            cmd.ReleaseTemporaryRT(m_tmpColorTexture.id);
        }
    }



    [System.Serializable]
    public class HLSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
        // 本 feature 将使用此 mat.shader.fstPass (passIdx 暂时强制设置为 0)
        public Material mMat;
        public float contrast = 0.5f; // 对比度
    }


    CustomRenderPass m_ScriptablePass;
    // 命名为 settings，可以直接显示在 inspector 中
    public HLSettings settings = new HLSettings();


    // 仅在代码改变后，或者程序启动时，此函数才会被调用一次
    // Initializes this feature's resources. This is called every time serialization happens.
    public override void Create()
    {

        m_ScriptablePass = new CustomRenderPass(
            settings.renderPassEvent, 
            settings.mMat, 
            settings.contrast
        );

        if (settings.mMat == null){
            Debug.LogWarningFormat("丢失blit材质");
            return;
        }
    }

    /*
        ---------------------------------------------------------- +++
        Here you can inject one or multiple render passes in the renderer.
        This method is called when setting up the renderer once per-camera.
        ---
        在派生类的实现体中:
            可将 数个 "ScriptableRenderPass" 注入到本 feature 中;
            代码:
                renderer.EnqueuePass( m_pass );
                此处
                "renderer" 就是本函数提供的的参数;
                m_pass 就是一个 "ScriptableRenderPass" 或其继承者的 实例;

        参数:
        renderer:
            如 "ForwardRenderer"
        renderingData:
            Rendering state. Use this to setup render passes.
    */
    public override void AddRenderPasses( ScriptableRenderer renderer, ref RenderingData renderingData )
    {           

        /*       
            tpr:
                只有 stack 中的最后一个 camera 可以执行此 render pass
                若不做此限制, 那么这个 render pass 会作用于 参数 renderer 体内的每一个 camera 上;
                (其它更多 筛选 camera 的方法 还有待探索..)
        */
        if( !renderingData.cameraData.resolveFinalTarget  ){
            return;
        }
             
        m_ScriptablePass.Setup( ref renderer, RenderTargetHandle.CameraTarget );
        renderer.EnqueuePass(m_ScriptablePass);
    }
}


