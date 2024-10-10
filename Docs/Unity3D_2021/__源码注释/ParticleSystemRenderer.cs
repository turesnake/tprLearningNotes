#region Assembly UnityEngine.ParticleSystemModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Use this class to render particles on to the screen.
[NativeHeader("Modules/ParticleSystem/ParticleSystemRenderer.h")]
[RequireComponent(typeof(Transform))]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemRendererScriptBindings.h")]
[NativeHeader("ParticleSystemScriptingClasses.h")]
public sealed class ParticleSystemRenderer : Renderer
{
    //
    // Summary:
    //     Control the direction that particles face.
    [NativeName("RenderAlignment")]
    public extern ParticleSystemRenderSpace alignment
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies how the system draws particles.
    public extern ParticleSystemRenderMode renderMode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies how the system randomly assigns meshes to particles.
    public extern ParticleSystemMeshDistribution meshDistribution
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies how to sort particles within a system.
    public extern ParticleSystemSortMode sortMode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     How much are the particles stretched in their direction of motion, defined as
    //     the length of the particle compared to its width.
    public extern float lengthScale
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies how much particles stretch depending on their velocity.
    public extern float velocityScale
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     How much do the particles stretch depending on the Camera's speed.
    public extern float cameraVelocityScale
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Specifies how much a billboard particle orients its normals towards the Camera.
    public extern float normalDirection
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Apply a shadow bias to prevent self-shadowing artifacts. The specified value
    //     is the proportion of the particle size.
    public extern float shadowBias
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Biases Particle System sorting amongst other transparencies.
    public extern float sortingFudge
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Clamp the minimum particle size.
    public extern float minParticleSize
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Clamp the maximum particle size.
    public extern float maxParticleSize
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Modify the pivot point used for rotating particles.
    public Vector3 pivot
    {
        get
        {
            get_pivot_Injected(out var ret);
            return ret;
        }
        set
        {
            set_pivot_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Flip a percentage of the particles, along each axis.
    public Vector3 flip
    {
        get
        {
            get_flip_Injected(out var ret);
            return ret;
        }
        set
        {
            set_flip_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Specifies how the Particle System Renderer interacts with SpriteMask.
    public extern SpriteMaskInteraction maskInteraction
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Set the Material that the TrailModule uses to attach trails to particles.
    public extern Material trailMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal extern Material oldTrailMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Enables GPU Instancing on platforms that support it.
    public extern bool enableGPUInstancing
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Allow billboard particles to roll around their z-axis.
    public extern bool allowRoll
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Enables freeform stretching behavior.
    public extern bool freeformStretching
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Rotate the particles based on the direction they are stretched in. This is added
    //     on top of other particle rotation.
    public extern bool rotateWithStretchDirection
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The Mesh that the particle uses instead of a billboarded Texture.
    public extern Mesh mesh
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetMesh", HasExplicitThis = true)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction(Name = "ParticleSystemRendererScriptBindings::SetMesh", HasExplicitThis = true)]
        set;
    }

    //
    // Summary:
    //     The number of Meshes the system uses for particle rendering.
    public extern int meshCount
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     The number of currently active custom vertex streams.
    public extern int activeVertexStreamsCount
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    internal extern bool editorEnabled
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Determines whether the Particle System can be rendered using GPU Instancing.
    public extern bool supportsMeshInstancing
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Enable a set of vertex Shader streams on the Particle System renderer.
    //
    // Parameters:
    //   streams:
    //     Streams to enable.
    // [Obsolete("EnableVertexStreams is deprecated.Use SetActiveVertexStreams instead.", false)]
    // public void EnableVertexStreams(ParticleSystemVertexStreams streams)
    // {
    //     Internal_SetVertexStreams(streams, enabled: true);
    // }

    //
    // Summary:
    //     Disable a set of vertex Shader streams on the Particle System Renderer. The position
    //     stream is always enabled, and any attempts to remove it are ignored.
    //
    // Parameters:
    //   streams:
    //     Streams to disable.
    // [Obsolete("DisableVertexStreams is deprecated.Use SetActiveVertexStreams instead.", false)]
    // public void DisableVertexStreams(ParticleSystemVertexStreams streams)
    // {
    //     Internal_SetVertexStreams(streams, enabled: false);
    // }

    //
    // Summary:
    //     Query whether the Particle System Renderer uses a particular set of vertex streams.
    //
    //
    // Parameters:
    //   streams:
    //     Streams to query.
    //
    // Returns:
    //     true if the queried streams are enabled. Returns false otherwise.
    // [Obsolete("AreVertexStreamsEnabled is deprecated.Use GetActiveVertexStreams instead.", false)]
    // public bool AreVertexStreamsEnabled(ParticleSystemVertexStreams streams)
    // {
    //     return Internal_GetEnabledVertexStreams(streams) == streams;
    // }

    //
    // Summary:
    //     Queries whether the Particle System renderer uses a particular set of vertex
    //     streams.
    //
    // Parameters:
    //   streams:
    //     Streams to query.
    //
    // Returns:
    //     The subset of the queried streams that are actually enabled.
    // [Obsolete("GetEnabledVertexStreams is deprecated.Use GetActiveVertexStreams instead.", false)]
    // public ParticleSystemVertexStreams GetEnabledVertexStreams(ParticleSystemVertexStreams streams)
    // {
    //     return Internal_GetEnabledVertexStreams(streams);
    // }

    // [Obsolete("Internal_SetVertexStreams is deprecated.Use SetActiveVertexStreams instead.", false)]
    // internal void Internal_SetVertexStreams(ParticleSystemVertexStreams streams, bool enabled)
    // {
    //     List<ParticleSystemVertexStream> list = new List<ParticleSystemVertexStream>(activeVertexStreamsCount);
    //     GetActiveVertexStreams(list);
    //     if (enabled)
    //     {
    //         if ((streams & ParticleSystemVertexStreams.Position) != 0 && !list.Contains(ParticleSystemVertexStream.Position))
    //         {
    //             list.Add(ParticleSystemVertexStream.Position);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Normal) != 0 && !list.Contains(ParticleSystemVertexStream.Normal))
    //         {
    //             list.Add(ParticleSystemVertexStream.Normal);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Tangent) != 0 && !list.Contains(ParticleSystemVertexStream.Tangent))
    //         {
    //             list.Add(ParticleSystemVertexStream.Tangent);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Color) != 0 && !list.Contains(ParticleSystemVertexStream.Color))
    //         {
    //             list.Add(ParticleSystemVertexStream.Color);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.UV) != 0 && !list.Contains(ParticleSystemVertexStream.UV))
    //         {
    //             list.Add(ParticleSystemVertexStream.UV);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.UV2BlendAndFrame) != 0 && !list.Contains(ParticleSystemVertexStream.UV2))
    //         {
    //             list.Add(ParticleSystemVertexStream.UV2);
    //             list.Add(ParticleSystemVertexStream.AnimBlend);
    //             list.Add(ParticleSystemVertexStream.AnimFrame);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.CenterAndVertexID) != 0 && !list.Contains(ParticleSystemVertexStream.Center))
    //         {
    //             list.Add(ParticleSystemVertexStream.Center);
    //             list.Add(ParticleSystemVertexStream.VertexID);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Size) != 0 && !list.Contains(ParticleSystemVertexStream.SizeXYZ))
    //         {
    //             list.Add(ParticleSystemVertexStream.SizeXYZ);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Rotation) != 0 && !list.Contains(ParticleSystemVertexStream.Rotation3D))
    //         {
    //             list.Add(ParticleSystemVertexStream.Rotation3D);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Velocity) != 0 && !list.Contains(ParticleSystemVertexStream.Velocity))
    //         {
    //             list.Add(ParticleSystemVertexStream.Velocity);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Lifetime) != 0 && !list.Contains(ParticleSystemVertexStream.AgePercent))
    //         {
    //             list.Add(ParticleSystemVertexStream.AgePercent);
    //             list.Add(ParticleSystemVertexStream.InvStartLifetime);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Custom1) != 0 && !list.Contains(ParticleSystemVertexStream.Custom1XYZW))
    //         {
    //             list.Add(ParticleSystemVertexStream.Custom1XYZW);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Custom2) != 0 && !list.Contains(ParticleSystemVertexStream.Custom2XYZW))
    //         {
    //             list.Add(ParticleSystemVertexStream.Custom2XYZW);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Random) != 0 && !list.Contains(ParticleSystemVertexStream.StableRandomXYZ))
    //         {
    //             list.Add(ParticleSystemVertexStream.StableRandomXYZ);
    //             list.Add(ParticleSystemVertexStream.VaryingRandomX);
    //         }
    //     }
    //     else
    //     {
    //         if ((streams & ParticleSystemVertexStreams.Position) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Position);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Normal) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Normal);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Tangent) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Tangent);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Color) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Color);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.UV) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.UV);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.UV2BlendAndFrame) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.UV2);
    //             list.Remove(ParticleSystemVertexStream.AnimBlend);
    //             list.Remove(ParticleSystemVertexStream.AnimFrame);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.CenterAndVertexID) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Center);
    //             list.Remove(ParticleSystemVertexStream.VertexID);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Size) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.SizeXYZ);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Rotation) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Rotation3D);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Velocity) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Velocity);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Lifetime) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.AgePercent);
    //             list.Remove(ParticleSystemVertexStream.InvStartLifetime);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Custom1) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Custom1XYZW);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Custom2) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.Custom2XYZW);
    //         }

    //         if ((streams & ParticleSystemVertexStreams.Random) != 0)
    //         {
    //             list.Remove(ParticleSystemVertexStream.StableRandomXYZW);
    //             list.Remove(ParticleSystemVertexStream.VaryingRandomX);
    //         }
    //     }

    //     SetActiveVertexStreams(list);
    // }

    // [Obsolete("Internal_GetVertexStreams is deprecated.Use GetActiveVertexStreams instead.", false)]
    // internal ParticleSystemVertexStreams Internal_GetEnabledVertexStreams(ParticleSystemVertexStreams streams)
    // {
    //     List<ParticleSystemVertexStream> list = new List<ParticleSystemVertexStream>(activeVertexStreamsCount);
    //     GetActiveVertexStreams(list);
    //     ParticleSystemVertexStreams particleSystemVertexStreams = ParticleSystemVertexStreams.None;
    //     if (list.Contains(ParticleSystemVertexStream.Position))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Position;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Normal))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Normal;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Tangent))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Tangent;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Color))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Color;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.UV))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.UV;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.UV2))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.UV2BlendAndFrame;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Center))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.CenterAndVertexID;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.SizeXYZ))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Size;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Rotation3D))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Rotation;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Velocity))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Velocity;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.AgePercent))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Lifetime;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Custom1XYZW))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Custom1;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.Custom2XYZW))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Custom2;
    //     }

    //     if (list.Contains(ParticleSystemVertexStream.StableRandomXYZ))
    //     {
    //         particleSystemVertexStreams |= ParticleSystemVertexStreams.Random;
    //     }

    //     return particleSystemVertexStreams & streams;
    // }

    //
    // Summary:
    //     Gets the array of Meshes to use when selecting particle meshes.
    //
    // Parameters:
    //   meshes:
    //     An array this function populates with the list of Meshes the ParticleSystemRenderer
    //     uses for particle Mesh selection. If the array is smaller than the number of
    //     Meshes, this function cannot populate it with every Mesh. If the array is larger
    //     than the number of Meshes, this function ignores indices greater than the number
    //     of Meshes. Use ParticleSystemRenderer.meshCount to get the number of Meshes the
    //     ParticleSystemRenderer has.
    //
    // Returns:
    //     The number of Meshes this function wrote to the destination array.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [RequiredByNativeCode]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetMeshes", HasExplicitThis = true)]
    public extern int GetMeshes([Out][NotNull("ArgumentNullException")] Mesh[] meshes);

    //
    // Summary:
    //     Sets the Meshes that the ParticleSystemRenderer uses to display particles when
    //     the ParticleSystemRenderer.renderMode is set to ParticleSystemRenderMode.Mesh.
    //
    //
    // Parameters:
    //   meshes:
    //     The array of Meshes to use.
    //
    //   size:
    //     The number of elements from the Mesh array to apply.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::SetMeshes", HasExplicitThis = true)]
    public extern void SetMeshes([NotNull("ArgumentNullException")] Mesh[] meshes, int size);

    //
    // Summary:
    //     Sets the Meshes that the ParticleSystemRenderer uses to display particles when
    //     the ParticleSystemRenderer.renderMode is set to ParticleSystemRenderMode.Mesh.
    //
    //
    // Parameters:
    //   meshes:
    //     The array of Meshes to use.
    //
    //   size:
    //     The number of elements from the Mesh array to apply.
    public void SetMeshes(Mesh[] meshes)
    {
        SetMeshes(meshes, meshes.Length);
    }

    //
    // Summary:
    //     Gets the array of Mesh weightings to use when randomly selecting particle meshes.
    //
    //
    // Parameters:
    //   weightings:
    //     An array this function populates with the list of Mesh weightings the ParticleSystemRenderer
    //     uses for particle Mesh selection. If the array is smaller than the number of
    //     weights, this function cannot populate it with every weight. If the array is
    //     larger than the number of weights, this function ignores indices greater than
    //     the number of weights. Use ParticleSystemRenderer.meshCount to get the number
    //     of Meshes, and thus weights, the ParticleSystemRenderer has.
    //
    // Returns:
    //     The number of weights this function wrote to the destination array.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetMeshWeightings", HasExplicitThis = true)]
    public extern int GetMeshWeightings([Out][NotNull("ArgumentNullException")] float[] weightings);

    //
    // Summary:
    //     Sets the weights that the ParticleSystemRenderer uses to assign Meshes to particles.
    //
    //
    // Parameters:
    //   weightings:
    //     The array of weights to use.
    //
    //   size:
    //     The number of elements from the weighting array to apply.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::SetMeshWeightings", HasExplicitThis = true)]
    public extern void SetMeshWeightings([NotNull("ArgumentNullException")] float[] weightings, int size);

    //
    // Summary:
    //     Sets the weights that the ParticleSystemRenderer uses to assign Meshes to particles.
    //
    //
    // Parameters:
    //   weightings:
    //     The array of weights to use.
    //
    //   size:
    //     The number of elements from the weighting array to apply.
    public void SetMeshWeightings(float[] weightings)
    {
        SetMeshWeightings(weightings, weightings.Length);
    }

    //
    // Summary:
    //     Creates a snapshot of ParticleSystemRenderer and stores it in mesh.
    //
    // Parameters:
    //   mesh:
    //     A static Mesh to receive the snapshot of the particles.
    //
    //   camera:
    //     The Camera used to determine which way camera-space particles face.
    //
    //   useTransform:
    //     Specifies whether to include the rotation and scale of the Transform in the baked
    //     Mesh.
    public void BakeMesh(Mesh mesh, bool useTransform = false)
    {
        BakeMesh(mesh, Camera.main, useTransform);
    }

    //
    // Summary:
    //     Creates a snapshot of ParticleSystemRenderer and stores it in mesh.
    //
    // Parameters:
    //   mesh:
    //     A static Mesh to receive the snapshot of the particles.
    //
    //   camera:
    //     The Camera used to determine which way camera-space particles face.
    //
    //   useTransform:
    //     Specifies whether to include the rotation and scale of the Transform in the baked
    //     Mesh.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void BakeMesh([NotNull("ArgumentNullException")] Mesh mesh, [NotNull("ArgumentNullException")] Camera camera, bool useTransform = false);

    //
    // Summary:
    //     Creates a snapshot of ParticleSystem Trails and stores them in mesh.
    //
    // Parameters:
    //   mesh:
    //     A static Mesh to receive the snapshot of the particle trails.
    //
    //   camera:
    //     The Camera used to determine which way camera-space trails face.
    //
    //   useTransform:
    //     Specifies whether to include the rotation and scale of the Transform in the baked
    //     Mesh.
    public void BakeTrailsMesh(Mesh mesh, bool useTransform = false)
    {
        BakeTrailsMesh(mesh, Camera.main, useTransform);
    }

    //
    // Summary:
    //     Creates a snapshot of ParticleSystem Trails and stores them in mesh.
    //
    // Parameters:
    //   mesh:
    //     A static Mesh to receive the snapshot of the particle trails.
    //
    //   camera:
    //     The Camera used to determine which way camera-space trails face.
    //
    //   useTransform:
    //     Specifies whether to include the rotation and scale of the Transform in the baked
    //     Mesh.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void BakeTrailsMesh([NotNull("ArgumentNullException")] Mesh mesh, [NotNull("ArgumentNullException")] Camera camera, bool useTransform = false);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::SetActiveVertexStreams", HasExplicitThis = true)]
    public extern void SetActiveVertexStreams([NotNull("ArgumentNullException")] List<ParticleSystemVertexStream> streams);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetActiveVertexStreams", HasExplicitThis = true)]
    public extern void GetActiveVertexStreams([NotNull("ArgumentNullException")] List<ParticleSystemVertexStream> streams);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_pivot_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_pivot_Injected(ref Vector3 value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_flip_Injected(out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_flip_Injected(ref Vector3 value);
}

