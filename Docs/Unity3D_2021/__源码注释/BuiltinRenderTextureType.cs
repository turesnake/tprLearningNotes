#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Built-in "temporary render textures" produced during camera's rendering.

        本 enum 变量 can be used as a RenderTargetIdentifier in some functions of CommandBuffer.

    */
    public enum BuiltinRenderTextureType//BuiltinRenderTextureType__RR
    {
        
        // 摘要:
        //     A globally set property name.
        PropertyName = -4,
        
        // 摘要:
        //     The raw RenderBuffer pointer to be used.
        BufferPtr = -3,
        
        // 摘要:
        //     The given RenderTexture.
        RenderTexture = -2,
        BindableTexture = -1,
        None = 0,
        
        /*
            摘要:
            Currently active render target.

            During command buffer execution, this identifies the render target that is active "right now". 
            During command buffer execution, the active render target might be changed by:
            CommandBuffer.SetRenderTarget or CommandBuffer.Blit commands.
        */
        CurrentActive = 1,

        /*
            摘要:
            Target texture of currently rendering camera.

            This is the render target where the current camera would be ultimately最终 rendering into. 
 
            此项和 上一项: "Currently active render target" 可能是不同的:
            ( 比如在渲染一个光源的 shadowmap 时, 或在一个 CommandBuffer.Blit 之后 )
        */
        CameraTarget = 2,
        
        // 摘要:
        //     Camera's depth texture.
        Depth = 3,

        /*
            摘要:
            Camera's depth + normals texture.

            从 DepthTextureMode.DepthNormals 抄来的解释, 可能不完全匹配:
                a "screen-space depth" and "view space normals" texture as seen from this camera. 
            
                Texture will be in RenderTextureFormat.ARGB32 format 
                and will be set as _CameraDepthNormalsTexture global shader property. 
                
                Depth and normals will be specially encoded, see Camera Depth Texture page for details.
        */
        DepthNormals = 4,

        
        /*
            摘要:
            Resolved depth buffer from deferred. 
            源自 延迟渲染 的 "被解析的 depth buffer";

            resolved depth buffer 包含:
            -- The resolved depth buffer contains depth written when filling G-buffers 
            -- as well as depth from forward rendered objects (if there's an active shadowed directional light)
            -- or if the camera has requested a depth texture.
        */
        ResolvedDepth = 5,


        /*
            !!! 用于废弃的 Legacy Deferred (light prepass) 渲染模式 !!!

        //    摘要:
        //    Deferred lighting (normals+specular) G-buffer.
        //    normalWS in RGB channels; specular exponent (镜反指数) in A channel.
        PrepassNormalsSpec = 7,

        // 摘要:
        //     Deferred lighting light buffer.
        //     Contains lighting information in legacy (prepass) deferred lighting.
        PrepassLight = 8,

        // 摘要:
        //     Deferred lighting HDR specular light buffer (Xbox 360 only).
        PrepassLightSpec = 9,
        */


        /*
            摘要:
            Deferred shading G-buffer #0 (typically diffuse color).

            Built-in deferred shaders: 
                -- diffuse albedo color (RGB)
            But your own custom shaders could be outputting anything there of course.
        */
        GBuffer0 = 10,

        /*
            摘要:
            Deferred shading G-buffer #1 (typically specular + roughness).

            Built-in deferred shaders:
                -- specular color   (RGB)
                -- roughness        (A)
            But your own custom shaders could be outputting anything there of course.
        */
        GBuffer1 = 11,

        /*
            摘要:
            Deferred shading G-buffer #2 (typically normals).

            Built-in deferred shaders:
                -- world-space normals (RGB)
            But your own custom shaders could be outputting anything there of course.
        */
        GBuffer2 = 12,

        /*
            摘要:
            Deferred shading G-buffer #3 (typically emission/lighting).

            Built-in deferred shaders:

            在 base pass (GBuffer 生成 pass) 中, 填入: ambient & emission (RGB)
            然后在后续的 lighting pass 中, 继续向此 buffer 累加 每个光源的结果

            But your own custom shaders could be outputting anything there of course.

            注意:
            当 current camera is using HDR, 此时不需要使用 GBuffer3;
            emission/lighting 可被直接写入 camera's target texture;

            You'll need to use CameraTarget render texture type to handle the HDR camera case.
        */
        GBuffer3 = 13,


        /*
            摘要:
            Reflections gathered from default reflection and reflections probes.

            Used by screen space reflections as a fallback, 
            when it's not possible to get reflections from the screen.

        */
        Reflections = 14,
        
        /*
            摘要:
            Motion Vectors generated when the camera has motion vectors enabled.

            Used by various post effects that require per pixel motion information.
        */
        MotionVectors = 15,
        
        /*
            摘要:
             Deferred shading G-buffer #4 (typically occlusion mask for static lights if any).

             Built-in deferred shaders:
                --  baked direct light occlusion (RGBA) 
                (on platform that support at least 8 render targets)
        */
        GBuffer4 = 16,

        
        // 摘要:
        //      G-buffer #5 Available.
        //      Available for custom effects on platforms that support at least 8 render targets.
        GBuffer5 = 17,
        
        // 摘要:
        //      G-buffer #6 Available.
        //      Available for custom effects on platforms that support at least 8 render targets.
        GBuffer6 = 18,
        
        // 摘要:
        //      G-buffer #7 Available.
        //      Available for custom effects on platforms that support at least 8 render targets.
        GBuffer7 = 19
    }
}

