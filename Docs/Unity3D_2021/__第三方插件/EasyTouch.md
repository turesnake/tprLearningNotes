# =============================================== #
#              Easy Touch
#              ETC
# =============================================== #


# 参考:
    https://blog.csdn.net/NCZ9_/article/details/103918975




# ----------------------------- #
#     非激活态地 vcamera, 向它输入 input 值是无效的
# ----------------------------- #





# ----------------------------- #
#  左摇杆
#  EasyTouchControlsCanvas
# ----------------------------- #

# 新建:
    Hierarchy 面板右键 - Easy Touch Control - joystick




# ----------------------------- #
#     右屏幕控制 视角转动
# ----------------------------- #

监听:
    EasyTouch.On_DragStart
    EasyTouch.On_Drag 
    EasyTouch.On_DragEnd 
    EasyTouch.On_SwipeStart
    EasyTouch.On_Swipe    
    EasyTouch.On_SwipeEnd  

# On_DragXXX:
    射线触碰到物体, 
    drag是拖动，必须能够选中一个目标，可以是一个点。


# On_SwipeXXX:
    射线没触碰到物体, 穿到天空盒外边去了
    swipe是一个滑动，可以没有目标的滑动。


# 改进:  EasyTouch.instance.alwaysSendSwipe = true;
    由于我们其实只关心 swipe, 不关心 drag
    所以可以开启 alwaysSendSwipe
    然后去掉所有 drag 的监听


# 注意 !!!  ui 层元素会拦截这些事件, 务必把一些 ui canvas 的 Graphic Raycaster 组件禁用掉;



# ----------------------------- #
#  如何实现:
#     玩家触控可以旋转相机视野
#     玩家不触控时, vcamera 自动跟随和旋转视野 
# ----------------------------- #

-1-
    只使用一个 free look vcamera, 模式设置为 world space;

-2-
    先实现 玩家触摸屏幕, 旋转相机视野, 可以借用 easy touch

-3-
    手动写代码实现类似 SimpleFollowWithWorldUp 的自动跟随功能
    在玩家不触控屏幕时接管;





# ----------------------------- #
#   bug:
#      当把 joystick 放到 camera-canvas 下时, 操作响应会异常
# ----------------------------- #

原因和修改:

    在 ETCJoystick.OnDrag() 中, if (isNoOffsetThumb) 分支下, 只实现了 overlay-canvas 这一模式;
    改为:

    if (isNoOffsetThumb)
    {

        /// <summary>
        /// 原插件实现并未考虑过 ScreenSpaceCamera-canvas 这个情况, 皮卡丘 完善了这个缺陷:
        /// </summary>
            
        Vector2 screenPos = Vector2.zero;
        if( cachedRootCanvas.renderMode == RenderMode.ScreenSpaceOverlay )
        { 
            screenPos = (Vector2)cachedRectTransform.position / cachedRootCanvas.rectTransform().localScale.x;
        }
        else if( cachedRootCanvas.renderMode == RenderMode.ScreenSpaceCamera ) 
        {
            screenPos = (Vector2)cachedRootCanvas.worldCamera.WorldToScreenPoint( cachedRectTransform.position );
        }
        thumbPosition = eventData.position - screenPos;
    }

    即可;




# ----------------------------- #
#   如何在 pc 端使用 wsad 键来映射 左摇杆
# ----------------------------- #

开启: Axes properties - Enable Unity axes

如果觉得映射后, 使用 wsad 控制摇杆时, 摇杆移动慢, 可将下方的
    Horizontal axis - General settings - Dead length
    Vertical axis   - General settings - Dead length
    --
这两个值都设置为 0.02




# ----------------------------- #
#   源码是如何在 pc 上模拟 双指的
# ----------------------------- #

    EasyTouchInput.TouchCount()





# ----------------------------- #
#     EasyTouch   各种回调函数
# ----------------------------- #


public enum EvtType{ 


#    None,


#    On_TouchStart,     -- 首帧
#    On_TouchDown,      -- 每一帧
#    On_TouchUp,        -- 尾后帧
    Occurs when a finger touched the screen.
    Occurs as the touch is active.
    Occurs when a finger was lifted from the screen.
    ---
    全局最宽泛的识别器;
    只要有一个手指按下, 这组cb 就一定会被调用       多指触碰时也出触发, 几个手指就调用几次
    --- 
    就算在 drag, swap, SimpleTap, LongTap 时, 本组函数也依然在被触发; 很可靠



#    On_SimpleTap,
    Occurs when a finger was lifted from the screen, 
    and the time elapsed since the beginning of the touch is less than the time required for the detection of a long tap.
    ---
    一次短单击;
    因为它通过时长来判断类型,  所以会在按下弹起的那一帧才会触发 (尾后帧)
    (多指触碰时 效果不明)
    ---
    注意:
        如果本次按下时间足够长, 将被判断为 LongTap, 那么在此按下离开时, 不会触发 On_SimpleTap



#    On_DoubleTap,
    Occurs when the number of taps is egal to 2 in a short time.
    --- 
    当玩家双击屏幕, 
    第二击的 尾后帧,  将触发 On_DoubleTap;



#    On_LongTapStart,   -- 按下后持续一段时间, 直到被判定为 LongTap 的第一帧
#    On_LongTap,        -- On_LongTapStart 后的每一帧
#	 On_LongTapEnd,      -- 尾后帧
    Occurs when a finger is touching the screen,  but hasn't moved  since the time required for the detection of a long tap.
    Occurs as the touch is active after a LongTapStart
    Occurs when a finger was lifted from the screen, and the time elapsed since the beginning of the touch is more than the time required for the detection of a long tap.
    ---
    按下后不松手, 时长超过一定时间后(大概2秒), 本次按下就会被判定为 LongTap,
    此时开始, 会触发 On_LongTapStart
    之后每一帧触发 On_LongTap (可能第一帧也触发了)
    尾后帧触发 On_LongTapEnd




#    On_DragStart,
#    On_Drag,
#    On_DragEnd,
    ---
    射线命中物体时才算 drag, 此处略


#    On_SwipeStart,     -- 首帧
#    On_Swipe,          -- 每一帧
#    On_SwipeEnd,       -- 尾后帧
    ----
    就算手指滑动空屏(射线不命中物体), 也是别为 swip, ( 记得 EasyTouch.instance.alwaysSendSwipe = true; )
    --

    双指时也会触发, 最好用 gesture.touchCount 规避下多指的情况



 
#    On_TouchStart2Fingers,     -- 首帧
#    On_TouchDown2Fingers,      -- 每帧
#    On_TouchUp2Fingers,        -- 尾(后)帧



#    On_SimpleTap2Fingers,



#	On_DoubleTap2Fingers,

    

#    On_LongTapStart2Fingers,
#    On_LongTap2Fingers,
#    On_LongTapEnd2Fingers,
    Like On_LongTapStart but for a 2 fingers gesture.
    Like On_LongTap but for a 2 fingers gesture.
    Like On_LongTapEnd but for a 2 fingers gesture.
    --- 
    双指版的 LongTap




#    On_Twist,         -- 扭动开始后的 每一帧
#    On_TwistEnd,       -- 尾后帧
    Occurs when a twist gesture start
    Occurs as the twist gesture is active.
    --- 
    双指旋转画面
    和下面得 pinch 一样, 记得开启比较的 flag;
    ---
    在 pc 上, 按下 alt, 然后鼠标左键模拟;



#    On_Pinch,          -- 出现任何 pinch 后的每一帧
#    On_PinchIn,        -- 缩小时的 每一帧
#    On_PinchOut,       -- 放大时的 每一帧
#    On_PinchEnd,       -- 好像没触发出来...
    Occurs as the pinch  gesture is active.
    Occurs as the pinch in gesture is active.
    Occurs as the pinch out gesture is active.
    Occurs when the 2 fingers that raise the pinch event , are lifted from the screen.
    ---
    Pinch - 捏, 大概率是 缩放;
    --
    按下 left alt/ctl 然后鼠标左击拖动屏幕,  如果发现没触发本组cb, 可能是 EasyTouch.instance.enable2FingersGesture 被关掉了;
    此时通过:
        EasyTouch.SetEnable2FingersGesture( true ) 来开启 
    




#    On_DragStart2Fingers,
#	On_Drag2Fingers,
#    On_DragEnd2Fingers,


#    On_SwipeStart2Fingers,
#    On_Swipe2Fingers,
#    On_SwipeEnd2Fingers, 



#    On_EasyTouchIsReady,
    Occurs when  easy touch is ready.


#    On_Cancel, 



#    On_Cancel2Fingers,



#    On_OverUIElement, 
    Occurs when current touch is over user interface element.


#    On_UIElementTouchUp

}






