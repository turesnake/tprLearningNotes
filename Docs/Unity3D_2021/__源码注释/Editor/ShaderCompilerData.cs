#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using UnityEngine.Rendering;

namespace UnityEditor.Rendering
{
    /*
        Collection of data used for shader variants generation, including targeted platform
        data and the keyword set representing a specific shader variant.

        
    */
    [UsedByNativeCodeAttribute]
    public struct ShaderCompilerData
    {
        //
        // 摘要:
        //     A collection of Rendering.ShaderKeyword that represents a specific shader variant.
        public ShaderKeywordSet shaderKeywordSet;
        //
        // 摘要:
        //     A collection of Rendering.ShaderKeyword that represents a specific platform shader
        //     variant.
        public PlatformKeywordSet platformKeywordSet;

        //
        // 摘要:
        //     Shader features required by a specific shader.
        public ShaderRequirements shaderRequirements { get; }
        //
        // 摘要:
        //     A GraphicsTier classifies low, medium and high performance hardware. You can
        //     only set a Graphics Tier in the Built-in Render Pipeline.
        public GraphicsTier graphicsTier { get; }
        //
        // 摘要:
        //     Shader compiler used to generate player data shader variants.
        public ShaderCompilerPlatform shaderCompilerPlatform { get; }
        //
        // 摘要:
        //     The build target to compile the shader variant for. (Read Only)
        public BuildTarget buildTarget { get; }
    }
}

