
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{

    /*
        Script interface for Graphics Settings.

        就是 project settings: Graphics 界面的 api
    */
    [NativeHeaderAttribute("Runtime/Camera/GraphicsSettings.h")]
    [StaticAccessorAttribute("GetGraphicsSettings()", Bindings.StaticAccessorType.Dot)]
    public sealed class GraphicsSettings : Object//GraphicsSettings__RR
    {
        /*
            If this is true, Light intensity is multiplied against linear color values. If
            it is false, gamma color values are used.

            -- 若为 true, Light intensity 会被乘以 线性color值; 
            -- 若为 false, 则改用 gamma color 值; [默认值]

            选择 线性color值 时物理正确的, 但不是使用 Unity 5.6 或更新版本 创建的 3D 项目的默认设置。
            2D 项目中本变量默认也是 false;

            如果你在一个项目中启动了本变量, 所有的光源都要做调整, 以接近原来的效果;
        */
        public static bool lightsUseLinearIntensity { get; set; }


        /*
            The "RenderPipelineAsset" that describes how the Scene should be rendered.
            The current RenderPipelineAsset is used to render "Scene", "View" and "Preview" Cameras.
        */
        public static RenderPipelineAsset renderPipelineAsset { get; set; }


        /*
            The current active "RenderPipelineAsset" taking into consideration the default and any active override.
            The current RenderPipelineAsset that is used to render Scene, View and Preview Cameras.

            在 urp 中被使用;
        */
        public static RenderPipelineAsset currentRenderPipeline { get; }


        //
        // 摘要:
        //     If and when to include video shaders in the build.
        public static VideoShadersIncludeMode videoShadersIncludeMode { get; set; }
        //
        // 摘要:
        //     Disables the built-in update loop for Custom Render Textures, so that you can
        //     write your own update loop.
        public static bool disableBuiltinCustomRenderTextureUpdate { get; set; }
        //
        // 摘要:
        //     If this is true, a log entry is made each time a shader is compiled at application
        //     runtime.
        public static bool logWhenShaderIsCompiled { get; set; }
        //
        // 摘要:
        //     Enable/Disable SRP batcher (experimental) at runtime.
        public static bool useScriptableRenderPipelineBatching { get; set; }
        //
        // 摘要:
        //     Stores the default value for the RenderingLayerMask property of newly created
        //     Renderers.
        public static uint defaultRenderingLayerMask { get; set; }
        //
        // 摘要:
        //     Whether to use a Light's color temperature when calculating the final color of
        //     that Light."
        public static bool lightsUseColorTemperature { get; set; }
        //
        // 摘要:
        //     The default RenderPipelineAsset that describes how the Scene should be rendered
        //     when no override is configured.
        public static RenderPipelineAsset defaultRenderPipeline { get; set; }
        //
        // 摘要:
        //     All RenderPipelineAssets that are configured
        public static RenderPipelineAsset[] allConfiguredRenderPipelines { get; }
        //
        // 摘要:
        //     An axis that describes the direction along which the distances of objects are
        //     measured for the purpose of sorting.
        public static Vector3 transparencySortAxis { get; set; }
        //
        // 摘要:
        //     Transparent object sorting mode.
        public static TransparencySortMode transparencySortMode { get; set; }
        //
        // 摘要:
        //     Is the current render pipeline capable of rendering direct lighting for rectangular
        //     area Lights?
        public static bool realtimeDirectRectangularAreaLights { get; set; }

        //
        // 摘要:
        //     Get custom shader used instead of a built-in shader.
        //
        // 参数:
        //   type:
        //     Built-in shader type to query custom shader for.
        //
        // 返回结果:
        //     The shader used.
        [NativeNameAttribute("GetCustomShaderScript")]
        public static Shader GetCustomShader(BuiltinShaderType type);
        //
        // 摘要:
        //     Provides a reference to the GraphicSettings object.
        //
        // 返回结果:
        //     Returns the GraphicsSettings object.
        [FreeFunctionAttribute]
        public static Object GetGraphicsSettings();
        //
        // 摘要:
        //     Get built-in shader mode.
        //
        // 参数:
        //   type:
        //     Built-in shader type to query.
        //
        // 返回结果:
        //     Mode used for built-in shader.
        [NativeNameAttribute("GetShaderModeScript")]
        public static BuiltinShaderMode GetShaderMode(BuiltinShaderType type);
        //
        // 摘要:
        //     Returns true if shader define was set when compiling shaders for a given GraphicsTier.
        //     Graphics Tiers are only available in the Built-in Render Pipeline.
        //
        // 参数:
        //   defineHash:
        public static bool HasShaderDefine(BuiltinShaderDefine defineHash);
        //
        // 摘要:
        //     Returns true if shader define was set when compiling shaders for current GraphicsTier.
        //     Graphics Tiers are only available in the Built-in Render Pipeline.
        //
        // 参数:
        //   tier:
        //
        //   defineHash:
        public static bool HasShaderDefine(GraphicsTier tier, BuiltinShaderDefine defineHash);
        //
        // 摘要:
        //     Set custom shader to use instead of a built-in shader.
        //
        // 参数:
        //   type:
        //     Built-in shader type to set custom shader to.
        //
        //   shader:
        //     The shader to use.
        [NativeNameAttribute("SetCustomShaderScript")]
        public static void SetCustomShader(BuiltinShaderType type, Shader shader);
        //
        // 摘要:
        //     Set built-in shader mode.
        //
        // 参数:
        //   type:
        //     Built-in shader type to change.
        //
        //   mode:
        //     Mode to use for built-in shader.
        [NativeNameAttribute("SetShaderModeScript")]
        public static void SetShaderMode(BuiltinShaderType type, BuiltinShaderMode mode);
    }
}