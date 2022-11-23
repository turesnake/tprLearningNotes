#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor
{
    //
    // 摘要:
    //     Use this class to manage SceneView settings, change the SceneView camera properties,
    //     subscribe to events, call SceneView methods, and render open scenes.
    [EditorWindowTitle(title = "Scene", useTypeNameAsIconName = true)]
    public class SceneView : SearchableEditorWindow, IHasCustomMenu, ISupportsOverlays
    {
        //
        // 摘要:
        //     Register to this callback to get notified when the active Scene View changes.
        public static Action<SceneView, SceneView> lastActiveSceneViewChanged;

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("onSceneGUIDelegate has been deprecated. Use duringSceneGui instead.")]
        // public static OnSceneFunc onSceneGUIDelegate;

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("m_SceneLighting has been deprecated. Use sceneLighting instead (UnityUpgradable) -> UnityEditor.SceneView.sceneLighting", true)]
        // public bool m_SceneLighting;

        //
        // 摘要:
        //     M_AudioPlay has been deprecated. Use audioPlay instead (UnityUpgradable) -> audioPlay.
        // [Obsolete("m_AudioPlay has been deprecated. Use audioPlay instead (UnityUpgradable) -> audioPlay", true)]
        // public bool m_AudioPlay;

        //
        // 摘要:
        //     M_RenderMode has been deprecated. Use cameraMode instead.
        // [Obsolete("Use cameraMode instead", false)]
        // public DrawCameraMode m_RenderMode;

        //
        // 摘要:
        //     M_ValidateTrueMetals has been deprecated. Use validateTrueMetals instead (UnityUpgradable)
        //     -> validateTrueMetals.
        // [Obsolete("m_ValidateTrueMetals has been deprecated. Use validateTrueMetals instead (UnityUpgradable) -> validateTrueMetals", true)]
        // public bool m_ValidateTrueMetals;


        public SceneView();

        //
        // 摘要:
        //     Gets the Color of selected outline.
        public static Color selectedOutlineColor { get; }
        //
        // 摘要:
        //     The SceneView that is being drawn.
        public static SceneView currentDrawingSceneView { get; }
        //
        // 摘要:
        //     The SceneView that was most recently in focus.
        public static SceneView lastActiveSceneView { get; }
        //
        // 摘要:
        //     The list of all open Scene view windows.
        public static ArrayList sceneViews { get; }
        //
        // 摘要:
        //     Whether the albedo is black for materials with an average specular color above
        //     0.45.
        public bool validateTrueMetals { get; set; }
        //
        // 摘要:
        //     Gets or sets whether to enable the grid for an instance of the SceneView.
        public bool showGrid { get; set; }
        //
        // 摘要:
        //     Use CameraSettings to set the properties for the SceneView Camera.
        public CameraSettings cameraSettings { get; set; }
        //
        // 摘要:
        //     When the Scene view is in 2D mode, this property contains the last camera rotation.
        public Quaternion lastSceneViewRotation { get; set; }
        //
        // 摘要:
        //     The distance from camera to pivot.
        public float cameraDistance { get; }

        //
        // 摘要:
        //     RenderMode has been deprecated. Use cameraMode instead.
        // [Obsolete("Use cameraMode instead", false)]
        // public DrawCameraMode renderMode { get; set; }

        //
        // 摘要:
        //     Enables or disables Scene view audio effects.
        public bool audioPlay { get; set; }
        //
        // 摘要:
        //     The Camera that is rendering this SceneView.
        public Camera camera { get; }
        //
        // 摘要:
        //     Use SceneViewState to set the debug options for the Scene view.
        public SceneViewState sceneViewState { get; set; }
        //
        // 摘要:
        //     The central point that the camera orbits within the Scene view.
        public Vector3 pivot { get; set; }
        //
        // 摘要:
        //     The size of the Scene view measured diagonally.
        public float size { get; set; }
        //
        // 摘要:
        //     Whether the Scene view camera can be rotated.
        public bool isRotationLocked { get; set; }
        //
        // 摘要:
        //     Whether the Scene view camera is set to orthographic mode.
        public bool orthographic { get; set; }
        //
        // 摘要:
        //     Whether the SceneView is in 2D mode.
        public bool in2DMode { get; set; }
        //
        // 摘要:
        //     Whether lighting is enabled or disabled in the Scene view.
        public bool sceneLighting { get; set; }
        //
        // 摘要:
        //     Whether this SceneView is using scene filtering.
        public bool isUsingSceneFiltering { get; }
        //
        // 摘要:
        //     Sets the visibility of all Gizmos in the Scene view.
        public bool drawGizmos { get; set; }
        //
        // 摘要:
        //     The direction of the camera to the pivot of the SceneView.
        public Quaternion rotation { get; set; }
        //
        // 摘要:
        //     The current DrawCameraMode for the Scene view camera.
        public CameraMode cameraMode { get; set; }
        protected internal Transform customParentForDraggedObjects { get; set; }
        protected internal Scene customScene { get; set; }

        public static event Action<SceneView> duringSceneGui;
        public static event Action<SceneView> beforeSceneGui;
        public event Action<bool> gridVisibilityChanged;
        public event Action<CameraMode> onCameraModeChanged;
        public event Func<CameraMode, bool> onValidateCameraMode;

        //
        // 摘要:
        //     Add a custom camera mode to the Scene view camera mode list.
        //
        // 参数:
        //   name:
        //     The name for the new mode.
        //
        //   section:
        //     The section in which the new mode will be added. This can be an existing or new
        //     section.
        //
        // 返回结果:
        //     A CameraMode with the provided name and section.
        public static CameraMode AddCameraMode(string name, string section);
        //
        // 摘要:
        //     Remove all user-defined camera modes.
        public static void ClearUserDefinedCameraModes();
        //
        // 摘要:
        //     Frames the currently selected object(s) in the last active Scene view.
        //
        // 返回结果:
        //     Returns true if the camera frame successfully frames the current selection.
        [RequiredByNativeCodeAttribute]
        public static bool FrameLastActiveSceneView();
        [RequiredByNativeCodeAttribute]
        public static bool FrameLastActiveSceneViewWithLock();
        //
        // 摘要:
        //     Retrieves an array of all camera components from all open Scene views.
        //
        // 返回结果:
        //     Returns an array of camera components.
        public static Camera[] GetAllSceneCameras();
        //
        // 摘要:
        //     Gets the built-in CameraMode that matches the specified DrawCameraMode.
        //
        // 参数:
        //   mode:
        //     The DrawCameraMode to match.
        //
        // 返回结果:
        //     Returns a built-in CameraMode.
        public static CameraMode GetBuiltinCameraMode(DrawCameraMode mode);
        //
        // 摘要:
        //     Repaints every open SceneView.
        public static void RepaintAll();
        public virtual void AddItemsToMenu(GenericMenu menu);
        //
        // 摘要:
        //     Moves the Scene view to frame a transform.
        //
        // 参数:
        //   t:
        //     The transform to frame in the Scene view.
        public void AlignViewToObject(Transform t);
        //
        // 摘要:
        //     Aligns the current selection with the position and rotation of the Scene view
        //     camera.
        public void AlignWithView();
        public void FixNegativeSize();
        public bool Frame(Bounds bounds, bool instant = true);
        public virtual bool FrameSelected(bool lockView, bool instant);
        //
        // 摘要:
        //     Frame the object selection in the Scene view.
        //
        // 参数:
        //   lockView:
        //     Whether the view should be locked to the selection.
        //
        // 返回结果:
        //     Returns true if the current selection fits in the Scene view. Returns false otherwise.
        public bool FrameSelected(bool lockView);
        //
        // 摘要:
        //     Frame the object selection in the Scene view.
        //
        // 参数:
        //   lockView:
        //     Whether the view should be locked to the selection.
        //
        // 返回结果:
        //     Returns true if the current selection fits in the Scene view. Returns false otherwise.
        public bool FrameSelected();
        public bool IsCameraDrawModeEnabled(CameraMode mode);
        public bool IsCameraDrawModeSupported(CameraMode mode);
        //
        // 摘要:
        //     Moves the Scene view to focus on a target.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction that the Scene view should view the target point from.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        //
        //   ortho:
        //     Whether the camera focus is in orthographic mode (true) or perspective mode (false).
        //
        //   instant:
        //     Apply the movement immediately (true) or animate the transition (false).
        public void LookAt(Vector3 point, Quaternion direction, float newSize, bool ortho, bool instant);
        //
        // 摘要:
        //     Moves the Scene view to focus on a target.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction that the Scene view should view the target point from.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        //
        //   ortho:
        //     Whether the camera focus is in orthographic mode (true) or perspective mode (false).
        //
        //   instant:
        //     Apply the movement immediately (true) or animate the transition (false).
        public void LookAt(Vector3 point, Quaternion direction, float newSize, bool ortho);
        //
        // 摘要:
        //     Moves the Scene view to focus on a target.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction that the Scene view should view the target point from.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        //
        //   ortho:
        //     Whether the camera focus is in orthographic mode (true) or perspective mode (false).
        //
        //   instant:
        //     Apply the movement immediately (true) or animate the transition (false).
        public void LookAt(Vector3 point);
        //
        // 摘要:
        //     Moves the Scene view to focus on a target.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction that the Scene view should view the target point from.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        //
        //   ortho:
        //     Whether the camera focus is in orthographic mode (true) or perspective mode (false).
        //
        //   instant:
        //     Apply the movement immediately (true) or animate the transition (false).
        public void LookAt(Vector3 point, Quaternion direction, float newSize);
        //
        // 摘要:
        //     Moves the Scene view to focus on a target.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction that the Scene view should view the target point from.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        //
        //   ortho:
        //     Whether the camera focus is in orthographic mode (true) or perspective mode (false).
        //
        //   instant:
        //     Apply the movement immediately (true) or animate the transition (false).
        public void LookAt(Vector3 point, Quaternion direction);
        //
        // 摘要:
        //     .LookAt without animating the scene movement.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction from which the Scene view should view the point.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        public void LookAtDirect(Vector3 point, Quaternion direction);
        //
        // 摘要:
        //     .LookAt without animating the scene movement.
        //
        // 参数:
        //   point:
        //     The position in world space to frame.
        //
        //   direction:
        //     The direction from which the Scene view should view the point.
        //
        //   newSize:
        //     The amount of camera zoom. Sets size.
        public void LookAtDirect(Vector3 point, Quaternion direction, float newSize);
        //
        // 摘要:
        //     Transforms all selected object to the scene pivot.
        //
        // 参数:
        //   target:
        //     A transform to place at the scene pivot.
        public void MoveToView();
        //
        // 摘要:
        //     Transforms all selected object to the scene pivot.
        //
        // 参数:
        //   target:
        //     A transform to place at the scene pivot.
        public void MoveToView(Transform target);
        public void OnDestroy();
        public override void OnDisable();
        public override void OnEnable();
        //
        // 摘要:
        //     Resets the CameraSettings for the SceneView Camera to default.
        public void ResetCameraSettings();
        //
        // 摘要:
        //     Sets a replacement shader for rendering this Scene view.
        //
        // 参数:
        //   shader:
        //     The replacement shader.
        //
        //   replaceString:
        //     The replacement shader tag.
        public void SetSceneViewShaderReplace(Shader shader, string replaceString);

        // [Obsolete("OnGUI has been deprecated. Use OnSceneGUI instead.")]
        // protected virtual void OnGUI();

        protected virtual void OnSceneGUI();
        //
        // 摘要:
        //     Override this method to control whether the Scene view should change when you
        //     switch from one stage to another stage.
        //
        // 返回结果:
        //     True if the Scene view automatically reacts to stage changes.
        protected virtual bool SupportsStageHandling();

        //
        // 摘要:
        //     Describes a built-in Scene view mode.
        public struct CameraMode
        {
            //
            // 摘要:
            //     The CameraDrawMode associated with the CameraMode.
            public DrawCameraMode drawMode;
            //
            // 摘要:
            //     The name of the CameraMode.
            public string name;
            //
            // 摘要:
            //     The section in the toolbar drop-down that this CameraMode belongs to.
            public string section;

            //
            // 摘要:
            //     Compares this CameraMode object against a specified CameraMode object.
            //
            // 参数:
            //   otherObject:
            //     The CameraMode to compare.
            //
            // 返回结果:
            //     Returns true if the CameraMode objects are equal. Returns false otherwise.
            public override bool Equals(object otherObject);
            public override int GetHashCode();
            //
            // 摘要:
            //     Gets a string summary of this CameraMode.
            public override string ToString();

            public static bool operator ==(CameraMode a, CameraMode z);
            public static bool operator !=(CameraMode a, CameraMode z);
        }

        //
        // 摘要:
        //     A collection of graphic settings for this SceneView. All graphic settings are
        //     boolean.
        public class SceneViewState
        {
            //
            // 摘要:
            //     Whether fog rendering is enabled in this SceneView.
            public bool showFog;
            //
            // 摘要:
            //     Whether the skybox rendering is enabled in this SceneView.
            public bool showSkybox;
            //
            // 摘要:
            //     Whether lens flare rendering is enabled in this SceneView.
            public bool showFlares;
            //
            // 摘要:
            //     Whether image effects (post processing) rendering is enabled in this SceneView.
            public bool showImageEffects;
            //
            // 摘要:
            //     Whether particle systems rendering is enabled in this SceneView.
            public bool showParticleSystems;
            //
            // 摘要:
            //     Whether visual effect graphs rendering is enabled in this SceneView.
            public bool showVisualEffectGraphs;

            //
            // 摘要:
            //     Creates a new SceneViewState with either default values or values from another
            //     SceneViewState.
            //
            // 参数:
            //   other:
            //     Specify a SceneViewState to copy values from when creating the new SceneViewState.
            //     If this param is not specified, the new SceneViewState is created with default
            //     values.
            public SceneViewState();
            public SceneViewState(SceneViewState other);

            //
            // 摘要:
            //     Whether visual effect graphs render in this SceneView.
            public bool visualEffectGraphsEnabled { get; }
            //
            // 摘要:
            //     Whether particle systems render in this SceneView.
            public bool particleSystemsEnabled { get; }
            //
            // 摘要:
            //     Whether image effects (post processing) render in this SceneView.
            public bool imageEffectsEnabled { get; }
            //
            // 摘要:
            //     Whether lens flares render in this SceneView.
            public bool flaresEnabled { get; }
            //
            // 摘要:
            //     Whether the skybox renders in this SceneView.
            public bool skyboxEnabled { get; }
            //
            // 摘要:
            //     Whether to redraw SceneView at a fixed interval.
            public bool alwaysRefreshEnabled { get; }

            //
            // 摘要:
            //     Whether animated materials rendering is enabled in this SceneView.
            // [EditorBrowsable(EditorBrowsableState.Never)]
            // [Obsolete("Obsolete msg (UnityUpgradable) -> alwaysRefresh")]
            // public bool showMaterialUpdate { get; set; }

            //
            // 摘要:
            //     Whether fog renders in this SceneView.
            public bool fogEnabled { get; }
            //
            // 摘要:
            //     Whether to redraw SceneView at a fixed interval.
            public bool alwaysRefresh { get; set; }
            //
            // 摘要:
            //     Whether all graphic settings are enabled for this SceneViewState.
            public bool allEnabled { get; }

            //
            // 摘要:
            //     Whether animated materials render in this SceneView.
            // [EditorBrowsable(EditorBrowsableState.Never)]
            // [Obsolete("Obsolete msg (UnityUpgradable) -> alwaysRefreshEnabled")]
            // public bool materialUpdateEnabled { get; }

            //
            // 摘要:
            //     Whether to render (when enabled) effects in this SceneView.
            public bool fxEnabled { get; set; }

            // [Obsolete("IsAllOn() has been deprecated. Use allEnabled instead (UnityUpgradable) -> allEnabled")]
            // public bool IsAllOn();

            //
            // 摘要:
            //     Sets all graphic settings, for this SceneViewState, to either true or false.
            //
            // 参数:
            //   value:
            //     The new value for all graphic settings in this SceneViewState. Possible values
            //     are true or false.
            public void SetAllEnabled(bool value);

            // [Obsolete("Toggle() has been deprecated. Use SetAllEnabled() instead (UnityUpgradable) -> SetAllEnabled(*)")]
            // public void Toggle(bool value);

        }
        //
        // 摘要:
        //     Use this class to set SceneView Camera properties.
        public class CameraSettings
        {
            //
            // 摘要:
            //     Create a new CameraSettings object.
            public CameraSettings();

            //
            // 摘要:
            //     The speed of the SceneView Camera.
            public float speed { get; set; }
            //
            // 摘要:
            //     The normalized speed of the SceneView Camera, relative to the current minimum/maximum
            //     range. Valid values are between [0, 1].
            public float speedNormalized { get; set; }
            //
            // 摘要:
            //     The minimum speed of the SceneView Camera. Valid values are between [0.0001,
            //     9999].
            public float speedMin { get; set; }
            //
            // 摘要:
            //     The maximum speed of the SceneView Camera. Valid values are between [0.0002,
            //     10000].
            public float speedMax { get; set; }
            //
            // 摘要:
            //     Enables Camera movement easing in the SceneView. This makes the Camera ease in
            //     when it starts moving, and ease out when it stops.
            public bool easingEnabled { get; set; }
            //
            // 摘要:
            //     How long it takes for the speed of the SceneView Camera to accelerate to its
            //     initial full speed. Measured in seconds. Valid values are between [0.1, 2].
            public float easingDuration { get; set; }
            //
            // 摘要:
            //     Enables Camera movement acceleration in the SceneView. This makes the Camera
            //     accelerate for the duration of movement.
            public bool accelerationEnabled { get; set; }
            //
            // 摘要:
            //     The height of the view angle for the SceneView Camera. Measured in degrees vertically,
            //     or along the local Y axis.
            public float fieldOfView { get; set; }
            //
            // 摘要:
            //     The closest point to the SceneView Camera where drawing occurs. The valid minimum
            //     value is 0.01.
            public float nearClip { get; set; }
            //
            // 摘要:
            //     The furthest point from the SceneView Camera that drawing occurs. The valid minimum
            //     value is 0.02.
            public float farClip { get; set; }
            //
            // 摘要:
            //     When enabled, the SceneView Camera's near and far clipping planes are calculated
            //     relative to the viewport size of the Scene. When disabled, nearClip and farClip
            //     are used instead.
            public bool dynamicClip { get; set; }
            //
            // 摘要:
            //     Enables occlusion culling in the SceneView. This prevents Unity from rendering
            //     GameObjects that the Camera cannot see because they are hidden by other GameObjects.
            public bool occlusionCulling { get; set; }
        }

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("OnSceneFunc() has been deprecated. Use System.Action instead.")]
        // public delegate void OnSceneFunc(SceneView sceneView);

    }
}

