#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;

namespace UnityEngine
{
    /*
        Store a collection of Keyframes that can be evaluated over time.

        srp core 库中实现了本类的 wrapper 版: "TextureCurve";

    */
    [DefaultMember("Item")]
    [NativeHeaderAttribute("Runtime/Math/AnimationCurve.bindings.h")]
    [RequiredByNativeCodeAttribute]
    public class AnimationCurve //AnimationCurve__
        : IEquatable<AnimationCurve>
    {
        
        //     Creates an empty animation curve.
        [RequiredByNativeCodeAttribute]
        public AnimationCurve();

        /*
            Creates an animation curve from an arbitrary number of keyframes.
            
            This creates a curve from variable number of Keyframe parameters. 
            If you want to create curve from an array of keyframes, create an empty curve and assign keys property.
        
        // 参数:
        //   keys:
        //     An array of Keyframes used to define the curve.
        */
        public AnimationCurve(params Keyframe[] keys);


        ~AnimationCurve();

        // 可以遍历自己
        public Keyframe this[int index] { get; }

      
        //     The number of keys in the curve. (Read Only)
        public int length { get; }


        /*
            All keys defined in the animation curve.

            This lets you clear, add or remove any keys from the array. 
            If keys are not sorted by time, they will be automatically sorted on assignment.

            Note that the array is "by value", i.e. getting keys returns a copy of all keys 
            and setting keys copies them into the curve.
            ---
            如果传入的 keys 不是按照时间排序的, 那么传入后, 在对本容器元素进行真正的生成时, 会自动执行排序;
            至于, 针对本变量的读写是 "值传递", 传入的值将被复制到本变量出, 拿出的值也是 copy 版;
        */
        public Keyframe[] keys { get; set; }

     
        //  The behaviour of the animation before the first keyframe.
        //  enum: Default, Once, Clamp, Loop, PingPong, ClampForever;
        public WrapMode preWrapMode { get; set; }
        
        //  The behaviour of the animation after the last keyframe.
        //  enum: Default, Once, Clamp, Loop, PingPong, ClampForever;
        public WrapMode postWrapMode { get; set; }

        /*
            Creates a constant "curve" starting at timeStart, ending at timeEnd and with the value value.
        // 参数:
        //   timeStart:
        //     The start time for the constant curve.
        //   timeEnd:
        //     The end time for the constant curve.
        //   value:
        //     The value for the constant curve.
        // 返回结果:
        //     The constant curve created from the specified values.
        */
        public static AnimationCurve Constant(float timeStart, float timeEnd, float value);

        /*
            Creates an ease-in and out curve starting at timeStart, valueStart and ending at timeEnd, valueEnd.
            缓入缓出曲线;
        // 参数:
        //   timeStart:
        //     The start time for the ease curve.
        //   valueStart:
        //     The start value for the ease curve.
        //   timeEnd:
        //     The end time for the ease curve.
        //   valueEnd:
        //     The end value for the ease curve.
        // 返回结果:
        //     The ease-in and out curve generated from the specified values.
        */
        public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd);

        /*
            A straight Line starting at timeStart, valueStart and ending at timeEnd, valueEnd.
        // 参数:
        //   timeStart:
        //     The start time for the linear curve.
        //   valueStart:
        //     The start value for the linear curve.
        //   timeEnd:
        //     The end time for the linear curve.
        //   valueEnd:
        //     The end value for the linear curve.
        // 返回结果:
        //     The linear curve created from the specified values.
        */
        public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd);

        /*
            Add a new key to the curve.

        // 参数:
        //   key:
        //     The key to add to the curve.
        //
        // 返回结果:
            The index of the added key, or -1 if the key could not be added.
            If no key could be added because there is already another keyframe at the same time 
            -1 will be returned.
        */
        public int AddKey(Keyframe key);

        /*
            Add a new key to the curve.

            Smooth tangents are automatically computed for the key.
            
        // 参数:
        //   time:
        //     The time at which to add the key (horizontal axis in the curve graph). x轴值
        //
        //   value:
        //     The value for the key (vertical axis in the curve graph). y轴值
        //
        // 返回结果:
            The index of the added key, or -1 if the key could not be added.
            If no key could be added because there is already another keyframe at the same time -1 will be returned.
        */
        [FreeFunctionAttribute("AnimationCurveBindings::AddKeySmoothTangents", HasExplicitThis = true, IsThreadSafe = true)]
        public int AddKey(float time, float value);


        public override bool Equals(object o);
        public bool Equals(AnimationCurve other);


        /*
            Evaluate the curve at time.
            传入 x值, 求解 y 值;

        // 参数:
        //   time:
        //     The time within the curve you want to evaluate (the horizontal axis in the curve graph).
        // 返回结果:
        //     The value of the curve, at the point in time specified.
        */
        [ThreadSafeAttribute]
        public float Evaluate(float time);


        public override int GetHashCode();


        /*
            Removes the keyframe at index and inserts key.
            If a keyframe already exists at "key.time", then the time of the old keyframe's position: "key[index].time" 
            will be used instead. 
            This is the desired behaviour for dragging keyframes in a curve editor.
            ---
        // 参数:
        //   index:
        //     The index of the key to move.
        //
        //   key:
        //     The key (with its new time) to insert.
        //
        // 返回结果:
        //     The index of the keyframe after moving it.
        */
        [FreeFunctionAttribute("AnimationCurveBindings::MoveKey", HasExplicitThis = true, IsThreadSafe = true)]
        [NativeThrowsAttribute]
        public int MoveKey(int index, Keyframe key);

       
        //  Removes a key.
        // 参数:
        //   index:
        //     The index of the key to remove.
        [FreeFunctionAttribute("AnimationCurveBindings::RemoveKey", HasExplicitThis = true, IsThreadSafe = true)]
        [NativeThrowsAttribute]
        public void RemoveKey(int index);
        

        /*
            Smooth the in and out tangents of the keyframe at index.
            平滑某个 keyframe; 

            A weight of 0 evens out tangents. (没看懂)
            evens out: 拉平;
        
        // 参数:
        //   index:
        //     The index of the keyframe to be smoothed.
        //   weight:
        //     The smoothing weight to apply to the keyframe's tangents.
        */
        [FreeFunctionAttribute("AnimationCurveBindings::SmoothTangents", HasExplicitThis = true, IsThreadSafe = true)]
        [NativeThrowsAttribute]
        public void SmoothTangents(int index, float weight);
    }
}

