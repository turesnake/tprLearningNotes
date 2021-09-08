
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    
    /*
        catlike 教程中, 通过: camera.TryGetCullingParameters( out ScriptableCullingParameters p ) 
        直接获得的 p.cullingOptions 
        将自动设置:
            OcclusionCull
            NeedsLighting
            NeedsReflectionProbes
            ShadowCasters 
    */

    // 摘要:
    //     Flags used by ScriptableCullingParameters.cullingOptions to configure a culling
    //     operation.
    [Flags]
    public enum CullingOptions
    {
        //
        // 摘要:
        //     Unset all CullingOptions flags.
        None = 0,
        //
        // 摘要:
        //     When this flag is set, Unity performs the culling operation even if the Camera
        //     is not active.
        ForceEvenIfCameraIsNotActive = 1,
        //
        // 摘要:
        //     When this flag is set, Unity performs occlusion culling as part of the culling
        //     operation.
        OcclusionCull = 2,
        //
        // 摘要:
        //     When this flag is set, Unity culls Lights as part of the culling operation.
        NeedsLighting = 4,
        //
        // 摘要:
        //     When this flag is set, Unity culls Reflection Probes as part of the culling operation.
        NeedsReflectionProbes = 8,
        //
        // 摘要:
        //     When this flag is set, Unity culls both eyes together for stereo rendering.
        Stereo = 16,
        //
        // 摘要:
        //     When this flag is set, Unity does not perform per-object culling.
        DisablePerObjectCulling = 32,
        //
        // 摘要:
        //     When this flag is set, Unity culls shadow casters as part of the culling operation.
        ShadowCasters = 64
    }
}
