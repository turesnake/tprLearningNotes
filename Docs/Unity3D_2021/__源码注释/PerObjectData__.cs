#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        What kind of per-object data to setup during rendering.

        最简模式下:
            物体转换矩阵 一定会被设置为 "逐物体"

        此时消耗的 内存和带宽最小,

        在此基础上, 还能让 lightmaps, light probes 等数据也 "逐物体化";

        可通过 本 enum 的各个 flags 的 组合来获得 复合配置;

    */
    [Flags]
    public enum PerObjectData//PerObjectData__
    {
        /*
            摘要:
            Do not setup any particular per-object data besides the transformation matrix.
            只有转换矩阵是 "逐物体" 的;
        */
        None = 0,

        
        // 摘要:
        //     Setup per-object light probe SH data.
        LightProbe = 1,


        
        // 摘要:
        //     Setup per-object reflection probe data.
        ReflectionProbes = 2,


        /*
            摘要:
            Setup per-object "light probe proxy volume" LPPV data.
            LPPV:
                在一个动态物体上设置 很多个 探针节点, 让此动态物体可以获得细腻的 GI 信息;
        */
        LightProbeProxyVolume = 4,
        

        // 摘要:
        //     Setup per-object lightmaps.
        Lightmaps = 8,

        
        // 摘要:
        //     Setup per-object light data.
        LightData = 16,

        
        // 摘要:
        //     Setup per-object motion vectors.
        MotionVectors = 32,

        /*
            摘要:
            Setup "per-object light indices".

            "per-object light indices" 是一个 unity 自带系统, 可在笔记中搜索此关键词;
            此系统存在问题, 最好别用;
        */
        LightIndices = 64,

        
        // 摘要:
        //     Setup per-object reflection probe index offset and count.
        ReflectionProbeData = 128,


        /*
            摘要:
            Setup per-object occlusion probe data.
            即: light probe(occlusion)
        */
        OcclusionProbe = 256,

        
        /*
            摘要:
            Setup per-object occlusion probe proxy volume data (occlusion in alpha channels).
            遮蔽信息版 的 LPPV ?
        */
        OcclusionProbeProxyVolume = 512,


        
        // 摘要:
        //     Setup per-object shadowmask.
        ShadowMask = 1024
    }
}

