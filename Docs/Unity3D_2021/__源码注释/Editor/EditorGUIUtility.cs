#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Internal;

namespace UnityEditor
{
    //
    // 摘要:
    //     Miscellaneous helper stuff for EditorGUI.
    [NativeHeaderAttribute("Runtime/Graphics/RenderTexture.h")]
    [NativeHeaderAttribute("Modules/TextRendering/Public/Font.h")]
    [NativeHeaderAttribute("Editor/Src/Utility/EditorGUIUtility.h")]
    [NativeHeaderAttribute("Editor/Src/EditorResources.h")]
    [NativeHeaderAttribute("Runtime/Graphics/Texture2D.h")]
    public sealed class EditorGUIUtility : GUIUtility
    {
        [Obsolete("This field is no longer used by any builtin controls. If passing this field to GetControlID, explicitly use the FocusType enum instead.", false)]
        public static FocusType native;

        public EditorGUIUtility();

        //
        // 摘要:
        //     The width in pixels reserved for labels of Editor GUI controls.
        public static float labelWidth { get; set; }
        //
        // 摘要:
        //     The minimum width in pixels reserved for the fields of Editor GUI controls.
        public static float fieldWidth { get; set; }
        //
        // 摘要:
        //     Get a white texture.
        public static Texture2D whiteTexture { get; }
        //
        // 摘要:
        //     The system copy buffer.
        public static string systemCopyBuffer { get; set; }
        //
        // 摘要:
        //     The scale of GUI points relative to screen pixels for the current view This value
        //     is the number of screen pixels per point of interface space. For instance, 2.0
        //     on retina displays. Note that the value may differ from one view to the next
        //     if the views are on monitors with different UI scales.
        public static float pixelsPerPoint { get; }
        //
        // 摘要:
        //     Get the height used by default for vertical spacing between controls.
        public static float standardVerticalSpacing { get; }
        //
        // 摘要:
        //     Is the user currently using the pro skin? (Read Only)
        public static bool isProSkin { get; }
        //
        // 摘要:
        //     Get the height used for a single Editor control such as a one-line EditorGUI.TextField
        //     or EditorGUI.Popup.
        public static float singleLineHeight { get; }
        //
        // 摘要:
        //     Is a text field currently editing text?
        public static bool editingTextField { get; set; }
        //
        // 摘要:
        //     True if a text field currently has focused and the text in it is selected.
        public static bool textFieldHasSelection { get; }
        //
        // 摘要:
        //     Is the Editor GUI is hierarchy mode?
        public static bool hierarchyMode { get; set; }
        //
        // 摘要:
        //     Is the Editor GUI currently in wide mode?
        public static bool wideMode { get; set; }
        //
        // 摘要:
        //     The width of the GUI area for the current EditorWindow or other view. This Property
        //     should only be accessed within an OnGUI call.
        public static float currentViewWidth { get; }

        //
        // 摘要:
        //     Add a custom mouse pointer to a control.
        //
        // 参数:
        //   position:
        //     The rectangle the control should be shown within.
        //
        //   mouse:
        //     The mouse cursor to use.
        //
        //   controlID:
        //     ID of a target control.
        public static void AddCursorRect(Rect position, MouseCursor mouse, int controlID);
        //
        // 摘要:
        //     Add a custom mouse pointer to a control.
        //
        // 参数:
        //   position:
        //     The rectangle the control should be shown within.
        //
        //   mouse:
        //     The mouse cursor to use.
        //
        //   controlID:
        //     ID of a target control.
        public static void AddCursorRect(Rect position, MouseCursor mouse);
        //
        // 摘要:
        //     Creates an event that can be sent to another window.
        //
        // 参数:
        //   commandName:
        //     The command to be sent.
        public static Event CommandEvent(string commandName);
        //
        // 摘要:
        //     Draw a color swatch.
        //
        // 参数:
        //   position:
        //     The rectangle to draw the color swatch within.
        //
        //   color:
        //     The color to draw.
        public static void DrawColorSwatch(Rect position, Color color);
        //
        // 摘要:
        //     Draw a curve swatch.
        //
        // 参数:
        //   position:
        //     The rectangle to draw the color swatch within.
        //
        //   curve:
        //     The curve to draw.
        //
        //   property:
        //     The curve to draw as a SerializedProperty.
        //
        //   color:
        //     The color to draw the curve with.
        //
        //   bgColor:
        //     The color to draw the background with.
        //
        //   curveRanges:
        //     Optional parameter to specify the range of the curve which should be included
        //     in swatch.
        public static void DrawCurveSwatch(Rect position, AnimationCurve curve, SerializedProperty property, Color color, Color bgColor);
        public static void DrawCurveSwatch(Rect position, AnimationCurve curve, SerializedProperty property, Color color, Color bgColor, Color topFillColor, Color bottomFillColor);
        public static void DrawCurveSwatch(Rect position, AnimationCurve curve, SerializedProperty property, Color color, Color bgColor, Color topFillColor, Color bottomFillColor, Rect curveRanges);
        //
        // 摘要:
        //     Draw a curve swatch.
        //
        // 参数:
        //   position:
        //     The rectangle to draw the color swatch within.
        //
        //   curve:
        //     The curve to draw.
        //
        //   property:
        //     The curve to draw as a SerializedProperty.
        //
        //   color:
        //     The color to draw the curve with.
        //
        //   bgColor:
        //     The color to draw the background with.
        //
        //   curveRanges:
        //     Optional parameter to specify the range of the curve which should be included
        //     in swatch.
        public static void DrawCurveSwatch(Rect position, AnimationCurve curve, SerializedProperty property, Color color, Color bgColor, Rect curveRanges);
        //
        // 摘要:
        //     Draw swatch with a filled region between two SerializedProperty curves.
        //
        // 参数:
        //   position:
        //
        //   property:
        //
        //   property2:
        //
        //   color:
        //
        //   bgColor:
        //
        //   curveRanges:
        public static void DrawRegionSwatch(Rect position, SerializedProperty property, SerializedProperty property2, Color color, Color bgColor, Rect curveRanges);
        //
        // 摘要:
        //     Draw swatch with a filled region between two curves.
        //
        // 参数:
        //   position:
        //
        //   curve:
        //
        //   curve2:
        //
        //   color:
        //
        //   bgColor:
        //
        //   curveRanges:
        public static void DrawRegionSwatch(Rect position, AnimationCurve curve, AnimationCurve curve2, Color color, Color bgColor, Rect curveRanges);
        //
        // 摘要:
        //     Get a texture from its source filename.
        //
        // 参数:
        //   name:
        public static Texture2D FindTexture(string name);
        //
        // 摘要:
        //     Get one of the built-in GUI skins, which can be the game view, inspector or Scene
        //     view skin as chosen by the parameter.
        //
        // 参数:
        //   skin:
        public static GUISkin GetBuiltinSkin(EditorSkin skin);
        public static List<Rect> GetFlowLayoutedRects(Rect rect, GUIStyle style, float horizontalSpacing, float verticalSpacing, List<string> items);
        //
        // 摘要:
        //     Gets the custom icon associated with an object. Only GameObjects and MonoScripts
        //     have associated custom icons.
        //
        // 参数:
        //   obj:
        //     The GameObject or MonoScript to query
        //
        // 返回结果:
        //     Returns the custom icon associated with the object. If there is no custom icon
        //     associated with the object, returns null.
        public static Texture2D GetIconForObject([NotNullAttribute("ArgumentNullException")] UnityEngine.Object obj);
        //
        // 摘要:
        //     Get the size that has been set using SetIconSize.
        public static Vector2 GetIconSize();
        //
        // 摘要:
        //     Returns position of Unity Editor's main window.
        //
        // 返回结果:
        //     Position of Unity Editor's main window.
        public static Rect GetMainWindowPosition();
        //
        // 摘要:
        //     The controlID of the currently showing object picker.
        public static int GetObjectPickerControlID();
        //
        // 摘要:
        //     The object currently selected in the object picker.
        public static UnityEngine.Object GetObjectPickerObject();
        //
        // 摘要:
        //     Does a given class have per-object thumbnails?
        //
        // 参数:
        //   objType:
        public static bool HasObjectThumbnail(Type objType);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("EditorGUIUtility.HSVToRGB is obsolete. Use Color.HSVToRGB instead (UnityUpgradable) -> [UnityEngine] UnityEngine.Color.HSVToRGB(*)", true)]
        public static Color HSVToRGB(float H, float S, float V, bool hdr);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("EditorGUIUtility.HSVToRGB is obsolete. Use Color.HSVToRGB instead (UnityUpgradable) -> [UnityEngine] UnityEngine.Color.HSVToRGB(*)", true)]
        public static Color HSVToRGB(float H, float S, float V);
        //
        // 摘要:
        //     Fetch the GUIContent from the Unity builtin resources with the given name.
        //
        // 参数:
        //   name:
        //     Name of the desired icon.
        //
        //   text:
        //     Tooltip for hovering over the icon.
        [ExcludeFromDocs]
        public static GUIContent IconContent(string name);
        //
        // 摘要:
        //     Fetch the GUIContent from the Unity builtin resources with the given name.
        //
        // 参数:
        //   name:
        //     Name of the desired icon.
        //
        //   text:
        //     Tooltip for hovering over the icon.
        public static GUIContent IconContent(string name, [UnityEngine.Internal.DefaultValue("null")] string text);
        //
        // 摘要:
        //     Check if any enabled camera can render to a particular display.
        //
        // 参数:
        //   displayIndex:
        //     Display index.
        //
        // 返回结果:
        //     True if a camera will render to the display.
        public static bool IsDisplayReferencedByCameras(int displayIndex);
        //
        // 摘要:
        //     Load a built-in resource.
        //
        // 参数:
        //   path:
        public static UnityEngine.Object Load(string path);
        //
        // 摘要:
        //     Load a required built-in resource.
        //
        // 参数:
        //   path:
        public static UnityEngine.Object LoadRequired(string path);
        //
        // 摘要:
        //     Make all EditorGUI look like regular controls.
        //
        // 参数:
        //   labelWidth:
        //     Width to use for prefixed labels.
        //
        //   fieldWidth:
        //     Width of text entries.
        //
        //   _labelWidth:
        //
        //   _fieldWidth:
        [Obsolete("LookLikeControls and LookLikeInspector modes are deprecated.Use EditorGUIUtility.labelWidth and EditorGUIUtility.fieldWidth to control label and field widths.", false)]
        public static void LookLikeControls(float _labelWidth, float _fieldWidth);
        [ExcludeFromDocs]
        [Obsolete("LookLikeControls and LookLikeInspector modes are deprecated.Use EditorGUIUtility.labelWidth and EditorGUIUtility.fieldWidth to control label and field widths.", false)]
        public static void LookLikeControls(float _labelWidth);
        //
        // 摘要:
        //     Make all EditorGUI look like regular controls.
        //
        // 参数:
        //   labelWidth:
        //     Width to use for prefixed labels.
        //
        //   fieldWidth:
        //     Width of text entries.
        //
        //   _labelWidth:
        //
        //   _fieldWidth:
        [ExcludeFromDocs]
        [Obsolete("LookLikeControls and LookLikeInspector modes are deprecated.Use EditorGUIUtility.labelWidth and EditorGUIUtility.fieldWidth to control label and field widths.", false)]
        public static void LookLikeControls();
        //
        // 摘要:
        //     Make all EditorGUI look like simplified outline view controls.
        [Obsolete("LookLikeControls and LookLikeInspector modes are deprecated.", false)]
        public static void LookLikeInspector();
        //
        // 摘要:
        //     Return a GUIContent object with the name and icon of an Object.
        //
        // 参数:
        //   obj:
        //
        //   type:
        public static GUIContent ObjectContent(UnityEngine.Object obj, Type type);
        

        /*
            Ping an object in the Scene like clicking it in an inspector.
            就是让这个文件在 Project 面板中, 高亮显示, 就好像 鼠标选中了这个文件一样; 很实用
        
        // 参数:
        //   obj:
        //     The object to be pinged.
        //
        //   targetInstanceID:
        */
        public static void PingObject(UnityEngine.Object obj);
        public static void PingObject(int targetInstanceID);


        //
        // 摘要:
        //     Convert a Rect from pixel space to point space.
        //
        // 参数:
        //   rect:
        //     A GUI rect measured in pixels.
        //
        // 返回结果:
        //     A rect representing the same area in points.
        public static Rect PixelsToPoints(Rect rect);
        //
        // 摘要:
        //     Convert a position from pixel to point space.
        //
        // 参数:
        //   position:
        //     A GUI position in pixel space.
        //
        // 返回结果:
        //     A vector representing the same position in point space.
        public static Vector2 PixelsToPoints(Vector2 position);
        //
        // 摘要:
        //     Converts a position from point to pixel space.
        //
        // 参数:
        //   rect:
        //     A GUI position in point space.
        //
        // 返回结果:
        //     The same position in pixel space.
        public static Rect PointsToPixels(Rect rect);
        //
        // 摘要:
        //     Convert a Rect from point space to pixel space.
        //
        // 参数:
        //   position:
        //     A GUI rect measured in points.
        //
        // 返回结果:
        //     A rect representing the same area in pixels.
        public static Vector2 PointsToPixels(Vector2 position);
        //
        // 摘要:
        //     Send an input event into the game.
        //
        // 参数:
        //   evt:
        public static void QueueGameViewInputEvent(Event evt);
        //
        // 摘要:
        //     Render all ingame cameras.
        //
        // 参数:
        //   cameraRect:
        //     The device coordinates to render all game cameras into.
        //
        //   gizmos:
        //     Show gizmos as well.
        //
        //   gui:
        //
        //   statsRect:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RenderGameViewCameras is no longer supported.Consider rendering cameras manually.", true)]
        public static void RenderGameViewCameras(Rect cameraRect, bool gizmos, bool gui);
        //
        // 摘要:
        //     Render all ingame cameras.
        //
        // 参数:
        //   cameraRect:
        //     The device coordinates to render all game cameras into.
        //
        //   gizmos:
        //     Show gizmos as well.
        //
        //   gui:
        //
        //   statsRect:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RenderGameViewCameras is no longer supported.Consider rendering cameras manually.", true)]
        public static void RenderGameViewCameras(Rect cameraRect, Rect statsRect, bool gizmos, bool gui);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RenderGameViewCameras is no longer supported.Consider rendering cameras manually.", true)]
        public static void RenderGameViewCameras(RenderTexture target, int targetDisplay, Rect screenRect, Vector2 mousePosition, bool gizmos);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("EditorGUIUtility.RGBToHSV is obsolete. Use Color.RGBToHSV instead (UnityUpgradable) -> [UnityEngine] UnityEngine.Color.RGBToHSV(*)", true)]
        public static void RGBToHSV(Color rgbColor, out float H, out float S, out float V);
        public static string SerializeMainMenuToString();
        //
        // 摘要:
        //     Sets a custom icon to associate with a GameObject or MonoScript. The custom icon
        //     is displayed in the Scene view and the Inspector.
        //
        // 参数:
        //   obj:
        //     The GameObject or MonoScript to associate the icon with.
        //
        //   icon:
        //     The custom icon to associate with the GameObject or MonoScript. When this value
        //     is null, the default icon is restored.
        public static void SetIconForObject([NotNullAttribute("ArgumentNullException")] UnityEngine.Object obj, Texture2D icon);
        //
        // 摘要:
        //     Set icons rendered as part of GUIContent to be rendered at a specific size.
        //
        // 参数:
        //   size:
        public static void SetIconSize(Vector2 size);
        //
        // 摘要:
        //     Sets position of Unity Editor's main window.
        //
        // 参数:
        //   position:
        public static void SetMainWindowPosition(Rect position);
        public static void SetMenuLocalizationTestMode(bool onoff);
        public static void SetWantsMouseJumping(int wantz);
        public static void ShowObjectPicker<T>(UnityEngine.Object obj, bool allowSceneObjects, string searchFilter, int controlID) where T : UnityEngine.Object;
        [ExcludeFromDocs]
        public static GUIContent TrIconContent(string iconName, string tooltip = null);
        [ExcludeFromDocs]
        public static GUIContent TrIconContent(Texture icon, string tooltip = null);
        [ExcludeFromDocs]
        public static GUIContent TrTempContent(string t);
        [ExcludeFromDocs]
        public static GUIContent[] TrTempContent(string[] texts);
        [ExcludeFromDocs]
        public static GUIContent[] TrTempContent(string[] texts, string[] tooltips);
        [ExcludeFromDocs]
        public static GUIContent TrTextContent(string text, Texture icon);
        [ExcludeFromDocs]
        public static GUIContent TrTextContent(string text, string tooltip, string iconName);
        [ExcludeFromDocs]
        public static GUIContent TrTextContent(string text, string tooltip = null, Texture icon = null);
        [ExcludeFromDocs]
        public static GUIContent TrTextContent(string key, string text, string tooltip, Texture icon);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, string tooltip, string iconName);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, string tooltip, Texture icon);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, string tooltip, MessageType messageType);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, MessageType messageType);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, Texture icon);
        [ExcludeFromDocs]
        public static GUIContent TrTextContentWithIcon(string text, string iconName);

        //
        // 摘要:
        //     Specifies a scope in which a callback gets called before each property is rendered.
        public class PropertyCallbackScope : IDisposable
        {
            public PropertyCallbackScope(Action<Rect, SerializedProperty> callback);

            //
            // 摘要:
            //     Releases the callback.
            public void Dispose();
        }
        //
        // 摘要:
        //     Disposable scope helper for GetIconSize / SetIconSize.
        public class IconSizeScope : GUI.Scope
        {
            //
            // 摘要:
            //     Begin an IconSizeScope.
            //
            // 参数:
            //   iconSizeWithinScope:
            //     Size to be used for icons rendered as GUIContent within this scope.
            public IconSizeScope(Vector2 iconSizeWithinScope);

            protected override void CloseScope();
        }
    }
}

