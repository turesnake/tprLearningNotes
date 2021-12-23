#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine
{
    /*
        A single keyframe that can be injected into an animation curve.
        ---
        十分类似 ps 中的钢笔曲线
    */
    [RequiredByNativeCodeAttribute]
    public struct Keyframe//Keyframe__RR
    {

        // 构造函数
        // 参数:
        //   time:
        //      猜测就是 x 轴值
        //   value:
        //      猜测就是 y 轴值
        //   inTangent:
        //      节点左侧 控制线的斜率
        //   outTangent:
        //      节点右侧 控制线的斜率
        //   inWeight:
        //      节点左侧 控制线的权重
        //   outWeight:
        //      节点右侧 控制线的权重
        public Keyframe(float time, float value);
        public Keyframe(float time, float value, float inTangent, float outTangent);
        public Keyframe(float time, float value, float inTangent, float outTangent, float inWeight, float outWeight);



        //
        // 摘要:
        //     The time of the keyframe.
        public float time { get; set; }
        //
        // 摘要:
        //     The value of the curve at keyframe.
        public float value { get; set; }

        /*
            Sets the incoming tangent for this key. The incoming tangent affects the slope
            of the curve from the previous key to this key.
            ----
            影响节点 左侧斜率; (应该是和 +x 轴方向的 夹角的 tan值)
            而且这东西好像是没有方向的, 即: 45度角 和 225度是相同的 (猜测)
        */
        public float inTangent { get; set; }
        /*
            Sets the outgoing tangent for this key. The outgoing tangent affects the slope
            of the curve from this key to the next key.
            ----
            影响节点 右侧斜率; (应该是和 +x 轴方向的 夹角的 tan值)
            而且这东西好像是没有方向的, 即: 45度角 和 225度是相同的 (猜测)
        */
        public float outTangent { get; set; }


        //
        // 摘要:
        //     Sets the incoming weight for this key. The incoming weight affects the slope
        //     of the curve from the previous key to this key.
        public float inWeight { get; set; }
        //
        // 摘要:
        //     Sets the outgoing weight for this key. The outgoing weight affects the slope
        //     of the curve from this key to the next key.
        public float outWeight { get; set; }
        //
        // 摘要:
        //     Weighted mode for the keyframe.
        public WeightedMode weightedMode { get; set; }
        //
        // 摘要:
        //     TangentMode is deprecated. Use AnimationUtility.SetKeyLeftTangentMode or AnimationUtility.SetKeyRightTangentMode
        //     instead.
        [Obsolete("Use AnimationUtility.SetKeyLeftTangentMode, AnimationUtility.SetKeyRightTangentMode, AnimationUtility.GetKeyLeftTangentMode or AnimationUtility.GetKeyRightTangentMode instead.")]
        public int tangentMode { get; set; }
    }
}

