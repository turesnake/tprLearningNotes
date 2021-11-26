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
    /*
        摘要:
        A Camera is a device through which the player views the world.

        A posSS is defined in pixels. 
            -- The bottom-left of the screen is (0,0); 
            -- the right-top is (pixelWidth,pixelHeight). 
            -- The z position is in world units from the Camera.

        A pos-viewport-space is normalized and relative to the Camera. 
            -- The bottom-left of the Camera is (0,0); 
            -- the top-right is (1,1). 
            -- The z position is in world units from the Camera.

        A posWS is defined in global coordinates (for example, Transform.position).

        Note that a class must not inherit from Camera directly. 
        If you need to inherit from Camera see ScriptableCamera.(没找到)

    */
    [NativeHeaderAttribute("Runtime/Shaders/Shader.h")]
    [NativeHeaderAttribute("Runtime/GfxDevice/GfxDeviceTypes.h")]
    [NativeHeaderAttribute("Runtime/Camera/RenderManager.h")]
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
    [NativeHeaderAttribute("Runtime/Misc/GameObjectUtility.h")]
    [NativeHeaderAttribute("Runtime/Graphics/RenderTexture.h")]
    [RequireComponent(typeof(Transform))]
    [UsedByNativeCodeAttribute]
    public sealed class Camera : Behaviour//Camera__
    {

        /*
            摘要:
            Delegate that you can use to execute custom code "before a Camera culls the scene".

            在 camera 对场景中的物体执行 cull 之前, 此事件会被调用;

            在 built-in 管线中, 如果一个 go 绑定了一个 active 的 camera 组件 同时还绑定了一个脚本;
            这个脚本体内可以 实现 MonoBehaviour.OnPreCull() callback 函数;

            Camera.OnPreCull() 和 MonoBehaviour.OnPreCull() 类似,不过不需要上述限制;
            任何能访问到这个 camera 的代码, 都能实现 Camera.OnPreCull();

            具体参考 MonoBehaviour.OnPreCull();
        */
        public static CameraCallback onPreCull;

        // 类似上条, 不过是在 "before a Camera renders the scene" 时会被触发的事件;
        // 参考 MonoBehaviour.OnPreRender();
        public static CameraCallback onPreRender;

        // 类似上条, 不过是在 "after a Camera renders the scene" 时会被触发的事件;
        // 参考 MonoBehaviour.OnPostRender()
        public static CameraCallback onPostRender;


        public Camera();

        /*
            The number of cameras in the current Scene.

            得到: Camera.allCameras 返回的 array 的元素个数;

            同时也是 Camera.GetAllCameras() 会向参数 array 填充的元素个数;
        */
        public static int allCamerasCount { get; }

        /*
            Returns all "enabled" cameras in the Scene.
            只有 enabled 的会被计入;
        */
        public static Camera[] allCameras { get; }


        /*
            摘要:
            The camera we are currently rendering with, for low-level render control only (Read Only).

            大部分场合都应该改用 Camera.main;

            本函数仅该被用于实现以下 事件之一时
            -- MonoBehaviour.OnRenderImage
            -- MonoBehaviour.OnPreRender
            -- MonoBehaviour.OnPostRender
        */
        public static Camera current { get; }

        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property mainCamera has been deprecated. Use Camera.main instead (UnityUpgradable) -> main", true)]
        public static Camera mainCamera { get; }
        */


        /*
            The first enabled Camera component that is tagged "MainCamera" (Read Only).
            If there is no enabled Camera component with the "MainCamera" tag, this property is null.

            Internally, Unity caches all GameObjects with the "MainCamera" tag.

            当你访问此变量时, unity 返回这个 cache 中第一个 valid camera 实例;

            和调用 GameObject.GetComponent() 函数相比, 访问本变量存在一点小的 cpu 开销; 
            如果程序对 cpu性能比较敏感, 建议在脚本中 缓存本变量;
        */
        public static Camera main { get; }


        /*
            摘要:
            How and if camera generates a screen-space depth texture

            enum:
                -- None
                -- Depth
                -- DepthNormals
                -- MotionVectors
            flags 可以组合;
        */
        public DepthTextureMode depthTextureMode { get; set; }


        /*
            The color with which the screen will be cleared.

            Only used if clearFlags are set to CameraClearFlags.SolidColor 
            (or CameraClearFlags.Skybox but the skybox is not set up).
        */
        public Color backgroundColor { get; set; }


        /*
            Should the camera clear the stencil buffer after the deferred light pass?

            当使用 延迟渲染, the G-buffer and lighting passes use the stencil buffer;

            通常, stencil buffer 中的数据会被保留, 不会被清楚, 一般它是用来记录 光模型的 数据的;

            若将本变量设为 true, 那么在 deferred light pass 结束后, stencil buffer 中数据会被全写 0;

            通常:
            如果你使用了 "deferred shading camera" 和 "UI elements with Masks (see UI.Mask)",
            你就需要设置本变量为 true;
        */
        public bool clearStencilAfterLightingPass { get; set; }


        /*
            若设为 true, 将会 use "physical camera properties" to compute the FOV and frustum.

            "physical camera properties": 
                -- sensor size, 
                -- lens shift, 
                -- focal length.
        */
        public bool usePhysicalProperties { get; set; }


        /*
            The size of the camera sensor, expressed in millimeters.
            需要开启 "Camera.usePhysicalProperties";
        */
        public Vector2 sensorSize { get; set; }


        /*
            Whether or not the Camera will use "occlusion culling" during rendering.

            "occlusion culling": 和 "frutum culling" 平起平坐的那个 cull 技术;
        */ 
        public bool useOcclusionCulling { get; set; }



        /*
            Per-layer culling distances.

            通常, camera 会将 far plane 之外的物体 cull 掉;
            这个 cull 操作统一使用 "Camera.farClipPlane" 的距离值;

            但是你也可以为 每一种 layer, 单独设置一个 cull distance;
            (layer 就是每个物体都设置的那个 layer)

            应该把本变量设置为 "含有 32 个元素" 的 array;
            每个元素值, 对应一个 layer;

            如果某个原始值为 0, 表示这个 layer 使用默认值: "Camera.farClipPlane"

            通过这个方法, 可以将一个 小物体 提前 cull 掉;
        */
        public float[] layerCullDistances { get; set; }




        //     Sets the culling maks used to determine which objects from which Scenes to draw.
        //     See EditorSceneManager.SetSceneCullingMask.
        [NativeConditionalAttribute("UNITY_EDITOR")]
        public ulong overrideSceneCullingMask { get; set; }



        /*
            摘要:
            Identifies what kind of camera this is, using the CameraType enum.

            enum:
                -- Game
                -- SceneView
                -- Preview
                -- VR
                -- Reflection

            通常, 在游戏运行时, 大部分camera 都是 Game 模式的;

            挡在 editor 阶段时, 才存在各种不同类型的 camera,
            在 srp 管线中也很有用, 如果你希望 camera 在 editor 中 和 运行时中 具备不同的行为;
        */
        public CameraType cameraType { get; set; }


        /*
            摘要:
            How to perform per-layer culling for a Camera.

            通常, camera cull 工作是基于 far plane distance 来实现的, 就是一个平面;
            若勾选此变量, 将改用 cull sphere 半径来执行 cull 判断;

            这种实现有一个优点: 就是当摄像机原地旋转时, 物体不会 一会儿出现在视野中, 一会儿又消失;
            (基于 far plane 就会这样)
        */
        public bool layerCullSpherical { get; set; }


        /*
            摘要:
            Mask to select which layers can trigger events on the camera.

            就好比 Camera.cullingMask 可以决定 camera 能看见哪些物体,
            eventMask 则进一步决定了, 这些能被 camera 看见的物体中, 哪些是可以接收到 鼠标事件的;

            一物体, 先要能被 camera 看见(cullingmask), 然后它的 layermask 能与 camera 的 eventMask 部分重叠,
            那么这个物体就能接受各种鼠标事件:
                -- MonoBehaviour.OnMouseEnter, 
                -- MonoBehaviour.OnMouseExit, 
                -- MonoBehaviour.OnMouseOver, 
                -- MonoBehaviour.OnMouseDown, 
                -- MonoBehaviour.OnMouseOver, 
                -- MonoBehaviour.OnMouseUp, 
                -- MonoBehaviour.OnMouseDrag, 
                -- MonoBehaviour.OnMouseUpAsButton.

            如果你不会用到 鼠标事件, 那么将本变量设置为 0 能提高性能;
        */
        public int eventMask { get; set; }


        /*
            摘要:
            This is used to render parts of the Scene selectively.

            如果 物体的 layerMask 和 camera 的 cullingMask 部分重叠, 
            那么这个物体 就会参与 camera 的后续渲染工作, 当然也包括 occlusion culling 和 frustum culling,
            即, 这个物体有可能会被渲染, 也有可能被剔除;

            如果这个物体的 layerMask 和 camera 的 cullingMask 不重叠, (AND运算得0),
            这个物体直接不会被 camera 拿去渲染;
        */
        public int cullingMask { get; set; }


        /*
            How the camera clears the background.

            enum:
                -- Skybox
                -- Color
                -- SolidColor
                -- Depth
                -- Nothing
        */
        public CameraClearFlags clearFlags { get; set; }



        /*
            Sets a custom matrix for the camera to use for all culling queries.

            设置在此处的 矩阵将持续存在, 直到调用 Camera.ResetCullingMatrix();

            A custom culling matrix can be useful in situations 
            where multiple cameras must be culled identically 
            in order to render effects such as reflections.
            --
            一个自定义的 culling矩阵 通常用于:
            当需要数个 cameras 都使用同一个 culling矩阵 去执行 culling 操作;
            比如在实现 反射 这种特效时;
        */
        public Matrix4x4 cullingMatrix { get; set; }



        /*
            The aspect ratio (width divided by height).  横纵比, w/h, 宽度除以高度;

            通常, 这个值会直接使用 screen's aspect ratio 值, 哪怕这个 camera 没有覆盖全屏;

            如果你在此手动改写此值, 新的值会始终存在, 直到调用 camera.ResetAspect();
            这个函数会把 本值再次 等同于 screen's aspect ratio;
        */
        public float aspect { get; set; }


        /*
            The lens offset of the camera. The lens shift is relative to the sensor size.
            For example, a lens shift of 0.5 offsets the sensor by half its horizontal size.

            需要开启 "Camera.usePhysicalProperties";
        */
        public Vector2 lensShift { get; set; }



        /*
            Camera's depth in the camera rendering order.

            这个值越低, 这个 camera 的优先级越高, 越先被执行;
            inspector 说明中指出, 这个值的区间为 [-100,100]
            默认值为 -1;
        */
        public float depth { get; set; }


        /*
            An axis that describes the direction along which the distances of objects are
            measured for the purpose of sorting.

            定义了一个 方向轴, 沿着这个轴来对 半透明物体排序;

            如果 camera.transparencySortMode (或者 transparencySortMode class 的) 被设置为 CustomAxis,
            管线就会沿着这个 自定义方向来 排序;

            具体参考下方的: "transparencySortMode" 的解释;


            This is used for sorting Renderer components when other, higher priority, 
            criterias fail to distinguish the render order.
            --
            当更高级别的 排序方式失效时, 就用此方法来排序;

            很适合 2.5d游戏 和 正交透视游戏, 
        */
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



        /*
            Opaque object sorting mode.

            有数种规则来对 不透明物体做排序:
            -- sorting layers, 
            -- shader queues, 
            -- materials, 
            -- distance, 
            -- lightmaps

            为了最大化 cpu 效率 (减少 render state 的改动次数, 提高 draw call batch 成功率)
            最大化 gpu 效率 ( 大部分 gpu 都喜欢 从前向后 的顺序执行渲染, 以便把遮挡的 fragments 都 剔除掉 )

            默认, 不透明物体被粗略地整合成 从前向后的 buckets, (因为这样对大部分 gpu 有利)
            
            但是少数 gpu 不喜欢这种排序方式, ( 主要是: PowerVR/Apple GPUs ),
            所以针对这些 gpu, 默认不会执行 基于 distance 的 排序;

            改写 "Camera.opaqueSortMode" 可以覆写上述默认功能, 
            比如, 如果你觉得在你的程序中, cpu算力 更为宝贵, 那么你可以彻底关闭 distance-based sorting;

            enum:
                -- Default
                -- FrontToBack
                -- NoDistanceSort
        */
        public OpaqueSortMode opaqueSortMode { get; set; }


        /*
            Is the camera orthographic (true) or perspective (false)?

            当启用 正交模式, camera's viewing volume is defined by "Camera.orthographicSize"
            当启用 透视模式, camera's viewing volume is defined by "Camera.fieldOfView"

            注意:
            延迟渲染 不支持 正交模式; 如果此处被设置为 正交, 那么 camera 会始终执行 前向渲染;
        */
        public bool orthographic { get; set; }


        /*
            Camera's half-size when in orthographic mode.

            defines the viewing volume of an orthographic Camera

            is half the size of the vertical viewing volume
            ---
            窗口垂直高度的一半;

            仅在 正交透视模式下 有效;
        */
        public float orthographicSize { get; set; }


        /*
            Should camera rendering be forced into a RenderTexture.
            ---
            是否应该将 camera 的渲染对象 强制转换为 render texture;

            若设为 true, camera 的渲染物 已经会被送入 render texture, 而不会直接送入 backbuffer. 

            如果你没有 image effects, 但又想用 command buffer 来作用于 current render target,
            此时就能启用此变量;
        */
        [NativePropertyAttribute("ForceIntoRT")]
        public bool forceIntoRenderTexture { get; set; }



        /*
            Dynamic Resolution Scaling.

            如果 camera 正在使用 Dynamic Resolution rendering, 此值为 true;

            就算把此值设置为 true, 也只有当 当前图形设备和驱动 支持 Dynamic Resolution rendering 时,
            这个功能才会被真的开启;

            注意:
                Dynamic resolution scaling (DRS) 会实时改变 camera 的 分辨率;
                这将减少 gpu 的工作量;
        */
        public bool allowDynamicResolution { get; set; }


        /*
            MSAA rendering.

            Should this camera use a MSAA render target ? 
            Will only use MSAA if supported by the current quality settings MSAA level.
        */
        public bool allowMSAA { get; set; }


        /*
            High dynamic range rendering.

            true 就是使用 hdr;

            只有当 current "GraphicsTier" 中支持 hdr 时, 才能通过此处开启 hdr;

            You can only set a Graphics Tier in the Built-in Render Pipeline.
        */
        public bool allowHDR { get; set; }


        /*
            The rendering path that is currently being used (Read Only).

            如果 底层gpu/平台 不支持用户定义的 "Camera.renderingPath",
            (或者别的原因 导致 用户定义的模式 无法被执行)
            那么就算设置那个值, 本变量仍然不会同步到 目标值上去, 依然维持当前正在用的 模式;
            这个值可能和 用户定义的 "Camera.renderingPath" 不同,
        */
        public RenderingPath actualRenderingPath { get; }


        /*
            The rendering path that should be used, if possible.

            用户可以设置这个值, 但不一定能设置成功, 所以, 我们在设置后, 可以去访问上面的
            "Camera.actualRenderingPath" 来查看是否设置成功
        */
        public RenderingPath renderingPath { get; set; }


        /*
            Get the world-space speed of the camera (Read Only).

            This camera's motion in units per second as it was during the last frame.
        */
        public Vector3 velocity { get; }


        /*
            The camera focal length, expressed in millimeters. 焦距
            需要开启 "Camera.usePhysicalProperties";
        */
        public float focalLength { get; set; }


        /*
            How wide is the camera in pixels (not accounting for dynamic resolution scaling) (Read Only).
        */
        public int pixelWidth { get; }


        /*
            Where on the screen is the camera rendered in normalized coordinates.
            The values in rect range from zero (left/bottom) to one (right/top).

            tpr:
                本 camera 的渲染, 在屏幕上覆盖的区域; 
                如果这个 camera 覆盖全屏, 则得到:(x:0.00, y:0.00, width:1.00, height:1.00)

        */
        [NativePropertyAttribute("NormalizedViewportRect")]
        public Rect rect { get; set; }


        /*
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
        */



        // Number of command buffers set up on this camera (Read Only).
        public int commandBufferCount { get; }

        
        // 摘要:
        //     Returns the eye that is currently rendering. If called when stereo is not enabled
        //     it will return Camera.MonoOrStereoscopicEye.Mono. If called during a camera rendering
        //     callback such as OnRenderImage it will return the currently rendering eye. If
        //     called outside of a rendering callback and stereo is enabled, it will return
        //     the default eye which is Camera.MonoOrStereoscopicEye.Left.
        public MonoOrStereoscopicEye stereoActiveEye { get; }//vr
        
        // 摘要:
        //     Defines which eye of a VR display the Camera renders into.
        public StereoTargetEyeMask stereoTargetEye { get; set; }//vr
        
        // 摘要:
        //     Determines whether the stereo view matrices are suitable to allow for a single
        //     pass cull.
        public bool areVRStereoViewMatricesWithinSingleCullTolerance { get; }//vr
        
        // 摘要:
        //     Distance to a point where virtual eyes converge.
        public float stereoConvergence { get; set; }//vr
        
        // 摘要:
        //     The distance between the virtual eyes. Use this to query or set the current eye
        //     separation. Note that most VR devices provide this value, in which case setting
        //     the value will have no effect.
        public float stereoSeparation { get; set; }//vr
        
        // 摘要:
        //     Stereoscopic rendering.
        public bool stereoEnabled { get; }//vr




        /*
            There are two gates for a camera, the "sensor gate" and the "resolution gate". 
            The physical camera sensor gate is defined by the "Camera.sensorSize", 
            the resolution gate is defined by the render target area.

            本变量定义了, sensor gate 的尺寸 是如何调整去适配 resolution gate 的;

            To use this property, enable "Camera.usePhysicalProperties"
            此 enum 在本文件最下方;
        */
        public GateFitMode gateFit { get; set; }


        /*
            If not null, the camera will only render the contents of the specified Scene.

            若本变量不为 null, 那么 camera 只会渲染 指定的 scene 中的物体;
            (这么看, 本变量默认为 null)

            Currently, only Scenes created by EditorSceneManager.NewPreviewScene() are supported.
        */
        public Scene scene { get; set; }


        /*
            Should the jittered matrix be used for transparency rendering?
            详细内容见下面两个变量;
        */
        [NativePropertyAttribute("UseJitteredProjectionMatrixForTransparent")]
        public bool useJitteredProjectionMatrixForTransparentRendering { get; set; }


        /*
            Get or set the raw projection matrix with no camera offset (no jittering).

            对于很多 "时间性 image effects", 当前正在渲染的 camera 需要在 default projection 的基础上
            做微小的 偏移; (也就是说, camera 发生了抖动 ‘jittered’ )

            使用本变量来指定: 在偏移发生之前 所用的 "default perspective matrix";

            可以对那些 半透明物体 选择使用 "jittered 矩阵", 或 "非 jittered 矩阵",
            参考上一个变量;

            如果你同时使用 motion vectors 和 camera jittering, 使用本变量来保证 帧之间的 motion vectors
            保持稳定;

            如果想要设置 jittered matrix, 可用: "Camera.projectionMatrix"
        */
        public Matrix4x4 nonJitteredProjectionMatrix { get; set; }



        /*
            Set a custom projection matrix.

            如果你改写此变量, camera 将不再 "基于它自己的 fov" 去更新渲染,
            直到你调用 Camera.ResetProjectionMatrix() 为止;

            只有当你真的需要一个 non-standard projection 时, 才去自定义本变量;
            本变量被 Unity's water rendering 使用, 来设置一个 液体投影矩阵;

            注意:
            传递给 shader 的 投影矩阵, 可能会基于平台或其它 state 而发生修改;
             
            If you need to calculate projection matrix for shader use from camera's projection, 
            use GL.GetGPUProjectionMatrix();
        */
        public Matrix4x4 projectionMatrix { get; set; }



        /*
            Matrix that transforms from world to camera-space.

            This matrix is often referred to as "view matrix" in graphics literature.

            unity 的 view-space 为右手坐标系;

            If you change this matrix, camera 不再基于自己的 Transform 组件信息来更新自己的 渲染;
            直到你调用 Camera.ResetWorldToCameraMatrix();
        */
        public Matrix4x4 worldToCameraMatrix { get; set; }

        //     Matrix that transforms from camera space to world space (Read Only).
        public Matrix4x4 cameraToWorldMatrix { get; }


        /*
            Set the target display for this Camera.

            This setting makes a Camera render into the specified display. 
            Maximum number of displays (eg.monitors) supported is 8.

            本变量对 Android and iOS 平台不起作用, 
            此时改用: Camera.SetTargetBuffers();
        */
        public int targetDisplay { get; set; }


        /*
            Gets the temporary RenderTexture target for this Camera.

            可在 camera 的 OnPostRender 回调函数中 访问 render target 的内容;
        */
        public RenderTexture activeTexture { get; }


        /*
            Destination render texture.

            Usually cameras render directly to screen, 也可用本变量指定一个 rt;
            当本值为 null, camera renders to screen.

            当设置了此值, the camera always renders into the whole texture; 
            effectively "Camera.rect" and "Camera.pixelRect" are ignored.

            还能让 camera 渲染进特定的 RenderBuffers, 或一次渲染进 multiple textures;
            使用: Camera.SetTargetBuffers()
        */
        public RenderTexture targetTexture { get; set; }


        /*
            the  w/h of the camera in pixels (考入了 dynamic resolution 的缩放) (Read Only).
        */
        public int scaledPixelHeight { get; }
        public int scaledPixelWidth { get; }



        /*
            How tall is the camera in pixels (不考虑 dynamic resolution 的缩放) (Read Only).
            Use this to return the "height of the Camera viewport" is in pixels
        */
        public int pixelHeight { get; }


        /*
            The vertical field-of-view (of the Camera, in degrees);

            若 camera 为正交透视模式, 将忽视本值;

            ... 一些关于 VR 的内容, 此处未翻译 ... 

            如果你改写了 Camera.projectionMatrix, camera 将忽略本值;
            直到你调用 Camera.ResetProjectionMatrix();
        */
        [NativePropertyAttribute("VerticalFieldOfView")]
        public float fieldOfView { get; set; }

        /*
            Where on the screen is the camera rendered in pixel coordinates.

            camera 的渲染区, 在屏幕上占据的区域, 不过是以 像素为单位的;

            如果一个项目, 屏幕长宽设置为: 1920,1080;
            且 camera 覆盖整个屏幕, 那么本变量的值为: (x:0.00, y:0.00, width:1920.00, height:1080.00)
        */
        [NativePropertyAttribute("ScreenViewportRect")]
        public Rect pixelRect { get; set; }



        //     Get the view-projection-matrix used on the last frame.
        public Matrix4x4 previousViewProjectionMatrix { get; }



        //     The distance of the near/far clipping plane from the the Camera, in world units.
        [NativePropertyAttribute("Near")]
        public float nearClipPlane { get; set; }

        [NativePropertyAttribute("Far")]
        public float farClipPlane { get; set; }


        /*
            Calculates the projection matrix from: 
                focal length, sensor size, lens shift, near/far plane distance, and Gate fit parameters. 
                
            如果不想计入 Gate fit, 可在参数 gateFitParameters.mode 上使用 None;

            参数:
            output:
                The calculated matrix. 输出端

            focalLength:
                Focal length in millimeters. 焦距, 毫米为单位

            sensorSize:
                Sensor dimensions in Millimeters.

            lensShift:
                Lens offset relative to the sensor size.

            nearClip:
            farClip:

            gateFitParameters:
                Gate fit parameters to use
                class 内容见本文件底部;
        */
        public static void CalculateProjectionMatrixFromPhysicalProperties(
            out Matrix4x4 output, 
            float focalLength, 
            Vector2 sensorSize, 
            Vector2 lensShift, 
            float nearClip, 
            float farClip, 
            GateFitParameters gateFitParameters = default
        );
        
        
        /*
            摘要:
            Converts fov to focal length(焦距). Use either:
                -- sensor height and vertical fov 
                -- sensor width and horizontal fov

        // 参数:
        //   fieldOfView:
        //     fov in degrees.
        //
        //   sensorSize:
        //     Sensor size in millimeters.
        //
        // 返回结果:
        //     Focal length in millimeters. 焦距
        */
        [NativeNameAttribute("FieldOfViewToFocalLength_Safe")]
        public static float FieldOfViewToFocalLength(float fieldOfView, float sensorSize);


        /*
            摘要:
            Converts focal length(焦距) to fov
        
        // 参数:
        //   focalLength:
        //     Focal length in millimeters. 焦距, 毫米为单位
        //
        //   sensorSize:
        //     Sensor size in millimeters. 
                Use the sensor height to get the vertical fov;
                Use the sensor width to get the horizontal fov;
        
        // 返回结果:
        //     fov in degrees.
        */
        [NativeNameAttribute("FocalLengthToFieldOfView_Safe")]
        public static float FocalLengthToFieldOfView(float focalLength, float sensorSize);


        /*
            摘要:
            Fills an array of Camera with the current cameras in the Scene, without allocating a new array.

            参数 array 分配的size 不能小于 Camera.allCamerasCount;
            若大于, 尾端不会被写入;
            若不够, 会抛出异常;
            若参数为 null, 会抛出异常;

            返回值:
                向 array 写入了多少个元素;
        
        // 参数:
        //   cameras:
        //     An array to be filled up with cameras currently in the Scene. 输出
        */
        public static int GetAllCameras(Camera[] cameras);


        /*
            摘要:
            Converts the horizontal FOV to the vertical FOV, 
            基于参数 aspectRatio (横纵比,w/h)

        
        // 参数:
        //   horizontalFieldOfView:
        //     The horizontal FOV value in degrees.
        //
        //   aspectRatio:
        //     The aspect ratio value used for the conversion
        */
        [NativeNameAttribute("HorizontalToVerticalFieldOfView_Safe")]
        public static float HorizontalToVerticalFieldOfView(float horizontalFieldOfView, float aspectRatio);

        // 和上一个函数相反
        public static float VerticalToHorizontalFieldOfView(float verticalFieldOfView, float aspectRatio);


        // 官方文档中没提及
        // 也无法才测试中访问此函数
        [FreeFunctionAttribute("CameraScripting::SetupCurrent")]
        public static void SetupCurrent(Camera cur);


        /*
            摘要:
            Add a command buffer to be executed at a specified place.

            Multiple command buffers can be set to execute at the same camera event 
            (or even the same buffer can be added multiple times)
        
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute.
        */
        public void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer);


        /*
            摘要:
            Adds a command buffer to the "GPU's async compute queues" and executes that command
            buffer when graphics processing reaches a given point.
        
            Multiple command buffers can be set to execute at the same camera event 
            (or even the same buffer can be added multiple times).

            在 "async compute queues" 上, command buffer 只能调用以下指令:
            (否则将报错)
            -- CommandBuffer.BeginSample
            -- CommandBuffer.CopyCounterValue
            -- CommandBuffer.CopyTexture
            -- CommandBuffer.CreateGPUFence
            -- CommandBuffer.DispatchCompute
            -- CommandBuffer.EndSample
            -- CommandBuffer.IssuePluginEvent
            -- CommandBuffer.SetComputeBufferParam
            -- CommandBuffer.SetComputeFloatParam
            -- CommandBuffer.SetComputeFloatParams
            -- CommandBuffer.SetComputeTextureParam
            -- CommandBuffer.SetComputeVectorParam
            -- CommandBuffer.WaitOnGPUFence

            此 command buffer 传递的所有 治理, 都被保证在同一个 queue 上执行;
            如果目标平台不支持 async compute queues,
            那么这些工作将被 派遣到 graphics queue;

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
        */
        public void AddCommandBufferAsync(CameraEvent evt, CommandBuffer buffer, ComputeQueueType queueType);


        /*
            此函数自动计算出 4个 rays 方向向量, 从 camera 射向目标平面(比如 far plane) 的四个角落;
            平截头体张开的角度则由第一参数: viewport 来控制;

            4个 rays 顺序为: bottom-left, top-left, top-right, bottom-right;

            计算出的 rays, 位于 camera-space;
                假设 viewport 为 (0,0,1,1) ( full screen)
                且 FOV = 60度, far depth = 1000; 
                则计算出的 rays 会是类似于:
                {
                    { -1026.4, -577.4, 1000 },
                    { -1026.4,  577.4, 1000 },
                    {  1026.4,  577.4, 1000 },
                    {  1026.4, -577.4, 1000 }
                }
                可手工验证上述值;
                ----

                所以, 必须要在此返回值基础上, 累加上 camera 的 posWS 和 朝向,
                才能进一步计算出这四个 ray 的 world-space 空间中的表达;

            可用来高效计算 the posWS of a pixel in an image effect shader. 
            此函数被 built-in 管线用于 fog 计算;

            参数:
            viewport:
                Normalized viewport coordinates to use for the frustum calculation.
                选择屏幕中的哪一块, 选择整个屏幕就写入: x=0,y=0,w=1,h=1
            z:
                Z-depth from the camera origin at which the corners will be calculated.
                射线射到的那个平面, 距离camera 的深度值, 比如 far plane 深度值;
            eye:
                Camera eye projection matrix to use.
                catlike 中选择使用: camera.stereoActiveEye;

            outCorners:
                输出端
                Output array for the frustum corner vectors. Cannot be null and length must be >= 4.
                out rays;


        */
        public void CalculateFrustumCorners(Rect viewport, float z, MonoOrStereoscopicEye eye, Vector3[] outCorners);


        /*
            摘要:
            Calculates and returns oblique near-plane projection matrix.

            Given a clip plane vector, 本函数返回 camera's projection matrix 
            which has this clip plane set as its near plane.

            "Oblique View Frustum":
                近平面是一个自定义的 斜向的面;
                通常使用此技术来克服 平面反射(倒影) 中的一些小bug;
                参见:
                https://blog.csdn.net/a1047120490/article/details/106743734

        // 参数:
        //   clipPlane:
        //     Vector4 that describes a clip plane.  剪切平面
        //
        // 返回结果:
        //     Oblique near-plane projection matrix.
        */
        [FreeFunctionAttribute("CameraScripting::CalculateObliqueMatrix", HasExplicitThis = true)]
        public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane);


        /*
            摘要:
            Makes this camera's settings match other camera.
        
            This will copy all camera's variables:
            (field of view, clear flags, culling mask, ...) from the other camera. 
             
            It will also set this camera's transform to match the other camera, 
            as well as this camera's layer to match the layer of the other camera.

            当使用 Camera.RenderWithShader() 时, 可能会用到本函数

        // 参数:
        //   other:
        //     数据源
        */
        [FreeFunctionAttribute("CameraScripting::CopyFrom", HasExplicitThis = true)]
        public void CopyFrom(Camera other);


        public void CopyStereoDeviceProjectionMatrixToNonJittered(StereoscopicEye eye);// vr


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.DoClear has been deprecated (UnityUpgradable).", true)]
        public void DoClear();
        */


        
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


        /*
            摘要:
            Retrieves the "effective vertical fov" of the camera, including GateFit.
            适配  sensor gate 和 resolution gate 会对最终的 fov 产生影响;
        
            If the "sensor gate 横纵比" 等于 "resolution gate 横纵比", 或者 camera 不在 physical mode,
            则本函数返回的值和 "Camera.fieldOfView" 一样;

        // 返回结果:
        //     Returns the "effective vertical fov"
        */
        public float GetGateFittedFieldOfView();



        /*
            摘要:
            Retrieves the effective lens offset of the camera, including GateFit. 
            适配  sensor gate 和 resolution gate 会对最终的 fov 产生影响;

            if the "sensor gate 横纵比" 等于 "resolution gate 横纵比",
            则本函数返回的值和 "Camera.lensShift" 一样;

            如果 camera 不在 physical mode, 则返回 Vector2.zero.

        // 返回结果:
        //     Returns the "effective lens shift value"
        */
        public Vector2 GetGateFittedLensShift();


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetScreenHeight has been deprecated. Use Screen.height instead (UnityUpgradable) -> System.Int32 Screen.height", true)]
        public float GetScreenHeight();
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetScreenWidth has been deprecated. Use Screen.width instead (UnityUpgradable) -> System.Int32 Screen.width", true)]
        public float GetScreenWidth();
        */


        public Matrix4x4 GetStereoNonJitteredProjectionMatrix(StereoscopicEye eye);// vr


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetStereoProjectionMatrices has been deprecated. Use GetStereoProjectionMatrix(StereoscopicEye eye) instead.", false)]
        public Matrix4x4[] GetStereoProjectionMatrices();
        */


        [FreeFunctionAttribute("CameraScripting::GetStereoProjectionMatrix", HasExplicitThis = true)]
        public Matrix4x4 GetStereoProjectionMatrix(StereoscopicEye eye);// vr


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.GetStereoViewMatrices has been deprecated. Use GetStereoViewMatrix(StereoscopicEye eye) instead.", false)]
        public Matrix4x4[] GetStereoViewMatrices();
        */



        [FreeFunctionAttribute("CameraScripting::GetStereoViewMatrix", HasExplicitThis = true)]
        public Matrix4x4 GetStereoViewMatrix(StereoscopicEye eye);// vr




        // Remove all command buffers set on this camera.
        public void RemoveAllCommandBuffers();



        /*
            摘要:
            Remove command buffer from execution at a specified place.

            If the same buffer is added multiple times on this camera event, 
            all occurrences of it will be removed. (全部被移除)
        
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        //
        //   buffer:
        //     The buffer to execute. 要被移除的
        */
        public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer);


        /*
            摘要:
            Remove command buffers from execution at a specified place.
            This function removes all command buffers set on the specified camera event.
        
        // 参数:
        //   evt:
        //     When to execute the command buffer during rendering.
        */
        public void RemoveCommandBuffers(CameraEvent evt);


        /*
            Render the camera manually.

            This will render the camera. It will use the camera's clear flags, target texture and all other settings.

            The camera will send OnPreCull, OnPreRender and OnPostRender to any scripts attached, 
            and render any eventual image filters.

            这用于精确控制渲染顺序。
            To make use of this feature, create a camera and disable it. Then call Render on it.

            如果一个 camera 正在被渲染(它是启用状态的), 那么你是不能对它调用 本函数的;
            此时你可以新建一个 camera, 调用 camera.CopyFrom() 来复制目标camera 的数据;
            然后把手头的 camera 设置为 disable, 然后调用本函数 手动渲染它;

            建议查看: Camera.RenderWithShader();
        */
        [FreeFunctionAttribute("CameraScripting::Render", HasExplicitThis = true)]
        public void Render();


        // 文档未提及
        [FreeFunctionAttribute("CameraScripting::RenderDontRestore", HasExplicitThis = true)]
        public void RenderDontRestore();


        /*
            摘要:
            Render into a "static" cubemap from this camera.
        
            本函数主要在 editor 中被用于: "baking" static cubemaps of your Scene. 
            (文档提供了一个 代码示范)
            
            If you want a realtime-updated cubemap, 请改用下方 RenderTexture 版本的;

            Camera's position, clear flags and clipping plane distances 
            will be used to render into cubemap faces. 

            一些硬件不支持本函数;

            注意:
                ReflectionProbes 是一种更高效的实现 实时反射的 方法;

            参数:
            cubemap:
                The cube map to render to.
            
            faceMask:
                A bitmask which determines which of the six faces are rendered to.
                Each bit that is set corresponds to a face;
                Bit numbers are integer values of CubemapFace enum.
                By default all six cubemap faces will be rendered 
                (default value 63 has six lowest bits on).
        
        // 返回结果:
        //     False if rendering fails, else true.
        */
        public bool RenderToCubemap(Cubemap cubemap, int faceMask);
        public bool RenderToCubemap(Cubemap cubemap);

        /*
            可以渲染进一个 动态的实时的 cubemap;

            这往往很昂贵, 尤其是当在一帧中集中完成6个面的渲染时;

            注意:
                参数 RenderTexture 的 dimension 必须设置为 Cube 模式. 


            额外参数:
                stereoEye:
                    A Camera eye corresponding to the left or right eye for stereoscopic rendering, 
                    or neither for non-stereoscopic rendering.

                    这个版本有额外的解释, 此处未翻译... 
        */
        public bool RenderToCubemap(RenderTexture cubemap, int faceMask);
        public bool RenderToCubemap(RenderTexture cubemap);
        public bool RenderToCubemap(RenderTexture cubemap, int faceMask, MonoOrStereoscopicEye stereoEye);//vr




        /*
            摘要:
            Render the camera with shader replacement.

            This will render the camera. It will use the camera's clear flags, target texture and all other settings.

            The camera will "not" send OnPreCull, OnPreRender or OnPostRender to attached scripts.
            Image filters will "not: be rendered either.

            本函数用于特殊功能: 
            -- rendering screenspace normal buffer of the whole Scene
            -- heat vision (热视觉)

            To make use of this feature, usually you create a camera and disable it. Then call RenderWithShader on it.

            如果一个 camera 正在被渲染(它是启用状态的), 那么你是不能对它调用 本函数的;
            此时你可以新建一个 camera, 调用 camera.CopyFrom() 来复制目标camera 的数据;
            然后把手头的 camera 设置为 disable, 然后调用本函数 手动渲染它;

        // 参数:
        //   shader:
        //
        //   replacementTag:
        */
        [FreeFunctionAttribute("CameraScripting::RenderWithShader", HasExplicitThis = true)]
        public void RenderWithShader(Shader shader, string replacementTag);



        //     Revert all camera parameters to default.
        public void Reset();


        //  Revert the aspect ratio to the screen's aspect ratio.
        //  Call this to end the effect of setting "Camera.aspect"
        public void ResetAspect();


        //  Make culling queries reflect the camera's built in parameters.
        // 让 culling 查询 返回 camera 的内置参数
        public void ResetCullingMatrix();


        /*
        // 摘要:
        //     Reset to the default field of view.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.ResetFieldOfView has been deprecated in Unity 5.6 and will be removed in the future. Please replace it by explicitly setting the camera's FOV to 60 degrees.", false)]
        public void ResetFieldOfView();
        */



        //     Make the projection reflect normal camera's parameters.
        //  Call this to end the effect of setting "Camera.projectionMatrix"
        public void ResetProjectionMatrix();


        //     Remove shader replacement from camera.
        //  Call this to end the effect of setting "Camera.SetReplacementShader()"
        public void ResetReplacementShader();


        

        //     Reset the camera to using the Unity computed projection matrices for all stereoscopic
        //     eyes.
        public void ResetStereoProjectionMatrices();//vr

        //     Reset the camera to using the Unity computed view matrices for all stereoscopic
        //     eyes.
        public void ResetStereoViewMatrices();// vr


        /*
            摘要:
            Resets this Camera's transparency sort settings to the default. Default transparency
            settings are taken from GraphicsSettings instead of directly from this Camera.

            Once "Camera.transparencySortMode" or "Camera.transparencySortAxis" are called from the script, 
            the rendering pipeline ignores the settings in the GraphicsSettings 
            and takes the settings directly from the Camera.

            Calling this method causes the 管线 to refer to the settings in GraphicsSettings instead of this Camera.
            (本函数也适用于 SceneView Cameras)
        */
        public void ResetTransparencySortSettings();



        //     Make the rendering position reflect the camera's position in the Scene.
        //   Call this to end the effect of setting "Camera.worldToCameraMatrix"
        public void ResetWorldToCameraMatrix();


        /*
            摘要:
             Returns a ray going from camera through a screen point.

             Resulting ray is in world space, starting on the near plane of the camera 
             and going through position's (x,y) pixel coordinates on the screen (position.z is ignored).
        
        
        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default is Mono.
        //
        //   pos:
                猜测是 posSS, 使用了 xy值, z值被忽略;
                Screenspace is defined in pixels. 
                    The bottom-left of the screen is (0,0); 
                    the right-top is (pixelWidth -1,pixelHeight -1).
        */
        public Ray ScreenPointToRay(Vector3 pos);
        public Ray ScreenPointToRay(Vector3 pos, MonoOrStereoscopicEye eye);//vr


        /*
            摘要:
            Transforms position from screen-space into viewport-space.

            Screenspace is defined in pixels. 
                The bottom-left of the screen is (0,0); 
                the right-top is (pixelWidth,pixelHeight). 
                The z position is in world units from the camera.

            Viewport space is normalized and relative to the camera. 
                The bottom-left of the camera is (0,0); 
                the top-right is (1,1). 
                The z position is in world units from the camera.


        // 参数:
        //   position:
                posSS, 具体描述如上;
        */
        public Vector3 ScreenToViewportPoint(Vector3 position);


        /*
            摘要:
            Transforms a point from screen-space into world-space, 
           
            World space coordinates can still be calculated even when provided as an off-screen coordinate, 
            for example for instantiating an off-screen object near a specific corner of the screen.
            ---
            就算传入一个 离屏 参数posSS, 也能计算出对应的 posWS; 不一定要在 屏幕范围内;

            Screenspace is defined in pixels. 
                The bottom-left of the screen is (0,0); 
                the right-top is (pixelWidth,pixelHeight). 
                The z position is in world units from the camera.


        // 参数:
        //   position:
        //      posSS (often mouse x, y), 
                plus a z position for depth (for example, a camera clipping plane).
        
        //   eye:
        //     By default, Camera.MonoOrStereoscopicEye.Mono. Can be set to Camera.MonoOrStereoscopicEye.Left
        //     or Camera.MonoOrStereoscopicEye.Right for use in stereoscopic rendering (e.g.,
        //     for VR).
        //
        // 返回结果:
        //     The posWS created by converting the posSS at the provided distance z from the camera plane.
        */
        public Vector3 ScreenToWorldPoint(Vector3 position);
        public Vector3 ScreenToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye);//vr



        /*
            摘要:
            Make the camera render with shader replacement.

            调用本函数后, camera 会使用替换的 shader 来执行渲染;

            Call "Camera.ResetReplacementShader()" to reset it back to normal rendering.

        // 参数:
        //   shader:
        //
        //   replacementTag:
        */
        public void SetReplacementShader(Shader shader, string replacementTag);


        /*
        // 摘要:
        //     Sets custom projection matrices for both the left and right stereoscopic eyes.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.SetStereoProjectionMatrices has been deprecated. Use SetStereoProjectionMatrix(StereoscopicEye eye) instead.", false)]
        public void SetStereoProjectionMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix);
        */


        public void SetStereoProjectionMatrix(StereoscopicEye eye, Matrix4x4 matrix);//vr


        /*
        // 摘要:
        //     Set custom view matrices for both eyes.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Camera.SetStereoViewMatrices has been deprecated. Use SetStereoViewMatrix(StereoscopicEye eye) instead.", false)]
        public void SetStereoViewMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix);
        */


        public void SetStereoViewMatrix(StereoscopicEye eye, Matrix4x4 matrix);// vr


        /*
            摘要:
            Sets the Camera to render to the chosen buffers of one or more RenderTextures.

            设置本camera 的 颜色信息, depth信息, 要渲染到哪些 rendertexture 上去;
        
            参数:
            colorBuffer:
                The RenderBuffer(s) to which color information will be rendered.
                将本 camera 的颜色信息 渲染到这些 buffer 上去 (代表 1 或 数个 rendertexture)
        
            depthBuffer:
                The RenderBuffer to which depth information will be rendered.
                将本 camera 的 depth 信息 渲染到这个 buffer 上去 (代表 1 个 rendertexture)
        */
        public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer);
        public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer);


        /*
            Submit a number of Camera.RenderRequests.
            This function will only work properly when using a srp.
        */
        public void SubmitRenderRequests(List<RenderRequest> renderRequests);


        /*
            Get culling parameters for a camera.

            参数:
            cullingParameters:
                Resultant culling parameters.  输出端;
               

            stereoAware:
                Generate single-pass stereo aware culling parameters.

                Both left and right stereo eyes are considered in the generated culling parameters 
                when stereoAware is true and single-pass stereo is enabled.

            返回值:
                bool Flag indicating whether culling parameters are valid.
                Returns false if camera is invalid to render 
                (empty viewport rectangle, invalid clip plane setup etc.).
        */
        public bool TryGetCullingParameters(out ScriptableCullingParameters cullingParameters);
        public bool TryGetCullingParameters(bool stereoAware, out ScriptableCullingParameters cullingParameters);
        


        /*
            摘要:
            Returns a ray going from camera through a viewport point.
        
            Resulting ray is in world space, starting on the near plane of the camera 
            and going through position's (x,y) coordinates on the viewport (position.z is ignored).

            Viewport coordinates are normalized and relative to the camera. 
            -- The bottom-left of the camera is (0,0); 
            -- the top-right is (1,1).

        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   pos:
                pos-Viewport, 
        */
        public Ray ViewportPointToRay(Vector3 pos);
        public Ray ViewportPointToRay(Vector3 pos, MonoOrStereoscopicEye eye);//vr


        /*
            摘要:
            Transforms position from viewport-space into screen-space.
        
            Viewport space is normalized and relative to the camera. 
            -- The bottom-left of the camera is (0,0); 
            -- the top-right is (1,1). 
            -- The z position is in world units from the camera.

            Screenspace is defined in pixels. 
            -- The bottom-left of the screen is (0,0); 
            -- the right-top is (pixelWidth,pixelHeight). 
            -- The z position is in world units from the camera.

        // 参数:
        //   position: pos-Viewport
        */
        public Vector3 ViewportToScreenPoint(Vector3 position);


        /*
            摘要:
            Transforms position from viewport space into world space.
        
            Viewport space is normalized and relative to the camera. 
            -- The bottom-left of the viewport is (0,0); 
            -- the top-right is (1,1). 
            -- The z position is in world units from the camera.

            Note that "Camera.ViewportToWorldPoint" transforms an x-y screen position into a x-y-z position in 3D space.

            Provide the function with a vector where the x-y components are the screen coordinates 
            and the z component is the distance of the resulting plane from the camera.

        // 参数:
        //   position:
        //     The 3d vector in Viewport space.
        //
        // 返回结果:
        //     The 3d vector in World space.
        */
        public Vector3 ViewportToWorldPoint(Vector3 position);
        public Vector3 ViewportToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye);//vr
        

        /*
            摘要:
            Transforms position from world space into screen space.
        
            Screenspace is defined in pixels. 
            -- The bottom-left of the screen is (0,0); 
            -- the right-top is (pixelWidth,pixelHeight). 
            -- The z position is in world units from the camera.

        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   position:
        */
        public Vector3 WorldToScreenPoint(Vector3 position);
        public Vector3 WorldToScreenPoint(Vector3 position, MonoOrStereoscopicEye eye);//vr

        
        /*
            摘要:
            Transforms position from world space into viewport space.
        
            Viewport space is normalized and relative to the camera. 
            -- The bottom-left of the camera is (0,0); 
            -- the top-right is (1,1). 
            -- The z position is in world units from the camera.

        // 参数:
        //   eye:
        //     Optional argument that can be used to specify which eye transform to use. Default
        //     is Mono.
        //
        //   position:
        */
        public Vector3 WorldToViewportPoint(Vector3 position);
        public Vector3 WorldToViewportPoint(Vector3 position, MonoOrStereoscopicEye eye);//vr



        /*
            摘要:
            Enum used to specify how the sensor gate (sensor frame) defined by Camera.sensorSize
            fits into the resolution gate (render frame).

            定义了 sensor gate 是如何适配到 resolution gate 的;
        */
        public enum GateFitMode
        {
            
            //  Stretch the sensor gate to fit exactly into the resolution gate.
            //  拉伸 resolution gate, 让它的长宽完全等于 resolution gate 的长宽;
            None = 0,
            
            //  Fit the resolution gate "vertically" within the sensor gate.
            //  猜测: 让 resolution gate 的 高度 等同于 sensor gate 的;
            Vertical = 1,
            
            //  Fit the resolution gate "horizontally" within the sensor gate.
            //  猜测: 让 resolution gate 的 宽度 等同于 sensor gate 的;
            Horizontal = 2,
            
            //  Automatically selects a horizontal or vertical fit so that the "sensor gate" fits
            //  completely inside the resolution gate.
            //  resolution gate 完全位于 sensor gate 体内, 且尺寸最大;
            Fill = 3,
            
            //  Automatically selects a horizontal or vertical fit so that the "render frame" fits
            //  completely inside the resolution gate.
            //  没看懂... 
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
        public enum StereoscopicEye//vr
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
        public enum MonoOrStereoscopicEye//vr
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



        /*
            Modes available for submitting when making a render request.
        */
        public enum RenderRequestMode
        {
            
            //     Default value for a request.
            // Outputs a buffer that has no defined value.
            None = 0,
            
            //     The render request outputs an object InstanceID buffer.
            //  Outputs a buffer that maps the the UnityEngine.Object.GetInstanceID() at each pixel.
            ObjectId = 1,
            
            //     The render request outputs a depth value.
            //  Outputs a buffer that maps the the depth value at each pixel. 
            //  The buffer will be generated from the camera used in the request.
            Depth = 2,

            /*
                The render request outputs the interpolated vertex normal.

                It outputs a buffer that maps the the vertex normalWS (不是法线贴图)) at each pixel. 
                The normal is stored as an rgb value, packed to 0...1 range. 
                Alpha is undefined. 
                It can be unpacked using normal = packedNormal * 2.0F - 1.0F. 
                The buffer will be generated from the camera used in the request.
            */
            VertexNormal = 3,

            /*
                The render request outputs a world position buffer.

                Outputs a buffer that maps the the WorldPosition (RGB) at each pixel. 
                    Alpha=1 means the position is valid. 
                    Alpha=0 means it is invalid. 
                    
                GraphicsFormat.R32G32B32A32_SFloat is recommended as the render texture format.
            */
            WorldPosition = 4,

            /*
                The render request outputs an entity id.

                Outputs a buffer that maps the the "DOTS entity ID" at each pixel. 
                The buffer will be generated from the camera used in the request.
            */
            EntityId = 5,

            /*
                The render request outputs the materials albedo / base color.

                Outputs a buffer that maps the "albedo / base RGB color" at each pixel. 
                Alpha is undefined. 
                该值将与 metallic workflow 中的 PBR Base Color 匹配，与 material or shader 无关。
                The buffer will be generated from the camera used in the request.
            */
            BaseColor = 6,

            /*
                The render request returns the materials specular color buffer.

                Outputs a buffer that maps the specular RGB color at each pixel. Alpha is undefined. 
                该值将与 specular workflow 中的 PBR Base Color 匹配，与 material or shader 无关。
                The buffer will be generated from the camera used in the request.
            */
            SpecularColor = 7,

            /*
                The render outputs the materials metal value.

                Outputs a buffer that maps the materials metallic value to a grayscale RGB value at each pixel. 
                Alpha is undefined. 
                该值将与 metallic workflow 中的 PBR Base Color 匹配，与 material or shader 无关。
                The buffer will be generated from the camera used in the request.
            */
            Metallic = 8,

            /*
                The render request outputs the materials emission value.

                Outputs a buffer that maps the materials RGB emission color at each pixel. 
                Alpha is undefined. 
                The buffer will be generated from the camera used in the request.
            */
            Emission = 9,

            /*
                The render request outputs the per pixel normal.

                Outputs a buffer that maps the the normalWS (including normal map) at each pixel. 
                The normal is stored as an rgb value, packed to 0...1 range. 
                It can be unpacked using normal = packedNormal * 2.0F - 1.0F. 
                Alpha is undefined. 
                The buffer will be generated from the camera used in the request.
            */
            Normal = 10,

            /*
                The render request returns the materials smoothness buffer.

                Outputs a buffer that maps the material smoothness value of the material 
                to a grayscale RGB value at each pixel. Alpha is undefined. 
                The buffer will be generated from the camera used in the request.
            */
            Smoothness = 11,

            /*
                The render request returns the material ambient occlusion buffer.

                Outputs a buffer that maps the ambient occlusion value of the material 
                to a grayscale RGB value at each pixel. Alpha is undefined. 
                The buffer will be generated from the camera used in the request.
            */
            Occlusion = 12,

            /*
                The render request outputs the materials diffuse color.

                Outputs a buffer that maps the diffuse RGB color at each pixel. Alpha is undefined. 
                该值将与 specular workflow 中的 PBR Diffuse Color 匹配，与 material or shader 无关。
                The buffer will be generated from the camera used in the request.
            */
            DiffuseColor = 13
        }

        /*
            Defines in which space render requests will be be outputted.
            Default is ScreenSpace, but it is also possible to output in UV space.
        */
        public enum RenderRequestOutputSpace
        {
            //     RenderRequests will be rendered in screenspace from the perspective of the camera.
            ScreenSpace = -1,
            //     RenderRequests will be outputted in UV 0 space of the rendered mesh.
            UV0 = 0,
            //     RenderRequests will be outputted in UV 1 space of the rendered mesh.
            UV1 = 1,
            //     RenderRequests will be outputted in UV 2 space of the rendered mesh.
            UV2 = 2,
            //     RenderRequests will be outputted in UV 3 space of the rendered mesh.
            UV3 = 3,
            //     RenderRequests will be outputted in UV 4 space of the rendered mesh.
            UV4 = 4,
            //     RenderRequests will be outputted in UV 5 space of the rendered mesh.
            UV5 = 5,
            //     RenderRequests will be outputted in UV 6 space of the rendered mesh.
            UV6 = 6,
            //     RenderRequests will be outputted in UV 7 space of the rendered mesh.
            UV7 = 7,
            //     RenderRequests will be outputted in UV 8 space of the rendered mesh.
            UV8 = 8
        }


        //     Wrapper for gate fit parameters
        public struct GateFitParameters
        {
            public GateFitParameters(GateFitMode mode, float aspect);

            //     GateFitMode to use
            public GateFitMode mode { readonly get; set; }
        
            //     Aspect ratio (横纵比,w/h) of the resolution gate.
            public float aspect { readonly get; set; }
        }



        /*
            A request that can be used for making specific rendering requests.

            You can use a RenderRequest and Camera.ProcessRenderRequests() 
            to request a specific set of RenderRexture resuls. 
            
            This is useful for custom scene tooling and baking.
        */
        public struct RenderRequest
        {
            public RenderRequest(RenderRequestMode mode, RenderTexture rt);
            public RenderRequest(RenderRequestMode mode, RenderRequestOutputSpace space, RenderTexture rt);

            //     Is this request properly formed. 此请求的格式是否正确。
            public bool isValid { get; }
            
            //     The type of request.
            public RenderRequestMode mode { get; }
            
            //     The result of the request.
            // When the request is submitted this render texture will have the reult.
            public RenderTexture result { get; }

            //     Defines in which space render requests will be be outputted.
            //  Default is ScreenSpace, but it is also possible to output in UV space.
            public RenderRequestOutputSpace outputSpace { get; }
        }



        
        // 摘要:
        //     Delegate type for camera callbacks.
        public delegate void CameraCallback(Camera cam);
    }
}