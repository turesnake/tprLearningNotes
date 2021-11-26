#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Rendering
{
    /*
        Opaque object sorting mode of a Camera.

        有数种规则来对 不透明物体做排序:
            -- sorting layers, 
            -- shader queues, 
            -- materials, 
            -- distance, 
            -- lightmaps

        为了最大化 cpu 效率 (减少 render state 的改动次数, 提高 draw call batch 成功率)
        最大化 gpu 效率 ( 大部分 gpu 都喜欢 从前向后 的顺序执行渲染, 以便把遮挡的 fragments 都 剔除掉 )

        默认, 不透明物体被粗略地整合成 从前向后的 buckets, (因为这样对大部分 gpu 有利)
        
        但是少数 gpu 不喜欢这种排序方式, ( 主要是: PowerVR/Apple GPUs ),
        所以针对这些 gpu, 默认不会执行 基于 distance 的 排序;

        改写 "Camera.opaqueSortMode" 可以覆写上述默认功能, 
        比如, 如果你觉得在你的程序中, cpu算力 更为宝贵, 那么你可以彻底关闭 distance-based sorting;
    */
    public enum OpaqueSortMode//OpaqueSortMode__
    {
        
        /*
            Default opaque sorting mode.
            估计就是上文介绍的各种 "通常" 配置;
        */
        Default = 0,
        
        /*
            Do rough front-to-back sorting of opaque objects.

            执行粗略的, 桶式的, 从前到后 排序;
        */
        FrontToBack = 1,


        //     Do not sort opaque objects by distance.
        NoDistanceSort = 2
    }
}

