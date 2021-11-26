
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    
    /*
        摘要:
        Flags used by ScriptableCullingParameters.cullingOptions (一个变量) to configure a culling operation.

        一部分 flags 被 unity 设置成默认值, 另一部分的值 则取决于 camera 的 properties;
        在执行真正的 Cull 操作之前, 你可以手动改写这些 flags;

        cull 的对象主要为三种:
            -- light
            -- 反射探针
            -- shadow caster (物体)

        还有一些 辅助性的 flag, 比如关于:
            -- 是否 cull "非 active camera"
            -- Occlusion Cull
            -- 是否 逐物体 cull

        -----
        catlike 教程中, 通过: camera.TryGetCullingParameters( out ScriptableCullingParameters p ) 
        直接获得的 p.cullingOptions 
        将自动设置:
            OcclusionCull
            NeedsLighting
            NeedsReflectionProbes
            ShadowCasters 
    */
    [Flags]
    public enum CullingOptions//CullingOptions__
    {
        
        // 摘要:
        //     Unset all CullingOptions flags. 关闭本enum 中所有 flags
        None = 0, // 默认关闭
        

        // 摘要:
        //     When set, Unity performs the culling operation even if the Camera is not active.
        ForceEvenIfCameraIsNotActive = 1, // 默认关闭
        

        /*
            摘要:
            When set, Unity performs occlusion culling as part of the culling operation.
            "occlusion culling" 
                就是那个和 frustum culling 平行的技术: 如果一个物体被另一个 静态物体遮挡, 此物体会被 culling;

            默认值: 如果相关 camera 的 Camera.useOcclusionCulling 被设置为 true, 本值开启;
            否则关闭;
        */
        OcclusionCull = 2,

        
        // 摘要:
        //     When set, Unity culls Lights as part of the culling operation.
        NeedsLighting = 4, // 默认开启

        
        // 摘要:
        //     Whenset, Unity culls Reflection Probes as part of the culling operation.
        NeedsReflectionProbes = 8, // 默认开启

        
        /*
            摘要:
            When set, Unity culls both eyes together for stereo rendering.
            默认值: 取决于 相关 camera 的设置;
        */
        Stereo = 16, // VR
        
        /*
            摘要:
            When set, Unity does not perform per-object culling.

            在使用 srp 时, unity 默认会对 light 和 反射探针 执行 per-obj cull;
            这意味着 Unity 在执行 culling 操作时将 "可见光 和 反射探针" 与 "可见的物体" 在其影响区域中配对。

            若不执行 逐物体 culling, 其实也是针对 光 和 弹射探针, 
            如果你的 srp 中不适用 "逐物体-光", 可以开启本 flag, 以节省 cpu 端性能开销;
            ---

            简而言之, 大部分情况下, 都建议关闭本 flag;
        */
        DisablePerObjectCulling = 32, // 默认关闭
        

        /*
            摘要:
            When set, Unity culls shadow casters as part of the culling operation.

            srp 中, 此值默认开启;

            若在 built-in 管线中, 如果 QualitySettings.shadows 被设置为 ShadowQuality.Disable,
            此值会被关闭, 否则, 此值保持开启;

            注意, 在 built-in 管线中, 手动修改此值 不起作用;
        */
        ShadowCasters = 64 // 默认开启
    }
}
