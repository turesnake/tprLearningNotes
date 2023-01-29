# ======================================================================== #
#             任务系统  Quest Machine
# ======================================================================== #

https://assetstore.unity.com/packages/tools/game-toolkits/quest-machine-39834



# 任务: quest, 其实就是 task


# ------------------------------------------- #
#         源码注解
# ------------------------------------------- #


# QuestMachine  (class)
    static manager class

# QuestMachineConfiguration (class)
    有点类似 brain 类, 总的管理类, 用到了 QuestMachine 里的功能;


# Quest  (class)
    (感觉有点像) 一个任务;
    可以是一个 quest asset (文件), 可也是个 quest instance (运行时实例)


# quest asset
    refers to the quest asset file in your project

# quest instances
    is an in-memory copy of a quest asset.
    There may be many quest instances of a quest asset.

    当一个 npc quest giver 初始化时, 它会将它的所有 quest 实例化;
    ---
    当 quest giver 将一个 quest 提供给 quester 时, 本质上是复制了一份新的 quest 实例;

# QuestGiver (class)
    quest 提供者, 比如 npc

# quester
    quest 接受者, 比如 player;


# QuestJournal (class)
    通常绑定在 quester 身上, 比如 player 身上;


# MessageSystem (class)

    MessageSystem.SendMessage()
    MessageSystem.SendMessageWithTarget() (to specify a target).
    MessageSystem.AddListener()
    MessageSystem.RemoveListener()
        It’s important to remove listeners before destroying the script instance;


# IMessageHandler (interface)


# DataSynchronizer (class)
    Uses the MessageSystem to keep data synchronized between a source and a listener.
    ---
    为啥有同步变量 这个需求呢 ? 
    































































