#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        How to sort objects during rendering.

        Control the way Unity sorts objects before drawing them by using and combining these flags

        有几个 flag 是基础的, 还有几个是用基础 flag 组合起来的;

    */
    [Flags]
    public enum SortingCriteria//SortingCriteria__
    {
        
        // 摘要:
        //     Do not sort objects.
        None = 0,


        /*
            摘要:
            Sort by renderer sorting layer.

            SortingLayer:
                被用于 2D 系统, 比如 sprites 的排序;
        */
        SortingLayer = 1,

        /*
            摘要:
            Sort by material "render queue".

            就是下面这组概念:
            -- metarial 可直接设置的 Rendering Mode: Opaque, Cutout, Fade, Transparent
            -- shader 中: 
                Tags { "Queue" = "Transparent+1" } 
        */
        RenderQueue = 2,

        /*
            摘要:
            Sort objects back to front.
            通常 半透明物体 需要执行此排序, 实心物体则不做 这道排序
        */
        BackToFront = 4,
        
        /*
            摘要:
            Sort objects "in rough front-to-back buckets".

            不再是精确的 逐物体 排序, 而是用几个桶 来表达深度值;
            做粗略排序

            下方的 CommonOpaque 用到了它, 说明 不透明物体 也会做适当的 前后排序
        */
        QuantizedFrontToBack = 8,


        /*
            摘要:
            Sort objects to reduce draw state changes.
            猜测:
                尽可能把 draw state 相同的物体放到一起; 
                以便 GPU Instancing, SRP Batch 等优化机制能起效;
        */
        OptimizeStateChanges = 16,


        /*
            摘要:
            Sort renderers taking canvas order into account.
            猜测:
                UI 物体相关的
        */
        CanvasOrder = 32,


        /*
            摘要:
            Sorts objects by renderer priority.

            "Renderer.rendererPriority" (变量) 
                inspector 中没发现有,
                小值优先级高, 先渲染, 大值后渲染;
        */
        RendererPriority = 64,


        //================================= 下面是 组合 flags ===================================== //

        /*
            摘要:
            Typical sorting for transparencies.
            包含:
                SortingLayer, 
                RenderQueue, 
                BackToFront, 
                OptimizeStateChanges 
        */
        CommonTransparent = 23,


        /*
            摘要:
            Typical sorting for opaque objects.
            包含:
                SortingLayer, 
                RenderQueue, 
                QuantizedFrontToBack,  // 适当的前后排序
                OptimizeStateChanges, 
                CanvasOrder
        */
        CommonOpaque = 59
    }
}

