#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Gizmos are used to give visual debugging or setup aids in the Scene view.
    [NativeHeaderAttribute("Runtime/Export/Gizmos/Gizmos.bindings.h")]
    [StaticAccessorAttribute("GizmoBindings", Bindings.StaticAccessorType.DoubleColon)]
    public sealed class Gizmos
    {
        public Gizmos();

        //
        // 摘要:
        //     Set a scale for Light Probe gizmos. This scale will be used to render the spherical
        //     harmonic preview spheres.
        public static float probeSize { get; }
        //
        // 摘要:
        //     Sets the Matrix4x4 that the Unity Editor uses to draw Gizmos.
        public static Matrix4x4 matrix { get; set; }
        //
        // 摘要:
        //     Sets the color for the gizmos that will be drawn next.
        public static Color color { get; set; }
        //
        // 摘要:
        //     Set a texture that contains the exposure correction for LightProbe gizmos. The
        //     value is sampled from the red channel in the middle of the texture.
        public static Texture exposure { get; set; }

        //
        // 摘要:
        //     Draw a solid box with center and size.
        //
        // 参数:
        //   center:
        //
        //   size:
        [NativeThrowsAttribute]
        public static void DrawCube(Vector3 center, Vector3 size);
        //
        // 摘要:
        //     Draw a camera frustum using the currently set Gizmos.matrix for its location
        //     and rotation.
        //
        // 参数:
        //   center:
        //     The apex of the truncated pyramid.
        //
        //   fov:
        //     Vertical field of view (ie, the angle at the apex in degrees).
        //
        //   maxRange:
        //     Distance of the frustum's far plane.
        //
        //   minRange:
        //     Distance of the frustum's near plane.
        //
        //   aspect:
        //     Width/height ratio.
        public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect);
        //
        // 摘要:
        //     Draw a texture in the Scene.
        //
        // 参数:
        //   screenRect:
        //     The size and position of the texture on the "screen" defined by the XY plane.
        //
        //   texture:
        //     The texture to be displayed.
        //
        //   mat:
        //     An optional material to apply the texture.
        //
        //   leftBorder:
        //     Inset from the rectangle's left edge.
        //
        //   rightBorder:
        //     Inset from the rectangle's right edge.
        //
        //   topBorder:
        //     Inset from the rectangle's top edge.
        //
        //   bottomBorder:
        //     Inset from the rectangle's bottom edge.
        [ExcludeFromDocs]
        public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder);
        //
        // 摘要:
        //     Draw a texture in the Scene.
        //
        // 参数:
        //   screenRect:
        //     The size and position of the texture on the "screen" defined by the XY plane.
        //
        //   texture:
        //     The texture to be displayed.
        //
        //   mat:
        //     An optional material to apply the texture.
        //
        //   leftBorder:
        //     Inset from the rectangle's left edge.
        //
        //   rightBorder:
        //     Inset from the rectangle's right edge.
        //
        //   topBorder:
        //     Inset from the rectangle's top edge.
        //
        //   bottomBorder:
        //     Inset from the rectangle's bottom edge.
        public static void DrawGUITexture(Rect screenRect, Texture texture, [DefaultValue("null")] Material mat);
        //
        // 摘要:
        //     Draw a texture in the Scene.
        //
        // 参数:
        //   screenRect:
        //     The size and position of the texture on the "screen" defined by the XY plane.
        //
        //   texture:
        //     The texture to be displayed.
        //
        //   mat:
        //     An optional material to apply the texture.
        //
        //   leftBorder:
        //     Inset from the rectangle's left edge.
        //
        //   rightBorder:
        //     Inset from the rectangle's right edge.
        //
        //   topBorder:
        //     Inset from the rectangle's top edge.
        //
        //   bottomBorder:
        //     Inset from the rectangle's bottom edge.
        [NativeThrowsAttribute]
        public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, [DefaultValue("null")] Material mat);
        //
        // 摘要:
        //     Draw a texture in the Scene.
        //
        // 参数:
        //   screenRect:
        //     The size and position of the texture on the "screen" defined by the XY plane.
        //
        //   texture:
        //     The texture to be displayed.
        //
        //   mat:
        //     An optional material to apply the texture.
        //
        //   leftBorder:
        //     Inset from the rectangle's left edge.
        //
        //   rightBorder:
        //     Inset from the rectangle's right edge.
        //
        //   topBorder:
        //     Inset from the rectangle's top edge.
        //
        //   bottomBorder:
        //     Inset from the rectangle's bottom edge.
        [ExcludeFromDocs]
        public static void DrawGUITexture(Rect screenRect, Texture texture);
        //
        // 摘要:
        //     Draw an icon at a position in the Scene view.
        //
        // 参数:
        //   center:
        //
        //   name:
        //
        //   allowScaling:
        [NativeThrowsAttribute]
        public static void DrawIcon(Vector3 center, string name, [DefaultValue("true")] bool allowScaling);
        [NativeThrowsAttribute]
        public static void DrawIcon(Vector3 center, string name, [DefaultValue("true")] bool allowScaling, [DefaultValue("Color(255,255,255,255)")] Color tint);
        //
        // 摘要:
        //     Draw an icon at a position in the Scene view.
        //
        // 参数:
        //   center:
        //
        //   name:
        //
        //   allowScaling:
        [ExcludeFromDocs]
        public static void DrawIcon(Vector3 center, string name);
        //
        // 摘要:
        //     Draws a line starting at from towards to.
        //
        // 参数:
        //   from:
        //
        //   to:
        [NativeThrowsAttribute]
        public static void DrawLine(Vector3 from, Vector3 to);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh);
        //
        // 摘要:
        //     Draws a mesh.
        //
        // 参数:
        //   mesh:
        //     Mesh to draw as a gizmo.
        //
        //   position:
        //     Position (default is zero).
        //
        //   rotation:
        //     Rotation (default is no rotation).
        //
        //   scale:
        //     Scale (default is no scale).
        //
        //   submeshIndex:
        //     Submesh to draw (default is -1, which draws whole mesh).
        [NativeThrowsAttribute]
        public static void DrawMesh(Mesh mesh, int submeshIndex, [DefaultValue("Vector3.zero")] Vector3 position, [DefaultValue("Quaternion.identity")] Quaternion rotation, [DefaultValue("Vector3.one")] Vector3 scale);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh, Vector3 position);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh, int submeshIndex);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation);
        //
        // 摘要:
        //     Draws a mesh.
        //
        // 参数:
        //   mesh:
        //     Mesh to draw as a gizmo.
        //
        //   position:
        //     Position (default is zero).
        //
        //   rotation:
        //     Rotation (default is no rotation).
        //
        //   scale:
        //     Scale (default is no scale).
        //
        //   submeshIndex:
        //     Submesh to draw (default is -1, which draws whole mesh).
        public static void DrawMesh(Mesh mesh, [DefaultValue("Vector3.zero")] Vector3 position, [DefaultValue("Quaternion.identity")] Quaternion rotation, [DefaultValue("Vector3.one")] Vector3 scale);
        [ExcludeFromDocs]
        public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position);
        //
        // 摘要:
        //     Draws a ray starting at from to from + direction.
        //
        // 参数:
        //   r:
        //
        //   from:
        //
        //   direction:
        public static void DrawRay(Vector3 from, Vector3 direction);
        //
        // 摘要:
        //     Draws a ray starting at from to from + direction.
        //
        // 参数:
        //   r:
        //
        //   from:
        //
        //   direction:
        public static void DrawRay(Ray r);
        //
        // 摘要:
        //     Draws a solid sphere with center and radius.
        //
        // 参数:
        //   center:
        //
        //   radius:
        [NativeThrowsAttribute]
        public static void DrawSphere(Vector3 center, float radius);
        //
        // 摘要:
        //     Draw a wireframe box with center and size.
        //
        // 参数:
        //   center:
        //
        //   size:
        [NativeThrowsAttribute]
        public static void DrawWireCube(Vector3 center, Vector3 size);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion rotation);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh, Vector3 position);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh);
        //
        // 摘要:
        //     Draws a wireframe mesh.
        //
        // 参数:
        //   mesh:
        //     Mesh to draw as a gizmo.
        //
        //   position:
        //     Position (default is zero).
        //
        //   rotation:
        //     Rotation (default is no rotation).
        //
        //   scale:
        //     Scale (default is no scale).
        //
        //   submeshIndex:
        //     Submesh to draw (default is -1, which draws whole mesh).
        public static void DrawWireMesh(Mesh mesh, [DefaultValue("Vector3.zero")] Vector3 position, [DefaultValue("Quaternion.identity")] Quaternion rotation, [DefaultValue("Vector3.one")] Vector3 scale);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh, int submeshIndex);
        //
        // 摘要:
        //     Draws a wireframe mesh.
        //
        // 参数:
        //   mesh:
        //     Mesh to draw as a gizmo.
        //
        //   position:
        //     Position (default is zero).
        //
        //   rotation:
        //     Rotation (default is no rotation).
        //
        //   scale:
        //     Scale (default is no scale).
        //
        //   submeshIndex:
        //     Submesh to draw (default is -1, which draws whole mesh).
        [NativeThrowsAttribute]
        public static void DrawWireMesh(Mesh mesh, int submeshIndex, [DefaultValue("Vector3.zero")] Vector3 position, [DefaultValue("Quaternion.identity")] Quaternion rotation, [DefaultValue("Vector3.one")] Vector3 scale);
        [ExcludeFromDocs]
        public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position);
        //
        // 摘要:
        //     Draws a wireframe sphere with center and radius.
        //
        // 参数:
        //   center:
        //
        //   radius:
        [NativeThrowsAttribute]
        public static void DrawWireSphere(Vector3 center, float radius);
    }
}

