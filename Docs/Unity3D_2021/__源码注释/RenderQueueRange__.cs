#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Describes a "material render queue range".

        猜测:
            本类实例 携带一个 range 信息 [上界值, 下界值], 
            只要被检测物体的 material render queue range 位于这个 区间内 (边界包含), 
            这个物体就会被认为是 "位于区间内的";

            还能使用 static 预定义实例:  all, opaque, transparent 来快速得到 目标区间;

    */
    public struct RenderQueueRange : IEquatable<RenderQueueRange>//RenderQueueRange__
    {
        
        // 摘要:
        //     Minimum value that can be used as a bound.
        public static readonly int minimumBound;
        
        // 摘要:
        //     Maximum value that can be used as a bound.
        public static readonly int maximumBound;


        /*
            摘要:
            Create a render queue range struct.
            
            参数:
            lowerBound:
                Inclusive lower bound for the range.
            
            upperBound:
                Inclusive upper bound for the range.
        */
        public RenderQueueRange(int lowerBound, int upperBound);

        
        // 摘要:
        //     A range that includes all objects.
        public static RenderQueueRange all { get; }
        
        // 摘要:
        //     A range that includes only opaque objects.
        public static RenderQueueRange opaque { get; }

        // 摘要:
        //     A range that includes only transparent objects.
        public static RenderQueueRange transparent { get; }

        /*
            摘要:
            Inclusive lower bound for the range.

            包含范围的 下限;
            物体的 material render queue 值, 只要大于等于 本变量, 就能被包含;
        */
        public int lowerBound { get; set; }

        /*
            摘要:
            Inclusive upper bound for the range.

            包含范围的上界:
            物体的 material render queue 值, 只要小于等于 本变量, 就能被包含;
        */
        public int upperBound { get; set; }


        public bool Equals(RenderQueueRange other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(RenderQueueRange left, RenderQueueRange right);
        public static bool operator !=(RenderQueueRange left, RenderQueueRange right);
    }
}

