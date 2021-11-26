#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{

    // 摘要:
    //     How the material interacts with lightmaps and lightprobes.
    [Flags]
    public enum MaterialGlobalIlluminationFlags//MaterialGlobalIlluminationFlags__
    {
        
        // 摘要:
        //     The emissive lighting does not affect Global Illumination at all.
        None = 0,
        

        /*
            摘要:
            The emissive lighting will affect realtime Global Illumination. 
            It emits(发射) lighting into realtime lightmaps and realtime lightprobes.

            如果启用了 realtime Global Illumination, 必须确保关闭 EmissiveIsBlack;

        */
        RealtimeEmissive = 1,
        
        
        // 摘要:
        //     The emissive lighting affects baked Global Illumination. It emits lighting into
        //     baked lightmaps and baked lightprobes.
        BakedEmissive = 2,

        /*
            摘要:
            Helper Mask to be used to query the enum only based on whether realtime GI or
            baked GI is set, ignoring all other bits.

            暂没看懂用途;
        */
        AnyEmissive = 3,
        

        // 摘要:
        //     The emissive lighting is guaranteed to be black. This lets the lightmapping system
        //     know that it doesn't have to extract emissive lighting information from the material
        //     and can simply assume it is completely black.
        EmissiveIsBlack = 4
    }
}

