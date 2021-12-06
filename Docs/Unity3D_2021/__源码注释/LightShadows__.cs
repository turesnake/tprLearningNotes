#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Shadow casting options for a Light.

        enum: None, Hard, Soft;
    */
    public enum LightShadows
    {
        //
        // 摘要:
        //     Do not cast shadows (default).
        None = 0,
        //
        // 摘要:
        //     Cast "hard" shadows (with no shadow filtering).
        Hard = 1,
        //
        // 摘要:
        //     Cast "soft" shadows (with 4x PCF filtering).
        Soft = 2
    }
}
