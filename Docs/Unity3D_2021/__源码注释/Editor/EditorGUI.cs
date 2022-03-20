#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Rendering;

namespace UnityEditor
{
    //
    // 摘要:
    //     These work pretty much like the normal GUI functions - and also have matching
    //     implementations in EditorGUILayout.
    public sealed class EditorGUI
    {
        public EditorGUI();

        //
        // 摘要:
        //     Makes the following controls give the appearance of editing multiple different
        //     values.
        public static bool showMixedValue { get; set; }
        //
        // 摘要:
        //     The indent level of the field labels.
        public static int indentLevel { get; set; }
        //
        // 摘要:
        //     Is the platform-dependent "action" modifier key held down? (Read Only)
        public static bool actionKey { get; }

        public static event Action<EditorWindow, HyperLinkClickedEventArgs> hyperLinkClicked;

        //
        // 摘要:
        //     Starts a new code block to check for GUI changes.
        public static void BeginChangeCheck();
        //
        // 摘要:
        //     Create a group of controls that can be disabled.
        //
        // 参数:
        //   disabled:
        //     Boolean specifying if the controls inside the group should be disabled.
        public static void BeginDisabledGroup(bool disabled);
        public static bool BeginFoldoutHeaderGroup(Rect position, bool foldout, string content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null);
        public static bool BeginFoldoutHeaderGroup(Rect position, bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null);
        //
        // 摘要:
        //     Create a Property wrapper, useful for making regular GUI controls work with SerializedProperty.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use for the control, including label if applicable.
        //
        //   label:
        //     Optional label in front of the slider. Use null to use the name from the SerializedProperty.
        //     Use GUIContent.none to not display a label.
        //
        //   property:
        //     The SerializedProperty to use for the control.
        //
        // 返回结果:
        //     The actual label to use for the control.
        public static GUIContent BeginProperty(Rect totalPosition, GUIContent label, SerializedProperty property);
        //
        // 摘要:
        //     Makes Center and Extents field for entering a Bounds.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Bounds BoundsField(Rect position, Bounds value);
        //
        // 摘要:
        //     Makes Center and Extents field for entering a Bounds.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Bounds BoundsField(Rect position, GUIContent label, Bounds value);
        public static Bounds BoundsField(Rect position, string label, Bounds value);
        //
        // 摘要:
        //     Makes Position and Size field for entering a BoundsInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(Rect position, BoundsInt value);
        //
        // 摘要:
        //     Makes Position and Size field for entering a BoundsInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(Rect position, string label, BoundsInt value);
        //
        // 摘要:
        //     Makes Position and Size field for entering a BoundsInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(Rect position, GUIContent label, BoundsInt value);
        //
        // 摘要:
        //     Get whether a SerializedProperty's inspector GUI can be cached.
        //
        // 参数:
        //   property:
        //     The SerializedProperty in question.
        //
        // 返回结果:
        //     Whether the property's inspector GUI can be cached.
        public static bool CanCacheInspectorGUI(SerializedProperty property);
        //
        // 摘要:
        //     Makes a field for selecting a Color.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The color to edit.
        //
        //   showEyedropper:
        //     If true, the color picker should show the eyedropper control. If false, don't
        //     show it.
        //
        //   showAlpha:
        //     If true, allow the user to set an alpha value for the color. If false, hide the
        //     alpha component.
        //
        //   hdr:
        //     If true, treat the color as an HDR value. If false, treat it as a standard LDR
        //     value.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(Rect position, GUIContent label, Color value);
        //
        // 摘要:
        //     Makes a field for selecting a Color.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The color to edit.
        //
        //   showEyedropper:
        //     If true, the color picker should show the eyedropper control. If false, don't
        //     show it.
        //
        //   showAlpha:
        //     If true, allow the user to set an alpha value for the color. If false, hide the
        //     alpha component.
        //
        //   hdr:
        //     If true, treat the color as an HDR value. If false, treat it as a standard LDR
        //     value.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(Rect position, Color value);
        //
        // 摘要:
        //     Makes a field for selecting a Color.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The color to edit.
        //
        //   showEyedropper:
        //     If true, the color picker should show the eyedropper control. If false, don't
        //     show it.
        //
        //   showAlpha:
        //     If true, allow the user to set an alpha value for the color. If false, hide the
        //     alpha component.
        //
        //   hdr:
        //     If true, treat the color as an HDR value. If false, treat it as a standard LDR
        //     value.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(Rect position, string label, Color value);
        //
        // 摘要:
        //     Makes a field for selecting a Color.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The color to edit.
        //
        //   showEyedropper:
        //     If true, the color picker should show the eyedropper control. If false, don't
        //     show it.
        //
        //   showAlpha:
        //     If true, allow the user to set an alpha value for the color. If false, hide the
        //     alpha component.
        //
        //   hdr:
        //     If true, treat the color as an HDR value. If false, treat it as a standard LDR
        //     value.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        [Obsolete("Use EditorGUI.ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr)")]
        public static Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, ColorPickerHDRConfig hdrConfig);
        //
        // 摘要:
        //     Makes a field for selecting a Color.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The color to edit.
        //
        //   showEyedropper:
        //     If true, the color picker should show the eyedropper control. If false, don't
        //     show it.
        //
        //   showAlpha:
        //     If true, allow the user to set an alpha value for the color. If false, hide the
        //     alpha component.
        //
        //   hdr:
        //     If true, treat the color as an HDR value. If false, treat it as a standard LDR
        //     value.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, AnimationCurve value);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, string label, AnimationCurve value);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, string label, AnimationCurve value, Color color, Rect ranges);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value, Color color, Rect ranges);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        //   label:
        //     Optional label to display in front of the field. Pass [[GUIContent.none] to hide
        //     the label.
        public static void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        //   label:
        //     Optional label to display in front of the field. Pass [[GUIContent.none] to hide
        //     the label.
        public static void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges, GUIContent label);
        //
        // 摘要:
        //     Makes a field for editing an AnimationCurve.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(Rect position, AnimationCurve value, Color color, Rect ranges);
        [ExcludeFromDocs]
        public static double DelayedDoubleField(Rect position, string label, double value);
        [ExcludeFromDocs]
        public static double DelayedDoubleField(Rect position, double value);
        //
        // 摘要:
        //     Makes a delayed text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static double DelayedDoubleField(Rect position, GUIContent label, double value);
        //
        // 摘要:
        //     Makes a delayed text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static float DelayedFloatField(Rect position, string label, float value);
        [ExcludeFromDocs]
        public static float DelayedFloatField(Rect position, GUIContent label, float value);
        //
        // 摘要:
        //     Makes a delayed text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   property:
        //     The float property to edit.
        //
        //   label:
        //     Optional label to display in front of the float field. Pass GUIContent.none to
        //     hide label.
        public static void DelayedFloatField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label);
        [ExcludeFromDocs]
        public static float DelayedFloatField(Rect position, float value);
        [ExcludeFromDocs]
        public static void DelayedFloatField(Rect position, SerializedProperty property);
        //
        // 摘要:
        //     Makes a delayed text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static int DelayedIntField(Rect position, int value);
        [ExcludeFromDocs]
        public static int DelayedIntField(Rect position, string label, int value);
        //
        // 摘要:
        //     Makes a delayed text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static void DelayedIntField(Rect position, SerializedProperty property);
        //
        // 摘要:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   property:
        //     The int property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        public static void DelayedIntField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label);
        [ExcludeFromDocs]
        public static int DelayedIntField(Rect position, GUIContent label, int value);
        public static string DelayedTextField(Rect position, GUIContent label, int controlId, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        [ExcludeFromDocs]
        public static string DelayedTextField(Rect position, GUIContent label, int controlId, string text);
        //
        // 摘要:
        //     Makes a delayed text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   property:
        //     The text property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        public static void DelayedTextField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label);
        [ExcludeFromDocs]
        public static void DelayedTextField(Rect position, SerializedProperty property);
        //
        // 摘要:
        //     Makes a delayed text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a delayed text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        [ExcludeFromDocs]
        public static string DelayedTextField(Rect position, string label, string text);
        //
        // 摘要:
        //     Makes a delayed text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        [ExcludeFromDocs]
        public static string DelayedTextField(Rect position, GUIContent label, string text);
        [ExcludeFromDocs]
        public static string DelayedTextField(Rect position, string text);
        [Obsolete("Use PasswordField instead.")]
        public static string DoPasswordField(int id, Rect position, string password, GUIStyle style);
        [Obsolete("Use PasswordField instead.")]
        public static string DoPasswordField(int id, Rect position, GUIContent label, string password, GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static double DoubleField(Rect position, string label, double value);
        [ExcludeFromDocs]
        public static double DoubleField(Rect position, double value);
        //
        // 摘要:
        //     Makes a text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static double DoubleField(Rect position, GUIContent label, double value);
        //
        // 摘要:
        //     Makes a text field for entering doubles.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the double field.
        //
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image, Material mat);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        public static void DrawPreviewTexture(Rect position, Texture image, [DefaultValue("null")] Material mat, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel, [DefaultValue("ColorWriteMask.All")] ColorWriteMask colorWriteMask, [DefaultValue("0")] float exposure);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect, float mipLevel, ColorWriteMask colorWriteMask);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect, float mipLevel);
        //
        // 摘要:
        //     Draws the texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   mat:
        //     Material to be used when drawing the texture.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     The mip-level to sample. If negative, the texture is sampled normally. Sets material's
        //     _Mip property.
        //
        //   colorWriteMask:
        //     Specifies which color components of image will get written. Sets material's _ColorMask
        //     property.
        //
        //   exposure:
        //     Specifies the exposure for the texture. Sets material's _Exposure property.
        [ExcludeFromDocs]
        public static void DrawPreviewTexture(Rect position, Texture image);
        //
        // 摘要:
        //     Draws a filled rectangle of color at the specified position and size within the
        //     current editor window.
        //
        // 参数:
        //   rect:
        //     The position and size of the rectangle to draw.
        //
        //   color:
        //     The color of the rectange.
        public static void DrawRect(Rect rect, Color color);
        //
        // 摘要:
        //     Draws the alpha channel of a texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     What mip-level to sample. If negative, texture will be sampled normally. It sets
        //     material _Mip property.
        public static void DrawTextureAlpha(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel);
        //
        // 摘要:
        //     Draws the alpha channel of a texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     What mip-level to sample. If negative, texture will be sampled normally. It sets
        //     material _Mip property.
        [ExcludeFromDocs]
        public static void DrawTextureAlpha(Rect position, Texture image);
        //
        // 摘要:
        //     Draws the alpha channel of a texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     What mip-level to sample. If negative, texture will be sampled normally. It sets
        //     material _Mip property.
        [ExcludeFromDocs]
        public static void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode);
        //
        // 摘要:
        //     Draws the alpha channel of a texture within a rectangle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the texture within.
        //
        //   image:
        //     Texture to display.
        //
        //   scaleMode:
        //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
        //     to be drawn within.
        //
        //   imageAspect:
        //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
        //     from the image is used.
        //
        //   mipLevel:
        //     What mip-level to sample. If negative, texture will be sampled normally. It sets
        //     material _Mip property.
        [ExcludeFromDocs]
        public static void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode, float imageAspect);
        [ExcludeFromDocs]
        public static void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode);
        public static void DrawTextureTransparent(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel, [DefaultValue("ColorWriteMask.All")] ColorWriteMask colorWriteMask, [DefaultValue("0")] float exposure);
        [ExcludeFromDocs]
        public static void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect, float mipLevel, ColorWriteMask colorWriteMask);
        [ExcludeFromDocs]
        public static void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect);
        [ExcludeFromDocs]
        public static void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect, float mipLevel);
        [ExcludeFromDocs]
        public static void DrawTextureTransparent(Rect position, Texture image);
        //
        // 摘要:
        //     Makes a button that reacts to mouse down, for displaying your own dropdown content.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   focusType:
        //     Whether the button should be selectable by keyboard or not.
        //
        //   style:
        //     Optional style to use.
        //
        // 返回结果:
        //     true when the user clicks the button.
        public static bool DropdownButton(Rect position, GUIContent content, FocusType focusType);
        //
        // 摘要:
        //     Makes a button that reacts to mouse down, for displaying your own dropdown content.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   focusType:
        //     Whether the button should be selectable by keyboard or not.
        //
        //   style:
        //     Optional style to use.
        //
        // 返回结果:
        //     true when the user clicks the button.
        public static bool DropdownButton(Rect position, GUIContent content, FocusType focusType, GUIStyle style);
        //
        // 摘要:
        //     Draws a label with a drop shadow.
        //
        // 参数:
        //   position:
        //     Where to show the label.
        //
        //   content:
        //     Text to show @style style to use.
        //
        //   text:
        //
        //   style:
        public static void DropShadowLabel(Rect position, GUIContent content);
        //
        // 摘要:
        //     Draws a label with a drop shadow.
        //
        // 参数:
        //   position:
        //     Where to show the label.
        //
        //   content:
        //     Text to show @style style to use.
        //
        //   text:
        //
        //   style:
        public static void DropShadowLabel(Rect position, string text, GUIStyle style);
        //
        // 摘要:
        //     Draws a label with a drop shadow.
        //
        // 参数:
        //   position:
        //     Where to show the label.
        //
        //   content:
        //     Text to show @style style to use.
        //
        //   text:
        //
        //   style:
        public static void DropShadowLabel(Rect position, GUIContent content, GUIStyle style);
        //
        // 摘要:
        //     Draws a label with a drop shadow.
        //
        // 参数:
        //   position:
        //     Where to show the label.
        //
        //   content:
        //     Text to show @style style to use.
        //
        //   text:
        //
        //   style:
        public static void DropShadowLabel(Rect position, string text);
        //
        // 摘要:
        //     Ends a code block and checks for any GUI changes.
        //
        // 返回结果:
        //     Returns true if GUI state changed since the call to EditorGUI.BeginChangeCheck,
        //     otherwise false.
        public static bool EndChangeCheck();
        //
        // 摘要:
        //     Ends a disabled group started with BeginDisabledGroup.
        public static void EndDisabledGroup();
        //
        // 摘要:
        //     Closes a group started with BeginFoldoutHeaderGroup. See Also: EditorGUILayout.BeginFoldoutHeaderGroup.
        public static void EndFoldoutHeaderGroup();
        //
        // 摘要:
        //     Ends a Property wrapper started with BeginProperty.
        public static void EndProperty();
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, [DefaultValue("false")] bool includeObsolete, [DefaultValue("null")] GUIStyle style = null);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, Enum enumValue);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, string label, Enum enumValue);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, string label, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //     An option for the value 0 with name "Nothing" and an option for the value ~0
        //     (that is, all bits set) with the name "Everything" are always displayed at the
        //     top of the menu. The names for the values 0 and ~0 can be overriden by defining
        //     these values in the enum type.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the enum flags field.
        //
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value (Only supports enum values for enum types with int as the underlying
        //     type).
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, GUIContent label, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, GUIContent label, Enum enumValue);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, string label, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, string label, Enum enumValue);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, Enum enumValue, GUIStyle style);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes a field
        //     for enum based masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Caption/label for the control.
        //
        //   enumValue:
        //     Enum to use for the flags.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     A selection BitMask where each bit represents an Enum value index. (Note this
        //     returned value is not itself an Enum).
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Rect position, Enum enumValue);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes an enum
        //     popup selection field for a bitmask.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum options the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The enum options that has been selected by the user.
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(Rect position, GUIContent label, Enum selected);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes an enum
        //     popup selection field for a bitmask.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum options the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The enum options that has been selected by the user.
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(Rect position, string label, Enum selected, GUIStyle style);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes an enum
        //     popup selection field for a bitmask.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum options the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The enum options that has been selected by the user.
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(Rect position, GUIContent label, Enum selected, GUIStyle style);
        //
        // 摘要:
        //     This method is obsolete. Use EditorGUI.EnumFlagsField instead. Makes an enum
        //     popup selection field for a bitmask.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum options the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The enum options that has been selected by the user.
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(Rect position, string label, Enum selected);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        [ExcludeFromDocs]
        public static Enum EnumPopup(Rect position, Enum selected);
        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("null")] Func<Enum, bool> checkEnabled, [DefaultValue("false")] bool includeObsolete = false, [DefaultValue("null")] GUIStyle style = null);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        [ExcludeFromDocs]
        public static Enum EnumPopup(Rect position, GUIContent label, Enum selected);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        public static Enum EnumPopup(Rect position, string label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        [ExcludeFromDocs]
        public static Enum EnumPopup(Rect position, string label, Enum selected);
        //
        // 摘要:
        //     Makes an enum popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        //   checkEnabled:
        //     Method called for each Enum value displayed. The specified method should return
        //     true if the option can be selected, false otherwise.
        //
        // 返回结果:
        //     The enum option that has been selected by the user.
        public static Enum EnumPopup(Rect position, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static float FloatField(Rect position, GUIContent label, float value);
        //
        // 摘要:
        //     Makes a text field for entering floats.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        [ExcludeFromDocs]
        public static float FloatField(Rect position, float value);
        [ExcludeFromDocs]
        public static float FloatField(Rect position, string label, float value);
        //
        // 摘要:
        //     Move keyboard focus to a named text field and begin editing of the content.
        //
        // 参数:
        //   name:
        //     Name set using GUI.SetNextControlName.
        public static void FocusTextInControl(string name);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(Rect position, bool foldout, string content);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(Rect position, bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(Rect position, bool foldout, GUIContent content);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(Rect position, bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label with a foldout arrow to the left of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the arrow and label.
        //
        //   foldout:
        //     The shown foldout state.
        //
        //   content:
        //     The label to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   toggleOnLabelClick:
        //     Should the label be a clickable part of the control?
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick);
        //
        // 摘要:
        //     Get the height needed for a PropertyField control.
        //
        // 参数:
        //   property:
        //     Height of the property area.
        //
        //   label:
        //     Descriptive text or image.
        //
        //   includeChildren:
        //     Should the returned height include the height of child properties?
        //
        //   type:
        [ExcludeFromDocs]
        public static float GetPropertyHeight(SerializedProperty property, GUIContent label);
        //
        // 摘要:
        //     Get the height needed for a PropertyField control.
        //
        // 参数:
        //   property:
        //     Height of the property area.
        //
        //   label:
        //     Descriptive text or image.
        //
        //   includeChildren:
        //     Should the returned height include the height of child properties?
        //
        //   type:
        public static float GetPropertyHeight(SerializedProperty property, bool includeChildren);
        //
        // 摘要:
        //     Get the height needed for a PropertyField control.
        //
        // 参数:
        //   property:
        //     Height of the property area.
        //
        //   label:
        //     Descriptive text or image.
        //
        //   includeChildren:
        //     Should the returned height include the height of child properties?
        //
        //   type:
        [ExcludeFromDocs]
        public static float GetPropertyHeight(SerializedProperty property);
        //
        // 摘要:
        //     Get the height needed for a PropertyField control.
        //
        // 参数:
        //   property:
        //     Height of the property area.
        //
        //   label:
        //     Descriptive text or image.
        //
        //   includeChildren:
        //     Should the returned height include the height of child properties?
        //
        //   type:
        public static float GetPropertyHeight(SerializedProperty property, [DefaultValue("null")] GUIContent label, [DefaultValue("true")] bool includeChildren);
        //
        // 摘要:
        //     Get the height needed for a PropertyField control.
        //
        // 参数:
        //   property:
        //     Height of the property area.
        //
        //   label:
        //     Descriptive text or image.
        //
        //   includeChildren:
        //     Should the returned height include the height of child properties?
        //
        //   type:
        public static float GetPropertyHeight(SerializedPropertyType type, GUIContent label);
        //
        // 摘要:
        //     Makes a field for editing a Gradient.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   gradient:
        //     The gradient to edit.
        //
        //   hdr:
        //     Display the HDR Gradient Editor.
        //
        //   colorSpace:
        //     Display the gradient and Gradient Editor in this color space.
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Rect position, GUIContent label, Gradient gradient, bool hdr, ColorSpace colorSpace);
        //
        // 摘要:
        //     Makes a field for editing a Gradient.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   gradient:
        //     The gradient to edit.
        //
        //   hdr:
        //     Display the HDR Gradient Editor.
        //
        //   colorSpace:
        //     Display the gradient and Gradient Editor in this color space.
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Rect position, Gradient gradient);
        //
        // 摘要:
        //     Makes a field for editing a Gradient.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   gradient:
        //     The gradient to edit.
        //
        //   hdr:
        //     Display the HDR Gradient Editor.
        //
        //   colorSpace:
        //     Display the gradient and Gradient Editor in this color space.
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Rect position, string label, Gradient gradient);
        //
        // 摘要:
        //     Makes a field for editing a Gradient.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   gradient:
        //     The gradient to edit.
        //
        //   hdr:
        //     Display the HDR Gradient Editor.
        //
        //   colorSpace:
        //     Display the gradient and Gradient Editor in this color space.
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Rect position, GUIContent label, Gradient gradient);
        //
        // 摘要:
        //     Makes a field for editing a Gradient.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display in front of the field.
        //
        //   gradient:
        //     The gradient to edit.
        //
        //   hdr:
        //     Display the HDR Gradient Editor.
        //
        //   colorSpace:
        //     Display the gradient and Gradient Editor in this color space.
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Rect position, GUIContent label, Gradient gradient, bool hdr);
        //
        // 摘要:
        //     Makes a label for some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   labelPosition:
        //     Rectangle on the screen to use for the label.
        //
        //   label:
        //     Label to show for the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   style:
        //     Optional GUIStyle to use for the label.
        [ExcludeFromDocs]
        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, int id);
        //
        // 摘要:
        //     Makes a label for some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   labelPosition:
        //     Rectangle on the screen to use for the label.
        //
        //   label:
        //     Label to show for the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   style:
        //     Optional GUIStyle to use for the label.
        [ExcludeFromDocs]
        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label);
        //
        // 摘要:
        //     Makes a label for some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   labelPosition:
        //     Rectangle on the screen to use for the label.
        //
        //   label:
        //     Label to show for the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   style:
        //     Optional GUIStyle to use for the label.
        public static void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, [DefaultValue("0")] int id, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a help box with a message to the user.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to draw the help box within.
        //
        //   message:
        //     The message text.
        //
        //   type:
        //     The type of message.
        public static void HelpBox(Rect position, string message, MessageType type);
        public static Rect IndentedRect(Rect source);
        public static bool InspectorTitlebar(Rect position, bool foldout, Editor editor);
        //
        // 摘要:
        //     Makes an inspector-window-like titlebar.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the titlebar.
        //
        //   foldout:
        //     The foldout state shown with the arrow.
        //
        //   targetObj:
        //     The object (for example a component) that the titlebar is for.
        //
        //   targetObjs:
        //     The objects that the titlebar is for.
        //
        //   expandable:
        //     Whether this editor should display a foldout arrow in order to toggle the display
        //     of its properties.
        //
        // 返回结果:
        //     The foldout state selected by the user.
        public static bool InspectorTitlebar(Rect position, bool foldout, UnityEngine.Object targetObj, bool expandable);
        //
        // 摘要:
        //     Makes an inspector-window-like titlebar.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the titlebar.
        //
        //   foldout:
        //     The foldout state shown with the arrow.
        //
        //   targetObj:
        //     The object (for example a component) that the titlebar is for.
        //
        //   targetObjs:
        //     The objects that the titlebar is for.
        //
        //   expandable:
        //     Whether this editor should display a foldout arrow in order to toggle the display
        //     of its properties.
        //
        // 返回结果:
        //     The foldout state selected by the user.
        public static bool InspectorTitlebar(Rect position, bool foldout, UnityEngine.Object[] targetObjs, bool expandable);
        public static void InspectorTitlebar(Rect position, UnityEngine.Object[] targetObjs);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static int IntField(Rect position, string label, int value);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static int IntField(Rect position, GUIContent label, int value);
        //
        // 摘要:
        //     Makes a text field for entering integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the int field.
        //
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static int IntField(Rect position, int value);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues);
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The SerializedProperty to use for the control.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   label:
        //     Optional label in front of the field.
        public static void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("null")] GUIContent label);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues);
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The SerializedProperty to use for the control.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   label:
        //     Optional label in front of the field.
        [ExcludeFromDocs]
        public static void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes an integer popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedValue:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option. If optionValues a direct mapping of
        //     selectedValue to displayedOptions is assumed.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(Rect position, GUIContent label, int value, int leftValue, int rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, string label);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, GUIContent label);
        //
        // 摘要:
        //     Makes a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(Rect position, string label, int value, int leftValue, int rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(Rect position, int value, int leftValue, int rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        [ExcludeFromDocs]
        public static void LabelField(Rect position, string label);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        public static void LabelField(Rect position, GUIContent label, GUIContent label2, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        public static void LabelField(Rect position, string label, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        [ExcludeFromDocs]
        public static void LabelField(Rect position, GUIContent label);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        public static void LabelField(Rect position, GUIContent label, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        [ExcludeFromDocs]
        public static void LabelField(Rect position, string label, string label2);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        public static void LabelField(Rect position, string label, string label2, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label field.
        //
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   style:
        //     Style information (color, etc) for displaying the label.
        [ExcludeFromDocs]
        public static void LabelField(Rect position, GUIContent label, GUIContent label2);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(Rect position, string label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(Rect position, GUIContent label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        [ExcludeFromDocs]
        public static int LayerField(Rect position, GUIContent label, int layer);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        [ExcludeFromDocs]
        public static int LayerField(Rect position, int layer);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(Rect position, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a layer selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The layer selected by the user.
        [ExcludeFromDocs]
        public static int LayerField(Rect position, string label, int layer);
        //
        // 摘要:
        //     Make a clickable link label.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the control. The underline is done with the
        //     bottom border so set the size accordingly.
        //
        //   label:
        //     Label of the link.
        //
        // 返回结果:
        //     true when the user clicks the link.
        public static bool LinkButton(Rect position, GUIContent label);
        //
        // 摘要:
        //     Make a clickable link label.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the control. The underline is done with the
        //     bottom border so set the size accordingly.
        //
        //   label:
        //     Label of the link.
        //
        // 返回结果:
        //     true when the user clicks the link.
        public static bool LinkButton(Rect position, string label);
        //
        // 摘要:
        //     Makes a text field for entering long integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the long field.
        //
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(Rect position, GUIContent label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering long integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the long field.
        //
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static long LongField(Rect position, long value);
        public static long LongField(Rect position, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field for entering long integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the long field.
        //
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static long LongField(Rect position, string label, long value);
        //
        // 摘要:
        //     Makes a text field for entering long integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the long field.
        //
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        [ExcludeFromDocs]
        public static long LongField(Rect position, GUIContent label, long value);
        //
        // 摘要:
        //     Makes a text field for entering long integers.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the long field.
        //
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(Rect position, string label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        [ExcludeFromDocs]
        public static int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        [ExcludeFromDocs]
        public static int MaskField(Rect position, string label, int mask, string[] displayedOptions);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(Rect position, string label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        [ExcludeFromDocs]
        public static int MaskField(Rect position, int mask, string[] displayedOptions);
        //
        // 摘要:
        //     Makes a field for masks.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for this control.
        //
        //   label:
        //     Label for the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   displayedOptions:
        //     A string array containing the labels for each flag.
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(Rect position, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        public static void MinMaxSlider(Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit);
        public static void MinMaxSlider(Rect position, GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit);
        public static void MinMaxSlider(Rect position, string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit);
        [Obsolete("Switch the order of the first two parameters.")]
        public static void MinMaxSlider(GUIContent label, Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit);
        //
        // 摘要:
        //     Makes a multi-control with text fields for entering multiple floats in the same
        //     line.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   subLabels:
        //     Array with small labels to show in front of each float field. There is room for
        //     one letter per field only.
        //
        //   values:
        //     Array with the values to edit.
        public static void MultiFloatField(Rect position, GUIContent label, GUIContent[] subLabels, float[] values);
        //
        // 摘要:
        //     Makes a multi-control with text fields for entering multiple floats in the same
        //     line.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the float field.
        //
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   subLabels:
        //     Array with small labels to show in front of each float field. There is room for
        //     one letter per field only.
        //
        //   values:
        //     Array with the values to edit.
        public static void MultiFloatField(Rect position, GUIContent[] subLabels, float[] values);
        //
        // 摘要:
        //     Makes a multi-control with text fields for entering multiple integers in the
        //     same line.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the integer field.
        //
        //   subLabels:
        //     Array with small labels to show in front of each int field. There is room for
        //     one letter per field only.
        //
        //   values:
        //     Array with the values to edit.
        public static void MultiIntField(Rect position, GUIContent[] subLabels, int[] values);
        //
        // 摘要:
        //     Makes a multi-control with several property fields in the same line.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the multi-property field.
        //
        //   valuesIterator:
        //     The SerializedProperty of the first property to make a control for.
        //
        //   label:
        //     Optional label to use. If not specified the label of the property itself is used.
        //     Use GUIContent.none to not display a label at all.
        //
        //   subLabels:
        //     Array with small labels to show in front of each float field. There is room for
        //     one letter per field only.
        public static void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator);
        //
        // 摘要:
        //     Makes a multi-control with several property fields in the same line.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the multi-property field.
        //
        //   valuesIterator:
        //     The SerializedProperty of the first property to make a control for.
        //
        //   label:
        //     Optional label to use. If not specified the label of the property itself is used.
        //     Use GUIContent.none to not display a label at all.
        //
        //   subLabels:
        //     Array with small labels to show in front of each float field. There is room for
        //     one letter per field only.
        public static void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator, GUIContent label);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        public static UnityEngine.Object ObjectField(Rect position, UnityEngine.Object obj, Type objType, bool allowSceneObjects);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label to display in front of the field. Pass GUIContent.none to hide
        //     the label.
        public static void ObjectField(Rect position, SerializedProperty property);
        public static UnityEngine.Object ObjectField(Rect position, UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label to display in front of the field. Pass GUIContent.none to hide
        //     the label.
        public static void ObjectField(Rect position, SerializedProperty property, Type objType);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label to display in front of the field. Pass GUIContent.none to hide
        //     the label.
        public static void ObjectField(Rect position, SerializedProperty property, Type objType, GUIContent label);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label to display in front of the field. Pass GUIContent.none to hide
        //     the label.
        public static void ObjectField(Rect position, SerializedProperty property, GUIContent label);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        public static UnityEngine.Object ObjectField(Rect position, GUIContent label, UnityEngine.Object obj, Type objType, bool allowSceneObjects);
        public static UnityEngine.Object ObjectField(Rect position, GUIContent label, UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        public static UnityEngine.Object ObjectField(Rect position, string label, UnityEngine.Object obj, Type objType);
        public static UnityEngine.Object ObjectField(Rect position, string label, UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        public static UnityEngine.Object ObjectField(Rect position, UnityEngine.Object obj, Type objType);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        public static UnityEngine.Object ObjectField(Rect position, GUIContent label, UnityEngine.Object obj, Type objType);
        //
        // 摘要:
        //     Makes an object field. You can assign objects either by drag and drop objects
        //     or by selecting an object using the Object Picker.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   obj:
        //     The object the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   allowSceneObjects:
        //     Allow assigning Scene objects. See Description for more info.
        //
        // 返回结果:
        //     The object that has been set by the user.
        public static UnityEngine.Object ObjectField(Rect position, string label, UnityEngine.Object obj, Type objType, bool allowSceneObjects);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        [ExcludeFromDocs]
        public static string PasswordField(Rect position, string password);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        public static string PasswordField(Rect position, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        [ExcludeFromDocs]
        public static string PasswordField(Rect position, string label, string password);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        public static string PasswordField(Rect position, string label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        [ExcludeFromDocs]
        public static string PasswordField(Rect position, GUIContent label, string password);
        //
        // 摘要:
        //     Makes a text field where the user can enter a password.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the password field.
        //
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The password entered by the user.
        public static string PasswordField(Rect position, GUIContent label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        public static int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        public static int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        public static int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int Popup(Rect position, int selectedIndex, string[] displayedOptions);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        public static int Popup(Rect position, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a generic popup selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   selectedIndex:
        //     The index of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the options shown in the popup.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        [ExcludeFromDocs]
        public static int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions);
        //
        // 摘要:
        //     Makes a label in front of some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   label:
        //     Label to show in front of the control.
        //
        //   style:
        //     Style to use for the label.
        //
        // 返回结果:
        //     Rectangle on the screen to use just for the control itself.
        public static Rect PrefixLabel(Rect totalPosition, int id, GUIContent label, GUIStyle style);
        //
        // 摘要:
        //     Makes a label in front of some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   label:
        //     Label to show in front of the control.
        //
        //   style:
        //     Style to use for the label.
        //
        // 返回结果:
        //     Rectangle on the screen to use just for the control itself.
        public static Rect PrefixLabel(Rect totalPosition, int id, GUIContent label);
        //
        // 摘要:
        //     Makes a label in front of some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   label:
        //     Label to show in front of the control.
        //
        //   style:
        //     Style to use for the label.
        //
        // 返回结果:
        //     Rectangle on the screen to use just for the control itself.
        public static Rect PrefixLabel(Rect totalPosition, GUIContent label);
        //
        // 摘要:
        //     Makes a label in front of some control.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the label and the control.
        //
        //   id:
        //     The unique ID of the control. If none specified, the ID of the following control
        //     is used.
        //
        //   label:
        //     Label to show in front of the control.
        //
        //   style:
        //     Style to use for the label.
        //
        // 返回结果:
        //     Rectangle on the screen to use just for the control itself.
        public static Rect PrefixLabel(Rect totalPosition, GUIContent label, GUIStyle style);
        //
        // 摘要:
        //     Makes a progress bar.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use in total for both the control.
        //
        //   value:
        //     Value that is shown.
        //
        //   position:
        //
        //   text:
        public static void ProgressBar(Rect position, float value, string text);
        //
        // 摘要:
        //     Use this to make a field for a SerializedProperty in the Editor.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the property field.
        //
        //   property:
        //     The SerializedProperty to make a field for.
        //
        //   label:
        //     Optional label to use. If not specified the label of the property itself is used.
        //     Use GUIContent.none to not display a label at all.
        //
        //   includeChildren:
        //     If true the property including children is drawn; otherwise only the control
        //     itself (such as only a foldout but nothing below it).
        //
        // 返回结果:
        //     True if the property has children and is expanded and includeChildren was set
        //     to false; otherwise false.
        public static bool PropertyField(Rect position, SerializedProperty property, GUIContent label, [DefaultValue("false")] bool includeChildren);
        [ExcludeFromDocs]
        public static bool PropertyField(Rect position, SerializedProperty property);
        //
        // 摘要:
        //     Use this to make a field for a SerializedProperty in the Editor.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the property field.
        //
        //   property:
        //     The SerializedProperty to make a field for.
        //
        //   label:
        //     Optional label to use. If not specified the label of the property itself is used.
        //     Use GUIContent.none to not display a label at all.
        //
        //   includeChildren:
        //     If true the property including children is drawn; otherwise only the control
        //     itself (such as only a foldout but nothing below it).
        //
        // 返回结果:
        //     True if the property has children and is expanded and includeChildren was set
        //     to false; otherwise false.
        public static bool PropertyField(Rect position, SerializedProperty property, [DefaultValue("false")] bool includeChildren);
        [ExcludeFromDocs]
        public static bool PropertyField(Rect position, SerializedProperty property, GUIContent label);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a Rect.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Rect RectField(Rect position, GUIContent label, Rect value);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a Rect.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Rect RectField(Rect position, string label, Rect value);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a Rect.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Rect RectField(Rect position, Rect value);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a RectInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static RectInt RectIntField(Rect position, RectInt value);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a RectInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static RectInt RectIntField(Rect position, string label, RectInt value);
        //
        // 摘要:
        //     Makes an X, Y, W, and H field for entering a RectInt.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static RectInt RectIntField(Rect position, GUIContent label, RectInt value);
        //
        // 摘要:
        //     Makes a selectable label field. (Useful for showing read-only info that can be
        //     copy-pasted.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label.
        //
        //   text:
        //     The text to show.
        //
        //   style:
        //     Optional GUIStyle.
        public static void SelectableLabel(Rect position, string text, [DefaultValue("EditorStyles.label")] GUIStyle style);
        //
        // 摘要:
        //     Makes a selectable label field. (Useful for showing read-only info that can be
        //     copy-pasted.)
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the label.
        //
        //   text:
        //     The text to show.
        //
        //   style:
        //     Optional GUIStyle.
        [ExcludeFromDocs]
        public static void SelectableLabel(Rect position, string text);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, GUIContent label);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, string label);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   property:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        public static void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float Slider(Rect position, GUIContent label, float value, float leftValue, float rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float Slider(Rect position, string label, float value, float leftValue, float rightValue);
        //
        // 摘要:
        //     Makes a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the slider.
        //
        //   label:
        //     Optional label in front of the slider.
        //
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float Slider(Rect position, float value, float leftValue, float rightValue);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        public static string TagField(Rect position, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        public static string TagField(Rect position, GUIContent label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        [ExcludeFromDocs]
        public static string TagField(Rect position, string tag);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        [ExcludeFromDocs]
        public static string TagField(Rect position, string label, string tag);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        [ExcludeFromDocs]
        public static string TagField(Rect position, GUIContent label, string tag);
        //
        // 摘要:
        //     Makes a tag selection field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The tag selected by the user.
        public static string TagField(Rect position, string label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text area.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        [ExcludeFromDocs]
        public static string TextArea(Rect position, string text);
        //
        // 摘要:
        //     Makes a text area.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextArea(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        [ExcludeFromDocs]
        public static string TextField(Rect position, string text);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        [ExcludeFromDocs]
        public static string TextField(Rect position, string label, string text);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        [ExcludeFromDocs]
        public static string TextField(Rect position, GUIContent label, string text);
        //
        // 摘要:
        //     Makes a text field.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the text field.
        //
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, GUIContent label, bool value, GUIStyle style);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, string label, bool value);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, bool value);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, bool value, GUIStyle style);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, string label, bool value, GUIStyle style);
        //
        // 摘要:
        //     Makes a toggle.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(Rect position, GUIContent label, bool value);
        //
        // 摘要:
        //     Makes a toggle field where the toggle is to the left and the label immediately
        //     to the right of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Label to display next to the toggle.
        //
        //   value:
        //     The value to edit.
        //
        //   labelStyle:
        //     Optional GUIStyle to use for the label.
        //
        // 返回结果:
        //     The value set by the user.
        [ExcludeFromDocs]
        public static bool ToggleLeft(Rect position, GUIContent label, bool value);
        //
        // 摘要:
        //     Makes a toggle field where the toggle is to the left and the label immediately
        //     to the right of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Label to display next to the toggle.
        //
        //   value:
        //     The value to edit.
        //
        //   labelStyle:
        //     Optional GUIStyle to use for the label.
        //
        // 返回结果:
        //     The value set by the user.
        public static bool ToggleLeft(Rect position, GUIContent label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle);
        //
        // 摘要:
        //     Makes a toggle field where the toggle is to the left and the label immediately
        //     to the right of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Label to display next to the toggle.
        //
        //   value:
        //     The value to edit.
        //
        //   labelStyle:
        //     Optional GUIStyle to use for the label.
        //
        // 返回结果:
        //     The value set by the user.
        [ExcludeFromDocs]
        public static bool ToggleLeft(Rect position, string label, bool value);
        //
        // 摘要:
        //     Makes a toggle field where the toggle is to the left and the label immediately
        //     to the right of it.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the toggle.
        //
        //   label:
        //     Label to display next to the toggle.
        //
        //   value:
        //     The value to edit.
        //
        //   labelStyle:
        //     Optional GUIStyle to use for the label.
        //
        // 返回结果:
        //     The value set by the user.
        public static bool ToggleLeft(Rect position, string label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle);
        //
        // 摘要:
        //     Makes an X and Y field for entering a Vector2.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2 Vector2Field(Rect position, string label, Vector2 value);
        //
        // 摘要:
        //     Makes an X and Y field for entering a Vector2.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2 Vector2Field(Rect position, GUIContent label, Vector2 value);
        //
        // 摘要:
        //     Makes an X and Y integer field for entering a Vector2Int.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2Int Vector2IntField(Rect position, string label, Vector2Int value);
        //
        // 摘要:
        //     Makes an X and Y integer field for entering a Vector2Int.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2Int Vector2IntField(Rect position, GUIContent label, Vector2Int value);
        //
        // 摘要:
        //     Makes an X, Y, and Z field for entering a Vector3.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3 Vector3Field(Rect position, string label, Vector3 value);
        //
        // 摘要:
        //     Makes an X, Y, and Z field for entering a Vector3.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3 Vector3Field(Rect position, GUIContent label, Vector3 value);
        //
        // 摘要:
        //     Makes an X, Y, and Z integer field for entering a Vector3Int.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3Int Vector3IntField(Rect position, string label, Vector3Int value);
        //
        // 摘要:
        //     Makes an X, Y, and Z integer field for entering a Vector3Int.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3Int Vector3IntField(Rect position, GUIContent label, Vector3Int value);
        //
        // 摘要:
        //     Makes an X, Y, Z, and W field for entering a Vector4.
        //
        // 参数:
        //   position:
        //     Rectangle on the screen to use for the field.
        //
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector4 Vector4Field(Rect position, string label, Vector4 value);
        public static Vector4 Vector4Field(Rect position, GUIContent label, Vector4 value);

        //
        // 摘要:
        //     Create a group of controls that can be disabled.
        public struct DisabledScope : IDisposable
        {
            //
            // 摘要:
            //     Create a new DisabledScope and begin the corresponding group.
            //
            // 参数:
            //   disabled:
            //     Boolean specifying if the controls inside the group should be disabled.
            public DisabledScope(bool disabled);

            public void Dispose();
        }

        //
        // 摘要:
        //     Check if any control was changed inside a block of code.
        public class ChangeCheckScope : GUI.Scope
        {
            //
            // 摘要:
            //     Begins a ChangeCheckScope.
            public ChangeCheckScope();

            //
            // 摘要:
            //     True if GUI.changed was set to true, otherwise false.
            public bool changed { get; }

            protected override void CloseScope();
        }
        //
        // 摘要:
        //     Scope for managing the indent level of the field labels.
        public class IndentLevelScope : GUI.Scope
        {
            //
            // 摘要:
            //     Creates an IndentLevelScope and increases the EditorGUI indent level.
            //
            // 参数:
            //   increment:
            //     The EditorGUI indent level will be increased by this amount inside the scope.
            public IndentLevelScope();
            //
            // 摘要:
            //     Creates an IndentLevelScope and increases the EditorGUI indent level.
            //
            // 参数:
            //   increment:
            //     The EditorGUI indent level will be increased by this amount inside the scope.
            public IndentLevelScope(int increment);

            protected override void CloseScope();
        }
        //
        // 摘要:
        //     Create a group of controls that can be disabled.
        public class DisabledGroupScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new DisabledGroupScope and begin the corresponding group.
            //
            // 参数:
            //   disabled:
            //     Boolean specifying if the controls inside the group should be disabled.
            public DisabledGroupScope(bool disabled);

            protected override void CloseScope();
        }
        //
        // 摘要:
        //     Create a Property wrapper, useful for making regular GUI controls work with SerializedProperty.
        public class PropertyScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new PropertyScope and begin the corresponding property.
            //
            // 参数:
            //   totalPosition:
            //     Rectangle on the screen to use for the control, including label if applicable.
            //
            //   label:
            //     Label in front of the slider. Use null to use the name from the SerializedProperty.
            //     Use GUIContent.none to not display a label.
            //
            //   property:
            //     The SerializedProperty to use for the control.
            public PropertyScope(Rect totalPosition, GUIContent label, SerializedProperty property);

            //
            // 摘要:
            //     The actual label to use for the control.
            public GUIContent content { get; protected set; }

            protected override void CloseScope();
        }
    }
}
