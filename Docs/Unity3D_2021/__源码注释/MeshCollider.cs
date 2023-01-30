
#region 程序集 UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.PhysicsModule.dll
#endregion

using System;
using System.ComponentModel;

namespace UnityEngine
{
    //
    // 摘要:
    //     A mesh collider allows you to do between meshes and primitives.
    [NativeHeaderAttribute("Modules/Physics/MeshCollider.h")]
    [NativeHeaderAttribute("Runtime/Graphics/Mesh/Mesh.h")]
    [RequiredByNativeCodeAttribute]
    public class MeshCollider : Collider
    {
        public MeshCollider();

        //
        // 摘要:
        //     The mesh object used for collision detection.
        public Mesh sharedMesh { get; set; }
        //
        // 摘要:
        //     Use a convex collider from the mesh.
        public bool convex { get; set; }
        //
        // 摘要:
        //     Options used to enable or disable certain features in mesh cooking.
        public MeshColliderCookingOptions cookingOptions { get; set; }
        //
        // 摘要:
        //     Uses interpolated normals for sphere collisions instead of flat polygonal normals.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Configuring smooth sphere collisions is no longer needed.", true)]
        public bool smoothSphereCollisions { get; set; }
        //
        // 摘要:
        //     Used when set to inflateMesh to determine how much inflation is acceptable.
        [Obsolete("MeshCollider.skinWidth is no longer used.")]
        public float skinWidth { get; set; }
        //
        // 摘要:
        //     Allow the physics engine to increase the volume of the input mesh in attempt
        //     to generate a valid convex mesh.
        [Obsolete("MeshCollider.inflateMesh is no longer supported. The new cooking algorithm doesn't need inflation to be used.")]
        public bool inflateMesh { get; set; }
    }
}
