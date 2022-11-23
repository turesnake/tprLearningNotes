
#region 程序集 UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.InputLegacyModule.dll
#endregion


namespace UnityEngine
{
    /*
        Structure describing the status of a finger touching the screen.

        Touch touch = Input.GetTouch(i);

    */
    [NativeHeaderAttribute("Runtime/Input/InputBindings.h")]
    public struct Touch
    {
        //
        // 摘要:
        //     The unique index for the touch.
        public int fingerId { get; set; }
        //
        // 摘要:
        //     The position of the touch in screen space pixel coordinates.
        public Vector2 position { get; set; }
        //
        // 摘要:
        //     The first position of the touch contact in screen space pixel coordinates.
        public Vector2 rawPosition { get; set; }
        //
        // 摘要:
        //     The position delta since last change in pixel coordinates.
        public Vector2 deltaPosition { get; set; }
        //
        // 摘要:
        //     Amount of time that has passed since the last recorded change in Touch values.
        public float deltaTime { get; set; }
        //
        // 摘要:
        //     Number of taps.
        public int tapCount { get; set; }
        //
        // 摘要:
        //     Describes the phase of the touch.
        public TouchPhase phase { get; set; }
        //
        // 摘要:
        //     The current amount of pressure being applied to a touch. 1.0f is considered to
        //     be the pressure of an average touch. If Input.touchPressureSupported returns
        //     false, the value of this property will always be 1.0f.
        public float pressure { get; set; }
        //
        // 摘要:
        //     The maximum possible pressure value for a platform. If Input.touchPressureSupported
        //     returns false, the value of this property will always be 1.0f.
        public float maximumPossiblePressure { get; set; }
        //
        // 摘要:
        //     A value that indicates whether a touch was of Direct, Indirect (or remote), or
        //     Stylus type.
        public TouchType type { get; set; }
        //
        // 摘要:
        //     Value of 0 radians indicates that the stylus is parallel to the surface, pi/2
        //     indicates that it is perpendicular.
        public float altitudeAngle { get; set; }
        //
        // 摘要:
        //     Value of 0 radians indicates that the stylus is pointed along the x-axis of the
        //     device.
        public float azimuthAngle { get; set; }
        //
        // 摘要:
        //     An estimated value of the radius of a touch. Add radiusVariance to get the maximum
        //     touch size, subtract it to get the minimum touch size.
        public float radius { get; set; }
        //
        // 摘要:
        //     This value determines the accuracy of the touch radius. Add this value to the
        //     radius to get the maximum touch size, subtract it to get the minimum touch size.
        public float radiusVariance { get; set; }
    }
}
