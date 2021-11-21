#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     ReflectionProbeBlendInfo contains information required for blending probes.
    [UsedByNativeCodeAttribute]
    public struct ReflectionProbeBlendInfo
    {
        //
        // 摘要:
        //     Reflection Probe used in blending.
        public ReflectionProbe probe;
        //
        // 摘要:
        //     Specifies the weight used in the interpolation between two probes, value varies
        //     from 0.0 to 1.0.
        public float weight;
    }
}