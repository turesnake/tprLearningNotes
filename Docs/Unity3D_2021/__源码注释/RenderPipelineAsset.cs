#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     An asset that produces a specific IRenderPipeline.
    public abstract class RenderPipelineAsset : ScriptableObject
    {
        protected RenderPipelineAsset();

        //
        // 摘要:
        //     Return the detail grass Shader for this pipeline.
        public virtual Shader terrainDetailGrassShader { get; }
        //
        // 摘要:
        //     Return the default Shader for this pipeline.
        //
        // 返回结果:
        //     Default shader.
        public virtual Shader defaultShader { get; }
        //
        // 摘要:
        //     Return the default 2D Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material default2DMaterial { get; }
        //
        // 摘要:
        //     Return the default UI ETC1 Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultUIETC1SupportedMaterial { get; }
        //
        // 摘要:
        //     Return the default UI overdraw Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultUIOverdrawMaterial { get; }
        //
        // 摘要:
        //     Return the default UI Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultUIMaterial { get; }
        //
        // 摘要:
        //     Return the default Terrain Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultTerrainMaterial { get; }
        //
        // 摘要:
        //     Return the default Line Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultLineMaterial { get; }
        //
        // 摘要:
        //     Return the default particle Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultParticleMaterial { get; }
        //
        // 摘要:
        //     Return the detail grass billboard Shader for this pipeline.
        public virtual Shader terrainDetailGrassBillboardShader { get; }
        //
        // 摘要:
        //     Return the default SpeedTree v8 Shader for this pipeline.
        public virtual Shader defaultSpeedTree8Shader { get; }
        //
        // 摘要:
        //     Return the detail lit Shader for this pipeline.
        public virtual Shader terrainDetailLitShader { get; }
        //
        // 摘要:
        //     Retrieves the default Autodesk Interactive masked Shader for this pipeline.
        //
        // 返回结果:
        //     Returns the default shader.
        public virtual Shader autodeskInteractiveMaskedShader { get; }
        //
        // 摘要:
        //     Retrieves the default Autodesk Interactive transparent Shader for this pipeline.
        //
        // 返回结果:
        //     Returns the default shader.
        public virtual Shader autodeskInteractiveTransparentShader { get; }
        //
        // 摘要:
        //     Retrieves the default Autodesk Interactive Shader for this pipeline.
        //
        // 返回结果:
        //     Returns the default shader.
        public virtual Shader autodeskInteractiveShader { get; }
        //
        // 摘要:
        //     Return the default Material for this pipeline.
        //
        // 返回结果:
        //     Default material.
        public virtual Material defaultMaterial { get; }
        //
        // 摘要:
        //     Returns the list of names used to display Rendering Layer Mask UI for this pipeline.
        //
        // 返回结果:
        //     Array of 32 Rendering Layer Mask names.
        public virtual string[] renderingLayerMaskNames { get; }
        //
        // 摘要:
        //     The render index for the terrain brush in the editor.
        //
        // 返回结果:
        //     Queue index.
        public virtual int terrainBrushPassIndex { get; }
        //
        // 摘要:
        //     Return the default SpeedTree v7 Shader for this pipeline.
        public virtual Shader defaultSpeedTree7Shader { get; }


        /*
            摘要:
            Create a IRenderPipeline specific to this asset.

            由用户来实现此 abstract 函数
            在程序渲染第一帧之前,unity 会主动调用此函数
            如果运行中途, RenderPipelineAsset 的一个设置发生了改变, unity 会销毁当前的 Render Pipe Instance
            然后在下一帧之前,重新调用本函数
 
            返回结果:
                Created pipeline.
        */
        protected abstract RenderPipeline CreatePipeline();
        

        //
        // 摘要:
        //     Default implementation of OnDisable for RenderPipelineAsset. See ScriptableObject.OnDisable
        protected virtual void OnDisable();
        //
        // 摘要:
        //     Default implementation of OnValidate for RenderPipelineAsset. See MonoBehaviour.OnValidate
        protected virtual void OnValidate();
    }
}