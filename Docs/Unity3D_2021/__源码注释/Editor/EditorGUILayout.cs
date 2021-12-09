#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Internal;

namespace UnityEditor
{
    //
    // 摘要:
    //     Auto laid out version of EditorGUI.
    public sealed class EditorGUILayout//EditorGUILayout__RR
    {
        public EditorGUILayout();

        //
        // 摘要:
        //     Begin a build target grouping and get the selected BuildTargetGroup back.
        public static BuildTargetGroup BeginBuildTargetSelectionGrouping();
        //
        // 摘要:
        //     Begins a group that can be be hidden/shown and the transition will be animated.
        //
        // 参数:
        //   value:
        //     A value between 0 and 1, 0 being hidden, and 1 being fully visible.
        //
        // 返回结果:
        //     If the group is visible or not.
        public static bool BeginFadeGroup(float value);
        public static bool BeginFoldoutHeaderGroup(bool foldout, string content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null);
        public static bool BeginFoldoutHeaderGroup(bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null);
        //
        // 摘要:
        //     Begin a horizontal group and get its rect back.
        //
        // 参数:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect BeginHorizontal(params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a horizontal group and get its rect back.
        //
        // 参数:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect BeginHorizontal(GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin an automatically laid out scrollview.
        //
        // 参数:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin an automatically laid out scrollview.
        //
        // 参数:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin an automatically laid out scrollview.
        //
        // 参数:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin an automatically laid out scrollview.
        //
        // 参数:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical group with a toggle to enable or disable all the controls within
        //     at once.
        //
        // 参数:
        //   label:
        //     Label to show above the toggled controls.
        //
        //   toggle:
        //     Enabled state of the toggle group.
        //
        // 返回结果:
        //     The enabled state selected by the user.
        public static bool BeginToggleGroup(string label, bool toggle);
        //
        // 摘要:
        //     Begin a vertical group with a toggle to enable or disable all the controls within
        //     at once.
        //
        // 参数:
        //   label:
        //     Label to show above the toggled controls.
        //
        //   toggle:
        //     Enabled state of the toggle group.
        //
        // 返回结果:
        //     The enabled state selected by the user.
        public static bool BeginToggleGroup(GUIContent label, bool toggle);
        //
        // 摘要:
        //     Begin a vertical group and get its rect back.
        //
        // 参数:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect BeginVertical(GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical group and get its rect back.
        //
        // 参数:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect BeginVertical(params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Center & Extents field for entering a Bounds.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Bounds BoundsField(string label, Bounds value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Center & Extents field for entering a Bounds.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Bounds BoundsField(Bounds value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Center & Extents field for entering a Bounds.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Bounds BoundsField(GUIContent label, Bounds value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Position & Size field for entering a BoundsInt.
        //
        // 参数:
        //   label:
        //     Make Position & Size field for entering a Bounds.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(string label, BoundsInt value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Position & Size field for entering a BoundsInt.
        //
        // 参数:
        //   label:
        //     Make Position & Size field for entering a Bounds.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(GUIContent label, BoundsInt value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make Position & Size field for entering a BoundsInt.
        //
        // 参数:
        //   label:
        //     Make Position & Size field for entering a Bounds.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static BoundsInt BoundsIntField(BoundsInt value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for selecting a Color.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(Color value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for selecting a Color.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(string label, Color value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for selecting a Color.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(GUIContent label, Color value, params GUILayoutOption[] options);
        
        
        /*
        [Obsolete("Use EditorGUILayout.ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, params GUILayoutOption[] options)")]
        public static Color ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, ColorPickerHDRConfig hdrConfig, params GUILayoutOption[] options);
        */


        //
        // 摘要:
        //     Make a field for selecting a Color.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     The color selected by the user.
        public static Color ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
        //   property:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   label:
        //     Optional label to display in front of the field. Pass [[GUIContent.none] to hide
        //     the label.
        public static void CurveField(SerializedProperty property, Color color, Rect ranges, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
        //   property:
        //     The curve to edit.
        //
        //   color:
        //     The color to show the curve with.
        //
        //   ranges:
        //     Optional rectangle that the curve is restrained within.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   label:
        //     Optional label to display in front of the field. Pass [[GUIContent.none] to hide
        //     the label.
        public static void CurveField(SerializedProperty property, Color color, Rect ranges, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(GUIContent label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(string label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(GUIContent label, AnimationCurve value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(string label, AnimationCurve value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing an AnimationCurve.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The curve edited by the user.
        public static AnimationCurve CurveField(AnimationCurve value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(GUIContent label, double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(string label, double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering doubles.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the double field.
        public static double DelayedDoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   property:
        //     The float property to edit.
        //
        //   label:
        //     Optional label to display in front of the float field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedFloatField(SerializedProperty property, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(string label, float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(GUIContent label, float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   property:
        //     The float property to edit.
        //
        //   label:
        //     Optional label to display in front of the float field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedFloatField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering floats.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the float field.
        public static float DelayedFloatField(float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(string label, int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(string label, int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(GUIContent label, int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   property:
        //     The int property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedIntField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   property:
        //     The int property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedIntField(SerializedProperty property, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the int field.
        public static int DelayedIntField(int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(GUIContent label, string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   property:
        //     The text property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedTextField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   property:
        //     The text property to edit.
        //
        //   label:
        //     Optional label to display in front of the int field. Pass GUIContent.none to
        //     hide label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void DelayedTextField(SerializedProperty property, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(string label, string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(string label, string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a delayed text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user. Note that the return value will not change until
        //     the user has pressed enter or focus is moved away from the text field.
        public static string DelayedTextField(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(GUIContent label, double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering double values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the double field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static double DoubleField(string label, double value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a button that reacts to mouse down, for displaying your own dropdown content.
        //
        // 参数:
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   focusType:
        //     Whether the button should be selectable by keyboard or not.
        //
        //   style:
        //     Optional style to use.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the user clicks the button.
        public static bool DropdownButton(GUIContent content, FocusType focusType, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a button that reacts to mouse down, for displaying your own dropdown content.
        //
        // 参数:
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   focusType:
        //     Whether the button should be selectable by keyboard or not.
        //
        //   style:
        //     Optional style to use.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the user clicks the button.
        public static bool DropdownButton(GUIContent content, FocusType focusType, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Makes a toolbar populated with the specified collection of editor tools.
        //
        // 参数:
        //   tools:
        //     The collection of editor tools for the toolbar.
        public static void EditorToolbar(params EditorTool[] tools);
        public static void EditorToolbar<T>(IList<T> tools) where T : EditorTool;
        //
        // 摘要:
        //     Makes a toolbar populated with the collection of editor tools that match the
        //     EditorToolAttribute of the target object.
        //
        // 参数:
        //   target:
        //     The target object.
        //
        //   content:
        //     An optional prefix label.
        public static void EditorToolbarForTarget(UnityEngine.Object target);
        //
        // 摘要:
        //     Makes a toolbar populated with the collection of editor tools that match the
        //     EditorToolAttribute of the target object.
        //
        // 参数:
        //   target:
        //     The target object.
        //
        //   content:
        //     An optional prefix label.
        public static void EditorToolbarForTarget(GUIContent content, UnityEngine.Object target);
        //
        // 摘要:
        //     Close a group started with BeginBuildTargetSelectionGrouping.
        public static void EndBuildTargetSelectionGrouping();
        //
        // 摘要:
        //     Closes a group started with BeginFadeGroup.
        public static void EndFadeGroup();
        //
        // 摘要:
        //     Closes a group started with BeginFoldoutHeaderGroup.
        public static void EndFoldoutHeaderGroup();
        //
        // 摘要:
        //     Close a group started with BeginHorizontal.
        public static void EndHorizontal();
        //
        // 摘要:
        //     Ends a scrollview started with a call to BeginScrollView.
        public static void EndScrollView();
        //
        // 摘要:
        //     Close a group started with BeginToggleGroup.
        public static void EndToggleGroup();
        //
        // 摘要:
        //     Close a group started with BeginVertical.
        public static void EndVertical();
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(string label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(string label, Enum enumValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Enum enumValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Displays a menu with an option for every value of the enum type when clicked.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the enum flags field.
        //
        //   enumValue:
        //     Enum flags value.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   includeObsolete:
        //     Set to true to include Enum values with ObsoleteAttribute. Set to false to exclude
        //     Enum values with ObsoleteAttribute.
        //
        // 返回结果:
        //     The enum flags value modified by the user. This is a selection BitMask where
        //     each bit represents an Enum value index. (Note this returned value is not itself
        //     an Enum).
        public static Enum EnumFlagsField(Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        

        /*
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(string label, Enum enumValue, params GUILayoutOption[] options);

        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(GUIContent label, Enum enumValue, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(string label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(Enum enumValue, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskField has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskField(GUIContent label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(string label, Enum selected, GUIStyle style, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(GUIContent label, Enum selected, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(GUIContent label, Enum selected, GUIStyle style, params GUILayoutOption[] options);
        
        [Obsolete("EnumMaskPopup has been deprecated. Use EnumFlagsField instead.")]
        public static Enum EnumMaskPopup(string label, Enum selected, params GUILayoutOption[] options);
        */

        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(Enum selected, GUIStyle style, params GUILayoutOption[] options);

        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(Enum selected, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(string label, Enum selected, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(string label, Enum selected, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(GUIContent label, Enum selected, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an enum popup selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   selected:
        //     The enum option the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
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
        public static Enum EnumPopup(GUIContent label, Enum selected, GUIStyle style, params GUILayoutOption[] options);
        public static Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options);
        public static Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(string label, float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(GUIContent label, float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering float values.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the float field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static float FloatField(float value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        [ExcludeFromDocs]
        public static bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        [ExcludeFromDocs]
        public static bool Foldout(bool foldout, string content, bool toggleOnLabelClick);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(bool foldout, GUIContent content);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        public static bool Foldout(bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style);
        //
        // 摘要:
        //     Make a label with a foldout arrow to the left of it.
        //
        // 参数:
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
        //     Specifies whether clicking the label toggles the foldout state. The default value
        //     is false. Set to true to include the label in the clickable area.
        //
        // 返回结果:
        //     The foldout state selected by the user. If true, you should render sub-objects.
        [ExcludeFromDocs]
        public static bool Foldout(bool foldout, string content);
        //
        // 摘要:
        //     Get a rect for an Editor control.
        //
        // 参数:
        //   hasLabel:
        //     Optional boolean to specify if the control has a label. Default is true.
        //
        //   height:
        //     The height in pixels of the control. Default is EditorGUIUtility.singleLineHeight.
        //
        //   style:
        //     Optional GUIStyle to use for the control.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Get a rect for an Editor control.
        //
        // 参数:
        //   hasLabel:
        //     Optional boolean to specify if the control has a label. Default is true.
        //
        //   height:
        //     The height in pixels of the control. Default is EditorGUIUtility.singleLineHeight.
        //
        //   style:
        //     Optional GUIStyle to use for the control.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect GetControlRect(bool hasLabel, float height, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Get a rect for an Editor control.
        //
        // 参数:
        //   hasLabel:
        //     Optional boolean to specify if the control has a label. Default is true.
        //
        //   height:
        //     The height in pixels of the control. Default is EditorGUIUtility.singleLineHeight.
        //
        //   style:
        //     Optional GUIStyle to use for the control.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect GetControlRect(bool hasLabel, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Get a rect for an Editor control.
        //
        // 参数:
        //   hasLabel:
        //     Optional boolean to specify if the control has a label. Default is true.
        //
        //   height:
        //     The height in pixels of the control. Default is EditorGUIUtility.singleLineHeight.
        //
        //   style:
        //     Optional GUIStyle to use for the control.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static Rect GetControlRect(params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing a Gradient.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The gradient to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdr:
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(Gradient value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing a Gradient.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The gradient to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdr:
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(string label, Gradient value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing a Gradient.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The gradient to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdr:
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(GUIContent label, Gradient value, bool hdr, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for editing a Gradient.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the field.
        //
        //   value:
        //     The gradient to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   hdr:
        //
        // 返回结果:
        //     The gradient edited by the user.
        public static Gradient GradientField(GUIContent label, Gradient value, params GUILayoutOption[] options);
        public static void HelpBox(GUIContent content, bool wide = true);
        //
        // 摘要:
        //     Make a help box with a message to the user.
        //
        // 参数:
        //   message:
        //     The message text.
        //
        //   type:
        //     The type of message.
        //
        //   wide:
        //     If true, the box will cover the whole width of the window; otherwise it will
        //     cover the controls part only.
        public static void HelpBox(string message, MessageType type, bool wide);
        //
        // 摘要:
        //     Make a help box with a message to the user.
        //
        // 参数:
        //   message:
        //     The message text.
        //
        //   type:
        //     The type of message.
        //
        //   wide:
        //     If true, the box will cover the whole width of the window; otherwise it will
        //     cover the controls part only.
        public static void HelpBox(string message, MessageType type);
        public static void InspectorTitlebar(UnityEngine.Object[] targetObjs);
        public static bool InspectorTitlebar(bool foldout, Editor editor);
        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object[] targetObjs, bool expandable);
        //
        // 摘要:
        //     Make an inspector-window-like titlebar.
        //
        // 参数:
        //   foldout:
        //     The foldout state shown with the arrow.
        //
        //   targetObj:
        //     The object (for example a component) or objects that the titlebar is for.
        //
        //   targetObjs:
        //
        // 返回结果:
        //     The foldout state selected by the user.
        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object[] targetObjs);
        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object targetObj, bool expandable);
        //
        // 摘要:
        //     Make an inspector-window-like titlebar.
        //
        // 参数:
        //   foldout:
        //     The foldout state shown with the arrow.
        //
        //   targetObj:
        //     The object (for example a component) or objects that the titlebar is for.
        //
        //   targetObjs:
        //
        // 返回结果:
        //     The foldout state selected by the user.
        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object targetObj);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(string label, int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(string label, int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the int field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static int IntField(GUIContent label, int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
        //   property:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
        //   property:
        //     The value of the option the field shows.
        //
        //   displayedOptions:
        //     An array with the displayed options the user can choose from.
        //
        //   optionValues:
        //     An array with the values for each option.
        //
        //   label:
        //     Optional label in front of the field.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options);
        
        /*
        [Obsolete("This function is obsolete and the style is not used.")]
        public static void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, GUIStyle style, params GUILayoutOption[] options);
        */

        
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an integer popup selection field.
        //
        // 参数:
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
        //     An array with the values for each option.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value of the option that has been selected by the user.
        public static int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, string label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(GUIContent label, int value, int leftValue, int rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(string label, int value, int leftValue, int rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a slider the user can drag to change an integer value between a min and
        //     a max.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static int IntSlider(int value, int leftValue, int rightValue, params GUILayoutOption[] options);
        public static float Knob(Vector2 knobSize, float value, float minValue, float maxValue, string unit, Color backgroundColor, Color activeColor, bool showValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(GUIContent label, GUIContent label2, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(string label, string label2, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(GUIContent label, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(string label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(GUIContent label, GUIContent label2, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(string label, string label2, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a label field. (Useful for showing read-only info.)
        //
        // 参数:
        //   label:
        //     Label in front of the label field.
        //
        //   label2:
        //     The label to show to the right.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   style:
        public static void LabelField(string label, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(string label, int layer, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(int layer, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(int layer, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(string label, int layer, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(GUIContent label, int layer, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a layer selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   layer:
        //     The layer shown in the field.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The layer selected by the user.
        public static int LayerField(GUIContent label, int layer, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a clickable link label.
        //
        // 参数:
        //   label:
        //     Label of the link.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the user clicks the link.
        public static bool LinkButton(string label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a clickable link label.
        //
        // 参数:
        //   label:
        //     Label of the link.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the user clicks the link.
        public static bool LinkButton(GUIContent label, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(GUIContent label, long value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(string label, long value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(long value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(long value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(string label, long value, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field for entering long integers.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the long field.
        //
        //   value:
        //     The value to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static long LongField(GUIContent label, long value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(string label, int mask, string[] displayedOptions, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(GUIContent label, int mask, string[] displayedOptions, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(string label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(GUIContent label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field for masks.
        //
        // 参数:
        //   label:
        //     Prefix label of the field.
        //
        //   mask:
        //     The current mask to display.
        //
        //   displayedOption:
        //     A string array containing the labels for each flag.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   displayedOptions:
        //
        //   style:
        //
        // 返回结果:
        //     The value modified by the user.
        public static int MaskField(int mask, string[] displayedOptions, params GUILayoutOption[] options);
        public static void MinMaxSlider(GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options);
        public static void MinMaxSlider(ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options);
        public static void MinMaxSlider(string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options);
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        public static UnityEngine.Object ObjectField(GUIContent label, UnityEngine.Object obj, Type objType, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field to receive any object type.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The object that has been set by the user.
        public static UnityEngine.Object ObjectField(string label, UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options);
        public static UnityEngine.Object ObjectField(string label, UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited, params GUILayoutOption[] options);
        public static UnityEngine.Object ObjectField(GUIContent label, UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited, params GUILayoutOption[] options);
        
        
        /*
        public static UnityEngine.Object ObjectField(GUIContent label, UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options);
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        public static UnityEngine.Object ObjectField(string label, UnityEngine.Object obj, Type objType, params GUILayoutOption[] options);
        [Obsolete("Check the docs for the usage of the new parameter 'allowSceneObjects'.")]
        */
        
        public static UnityEngine.Object ObjectField(UnityEngine.Object obj, Type objType, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field to receive any object type.
        //
        // 参数:
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label in front of the field. Pass GUIContent.none to hide the label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void ObjectField(SerializedProperty property, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a field to receive any object type.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style. See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The object that has been set by the user.
        public static UnityEngine.Object ObjectField(UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options);
        public static UnityEngine.Object ObjectField(UnityEngine.Object obj, Type objType, UnityEngine.Object targetBeingEdited, params GUILayoutOption[] options);
        
        //
        // 摘要:
        //     Make a field to receive any object type.
        //
        // 参数:
        //   property:
        //     The object reference property the field shows.
        //
        //   objType:
        //     The type of the objects that can be assigned.
        //
        //   label:
        //     Optional label in front of the field. Pass GUIContent.none to hide the label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void ObjectField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options);
        public static void ObjectField(SerializedProperty property, Type objType, params GUILayoutOption[] options);
        public static void ObjectField(SerializedProperty property, Type objType, GUIContent label, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a text field where the user can enter a password.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the password field.
        //
        //   password:
        //     The password to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The password entered by the user.
        public static string PasswordField(string password, params GUILayoutOption[] options);
        public static string PasswordField(GUIContent label, string password, GUIStyle style, params GUILayoutOption[] options);
        public static string PasswordField(GUIContent label, string password, params GUILayoutOption[] options);
        public static string PasswordField(string label, string password, GUIStyle style, params GUILayoutOption[] options);
        public static string PasswordField(string label, string password, params GUILayoutOption[] options);
        public static string PasswordField(string password, GUIStyle style, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a generic popup selection field.
        //
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The index of the option that has been selected by the user.
        public static int Popup(string label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options);
        public static int Popup(int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        public static int Popup(int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options);
        public static int Popup(int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        public static int Popup(GUIContent label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options);
        public static int Popup(string label, int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        public static int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options);
        public static int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options);
        public static int Popup(int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a label in front of some control.
        //
        // 参数:
        //   label:
        //     Label to show to the left of the control.
        //
        //   followingStyle:
        //
        //   labelStyle:
        [ExcludeFromDocs]
        public static void PrefixLabel(GUIContent label);
        public static void PrefixLabel(string label, GUIStyle followingStyle, GUIStyle labelStyle);
        public static void PrefixLabel(string label, [DefaultValue("\"Button\"")] GUIStyle followingStyle);
        [ExcludeFromDocs]public static void PrefixLabel(string label);
        public static void PrefixLabel(GUIContent label, [DefaultValue("\"Button\"")] GUIStyle followingStyle);
        public static void PrefixLabel(GUIContent label, GUIStyle followingStyle, GUIStyle labelStyle);


        /*
            摘要:
                Make a field for SerializedProperty.
        
        
        // 参数:
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
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
                True if the property has children and is expanded and includeChildren was set to false; 
                otherwise false.
        */
        public static bool PropertyField(SerializedProperty property, GUIContent label, bool includeChildren, params GUILayoutOption[] options);
        public static bool PropertyField(SerializedProperty property, params GUILayoutOption[] options);
        public static bool PropertyField(SerializedProperty property, bool includeChildren, params GUILayoutOption[] options);
        public static bool PropertyField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make an X, Y, W & H field for entering a Rect.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Rect RectField(Rect value, params GUILayoutOption[] options);
        public static Rect RectField(string label, Rect value, params GUILayoutOption[] options);
        public static Rect RectField(GUIContent label, Rect value, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make an X, Y, W & H field for entering a RectInt.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static RectInt RectIntField(GUIContent label, RectInt value, params GUILayoutOption[] options);
        public static RectInt RectIntField(string label, RectInt value, params GUILayoutOption[] options);
        public static RectInt RectIntField(RectInt value, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a selectable label field. (Useful for showing read-only info that can be
        //     copy-pasted.)
        //
        // 参数:
        //   text:
        //     The text to show.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void SelectableLabel(string text, GUIStyle style, params GUILayoutOption[] options);
        public static void SelectableLabel(string text, params GUILayoutOption[] options);


        public static void Separator();


        //
        // 摘要:
        //     Make a slider the user can drag to change a value between a min and a max.
        //
        // 参数:
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
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Slider(SerializedProperty property, float leftValue, float rightValue, string label, params GUILayoutOption[] options);
        public static void Slider(SerializedProperty property, float leftValue, float rightValue, GUIContent label, params GUILayoutOption[] options);

        // 返回结果:
        //     The value that has been set by the user.
        public static float Slider(GUIContent label, float value, float leftValue, float rightValue, params GUILayoutOption[] options);
        public static float Slider(string label, float value, float leftValue, float rightValue, params GUILayoutOption[] options);
        public static float Slider(float value, float leftValue, float rightValue, params GUILayoutOption[] options);
        public static void Slider(SerializedProperty property, float leftValue, float rightValue, params GUILayoutOption[] options);




        public static void Space(float width, bool expand);
        //
        // 摘要:
        //     Make a small space between the previous control and the following.
        public static void Space();
        public static void Space(float width);


        //
        // 摘要:
        //     Make a tag selection field.
        //
        // 参数:
        //   label:
        //     Optional label in front of the field.
        //
        //   tag:
        //     The tag the field shows.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The tag selected by the user.
        public static string TagField(string tag, GUIStyle style, params GUILayoutOption[] options);
        public static string TagField(GUIContent label, string tag, GUIStyle style, params GUILayoutOption[] options);
        public static string TagField(GUIContent label, string tag, params GUILayoutOption[] options);
        public static string TagField(string label, string tag, GUIStyle style, params GUILayoutOption[] options);
        public static string TagField(string label, string tag, params GUILayoutOption[] options);
        public static string TagField(string tag, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a text area.
        //
        // 参数:
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextArea(string text, params GUILayoutOption[] options);
        public static string TextArea(string text, GUIStyle style, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a text field.
        //
        // 参数:
        //   label:
        //     Optional label to display in front of the text field.
        //
        //   text:
        //     The text to edit.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The text entered by the user.
        public static string TextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options);
        public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options);
        public static string TextField(GUIContent label, string text, params GUILayoutOption[] options);
        public static string TextField(string label, string text, GUIStyle style, params GUILayoutOption[] options);
        public static string TextField(string label, string text, params GUILayoutOption[] options);
        public static string TextField(string text, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a toggle.
        //
        // 参数:
        //   label:
        //     Optional label in front of the toggle.
        //
        //   value:
        //     The shown state of the toggle.
        //
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The selected state of the toggle.
        public static bool Toggle(bool value, params GUILayoutOption[] options);
        public static bool Toggle(string label, bool value, params GUILayoutOption[] options);
        public static bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options);
        public static bool Toggle(bool value, GUIStyle style, params GUILayoutOption[] options);
        public static bool Toggle(string label, bool value, GUIStyle style, params GUILayoutOption[] options);
        public static bool Toggle(GUIContent label, bool value, GUIStyle style, params GUILayoutOption[] options);


        //
        // 摘要:
        //     Make a toggle field where the toggle is to the left and the label immediately
        //     to the right of it.
        //
        // 参数:
        //   label:
        //     Label to display next to the toggle.
        //
        //   value:
        //     The value to edit.
        //
        //   labelStyle:
        //     Optional GUIStyle to use for the label.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static bool ToggleLeft(GUIContent label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options);
        public static bool ToggleLeft(string label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options);
        public static bool ToggleLeft(string label, bool value, params GUILayoutOption[] options);
        public static bool ToggleLeft(GUIContent label, bool value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an X & Y field for entering a Vector2.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br>
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2 Vector2Field(GUIContent label, Vector2 value, params GUILayoutOption[] options);
        public static Vector2 Vector2Field(string label, Vector2 value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an X & Y integer field for entering a Vector2Int.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector2Int Vector2IntField(GUIContent label, Vector2Int value, params GUILayoutOption[] options);
        public static Vector2Int Vector2IntField(string label, Vector2Int value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an X, Y & Z field for entering a Vector3.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3 Vector3Field(GUIContent label, Vector3 value, params GUILayoutOption[] options);
        public static Vector3 Vector3Field(string label, Vector3 value, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an X, Y & Z integer field for entering a Vector3Int.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector3Int Vector3IntField(GUIContent label, Vector3Int value, params GUILayoutOption[] options);
        public static Vector3Int Vector3IntField(string label, Vector3Int value, params GUILayoutOption[] options);

        //
        // 摘要:
        //     Make an X, Y, Z & W field for entering a Vector4.
        //
        // 参数:
        //   label:
        //     Label to display above the field.
        //
        //   value:
        //     The value to edit.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The value entered by the user.
        public static Vector4 Vector4Field(string label, Vector4 value, params GUILayoutOption[] options);
        public static Vector4 Vector4Field(GUIContent label, Vector4 value, params GUILayoutOption[] options);

        //
        // 摘要:
        //     Begin a vertical group with a toggle to enable or disable all the controls within
        //     at once.
        public class ToggleGroupScope : GUI.Scope
        {
            //
            // 参数:
            //   label:
            //     Label to show above the toggled controls.
            //
            //   toggle:
            //     Enabled state of the toggle group.
            public ToggleGroupScope(string label, bool toggle);
            public ToggleGroupScope(GUIContent label, bool toggle);

            //
            // 摘要:
            //     The enabled state selected by the user.
            public bool enabled { get; protected set; }

            protected override void CloseScope();
        }
        //
        // 摘要:
        //     Disposable helper class for managing BeginHorizontal / EndHorizontal.
        public class HorizontalScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new HorizontalScope and begin the corresponding horizontal group.
            //
            // 参数:
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public HorizontalScope(params GUILayoutOption[] options);
            public HorizontalScope(GUIStyle style, params GUILayoutOption[] options);

            //
            // 摘要:
            //     The rect of the horizontal group.
            public Rect rect { get; protected set; }

            protected override void CloseScope();
        }


        //
        // 摘要:
        //     Disposable helper class for managing BeginVertical / EndVertical.
        public class VerticalScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new VerticalScope and begin the corresponding vertical group.
            //
            // 参数:
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public VerticalScope(params GUILayoutOption[] options);
            public VerticalScope(GUIStyle style, params GUILayoutOption[] options);

            //
            // 摘要:
            //     The rect of the vertical group.
            public Rect rect { get; protected set; }

            protected override void CloseScope();
        }


        //
        // 摘要:
        //     Disposable helper class for managing BeginScrollView / EndScrollView.
        public class ScrollViewScope : GUI.Scope
        {

            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The scroll position to use.
            //
            //   alwaysShowHorizontal:
            //     Whether to always show the horizontal scrollbar. If false, it is only shown when
            //     the content inside the ScrollView is wider than the scrollview itself.
            //
            //   alwaysShowVertical:
            //     Whether to always show the vertical scrollbar. If false, it is only shown when
            //     the content inside the ScrollView is higher than the scrollview itself.
            //
            //   horizontalScrollbar:
            //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
            //     style from the current GUISkin is used.
            //
            //   verticalScrollbar:
            //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
            //     style from the current GUISkin is used.
            //
            //   options:
            //
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, params GUILayoutOption[] options);
            public ScrollViewScope(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options);
            public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options);
            public ScrollViewScope(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
            public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options);


            //
            // 摘要:
            //     The modified scrollPosition. Feed this back into the variable you pass in, as
            //     shown in the example.
            public Vector2 scrollPosition { get; protected set; }
            //
            // 摘要:
            //     Whether this ScrollView should handle scroll wheel events. (default: true).
            public bool handleScrollWheel { get; set; }

            protected override void CloseScope();
        }
        //
        // 摘要:
        //     Begins a group that can be be hidden/shown and the transition will be animated.
        public class FadeGroupScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new FadeGroupScope and begin the corresponding group.
            //
            // 参数:
            //   value:
            //     A value between 0 and 1, 0 being hidden, and 1 being fully visible.
            public FadeGroupScope(float value);

            //
            // 摘要:
            //     Whether the group is visible.
            public bool visible { get; protected set; }

            protected override void CloseScope();
        }
    }
}

