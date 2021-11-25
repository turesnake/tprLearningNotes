#region 程序集 UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.IMGUIModule.dll
#endregion

namespace UnityEngine
{
    /*
        摘要:
        Types of UnityGUI input and processing events.

        Use this to tell which type of event has taken place in the GUI. 
        事件类型包含: 
            mouse clicking, 
            mouse dragging, 
            button pressing, 
            the mouse entering or exiting the window, 
            the scroll wheel
            ...

        用法:
            void OnGUI()
            {
                if (Event.current.type == EventType.MouseDown){
                    Debug.Log("Mouse Down.");
                }
            }

    */
    public enum EventType
    {
        
        //     Mouse button was pressed.
        // This event gets sent when any mouse button is pressed. 
        //Use Event.button to determine which button was pressed down.
        MouseDown = 0,
        mouseDown = 0,
        
        //     Mouse button was released.
        // This event gets sent when any mouse button is released
        MouseUp = 1,
        mouseUp = 1,


        //
        // 摘要:
        //     Mouse was moved (Editor views only).
        MouseMove = 2,
        mouseMove = 2,
        //
        // 摘要:
        //     Mouse was dragged.
        MouseDrag = 3,
        //
        // 摘要:
        //     An event that is called when the mouse is clicked and dragged.
        mouseDrag = 3,
        //
        // 摘要:
        //     A keyboard key was pressed.
        KeyDown = 4,
        keyDown = 4,
        //
        // 摘要:
        //     A keyboard key was released.
        KeyUp = 5,
        keyUp = 5,
        //
        // 摘要:
        //     The scroll wheel was moved.
        ScrollWheel = 6,
        scrollWheel = 6,
        
        //
        // 摘要:
        //     A repaint event. One is sent every frame.
        Repaint = 7,
        repaint = 7,

        //
        // 摘要:
        //     A layout event.
        Layout = 8,
        layout = 8,

        //
        // 摘要:
        //     Editor only: drag & drop operation updated.
        DragUpdated = 9,
        dragUpdated = 9,

        //
        // 摘要:
        //     Editor only: drag & drop operation performed.
        DragPerform = 10,
        dragPerform = 10,

        //
        // 摘要:
        //     Event should be ignored.
        Ignore = 11,
        ignore = 11,

        //
        // 摘要:
        //     Already processed event.
        Used = 12,
        used = 12,

        //
        // 摘要:
        //     Validates a special command (e.g. copy & paste).
        ValidateCommand = 13,
        //
        // 摘要:
        //     Execute a special command (eg. copy & paste).
        ExecuteCommand = 14,
        //
        // 摘要:
        //     Editor only: drag & drop operation exited.
        DragExited = 15,
        //
        // 摘要:
        //     User has right-clicked (or control-clicked on the mac).
        ContextClick = 16,
        //
        // 摘要:
        //     Mouse entered a window (Editor views only).
        MouseEnterWindow = 20,
        //
        // 摘要:
        //     Mouse left a window (Editor views only).
        MouseLeaveWindow = 21,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) touched the screen.
        TouchDown = 30,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) left the screen.
        TouchUp = 31,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) moved on the screen (drag).
        TouchMove = 32,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) moving into the window (drag).
        TouchEnter = 33,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) moved out of the window (drag).
        TouchLeave = 34,
        //
        // 摘要:
        //     Direct manipulation device (finger, pen) stationary event (long touch down).
        TouchStationary = 35
    }
}

