/*

    ===================================================================
                        ForwardRenderer.Setup()
    ===================================================================:

    -- 处理特殊的 offsreen depth camera
        - 沿用 camera 原本绑定得 color/depth target
        - enqueue 所有 用户自定义 renderFeature 中得 render passes 
        - enqueue opaqueForwardPass
        - enqueue skybox pass
        - enqueue transparent forward pass
        - return


    -- 若要创建 color texture, 
        就要将 renderer.m_CameraColorTarget 设置为:"_CameraColorTexture"


    -- enqueue 所有 用户自定义 renderFeature 中得 render passes 


    -- 生成 renderPassInputs;
        汇总了所有 active render pass 对 input 数据的需求;
        以供后续决策用;


    --  m_MainLightShadowCasterPass.Setup()
        m_AdditionalLightsShadowCasterPass.Setup()

    -- m_TransparentSettingsPass.Setup()


    -- 若为 base camera:
        ? 创建 color rt: "_CameraColorTexture", 
        ? 创建 depth rt: "_CameraDepthAttachment"
        ---
        若为 overlay camera:
        则直接沿用 base camera 中已经创建好的;


    -- ConfigureCameraTarget()
        写入 ScriptableRenderer 的 m_CameraColorTarget, m_CameraDepthTarget;


    -- ? EnqueuePass(m_MainLightShadowCasterPass);
    -- ? EnqueuePass(m_AdditionalLightsShadowCasterPass);

    -- 如果需要 prepass:
        Setup 并 EnqueuePass: 
            m_DepthNormalPrepass 或 m_DepthPrepass

    -- 如果需要:
        Setup 并 EnqueuePass: colorGradingLutPass
        
    -- EnqueuePass(m_RenderOpaqueForwardPass);

    -- base camera:
        (且符合一些要求)
        EnqueuePass(m_DrawSkyboxPass);

    -- ? Setup 并 EnqueuePass: m_CopyDepthPass

    -- 若为 base camera, 没启用 depth prepass, 也没启用 depth copy, 
        则绑定一个 global texture: "_CameraDepthTexture"



    ================================= oth ==================================




    -------------------------------------------------------:
    在具体的 render pass 的实现代码中, 自己设置的 render targets
    ---
    使用本类的 "ConfigureTarget()" 来设置本组值;
    (此函数通常在 "OnCameraSetup()" 函数实现体内 被调用;)







*/
