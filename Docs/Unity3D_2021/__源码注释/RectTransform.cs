#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Position, size, anchor and pivot information for a rectangle.
    [NativeClassAttribute("UI::RectTransform")]
    [NativeHeaderAttribute("Runtime/Transform/RectTransform.h")]
    public sealed class RectTransform : Transform
    {
        public RectTransform();

        //
        // 摘要:
        //     The position of the pivot of this RectTransform relative to the anchor reference
        //     point.
        public Vector2 anchoredPosition { get; set; }
        //
        // 摘要:
        //     The object that is driving the values of this RectTransform. Value is null if
        //     not driven.
        public Object drivenByObject { get; }
        //
        // 摘要:
        //     The offset of the upper right corner of the rectangle relative to the upper right
        //     anchor.
        public Vector2 offsetMax { get; set; }
        //
        // 摘要:
        //     The offset of the lower left corner of the rectangle relative to the lower left
        //     anchor.
        public Vector2 offsetMin { get; set; }
        //
        // 摘要:
        //     The calculated rectangle in the local space of the Transform.
        public Rect rect { get; }
        //
        // 摘要:
        //     The normalized position in the parent RectTransform that the lower left corner
        //     is anchored to.
        public Vector2 anchorMin { get; set; }
        //
        // 摘要:
        //     The normalized position in the parent RectTransform that the upper right corner
        //     is anchored to.
        public Vector2 anchorMax { get; set; }
        //
        // 摘要:
        //     The 3D position of the pivot of this RectTransform relative to the anchor reference
        //     point.
        public Vector3 anchoredPosition3D { get; set; }
        //
        // 摘要:
        //     The size of this RectTransform relative to the distances between the anchors.
        public Vector2 sizeDelta { get; set; }
        //
        // 摘要:
        //     The normalized position in this RectTransform that it rotates around.
        public Vector2 pivot { get; set; }

        public static event ReapplyDrivenProperties reapplyDrivenProperties;

        //
        // 摘要:
        //     Force the recalculation of RectTransforms internal data.
        [NativeMethodAttribute("UpdateIfTransformDispatchIsDirty")]
        public void ForceUpdateRectTransforms();
        //
        // 摘要:
        //     Get the corners of the calculated rectangle in the local space of its Transform.
        //
        // 参数:
        //   fourCornersArray:
        //     The array that corners are filled into.
        public void GetLocalCorners(Vector3[] fourCornersArray);
        
        //
        // 摘要:
        //     Get the corners of the calculated rectangle in world space.
        //
        // 参数:
        //   fourCornersArray:
        //     The array that corners are filled into.
        public void GetWorldCorners(Vector3[] fourCornersArray);

        public void SetInsetAndSizeFromParentEdge(Edge edge, float inset, float size);
        public void SetSizeWithCurrentAnchors(Axis axis, float size);

        //
        // 摘要:
        //     Enum used to specify one edge of a rectangle.
        public enum Edge
        {
            //
            // 摘要:
            //     The left edge.
            Left = 0,
            //
            // 摘要:
            //     The right edge.
            Right = 1,
            //
            // 摘要:
            //     The top edge.
            Top = 2,
            //
            // 摘要:
            //     The bottom edge.
            Bottom = 3
        }
        //
        // 摘要:
        //     An axis that can be horizontal or vertical.
        public enum Axis
        {
            //
            // 摘要:
            //     Horizontal.
            Horizontal = 0,
            //
            // 摘要:
            //     Vertical.
            Vertical = 1
        }

        //
        // 摘要:
        //     Delegate used for the reapplyDrivenProperties event.
        //
        // 参数:
        //   driven:
        public delegate void ReapplyDrivenProperties(RectTransform driven);
    }
}
