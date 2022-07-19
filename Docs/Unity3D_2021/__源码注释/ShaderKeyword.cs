#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        Identifier of a specific code path in a shader.


    */
    [NativeHeaderAttribute("Runtime/Shaders/ShaderKeywords.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [UsedByNativeCodeAttribute]
    public struct ShaderKeyword//ShaderKeyword__
    {
        /*
            摘要:
            Initializes a new instance of the ShaderKeyword class "from a shader global keyword name".
            --
            参数是 global keyword;
        
        // 参数:
        //   keywordName:
        //     The name of the keyword.
        */
        public ShaderKeyword(string keywordName);

        /*
            摘要:
            Initializes a new instance of the ShaderKeyword class "from a global or local shader keyword name".
            --
            参数是 global or local shader keyword;
            如果是 local 的, 就要指定 shader 对象;
        
            参数:
            shader:
                The shader that declares the keyword.
            
            keywordName:
                The name of the keyword.
        */
        public ShaderKeyword(Shader shader, string keywordName);

        //
        // 摘要:
        //     Initializes a new instance of the ShaderKeyword class from a local shader keyword
        //     name, and the compute shader that defines that local keyword.
        //
        // 参数:
        //   shader:
        //     The compute shader that declares the local keyword.
        //
        //   keywordName:
        //     The name of the keyword.
        public ShaderKeyword(ComputeShader shader, string keywordName);

        //
        // 摘要:
        //     The index of the shader keyword.
        public int index { get; }

        //
        // 摘要:
        //     Returns the string name of the global keyword.
        //
        // 参数:
        //   index:
        [FreeFunctionAttribute("ShaderScripting::GetGlobalKeywordName")]
        public static string GetGlobalKeywordName(ShaderKeyword index);

        //
        // 摘要:
        //     Returns the type of global keyword: built-in or user defined.
        //
        // 参数:
        //   index:
        [FreeFunctionAttribute("ShaderScripting::GetGlobalKeywordType")]
        public static ShaderKeywordType GetGlobalKeywordType(ShaderKeyword index);

        //
        // 摘要:
        //     Returns the string name of the keyword.
        [FreeFunctionAttribute("ShaderScripting::GetKeywordName")]
        public static string GetKeywordName(Shader shader, ShaderKeyword index);
        public static string GetKeywordName(ComputeShader shader, ShaderKeyword index);

        //
        // 摘要:
        //     Returns the type of keyword: built-in or user defined.
        [FreeFunctionAttribute("ShaderScripting::GetKeywordType")]
        public static ShaderKeywordType GetKeywordType(Shader shader, ShaderKeyword index);
        public static ShaderKeywordType GetKeywordType(ComputeShader shader, ShaderKeyword index);


        //
        // 摘要:
        //     Returns true if the keyword is local.
        [FreeFunctionAttribute("ShaderScripting::IsKeywordLocal")]
        public static bool IsKeywordLocal(ShaderKeyword index);


        /*
        // 摘要:
        //     Returns the string name of the keyword.
        [Obsolete("GetKeywordName is deprecated. Use ShaderKeyword.GetGlobalKeywordName instead.")]
        public string GetKeywordName();
        */

        /*
        // 摘要:
        //     Returns the type of keyword: built-in or user defined.
        [Obsolete("GetKeywordType is deprecated. Use ShaderKeyword.GetGlobalKeywordType instead.")]
        public ShaderKeywordType GetKeywordType();
        */

        /*
        [Obsolete("GetName() has been deprecated. Use ShaderKeyword.GetGlobalKeywordName instead.")]
        public string GetName();
        */

        
        // 摘要:
        //     Returns true if the keyword has been imported by Unity.
        public bool IsValid();
    }
}
