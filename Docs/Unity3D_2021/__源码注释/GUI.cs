#region Assembly UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine;

//
// Summary:
//     The GUI class is the interface for Unity's GUI with manual positioning.
[NativeHeader("Modules/IMGUI/GUISkin.bindings.h")]
[NativeHeader("Modules/IMGUI/GUI.bindings.h")]
public class GUI
{
    //
    // Summary:
    //     Determines how toolbar button size is calculated.
    public enum ToolbarButtonSize
    {
        //
        // Summary:
        //     Calculates the button size by dividing the available width by the number of buttons.
        //     The minimum size is the maximum content width.
        Fixed,
        //
        // Summary:
        //     The width of each toolbar button is calculated based on the width of its content.
        FitToContents
    }

    internal delegate void CustomSelectionGridItemGUI(int item, Rect rect, GUIStyle style, int controlID);

    //
    // Summary:
    //     Callback to draw GUI within a window (used with GUI.Window).
    //
    // Parameters:
    //   id:
    public delegate void WindowFunction(int id);

    public abstract class Scope : IDisposable
    {
        private bool m_Disposed;

        internal virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing && !GUIUtility.guiIsExiting)
                {
                    CloseScope();
                }

                m_Disposed = true;
            }
        }

        ~Scope()
        {
            if (!m_Disposed && !GUIUtility.guiIsExiting)
            {
                Console.WriteLine(GetType().Name + " was not disposed! You should use the 'using' keyword or manually call Dispose.");
            }

            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected abstract void CloseScope();
    }

    //
    // Summary:
    //     Disposable helper class for managing BeginGroup / EndGroup.
    public class GroupScope : Scope
    {
        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position)
        {
            BeginGroup(position);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, string text)
        {
            BeginGroup(position, text);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, Texture image)
        {
            BeginGroup(position, image);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, GUIContent content)
        {
            BeginGroup(position, content);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, GUIStyle style)
        {
            BeginGroup(position, style);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, string text, GUIStyle style)
        {
            BeginGroup(position, text, style);
        }

        //
        // Summary:
        //     Create a new GroupScope and begin the corresponding group.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the group.
        //
        //   text:
        //     Text to display on the group.
        //
        //   image:
        //     Texture to display on the group.
        //
        //   content:
        //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
        //     by the group and not If left out, no background is rendered, and mouse clicks
        //     are passed.
        //
        //   style:
        //     The style to use for the background.
        public GroupScope(Rect position, Texture image, GUIStyle style)
        {
            BeginGroup(position, image, style);
        }

        protected override void CloseScope()
        {
            EndGroup();
        }
    }

    //
    // Summary:
    //     Disposable helper class for managing BeginScrollView / EndScrollView.
    public class ScrollViewScope : Scope
    {
        //
        // Summary:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public Vector2 scrollPosition { get; private set; }

        //
        // Summary:
        //     Whether this ScrollView should handle scroll wheel events. (default: true).
        public bool handleScrollWheel { get; set; }

        //
        // Summary:
        //     Create a new ScrollViewScope and begin the corresponding ScrollView.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the ScrollView.
        //
        //   scrollPosition:
        //     The pixel distance that the view is scrolled in the X and Y directions.
        //
        //   viewRect:
        //     The rectangle used inside the scrollview.
        //
        //   alwaysShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when clientRect is wider than position.
        //
        //   alwaysShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when clientRect is taller than position.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect)
        {
            handleScrollWheel = true;
            this.scrollPosition = BeginScrollView(position, scrollPosition, viewRect);
        }

        //
        // Summary:
        //     Create a new ScrollViewScope and begin the corresponding ScrollView.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the ScrollView.
        //
        //   scrollPosition:
        //     The pixel distance that the view is scrolled in the X and Y directions.
        //
        //   viewRect:
        //     The rectangle used inside the scrollview.
        //
        //   alwaysShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when clientRect is wider than position.
        //
        //   alwaysShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when clientRect is taller than position.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical)
        {
            handleScrollWheel = true;
            this.scrollPosition = BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical);
        }

        //
        // Summary:
        //     Create a new ScrollViewScope and begin the corresponding ScrollView.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the ScrollView.
        //
        //   scrollPosition:
        //     The pixel distance that the view is scrolled in the X and Y directions.
        //
        //   viewRect:
        //     The rectangle used inside the scrollview.
        //
        //   alwaysShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when clientRect is wider than position.
        //
        //   alwaysShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when clientRect is taller than position.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
        {
            handleScrollWheel = true;
            this.scrollPosition = BeginScrollView(position, scrollPosition, viewRect, horizontalScrollbar, verticalScrollbar);
        }

        //
        // Summary:
        //     Create a new ScrollViewScope and begin the corresponding ScrollView.
        //
        // Parameters:
        //   position:
        //     Rectangle on the screen to use for the ScrollView.
        //
        //   scrollPosition:
        //     The pixel distance that the view is scrolled in the X and Y directions.
        //
        //   viewRect:
        //     The rectangle used inside the scrollview.
        //
        //   alwaysShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when clientRect is wider than position.
        //
        //   alwaysShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when clientRect is taller than position.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
        {
            handleScrollWheel = true;
            this.scrollPosition = BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar);
        }

        internal ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
        {
            handleScrollWheel = true;
            this.scrollPosition = BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background);
        }

        protected override void CloseScope()
        {
            EndScrollView(handleScrollWheel);
        }
    }

    public class ClipScope : Scope
    {
        public ClipScope(Rect position)
        {
            BeginClip(position);
        }

        internal ClipScope(Rect position, Vector2 scrollOffset)
        {
            BeginClip(position, scrollOffset, default(Vector2), resetOffset: false);
        }

        protected override void CloseScope()
        {
            EndClip();
        }
    }

    internal struct ColorScope : IDisposable
    {
        private bool m_Disposed;

        private Color m_PreviousColor;

        public ColorScope(Color newColor)
        {
            m_Disposed = false;
            m_PreviousColor = color;
            color = newColor;
        }

        public ColorScope(float r, float g, float b, float a = 1f)
            : this(new Color(r, g, b, a))
        {
        }

        public void Dispose()
        {
            if (!m_Disposed)
            {
                m_Disposed = true;
                color = m_PreviousColor;
            }
        }
    }

    internal struct BackgroundColorScope : IDisposable
    {
        private bool m_Disposed;

        private Color m_PreviousColor;

        public BackgroundColorScope(Color newColor)
        {
            m_Disposed = false;
            m_PreviousColor = backgroundColor;
            backgroundColor = newColor;
        }

        public BackgroundColorScope(float r, float g, float b, float a = 1f)
            : this(new Color(r, g, b, a))
        {
        }

        public void Dispose()
        {
            if (!m_Disposed)
            {
                m_Disposed = true;
                backgroundColor = m_PreviousColor;
            }
        }
    }

    private const float s_ScrollStepSize = 10f;

    private static int s_ScrollControlId;

    private static int s_HotTextField;

    private static readonly int s_BoxHash;

    private static readonly int s_ButonHash;

    private static readonly int s_RepeatButtonHash;

    private static readonly int s_ToggleHash;

    private static readonly int s_ButtonGridHash;

    private static readonly int s_SliderHash;

    private static readonly int s_BeginGroupHash;

    private static readonly int s_ScrollviewHash;

    private static GUISkin s_Skin;

    internal static Rect s_ToolTipRect;

    //
    // Summary:
    //     Applies a global tint to the GUI. The tint affects backgrounds and text colors.
    public static Color color
    {
        get
        {
            get_color_Injected(out var ret);
            return ret;
        }
        set
        {
            set_color_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Global tinting color for all background elements rendered by the GUI.
    public static Color backgroundColor
    {
        get
        {
            get_backgroundColor_Injected(out var ret);
            return ret;
        }
        set
        {
            set_backgroundColor_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Tinting color for all text rendered by the GUI.
    public static Color contentColor
    {
        get
        {
            get_contentColor_Injected(out var ret);
            return ret;
        }
        set
        {
            set_contentColor_Injected(ref value);
        }
    }

    //
    // Summary:
    //     Returns true if any controls changed the value of the input data.
    public static extern bool changed
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Is the GUI enabled?
    public static extern bool enabled
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     The sorting depth of the currently executing GUI behaviour.
    public static extern int depth
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern bool usePageScrollbars
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    internal static extern bool isInsideList
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    internal static extern Material blendMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetGUIBlendMaterial")]
        get;
    }

    internal static extern Material blitMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetGUIBlitMaterial")]
        get;
    }

    internal static extern Material roundedRectMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetGUIRoundedRectMaterial")]
        get;
    }

    internal static extern Material roundedRectWithColorPerBorderMaterial
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("GetGUIRoundedRectWithColorPerBorderMaterial")]
        get;
    }

    internal static int scrollTroughSide { get; set; }

    internal static DateTime nextScrollStepTime { get; set; }

    //
    // Summary:
    //     The global skin to use.
    public static GUISkin skin
    {
        get
        {
            GUIUtility.CheckOnGUI();
            return s_Skin;
        }
        set
        {
            GUIUtility.CheckOnGUI();
            DoSetSkin(value);
        }
    }

    //
    // Summary:
    //     The GUI transform matrix.
    public static Matrix4x4 matrix
    {
        get
        {
            return GUIClip.GetMatrix();
        }
        set
        {
            GUIClip.SetMatrix(value);
        }
    }

    //
    // Summary:
    //     The tooltip of the control the mouse is currently over, or which has keyboard
    //     focus. (Read Only).
    public static string tooltip
    {
        get
        {
            string text = Internal_GetTooltip();
            if (text != null)
            {
                return text;
            }

            return "";
        }
        set
        {
            Internal_SetTooltip(value);
        }
    }

    protected static string mouseTooltip => Internal_GetMouseTooltip();

    protected static Rect tooltipRect
    {
        get
        {
            return s_ToolTipRect;
        }
        set
        {
            s_ToolTipRect = value;
        }
    }

    internal static GenericStack scrollViewStates { get; set; }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GrabMouseControl(int id);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasMouseControl(int id);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ReleaseMouseControl();

    //
    // Summary:
    //     Set the name of the next control.
    //
    // Parameters:
    //   name:
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("GetGUIState().SetNameOfNextControl")]
    public static extern void SetNextControlName(string name);

    //
    // Summary:
    //     Get the name of named control that has focus.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("GetGUIState().GetNameOfFocusedControl")]
    public static extern string GetNameOfFocusedControl();

    //
    // Summary:
    //     Move keyboard focus to a named control.
    //
    // Parameters:
    //   name:
    //     Name set using SetNextControlName.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("GetGUIState().FocusKeyboardControl")]
    public static extern void FocusControl(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void InternalRepaintEditorWindow();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetTooltip();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetTooltip(string value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetMouseTooltip();

    private static Rect Internal_DoModalWindow(int id, int instanceID, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style, object skin)
    {
        Internal_DoModalWindow_Injected(id, instanceID, ref clientRect, func, content, style, skin, out var ret);
        return ret;
    }

    private static Rect Internal_DoWindow(int id, int instanceID, Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style, object skin, bool forceRectOnLayout)
    {
        Internal_DoWindow_Injected(id, instanceID, ref clientRect, func, title, style, skin, forceRectOnLayout, out var ret);
        return ret;
    }

    //
    // Summary:
    //     Make a window draggable.
    //
    // Parameters:
    //   position:
    //     The part of the window that can be dragged. This is clipped to the actual window.
    public static void DragWindow(Rect position)
    {
        DragWindow_Injected(ref position);
    }

    //
    // Summary:
    //     Bring a specific window to front of the floating windows.
    //
    // Parameters:
    //   windowID:
    //     The identifier used when you created the window in the Window call.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BringWindowToFront(int windowID);

    //
    // Summary:
    //     Bring a specific window to back of the floating windows.
    //
    // Parameters:
    //   windowID:
    //     The identifier used when you created the window in the Window call.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BringWindowToBack(int windowID);

    //
    // Summary:
    //     Make a window become the active window.
    //
    // Parameters:
    //   windowID:
    //     The identifier used when you created the window in the Window call.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void FocusWindow(int windowID);

    //
    // Summary:
    //     Remove focus from all windows.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UnfocusWindow();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_BeginWindows();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_EndWindows();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string Internal_Concatenate(GUIContent first, GUIContent second);

    static GUI()
    {
        s_HotTextField = -1;
        s_BoxHash = "Box".GetHashCode();
        s_ButonHash = "Button".GetHashCode();
        s_RepeatButtonHash = "repeatButton".GetHashCode();
        s_ToggleHash = "Toggle".GetHashCode();
        s_ButtonGridHash = "ButtonGrid".GetHashCode();
        s_SliderHash = "Slider".GetHashCode();
        s_BeginGroupHash = "BeginGroup".GetHashCode();
        s_ScrollviewHash = "scrollView".GetHashCode();
        scrollViewStates = new GenericStack();
        nextScrollStepTime = DateTime.Now;
    }

    internal static void DoSetSkin(GUISkin newSkin)
    {
        if (!newSkin)
        {
            newSkin = GUIUtility.GetDefaultSkin();
        }

        s_Skin = newSkin;
        newSkin.MakeCurrent();
    }

    internal static void CleanupRoots()
    {
        s_Skin = null;
        GUIUtility.CleanupRoots();
        GUILayoutUtility.CleanupRoots();
        GUISkin.CleanupRoots();
        GUIStyle.CleanupRoots();
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, string text)
    {
        Label(position, GUIContent.Temp(text), s_Skin.label);
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, Texture image)
    {
        Label(position, GUIContent.Temp(image), s_Skin.label);
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, GUIContent content)
    {
        Label(position, content, s_Skin.label);
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, string text, GUIStyle style)
    {
        Label(position, GUIContent.Temp(text), style);
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, Texture image, GUIStyle style)
    {
        Label(position, GUIContent.Temp(image), style);
    }

    //
    // Summary:
    //     Make a text or texture label on screen.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the label.
    //
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
    public static void Label(Rect position, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        DoLabel(position, content, style);
    }

    //
    // Summary:
    //     Draw a texture within a rectangle.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    public static void DrawTexture(Rect position, Texture image)
    {
        DrawTexture(position, image, ScaleMode.StretchToFill);
    }

    //
    // Summary:
    //     Draw a texture within a rectangle.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode)
    {
        DrawTexture(position, image, scaleMode, alphaBlend: true);
    }

    //
    // Summary:
    //     Draw a texture within a rectangle.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend)
    {
        DrawTexture(position, image, scaleMode, alphaBlend, 0f);
    }

    //
    // Summary:
    //     Draw a texture within a rectangle.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect)
    {
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, 0f, 0f);
    }

    //
    // Summary:
    //     Draws a border with rounded corners within a rectangle. The texture is used to
    //     pattern the border. Note that this method only works on shader model 2.5 and
    //     above.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    //
    //   color:
    //     A tint color to apply on the texture.
    //
    //   borderWidth:
    //     The width of the border. If 0, the full texture is drawn.
    //
    //   borderWidths:
    //     The width of the borders (left, top, right and bottom). If Vector4.zero, the
    //     full texture is drawn.
    //
    //   borderRadius:
    //     The radius for rounded corners. If 0, corners will not be rounded.
    //
    //   borderRadiuses:
    //     The radiuses for rounded corners (top-left, top-right, bottom-right and bottom-left).
    //     If Vector4.zero, corners will not be rounded.
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, float borderWidth, float borderRadius)
    {
        Vector4 borderWidths = Vector4.one * borderWidth;
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadius);
    }

    //
    // Summary:
    //     Draws a border with rounded corners within a rectangle. The texture is used to
    //     pattern the border. Note that this method only works on shader model 2.5 and
    //     above.
    //
    // Parameters:
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
    //   alphaBlend:
    //     Whether to apply alpha blending when drawing the image (enabled by default).
    //
    //
    //   imageAspect:
    //     Aspect ratio to use for the source image. If 0 (the default), the aspect ratio
    //     from the image is used. Pass in w/h for the desired aspect ratio. This allows
    //     the aspect ratio of the source image to be adjusted without changing the pixel
    //     width and height.
    //
    //   color:
    //     A tint color to apply on the texture.
    //
    //   borderWidth:
    //     The width of the border. If 0, the full texture is drawn.
    //
    //   borderWidths:
    //     The width of the borders (left, top, right and bottom). If Vector4.zero, the
    //     full texture is drawn.
    //
    //   borderRadius:
    //     The radius for rounded corners. If 0, corners will not be rounded.
    //
    //   borderRadiuses:
    //     The radiuses for rounded corners (top-left, top-right, bottom-right and bottom-left).
    //     If Vector4.zero, corners will not be rounded.
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, float borderRadius)
    {
        Vector4 borderRadiuses = Vector4.one * borderRadius;
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadiuses);
    }

    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses)
    {
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadiuses, drawSmoothCorners: true);
    }

    internal static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses, bool drawSmoothCorners)
    {
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, color, color, color, borderWidths, borderRadiuses, drawSmoothCorners);
    }

    internal static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color leftColor, Color topColor, Color rightColor, Color bottomColor, Vector4 borderWidths, Vector4 borderRadiuses)
    {
        DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, leftColor, topColor, rightColor, bottomColor, borderWidths, borderRadiuses, drawSmoothCorners: true);
    }

    internal static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color leftColor, Color topColor, Color rightColor, Color bottomColor, Vector4 borderWidths, Vector4 borderRadiuses, bool drawSmoothCorners)
    {
        GUIUtility.CheckOnGUI();
        if (Event.current.type != EventType.Repaint)
        {
            return;
        }

        if (image == null)
        {
            Debug.LogWarning("null texture passed to GUI.DrawTexture");
            return;
        }

        if (imageAspect == 0f)
        {
            imageAspect = (float)image.width / (float)image.height;
        }

        Material material = null;
        material = ((borderWidths != Vector4.zero) ? ((!(leftColor != topColor) && !(leftColor != rightColor) && !(leftColor != bottomColor)) ? roundedRectMaterial : roundedRectWithColorPerBorderMaterial) : ((!(borderRadiuses != Vector4.zero)) ? (alphaBlend ? blendMaterial : blitMaterial) : roundedRectMaterial));
        Internal_DrawTextureArguments internal_DrawTextureArguments = default(Internal_DrawTextureArguments);
        internal_DrawTextureArguments.leftBorder = 0;
        internal_DrawTextureArguments.rightBorder = 0;
        internal_DrawTextureArguments.topBorder = 0;
        internal_DrawTextureArguments.bottomBorder = 0;
        internal_DrawTextureArguments.color = leftColor;
        internal_DrawTextureArguments.leftBorderColor = leftColor;
        internal_DrawTextureArguments.topBorderColor = topColor;
        internal_DrawTextureArguments.rightBorderColor = rightColor;
        internal_DrawTextureArguments.bottomBorderColor = bottomColor;
        internal_DrawTextureArguments.borderWidths = borderWidths;
        internal_DrawTextureArguments.cornerRadiuses = borderRadiuses;
        internal_DrawTextureArguments.texture = image;
        internal_DrawTextureArguments.smoothCorners = drawSmoothCorners;
        internal_DrawTextureArguments.mat = material;
        Internal_DrawTextureArguments args = internal_DrawTextureArguments;
        CalculateScaledTextureRects(position, scaleMode, imageAspect, ref args.screenRect, ref args.sourceRect);
        Graphics.Internal_DrawTexture(ref args);
    }

    internal static bool CalculateScaledTextureRects(Rect position, ScaleMode scaleMode, float imageAspect, ref Rect outScreenRect, ref Rect outSourceRect)
    {
        float num = position.width / position.height;
        bool result = false;
        switch (scaleMode)
        {
            case ScaleMode.StretchToFill:
                outScreenRect = position;
                outSourceRect = new Rect(0f, 0f, 1f, 1f);
                result = true;
                break;
            case ScaleMode.ScaleAndCrop:
                if (num > imageAspect)
                {
                    float num4 = imageAspect / num;
                    outScreenRect = position;
                    outSourceRect = new Rect(0f, (1f - num4) * 0.5f, 1f, num4);
                    result = true;
                }
                else
                {
                    float num5 = num / imageAspect;
                    outScreenRect = position;
                    outSourceRect = new Rect(0.5f - num5 * 0.5f, 0f, num5, 1f);
                    result = true;
                }

                break;
            case ScaleMode.ScaleToFit:
                if (num > imageAspect)
                {
                    float num2 = imageAspect / num;
                    outScreenRect = new Rect(position.xMin + position.width * (1f - num2) * 0.5f, position.yMin, num2 * position.width, position.height);
                    outSourceRect = new Rect(0f, 0f, 1f, 1f);
                    result = true;
                }
                else
                {
                    float num3 = num / imageAspect;
                    outScreenRect = new Rect(position.xMin, position.yMin + position.height * (1f - num3) * 0.5f, position.width, num3 * position.height);
                    outSourceRect = new Rect(0f, 0f, 1f, 1f);
                    result = true;
                }

                break;
        }

        return result;
    }

    //
    // Summary:
    //     Draw a texture within a rectangle with the given texture coordinates.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to draw the texture within.
    //
    //   image:
    //     Texture to display.
    //
    //   texCoords:
    //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
    //     to be drawn within.
    //
    //   alphaBlend:
    //     Whether to alpha blend the image on to the display (the default). If false, the
    //     picture is drawn on to the display.
    public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords)
    {
        DrawTextureWithTexCoords(position, image, texCoords, alphaBlend: true);
    }

    //
    // Summary:
    //     Draw a texture within a rectangle with the given texture coordinates.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to draw the texture within.
    //
    //   image:
    //     Texture to display.
    //
    //   texCoords:
    //     How to scale the image when the aspect ratio of it doesn't fit the aspect ratio
    //     to be drawn within.
    //
    //   alphaBlend:
    //     Whether to alpha blend the image on to the display (the default). If false, the
    //     picture is drawn on to the display.
    public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords, bool alphaBlend)
    {
        GUIUtility.CheckOnGUI();
        if (Event.current.type == EventType.Repaint)
        {
            Material mat = (alphaBlend ? blendMaterial : blitMaterial);
            Internal_DrawTextureArguments args = default(Internal_DrawTextureArguments);
            args.texture = image;
            args.mat = mat;
            args.leftBorder = 0;
            args.rightBorder = 0;
            args.topBorder = 0;
            args.bottomBorder = 0;
            args.color = color;
            args.leftBorderColor = color;
            args.topBorderColor = color;
            args.rightBorderColor = color;
            args.bottomBorderColor = color;
            args.screenRect = position;
            args.sourceRect = texCoords;
            Graphics.Internal_DrawTexture(ref args);
        }
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, string text)
    {
        Box(position, GUIContent.Temp(text), s_Skin.box);
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, Texture image)
    {
        Box(position, GUIContent.Temp(image), s_Skin.box);
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, GUIContent content)
    {
        Box(position, content, s_Skin.box);
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, string text, GUIStyle style)
    {
        Box(position, GUIContent.Temp(text), style);
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, Texture image, GUIStyle style)
    {
        Box(position, GUIContent.Temp(image), style);
    }

    //
    // Summary:
    //     Create a Box on the GUI Layer.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the box.
    //
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
    public static void Box(Rect position, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        int controlID = GUIUtility.GetControlID(s_BoxHash, FocusType.Passive);
        if (Event.current.type == EventType.Repaint)
        {
            style.Draw(position, content, controlID, on: false, position.Contains(Event.current.mousePosition));
        }
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, string text)
    {
        return Button(position, GUIContent.Temp(text), s_Skin.button);
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, Texture image)
    {
        return Button(position, GUIContent.Temp(image), s_Skin.button);
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, GUIContent content)
    {
        return Button(position, content, s_Skin.button);
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, string text, GUIStyle style)
    {
        return Button(position, GUIContent.Temp(text), style);
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, Texture image, GUIStyle style)
    {
        return Button(position, GUIContent.Temp(image), style);
    }

    //
    // Summary:
    //     Make a single press button. The user clicks them and something happens immediately.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     true when the users clicks the button.
    public static bool Button(Rect position, GUIContent content, GUIStyle style)
    {
        int controlID = GUIUtility.GetControlID(s_ButonHash, FocusType.Passive, position);
        return Button(position, controlID, content, style);
    }

    internal static bool Button(Rect position, int id, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoButton(position, id, content, style);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, string text)
    {
        return DoRepeatButton(position, GUIContent.Temp(text), s_Skin.button, FocusType.Passive);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, Texture image)
    {
        return DoRepeatButton(position, GUIContent.Temp(image), s_Skin.button, FocusType.Passive);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, GUIContent content)
    {
        return DoRepeatButton(position, content, s_Skin.button, FocusType.Passive);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, string text, GUIStyle style)
    {
        return DoRepeatButton(position, GUIContent.Temp(text), style, FocusType.Passive);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, Texture image, GUIStyle style)
    {
        return DoRepeatButton(position, GUIContent.Temp(image), style, FocusType.Passive);
    }

    //
    // Summary:
    //     Make a button that is active as long as the user holds it down.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
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
    //
    // Returns:
    //     True when the users clicks the button.
    public static bool RepeatButton(Rect position, GUIContent content, GUIStyle style)
    {
        return DoRepeatButton(position, content, style, FocusType.Passive);
    }

    private static bool DoRepeatButton(Rect position, GUIContent content, GUIStyle style, FocusType focusType)
    {
        GUIUtility.CheckOnGUI();
        int controlID = GUIUtility.GetControlID(s_RepeatButtonHash, focusType, position);
        switch (Event.current.GetTypeForControl(controlID))
        {
            case EventType.MouseDown:
                if (position.Contains(Event.current.mousePosition))
                {
                    GUIUtility.hotControl = controlID;
                    Event.current.Use();
                }

                return false;
            case EventType.MouseUp:
                if (GUIUtility.hotControl == controlID)
                {
                    GUIUtility.hotControl = 0;
                    Event.current.Use();
                    return position.Contains(Event.current.mousePosition);
                }

                return false;
            case EventType.Repaint:
                style.Draw(position, content, controlID, on: false, position.Contains(Event.current.mousePosition));
                return controlID == GUIUtility.hotControl && position.Contains(Event.current.mousePosition);
            default:
                return false;
        }
    }

    //
    // Summary:
    //     Make a single-line text field where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextField(Rect position, string text)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: false, -1, skin.textField);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a single-line text field where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextField(Rect position, string text, int maxLength)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: false, maxLength, skin.textField);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a single-line text field where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextField(Rect position, string text, GUIStyle style)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: false, -1, style);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a single-line text field where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextField(Rect position, string text, int maxLength, GUIStyle style)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: false, maxLength, style);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a text field where the user can enter a password.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited password.
    public static string PasswordField(Rect position, string password, char maskChar)
    {
        return PasswordField(position, password, maskChar, -1, skin.textField);
    }

    //
    // Summary:
    //     Make a text field where the user can enter a password.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited password.
    public static string PasswordField(Rect position, string password, char maskChar, int maxLength)
    {
        return PasswordField(position, password, maskChar, maxLength, skin.textField);
    }

    //
    // Summary:
    //     Make a text field where the user can enter a password.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited password.
    public static string PasswordField(Rect position, string password, char maskChar, GUIStyle style)
    {
        return PasswordField(position, password, maskChar, -1, style);
    }

    //
    // Summary:
    //     Make a text field where the user can enter a password.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited password.
    public static string PasswordField(Rect position, string password, char maskChar, int maxLength, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        string t = PasswordFieldGetStrToShow(password, maskChar);
        GUIContent gUIContent = GUIContent.Temp(t);
        bool flag = changed;
        changed = false;
        if (TouchScreenKeyboard.isSupported && !TouchScreenKeyboard.isInPlaceEditingAllowed)
        {
            DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard), gUIContent, multiline: false, maxLength, style, password, maskChar);
        }
        else
        {
            DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: false, maxLength, style);
        }

        t = (changed ? gUIContent.text : password);
        changed |= flag;
        return t;
    }

    internal static string PasswordFieldGetStrToShow(string password, char maskChar)
    {
        return (Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseDown) ? "".PadRight(password.Length, maskChar) : password;
    }

    //
    // Summary:
    //     Make a Multi-line text area where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextArea(Rect position, string text)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: true, -1, skin.textArea);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a Multi-line text area where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextArea(Rect position, string text, int maxLength)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: true, maxLength, skin.textArea);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a Multi-line text area where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextArea(Rect position, string text, GUIStyle style)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: true, -1, style);
        return gUIContent.text;
    }

    //
    // Summary:
    //     Make a Multi-line text area where the user can edit a string.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the text field.
    //
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
    // Returns:
    //     The edited string.
    public static string TextArea(Rect position, string text, int maxLength, GUIStyle style)
    {
        GUIContent gUIContent = GUIContent.Temp(text);
        DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), gUIContent, multiline: true, maxLength, style);
        return gUIContent.text;
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style)
    {
        DoTextField(position, id, content, multiline, maxLength, style, null);
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText)
    {
        DoTextField(position, id, content, multiline, maxLength, style, secureText, '\0');
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar)
    {
        GUIUtility.CheckOnGUI();
        if (maxLength >= 0 && content.text.Length > maxLength)
        {
            content.text = content.text.Substring(0, maxLength);
        }

        TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), id);
        textEditor.text = content.text;
        textEditor.SaveBackup();
        textEditor.position = position;
        textEditor.style = style;
        textEditor.multiline = multiline;
        textEditor.controlID = id;
        textEditor.DetectFocusChange();
        if (TouchScreenKeyboard.isRequiredToForceOpen)
        {
            HandleTextFieldEventForDesktopWithForcedKeyboard(position, id, content, multiline, maxLength, style, secureText, textEditor);
        }
        else if (TouchScreenKeyboard.isSupported && !TouchScreenKeyboard.isInPlaceEditingAllowed)
        {
            HandleTextFieldEventForTouchscreen(position, id, content, multiline, maxLength, style, secureText, maskChar, textEditor);
        }
        else
        {
            HandleTextFieldEventForDesktop(position, id, content, multiline, maxLength, style, textEditor);
        }

        textEditor.UpdateScrollOffsetIfNeeded(Event.current);
    }

    private static void HandleTextFieldEventForTouchscreen(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar, TextEditor editor)
    {
        Event current = Event.current;
        switch (current.type)
        {
            case EventType.MouseDown:
                if (position.Contains(current.mousePosition))
                {
                    GUIUtility.hotControl = id;
                    if (s_HotTextField != -1 && s_HotTextField != id)
                    {
                        TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), s_HotTextField);
                        textEditor.keyboardOnScreen = null;
                    }

                    s_HotTextField = id;
                    if (GUIUtility.keyboardControl != id)
                    {
                        GUIUtility.keyboardControl = id;
                    }

                    editor.keyboardOnScreen = TouchScreenKeyboard.Open(secureText ?? content.text, TouchScreenKeyboardType.Default, autocorrection: true, multiline, secureText != null);
                    current.Use();
                }

                break;
            case EventType.Repaint:
                {
                    if (editor.keyboardOnScreen != null)
                    {
                        content.text = editor.keyboardOnScreen.text;
                        if (maxLength >= 0 && content.text.Length > maxLength)
                        {
                            content.text = content.text.Substring(0, maxLength);
                        }

                        if (editor.keyboardOnScreen.status != 0)
                        {
                            editor.keyboardOnScreen = null;
                            changed = true;
                        }
                    }

                    string text = content.text;
                    if (secureText != null)
                    {
                        content.text = PasswordFieldGetStrToShow(text, maskChar);
                    }

                    style.Draw(position, content, id, on: false);
                    content.text = text;
                    break;
                }
        }
    }

    private static void HandleTextFieldEventForDesktop(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, TextEditor editor)
    {
        Event current = Event.current;
        bool flag = false;
        switch (current.type)
        {
            case EventType.MouseDown:
                if (position.Contains(current.mousePosition))
                {
                    GUIUtility.hotControl = id;
                    GUIUtility.keyboardControl = id;
                    editor.m_HasFocus = true;
                    editor.MoveCursorToPosition(Event.current.mousePosition);
                    if (Event.current.clickCount == 2 && skin.settings.doubleClickSelectsWord)
                    {
                        editor.SelectCurrentWord();
                        editor.DblClickSnap(TextEditor.DblClickSnapping.WORDS);
                        editor.MouseDragSelectsWholeWords(on: true);
                    }

                    if (Event.current.clickCount == 3 && skin.settings.tripleClickSelectsLine)
                    {
                        editor.SelectCurrentParagraph();
                        editor.MouseDragSelectsWholeWords(on: true);
                        editor.DblClickSnap(TextEditor.DblClickSnapping.PARAGRAPHS);
                    }

                    current.Use();
                }

                break;
            case EventType.MouseDrag:
                if (GUIUtility.hotControl == id)
                {
                    if (current.shift)
                    {
                        editor.MoveCursorToPosition(Event.current.mousePosition);
                    }
                    else
                    {
                        editor.SelectToPosition(Event.current.mousePosition);
                    }

                    current.Use();
                }

                break;
            case EventType.MouseUp:
                if (GUIUtility.hotControl == id)
                {
                    editor.MouseDragSelectsWholeWords(on: false);
                    GUIUtility.hotControl = 0;
                    current.Use();
                }

                break;
            case EventType.KeyDown:
                {
                    if (GUIUtility.keyboardControl != id)
                    {
                        return;
                    }

                    if (editor.HandleKeyEvent(current))
                    {
                        current.Use();
                        flag = true;
                        content.text = editor.text;
                        break;
                    }

                    if (current.keyCode == KeyCode.Tab || current.character == '\t')
                    {
                        return;
                    }

                    char character = current.character;
                    if (character == '\n' && !multiline && !current.alt)
                    {
                        return;
                    }

                    Font font = style.font;
                    if (!font)
                    {
                        font = skin.font;
                    }

                    if (font.HasCharacter(character) || character == '\n')
                    {
                        editor.Insert(character);
                        flag = true;
                    }
                    else if (character == '\0')
                    {
                        if (GUIUtility.compositionString.Length > 0)
                        {
                            editor.ReplaceSelection("");
                            flag = true;
                        }

                        current.Use();
                    }

                    break;
                }
            case EventType.Repaint:
                if (GUIUtility.keyboardControl != id)
                {
                    style.Draw(position, content, id, on: false);
                }
                else
                {
                    editor.DrawCursor(content.text);
                }

                break;
        }

        if (GUIUtility.keyboardControl == id)
        {
            GUIUtility.textFieldInput = true;
        }

        if (flag)
        {
            changed = true;
            content.text = editor.text;
            if (maxLength >= 0 && content.text.Length > maxLength)
            {
                content.text = content.text.Substring(0, maxLength);
            }

            current.Use();
        }
    }

    private static void HandleTextFieldEventForDesktopWithForcedKeyboard(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, TextEditor editor)
    {
        bool flag = false;
        if (Event.current.type == EventType.Repaint)
        {
            if (s_HotTextField != -1 && s_HotTextField != id)
            {
                TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), s_HotTextField);
                textEditor.keyboardOnScreen.active = false;
                textEditor.keyboardOnScreen = null;
            }

            if (editor.keyboardOnScreen != null)
            {
                if (GUIUtility.keyboardControl != id || !Application.isFocused)
                {
                    editor.keyboardOnScreen.active = false;
                    editor.keyboardOnScreen = null;
                }
                else if (!editor.keyboardOnScreen.active)
                {
                    flag = true;
                }
            }
            else if (GUIUtility.keyboardControl == id && Application.isFocused)
            {
                flag = true;
            }
        }

        if (flag)
        {
            editor.keyboardOnScreen = TouchScreenKeyboard.Open(secureText ?? content.text, TouchScreenKeyboardType.Default, autocorrection: true, multiline, secureText != null);
        }

        HandleTextFieldEventForDesktop(position, id, content, multiline, maxLength, style, editor);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, string text)
    {
        return Toggle(position, value, GUIContent.Temp(text), s_Skin.toggle);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, Texture image)
    {
        return Toggle(position, value, GUIContent.Temp(image), s_Skin.toggle);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, GUIContent content)
    {
        return Toggle(position, value, content, s_Skin.toggle);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, string text, GUIStyle style)
    {
        return Toggle(position, value, GUIContent.Temp(text), style);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, Texture image, GUIStyle style)
    {
        return Toggle(position, value, GUIContent.Temp(image), style);
    }

    //
    // Summary:
    //     Make an on/off toggle button.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the button.
    //
    //   value:
    //     Is this button on or off?
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
    //     The style to use. If left out, the toggle style from the current GUISkin is used.
    //
    //
    // Returns:
    //     The new value of the button.
    public static bool Toggle(Rect position, bool value, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoToggle(position, GUIUtility.GetControlID(s_ToggleHash, FocusType.Passive, position), value, content, style);
    }

    public static bool Toggle(Rect position, int id, bool value, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoToggle(position, id, value, content, style);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, string[] texts)
    {
        return Toolbar(position, selected, GUIContent.Temp(texts), s_Skin.button);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, Texture[] images)
    {
        return Toolbar(position, selected, GUIContent.Temp(images), s_Skin.button);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, GUIContent[] contents)
    {
        return Toolbar(position, selected, contents, s_Skin.button);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, string[] texts, GUIStyle style)
    {
        return Toolbar(position, selected, GUIContent.Temp(texts), style);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, Texture[] images, GUIStyle style)
    {
        return Toolbar(position, selected, GUIContent.Temp(images), style);
    }

    //
    // Summary:
    //     Make a toolbar.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the toolbar.
    //
    //   selected:
    //     The index of the selected button.
    //
    //   texts:
    //     An array of strings to show on the toolbar buttons.
    //
    //   images:
    //     An array of textures on the toolbar buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the toolbar buttons.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   buttonSize:
    //     Determines how toolbar button size is calculated.
    //
    // Returns:
    //     The index of the selected button.
    public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style)
    {
        return Toolbar(position, selected, contents, null, style, ToolbarButtonSize.Fixed);
    }

    public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style, ToolbarButtonSize buttonSize)
    {
        return Toolbar(position, selected, contents, null, style, buttonSize);
    }

    internal static int Toolbar(Rect position, int selected, GUIContent[] contents, string[] controlNames, GUIStyle style, ToolbarButtonSize buttonSize, bool[] contentsEnabled = null)
    {
        GUIUtility.CheckOnGUI();
        FindStyles(ref style, out var firstStyle, out var midStyle, out var lastStyle, "left", "mid", "right");
        return DoButtonGrid(position, selected, contents, controlNames, contents.Length, style, firstStyle, midStyle, lastStyle, buttonSize, contentsEnabled);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, string[] texts, int xCount)
    {
        return SelectionGrid(position, selected, GUIContent.Temp(texts), xCount, null);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount)
    {
        return SelectionGrid(position, selected, GUIContent.Temp(images), xCount, null);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, GUIContent[] content, int xCount)
    {
        return SelectionGrid(position, selected, content, xCount, null);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, string[] texts, int xCount, GUIStyle style)
    {
        return SelectionGrid(position, selected, GUIContent.Temp(texts), xCount, style);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount, GUIStyle style)
    {
        return SelectionGrid(position, selected, GUIContent.Temp(images), xCount, style);
    }

    //
    // Summary:
    //     Make a grid of buttons.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the grid.
    //
    //   selected:
    //     The index of the selected grid button.
    //
    //   texts:
    //     An array of strings to show on the grid buttons.
    //
    //   images:
    //     An array of textures on the grid buttons.
    //
    //   contents:
    //     An array of text, image and tooltips for the grid button.
    //
    //   xCount:
    //     How many elements to fit in the horizontal direction. The controls will be scaled
    //     to fit unless the style defines a fixedWidth to use.
    //
    //   style:
    //     The style to use. If left out, the button style from the current GUISkin is used.
    //
    //
    //   content:
    //
    // Returns:
    //     The index of the selected button.
    public static int SelectionGrid(Rect position, int selected, GUIContent[] contents, int xCount, GUIStyle style)
    {
        if (style == null)
        {
            style = s_Skin.button;
        }

        return DoButtonGrid(position, selected, contents, null, xCount, style, style, style, style, ToolbarButtonSize.Fixed);
    }

    internal static void FindStyles(ref GUIStyle style, out GUIStyle firstStyle, out GUIStyle midStyle, out GUIStyle lastStyle, string first, string mid, string last)
    {
        if (style == null)
        {
            style = skin.button;
        }

        string name = style.name;
        midStyle = skin.FindStyle(name + mid) ?? style;
        firstStyle = skin.FindStyle(name + first) ?? midStyle;
        lastStyle = skin.FindStyle(name + last) ?? midStyle;
    }

    internal static int CalcTotalHorizSpacing(int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle)
    {
        if (xCount < 2)
        {
            return 0;
        }

        if (xCount == 2)
        {
            return Mathf.Max(firstStyle.margin.right, lastStyle.margin.left);
        }

        int num = Mathf.Max(midStyle.margin.left, midStyle.margin.right);
        return Mathf.Max(firstStyle.margin.right, midStyle.margin.left) + Mathf.Max(midStyle.margin.right, lastStyle.margin.left) + num * (xCount - 3);
    }

    internal static bool DoControl(Rect position, int id, bool on, bool hover, GUIContent content, GUIStyle style)
    {
        Event current = Event.current;
        switch (current.type)
        {
            case EventType.Repaint:
                style.Draw(position, content, id, on, hover);
                break;
            case EventType.MouseDown:
                if (GUIUtility.HitTest(position, current))
                {
                    GrabMouseControl(id);
                    current.Use();
                }

                break;
            case EventType.KeyDown:
                {
                    bool flag = current.alt || current.shift || current.command || current.control;
                    if ((current.keyCode == KeyCode.Space || current.keyCode == KeyCode.Return || current.keyCode == KeyCode.KeypadEnter) && !flag && GUIUtility.keyboardControl == id)
                    {
                        current.Use();
                        changed = true;
                        return !on;
                    }

                    break;
                }
            case EventType.MouseUp:
                if (HasMouseControl(id))
                {
                    ReleaseMouseControl();
                    current.Use();
                    if (GUIUtility.HitTest(position, current))
                    {
                        changed = true;
                        return !on;
                    }
                }

                break;
            case EventType.MouseDrag:
                if (HasMouseControl(id))
                {
                    current.Use();
                }

                break;
        }

        return on;
    }

    private static void DoLabel(Rect position, GUIContent content, GUIStyle style)
    {
        Event current = Event.current;
        if (current.type != EventType.Repaint)
        {
            return;
        }

        bool flag = position.Contains(current.mousePosition);
        style.Draw(position, content, flag, isActive: false, on: false, hasKeyboardFocus: false);
        if (!string.IsNullOrEmpty(content.tooltip) && flag && GUIClip.visibleRect.Contains(current.mousePosition))
        {
            if (!GUIStyle.IsTooltipActive(content.tooltip))
            {
                s_ToolTipRect = new Rect(current.mousePosition, Vector2.zero);
            }

            GUIStyle.SetMouseTooltip(content.tooltip, s_ToolTipRect);
        }
    }

    internal static bool DoToggle(Rect position, int id, bool value, GUIContent content, GUIStyle style)
    {
        return DoControl(position, id, value, position.Contains(Event.current.mousePosition), content, style);
    }

    internal static bool DoButton(Rect position, int id, GUIContent content, GUIStyle style)
    {
        return DoControl(position, id, on: false, position.Contains(Event.current.mousePosition), content, style);
    }

    private static Rect[] CalcGridRectsFixedWidthFixedMargin(Rect position, int itemCount, int itemsPerRow, float elemWidth, float elemHeight, float spacingHorizontal, float spacingVertical)
    {
        int num = 0;
        float x = position.xMin;
        float num2 = position.yMin;
        Rect[] array = new Rect[itemCount];
        for (int i = 0; i < itemCount; i++)
        {
            array[i] = new Rect(x, num2, elemWidth, elemHeight);
            array[i] = GUIUtility.AlignRectToDevice(array[i]);
            x = array[i].xMax + spacingHorizontal;
            if (++num >= itemsPerRow)
            {
                num = 0;
                num2 += elemHeight + spacingVertical;
                x = position.xMin;
            }
        }

        return array;
    }

    internal static int DoCustomSelectionGrid(Rect position, int selected, int itemCount, CustomSelectionGridItemGUI itemGUI, int itemsPerRow, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        if (itemCount == 0)
        {
            return selected;
        }

        if (itemsPerRow <= 0)
        {
            Debug.LogWarning("You are trying to create a SelectionGrid with zero or less elements to be displayed in the horizontal direction. Set itemsPerRow to a positive value.");
            return selected;
        }

        int num = (itemCount + itemsPerRow - 1) / itemsPerRow;
        float spacingHorizontal = Mathf.Max(style.margin.left, style.margin.right);
        float num2 = Mathf.Max(style.margin.top, style.margin.bottom);
        float elemWidth = ((style.fixedWidth != 0f) ? style.fixedWidth : ((position.width - (float)CalcTotalHorizSpacing(itemsPerRow, style, style, style, style)) / (float)itemsPerRow));
        float elemHeight = ((style.fixedHeight != 0f) ? style.fixedHeight : ((position.height - num2 * (float)(num - 1)) / (float)num));
        Rect[] array = CalcGridRectsFixedWidthFixedMargin(position, itemCount, itemsPerRow, elemWidth, elemHeight, spacingHorizontal, num2);
        int controlID = 0;
        for (int i = 0; i < itemCount; i++)
        {
            Rect rect = array[i];
            int controlID2 = GUIUtility.GetControlID(s_ButtonGridHash, FocusType.Passive, rect);
            if (i == selected)
            {
                controlID = controlID2;
            }

            EventType typeForControl = Event.current.GetTypeForControl(controlID2);
            switch (typeForControl)
            {
                case EventType.MouseDown:
                    if (GUIUtility.HitTest(rect, Event.current))
                    {
                        GUIUtility.hotControl = controlID2;
                        Event.current.Use();
                    }

                    break;
                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == controlID2)
                    {
                        Event.current.Use();
                    }

                    break;
                case EventType.MouseUp:
                    if (GUIUtility.hotControl == controlID2)
                    {
                        GUIUtility.hotControl = 0;
                        Event.current.Use();
                        changed = true;
                        return i;
                    }

                    break;
                case EventType.Repaint:
                    if (selected != i)
                    {
                        itemGUI(i, rect, style, controlID2);
                    }

                    break;
            }

            if (typeForControl != EventType.Repaint || selected != i)
            {
                itemGUI(i, rect, style, controlID2);
            }
        }

        if (selected >= 0 && selected < itemCount && Event.current.type == EventType.Repaint)
        {
            itemGUI(selected, array[selected], style, controlID);
        }

        return selected;
    }

    private static int DoButtonGrid(Rect position, int selected, GUIContent[] contents, string[] controlNames, int itemsPerRow, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, ToolbarButtonSize buttonSize, bool[] contentsEnabled = null)
    {
        GUIUtility.CheckOnGUI();
        int num = contents.Length;
        if (num == 0)
        {
            return selected;
        }

        if (itemsPerRow <= 0)
        {
            Debug.LogWarning("You are trying to create a SelectionGrid with zero or less elements to be displayed in the horizontal direction. Set itemsPerRow to a positive value.");
            return selected;
        }

        if (contentsEnabled != null && contentsEnabled.Length != num)
        {
            throw new ArgumentException("contentsEnabled");
        }

        int num2 = (num + itemsPerRow - 1) / itemsPerRow;
        float elemWidth = ((style.fixedWidth != 0f) ? style.fixedWidth : ((position.width - (float)CalcTotalHorizSpacing(itemsPerRow, style, firstStyle, midStyle, lastStyle)) / (float)itemsPerRow));
        float elemHeight = ((style.fixedHeight != 0f) ? style.fixedHeight : ((position.height - (float)(Mathf.Max(style.margin.top, style.margin.bottom) * (num2 - 1))) / (float)num2));
        Rect[] array = CalcGridRects(position, contents, itemsPerRow, elemWidth, elemHeight, style, firstStyle, midStyle, lastStyle, buttonSize);
        GUIStyle gUIStyle = null;
        int num3 = 0;
        for (int i = 0; i < num; i++)
        {
            bool flag = enabled;
            enabled &= contentsEnabled == null || contentsEnabled[i];
            Rect rect = array[i];
            GUIContent gUIContent = contents[i];
            if (controlNames != null)
            {
                SetNextControlName(controlNames[i]);
            }

            int controlID = GUIUtility.GetControlID(s_ButtonGridHash, FocusType.Passive, rect);
            if (i == selected)
            {
                num3 = controlID;
            }

            switch (Event.current.GetTypeForControl(controlID))
            {
                case EventType.MouseDown:
                    if (GUIUtility.HitTest(rect, Event.current))
                    {
                        GUIUtility.hotControl = controlID;
                        Event.current.Use();
                    }

                    break;
                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == controlID)
                    {
                        Event.current.Use();
                    }

                    break;
                case EventType.MouseUp:
                    if (GUIUtility.hotControl == controlID)
                    {
                        GUIUtility.hotControl = 0;
                        Event.current.Use();
                        changed = true;
                        return i;
                    }

                    break;
                case EventType.Repaint:
                    {
                        GUIStyle gUIStyle2 = ((num == 1) ? style : ((i == 0) ? firstStyle : ((i == num - 1) ? lastStyle : midStyle)));
                        bool flag2 = rect.Contains(Event.current.mousePosition);
                        bool flag3 = GUIUtility.hotControl == controlID;
                        if (selected != i)
                        {
                            gUIStyle2.Draw(rect, gUIContent, enabled && flag2 && (flag3 || GUIUtility.hotControl == 0), enabled && flag3, on: false, hasKeyboardFocus: false);
                        }
                        else
                        {
                            gUIStyle = gUIStyle2;
                        }

                        if (flag2)
                        {
                            GUIUtility.mouseUsed = true;
                            if (!string.IsNullOrEmpty(gUIContent.tooltip))
                            {
                                GUIStyle.SetMouseTooltip(gUIContent.tooltip, rect);
                            }
                        }

                        break;
                    }
            }

            enabled = flag;
        }

        if (gUIStyle != null)
        {
            Rect position2 = array[selected];
            GUIContent content = contents[selected];
            bool flag4 = position2.Contains(Event.current.mousePosition);
            bool flag5 = GUIUtility.hotControl == num3;
            bool flag6 = enabled;
            enabled &= contentsEnabled == null || contentsEnabled[selected];
            gUIStyle.Draw(position2, content, enabled && flag4 && (flag5 || GUIUtility.hotControl == 0), enabled && flag5, on: true, hasKeyboardFocus: false);
            enabled = flag6;
        }

        return selected;
    }

    private static Rect[] CalcGridRects(Rect position, GUIContent[] contents, int xCount, float elemWidth, float elemHeight, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, ToolbarButtonSize buttonSize)
    {
        int num = contents.Length;
        int num2 = 0;
        float x = position.xMin;
        float num3 = position.yMin;
        GUIStyle gUIStyle = style;
        Rect[] array = new Rect[num];
        if (num > 1)
        {
            gUIStyle = firstStyle;
        }

        for (int i = 0; i < num; i++)
        {
            float width = 0f;
            switch (buttonSize)
            {
                case ToolbarButtonSize.Fixed:
                    width = elemWidth;
                    break;
                case ToolbarButtonSize.FitToContents:
                    width = gUIStyle.CalcSize(contents[i]).x;
                    break;
            }

            array[i] = new Rect(x, num3, width, elemHeight);
            array[i] = GUIUtility.AlignRectToDevice(array[i]);
            GUIStyle gUIStyle2 = midStyle;
            if (i == num - 2 || i == xCount - 2)
            {
                gUIStyle2 = lastStyle;
            }

            x = array[i].xMax + (float)Mathf.Max(gUIStyle.margin.right, gUIStyle2.margin.left);
            num2++;
            if (num2 >= xCount)
            {
                num2 = 0;
                num3 += elemHeight + (float)Mathf.Max(style.margin.top, style.margin.bottom);
                x = position.xMin;
                gUIStyle2 = firstStyle;
            }

            gUIStyle = gUIStyle2;
        }

        return array;
    }

    //
    // Summary:
    //     A horizontal slider the user can drag to change a value between a min and a max.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the slider.
    //
    //   value:
    //     The value the slider shows. This determines the position of the draggable thumb.
    //
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
    // Returns:
    //     The value that has been set by the user.
    public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue)
    {
        return Slider(position, value, 0f, leftValue, rightValue, skin.horizontalSlider, skin.horizontalSliderThumb, horiz: true, 0, skin.horizontalSliderThumbExtent);
    }

    //
    // Summary:
    //     A horizontal slider the user can drag to change a value between a min and a max.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the slider.
    //
    //   value:
    //     The value the slider shows. This determines the position of the draggable thumb.
    //
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
    // Returns:
    //     The value that has been set by the user.
    public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb)
    {
        return Slider(position, value, 0f, leftValue, rightValue, slider, thumb, horiz: true, 0);
    }

    public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUIStyle thumbExtent)
    {
        return Slider(position, value, 0f, leftValue, rightValue, slider, thumb, horiz: true, 0, (thumbExtent == null && thumb == skin.horizontalSliderThumb) ? skin.horizontalSliderThumbExtent : thumbExtent);
    }

    //
    // Summary:
    //     A vertical slider the user can drag to change a value between a min and a max.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the slider.
    //
    //   value:
    //     The value the slider shows. This determines the position of the draggable thumb.
    //
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
    // Returns:
    //     The value that has been set by the user.
    public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue)
    {
        return Slider(position, value, 0f, topValue, bottomValue, skin.verticalSlider, skin.verticalSliderThumb, horiz: false, 0, skin.verticalSliderThumbExtent);
    }

    //
    // Summary:
    //     A vertical slider the user can drag to change a value between a min and a max.
    //
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the slider.
    //
    //   value:
    //     The value the slider shows. This determines the position of the draggable thumb.
    //
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
    // Returns:
    //     The value that has been set by the user.
    public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue, GUIStyle slider, GUIStyle thumb)
    {
        return Slider(position, value, 0f, topValue, bottomValue, slider, thumb, horiz: false, 0);
    }

    public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue, GUIStyle slider, GUIStyle thumb, GUIStyle thumbExtent)
    {
        return Slider(position, value, 0f, topValue, bottomValue, slider, thumb, horiz: false, 0, (thumbExtent == null && thumb == skin.verticalSliderThumb) ? skin.verticalSliderThumbExtent : thumbExtent);
    }

    public static float Slider(Rect position, float value, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id, GUIStyle thumbExtent = null)
    {
        GUIUtility.CheckOnGUI();
        if (id == 0)
        {
            id = GUIUtility.GetControlID(s_SliderHash, FocusType.Passive, position);
        }

        return new SliderHandler(position, value, size, start, end, slider, thumb, horiz, id, thumbExtent).Handle();
    }

    //
    // Summary:
    //     Make a horizontal scrollbar. Scrollbars are what you use to scroll through a
    //     document. Most likely, you want to use scrollViews instead.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the scrollbar.
    //
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
    // Returns:
    //     The modified value. This can be changed by the user by dragging the scrollbar,
    //     or clicking the arrows at the end.
    public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue)
    {
        return Scroller(position, value, size, leftValue, rightValue, skin.horizontalScrollbar, skin.horizontalScrollbarThumb, skin.horizontalScrollbarLeftButton, skin.horizontalScrollbarRightButton, horiz: true);
    }

    //
    // Summary:
    //     Make a horizontal scrollbar. Scrollbars are what you use to scroll through a
    //     document. Most likely, you want to use scrollViews instead.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the scrollbar.
    //
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
    // Returns:
    //     The modified value. This can be changed by the user by dragging the scrollbar,
    //     or clicking the arrows at the end.
    public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle style)
    {
        return Scroller(position, value, size, leftValue, rightValue, style, skin.GetStyle(style.name + "thumb"), skin.GetStyle(style.name + "leftbutton"), skin.GetStyle(style.name + "rightbutton"), horiz: true);
    }

    internal static bool ScrollerRepeatButton(int scrollerID, Rect rect, GUIStyle style)
    {
        bool result = false;
        if (DoRepeatButton(rect, GUIContent.none, style, FocusType.Passive))
        {
            bool flag = s_ScrollControlId != scrollerID;
            s_ScrollControlId = scrollerID;
            if (flag)
            {
                result = true;
                nextScrollStepTime = DateTime.Now.AddMilliseconds(250.0);
            }
            else if (DateTime.Now >= nextScrollStepTime)
            {
                result = true;
                nextScrollStepTime = DateTime.Now.AddMilliseconds(30.0);
            }

            if (Event.current.type == EventType.Repaint)
            {
                InternalRepaintEditorWindow();
            }
        }

        return result;
    }

    //
    // Summary:
    //     Make a vertical scrollbar. Scrollbars are what you use to scroll through a document.
    //     Most likely, you want to use scrollViews instead.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the scrollbar.
    //
    //   value:
    //     The position between min and max.
    //
    //   size:
    //     How much can we see?
    //
    //   topValue:
    //     The value at the top of the scrollbar.
    //
    //   bottomValue:
    //     The value at the bottom of the scrollbar.
    //
    //   style:
    //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    // Returns:
    //     The modified value. This can be changed by the user by dragging the scrollbar,
    //     or clicking the arrows at the end.
    public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue)
    {
        return Scroller(position, value, size, topValue, bottomValue, skin.verticalScrollbar, skin.verticalScrollbarThumb, skin.verticalScrollbarUpButton, skin.verticalScrollbarDownButton, horiz: false);
    }

    //
    // Summary:
    //     Make a vertical scrollbar. Scrollbars are what you use to scroll through a document.
    //     Most likely, you want to use scrollViews instead.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the scrollbar.
    //
    //   value:
    //     The position between min and max.
    //
    //   size:
    //     How much can we see?
    //
    //   topValue:
    //     The value at the top of the scrollbar.
    //
    //   bottomValue:
    //     The value at the bottom of the scrollbar.
    //
    //   style:
    //     The style to use for the scrollbar background. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    // Returns:
    //     The modified value. This can be changed by the user by dragging the scrollbar,
    //     or clicking the arrows at the end.
    public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue, GUIStyle style)
    {
        return Scroller(position, value, size, topValue, bottomValue, style, skin.GetStyle(style.name + "thumb"), skin.GetStyle(style.name + "upbutton"), skin.GetStyle(style.name + "downbutton"), horiz: false);
    }

    internal static float Scroller(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUIStyle leftButton, GUIStyle rightButton, bool horiz)
    {
        GUIUtility.CheckOnGUI();
        int controlID = GUIUtility.GetControlID(s_SliderHash, FocusType.Passive, position);
        Rect position2;
        Rect rect;
        Rect rect2;
        if (horiz)
        {
            position2 = new Rect(position.x + leftButton.fixedWidth, position.y, position.width - leftButton.fixedWidth - rightButton.fixedWidth, position.height);
            rect = new Rect(position.x, position.y, leftButton.fixedWidth, position.height);
            rect2 = new Rect(position.xMax - rightButton.fixedWidth, position.y, rightButton.fixedWidth, position.height);
        }
        else
        {
            position2 = new Rect(position.x, position.y + leftButton.fixedHeight, position.width, position.height - leftButton.fixedHeight - rightButton.fixedHeight);
            rect = new Rect(position.x, position.y, position.width, leftButton.fixedHeight);
            rect2 = new Rect(position.x, position.yMax - rightButton.fixedHeight, position.width, rightButton.fixedHeight);
        }

        value = Slider(position2, value, size, leftValue, rightValue, slider, thumb, horiz, controlID);
        bool flag = Event.current.type == EventType.MouseUp;
        if (ScrollerRepeatButton(controlID, rect, leftButton))
        {
            value -= 10f * ((leftValue < rightValue) ? 1f : (-1f));
        }

        if (ScrollerRepeatButton(controlID, rect2, rightButton))
        {
            value += 10f * ((leftValue < rightValue) ? 1f : (-1f));
        }

        if (flag && Event.current.type == EventType.Used)
        {
            s_ScrollControlId = 0;
        }

        value = ((!(leftValue < rightValue)) ? Mathf.Clamp(value, rightValue, leftValue - size) : Mathf.Clamp(value, leftValue, rightValue - size));
        return value;
    }

    public static void BeginClip(Rect position, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset)
    {
        GUIUtility.CheckOnGUI();
        GUIClip.Push(position, scrollOffset, renderOffset, resetOffset);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position)
    {
        BeginGroup(position, GUIContent.none, GUIStyle.none);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, string text)
    {
        BeginGroup(position, GUIContent.Temp(text), GUIStyle.none);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, Texture image)
    {
        BeginGroup(position, GUIContent.Temp(image), GUIStyle.none);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, GUIContent content)
    {
        BeginGroup(position, content, GUIStyle.none);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, GUIStyle style)
    {
        BeginGroup(position, GUIContent.none, style);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, string text, GUIStyle style)
    {
        BeginGroup(position, GUIContent.Temp(text), style);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, Texture image, GUIStyle style)
    {
        BeginGroup(position, GUIContent.Temp(image), style);
    }

    //
    // Summary:
    //     Begin a group. Must be matched with a call to EndGroup.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the group.
    //
    //   text:
    //     Text to display on the group.
    //
    //   image:
    //     Texture to display on the group.
    //
    //   content:
    //     Text, image and tooltip for this group. If supplied, any mouse clicks are "captured"
    //     by the group and not If left out, no background is rendered, and mouse clicks
    //     are passed.
    //
    //   style:
    //     The style to use for the background.
    public static void BeginGroup(Rect position, GUIContent content, GUIStyle style)
    {
        BeginGroup(position, content, style, Vector2.zero);
    }

    internal static void BeginGroup(Rect position, GUIContent content, GUIStyle style, Vector2 scrollOffset)
    {
        GUIUtility.CheckOnGUI();
        int controlID = GUIUtility.GetControlID(s_BeginGroupHash, FocusType.Passive);
        if (content != GUIContent.none || style != GUIStyle.none)
        {
            EventType type = Event.current.type;
            EventType eventType = type;
            if (eventType == EventType.Repaint)
            {
                style.Draw(position, content, controlID);
            }
            else if (position.Contains(Event.current.mousePosition))
            {
                GUIUtility.mouseUsed = true;
            }
        }

        GUIClip.Push(position, scrollOffset, Vector2.zero, resetOffset: false);
    }

    //
    // Summary:
    //     End a group.
    public static void EndGroup()
    {
        GUIUtility.CheckOnGUI();
        GUIClip.Internal_Pop();
    }

    public static void BeginClip(Rect position)
    {
        GUIUtility.CheckOnGUI();
        GUIClip.Push(position, Vector2.zero, Vector2.zero, resetOffset: false);
    }

    public static void EndClip()
    {
        GUIUtility.CheckOnGUI();
        GUIClip.Pop();
    }

    //
    // Summary:
    //     Begin a scrolling view inside your GUI.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the ScrollView.
    //
    //   scrollPosition:
    //     The pixel distance that the view is scrolled in the X and Y directions.
    //
    //   viewRect:
    //     The rectangle used inside the scrollview.
    //
    //   horizontalScrollbar:
    //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    //   verticalScrollbar:
    //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
    //     style from the current GUISkin is used.
    //
    //   alwaysShowHorizontal:
    //     Optional parameter to always show the horizontal scrollbar. If false or left
    //     out, it is only shown when viewRect is wider than position.
    //
    //   alwaysShowVertical:
    //     Optional parameter to always show the vertical scrollbar. If false or left out,
    //     it is only shown when viewRect is taller than position.
    //
    // Returns:
    //     The modified scrollPosition. Feed this back into the variable you pass in, as
    //     shown in the example.
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect)
    {
        return BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal: false, alwaysShowVertical: false, skin.horizontalScrollbar, skin.verticalScrollbar, skin.scrollView);
    }

    //
    // Summary:
    //     Begin a scrolling view inside your GUI.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the ScrollView.
    //
    //   scrollPosition:
    //     The pixel distance that the view is scrolled in the X and Y directions.
    //
    //   viewRect:
    //     The rectangle used inside the scrollview.
    //
    //   horizontalScrollbar:
    //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    //   verticalScrollbar:
    //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
    //     style from the current GUISkin is used.
    //
    //   alwaysShowHorizontal:
    //     Optional parameter to always show the horizontal scrollbar. If false or left
    //     out, it is only shown when viewRect is wider than position.
    //
    //   alwaysShowVertical:
    //     Optional parameter to always show the vertical scrollbar. If false or left out,
    //     it is only shown when viewRect is taller than position.
    //
    // Returns:
    //     The modified scrollPosition. Feed this back into the variable you pass in, as
    //     shown in the example.
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical)
    {
        return BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, skin.horizontalScrollbar, skin.verticalScrollbar, skin.scrollView);
    }

    //
    // Summary:
    //     Begin a scrolling view inside your GUI.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the ScrollView.
    //
    //   scrollPosition:
    //     The pixel distance that the view is scrolled in the X and Y directions.
    //
    //   viewRect:
    //     The rectangle used inside the scrollview.
    //
    //   horizontalScrollbar:
    //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    //   verticalScrollbar:
    //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
    //     style from the current GUISkin is used.
    //
    //   alwaysShowHorizontal:
    //     Optional parameter to always show the horizontal scrollbar. If false or left
    //     out, it is only shown when viewRect is wider than position.
    //
    //   alwaysShowVertical:
    //     Optional parameter to always show the vertical scrollbar. If false or left out,
    //     it is only shown when viewRect is taller than position.
    //
    // Returns:
    //     The modified scrollPosition. Feed this back into the variable you pass in, as
    //     shown in the example.
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
    {
        return BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal: false, alwaysShowVertical: false, horizontalScrollbar, verticalScrollbar, skin.scrollView);
    }

    //
    // Summary:
    //     Begin a scrolling view inside your GUI.
    //
    // Parameters:
    //   position:
    //     Rectangle on the screen to use for the ScrollView.
    //
    //   scrollPosition:
    //     The pixel distance that the view is scrolled in the X and Y directions.
    //
    //   viewRect:
    //     The rectangle used inside the scrollview.
    //
    //   horizontalScrollbar:
    //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
    //     style from the current GUISkin is used.
    //
    //   verticalScrollbar:
    //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
    //     style from the current GUISkin is used.
    //
    //   alwaysShowHorizontal:
    //     Optional parameter to always show the horizontal scrollbar. If false or left
    //     out, it is only shown when viewRect is wider than position.
    //
    //   alwaysShowVertical:
    //     Optional parameter to always show the vertical scrollbar. If false or left out,
    //     it is only shown when viewRect is taller than position.
    //
    // Returns:
    //     The modified scrollPosition. Feed this back into the variable you pass in, as
    //     shown in the example.
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
    {
        return BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, skin.scrollView);
    }

    protected static Vector2 DoBeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
    {
        return BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background);
    }

    internal static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
    {
        GUIUtility.CheckOnGUI();
        if (Event.current.type == EventType.DragUpdated && position.Contains(Event.current.mousePosition))
        {
            if (Mathf.Abs(Event.current.mousePosition.y - position.y) < 8f)
            {
                scrollPosition.y -= 16f;
                InternalRepaintEditorWindow();
            }
            else if (Mathf.Abs(Event.current.mousePosition.y - position.yMax) < 8f)
            {
                scrollPosition.y += 16f;
                InternalRepaintEditorWindow();
            }
        }

        int controlID = GUIUtility.GetControlID(s_ScrollviewHash, FocusType.Passive);
        ScrollViewState scrollViewState = (ScrollViewState)GUIUtility.GetStateObject(typeof(ScrollViewState), controlID);
        if (scrollViewState.apply)
        {
            scrollPosition = scrollViewState.scrollPosition;
            scrollViewState.apply = false;
        }

        scrollViewState.position = position;
        scrollViewState.scrollPosition = scrollPosition;
        scrollViewState.visibleRect = (scrollViewState.viewRect = viewRect);
        scrollViewState.visibleRect.width = position.width;
        scrollViewState.visibleRect.height = position.height;
        scrollViewStates.Push(scrollViewState);
        Rect screenRect = new Rect(position);
        switch (Event.current.type)
        {
            case EventType.Layout:
                GUIUtility.GetControlID(s_SliderHash, FocusType.Passive);
                GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                GUIUtility.GetControlID(s_SliderHash, FocusType.Passive);
                GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                break;
            default:
                {
                    bool flag = alwaysShowVertical;
                    bool flag2 = alwaysShowHorizontal;
                    if (flag2 || viewRect.width > screenRect.width)
                    {
                        scrollViewState.visibleRect.height = position.height - horizontalScrollbar.fixedHeight + (float)horizontalScrollbar.margin.top;
                        screenRect.height -= horizontalScrollbar.fixedHeight + (float)horizontalScrollbar.margin.top;
                        flag2 = true;
                    }

                    if (flag || viewRect.height > screenRect.height)
                    {
                        scrollViewState.visibleRect.width = position.width - verticalScrollbar.fixedWidth + (float)verticalScrollbar.margin.left;
                        screenRect.width -= verticalScrollbar.fixedWidth + (float)verticalScrollbar.margin.left;
                        flag = true;
                        if (!flag2 && viewRect.width > screenRect.width)
                        {
                            scrollViewState.visibleRect.height = position.height - horizontalScrollbar.fixedHeight + (float)horizontalScrollbar.margin.top;
                            screenRect.height -= horizontalScrollbar.fixedHeight + (float)horizontalScrollbar.margin.top;
                            flag2 = true;
                        }
                    }

                    if (Event.current.type == EventType.Repaint && background != GUIStyle.none)
                    {
                        background.Draw(position, position.Contains(Event.current.mousePosition), isActive: false, flag2 && flag, hasKeyboardFocus: false);
                    }

                    if (flag2 && horizontalScrollbar != GUIStyle.none)
                    {
                        scrollPosition.x = HorizontalScrollbar(new Rect(position.x, position.yMax - horizontalScrollbar.fixedHeight, screenRect.width, horizontalScrollbar.fixedHeight), scrollPosition.x, Mathf.Min(screenRect.width, viewRect.width), 0f, viewRect.width, horizontalScrollbar);
                    }
                    else
                    {
                        GUIUtility.GetControlID(s_SliderHash, FocusType.Passive);
                        GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                        GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                        scrollPosition.x = ((horizontalScrollbar != GUIStyle.none) ? 0f : Mathf.Clamp(scrollPosition.x, 0f, Mathf.Max(viewRect.width - position.width, 0f)));
                    }

                    if (flag && verticalScrollbar != GUIStyle.none)
                    {
                        scrollPosition.y = VerticalScrollbar(new Rect(screenRect.xMax + (float)verticalScrollbar.margin.left, screenRect.y, verticalScrollbar.fixedWidth, screenRect.height), scrollPosition.y, Mathf.Min(screenRect.height, viewRect.height), 0f, viewRect.height, verticalScrollbar);
                        break;
                    }

                    GUIUtility.GetControlID(s_SliderHash, FocusType.Passive);
                    GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                    GUIUtility.GetControlID(s_RepeatButtonHash, FocusType.Passive);
                    scrollPosition.y = ((verticalScrollbar != GUIStyle.none) ? 0f : Mathf.Clamp(scrollPosition.y, 0f, Mathf.Max(viewRect.height - position.height, 0f)));
                    break;
                }
            case EventType.Used:
                break;
        }

        GUIClip.Push(screenRect, new Vector2(Mathf.Round(0f - scrollPosition.x - viewRect.x), Mathf.Round(0f - scrollPosition.y - viewRect.y)), Vector2.zero, resetOffset: false);
        return scrollPosition;
    }

    //
    // Summary:
    //     Ends a scrollview started with a call to BeginScrollView.
    //
    // Parameters:
    //   handleScrollWheel:
    public static void EndScrollView()
    {
        EndScrollView(handleScrollWheel: true);
    }

    //
    // Summary:
    //     Ends a scrollview started with a call to BeginScrollView.
    //
    // Parameters:
    //   handleScrollWheel:
    public static void EndScrollView(bool handleScrollWheel)
    {
        GUIUtility.CheckOnGUI();
        if (scrollViewStates.Count == 0)
        {
            return;
        }

        ScrollViewState scrollViewState = (ScrollViewState)scrollViewStates.Peek();
        GUIClip.Pop();
        scrollViewStates.Pop();
        bool flag = false;
        float num = Time.realtimeSinceStartup - scrollViewState.previousTimeSinceStartup;
        scrollViewState.previousTimeSinceStartup = Time.realtimeSinceStartup;
        if (Event.current.type == EventType.Repaint && scrollViewState.velocity != Vector2.zero)
        {
            for (int i = 0; i < 2; i++)
            {
                scrollViewState.velocity[i] *= Mathf.Pow(0.1f, num);
                float num2 = 0.1f / num;
                if (Mathf.Abs(scrollViewState.velocity[i]) < num2)
                {
                    scrollViewState.velocity[i] = 0f;
                    continue;
                }

                scrollViewState.velocity[i] += ((scrollViewState.velocity[i] < 0f) ? num2 : (0f - num2));
                scrollViewState.scrollPosition[i] += scrollViewState.velocity[i] * num;
                flag = true;
                scrollViewState.touchScrollStartMousePosition = Event.current.mousePosition;
                scrollViewState.touchScrollStartPosition = scrollViewState.scrollPosition;
            }

            if (scrollViewState.velocity != Vector2.zero)
            {
                InternalRepaintEditorWindow();
            }
        }

        if (handleScrollWheel && (Event.current.type == EventType.ScrollWheel || Event.current.type == EventType.TouchDown || Event.current.type == EventType.TouchUp || Event.current.type == EventType.TouchMove) && (scrollViewState.viewRect.width > scrollViewState.visibleRect.width || scrollViewState.viewRect.height > scrollViewState.visibleRect.height))
        {
            if (Event.current.type == EventType.ScrollWheel && ((scrollViewState.viewRect.width > scrollViewState.visibleRect.width && !Mathf.Approximately(0f, Event.current.delta.x)) || (scrollViewState.viewRect.height > scrollViewState.visibleRect.height && !Mathf.Approximately(0f, Event.current.delta.y))) && scrollViewState.position.Contains(Event.current.mousePosition))
            {
                scrollViewState.scrollPosition.x = Mathf.Clamp(scrollViewState.scrollPosition.x + Event.current.delta.x * 20f, 0f, scrollViewState.viewRect.width - scrollViewState.visibleRect.width);
                scrollViewState.scrollPosition.y = Mathf.Clamp(scrollViewState.scrollPosition.y + Event.current.delta.y * 20f, 0f, scrollViewState.viewRect.height - scrollViewState.visibleRect.height);
                Event.current.Use();
                flag = true;
            }
            else if (Event.current.type == EventType.TouchDown && (Event.current.modifiers & EventModifiers.Alt) == EventModifiers.Alt && scrollViewState.position.Contains(Event.current.mousePosition))
            {
                scrollViewState.isDuringTouchScroll = true;
                scrollViewState.touchScrollStartMousePosition = Event.current.mousePosition;
                scrollViewState.touchScrollStartPosition = scrollViewState.scrollPosition;
                GUIUtility.hotControl = GUIUtility.GetControlID(s_ScrollviewHash, FocusType.Passive, scrollViewState.position);
                Event.current.Use();
            }
            else if (scrollViewState.isDuringTouchScroll && Event.current.type == EventType.TouchUp)
            {
                scrollViewState.isDuringTouchScroll = false;
            }
            else if (scrollViewState.isDuringTouchScroll && Event.current.type == EventType.TouchMove)
            {
                Vector2 scrollPosition = scrollViewState.scrollPosition;
                scrollViewState.scrollPosition.x = Mathf.Clamp(scrollViewState.touchScrollStartPosition.x - (Event.current.mousePosition.x - scrollViewState.touchScrollStartMousePosition.x), 0f, scrollViewState.viewRect.width - scrollViewState.visibleRect.width);
                scrollViewState.scrollPosition.y = Mathf.Clamp(scrollViewState.touchScrollStartPosition.y - (Event.current.mousePosition.y - scrollViewState.touchScrollStartMousePosition.y), 0f, scrollViewState.viewRect.height - scrollViewState.visibleRect.height);
                Event.current.Use();
                Vector2 b = (scrollViewState.scrollPosition - scrollPosition) / num;
                scrollViewState.velocity = Vector2.Lerp(scrollViewState.velocity, b, num * 10f);
                flag = true;
            }
        }

        if (flag)
        {
            if (scrollViewState.scrollPosition.x < 0f)
            {
                scrollViewState.scrollPosition.x = 0f;
            }

            if (scrollViewState.scrollPosition.y < 0f)
            {
                scrollViewState.scrollPosition.y = 0f;
            }

            scrollViewState.apply = true;
        }
    }

    internal static ScrollViewState GetTopScrollView()
    {
        if (scrollViewStates.Count != 0)
        {
            return (ScrollViewState)scrollViewStates.Peek();
        }

        return null;
    }

    //
    // Summary:
    //     Scrolls all enclosing scrollviews so they try to make position visible.
    //
    // Parameters:
    //   position:
    public static void ScrollTo(Rect position)
    {
        GetTopScrollView()?.ScrollTo(position);
    }

    public static bool ScrollTowards(Rect position, float maxDelta)
    {
        return GetTopScrollView()?.ScrollTowards(position, maxDelta) ?? false;
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, string text)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, GUIContent.Temp(text), skin.window, skin, forceRectOnLayout: true);
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, Texture image)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, GUIContent.Temp(image), skin.window, skin, forceRectOnLayout: true);
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent content)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, content, skin.window, skin, forceRectOnLayout: true);
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, GUIContent.Temp(text), style, skin, forceRectOnLayout: true);
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, Texture image, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, GUIContent.Temp(image), style, skin, forceRectOnLayout: true);
    }

    public static Rect Window(int id, Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoWindow(id, clientRect, func, title, style, skin, forceRectOnLayout: true);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, string text)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, GUIContent.Temp(text), skin.window, skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, Texture image)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, GUIContent.Temp(image), skin.window, skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, content, skin.window, skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, GUIContent.Temp(text), style, skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, Texture image, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, GUIContent.Temp(image), style, skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style)
    {
        GUIUtility.CheckOnGUI();
        return DoModalWindow(id, clientRect, func, content, style, skin);
    }

    private static Rect DoWindow(int id, Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout)
    {
        return Internal_DoWindow(id, GUIUtility.s_OriginalID, clientRect, func, title, style, skin, forceRectOnLayout);
    }

    private static Rect DoModalWindow(int id, Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin)
    {
        return Internal_DoModalWindow(id, GUIUtility.s_OriginalID, clientRect, func, content, style, skin);
    }

    [RequiredByNativeCode]
    internal static void CallWindowDelegate(WindowFunction func, int id, int instanceID, GUISkin _skin, int forceRect, float width, float height, GUIStyle style)
    {
        GUILayoutUtility.SelectIDList(id, isWindow: true);
        GUISkin gUISkin = skin;
        if (Event.current.type == EventType.Layout)
        {
            if (forceRect != 0)
            {
                GUILayoutOption[] options = new GUILayoutOption[2]
                {
                    GUILayout.Width(width),
                    GUILayout.Height(height)
                };
                GUILayoutUtility.BeginWindow(id, style, options);
            }
            else
            {
                GUILayoutUtility.BeginWindow(id, style, null);
            }
        }
        else
        {
            GUILayoutUtility.BeginWindow(id, GUIStyle.none, null);
        }

        skin = _skin;
        func?.Invoke(id);
        if (Event.current.type == EventType.Layout)
        {
            GUILayoutUtility.Layout();
        }

        skin = gUISkin;
    }

    //
    // Summary:
    //     If you want to have the entire window background to act as a drag area, use the
    //     version of DragWindow that takes no parameters and put it at the end of the window
    //     function.
    public static void DragWindow()
    {
        DragWindow(new Rect(0f, 0f, 10000f, 10000f));
    }

    internal static void BeginWindows(int skinMode, int editorWindowInstanceID)
    {
        GUILayoutGroup topLevel = GUILayoutUtility.current.topLevel;
        GenericStack layoutGroups = GUILayoutUtility.current.layoutGroups;
        GUILayoutGroup windows = GUILayoutUtility.current.windows;
        Matrix4x4 matrix4x = matrix;
        Internal_BeginWindows();
        matrix = matrix4x;
        GUILayoutUtility.current.topLevel = topLevel;
        GUILayoutUtility.current.layoutGroups = layoutGroups;
        GUILayoutUtility.current.windows = windows;
    }

    internal static void EndWindows()
    {
        GUILayoutGroup topLevel = GUILayoutUtility.current.topLevel;
        GenericStack layoutGroups = GUILayoutUtility.current.layoutGroups;
        GUILayoutGroup windows = GUILayoutUtility.current.windows;
        Internal_EndWindows();
        GUILayoutUtility.current.topLevel = topLevel;
        GUILayoutUtility.current.layoutGroups = layoutGroups;
        GUILayoutUtility.current.windows = windows;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void get_color_Injected(out Color ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void set_color_Injected(ref Color value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void get_backgroundColor_Injected(out Color ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void set_backgroundColor_Injected(ref Color value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void get_contentColor_Injected(out Color ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private static extern void set_contentColor_Injected(ref Color value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_DoModalWindow_Injected(int id, int instanceID, ref Rect clientRect, WindowFunction func, GUIContent content, GUIStyle style, object skin, out Rect ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_DoWindow_Injected(int id, int instanceID, ref Rect clientRect, WindowFunction func, GUIContent title, GUIStyle style, object skin, bool forceRectOnLayout, out Rect ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void DragWindow_Injected(ref Rect position);
}

