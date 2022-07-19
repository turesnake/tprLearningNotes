#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

namespace UnityEditor.Rendering
{
    //
    // 摘要:
    //     Identifies the stage in the rendering pipeline.
    public enum ShaderType
    {
        //
        // 摘要:
        //     Identifier for the vertex Shader stage.
        Vertex = 1,
        //
        // 摘要:
        //     Identifier for the fragment Shader stage.
        Fragment = 2,
        //
        // 摘要:
        //     Identifier for the geometry Shader stage.
        Geometry = 3,
        //
        // 摘要:
        //     Identifier for the hull Shader stage.
        Hull = 4,
        //
        // 摘要:
        //     Identifier for the domain Shader stage.
        Domain = 5,
        //
        // 摘要:
        //     Identifier for the surface Shader stage.
        Surface = 6,
        //
        // 摘要:
        //     Identifier for the ray tracing Shader stage.
        RayTracing = 7,
        //
        // 摘要:
        //     The number of ShaderTypes that Unity supports.
        //     -- 感觉这不是一个类型... 是一个数值
        Count = 7
    }
}

