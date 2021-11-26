#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Rendering;

namespace UnityEngine
{

    /*
        摘要:
        Stores light probe data for all currently loaded Scenes.

        和 lightmap 不同, 在一个场景中, 可以存在数张 lightmaps, 
        但是 针对当前所有 active 的 scenes, 只有一个 LightProbes 实例信息;

        包含的数据有:
            -- probe positions, 
            -- 球谐系数
            -- the tetrahedral tessellation. 四面体镶嵌

        可以在运行时修改 系数, 更新 四面体镶嵌;

        还可以通过 LightmapSettings.lightProbes 变量, 交换另一份 预烘培的 LightProbes object;

    */
    [NativeHeaderAttribute("Runtime/Export/Graphics/Graphics.bindings.h")]
    public sealed class LightProbes : Object//LightProbes__
    {
        

        //     Positions of the baked light probes (Read Only).
        public Vector3[] positions { get; }


        //     Coefficients of baked light probes.
        public SphericalHarmonicsL2[] bakedProbes { get; set; }



        //     The number of light probes (Read Only).
        public int count { get; }


        /*
            摘要:
            The number of cells - space is divided into (Read Only).
            This includes both interior cells (tetrahedra) and outer space cells.
            猜测:
                light probes 将空间分割成很多个 四面体, 每个四面体就是一个 cell;
                本变量存储了这些 cell 的个数;
                不关包括 真正的 "内部四面体", 还包括外部的 空间cell
        */
        public int cellCount { get; }


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use bakedProbes instead.", true)]
        public float[] coefficients { get; set; }
        */


        /* 
            "四面体化完成了"

            当调用:
                -- LightProbes.Tetrahedralize()
                -- LightProbes.TetrahedralizeAsync() 
            之后, 会 重构四面体集合;

            当重构完成后, 本事件会被触发;
        */
        public static event Action tetrahedralizationCompleted;

        /*
            如果加载/卸载了 additive scene, 恰好这些 scene 携带了 烘焙好的 lightprobe 数据;
            那么当前总体环境中, active 的 lightprobe 数量就会发生变化, 这会直接导致 由它们构成的 四面体们 的数据发生变化;
            此时, 本事件就会被触发, 以此来告诉用户, 需要去 "重构四画面集合" 了!

            在这个时间节点, 你可以去调用 LightProbes.Tetrahedralize() or LightProbes.TetrahedralizeAsync() 来 "重构四面体集合";

            lightprobe 数据 虽然被绑定到一个 scene 上, 但它不是 scene 数据的一部分; 
            所以当一个 scene 被加载时, lightprobe 数据会被异步加载; 这导致有时候 scene 已经加载完成了, 但 lightprobe 数据却没有;

            所以我们不能依靠 SceneManager.sceneLoaded 事件去判断是否需要 "重构四面体", 因为这个事件只意味着 scene 加载完成了,
            它不关心 lightprobes 的加载进度;

            此外, 如果你同时加载 N 个 scenes (都携带 lightprobe 数据),
            那你应该等待出现了 N 次 本事件发生后, 再去执行 重构四面体化;
            这样最高效;
        */
        public static event Action needsRetetrahedralization;



        /*
            摘要:
            Calculate "light probes" and "occlusion probes" at the given world-space positions.

            直观的看, 本函数可以传入一组 posWS, 经过函数计算后, 最终将这个 posWS 位置的 lightprobe信息 和 occlusionprobe信息
            (都是 sh系数) 写入 参数 lightProbes, occlusionProbes 提供的两个容器中;

            猜测:
                这个 posWS 并不是那些 预烘焙的 探针的pos, 而是任意pos;

            如果场景中没有预烘焙的 probes 数据, 就会:
                -- 将 ambient probe 写入 "lightProbes array", (猜测就是 unity 默认设置的环境光)
                -- 将 Vector4(1,1,1,1) 写入 "occlusionProbes array"; (意为没有任何遮蔽)

            如果参数 positions 为 null, 会抛出异常;

            当然, 你也可以将 参数 lightProbes 或 occlusionProbes 二者之一设为 null,  以此来表达: 这一种数据我不需要;
            但是你不能将这两个参数同时设为 null, (那还传个啥), 此时会抛出异常;

            最好的选择还是同时接收 lightprobe 和 occlusionprobe 数据, 这样得到的视觉效果是最好的;
            ---

            对于 "参数为数组的那个函数重载":
                参数 lightProbes 和 occlusionProbes 这两个 array 能容纳的元素个数, 至少不能少于 positions 的;

            对于 "参数为 List<> 的那个函数重载":
                如果参数 lightProbes 和 occlusionProbes 这两个 List, 当前分配的空间不够, 就会对它们已经 resize;

            ====

            最终计算出来的 两组 probes 数据, 可通过:
                MaterialPropertyBlock.CopySHCoefficientArraysFrom()
                MaterialPropertyBlock.CopyProbeOcclusionArrayFrom()
            将它们复制给一个 支持 MaterialPropertyBlock 的物体,
            以此来渲染这个物体;
            

        // 参数:
        //   positions:
        //     The array of world-space poses used to evaluate the probes. 输入的数据
        //
        //   lightProbes:
        //     The array where the resulting light probes are written to.  输出值
        //
        //   occlusionProbes:
        //     The array where the resulting occlusion probes are written to. 输出值
        */
        public static void CalculateInterpolatedLightAndOcclusionProbes(Vector3[] positions, SphericalHarmonicsL2[] lightProbes, Vector4[] occlusionProbes);
        public static void CalculateInterpolatedLightAndOcclusionProbes(List<Vector3> positions, List<SphericalHarmonicsL2> lightProbes, List<Vector4> occlusionProbes);
        
        
        /*
            Returns an interpolated probe for the given position for both realtime and baked light probes combined.

            返回 position 位置的 插值过的 探针信息, 这个信息综合了 实时+烘焙 数据;

            之所以需要 参数 renderer, 是因为它携带了 它在上一帧中位于的 四面体的 idx, 依据这个信息, 可以加速查找出 position
            所在的 四面体;
        */
        [FreeFunctionAttribute]
        public static void GetInterpolatedProbe(Vector3 position, Renderer renderer, out SphericalHarmonicsL2 probe);



        /*
            摘要:
            Synchronously tetrahedralize(同步四面体化) the currently loaded LightProbe positions.

            Call this function to tetrahedralize the currently loaded LightProbe positions.

            通常, 你应该只在接收到 LightProbes.needsRetetrahedralization 事件时, 才调用本函数;
        */
        [FreeFunctionAttribute]
        public static void Tetrahedralize();



        /*
            摘要:
            Asynchronously tetrahedralize(异步四面体化) the currently loaded LightProbe positions.

            Call this function to tetrahedralize the currently loaded LightProbe positions.

            通常, 你应该只在接收到 LightProbes.needsRetetrahedralization  事件时, 才调用本函数;
        */
        [FreeFunctionAttribute]
        public static void TetrahedralizeAsync();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use GetInterpolatedProbe instead.", true)]
        public void GetInterpolatedLightProbe(Vector3 position, Renderer renderer, float[] coefficients);
        */

    }
}

