# ========================================================= #
#                     UI za
# ========================================================= #




# ---------------------------------- #
#          CanvasGroup
# ---------------------------------- #
可以用它来整合一堆 ui元素,

设置 CanvasGroup.alpha = 0f 可将这个 group 隐藏;

        -- 让所有子元素 淡入淡出
        -- 让所有子元素 失活 (按钮无法点击)
        -- 让所有子元素 不接收 射线碰撞检测
        -- 可以用本 canvasGroup 的配置参数, 屏蔽所有上层的 canvasGroup 配置参数;


CanvasGroup.BlocksRaycasts:
    勾选后可以在本层接住鼠标点击, 且不让点击射线往下穿透
    反正若不勾选, 则能让本层(及子孙层) 不在遮挡鼠标点击, 允许它往下穿透; (主要需要这个功能)


# ---------------------------------- #
#         如何实现 按钮长按
# ---------------------------------- #

# 大致参考:
https://www.jianshu.com/p/9f0f90acc84f

在 button go 下绑定组件 EventTrigger, 添加 callback: PointerDown, PointerUp, 
分别代表 按下帧 和 弹起帧;

# ------- #
# 还可用 代码来实现上述工作:
    -1- 手动在 button go 下绑定组件 EventTrigger;
    -2- 实现代码:

# -- 通用的绑定函数:
        static void AddEventTriggerListener(    EventTrigger trigger,
                                                EventTriggerType eventType,
                                                System.Action<BaseEventData> callback
        ){
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventType;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
            trigger.triggers.Add(entry);
        }


# -- 绑定 callback
        AddEventTriggerListener( leftTrigger, EventTriggerType.PointerDown, WhenDown);
        AddEventTriggerListener( leftTrigger, EventTriggerType.PointerUp, WhenUp);


# -- callback 本体:
        void WhenDown( BaseEventData eventData_) 
        {
            PointerEventData pointerEventData = (PointerEventData)eventData_;
            GameObject selectedObject = pointerEventData.selectedObject;
            // ---:
            // 处理 selectedObject 这个东西 ...
            // ...
        }

# ------------
# 观察上述代码可知:
    BaseEventData.selectedObject  就是按钮按下时点击的 button gameobject 本身;





# ---------------------------------- #
#   ui 各种坐标:
#    anchoredPosition
#    position
#   如何设置 ui 的 global ui-pos ?????
# ---------------------------------- #

# ui.anchoredPosition 
    这只是一个 local ui-pos, 基于像素值, 
    
    如果 ui 元素位于 canvas 的最顶层, 则屏幕左下角为 (0,0), 右上角为 (Screen.width, Screen.height)

    当 ui元素拥有多个 父节点, 且父节点也发生偏移时, anchoredPosition 就不起效了, 
    毕竟它是 local 的, 无法屏蔽掉 父节点的影响;

# 那么当我们计算出 ui-pos 时, 如何将它设置给一个 拥有复杂父层级的 ui元素呢 ?

# ui.position 
    这是 world-space pos, 
    如果 顶层 canvas 选择默认设置, 则整个 canvas (一个quad) 四个顶点, 左下角: (0,0,0), 右上角 (Screen.width, Screen.height,0)
    ---

    我们完全可以利用这个特性, 先计算出 anchoredPosition, 进而得到 [0f,1f] 映射值,
    然后拿到顶层 canvas 的 quad 的4个顶点的 posWS,
    然后计算出这个 ui 元素的 position

# 现在, 最大的问题是, 我们怎么拿到顶层 canvas 信息 ?


相关讨论:
    https://stackoverflow.com/questions/63481215/unity-get-root-canvas-gameobject-from-its-child


# 已经实现 !!!!! 参见: UI_Utils.cs - GetRootCanvasCornersInfo() 和 CalculateUIGlobalPositionWS()






# ---------------------------------- #
#         如何在 3d 世界中渲染字体
# ---------------------------------- #

# 创建:
hierachy 鼠标右键 - 3D Object → Text - TextMeshPro
    它能不依靠 canvas 直接给你搞个 text 出来;


# 设置:
w/h 设置正常米值
scale 都设1
font size 可以设为 0.23 这种小数, 目前看来效果不错



