# ================================================================ #
#                  Fork  za
# ================================================================ #


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

        处理2:
            https://stackoverflow.com/questions/17404316/the-following-untracked-working-tree-files-would-be-overwritten-by-merge-but-i


        处理3:
            更简单的思路是: 因为这些文件是 git 的 untracked 的, 可以直接使用 cmd 的 del 指令来删除;
            比如 
                del C:\Users\canglanxing\Desktop\aa\01.txt
            注意, 这个指令可以跨磁盘删文件, 比如, 在 c 盘可以直接删除 D盘文件:
                del D:\01001.txt


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



# -------------------------------------- #
#    若 本地 commit 了一个 版本, 但不想要了, 希望回退怎么做 ?
# -------------------------------------- #

-1-
    查看当前版本:
        git log --pretty=oneline
    
    可以看到最近的若干次版本

-2-
    往后回退一次:
        git reset --hard HEAD~1

    如果不行, 就再回退一次;



# -------------------------------------- #
#    制作 diff:
#    将上一次在本地生成的 commit, 制作成一个 diff
# -------------------------------------- #
(这个不常用, 常用的为下方的 patch)

-1-
    fork 右上角打开 console, 输入: git log, 可显示最近几次 commit 的信息;
    比如它的 id, 
    ---
    也可直接在 fork 主界面上查看, 选中某一行, 下方会出现此 commit 的信息,
    SHA 码 就是它的 id值;

-2-
    在 console 中输入:
        git diff  XXX^ XXX > diffName.diff


    这里的 XXX 就是本次 commit 的id值, 可以只写入其 头部若干字符即可;
    "XXX^" 表示的是 XXX 的上一条 commit, 是种简写方式;

    然后就能生成一个 diff 文件;

# 这个生成的 文件后缀, 可以是 .diff, 也可以是 .patch, 最终文件里的内容是一样的
为避免和 真的 patch 文件混淆, 此处推荐使用 .diff 后缀;



# -------------------------------------- #
#    打补丁:
#    将上一次在本地生成的 commit, 制作成一个 patch
# -------------------------------------- #

-1-
    在 左下角 "Search Commits" 中输入关键词, 查到目标 commit;
    此时这个 commit 会在 中间窗口中显示出来 (一行)

-2-
    选择中间窗口的 这一行, 右键单击, 选择 "Save as Patch",
    然后选择要存储的 文件夹, 就能打成一个 patch 了;



# -------------------------------------- #
#    撤销一次 已经提交到 总库的 commit
# -------------------------------------- #
点击 revert commit

维持那个 commit 按钮为勾选状态;

https://blog.csdn.net/shaobo8910/article/details/106055164



# -------------------------------------- #
#    撤销一次 生成在本地的 commit
# -------------------------------------- #

# rebase ".." to here:
选择一个 较早的 commit, 然后右键点击此功能, 就能把本地 commit 回退掉; 



# -------------------------------------- #
#   让项目 进入某个指定的 commit
# -------------------------------------- #
选择那个 commit, 右键: 
    Reset 'dev' to here;



# -------------------------------------- #
#   Cherry-Pick 了一个提交, 但没有合到 总库, 如何撤销这个本地的 Cherry-Pick
# -------------------------------------- #

不要提交, 调用 git reset  ( Reset 'dev' to here ) 来回退到 Cherry-Pick 前的一条提交;
然后那个 Cherry-Pick 就消失了;



# -------------------------------------- #
#      查看一个文件的所有提交记录
# -------------------------------------- #
在这个文件上随意修改一行
然后在 fork 的 Local Changes 一栏找到这个文件, 右键选择 history, 就能显示这个文件的 全部提交历史;







# -------------------------------------- #
#      Pull . Stash and reapply local changes
# -------------------------------------- #
new bing:
the option "Stash and reapply local changes" refers to a feature that allows you to stash your local changes before pulling changes from a remote repository¹. 
This option is useful when you have made local modifications that you want to save temporarily before updating your codebase with the latest changes from the remote repository¹.

When you select "Stash and reapply local changes," **Fork** will automatically stash your local changes, pull the latest changes from the remote repository, 
and then reapply your stashed changes on top of the updated codebase¹. This ensures that your local modifications are preserved while incorporating(并入) the new changes from the remote repository¹.

By using this option, you can switch between branches or update your codebase without losing your local work¹. 
It provides a convenient way to manage your changes and keep your code up to date with the latest developments in the remote repository.

Source: Conversation with Bing, 2023/9/20
(1) [Feature request] Add `Stash and reapply` option to the ... - GitHub. https://github.com/fork-dev/TrackerWin/issues/1311.
(2) . https://bing.com/search?q=Stash+and+reapply+local+changes+in+app+Fork%27s+Pull+button.
(3) git - How to stash the changes between local repository and remote .... https://stackoverflow.com/questions/33069752/how-to-stash-the-changes-between-local-repository-and-remote-repository.
(4) git pull: keeps telling me to stash local changes before pulling. https://stackoverflow.com/questions/20568971/git-pull-keeps-telling-me-to-stash-local-changes-before-pulling.
(5) undefined. https://www.atlassian.com/git/tutorials/saving-changes/git-stash.
(6) undefined. https://www.freecodecamp.org/news/git-stash-explained/.




# -------------------------------------- #
#   如何用  git  指令来模拟  fork 中的 Pull 
#   (同时勾选了  "rebase instead of merge"  和  "stash and reapply local changes"  )
# -------------------------------------- #

# -1-
git stash

# -2-
git pull --rebase

# -3-
git stash apply


# 实测, 速度比 fork 快很多....





















