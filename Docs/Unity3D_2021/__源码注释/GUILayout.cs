#region 程序集 UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.IMGUIModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     The GUILayout class is the interface for Unity gui with automatic layout.
    public class GUILayout
    {
        public GUILayout();

        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, string text, GUIStyle style);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, Texture image, GUIStyle style);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, Texture image);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, string text);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, GUIStyle style);
        //
        // 摘要:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // 参数:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static void BeginArea(Rect screenRect, GUIContent content);
        //
        // 摘要:
        //     Begin a Horizontal control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginHorizontal(params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a Horizontal control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a Horizontal control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginHorizontal(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a Horizontal control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginHorizontal(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a Horizontal control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginHorizontal(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
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
        //   style:
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
        //   style:
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
        //   style:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
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
        //   style:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style);
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
        //   style:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
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
        //   style:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
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
        //   style:
        //
        //   background:
        //
        // 返回结果:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginVertical(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginVertical(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginVertical(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginVertical(params GUILayoutOption[] options);
        //
        // 摘要:
        //     Begin a vertical control group.
        //
        // 参数:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(Texture image, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout box.
        //
        // 参数:
        //   text:
        //     Text to display on the box.
        //
        //   image:
        //     Texture to display on the box.
        //
        //   content:
        //     Text, image and tooltip for this box.
        //
        //   style:
        //     The style to use. If left out, the box style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Box(GUIContent content, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(Texture image, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(GUIContent content, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single press button.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the users clicks the button.
        public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Close a GUILayout block started with BeginArea.
        public static void EndArea();
        //
        // 摘要:
        //     Close a group started with BeginHorizontal.
        public static void EndHorizontal();
        //
        // 摘要:
        //     End a scroll view begun with a call to BeginScrollView.
        public static void EndScrollView();
        //
        // 摘要:
        //     Close a group started with BeginVertical.
        public static void EndVertical();
        //
        // 摘要:
        //     Option passed to a control to allow or disallow vertical expansion.
        //
        // 参数:
        //   expand:
        public static GUILayoutOption ExpandHeight(bool expand);
        //
        // 摘要:
        //     Option passed to a control to allow or disallow horizontal expansion.
        //
        // 参数:
        //   expand:
        public static GUILayoutOption ExpandWidth(bool expand);

        /*
            Insert a flexible space element.

            可变相实现 "右对齐":

                EditorGUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace(); // 填充左侧空间, 变相让下面两个按钮 右对齐
                    
                    if (GUILayout.Button("( + )"))
                    {
                        Undo.RecordObject(target, "Insert");
                        pair_.list.Add( new UnityEngine.Object() );
                    }
                    if (GUILayout.Button("( - )"))
                    {
                        Undo.RecordObject(target, "Remove");
                        pair_.list.RemoveAt( pair_.list.Count - 1 );
                    }
                EditorGUILayout.EndHorizontal();

            如上例子:
        */
        public static void FlexibleSpace();


        //
        // 摘要:
        //     Option passed to a control to give it an absolute height.
        //
        // 参数:
        //   height:
        public static GUILayoutOption Height(float height);
        //
        // 摘要:
        //     Make a horizontal scrollbar.
        //
        // 参数:
        //   value:
        //     The position between min and max.
        //
        //   size:
        //     How much can we see?
        //
        //   leftValue:
        //     The value at the left end of the scrollbar.
        //
        //   rightValue:
        //     The value at the right end of the scrollbar.
        //
        //   style:
        //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The modified value. This can be changed by the user by dragging the scrollbar,
        //     or clicking the arrows at the end.
        public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a horizontal scrollbar.
        //
        // 参数:
        //   value:
        //     The position between min and max.
        //
        //   size:
        //     How much can we see?
        //
        //   leftValue:
        //     The value at the left end of the scrollbar.
        //
        //   rightValue:
        //     The value at the right end of the scrollbar.
        //
        //   style:
        //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The modified value. This can be changed by the user by dragging the scrollbar,
        //     or clicking the arrows at the end.
        public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     A horizontal slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        //   slider:
        //     The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider
        //     style from the current GUISkin is used.
        //
        //   thumb:
        //     The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float HorizontalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     A horizontal slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   leftValue:
        //     The value at the left end of the slider.
        //
        //   rightValue:
        //     The value at the right end of the slider.
        //
        //   slider:
        //     The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider
        //     style from the current GUISkin is used.
        //
        //   thumb:
        //     The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float HorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(Texture image, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(GUIContent content, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an auto-layout label.
        //
        // 参数:
        //   text:
        //     Text to display on the label.
        //
        //   image:
        //     Texture to display on the label.
        //
        //   content:
        //     Text, image and tooltip for this label.
        //
        //   style:
        //     The style to use. If left out, the label style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static void Label(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Option passed to a control to specify a maximum height.
        //
        // 参数:
        //   maxHeight:
        public static GUILayoutOption MaxHeight(float maxHeight);
        //
        // 摘要:
        //     Option passed to a control to specify a maximum width.
        //
        // 参数:
        //   maxWidth:
        public static GUILayoutOption MaxWidth(float maxWidth);
        //
        // 摘要:
        //     Option passed to a control to specify a minimum height.
        //
        // 参数:
        //   minHeight:
        public static GUILayoutOption MinHeight(float minHeight);
        //
        // 摘要:
        //     Option passed to a control to specify a minimum width.
        //
        // 参数:
        //   minWidth:
        public static GUILayoutOption MinWidth(float minWidth);
        //
        // 摘要:
        //     Make a text field where the user can enter a password.
        //
        // 参数:
        //   password:
        //     Password to edit. The return value of this function should be assigned back to
        //     the string as shown in the example.
        //
        //   maskChar:
        //     Character to mask the password with.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //
        // 返回结果:
        //     The edited password.
        public static string PasswordField(string password, char maskChar, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field where the user can enter a password.
        //
        // 参数:
        //   password:
        //     Password to edit. The return value of this function should be assigned back to
        //     the string as shown in the example.
        //
        //   maskChar:
        //     Character to mask the password with.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //
        // 返回结果:
        //     The edited password.
        public static string PasswordField(string password, char maskChar, int maxLength, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field where the user can enter a password.
        //
        // 参数:
        //   password:
        //     Password to edit. The return value of this function should be assigned back to
        //     the string as shown in the example.
        //
        //   maskChar:
        //     Character to mask the password with.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //
        // 返回结果:
        //     The edited password.
        public static string PasswordField(string password, char maskChar, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a text field where the user can enter a password.
        //
        // 参数:
        //   password:
        //     Password to edit. The return value of this function should be assigned back to
        //     the string as shown in the example.
        //
        //   maskChar:
        //     Character to mask the password with.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //
        // 返回结果:
        //     The edited password.
        public static string PasswordField(string password, char maskChar, int maxLength, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(Texture image, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a repeating button. The button returns true as long as the user holds down
        //     the mouse.
        //
        // 参数:
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     true when the holds down the mouse.
        public static bool RepeatButton(GUIContent content, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, GUIContent[] contents, int xCount, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, string[] texts, int xCount, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, Texture[] images, int xCount, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, string[] texts, int xCount, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, GUIContent[] content, int xCount, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a Selection Grid.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   xCount:
        //     How many elements to fit in the horizontal direction. The elements will be scaled
        //     to fit unless the style defines a fixedWidth to use. The height of the control
        //     will be determined from the number of elements.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   content:
        //
        // 返回结果:
        //     The index of the selected button.
        public static int SelectionGrid(int selected, Texture[] images, int xCount, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Insert a space in the current layout group.
        //
        // 参数:
        //   pixels:
        public static void Space(float pixels);
        //
        // 摘要:
        //     Make a multi-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.&amp;lt;br&amp;gt;
        //     See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth,
        //     GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextArea(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a multi-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.&amp;lt;br&amp;gt;
        //     See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth,
        //     GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextArea(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a multi-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.&amp;lt;br&amp;gt;
        //     See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth,
        //     GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextArea(string text, int maxLength, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a multi-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textField style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.&amp;lt;br&amp;gt;
        //     See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth,
        //     GUILayout.MinHeight, GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextArea(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textArea style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textArea style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextField(string text, int maxLength, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textArea style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextField(string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a single-line text field where the user can edit a string.
        //
        // 参数:
        //   text:
        //     Text to edit. The return value of this function should be assigned back to the
        //     string as shown in the example.
        //
        //   maxLength:
        //     The maximum length of the string. If left out, the user can type for ever and
        //     ever.
        //
        //   style:
        //     The style to use. If left out, the textArea style from the current GUISkin is
        //     used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The edited string.
        public static string TextField(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, Texture image, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, string text, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, GUIContent content, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, Texture image, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make an on/off toggle button.
        //
        // 参数:
        //   value:
        //     Is the button on or off?
        //
        //   text:
        //     Text to display on the button.
        //
        //   image:
        //     Texture to display on the button.
        //
        //   content:
        //     Text, image and tooltip for this button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        // 返回结果:
        //     The new value of the button.
        public static bool Toggle(bool value, string text, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, string[] texts, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, GUIContent[] contents, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, Texture[] images, GUIStyle style, params GUILayoutOption[] options);
        public static int Toolbar(int selected, Texture[] images, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, GUIContent[] contents, GUIStyle style, params GUILayoutOption[] options);
        public static int Toolbar(int selected, GUIContent[] contents, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options);
        public static int Toolbar(int selected, GUIContent[] contents, bool[] enabled, GUIStyle style, params GUILayoutOption[] options);
        public static int Toolbar(int selected, GUIContent[] contents, bool[] enabled, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a toolbar.
        //
        // 参数:
        //   selected:
        //     The index of the selected button.
        //
        //   texts:
        //     An array of strings to show on the buttons.
        //
        //   images:
        //     An array of textures on the buttons.
        //
        //   contents:
        //     An array of text, image and tooltips for the button.
        //
        //   style:
        //     The style to use. If left out, the button style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        //
        //   buttonSize:
        //     Determines how toolbar button size is calculated.
        //
        // 返回结果:
        //     The index of the selected button.
        public static int Toolbar(int selected, Texture[] images, params GUILayoutOption[] options);
        public static int Toolbar(int selected, string[] texts, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a vertical scrollbar.
        //
        // 参数:
        //   value:
        //     The position between min and max.
        //
        //   size:
        //     How much can we see?
        //
        //   topValue:
        //     The value at the top end of the scrollbar.
        //
        //   bottomValue:
        //     The value at the bottom end of the scrollbar.
        //
        //   style:
        //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The modified value. This can be changed by the user by dragging the scrollbar,
        //     or clicking the arrows at the end.
        public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, GUIStyle style, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Make a vertical scrollbar.
        //
        // 参数:
        //   value:
        //     The position between min and max.
        //
        //   size:
        //     How much can we see?
        //
        //   topValue:
        //     The value at the top end of the scrollbar.
        //
        //   bottomValue:
        //     The value at the bottom end of the scrollbar.
        //
        //   style:
        //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        // 返回结果:
        //     The modified value. This can be changed by the user by dragging the scrollbar,
        //     or clicking the arrows at the end.
        public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     A vertical slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   topValue:
        //     The value at the top end of the slider.
        //
        //   bottomValue:
        //     The value at the bottom end of the slider.
        //
        //   slider:
        //     The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider
        //     style from the current GUISkin is used.
        //
        //   thumb:
        //     The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        //   leftValue:
        //
        //   rightValue:
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float VerticalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options);
        //
        // 摘要:
        //     A vertical slider the user can drag to change a value between a min and a max.
        //
        // 参数:
        //   value:
        //     The value the slider shows. This determines the position of the draggable thumb.
        //
        //   topValue:
        //     The value at the top end of the slider.
        //
        //   bottomValue:
        //     The value at the bottom end of the slider.
        //
        //   slider:
        //     The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider
        //     style from the current GUISkin is used.
        //
        //   thumb:
        //     The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb
        //     style from the current GUISkin is used.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.
        //
        //   leftValue:
        //
        //   rightValue:
        //
        // 返回结果:
        //     The value that has been set by the user.
        public static float VerticalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options);
        //
        // 摘要:
        //     Option passed to a control to give it an absolute width.
        //
        // 参数:
        //   width:
        public static GUILayoutOption Width(float width);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, params GUILayoutOption[] options);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, string text, GUIStyle style, params GUILayoutOption[] options);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, GUIContent content, params GUILayoutOption[] options);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, Texture image, params GUILayoutOption[] options);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, string text, params GUILayoutOption[] options);
        public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, Texture image, GUIStyle style, params GUILayoutOption[] options);

        //
        // 摘要:
        //     Disposable helper class for managing BeginArea / EndArea.
        public class AreaScope : GUI.Scope
        {
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, string text);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, Texture image);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, GUIContent content);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, string text, GUIStyle style);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, Texture image, GUIStyle style);
            //
            // 摘要:
            //     Create a new AreaScope and begin the corresponding Area.
            //
            // 参数:
            //   text:
            //     Optional text to display in the area.
            //
            //   image:
            //     Optional texture to display in the area.
            //
            //   content:
            //     Optional text, image and tooltip top display for this area.
            //
            //   style:
            //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
            //     a transparent background.
            //
            //   screenRect:
            public AreaScope(Rect screenRect, GUIContent content, GUIStyle style);

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
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
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
            //
            // 摘要:
            //     Create a new HorizontalScope and begin the corresponding horizontal group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public HorizontalScope(GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new HorizontalScope and begin the corresponding horizontal group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public HorizontalScope(string text, GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new HorizontalScope and begin the corresponding horizontal group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public HorizontalScope(Texture image, GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new HorizontalScope and begin the corresponding horizontal group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public HorizontalScope(GUIContent content, GUIStyle style, params GUILayoutOption[] options);

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
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
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
            //
            // 摘要:
            //     Create a new VerticalScope and begin the corresponding vertical group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public VerticalScope(GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new VerticalScope and begin the corresponding vertical group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public VerticalScope(string text, GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new VerticalScope and begin the corresponding vertical group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public VerticalScope(Texture image, GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new VerticalScope and begin the corresponding vertical group.
            //
            // 参数:
            //   text:
            //     Text to display on group.
            //
            //   image:
            //     Texture to display on group.
            //
            //   content:
            //     Text, image, and tooltip for this group.
            //
            //   style:
            //     The style to use for background image and padding values. If left out, the background
            //     is transparent.
            //
            //   options:
            //     An optional list of layout options that specify extra layouting properties. Any
            //     values passed in here will override settings defined by the style.<br> See Also:
            //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
            //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
            public VerticalScope(GUIContent content, GUIStyle style, params GUILayoutOption[] options);

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
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options);
            //
            // 摘要:
            //     Create a new ScrollViewScope and begin the corresponding ScrollView.
            //
            // 参数:
            //   scrollPosition:
            //     The position to use display.
            //
            //   alwaysShowHorizontal:
            //     Optional parameter to always show the horizontal scrollbar. If false or left
            //     out, it is only shown when the content inside the ScrollView is wider than the
            //     scrollview itself.
            //
            //   alwaysShowVertical:
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
            //   style:
            //
            //   background:
            public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options);

            //
            // 摘要:
            //     The modified scrollPosition. Feed this back into the variable you pass in, as
            //     shown in the example.
            public Vector2 scrollPosition { get; }
            //
            // 摘要:
            //     Whether this ScrollView should handle scroll wheel events. (default: true).
            public bool handleScrollWheel { get; set; }

            protected override void CloseScope();
        }
    }
}