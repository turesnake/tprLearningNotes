#region 程序集 UnityEngine.ParticleSystemModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.ParticleSystemModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     Script interface for ParticleSystem. Unity's powerful and versatile particle
    //     system implementation.
    [NativeHeaderAttribute("ParticleSystemScriptingClasses.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ParticleSystemGeometryJob.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
    [NativeHeaderAttribute("ParticleSystemScriptingClasses.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ParticleSystem.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ScriptBindings/ParticleSystemModulesScriptBindings.h")]
    [NativeHeaderAttribute("Modules/ParticleSystem/ParticleSystem.h")]
    [RequireComponent(typeof(Transform))]
    [UsedByNativeCodeAttribute]
    public sealed class ParticleSystem : Component
    {
        public ParticleSystem();

        //
        // 摘要:
        //     The scaling mode applied to particle sizes and positions.
        [Obsolete("scalingMode property is deprecated. Use main.scalingMode instead.", false)]
        public ParticleSystemScalingMode scalingMode { get; set; }
        //
        // 摘要:
        //     The current number of particles (Read Only).
        public int particleCount { get; }
        //
        // 摘要:
        //     The initial color of particles when emitted.
        [Obsolete("startColor property is deprecated. Use main.startColor instead.", false)]
        public Color startColor { get; set; }
        //
        // 摘要:
        //     Determines whether the Particle System is in the stopped state.
        public bool isStopped { get; }
        //
        // 摘要:
        //     Determines whether the Particle System is emitting particles. A Particle System
        //     may stop emitting when its emission module has finished, it has been paused or
        //     if the system has been stopped using ParticleSystem.Stop|Stop with the ParticleSystemStopBehavior.StopEmitting|StopEmitting
        //     flag. Resume emitting by calling ParticleSystem.Play|Play.
        public bool isEmitting { get; }
        //
        // 摘要:
        //     Determines whether the Particle System is playing.
        public bool isPlaying { get; }
        //
        // 摘要:
        //     Does this system support Automatic Culling?
        [Obsolete("automaticCullingEnabled property is deprecated. Use proceduralSimulationSupported instead (UnityUpgradable) -> proceduralSimulationSupported", true)]
        public bool automaticCullingEnabled { get; }
        //
        // 摘要:
        //     This selects the space in which to simulate particles. It can be either world
        //     or local space.
        [Obsolete("simulationSpace property is deprecated. Use main.simulationSpace instead.", false)]
        public ParticleSystemSimulationSpace simulationSpace { get; set; }
        //
        // 摘要:
        //     The maximum number of particles to emit.
        [Obsolete("maxParticles property is deprecated. Use main.maxParticles instead.", false)]
        public int maxParticles { get; set; }
        //
        // 摘要:
        //     Scale being applied to the gravity defined by Physics.gravity.
        [Obsolete("gravityModifier property is deprecated. Use main.gravityModifier or main.gravityModifierMultiplier instead.", false)]
        public float gravityModifier { get; set; }
        //
        // 摘要:
        //     The total lifetime in seconds that particles will have when emitted. When using
        //     curves, this value acts as a scale on the curve. This value is set in the particle
        //     when it is created by the Particle System.
        [Obsolete("startLifetime property is deprecated. Use main.startLifetime or main.startLifetimeMultiplier instead.", false)]
        public float startLifetime { get; set; }
        //
        // 摘要:
        //     The initial 3D rotation of particles when emitted. When using curves, this value
        //     acts as a scale on the curves.
        [Obsolete("startRotation3D property is deprecated. Use main.startRotationX, main.startRotationY and main.startRotationZ instead. (Or main.startRotationXMultiplier, main.startRotationYMultiplier and main.startRotationZMultiplier).", false)]
        public Vector3 startRotation3D { get; set; }
        [Obsolete("safeCollisionEventSize has been deprecated. Use GetSafeCollisionEventSize() instead (UnityUpgradable) -> ParticlePhysicsExtensions.GetSafeCollisionEventSize(UnityEngine.ParticleSystem)", false)]
        public int safeCollisionEventSize { get; }
        //
        // 摘要:
        //     Start delay in seconds.
        [Obsolete("startDelay property is deprecated. Use main.startDelay or main.startDelayMultiplier instead.", false)]
        public float startDelay { get; set; }
        //
        // 摘要:
        //     Determines whether the Particle System is looping.
        [Obsolete("loop property is deprecated. Use main.loop instead.", false)]
        public bool loop { get; set; }
        //
        // 摘要:
        //     If set to true, the Particle System will automatically start playing on startup.
        [Obsolete("playOnAwake property is deprecated. Use main.playOnAwake instead.", false)]
        public bool playOnAwake { get; set; }
        //
        // 摘要:
        //     The duration of the Particle System in seconds (Read Only).
        [Obsolete("duration property is deprecated. Use main.duration instead.", false)]
        public float duration { get; }
        //
        // 摘要:
        //     The playback speed of the Particle System. 1 is normal playback speed.
        [Obsolete("playbackSpeed property is deprecated. Use main.simulationSpeed instead.", false)]
        public float playbackSpeed { get; set; }
        //
        // 摘要:
        //     When set to false, the Particle System will not emit particles.
        [Obsolete("enableEmission property is deprecated. Use emission.enabled instead.", false)]
        public bool enableEmission { get; set; }
        //
        // 摘要:
        //     The rate of particle emission.
        [Obsolete("emissionRate property is deprecated. Use emission.rateOverTime, emission.rateOverDistance, emission.rateOverTimeMultiplier or emission.rateOverDistanceMultiplier instead.", false)]
        public float emissionRate { get; set; }
        //
        // 摘要:
        //     The initial speed of particles when emitted. When using curves, this value acts
        //     as a scale on the curve.
        [Obsolete("startSpeed property is deprecated. Use main.startSpeed or main.startSpeedMultiplier instead.", false)]
        public float startSpeed { get; set; }
        //
        // 摘要:
        //     The initial size of particles when emitted. When using curves, this value acts
        //     as a scale on the curve.
        [Obsolete("startSize property is deprecated. Use main.startSize or main.startSizeMultiplier instead.", false)]
        public float startSize { get; set; }
        //
        // 摘要:
        //     Playback position in seconds.
        public float time { get; set; }
        //
        // 摘要:
        //     Override the random seed used for the Particle System emission.
        public uint randomSeed { get; set; }
        //
        // 摘要:
        //     Determines whether the Particle System is paused.
        public bool isPaused { get; }
        //
        // 摘要:
        //     Does this system support Procedural Simulation?
        public bool proceduralSimulationSupported { get; }
        //
        // 摘要:
        //     Script interface for the CustomDataModule of a Particle System.
        public CustomDataModule customData { get; }
        //
        // 摘要:
        //     Script interface for the TrailsModule of a Particle System.
        public TrailModule trails { get; }
        //
        // 摘要:
        //     Script interface for the LightsModule of a Particle System.
        public LightsModule lights { get; }
        //
        // 摘要:
        //     Script interface for the TextureSheetAnimationModule of a Particle System.
        public TextureSheetAnimationModule textureSheetAnimation { get; }
        //
        // 摘要:
        //     Script interface for the SubEmittersModule of a Particle System.
        public SubEmittersModule subEmitters { get; }
        //
        // 摘要:
        //     Script interface for the TriggerModule of a Particle System.
        public TriggerModule trigger { get; }
        //
        // 摘要:
        //     Script interface for the CollisionModule of a Particle System.
        public CollisionModule collision { get; }
        //
        // 摘要:
        //     Script interface for the NoiseModule of a Particle System.
        public NoiseModule noise { get; }
        //
        // 摘要:
        //     Script interface for the ExternalForcesModule of a Particle System.
        public ExternalForcesModule externalForces { get; }
        //
        // 摘要:
        //     Script interface for the RotationBySpeedModule of a Particle System.
        public RotationBySpeedModule rotationBySpeed { get; }
        //
        // 摘要:
        //     Script interface for the RotationOverLifetimeModule of a Particle System.
        public RotationOverLifetimeModule rotationOverLifetime { get; }
        //
        // 摘要:
        //     Controls whether the Particle System uses an automatically-generated random number
        //     to seed the random number generator.
        public bool useAutoRandomSeed { get; set; }
        //
        // 摘要:
        //     Script interface for the SizeBySpeedModule of a Particle System.
        public SizeBySpeedModule sizeBySpeed { get; }
        //
        // 摘要:
        //     The initial rotation of particles when emitted. When using curves, this value
        //     acts as a scale on the curve.
        [Obsolete("startRotation property is deprecated. Use main.startRotation or main.startRotationMultiplier instead.", false)]
        public float startRotation { get; set; }
        //
        // 摘要:
        //     Script interface for the InheritVelocityModule of a Particle System.
        public InheritVelocityModule inheritVelocity { get; }
        //
        // 摘要:
        //     Script interface for the ColorByLifetimeModule of a Particle System.
        public ColorBySpeedModule colorBySpeed { get; }
        //
        // 摘要:
        //     Access the main Particle System settings.
        public MainModule main { get; }
        //
        // 摘要:
        //     Script interface for the EmissionModule of a Particle System.
        public EmissionModule emission { get; }
        //
        // 摘要:
        //     Script interface for the ShapeModule of a Particle System.
        public ShapeModule shape { get; }
        //
        // 摘要:
        //     Script interface for the ColorOverLifetimeModule of a Particle System.
        public ColorOverLifetimeModule colorOverLifetime { get; }
        //
        // 摘要:
        //     Script interface for the ForceOverLifetimeModule of a Particle System.
        public ForceOverLifetimeModule forceOverLifetime { get; }
        //
        // 摘要:
        //     Script interface for the Particle System Lifetime By Emitter Speed module.
        public LifetimeByEmitterSpeedModule lifetimeByEmitterSpeed { get; }
        //
        // 摘要:
        //     Script interface for the SizeOverLifetimeModule of a Particle System.
        public SizeOverLifetimeModule sizeOverLifetime { get; }
        //
        // 摘要:
        //     Script interface for the VelocityOverLifetimeModule of a Particle System.
        public VelocityOverLifetimeModule velocityOverLifetime { get; }
        //
        // 摘要:
        //     Script interface for the LimitVelocityOverLifetimeModule of a Particle System.
        //     .
        public LimitVelocityOverLifetimeModule limitVelocityOverLifetime { get; }

        //
        // 摘要:
        //     Reset the cache of reserved graphics memory used for efficient rendering of Particle
        //     Systems.
        [FreeFunctionAttribute(Name = "ParticleSystemGeometryJob::ResetPreMappedBufferMemory")]
        public static void ResetPreMappedBufferMemory();
        //
        // 摘要:
        //     Limits the amount of graphics memory Unity reserves for efficient rendering of
        //     Particle Systems.
        //
        // 参数:
        //   vertexBuffersCount:
        //     The maximum number of cached vertex buffers.
        //
        //   indexBuffersCount:
        //     The maximum number of cached index buffers.
        [FreeFunctionAttribute(Name = "ParticleSystemGeometryJob::SetMaximumPreMappedBufferCounts")]
        public static void SetMaximumPreMappedBufferCounts(int vertexBuffersCount, int indexBuffersCount);
        //
        // 摘要:
        //     Ensures that the ParticleSystemJobs.ParticleSystemJobData._axisOfRotations|axisOfRotations
        //     particle attribute array is allocated.
        [NativeNameAttribute("SetUsesAxisOfRotation")]
        public void AllocateAxisOfRotationAttribute();
        //
        // 摘要:
        //     Ensures that the ParticleSystemJobs.ParticleSystemJobData.customData1|customData1
        //     and ParticleSystemJobs.ParticleSystemJobData.customData1|customData2 particle
        //     attribute arrays are allocated.
        //
        // 参数:
        //   stream:
        //     The custom data stream to allocate.
        [NativeNameAttribute("SetUsesCustomData")]
        public void AllocateCustomDataAttribute(ParticleSystemCustomData stream);
        //
        // 摘要:
        //     Ensures that the ParticleSystemJobs.ParticleSystemJobData._meshIndices|meshIndices
        //     particle attribute array is allocated.
        [NativeNameAttribute("SetUsesMeshIndex")]
        public void AllocateMeshIndexAttribute();
        //
        // 摘要:
        //     Remove all particles in the Particle System.
        //
        // 参数:
        //   withChildren:
        //     Clear all child Particle Systems as well.
        public void Clear();
        //
        // 摘要:
        //     Remove all particles in the Particle System.
        //
        // 参数:
        //   withChildren:
        //     Clear all child Particle Systems as well.
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::Clear", HasExplicitThis = true)]
        public void Clear([Internal.DefaultValue("true")] bool withChildren);
        //
        // 参数:
        //   position:
        //
        //   velocity:
        //
        //   size:
        //
        //   lifetime:
        //
        //   color:
        [Obsolete("Emit with specific parameters is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", false)]
        public void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color);
        [Obsolete("Emit with a single particle structure is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", false)]
        public void Emit(Particle particle);
        [NativeNameAttribute("SyncJobs()->EmitParticlesExternal")]
        public void Emit(EmitParams emitParams, int count);
        //
        // 摘要:
        //     Emit count particles immediately.
        //
        // 参数:
        //   count:
        //     Number of particles to emit.
        [RequiredByNativeCodeAttribute]
        public void Emit(int count);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::GetCustomParticleData", HasExplicitThis = true, ThrowsException = true)]
        public int GetCustomParticleData([NotNullAttribute("ArgumentNullException")] List<Vector4> customData, ParticleSystemCustomData streamIndex);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::GetParticles", HasExplicitThis = true, ThrowsException = true)]
        public int GetParticles([NotNullAttribute("ArgumentNullException")] Particle[] particles, int size, int offset);
        public int GetParticles(Particle[] particles, int size);
        public int GetParticles(NativeArray<Particle> particles);
        public int GetParticles(NativeArray<Particle> particles, int size);
        public int GetParticles(NativeArray<Particle> particles, int size, int offset);
        public int GetParticles(Particle[] particles);
        //
        // 摘要:
        //     Returns all the data that relates to the current internal state of the Particle
        //     System.
        //
        // 返回结果:
        //     The current internal state of the Particle System.
        public PlaybackState GetPlaybackState();
        //
        // 摘要:
        //     Returns all the data relating to the current internal state of the Particle System
        //     Trails.
        //
        // 返回结果:
        //     The variable to populate with the Trails that currently belong to the Particle
        //     System..
        public Trails GetTrails();
        public int GetTrails(ref Trails trailData);
        //
        // 摘要:
        //     Does the Particle System contain any live particles, or will it produce more?
        //
        // 参数:
        //   withChildren:
        //     Check all child Particle Systems as well.
        //
        // 返回结果:
        //     True if the Particle System contains live particles or is still creating new
        //     particles. False if the Particle System has stopped emitting particles and all
        //     particles are dead.
        public bool IsAlive();
        //
        // 摘要:
        //     Does the Particle System contain any live particles, or will it produce more?
        //
        // 参数:
        //   withChildren:
        //     Check all child Particle Systems as well.
        //
        // 返回结果:
        //     True if the Particle System contains live particles or is still creating new
        //     particles. False if the Particle System has stopped emitting particles and all
        //     particles are dead.
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::IsAlive", HasExplicitThis = true)]
        public bool IsAlive([Internal.DefaultValue("true")] bool withChildren);
        //
        // 摘要:
        //     Pauses the system so no new particles are emitted and the existing particles
        //     are not updated.
        //
        // 参数:
        //   withChildren:
        //     Pause all child Particle Systems as well.
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::Pause", HasExplicitThis = true)]
        public void Pause([Internal.DefaultValue("true")] bool withChildren);
        //
        // 摘要:
        //     Pauses the system so no new particles are emitted and the existing particles
        //     are not updated.
        //
        // 参数:
        //   withChildren:
        //     Pause all child Particle Systems as well.
        public void Pause();
        //
        // 摘要:
        //     Starts the Particle System.
        //
        // 参数:
        //   withChildren:
        //     Play all child Particle Systems as well.
        public void Play();
        //
        // 摘要:
        //     Starts the Particle System.
        //
        // 参数:
        //   withChildren:
        //     Play all child Particle Systems as well.
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::Play", HasExplicitThis = true)]
        public void Play([Internal.DefaultValue("true")] bool withChildren);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::SetCustomParticleData", HasExplicitThis = true, ThrowsException = true)]
        public void SetCustomParticleData([NotNullAttribute("ArgumentNullException")] List<Vector4> customData, ParticleSystemCustomData streamIndex);
        public void SetParticles(NativeArray<Particle> particles);
        public void SetParticles(NativeArray<Particle> particles, int size);
        public void SetParticles(Particle[] particles);
        public void SetParticles(Particle[] particles, int size);
        public void SetParticles(NativeArray<Particle> particles, int size, int offset);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::SetParticles", HasExplicitThis = true, ThrowsException = true)]
        public void SetParticles(Particle[] particles, int size, int offset);
        public void SetPlaybackState(PlaybackState playbackState);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::SetTrailData", HasExplicitThis = true)]
        public void SetTrails(Trails trailData);
        //
        // 摘要:
        //     Fast-forwards the Particle System by simulating particles over the given period
        //     of time, then pauses it.
        //
        // 参数:
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
        public void Simulate(float t, [Internal.DefaultValue("true")] bool withChildren, [Internal.DefaultValue("true")] bool restart);
        //
        // 摘要:
        //     Fast-forwards the Particle System by simulating particles over the given period
        //     of time, then pauses it.
        //
        // 参数:
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
        public void Simulate(float t, [Internal.DefaultValue("true")] bool withChildren);
        //
        // 摘要:
        //     Fast-forwards the Particle System by simulating particles over the given period
        //     of time, then pauses it.
        //
        // 参数:
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
        public void Simulate(float t);
        //
        // 摘要:
        //     Fast-forwards the Particle System by simulating particles over the given period
        //     of time, then pauses it.
        //
        // 参数:
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
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::Simulate", HasExplicitThis = true)]
        public void Simulate(float t, [Internal.DefaultValue("true")] bool withChildren, [Internal.DefaultValue("true")] bool restart, [Internal.DefaultValue("true")] bool fixedTimeStep);
        //
        // 摘要:
        //     Stops playing the Particle System using the supplied stop behaviour.
        //
        // 参数:
        //   withChildren:
        //     Stop all child Particle Systems as well.
        //
        //   stopBehavior:
        //     Stop emitting or stop emitting and clear the system.
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::Stop", HasExplicitThis = true)]
        public void Stop([Internal.DefaultValue("true")] bool withChildren, [Internal.DefaultValue("ParticleSystemStopBehavior.StopEmitting")] ParticleSystemStopBehavior stopBehavior);
        //
        // 摘要:
        //     Stops playing the Particle System using the supplied stop behaviour.
        //
        // 参数:
        //   withChildren:
        //     Stop all child Particle Systems as well.
        //
        //   stopBehavior:
        //     Stop emitting or stop emitting and clear the system.
        public void Stop([Internal.DefaultValue("true")] bool withChildren);
        //
        // 摘要:
        //     Stops playing the Particle System using the supplied stop behaviour.
        //
        // 参数:
        //   withChildren:
        //     Stop all child Particle Systems as well.
        //
        //   stopBehavior:
        //     Stop emitting or stop emitting and clear the system.
        public void Stop();
        public void TriggerSubEmitter(int subEmitterIndex, ref Particle particle);
        [FreeFunctionAttribute(Name = "ParticleSystemScriptBindings::TriggerSubEmitter", HasExplicitThis = true)]
        public void TriggerSubEmitter(int subEmitterIndex, List<Particle> particles);
        //
        // 摘要:
        //     Triggers the specified sub emitter on all particles of the Particle System.
        //
        // 参数:
        //   subEmitterIndex:
        //     Index of the sub emitter to trigger.
        public void TriggerSubEmitter(int subEmitterIndex);

        //
        // 摘要:
        //     Script interface for the Limit Velocity Over Lifetime module.
        public struct LimitVelocityOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the LimitForceOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Maximum velocity curve for the x-axis.
            public MinMaxCurve limitX { get; set; }
            //
            // 摘要:
            //     Change the limit multiplier on the x-axis.
            public float limitXMultiplier { get; set; }
            //
            // 摘要:
            //     Maximum velocity curve for the y-axis.
            public MinMaxCurve limitY { get; set; }
            //
            // 摘要:
            //     Change the limit multiplier on the y-axis.
            public float limitYMultiplier { get; set; }
            //
            // 摘要:
            //     Maximum velocity curve for the z-axis.
            public MinMaxCurve limitZ { get; set; }
            //
            // 摘要:
            //     Change the limit multiplier on the z-axis.
            public float limitZMultiplier { get; set; }
            //
            // 摘要:
            //     Maximum velocity curve, when not using one curve per axis.
            [NativeNameAttribute("Magnitude")]
            public MinMaxCurve limit { get; set; }
            //
            // 摘要:
            //     Change the limit multiplier.
            [NativeNameAttribute("MagnitudeMultiplier")]
            public float limitMultiplier { get; set; }
            //
            // 摘要:
            //     Controls how much this module dampens particle velocities that exceed the velocity
            //     limit.
            public float dampen { get; set; }
            //
            // 摘要:
            //     Set the velocity limit on each axis separately. This module uses ParticleSystem.LimitVelocityOverLifetimeModule._drag
            //     to dampen a particle's velocity if the velocity exceeds this value.
            public bool separateAxes { get; set; }
            //
            // 摘要:
            //     Specifies if the velocity limits are in local space (rotated with the transform)
            //     or world space.
            public ParticleSystemSimulationSpace space { get; set; }
            //
            // 摘要:
            //     Controls the amount of drag that this modules applies to the particle velocities.
            public MinMaxCurve drag { get; set; }
            //
            // 摘要:
            //     Specifies the drag multiplier.
            public float dragMultiplier { get; set; }
            //
            // 摘要:
            //     Adjust the amount of drag this module applies to particles, based on their sizes.
            public bool multiplyDragByParticleSize { get; set; }
            //
            // 摘要:
            //     Adjust the amount of drag this module applies to particles, based on their speeds.
            public bool multiplyDragByParticleVelocity { get; set; }
        }
        //
        // 摘要:
        //     The Inherit Velocity Module controls how the velocity of the emitter is transferred
        //     to the particles as they are emitted.
        public struct InheritVelocityModule
        {
            //
            // 摘要:
            //     Specifies whether the InheritVelocityModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Specifies how to apply emitter velocity to particles.
            public ParticleSystemInheritVelocityMode mode { get; set; }
            //
            // 摘要:
            //     Curve to define how much of the emitter velocity the system applies during the
            //     lifetime of a particle.
            public MinMaxCurve curve { get; set; }
            //
            // 摘要:
            //     Change the curve multiplier.
            public float curveMultiplier { get; set; }
        }
        //
        // 摘要:
        //     The Lifetime By Emitter Speed Module controls the initial lifetime of each particle
        //     based on the speed of the emitter when the particle was spawned.
        public struct LifetimeByEmitterSpeedModule
        {
            //
            // 摘要:
            //     Use this property to enable or disable the LifetimeByEmitterSpeed module.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Use this curve to define which value to multiply the start lifetime of a particle
            //     with, based on the speed of the emitter when the particle is spawned.
            public MinMaxCurve curve { get; set; }
            //
            // 摘要:
            //     Use this property to change the curve multiplier.
            public float curveMultiplier { get; set; }
            //
            // 摘要:
            //     Control the start lifetime multiplier between these minimum and maximum speeds
            //     of the emitter.
            public Vector2 range { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the ForceOverLifetimeModule of a Particle System.
        public struct ForceOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the ForceOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The curve that defines particle forces in the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     The curve defining particle forces in the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     The curve defining particle forces in the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Defines the x-axis multiplier.
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Defines the y-axis multiplier.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     Defines the z-axis multiplier.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     Specifies whether the modules applies the forces in local or world space.
            public ParticleSystemSimulationSpace space { get; set; }
            //
            // 摘要:
            //     When randomly selecting values between two curves or constants, this flag causes
            //     the system to choose a new random force on each frame.
            public bool randomized { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the ColorOverLifetimeModule of a Particle System.
        public struct ColorOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the ColorOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The gradient that controls the particle colors.
            public MinMaxGradient color { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the ColorBySpeedModule of a Particle System.
        public struct ColorBySpeedModule
        {
            //
            // 摘要:
            //     Specifies whether the ColorBySpeedModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The gradient that controls the particle colors.
            public MinMaxGradient color { get; set; }
            //
            // 摘要:
            //     Apply the color gradient between these minimum and maximum speeds.
            public Vector2 range { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the SizeOverLifetimeModule.
        public struct SizeOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the SizeOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Curve to control particle size based on lifetime.
            [NativeNameAttribute("X")]
            public MinMaxCurve size { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.SizeOverLifetimeModule._size.
            [NativeNameAttribute("XMultiplier")]
            public float sizeMultiplier { get; set; }
            //
            // 摘要:
            //     Size over lifetime curve for the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     Size multiplier along the x-axis.
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Size over lifetime curve for the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     Size multiplier along the y-axis.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     Size over lifetime curve for the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Size multiplier along the z-axis.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     Set the size over lifetime on each axis separately.
            public bool separateAxes { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the SizeBySpeedModule.
        public struct SizeBySpeedModule
        {
            //
            // 摘要:
            //     Specifies whether the SizeBySpeedModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Curve to control particle size based on speed.
            [NativeNameAttribute("X")]
            public MinMaxCurve size { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.SizeBySpeedModule._size.
            [NativeNameAttribute("XMultiplier")]
            public float sizeMultiplier { get; set; }
            //
            // 摘要:
            //     Size by speed curve for the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     Size multiplier along the x-axis.
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Size by speed curve for the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     Size multiplier along the y-axis.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     Size by speed curve for the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Size multiplier along the z-axis.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     Set the size by speed on each axis separately.
            public bool separateAxes { get; set; }
            //
            // 摘要:
            //     Set the minimum and maximum speed that this modules applies the size curve between.
            public Vector2 range { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the RotationOverLifetimeModule.
        public struct RotationOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the RotationOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Rotation over lifetime curve for the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     Rotation multiplier around the x-axis.
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Rotation over lifetime curve for the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     Rotation multiplier around the y-axis.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     Rotation over lifetime curve for the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Rotation multiplier around the z-axis.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     Set the rotation over lifetime on each axis separately.
            public bool separateAxes { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the RotationBySpeedModule.
        public struct RotationBySpeedModule
        {
            //
            // 摘要:
            //     ESpecifies whether the RotationBySpeedModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Rotation by speed curve for the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the x-axis.
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Rotation by speed curve for the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the y-axis.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     Rotation by speed curve for the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the z-axis.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     Set the rotation by speed on each axis separately.
            public bool separateAxes { get; set; }
            //
            // 摘要:
            //     Set the minimum and maximum speeds that this module applies the rotation curve
            //     between.
            public Vector2 range { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the ExternalForcesModule of a Particle System.
        public struct ExternalForcesModule
        {
            //
            // 摘要:
            //     Specifies whether the ExternalForcesModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Multiplies the magnitude of external forces affecting the particles.
            public float multiplier { get; set; }
            //
            // 摘要:
            //     Multiplies the magnitude of applied external forces.
            public MinMaxCurve multiplierCurve { get; set; }
            //
            // 摘要:
            //     Apply all Force Fields belonging to a matching Layer to this Particle System.
            public ParticleSystemGameObjectFilter influenceFilter { get; set; }
            //
            // 摘要:
            //     Particle System Force Field Components with a matching Layer affect this Particle
            //     System.
            public LayerMask influenceMask { get; set; }
            //
            // 摘要:
            //     The number of Force Fields explicitly provided to the influencers list.
            [NativeThrowsAttribute]
            public int influenceCount { get; }

            //
            // 摘要:
            //     Adds a ParticleSystemForceField to the influencers list.
            //
            // 参数:
            //   field:
            //     The Force Field to add to the influencers list.
            [NativeThrowsAttribute]
            public void AddInfluence([NotNullAttribute("ArgumentNullException")] ParticleSystemForceField field);
            //
            // 摘要:
            //     Gets the ParticleSystemForceField at the given index in the influencers list.
            //
            // 参数:
            //   index:
            //     The index to return the chosen Force Field from.
            //
            // 返回结果:
            //     The ForceField from the list.
            [NativeThrowsAttribute]
            public ParticleSystemForceField GetInfluence(int index);
            //
            // 摘要:
            //     Determines whether any particles are inside the influence of a Force Field.
            //
            // 参数:
            //   field:
            //     The Force Field to test.
            //
            // 返回结果:
            //     Whether the Force Field affects the Particle System.
            public bool IsAffectedBy(ParticleSystemForceField field);
            //
            // 摘要:
            //     Removes every Force Field from the influencers list.
            [NativeThrowsAttribute]
            public void RemoveAllInfluences();
            //
            // 摘要:
            //     Removes the Force Field from the influencers list at the given index.
            //
            // 参数:
            //   index:
            //     The index to remove the chosen Force Field from.
            //
            //   field:
            //     The Force Field to remove from the list.
            public void RemoveInfluence(int index);
            //
            // 摘要:
            //     Removes the Force Field from the influencers list at the given index.
            //
            // 参数:
            //   index:
            //     The index to remove the chosen Force Field from.
            //
            //   field:
            //     The Force Field to remove from the list.
            [NativeThrowsAttribute]
            public void RemoveInfluence([NotNullAttribute("ArgumentNullException")] ParticleSystemForceField field);
            //
            // 摘要:
            //     Assigns the Force Field at the given index in the influencers list.
            //
            // 参数:
            //   index:
            //     Index to assign the Force Field.
            //
            //   field:
            //     Force Field that to assign.
            [NativeThrowsAttribute]
            public void SetInfluence(int index, [NotNullAttribute("ArgumentNullException")] ParticleSystemForceField field);
        }
        //
        // 摘要:
        //     Script interface for the NoiseModule.
        public struct NoiseModule
        {
            //
            // 摘要:
            //     Specifies whether the the NoiseModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     How much the noise affects the particle positions.
            public MinMaxCurve positionAmount { get; set; }
            //
            // 摘要:
            //     z-axis remap multiplier.
            public float remapZMultiplier { get; set; }
            //
            // 摘要:
            //     Define how the noise values are remapped on the z-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve remapZ { get; set; }
            //
            // 摘要:
            //     y-axis remap multiplier.
            public float remapYMultiplier { get; set; }
            //
            // 摘要:
            //     Define how the noise values are remapped on the y-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve remapY { get; set; }
            //
            // 摘要:
            //     x-axis remap multiplier.
            public float remapXMultiplier { get; set; }
            //
            // 摘要:
            //     Define how the noise values are remapped on the x-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve remapX { get; set; }
            //
            // 摘要:
            //     Remap multiplier.
            [NativeNameAttribute("RemapXMultiplier")]
            public float remapMultiplier { get; set; }
            //
            // 摘要:
            //     Define how the noise values are remapped.
            [NativeNameAttribute("RemapX")]
            public MinMaxCurve remap { get; set; }
            //
            // 摘要:
            //     Enable remapping of the final noise values, allowing for noise values to be translated
            //     into different values.
            public bool remapEnabled { get; set; }
            //
            // 摘要:
            //     Scroll speed multiplier.
            public float scrollSpeedMultiplier { get; set; }
            //
            // 摘要:
            //     Scroll the noise map over the Particle System.
            public MinMaxCurve scrollSpeed { get; set; }
            //
            // 摘要:
            //     Generate 1D, 2D or 3D noise.
            public ParticleSystemNoiseQuality quality { get; set; }
            //
            // 摘要:
            //     When combining each octave, zoom in by this amount.
            public float octaveScale { get; set; }
            //
            // 摘要:
            //     When combining each octave, scale the intensity by this amount.
            public float octaveMultiplier { get; set; }
            //
            // 摘要:
            //     Layers of noise that combine to produce final noise.
            public int octaveCount { get; set; }
            //
            // 摘要:
            //     Higher frequency noise reduces the strength by a proportional amount, if enabled.
            public bool damping { get; set; }
            //
            // 摘要:
            //     Low values create soft, smooth noise, and high values create rapidly changing
            //     noise.
            public float frequency { get; set; }
            //
            // 摘要:
            //     z-axis strength multiplier.
            public float strengthZMultiplier { get; set; }
            //
            // 摘要:
            //     Define the strength of the effect on the z-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve strengthZ { get; set; }
            //
            // 摘要:
            //     y-axis strength multiplier.
            public float strengthYMultiplier { get; set; }
            //
            // 摘要:
            //     Define the strength of the effect on the y-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve strengthY { get; set; }
            //
            // 摘要:
            //     x-axis strength multiplier.
            public float strengthXMultiplier { get; set; }
            //
            // 摘要:
            //     Define the strength of the effect on the x-axis, when using the ParticleSystem.NoiseModule.separateAxes
            //     option.
            public MinMaxCurve strengthX { get; set; }
            //
            // 摘要:
            //     Strength multiplier.
            [NativeNameAttribute("StrengthXMultiplier")]
            public float strengthMultiplier { get; set; }
            //
            // 摘要:
            //     How strong the overall noise effect is.
            [NativeNameAttribute("StrengthX")]
            public MinMaxCurve strength { get; set; }
            //
            // 摘要:
            //     Control the noise separately for each axis.
            public bool separateAxes { get; set; }
            //
            // 摘要:
            //     How much the noise affects the particle rotation, in degrees per second.
            public MinMaxCurve rotationAmount { get; set; }
            //
            // 摘要:
            //     How much the noise affects the particle sizes, applied as a multiplier on the
            //     size of each particle.
            public MinMaxCurve sizeAmount { get; set; }
        }
        //
        // 摘要:
        //     Access the ParticleSystem Lights Module.
        public struct LightsModule
        {
            //
            // 摘要:
            //     Specifies whether the LightsModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Choose what proportion of particles receive a dynamic light.
            public float ratio { get; set; }
            //
            // 摘要:
            //     Randomly assign Lights to new particles based on ParticleSystem.LightsModule.ratio.
            public bool useRandomDistribution { get; set; }
            //
            // 摘要:
            //     Select what Light Prefab you want to base your particle lights on.
            public Light light { get; set; }
            //
            // 摘要:
            //     Toggle whether the particle lights multiply their color by the particle color.
            public bool useParticleColor { get; set; }
            //
            // 摘要:
            //     Toggle whether the system multiplies the particle size by the light range to
            //     determine the final light range.
            public bool sizeAffectsRange { get; set; }
            //
            // 摘要:
            //     Toggle whether the system multiplies the particle alpha by the light intensity
            //     when it computes the final light intensity.
            public bool alphaAffectsIntensity { get; set; }
            //
            // 摘要:
            //     Define a curve to apply custom range scaling to particle Lights.
            public MinMaxCurve range { get; set; }
            //
            // 摘要:
            //     Range multiplier.
            public float rangeMultiplier { get; set; }
            //
            // 摘要:
            //     Define a curve to apply custom intensity scaling to particle Lights.
            public MinMaxCurve intensity { get; set; }
            //
            // 摘要:
            //     Intensity multiplier.
            public float intensityMultiplier { get; set; }
            //
            // 摘要:
            //     Set a limit on how many Lights this Module can create.
            public int maxLights { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the VelocityOverLifetimeModule.
        public struct VelocityOverLifetimeModule
        {
            //
            // 摘要:
            //     Specifies whether the VelocityOverLifetimeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, without affecting the direction
            //     of the particles.
            public MinMaxCurve speedModifier { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._radial.
            public float radialMultiplier { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, away from a center position.
            public MinMaxCurve radial { get; set; }
            //
            // 摘要:
            //     A multiplier for _orbitalOffsetY.
            public float orbitalOffsetZMultiplier { get; set; }
            //
            // 摘要:
            //     A multiplier for _orbitalOffsetY.
            public float orbitalOffsetYMultiplier { get; set; }
            //
            // 摘要:
            //     A multiplier for _orbitalOffsetX.
            public float orbitalOffsetXMultiplier { get; set; }
            //
            // 摘要:
            //     Specify a custom center of rotation for the orbital and radial velocities.
            public MinMaxCurve orbitalOffsetZ { get; set; }
            //
            // 摘要:
            //     Specify a custom center of rotation for the orbital and radial velocities.
            public MinMaxCurve orbitalOffsetY { get; set; }
            //
            // 摘要:
            //     Specify a custom center of rotation for the orbital and radial velocities.
            public MinMaxCurve orbitalOffsetX { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the z-axis.
            public float orbitalZMultiplier { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the y-axis.
            public float orbitalYMultiplier { get; set; }
            //
            // 摘要:
            //     Speed multiplier along the x-axis.
            public float orbitalXMultiplier { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, around the z-axis.
            public MinMaxCurve orbitalZ { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, around the y-axis.
            public MinMaxCurve orbitalY { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, around the x-axis.
            public MinMaxCurve orbitalX { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._z.
            public float zMultiplier { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._y.
            public float yMultiplier { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._x
            public float xMultiplier { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, on the z-axis.
            public MinMaxCurve z { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, on the y-axis.
            public MinMaxCurve y { get; set; }
            //
            // 摘要:
            //     Curve to control particle speed based on lifetime, on the x-axis.
            public MinMaxCurve x { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.VelocityOverLifetimeModule._speedModifier.
            public float speedModifierMultiplier { get; set; }
            //
            // 摘要:
            //     Specifies if the velocities are in local space (rotated with the transform) or
            //     world space.
            public ParticleSystemSimulationSpace space { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the TrailsModule.
        public struct TrailModule
        {
            //
            // 摘要:
            //     Specifies whether the TrailModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Apply a shadow bias to prevent self-shadowing artifacts. The specified value
            //     is the proportion of the trail width at each segment.
            public float shadowBias { get; set; }
            //
            // 摘要:
            //     Select how many lines to create through the Particle System.
            public int ribbonCount { get; set; }
            //
            // 摘要:
            //     Configures the trails to generate Normals and Tangents. With this data, Scene
            //     lighting can affect the trails via Normal Maps and the Unity Standard Shader,
            //     or your own custom-built Shaders.
            public bool generateLightingData { get; set; }
            //
            // 摘要:
            //     The gradient that controls the trail colors over the length of the trail.
            public MinMaxGradient colorOverTrail { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.TrailModule._widthOverTrail.
            public float widthOverTrailMultiplier { get; set; }
            //
            // 摘要:
            //     The curve describing the width of each trail point.
            public MinMaxCurve widthOverTrail { get; set; }
            //
            // 摘要:
            //     The gradient that controls the trail colors during the lifetime of the attached
            //     particle.
            public MinMaxGradient colorOverLifetime { get; set; }
            //
            // 摘要:
            //     Toggle whether the trail inherits the particle color as its starting color.
            public bool inheritParticleColor { get; set; }
            //
            // 摘要:
            //     Specifies whether, if you use this system as a sub-emitter, ribbons connect particles
            //     from each parent particle independently.
            public bool splitSubEmitterRibbons { get; set; }
            //
            // 摘要:
            //     Set whether the particle size acts as a multiplier on top of the trail lifetime.
            public bool sizeAffectsLifetime { get; set; }
            //
            // 摘要:
            //     Specifies whether trails disappear immediately when their owning particle dies.
            //     When false, each trail persists until all its points have naturally expired,
            //     based on its lifetime.
            public bool dieWithParticles { get; set; }
            //
            // 摘要:
            //     Drop new trail points in world space, regardless of Particle System Simulation
            //     Space.
            public bool worldSpace { get; set; }
            //
            // 摘要:
            //     Choose whether the U coordinate of the trail Texture is tiled or stretched.
            public ParticleSystemTrailTextureMode textureMode { get; set; }
            //
            // 摘要:
            //     Set the minimum distance each trail can travel before the system adds a new vertex
            //     to it.
            public float minVertexDistance { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.TrailModule._lifetime.
            public float lifetimeMultiplier { get; set; }
            //
            // 摘要:
            //     The curve describing the trail lifetime, throughout the lifetime of the particle.
            public MinMaxCurve lifetime { get; set; }
            //
            // 摘要:
            //     Choose what proportion of particles receive a trail.
            public float ratio { get; set; }
            //
            // 摘要:
            //     Choose how the system generates the particle trails.
            public ParticleSystemTrailMode mode { get; set; }
            //
            // 摘要:
            //     Set whether the particle size acts as a multiplier on top of the trail width.
            public bool sizeAffectsWidth { get; set; }
            //
            // 摘要:
            //     Adds an extra position to each ribbon, connecting it to the location of the Transform
            //     Component.
            public bool attachRibbonsToTransform { get; set; }
        }
        //
        // 摘要:
        //     Script interface for storing the particle trail data.
        [NativeTypeAttribute(Bindings.CodegenOptions.Custom, "MonoParticleTrails")]
        public struct Trails
        {
            //
            // 摘要:
            //     Reserve memory for the particle trail data.
            public int capacity { get; set; }
        }
        //
        // 摘要:
        //     Script interface for storing the particle playback state.
        public struct PlaybackState
        {
        }
        //
        // 摘要:
        //     Script interface for Particle System emission parameters.
        public struct EmitParams
        {
            //
            // 摘要:
            //     When overriding the position of particles, setting this flag to true allows you
            //     to retain the influence of the shape module.
            public bool applyShapeToPosition { get; set; }
            //
            // 摘要:
            //     Override the initial color of particles this system emits.
            public Color32 startColor { get; set; }
            //
            // 摘要:
            //     Override the 3D angular velocity of particles this system emits.
            public Vector3 angularVelocity3D { get; set; }
            //
            // 摘要:
            //     Override the angular velocity of particles this system emits.
            public float angularVelocity { get; set; }
            //
            // 摘要:
            //     Override the 3D rotation of particles this system emits.
            public Vector3 rotation3D { get; set; }
            //
            // 摘要:
            //     Override the rotation of particles this system emits.
            public float rotation { get; set; }
            //
            // 摘要:
            //     Override the axis of rotation of particles this system emits.
            public Vector3 axisOfRotation { get; set; }
            //
            // 摘要:
            //     Override the initial 3D size of particles this system emits.
            public Vector3 startSize3D { get; set; }
            //
            // 摘要:
            //     Override the initial size of particles this system emits.
            public float startSize { get; set; }
            //
            // 摘要:
            //     Override the lifetime of particles this system emits.
            public float startLifetime { get; set; }
            //
            // 摘要:
            //     Override the velocity of particles this system emits.
            public Vector3 velocity { get; set; }
            //
            // 摘要:
            //     Override the random seed of particles this system emits.
            public uint randomSeed { get; set; }
            //
            // 摘要:
            //     Set the index that specifies which Mesh to emit.
            public int meshIndex { set; }
            //
            // 摘要:
            //     Override all the properties of particles this system emits.
            public Particle particle { get; set; }
            //
            // 摘要:
            //     Override the position of particles this system emits.
            public Vector3 position { get; set; }

            //
            // 摘要:
            //     Reverts angularVelocity and angularVelocity3D back to the values specified in
            //     the Inspector.
            public void ResetAngularVelocity();
            //
            // 摘要:
            //     Revert the axis of rotation back to the value specified in the Inspector.
            public void ResetAxisOfRotation();
            //
            // 摘要:
            //     Revert the Mesh selection back to the default randomized behavior.
            public void ResetMeshIndex();
            //
            // 摘要:
            //     Revert the position back to the value specified in the Inspector.
            public void ResetPosition();
            //
            // 摘要:
            //     Revert the random seed back to the value specified in the Inspector.
            public void ResetRandomSeed();
            //
            // 摘要:
            //     Reverts rotation and rotation3D back to the values specified in the Inspector.
            public void ResetRotation();
            //
            // 摘要:
            //     Revert the initial color back to the value specified in the Inspector.
            public void ResetStartColor();
            //
            // 摘要:
            //     Revert the lifetime back to the value specified in the Inspector.
            public void ResetStartLifetime();
            //
            // 摘要:
            //     Revert the initial size back to the value specified in the Inspector.
            public void ResetStartSize();
            //
            // 摘要:
            //     Revert the velocity back to the value specified in the Inspector.
            public void ResetVelocity();
        }
        //
        // 摘要:
        //     Script interface for a Min-Max Gradient.
        [NativeTypeAttribute(Bindings.CodegenOptions.Custom, "MonoMinMaxGradient", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
        public struct MinMaxGradient
        {
            //
            // 摘要:
            //     A single constant color for the entire gradient.
            //
            // 参数:
            //   color:
            //     Constant color.
            public MinMaxGradient(Color color);
            //
            // 摘要:
            //     Use one gradient when evaluating numbers along this Min-Max Gradient.
            //
            // 参数:
            //   gradient:
            //     A single gradient for evaluating against.
            public MinMaxGradient(Gradient gradient);
            //
            // 摘要:
            //     Randomly select colors based on the interval between the minimum and maximum
            //     constants.
            //
            // 参数:
            //   min:
            //     The constant color describing the minimum colors to be evaluated.
            //
            //   max:
            //     The constant color describing the maximum colors to be evaluated.
            public MinMaxGradient(Color min, Color max);
            //
            // 摘要:
            //     Randomly select colors based on the interval between the minimum and maximum
            //     gradients.
            //
            // 参数:
            //   min:
            //     The gradient describing the minimum colors to be evaluated.
            //
            //   max:
            //     The gradient describing the maximum colors to be evaluated.
            public MinMaxGradient(Gradient min, Gradient max);

            //
            // 摘要:
            //     Set the mode that the Min-Max Gradient uses to evaluate colors.
            public ParticleSystemGradientMode mode { get; set; }
            //
            // 摘要:
            //     Set a gradient for the upper bound.
            public Gradient gradientMax { get; set; }
            //
            // 摘要:
            //     Set a gradient for the lower bound.
            public Gradient gradientMin { get; set; }
            //
            // 摘要:
            //     Set a constant color for the upper bound.
            public Color colorMax { get; set; }
            //
            // 摘要:
            //     Set a constant color for the lower bound.
            public Color colorMin { get; set; }
            //
            // 摘要:
            //     Set a constant color.
            public Color color { get; set; }
            //
            // 摘要:
            //     Set the gradient.
            public Gradient gradient { get; set; }

            //
            // 摘要:
            //     Manually query the gradient to calculate colors based on what mode it is in.
            //
            // 参数:
            //   time:
            //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
            //     the gradient. This is valid when ParticleSystem.MinMaxGradient.mode is set to
            //     ParticleSystemGradientMode.Gradient or ParticleSystemGradientMode.TwoGradients.
            //
            //   lerpFactor:
            //     Blend between the two gradients/colors (Valid when ParticleSystem.MinMaxGradient.mode
            //     is set to ParticleSystemGradientMode.TwoColors or ParticleSystemGradientMode.TwoGradients).
            //
            // 返回结果:
            //     Calculated gradient/color value.
            public Color Evaluate(float time);
            //
            // 摘要:
            //     Manually query the gradient to calculate colors based on what mode it is in.
            //
            // 参数:
            //   time:
            //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
            //     the gradient. This is valid when ParticleSystem.MinMaxGradient.mode is set to
            //     ParticleSystemGradientMode.Gradient or ParticleSystemGradientMode.TwoGradients.
            //
            //   lerpFactor:
            //     Blend between the two gradients/colors (Valid when ParticleSystem.MinMaxGradient.mode
            //     is set to ParticleSystemGradientMode.TwoColors or ParticleSystemGradientMode.TwoGradients).
            //
            // 返回结果:
            //     Calculated gradient/color value.
            public Color Evaluate(float time, float lerpFactor);

            public static implicit operator MinMaxGradient(Color color);
            public static implicit operator MinMaxGradient(Gradient gradient);
        }
        //
        // 摘要:
        //     Script interface for a Burst.
        [NativeTypeAttribute(Bindings.CodegenOptions.Custom, "MonoBurst", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
        public struct Burst
        {
            //
            // 摘要:
            //     Construct a new Burst with a time and count.
            //
            // 参数:
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
            public Burst(float _time, short _count);
            public Burst(float _time, MinMaxCurve _count);
            //
            // 摘要:
            //     Construct a new Burst with a time and count.
            //
            // 参数:
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
            public Burst(float _time, short _minCount, short _maxCount);
            public Burst(float _time, MinMaxCurve _count, int _cycleCount, float _repeatInterval);
            //
            // 摘要:
            //     Construct a new Burst with a time and count.
            //
            // 参数:
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
            public Burst(float _time, short _minCount, short _maxCount, int _cycleCount, float _repeatInterval);

            //
            // 摘要:
            //     The time that each burst occurs.
            public float time { get; set; }
            //
            // 摘要:
            //     Specify the number of particles to emit.
            public MinMaxCurve count { get; set; }
            //
            // 摘要:
            //     The minimum number of particles to emit.
            public short minCount { get; set; }
            //
            // 摘要:
            //     The maximum number of particles to emit.
            public short maxCount { get; set; }
            //
            // 摘要:
            //     Specifies how many times the system should play the burst. Set this to 0 to make
            //     it play indefinitely.
            public int cycleCount { get; set; }
            //
            // 摘要:
            //     How often to repeat the burst, in seconds.
            public float repeatInterval { get; set; }
            //
            // 摘要:
            //     The probability that the system triggers a burst.
            public float probability { get; set; }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ParticleSystem.CollisionEvent has been deprecated. Use ParticleCollisionEvent instead (UnityUpgradable)", true)]
        public struct CollisionEvent
        {
            public Vector3 intersection { get; }
            public Vector3 normal { get; }
            public Vector3 velocity { get; }
            public Component collider { get; }
        }
        //
        // 摘要:
        //     Script interface for a Particle.
        [RequiredByNativeCodeAttribute("particleSystemParticle", Optional = true)]
        public struct Particle
        {
            //
            // 摘要:
            //     The animated velocity of the particle.
            public Vector3 animatedVelocity { get; }
            //
            // 摘要:
            //     The 3D rotation of the particle.
            public Vector3 rotation3D { get; set; }
            //
            // 摘要:
            //     The rotation of the particle.
            public float rotation { get; set; }
            //
            // 摘要:
            //     The initial 3D size of the particle. The current size of the particle is calculated
            //     procedurally based on this value and the active size modules.
            public Vector3 startSize3D { get; set; }
            //
            // 摘要:
            //     The initial size of the particle. The current size of the particle is calculated
            //     procedurally based on this value and the active size modules.
            public float startSize { get; set; }
            //
            // 摘要:
            //     Mesh particles rotate around this axis.
            public Vector3 axisOfRotation { get; set; }
            //
            // 摘要:
            //     The random seed of the particle.
            public uint randomSeed { get; set; }
            //
            // 摘要:
            //     The initial color of the particle. The current color of the particle is calculated
            //     procedurally based on this value and the active color modules.
            public Color32 startColor { get; set; }
            //
            // 摘要:
            //     The starting lifetime of the particle.
            public float startLifetime { get; set; }
            //
            // 摘要:
            //     The remaining lifetime of the particle.
            public float remainingLifetime { get; set; }
            //
            // 摘要:
            //     The total velocity of the particle.
            public Vector3 totalVelocity { get; }
            //
            // 摘要:
            //     The 3D angular velocity of the particle.
            public Vector3 angularVelocity3D { get; set; }
            //
            // 摘要:
            //     The velocity of the particle.
            public Vector3 velocity { get; set; }
            //
            // 摘要:
            //     The position of the particle.
            public Vector3 position { get; set; }
            [Obsolete("color property is deprecated. Use startColor or GetCurrentColor() instead.", false)]
            public Color32 color { get; set; }
            [Obsolete("size property is deprecated. Use startSize or GetCurrentSize() instead.", false)]
            public float size { get; set; }
            //
            // 摘要:
            //     The random value of the particle.
            [Obsolete("randomValue property is deprecated. Use randomSeed instead to control random behavior of particles.", false)]
            public float randomValue { get; set; }
            //
            // 摘要:
            //     The lifetime of the particle.
            [Obsolete("Please use Particle.remainingLifetime instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/Particle.remainingLifetime", false)]
            public float lifetime { get; set; }
            //
            // 摘要:
            //     The angular velocity of the particle.
            public float angularVelocity { get; set; }

            //
            // 摘要:
            //     Calculate the current color of the particle by applying the relevant curves to
            //     its startColor property.
            //
            // 参数:
            //   system:
            //     The Particle System from which this particle was emitted.
            //
            // 返回结果:
            //     Current color.
            public Color32 GetCurrentColor(ParticleSystem system);
            //
            // 摘要:
            //     Calculate the current size of the particle by applying the relevant curves to
            //     its startSize property.
            //
            // 参数:
            //   system:
            //     The Particle System from which this particle was emitted.
            //
            // 返回结果:
            //     Current size.
            public float GetCurrentSize(ParticleSystem system);
            //
            // 摘要:
            //     Calculate the current 3D size of the particle by applying the relevant curves
            //     to its startSize3D property.
            //
            // 参数:
            //   system:
            //     The Particle System from which this particle was emitted.
            //
            // 返回结果:
            //     Current size.
            public Vector3 GetCurrentSize3D(ParticleSystem system);
            //
            // 摘要:
            //     Calculate the Mesh index of the particle, used for choosing which Mesh a particle
            //     is rendered with.
            //
            // 参数:
            //   system:
            //     The Particle System from which this particle was emitted.
            //
            // 返回结果:
            //     The index of the mesh used for rendering the particle.
            public int GetMeshIndex(ParticleSystem system);
            //
            // 摘要:
            //     Sets the Mesh index of the particle, used for choosing which Mesh a particle
            //     is rendered with.
            //
            // 参数:
            //   index:
            //     The Mesh index.
            public void SetMeshIndex(int index);
        }
        //
        // 摘要:
        //     Script interface for the TextureSheetAnimationModule.
        public struct TextureSheetAnimationModule
        {
            //
            // 摘要:
            //     Defines the tiling of the Texture in the x-axis.
            public int numTilesX { get; set; }
            //
            // 摘要:
            //     Choose which UV channels receive Texture animation.
            public UVChannelFlags uvChannelMask { get; set; }
            //
            // 摘要:
            //     Explicitly select which row of the Texture sheet to use. The system uses this
            //     property when ParticleSystem.TextureSheetAnimationModule.rowMode is set to Custom.
            public int rowIndex { get; set; }
            //
            // 摘要:
            //     Specifies how many times the animation loops during the lifetime of the particle.
            public int cycleCount { get; set; }
            //
            // 摘要:
            //     The starting frame multiplier.
            public float startFrameMultiplier { get; set; }
            //
            // 摘要:
            //     Define a random starting frame for the Texture sheet animation.
            public MinMaxCurve startFrame { get; set; }
            //
            // 摘要:
            //     The frame over time mutiplier.
            public float frameOverTimeMultiplier { get; set; }
            //
            // 摘要:
            //     A curve to control which frame of the Texture sheet animation to play.
            public MinMaxCurve frameOverTime { get; set; }
            //
            // 摘要:
            //     Select how particles choose which row of a Texture Sheet Animation to use.
            public ParticleSystemAnimationRowMode rowMode { get; set; }
            //
            // 摘要:
            //     Specifies the animation type.
            public ParticleSystemAnimationType animation { get; set; }
            //
            // 摘要:
            //     Defines the tiling of the texture in the y-axis.
            public int numTilesY { get; set; }
            //
            // 摘要:
            //     Specify how particle speeds are mapped to the animation frames.
            public Vector2 speedRange { get; set; }
            //
            // 摘要:
            //     Control how quickly the animation plays.
            public float fps { get; set; }
            //
            // 摘要:
            //     Select whether the system bases the playback on mapping a curve to the lifetime
            //     of each particle, by using the particle speeds, or if playback simply uses a
            //     constant frames per second.
            public ParticleSystemAnimationTimeMode timeMode { get; set; }
            //
            // 摘要:
            //     Select whether the animated Texture information comes from a grid of frames on
            //     a single Texture, or from a list of Sprite objects.
            public ParticleSystemAnimationMode mode { get; set; }
            //
            // 摘要:
            //     Specifies whether the TextureSheetAnimationModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Use a random row of the Texture sheet for each particle emitted.
            [Obsolete("useRandomRow property is deprecated. Use rowMode instead.", false)]
            public bool useRandomRow { get; set; }
            //
            // 摘要:
            //     Flip the V coordinate on particles, causing them to appear mirrored vertically.
            [Obsolete("flipV property is deprecated. Use ParticleSystemRenderer.flip.y instead.", false)]
            public float flipV { get; set; }
            //
            // 摘要:
            //     Flip the U coordinate on particles, causing them to appear mirrored horizontally.
            [Obsolete("flipU property is deprecated. Use ParticleSystemRenderer.flip.x instead.", false)]
            public float flipU { get; set; }
            //
            // 摘要:
            //     The total number of sprites.
            public int spriteCount { get; }

            //
            // 摘要:
            //     Add a new Sprite.
            //
            // 参数:
            //   sprite:
            //     The Sprite to be added.
            [NativeThrowsAttribute]
            public void AddSprite(Sprite sprite);
            //
            // 摘要:
            //     Get the Sprite at the given index.
            //
            // 参数:
            //   index:
            //     The index of the desired Sprite.
            //
            // 返回结果:
            //     The Sprite being requested.
            [NativeThrowsAttribute]
            public Sprite GetSprite(int index);
            //
            // 摘要:
            //     Remove a Sprite from the given index in the array.
            //
            // 参数:
            //   index:
            //     The index from which to remove a Sprite.
            [NativeThrowsAttribute]
            public void RemoveSprite(int index);
            //
            // 摘要:
            //     Set the Sprite at the given index.
            //
            // 参数:
            //   index:
            //     The index of the Sprite being modified.
            //
            //   sprite:
            //     The Sprite being assigned.
            [NativeThrowsAttribute]
            public void SetSprite(int index, Sprite sprite);
        }
        //
        // 摘要:
        //     Script interface for the SubEmittersModule.
        public struct SubEmittersModule
        {
            //
            // 摘要:
            //     The total number of sub-emitters.
            public int subEmittersCount { get; }
            //
            // 摘要:
            //     Sub-Particle System to spawn on death of the parent system's particles.
            [Obsolete("death1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem death1 { get; set; }
            //
            // 摘要:
            //     Sub-Particle System which spawns at the locations of the death of the particles
            //     from the parent system.
            [Obsolete("death0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem death0 { get; set; }
            //
            // 摘要:
            //     Sub-Particle System which spawns at the locations of the collision of the particles
            //     from the parent system.
            [Obsolete("collision1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem collision1 { get; set; }
            //
            // 摘要:
            //     Sub-Particle System which spawns at the locations of the collision of the particles
            //     from the parent system.
            [Obsolete("collision0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem collision0 { get; set; }
            //
            // 摘要:
            //     Sub-Particle System which spawns at the locations of the birth of the particles
            //     from the parent system.
            [Obsolete("birth1 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem birth1 { get; set; }
            //
            // 摘要:
            //     Sub-Particle System which spawns at the locations of the birth of the particles
            //     from the parent system.
            [Obsolete("birth0 property is deprecated. Use AddSubEmitter, RemoveSubEmitter, SetSubEmitterSystem and GetSubEmitterSystem instead.", false)]
            public ParticleSystem birth0 { get; set; }
            //
            // 摘要:
            //     Specifies whether the SubEmittersModule is enabled or disabled.
            public bool enabled { get; set; }

            //
            // 摘要:
            //     Add a new sub-emitter.
            //
            // 参数:
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
            [NativeThrowsAttribute]
            public void AddSubEmitter(ParticleSystem subEmitter, ParticleSystemSubEmitterType type, ParticleSystemSubEmitterProperties properties, float emitProbability);
            //
            // 摘要:
            //     Add a new sub-emitter.
            //
            // 参数:
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
            public void AddSubEmitter(ParticleSystem subEmitter, ParticleSystemSubEmitterType type, ParticleSystemSubEmitterProperties properties);
            //
            // 摘要:
            //     Gets the probability that the sub-emitter emits particles.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter.
            //
            // 返回结果:
            //     The emission probability for the sub-emitter
            [NativeThrowsAttribute]
            public float GetSubEmitterEmitProbability(int index);
            //
            // 摘要:
            //     Gets the properties of the sub-emitter at the given index.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter.
            //
            // 返回结果:
            //     The properties of the sub-emitter at the index.
            [NativeThrowsAttribute]
            public ParticleSystemSubEmitterProperties GetSubEmitterProperties(int index);
            //
            // 摘要:
            //     Gets the sub-emitter Particle System at the given index.
            //
            // 参数:
            //   index:
            //     The index of the desired sub-emitter.
            //
            // 返回结果:
            //     The sub-emitter at the index.
            [NativeThrowsAttribute]
            public ParticleSystem GetSubEmitterSystem(int index);
            //
            // 摘要:
            //     Gets the type of the sub-emitter at the given index.
            //
            // 参数:
            //   index:
            //     The index of the desired sub-emitter.
            //
            // 返回结果:
            //     The type of sub-emitter at the index.
            [NativeThrowsAttribute]
            public ParticleSystemSubEmitterType GetSubEmitterType(int index);
            //
            // 摘要:
            //     Removes a sub-emitter from the given index in the array.
            //
            // 参数:
            //   subEmitter:
            //     The sub-emitter to remove.
            public void RemoveSubEmitter(ParticleSystem subEmitter);
            //
            // 摘要:
            //     Removes a sub-emitter from the given index in the array.
            //
            // 参数:
            //   index:
            //     The index from which to remove a sub-emitter.
            [NativeThrowsAttribute]
            public void RemoveSubEmitter(int index);
            //
            // 摘要:
            //     Sets the probability that the sub-emitter emits particles.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter you want to modify.
            //
            //   emitProbability:
            //     The probability value.
            [NativeThrowsAttribute]
            public void SetSubEmitterEmitProbability(int index, float emitProbability);
            //
            // 摘要:
            //     Sets the properties of the sub-emitter at the given index.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter you want to modify.
            //
            //   properties:
            //     The new properties to assign to this sub-emitter.
            [NativeThrowsAttribute]
            public void SetSubEmitterProperties(int index, ParticleSystemSubEmitterProperties properties);
            //
            // 摘要:
            //     Sets the Particle System to use as the sub-emitter at the given index.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter you want to modify.
            //
            //   subEmitter:
            //     The Particle System to use as the sub-emitter at the specified index.
            [NativeThrowsAttribute]
            public void SetSubEmitterSystem(int index, ParticleSystem subEmitter);
            //
            // 摘要:
            //     Sets the type of the sub-emitter at the given index.
            //
            // 参数:
            //   index:
            //     The index of the sub-emitter you want to modify.
            //
            //   type:
            //     The new spawning type to assign to this sub-emitter.
            [NativeThrowsAttribute]
            public void SetSubEmitterType(int index, ParticleSystemSubEmitterType type);
        }
        //
        // 摘要:
        //     Script interface for the TriggerModule.
        public struct TriggerModule
        {
            //
            // 摘要:
            //     The maximum number of collision shapes that can be attached to this Particle
            //     System trigger.
            [Obsolete("The maxColliderCount restriction has been removed. Please use colliderCount instead to find out how many colliders there are. (UnityUpgradable) -> UnityEngine.ParticleSystem/TriggerModule.colliderCount", false)]
            public int maxColliderCount { get; }
            //
            // 摘要:
            //     Specifies whether the TriggerModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     Choose what action to perform when particles are inside the trigger volume.
            public ParticleSystemOverlapAction inside { get; set; }
            //
            // 摘要:
            //     Choose what action to perform when particles are outside the trigger volume.
            public ParticleSystemOverlapAction outside { get; set; }
            //
            // 摘要:
            //     Choose what action to perform when particles enter the trigger volume.
            public ParticleSystemOverlapAction enter { get; set; }
            //
            // 摘要:
            //     Choose what action to perform when particles leave the trigger volume.
            public ParticleSystemOverlapAction exit { get; set; }
            //
            // 摘要:
            //     Determines whether collider information is available when calling ParticleSystem::GetTriggerParticles.
            public ParticleSystemColliderQueryMode colliderQueryMode { get; set; }
            //
            // 摘要:
            //     A multiplier Unity applies to the size of each particle before it processes overlaps.
            public float radiusScale { get; set; }
            //
            // 摘要:
            //     Indicates the number of collision shapes attached to this Particle System trigger.
            [NativeThrowsAttribute]
            public int colliderCount { get; }

            //
            // 摘要:
            //     Adds a Collision shape associated with this Particle System trigger.
            //
            // 参数:
            //   transform:
            //     The Collider to associate with this trigger.
            //
            //   collider:
            [NativeThrowsAttribute]
            public void AddCollider(Component collider);
            //
            // 摘要:
            //     Gets a collision shape associated with this Particle System trigger.
            //
            // 参数:
            //   index:
            //     The Collider to return.
            //
            // 返回结果:
            //     The Collider at the given index.
            [NativeThrowsAttribute]
            public Component GetCollider(int index);
            //
            // 摘要:
            //     Removes a collision shape associated with this Particle System trigger.
            //
            // 参数:
            //   index:
            //     The Collider to remove.
            [NativeThrowsAttribute]
            public void RemoveCollider(int index);
            //
            // 摘要:
            //     Removes a collision shape associated with this Particle System trigger.
            //
            // 参数:
            //   collider:
            //     The Collider to remove.
            public void RemoveCollider(Component collider);
            //
            // 摘要:
            //     Sets a Collision shape associated with this Particle System trigger.
            //
            // 参数:
            //   index:
            //     The Collider entry to assign.
            //
            //   collider:
            //     The Collider to associate with this trigger.
            [NativeThrowsAttribute]
            public void SetCollider(int index, Component collider);
        }
        //
        // 摘要:
        //     Script interface for the CollisionMmodule of a Particle System.
        public struct CollisionModule
        {
            //
            // 摘要:
            //     Change the lifetime loss multiplier.
            public float lifetimeLossMultiplier { get; set; }
            //
            // 摘要:
            //     Specifies whether the physics system considers particle sizes when it applies
            //     forces to Colliders.
            public bool multiplyColliderForceByParticleSize { get; set; }
            //
            // 摘要:
            //     Specifies whether the physics system considers particle speeds when it applies
            //     forces to Colliders.
            public bool multiplyColliderForceByParticleSpeed { get; set; }
            //
            // 摘要:
            //     Specifies whether the physics system considers the collision angle when it applies
            //     forces from particles to Colliders.
            public bool multiplyColliderForceByCollisionAngle { get; set; }
            //
            // 摘要:
            //     How much force is applied to a Collider when hit by particles from this Particle
            //     System.
            public float colliderForce { get; set; }
            //
            // 摘要:
            //     Send collision callback messages.
            public bool sendCollisionMessages { get; set; }
            //
            // 摘要:
            //     A multiplier that Unity applies to the size of each particle before collisions
            //     are processed.
            public float radiusScale { get; set; }
            //
            // 摘要:
            //     Size of voxels in the collision cache.
            public float voxelSize { get; set; }
            //
            // 摘要:
            //     Specifies the accuracy of particle collisions against colliders in the Scene.
            public ParticleSystemCollisionQuality quality { get; set; }
            //
            // 摘要:
            //     The maximum number of collision shapes Unity considers for particle collisions.
            //     It ignores excess shapes. Terrains take priority.
            public int maxCollisionShapes { get; set; }
            //
            // 摘要:
            //     Allow particles to collide with dynamic colliders when using world collision
            //     mode.
            public bool enableDynamicColliders { get; set; }
            //
            // 摘要:
            //     Control which Layers this Particle System collides with.
            public LayerMask collidesWith { get; set; }
            //
            // 摘要:
            //     Kill particles whose speed goes above this threshold, after a collision.
            public float maxKillSpeed { get; set; }
            //
            // 摘要:
            //     Kill particles whose speed falls below this threshold, after a collision.
            public float minKillSpeed { get; set; }
            //
            // 摘要:
            //     Allow particles to collide when inside colliders.
            [Obsolete("enableInteriorCollisions property is deprecated and is no longer required and has no effect on the particle system.", false)]
            public bool enableInteriorCollisions { get; set; }
            //
            // 摘要:
            //     How much a collision reduces a particle's lifetime.
            public MinMaxCurve lifetimeLoss { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.CollisionModule._bounce.
            public float bounceMultiplier { get; set; }
            //
            // 摘要:
            //     How much force is applied to each particle after a collision.
            public MinMaxCurve bounce { get; set; }
            //
            // 摘要:
            //     Change the dampen multiplier.
            public float dampenMultiplier { get; set; }
            //
            // 摘要:
            //     How much speed does each particle lose after a collision.
            public MinMaxCurve dampen { get; set; }
            //
            // 摘要:
            //     Choose between 2D and 3D world collisions.
            public ParticleSystemCollisionMode mode { get; set; }
            //
            // 摘要:
            //     The type of particle collision to perform.
            public ParticleSystemCollisionType type { get; set; }
            //
            // 摘要:
            //     Specifies whether the CollisionModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The maximum number of planes it is possible to set as colliders.
            [Obsolete("The maxPlaneCount restriction has been removed. Please use planeCount instead to find out how many planes there are. (UnityUpgradable) -> UnityEngine.ParticleSystem/CollisionModule.planeCount", false)]
            public int maxPlaneCount { get; }
            //
            // 摘要:
            //     Shows the number of planes currently set as Colliders.
            [NativeThrowsAttribute]
            public int planeCount { get; }

            //
            // 摘要:
            //     Adds a collision plane to use with this Particle System.
            //
            // 参数:
            //   transform:
            //     The plane to add.
            [NativeThrowsAttribute]
            public void AddPlane(Transform transform);
            //
            // 摘要:
            //     Get a collision plane associated with this Particle System.
            //
            // 参数:
            //   index:
            //     The plane to return.
            //
            // 返回结果:
            //     The plane.
            [NativeThrowsAttribute]
            public Transform GetPlane(int index);
            //
            // 摘要:
            //     Removes a collision plane associated with this Particle System.
            //
            // 参数:
            //   transform:
            //     The collision plane to remove.
            public void RemovePlane(Transform transform);
            //
            // 摘要:
            //     Removes a collision plane associated with this Particle System.
            //
            // 参数:
            //   index:
            //     The collision plane to remove.
            [NativeThrowsAttribute]
            public void RemovePlane(int index);
            //
            // 摘要:
            //     Set a collision plane to use with this Particle System.
            //
            // 参数:
            //   index:
            //     The plane entry to set.
            //
            //   transform:
            //     The plane to collide particles against.
            [NativeThrowsAttribute]
            public void SetPlane(int index, Transform transform);
        }
        //
        // 摘要:
        //     Script interface for the ShapeModule.
        public struct ShapeModule
        {
            //
            // 摘要:
            //     Scale of the box to emit particles from.
            [Obsolete("Please use scale instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/ShapeModule.scale", false)]
            public Vector3 box { get; set; }
            //
            // 摘要:
            //     Modulate the particle colors with the vertex colors, or the Material color if
            //     no vertex colors exist.
            public bool useMeshColors { get; set; }
            //
            // 摘要:
            //     Move particles away from the surface of the source Mesh.
            public float normalOffset { get; set; }
            //
            // 摘要:
            //     The mode to use to generate particles on a Mesh.
            public ParticleSystemShapeMultiModeValue meshSpawnMode { get; set; }
            //
            // 摘要:
            //     Control the gap between particle emission points across the Mesh.
            public float meshSpawnSpread { get; set; }
            //
            // 摘要:
            //     In animated modes, this determines how quickly the particle emission position
            //     moves across the Mesh.
            public MinMaxCurve meshSpawnSpeed { get; set; }
            //
            // 摘要:
            //     A multiplier of the Mesh spawn speed.
            public float meshSpawnSpeedMultiplier { get; set; }
            //
            // 摘要:
            //     Angle of the circle arc to emit particles from.
            public float arc { get; set; }
            //
            // 摘要:
            //     The mode that Unity uses to generate particles around the arc.
            public ParticleSystemShapeMultiModeValue arcMode { get; set; }
            //
            // 摘要:
            //     Control the gap between particle emission points around the arc.
            public float arcSpread { get; set; }
            //
            // 摘要:
            //     Emit particles from a single Material of a Mesh.
            public int meshMaterialIndex { get; set; }
            //
            // 摘要:
            //     In animated modes, this determines how quickly the particle emission position
            //     moves around the arc.
            public MinMaxCurve arcSpeed { get; set; }
            //
            // 摘要:
            //     The thickness of the Donut shape to emit particles from.
            public float donutRadius { get; set; }
            //
            // 摘要:
            //     Apply an offset to the position from which the system emits particles.
            public Vector3 position { get; set; }
            //
            // 摘要:
            //     Apply a rotation to the shape from which the system emits particles.
            public Vector3 rotation { get; set; }
            //
            // 摘要:
            //     Apply scale to the shape from which the system emits particles.
            public Vector3 scale { get; set; }
            //
            // 摘要:
            //     Specifies a Texture to tint the particle's start colors.
            public Texture2D texture { get; set; }
            //
            // 摘要:
            //     Selects which channel of the Texture to use for discarding particles.
            public ParticleSystemShapeTextureChannel textureClipChannel { get; set; }
            //
            // 摘要:
            //     Discards particles when they spawn on an area of the Texture with a value lower
            //     than this threshold.
            public float textureClipThreshold { get; set; }
            //
            // 摘要:
            //     When enabled, the system applies the RGB channels of the Texture to the particle
            //     color when the particle spawns.
            public bool textureColorAffectsParticles { get; set; }
            //
            // 摘要:
            //     When enabled, the system applies the alpha channel of the Texture to the particle
            //     alpha when the particle spawns.
            public bool textureAlphaAffectsParticles { get; set; }
            //
            // 摘要:
            //     A multiplier of the arc speed of the particle emission shape.
            public float arcSpeedMultiplier { get; set; }
            //
            // 摘要:
            //     Emit particles from a single Material, or the whole Mesh.
            public bool useMeshMaterialIndex { get; set; }
            //
            // 摘要:
            //     SpriteRenderer to emit particles from.
            public SpriteRenderer spriteRenderer { get; set; }
            //
            // 摘要:
            //     Sprite to emit particles from.
            public Sprite sprite { get; set; }
            //
            // 摘要:
            //     Apply a scaling factor to the Mesh that emits the particles.
            [Obsolete("meshScale property is deprecated.Please use scale instead.", false)]
            public float meshScale { get; set; }
            //
            // 摘要:
            //     Randomizes the starting direction of particles.
            [Obsolete("randomDirection property is deprecated. Use randomDirectionAmount instead.", false)]
            public bool randomDirection { get; set; }
            //
            // 摘要:
            //     Specifies whether the ShapeModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The type of shape to emit particles from.
            public ParticleSystemShapeType shapeType { get; set; }
            //
            // 摘要:
            //     Randomizes the starting direction of particles.
            public float randomDirectionAmount { get; set; }
            //
            // 摘要:
            //     Makes particles move in a spherical direction from their starting point.
            public float sphericalDirectionAmount { get; set; }
            //
            // 摘要:
            //     Randomizes the starting position of particles.
            public float randomPositionAmount { get; set; }
            //
            // 摘要:
            //     Align particles based on their initial direction of travel.
            public bool alignToDirection { get; set; }
            //
            // 摘要:
            //     Radius of the shape to emit particles from.
            public float radius { get; set; }
            //
            // 摘要:
            //     The mode to use to generate particles along the radius.
            public ParticleSystemShapeMultiModeValue radiusMode { get; set; }
            //
            // 摘要:
            //     Control the gap between particle emission points along the radius.
            public float radiusSpread { get; set; }
            //
            // 摘要:
            //     In animated modes, this determines how quickly the particle emission position
            //     moves along the radius.
            public MinMaxCurve radiusSpeed { get; set; }
            //
            // 摘要:
            //     A multiplier of the radius speed of the particle emission shape.
            public float radiusSpeedMultiplier { get; set; }
            //
            // 摘要:
            //     Radius thickness of the shape's edge from which to emit particles.
            public float radiusThickness { get; set; }
            //
            // 摘要:
            //     Angle of the cone to emit particles from.
            public float angle { get; set; }
            //
            // 摘要:
            //     Length of the cone to emit particles from.
            public float length { get; set; }
            //
            // 摘要:
            //     Thickness of the box to emit particles from.
            public Vector3 boxThickness { get; set; }
            //
            // 摘要:
            //     Where on the Mesh to emit particles from.
            public ParticleSystemMeshShapeType meshShapeType { get; set; }
            //
            // 摘要:
            //     Mesh to emit particles from.
            public Mesh mesh { get; set; }
            //
            // 摘要:
            //     MeshRenderer to emit particles from.
            public MeshRenderer meshRenderer { get; set; }
            //
            // 摘要:
            //     SkinnedMeshRenderer to emit particles from.
            public SkinnedMeshRenderer skinnedMeshRenderer { get; set; }
            //
            // 摘要:
            //     When enabled, the system takes four neighboring samples from the Texture then
            //     combines them to give the final particle value.
            public bool textureBilinearFiltering { get; set; }
            //
            // 摘要:
            //     When using a Mesh as a source shape type, this option controls which UV channel
            //     on the Mesh to use for reading the source Texture.
            public int textureUVChannel { get; set; }
        }
        //
        // 摘要:
        //     Script interface for the EmissionModule of a Particle System.
        public struct EmissionModule
        {
            //
            // 摘要:
            //     The emission type.
            [Obsolete("ParticleSystemEmissionType no longer does anything. Time and Distance based emission are now both always active.", false)]
            public ParticleSystemEmissionType type { get; set; }
            //
            // 摘要:
            //     The rate at which the system spawns new particles.
            [Obsolete("rate property is deprecated. Use rateOverTime or rateOverDistance instead.", false)]
            public MinMaxCurve rate { get; set; }
            //
            // 摘要:
            //     Change the rate multiplier.
            [Obsolete("rateMultiplier property is deprecated. Use rateOverTimeMultiplier or rateOverDistanceMultiplier instead.", false)]
            public float rateMultiplier { get; set; }
            //
            // 摘要:
            //     Specifies whether the EmissionModule is enabled or disabled.
            public bool enabled { get; set; }
            //
            // 摘要:
            //     The rate at which the emitter spawns new particles over time.
            public MinMaxCurve rateOverTime { get; set; }
            //
            // 摘要:
            //     Change the rate over time multiplier.
            public float rateOverTimeMultiplier { get; set; }
            //
            // 摘要:
            //     The rate at which the emitter spawns new particles over distance.
            public MinMaxCurve rateOverDistance { get; set; }
            //
            // 摘要:
            //     Change the rate over distance multiplier.
            public float rateOverDistanceMultiplier { get; set; }
            //
            // 摘要:
            //     The current number of bursts.
            public int burstCount { get; set; }

            //
            // 摘要:
            //     Gets a single burst from the array of bursts.
            //
            // 参数:
            //   index:
            //     The index of the burst to retrieve.
            //
            // 返回结果:
            //     The burst data at the given index.
            [NativeThrowsAttribute]
            public Burst GetBurst(int index);
            public int GetBursts(Burst[] bursts);
            [NativeThrowsAttribute]
            public void SetBurst(int index, Burst burst);
            public void SetBursts(Burst[] bursts);
            public void SetBursts(Burst[] bursts, int size);
        }
        //
        // 摘要:
        //     Script interface for the MainModule of a Particle System.
        public struct MainModule
        {
            //
            // 摘要:
            //     Cause some particles to spin in the opposite direction.
            [Obsolete("Please use flipRotation instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/MainModule.flipRotation", false)]
            public float randomizeRotationDirection { get; set; }
            //
            // 摘要:
            //     The initial rotation multiplier of particles around the x-axis when the Particle
            //     System first spawns them.
            public float startRotationXMultiplier { get; set; }
            //
            // 摘要:
            //     The initial rotation of particles around the y-axis when the Particle System
            //     first spawns them.
            public MinMaxCurve startRotationY { get; set; }
            //
            // 摘要:
            //     The initial rotation multiplier of particles around the y-axis when the Particle
            //     System first spawns them..
            public float startRotationYMultiplier { get; set; }
            //
            // 摘要:
            //     The initial rotation of particles around the z-axis when the Particle System
            //     first spawns them
            public MinMaxCurve startRotationZ { get; set; }
            //
            // 摘要:
            //     The initial rotation multiplier of particles around the z-axis when the Particle
            //     System first spawns them.
            public float startRotationZMultiplier { get; set; }
            //
            // 摘要:
            //     Makes some particles spin in the opposite direction.
            public float flipRotation { get; set; }
            //
            // 摘要:
            //     The initial color of particles when the Particle System first spawns them.
            public MinMaxGradient startColor { get; set; }
            //
            // 摘要:
            //     A scale that this Particle System applies to gravity, defined by Physics.gravity.
            public MinMaxCurve gravityModifier { get; set; }
            //
            // 摘要:
            //     Change the gravity multiplier.
            public float gravityModifierMultiplier { get; set; }
            //
            // 摘要:
            //     This selects the space in which to simulate particles. It can be either world
            //     or local space.
            public ParticleSystemSimulationSpace simulationSpace { get; set; }
            //
            // 摘要:
            //     Simulate particles relative to a custom transform component.
            public Transform customSimulationSpace { get; set; }
            //
            // 摘要:
            //     Override the default playback speed of the Particle System.
            public float simulationSpeed { get; set; }
            //
            // 摘要:
            //     When true, use the unscaled delta time to simulate the Particle System. Otherwise,
            //     use the scaled delta time.
            public bool useUnscaledTime { get; set; }
            //
            // 摘要:
            //     Control how the Particle System applies its Transform component to the particles
            //     it emits.
            public ParticleSystemScalingMode scalingMode { get; set; }
            //
            // 摘要:
            //     If set to true, the Particle System automatically begins to play on startup.
            public bool playOnAwake { get; set; }
            //
            // 摘要:
            //     The maximum number of particles to emit.
            public int maxParticles { get; set; }
            //
            // 摘要:
            //     Control how the Particle System calculates its velocity, when moving in the world.
            public ParticleSystemEmitterVelocityMode emitterVelocityMode { get; set; }
            //
            // 摘要:
            //     Select whether to Disable or Destroy the GameObject, or to call the MonoBehaviour.OnParticleSystemStopped
            //     script Callback, when the Particle System stops and all particles have died.
            public ParticleSystemStopAction stopAction { get; set; }
            //
            // 摘要:
            //     Configure the Particle System to not kill its particles when their lifetimes
            //     are exceeded.
            public ParticleSystemRingBufferMode ringBufferMode { get; set; }
            //
            // 摘要:
            //     The initial rotation of particles around the x-axis when emitted.
            public MinMaxCurve startRotationX { get; set; }
            //
            // 摘要:
            //     When ParticleSystem.MainModule.ringBufferMode is set to loop, this value defines
            //     the proportion of the particle life that loops.
            public Vector2 ringBufferLoopRange { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startRotation.
            [NativeNameAttribute("StartRotationZMultiplier")]
            public float startRotationMultiplier { get; set; }
            //
            // 摘要:
            //     A flag to enable 3D particle rotation.
            public bool startRotation3D { get; set; }
            //
            // 摘要:
            //     The current Particle System velocity.
            public Vector3 emitterVelocity { get; set; }
            //
            // 摘要:
            //     The duration of the Particle System in seconds.
            public float duration { get; set; }
            //
            // 摘要:
            //     Specifies whether the Particle System is looping.
            public bool loop { get; set; }
            //
            // 摘要:
            //     If ParticleSystem.MainModule._loop is true, when you enable this property, the
            //     Particle System looks like it has already simulated for one loop when first becoming
            //     visible.
            public bool prewarm { get; set; }
            //
            // 摘要:
            //     Start delay in seconds.
            public MinMaxCurve startDelay { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startDelay in seconds.
            public float startDelayMultiplier { get; set; }
            //
            // 摘要:
            //     The total lifetime in seconds that each new particle has.
            public MinMaxCurve startLifetime { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startLifetime.
            public float startLifetimeMultiplier { get; set; }
            //
            // 摘要:
            //     The initial speed of particles when the Particle System first spawns them.
            public MinMaxCurve startSpeed { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startSpeed.
            public float startSpeedMultiplier { get; set; }
            //
            // 摘要:
            //     A flag to enable specifying particle size individually for each axis.
            public bool startSize3D { get; set; }
            //
            // 摘要:
            //     The initial size of particles when the Particle System first spawns them.
            [NativeNameAttribute("StartSizeX")]
            public MinMaxCurve startSize { get; set; }
            //
            // 摘要:
            //     A multiplier for the initial size of particles when the Particle System first
            //     spawns them.
            [NativeNameAttribute("StartSizeXMultiplier")]
            public float startSizeMultiplier { get; set; }
            //
            // 摘要:
            //     The initial size of particles along the x-axis when the Particle System first
            //     spawns them.
            public MinMaxCurve startSizeX { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startSizeX.
            public float startSizeXMultiplier { get; set; }
            //
            // 摘要:
            //     The initial size of particles along the y-axis when the Particle System first
            //     spawns them.
            public MinMaxCurve startSizeY { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startSizeY.
            public float startSizeYMultiplier { get; set; }
            //
            // 摘要:
            //     The initial size of particles along the z-axis when the Particle System first
            //     spawns them.
            public MinMaxCurve startSizeZ { get; set; }
            //
            // 摘要:
            //     A multiplier for ParticleSystem.MainModule._startSizeZ.
            public float startSizeZMultiplier { get; set; }
            //
            // 摘要:
            //     The initial rotation of particles when the Particle System first spawns them.
            [NativeNameAttribute("StartRotationZ")]
            public MinMaxCurve startRotation { get; set; }
            //
            // 摘要:
            //     Configure whether the Particle System will still be simulated each frame, when
            //     it is offscreen.
            public ParticleSystemCullingMode cullingMode { get; set; }
        }
        //
        // 摘要:
        //     Script interface for a Min-Max Curve.
        [NativeTypeAttribute(Bindings.CodegenOptions.Custom, "MonoMinMaxCurve", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
        public struct MinMaxCurve
        {
            //
            // 摘要:
            //     A single constant value for the entire curve.
            //
            // 参数:
            //   constant:
            //     Constant value.
            public MinMaxCurve(float constant);
            //
            // 摘要:
            //     Use one curve when evaluating numbers along this Min-Max curve.
            //
            // 参数:
            //   scalar:
            //     A multiplier to apply to the curve.
            //
            //   curve:
            //     A single curve to evaluate against.
            //
            //   multiplier:
            public MinMaxCurve(float multiplier, AnimationCurve curve);
            //
            // 摘要:
            //     Randomly select values based on the interval between the minimum and maximum
            //     constants.
            //
            // 参数:
            //   min:
            //     The constant describing the minimum values to be evaluated.
            //
            //   max:
            //     The constant describing the maximum values to be evaluated.
            public MinMaxCurve(float min, float max);
            //
            // 摘要:
            //     Randomly select values based on the interval between the minimum and maximum
            //     curves.
            //
            // 参数:
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
            public MinMaxCurve(float multiplier, AnimationCurve min, AnimationCurve max);

            [Obsolete("Please use MinMaxCurve.curveMultiplier instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/MinMaxCurve.curveMultiplier", false)]
            public float curveScalar { get; set; }
            //
            // 摘要:
            //     Set the mode that the min-max curve uses to evaluate values.
            public ParticleSystemCurveMode mode { get; set; }
            //
            // 摘要:
            //     Set a multiplier to apply to the curves.
            public float curveMultiplier { get; set; }
            //
            // 摘要:
            //     Set a curve for the upper bound.
            public AnimationCurve curveMax { get; set; }
            //
            // 摘要:
            //     Set a curve for the lower bound.
            public AnimationCurve curveMin { get; set; }
            //
            // 摘要:
            //     Set a constant for the upper bound.
            public float constantMax { get; set; }
            //
            // 摘要:
            //     Set a constant for the lower bound.
            public float constantMin { get; set; }
            //
            // 摘要:
            //     Set the constant value.
            public float constant { get; set; }
            //
            // 摘要:
            //     Set the curve.
            public AnimationCurve curve { get; set; }

            //
            // 摘要:
            //     Manually query the curve to calculate values based on what mode it is in.
            //
            // 参数:
            //   time:
            //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
            //     the curve. This is valid when ParticleSystem.MinMaxCurve.mode is set to ParticleSystemCurveMode.Curve
            //     or ParticleSystemCurveMode.TwoCurves.
            //
            //   lerpFactor:
            //     Blend between the two curves/constants (Valid when ParticleSystem.MinMaxCurve.mode
            //     is set to ParticleSystemCurveMode.TwoConstants or ParticleSystemCurveMode.TwoCurves).
            //
            // 返回结果:
            //     Calculated curve/constant value.
            public float Evaluate(float time);
            //
            // 摘要:
            //     Manually query the curve to calculate values based on what mode it is in.
            //
            // 参数:
            //   time:
            //     Normalized time (in the range 0 - 1, where 1 represents 100%) at which to evaluate
            //     the curve. This is valid when ParticleSystem.MinMaxCurve.mode is set to ParticleSystemCurveMode.Curve
            //     or ParticleSystemCurveMode.TwoCurves.
            //
            //   lerpFactor:
            //     Blend between the two curves/constants (Valid when ParticleSystem.MinMaxCurve.mode
            //     is set to ParticleSystemCurveMode.TwoConstants or ParticleSystemCurveMode.TwoCurves).
            //
            // 返回结果:
            //     Calculated curve/constant value.
            public float Evaluate(float time, float lerpFactor);

            public static implicit operator MinMaxCurve(float constant);
        }
        //
        // 摘要:
        //     Script interface for particle Collider data.
        public struct ColliderData
        {
            //
            // 摘要:
            //     Retrieve a specific Collider that a particle iss interacting with.
            //
            // 参数:
            //   particleIndex:
            //     The index of the particle event.
            //
            //   colliderIndex:
            //     The index of the collider to obtain.
            //
            // 返回结果:
            //     The Collider or Collider2D Component that a particle is interacting with.
            public Component GetCollider(int particleIndex, int colliderIndex);
            //
            // 摘要:
            //     Returns how how many Colliders a particle is interacting with.
            //
            // 参数:
            //   particleIndex:
            //     The index of the particle event.
            //
            // 返回结果:
            //     The number of Colliders the particle is interacting with.
            public int GetColliderCount(int particleIndex);
        }
        //
        // 摘要:
        //     Script interface for the CustomDataModule of a Particle System.
        public struct CustomDataModule
        {
            //
            // 摘要:
            //     Specifies whether the CustomDataModule is enabled or disabled.
            public bool enabled { get; set; }

            //
            // 摘要:
            //     Get a ParticleSystem.MinMaxGradient, that is being used to generate custom HDR
            //     color data.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to retrieve the gradient from.
            //
            // 返回结果:
            //     The color gradient being used to generate custom color data.
            [NativeThrowsAttribute]
            public MinMaxGradient GetColor(ParticleSystemCustomData stream);
            //
            // 摘要:
            //     Find out the type of custom data that is being generated for the chosen data
            //     stream.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to query.
            //
            // 返回结果:
            //     The type of data being generated for the requested stream.
            [NativeThrowsAttribute]
            public ParticleSystemCustomDataMode GetMode(ParticleSystemCustomData stream);
            //
            // 摘要:
            //     Get a ParticleSystem.MinMaxCurve, that is being used to generate custom data.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to retrieve the curve from.
            //
            //   component:
            //     The component index to retrieve the curve for (0-3, mapping to the xyzw components
            //     of a Vector4 or float4).
            //
            // 返回结果:
            //     The curve being used to generate custom data.
            [NativeThrowsAttribute]
            public MinMaxCurve GetVector(ParticleSystemCustomData stream, int component);
            //
            // 摘要:
            //     Query how many ParticleSystem.MinMaxCurve elements are being used to generate
            //     this stream of custom data.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to retrieve the curve from.
            //
            // 返回结果:
            //     The number of curves.
            [NativeThrowsAttribute]
            public int GetVectorComponentCount(ParticleSystemCustomData stream);
            [NativeThrowsAttribute]
            public void SetColor(ParticleSystemCustomData stream, MinMaxGradient gradient);
            //
            // 摘要:
            //     Choose the type of custom data to generate for the chosen data stream.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to enable data generation on.
            //
            //   mode:
            //     The type of data to generate.
            [NativeThrowsAttribute]
            public void SetMode(ParticleSystemCustomData stream, ParticleSystemCustomDataMode mode);
            [NativeThrowsAttribute]
            public void SetVector(ParticleSystemCustomData stream, int component, MinMaxCurve curve);
            //
            // 摘要:
            //     Specify how many curves are used to generate custom data for this stream.
            //
            // 参数:
            //   stream:
            //     The name of the custom data stream to apply the curve to.
            //
            //   curveCount:
            //     The number of curves to generate data for.
            //
            //   count:
            [NativeThrowsAttribute]
            public void SetVectorComponentCount(ParticleSystemCustomData stream, int count);
        }
    }
}
