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












