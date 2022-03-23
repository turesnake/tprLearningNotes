# ================================================================//
#                  Fork  za
# ================================================================//


# -------------------------:
#  github 库: 初步配置方法:
https://zhuanlan.zhihu.com/p/459863566




# -------------------------:
# 选择项目
点击 "极左侧,中上方位" 的加号 按钮, 添加一个新窗口;
此时会弹出列表, 让你选择 已经识别的 项目之一;



# -------------------------------------- #
#    一次完整的 修改提交流程
#     (只提交一部分文件, 即自己修改的那些)
# -------------------------------------- #
-1-
    单击 fork 左上角的 pull 按钮,
    把代码 同步到最新版;
    ---
    在中间窗口的 项目树上, 排在最上面的条条, 就是最新的版本

-2-
    此时可能会出现一些错误:
    --1--
        error: Your local changes to the following files would be overwritten by merge:
        (你对以下文件的本地更改将被“合并”覆盖)
            Assets/BundleResources/QualityPresets/ForwardRenderer.asset
            Assets/BundleResources/Timeline/storytimeline/1-1_part01.prefab.meta
        Please commit(提交) your changes or stash(藏匿) them before you merge.
        ---

        处理:
            对于这些不匹配的文件, 全选并复制其 路径名,
            打开 fork 右上角的 命令行 窗口, 键入:
                "git checkout " (最后有空格)
            然后单击 右键, 完成 "粘贴" 操作; 然后回车
            此时会出现:
                Updated 1 path from the index
            表示同步完成;

        多文件批处理:
            改用:
                git checkout -- Path.A.md Path/B.md
            可以一次处理多个文件;
            但是在回车执行后, cmd 并不会显示额外信息...
            

    --2--
        error: The following untracked working tree files would be overwritten by merge:
        (以下未跟踪的工作树文件将被“合并”覆盖)
            ProjectSettings/NotificationsSettings.asset
        Please move or remove them before you merge.
        Aborting
        (
            大概原因:
                -1-:
                    总库里新建了一个文件 a.md
                    本地也有一个同名的 新文件 a.md
        )

        --

        处理:
            将本地同名的文件, 删掉, 再 pull;
            ---
            https://stackoverflow.com/questions/4858047/gitignore-and-the-following-untracked-working-tree-files-would-be-overwritten
            https://stackoverflow.com/questions/17404316/the-following-untracked-working-tree-files-would-be-overwritten-by-merge-but-i/52255219#52255219


-3-
    进入 local changes 面板, 找到自己修改的部分,
    逐个点击自己修改的 每一个代码文件, 然后点击 stage;
    全部 stage 之后, 
    编辑自己的 commit subject, 比如:
        "fix:修正了xxx"
    (中间不要出现空格)
    最后点击 commit

    标题编写规范:
        "fix:"  修改了某东西
        "feat:" 添加了某东西

-4-
    最后点击 左上角的 push 按钮, 推送给全部成员;


# -------------------------------------- #
#    单独 复原某个 文件, 让它和全局同步
# -------------------------------------- #
假设我们把某个文件改坏了, 我们希望删除本地的这个文件, 然后从全局下载一个下来;
方法:
    fork 中左侧找到 "Local Changes", 
    找到目标文件, 右键, "Discard Changes" (变相等于删除它)

    然后, 重新 "pull" 即可;




# -------------------------- #
#      Fork  账户设置
# -------------------------- #
"File" - "Accounts", 点击 左下角 "+" 号, 
选择 "Gitlab Server", 

在 "Server" 上输入: http://fantang.f3322.net:8888/
在 Person Access Token 上输入: -P-ACMUW-wzLiHvs8RVY

即可成功设置账户;







