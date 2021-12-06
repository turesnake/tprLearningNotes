#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        Struct describing the result of a Global Illumination bake for a given light.



    */
    [NativeHeaderAttribute("Runtime/Camera/SharedLightData.h")]
    public struct LightBakingOutput//LightBakingOutput__RR
    {
        /*
            如果上面得 "lightmapBakeType" 选择了 "Mixed" 模式;
            contains the index of the light "as seen from the occlusion probes point of view if any", otherwise -1.
            ---
            "如果有的话，包含从 occlusion probes 的角度看到的光的 idx值，否则 -1"; 

            这句话很迷, 猜测:
                如果本光源 为 Mixed 光, 那么它需要被记录到 探针上去, 此时代表本 light 的 idx值;
                也有可能 这个光没有被 任何探针看到,  那么这个 light 的 本值就为 -1;

            urp, hdrp 
        */
        public int probeOcclusionLightIndex;

        /*
            如果上面得 "lightmapBakeType" 选择了 "Mixed" 模式;
            contains the index of the "occlusion mask channel" to use if any, otherwise -1;
            ---
            shadowmask 每个 texel 为 float4, 可存储 4 个各自独立的 shadowmask 信息;
            可用 {0,1,2,3} 4个 idx 去访问这个 float4; 

            如果本光源参与了 shadowmask 贡献, 那么 "occlusionMaskChannel" 就表示, 
            本光源的贡献, 被存储在 shadowmask 的哪个 通道里; 
        */
        public int occlusionMaskChannel;

        /*
            This property describes what part of a light's contribution was baked.

            enum: Mixed, Baked, Realtime;
        */
        [NativeNameAttribute("lightmapBakeMode.lightmapBakeType")]
        public LightmapBakeType lightmapBakeType;

        /*
            如果上面得 "lightmapBakeType" 选择了 "Mixed" 模式;
            describes what Mixed mode was used to bake the light, irrelevant otherwise.

            enum: IndirectOnly, Subtractive, Shadowmask;
        */
        [NativeNameAttribute("lightmapBakeMode.mixedLightingMode")]
        public MixedLightingMode mixedLightingMode;

        
        //     Is the light contribution already stored in lightmaps and/or lightprobes?
        public bool isBaked;
    }
}