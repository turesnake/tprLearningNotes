
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     Low-level graphics library.
    [NativeHeaderAttribute("Runtime/Camera/CameraUtil.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDevice.h")]
    [NativeHeaderAttribute("Runtime/Graphics/GraphicsScriptBindings.h")]
    [StaticAccessorAttribute("GetGfxDevice()", Bindings.StaticAccessorType.Dot)]
    public sealed class GL
    {
        //
        // 摘要:
        //     Mode for Begin: draw triangles.
        public const int TRIANGLES = 4;
        //
        // 摘要:
        //     Mode for Begin: draw triangle strip.
        public const int TRIANGLE_STRIP = 5;
        //
        // 摘要:
        //     Mode for Begin: draw quads.
        public const int QUADS = 7;
        //
        // 摘要:
        //     Mode for Begin: draw lines.
        public const int LINES = 1;
        //
        // 摘要:
        //     Mode for Begin: draw line strip.
        public const int LINE_STRIP = 2;

        public GL();


        /*
            Controls whether "Linear-to-sRGB color conversion" is performed while rendering.

            只有当设置为 线性颜色空间时, 本变量才起作用;

            Typically when linear color space is used, non-HDR render textures are treated as sRGB data (i.e. "regular colors"), 
            and fragment shaders outputs are treated as linear color values. 
            So by default the fragment shader color value is converted into sRGB.
            --
            通常, 当设置为 线性颜色空间时, 类型为 non-HDR 的 render texture 会被认为是 sRGB 数据, (比如 "regular colors"), 
            而 frag shader 的输出值, 则是 线性颜色值,
            所以默认情况下, frag shader 的 color value 会被转换为 sRGB;
            猜测:
                render texture 是 fs 的写入目的地, fs端输出的是 线性数据 (因为程序选用了 线性颜色空间)
                但 render texture 能容纳的数据确实 sRGB 数据,
                所以需要把 fs输出的数据, linear->sRGB 转换一下;

            但是, 如果你知道你的 fs 的输出数据就已经是 sRGB 模式了, 不再需要这道 linear->sRGB 转换了,
            你可使用本变量来 暂时关闭 这个 转换;

            注意:
            不是所有平台都支持本变量的功能 (关闭 linear->sRGB 转换功能);
            ( 通常, 移动端的 "tile based" GPU 不支持 )
            所有这被认为是 不得已而为之的 功能;

            最好的办法是: 在创建 render texture 时, 就设置为 linear 空间,
            然后就不需要 linear->sRGB 转换 了;
        */
        public static bool sRGBWrite { get; set; }




        //
        // 摘要:
        //     Should rendering be done in wireframe?
        public static bool wireframe { get; set; }
        //
        // 摘要:
        //     Select whether to invert the backface culling (true) or not (false).
        [NativePropertyAttribute("UserBackfaceMode")]
        public static bool invertCulling { get; set; }
        //
        // 摘要:
        //     Gets or sets the modelview matrix.
        public static Matrix4x4 modelview { get; set; }

        //
        // 摘要:
        //     Begin drawing 3D primitives.
        //
        // 参数:
        //   mode:
        //     Primitives to draw: can be TRIANGLES, TRIANGLE_STRIP, QUADS or LINES.
        [FreeFunctionAttribute("GLBegin", ThrowsException = true)]
        public static void Begin(int mode);
        //
        // 摘要:
        //     Clear the current render buffer.
        //
        // 参数:
        //   clearDepth:
        //     Should the depth buffer be cleared?
        //
        //   clearColor:
        //     Should the color buffer be cleared?
        //
        //   backgroundColor:
        //     The color to clear with, used only if clearColor is true.
        //
        //   depth:
        //     The depth to clear the z-buffer with, used only if clearDepth is true. The valid
        //     range is from 0 (near plane) to 1 (far plane). The value is graphics API agnostic:
        //     the abstraction layer will convert the value to match the convention of the current
        //     graphics API.
        public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, [DefaultValue("1.0f")] float depth);
        public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor);
        //
        // 摘要:
        //     Clear the current render buffer with camera's skybox.
        //
        // 参数:
        //   clearDepth:
        //     Should the depth buffer be cleared?
        //
        //   camera:
        //     Camera to get projection parameters and skybox from.
        [FreeFunctionAttribute("ClearWithSkybox")]
        public static void ClearWithSkybox(bool clearDepth, Camera camera);
        //
        // 摘要:
        //     Sets current vertex color.
        //
        // 参数:
        //   c:
        public static void Color(Color c);
        //
        // 摘要:
        //     End drawing 3D primitives.
        [FreeFunctionAttribute("GLEnd")]
        public static void End();
        //
        // 摘要:
        //     Sends queued-up commands in the driver's command buffer to the GPU.
        public static void Flush();
        //
        // 摘要:
        //     Compute GPU projection matrix from camera's projection matrix.
        //
        // 参数:
        //   proj:
        //     Source projection matrix.
        //
        //   renderIntoTexture:
        //     Will this projection be used for rendering into a RenderTexture?
        //
        // 返回结果:
        //     Adjusted projection matrix for the current graphics API.
        [FreeFunctionAttribute("GLGetGPUProjectionMatrix")]
        public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture);
        //
        // 摘要:
        //     Invalidate the internally cached render state.
        [FreeFunctionAttribute("GLInvalidateState")]
        public static void InvalidateState();
        //
        // 摘要:
        //     Send a user-defined event to a native code plugin.
        //
        // 参数:
        //   eventID:
        //     User defined id to send to the callback.
        //
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        public static void IssuePluginEvent(IntPtr callback, int eventID);
        //
        // 摘要:
        //     Send a user-defined event to a native code plugin.
        //
        // 参数:
        //   eventID:
        //     User defined id to send to the callback.
        //
        //   callback:
        //     Native code callback to queue for Unity's renderer to invoke.
        [NativeNameAttribute("InsertCustomMarker")]
        [Obsolete("IssuePluginEvent(eventID) is deprecated. Use IssuePluginEvent(callback, eventID) instead.", false)]
        public static void IssuePluginEvent(int eventID);
        //
        // 摘要:
        //     Load an identity into the current model and view matrices.
        [FreeFunctionAttribute("GLLoadIdentityScript")]
        public static void LoadIdentity();
        //
        // 摘要:
        //     Helper function to set up an orthograhic projection.
        [FreeFunctionAttribute("GLLoadOrthoScript")]
        public static void LoadOrtho();
        //
        // 摘要:
        //     Setup a matrix for pixel-correct rendering.
        //
        // 参数:
        //   left:
        //
        //   right:
        //
        //   bottom:
        //
        //   top:
        public static void LoadPixelMatrix(float left, float right, float bottom, float top);
        //
        // 摘要:
        //     Setup a matrix for pixel-correct rendering.
        [FreeFunctionAttribute("GLLoadPixelMatrixScript")]
        public static void LoadPixelMatrix();
        //
        // 摘要:
        //     Load an arbitrary matrix to the current projection matrix.
        //
        // 参数:
        //   mat:
        [FreeFunctionAttribute("GLLoadProjectionMatrixScript")]
        public static void LoadProjectionMatrix(Matrix4x4 mat);
        //
        // 摘要:
        //     Sets current texture coordinate (v.x,v.y,v.z) to the actual texture unit.
        //
        // 参数:
        //   unit:
        //
        //   v:
        public static void MultiTexCoord(int unit, Vector3 v);
        //
        // 摘要:
        //     Sets current texture coordinate (x,y) for the actual texture unit.
        //
        // 参数:
        //   unit:
        //
        //   x:
        //
        //   y:
        public static void MultiTexCoord2(int unit, float x, float y);
        //
        // 摘要:
        //     Sets current texture coordinate (x,y,z) to the actual texture unit.
        //
        // 参数:
        //   unit:
        //
        //   x:
        //
        //   y:
        //
        //   z:
        [NativeNameAttribute("ImmediateTexCoord")]
        public static void MultiTexCoord3(int unit, float x, float y, float z);
        //
        // 摘要:
        //     Sets the current model matrix to the one specified.
        //
        // 参数:
        //   m:
        [NativeNameAttribute("SetWorldMatrix")]
        public static void MultMatrix(Matrix4x4 m);
        //
        // 摘要:
        //     Restores the model, view and projection matrices off the top of the matrix stack.
        [FreeFunctionAttribute("GLPopMatrixScript")]
        public static void PopMatrix();
        //
        // 摘要:
        //     Saves the model, view and projection matrices to the top of the matrix stack.
        [FreeFunctionAttribute("GLPushMatrixScript")]
        public static void PushMatrix();
        //
        // 摘要:
        //     Resolves the render target for subsequent operations sampling from it.
        public static void RenderTargetBarrier();
        [NativeNameAttribute("SetUserBackfaceMode")]
        [Obsolete("SetRevertBackfacing(revertBackFaces) is deprecated. Use invertCulling property instead.", false)]
        public static void SetRevertBackfacing(bool revertBackFaces);
        //
        // 摘要:
        //     Sets current texture coordinate (v.x,v.y,v.z) for all texture units.
        //
        // 参数:
        //   v:
        public static void TexCoord(Vector3 v);
        //
        // 摘要:
        //     Sets current texture coordinate (x,y) for all texture units.
        //
        // 参数:
        //   x:
        //
        //   y:
        public static void TexCoord2(float x, float y);
        //
        // 摘要:
        //     Sets current texture coordinate (x,y,z) for all texture units.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   z:
        [NativeNameAttribute("ImmediateTexCoordAll")]
        public static void TexCoord3(float x, float y, float z);
        //
        // 摘要:
        //     Submit a vertex.
        //
        // 参数:
        //   v:
        public static void Vertex(Vector3 v);
        //
        // 摘要:
        //     Submit a vertex.
        //
        // 参数:
        //   x:
        //
        //   y:
        //
        //   z:
        [NativeNameAttribute("ImmediateVertex")]
        public static void Vertex3(float x, float y, float z);
        //
        // 摘要:
        //     Set the rendering viewport.
        //
        // 参数:
        //   pixelRect:
        [FreeFunctionAttribute("SetGLViewport")]
        public static void Viewport(Rect pixelRect);
    }
}