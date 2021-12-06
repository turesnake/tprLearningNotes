#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Enum describing what lighting mode to be used with "Mixed lights".

        enum: IndirectOnly, Subtractive, Shadowmask;
    */
    public enum MixedLightingMode//MixedLightingMode__
    {
       
        //     Mixed lights provide realtime direct lighting while indirect light is baked into
        //     lightmaps and light probes.
        IndirectOnly = 0,

        
        //     Mixed lights provide baked direct and indirect lighting for static objects. Dynamic
        //     objects receive realtime direct lighting and cast shadows on static objects using
        //     the main directional light in the Scene.
        Subtractive = 1,
        

        //     Mixed lights provide realtime direct lighting. Indirect lighting gets baked into
        //     lightmaps and light probes. Shadowmasks and light probe occlusion get generated
        //     for baked shadows. The Shadowmask Mode used at run time can be set in the Quality
        //     Settings panel.
        Shadowmask = 2
    }
}
