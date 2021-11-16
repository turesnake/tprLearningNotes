#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Backface culling mode.
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    public enum CullMode
    {
        
        // 摘要:
        //     Disable culling.
        Off = 0,
        
        // 摘要:
        //     Cull front-facing geometry.
        Front = 1,
        
        // 摘要:
        //     Cull back-facing geometry.
        Back = 2
    }
}
