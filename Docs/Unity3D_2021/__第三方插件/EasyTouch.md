# =============================================== #
#              Easy Touch
# =============================================== #


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


# 




















