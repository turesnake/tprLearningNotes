#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     A collection of Rendering.ShaderKeyword that represents a specific shader variant.
    [NativeHeaderAttribute("Editor/Src/Graphics/ShaderCompilerData.h")]
    [UsedByNativeCodeAttribute]
    public struct ShaderKeywordSet
    {
        //
        // 摘要:
        //     Disable a specific shader keyword.
        //
        // 参数:
        //   keyword:
        public void Disable(ShaderKeyword keyword);
        //
        // 摘要:
        //     Enable a specific shader keyword.
        //
        // 参数:
        //   keyword:
        public void Enable(ShaderKeyword keyword);
        //
        // 摘要:
        //     Return an array with all the enabled keywords in the ShaderKeywordSet.
        public ShaderKeyword[] GetShaderKeywords();
        //
        // 摘要:
        //     Check whether a specific shader keyword is enabled.
        //
        // 参数:
        //   keyword:
        public bool IsEnabled(ShaderKeyword keyword);
        //
        // 摘要:
        //     Check whether a specific shader keyword is enabled.
        //
        // 参数:
        //   keyword:
        public bool IsEnabled(GlobalKeyword keyword);
        //
        // 摘要:
        //     Check whether a specific shader keyword is enabled.
        //
        // 参数:
        //   keyword:
        public bool IsEnabled(LocalKeyword keyword);
    }
}

