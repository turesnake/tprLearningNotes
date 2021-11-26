#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    
    // 摘要:
    //     Depth or stencil comparison function.
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    public enum CompareFunction//CompareFunction__
    {
        
        // 摘要:
        //     Depth or stencil test is disabled.
        Disabled = 0,
        //
        // 摘要:
        //     Never pass depth or stencil test.
        Never = 1,
        //
        // 摘要:
        //     Pass depth or stencil test when new value is less than old one.
        Less = 2,
        //
        // 摘要:
        //     Pass depth or stencil test when values are equal.
        Equal = 3,
        //
        // 摘要:
        //     Pass depth or stencil test when new value is less or equal than old one.
        LessEqual = 4,
        //
        // 摘要:
        //     Pass depth or stencil test when new value is greater than old one.
        Greater = 5,
        //
        // 摘要:
        //     Pass depth or stencil test when values are different.
        NotEqual = 6,
        //
        // 摘要:
        //     Pass depth or stencil test when new value is greater or equal than old one.
        GreaterEqual = 7,
        //
        // 摘要:
        //     Always pass depth or stencil test.
        Always = 8
    }
}
