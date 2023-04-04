# ================================================================ #
#                      MonoBehaviour
# ================================================================ #



# 快速版:

# --- 进入场景, go 被初始化, 调用: 
    Awake()     -- 只要 go 是 active 的, 就会被调用, 哪怕本组件是被禁用的, 但是若 go 一开始就是 disactive 的, 则不会被调用
    OnEnable()  -- 只有 go 和 组件都 active 了, 才会被调用
    Start()     -- 只有 go 和 组件都 active 了, 才会被调用

# --- 如果 禁用复用 component/go, 调用: 
    OnEnable()
    OnDisable()


# --- 如果删除 component/go, 调用: 
    OnDisable()   -- 若组件已经 disactive 了, 则此函数不会被调用
    OnDestroy()

# --- 若加载新场景, 当前场景变成 非 active 的, 则
    啥也不调用

# --- 若本场景再次变为 active 的, 则
    啥也不调用




# ---------------------------------------------- #
#             Awake()
# ---------------------------------------------- #
类似于 constructor 构造函数
会在本类的 成员 被新建完毕后,调用;

# 注意 (tpr):
    当场景中的 gameobj 第一次从 disable -> enable 时, Awake() 才会被调用, 且只调用一次; 
        (直接加载一个 enable 的 go 时也会立刻调用 Awake())

# -2-:
    Awake() 不受 脚本的 enable/disable 的影响;
    也就是说:
        就算一个 go 的 c#脚本始终是 disable 的, 只要在场景中实例化一个 go, 它的所有脚本的 Awake() 就都会被执行;

    这算是 Awake() 和 Start() 的最大区别了: 只有当 go 和 脚本组件 都 enable 了, Start() 才会被调用...
    


# ---------------------------------------------- #
#             OnEnable()
# ---------------------------------------------- #
-1-
在 play mode 中, 当一次 "重编译" 发生时, 首先, 所有 active 的组件全部被 disabled, 
此时会调用 OnDisable(), 
然后存储 game state, 执行编译, 然后恢复 game state, 
然后把之前为 active 的 组件全部恢复为 active,

-2-
当一个组件执行了自己的 MonoBehaviour.Awake(); 之后, 也会立即执行 OnEnable();
除非这个组件被存储为 disabled 状态, 


本组件每次在 editor 中热更新后 (也包括 刚启动的 Awake() 时),
进入 enable 状态的一瞬间, 会调用此函数
    ---
    注意, 上文的 "editor" 指的应该是 play 模式... 反正如果你不启动 play, 本组函数是不会被调用的; 


# 注意 (tpr):
    需要和 OnDisable() 配套使用;

# 在游戏运行时:
    if( "组件所在go_变成_active" && "组件自己变成_enalbe" ) 
    {
        OnEnable();
    }

    但反过来:

    if( "组件所在go_变成_disactive" || "组件自己变成_not_enalbe" ) 
    {
        OnDisable();
    }




# ---------------------------------------------- #
#             Reset()
# ---------------------------------------------- #



# ---------------------------------------------- #
#             Start()
# ---------------------------------------------- #
只有在 本组件的 Update 函数被 第一次调用之前, Start 函数才会被调用
(无论这个 组件是否有 update 函数)
如果一个 组件在运行时的某一时刻被新建, 它的第一个 update 会在下一帧被调用. 

# 注意:
当在一个场景中反复 disable - enable 一个 组件/go 时, 它的 Start() 不会被多次调用;
它只会在第一次执行 update() 时调用一次....

所以 Start() 和 OnEnable() 还是存在很大区别的....


# ---------------------------------------------- #
#             FixedUpdate()
# ---------------------------------------------- #

不要在很多个 物体的脚本上, 分别地单独调用 FixedUpdate(), 每一次调用此函数, 
都存在一些额外开销, 此时可优化成单次 FixedUpdate() 调用; 


# ---------------------------------------------- #
#             OnTriggerXXX()
#             OnCollisionXXX()
# ---------------------------------------------- #


# ---------------------------------------------- #
#             yield WaitForFixedUpdate;
# ---------------------------------------------- #



# ---------------------------------------------- #
#             OnMouseXXX
# ---------------------------------------------- #


# ---------------------------------------------- #
#             Update()
# ---------------------------------------------- #


# ---------------------------------------------- #
#           yield null;
#           yield WaitForSeconds;
#           yield WWW;
#           yield StartCoroutine;
# ---------------------------------------------- #



# ---------------------------------------------- #
#           LateUpdate()
# ---------------------------------------------- #


# ---------------------------------------------- #
#           OnPreCall()
#           OnWillRenderObject()
#           OnBecameVisible()
#           OnBecameInvisible()
#           OnPreRender()
#           OnRenderObject()
#           OnPostRender()
#           OnRenderImage()
# ---------------------------------------------- #
另一个文件中有描述

# ---------------------------------------------- #
#           OnDrawGizmos()
# ---------------------------------------------- #
另一个文件中有描述

# ---------------------------------------------- #
#           OnGUI()
# ---------------------------------------------- #
另一个文件中有描述

# ---------------------------------------------- #
#           yield WaitForEndOfFrame;
# ---------------------------------------------- #

# ---------------------------------------------- #
#           OnApplicationFocus( bool hasFocus )
# ---------------------------------------------- #

当 app 获得 focus, 或得到 focus 时, 本函数会被调用;

# 参数 hasFocus:
    得到 focus 时参数为 true, 丢失 focus 时参数为 false;

此函数存在协程版, 此时本函数会在 init 帧被执行两次, 
第一次是作为一个 early notification;
第二次则位于 the normal co-routine update step.

# 在安卓
when the on-screen keyboard(猜测是屏幕上的虚拟键盘) is enabled, 会调用一次 OnApplicationFocus( false );
当在 keyboard 为 enabled 时 如果你按下 home 键, 此时不会调用 OnApplicationFocus(), 而会调用 OnApplicationPause();

# 注意:
当 editor 处于 play 模式时, Game 窗口每次获得/丢失 focus, 都会调用本函数;
如果一个 unity 之外的 app 获得了 focus, and you click a different Editor tab,(然后你点击了 unity 中的另一个 tab)
那么在这一帧, OnApplicationFocus() 会被调用两次;
    第一次: 参数为 true, 因为此时 unity 再次获得 focus
    第二次, 参数为 false, 因为此时 Game 窗口失去了 focus;


为了减少  OnApplicationFocus() 被调用的次数, 可使用 unity 推荐的脚本来:
    public class AppPaused : MonoBehaviour
    {
        bool isPaused = false;

        void OnGUI()
        {
            if (isPaused)
                GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
        }

        void OnApplicationFocus(bool hasFocus)
        {
            isPaused = !hasFocus;
        }

        void OnApplicationPause(bool pauseStatus)
        {
            isPaused = pauseStatus;
        }
    }
    ----------
    跟踪此脚本的 isPaused, 当丢失 focus 时, 它将为 false;





# ---------------------------------------------- #
#           OnApplicationPause( bool pauseStatus )
# ---------------------------------------------- #
当 app 暂停, 或从暂定中恢复时 被调用;

所谓 "暂停" 其实就是 一个窗口态的 app 突然被别的 app 覆盖了(部分或全部)
此时有点类似丢失 focus, 但是好像不完全一样; (个人猜测)



# 参数 pauseStatus:
    表示 app 是否处于 暂停 状态;
    当 app 开始进入 暂停状态, 此次调用的参数为 true, 表示进入 暂停;
    当 app 从暂停中恢复, 此次调用的参数为 false, 表示 "不再暂停";

# 在 player settings 的 resolution presentation 面板中, 可选择关闭 
    "Run in Background" 和
    "Visible in Background"

本函数可在非 editor 平台的 独立状态游戏中被使用; 此时, app不能是全屏, 需要是窗口模式;
当这个 app 窗口被部分/全部隐藏,(被另一个app), 此时 本函数就会被调用, 且参数为 true;
当再次关注这个 app 窗口(它开始位于桌面的最顶层), 本函数会被调用, 且参数为 false;

此函数存在协程版, 此时本函数会在 init 帧被执行两次, 
第一次是作为一个 early notification;
第二次则位于 the normal co-routine update step.

# 在安卓
when the on-screen keyboard(猜测是屏幕上的虚拟键盘) is enabled, 会调用一次 OnApplicationFocus( false );
当在 keyboard 为 enabled 时 如果你按下 home 键, 此时不会调用 OnApplicationFocus(), 而会调用 OnApplicationPause();

# 注意, 在一个 go 开始运行时, 它的脚本的 OnApplicationPause() 会被调用一次, 
此时参数为 false; (毕竟此时不在 pause 状态)
这次调用要晚于 Awake(); 



# ---------------------------------------------- #
#           OnApplicationQuit()
# ---------------------------------------------- #
在 app 结束之时调用;
在 editor 模式中, 在 play 模式将要结束时, 此函数被调用;

# ios:
ios 平台通常只会让 app "suspended"(挂起), 而不是 "quit" (终止);
可以在为 ios 打包时, 在 player settings 中勾选 "Exit on Suspend"; 此时 app 就会真的 quit, 而不是 suspended; 
如果你不打算勾选 "Exit on Suspend", 可以改用 "OnApplicationPause()";

# window store app / win phone 8:
那里不存在 app quit event; 请在 focusStatus 等于 false 时使用 OnApplicationFocus 事件;

# webGL:
由于 浏览器标签页关闭的方式, 没办法实现 OnApplicationQuit();
替换方法建议阅读:
https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html

# 注意:
如果用户在 移动平台 suspended(挂起) 你的 app, 操作系统可能会为了节省资源而将 app quit 掉;
有些操作系统中, 可能不会调用此函数;

在移动平台上, 为了稳定性 最好不要依赖这个函数;
作为代替品, 改用 MonoBehaviour.OnApplicationFocus(), 它会在 app 每次丢失 focus 时被调用;
选择此时去存储数据;





# ---------------------------------------------- #
#           OnDisable()
# ---------------------------------------------- #
被正式销毁时, 也包含每次 editor 热更新时的 重置

当 behaviour 类实例 被设置为 disabled 时, 此函数被调用.
当 obj 被销毁时, 此函数也被调用.

and can be used for any cleanup code. 
When scripts are reloaded after compilation has finished, OnDisable will be called, 
followed by an OnEnable after the script has been loaded.


# 在游戏运行时:
    if( "组件所在go_变成_active" && "组件自己变成_enalbe" ) 
    {
        OnEnable();
    }

    但反过来:

    if( "组件所在go_变成_disactive" || "组件自己变成_not_enalbe" ) 
    {
        OnDisable();
    }
    


# ----------------------------------------------#
#               OnValidate()
# ----------------------------------------------#
    此函数的位置 不明...

    只在 editor 模式中有意义的函数, 当一个 脚本被 loaded, 或当一个变量在 inspector 中被修改时,
	此函数被调用.

	所以, 这个函数的内容, 可围绕那个刚在 inspector 中被修改的 变量展开, 比如, 修正它的范围.

	注意:
		不应在此函数中做别的事情,比如:
		新建obj, 调用其它 非线程安全的 unity api. 
		---
		因为 此函数可能不会在 main thread 中被调用, 而是在类似于 loading thread 中.

		不该在此处 执行 camera rendering 操作. 而是应该 add a listener to EditorApplication.update; 
		and perform the rendering during the next Editor Update call.


#    不要在 Awake Start 等运行时函数中调用此函数;
    打包的时候 会报错;


# ----------------------------------------------#
#            OnDestroy()
# ----------------------------------------------#
在一帧的末尾被调用;


一个 激活态的 go, 它的脚本里实现了 OnDestroy();

在运行时的以下场合, OnDestroy() 会被调用:
# -1-
    当这个 脚本组件被销毁时
# -2-
    当这个 激活态的 go 被销毁时
# -3-
    当这个 scene 被结束时
    (此时往往意味着, 一个新的 scene 将要被加载)
# -4-
    editor 阶段, 当从 play mode 退出时
    builded 阶段, 当关闭 app 时

观察以上行为可发现, OnDestroy() 被触发的根本原因是因为 它的 MonoBehaviour 实例被销毁了.

注意:
    如果 go 在运行之前就已经是 激活态的, 那么在运行时, 不管是否把 go 和 脚本 disactive, 只要 monobehaviour 组件被销毁, OnDestroy() 都会被触发
    ---
    反之, 若在运行时之前, go 就是 disable 态的, 那么在运行时, 不管算出 go 还是 脚本组件, 都不会触发这个 OnDestroy()


# ================================================================== #
# 以下是 未出现在 固定流程图中的 callbacks

# ---------------------------------------------- #
#               OnDrawGizmos()
#               OnDrawGizmosSelected()
# ---------------------------------------------- #
绘制 Gizmos 时, unity 自动调用.

即便在 editor 模式中, (非 play 模式), OnDrawGizmos() 也会被调用
所以需要注意此函数中存在的变量, 已经提前配置好了, 而不是那种直到 Awake()
才被配置的数据; 

# 实践表明, 只有当我们去改动 scene 窗口时 (比如改动观察 scene 窗口的方式), 
    此时 unity 才会去重渲染 scene 窗口
    此时才会调用 OnDrawGizmos() 函数 (另一个函数可能也是如此)




























