#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    
    //     Shadow resolution options for a Light.
    // enum: FromQualitySettings, Low, Medium, High, VeryHigh;
    public enum LightShadowResolution//LightShadowResolution__
    {
        //
        // 摘要:
        //     Use resolution from QualitySettings (default).
        FromQualitySettings = -1,
        //
        // 摘要:
        //     Low shadow map resolution.
        Low = 0,
        //
        // 摘要:
        //     Medium shadow map resolution.
        Medium = 1,
        //
        // 摘要:
        //     High shadow map resolution.
        High = 2,
        //
        // 摘要:
        //     Very high shadow map resolution.
        VeryHigh = 3
    }
}
