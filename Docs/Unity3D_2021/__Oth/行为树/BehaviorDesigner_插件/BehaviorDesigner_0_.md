


# 官方文档:
https://opsive.com/support/documentation/behavior-designer/overview/



# ------------------------------------------ #
#         behaviour tree 执行:
# ------------------------------------------ #

https://opsive.com/support/documentation/behavior-designer/behavior-tree-component/




# ------------------------------------------ #
#         BehaviorTree  开启关闭:
# ------------------------------------------ #

BehaviorTree(继承自Behavior)提供了明确的开关API:

**核心方法：**

- `EnableBehavior()` — 启用/恢复整个行为树的Tick
- `DisableBehavior()` — 禁用整个行为树，停止Tick，所有节点会被重置(不是暂停在当前状态,而是复位)
- `StartBehavior()` / `StopBehavior()` — 也存在，语义上更像"开始一轮执行/主动结束当前执行"，效果和上面类似,内部也是走 enabled 开关这条路

**Inspector 层面：**

- Behavior Tree 组件本身有一个 `enabled` checkbox(因为它是 MonoBehaviour),直接勾掉等价于 DisableBehavior
- 也可以直接 `behaviorTree.enabled = false;` 达到同样效果

**几个你需要注意的细节：**

1. Disable 后再 Enable，行为树是**从 Entry 重新开始**跑,不会记得上次跑到哪个节点、Running 状态也不会保留。如果你需要"暂停/恢复到原来的位置"，这个组件本身不直接提供，需要你自己在外面存状态。

2. 如果树里有 Task 正处于 Running(比如你的 SitOnGround 协程还没退出)，Disable 时插件会调用该 Task 的 `OnEnd()`，但**不会**自动帮你停掉你在 Task 内部另开的协程/StepFlow。也就是说,如果 SitOnGround 是靠 `StartCoroutine` 在 GhostWorldRunner 里跑的,你需要自己在 Task 的 `OnEnd()` 里显式做清理(比如调用 stepflow 的 `RequestExit()`),否则会出现"树已经关了,但协程还在跑"的野对象问题。这是实际项目里最容易踩的坑。

3. 想要"完全销毁并重建整棵树"用 `DestroyBehavior()`; 只是想临时挂起用 `DisableBehavior()` 就够了。

要不要我给你说下 Task 里 `OnStart()` / `OnUpdate()` / `OnEnd()` 这几个生命周期方法具体啥时候被引擎调用？这个对你后面写自定义 Action 节点(比如 SitOnGround、CheckIsNeedSitGoOn)很关键。



# ------------------------------------------ #
#         Tasl  生命周期:
# ------------------------------------------ #
每个 Task 的生命周期由框架的 Tick 机制驱动，核心是下面几个方法：

**调用顺序与时机**

1. **`OnStart()`** — 每次这个节点**从"非Running"状态被重新进入**时调用一次。也就是说：父节点决定要执行这个子节点了(第一次执行，或者上次已经返回 Success/Failure 后再被重新选中)，就会先调一次 `OnStart()`，用来做初始化(比如缓存组件引用、记录起始时间、启动一个子协程)。

2. **`OnUpdate()`** — 每个 Tick(默认每帧，除非你设置了 Behavior 的 Tick 间隔)都会调用，直到你返回 `TaskStatus.Success` 或 `TaskStatus.Failure`。只要你返回 `TaskStatus.Running`，下一帧还会继续调 `OnUpdate()`，`OnStart()` 不会重复调用。

3. **`OnEnd()`** — 当这个节点**结束当前这一轮执行**时调用，触发时机有两种：
   - 正常结束：`OnUpdate()` 自己返回了 Success/Failure
   - 被外部打断：父节点(比如 Composite 的 abort、Parallel 的其他分支达成 Success Policy、或者整棵树被 Disable)强制中止了它

   `OnEnd()` 是你做清理工作的地方——取消订阅事件、Stop 掉自己开的协程、复位临时状态。**这是你的 SitOnGround 节点最关键的一环**：一旦 `OnEnd()` 被调用，就说明这个节点被判定为"结束了"，不管是自然结束还是被打断，你都必须在这里把底层的 StepFlow 协程一并终止掉，否则会出现"树认为节点已经退出，但协程还在跑"的不一致。

**一个容易踩的坑**

`OnStart()` **不是**在节点第一次被创建时调用一次，而是每次"重新进入 Running 序列"都会调。举例：如果 SitOnGround 被 Parallel 打断后 `OnEnd()`，之后行为树重新走到这个分支，会**再次**调用 `OnStart()`（不是继续上次状态）。所以你不能在 `OnStart()` 里做那种"只想执行一次的全局初始化"，也不能假设 `OnUpdate()` 里的局部变量在两次 `OnStart()` 之间会被保留（Task 实例本身一般是复用的，字段值会保留，但语义上你不该依赖这点，应该在 `OnStart()` 里显式重置该重置的状态）。

**还有两个不那么常用但你可能会用到的**

- `OnBehaviorComplete()` — 整棵树跑完(根节点返回结果)时，所有节点都会收到这个回调，用于一些统计/日志类节点。
- `OnConditionalAbort()` — 专门给 Conditional 节点用的，当它是被标记为"参与 abort 检测"的节点时，框架轮询它调用的入口跟普通 Tick 略有不同（不是走 Sequence 里正常排队执行，而是被单独 poll，检测 Success/Failure 变化）。

**落到你的 SitOnGround / CheckIsNeedSitGoOn 设计上：**

- `SitOnGround.OnStart()`：调用 stepflow 的启动逻辑（进入坐下动画过渡）。
- `SitOnGround.OnUpdate()`：检查 stepflow 内部的收尾标志位，没收尾就返回 Running；如果 stepflow 自己已经流转完"离开动画过渡"，才返回 Success。
- `SitOnGround.OnEnd()`：无论是正常结束还是被 Parallel 提前打断，都调用 stepflow 的 `RequestExit()`/强制清理，保证协程一定被收干净。
- `CheckIsNeedSitGoOn.OnUpdate()`：用 `Time.deltaTime` 自己攒计时器，攒够1秒做一次全局检查，不满足条件时**必须返回 Running**（否则 Parallel 会以为它结束了），满足条件才返回 Success 并广播事件。






# ------------------------------------------ #
#            共享变量: static
#        SharedTransform target;
# ------------------------------------------ # 
有很多 shared 变量类型, 暂以 SharedTransform 为例:

# 先是默认的 静态变量, 它们预先设置在 btree 中, 所有 btree 实例都能访问到:

# -1-:
btree 编辑器里, Variables 中新建变量 target;

# -2-:
每个 自定义脚本里设置 
    public SharedTransform target;

# -3-:
在编辑器里对应节点 inspector 中, 
target 右侧点原点,去掉自动绑定
点击框右侧的 向下小箭头, 选择 target

# -4-:
运行程序

# -5-:
可以访问 共享的元素本体:
Transform transformValue = target.Value;


# 在没有继承于 Task 的普通脚本中, 如何访问这些变量:
https://opsive.com/support/documentation/behavior-designer/variables/accessing-variables-from-non-task-objects/


# 可以自定义 共享变量 的类型:
https://opsive.com/support/documentation/behavior-designer/variables/creating-shared-variables/



# ------------------------------------------ #
#         共享变量: Dynamic Variables
# ------------------------------------------ #
https://opsive.com/support/documentation/behavior-designer/variables/dynamic-variables/
# ---- Dynamic Variables:
普通变量（Static Variables）是写死在行为树中的，所有使用同一个行为树的实例共享这组变量。
动态变量允许你在运行时给每个行为树实例单独赋值，不影响其他实例。


可以问下 ai 具体用法; 有点类似 material 中访问 shader 中的各个变量


# set:
behaviorTree.SetVariableValue( "tgt", possibleTargets[i] );

设置端好像无效将这个变量暴露到 节点 inspector 上

# get:
public SharedTransform tgt;
tgt = behaviorTree.GetVariable("tgt") as SharedTransform;
---
还要在这个 task 的 inspector 上, 将暴露的 tgt 设置为 dynamic; 然后在填空处写入 "tgt"
(虽然最后一步有点奇怪...)




# ------------------------------------ #
#    自定义 action 脚本中, 如何访问 BehaviorTree 实例
# ------------------------------------ #

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MyCustomAction : Action
{
    private BehaviorTree behaviorTree;

    public override void OnStart()
    {
        // Owner 属性就是挂载Behavior Tree组件对应的GameObject上的BehaviorTree组件实例
        behaviorTree = Owner as BehaviorTree;

        if (behaviorTree != null)
        {
            // 你现在可以通过 behaviorTree 访问它的变量或其他属性了
        }
    }
}






# ------------------------------------------ #
#       装饰器: Decorator
# ------------------------------------------ #

# == Conditional Evaluater:
内涵 比较器 和 task, 
若 比较器 ret true, 执行 task, 返回 task
若 比较器 ret false, 则 task 不被run, 直接返回 false

# == Cooldown:
先执行 子task, 然后等待一段时间, 然后再返回 子task 的返回值 (t/f)

# == Interrupt:
可以中断 子task 的running

# == Inverter:
先执行 子task, 拿到返回值 (t/f) 后翻转下再ret;

# == Repeater:
将 子task 执行若干次;
开启某个设置后, 就算 子task 返回f, 它也会循环下去;

# == Return Failure:
除非 子task 正在 running, 否则一定ret f;

# == Return Success:
类似上面

# == Task Guard:
类似多线程程序中的 semaphore(信号棋), 用来确保一个受限的资源 不被过度使用;
举例:
给一个正在播放动画的 task 套上本task, 在同一个 btree 的别的节点上, 在同样的人物骨骼上播放别的动画; (此时就出现资源争夺了)
Task Guard 可以指定在同一时间上这个 子task 可以被多少个对象同时运行;

# == Until Failure / Success:
不停执行自己的 子task, 直到它返回 f/t;



# ------------------------------------------ #
#         各种 Task
# ------------------------------------------ #

# -------------------- 
# === Selector:
Selector(选择节点)相当于行为树中的"或"运算。它从左到右依次执行子节点,
一旦某个子节点返回 Success 就立即返回 Success;
某个子节点失败时则继续尝试下一个。

只有当所有子节点都失败后,才返回 Failure。

子节点的排列顺序应该从最理想、最具体的行为,排到最保底、最可靠的兜底行为。
如果某个子节点处于 Running 状态, Selector 就不会去尝试它右边的任何子节点,直到该子节点结束或被打断为止。


# -------------------- 
# === Sequence:
Sequence(序列节点)相当于行为树中的"与"运算。它从左到右依次执行子节点,
某个子节点返回 Success 后继续执行下一个,
一旦某个子节点失败就立即返回 Failure。

只有当所有子节点都成功后,才返回 Success。

Sequence 适合用来表达有先后顺序的前提条件和具体动作,
比如 "能看到敌人吗?" 后面接 "追击敌人"。

把条件节点(Conditional)放在前面,这样当该分支的前提不满足时,能在对应的动作(Action)开始执行之前就先失败退出。


# Abort Type 为 None 时, 
    行为符合上述描述,
但如果设为别的值, 比如 Lower Priority, Sequence 将不再无限等到某个 子task 的完成



# -------------------- 
# == Parallel:
Parallel(并行节点) 会在同一次遍历中 同时启动所有子节点,而不是等一个子节点完成后再启动下一个。

当所有子节点都成功时, 它返回成功(Success)。

如果有任意一个子节点失败, Parallel 就返回失败(Failure), 并停止其余尚未完成的子节点。


# 参数 instant:
"Instant"这个选项控制的是 Parallel 在**同一帧内**驱动子节点的方式。

勾选(默认开启)时,Parallel 在一帧里会尽可能"一次性"把所有子节点都 tick 完并立刻根据成功/失败策略判断整体状态——
也就是说,如果第一个子节点这一帧就返回了 Success 并且触发了你设置的成功策略(比如"任一成功即整体成功"),
Parallel 会在**同一帧**内立刻结束,其余还没被 tick 到的子节点根本不会被执行到,直接连 `OnStart` 都不会调用,更不会进入 Running 状态。

不勾选时,Parallel 会更"温和"地展开:每个子节点该走的生命周期(`OnStart`→至少一次`OnUpdate`)都会正常跑一遍,即使前面的子节点已经满足了退出策略,
后面的子节点这一帧也会先被启动起来,策略判断放到下一帧统一收口,不会出现"某个子节点连开始都没开始就被跳过"的情况。




# -------------------- 
# === Parallel Selector:
Parallel Selector(并行选择节点)会同时启动所有子节点,
一旦有某个子节点成功就立即返回 Success;

只有当所有子节点都失败时才返回 Failure。

当该复合节点结束时,其余仍处于 Running 状态的子节点会被停止。


这使它适合用来做"竞速"场景:
比如让一个耗时较长的操作和一个计时器并行运行,
或者让移动和完成条件判断并行运行。

需要确认的是,停止那个"落败"的分支是安全的, 并且它的 OnEnd 中要正确释放动画、导航或事件订阅等状态。


# -------------------- 
# === Priority Selector:
Priority Selector(优先级选择节点)会向每个子节点查询它的 GetPriority() 值,据此排序, 
然后按这个顺序应用 Selector 的行为逻辑。优先级最高且满足条件的分支会被最先尝试。


当分支的执行顺序需要在该复合节点开始运行时动态计算,而不是固定按水平排列位置决定时,适合使用它。
优先级数值应当保持可比较、便于查看。
如果数值变化需要能够打断一个正在运行的分支并重新导向,那么应该改用固定优先级顺序的 Selector Evaluator,
或者带条件中止(Conditional Aborts)的 Selector。



# -------------------- 
# === Utility Selector:
Utility Selector(效用选择节点)会运行当前可用子节点中 GetUtility() 值最高的那一个。
它每一帧都会重新评估所有可用子节点,一旦有其他子节点的效用值胜出,就会打断当前正在执行的子节点。

当某个子节点失败后,它会重新比较剩余的子节点。和 Selector 一样,只要有子节点成功它就成功,当没有可用子节点时它就失败。

当安全、饥饿、疲劳等这类会不断变化的需求必须放在同一尺度上进行比较时,适合使用它。

要确保每个任务都能被安全地打断。如果排序只需要在启动时计算一次,用 Priority Selector;

如果需要按固定优先级重新考虑,用 Selector Evaluator;

如果是由条件驱动的打断,用带条件中止(Conditional Aborts)的 Selector。

应当把归一化和打分规则放在结构性任务节点之外去实现,这样行为树才能保持清晰易读。



# -------------------- 
# === Selector Evaluator
是专门用来实现 "优先级抢占"(higher-priority interrupt)的复合节点,
它本身不直接管理一堆子节点的执行,而是包裹一个 Selector, 赋予这个 Selector 重新评估的能力。

**基本结构**
SelectorEvaluator
    └── Selector
            ├── ChildA (高优先级)
            ├── ChildB
            └── ChildC (低优先级,当前正在 Running)

SelectorEvaluator 只允许挂一个子节点,且这个子节点必须是 Selector(或 Selector 的派生),Inspector 上会强制要求这个结构。

**行为逻辑**
标准 Selector 的执行逻辑是:一旦某个子节点进入 Running, Selector 会记住当前索引,
下一帧直接从这个 Running 的子节点继续 tick,不会回头再检查前面优先级更高的子节点是否已经满足条件。
这在很多场景下是个问题,比如你希望"如果敌人靠近应该立刻打断当前的巡逻行为,切换到攻击",但普通 Selector 不会主动回头检查。


SelectorEvaluator 解决的正是这个问题。每一帧它会先重新执行 Selector 里排在当前 Running 节点之前的那些子节点(不含当前 Running 节点本身),检查它们是否有一个能返回 Success 或者进入 Running。

如果某个更高优先级的子节点这一帧满足条件了,SelectorEvaluator 会强制打断当前正在 Running 的低优先级子节点,给它正式调用 OnEnd,然后切换执行到这个更高优先级的子节点上。

如果前面所有更高优先级的子节点都还是 Failure,那就继续保持当前正在 Running 的子节点不变,行为和普通 Selector 一样往下 tick。

**典型用途**
最常见的用法就是你说的"高优先级打断"场景,比如:
SelectorEvaluator
    └── Selector
            ├── IsHealthLow -> Flee   (生命值低时逃跑,优先级最高)
            ├── EnemyVisible -> Attack (发现敌人则攻击)
            └── Patrol                (默认巡逻,通常处于Running)
Patrol 在跑的过程中,如果突然生命值变低,SelectorEvaluator 每帧的重评估机制会让 Flee 分支被检测到并抢占执行权,Patrol 会被正式打断收尾。

**和普通 Selector 的关键区别**
普通 Selector 只在子节点返回非 Running 状态时才会往下换节点,一旦某节点 Running 住了就"赖"在那不会主动回头看。SelectorEvaluator 则是每帧都强制重新评估前置的高优先级节点,本质上是用一定的额外开销(每帧都要重新 tick 前面几个节点)换取"可被随时打断"的能力。

**性能提示**
因为每一帧都要重新执行 Selector 里排在 Running 节点之前的所有子节点(哪怕只是简单的 Conditional 判断),如果这些前置节点本身逻辑较重,会有持续的 CPU 开销,所以一般只在真正需要"实时优先级抢占"的地方使用,不建议整棵树到处套。




# -------------------- 
# == Repeater: 装饰器:
Repeater(重复节点) 会将其子节点重复执行指定次数, 或无限重复执行。
它可以设置为当子节点失败时提前停止。

只有当整个行为都需要在完成后重新开始时,才在根节点使用无限 Repeater。

如果只是某一个分支需要循环,应该用一个范围更小的 Repeater 把那部分包起来。

避免用一个紧凑的循环直接包住一个立即执行完的任务; 应当加一个 Wait, 或者让节点返回 Running,
这样重试就不会一次性耗尽整个执行预算。



# -------------------- 
# === Cooldown: 装饰器:
Cooldown(冷却节点)会立即启动其子节点。
当子节点返回 Success 或 Failure 后,它会存储这个结果,并在子节点不再活动期间保持 Running 状态,持续时长为 Duration。

当这段时长结束后,它才返回之前存储的结果。在整个等待期间,父节点会一直停留在这个分支上。

经典版的 Cooldown 只暴露 Duration 这一个参数。它没有"等待冷却结束"(Wait For Cooldown)选项,
也不会把"冷却中拒绝新的尝试"当作一种可用性判断机制来使用。任务结束时会清除它的计时器。

应当把 Cooldown 直接放在它所限制的 Action 或分支的正上方,这样这条计时规则才清晰可见。
如果需要在攻击不可用期间让 Selector 去选择一个备用分支,应该用一个单独的、基于时间判断的 Conditional 节点,并配合一个持久保存的"下次可用时间"来实现。



# -------------------- 
# === Until Success: 装饰器:
Until Success(直到成功节点)会在子节点返回 Failure 时不断重启该子节点,只有当子节点成功后才返回 Success。

当"暂时性的失败应当引发再次尝试"时,适合使用它。

如果子节点会立即返回结果,可能导致在行为树的一次更新循环中不停重试,这时应当在失败路径上加入一个 Wait。

Until Success 本身没有内置的尝试次数限制, 因此如果这个操作最终需要能够放弃, 
就要用一个自定义的重试装饰器(Decorator)或显式的计数器来实现。




# ------------------------------------------ #
#         Conditional Aborts
# ------------------------------------------ #
https://opsive.com/support/documentation/behavior-designer/conditional-aborts/

通常情况下,一个 Conditional 只有在执行流程遍历到它时才会运行。而开启了 Abort 功能的 Composite 会持续监视其下符合条件的 Conditional 后代节点。当被监视的 Conditional 状态发生变化时,Behavior Designer 会打断受影响的正在运行的分支,并从该决策点重新评估整棵树。

Conditional 状态图标周围的小圆形箭头表示该任务正在被重新评估。





# ------------------------------------------ #
#        继承 Action
# ------------------------------------------ #

# == OnAwake() 
—— 树第一次启用时，对每个 task 调一次，整个树的生命周期里只有这一次。
    用来取长期引用，比如你的 gRunner = GhostTaskHelper.ResolveGRunner(Owner)。
    注意这里拿到的东西会跨越所有回合，不能放任何「本回合状态」。

# == OnStart() 
—— 每次这个节点被压栈、即将开始工作时调一次。这是复位本次执行状态的地方：
    isSatDown = false、_pollTimer = 0f、启协程。
    你 SitOnGroundAction 里就是这么用的。
    --
    OnStart 里不能返回状态。 如果你想「一进来就判定失败」，只能在 OnUpdate 第一次调用时返 Failure。这也是 Gate 类节点写成 Conditional（首帧给明确结果）的原因

# == OnUpdate() 
—— 节点在栈顶时，每帧调一次，返回 Running / Success / Failure。
    返 Running 就继续留在栈顶，下一帧再来；返非 Running 就结束、弹栈、把状态交给父节点。
    这是 Action 唯一必须实现的方法。
    ---
    OnStart() 执行完后会立刻执行第一次 OnUpdate()


# == OnEnd() 
—— 节点退出时调一次，不管是正常返回 Success/Failure，还是被 abort 掉。清理都放这儿：
    停协程、恢复状态机（你那句 ToStage_IdleWalkJump(isForce_:true)）。
    --
    一定会执行，但别假设它执行时 Owner 还活着。 
    树被停掉、GameObject 被销毁的路径下，Owner.StopCoroutine 可能已经无意义。
    你现在协程挂在 Owner 上就有这个隐患 —— 前面提过的「协程宿主该挪到常驻 MonoBehaviour」就是指这个，等主线通了再动。

------

# == OnPause(bool paused)
    树被 PauseBehavior 或被 parallel 挂起
    需要暂停计时器时写

# == OnBehaviorComplete()
    整棵树结束时 收尾清理


# == OnDrawGizmos()
    Scene 视图画调试图形 调试用

# == GetPriority()
    上层是 PrioritySelector 时被问优先级


# ------------------------------------------ #
#        继承 Conditional
# ------------------------------------------ #
钩子和 action 基本一致, 只是用户实现逻辑上存在不同, Conditional 中, 用户在首帧 OnUpdate() 中完成判断然后返回
一般在 OnUpdate 里直接返回 Success/Failure,不应该有副作用

当然如果想实现 延时Conditional 也可以, 等待的时候返回 Running, 等到最后判断帧, 再返回 Success/Failure;


# ------------------------------------------ #
#        继承 Decorator
# ------------------------------------------ #
| 方法 | 干什么 | 要不要写 |  
|---|---|---|  
| `CanExecute()` | 调度器问「孩子能不能（再）跑」。**这是流程控制的唯一开关** | **必写**，不写就是隐形死循环 |  
| `OnChildExecuted(TaskStatus)` | 收孩子的状态，通常用来更新 `CanExecute()` 依赖的状态字段 | 几乎必写（`CanExecute` 的数据来源） |  
| `Decorate(TaskStatus)` | 改写向上返回的状态。**不控制流程** | 按需，装饰器的本职 |  
| `OnStart()` / `OnEnd()` | 复位内部状态字段 | 有状态字段就必写 |  
| `OnAwake()` | 一次性拿引用（你的 `gRunner`） | 按需 |  
| `OnConditionalAbort(int childIndex)` | 下方条件节点触发 abort 时，清理自己的状态 | 用了 abort type 就要写 |  
| `OnUpdate()` | 装饰器一般**不要**动，基类交给调度器处理 | 别写 |  
| `MaxChildren()` | `Decorator` 已经返 1 | 别动 |  


# == OnChildExecuted(TaskStatus):
触发点是：孩子的 OnUpdate() 刚刚返回了一个状态、控制权即将回到父节点手上的那一瞬间。本函数被调用



# ------------------------------------------ #
#           tree 总执行流程
# ------------------------------------------ #

BD 的运行核心是 BehaviorManager 里维护的一个 task stack 任务栈（每棵树一个）。
每帧 Tick 时，它从栈顶开始往下走，谁在栈顶就执行谁的 OnUpdate()。

BehaviorManager.Tick
 └─ 栈顶是 SitOnGroundAction → 调它的 OnUpdate()，拿到 status
     ├─ 若 status != Running → 调孩子的 OnEnd()，把它弹栈
     ├─ 调 父节点.OnChildExecuted(status)    ← 就是这里
     └─ 控制权回到父节点(AlwaysReturnSuccess)
         ├─ 调 Decorate(status) 得到对外的返回值
         └─ 调 CanExecute() 决定要不要再把孩子压回栈上


BD 一次 tick 里可以走完很多个节点，不是一帧一个。 
只要节点返回非 Running，调度器就当场弹栈、通知父节点、继续往下一个节点走，全程不跨帧。
所以单帧内完整跑完「Sequence.OnStart → Gate.OnStart → Gate.OnUpdate(Success) → Gate.OnEnd → Action.OnStart → Action.OnUpdate(Running)」是完全正常的。
你之前看到四个报价器的日志 time 全是同一个 frameCount，根源就在这儿
—整个 PrioritySelector 的排序加分支选中，全在一帧里完成。

# 一帧内会停下来的唯一原因是有节点返回了 Running，那才是帧的边界。













