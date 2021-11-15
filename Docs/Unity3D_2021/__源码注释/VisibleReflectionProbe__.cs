#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Holds data of a visible reflection reflectionProbe.

        在 ScriptableRenderContext.Cull() 执行结束后, 会返回一个 CullingResults 实例,
        此实例的 visibleReflectionProbes 成员 是个 array, 它包含一组 本class 实例;

        本类实例 包含了 "ReflectionProbe" (class) 中最常用的一些数据, 
        以及一个指向 ReflectionProbe 实例的引用;

    */
    [UsedByNativeCodeAttribute]
    public struct VisibleReflectionProbe : IEquatable<VisibleReflectionProbe>
    {
        
        /*
            摘要:
            Probe texture.

            cubemap 继承于 Texture, 也能放在这个变量中;
            既然是反射探针, 那么应该是 cubemap
        */
        public Texture texture { get; }
        

        /*
            摘要:
            Accessor to ReflectionProbe component.
            一个引用, 指向那个真正的 反射探针组件
        */
        public ReflectionProbe reflectionProbe { get; }
        

        // 摘要:
        //     Probe bounding box.
        public Bounds bounds { get; set; }
        

        // 摘要:
        //     Probe transformation matrix. OS->WS
        public Matrix4x4 localToWorldMatrix { get; set; }
        

        // 摘要:
        //     Shader data for probe HDR texture decoding.
        public Vector4 hdrData { get; set; }
        

        // 摘要:
        //     Probe projection center.
        public Vector3 center { get; set; }
        

        // 摘要:
        //     Probe blending distance.
        public float blendDistance { get; set; }
        

        // 摘要:
        //     Probe importance.
        public int importance { get; set; }
        

        // 摘要:
        //     Should probe use box projection.
        public bool isBoxProjection { get; set; }
        

        public bool Equals(VisibleReflectionProbe other);
        public override bool Equals(object obj);
        public override int GetHashCode();

        public static bool operator ==(VisibleReflectionProbe left, VisibleReflectionProbe right);
        public static bool operator !=(VisibleReflectionProbe left, VisibleReflectionProbe right);
    }
}

