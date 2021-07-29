using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


// Renderer Feature 的使用示范：
// 修改 画面颜色对比度

// 使用方式:
// 将 ColorContrast.shader 绑定到一个 mat 上
// 并将此 mat，绑定到 本 feature 实例中
// 这样，我们就能使用这个 shader 
// ---
// 注意，这组 shader，mat 不应该用在别的任何地方
// 比如把它绑定到一个 go 上，这样做是无效的
//（我们创建这组 mat，shader 的目的只是用它来处理数据，）
//（而不是用它来 渲染go）


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
        }

        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in a performant manner.
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            this.src = this.srcRenderer.cameraColorTarget;
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
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


        // Cleanup any allocated resources that were created during the execution of this render pass.
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


    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses( ScriptableRenderer renderer, ref RenderingData renderingData )
    {                
        m_ScriptablePass.Setup( ref renderer, RenderTargetHandle.CameraTarget );
        renderer.EnqueuePass(m_ScriptablePass);
    }
}


