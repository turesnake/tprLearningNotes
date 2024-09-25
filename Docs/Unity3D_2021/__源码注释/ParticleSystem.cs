#region Assembly UnityEngine.ParticleSystemModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Script interface for ParticleSystem. Unity's powerful and versatile particle
//     system implementation.
[NativeHeader("ParticleSystemScriptingClasses.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystemGeometryJob.h")]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
[UsedByNativeCode]
[RequireComponent(typeof(Transform))]
[NativeHeader("ParticleSystemScriptingClasses.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemModulesScriptBindings.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
public sealed class ParticleSystem : Component
{
    //
    // Summary:
    //     Script interface for a Min-Max Curve.
    [Serializable]
    [NativeType(CodegenOptions.Custom, "MonoMinMaxCurve", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
    public struct MinMaxCurve
    {
        [SerializeField]
        private ParticleSystemCurveMode m_Mode;

        [SerializeField]
        private float m_CurveMultiplier;

        [SerializeField]
        private AnimationCurve m_CurveMin;

        [SerializeField]
        private AnimationCurve m_CurveMax;

        [SerializeField]
        private float m_ConstantMin;

        [SerializeField]
        private float m_ConstantMax;

        // [Obsolete("Please use MinMaxCurve.curveMultiplier instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/MinMaxCurve.curveMultiplier", false)]
        // public float curveScalar
        // {
        //     get
        //     {
        //         return m_CurveMultiplier;
        //     }
        //     set
        //     {
        //         m_CurveMultiplier = value;
        //     }
        // }

        //
        // Summary:
        //     Set the mode that the min-max curve uses to evaluate values.
        public ParticleSystemCurveMode mode
        {
            get
            {
                return m_Mode;
            }
            set
            {
                m_Mode = value;
            }
        }

        //
        // Summary:
        //     Set a multiplier to apply to the curves.
        public float curveMultiplier
        {
            get
            {
                return m_CurveMultiplier;
            }
            set
            {
                m_CurveMultiplier = value;
            }
        }

        //
        // Summary:
        //     Set a curve for the upper bound.
        public AnimationCurve curveMax
        {
            get
            {
                return m_CurveMax;
            }
            set
            {
                m_CurveMax = value;
            }
        }

        //
        // Summary:
        //     Set a curve for the lower bound.
        public AnimationCurve curveMin
        {
            get
            {
                return m_CurveMin;
            }
            set
            {
                m_CurveMin = value;
            }
        }

        //
        // Summary:
        //     Set a constant for the upper bound.
        public float constantMax
        {
            get
            {
                return m_ConstantMax;
            }
            set
            {
                m_ConstantMax = value;
            }
        }

        //
        // Summary:
        //     Set a constant for the lower bound.
        public float constantMin
        {
            get
            {
                return m_ConstantMin;
            }
            set
            {
                m_ConstantMin = value;
            }
        }

        //
        // Summary:
        //     Set the constant value.
        public float constant
        {
            get
            {
                return m_ConstantMax;
            }
            set
            {
                m_ConstantMax = value;
            }
        }

        //
        // Summary:
        //     Set the curve.
        public AnimationCurve curve
        {
            get
            {
                return m_CurveMax;
            }
            set
            {
                m_CurveMax = value;
            }
        }

        //
        // Summary:
        //     A single constant value for the entire curve.
        //
        // Parameters:
        //   constant:
        //     Constant value.
        public MinMaxCurve(float constant)
        {
            m_Mode = ParticleSystemCurveMode.Constant;
            m_CurveMultiplier = 0f;
            m_CurveMin = null;
            m_CurveMax = null;
            m_ConstantMin = 0f;
            m_ConstantMax = constant;
        }

        //
        // Summary:
        //     Use one curve when evaluating numbers along this Min-Max curve.
        //
        // Parameters:
        //   scalar:
        //     A multiplier to apply to the curve.
        //
        //   curve:
        //     A single curve to evaluate against.
        //
        //   multiplier:
        public MinMaxCurve(float multiplier, AnimationCurve curve)
        {
            m_Mode = ParticleSystemCurveMode.Curve;
            m_CurveMultiplier = multiplier;
            m_CurveMin = null;
            m_CurveMax = curve;
            m_ConstantMin = 0f;
            m_ConstantMax = 0f;
        }

        //
        // Summary:
        //     Randomly select values based on the interval between the minimum and maximum
        //     curves.
        //
        // Parameters:
        //   scalar:
        //     A multiplier to apply to the curves.
        //
        //   min:
        //     The curve describing the minimum values to be evaluated.
        //
        //   max:
        //     The curve describing the maximum values to be evaluated.
        //
        //   multiplier:
        public MinMaxCurve(float multiplier, AnimationCurve min, AnimationCurve max)
        {
            m_Mode = ParticleSystemCurveMode.TwoCurves;
            m_CurveMultiplier = multiplier;
            m_CurveMin = min;
            m_CurveMax = max;
            m_ConstantMin = 0f;
            m_ConstantMax = 0f;
        }

        //
        // Summary:
        //     Randomly select values based on the interval between the minimum and maximum
        //     constants.
        //
        // Parameters:
        //   min:
        //     The constant describing the minimum values to be evaluated.
        //
        //   max:
        //     The constant describing the maximum values to be evaluated.
        public MinMaxCurve(float min, float max)
        {
            m_Mode = ParticleSystemCurveMode.TwoConstants;
            m_CurveMultiplier = 0f;
            m_CurveMin = null;
            m_CurveMax = null;
            m_ConstantMin = min;
            m_ConstantMax = max;
        }

        //
        // Summary:
        //     Manually query the curve to calculate values based on what mode it is in.
        //
        // Parameters:
        //   time:
        //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
        //     the curve. This is valid when ParticleSystem.MinMaxCurve.mode is set to ParticleSystemCurveMode.Curve
        //     or ParticleSystemCurveMode.TwoCurves.
        //
        //   lerpFactor:
        //     Blend between the two curves/constants (Valid when ParticleSystem.MinMaxCurve.mode
        //     is set to ParticleSystemCurveMode.TwoConstants or ParticleSystemCurveMode.TwoCurves).
        //
        //
        // Returns:
        //     Calculated curve/constant value.
        public float Evaluate(float time)
        {
            return Evaluate(time, 1f);
        }

        //
        // Summary:
        //     Manually query the curve to calculate values based on what mode it is in.
        //
        // Parameters:
        //   time:
        //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
        //     the curve. This is valid when ParticleSystem.MinMaxCurve.mode is set to ParticleSystemCurveMode.Curve
        //     or ParticleSystemCurveMode.TwoCurves.
        //
        //   lerpFactor:
        //     Blend between the two curves/constants (Valid when ParticleSystem.MinMaxCurve.mode
        //     is set to ParticleSystemCurveMode.TwoConstants or ParticleSystemCurveMode.TwoCurves).
        //
        //
        // Returns:
        //     Calculated curve/constant value.
        public float Evaluate(float time, float lerpFactor)
        {
            return mode switch
            {
                ParticleSystemCurveMode.Constant => m_ConstantMax,
                ParticleSystemCurveMode.TwoCurves => Mathf.Lerp(m_CurveMin.Evaluate(time), m_CurveMax.Evaluate(time), lerpFactor) * m_CurveMultiplier,
                ParticleSystemCurveMode.TwoConstants => Mathf.Lerp(m_ConstantMin, m_ConstantMax, lerpFactor),
                _ => m_CurveMax.Evaluate(time) * m_CurveMultiplier,
            };
        }

        public static implicit operator MinMaxCurve(float constant)
        {
            return new MinMaxCurve(constant);
        }
    }

    //
    // Summary:
    //     Script interface for the MainModule of a Particle System.
    public struct MainModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Cause some particles to spin in the opposite direction.
        // [Obsolete("Please use flipRotation instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/MainModule.flipRotation", false)]
        // public float randomizeRotationDirection
        // {
        //     get
        //     {
        //         return flipRotation;
        //     }
        //     set
        //     {
        //         flipRotation = value;
        //     }
        // }

        //
        // Summary:
        //     The current Particle System velocity.
        public Vector3 emitterVelocity
        {
            get
            {
                get_emitterVelocity_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_emitterVelocity_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The duration of the Particle System in seconds.
        public float duration
        {
            get
            {
                return get_duration_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_duration_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether the Particle System is looping.
        public bool loop
        {
            get
            {
                return get_loop_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_loop_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     If ParticleSystem.MainModule._loop is true, when you enable this property, the
        //     Particle System looks like it has already simulated for one loop when first becoming
        //     visible.
        public bool prewarm
        {
            get
            {
                return get_prewarm_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_prewarm_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Start delay in seconds.
        public MinMaxCurve startDelay
        {
            get
            {
                get_startDelay_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startDelay_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startDelay in seconds.
        public float startDelayMultiplier
        {
            get
            {
                return get_startDelayMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startDelayMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The total lifetime in seconds that each new particle has.
        public MinMaxCurve startLifetime
        {
            get
            {
                get_startLifetime_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startLifetime_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startLifetime.
        public float startLifetimeMultiplier
        {
            get
            {
                return get_startLifetimeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startLifetimeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial speed of particles when the Particle System first spawns them.
        public MinMaxCurve startSpeed
        {
            get
            {
                get_startSpeed_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startSpeed_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startSpeed.
        public float startSpeedMultiplier
        {
            get
            {
                return get_startSpeedMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSpeedMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A flag to enable specifying particle size individually for each axis.
        public bool startSize3D
        {
            get
            {
                return get_startSize3D_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSize3D_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial size of particles when the Particle System first spawns them.
        [NativeName("StartSizeX")]
        public MinMaxCurve startSize
        {
            get
            {
                get_startSize_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startSize_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for the initial size of particles when the Particle System first
        //     spawns them.
        [NativeName("StartSizeXMultiplier")]
        public float startSizeMultiplier
        {
            get
            {
                return get_startSizeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSizeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial size of particles along the x-axis when the Particle System first
        //     spawns them.
        public MinMaxCurve startSizeX
        {
            get
            {
                get_startSizeX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startSizeX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startSizeX.
        public float startSizeXMultiplier
        {
            get
            {
                return get_startSizeXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSizeXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial size of particles along the y-axis when the Particle System first
        //     spawns them.
        public MinMaxCurve startSizeY
        {
            get
            {
                get_startSizeY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startSizeY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startSizeY.
        public float startSizeYMultiplier
        {
            get
            {
                return get_startSizeYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSizeYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial size of particles along the z-axis when the Particle System first
        //     spawns them.
        public MinMaxCurve startSizeZ
        {
            get
            {
                get_startSizeZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startSizeZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startSizeZ.
        public float startSizeZMultiplier
        {
            get
            {
                return get_startSizeZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startSizeZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A flag to enable 3D particle rotation.
        public bool startRotation3D
        {
            get
            {
                return get_startRotation3D_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startRotation3D_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial rotation of particles when the Particle System first spawns them.
        [NativeName("StartRotationZ")]
        public MinMaxCurve startRotation
        {
            get
            {
                get_startRotation_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startRotation_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.MainModule._startRotation.
        [NativeName("StartRotationZMultiplier")]
        public float startRotationMultiplier
        {
            get
            {
                return get_startRotationMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startRotationMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial rotation of particles around the x-axis when emitted.
        public MinMaxCurve startRotationX
        {
            get
            {
                get_startRotationX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startRotationX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The initial rotation multiplier of particles around the x-axis when the Particle
        //     System first spawns them.
        public float startRotationXMultiplier
        {
            get
            {
                return get_startRotationXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startRotationXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial rotation of particles around the y-axis when the Particle System
        //     first spawns them.
        public MinMaxCurve startRotationY
        {
            get
            {
                get_startRotationY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startRotationY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The initial rotation multiplier of particles around the y-axis when the Particle
        //     System first spawns them..
        public float startRotationYMultiplier
        {
            get
            {
                return get_startRotationYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startRotationYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial rotation of particles around the z-axis when the Particle System
        //     first spawns them
        public MinMaxCurve startRotationZ
        {
            get
            {
                get_startRotationZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startRotationZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The initial rotation multiplier of particles around the z-axis when the Particle
        //     System first spawns them.
        public float startRotationZMultiplier
        {
            get
            {
                return get_startRotationZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startRotationZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Makes some particles spin in the opposite direction.
        public float flipRotation
        {
            get
            {
                return get_flipRotation_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_flipRotation_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The initial color of particles when the Particle System first spawns them.
        public MinMaxGradient startColor
        {
            get
            {
                get_startColor_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startColor_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A scale that this Particle System applies to gravity, defined by Physics.gravity.
        public MinMaxCurve gravityModifier
        {
            get
            {
                get_gravityModifier_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_gravityModifier_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the gravity multiplier.
        public float gravityModifierMultiplier
        {
            get
            {
                return get_gravityModifierMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_gravityModifierMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     This selects the space in which to simulate particles. It can be either world
        //     or local space.
        public ParticleSystemSimulationSpace simulationSpace
        {
            get
            {
                return get_simulationSpace_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_simulationSpace_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Simulate particles relative to a custom transform component.
        public Transform customSimulationSpace
        {
            get
            {
                return get_customSimulationSpace_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_customSimulationSpace_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Override the default playback speed of the Particle System.
        public float simulationSpeed
        {
            get
            {
                return get_simulationSpeed_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_simulationSpeed_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When true, use the unscaled delta time to simulate the Particle System. Otherwise,
        //     use the scaled delta time.
        public bool useUnscaledTime
        {
            get
            {
                return get_useUnscaledTime_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_useUnscaledTime_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control how the Particle System applies its Transform component to the particles
        //     it emits.
        public ParticleSystemScalingMode scalingMode
        {
            get
            {
                return get_scalingMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_scalingMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     If set to true, the Particle System automatically begins to play on startup.
        public bool playOnAwake
        {
            get
            {
                return get_playOnAwake_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_playOnAwake_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The maximum number of particles to emit.
        public int maxParticles
        {
            get
            {
                return get_maxParticles_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_maxParticles_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control how the Particle System calculates its velocity, when moving in the world.
        public ParticleSystemEmitterVelocityMode emitterVelocityMode
        {
            get
            {
                return get_emitterVelocityMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_emitterVelocityMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select whether to Disable or Destroy the GameObject, or to call the MonoBehaviour.OnParticleSystemStopped
        //     script Callback, when the Particle System stops and all particles have died.
        public ParticleSystemStopAction stopAction
        {
            get
            {
                return get_stopAction_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_stopAction_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Configure the Particle System to not kill its particles when their lifetimes
        //     are exceeded.
        public ParticleSystemRingBufferMode ringBufferMode
        {
            get
            {
                return get_ringBufferMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_ringBufferMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When ParticleSystem.MainModule.ringBufferMode is set to loop, this value defines
        //     the proportion of the particle life that loops.
        public Vector2 ringBufferLoopRange
        {
            get
            {
                get_ringBufferLoopRange_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_ringBufferLoopRange_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Configure whether the Particle System will still be simulated each frame, when
        //     it is offscreen.
        public ParticleSystemCullingMode cullingMode
        {
            get
            {
                return get_cullingMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_cullingMode_Injected(ref this, value);
            }
        }

        internal MainModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_emitterVelocity_Injected(ref MainModule _unity_self, out Vector3 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_emitterVelocity_Injected(ref MainModule _unity_self, ref Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_duration_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_duration_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_loop_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_loop_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_prewarm_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_prewarm_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startDelay_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startDelay_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startDelayMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startDelayMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startLifetime_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startLifetime_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startLifetimeMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startLifetimeMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startSpeed_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSpeed_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startSpeedMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSpeedMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_startSize3D_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSize3D_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startSize_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSize_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startSizeMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startSizeX_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeX_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startSizeXMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeXMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startSizeY_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeY_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startSizeYMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeYMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startSizeZ_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeZ_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startSizeZMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startSizeZMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_startRotation3D_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotation3D_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startRotation_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotation_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startRotationMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startRotationX_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationX_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startRotationXMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationXMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startRotationY_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationY_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startRotationYMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationYMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startRotationZ_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationZ_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startRotationZMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startRotationZMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_flipRotation_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_flipRotation_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startColor_Injected(ref MainModule _unity_self, out MinMaxGradient ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startColor_Injected(ref MainModule _unity_self, ref MinMaxGradient value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_gravityModifier_Injected(ref MainModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_gravityModifier_Injected(ref MainModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_gravityModifierMultiplier_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_gravityModifierMultiplier_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemSimulationSpace get_simulationSpace_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_simulationSpace_Injected(ref MainModule _unity_self, ParticleSystemSimulationSpace value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern Transform get_customSimulationSpace_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_customSimulationSpace_Injected(ref MainModule _unity_self, Transform value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_simulationSpeed_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_simulationSpeed_Injected(ref MainModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_useUnscaledTime_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_useUnscaledTime_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemScalingMode get_scalingMode_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_scalingMode_Injected(ref MainModule _unity_self, ParticleSystemScalingMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_playOnAwake_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_playOnAwake_Injected(ref MainModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_maxParticles_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_maxParticles_Injected(ref MainModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemEmitterVelocityMode get_emitterVelocityMode_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_emitterVelocityMode_Injected(ref MainModule _unity_self, ParticleSystemEmitterVelocityMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemStopAction get_stopAction_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_stopAction_Injected(ref MainModule _unity_self, ParticleSystemStopAction value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemRingBufferMode get_ringBufferMode_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_ringBufferMode_Injected(ref MainModule _unity_self, ParticleSystemRingBufferMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_ringBufferLoopRange_Injected(ref MainModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_ringBufferLoopRange_Injected(ref MainModule _unity_self, ref Vector2 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemCullingMode get_cullingMode_Injected(ref MainModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_cullingMode_Injected(ref MainModule _unity_self, ParticleSystemCullingMode value);
    }

    //
    // Summary:
    //     Script interface for the EmissionModule of a Particle System.
    public struct EmissionModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     The emission type.
        // [Obsolete("ParticleSystemEmissionType no longer does anything. Time and Distance based emission are now both always active.", false)]
        // public ParticleSystemEmissionType type
        // {
        //     get
        //     {
        //         return ParticleSystemEmissionType.Time;
        //     }
        //     set
        //     {
        //     }
        // }

        //
        // Summary:
        //     The rate at which the system spawns new particles.
        // [Obsolete("rate property is deprecated. Use rateOverTime or rateOverDistance instead.", false)]
        // public MinMaxCurve rate
        // {
        //     get
        //     {
        //         return rateOverTime;
        //     }
        //     set
        //     {
        //         rateOverTime = value;
        //     }
        // }

        //
        // Summary:
        //     Change the rate multiplier.
        // [Obsolete("rateMultiplier property is deprecated. Use rateOverTimeMultiplier or rateOverDistanceMultiplier instead.", false)]
        // public float rateMultiplier
        // {
        //     get
        //     {
        //         return rateOverTimeMultiplier;
        //     }
        //     set
        //     {
        //         rateOverTimeMultiplier = value;
        //     }
        // }

        //
        // Summary:
        //     Specifies whether the EmissionModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The rate at which the emitter spawns new particles over time.
        public MinMaxCurve rateOverTime
        {
            get
            {
                get_rateOverTime_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_rateOverTime_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the rate over time multiplier.
        public float rateOverTimeMultiplier
        {
            get
            {
                return get_rateOverTimeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_rateOverTimeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The rate at which the emitter spawns new particles over distance.
        public MinMaxCurve rateOverDistance
        {
            get
            {
                get_rateOverDistance_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_rateOverDistance_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the rate over distance multiplier.
        public float rateOverDistanceMultiplier
        {
            get
            {
                return get_rateOverDistanceMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_rateOverDistanceMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The current number of bursts.
        public int burstCount
        {
            get
            {
                return get_burstCount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_burstCount_Injected(ref this, value);
            }
        }

        internal EmissionModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        public void SetBursts(Burst[] bursts)
        {
            SetBursts(bursts, bursts.Length);
        }

        public void SetBursts(Burst[] bursts, int size)
        {
            burstCount = size;
            for (int i = 0; i < size; i++)
            {
                SetBurst(i, bursts[i]);
            }
        }

        public int GetBursts(Burst[] bursts)
        {
            int num = burstCount;
            for (int i = 0; i < num; i++)
            {
                bursts[i] = GetBurst(i);
            }

            return num;
        }

        [NativeThrows]
        public void SetBurst(int index, Burst burst)
        {
            SetBurst_Injected(ref this, index, ref burst);
        }

        //
        // Summary:
        //     Gets a single burst from the array of bursts.
        //
        // Parameters:
        //   index:
        //     The index of the burst to retrieve.
        //
        // Returns:
        //     The burst data at the given index.
        [NativeThrows]
        public Burst GetBurst(int index)
        {
            GetBurst_Injected(ref this, index, out var ret);
            return ret;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref EmissionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref EmissionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_rateOverTime_Injected(ref EmissionModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rateOverTime_Injected(ref EmissionModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_rateOverTimeMultiplier_Injected(ref EmissionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rateOverTimeMultiplier_Injected(ref EmissionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_rateOverDistance_Injected(ref EmissionModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rateOverDistance_Injected(ref EmissionModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_rateOverDistanceMultiplier_Injected(ref EmissionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rateOverDistanceMultiplier_Injected(ref EmissionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetBurst_Injected(ref EmissionModule _unity_self, int index, ref Burst burst);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetBurst_Injected(ref EmissionModule _unity_self, int index, out Burst ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_burstCount_Injected(ref EmissionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_burstCount_Injected(ref EmissionModule _unity_self, int value);
    }

    //
    // Summary:
    //     Script interface for the ShapeModule.
    public struct ShapeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Scale of the box to emit particles from.
        // [Obsolete("Please use scale instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/ShapeModule.scale", false)]
        // public Vector3 box
        // {
        //     get
        //     {
        //         return scale;
        //     }
        //     set
        //     {
        //         scale = value;
        //     }
        // }

        //
        // Summary:
        //     Apply a scaling factor to the Mesh that emits the particles.
        // [Obsolete("meshScale property is deprecated.Please use scale instead.", false)]
        // public float meshScale
        // {
        //     get
        //     {
        //         return scale.x;
        //     }
        //     set
        //     {
        //         scale = new Vector3(value, value, value);
        //     }
        // }

        //
        // Summary:
        //     Randomizes the starting direction of particles.
        // [Obsolete("randomDirection property is deprecated. Use randomDirectionAmount instead.", false)]
        // public bool randomDirection
        // {
        //     get
        //     {
        //         return randomDirectionAmount >= 0.5f;
        //     }
        //     set
        //     {
        //         randomDirectionAmount = (value ? 1f : 0f);
        //     }
        // }

        //
        // Summary:
        //     Specifies whether the ShapeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The type of shape to emit particles from.
        public ParticleSystemShapeType shapeType
        {
            get
            {
                return get_shapeType_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_shapeType_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Randomizes the starting direction of particles.
        public float randomDirectionAmount
        {
            get
            {
                return get_randomDirectionAmount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_randomDirectionAmount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Makes particles move in a spherical direction from their starting point.
        public float sphericalDirectionAmount
        {
            get
            {
                return get_sphericalDirectionAmount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sphericalDirectionAmount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Randomizes the starting position of particles.
        public float randomPositionAmount
        {
            get
            {
                return get_randomPositionAmount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_randomPositionAmount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Align particles based on their initial direction of travel.
        public bool alignToDirection
        {
            get
            {
                return get_alignToDirection_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_alignToDirection_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Radius of the shape to emit particles from.
        public float radius
        {
            get
            {
                return get_radius_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radius_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The mode to use to generate particles along the radius.
        public ParticleSystemShapeMultiModeValue radiusMode
        {
            get
            {
                return get_radiusMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control the gap between particle emission points along the radius.
        public float radiusSpread
        {
            get
            {
                return get_radiusSpread_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusSpread_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     In animated modes, this determines how quickly the particle emission position
        //     moves along the radius.
        public MinMaxCurve radiusSpeed
        {
            get
            {
                get_radiusSpeed_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_radiusSpeed_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier of the radius speed of the particle emission shape.
        public float radiusSpeedMultiplier
        {
            get
            {
                return get_radiusSpeedMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusSpeedMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Radius thickness of the shape's edge from which to emit particles.
        public float radiusThickness
        {
            get
            {
                return get_radiusThickness_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusThickness_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Angle of the cone to emit particles from.
        public float angle
        {
            get
            {
                return get_angle_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_angle_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Length of the cone to emit particles from.
        public float length
        {
            get
            {
                return get_length_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_length_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Thickness of the box to emit particles from.
        public Vector3 boxThickness
        {
            get
            {
                get_boxThickness_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_boxThickness_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Where on the Mesh to emit particles from.
        public ParticleSystemMeshShapeType meshShapeType
        {
            get
            {
                return get_meshShapeType_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshShapeType_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Mesh to emit particles from.
        public Mesh mesh
        {
            get
            {
                return get_mesh_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_mesh_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     MeshRenderer to emit particles from.
        public MeshRenderer meshRenderer
        {
            get
            {
                return get_meshRenderer_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshRenderer_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     SkinnedMeshRenderer to emit particles from.
        public SkinnedMeshRenderer skinnedMeshRenderer
        {
            get
            {
                return get_skinnedMeshRenderer_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_skinnedMeshRenderer_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Sprite to emit particles from.
        public Sprite sprite
        {
            get
            {
                return get_sprite_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sprite_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     SpriteRenderer to emit particles from.
        public SpriteRenderer spriteRenderer
        {
            get
            {
                return get_spriteRenderer_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_spriteRenderer_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Emit particles from a single Material, or the whole Mesh.
        public bool useMeshMaterialIndex
        {
            get
            {
                return get_useMeshMaterialIndex_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_useMeshMaterialIndex_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Emit particles from a single Material of a Mesh.
        public int meshMaterialIndex
        {
            get
            {
                return get_meshMaterialIndex_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshMaterialIndex_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Modulate the particle colors with the vertex colors, or the Material color if
        //     no vertex colors exist.
        public bool useMeshColors
        {
            get
            {
                return get_useMeshColors_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_useMeshColors_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Move particles away from the surface of the source Mesh.
        public float normalOffset
        {
            get
            {
                return get_normalOffset_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_normalOffset_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The mode to use to generate particles on a Mesh.
        public ParticleSystemShapeMultiModeValue meshSpawnMode
        {
            get
            {
                return get_meshSpawnMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshSpawnMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control the gap between particle emission points across the Mesh.
        public float meshSpawnSpread
        {
            get
            {
                return get_meshSpawnSpread_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshSpawnSpread_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     In animated modes, this determines how quickly the particle emission position
        //     moves across the Mesh.
        public MinMaxCurve meshSpawnSpeed
        {
            get
            {
                get_meshSpawnSpeed_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_meshSpawnSpeed_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier of the Mesh spawn speed.
        public float meshSpawnSpeedMultiplier
        {
            get
            {
                return get_meshSpawnSpeedMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_meshSpawnSpeedMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Angle of the circle arc to emit particles from.
        public float arc
        {
            get
            {
                return get_arc_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_arc_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The mode that Unity uses to generate particles around the arc.
        public ParticleSystemShapeMultiModeValue arcMode
        {
            get
            {
                return get_arcMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_arcMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control the gap between particle emission points around the arc.
        public float arcSpread
        {
            get
            {
                return get_arcSpread_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_arcSpread_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     In animated modes, this determines how quickly the particle emission position
        //     moves around the arc.
        public MinMaxCurve arcSpeed
        {
            get
            {
                get_arcSpeed_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_arcSpeed_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier of the arc speed of the particle emission shape.
        public float arcSpeedMultiplier
        {
            get
            {
                return get_arcSpeedMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_arcSpeedMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The thickness of the Donut shape to emit particles from.
        public float donutRadius
        {
            get
            {
                return get_donutRadius_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_donutRadius_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Apply an offset to the position from which the system emits particles.
        public Vector3 position
        {
            get
            {
                get_position_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_position_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Apply a rotation to the shape from which the system emits particles.
        public Vector3 rotation
        {
            get
            {
                get_rotation_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_rotation_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Apply scale to the shape from which the system emits particles.
        public Vector3 scale
        {
            get
            {
                get_scale_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_scale_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Specifies a Texture to tint the particle's start colors.
        public Texture2D texture
        {
            get
            {
                return get_texture_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_texture_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Selects which channel of the Texture to use for discarding particles.
        public ParticleSystemShapeTextureChannel textureClipChannel
        {
            get
            {
                return get_textureClipChannel_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureClipChannel_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Discards particles when they spawn on an area of the Texture with a value lower
        //     than this threshold.
        public float textureClipThreshold
        {
            get
            {
                return get_textureClipThreshold_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureClipThreshold_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When enabled, the system applies the RGB channels of the Texture to the particle
        //     color when the particle spawns.
        public bool textureColorAffectsParticles
        {
            get
            {
                return get_textureColorAffectsParticles_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureColorAffectsParticles_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When enabled, the system applies the alpha channel of the Texture to the particle
        //     alpha when the particle spawns.
        public bool textureAlphaAffectsParticles
        {
            get
            {
                return get_textureAlphaAffectsParticles_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureAlphaAffectsParticles_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When enabled, the system takes four neighboring samples from the Texture then
        //     combines them to give the final particle value.
        public bool textureBilinearFiltering
        {
            get
            {
                return get_textureBilinearFiltering_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureBilinearFiltering_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When using a Mesh as a source shape type, this option controls which UV channel
        //     on the Mesh to use for reading the source Texture.
        public int textureUVChannel
        {
            get
            {
                return get_textureUVChannel_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureUVChannel_Injected(ref this, value);
            }
        }

        internal ShapeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemShapeType get_shapeType_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_shapeType_Injected(ref ShapeModule _unity_self, ParticleSystemShapeType value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_randomDirectionAmount_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_randomDirectionAmount_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_sphericalDirectionAmount_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sphericalDirectionAmount_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_randomPositionAmount_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_randomPositionAmount_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_alignToDirection_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_alignToDirection_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radius_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radius_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemShapeMultiModeValue get_radiusMode_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusMode_Injected(ref ShapeModule _unity_self, ParticleSystemShapeMultiModeValue value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radiusSpread_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusSpread_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_radiusSpeed_Injected(ref ShapeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusSpeed_Injected(ref ShapeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radiusSpeedMultiplier_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusSpeedMultiplier_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radiusThickness_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusThickness_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_angle_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_angle_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_length_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_length_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_boxThickness_Injected(ref ShapeModule _unity_self, out Vector3 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_boxThickness_Injected(ref ShapeModule _unity_self, ref Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemMeshShapeType get_meshShapeType_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshShapeType_Injected(ref ShapeModule _unity_self, ParticleSystemMeshShapeType value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern Mesh get_mesh_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_mesh_Injected(ref ShapeModule _unity_self, Mesh value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern MeshRenderer get_meshRenderer_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshRenderer_Injected(ref ShapeModule _unity_self, MeshRenderer value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern SkinnedMeshRenderer get_skinnedMeshRenderer_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_skinnedMeshRenderer_Injected(ref ShapeModule _unity_self, SkinnedMeshRenderer value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern Sprite get_sprite_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sprite_Injected(ref ShapeModule _unity_self, Sprite value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern SpriteRenderer get_spriteRenderer_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_spriteRenderer_Injected(ref ShapeModule _unity_self, SpriteRenderer value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_useMeshMaterialIndex_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_useMeshMaterialIndex_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_meshMaterialIndex_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshMaterialIndex_Injected(ref ShapeModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_useMeshColors_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_useMeshColors_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_normalOffset_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_normalOffset_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemShapeMultiModeValue get_meshSpawnMode_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshSpawnMode_Injected(ref ShapeModule _unity_self, ParticleSystemShapeMultiModeValue value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_meshSpawnSpread_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshSpawnSpread_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_meshSpawnSpeed_Injected(ref ShapeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshSpawnSpeed_Injected(ref ShapeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_meshSpawnSpeedMultiplier_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_meshSpawnSpeedMultiplier_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_arc_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_arc_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemShapeMultiModeValue get_arcMode_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_arcMode_Injected(ref ShapeModule _unity_self, ParticleSystemShapeMultiModeValue value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_arcSpread_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_arcSpread_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_arcSpeed_Injected(ref ShapeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_arcSpeed_Injected(ref ShapeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_arcSpeedMultiplier_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_arcSpeedMultiplier_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_donutRadius_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_donutRadius_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_position_Injected(ref ShapeModule _unity_self, out Vector3 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_position_Injected(ref ShapeModule _unity_self, ref Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_rotation_Injected(ref ShapeModule _unity_self, out Vector3 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rotation_Injected(ref ShapeModule _unity_self, ref Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_scale_Injected(ref ShapeModule _unity_self, out Vector3 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_scale_Injected(ref ShapeModule _unity_self, ref Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern Texture2D get_texture_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_texture_Injected(ref ShapeModule _unity_self, Texture2D value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemShapeTextureChannel get_textureClipChannel_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureClipChannel_Injected(ref ShapeModule _unity_self, ParticleSystemShapeTextureChannel value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_textureClipThreshold_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureClipThreshold_Injected(ref ShapeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_textureColorAffectsParticles_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureColorAffectsParticles_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_textureAlphaAffectsParticles_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureAlphaAffectsParticles_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_textureBilinearFiltering_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureBilinearFiltering_Injected(ref ShapeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_textureUVChannel_Injected(ref ShapeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureUVChannel_Injected(ref ShapeModule _unity_self, int value);
    }

    //
    // Summary:
    //     Script interface for the CollisionMmodule of a Particle System.
    public struct CollisionModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     The maximum number of planes it is possible to set as colliders.
        // [Obsolete("The maxPlaneCount restriction has been removed. Please use planeCount instead to find out how many planes there are. (UnityUpgradable) -> UnityEngine.ParticleSystem/CollisionModule.planeCount", false)]
        // public int maxPlaneCount => planeCount;

        //
        // Summary:
        //     Specifies whether the CollisionModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The type of particle collision to perform.
        public ParticleSystemCollisionType type
        {
            get
            {
                return get_type_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_type_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose between 2D and 3D world collisions.
        public ParticleSystemCollisionMode mode
        {
            get
            {
                return get_mode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_mode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How much speed does each particle lose after a collision.
        public MinMaxCurve dampen
        {
            get
            {
                get_dampen_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_dampen_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the dampen multiplier.
        public float dampenMultiplier
        {
            get
            {
                return get_dampenMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_dampenMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How much force is applied to each particle after a collision.
        public MinMaxCurve bounce
        {
            get
            {
                get_bounce_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_bounce_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.CollisionModule._bounce.
        public float bounceMultiplier
        {
            get
            {
                return get_bounceMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_bounceMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How much a collision reduces a particle's lifetime.
        public MinMaxCurve lifetimeLoss
        {
            get
            {
                get_lifetimeLoss_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_lifetimeLoss_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the lifetime loss multiplier.
        public float lifetimeLossMultiplier
        {
            get
            {
                return get_lifetimeLossMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_lifetimeLossMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Kill particles whose speed falls below this threshold, after a collision.
        public float minKillSpeed
        {
            get
            {
                return get_minKillSpeed_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_minKillSpeed_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Kill particles whose speed goes above this threshold, after a collision.
        public float maxKillSpeed
        {
            get
            {
                return get_maxKillSpeed_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_maxKillSpeed_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control which Layers this Particle System collides with.
        public LayerMask collidesWith
        {
            get
            {
                get_collidesWith_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_collidesWith_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Allow particles to collide with dynamic colliders when using world collision
        //     mode.
        public bool enableDynamicColliders
        {
            get
            {
                return get_enableDynamicColliders_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enableDynamicColliders_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The maximum number of collision shapes Unity considers for particle collisions.
        //     It ignores excess shapes. Terrains take priority.
        public int maxCollisionShapes
        {
            get
            {
                return get_maxCollisionShapes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_maxCollisionShapes_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies the accuracy of particle collisions against colliders in the Scene.
        public ParticleSystemCollisionQuality quality
        {
            get
            {
                return get_quality_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_quality_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size of voxels in the collision cache.
        public float voxelSize
        {
            get
            {
                return get_voxelSize_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_voxelSize_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier that Unity applies to the size of each particle before collisions
        //     are processed.
        public float radiusScale
        {
            get
            {
                return get_radiusScale_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusScale_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Send collision callback messages.
        public bool sendCollisionMessages
        {
            get
            {
                return get_sendCollisionMessages_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sendCollisionMessages_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How much force is applied to a Collider when hit by particles from this Particle
        //     System.
        public float colliderForce
        {
            get
            {
                return get_colliderForce_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_colliderForce_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether the physics system considers the collision angle when it applies
        //     forces from particles to Colliders.
        public bool multiplyColliderForceByCollisionAngle
        {
            get
            {
                return get_multiplyColliderForceByCollisionAngle_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplyColliderForceByCollisionAngle_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether the physics system considers particle speeds when it applies
        //     forces to Colliders.
        public bool multiplyColliderForceByParticleSpeed
        {
            get
            {
                return get_multiplyColliderForceByParticleSpeed_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplyColliderForceByParticleSpeed_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether the physics system considers particle sizes when it applies
        //     forces to Colliders.
        public bool multiplyColliderForceByParticleSize
        {
            get
            {
                return get_multiplyColliderForceByParticleSize_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplyColliderForceByParticleSize_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Shows the number of planes currently set as Colliders.
        [NativeThrows]
        public int planeCount => get_planeCount_Injected(ref this);

        //
        // Summary:
        //     Allow particles to collide when inside colliders.
        // [Obsolete("enableInteriorCollisions property is deprecated and is no longer required and has no effect on the particle system.", false)]
        // public bool enableInteriorCollisions
        // {
        //     get
        //     {
        //         return get_enableInteriorCollisions_Injected(ref this);
        //     }
        //     [NativeThrows]
        //     set
        //     {
        //         set_enableInteriorCollisions_Injected(ref this, value);
        //     }
        // }

        internal CollisionModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Adds a collision plane to use with this Particle System.
        //
        // Parameters:
        //   transform:
        //     The plane to add.
        [NativeThrows]
        public void AddPlane(Transform transform)
        {
            AddPlane_Injected(ref this, transform);
        }

        //
        // Summary:
        //     Removes a collision plane associated with this Particle System.
        //
        // Parameters:
        //   index:
        //     The collision plane to remove.
        [NativeThrows]
        public void RemovePlane(int index)
        {
            RemovePlane_Injected(ref this, index);
        }

        //
        // Summary:
        //     Removes a collision plane associated with this Particle System.
        //
        // Parameters:
        //   transform:
        //     The collision plane to remove.
        public void RemovePlane(Transform transform)
        {
            RemovePlaneObject(transform);
        }

        [NativeThrows]
        private void RemovePlaneObject(Transform transform)
        {
            RemovePlaneObject_Injected(ref this, transform);
        }

        //
        // Summary:
        //     Set a collision plane to use with this Particle System.
        //
        // Parameters:
        //   index:
        //     The plane entry to set.
        //
        //   transform:
        //     The plane to collide particles against.
        [NativeThrows]
        public void SetPlane(int index, Transform transform)
        {
            SetPlane_Injected(ref this, index, transform);
        }

        //
        // Summary:
        //     Get a collision plane associated with this Particle System.
        //
        // Parameters:
        //   index:
        //     The plane to return.
        //
        // Returns:
        //     The plane.
        [NativeThrows]
        public Transform GetPlane(int index)
        {
            return GetPlane_Injected(ref this, index);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemCollisionType get_type_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_type_Injected(ref CollisionModule _unity_self, ParticleSystemCollisionType value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemCollisionMode get_mode_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_mode_Injected(ref CollisionModule _unity_self, ParticleSystemCollisionMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_dampen_Injected(ref CollisionModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_dampen_Injected(ref CollisionModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_dampenMultiplier_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_dampenMultiplier_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_bounce_Injected(ref CollisionModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_bounce_Injected(ref CollisionModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_bounceMultiplier_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_bounceMultiplier_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_lifetimeLoss_Injected(ref CollisionModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_lifetimeLoss_Injected(ref CollisionModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_lifetimeLossMultiplier_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_lifetimeLossMultiplier_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_minKillSpeed_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_minKillSpeed_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_maxKillSpeed_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_maxKillSpeed_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_collidesWith_Injected(ref CollisionModule _unity_self, out LayerMask ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_collidesWith_Injected(ref CollisionModule _unity_self, ref LayerMask value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enableDynamicColliders_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enableDynamicColliders_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_maxCollisionShapes_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_maxCollisionShapes_Injected(ref CollisionModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemCollisionQuality get_quality_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_quality_Injected(ref CollisionModule _unity_self, ParticleSystemCollisionQuality value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_voxelSize_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_voxelSize_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radiusScale_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusScale_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_sendCollisionMessages_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sendCollisionMessages_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_colliderForce_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_colliderForce_Injected(ref CollisionModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_multiplyColliderForceByCollisionAngle_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplyColliderForceByCollisionAngle_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_multiplyColliderForceByParticleSpeed_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplyColliderForceByParticleSpeed_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_multiplyColliderForceByParticleSize_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplyColliderForceByParticleSize_Injected(ref CollisionModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddPlane_Injected(ref CollisionModule _unity_self, Transform transform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemovePlane_Injected(ref CollisionModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemovePlaneObject_Injected(ref CollisionModule _unity_self, Transform transform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetPlane_Injected(ref CollisionModule _unity_self, int index, Transform transform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Transform GetPlane_Injected(ref CollisionModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_planeCount_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enableInteriorCollisions_Injected(ref CollisionModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enableInteriorCollisions_Injected(ref CollisionModule _unity_self, bool value);
    }

    //
    // Summary:
    //     Script interface for the TriggerModule.
    public struct TriggerModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     The maximum number of collision shapes that can be attached to this Particle
        //     System trigger.
        // [Obsolete("The maxColliderCount restriction has been removed. Please use colliderCount instead to find out how many colliders there are. (UnityUpgradable) -> UnityEngine.ParticleSystem/TriggerModule.colliderCount", false)]
        // public int maxColliderCount => colliderCount;

        //
        // Summary:
        //     Specifies whether the TriggerModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what action to perform when particles are inside the trigger volume.
        public ParticleSystemOverlapAction inside
        {
            get
            {
                return get_inside_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_inside_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what action to perform when particles are outside the trigger volume.
        public ParticleSystemOverlapAction outside
        {
            get
            {
                return get_outside_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_outside_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what action to perform when particles enter the trigger volume.
        public ParticleSystemOverlapAction enter
        {
            get
            {
                return get_enter_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enter_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what action to perform when particles leave the trigger volume.
        public ParticleSystemOverlapAction exit
        {
            get
            {
                return get_exit_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_exit_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Determines whether collider information is available when calling ParticleSystem::GetTriggerParticles.
        public ParticleSystemColliderQueryMode colliderQueryMode
        {
            get
            {
                return get_colliderQueryMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_colliderQueryMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier Unity applies to the size of each particle before it processes overlaps.
        public float radiusScale
        {
            get
            {
                return get_radiusScale_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radiusScale_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Indicates the number of collision shapes attached to this Particle System trigger.
        [NativeThrows]
        public int colliderCount => get_colliderCount_Injected(ref this);

        internal TriggerModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Adds a Collision shape associated with this Particle System trigger.
        //
        // Parameters:
        //   transform:
        //     The Collider to associate with this trigger.
        //
        //   collider:
        [NativeThrows]
        public void AddCollider(Component collider)
        {
            AddCollider_Injected(ref this, collider);
        }

        //
        // Summary:
        //     Removes a collision shape associated with this Particle System trigger.
        //
        // Parameters:
        //   index:
        //     The Collider to remove.
        [NativeThrows]
        public void RemoveCollider(int index)
        {
            RemoveCollider_Injected(ref this, index);
        }

        //
        // Summary:
        //     Removes a collision shape associated with this Particle System trigger.
        //
        // Parameters:
        //   collider:
        //     The Collider to remove.
        public void RemoveCollider(Component collider)
        {
            RemoveColliderObject(collider);
        }

        [NativeThrows]
        private void RemoveColliderObject(Component collider)
        {
            RemoveColliderObject_Injected(ref this, collider);
        }

        //
        // Summary:
        //     Sets a Collision shape associated with this Particle System trigger.
        //
        // Parameters:
        //   index:
        //     The Collider entry to assign.
        //
        //   collider:
        //     The Collider to associate with this trigger.
        [NativeThrows]
        public void SetCollider(int index, Component collider)
        {
            SetCollider_Injected(ref this, index, collider);
        }

        //
        // Summary:
        //     Gets a collision shape associated with this Particle System trigger.
        //
        // Parameters:
        //   index:
        //     The Collider to return.
        //
        // Returns:
        //     The Collider at the given index.
        [NativeThrows]
        public Component GetCollider(int index)
        {
            return GetCollider_Injected(ref this, index);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref TriggerModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemOverlapAction get_inside_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_inside_Injected(ref TriggerModule _unity_self, ParticleSystemOverlapAction value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemOverlapAction get_outside_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_outside_Injected(ref TriggerModule _unity_self, ParticleSystemOverlapAction value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemOverlapAction get_enter_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enter_Injected(ref TriggerModule _unity_self, ParticleSystemOverlapAction value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemOverlapAction get_exit_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_exit_Injected(ref TriggerModule _unity_self, ParticleSystemOverlapAction value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemColliderQueryMode get_colliderQueryMode_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_colliderQueryMode_Injected(ref TriggerModule _unity_self, ParticleSystemColliderQueryMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radiusScale_Injected(ref TriggerModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radiusScale_Injected(ref TriggerModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddCollider_Injected(ref TriggerModule _unity_self, Component collider);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveCollider_Injected(ref TriggerModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveColliderObject_Injected(ref TriggerModule _unity_self, Component collider);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetCollider_Injected(ref TriggerModule _unity_self, int index, Component collider);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Component GetCollider_Injected(ref TriggerModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_colliderCount_Injected(ref TriggerModule _unity_self);
    }

    //
    // Summary:
    //     Script interface for the SubEmittersModule.
    public struct SubEmittersModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Sub-Particle System which spawns at the locations of the birth of the particles
        //     from the parent system.
        // [Obsolete("birth0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem birth0
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Sub-Particle System which spawns at the locations of the birth of the particles
        //     from the parent system.
        // [Obsolete("birth1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem birth1
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Sub-Particle System which spawns at the locations of the collision of the particles
        //     from the parent system.
        // [Obsolete("collision0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem collision0
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Sub-Particle System which spawns at the locations of the collision of the particles
        //     from the parent system.
        // [Obsolete("collision1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem collision1
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Sub-Particle System which spawns at the locations of the death of the particles
        //     from the parent system.
        // [Obsolete("death0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem death0
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Sub-Particle System to spawn on death of the parent system's particles.
        // [Obsolete("death1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
        // public ParticleSystem death1
        // {
        //     get
        //     {
        //         ThrowNotImplemented();
        //         return null;
        //     }
        //     set
        //     {
        //         ThrowNotImplemented();
        //     }
        // }

        //
        // Summary:
        //     Specifies whether the SubEmittersModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The total number of sub-emitters.
        public int subEmittersCount => get_subEmittersCount_Injected(ref this);

        private static void ThrowNotImplemented()
        {
            throw new NotImplementedException();
        }

        internal SubEmittersModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Add a new sub-emitter.
        //
        // Parameters:
        //   subEmitter:
        //     The sub-emitter to add.
        //
        //   type:
        //     The event that creates new particles.
        //
        //   properties:
        //     The properties of the new particles.
        //
        //   emitProbability:
        //     The probability that the sub-emitter emits particles. Accepts values from 0 to
        //     1, where 0 is never and 1 is always.
        [NativeThrows]
        public void AddSubEmitter(ParticleSystem subEmitter, ParticleSystemSubEmitterType type, ParticleSystemSubEmitterProperties properties, float emitProbability)
        {
            AddSubEmitter_Injected(ref this, subEmitter, type, properties, emitProbability);
        }

        //
        // Summary:
        //     Add a new sub-emitter.
        //
        // Parameters:
        //   subEmitter:
        //     The sub-emitter to add.
        //
        //   type:
        //     The event that creates new particles.
        //
        //   properties:
        //     The properties of the new particles.
        //
        //   emitProbability:
        //     The probability that the sub-emitter emits particles. Accepts values from 0 to
        //     1, where 0 is never and 1 is always.
        public void AddSubEmitter(ParticleSystem subEmitter, ParticleSystemSubEmitterType type, ParticleSystemSubEmitterProperties properties)
        {
            AddSubEmitter(subEmitter, type, properties, 1f);
        }

        //
        // Summary:
        //     Removes a sub-emitter from the given index in the array.
        //
        // Parameters:
        //   index:
        //     The index from which to remove a sub-emitter.
        [NativeThrows]
        public void RemoveSubEmitter(int index)
        {
            RemoveSubEmitter_Injected(ref this, index);
        }

        //
        // Summary:
        //     Removes a sub-emitter from the given index in the array.
        //
        // Parameters:
        //   subEmitter:
        //     The sub-emitter to remove.
        public void RemoveSubEmitter(ParticleSystem subEmitter)
        {
            RemoveSubEmitterObject(subEmitter);
        }

        [NativeThrows]
        private void RemoveSubEmitterObject(ParticleSystem subEmitter)
        {
            RemoveSubEmitterObject_Injected(ref this, subEmitter);
        }

        //
        // Summary:
        //     Sets the Particle System to use as the sub-emitter at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter you want to modify.
        //
        //   subEmitter:
        //     The Particle System to use as the sub-emitter at the specified index.
        [NativeThrows]
        public void SetSubEmitterSystem(int index, ParticleSystem subEmitter)
        {
            SetSubEmitterSystem_Injected(ref this, index, subEmitter);
        }

        //
        // Summary:
        //     Sets the type of the sub-emitter at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter you want to modify.
        //
        //   type:
        //     The new spawning type to assign to this sub-emitter.
        [NativeThrows]
        public void SetSubEmitterType(int index, ParticleSystemSubEmitterType type)
        {
            SetSubEmitterType_Injected(ref this, index, type);
        }

        //
        // Summary:
        //     Sets the properties of the sub-emitter at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter you want to modify.
        //
        //   properties:
        //     The new properties to assign to this sub-emitter.
        [NativeThrows]
        public void SetSubEmitterProperties(int index, ParticleSystemSubEmitterProperties properties)
        {
            SetSubEmitterProperties_Injected(ref this, index, properties);
        }

        //
        // Summary:
        //     Sets the probability that the sub-emitter emits particles.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter you want to modify.
        //
        //   emitProbability:
        //     The probability value.
        [NativeThrows]
        public void SetSubEmitterEmitProbability(int index, float emitProbability)
        {
            SetSubEmitterEmitProbability_Injected(ref this, index, emitProbability);
        }

        //
        // Summary:
        //     Gets the sub-emitter Particle System at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the desired sub-emitter.
        //
        // Returns:
        //     The sub-emitter at the index.
        [NativeThrows]
        public ParticleSystem GetSubEmitterSystem(int index)
        {
            return GetSubEmitterSystem_Injected(ref this, index);
        }

        //
        // Summary:
        //     Gets the type of the sub-emitter at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the desired sub-emitter.
        //
        // Returns:
        //     The type of sub-emitter at the index.
        [NativeThrows]
        public ParticleSystemSubEmitterType GetSubEmitterType(int index)
        {
            return GetSubEmitterType_Injected(ref this, index);
        }

        //
        // Summary:
        //     Gets the properties of the sub-emitter at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter.
        //
        // Returns:
        //     The properties of the sub-emitter at the index.
        [NativeThrows]
        public ParticleSystemSubEmitterProperties GetSubEmitterProperties(int index)
        {
            return GetSubEmitterProperties_Injected(ref this, index);
        }

        //
        // Summary:
        //     Gets the probability that the sub-emitter emits particles.
        //
        // Parameters:
        //   index:
        //     The index of the sub-emitter.
        //
        // Returns:
        //     The emission probability for the sub-emitter
        [NativeThrows]
        public float GetSubEmitterEmitProbability(int index)
        {
            return GetSubEmitterEmitProbability_Injected(ref this, index);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref SubEmittersModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref SubEmittersModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_subEmittersCount_Injected(ref SubEmittersModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddSubEmitter_Injected(ref SubEmittersModule _unity_self, ParticleSystem subEmitter, ParticleSystemSubEmitterType type, ParticleSystemSubEmitterProperties properties, float emitProbability);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveSubEmitter_Injected(ref SubEmittersModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveSubEmitterObject_Injected(ref SubEmittersModule _unity_self, ParticleSystem subEmitter);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetSubEmitterSystem_Injected(ref SubEmittersModule _unity_self, int index, ParticleSystem subEmitter);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetSubEmitterType_Injected(ref SubEmittersModule _unity_self, int index, ParticleSystemSubEmitterType type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetSubEmitterProperties_Injected(ref SubEmittersModule _unity_self, int index, ParticleSystemSubEmitterProperties properties);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetSubEmitterEmitProbability_Injected(ref SubEmittersModule _unity_self, int index, float emitProbability);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ParticleSystem GetSubEmitterSystem_Injected(ref SubEmittersModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ParticleSystemSubEmitterType GetSubEmitterType_Injected(ref SubEmittersModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ParticleSystemSubEmitterProperties GetSubEmitterProperties_Injected(ref SubEmittersModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern float GetSubEmitterEmitProbability_Injected(ref SubEmittersModule _unity_self, int index);
    }

    //
    // Summary:
    //     Script interface for the TextureSheetAnimationModule.
    public struct TextureSheetAnimationModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Flip the U coordinate on particles, causing them to appear mirrored horizontally.
        // [Obsolete("flipU property is deprecated. Use ParticleSystemRenderer.flip.x instead.", false)]
        // public float flipU
        // {
        //     get
        //     {
        //         return m_ParticleSystem.GetComponent<ParticleSystemRenderer>().flip.x;
        //     }
        //     set
        //     {
        //         ParticleSystemRenderer component = m_ParticleSystem.GetComponent<ParticleSystemRenderer>();
        //         Vector3 flip = component.flip;
        //         flip.x = value;
        //         component.flip = flip;
        //     }
        // }

        //
        // Summary:
        //     Flip the V coordinate on particles, causing them to appear mirrored vertically.
        // [Obsolete("flipV property is deprecated. Use ParticleSystemRenderer.flip.y instead.", false)]
        // public float flipV
        // {
        //     get
        //     {
        //         return m_ParticleSystem.GetComponent<ParticleSystemRenderer>().flip.y;
        //     }
        //     set
        //     {
        //         ParticleSystemRenderer component = m_ParticleSystem.GetComponent<ParticleSystemRenderer>();
        //         Vector3 flip = component.flip;
        //         flip.y = value;
        //         component.flip = flip;
        //     }
        // }

        //
        // Summary:
        //     Use a random row of the Texture sheet for each particle emitted.
        // [Obsolete("useRandomRow property is deprecated. Use rowMode instead.", false)]
        // public bool useRandomRow
        // {
        //     get
        //     {
        //         return rowMode == ParticleSystemAnimationRowMode.Random;
        //     }
        //     set
        //     {
        //         rowMode = (value ? ParticleSystemAnimationRowMode.Random : ParticleSystemAnimationRowMode.Custom);
        //     }
        // }

        //
        // Summary:
        //     Specifies whether the TextureSheetAnimationModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select whether the animated Texture information comes from a grid of frames on
        //     a single Texture, or from a list of Sprite objects.
        public ParticleSystemAnimationMode mode
        {
            get
            {
                return get_mode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_mode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select whether the system bases the playback on mapping a curve to the lifetime
        //     of each particle, by using the particle speeds, or if playback simply uses a
        //     constant frames per second.
        public ParticleSystemAnimationTimeMode timeMode
        {
            get
            {
                return get_timeMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_timeMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control how quickly the animation plays.
        public float fps
        {
            get
            {
                return get_fps_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_fps_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Defines the tiling of the Texture in the x-axis.
        public int numTilesX
        {
            get
            {
                return get_numTilesX_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_numTilesX_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Defines the tiling of the texture in the y-axis.
        public int numTilesY
        {
            get
            {
                return get_numTilesY_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_numTilesY_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies the animation type.
        public ParticleSystemAnimationType animation
        {
            get
            {
                return get_animation_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_animation_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select how particles choose which row of a Texture Sheet Animation to use.
        public ParticleSystemAnimationRowMode rowMode
        {
            get
            {
                return get_rowMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_rowMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A curve to control which frame of the Texture sheet animation to play.
        public MinMaxCurve frameOverTime
        {
            get
            {
                get_frameOverTime_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_frameOverTime_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The frame over time mutiplier.
        public float frameOverTimeMultiplier
        {
            get
            {
                return get_frameOverTimeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_frameOverTimeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define a random starting frame for the Texture sheet animation.
        public MinMaxCurve startFrame
        {
            get
            {
                get_startFrame_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_startFrame_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The starting frame multiplier.
        public float startFrameMultiplier
        {
            get
            {
                return get_startFrameMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_startFrameMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies how many times the animation loops during the lifetime of the particle.
        public int cycleCount
        {
            get
            {
                return get_cycleCount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_cycleCount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Explicitly select which row of the Texture sheet to use. The system uses this
        //     property when ParticleSystem.TextureSheetAnimationModule.rowMode is set to Custom.
        public int rowIndex
        {
            get
            {
                return get_rowIndex_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_rowIndex_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose which UV channels receive Texture animation.
        public UVChannelFlags uvChannelMask
        {
            get
            {
                return get_uvChannelMask_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_uvChannelMask_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The total number of sprites.
        public int spriteCount => get_spriteCount_Injected(ref this);

        //
        // Summary:
        //     Specify how particle speeds are mapped to the animation frames.
        public Vector2 speedRange
        {
            get
            {
                get_speedRange_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_speedRange_Injected(ref this, ref value);
            }
        }

        internal TextureSheetAnimationModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Add a new Sprite.
        //
        // Parameters:
        //   sprite:
        //     The Sprite to be added.
        [NativeThrows]
        public void AddSprite(Sprite sprite)
        {
            AddSprite_Injected(ref this, sprite);
        }

        //
        // Summary:
        //     Remove a Sprite from the given index in the array.
        //
        // Parameters:
        //   index:
        //     The index from which to remove a Sprite.
        [NativeThrows]
        public void RemoveSprite(int index)
        {
            RemoveSprite_Injected(ref this, index);
        }

        //
        // Summary:
        //     Set the Sprite at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the Sprite being modified.
        //
        //   sprite:
        //     The Sprite being assigned.
        [NativeThrows]
        public void SetSprite(int index, Sprite sprite)
        {
            SetSprite_Injected(ref this, index, sprite);
        }

        //
        // Summary:
        //     Get the Sprite at the given index.
        //
        // Parameters:
        //   index:
        //     The index of the desired Sprite.
        //
        // Returns:
        //     The Sprite being requested.
        [NativeThrows]
        public Sprite GetSprite(int index)
        {
            return GetSprite_Injected(ref this, index);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref TextureSheetAnimationModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemAnimationMode get_mode_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_mode_Injected(ref TextureSheetAnimationModule _unity_self, ParticleSystemAnimationMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemAnimationTimeMode get_timeMode_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_timeMode_Injected(ref TextureSheetAnimationModule _unity_self, ParticleSystemAnimationTimeMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_fps_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_fps_Injected(ref TextureSheetAnimationModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_numTilesX_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_numTilesX_Injected(ref TextureSheetAnimationModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_numTilesY_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_numTilesY_Injected(ref TextureSheetAnimationModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemAnimationType get_animation_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_animation_Injected(ref TextureSheetAnimationModule _unity_self, ParticleSystemAnimationType value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemAnimationRowMode get_rowMode_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rowMode_Injected(ref TextureSheetAnimationModule _unity_self, ParticleSystemAnimationRowMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_frameOverTime_Injected(ref TextureSheetAnimationModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_frameOverTime_Injected(ref TextureSheetAnimationModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_frameOverTimeMultiplier_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_frameOverTimeMultiplier_Injected(ref TextureSheetAnimationModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_startFrame_Injected(ref TextureSheetAnimationModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startFrame_Injected(ref TextureSheetAnimationModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_startFrameMultiplier_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_startFrameMultiplier_Injected(ref TextureSheetAnimationModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_cycleCount_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_cycleCount_Injected(ref TextureSheetAnimationModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_rowIndex_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rowIndex_Injected(ref TextureSheetAnimationModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern UVChannelFlags get_uvChannelMask_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_uvChannelMask_Injected(ref TextureSheetAnimationModule _unity_self, UVChannelFlags value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_spriteCount_Injected(ref TextureSheetAnimationModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_speedRange_Injected(ref TextureSheetAnimationModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_speedRange_Injected(ref TextureSheetAnimationModule _unity_self, ref Vector2 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddSprite_Injected(ref TextureSheetAnimationModule _unity_self, Sprite sprite);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveSprite_Injected(ref TextureSheetAnimationModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetSprite_Injected(ref TextureSheetAnimationModule _unity_self, int index, Sprite sprite);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Sprite GetSprite_Injected(ref TextureSheetAnimationModule _unity_self, int index);
    }

    //
    // Summary:
    //     Script interface for a Particle.
    [RequiredByNativeCode("particleSystemParticle", Optional = true)]
    public struct Particle
    {
        [Flags]
        private enum Flags
        {
            Size3D = 1,
            Rotation3D = 2,
            MeshIndex = 4
        }

        private Vector3 m_Position;

        private Vector3 m_Velocity;

        private Vector3 m_AnimatedVelocity;

        private Vector3 m_InitialVelocity;

        private Vector3 m_AxisOfRotation;

        private Vector3 m_Rotation;

        private Vector3 m_AngularVelocity;

        private Vector3 m_StartSize;

        private Color32 m_StartColor;

        private uint m_RandomSeed;

        private uint m_ParentRandomSeed;

        private float m_Lifetime;

        private float m_StartLifetime;

        private int m_MeshIndex;

        private float m_EmitAccumulator0;

        private float m_EmitAccumulator1;

        private uint m_Flags;

        //
        // Summary:
        //     The lifetime of the particle.
        // [Obsolete("Please use Particle.remainingLifetime instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/Particle.remainingLifetime", false)]
        // public float lifetime
        // {
        //     get
        //     {
        //         return remainingLifetime;
        //     }
        //     set
        //     {
        //         remainingLifetime = value;
        //     }
        // }

        //
        // Summary:
        //     The random value of the particle.
        // [Obsolete("randomValue property is deprecated. Use randomSeed instead to control random behavior of particles.", false)]
        // public float randomValue
        // {
        //     get
        //     {
        //         return BitConverter.ToSingle(BitConverter.GetBytes(m_RandomSeed), 0);
        //     }
        //     set
        //     {
        //         m_RandomSeed = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        //     }
        // }

        // [Obsolete("size property is deprecated. Use startSize or GetCurrentSize() instead.", false)]
        // public float size
        // {
        //     get
        //     {
        //         return startSize;
        //     }
        //     set
        //     {
        //         startSize = value;
        //     }
        // }

        // [Obsolete("color property is deprecated. Use startColor or GetCurrentColor() instead.", false)]
        // public Color32 color
        // {
        //     get
        //     {
        //         return startColor;
        //     }
        //     set
        //     {
        //         startColor = value;
        //     }
        // }

        //
        // Summary:
        //     The position of the particle.
        public Vector3 position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }

        //
        // Summary:
        //     The velocity of the particle, measured in units per second.
        public Vector3 velocity
        {
            get
            {
                return m_Velocity;
            }
            set
            {
                m_Velocity = value;
            }
        }

        //
        // Summary:
        //     The animated velocity of the particle.
        public Vector3 animatedVelocity => m_AnimatedVelocity;

        //
        // Summary:
        //     The total velocity of the particle.
        public Vector3 totalVelocity => m_Velocity + m_AnimatedVelocity;

        //
        // Summary:
        //     The remaining lifetime of the particle.
        public float remainingLifetime
        {
            get
            {
                return m_Lifetime;
            }
            set
            {
                m_Lifetime = value;
            }
        }

        //
        // Summary:
        //     The starting lifetime of the particle.
        public float startLifetime
        {
            get
            {
                return m_StartLifetime;
            }
            set
            {
                m_StartLifetime = value;
            }
        }

        //
        // Summary:
        //     The initial color of the particle. The current color of the particle is calculated
        //     procedurally based on this value and the active color modules.
        public Color32 startColor
        {
            get
            {
                return m_StartColor;
            }
            set
            {
                m_StartColor = value;
            }
        }

        //
        // Summary:
        //     The random seed of the particle.
        public uint randomSeed
        {
            get
            {
                return m_RandomSeed;
            }
            set
            {
                m_RandomSeed = value;
            }
        }

        //
        // Summary:
        //     Mesh particles rotate around this axis.
        public Vector3 axisOfRotation
        {
            get
            {
                return m_AxisOfRotation;
            }
            set
            {
                m_AxisOfRotation = value;
            }
        }

        //
        // Summary:
        //     The initial size of the particle. The current size of the particle is calculated
        //     procedurally based on this value and the active size modules.
        public float startSize
        {
            get
            {
                return m_StartSize.x;
            }
            set
            {
                m_StartSize = new Vector3(value, value, value);
            }
        }

        //
        // Summary:
        //     The initial 3D size of the particle. The current size of the particle is calculated
        //     procedurally based on this value and the active size modules.
        public Vector3 startSize3D
        {
            get
            {
                return m_StartSize;
            }
            set
            {
                m_StartSize = value;
                m_Flags |= 1u;
            }
        }

        //
        // Summary:
        //     The rotation of the particle.
        public float rotation
        {
            get
            {
                return m_Rotation.z * 57.29578f;
            }
            set
            {
                m_Rotation = new Vector3(0f, 0f, value * ((float)Math.PI / 180f));
            }
        }

        //
        // Summary:
        //     The 3D rotation of the particle.
        public Vector3 rotation3D
        {
            get
            {
                return m_Rotation * 57.29578f;
            }
            set
            {
                m_Rotation = value * ((float)Math.PI / 180f);
                m_Flags |= 2u;
            }
        }

        //
        // Summary:
        //     The angular velocity of the particle.
        public float angularVelocity
        {
            get
            {
                return m_AngularVelocity.z * 57.29578f;
            }
            set
            {
                m_AngularVelocity = new Vector3(0f, 0f, value * ((float)Math.PI / 180f));
            }
        }

        //
        // Summary:
        //     The 3D angular velocity of the particle.
        public Vector3 angularVelocity3D
        {
            get
            {
                return m_AngularVelocity * 57.29578f;
            }
            set
            {
                m_AngularVelocity = value * ((float)Math.PI / 180f);
                m_Flags |= 2u;
            }
        }

        //
        // Summary:
        //     Calculate the current size of the particle by applying the relevant curves to
        //     its startSize property.
        //
        // Parameters:
        //   system:
        //     The Particle System from which this particle was emitted.
        //
        // Returns:
        //     Current size.
        public float GetCurrentSize(ParticleSystem system)
        {
            return system.GetParticleCurrentSize(ref this);
        }

        //
        // Summary:
        //     Calculate the current 3D size of the particle by applying the relevant curves
        //     to its startSize3D property.
        //
        // Parameters:
        //   system:
        //     The Particle System from which this particle was emitted.
        //
        // Returns:
        //     Current size.
        public Vector3 GetCurrentSize3D(ParticleSystem system)
        {
            return system.GetParticleCurrentSize3D(ref this);
        }

        //
        // Summary:
        //     Calculate the current color of the particle by applying the relevant curves to
        //     its startColor property.
        //
        // Parameters:
        //   system:
        //     The Particle System from which this particle was emitted.
        //
        // Returns:
        //     Current color.
        public Color32 GetCurrentColor(ParticleSystem system)
        {
            return system.GetParticleCurrentColor(ref this);
        }

        //
        // Summary:
        //     Sets the Mesh index of the particle, used for choosing which Mesh a particle
        //     is rendered with.
        //
        // Parameters:
        //   index:
        //     The Mesh index.
        public void SetMeshIndex(int index)
        {
            m_MeshIndex = index;
            m_Flags |= 4u;
        }

        //
        // Summary:
        //     Calculate the Mesh index of the particle, used for choosing which Mesh a particle
        //     is rendered with.
        //
        // Parameters:
        //   system:
        //     The Particle System from which this particle was emitted.
        //
        // Returns:
        //     The index of the mesh used for rendering the particle.
        public int GetMeshIndex(ParticleSystem system)
        {
            return system.GetParticleMeshIndex(ref this);
        }
    }

    // [StructLayout(LayoutKind.Sequential, Size = 1)]
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("ParticleSystem.CollisionEvent has been deprecated. Use ParticleCollisionEvent instead (UnityUpgradable)", true)]
    // public struct CollisionEvent
    // {
    //     public Vector3 intersection => default(Vector3);

    //     public Vector3 normal => default(Vector3);

    //     public Vector3 velocity => default(Vector3);

    //     public Component collider => null;
    // }

    //
    // Summary:
    //     Script interface for a Burst.
    [NativeType(CodegenOptions.Custom, "MonoBurst", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
    public struct Burst
    {
        private float m_Time;

        private MinMaxCurve m_Count;

        private int m_RepeatCount;

        private float m_RepeatInterval;

        private float m_InvProbability;

        //
        // Summary:
        //     The time that each burst occurs.
        public float time
        {
            get
            {
                return m_Time;
            }
            set
            {
                m_Time = value;
            }
        }

        //
        // Summary:
        //     Specify the number of particles to emit.
        public MinMaxCurve count
        {
            get
            {
                return m_Count;
            }
            set
            {
                m_Count = value;
            }
        }

        //
        // Summary:
        //     The minimum number of particles to emit.
        public short minCount
        {
            get
            {
                return (short)m_Count.constantMin;
            }
            set
            {
                m_Count.constantMin = value;
            }
        }

        //
        // Summary:
        //     The maximum number of particles to emit.
        public short maxCount
        {
            get
            {
                return (short)m_Count.constantMax;
            }
            set
            {
                m_Count.constantMax = value;
            }
        }

        //
        // Summary:
        //     Specifies how many times the system should play the burst. Set this to 0 to make
        //     it play indefinitely.
        public int cycleCount
        {
            get
            {
                return m_RepeatCount + 1;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("cycleCount", "cycleCount must be at least 0: " + value);
                }

                m_RepeatCount = value - 1;
            }
        }

        //
        // Summary:
        //     How often to repeat the burst, in seconds.
        public float repeatInterval
        {
            get
            {
                return m_RepeatInterval;
            }
            set
            {
                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("repeatInterval", "repeatInterval must be greater than 0.0f: " + value);
                }

                m_RepeatInterval = value;
            }
        }

        //
        // Summary:
        //     The probability that the system triggers a burst.
        public float probability
        {
            get
            {
                return 1f - m_InvProbability;
            }
            set
            {
                if (value < 0f || value > 1f)
                {
                    throw new ArgumentOutOfRangeException("probability", "probability must be between 0.0f and 1.0f: " + value);
                }

                m_InvProbability = 1f - value;
            }
        }

        //
        // Summary:
        //     Construct a new Burst with a time and count.
        //
        // Parameters:
        //   _time:
        //     Time to emit the burst.
        //
        //   _minCount:
        //     Minimum number of particles to emit.
        //
        //   _maxCount:
        //     Maximum number of particles to emit.
        //
        //   _count:
        //     Number of particles to emit.
        //
        //   _cycleCount:
        //     Specifies how many times the system should play the burst. Set this to 0 to make
        //     it play indefinitely.
        //
        //   _repeatInterval:
        //     How often to repeat the burst, in seconds.
        public Burst(float _time, short _count)
        {
            m_Time = _time;
            m_Count = _count;
            m_RepeatCount = 0;
            m_RepeatInterval = 0f;
            m_InvProbability = 0f;
        }

        //
        // Summary:
        //     Construct a new Burst with a time and count.
        //
        // Parameters:
        //   _time:
        //     Time to emit the burst.
        //
        //   _minCount:
        //     Minimum number of particles to emit.
        //
        //   _maxCount:
        //     Maximum number of particles to emit.
        //
        //   _count:
        //     Number of particles to emit.
        //
        //   _cycleCount:
        //     Specifies how many times the system should play the burst. Set this to 0 to make
        //     it play indefinitely.
        //
        //   _repeatInterval:
        //     How often to repeat the burst, in seconds.
        public Burst(float _time, short _minCount, short _maxCount)
        {
            m_Time = _time;
            m_Count = new MinMaxCurve(_minCount, _maxCount);
            m_RepeatCount = 0;
            m_RepeatInterval = 0f;
            m_InvProbability = 0f;
        }

        //
        // Summary:
        //     Construct a new Burst with a time and count.
        //
        // Parameters:
        //   _time:
        //     Time to emit the burst.
        //
        //   _minCount:
        //     Minimum number of particles to emit.
        //
        //   _maxCount:
        //     Maximum number of particles to emit.
        //
        //   _count:
        //     Number of particles to emit.
        //
        //   _cycleCount:
        //     Specifies how many times the system should play the burst. Set this to 0 to make
        //     it play indefinitely.
        //
        //   _repeatInterval:
        //     How often to repeat the burst, in seconds.
        public Burst(float _time, short _minCount, short _maxCount, int _cycleCount, float _repeatInterval)
        {
            m_Time = _time;
            m_Count = new MinMaxCurve(_minCount, _maxCount);
            m_RepeatCount = _cycleCount - 1;
            m_RepeatInterval = _repeatInterval;
            m_InvProbability = 0f;
        }

        public Burst(float _time, MinMaxCurve _count)
        {
            m_Time = _time;
            m_Count = _count;
            m_RepeatCount = 0;
            m_RepeatInterval = 0f;
            m_InvProbability = 0f;
        }

        public Burst(float _time, MinMaxCurve _count, int _cycleCount, float _repeatInterval)
        {
            m_Time = _time;
            m_Count = _count;
            m_RepeatCount = _cycleCount - 1;
            m_RepeatInterval = _repeatInterval;
            m_InvProbability = 0f;
        }
    }

    //
    // Summary:
    //     Script interface for a Min-Max Gradient.
    [Serializable]
    [NativeType(CodegenOptions.Custom, "MonoMinMaxGradient", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
    public struct MinMaxGradient
    {
        [SerializeField]
        private ParticleSystemGradientMode m_Mode;

        [SerializeField]
        private Gradient m_GradientMin;

        [SerializeField]
        private Gradient m_GradientMax;

        [SerializeField]
        private Color m_ColorMin;

        [SerializeField]
        private Color m_ColorMax;

        //
        // Summary:
        //     Set the mode that the Min-Max Gradient uses to evaluate colors.
        public ParticleSystemGradientMode mode
        {
            get
            {
                return m_Mode;
            }
            set
            {
                m_Mode = value;
            }
        }

        //
        // Summary:
        //     Set a gradient for the upper bound.
        public Gradient gradientMax
        {
            get
            {
                return m_GradientMax;
            }
            set
            {
                m_GradientMax = value;
            }
        }

        //
        // Summary:
        //     Set a gradient for the lower bound.
        public Gradient gradientMin
        {
            get
            {
                return m_GradientMin;
            }
            set
            {
                m_GradientMin = value;
            }
        }

        //
        // Summary:
        //     Set a constant color for the upper bound.
        public Color colorMax
        {
            get
            {
                return m_ColorMax;
            }
            set
            {
                m_ColorMax = value;
            }
        }

        //
        // Summary:
        //     Set a constant color for the lower bound.
        public Color colorMin
        {
            get
            {
                return m_ColorMin;
            }
            set
            {
                m_ColorMin = value;
            }
        }

        //
        // Summary:
        //     Set a constant color.
        public Color color
        {
            get
            {
                return m_ColorMax;
            }
            set
            {
                m_ColorMax = value;
            }
        }

        //
        // Summary:
        //     Set the gradient.
        public Gradient gradient
        {
            get
            {
                return m_GradientMax;
            }
            set
            {
                m_GradientMax = value;
            }
        }

        //
        // Summary:
        //     A single constant color for the entire gradient.
        //
        // Parameters:
        //   color:
        //     Constant color.
        public MinMaxGradient(Color color)
        {
            m_Mode = ParticleSystemGradientMode.Color;
            m_GradientMin = null;
            m_GradientMax = null;
            m_ColorMin = Color.black;
            m_ColorMax = color;
        }

        //
        // Summary:
        //     Use one gradient when evaluating numbers along this Min-Max Gradient.
        //
        // Parameters:
        //   gradient:
        //     A single gradient for evaluating against.
        public MinMaxGradient(Gradient gradient)
        {
            m_Mode = ParticleSystemGradientMode.Gradient;
            m_GradientMin = null;
            m_GradientMax = gradient;
            m_ColorMin = Color.black;
            m_ColorMax = Color.black;
        }

        //
        // Summary:
        //     Randomly select colors based on the interval between the minimum and maximum
        //     constants.
        //
        // Parameters:
        //   min:
        //     The constant color describing the minimum colors to be evaluated.
        //
        //   max:
        //     The constant color describing the maximum colors to be evaluated.
        public MinMaxGradient(Color min, Color max)
        {
            m_Mode = ParticleSystemGradientMode.TwoColors;
            m_GradientMin = null;
            m_GradientMax = null;
            m_ColorMin = min;
            m_ColorMax = max;
        }

        //
        // Summary:
        //     Randomly select colors based on the interval between the minimum and maximum
        //     gradients.
        //
        // Parameters:
        //   min:
        //     The gradient describing the minimum colors to be evaluated.
        //
        //   max:
        //     The gradient describing the maximum colors to be evaluated.
        public MinMaxGradient(Gradient min, Gradient max)
        {
            m_Mode = ParticleSystemGradientMode.TwoGradients;
            m_GradientMin = min;
            m_GradientMax = max;
            m_ColorMin = Color.black;
            m_ColorMax = Color.black;
        }

        //
        // Summary:
        //     Manually query the gradient to calculate colors based on what mode it is in.
        //
        //
        // Parameters:
        //   time:
        //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
        //     the gradient. This is valid when ParticleSystem.MinMaxGradient.mode is set to
        //     ParticleSystemGradientMode.Gradient or ParticleSystemGradientMode.TwoGradients.
        //
        //
        //   lerpFactor:
        //     Blend between the two gradients/colors (Valid when ParticleSystem.MinMaxGradient.mode
        //     is set to ParticleSystemGradientMode.TwoColors or ParticleSystemGradientMode.TwoGradients).
        //
        //
        // Returns:
        //     Calculated gradient/color value.
        public Color Evaluate(float time)
        {
            return Evaluate(time, 1f);
        }

        //
        // Summary:
        //     Manually query the gradient to calculate colors based on what mode it is in.
        //
        //
        // Parameters:
        //   time:
        //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
        //     the gradient. This is valid when ParticleSystem.MinMaxGradient.mode is set to
        //     ParticleSystemGradientMode.Gradient or ParticleSystemGradientMode.TwoGradients.
        //
        //
        //   lerpFactor:
        //     Blend between the two gradients/colors (Valid when ParticleSystem.MinMaxGradient.mode
        //     is set to ParticleSystemGradientMode.TwoColors or ParticleSystemGradientMode.TwoGradients).
        //
        //
        // Returns:
        //     Calculated gradient/color value.
        public Color Evaluate(float time, float lerpFactor)
        {
            return m_Mode switch
            {
                ParticleSystemGradientMode.Color => m_ColorMax,
                ParticleSystemGradientMode.TwoColors => Color.Lerp(m_ColorMin, m_ColorMax, lerpFactor),
                ParticleSystemGradientMode.TwoGradients => Color.Lerp(m_GradientMin.Evaluate(time), m_GradientMax.Evaluate(time), lerpFactor),
                ParticleSystemGradientMode.RandomColor => m_GradientMax.Evaluate(lerpFactor),
                _ => m_GradientMax.Evaluate(time),
            };
        }

        public static implicit operator MinMaxGradient(Color color)
        {
            return new MinMaxGradient(color);
        }

        public static implicit operator MinMaxGradient(Gradient gradient)
        {
            return new MinMaxGradient(gradient);
        }
    }

    //
    // Summary:
    //     Script interface for Particle System emission parameters.
    public struct EmitParams
    {
        [NativeName("particle")]
        private Particle m_Particle;

        [NativeName("positionSet")]
        private bool m_PositionSet;

        [NativeName("velocitySet")]
        private bool m_VelocitySet;

        [NativeName("axisOfRotationSet")]
        private bool m_AxisOfRotationSet;

        [NativeName("rotationSet")]
        private bool m_RotationSet;

        [NativeName("rotationalSpeedSet")]
        private bool m_AngularVelocitySet;

        [NativeName("startSizeSet")]
        private bool m_StartSizeSet;

        [NativeName("startColorSet")]
        private bool m_StartColorSet;

        [NativeName("randomSeedSet")]
        private bool m_RandomSeedSet;

        [NativeName("startLifetimeSet")]
        private bool m_StartLifetimeSet;

        [NativeName("meshIndexSet")]
        private bool m_MeshIndexSet;

        [NativeName("applyShapeToPosition")]
        private bool m_ApplyShapeToPosition;

        //
        // Summary:
        //     Override all the properties of particles this system emits.
        public Particle particle
        {
            get
            {
                return m_Particle;
            }
            set
            {
                m_Particle = value;
                m_PositionSet = true;
                m_VelocitySet = true;
                m_AxisOfRotationSet = true;
                m_RotationSet = true;
                m_AngularVelocitySet = true;
                m_StartSizeSet = true;
                m_StartColorSet = true;
                m_RandomSeedSet = true;
                m_StartLifetimeSet = true;
                m_MeshIndexSet = true;
            }
        }

        //
        // Summary:
        //     Override the position of particles this system emits.
        public Vector3 position
        {
            get
            {
                return m_Particle.position;
            }
            set
            {
                m_Particle.position = value;
                m_PositionSet = true;
            }
        }

        //
        // Summary:
        //     When overriding the position of particles, setting this flag to true allows you
        //     to retain the influence of the shape module.
        public bool applyShapeToPosition
        {
            get
            {
                return m_ApplyShapeToPosition;
            }
            set
            {
                m_ApplyShapeToPosition = value;
            }
        }

        //
        // Summary:
        //     Override the velocity of particles this system emits.
        public Vector3 velocity
        {
            get
            {
                return m_Particle.velocity;
            }
            set
            {
                m_Particle.velocity = value;
                m_VelocitySet = true;
            }
        }

        //
        // Summary:
        //     Override the lifetime of particles this system emits.
        public float startLifetime
        {
            get
            {
                return m_Particle.startLifetime;
            }
            set
            {
                m_Particle.startLifetime = value;
                m_StartLifetimeSet = true;
            }
        }

        //
        // Summary:
        //     Override the initial size of particles this system emits.
        public float startSize
        {
            get
            {
                return m_Particle.startSize;
            }
            set
            {
                m_Particle.startSize = value;
                m_StartSizeSet = true;
            }
        }

        //
        // Summary:
        //     Override the initial 3D size of particles this system emits.
        public Vector3 startSize3D
        {
            get
            {
                return m_Particle.startSize3D;
            }
            set
            {
                m_Particle.startSize3D = value;
                m_StartSizeSet = true;
            }
        }

        //
        // Summary:
        //     Override the axis of rotation of particles this system emits.
        public Vector3 axisOfRotation
        {
            get
            {
                return m_Particle.axisOfRotation;
            }
            set
            {
                m_Particle.axisOfRotation = value;
                m_AxisOfRotationSet = true;
            }
        }

        //
        // Summary:
        //     Override the rotation of particles this system emits.
        public float rotation
        {
            get
            {
                return m_Particle.rotation;
            }
            set
            {
                m_Particle.rotation = value;
                m_RotationSet = true;
            }
        }

        //
        // Summary:
        //     Override the 3D rotation of particles this system emits.
        public Vector3 rotation3D
        {
            get
            {
                return m_Particle.rotation3D;
            }
            set
            {
                m_Particle.rotation3D = value;
                m_RotationSet = true;
            }
        }

        //
        // Summary:
        //     Override the angular velocity of particles this system emits.
        public float angularVelocity
        {
            get
            {
                return m_Particle.angularVelocity;
            }
            set
            {
                m_Particle.angularVelocity = value;
                m_AngularVelocitySet = true;
            }
        }

        //
        // Summary:
        //     Override the 3D angular velocity of particles this system emits.
        public Vector3 angularVelocity3D
        {
            get
            {
                return m_Particle.angularVelocity3D;
            }
            set
            {
                m_Particle.angularVelocity3D = value;
                m_AngularVelocitySet = true;
            }
        }

        //
        // Summary:
        //     Override the initial color of particles this system emits.
        public Color32 startColor
        {
            get
            {
                return m_Particle.startColor;
            }
            set
            {
                m_Particle.startColor = value;
                m_StartColorSet = true;
            }
        }

        //
        // Summary:
        //     Override the random seed of particles this system emits.
        public uint randomSeed
        {
            get
            {
                return m_Particle.randomSeed;
            }
            set
            {
                m_Particle.randomSeed = value;
                m_RandomSeedSet = true;
            }
        }

        //
        // Summary:
        //     Set the index that specifies which Mesh to emit.
        public int meshIndex
        {
            set
            {
                m_Particle.SetMeshIndex(value);
                m_MeshIndexSet = true;
            }
        }

        //
        // Summary:
        //     Revert the position back to the value specified in the Inspector.
        public void ResetPosition()
        {
            m_PositionSet = false;
        }

        //
        // Summary:
        //     Revert the velocity back to the value specified in the Inspector.
        public void ResetVelocity()
        {
            m_VelocitySet = false;
        }

        //
        // Summary:
        //     Revert the axis of rotation back to the value specified in the Inspector.
        public void ResetAxisOfRotation()
        {
            m_AxisOfRotationSet = false;
        }

        //
        // Summary:
        //     Reverts rotation and rotation3D back to the values specified in the Inspector.
        public void ResetRotation()
        {
            m_RotationSet = false;
        }

        //
        // Summary:
        //     Reverts angularVelocity and angularVelocity3D back to the values specified in
        //     the Inspector.
        public void ResetAngularVelocity()
        {
            m_AngularVelocitySet = false;
        }

        //
        // Summary:
        //     Revert the initial size back to the value specified in the Inspector.
        public void ResetStartSize()
        {
            m_StartSizeSet = false;
        }

        //
        // Summary:
        //     Revert the initial color back to the value specified in the Inspector.
        public void ResetStartColor()
        {
            m_StartColorSet = false;
        }

        //
        // Summary:
        //     Revert the random seed back to the value specified in the Inspector.
        public void ResetRandomSeed()
        {
            m_RandomSeedSet = false;
        }

        //
        // Summary:
        //     Revert the lifetime back to the value specified in the Inspector.
        public void ResetStartLifetime()
        {
            m_StartLifetimeSet = false;
        }

        //
        // Summary:
        //     Revert the Mesh selection back to the default randomized behavior.
        public void ResetMeshIndex()
        {
            m_MeshIndexSet = false;
        }
    }

    //
    // Summary:
    //     Script interface for storing the particle playback state.
    public struct PlaybackState
    {
        internal struct Seed
        {
            public uint x;

            public uint y;

            public uint z;

            public uint w;
        }

        internal struct Seed4
        {
            public Seed x;

            public Seed y;

            public Seed z;

            public Seed w;
        }

        internal struct Emission
        {
            public float m_ParticleSpacing;

            public float m_ToEmitAccumulator;

            public Seed m_Random;
        }

        internal struct Initial
        {
            public Seed4 m_Random;
        }

        internal struct Shape
        {
            public Seed4 m_Random;

            public float m_RadiusTimer;

            public float m_RadiusTimerPrev;

            public float m_ArcTimer;

            public float m_ArcTimerPrev;

            public float m_MeshSpawnTimer;

            public float m_MeshSpawnTimerPrev;

            public int m_OrderedMeshVertexIndex;
        }

        internal struct Force
        {
            public Seed4 m_Random;
        }

        internal struct Collision
        {
            public Seed4 m_Random;
        }

        internal struct Noise
        {
            public float m_ScrollOffset;
        }

        internal struct Lights
        {
            public Seed m_Random;

            public float m_ParticleEmissionCounter;
        }

        internal struct Trail
        {
            public float m_Timer;
        }

        internal float m_AccumulatedDt;

        internal float m_StartDelay;

        internal float m_PlaybackTime;

        internal int m_RingBufferIndex;

        internal Emission m_Emission;

        internal Initial m_Initial;

        internal Shape m_Shape;

        internal Force m_Force;

        internal Collision m_Collision;

        internal Noise m_Noise;

        internal Lights m_Lights;

        internal Trail m_Trail;
    }

    //
    // Summary:
    //     Script interface for storing the particle trail data.
    [NativeType(CodegenOptions.Custom, "MonoParticleTrails")]
    public struct Trails
    {
        internal List<Vector4> positions;

        internal List<int> frontPositions;

        internal List<int> backPositions;

        internal List<int> positionCounts;

        internal int maxTrailCount;

        internal int maxPositionsPerTrailCount;

        //
        // Summary:
        //     Reserve memory for the particle trail data.
        public int capacity
        {
            get
            {
                if (positions == null)
                {
                    return 0;
                }

                return positions.Capacity;
            }
            set
            {
                Allocate();
                positions.Capacity = value;
                frontPositions.Capacity = value;
                backPositions.Capacity = value;
                positionCounts.Capacity = value;
            }
        }

        internal void Allocate()
        {
            if (positions == null)
            {
                positions = new List<Vector4>();
            }

            if (frontPositions == null)
            {
                frontPositions = new List<int>();
            }

            if (backPositions == null)
            {
                backPositions = new List<int>();
            }

            if (positionCounts == null)
            {
                positionCounts = new List<int>();
            }
        }
    }

    //
    // Summary:
    //     Script interface for particle Collider data.
    public struct ColliderData
    {
        internal Component[] colliders;

        internal int[] colliderIndices;

        internal int[] particleStartIndices;

        //
        // Summary:
        //     Returns how how many Colliders a particle is interacting with.
        //
        // Parameters:
        //   particleIndex:
        //     The index of the particle event.
        //
        // Returns:
        //     The number of Colliders the particle is interacting with.
        public int GetColliderCount(int particleIndex)
        {
            if (particleIndex < particleStartIndices.Length - 1)
            {
                return particleStartIndices[particleIndex + 1] - particleStartIndices[particleIndex];
            }

            return colliderIndices.Length - particleStartIndices[particleIndex];
        }

        //
        // Summary:
        //     Retrieve a specific Collider that a particle iss interacting with.
        //
        // Parameters:
        //   particleIndex:
        //     The index of the particle event.
        //
        //   colliderIndex:
        //     The index of the collider to obtain.
        //
        // Returns:
        //     The Collider or Collider2D Component that a particle is interacting with.
        public Component GetCollider(int particleIndex, int colliderIndex)
        {
            if (colliderIndex >= GetColliderCount(particleIndex))
            {
                throw new IndexOutOfRangeException("colliderIndex exceeded the total number of colliders for the requested particle");
            }

            int num = particleStartIndices[particleIndex] + colliderIndex;
            return colliders[colliderIndices[num]];
        }
    }

    //
    // Summary:
    //     Script interface for the VelocityOverLifetimeModule.
    public struct VelocityOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the VelocityOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, on the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, on the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, on the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._x
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._y.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._z.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, around the x-axis.
        public MinMaxCurve orbitalX
        {
            get
            {
                get_orbitalX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, around the y-axis.
        public MinMaxCurve orbitalY
        {
            get
            {
                get_orbitalY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, around the z-axis.
        public MinMaxCurve orbitalZ
        {
            get
            {
                get_orbitalZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the x-axis.
        public float orbitalXMultiplier
        {
            get
            {
                return get_orbitalXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the y-axis.
        public float orbitalYMultiplier
        {
            get
            {
                return get_orbitalYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the z-axis.
        public float orbitalZMultiplier
        {
            get
            {
                return get_orbitalZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specify a custom center of rotation for the orbital and radial velocities.
        public MinMaxCurve orbitalOffsetX
        {
            get
            {
                get_orbitalOffsetX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Specify a custom center of rotation for the orbital and radial velocities.
        public MinMaxCurve orbitalOffsetY
        {
            get
            {
                get_orbitalOffsetY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Specify a custom center of rotation for the orbital and radial velocities.
        public MinMaxCurve orbitalOffsetZ
        {
            get
            {
                get_orbitalOffsetZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for _orbitalOffsetX.
        public float orbitalOffsetXMultiplier
        {
            get
            {
                return get_orbitalOffsetXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier for _orbitalOffsetY.
        public float orbitalOffsetYMultiplier
        {
            get
            {
                return get_orbitalOffsetYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     A multiplier for _orbitalOffsetY.
        public float orbitalOffsetZMultiplier
        {
            get
            {
                return get_orbitalOffsetZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_orbitalOffsetZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, away from a center position.
        public MinMaxCurve radial
        {
            get
            {
                get_radial_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_radial_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._radial.
        public float radialMultiplier
        {
            get
            {
                return get_radialMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_radialMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle speed based on lifetime, without affecting the direction
        //     of the particles.
        public MinMaxCurve speedModifier
        {
            get
            {
                get_speedModifier_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_speedModifier_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._speedModifier.
        public float speedModifierMultiplier
        {
            get
            {
                return get_speedModifierMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_speedModifierMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies if the velocities are in local space (rotated with the transform) or
        //     world space.
        public ParticleSystemSimulationSpace space
        {
            get
            {
                return get_space_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_space_Injected(ref this, value);
            }
        }

        internal VelocityOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref VelocityOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalX_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalX_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalY_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalY_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalZ_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalZ_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalXMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalXMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalYMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalYMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalZMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalZMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalOffsetX_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetX_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalOffsetY_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetY_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_orbitalOffsetZ_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetZ_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalOffsetXMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetXMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalOffsetYMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetYMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_orbitalOffsetZMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_orbitalOffsetZMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_radial_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radial_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_radialMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_radialMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_speedModifier_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_speedModifier_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_speedModifierMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_speedModifierMultiplier_Injected(ref VelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemSimulationSpace get_space_Injected(ref VelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_space_Injected(ref VelocityOverLifetimeModule _unity_self, ParticleSystemSimulationSpace value);
    }

    //
    // Summary:
    //     Script interface for the Limit Velocity Over Lifetime module.
    public struct LimitVelocityOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the LimitForceOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Maximum velocity curve for the x-axis.
        public MinMaxCurve limitX
        {
            get
            {
                get_limitX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_limitX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the limit multiplier on the x-axis.
        public float limitXMultiplier
        {
            get
            {
                return get_limitXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_limitXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Maximum velocity curve for the y-axis.
        public MinMaxCurve limitY
        {
            get
            {
                get_limitY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_limitY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the limit multiplier on the y-axis.
        public float limitYMultiplier
        {
            get
            {
                return get_limitYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_limitYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Maximum velocity curve for the z-axis.
        public MinMaxCurve limitZ
        {
            get
            {
                get_limitZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_limitZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the limit multiplier on the z-axis.
        public float limitZMultiplier
        {
            get
            {
                return get_limitZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_limitZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Maximum velocity curve, when not using one curve per axis.
        [NativeName("Magnitude")]
        public MinMaxCurve limit
        {
            get
            {
                get_limit_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_limit_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the limit multiplier.
        [NativeName("MagnitudeMultiplier")]
        public float limitMultiplier
        {
            get
            {
                return get_limitMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_limitMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Controls how much this module dampens particle velocities that exceed the velocity
        //     limit.
        public float dampen
        {
            get
            {
                return get_dampen_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_dampen_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the velocity limit on each axis separately. This module uses ParticleSystem.LimitVelocityOverLifetimeModule._drag
        //     to dampen a particle's velocity if the velocity exceeds this value.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies if the velocity limits are in local space (rotated with the transform)
        //     or world space.
        public ParticleSystemSimulationSpace space
        {
            get
            {
                return get_space_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_space_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Controls the amount of drag that this modules applies to the particle velocities.
        public MinMaxCurve drag
        {
            get
            {
                get_drag_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_drag_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Specifies the drag multiplier.
        public float dragMultiplier
        {
            get
            {
                return get_dragMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_dragMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Adjust the amount of drag this module applies to particles, based on their sizes.
        public bool multiplyDragByParticleSize
        {
            get
            {
                return get_multiplyDragByParticleSize_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplyDragByParticleSize_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Adjust the amount of drag this module applies to particles, based on their speeds.
        public bool multiplyDragByParticleVelocity
        {
            get
            {
                return get_multiplyDragByParticleVelocity_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplyDragByParticleVelocity_Injected(ref this, value);
            }
        }

        internal LimitVelocityOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref LimitVelocityOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_limitX_Injected(ref LimitVelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitX_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_limitXMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitXMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_limitY_Injected(ref LimitVelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitY_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_limitYMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitYMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_limitZ_Injected(ref LimitVelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitZ_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_limitZMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitZMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_limit_Injected(ref LimitVelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limit_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_limitMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_limitMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_dampen_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_dampen_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref LimitVelocityOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemSimulationSpace get_space_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_space_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ParticleSystemSimulationSpace value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_drag_Injected(ref LimitVelocityOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_drag_Injected(ref LimitVelocityOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_dragMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_dragMultiplier_Injected(ref LimitVelocityOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_multiplyDragByParticleSize_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplyDragByParticleSize_Injected(ref LimitVelocityOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_multiplyDragByParticleVelocity_Injected(ref LimitVelocityOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplyDragByParticleVelocity_Injected(ref LimitVelocityOverLifetimeModule _unity_self, bool value);
    }

    //
    // Summary:
    //     The Inherit Velocity Module controls how the velocity of the emitter is transferred
    //     to the particles as they are emitted.
    public struct InheritVelocityModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the InheritVelocityModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies how to apply emitter velocity to particles.
        public ParticleSystemInheritVelocityMode mode
        {
            get
            {
                return get_mode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_mode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to define how much of the emitter velocity the system applies during the
        //     lifetime of a particle.
        public MinMaxCurve curve
        {
            get
            {
                get_curve_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_curve_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Change the curve multiplier.
        public float curveMultiplier
        {
            get
            {
                return get_curveMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_curveMultiplier_Injected(ref this, value);
            }
        }

        internal InheritVelocityModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref InheritVelocityModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref InheritVelocityModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemInheritVelocityMode get_mode_Injected(ref InheritVelocityModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_mode_Injected(ref InheritVelocityModule _unity_self, ParticleSystemInheritVelocityMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_curve_Injected(ref InheritVelocityModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_curve_Injected(ref InheritVelocityModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_curveMultiplier_Injected(ref InheritVelocityModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_curveMultiplier_Injected(ref InheritVelocityModule _unity_self, float value);
    }

    //
    // Summary:
    //     The Lifetime By Emitter Speed Module controls the initial lifetime of each particle
    //     based on the speed of the emitter when the particle was spawned.
    public struct LifetimeByEmitterSpeedModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Use this property to enable or disable the LifetimeByEmitterSpeed module.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Use this curve to define which value to multiply the start lifetime of a particle
        //     with, based on the speed of the emitter when the particle is spawned.
        public MinMaxCurve curve
        {
            get
            {
                get_curve_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_curve_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Use this property to change the curve multiplier.
        public float curveMultiplier
        {
            get
            {
                return get_curveMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_curveMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control the start lifetime multiplier between these minimum and maximum speeds
        //     of the emitter.
        public Vector2 range
        {
            get
            {
                get_range_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_range_Injected(ref this, ref value);
            }
        }

        internal LifetimeByEmitterSpeedModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref LifetimeByEmitterSpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref LifetimeByEmitterSpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_curve_Injected(ref LifetimeByEmitterSpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_curve_Injected(ref LifetimeByEmitterSpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_curveMultiplier_Injected(ref LifetimeByEmitterSpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_curveMultiplier_Injected(ref LifetimeByEmitterSpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_range_Injected(ref LifetimeByEmitterSpeedModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_range_Injected(ref LifetimeByEmitterSpeedModule _unity_self, ref Vector2 value);
    }

    //
    // Summary:
    //     Script interface for the ForceOverLifetimeModule of a Particle System.
    public struct ForceOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the ForceOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The curve that defines particle forces in the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The curve defining particle forces in the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The curve defining particle forces in the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Defines the x-axis multiplier.
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Defines the y-axis multiplier.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Defines the z-axis multiplier.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether the modules applies the forces in local or world space.
        public ParticleSystemSimulationSpace space
        {
            get
            {
                return get_space_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_space_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When randomly selecting values between two curves or constants, this flag causes
        //     the system to choose a new random force on each frame.
        public bool randomized
        {
            get
            {
                return get_randomized_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_randomized_Injected(ref this, value);
            }
        }

        internal ForceOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref ForceOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref ForceOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref ForceOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref ForceOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref ForceOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref ForceOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref ForceOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref ForceOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref ForceOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref ForceOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemSimulationSpace get_space_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_space_Injected(ref ForceOverLifetimeModule _unity_self, ParticleSystemSimulationSpace value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_randomized_Injected(ref ForceOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_randomized_Injected(ref ForceOverLifetimeModule _unity_self, bool value);
    }

    //
    // Summary:
    //     Script interface for the ColorOverLifetimeModule of a Particle System.
    public struct ColorOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the ColorOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The gradient that controls the particle colors.
        public MinMaxGradient color
        {
            get
            {
                get_color_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_color_Injected(ref this, ref value);
            }
        }

        internal ColorOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref ColorOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref ColorOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_color_Injected(ref ColorOverLifetimeModule _unity_self, out MinMaxGradient ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_color_Injected(ref ColorOverLifetimeModule _unity_self, ref MinMaxGradient value);
    }

    //
    // Summary:
    //     Script interface for the ColorBySpeedModule of a Particle System.
    public struct ColorBySpeedModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the ColorBySpeedModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The gradient that controls the particle colors.
        public MinMaxGradient color
        {
            get
            {
                get_color_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_color_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Apply the color gradient between these minimum and maximum speeds.
        public Vector2 range
        {
            get
            {
                get_range_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_range_Injected(ref this, ref value);
            }
        }

        internal ColorBySpeedModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref ColorBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref ColorBySpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_color_Injected(ref ColorBySpeedModule _unity_self, out MinMaxGradient ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_color_Injected(ref ColorBySpeedModule _unity_self, ref MinMaxGradient value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_range_Injected(ref ColorBySpeedModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_range_Injected(ref ColorBySpeedModule _unity_self, ref Vector2 value);
    }

    //
    // Summary:
    //     Script interface for the SizeOverLifetimeModule.
    public struct SizeOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the SizeOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle size based on lifetime.
        [NativeName("X")]
        public MinMaxCurve size
        {
            get
            {
                get_size_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_size_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.SizeOverLifetimeModule._size.
        [NativeName("XMultiplier")]
        public float sizeMultiplier
        {
            get
            {
                return get_sizeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sizeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size over lifetime curve for the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the x-axis.
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size over lifetime curve for the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the y-axis.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size over lifetime curve for the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the z-axis.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the size over lifetime on each axis separately.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        internal SizeOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref SizeOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_size_Injected(ref SizeOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_size_Injected(ref SizeOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_sizeMultiplier_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeMultiplier_Injected(ref SizeOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref SizeOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref SizeOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref SizeOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref SizeOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref SizeOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref SizeOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref SizeOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref SizeOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref SizeOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref SizeOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref SizeOverLifetimeModule _unity_self, bool value);
    }

    //
    // Summary:
    //     Script interface for the SizeBySpeedModule.
    public struct SizeBySpeedModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the SizeBySpeedModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Curve to control particle size based on speed.
        [NativeName("X")]
        public MinMaxCurve size
        {
            get
            {
                get_size_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_size_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.SizeBySpeedModule._size.
        [NativeName("XMultiplier")]
        public float sizeMultiplier
        {
            get
            {
                return get_sizeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sizeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size by speed curve for the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the x-axis.
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size by speed curve for the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the y-axis.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Size by speed curve for the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Size multiplier along the z-axis.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the size by speed on each axis separately.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the minimum and maximum speed that this modules applies the size curve between.
        public Vector2 range
        {
            get
            {
                get_range_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_range_Injected(ref this, ref value);
            }
        }

        internal SizeBySpeedModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref SizeBySpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_size_Injected(ref SizeBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_size_Injected(ref SizeBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_sizeMultiplier_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeMultiplier_Injected(ref SizeBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref SizeBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref SizeBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref SizeBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref SizeBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref SizeBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref SizeBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref SizeBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref SizeBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref SizeBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref SizeBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref SizeBySpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_range_Injected(ref SizeBySpeedModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_range_Injected(ref SizeBySpeedModule _unity_self, ref Vector2 value);
    }

    //
    // Summary:
    //     Script interface for the RotationOverLifetimeModule.
    public struct RotationOverLifetimeModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the RotationOverLifetimeModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation over lifetime curve for the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Rotation multiplier around the x-axis.
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation over lifetime curve for the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Rotation multiplier around the y-axis.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation over lifetime curve for the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Rotation multiplier around the z-axis.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the rotation over lifetime on each axis separately.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        internal RotationOverLifetimeModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref RotationOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref RotationOverLifetimeModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref RotationOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref RotationOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref RotationOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref RotationOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref RotationOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref RotationOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref RotationOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref RotationOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref RotationOverLifetimeModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref RotationOverLifetimeModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref RotationOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref RotationOverLifetimeModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref RotationOverLifetimeModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref RotationOverLifetimeModule _unity_self, bool value);
    }

    //
    // Summary:
    //     Script interface for the RotationBySpeedModule.
    public struct RotationBySpeedModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     ESpecifies whether the RotationBySpeedModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation by speed curve for the x-axis.
        public MinMaxCurve x
        {
            get
            {
                get_x_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_x_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the x-axis.
        public float xMultiplier
        {
            get
            {
                return get_xMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_xMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation by speed curve for the y-axis.
        public MinMaxCurve y
        {
            get
            {
                get_y_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_y_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the y-axis.
        public float yMultiplier
        {
            get
            {
                return get_yMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_yMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Rotation by speed curve for the z-axis.
        public MinMaxCurve z
        {
            get
            {
                get_z_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_z_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Speed multiplier along the z-axis.
        public float zMultiplier
        {
            get
            {
                return get_zMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_zMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the rotation by speed on each axis separately.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the minimum and maximum speeds that this module applies the rotation curve
        //     between.
        public Vector2 range
        {
            get
            {
                get_range_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_range_Injected(ref this, ref value);
            }
        }

        internal RotationBySpeedModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref RotationBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref RotationBySpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_x_Injected(ref RotationBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_x_Injected(ref RotationBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_xMultiplier_Injected(ref RotationBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_xMultiplier_Injected(ref RotationBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_y_Injected(ref RotationBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_y_Injected(ref RotationBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_yMultiplier_Injected(ref RotationBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_yMultiplier_Injected(ref RotationBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_z_Injected(ref RotationBySpeedModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_z_Injected(ref RotationBySpeedModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_zMultiplier_Injected(ref RotationBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_zMultiplier_Injected(ref RotationBySpeedModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref RotationBySpeedModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref RotationBySpeedModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_range_Injected(ref RotationBySpeedModule _unity_self, out Vector2 ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_range_Injected(ref RotationBySpeedModule _unity_self, ref Vector2 value);
    }

    //
    // Summary:
    //     Script interface for the ExternalForcesModule of a Particle System.
    public struct ExternalForcesModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the ExternalForcesModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Multiplies the magnitude of external forces affecting the particles.
        public float multiplier
        {
            get
            {
                return get_multiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_multiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Multiplies the magnitude of applied external forces.
        public MinMaxCurve multiplierCurve
        {
            get
            {
                get_multiplierCurve_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_multiplierCurve_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Apply all Force Fields belonging to a matching Layer to this Particle System.
        public ParticleSystemGameObjectFilter influenceFilter
        {
            get
            {
                return get_influenceFilter_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_influenceFilter_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Particle System Force Field Components with a matching Layer affect this Particle
        //     System.
        public LayerMask influenceMask
        {
            get
            {
                get_influenceMask_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_influenceMask_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The number of Force Fields explicitly provided to the influencers list.
        [NativeThrows]
        public int influenceCount => get_influenceCount_Injected(ref this);

        internal ExternalForcesModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Determines whether any particles are inside the influence of a Force Field.
        //
        // Parameters:
        //   field:
        //     The Force Field to test.
        //
        // Returns:
        //     Whether the Force Field affects the Particle System.
        public bool IsAffectedBy(ParticleSystemForceField field)
        {
            return IsAffectedBy_Injected(ref this, field);
        }

        //
        // Summary:
        //     Adds a ParticleSystemForceField to the influencers list.
        //
        // Parameters:
        //   field:
        //     The Force Field to add to the influencers list.
        [NativeThrows]
        public void AddInfluence([NotNull("ArgumentNullException")] ParticleSystemForceField field)
        {
            AddInfluence_Injected(ref this, field);
        }

        [NativeThrows]
        private void RemoveInfluenceAtIndex(int index)
        {
            RemoveInfluenceAtIndex_Injected(ref this, index);
        }

        //
        // Summary:
        //     Removes the Force Field from the influencers list at the given index.
        //
        // Parameters:
        //   index:
        //     The index to remove the chosen Force Field from.
        //
        //   field:
        //     The Force Field to remove from the list.
        public void RemoveInfluence(int index)
        {
            RemoveInfluenceAtIndex(index);
        }

        //
        // Summary:
        //     Removes the Force Field from the influencers list at the given index.
        //
        // Parameters:
        //   index:
        //     The index to remove the chosen Force Field from.
        //
        //   field:
        //     The Force Field to remove from the list.
        [NativeThrows]
        public void RemoveInfluence([NotNull("ArgumentNullException")] ParticleSystemForceField field)
        {
            RemoveInfluence_Injected(ref this, field);
        }

        //
        // Summary:
        //     Removes every Force Field from the influencers list.
        [NativeThrows]
        public void RemoveAllInfluences()
        {
            RemoveAllInfluences_Injected(ref this);
        }

        //
        // Summary:
        //     Assigns the Force Field at the given index in the influencers list.
        //
        // Parameters:
        //   index:
        //     Index to assign the Force Field.
        //
        //   field:
        //     Force Field that to assign.
        [NativeThrows]
        public void SetInfluence(int index, [NotNull("ArgumentNullException")] ParticleSystemForceField field)
        {
            SetInfluence_Injected(ref this, index, field);
        }

        //
        // Summary:
        //     Gets the ParticleSystemForceField at the given index in the influencers list.
        //
        //
        // Parameters:
        //   index:
        //     The index to return the chosen Force Field from.
        //
        // Returns:
        //     The ForceField from the list.
        [NativeThrows]
        public ParticleSystemForceField GetInfluence(int index)
        {
            return GetInfluence_Injected(ref this, index);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref ExternalForcesModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref ExternalForcesModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_multiplier_Injected(ref ExternalForcesModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplier_Injected(ref ExternalForcesModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_multiplierCurve_Injected(ref ExternalForcesModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_multiplierCurve_Injected(ref ExternalForcesModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemGameObjectFilter get_influenceFilter_Injected(ref ExternalForcesModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_influenceFilter_Injected(ref ExternalForcesModule _unity_self, ParticleSystemGameObjectFilter value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_influenceMask_Injected(ref ExternalForcesModule _unity_self, out LayerMask ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_influenceMask_Injected(ref ExternalForcesModule _unity_self, ref LayerMask value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_influenceCount_Injected(ref ExternalForcesModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool IsAffectedBy_Injected(ref ExternalForcesModule _unity_self, ParticleSystemForceField field);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddInfluence_Injected(ref ExternalForcesModule _unity_self, ParticleSystemForceField field);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveInfluenceAtIndex_Injected(ref ExternalForcesModule _unity_self, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveInfluence_Injected(ref ExternalForcesModule _unity_self, ParticleSystemForceField field);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void RemoveAllInfluences_Injected(ref ExternalForcesModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetInfluence_Injected(ref ExternalForcesModule _unity_self, int index, ParticleSystemForceField field);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ParticleSystemForceField GetInfluence_Injected(ref ExternalForcesModule _unity_self, int index);
    }

    //
    // Summary:
    //     Script interface for the NoiseModule.
    public struct NoiseModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the the NoiseModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Control the noise separately for each axis.
        public bool separateAxes
        {
            get
            {
                return get_separateAxes_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_separateAxes_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How strong the overall noise effect is.
        [NativeName("StrengthX")]
        public MinMaxCurve strength
        {
            get
            {
                get_strength_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_strength_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Strength multiplier.
        [NativeName("StrengthXMultiplier")]
        public float strengthMultiplier
        {
            get
            {
                return get_strengthMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_strengthMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define the strength of the effect on the x-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve strengthX
        {
            get
            {
                get_strengthX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_strengthX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     x-axis strength multiplier.
        public float strengthXMultiplier
        {
            get
            {
                return get_strengthXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_strengthXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define the strength of the effect on the y-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve strengthY
        {
            get
            {
                get_strengthY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_strengthY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     y-axis strength multiplier.
        public float strengthYMultiplier
        {
            get
            {
                return get_strengthYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_strengthYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define the strength of the effect on the z-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve strengthZ
        {
            get
            {
                get_strengthZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_strengthZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     z-axis strength multiplier.
        public float strengthZMultiplier
        {
            get
            {
                return get_strengthZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_strengthZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Low values create soft, smooth noise, and high values create rapidly changing
        //     noise.
        public float frequency
        {
            get
            {
                return get_frequency_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_frequency_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Higher frequency noise reduces the strength by a proportional amount, if enabled.
        public bool damping
        {
            get
            {
                return get_damping_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_damping_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Layers of noise that combine to produce final noise.
        public int octaveCount
        {
            get
            {
                return get_octaveCount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_octaveCount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When combining each octave, scale the intensity by this amount.
        public float octaveMultiplier
        {
            get
            {
                return get_octaveMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_octaveMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     When combining each octave, zoom in by this amount.
        public float octaveScale
        {
            get
            {
                return get_octaveScale_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_octaveScale_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Generate 1D, 2D or 3D noise.
        public ParticleSystemNoiseQuality quality
        {
            get
            {
                return get_quality_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_quality_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Scroll the noise map over the Particle System.
        public MinMaxCurve scrollSpeed
        {
            get
            {
                get_scrollSpeed_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_scrollSpeed_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Scroll speed multiplier.
        public float scrollSpeedMultiplier
        {
            get
            {
                return get_scrollSpeedMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_scrollSpeedMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Enable remapping of the final noise values, allowing for noise values to be translated
        //     into different values.
        public bool remapEnabled
        {
            get
            {
                return get_remapEnabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_remapEnabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define how the noise values are remapped.
        [NativeName("RemapX")]
        public MinMaxCurve remap
        {
            get
            {
                get_remap_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_remap_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Remap multiplier.
        [NativeName("RemapXMultiplier")]
        public float remapMultiplier
        {
            get
            {
                return get_remapMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_remapMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define how the noise values are remapped on the x-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve remapX
        {
            get
            {
                get_remapX_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_remapX_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     x-axis remap multiplier.
        public float remapXMultiplier
        {
            get
            {
                return get_remapXMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_remapXMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define how the noise values are remapped on the y-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve remapY
        {
            get
            {
                get_remapY_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_remapY_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     y-axis remap multiplier.
        public float remapYMultiplier
        {
            get
            {
                return get_remapYMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_remapYMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define how the noise values are remapped on the z-axis, when using the ParticleSystem.NoiseModule.separateAxes
        //     option.
        public MinMaxCurve remapZ
        {
            get
            {
                get_remapZ_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_remapZ_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     z-axis remap multiplier.
        public float remapZMultiplier
        {
            get
            {
                return get_remapZMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_remapZMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     How much the noise affects the particle positions.
        public MinMaxCurve positionAmount
        {
            get
            {
                get_positionAmount_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_positionAmount_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     How much the noise affects the particle rotation, in degrees per second.
        public MinMaxCurve rotationAmount
        {
            get
            {
                get_rotationAmount_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_rotationAmount_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     How much the noise affects the particle sizes, applied as a multiplier on the
        //     size of each particle.
        public MinMaxCurve sizeAmount
        {
            get
            {
                get_sizeAmount_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_sizeAmount_Injected(ref this, ref value);
            }
        }

        internal NoiseModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref NoiseModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_separateAxes_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_separateAxes_Injected(ref NoiseModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_strength_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strength_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_strengthMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_strengthX_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthX_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_strengthXMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthXMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_strengthY_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthY_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_strengthYMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthYMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_strengthZ_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthZ_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_strengthZMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_strengthZMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_frequency_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_frequency_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_damping_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_damping_Injected(ref NoiseModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_octaveCount_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_octaveCount_Injected(ref NoiseModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_octaveMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_octaveMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_octaveScale_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_octaveScale_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemNoiseQuality get_quality_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_quality_Injected(ref NoiseModule _unity_self, ParticleSystemNoiseQuality value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_scrollSpeed_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_scrollSpeed_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_scrollSpeedMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_scrollSpeedMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_remapEnabled_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapEnabled_Injected(ref NoiseModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_remap_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remap_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_remapMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_remapX_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapX_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_remapXMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapXMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_remapY_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapY_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_remapYMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapYMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_remapZ_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapZ_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_remapZMultiplier_Injected(ref NoiseModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_remapZMultiplier_Injected(ref NoiseModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_positionAmount_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_positionAmount_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_rotationAmount_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rotationAmount_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_sizeAmount_Injected(ref NoiseModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeAmount_Injected(ref NoiseModule _unity_self, ref MinMaxCurve value);
    }

    //
    // Summary:
    //     Access the ParticleSystem Lights Module.
    public struct LightsModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the LightsModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what proportion of particles receive a dynamic light.
        public float ratio
        {
            get
            {
                return get_ratio_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_ratio_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Randomly assign Lights to new particles based on ParticleSystem.LightsModule.ratio.
        public bool useRandomDistribution
        {
            get
            {
                return get_useRandomDistribution_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_useRandomDistribution_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select what Light Prefab you want to base your particle lights on.
        public Light light
        {
            get
            {
                return get_light_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_light_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Toggle whether the particle lights multiply their color by the particle color.
        public bool useParticleColor
        {
            get
            {
                return get_useParticleColor_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_useParticleColor_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Toggle whether the system multiplies the particle size by the light range to
        //     determine the final light range.
        public bool sizeAffectsRange
        {
            get
            {
                return get_sizeAffectsRange_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sizeAffectsRange_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Toggle whether the system multiplies the particle alpha by the light intensity
        //     when it computes the final light intensity.
        public bool alphaAffectsIntensity
        {
            get
            {
                return get_alphaAffectsIntensity_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_alphaAffectsIntensity_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define a curve to apply custom range scaling to particle Lights.
        public MinMaxCurve range
        {
            get
            {
                get_range_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_range_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Range multiplier.
        public float rangeMultiplier
        {
            get
            {
                return get_rangeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_rangeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Define a curve to apply custom intensity scaling to particle Lights.
        public MinMaxCurve intensity
        {
            get
            {
                get_intensity_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_intensity_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Intensity multiplier.
        public float intensityMultiplier
        {
            get
            {
                return get_intensityMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_intensityMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set a limit on how many Lights this Module can create.
        public int maxLights
        {
            get
            {
                return get_maxLights_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_maxLights_Injected(ref this, value);
            }
        }

        internal LightsModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref LightsModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_ratio_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_ratio_Injected(ref LightsModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_useRandomDistribution_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_useRandomDistribution_Injected(ref LightsModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern Light get_light_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_light_Injected(ref LightsModule _unity_self, Light value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_useParticleColor_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_useParticleColor_Injected(ref LightsModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_sizeAffectsRange_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeAffectsRange_Injected(ref LightsModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_alphaAffectsIntensity_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_alphaAffectsIntensity_Injected(ref LightsModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_range_Injected(ref LightsModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_range_Injected(ref LightsModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_rangeMultiplier_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_rangeMultiplier_Injected(ref LightsModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_intensity_Injected(ref LightsModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_intensity_Injected(ref LightsModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_intensityMultiplier_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_intensityMultiplier_Injected(ref LightsModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_maxLights_Injected(ref LightsModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_maxLights_Injected(ref LightsModule _unity_self, int value);
    }

    //
    // Summary:
    //     Script interface for the TrailsModule.
    public struct TrailModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the TrailModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose how the system generates the particle trails.
        public ParticleSystemTrailMode mode
        {
            get
            {
                return get_mode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_mode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose what proportion of particles receive a trail.
        public float ratio
        {
            get
            {
                return get_ratio_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_ratio_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The curve describing the trail lifetime, throughout the lifetime of the particle.
        public MinMaxCurve lifetime
        {
            get
            {
                get_lifetime_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_lifetime_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.TrailModule._lifetime.
        public float lifetimeMultiplier
        {
            get
            {
                return get_lifetimeMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_lifetimeMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set the minimum distance each trail can travel before the system adds a new vertex
        //     to it.
        public float minVertexDistance
        {
            get
            {
                return get_minVertexDistance_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_minVertexDistance_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Choose whether the U coordinate of the trail Texture is tiled or stretched.
        public ParticleSystemTrailTextureMode textureMode
        {
            get
            {
                return get_textureMode_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_textureMode_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Drop new trail points in world space, regardless of Particle System Simulation
        //     Space.
        public bool worldSpace
        {
            get
            {
                return get_worldSpace_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_worldSpace_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether trails disappear immediately when their owning particle dies.
        //     When false, each trail persists until all its points have naturally expired,
        //     based on its lifetime.
        public bool dieWithParticles
        {
            get
            {
                return get_dieWithParticles_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_dieWithParticles_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set whether the particle size acts as a multiplier on top of the trail width.
        public bool sizeAffectsWidth
        {
            get
            {
                return get_sizeAffectsWidth_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sizeAffectsWidth_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Set whether the particle size acts as a multiplier on top of the trail lifetime.
        public bool sizeAffectsLifetime
        {
            get
            {
                return get_sizeAffectsLifetime_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_sizeAffectsLifetime_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Toggle whether the trail inherits the particle color as its starting color.
        public bool inheritParticleColor
        {
            get
            {
                return get_inheritParticleColor_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_inheritParticleColor_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The gradient that controls the trail colors during the lifetime of the attached
        //     particle.
        public MinMaxGradient colorOverLifetime
        {
            get
            {
                get_colorOverLifetime_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_colorOverLifetime_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     The curve describing the width of each trail point.
        public MinMaxCurve widthOverTrail
        {
            get
            {
                get_widthOverTrail_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_widthOverTrail_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     A multiplier for ParticleSystem.TrailModule._widthOverTrail.
        public float widthOverTrailMultiplier
        {
            get
            {
                return get_widthOverTrailMultiplier_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_widthOverTrailMultiplier_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     The gradient that controls the trail colors over the length of the trail.
        public MinMaxGradient colorOverTrail
        {
            get
            {
                get_colorOverTrail_Injected(ref this, out var ret);
                return ret;
            }
            [NativeThrows]
            set
            {
                set_colorOverTrail_Injected(ref this, ref value);
            }
        }

        //
        // Summary:
        //     Configures the trails to generate Normals and Tangents. With this data, Scene
        //     lighting can affect the trails via Normal Maps and the Unity Standard Shader,
        //     or your own custom-built Shaders.
        public bool generateLightingData
        {
            get
            {
                return get_generateLightingData_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_generateLightingData_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Select how many lines to create through the Particle System.
        public int ribbonCount
        {
            get
            {
                return get_ribbonCount_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_ribbonCount_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Apply a shadow bias to prevent self-shadowing artifacts. The specified value
        //     is the proportion of the trail width at each segment.
        public float shadowBias
        {
            get
            {
                return get_shadowBias_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_shadowBias_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Specifies whether, if you use this system as a sub-emitter, ribbons connect particles
        //     from each parent particle independently.
        public bool splitSubEmitterRibbons
        {
            get
            {
                return get_splitSubEmitterRibbons_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_splitSubEmitterRibbons_Injected(ref this, value);
            }
        }

        //
        // Summary:
        //     Adds an extra position to each ribbon, connecting it to the location of the Transform
        //     Component.
        public bool attachRibbonsToTransform
        {
            get
            {
                return get_attachRibbonsToTransform_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_attachRibbonsToTransform_Injected(ref this, value);
            }
        }

        internal TrailModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemTrailMode get_mode_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_mode_Injected(ref TrailModule _unity_self, ParticleSystemTrailMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_ratio_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_ratio_Injected(ref TrailModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_lifetime_Injected(ref TrailModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_lifetime_Injected(ref TrailModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_lifetimeMultiplier_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_lifetimeMultiplier_Injected(ref TrailModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_minVertexDistance_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_minVertexDistance_Injected(ref TrailModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern ParticleSystemTrailTextureMode get_textureMode_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_textureMode_Injected(ref TrailModule _unity_self, ParticleSystemTrailTextureMode value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_worldSpace_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_worldSpace_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_dieWithParticles_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_dieWithParticles_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_sizeAffectsWidth_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeAffectsWidth_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_sizeAffectsLifetime_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_sizeAffectsLifetime_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_inheritParticleColor_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_inheritParticleColor_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_colorOverLifetime_Injected(ref TrailModule _unity_self, out MinMaxGradient ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_colorOverLifetime_Injected(ref TrailModule _unity_self, ref MinMaxGradient value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_widthOverTrail_Injected(ref TrailModule _unity_self, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_widthOverTrail_Injected(ref TrailModule _unity_self, ref MinMaxCurve value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_widthOverTrailMultiplier_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_widthOverTrailMultiplier_Injected(ref TrailModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void get_colorOverTrail_Injected(ref TrailModule _unity_self, out MinMaxGradient ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_colorOverTrail_Injected(ref TrailModule _unity_self, ref MinMaxGradient value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_generateLightingData_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_generateLightingData_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern int get_ribbonCount_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_ribbonCount_Injected(ref TrailModule _unity_self, int value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern float get_shadowBias_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_shadowBias_Injected(ref TrailModule _unity_self, float value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_splitSubEmitterRibbons_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_splitSubEmitterRibbons_Injected(ref TrailModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_attachRibbonsToTransform_Injected(ref TrailModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_attachRibbonsToTransform_Injected(ref TrailModule _unity_self, bool value);
    }

    //
    // Summary:
    //     Script interface for the CustomDataModule of a Particle System.
    public struct CustomDataModule
    {
        internal ParticleSystem m_ParticleSystem;

        //
        // Summary:
        //     Specifies whether the CustomDataModule is enabled or disabled.
        public bool enabled
        {
            get
            {
                return get_enabled_Injected(ref this);
            }
            [NativeThrows]
            set
            {
                set_enabled_Injected(ref this, value);
            }
        }

        internal CustomDataModule(ParticleSystem particleSystem)
        {
            m_ParticleSystem = particleSystem;
        }

        //
        // Summary:
        //     Choose the type of custom data to generate for the chosen data stream.
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to enable data generation on.
        //
        //   mode:
        //     The type of data to generate.
        [NativeThrows]
        public void SetMode(ParticleSystemCustomData stream, ParticleSystemCustomDataMode mode)
        {
            SetMode_Injected(ref this, stream, mode);
        }

        //
        // Summary:
        //     Find out the type of custom data that is being generated for the chosen data
        //     stream.
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to query.
        //
        // Returns:
        //     The type of data being generated for the requested stream.
        [NativeThrows]
        public ParticleSystemCustomDataMode GetMode(ParticleSystemCustomData stream)
        {
            return GetMode_Injected(ref this, stream);
        }

        //
        // Summary:
        //     Specify how many curves are used to generate custom data for this stream.
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to apply the curve to.
        //
        //   curveCount:
        //     The number of curves to generate data for.
        //
        //   count:
        [NativeThrows]
        public void SetVectorComponentCount(ParticleSystemCustomData stream, int count)
        {
            SetVectorComponentCount_Injected(ref this, stream, count);
        }

        //
        // Summary:
        //     Query how many ParticleSystem.MinMaxCurve elements are being used to generate
        //     this stream of custom data.
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to retrieve the curve from.
        //
        // Returns:
        //     The number of curves.
        [NativeThrows]
        public int GetVectorComponentCount(ParticleSystemCustomData stream)
        {
            return GetVectorComponentCount_Injected(ref this, stream);
        }

        [NativeThrows]
        public void SetVector(ParticleSystemCustomData stream, int component, MinMaxCurve curve)
        {
            SetVector_Injected(ref this, stream, component, ref curve);
        }

        //
        // Summary:
        //     Get a ParticleSystem.MinMaxCurve, that is being used to generate custom data.
        //
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to retrieve the curve from.
        //
        //   component:
        //     The component index to retrieve the curve for (0-3, mapping to the xyzw components
        //     of a Vector4 or float4).
        //
        // Returns:
        //     The curve being used to generate custom data.
        [NativeThrows]
        public MinMaxCurve GetVector(ParticleSystemCustomData stream, int component)
        {
            GetVector_Injected(ref this, stream, component, out var ret);
            return ret;
        }

        [NativeThrows]
        public void SetColor(ParticleSystemCustomData stream, MinMaxGradient gradient)
        {
            SetColor_Injected(ref this, stream, ref gradient);
        }

        //
        // Summary:
        //     Get a ParticleSystem.MinMaxGradient, that is being used to generate custom HDR
        //     color data.
        //
        // Parameters:
        //   stream:
        //     The name of the custom data stream to retrieve the gradient from.
        //
        // Returns:
        //     The color gradient being used to generate custom color data.
        [NativeThrows]
        public MinMaxGradient GetColor(ParticleSystemCustomData stream)
        {
            GetColor_Injected(ref this, stream, out var ret);
            return ret;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern bool get_enabled_Injected(ref CustomDataModule _unity_self);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [SpecialName]
        private static extern void set_enabled_Injected(ref CustomDataModule _unity_self, bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetMode_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, ParticleSystemCustomDataMode mode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ParticleSystemCustomDataMode GetMode_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetVectorComponentCount_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, int count);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int GetVectorComponentCount_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetVector_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, int component, ref MinMaxCurve curve);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetVector_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, int component, out MinMaxCurve ret);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetColor_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, ref MinMaxGradient gradient);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetColor_Injected(ref CustomDataModule _unity_self, ParticleSystemCustomData stream, out MinMaxGradient ret);
    }

    // [Obsolete("safeCollisionEventSize has been deprecated. Use GetSafeCollisionEventSize() instead (UnityUpgradable) -> ParticlePhysicsExtensions.GetSafeCollisionEventSize(UnityEngine.ParticleSystem)", false)]
    // public int safeCollisionEventSize => ParticleSystemExtensionsImpl.GetSafeCollisionEventSize(this);

    //
    // Summary:
    //     Start delay in seconds.
    // [Obsolete("startDelay property is deprecated. Use main.startDelay or main.startDelayMultiplier instead.", false)]
    // public float startDelay
    // {
    //     get
    //     {
    //         return main.startDelayMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startDelayMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     Determines whether the Particle System is looping.
    // [Obsolete("loop property is deprecated. Use main.loop instead.", false)]
    // public bool loop
    // {
    //     get
    //     {
    //         return main.loop;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.loop = value;
    //     }
    // }

    //
    // Summary:
    //     If set to true, the Particle System will automatically start playing on startup.
    // [Obsolete("playOnAwake property is deprecated. Use main.playOnAwake instead.", false)]
    // public bool playOnAwake
    // {
    //     get
    //     {
    //         return main.playOnAwake;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.playOnAwake = value;
    //     }
    // }

    //
    // Summary:
    //     The duration of the Particle System in seconds (Read Only).
    // [Obsolete("duration property is deprecated. Use main.duration instead.", false)]
    // public float duration => main.duration;

    //
    // Summary:
    //     The playback speed of the Particle System. 1 is normal playback speed.
    // [Obsolete("playbackSpeed property is deprecated. Use main.simulationSpeed instead.", false)]
    // public float playbackSpeed
    // {
    //     get
    //     {
    //         return main.simulationSpeed;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.simulationSpeed = value;
    //     }
    // }

    //
    // Summary:
    //     When set to false, the Particle System will not emit particles.
    // [Obsolete("enableEmission property is deprecated. Use emission.enabled instead.", false)]
    // public bool enableEmission
    // {
    //     get
    //     {
    //         return emission.enabled;
    //     }
    //     set
    //     {
    //         EmissionModule emissionModule = emission;
    //         emissionModule.enabled = value;
    //     }
    // }

    //
    // Summary:
    //     The rate of particle emission.
    // [Obsolete("emissionRate property is deprecated. Use emission.rateOverTime, emission.rateOverDistance, emission.rateOverTimeMultiplier or emission.rateOverDistanceMultiplier instead.", false)]
    // public float emissionRate
    // {
    //     get
    //     {
    //         return emission.rateOverTimeMultiplier;
    //     }
    //     set
    //     {
    //         EmissionModule emissionModule = emission;
    //         emissionModule.rateOverTime = value;
    //     }
    // }

    //
    // Summary:
    //     The initial speed of particles when emitted. When using curves, this value acts
    //     as a scale on the curve.
    // [Obsolete("startSpeed property is deprecated. Use main.startSpeed or main.startSpeedMultiplier instead.", false)]
    // public float startSpeed
    // {
    //     get
    //     {
    //         return main.startSpeedMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startSpeedMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     The initial size of particles when emitted. When using curves, this value acts
    //     as a scale on the curve.
    // [Obsolete("startSize property is deprecated. Use main.startSize or main.startSizeMultiplier instead.", false)]
    // public float startSize
    // {
    //     get
    //     {
    //         return main.startSizeMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startSizeMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     The initial color of particles when emitted.
    // [Obsolete("startColor property is deprecated. Use main.startColor instead.", false)]
    // public Color startColor
    // {
    //     get
    //     {
    //         return main.startColor.color;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startColor = value;
    //     }
    // }

    //
    // Summary:
    //     The initial rotation of particles when emitted. When using curves, this value
    //     acts as a scale on the curve.
    // [Obsolete("startRotation property is deprecated. Use main.startRotation or main.startRotationMultiplier instead.", false)]
    // public float startRotation
    // {
    //     get
    //     {
    //         return main.startRotationMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startRotationMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     The initial 3D rotation of particles when emitted. When using curves, this value
    //     acts as a scale on the curves.
    // [Obsolete("startRotation3D property is deprecated. Use main.startRotationX, main.startRotationY and main.startRotationZ instead. (Or main.startRotationXMultiplier, main.startRotationYMultiplier and main.startRotationZMultiplier).", false)]
    // public Vector3 startRotation3D
    // {
    //     get
    //     {
    //         return new Vector3(main.startRotationXMultiplier, main.startRotationYMultiplier, main.startRotationZMultiplier);
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startRotationXMultiplier = value.x;
    //         mainModule.startRotationYMultiplier = value.y;
    //         mainModule.startRotationZMultiplier = value.z;
    //     }
    // }

    //
    // Summary:
    //     The total lifetime in seconds that particles will have when emitted. When using
    //     curves, this value acts as a scale on the curve. This value is set in the particle
    //     when it is created by the Particle System.
    // [Obsolete("startLifetime property is deprecated. Use main.startLifetime or main.startLifetimeMultiplier instead.", false)]
    // public float startLifetime
    // {
    //     get
    //     {
    //         return main.startLifetimeMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.startLifetimeMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     Scale being applied to the gravity defined by Physics.gravity.
    // [Obsolete("gravityModifier property is deprecated. Use main.gravityModifier or main.gravityModifierMultiplier instead.", false)]
    // public float gravityModifier
    // {
    //     get
    //     {
    //         return main.gravityModifierMultiplier;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.gravityModifierMultiplier = value;
    //     }
    // }

    //
    // Summary:
    //     The maximum number of particles to emit.
    // [Obsolete("maxParticles property is deprecated. Use main.maxParticles instead.", false)]
    // public int maxParticles
    // {
    //     get
    //     {
    //         return main.maxParticles;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.maxParticles = value;
    //     }
    // }

    //
    // Summary:
    //     This selects the space in which to simulate particles. It can be either world
    //     or local space.
    // [Obsolete("simulationSpace property is deprecated. Use main.simulationSpace instead.", false)]
    // public ParticleSystemSimulationSpace simulationSpace
    // {
    //     get
    //     {
    //         return main.simulationSpace;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.simulationSpace = value;
    //     }
    // }

    //
    // Summary:
    //     The scaling mode applied to particle sizes and positions.
    // [Obsolete("scalingMode property is deprecated. Use main.scalingMode instead.", false)]
    // public ParticleSystemScalingMode scalingMode
    // {
    //     get
    //     {
    //         return main.scalingMode;
    //     }
    //     set
    //     {
    //         MainModule mainModule = main;
    //         mainModule.scalingMode = value;
    //     }
    // }

    //
    // Summary:
    //     Does this system support Automatic Culling?
    // [Obsolete("automaticCullingEnabled property is deprecated. Use proceduralSimulationSupported instead (UnityUpgradable) -> proceduralSimulationSupported", true)]
    // public bool automaticCullingEnabled => proceduralSimulationSupported;

    // //
    // // Summary:
    // //     Determines whether the Particle System is playing.
    // public extern bool isPlaying
    // {
    //     [MethodImpl(MethodImplOptions.InternalCall)]
    //     [NativeName("SyncJobs(false)->IsPlaying")]
    //     get;
    // }

    //
    // Summary:
    //     Determines whether the Particle System is emitting particles. A Particle System
    //     may stop emitting when its emission module has finished, it has been paused or
    //     if the system has been stopped using ParticleSystem.Stop|Stop with the ParticleSystemStopBehavior.StopEmitting|StopEmitting
    //     flag. Resume emitting by calling ParticleSystem.Play|Play.
    public extern bool isEmitting
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->IsEmitting")]
        get;
    }

    //
    // Summary:
    //     Determines whether the Particle System is in the stopped state.
    public extern bool isStopped
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->IsStopped")]
        get;
    }

    //
    // Summary:
    //     Determines whether the Particle System is paused.
    public extern bool isPaused
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->IsPaused")]
        get;
    }

    //
    // Summary:
    //     The current number of particles (Read Only). The number doesn't include particles
    //     of child Particle Systems
    public extern int particleCount
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->GetParticleCount")]
        get;
    }

    //
    // Summary:
    //     Playback position in seconds.
    public extern float time
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->GetSecPosition")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->SetSecPosition")]
        set;
    }

    //
    // Summary:
    //     Override the random seed used for the Particle System emission.
    public extern uint randomSeed
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("GetRandomSeed")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->SetRandomSeed")]
        set;
    }

    //
    // Summary:
    //     Controls whether the Particle System uses an automatically-generated random number
    //     to seed the random number generator.
    public extern bool useAutoRandomSeed
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("GetAutoRandomSeed")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeName("SyncJobs(false)->SetAutoRandomSeed")]
        set;
    }

    //
    // Summary:
    //     Does this system support Procedural Simulation?
    public extern bool proceduralSimulationSupported
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    [NativeProperty("GetState().localToWorld", TargetType = TargetType.Field)]
    internal Matrix4x4 localToWorldMatrix
    {
        get
        {
            get_localToWorldMatrix_Injected(out var ret);
            return ret;
        }
    }

    //
    // Summary:
    //     Access the main Particle System settings.
    public MainModule main => new MainModule(this);

    //
    // Summary:
    //     Script interface for the EmissionModule of a Particle System.
    public EmissionModule emission => new EmissionModule(this);

    //
    // Summary:
    //     Script interface for the ShapeModule of a Particle System.
    public ShapeModule shape => new ShapeModule(this);

    //
    // Summary:
    //     Script interface for the VelocityOverLifetimeModule of a Particle System.
    public VelocityOverLifetimeModule velocityOverLifetime => new VelocityOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the LimitVelocityOverLifetimeModule of a Particle System.
    //     .
    public LimitVelocityOverLifetimeModule limitVelocityOverLifetime => new LimitVelocityOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the InheritVelocityModule of a Particle System.
    public InheritVelocityModule inheritVelocity => new InheritVelocityModule(this);

    //
    // Summary:
    //     Script interface for the Particle System Lifetime By Emitter Speed module.
    public LifetimeByEmitterSpeedModule lifetimeByEmitterSpeed => new LifetimeByEmitterSpeedModule(this);

    //
    // Summary:
    //     Script interface for the ForceOverLifetimeModule of a Particle System.
    public ForceOverLifetimeModule forceOverLifetime => new ForceOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the ColorOverLifetimeModule of a Particle System.
    public ColorOverLifetimeModule colorOverLifetime => new ColorOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the ColorByLifetimeModule of a Particle System.
    public ColorBySpeedModule colorBySpeed => new ColorBySpeedModule(this);

    //
    // Summary:
    //     Script interface for the SizeOverLifetimeModule of a Particle System.
    public SizeOverLifetimeModule sizeOverLifetime => new SizeOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the SizeBySpeedModule of a Particle System.
    public SizeBySpeedModule sizeBySpeed => new SizeBySpeedModule(this);

    //
    // Summary:
    //     Script interface for the RotationOverLifetimeModule of a Particle System.
    public RotationOverLifetimeModule rotationOverLifetime => new RotationOverLifetimeModule(this);

    //
    // Summary:
    //     Script interface for the RotationBySpeedModule of a Particle System.
    public RotationBySpeedModule rotationBySpeed => new RotationBySpeedModule(this);

    //
    // Summary:
    //     Script interface for the ExternalForcesModule of a Particle System.
    public ExternalForcesModule externalForces => new ExternalForcesModule(this);

    //
    // Summary:
    //     Script interface for the NoiseModule of a Particle System.
    public NoiseModule noise => new NoiseModule(this);

    //
    // Summary:
    //     Script interface for the CollisionModule of a Particle System.
    public CollisionModule collision => new CollisionModule(this);

    //
    // Summary:
    //     Script interface for the TriggerModule of a Particle System.
    public TriggerModule trigger => new TriggerModule(this);

    //
    // Summary:
    //     Script interface for the SubEmittersModule of a Particle System.
    public SubEmittersModule subEmitters => new SubEmittersModule(this);

    //
    // Summary:
    //     Script interface for the TextureSheetAnimationModule of a Particle System.
    public TextureSheetAnimationModule textureSheetAnimation => new TextureSheetAnimationModule(this);

    //
    // Summary:
    //     Script interface for the LightsModule of a Particle System.
    public LightsModule lights => new LightsModule(this);

    //
    // Summary:
    //     Script interface for the TrailsModule of a Particle System.
    public TrailModule trails => new TrailModule(this);

    //
    // Summary:
    //     Script interface for the CustomDataModule of a Particle System.
    public CustomDataModule customData => new CustomDataModule(this);

    //
    // Parameters:
    //   position:
    //
    //   velocity:
    //
    //   size:
    //
    //   lifetime:
    //
    //   color:
    // [Obsolete("Emit with specific parameters is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", false)]
    // public void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color)
    // {
    //     Particle particle = default(Particle);
    //     particle.position = position;
    //     particle.velocity = velocity;
    //     particle.lifetime = lifetime;
    //     particle.startLifetime = lifetime;
    //     particle.startSize = size;
    //     particle.rotation3D = Vector3.zero;
    //     particle.angularVelocity3D = Vector3.zero;
    //     particle.startColor = color;
    //     particle.randomSeed = 5u;
    //     EmitOld_Internal(ref particle);
    // }

    // [Obsolete("Emit with a single particle structure is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", false)]
    // public void Emit(Particle particle)
    // {
    //     EmitOld_Internal(ref particle);
    // }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleCurrentSize", HasExplicitThis = true)]
    internal extern float GetParticleCurrentSize(ref Particle particle);

    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleCurrentSize3D", HasExplicitThis = true)]
    internal Vector3 GetParticleCurrentSize3D(ref Particle particle)
    {
        GetParticleCurrentSize3D_Injected(ref particle, out var ret);
        return ret;
    }

    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleCurrentColor", HasExplicitThis = true)]
    internal Color32 GetParticleCurrentColor(ref Particle particle)
    {
        GetParticleCurrentColor_Injected(ref particle, out var ret);
        return ret;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleMeshIndex", HasExplicitThis = true)]
    internal extern int GetParticleMeshIndex(ref Particle particle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::SetParticles", HasExplicitThis = true, ThrowsException = true)]
    public extern void SetParticles([Out] Particle[] particles, int size, int offset);

    public void SetParticles([Out] Particle[] particles, int size)
    {
        SetParticles(particles, size, 0);
    }

    public void SetParticles([Out] Particle[] particles)
    {
        SetParticles(particles, -1);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::SetParticlesWithNativeArray", HasExplicitThis = true, ThrowsException = true)]
    private extern void SetParticlesWithNativeArray(IntPtr particles, int particlesLength, int size, int offset);

    public unsafe void SetParticles([Out] NativeArray<Particle> particles, int size, int offset)
    {
        SetParticlesWithNativeArray((IntPtr)particles.GetUnsafeReadOnlyPtr(), particles.Length, size, offset);
    }

    public void SetParticles([Out] NativeArray<Particle> particles, int size)
    {
        SetParticles(particles, size, 0);
    }

    public void SetParticles([Out] NativeArray<Particle> particles)
    {
        SetParticles(particles, -1);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticles", HasExplicitThis = true, ThrowsException = true)]
    public extern int GetParticles([Out][NotNull("ArgumentNullException")] Particle[] particles, int size, int offset);

    public int GetParticles([Out] Particle[] particles, int size)
    {
        return GetParticles(particles, size, 0);
    }

    public int GetParticles([Out] Particle[] particles)
    {
        return GetParticles(particles, -1);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetParticlesWithNativeArray", HasExplicitThis = true, ThrowsException = true)]
    private extern int GetParticlesWithNativeArray(IntPtr particles, int particlesLength, int size, int offset);

    public unsafe int GetParticles([Out] NativeArray<Particle> particles, int size, int offset)
    {
        return GetParticlesWithNativeArray((IntPtr)particles.GetUnsafePtr(), particles.Length, size, offset);
    }

    public int GetParticles([Out] NativeArray<Particle> particles, int size)
    {
        return GetParticles(particles, size, 0);
    }

    public int GetParticles([Out] NativeArray<Particle> particles)
    {
        return GetParticles(particles, -1);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::SetCustomParticleData", HasExplicitThis = true, ThrowsException = true)]
    public extern void SetCustomParticleData([NotNull("ArgumentNullException")] List<Vector4> customData, ParticleSystemCustomData streamIndex);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetCustomParticleData", HasExplicitThis = true, ThrowsException = true)]
    public extern int GetCustomParticleData([NotNull("ArgumentNullException")] List<Vector4> customData, ParticleSystemCustomData streamIndex);

    //
    // Summary:
    //     Returns all the data that relates to the current internal state of the Particle
    //     System.
    //
    // Returns:
    //     The current internal state of the Particle System.
    public PlaybackState GetPlaybackState()
    {
        GetPlaybackState_Injected(out var ret);
        return ret;
    }

    public void SetPlaybackState(PlaybackState playbackState)
    {
        SetPlaybackState_Injected(ref playbackState);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetTrailData", HasExplicitThis = true)]
    private extern void GetTrailDataInternal(ref Trails trailData);

    //
    // Summary:
    //     Returns all the data relating to the current internal state of the Particle System
    //     Trails.
    //
    // Returns:
    //     The variable to populate with the Trails that currently belong to the Particle
    //     System..
    public Trails GetTrails()
    {
        Trails trailData = default(Trails);
        trailData.Allocate();
        GetTrailDataInternal(ref trailData);
        return trailData;
    }

    public int GetTrails(ref Trails trailData)
    {
        trailData.Allocate();
        GetTrailDataInternal(ref trailData);
        return trailData.positions.Count;
    }

    [FreeFunction(Name = "ParticleSystemScriptBindings::SetTrailData", HasExplicitThis = true)]
    public void SetTrails(Trails trailData)
    {
        SetTrails_Injected(ref trailData);
    }

    //
    // Summary:
    //     Fast-forwards the Particle System by simulating particles over the given period
    //     of time, then pauses it.
    //
    // Parameters:
    //   t:
    //     Time period in seconds to advance the ParticleSystem simulation by. If restart
    //     is true, the ParticleSystem will be reset to 0 time, and then advanced by this
    //     value. If restart is false, the ParticleSystem simulation will be advanced in
    //     time from its current state by this value.
    //
    //   withChildren:
    //     Fast-forward all child Particle Systems as well.
    //
    //   restart:
    //     Restart and start from the beginning.
    //
    //   fixedTimeStep:
    //     Only update the system at fixed intervals, based on the value in "Fixed Time"
    //     in the Time options.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::Simulate", HasExplicitThis = true)]
    public extern void Simulate(float t, [UnityEngine.Internal.DefaultValue("true")] bool withChildren, [UnityEngine.Internal.DefaultValue("true")] bool restart, [UnityEngine.Internal.DefaultValue("true")] bool fixedTimeStep);

    //
    // Summary:
    //     Fast-forwards the Particle System by simulating particles over the given period
    //     of time, then pauses it.
    //
    // Parameters:
    //   t:
    //     Time period in seconds to advance the ParticleSystem simulation by. If restart
    //     is true, the ParticleSystem will be reset to 0 time, and then advanced by this
    //     value. If restart is false, the ParticleSystem simulation will be advanced in
    //     time from its current state by this value.
    //
    //   withChildren:
    //     Fast-forward all child Particle Systems as well.
    //
    //   restart:
    //     Restart and start from the beginning.
    //
    //   fixedTimeStep:
    //     Only update the system at fixed intervals, based on the value in "Fixed Time"
    //     in the Time options.
    public void Simulate(float t, [UnityEngine.Internal.DefaultValue("true")] bool withChildren, [UnityEngine.Internal.DefaultValue("true")] bool restart)
    {
        Simulate(t, withChildren, restart, fixedTimeStep: true);
    }

    //
    // Summary:
    //     Fast-forwards the Particle System by simulating particles over the given period
    //     of time, then pauses it.
    //
    // Parameters:
    //   t:
    //     Time period in seconds to advance the ParticleSystem simulation by. If restart
    //     is true, the ParticleSystem will be reset to 0 time, and then advanced by this
    //     value. If restart is false, the ParticleSystem simulation will be advanced in
    //     time from its current state by this value.
    //
    //   withChildren:
    //     Fast-forward all child Particle Systems as well.
    //
    //   restart:
    //     Restart and start from the beginning.
    //
    //   fixedTimeStep:
    //     Only update the system at fixed intervals, based on the value in "Fixed Time"
    //     in the Time options.
    public void Simulate(float t, [UnityEngine.Internal.DefaultValue("true")] bool withChildren)
    {
        Simulate(t, withChildren, restart: true);
    }

    //
    // Summary:
    //     Fast-forwards the Particle System by simulating particles over the given period
    //     of time, then pauses it.
    //
    // Parameters:
    //   t:
    //     Time period in seconds to advance the ParticleSystem simulation by. If restart
    //     is true, the ParticleSystem will be reset to 0 time, and then advanced by this
    //     value. If restart is false, the ParticleSystem simulation will be advanced in
    //     time from its current state by this value.
    //
    //   withChildren:
    //     Fast-forward all child Particle Systems as well.
    //
    //   restart:
    //     Restart and start from the beginning.
    //
    //   fixedTimeStep:
    //     Only update the system at fixed intervals, based on the value in "Fixed Time"
    //     in the Time options.
    public void Simulate(float t)
    {
        Simulate(t, withChildren: true);
    }

    //
    // Summary:
    //     Starts the Particle System.
    //
    // Parameters:
    //   withChildren:
    //     Play all child Particle Systems as well.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::Play", HasExplicitThis = true)]
    public extern void Play([UnityEngine.Internal.DefaultValue("true")] bool withChildren);

    //
    // Summary:
    //     Starts the Particle System.
    //
    // Parameters:
    //   withChildren:
    //     Play all child Particle Systems as well.
    public void Play()
    {
        Play(withChildren: true);
    }

    //
    // Summary:
    //     Pauses the system so no new particles are emitted and the existing particles
    //     are not updated.
    //
    // Parameters:
    //   withChildren:
    //     Pause all child Particle Systems as well.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::Pause", HasExplicitThis = true)]
    public extern void Pause([UnityEngine.Internal.DefaultValue("true")] bool withChildren);

    //
    // Summary:
    //     Pauses the system so no new particles are emitted and the existing particles
    //     are not updated.
    //
    // Parameters:
    //   withChildren:
    //     Pause all child Particle Systems as well.
    public void Pause()
    {
        Pause(withChildren: true);
    }

    //
    // Summary:
    //     Stops playing the Particle System using the supplied stop behaviour.
    //
    // Parameters:
    //   withChildren:
    //     Stop all child Particle Systems as well.
    //
    //   stopBehavior:
    //     Stop emitting or stop emitting and clear the system.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::Stop", HasExplicitThis = true)]
    public extern void Stop([UnityEngine.Internal.DefaultValue("true")] bool withChildren, [UnityEngine.Internal.DefaultValue("ParticleSystemStopBehavior.StopEmitting")] ParticleSystemStopBehavior stopBehavior);

    //
    // Summary:
    //     Stops playing the Particle System using the supplied stop behaviour.
    //
    // Parameters:
    //   withChildren:
    //     Stop all child Particle Systems as well.
    //
    //   stopBehavior:
    //     Stop emitting or stop emitting and clear the system.
    public void Stop([UnityEngine.Internal.DefaultValue("true")] bool withChildren)
    {
        Stop(withChildren, ParticleSystemStopBehavior.StopEmitting);
    }

    //
    // Summary:
    //     Stops playing the Particle System using the supplied stop behaviour.
    //
    // Parameters:
    //   withChildren:
    //     Stop all child Particle Systems as well.
    //
    //   stopBehavior:
    //     Stop emitting or stop emitting and clear the system.
    public void Stop()
    {
        Stop(withChildren: true);
    }

    //
    // Summary:
    //     Remove all particles in the Particle System.
    //
    // Parameters:
    //   withChildren:
    //     Clear all child Particle Systems as well.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::Clear", HasExplicitThis = true)]
    public extern void Clear([UnityEngine.Internal.DefaultValue("true")] bool withChildren);

    //
    // Summary:
    //     Remove all particles in the Particle System.
    //
    // Parameters:
    //   withChildren:
    //     Clear all child Particle Systems as well.
    public void Clear()
    {
        Clear(withChildren: true);
    }

    //
    // Summary:
    //     Does the Particle System contain any live particles, or will it produce more?
    //
    //
    // Parameters:
    //   withChildren:
    //     Check all child Particle Systems as well.
    //
    // Returns:
    //     True if the Particle System contains live particles or is still creating new
    //     particles. False if the Particle System has stopped emitting particles and all
    //     particles are dead.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::IsAlive", HasExplicitThis = true)]
    public extern bool IsAlive([UnityEngine.Internal.DefaultValue("true")] bool withChildren);

    //
    // Summary:
    //     Does the Particle System contain any live particles, or will it produce more?
    //
    //
    // Parameters:
    //   withChildren:
    //     Check all child Particle Systems as well.
    //
    // Returns:
    //     True if the Particle System contains live particles or is still creating new
    //     particles. False if the Particle System has stopped emitting particles and all
    //     particles are dead.
    public bool IsAlive()
    {
        return IsAlive(withChildren: true);
    }

    //
    // Summary:
    //     Emit count particles immediately.
    //
    // Parameters:
    //   count:
    //     Number of particles to emit.
    [RequiredByNativeCode]
    public void Emit(int count)
    {
        Emit_Internal(count);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("SyncJobs()->Emit")]
    private extern void Emit_Internal(int count);

    [NativeName("SyncJobs()->EmitParticlesExternal")]
    public void Emit(EmitParams emitParams, int count)
    {
        Emit_Injected(ref emitParams, count);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("SyncJobs()->EmitParticleExternal")]
    private extern void EmitOld_Internal(ref Particle particle);

    //
    // Summary:
    //     Triggers the specified sub emitter on all particles of the Particle System.
    //
    // Parameters:
    //   subEmitterIndex:
    //     Index of the sub emitter to trigger.
    public void TriggerSubEmitter(int subEmitterIndex)
    {
        TriggerSubEmitter(subEmitterIndex, null);
    }

    public void TriggerSubEmitter(int subEmitterIndex, ref Particle particle)
    {
        TriggerSubEmitterForParticle(subEmitterIndex, particle);
    }

    [FreeFunction(Name = "ParticleSystemScriptBindings::TriggerSubEmitterForParticle", HasExplicitThis = true)]
    internal void TriggerSubEmitterForParticle(int subEmitterIndex, Particle particle)
    {
        TriggerSubEmitterForParticle_Injected(subEmitterIndex, ref particle);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::TriggerSubEmitter", HasExplicitThis = true)]
    public extern void TriggerSubEmitter(int subEmitterIndex, List<Particle> particles);

    //
    // Summary:
    //     Reset the cache of reserved graphics memory used for efficient rendering of Particle
    //     Systems.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemGeometryJob::ResetPreMappedBufferMemory")]
    public static extern void ResetPreMappedBufferMemory();

    //
    // Summary:
    //     Limits the amount of graphics memory Unity reserves for efficient rendering of
    //     Particle Systems.
    //
    // Parameters:
    //   vertexBuffersCount:
    //     The maximum number of cached vertex buffers.
    //
    //   indexBuffersCount:
    //     The maximum number of cached index buffers.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemGeometryJob::SetMaximumPreMappedBufferCounts")]
    public static extern void SetMaximumPreMappedBufferCounts(int vertexBuffersCount, int indexBuffersCount);

    //
    // Summary:
    //     Ensures that the ParticleSystemJobs.ParticleSystemJobData._axisOfRotations|axisOfRotations
    //     particle attribute array is allocated.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("SetUsesAxisOfRotation")]
    public extern void AllocateAxisOfRotationAttribute();

    //
    // Summary:
    //     Ensures that the ParticleSystemJobs.ParticleSystemJobData._meshIndices|meshIndices
    //     particle attribute array is allocated.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("SetUsesMeshIndex")]
    public extern void AllocateMeshIndexAttribute();

    //
    // Summary:
    //     Ensures that the ParticleSystemJobs.ParticleSystemJobData.customData1|customData1
    //     and ParticleSystemJobs.ParticleSystemJobData.customData1|customData2 particle
    //     attribute arrays are allocated.
    //
    // Parameters:
    //   stream:
    //     The custom data stream to allocate.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("SetUsesCustomData")]
    public extern void AllocateCustomDataAttribute(ParticleSystemCustomData stream);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal unsafe extern void* GetManagedJobData();

    internal JobHandle GetManagedJobHandle()
    {
        GetManagedJobHandle_Injected(out var ret);
        return ret;
    }

    internal void SetManagedJobHandle(JobHandle handle)
    {
        SetManagedJobHandle_Injected(ref handle);
    }

    [FreeFunction("ScheduleManagedJob", ThrowsException = true)]
    internal unsafe static JobHandle ScheduleManagedJob(ref JobsUtility.JobScheduleParameters parameters, void* additionalData)
    {
        ScheduleManagedJob_Injected(ref parameters, additionalData, out var ret);
        return ret;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [ThreadSafe]
    internal unsafe static extern void CopyManagedJobData(void* systemPtr, out NativeParticleData particleData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemEditor::SetupDefaultParticleSystemType", HasExplicitThis = true)]
    internal extern void SetupDefaultType(ParticleSystemSubEmitterType type);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeName("GetNoiseModule().GeneratePreviewTexture")]
    internal extern void GenerateNoisePreviewTexture(Texture2D dst);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void CalculateEffectUIData(ref int particleCount, ref float fastestParticle, ref float slowestParticle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern int GenerateRandomSeed();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::CalculateEffectUISubEmitterData", HasExplicitThis = true)]
    internal extern bool CalculateEffectUISubEmitterData(ref int particleCount, ref float fastestParticle, ref float slowestParticle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::CheckVertexStreamsMatchShader")]
    internal static extern bool CheckVertexStreamsMatchShader(bool hasTangent, bool hasColor, int texCoordChannelCount, Material material, ref bool tangentError, ref bool colorError, ref bool uvError);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemScriptBindings::GetMaxTexCoordStreams")]
    internal static extern int GetMaxTexCoordStreams();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetParticleCurrentSize3D_Injected(ref Particle particle, out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetParticleCurrentColor_Injected(ref Particle particle, out Color32 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetPlaybackState_Injected(out PlaybackState ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetPlaybackState_Injected(ref PlaybackState playbackState);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetTrails_Injected(ref Trails trailData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Emit_Injected(ref EmitParams emitParams, int count);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void TriggerSubEmitterForParticle_Injected(int subEmitterIndex, ref Particle particle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetManagedJobHandle_Injected(out JobHandle ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetManagedJobHandle_Injected(ref JobHandle handle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private unsafe static extern void ScheduleManagedJob_Injected(ref JobsUtility.JobScheduleParameters parameters, void* additionalData, out JobHandle ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_localToWorldMatrix_Injected(out Matrix4x4 ret);
}

