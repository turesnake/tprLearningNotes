#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Experimental.Rendering
{
    /*
        Use a default format to create either Textures or RenderTextures from scripts
        based on platform specific capability.

        Each graphics card may not support all usages across formats. 
        Use SystemInfo.IsFormatSupported to check which usages the graphics card supports.
    */
    public enum DefaultFormat//DefaultFormat__
    {
        /*
            Represents the default platform-specific LDR format. 
            If the project uses the linear rendering mode, the actual format is sRGB. 
            If the project uses the gamma rendering mode, the actual format is UNorm.
        */
        LDR = 0,

        //     Represents the default platform specific HDR format.
        HDR = 1
    }
}
