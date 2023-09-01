#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Playables;

namespace UnityEngine
{
    /*
        Interface to control the Mecanim animation system.

        ==============
        设置变量值:
            static int id = Animator.StringToHash("_AAA");
            animator.SetFloat( id, 0.1f );






    */
    [NativeHeaderAttribute("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
    [NativeHeaderAttribute("Modules/Animation/ScriptBindings/Animator.bindings.h")]
    [NativeHeaderAttribute("Modules/Animation/Animator.h")]
    [UsedByNativeCodeAttribute]
    public class Animator : Behaviour
    {
        public Animator();

        //
        // 摘要:
        //     Controls the behaviour of the Animator component when a GameObject is disabled.
        public bool keepAnimatorControllerStateOnDisable { get; set; }

        /*
            https://www.bilibili.com/video/BV11T4y1Y7RX/?spm_id_from=333.788&vd_source=df0fa6bb68b75a198c4c3f59ce640962

            下二变量 只在 Humanoid 动画 中存在, 因为在 Humanoid 中, 所有骨骼都被转化为了 "肌肉" 这个概念;
            进而不再存在 根骨骼 root 这个东西; 相应的, unity 自己计算了一个 "质心点";
            ----
            这个 质心点 一般位于 角色的 臀部区域, 和传统人形模型的 root node 的位置其实是非常接近的;
            ---
            然后, unity 根据当前动画, 计算本帧 质心点 在 xz平面的 投影点, 然后把这个 投影点, 当作角色的 "根节点";
            这个 投影点 被称为 "root transform"
                有关它的参数为:
                    rootPosition
                    rootRotation

            bodyPosition 就是 质心点 的 pos;      (ws)
            bodyRotation 就是 质心点 的 rotation; (ws)
            ---
            这两个变量只能在 OnAnimatorIK() 中改写这两个值;

        */
        //     The rotation of the body center of mass.
        public Quaternion bodyRotation { get; set; }
        //     The position of the body center of mass.
        public Vector3 bodyPosition { get; set; }


        //
        // 摘要:
        //     Returns true if the object has a transform hierarchy.
        public bool hasTransformHierarchy { get; }
        //
        // 摘要:
        //     Specifies the update mode of the Animator.
        public AnimatorUpdateMode updateMode { get; set; }
        //
        // 摘要:
        //     When turned on, animations will be executed in the physics loop. This is only
        //     useful in conjunction with kinematic rigidbodies.
        [Obsolete("Animator.animatePhysics has been deprecated. Use Animator.updateMode instead.")]
        public bool animatePhysics { get; set; }
        //
        // 摘要:
        //     When linearVelocityBlending is set to true, the root motion velocity and angular
        //     velocity will be blended linearly.
        [Obsolete("Animator.linearVelocityBlending is no longer used and has been deprecated.")]
        public bool linearVelocityBlending { get; set; }
        //
        // 摘要:
        //     Should root motion be applied?
        public bool applyRootMotion { get; set; }


        // "root tranform" (质心点到 xz平面的投影点) 的 pos 和 rotation; (ws)
        // 参考本文件 上方的 "bodyPosition" 区域 有关 "质心点" 的描述;
        //   
        //     The root rotation, the rotation of the game object.
        public Quaternion rootRotation { get; set; }
        //     The root position, the position of the game object.
        public Vector3 rootPosition { get; set; }



        //
        // 摘要:
        //     Gets the avatar angular velocity for the last evaluated frame.
        public Vector3 angularVelocity { get; }
        //
        // 摘要:
        //     Gets the avatar velocity for the last evaluated frame.
        public Vector3 velocity { get; }


        /*
            Gets the avatar delta rotation for the last evaluated frame.
            Animator.applyRootMotion must be enabled for deltaRotation to be calculated.
            ---
            只有在开启 root motion 功能后, 才会被计算的 上帧-本帧 旋转量 (已经计算进了角色的缩放值);

            可在 OnAnimatorMove() 函数内, 直接写:

        */
        public Quaternion deltaRotation { get; }

        /*
            Gets the avatar delta position for the last evaluated frame.
            Animator.applyRootMotion must be enabled for deltaPosition to be calculated.
            --
            只有在开启 root motion 功能后, 才会被计算的 上帧-本帧 位移量 (已经计算进了角色的缩放值);

            可在 OnAnimatorMove() 函数内, 直接写:
                transform.position += animator.deltaPosition;
            
            来模拟相同的 root motion 功能;

        */
        public Vector3 deltaPosition { get; }


        //
        // 摘要:
        //     Returns whether the animator is initialized successfully.
        public bool isInitialized { get; }


        /*
            Returns the scale of the current Avatar for a humanoid rig, (1 by default if the rig is generic).
            The scale is relative to Unity's Default Avatar.  ( Unity's Default Avatar 的 scale 值为 1f  )
            ---
            如果启用了 root motion,
            且多个角色 共用一套 animator controller, 那么各个角色的 humanScale 会影响最终的移动速度;
            humanScale 值较小的角色, 最终移动速度会较慢; 此时就需要用 本值来修正

        */
        public float humanScale { get; }


        //
        // 摘要:
        //     Returns true if the current rig has root motion.
        public bool hasRootMotion { get; }
        //
        // 摘要:
        //     Returns true if the current rig is humanoid, false if it is generic.
        public bool isHuman { get; }
        //
        // 摘要:
        //     Returns true if the current rig is optimizable with AnimatorUtility.OptimizeTransformHierarchy.
        public bool isOptimizable { get; }
        //
        // 摘要:
        //     Sets whether the Animator sends events of type AnimationEvent.
        public bool fireEvents { get; set; }
        //
        // 摘要:
        //     Automatic stabilization of feet during transition and blending.
        public bool stabilizeFeet { get; set; }
        //
        // 摘要:
        //     Returns the number of layers in the controller.
        public int layerCount { get; }
        //
        // 摘要:
        //     The current gravity weight based on current animations that are played.
        public float gravityWeight { get; }
        //
        // 摘要:
        //     Returns the number of parameters in the controller.
        public int parameterCount { get; }
        public bool logWarnings { get; set; }
        //
        // 摘要:
        //     Get right foot bottom height.
        public float rightFeetBottomHeight { get; }
        //
        // 摘要:
        //     Get left foot bottom height.
        public float leftFeetBottomHeight { get; }
        //
        // 摘要:
        //     Additional layers affects the center of mass.
        public bool layersAffectMassCenter { get; set; }
        //
        // 摘要:
        //     The PlayableGraph created by the Animator.
        public PlayableGraph playableGraph { get; }
        //
        // 摘要:
        //     Gets/Sets the current Avatar.
        public Avatar avatar { get; set; }
        //
        // 摘要:
        //     The AnimatorControllerParameter list used by the animator. (Read Only)
        public AnimatorControllerParameter[] parameters { get; }
        //
        // 摘要:
        //     The runtime representation of AnimatorController that controls the Animator.
        public RuntimeAnimatorController runtimeAnimatorController { get; set; }
        //
        // 摘要:
        //     Gets the mode of the Animator recorder.
        public AnimatorRecorderMode recorderMode { get; }
        //
        // 摘要:
        //     End time of the recorded clip relative to when StartRecording was called.
        public float recorderStopTime { get; set; }
        //
        // 摘要:
        //     Returns true if Animator has any playables assigned to it.
        public bool hasBoundPlayables { get; }
        //
        // 摘要:
        //     Sets the playback position in the recording buffer.
        public float playbackTime { get; set; }
        //
        // 摘要:
        //     Controls culling of this Animator component.
        public AnimatorCullingMode cullingMode { get; set; }
        //
        // 摘要:
        //     Returns the rotation of the target specified by SetTarget.
        public Quaternion targetRotation { get; }
        //
        // 摘要:
        //     Returns the position of the target specified by SetTarget.
        public Vector3 targetPosition { get; }
        //
        // 摘要:
        //     The playback speed of the Animator. 1 is normal playback speed.
        public float speed { get; set; }
        //
        // 摘要:
        //     If automatic matching is active.
        public bool isMatchingTarget { get; }
        //
        // 摘要:
        //     Get the current position of the pivot.
        public Vector3 pivotPosition { get; }
        //
        // 摘要:
        //     Blends pivot point between body center of mass and feet pivot.
        public float feetPivotActive { get; set; }
        //
        // 摘要:
        //     Gets the pivot weight.
        public float pivotWeight { get; }
        //
        // 摘要:
        //     Start time of the first frame of the buffer relative to the frame at which StartRecording
        //     was called.
        public float recorderStartTime { get; set; }

        //
        // 摘要:
        //     Generates an parameter id from a string.
        //
        // 参数:
        //   name:
        //     The string to convert to Id.
        [NativeMethodAttribute(Name = "ScriptingStringToCRC32", IsThreadSafe = true)]
        public static int StringToHash(string name);


        //
        // 摘要:
        //     Apply the default Root Motion.
        public void ApplyBuiltinRootMotion();
        public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer);
        public void CrossFade(string stateName, float normalizedTransitionDuration, int layer);
        //
        // 摘要:
        //     Creates a crossfade from the current state to any other state using normalized
        //     times.
        //
        // 参数:
        //   stateName:
        //     The name of the state.
        //
        //   stateHashName:
        //     The hash name of the state.
        //
        //   normalizedTransitionDuration:
        //     The duration of the transition (normalized).
        //
        //   layer:
        //     The layer where the crossfade occurs.
        //
        //   normalizedTimeOffset:
        //     The time of the state (normalized).
        //
        //   normalizedTransitionTime:
        //     The time of the transition (normalized).
        [FreeFunctionAttribute(Name = "AnimatorBindings::CrossFade", HasExplicitThis = true)]
        public void CrossFade(int stateHashName, float normalizedTransitionDuration, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("0.0f")] float normalizedTimeOffset, [Internal.DefaultValue("0.0f")] float normalizedTransitionTime);
        //
        // 摘要:
        //     Creates a crossfade from the current state to any other state using normalized
        //     times.
        //
        // 参数:
        //   stateName:
        //     The name of the state.
        //
        //   stateHashName:
        //     The hash name of the state.
        //
        //   normalizedTransitionDuration:
        //     The duration of the transition (normalized).
        //
        //   layer:
        //     The layer where the crossfade occurs.
        //
        //   normalizedTimeOffset:
        //     The time of the state (normalized).
        //
        //   normalizedTransitionTime:
        //     The time of the transition (normalized).
        public void CrossFade(string stateName, float normalizedTransitionDuration, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("float.NegativeInfinity")] float normalizedTimeOffset, [Internal.DefaultValue("0.0f")] float normalizedTransitionTime);
        public void CrossFade(string stateName, float normalizedTransitionDuration);
        public void CrossFade(int stateHashName, float normalizedTransitionDuration);
        public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset);
        public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset);
        //
        // 摘要:
        //     Creates a crossfade from the current state to any other state using times in
        //     seconds.
        //
        // 参数:
        //   stateName:
        //     The name of the state.
        //
        //   stateHashName:
        //     The hash name of the state.
        //
        //   fixedTransitionDuration:
        //     The duration of the transition (in seconds).
        //
        //   layer:
        //     The layer where the crossfade occurs.
        //
        //   fixedTimeOffset:
        //     The time of the state (in seconds).
        //
        //   normalizedTransitionTime:
        //     The time of the transition (normalized).
        [FreeFunctionAttribute(Name = "AnimatorBindings::CrossFadeInFixedTime", HasExplicitThis = true)]
        public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("0.0f")] float fixedTimeOffset, [Internal.DefaultValue("0.0f")] float normalizedTransitionTime);
        public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration);
        public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration);
        public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer);
        public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset);
        //
        // 摘要:
        //     Creates a crossfade from the current state to any other state using times in
        //     seconds.
        //
        // 参数:
        //   stateName:
        //     The name of the state.
        //
        //   stateHashName:
        //     The hash name of the state.
        //
        //   fixedTransitionDuration:
        //     The duration of the transition (in seconds).
        //
        //   layer:
        //     The layer where the crossfade occurs.
        //
        //   fixedTimeOffset:
        //     The time of the state (in seconds).
        //
        //   normalizedTransitionTime:
        //     The time of the transition (normalized).
        public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("0.0f")] float fixedTimeOffset, [Internal.DefaultValue("0.0f")] float normalizedTransitionTime);
        public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset);
        public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer);
        [Obsolete("ForceStateNormalizedTime is deprecated. Please use Play or CrossFade instead.")]
        public void ForceStateNormalizedTime(float normalizedTime);
        //
        // 摘要:
        //     Returns an AnimatorTransitionInfo with the informations on the current transition.
        //
        // 参数:
        //   layerIndex:
        //     The layer's index.
        //
        // 返回结果:
        //     An AnimatorTransitionInfo with the informations on the current transition.
        public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex);
        public T GetBehaviour<T>() where T : StateMachineBehaviour;
        public T[] GetBehaviours<T>() where T : StateMachineBehaviour;
        public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex);


        /*
            Returns Transform mapped to this human bone id. 
            Returns null if the animator组件 is disabled, or if it does not have a human description, or if the bone id is invalid.
            ---
            
            参数:
            humanBoneId:
                The human bone that is queried, see enum HumanBodyBones for a list of possible
                values.
        */
        public Transform GetBoneTransform(HumanBodyBones humanBoneId);


        //
        // 摘要:
        //     Returns the value of the given boolean parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public bool GetBool(string name);
        //
        // 摘要:
        //     Returns the value of the given boolean parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public bool GetBool(int id);
        //
        // 摘要:
        //     Gets the list of AnimatorClipInfo currently played by the current state.
        //
        // 参数:
        //   layerIndex:
        //     The layer's index.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetCurrentAnimationClipState is obsolete. Use GetCurrentAnimatorClipInfo instead (UnityUpgradable) -> GetCurrentAnimatorClipInfo(*)", true)]
        public AnimationInfo[] GetCurrentAnimationClipState(int layerIndex);
        //
        // 摘要:
        //     Returns an array of all the AnimatorClipInfo in the current state of the given
        //     layer.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     An array of all the AnimatorClipInfo in the current state.
        [FreeFunctionAttribute(Name = "AnimatorBindings::GetCurrentAnimatorClipInfo", HasExplicitThis = true)]
        public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex);
        public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips);
        //
        // 摘要:
        //     Returns the number of AnimatorClipInfo in the current state.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     The number of AnimatorClipInfo in the current state.
        public int GetCurrentAnimatorClipInfoCount(int layerIndex);


        /*
            Returns an AnimatorStateInfo with the information on the current state.

            常见用法:

                stateInfo = animator.GetCurrentAnimatorStateInfo( animator.GetLayerIndex("Base Layer") );

            这里的 "state" 就是指: 当前时刻, animator 正运行到哪一个 .anim clip 状态; (就是 animator 里的那些块块);
            这个 state信息 时刻在变动, 应该随用随取;
            
            参数:
            layerIndex:
                The layer index.
            
            返回结果:
                An AnimatorStateInfo with the information on the current state.
        */
        public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);


        //
        // 摘要:
        //     Returns the value of the given float parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public float GetFloat(string name);
        //
        // 摘要:
        //     Returns the value of the given float parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public float GetFloat(int id);
        //
        // 摘要:
        //     Gets the position of an IK hint.
        //
        // 参数:
        //   hint:
        //     The AvatarIKHint that is queried.
        //
        // 返回结果:
        //     Return the current position of this IK hint in world space.
        public Vector3 GetIKHintPosition(AvatarIKHint hint);
        //
        // 摘要:
        //     Gets the translative weight of an IK Hint (0 = at the original animation before
        //     IK, 1 = at the hint).
        //
        // 参数:
        //   hint:
        //     The AvatarIKHint that is queried.
        //
        // 返回结果:
        //     Return translative weight.
        public float GetIKHintPositionWeight(AvatarIKHint hint);
        //
        // 摘要:
        //     Gets the position of an IK goal.
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is queried.
        //
        // 返回结果:
        //     Return the current position of this IK goal in world space.
        public Vector3 GetIKPosition(AvatarIKGoal goal);
        //
        // 摘要:
        //     Gets the translative weight of an IK goal (0 = at the original animation before
        //     IK, 1 = at the goal).
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is queried.
        public float GetIKPositionWeight(AvatarIKGoal goal);
        //
        // 摘要:
        //     Gets the rotation of an IK goal.
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is is queried.
        public Quaternion GetIKRotation(AvatarIKGoal goal);
        //
        // 摘要:
        //     Gets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation
        //     at the IK goal).
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is queried.
        public float GetIKRotationWeight(AvatarIKGoal goal);
        //
        // 摘要:
        //     Returns the value of the given integer parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public int GetInteger(int id);
        //
        // 摘要:
        //     Returns the value of the given integer parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     The value of the parameter.
        public int GetInteger(string name);


        //
        // 摘要:
        //     Returns the index of the layer with the given name.
        //
        // 参数:
        //   layerName:
        //     The layer name.
        //
        // 返回结果:
        //     The layer index.
        public int GetLayerIndex(string layerName);


        //
        // 摘要:
        //     Returns the layer name.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     The layer name.
        public string GetLayerName(int layerIndex);
        //
        // 摘要:
        //     Returns the weight of the layer at the specified index.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     The layer weight.
        public float GetLayerWeight(int layerIndex);
        //
        // 摘要:
        //     Gets the list of AnimatorClipInfo currently played by the next state.
        //
        // 参数:
        //   layerIndex:
        //     The layer's index.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetNextAnimationClipState is obsolete. Use GetNextAnimatorClipInfo instead (UnityUpgradable) -> GetNextAnimatorClipInfo(*)", true)]
        public AnimationInfo[] GetNextAnimationClipState(int layerIndex);
        public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips);
        //
        // 摘要:
        //     Returns an array of all the AnimatorClipInfo in the next state of the given layer.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     An array of all the AnimatorClipInfo in the next state.
        [FreeFunctionAttribute(Name = "AnimatorBindings::GetNextAnimatorClipInfo", HasExplicitThis = true)]
        public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex);
        //
        // 摘要:
        //     Returns the number of AnimatorClipInfo in the next state.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     The number of AnimatorClipInfo in the next state.
        public int GetNextAnimatorClipInfoCount(int layerIndex);
        //
        // 摘要:
        //     Returns an AnimatorStateInfo with the information on the next state.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     An AnimatorStateInfo with the information on the next state.
        public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex);
        //
        // 摘要:
        //     See AnimatorController.parameters.
        //
        // 参数:
        //   index:
        public AnimatorControllerParameter GetParameter(int index);
        //
        // 摘要:
        //     Gets the value of a quaternion parameter.
        //
        // 参数:
        //   id:
        //     The id of the parameter. The id is generated using Animator::StringToHash.
        [Obsolete("GetQuaternion is deprecated.")]
        public Quaternion GetQuaternion(int id);
        //
        // 摘要:
        //     Gets the value of a quaternion parameter.
        //
        // 参数:
        //   name:
        //     The name of the parameter.
        [Obsolete("GetQuaternion is deprecated.")]
        public Quaternion GetQuaternion(string name);
        //
        // 摘要:
        //     Gets the value of a vector parameter.
        //
        // 参数:
        //   name:
        //     The name of the parameter.
        [Obsolete("GetVector is deprecated.")]
        public Vector3 GetVector(string name);
        //
        // 摘要:
        //     Gets the value of a vector parameter.
        //
        // 参数:
        //   id:
        //     The id of the parameter. The id is generated using Animator::StringToHash.
        [Obsolete("GetVector is deprecated.")]
        public Vector3 GetVector(int id);
        //
        // 摘要:
        //     Returns true if the state exists in this layer, false otherwise.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        //   stateID:
        //     The state ID.
        //
        // 返回结果:
        //     True if the state exists in this layer, false otherwise.
        public bool HasState(int layerIndex, int stateID);
        //
        // 摘要:
        //     Interrupts the automatic target matching.
        //
        // 参数:
        //   completeMatch:
        public void InterruptMatchTarget([Internal.DefaultValue("true")] bool completeMatch);
        //
        // 摘要:
        //     Interrupts the automatic target matching.
        //
        // 参数:
        //   completeMatch:
        public void InterruptMatchTarget();
        //
        // 摘要:
        //     Returns true if the transform is controlled by the Animator\.
        //
        // 参数:
        //   transform:
        //     The transform that is queried.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use mask and layers to control subset of transfroms in a skeleton.", true)]
        public bool IsControlled(Transform transform);
        //
        // 摘要:
        //     Returns true if there is a transition on the given layer, false otherwise.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        // 返回结果:
        //     True if there is a transition on the given layer, false otherwise.
        public bool IsInTransition(int layerIndex);
        //
        // 摘要:
        //     Returns true if the parameter is controlled by a curve, false otherwise.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     True if the parameter is controlled by a curve, false otherwise.
        public bool IsParameterControlledByCurve(string name);
        //
        // 摘要:
        //     Returns true if the parameter is controlled by a curve, false otherwise.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        // 返回结果:
        //     True if the parameter is controlled by a curve, false otherwise.
        public bool IsParameterControlledByCurve(int id);
        


        
        /*
            摘要:
                Automatically adjust the GameObject position and rotation.

                Adjust the GameObject position and rotation so that the AvatarTarget reaches the matchPosition when the current state is at the specified progress. 
                Target matching only works on the base layer (index 0). 
                You can only queue one match target at a time and you must wait for the first one to finish, 
                otherwise your target matching will be discarded. 
                If you call a MatchTarget with a start time lower than the clip's normalized time and the clip can loop, MatchTarget will adjust the time to match the next clip loop. 
                For example, start time= 0.2 normalized time = 0.3, start time will be 1.2. Animator.applyRootMotion must be enabled for MatchTarget to take effect.
            

            参数:
            matchPosition:
                The position we want the body part to reach.
            
            matchRotation:
                The rotation in which we want the body part to be.
            
            targetBodyPart:
                The body part that is involved in the match.
            
            weightMask:
                Structure that contains weights for matching position and rotation.
            
            startNormalizedTime:
                Start time within the animation clip (0 - beginning of clip, 1 - end of clip).
            
            targetNormalizedTime:
                End time within the animation clip (0 - beginning of clip, 1 - end of clip),
                values greater than 1 can be set to trigger a match after a certain number of
                loops. Ex: 2.3 means at 30% of 2nd loop.
            
            completeMatch:
                Allows you to specify what should happen if the MatchTarget function is interrupted.
                A value of true causes the GameObject to immediately move to the matchPosition
                if interrupted. A value of false causes the GameObject to stay at its current
                position if interrupted.
        */
        public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [Internal.DefaultValue("1")] float targetNormalizedTime);
        
        public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [Internal.DefaultValue("1")] float targetNormalizedTime, [Internal.DefaultValue("true")] bool completeMatch);
        public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime);



        
        public void Play(string stateName, int layer);
        //
        // 摘要:
        //     Plays a state.
        //
        // 参数:
        //   stateName:
        //     The state name.
        //
        //   stateNameHash:
        //     The state hash name. If stateNameHash is 0, it changes the current state time.
        //
        //   layer:
        //     The layer index. If layer is -1, it plays the first state with the given state
        //     name or hash.
        //
        //   normalizedTime:
        //     The time offset between zero and one.
        public void Play(string stateName, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime);
        //
        // 摘要:
        //     Plays a state.
        //
        // 参数:
        //   stateName:
        //     The state name.
        //
        //   stateNameHash:
        //     The state hash name. If stateNameHash is 0, it changes the current state time.
        //
        //   layer:
        //     The layer index. If layer is -1, it plays the first state with the given state
        //     name or hash.
        //
        //   normalizedTime:
        //     The time offset between zero and one.
        [FreeFunctionAttribute(Name = "AnimatorBindings::Play", HasExplicitThis = true)]
        public void Play(int stateNameHash, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime);
        public void Play(string stateName);
        public void Play(int stateNameHash, int layer);
        public void Play(int stateNameHash);
        //
        // 摘要:
        //     Plays a state.
        //
        // 参数:
        //   stateName:
        //     The state name.
        //
        //   stateNameHash:
        //     The state hash name. If stateNameHash is 0, it changes the current state time.
        //
        //   layer:
        //     The layer index. If layer is -1, it plays the first state with the given state
        //     name or hash.
        //
        //   fixedTime:
        //     The time offset (in seconds).
        public void PlayInFixedTime(string stateName, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("float.NegativeInfinity")] float fixedTime);
        public void PlayInFixedTime(string stateName);
        public void PlayInFixedTime(int stateNameHash, int layer);
        public void PlayInFixedTime(int stateNameHash);
        //
        // 摘要:
        //     Plays a state.
        //
        // 参数:
        //   stateName:
        //     The state name.
        //
        //   stateNameHash:
        //     The state hash name. If stateNameHash is 0, it changes the current state time.
        //
        //   layer:
        //     The layer index. If layer is -1, it plays the first state with the given state
        //     name or hash.
        //
        //   fixedTime:
        //     The time offset (in seconds).
        [FreeFunctionAttribute(Name = "AnimatorBindings::PlayInFixedTime", HasExplicitThis = true)]
        public void PlayInFixedTime(int stateNameHash, [Internal.DefaultValue("-1")] int layer, [Internal.DefaultValue("float.NegativeInfinity")] float fixedTime);
        public void PlayInFixedTime(string stateName, int layer);
        //
        // 摘要:
        //     Rebind all the animated properties and mesh data with the Animator.
        public void Rebind();
        //
        // 摘要:
        //     Resets the value of the given trigger parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        public void ResetTrigger(int id);
        //
        // 摘要:
        //     Resets the value of the given trigger parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        public void ResetTrigger(string name);
        //
        // 摘要:
        //     Sets local rotation of a human bone during a IK pass.
        //
        // 参数:
        //   humanBoneId:
        //     The human bone Id.
        //
        //   rotation:
        //     The local rotation.
        public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation);
        //
        // 摘要:
        //     Sets the value of the given boolean parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        //   value:
        //     The new parameter value.
        public void SetBool(string name, bool value);
        //
        // 摘要:
        //     Sets the value of the given boolean parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        //   value:
        //     The new parameter value.
        public void SetBool(int id, bool value);


        /*
            Send float values to the Animator to affect transitions.
            ---
            带阻尼 damper 的版本, 可实现类似 线性过度的效果;
            
            参数:
            name:
                The parameter name.
            
            id:
                The parameter ID.
            
            value:
                The new parameter value.
            
            dampTime:
                The damper total time. -- 值越大, 阻尼越大, 值过度得越慢
            
            deltaTime:
                The delta time to give to the damper.
        */
        public void SetFloat(int id, float value, float dampTime, float deltaTime);
        public void SetFloat(int id, float value);
        public void SetFloat(string name, float value);
        public void SetFloat(string name, float value, float dampTime, float deltaTime);


        //
        // 摘要:
        //     Sets the position of an IK hint.
        //
        // 参数:
        //   hint:
        //     The AvatarIKHint that is set.
        //
        //   hintPosition:
        //     The position in world space.
        public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition);
        //
        // 摘要:
        //     Sets the translative weight of an IK hint (0 = at the original animation before
        //     IK, 1 = at the hint).
        //
        // 参数:
        //   hint:
        //     The AvatarIKHint that is set.
        //
        //   value:
        //     The translative weight.
        public void SetIKHintPositionWeight(AvatarIKHint hint, float value);
        //
        // 摘要:
        //     Sets the position of an IK goal.
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is set.
        //
        //   goalPosition:
        //     The position in world space.
        public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition);
        //
        // 摘要:
        //     Sets the translative weight of an IK goal (0 = at the original animation before
        //     IK, 1 = at the goal).
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is set.
        //
        //   value:
        //     The translative weight.
        public void SetIKPositionWeight(AvatarIKGoal goal, float value);
        //
        // 摘要:
        //     Sets the rotation of an IK goal.
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is set.
        //
        //   goalRotation:
        //     The rotation in world space.
        public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation);
        //
        // 摘要:
        //     Sets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation
        //     at the IK goal).
        //
        // 参数:
        //   goal:
        //     The AvatarIKGoal that is set.
        //
        //   value:
        //     The rotational weight.
        public void SetIKRotationWeight(AvatarIKGoal goal, float value);
        //
        // 摘要:
        //     Sets the value of the given integer parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        //   value:
        //     The new parameter value.
        public void SetInteger(int id, int value);
        //
        // 摘要:
        //     Sets the value of the given integer parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        //
        //   value:
        //     The new parameter value.
        public void SetInteger(string name, int value);
        //
        // 摘要:
        //     Sets the weight of the layer at the given index.
        //
        // 参数:
        //   layerIndex:
        //     The layer index.
        //
        //   weight:
        //     The new layer weight.
        public void SetLayerWeight(int layerIndex, float weight);
        //
        // 摘要:
        //     Sets the look at position.
        //
        // 参数:
        //   lookAtPosition:
        //     The position to lookAt.
        public void SetLookAtPosition(Vector3 lookAtPosition);
        //
        // 摘要:
        //     Set look at weights.
        //
        // 参数:
        //   weight:
        //     (0-1) the global weight of the LookAt, multiplier for other parameters.
        //
        //   bodyWeight:
        //     (0-1) determines how much the body is involved in the LookAt.
        //
        //   headWeight:
        //     (0-1) determines how much the head is involved in the LookAt.
        //
        //   eyesWeight:
        //     (0-1) determines how much the eyes are involved in the LookAt.
        //
        //   clampWeight:
        //     (0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means
        //     he's completely clamped (look at becomes impossible), and 0.5 means he'll be
        //     able to move on half of the possible range (180 degrees).
        public void SetLookAtWeight(float weight, [Internal.DefaultValue("0.0f")] float bodyWeight, [Internal.DefaultValue("1.0f")] float headWeight, [Internal.DefaultValue("0.0f")] float eyesWeight, [Internal.DefaultValue("0.5f")] float clampWeight);
        //
        // 摘要:
        //     Set look at weights.
        //
        // 参数:
        //   weight:
        //     (0-1) the global weight of the LookAt, multiplier for other parameters.
        //
        //   bodyWeight:
        //     (0-1) determines how much the body is involved in the LookAt.
        //
        //   headWeight:
        //     (0-1) determines how much the head is involved in the LookAt.
        //
        //   eyesWeight:
        //     (0-1) determines how much the eyes are involved in the LookAt.
        //
        //   clampWeight:
        //     (0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means
        //     he's completely clamped (look at becomes impossible), and 0.5 means he'll be
        //     able to move on half of the possible range (180 degrees).
        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight);
        //
        // 摘要:
        //     Set look at weights.
        //
        // 参数:
        //   weight:
        //     (0-1) the global weight of the LookAt, multiplier for other parameters.
        //
        //   bodyWeight:
        //     (0-1) determines how much the body is involved in the LookAt.
        //
        //   headWeight:
        //     (0-1) determines how much the head is involved in the LookAt.
        //
        //   eyesWeight:
        //     (0-1) determines how much the eyes are involved in the LookAt.
        //
        //   clampWeight:
        //     (0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means
        //     he's completely clamped (look at becomes impossible), and 0.5 means he'll be
        //     able to move on half of the possible range (180 degrees).
        public void SetLookAtWeight(float weight, float bodyWeight, float headWeight);
        //
        // 摘要:
        //     Set look at weights.
        //
        // 参数:
        //   weight:
        //     (0-1) the global weight of the LookAt, multiplier for other parameters.
        //
        //   bodyWeight:
        //     (0-1) determines how much the body is involved in the LookAt.
        //
        //   headWeight:
        //     (0-1) determines how much the head is involved in the LookAt.
        //
        //   eyesWeight:
        //     (0-1) determines how much the eyes are involved in the LookAt.
        //
        //   clampWeight:
        //     (0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means
        //     he's completely clamped (look at becomes impossible), and 0.5 means he'll be
        //     able to move on half of the possible range (180 degrees).
        public void SetLookAtWeight(float weight, float bodyWeight);
        //
        // 摘要:
        //     Set look at weights.
        //
        // 参数:
        //   weight:
        //     (0-1) the global weight of the LookAt, multiplier for other parameters.
        //
        //   bodyWeight:
        //     (0-1) determines how much the body is involved in the LookAt.
        //
        //   headWeight:
        //     (0-1) determines how much the head is involved in the LookAt.
        //
        //   eyesWeight:
        //     (0-1) determines how much the eyes are involved in the LookAt.
        //
        //   clampWeight:
        //     (0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means
        //     he's completely clamped (look at becomes impossible), and 0.5 means he'll be
        //     able to move on half of the possible range (180 degrees).
        public void SetLookAtWeight(float weight);
        //
        // 摘要:
        //     Sets the value of a quaternion parameter.
        //
        // 参数:
        //   id:
        //     Of the parameter. The id is generated using Animator::StringToHash.
        //
        //   value:
        //     The new value for the parameter.
        [Obsolete("SetQuaternion is deprecated.")]
        public void SetQuaternion(int id, Quaternion value);
        //
        // 摘要:
        //     Sets the value of a quaternion parameter.
        //
        // 参数:
        //   name:
        //     The name of the parameter.
        //
        //   value:
        //     The new value for the parameter.
        [Obsolete("SetQuaternion is deprecated.")]
        public void SetQuaternion(string name, Quaternion value);
        //
        // 摘要:
        //     Sets an AvatarTarget and a targetNormalizedTime for the current state.
        //
        // 参数:
        //   targetIndex:
        //     The avatar body part that is queried.
        //
        //   targetNormalizedTime:
        //     The current state Time that is queried.
        public void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime);
        //
        // 摘要:
        //     Sets the value of the given trigger parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        public void SetTrigger(int id);
        //
        // 摘要:
        //     Sets the value of the given trigger parameter.
        //
        // 参数:
        //   name:
        //     The parameter name.
        //
        //   id:
        //     The parameter ID.
        public void SetTrigger(string name);
        //
        // 摘要:
        //     Sets the value of a vector parameter.
        //
        // 参数:
        //   name:
        //     The name of the parameter.
        //
        //   value:
        //     The new value for the parameter.
        [Obsolete("SetVector is deprecated.")]
        public void SetVector(string name, Vector3 value);
        //
        // 摘要:
        //     Sets the value of a vector parameter.
        //
        // 参数:
        //   id:
        //     The id of the parameter. The id is generated using Animator::StringToHash.
        //
        //   value:
        //     The new value for the parameter.
        [Obsolete("SetVector is deprecated.")]
        public void SetVector(int id, Vector3 value);
        //
        // 摘要:
        //     Sets the animator in playback mode.
        public void StartPlayback();
        //
        // 摘要:
        //     Sets the animator in recording mode, and allocates a circular buffer of size
        //     frameCount.
        //
        // 参数:
        //   frameCount:
        //     The number of frames (updates) that will be recorded. If frameCount is 0, the
        //     recording will continue until the user calls StopRecording. The maximum value
        //     for frameCount is 10000.
        public void StartRecording(int frameCount);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Stop is obsolete. Use Animator.enabled = false instead", true)]
        public void Stop();
        //
        // 摘要:
        //     Stops the animator playback mode. When playback stops, the avatar resumes getting
        //     control from game logic.
        public void StopPlayback();
        //
        // 摘要:
        //     Stops animator record mode.
        public void StopRecording();
        //
        // 摘要:
        //     Evaluates the animator based on deltaTime.
        //
        // 参数:
        //   deltaTime:
        //     The time delta.
        [NativeMethodAttribute("UpdateWithDelta")]
        public void Update(float deltaTime);
        //
        // 摘要:
        //     Forces a write of the default values stored in the animator.
        [FreeFunctionAttribute(Name = "AnimatorBindings::WriteDefaultValues", HasExplicitThis = true)]
        public void WriteDefaultValues();
    }
}

