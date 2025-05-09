
#region 程序集 UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.InputLegacyModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     Interface into the Input system.
    [NativeHeaderAttribute("Runtime/Input/InputBindings.h")]
    public class Input
    {
        public Input();

        //
        // 摘要:
        //     Returns the keyboard input entered this frame. (Read Only)
        [NativeThrowsAttribute]
        public static string inputString { get; }
        //
        // 摘要:
        //     Controls enabling and disabling of IME input composition.
        public static IMECompositionMode imeCompositionMode { get; set; }
        //
        // 摘要:
        //     The current IME composition string being typed by the user.
        public static string compositionString { get; }
        //
        // 摘要:
        //     Does the user have an IME keyboard input source selected?
        public static bool imeIsSelected { get; }

        
        //
        // 摘要:
        //     The current text input position used by IMEs to open windows.
        public static Vector2 compositionCursorPos { get; set; }


        //
        // 摘要:
        //     Property indicating whether keypresses are eaten by a textinput if it has focus
        //     (default true).
        [Obsolete("eatKeyPressOnTextFieldFocus property is deprecated, and only provided to support legacy behavior.")]
        public static bool eatKeyPressOnTextFieldFocus { get; set; }
        //
        // 摘要:
        //     Indicates if a mouse device is detected.
        public static bool mousePresent { get; }
        //
        // 摘要:
        //     Number of touches. Guaranteed not to change throughout the frame. (Read Only)
        public static int touchCount { get; }
        //
        // 摘要:
        //     Bool value which let's users check if touch pressure is supported.
        public static bool touchPressureSupported { get; }
        //
        // 摘要:
        //     Returns true when Stylus Touch is supported by a device or platform.
        public static bool stylusTouchSupported { get; }
        //
        // 摘要:
        //     Returns whether the device on which application is currently running supports
        //     touch input.
        public static bool touchSupported { get; }
        //
        // 摘要:
        //     Property indicating whether the system handles multiple touches.
        public static bool multiTouchEnabled { get; set; }
        [Obsolete("isGyroAvailable property is deprecated. Please use SystemInfo.supportsGyroscope instead.")]
        public static bool isGyroAvailable { get; }
        //
        // 摘要:
        //     Device physical orientation as reported by OS. (Read Only)
        public static DeviceOrientation deviceOrientation { get; }
        //
        // 摘要:
        //     Last measured linear acceleration of a device in three-dimensional space. (Read
        //     Only)
        public static Vector3 acceleration { get; }
        //
        // 摘要:
        //     This property controls if input sensors should be compensated for screen orientation.
        public static bool compensateSensors { get; set; }
        //
        // 摘要:
        //     Number of acceleration measurements which occurred during last frame.
        public static int accelerationEventCount { get; }
        //
        // 摘要:
        //     Should Back button quit the application? Only usable on Android, Windows Phone
        //     or Windows Tablets.
        public static bool backButtonLeavesApp { get; set; }
        //
        // 摘要:
        //     Property for accessing device location (handheld devices only). (Read Only)
        public static LocationService location { get; }
        //
        // 摘要:
        //     Property for accessing compass (handheld devices only). (Read Only)
        public static Compass compass { get; }
        //
        // 摘要:
        //     Returns default gyroscope.
        public static Gyroscope gyro { get; }


        /*
            The current mouse scroll delta. (Read Only)

            滚轮 前滚时, y = -1.0;
                后滚时,  y =  1.0;
        */
        [NativeThrowsAttribute]
        public static Vector2 mouseScrollDelta { get; }


        /*
            The current mouse position in pixel coordinates. (Read Only).
            ---
            假设当前屏幕是 800x600, 那么得到的值就位于 [0,0] -> [800,600] 这矩形区间内, z值为0
        */
        [NativeThrowsAttribute]
        public static Vector3 mousePosition { get; }


        //
        // 摘要:
        //     Returns list of acceleration measurements which occurred during the last frame.
        //     (Read Only) (Allocates temporary variables).
        public static AccelerationEvent[] accelerationEvents { get; }
        //
        // 摘要:
        //     Returns true the first frame the user hits any key or mouse button. (Read Only)
        [NativeThrowsAttribute]
        public static bool anyKeyDown { get; }
        //
        // 摘要:
        //     Is any key or mouse button currently held down? (Read Only)
        [NativeThrowsAttribute]
        public static bool anyKey { get; }
        //
        // 摘要:
        //     Enables/Disables mouse simulation with touches. By default this option is enabled.
        public static bool simulateMouseWithTouches { get; set; }
        //
        // 摘要:
        //     Returns list of objects representing status of all touches during last frame.
        //     (Read Only) (Allocates temporary variables).
        public static Touch[] touches { get; }

        //
        // 摘要:
        //     Returns specific acceleration measurement which occurred during last frame. (Does
        //     not allocate temporary variables).
        //
        // 参数:
        //   index:
        [NativeThrowsAttribute]
        public static AccelerationEvent GetAccelerationEvent(int index);
        //
        // 摘要:
        //     Returns the value of the virtual axis identified by axisName.
        //
        // 参数:
        //   axisName:
        [NativeThrowsAttribute]
        public static float GetAxis(string axisName);
        //
        // 摘要:
        //     Returns the value of the virtual axis identified by axisName with no smoothing
        //     filtering applied.
        //
        // 参数:
        //   axisName:
        [NativeThrowsAttribute]
        public static float GetAxisRaw(string axisName);
        //
        // 摘要:
        //     Returns true while the virtual button identified by buttonName is held down.
        //
        // 参数:
        //   buttonName:
        //     The name of the button such as Jump.
        //
        // 返回结果:
        //     True when an axis has been pressed and not released.
        [NativeThrowsAttribute]
        public static bool GetButton(string buttonName);
        //
        // 摘要:
        //     Returns true during the frame the user pressed down the virtual button identified
        //     by buttonName.
        //
        // 参数:
        //   buttonName:
        [NativeThrowsAttribute]
        public static bool GetButtonDown(string buttonName);
        //
        // 摘要:
        //     Returns true the first frame the user releases the virtual button identified
        //     by buttonName.
        //
        // 参数:
        //   buttonName:
        [NativeThrowsAttribute]
        public static bool GetButtonUp(string buttonName);
        //
        // 摘要:
        //     Retrieves a list of input device names corresponding to the index of an Axis
        //     configured within Input Manager.
        //
        // 返回结果:
        //     Returns an array of joystick and gamepad device names.
        [NativeThrowsAttribute]
        public static string[] GetJoystickNames();
        //
        // 摘要:
        //     Returns true while the user holds down the key identified by name.
        //
        // 参数:
        //   name:
        public static bool GetKey(string name);
        //
        // 摘要:
        //     Returns true while the user holds down the key identified by the key KeyCode
        //     enum parameter.
        //
        // 参数:
        //   key:
        public static bool GetKey(KeyCode key);
        //
        // 摘要:
        //     Returns true during the frame the user starts pressing down the key identified
        //     by the key KeyCode enum parameter.
        //
        // 参数:
        //   key:
        public static bool GetKeyDown(KeyCode key);
        //
        // 摘要:
        //     Returns true during the frame the user starts pressing down the key identified
        //     by name.
        //
        // 参数:
        //   name:
        public static bool GetKeyDown(string name);
        //
        // 摘要:
        //     Returns true during the frame the user releases the key identified by the key
        //     KeyCode enum parameter.
        //
        // 参数:
        //   key:
        public static bool GetKeyUp(KeyCode key);
        //
        // 摘要:
        //     Returns true during the frame the user releases the key identified by name.
        //
        // 参数:
        //   name:
        public static bool GetKeyUp(string name);


        /*
            Returns whether the given mouse button is held down.
            ---
            注意:
                在按下的第一帧, 先触发 GetMouseButtonDown(), 后触发 GetMouseButton()
                在持续按下后的每一帧, 只触发 GetMouseButton()
                在离开按下的第一帧, 只触发 GetMouseButtonUp() -- 可以理解为是 尾后帧

            参数:
            button:
        */
        [NativeThrowsAttribute]
        public static bool GetMouseButton(int button);

        /*
            Returns true during the frame the user pressed the given mouse button.
            ---
            注意:
                在按下的第一帧, 先触发 mouseDown(), 后触发 GetMouseButton()
                在持续按下后的每一帧, 只触发 GetMouseButton()
                在离开按下的第一帧, 只触发 GetMouseButtonUp() -- 可以理解为是 尾后帧
            
            参数:
              button:
        */
        [NativeThrowsAttribute]
        public static bool GetMouseButtonDown(int button);

        /*
            Returns true during the frame the user releases the given mouse button.
            ---
            注意:
                在按下的第一帧, 先触发 GetMouseButtonDown(), 后触发 GetMouseButton()
                在持续按下后的每一帧, 只触发 GetMouseButton()
                在离开按下的第一帧, 只触发 GetMouseButtonUp() -- 可以理解为是 尾后帧
            
            参数:
              button:
        */
        [NativeThrowsAttribute]
        public static bool GetMouseButtonUp(int button);

        //
        // 摘要:
        //     Call Input.GetTouch to obtain a Touch struct.
        //
        // 参数:
        //   index:
        //     The touch input on the device screen.
        //
        // 返回结果:
        //     Touch details in the struct.
        [NativeThrowsAttribute]
        public static Touch GetTouch(int index);
        //
        // 摘要:
        //     Determine whether a particular joystick model has been preconfigured by Unity.
        //     (Linux-only).
        //
        // 参数:
        //   joystickName:
        //     The name of the joystick to check (returned by Input.GetJoystickNames).
        //
        // 返回结果:
        //     True if the joystick layout has been preconfigured; false otherwise.
        public static bool IsJoystickPreconfigured(string joystickName);
        //
        // 摘要:
        //     Resets all input. After ResetInputAxes all axes return to 0 and all buttons return
        //     to 0 for one frame.
        [FreeFunctionAttribute("ResetInput")]
        public static void ResetInputAxes();
    }
}