#region 程序集 UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UI.dll
#endregion

using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
    public class PointerEventData : BaseEventData
    {
        public List<GameObject> hovered;

        public PointerEventData(EventSystem eventSystem);

        public bool useDragThreshold { get; set; }
        public bool dragging { get; set; }
        public InputButton button { get; set; }
        public float pressure { get; set; }
        public float tangentialPressure { get; set; }
        public float altitudeAngle { get; set; }
        public float azimuthAngle { get; set; }
        public float twist { get; set; }
        public Vector2 radius { get; set; }
        public Vector2 radiusVariance { get; set; }
        public bool fullyExited { get; set; }
        public bool reentered { get; set; }
        public Camera enterEventCamera { get; }
        public Camera pressEventCamera { get; }
        public GameObject pointerPress { get; set; }
        public Vector2 scrollDelta { get; set; }
        public int clickCount { get; set; }
        public float clickTime { get; set; }
        [Obsolete("Use either pointerCurrentRaycast.worldNormal or pointerPressRaycast.worldNormal")]
        public Vector3 worldNormal { get; set; }
        public GameObject pointerEnter { get; set; }
        public GameObject lastPress { get; }
        public GameObject rawPointerPress { get; set; }
        public GameObject pointerDrag { get; set; }
        public RaycastResult pointerCurrentRaycast { get; set; }
        public RaycastResult pointerPressRaycast { get; set; }
        public GameObject pointerClick { get; set; }
        public int pointerId { get; set; }
        public Vector2 position { get; set; }
        public Vector2 delta { get; set; }
        public Vector2 pressPosition { get; set; }
        [Obsolete("Use either pointerCurrentRaycast.worldPosition or pointerPressRaycast.worldPosition")]
        public Vector3 worldPosition { get; set; }
        public bool eligibleForClick { get; set; }

        public bool IsPointerMoving();
        public bool IsScrolling();
        public override string ToString();

        public enum InputButton
        {
            Left = 0,
            Right = 1,
            Middle = 2
        }
        public enum FramePressState
        {
            Pressed = 0,
            Released = 1,
            PressedAndReleased = 2,
            NotChanged = 3
        }
    }
}