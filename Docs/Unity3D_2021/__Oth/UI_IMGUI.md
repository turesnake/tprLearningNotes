# =============================================================== #
#                       IMGUI
# =============================================================== #

一套独立于 unity ui 的 game窗口内的 ui 系统

https://docs.unity3d.com/2021.3/Documentation/Manual/GUIScriptingGuide.html


# 组件:
https://docs.unity3d.com/2021.3/Documentation/Manual/gui-Controls.html


# 用法:
    创建一个常规 c# mono 脚本, 实现一个函数 OnGUI(),  在里面实现 imgui 绘制功能; 





# ------------------------------------ #
#          Debug 方法
# ------------------------------------ #

可以在 EventSystem.RaycastAll()  里面断点, 看看有没有响应 我们触发的事件

# todo 待学习



# ------------------------------------ #
#       绘制一个 区域
# ------------------------------------ #

GUI.Box(new Rect(50,50,500,800), "Loader Menu");



# ------------------------------------ #
#        按钮  (单击 / 持续)
# ------------------------------------ #

#   设置 按钮 文本大小
    GUIStyle buttonStyle = new GUIStyle( GUI.skin.button );               // copy
    GUIStyle buttonStyle = new GUIStyle( GUI.skin.GetStyle ("button"));   // copy
    buttonStyle.fontSize = 30;

    if(GUI.Button(new Rect(100,100,200,100), "Level 1", buttonStyle ))
    {
        ...
    }
    ----

    通过此方法可以给不同的 button 配置不同的 ui 样式;


# 这个按钮貌似不支持 长按;   它等于 GetKeyUp(),  仅在释放的一帧被触发;


# GUI.RepeatButton()  在按下后每帧都触发;
    if (GUI.RepeatButton (new Rect (100,200,200,90), "RepeatButton")) 
    {
        print("-koko-");
    }

# ------------------------------------ #
#      在 按钮(等元件) 里显示图片
# ------------------------------------ #

    public Texture2D icon;
    if (GUI.Button (new Rect (10,10, 100, 50), icon)) 
    {
        print ("you clicked the icon");
    }
    ---

    通过 icon 变量来实现 图片显示;



# ------------------------------------ #
#       tooltip
# ------------------------------------ #

# --案例--:
    // This line feeds "This is the tooltip" into GUI.tooltip
    GUI.Button (new Rect (10,10,100,20), new GUIContent ("Click me", "This is the tooltip"));
    
    // This line reads and displays the contents of GUI.tooltip
    GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
    ---

    按钮自己名字为 "Click me", 同时设置了一个内容为 "This is the tooltip" 的 tooltip string 变量;
    ---
    当玩家鼠标移动到这个按钮上时,
    下方显示 label 信息: "This is the tooltip"   -- 也就是把这个 tooltip 内容打印出来;


# ------------------------------------ #
#      单行 文本字段 TextField
# ------------------------------------ #
    private string textFieldString = "text field";
    void OnGUI() {
        textFieldString = GUI.TextField (new Rect (100, 200, 300, 300), textFieldString );
    }
    ----
    用户可在这个框里写文本,  改写的文本写入变量 textFieldString, 可被其他代码访问;

# TextField 只支持单行


# ------------------------------------ #
#      多行 文本区 TextArea 
# ------------------------------------ #
    private string textFieldString = "text field";
    void OnGUI() {
        textFieldString = GUI.TextArea (new Rect (100, 200, 300, 300), textFieldString );
    }
    ---
    类似 text 编辑器, 可换行, 可用光标选择 文本位置,  虽然不能上下拖动文本, 但是上下移动光标, 可实现类似的功能;



# ------------------------------------ #
#      单选框  Toggle
# ------------------------------------ #
    private bool toggleBool = true;
    void OnGUI() {
        toggleBool = GUI.Toggle (new Rect (100, 200, 100, 40), toggleBool, "Toggle", buttonStyle_Sml );
    }


# ------------------------------------ #
#     单行的 多选题  Toolbar
# ------------------------------------ #

一排按钮, 单一时间里只有一个按钮 高亮,  表示当前状态;

https://docs.unity3d.com/2021.3/Documentation/Manual/gui-Controls.html


# ------------------------------------ #
#     多行的 多选题  SelectionGrid
# ------------------------------------ #

Toolbar 的多行版



# ------------------------------------ #
#    水平 滑杆  HorizontalSlider
#    垂直 滑杆  VerticalSlider
# ------------------------------------ #




# ------------------------------------ #
#   滑动区:   ScrollView
#   控制滑动区的 水平滑杆    HorizontalScrollbar
#   控制滑动区的 垂直滑杆    VerticalScrollbar
# ------------------------------------ #



# ------------------------------------ #
#     Window
# ------------------------------------ #
暂时没搞懂它的用法...


# ------------------------------------ #
#     GUI.changed
# ------------------------------------ #

类似于 dirty flag, 可用来精简待机时的 运算负担;

但是这个不会减少 imgui 每帧的绘制负担;



# ------------------------------------ #
#    ui 风格: GUIStyle
# ------------------------------------ #

    GUIStyle buttonStyle_Mid = GUI.skin.GetStyle ("label");                // 直接拿了系统的对象
    GUIStyle buttonStyle_Mid = new GUIStyle(GUI.skin.GetStyle ("label"));  // copy
    buttonStyle_Mid.fontSize = 35;
    ---

# GUI.skin.GetStyle();
    可选参数 [string]:  
        box
        button
        toggle
        label
        window
        textfield
        textarea
        horizontalslider
        horizontalsliderthumb
        verticalslider
        verticalsliderthumb
        horizontalscrollbar
        horizontalscrollbarthumb
        horizontalscrollbarleftbutton
        horizontalscrollbarrightbutton
        verticalscrollbar
        verticalscrollbarthumb
        verticalscrollbarupbutton
        verticalscrollbardownbutton
        scrollview



# ------------------------------------ #
#   IMGUI Layout Modes
# ------------------------------------ #

# GUI           静态 layout 
# GUILayout     动态 layout

https://docs.unity3d.com/2021.3/Documentation/Manual/gui-Layout.html



# ========== 静态 layout ===========:
    // Make a group on the center of the screen
    GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
    // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

        // We'll make a box so you can see where the group is on-screen.
        GUI.Box (new Rect (0,0,700,100), "Group is here", buttonStyle_Sml);
        GUI.Button (new Rect (10,10,680,80), "Click me", buttonStyle_Sml);

    // End the group we started above. This is very important to remember!
    GUI.EndGroup ();
    ----------
    被包在上述 GUI.BeginGroup, GUI.EndGroup 内的元素,  不会超出 group 约束的范围, 超出的不被绘制;
    然后在里面的元素, 直接从 lt:0,0  开始计算坐标, 算是变简单了

# BeginGroup 组 是可以层层嵌套的;




# ------------------------------------ #
#   固定的一组 ui 元素 列表
#     GridLayoutGroup
# ------------------------------------ #

只要准备一个 root 节点, 绑定 GridLayoutGroup 组件, 配置好参数;
然后运行时往这个节点下面塞 node, 这些 node 就能被自动排列






