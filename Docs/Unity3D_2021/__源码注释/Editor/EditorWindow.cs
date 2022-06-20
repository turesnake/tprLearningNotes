#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.UIElements;

namespace UnityEditor
{
    /*
        Derive from this class to create an editor window.

        可以在 unity 编辑器中 创建一个 浮动窗口, 非常强大, 可使用此系统, 在启用一些工具之前, 优先配置一些参数;


        # ----------- SSS ----------- #
        #  如何缓存这些 配置参数:
        使用: EditorPrefs;  这是 unity 自带的一个数据缓存表;

        参考这个网页中的使用示范代码:
            https://answers.unity.com/questions/119978/how-do-i-have-an-editorwindow-save-its-data-inbetw.html

        直接地说, 就是将下面代码复制进

            // 读取上次用户设置的 参数, (或使用默认值)
            protected void OnEnable()
            {
                // Here we retrieve the data if it exists or we save the default field initialisers we set above
                var data = EditorPrefs.GetString("AutoOptimizeAndReplaceFBXAnimation", JsonUtility.ToJson(this, false));
                // Then we apply them to this window
                JsonUtility.FromJsonOverwrite(data, this);
            }

            // 存储本次用户设置的参数
            protected void OnDisable()
            {
                // We get the Json data
                var data = JsonUtility.ToJson(this, false);
                // And we save it
                EditorPrefs.SetString("AutoOptimizeAndReplaceFBXAnimation", data);
            }



    */
    [ExcludeFromObjectFactory]
    [NativeHeaderAttribute("Editor/Src/ContainerWindow.bindings.h")]
    [UsedByNativeCodeAttribute]
    public class EditorWindow : ScriptableObject
    {
        public EditorWindow();

        //
        // 摘要:
        //     The EditorWindow currently under the mouse cursor. (Read Only)
        public static EditorWindow mouseOverWindow { get; }
        //
        // 摘要:
        //     The EditorWindow which currently has keyboard focus. (Read Only)
        public static EditorWindow focusedWindow { get; }
        //
        // 摘要:
        //     Checks whether MouseMove events are received in the GUI in this Editor window.
        public bool wantsMouseMove { get; set; }
        //
        // 摘要:
        //     Checks whether MouseEnterWindow and MouseLeaveWindow events are received in the
        //     GUI in this Editor window.
        public bool wantsMouseEnterLeaveWindow { get; set; }
        [Obsolete("AA is not supported on EditorWindows", false)]
        public int antiAlias { get; set; }
        //
        // 摘要:
        //     Retrieves the root visual element of this window hierarchy.
        public VisualElement rootVisualElement { get; }
        //
        // 摘要:
        //     Specifies whether a layout pass is performed before all user events (for example,
        //     EventType.MouseDown or EventType, KeyDown), or is only performed before repaint
        //     events.
        public bool wantsLessLayoutEvents { get; set; }
        //
        // 摘要:
        //     Does the window automatically repaint whenever the Scene has changed?
        public bool autoRepaintOnSceneChange { get; set; }
        //
        // 摘要:
        //     Is this window maximized?
        public bool maximized { get; set; }
        //
        // 摘要:
        //     Returns true if EditorWindow is focused.
        public bool hasFocus { get; }
        //
        // 摘要:
        //     The desired position of the window in screen space.
        public Rect position { get; set; }
        //
        // 摘要:
        //     This property specifies whether the Editor prompts the user to save or discard
        //     unsaved changes before the window closes.
        public bool hasUnsavedChanges { get; protected set; }
        //
        // 摘要:
        //     The message that displays to the user if they are prompted to save
        public string saveChangesMessage { get; protected set; }
        //
        // 摘要:
        //     The minimum size of this window when it is floating or modal. The minimum size
        //     is not used when the window is docked.
        public Vector2 minSize { get; set; }
        public int depthBufferBits { get; set; }
        //
        // 摘要:
        //     The GUIContent used for drawing the title of EditorWindows.
        public GUIContent titleContent { get; set; }
        //
        // 摘要:
        //     The title of this window.
        [Obsolete("Use titleContent instead (it supports setting a title icon as well).")]
        public string title { get; set; }
        //
        // 摘要:
        //     The maximum size of this window when it is floating or modal. The maximum size
        //     is not used when the window is docked.
        public Vector2 maxSize { get; set; }
        //
        // 摘要:
        //     Returns true if EditorWindow is docked.
        public bool docked { get; }

        public static T CreateWindow<T>(string title, params Type[] desiredDockNextTo) where T : EditorWindow;
        public static T CreateWindow<T>(params Type[] desiredDockNextTo) where T : EditorWindow;
        public static void FocusWindowIfItsOpen<T>() where T : EditorWindow;
        //
        // 摘要:
        //     Focuses the first found EditorWindow of specified type if it is open.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        public static void FocusWindowIfItsOpen(Type t);
        public static T GetWindow<T>(string title, bool focus, params Type[] desiredDockNextTo) where T : EditorWindow;
        public static T GetWindow<T>(string title, params Type[] desiredDockNextTo) where T : EditorWindow;
        public static T GetWindow<T>(params Type[] desiredDockNextTo) where T : EditorWindow;
        public static T GetWindow<T>(bool utility, string title, bool focus) where T : EditorWindow;
        public static T GetWindow<T>(string title) where T : EditorWindow;
        public static T GetWindow<T>(bool utility, string title) where T : EditorWindow;
        public static T GetWindow<T>(bool utility) where T : EditorWindow;
        public static T GetWindow<T>() where T : EditorWindow;
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        //
        //   focus:
        //     Whether to give the window focus, if it already exists. (If GetWindow creates
        //     a new window, it will always get focus).
        [ExcludeFromDocs]
        public static EditorWindow GetWindow(Type t);
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        //
        //   focus:
        //     Whether to give the window focus, if it already exists. (If GetWindow creates
        //     a new window, it will always get focus).
        [ExcludeFromDocs]
        public static EditorWindow GetWindow(Type t, bool utility);
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        //
        //   focus:
        //     Whether to give the window focus, if it already exists. (If GetWindow creates
        //     a new window, it will always get focus).
        [ExcludeFromDocs]
        public static EditorWindow GetWindow(Type t, bool utility, string title);
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        //
        //   focus:
        //     Whether to give the window focus, if it already exists. (If GetWindow creates
        //     a new window, it will always get focus).
        public static EditorWindow GetWindow(Type t, [DefaultValue("false")] bool utility, [DefaultValue("null")] string title, [DefaultValue("true")] bool focus);
        public static T GetWindow<T>(string title, bool focus) where T : EditorWindow;
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   rect:
        //     The position on the screen where a newly created window will show.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        [ExcludeFromDocs]
        public static EditorWindow GetWindowWithRect(Type t, Rect rect, bool utility);
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   rect:
        //     The position on the screen where a newly created window will show.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        public static EditorWindow GetWindowWithRect(Type t, Rect rect, [DefaultValue("false")] bool utility, [DefaultValue("null")] string title);
        public static T GetWindowWithRect<T>(Rect rect) where T : EditorWindow;
        public static T GetWindowWithRect<T>(Rect rect, bool utility) where T : EditorWindow;
        public static T GetWindowWithRect<T>(Rect rect, bool utility, string title) where T : EditorWindow;
        public static T GetWindowWithRect<T>(Rect rect, bool utility, string title, bool focus) where T : EditorWindow;
        //
        // 摘要:
        //     Returns the first EditorWindow of type t which is currently on the screen.
        //
        // 参数:
        //   t:
        //     The type of the window. Must derive from EditorWindow.
        //
        //   rect:
        //     The position on the screen where a newly created window will show.
        //
        //   utility:
        //     Set this to true, to create a floating utility window, false to create a normal
        //     window.
        //
        //   title:
        //     If GetWindow creates a new window, it will get this title. If this value is null,
        //     use the class name as title.
        [ExcludeFromDocs]
        public static EditorWindow GetWindowWithRect(Type t, Rect rect);
        public static bool HasOpenInstances<T>() where T : EditorWindow;
        //
        // 摘要:
        //     Mark the beginning area of all popup windows.
        public void BeginWindows();
        //
        // 摘要:
        //     Close the editor window.
        public void Close();
        //
        // 摘要:
        //     Discards unsaved changes to the contents of the window.
        public virtual void DiscardChanges();
        //
        // 摘要:
        //     Close a window group started with EditorWindow.BeginWindows.
        public void EndWindows();
        //
        // 摘要:
        //     Moves keyboard focus to another EditorWindow.
        public void Focus();
        //
        // 摘要:
        //     Gets the extra panes associated with the window.
        //
        // 返回结果:
        //     The extra panes that are specific to the window.
        public virtual IEnumerable<Type> GetExtraPaneTypes();
        //
        // 摘要:
        //     Stop showing notification message.
        public void RemoveNotification();
        //
        // 摘要:
        //     Make the window repaint.
        public void Repaint();
        //
        // 摘要:
        //     Performs a save action on the contents of the window.
        public virtual void SaveChanges();
        //
        // 摘要:
        //     Sends an Event to a window.
        //
        // 参数:
        //   e:
        public bool SendEvent(Event e);
        //
        // 摘要:
        //     Show the EditorWindow window.
        //
        // 参数:
        //   immediateDisplay:
        //     Immediately display Show.
        public void Show(bool immediateDisplay);
        //
        // 摘要:
        //     Show the EditorWindow window.
        //
        // 参数:
        //   immediateDisplay:
        //     Immediately display Show.
        public void Show();
        //
        // 摘要:
        //     Shows a window with dropdown behaviour and styling.
        //
        // 参数:
        //   buttonRect:
        //     The button from which the position of the window will be determined (see description).
        //
        //   windowSize:
        //     The initial size of the window.
        public void ShowAsDropDown(Rect buttonRect, Vector2 windowSize);
        //
        // 摘要:
        //     Show the editor window in the auxiliary window.
        public void ShowAuxWindow();
        //
        // 摘要:
        //     Show modal editor window.
        public void ShowModal();
        //
        // 摘要:
        //     Show the EditorWindow as a floating modal window.
        public void ShowModalUtility();
        //
        // 摘要:
        //     Show a notification message.
        //
        // 参数:
        //   notification:
        //     The contents of the notification message.
        //
        //   fadeoutWait:
        //     The duration the notification is displayed. Measured in seconds.
        public void ShowNotification(GUIContent notification, double fadeoutWait);
        //
        // 摘要:
        //     Show a notification message.
        //
        // 参数:
        //   notification:
        //     The contents of the notification message.
        //
        //   fadeoutWait:
        //     The duration the notification is displayed. Measured in seconds.
        public void ShowNotification(GUIContent notification);
        //
        // 摘要:
        //     Shows an Editor window using popup-style framing.
        public void ShowPopup();
        public void ShowTab();
        //
        // 摘要:
        //     Show the EditorWindow as a floating utility window.
        public void ShowUtility();
        public bool TryGetOverlay(string id, out Overlay match);
        //
        // 摘要:
        //     Called when the UI scaling for this EditorWindow is changed.
        protected virtual void OnBackingScaleFactorChanged();
    }
}
