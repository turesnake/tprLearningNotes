#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     The rendering mode of Shadowmask.
    public enum ShadowmaskMode
    {
        //
        // 摘要:
        //     Static shadow casters won't be rendered into realtime shadow maps. All shadows
        //     from static casters are handled via Shadowmasks and occlusion from Light Probes.
        Shadowmask = 0,
        //
        // 摘要:
        //     Static shadow casters will be rendered into realtime shadow maps. Shadowmasks
        //     and occlusion from Light Probes will only be used past the realtime shadow distance.
        DistanceShadowmask = 1
    }
}

