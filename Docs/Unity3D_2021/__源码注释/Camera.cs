#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace UnityEngine
{
    //
    // 摘要:
    //     A Camera is a device through which the player views the world.
    [NativeHeaderAttribute("Runtime/Shaders/Shader.h")]
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    [NativeHeaderAttribute("Runtime/Camera/RenderManager.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
    [NativeHeaderAttribute("Runtime/Misc/GameObjectUtility.h")]
    [NativeHeaderAttribute("Runtime/Graphics/RenderTexture.h")]
    [RequireComponent(typeof(Transform))]
    [UsedByNativeCodeAttribute]
    public sealed class Camera : Behaviour
    {
        //
        // 摘要:
        //     Delegate that you can use to execute custom code before a Camera culls the scene.
        public static CameraCallback onPreCull;
        //
        // 摘要:
        //     Delegate that you can use to execute custom code before a Camera renders the
        //     scene.
        public static CameraCallback onPreRender;
        //
        // 摘要:
        //     Delegate that you can use to execute custom code after a Camera renders the scene.
        public static CameraCallback onPostRender;

        public Camera();

        //
        // 摘要:
        //     The number of cameras in the current Scene.
        public static int allCamerasCount { get; }
        //
        // 摘要:
        //     Returns all enabled cameras in the Scene.
        public static Camera[] allCameras { get; }
        //
        // 摘要:
        //     The camera we are currently rendering with, for low-level render control only
        //     (Read Only).
        public static Camera current { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property mainCamera has been deprecated. Use Camera.main instead (UnityUpgradable) -> main", true)]
        public static Camera mainCamera { get; }
        //
        // 摘要:
        //     The first enabled Camera component that is tagged "MainCamera" (Read Only).
        public static Camera main { get; }
        //
        // 摘要:
        //     How and if camera generates a depth texture.
        public DepthTextureMode depthTextureMode { get; set; }
        //
        // 摘要:
        //     The color with which the screen will be cleared.
        public Color backgroundColor { get; set; }
        //
        // 摘要:
        //     Should the camera clear the stencil buffer after the deferred light pass?
        public bool clearStencilAfterLightingPass { get; set; }
        //
        // 摘要:
        //     Enable [UsePhysicalProperties] to use physical camera properties to compute the
        //     field of view and the frustum.
        public bool usePhysicalProperties { get; set; }
        //
        // 摘要:
        //     The size of the camera sensor, expressed in millimeters.
        public Vector2 sensorSize { get; set; }
        //
        // 摘要:
        //     Whether or not the Camera will use occlusion culling during rendering.
        public bool useOcclusionCulling { get; set; }
        //
        // 摘要:
        //     Per-layer culling distances.
        public float[] layerCullDistances { get; set; }
        //
        // 摘要:
        //     Sets the culling maks used to determine which objects from which Scenes to draw.
        //     See EditorSceneManager.SetSceneCullingMask.
        [NativeConditionalAttribute("UNITY_EDITOR")]
        public ulong overrideSceneCullingMask { get; set; }
        //
        // 摘要:
        //     Identifies what kind of camera this is, using the CameraType enum.
        public CameraType cameraType { get; set; }
        //
        // 摘要:
        //     How to perform per-layer culling for a Camera.
        public bool layerCullSpherical { get; set; }
        //
        // 摘要:
        //     Mask to select which layers can trigger events on the camera.
        public int eventMask { get; set; }
        //
        // 摘要:
        //     This is used to render parts of the Scene selectively.
        public int cullingMask { get; set; }
        //
        // 摘要:
        //     How the camera clears the background.
        public CameraClearFlags clearFlags { get; set; }
        //
        // 摘要:
        //     Sets a custom matrix for the camera to use for all culling queries.
        public Matrix4x4 cullingMatrix { get; set; }
        //
        // 摘要:
        //     The aspect ratio (width divided by height).
        public float aspect { get; set; }
        //
        // 摘要:
        //     The lens offset of the camera. The lens shift is relative to the sensor size.
        //     For example, a lens shift of 0.5 offsets the sensor by half its horizontal size.
        public Vector2 lensShift { get; set; }
        //
        // 摘要:
        //     Camera's depth in the camera rendering order.
        public float depth { get; set; }
        //
        // 摘要:
        //     An axis that describes the direction along which the distances of objects are
        //     measured for the purpose of sorting.
        public Vector3 transparencySortAxis { get; set; }


        /*
            摘要:
            Transparent object sorting mode.
            
            返回值:
            enum:
            -- Default:
                默认模式:
                若为投射模式的 camera:
                    半透明物体按照 "distance from camera pos to the obj center" 来排序;
                若为正交模式的 camera:
                    半透明物体按照 "物体 沿着 view direction 方向的 distance" 来排序;

            -- Perspective:
                透视模式的 camera 中, 
                半透明物体按照 "distance from camera pos to the obj center" 来排序;

            -- Orthographic:
                2d 游戏专用, 
                半透明物体按照 "distance along the camera's view" 排序;

            -- CustomAxis:
                Sort objects based on "distance along a custom axis".
                适用于 2.5D 游戏

                注意, 此处的排序规则优先级, 要低于 SortingLayer.
                SortingLayer 被用于 2D 系统, 比如 sprites 的排序;
        */
        public TransparencySortMode transparencySortMode { get; set; }



        //
        // 摘要:
        //     Opaque object sorting mode.
        public OpaqueSortMode opaqueSortMode { get; set; }
        //
        // 摘要:
        //     Is the camera orthographic (true) or perspective (false)?
        public bool orthographic { get; set; }
        //
        // 摘要:
        //     Camera's half-size when in orthographic mode.
        public float orthographicSize { get; set; }
        //
        // 摘要:
        //     Should camera rendering be forced into a RenderTexture.
        [NativePropertyAttribute("ForceIntoRT")]
        public bool forceIntoRenderTexture { get; set; }
        //
        // 摘要:
        //     Dynamic Resolution Scaling.
        public bool allowDynamicResolution { get; set; }
        //
        // 摘要:
        //     MSAA rendering.
        public bool allowMSAA { get; set; }
        //
        // 摘要:
        //     High dynamic range rendering.
        public bool allowHDR { get; set; }
        //
        // 摘要:
        //     The rendering path that is currently being used (Read Only).
        public RenderingPath actualRenderingPath { get; }
        //
        // 摘要:
        //     The rendering path that should be used, if possible.
        public RenderingPath renderingPath { get; set; }
        //
        // 摘要:
        //     Get the world-space speed of the camera (Read Only).
        public Vector3 velocity { get; }
        //
        // 摘要:
        //     The camera focal length, expressed in millimeters. To use this property, enable
        //     UsePhysicalProperties.
        public float focalLength { get; set; }
        //
        // 摘要:
        //     How wide is the camera in pixels (not accounting for dynamic resolution scaling)
        //     (Read Only).
        public int pixelWidth { get; }
        //
        // 摘要:
        //     Where on the screen is the camera rendered in normalized coordinates.
        [NativePropertyAttribute("NormalizedViewportRect")]
        public Rect rect { get; set; }
        //
        // 摘要:
        //     Render only once and use resulting image for both eyes.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property stereoMirrorMode is no longer supported. Please use single pass stereo rendering instead.", true)]
        public bool stereoMirrorMode { get; set; }
        //
        // 摘要:
        //     High dynamic range rendering.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property hdr has been deprecated. Use Camera.allowHDR instead (UnityUpgradable) -> UnityEngine.Camera.allowHDR", false)]
        public bool hdr { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property fov has been deprecated. Use Camera.fieldOfView instead (UnityUpgradable) -> UnityEngine.Camera.fieldOfView", false)]
        public float fov { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property far has been deprecated. Use Camera.farClipPlane instead (UnityUpgradable) -> UnityEngine.Camera.farClipPlane", false)]
        public float far { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property near has been deprecated. Use Camera.nearClipPlane instead (UnityUpgradable) -> UnityEngine.Camera.nearClipPlane", false)]
        public float near { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property isOrthoGraphic has been deprecated. Use orthographic (UnityUpgradable) -> orthographic", true)]
        public bool isOrthoGraphic { get; set; }
        //
        // 摘要:
        //     Number of command buffers set up on this camera (Read Only).
        public int commandBufferCount { get; }
        //
        // 摘要:
        //     Returns the eye that is currently rendering. If called when stereo is not enabled
        //     it will return Camera.MonoOrStereoscopicEye.Mono. If called during a camera rendering
        //     callback such as OnRenderImage it will return the currently rendering eye. If
        //     called outside of a rendering callback and stereo is enabled, it will return
        //     the default eye which is Camera.MonoOrStereoscopicEye.Left.
        public MonoOrStereoscopicEye stereoActiveEye { get; }
        //
        // 摘要:
        //     Defines which eye of a VR display the Camera renders into.
        public StereoTargetEyeMask stereoTargetEye { get; set; }
        //
        // 摘要:
        //     Determines whether the stereo view matrices are suitable to allow for a single
        //     pass cull.
        public bool areVRStereoViewMatricesWithinSingleCullTolerance { get; }
        //
        // 摘要:
        //     Distance to a point where virtual eyes converge.
        public float stereoConvergence { get; set; }
        //
        // 摘要:
        //     The distance between the virtual eyes. Use this to query or set the current eye
        //     separation. Note that most VR devices provide this value, in which case setting
        //     the value will have no effect.
        public float stereoSeparation { get; set; }
        //
        // 摘要:
        //     Stereoscopic rendering.
        public bool stereoEnabled { get; }
        //
        // 摘要:
        //     There are two gates for a camera, the sensor gate and the resolution gate. The
        //     physical camera sensor gate is defined by the sensorSize property, the resolution
        //     gate is defined by the render target area.
        public GateFitMode gateFit { get; set; }
        //
        // 摘要:
        //     If not null, the camera will only render the contents of the specified Scene.
        public Scene scene { get; set; }
        //
        // 摘要:
        //     Should the jittered matrix be used for transparency rendering?
        [NativePropertyAttribute("UseJitteredProjectionMatrixForTransparent")]
        public bool useJitteredProjectionMatrixForTransparentRendering { get; set; }
        //
        // 摘要:
        //     Get or set the raw projection matrix with no camera offset (no jittering).
        public Matrix4x4 nonJitteredProjectionMatrix { get; set; }
        //
        // 摘要:
        //     Set a custom projection matrix.
        public Matrix4x4 projectionMatrix { get; set; }
        //
        // 摘要:
        //     Matrix that transforms from world to camera space.
        public Matrix4x4 worldToCameraMatrix { get; set; }
        //
        // 摘要:
        //     Matrix that transforms from camera space to world space (Read Only).
        public Matrix4x4 cameraToWorldMatrix { get; }
        //
        // 摘要:
        //     Set the target display for this Camera.
        public int targetDisplay { get; set; }
        //
        // 摘要:
        //     Gets the temporary RenderTexture target for this Camera.
        public RenderTexture activeTexture { get; }
        //
        // 摘要:
        //     Destination render texture.
        public RenderTexture targetTexture { get; set; }
        //
        // 摘要:
        //     How tall is the camera in pixels (accounting for dynamic resolution scaling)
        //     (Read Only).
        public int scaledPixelHeight { get; }
        //
        // 摘要:
        //     How wide is the camera in pixels (accounting for dynamic resolution scaling)
        //     (Read Only).
        public int scaledPixelWidth { get; }
        //
        // 摘要:
        //     How tall is the camera in pixels (not accounting for dynamic resolution scaling)
        //     (Read Only).
        public int pixelHeight { get; }
        //
        // 摘要:
        //     The vertical field of view of the Camera, in degrees.
        [NativePropertyAttribute("VerticalFieldOfView")]
        public float fieldOfView { get; set; }
        //
        // 摘要:
        //     Where on the screen is the camera rendered in pixel coordinates.
        [NativePropertyAttribute("ScreenViewportRect")]
        public Rect pixelRect { get; set; }
        //
        // 摘要:
        //     Get the view projection matrix used on the last frame.
        public Matrix4x4 previousViewProjectionMatrix { get; }
        //
        // 摘要:
        //     The distance of the near clipping plane from the the Camera, in world units.
        [NativePropertyAttribute("Near")]
        public float nearClipPlane { get; set; }
        //
        // 摘要:
        //     The distance of the far clipping plane from the Camera, in world units.
        [NativePropertyAttribute("Far")]
        public float farClipPlane { get; set; }

        public static void CalculateProjectionMatrixFromPhysicalProperties(out Matrix4x4 output, float focalLength, Vector2 sensorSize, Vector2 lensShift, float nearClip, float farClip, GateFitParameters gateFitParameters = default);
        //
        // 摘要:
        //     Converts field of view to focal length. Use either sensor height and vertical
        //     field of view or sensor width and horizontal field of view.
        //
        // 参数:
        //   fieldOfView:
        //     field of view in degrees.
        //
        //   sensorSize:
        //     Sensor size in millimeters.
        //
        // 返回结果:
        //     Focal length in millimeters.
        [NativeNameAttribute("FieldOfViewToFocalLength_Safe")]
        public static float FieldOfViewToFocalLength(float fieldOfView, float sensorSize);
        //
        // 摘要:
        //     Converts focal length to field of view.
        //
        // 参数:
        //   focalLength:
        //     Focal length in millimeters.
        //
        //   sensorSize:
        //     Sensor size in millimeters. Use the sensor height to get the vertical field of
        //     view. Use the sensor width to get the horizontal field of view.
        //
        // 返回结果:
        //     field of view in degrees.
        [NativeNameAttribute("FocalLengthToFieldOfView_Safe")]
        public static float FocalLengthToFieldOfView(float focalLength, float sensorSize);
        //
        // 摘要:
        //     Fills an array of Camera with the current cameras in the Scene, without allocating
        //     a new array.
        //
        // 参数:
        //   cameras:
        //     An array to be filled up with cameras currently in the Scene.
        public static int GetAllCameras(Camera[] cameras);
        //
        // 摘要:
        //     Converts the horizontal field of view (FOV) to the vertical FOV, based on the
        //     value of the aspect ratio parameter.
        //
        // 参数:
        //   horizontalFOV:
        //     The horizontal FOV value in degrees.
        //
        //   aspectRatio:
        //     The aspect ratio value used for the conversion
        //
        //   horizontalFieldOfView:
        [NativeNameAttribute("HorizontalToVerticalFieldOfView_Safe")]
        public static float HorizontalToVerticalFieldOfView(float horizontalFieldOfView, float aspectRatio);
        [FreeFunctionAttribute("CameraScripting::SetupCurrent")]
        public static void SetupCurrent(Camera cur);
        //
        // 摘要:
        //     Converts the vertical field of view (FOV) to the horizontal FOV, based on the
        //     value of the aspect ratio parameter.
        //
        // 参数:
        //   verticalFieldOfView:
        //     The vertical FOV value in degrees.
        //
        //   aspectRatio:
        //     The aspect ratio value used for the conversion
        public static float VerticalToHorizontalFieldOfView(float verticalFieldOfView, float aspectRatio);
        //
        // 摘要:
        //     Add a command buffer to be executed at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        public void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer);
        //
        // 摘要:
        //     Adds a command buffer to the GPU's async compute queues and executes that command
        //     buffer when graphics processing reaches a given point.
        //
        // 参数:
        //   evt:
        //     The point during the graphics processing at which this command buffer should
        //     commence on the GPU.
        //
        //   buffer:
        //     The buffer to execute.
        //
        //   queueType:
        //     The desired async compute queue type to execute the buffer on.
        public void AddCommandBufferAsync(CameraEvent evt, CommandBuffer buffer, ComputeQueueType queueType);
        public void CalculateFrustumCorners(Rect viewport, float z, MonoOrStereoscopicEye eye, Vector3[] outCorners);
        //
        // 摘要:
        //     Calculates and returns oblique near-plane projection matrix.
        //
        // 参数:
        //   clipPlane:
        //     Vector4 that describes a clip plane.
        //
        // 返回结果:
        //     Oblique near-plane projection matrix.
        [FreeFunctionAttribute("CameraScripting::CalculateObliqueMatrix", HasExplicitThis = true)]
        public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane);
        //
        // 摘要:
        //     Makes this camera's settings match other camera.
        //
        // 参数:
        //   other:
        //     Copy camera settings to the other camera.
        [FreeFunctionAttribute("CameraScripting::CopyFrom", HasExplicitThis = true)]
        public void CopyFrom(Camera other);
        public void CopyStereoDeviceProjectionMatrixToNonJittered(StereoscopicEye eye);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.DoClear has been deprecated (UnityUpgradable).", true)]
        public void DoClear();
        //
        // 摘要:
        //     Get command buffers to be executed at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        // 返回结果:
        //     Array of command buffers.
        [FreeFunctionAttribute("CameraScripting::GetCommandBuffers", HasExplicitThis = true)]
        public CommandBuffer[] GetCommandBuffers(CameraEvent evt);
        //
        // 摘要:
        //     Retrieves the effective vertical field of view of the camera, including GateFit.
        //     Fitting the sensor gate and the resolution gate has an impact on the final field
        //     of view. If the sensor gate aspect ratio is the same as the resolution gate aspect
        //     ratio or if the camera is not in physical mode, then this method returns the
        //     same value as the fieldofview property.
        //
        // 返回结果:
        //     Returns the effective vertical field of view.
        public float GetGateFittedFieldOfView();
        //
        // 摘要:
        //     Retrieves the effective lens offset of the camera, including GateFit. Fitting
        //     the sensor gate and the resolution gate has an impact on the final obliqueness
        //     of the projection. If the sensor gate aspect ratio is the same as the resolution
        //     gate aspect ratio, then this method returns the same value as the lenshift property.
        //     If the camera is not in physical mode, then this methods returns Vector2.zero.
        //
        // 返回结果:
        //     Returns the effective lens shift value.
        public Vector2 GetGateFittedLensShift();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetScreenHeight has been deprecated. Use Screen.height instead (UnityUpgradable) -> System.Int32 Screen.height", true)]
        public float GetScreenHeight();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetScreenWidth has been deprecated. Use Screen.width instead (UnityUpgradable) -> System.Int32 Screen.width", true)]
        public float GetScreenWidth();
        public Matrix4x4 GetStereoNonJitteredProjectionMatrix(StereoscopicEye eye);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetStereoProjectionMatrices has been deprecated. Use GetStereoProjectionMatrix(StereoscopicEye eye) instead.", false)]
        public Matrix4x4[] GetStereoProjectionMatrices();
        [FreeFunctionAttribute("CameraScripting::GetStereoProjectionMatrix", HasExplicitThis = true)]
        public Matrix4x4 GetStereoProjectionMatrix(StereoscopicEye eye);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetStereoViewMatrices has been deprecated. Use GetStereoViewMatrix(StereoscopicEye eye) instead.", false)]
        public Matrix4x4[] GetStereoViewMatrices();
        [FreeFunctionAttribute("CameraScripting::GetStereoViewMatrix", HasExplicitThis = true)]
        public Matrix4x4 GetStereoViewMatrix(StereoscopicEye eye);
        //
        // 摘要:
        //     Remove all command buffers set on this camera.
        public void RemoveAllCommandBuffers();
        //
        // 摘要:
        //     Remove command buffer from execution at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer);
        //
        // 摘要:
        //     Remove command buffers from execution at a specified place.
        //
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        public void RemoveCommandBuffers(CameraEvent evt);
        //
        // 摘要:
        //     Render the camera manually.
        [FreeFunctionAttribute("CameraScripting::Render", HasExplicitThis = true)]
        public void Render();
        [FreeFunctionAttribute("CameraScripting::RenderDontRestore", HasExplicitThis = true)]
        public void RenderDontRestore();
        //
        // 摘要:
        //     Render into a static cubemap from this camera.
        //
        // 参数:
        //   cubemap:
        //     The cube map to render to.
        //
        //   faceMask:
        //     A bitmask which determines which of the six faces are rendered to.
        //
        // 返回结果:
        //     False if rendering fails, else true.
        public bool RenderToCubemap(Cubemap cubemap, int faceMask);
        public bool RenderToCubemap(Cubemap cubemap);
        //
        // 摘要:
        //     Render into a cubemap from this camera.
        //
        // 参数:
        //   faceMask:
        //     A bitfield indicating which cubemap faces should be rendered into.
        //
        //   cubemap:
        //     The texture to render to.
        //
        // 返回结果:
        //     False if rendering fails, else true.
        public bool RenderToCubemap(RenderTexture cubemap, int faceMask);
        public bool RenderToCubemap(RenderTexture cubemap);
        public bool RenderToCubemap(RenderTexture cubemap, int faceMask, MonoOrStereoscopicEye stereoEye);
        //
        // 摘要:
        //     Render the camera with shader replacement.
        //
        // 参数:
        //   shader:
        //
        //   replacementTag:
        [FreeFunctionAttribute("CameraScripting::RenderWithShader", HasExplicitThis = true)]
        public void RenderWithShader(Shader shader, string replacementTag);
        //
        // 摘要:
        //     Revert all camera parameters to default.
        public void Reset();
        //
        // 摘要:
        //     Revert the aspect ratio to the screen's aspect ratio.
        public void ResetAspect();
        //
        // 摘要:
        //     Make culling queries reflect the camera's built in parameters.
        public void ResetCullingMatrix();
        //
        // 摘要:
        //     Reset to the default field of view.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.ResetFieldOfView has been deprecated in Unity 5.6 and will be removed in the future. Please replace it by explicitly setting the camera's FOV to 60 degrees.", false)]
        public void ResetFieldOfView();
        //
        // 摘要:
        //     Make the projection reflect normal camera's parameters.
        public void ResetProjectionMatrix();
        //
        // 摘要:
        //     Remove shader replacement from camera.
        public void ResetReplacementShader();
        //
        // 摘要:
        //     Reset the camera to using the Unity computed projection matrices for all stereoscopic
        //     eyes.
        public void ResetStereoProjectionMatrices();
        //
        // 摘要:
        //     Reset the camera to using the Unity computed view matrices for all stereoscopic
        //     eyes.
        public void ResetStereoViewMatrices();
        //
        // 摘要:
        //     Resets this Camera's transparency sort settings to the default. Default transparency
        //     settings are taken from GraphicsSettings instead of directly from this Camera.
        public void ResetTransparencySortSettings();
        //
        // 摘要:
        //     Make the rendering position reflect the camera's position in the Scene.
        public void ResetWorldToCameraMatrix();
        //
        // 摘要:
        //     Returns a ray going from camera through a screen point.
        //
        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   pos:
        public Ray ScreenPointToRay(Vector3 pos);
        public Ray ScreenPointToRay(Vector3 pos, MonoOrStereoscopicEye eye);
        //
        // 摘要:
        //     Transforms position from screen space into viewport space.
        //
        // 参数:
        //   position:
        public Vector3 ScreenToViewportPoint(Vector3 position);
        //
        // 摘要:
        //     Transforms a point from screen space into world space, where world space is defined
        //     as the coordinate system at the very top of your game's hierarchy.
        //
        // 参数:
        //   position:
        //     A screen space position (often mouse x, y), plus a z position for depth (for
        //     example, a camera clipping plane).
        //
        //   eye:
        //     By default, Camera.MonoOrStereoscopicEye.Mono. Can be set to Camera.MonoOrStereoscopicEye.Left
        //     or Camera.MonoOrStereoscopicEye.Right for use in stereoscopic rendering (e.g.,
        //     for VR).
        //
        // 返回结果:
        //     The worldspace point created by converting the screen space point at the provided
        //     distance z from the camera plane.
        public Vector3 ScreenToWorldPoint(Vector3 position);
        public Vector3 ScreenToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye);
        //
        // 摘要:
        //     Make the camera render with shader replacement.
        //
        // 参数:
        //   shader:
        //
        //   replacementTag:
        public void SetReplacementShader(Shader shader, string replacementTag);
        //
        // 摘要:
        //     Sets custom projection matrices for both the left and right stereoscopic eyes.
        //
        // 参数:
        //   leftMatrix:
        //     Projection matrix for the stereoscopic left eye.
        //
        //   rightMatrix:
        //     Projection matrix for the stereoscopic right eye.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.SetStereoProjectionMatrices has been deprecated. Use SetStereoProjectionMatrix(StereoscopicEye eye) instead.", false)]
        public void SetStereoProjectionMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix);
        public void SetStereoProjectionMatrix(StereoscopicEye eye, Matrix4x4 matrix);
        //
        // 摘要:
        //     Set custom view matrices for both eyes.
        //
        // 参数:
        //   leftMatrix:
        //     View matrix for the stereo left eye.
        //
        //   rightMatrix:
        //     View matrix for the stereo right eye.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.SetStereoViewMatrices has been deprecated. Use SetStereoViewMatrix(StereoscopicEye eye) instead.", false)]
        public void SetStereoViewMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix);
        public void SetStereoViewMatrix(StereoscopicEye eye, Matrix4x4 matrix);
        //
        // 摘要:
        //     Sets the Camera to render to the chosen buffers of one or more RenderTextures.
        //
        // 参数:
        //   colorBuffer:
        //     The RenderBuffer(s) to which color information will be rendered.
        //
        //   depthBuffer:
        //     The RenderBuffer to which depth information will be rendered.
        public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer);
        //
        // 摘要:
        //     Sets the Camera to render to the chosen buffers of one or more RenderTextures.
        //
        // 参数:
        //   colorBuffer:
        //     The RenderBuffer(s) to which color information will be rendered.
        //
        //   depthBuffer:
        //     The RenderBuffer to which depth information will be rendered.
        public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer);
        public void SubmitRenderRequests(List<RenderRequest> renderRequests);
        public bool TryGetCullingParameters(bool stereoAware, out ScriptableCullingParameters cullingParameters);
        public bool TryGetCullingParameters(out ScriptableCullingParameters cullingParameters);
        public Ray ViewportPointToRay(Vector3 pos, MonoOrStereoscopicEye eye);
        //
        // 摘要:
        //     Returns a ray going from camera through a viewport point.
        //
        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   pos:
        public Ray ViewportPointToRay(Vector3 pos);
        //
        // 摘要:
        //     Transforms position from viewport space into screen space.
        //
        // 参数:
        //   position:
        public Vector3 ViewportToScreenPoint(Vector3 position);
        //
        // 摘要:
        //     Transforms position from viewport space into world space.
        //
        // 参数:
        //   position:
        //     The 3d vector in Viewport space.
        //
        // 返回结果:
        //     The 3d vector in World space.
        public Vector3 ViewportToWorldPoint(Vector3 position);
        public Vector3 ViewportToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye);
        public Vector3 WorldToScreenPoint(Vector3 position, MonoOrStereoscopicEye eye);
        //
        // 摘要:
        //     Transforms position from world space into screen space.
        //
        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   position:
        public Vector3 WorldToScreenPoint(Vector3 position);
        public Vector3 WorldToViewportPoint(Vector3 position, MonoOrStereoscopicEye eye);
        //
        // 摘要:
        //     Transforms position from world space into viewport space.
        //
        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   position:
        public Vector3 WorldToViewportPoint(Vector3 position);

        //
        // 摘要:
        //     Enum used to specify how the sensor gate (sensor frame) defined by Camera.sensorSize
        //     fits into the resolution gate (render frame).
        public enum GateFitMode
        {
            //
            // 摘要:
            //     Stretch the sensor gate to fit exactly into the resolution gate.
            None = 0,
            //
            // 摘要:
            //     Fit the resolution gate vertically within the sensor gate.
            Vertical = 1,
            //
            // 摘要:
            //     Fit the resolution gate horizontally within the sensor gate.
            Horizontal = 2,
            //
            // 摘要:
            //     Automatically selects a horizontal or vertical fit so that the sensor gate fits
            //     completely inside the resolution gate.
            Fill = 3,
            //
            // 摘要:
            //     Automatically selects a horizontal or vertical fit so that the render frame fits
            //     completely inside the resolution gate.
            Overscan = 4
        }
        //
        // 摘要:
        //     Enumerates which axis to use when expressing the value for the field of view.
        //     The default value is Camera.FieldOfViewAxis.Vertical.
        public enum FieldOfViewAxis
        {
            //
            // 摘要:
            //     Specifies the field of view as vertical.
            Vertical = 0,
            //
            // 摘要:
            //     Specifies the field of view as horizontal.
            Horizontal = 1
        }
        //
        // 摘要:
        //     Enum used to specify either the left or the right eye of a stereoscopic camera.
        public enum StereoscopicEye
        {
            //
            // 摘要:
            //     Specifies the target to be the left eye.
            Left = 0,
            //
            // 摘要:
            //     Specifies the target to be the right eye.
            Right = 1
        }
        //
        // 摘要:
        //     A Camera eye corresponding to the left or right human eye for stereoscopic rendering,
        //     or neither for non-stereoscopic rendering. A single Camera can render both left
        //     and right views in a single frame. Therefore, this enum describes which eye the
        //     Camera is currently rendering when returned by Camera.stereoActiveEye during
        //     a rendering callback (such as Camera.OnRenderImage), or which eye to act on when
        //     passed into a function. The default value is Camera.MonoOrStereoscopicEye.Left,
        //     so Camera.MonoOrStereoscopicEye.Left may be returned by some methods or properties
        //     when called outside of rendering if stereoscopic rendering is enabled.
        public enum MonoOrStereoscopicEye
        {
            //
            // 摘要:
            //     Camera eye corresponding to stereoscopic rendering of the left eye.
            Left = 0,
            //
            // 摘要:
            //     Camera eye corresponding to stereoscopic rendering of the right eye.
            Right = 1,
            //
            // 摘要:
            //     Camera eye corresponding to non-stereoscopic rendering.
            Mono = 2
        }
        //
        // 摘要:
        //     Modes available for submitting when making a render request.
        public enum RenderRequestMode
        {
            //
            // 摘要:
            //     Default value for a request.
            None = 0,
            //
            // 摘要:
            //     The render request outputs an object InstanceID buffer.
            ObjectId = 1,
            //
            // 摘要:
            //     The render request outputs a depth value.
            Depth = 2,
            //
            // 摘要:
            //     The render request outputs the interpolated vertex normal.
            VertexNormal = 3,
            //
            // 摘要:
            //     The render request outputs a world position buffer.
            WorldPosition = 4,
            //
            // 摘要:
            //     The render request outputs an entity id.
            EntityId = 5,
            //
            // 摘要:
            //     The render request outputs the materials albedo / base color.
            BaseColor = 6,
            //
            // 摘要:
            //     The render request returns the materials specular color buffer.
            SpecularColor = 7,
            //
            // 摘要:
            //     The render outputs the materials metal value.
            Metallic = 8,
            //
            // 摘要:
            //     The render request outputs the materials emission value.
            Emission = 9,
            //
            // 摘要:
            //     The render request outputs the per pixel normal.
            Normal = 10,
            //
            // 摘要:
            //     The render request returns the materials smoothness buffer.
            Smoothness = 11,
            //
            // 摘要:
            //     The render request returns the material ambient occlusion buffer.
            Occlusion = 12,
            //
            // 摘要:
            //     The render request outputs the materials diffuse color.
            DiffuseColor = 13
        }
        //
        // 摘要:
        //     Defines in which space render requests will be be outputted.
        public enum RenderRequestOutputSpace
        {
            //
            // 摘要:
            //     RenderRequests will be rendered in screenspace from the perspective of the camera.
            ScreenSpace = -1,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 0 space of the rendered mesh.
            UV0 = 0,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 1 space of the rendered mesh.
            UV1 = 1,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 2 space of the rendered mesh.
            UV2 = 2,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 3 space of the rendered mesh.
            UV3 = 3,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 4 space of the rendered mesh.
            UV4 = 4,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 5 space of the rendered mesh.
            UV5 = 5,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 6 space of the rendered mesh.
            UV6 = 6,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 7 space of the rendered mesh.
            UV7 = 7,
            //
            // 摘要:
            //     RenderRequests will be outputted in UV 8 space of the rendered mesh.
            UV8 = 8
        }

        //
        // 摘要:
        //     Wrapper for gate fit parameters
        public struct GateFitParameters
        {
            public GateFitParameters(GateFitMode mode, float aspect);

            //
            // 摘要:
            //     GateFitMode to use. See Camera.GateFitMode.
            public GateFitMode mode { readonly get; set; }
            //
            // 摘要:
            //     Aspect ratio of the resolution gate.
            public float aspect { readonly get; set; }
        }
        //
        // 摘要:
        //     A request that can be used for making specific rendering requests.
        public struct RenderRequest
        {
            public RenderRequest(RenderRequestMode mode, RenderTexture rt);
            public RenderRequest(RenderRequestMode mode, RenderRequestOutputSpace space, RenderTexture rt);

            //
            // 摘要:
            //     Is this request properly formed.
            public bool isValid { get; }
            //
            // 摘要:
            //     The type of request.
            public RenderRequestMode mode { get; }
            //
            // 摘要:
            //     The result of the request.
            public RenderTexture result { get; }
            //
            // 摘要:
            //     Defines in which space render requests will be be outputted.
            public RenderRequestOutputSpace outputSpace { get; }
        }

        //
        // 摘要:
        //     Delegate type for camera callbacks.
        //
        // 参数:
        //   cam:
        public delegate void CameraCallback(Camera cam);
    }
}