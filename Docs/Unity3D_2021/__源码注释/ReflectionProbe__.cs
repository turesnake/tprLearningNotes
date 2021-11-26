#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        摘要:
        The reflection probe is used to capture the surroundings into a texture which
        is passed to the shaders and used for reflections.

        注意, 本 class 是那个 组件 class;

        本class 中的 变量, 和 inspector 上见到的那些是几乎一致的;

    */
    [NativeHeaderAttribute("Runtime/Camera/ReflectionProbes.h")]
    public sealed class ReflectionProbe : Behaviour//ReflectionProbe__
    {


        public ReflectionProbe();

        
        /*
            摘要:
            Texture which is used outside of all reflection probes (Read Only).

            这就是那个在 inspector: Lighting window 中设置的 "default" environment lighting reflection probe;
            (通常为 skybox)
            
            鉴于 Cubemap 继承于 Texture, 所以此处实际存储的 数据应该是 cubemap
        */
        [StaticAccessorAttribute("GetReflectionProbes()")]
        public static Texture defaultTexture { get; }
        
        
        // 摘要:
        //     "HDR decode values" of the default reflection probe texture. 用于解码
        [StaticAccessorAttribute("GetReflectionProbes()")]
        public static Vector4 defaultTextureHDRDecodeValues { get; }

        /*
            猜测:
                如期字面意思, 就是关于 烘培的 cubemap 分辨率的
        */
        [StaticAccessorAttribute("GetReflectionProbes()")]
        public static int maxBakedCubemapResolution { get; }
        [StaticAccessorAttribute("GetReflectionProbes()")]
        public static int minBakedCubemapResolution { get; }


        /*
            摘要:
            Distance around probe used for blending (used in deferred probes).

            在 延迟渲染中, 反射探针是 逐-frag 计算的, (而不是像 前向渲染中那样, 逐物体计算)
            本变量控制: 本探针是如何与其它探针 blend 的; 本质上,这个值的含义是 探针的混合区域, 
            
            默认为 1;
            若设为 0, 表示彻底不混合, 两个 反射探针之间的过度 就是硬切换;

            catlike rendering 13 - 3.2 中有详细介绍;
            此值在 inspector component 中有显示, 但仅仅在 延迟渲染 中可被编辑;
        */
        public float blendDistance { get; set; }


        
        // 摘要:
        //     Should this reflection probe use box projection?
        public bool boxProjection { get; set; }
        

        /*
            摘要:
            Should reflection probe texture be generated in the Editor (ReflectionProbeMode.Baked)
            or should probe use custom specified texure (ReflectionProbeMode.Custom)?

            -- Backed
            -- Realtime
            -- Custom
        */
        public ReflectionProbeMode mode { get; set; }


        /*
            摘要:
            Reflection probe importance.

            值越大, 越重要; 优先级越高;
            此值还会影响 两个探针之间的 blend;

            若物体同时位于两个 探针区域内, 且一个探针 "更重要", 那么此时物体值接收 "更重要" 的探针的数据;
            当物体渐渐离开这个 "更重要" 探针区域时, 它会逐渐过渡到 "次重要" 探针数据中;
            若两个探针的 importance 值是相同的, 那就当场混合;
        */
        public int importance { get; set; }


        /*
            摘要:
            Sets the way the probe will refresh.
            -- OnAwake
            -- EveryFrame
            -- ViaScripting
        */
        public ReflectionProbeRefreshMode refreshMode { get; set; }


        /*
            摘要:
            Reference to the baked texture of the reflection probe's surrounding. 
            Use this to assign custom reflection texture.
            猜测:
                估计和上面的 mode:Custom 有关;
                在 inspector 中,当选择了 Custom, 确实新增了一个 cubemap 可以被绑定;
        */
        public Texture customBakedTexture { get; set; }


        
        // 摘要:
        //     Reference to the baked texture of the reflection probe's surrounding.
        public Texture bakedTexture { get; set; }


        /*
            摘要:
            The color with which the texture of reflection probe will be cleared.

            Only used if clearFlags are set to CameraClearFlags.SolidColor 
            (or CameraClearFlags.Skybox but the skybox is not set up).
        */
        public Color backgroundColor { get; set; }

        
        // 摘要:
        //     Reference to the realtime texture of the reflection probe's surroundings. Use
        //     this to assign a RenderTexture to use for realtime reflection.
        public RenderTexture realtimeTexture { get; set; }


        /*
            摘要:
            Texture which is passed to the shader of the objects in the vicinity(周围地区) of the reflection probe (Read Only).
            这个 texture 会提供给 反射探针临近地区的 obj 的 shader;

            This texture is meant to represent reflection in a particular direction.
            此 texture 旨在表达 特定方向上的 反射;
        */
        public Texture texture { get; }

        
        // 摘要:
        //     HDR decode values of the reflection probe texture.
        public Vector4 textureHDRDecodeValues { get; }


        /*
            摘要:
            Sets this probe time-slicing mode

            当 ReflectionProbe.refreshMode 被设置为 EveryFrame, 本变量详细定义了具体的 更新方式;

            更新一次 反射探针地 cubemap 是一个大工程, 首先要渲染 cubemap 的每一个面, 然后执行特定的模糊
            以得到 glossy 材质的反射;

            Time-slicing 能让一次更新在数帧内平缓地实现, 以避免出现帧率波动;

            -- AllFacesAtOnce:
                在第一帧更新 cubemap 的每一个面;
                然后在后续 8 帧内完成剩余工作,
                一个周期消耗 9 帧;

            -- IndividualFaces:
                前6帧, 每一帧更新 cubemap 的一个面,
                然后在后续 8 帧内完成剩余工作,
                一个周期消耗 14 帧;

                此方案对帧率的破坏最小, 但是如果环境变化太快, 会露出破绽;

            -- NoTimeSlicing:
                所有更新工作 都在一帧内完成
        */
        public ReflectionProbeTimeSlicingMode timeSlicingMode { get; set; }


        /*
            摘要:
                How the reflection probe clears the background.
                -- Skybox
                -- SolidColor
        */
        public ReflectionProbeClearFlags clearFlags { get; set; }


        /*
            摘要:
            This is used to render parts of the reflecion probe's surrounding selectively.

            "物体的 layerMask" AND "反射探针的 cullingmask", 如果计算结果为0, 
            则这个物体不会被渲染到 反射探针 上去;
        */
        public int cullingMask { get; set; }


        
        // 摘要:
        //     Resolution of the underlying reflection texture in pixels.
        public int resolution { get; set; }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [NativeNameAttribute("ProbeType")]
        [Obsolete("type property has been deprecated. Starting with Unity 5.4, the only supported reflection probe type is Cube.", true)]
        public ReflectionProbeType type { get; set; }
        */


        
        // 摘要:
        //     The size of the box area in which reflections will be applied to the objects.
        //     Measured in the probes's local space.
        [NativeNameAttribute("BoxSize")]
        public Vector3 size { get; set; }


        
        // 摘要:
        //     The near clipping plane distance when rendering the probe.
        [NativeNameAttribute("Near")]
        public float nearClipPlane { get; set; }
        
        // 摘要:
        //     The far clipping plane distance when rendering the probe.
        [NativeNameAttribute("Far")]
        public float farClipPlane { get; set; }


        
        // 摘要:
        //     The center of the box area in which reflections will be applied to the objects.
        //     Measured in the probes's local space.
        [NativeNameAttribute("BoxOffset")]
        public Vector3 center { get; set; }


        
        // 摘要:
        //     The bounding volume of the reflection probe (Read Only).
        [NativeNameAttribute("GlobalAABB")]
        public Bounds bounds { get; }


        /*
            摘要:
            Should this reflection probe use HDR rendering?

            如果选择了 hdr, 反射探针的 值区间 [0,8] 会被封装为 [0,1] 区间,
            那个 multiplier 乘数 则被存储在 alpha 通道中
        */
        [NativeNameAttribute("HDR")]
        public bool hdr { get; set; }


        /*
            摘要:
            Specifies whether Unity should render non-static GameObjects into the Reflection Probe. 

            只有到 反射探针的 Type 被设置为 Custom 时, 此值的设置才会起效;
        */
        [NativeNameAttribute("RenderDynamicObjects")]
        public bool renderDynamicObjects { get; set; }


        
        // 摘要:
        //     Shadow drawing distance when rendering the probe.
        public float shadowDistance { get; set; }


        
        // 摘要:
        //     The "intensity modifier" that is applied to the texture of reflection probe in the shader.
        [NativeNameAttribute("IntensityMultiplier")]
        public float intensity { get; set; }


        /*
            Adds a delegate to get notifications when the default specular Cubemap is changed.
        */
        public static event Action<Cubemap> defaultReflectionSet;


        /*
            Adds a delegate to get notifications when a Reflection Probe is added to a Scene or removed from a Scene.
        */
        public static event Action<ReflectionProbe, ReflectionProbeEvent> reflectionProbeChanged;


        
        // 摘要:
        //     Utility method to blend 2 cubemaps into a target render texture.
        //
        // 参数:
        //   src:
        //     Cubemap to blend from.
        //
        //   dst:
        //     Cubemap to blend to.
        //
        //   blend:
        //     Blend weight.
        //
        //   target:
        //     RenderTexture which will hold the result of the blend.
        //
        // 返回结果:
        //     Returns trues if cubemaps were blended, false otherwise.
        [FreeFunctionAttribute("CubemapGPUBlend")]
        [NativeHeaderAttribute("Runtime/Camera/CubemapGPUUtility.h")]
        public static bool BlendCubemap(Texture src, Texture dst, float blend, RenderTexture target);


        /*
        // 摘要:
        //     Checks if a probe has finished a time-sliced render.
        //
        // 参数:
        //   renderId:
        //     An integer representing the RenderID as returned by the RenderProbe method.
                此值 可通过调用 本类 RenderProbe() 返回
        */
        public bool IsFinishedRendering(int renderId);


        /*
            摘要:
            Refreshes the probe's cubemap.
            
        // 参数:
        //   targetTexture:
        //     Target RendeTexture in which rendering should be done. Specifying null will update
        //     the probe's default texture.
        //
        // 返回结果:
        //     An integer representing a RenderID which can subsequently be used to check if
        //     the probe has finished rendering while rendering in time-slice mode.
        
            int 表示 RenderID 的整数，
            随后可用于在 time-slice 模式中渲染时 检查 是否已完成 反射探针的渲染;
        */
        public int RenderProbe([Internal.DefaultValue("null")] RenderTexture targetTexture);
        public int RenderProbe();



        
        // 摘要:
        //     Revert all ReflectionProbe parameters to default.
        public void Reset();


        
        // 摘要:
        //     Types of events that occur when ReflectionProbe components are used in a Scene.
        public enum ReflectionProbeEvent
        {
            
            // 摘要:
            //     An event that occurs when a Reflection Probe component is added to a Scene or
            //     enabled in a Scene.
            ReflectionProbeAdded = 0,
            
            // 摘要:
            //     An event that occurs when a Reflection Probe component is unloaded from a Scene
            //     or disabled in a Scene.
            ReflectionProbeRemoved = 1
        }
    }
}

