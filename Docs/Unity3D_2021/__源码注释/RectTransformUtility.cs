#region 程序集 UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UIModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Utility class containing helper methods for working with RectTransform.
    [NativeHeaderAttribute("Runtime/Camera/Camera.h")]
    [NativeHeaderAttribute("Modules/UI/Canvas.h")]
    [NativeHeaderAttribute("Modules/UI/RectTransformUtil.h")]
    [NativeHeaderAttribute("Runtime/Transform/RectTransform.h")]
    [StaticAccessorAttribute("UI", Bindings.StaticAccessorType.DoubleColon)]
    public sealed class RectTransformUtility
    {
        public static Bounds CalculateRelativeRectTransformBounds(Transform root, Transform child);
        public static Bounds CalculateRelativeRectTransformBounds(Transform trans);
        //
        // 摘要:
        //     Flips the horizontal and vertical axes of the RectTransform size and alignment,
        //     and optionally its children as well.
        //
        // 参数:
        //   rect:
        //     The RectTransform to flip.
        //
        //   keepPositioning:
        //     Flips around the pivot if true. Flips within the parent rect if false.
        //
        //   recursive:
        //     Flip the children as well?
        public static void FlipLayoutAxes(RectTransform rect, bool keepPositioning, bool recursive);
        //
        // 摘要:
        //     Flips the alignment of the RectTransform along the horizontal or vertical axis,
        //     and optionally its children as well.
        //
        // 参数:
        //   rect:
        //     The RectTransform to flip.
        //
        //   keepPositioning:
        //     Flips around the pivot if true. Flips within the parent rect if false.
        //
        //   recursive:
        //     Flip the children as well?
        //
        //   axis:
        //     The axis to flip along. 0 is horizontal and 1 is vertical.
        public static void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive);
        //
        // 摘要:
        //     Convert a given point in screen space into a pixel correct point.
        //
        // 参数:
        //   point:
        //
        //   elementTransform:
        //
        //   canvas:
        //
        // 返回结果:
        //     Pixel adjusted point.
        public static Vector2 PixelAdjustPoint(Vector2 point, Transform elementTransform, Canvas canvas);
        //
        // 摘要:
        //     Given a rect transform, return the corner points in pixel accurate coordinates.
        //
        // 参数:
        //   rectTransform:
        //
        //   canvas:
        //
        // 返回结果:
        //     Pixel adjusted rect.
        public static Rect PixelAdjustRect(RectTransform rectTransform, Canvas canvas);
        public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint);
        //
        // 摘要:
        //     Does the RectTransform contain the screen point as seen from the given camera?
        //
        // 参数:
        //   rect:
        //     The RectTransform to test with.
        //
        //   screenPoint:
        //     The screen point to test.
        //
        //   cam:
        //     The camera from which the test is performed from. (Optional)
        //
        // 返回结果:
        //     True if the point is inside the rectangle.
        public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam);
        public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam, Vector4 offset);

        /*
            Transform a screen space point to a position in the local space of a RectTransform that is on the plane of its rectangle.

            The cam parameter should be the camera associated with the screen point. 
            For a RectTransform in a Canvas set to Screen Space - Overlay mode, the cam parameter should be null.

            When ScreenPointToLocalPointInRectangle is used from within an event handler that provides a PointerEventData object, 
            the correct camera can be obtained by using PointerEventData.enterEventData (for hover functionality) or PointerEventData.pressEventCamera (for click functionality). 
            This will automatically use the correct camera (or null) for the given event.


        */
        public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint);

        
        public static Ray ScreenPointToRay(Camera cam, Vector2 screenPos);
        public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint);
        public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint);
    }
}
