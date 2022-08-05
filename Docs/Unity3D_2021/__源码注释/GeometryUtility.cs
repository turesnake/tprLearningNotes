#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Utility class for common geometric functions.
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [StaticAccessorAttribute("GeometryUtilityScripting", Bindings.StaticAccessorType.DoubleColon)]
    public sealed class GeometryUtility
    {
        public GeometryUtility();

        //
        // 摘要:
        //     Calculates the bounding box from the given array of positions and the transformation
        //     matrix.
        //
        // 参数:
        //   positions:
        //     An array that stores the location of 3d positions.
        //
        //   transform:
        //     A matrix that changes the position, rotation and size of the bounds calculation.
        //
        // 返回结果:
        //     Calculates the axis-aligned bounding box.
        public static Bounds CalculateBounds(Vector3[] positions, Matrix4x4 transform);

        

        /*
            Calculates frustum planes.

            

            返回结果:
                The planes that enclose the projection space described by the matrix.

                Ordering: [0] = Left, [1] = Right, [2] = Down, [3] = Up, [4] = Near, [5] = Far
            
            参数:
            camera:
                The camera with the view frustum that you want to calculate planes from.
            
            参数:
            worldToProjectionMatrix:
                A matrix that transforms from world space to projection space, from which the
                planes will be calculated.
            
            planes:
                An array of 6 Planes that will be overwritten with the calculated plane values.
        */
        public static Plane[] CalculateFrustumPlanes(Camera camera);
        public static Plane[] CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix);
        public static void CalculateFrustumPlanes(Camera camera, Plane[] planes);        
        public static void CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix, Plane[] planes);




        /*
            Returns true if bounds are inside the plane array.

            The TestPlanesAABB function uses the Plane array to test whether a bounding box is in the frustum or not.
            You can use this function with CalculateFrustrumPlanes() to test whether a camera's view contains an object regardless of whether it is rendered or not.

            The test is conservative and can give false positive results. A bounding box can intersect the planes outside of the frustum 
            because the planes are infinite and extend beyond the frustum volume. A typical false positive result is produced by a big bounding box 
            near the frustum edge or corner.
            ---
            本函数的结果可能是 "假阳性" 的: 
            因为 frustum 的6个平面, 每个平面都是无线大的, 就算是 frustum 之外的 平面区域 和目标mesh相交, 本函数也判定为相交;
            
            参数:
            planes:
            
            bounds:
        */
        public static bool TestPlanesAABB(Plane[] planes, Bounds bounds);




        public static bool TryCreatePlaneFromPolygon(Vector3[] vertices, out Plane plane);
    }
}

