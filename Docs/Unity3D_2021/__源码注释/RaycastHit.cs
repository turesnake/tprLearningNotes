#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

using System;
using System.ComponentModel;

namespace UnityEngine
{
    /*
        Structure used to get information back from a raycast();
        
    */
    [NativeHeaderAttribute("Runtime/Interfaces/IRaycast.h")]
    [NativeHeaderAttribute("PhysicsScriptingClasses.h")]
    [NativeHeaderAttribute("Modules/Physics/RaycastHit.h")]
    [UsedByNativeCodeAttribute]
    public struct RaycastHit
    {
        //
        // 摘要:
        //     The Collider that was hit.
        public Collider collider { get; }
        //
        // 摘要:
        //     Instance ID of the Collider that was hit.
        public int colliderInstanceID { get; }
        //
        // 摘要:
        //     The impact point in world space where the ray hit the collider.
        public Vector3 point { get; set; }
        //
        // 摘要:
        //     The normal of the surface the ray hit.
        public Vector3 normal { get; set; }
        //
        // 摘要:
        //     The barycentric coordinate of the triangle we hit.
        public Vector3 barycentricCoordinate { get; set; }
        //
        // 摘要:
        //     The distance from the ray's origin to the impact point.
        public float distance { get; set; }
        //
        // 摘要:
        //     The index of the triangle that was hit.
        public int triangleIndex { get; }
        //
        // 摘要:
        //     The uv texture coordinate at the collision location.
        public Vector2 textureCoord { get; }
        //
        // 摘要:
        //     The secondary uv texture coordinate at the impact point.
        public Vector2 textureCoord2 { get; }
        //
        // 摘要:
        //     The Transform of the rigidbody or collider that was hit.
        public Transform transform { get; }
        //
        // 摘要:
        //     The Rigidbody of the collider that was hit. If the collider is not attached to
        //     a rigidbody then it is null.
        public Rigidbody rigidbody { get; }
        //
        // 摘要:
        //     The ArticulationBody of the collider that was hit. If the collider is not attached
        //     to an articulation body then it is null.
        public ArticulationBody articulationBody { get; }
        //
        // 摘要:
        //     The uv lightmap coordinate at the impact point.
        public Vector2 lightmapCoord { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use textureCoord2 instead. (UnityUpgradable) -> textureCoord2")]
        public Vector2 textureCoord1 { get; }
    }
}

