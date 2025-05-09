using Engine.Lib;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Engine.UI
{
    public delegate void PointerEventDelegate(PointerEventData eventData);

    public static class UIEventProxyExtensions
    {
        /// <summary>
        /// 添加一个快捷扩展
        /// </summary>
        /// <param name="gameObj"></param>
        /// <returns></returns>
        public static UIEventProxy AddUIEventProxy(this GameObject gameObj)
        {
            return UIEventProxy.Create(gameObj);
        }
    }


    /// <summary>
    /// 转处理drag的proxy
    /// </summary>
    public class EventDragProxy : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler,
        IEndDragHandler, IDropHandler
    {
        public PointerEventDelegate onPointerDrag;
        public PointerEventDelegate onPointerDrop;
        public PointerEventDelegate onPointerBeginDrag;
        public PointerEventDelegate onPointerEndDrag;

        public PointerEventDelegate onInitializePotentialDrag;

        /// <summary>
        /// 创建代码
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static EventDragProxy Create(GameObject go)
        {
            EventDragProxy proxy = go.EnsureComponent<EventDragProxy>();
            return proxy;
        }


        public void OnDrag(PointerEventData eventData)
        {
            onPointerDrag?.Invoke(eventData);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.clickCount > 1)
            {
                //多点点击时不响应
                return;
            }

            onPointerDrop?.Invoke(eventData);
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            onInitializePotentialDrag?.Invoke(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.clickCount > 1)
            {
                //多点点击时不响应
                return;
            }

            onPointerBeginDrag?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.clickCount > 1)
            {
                //多点点击时不响应
                return;
            }

            onPointerEndDrag?.Invoke(eventData);
        }
    }

    /// <summary>
    /// ui事件的通用代理事件
    /// </summary>
    public class UIEventProxy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        #region 实际的事件处理

        public PointerEventDelegate onPointerClick;
        public PointerEventDelegate onPointerDown;
        public PointerEventDelegate onPointerUp;


        private float _lastClickTime = 0f;


        private void OnDestroy()
        {
            onPointerClick = null;
            onPointerDown = onPointerUp = null;
        }

        /// <summary>
        /// 防止多次点击的方法
        /// </summary>
        /// <returns></returns>
        public bool PreventMultiClick()
        {
            if (Time.realtimeSinceStartup - _lastClickTime >= 0.3f)
            {
                _lastClickTime = Time.realtimeSinceStartup;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 创建代码
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static UIEventProxy Create(GameObject go)
        {
            UIEventProxy proxy = go.GetComponent<UIEventProxy>();
            if (proxy == null) proxy = go.AddComponent<UIEventProxy>();
            return proxy;
        }

        #region 继承的方法以代理方法

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDown?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUp?.Invoke(eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (onPointerClick != null && !eventData.dragging)
            {
                if (Input.touchCount > 1)
                {
                    //多点点击时不响应
                    return;
                }

                onPointerClick(eventData);
            }
        }

        #endregion
    }
}