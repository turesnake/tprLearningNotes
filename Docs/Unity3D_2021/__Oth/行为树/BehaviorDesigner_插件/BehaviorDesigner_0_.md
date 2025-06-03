


# 官方文档:
https://opsive.com/support/documentation/behavior-designer/overview/



# ------------------------------------------ #
#         behaviour tree 执行:
# ------------------------------------------ #

https://opsive.com/support/documentation/behavior-designer/behavior-tree-component/











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












