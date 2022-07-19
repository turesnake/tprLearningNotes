#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using UnityEngine.Rendering;

namespace UnityEditor.Rendering
{
    //
    // 摘要:
    //     Collection of properties about the specific shader code being compiled.
    [UsedByNativeCodeAttribute]
    public struct ShaderSnippetData
    {
        //
        // 摘要:
        //     Shader stage in the rendering the pipeline.
        public ShaderType shaderType { get; }
        //
        // 摘要:
        //     Shader pass type for Unity's lighting pipeline.
        public PassType passType { get; }
        //
        // 摘要:
        //     Shader.
        public string passName { get; }
        //
        // 摘要:
        //     An opaque identifier for the being compiled.
        public PassIdentifier pass { get; }
    }
}

