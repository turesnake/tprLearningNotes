# ================================================================= #
#                    Git  Stash
# ================================================================= #

临时储藏工作现场：


# 可有很多个 stash, 构成一个栈, 可用 stash@{i} 来访问, stash@{0} 为栈顶 stash




    恢复方法一：

    $ git stash drop 删除储藏的工作现场

    恢复方法二：
    $ git stash pop 恢复的同时把stash内容删除。

    当多次git stash时，可以：
    $ git stash apply stash@{0} 来恢复指定的某份储藏


# ------------------------------ #
#     git stash
# ------------------------------ #

会把当前 work 中所有修改的 文件 stash;
那些 新建的文件不会被处理,  因为它们尚未被 git 识别到, 不被管理;


    将目前尚未add 或 commit 的工作现场 储藏起来。
    等待恢复现场后继续工作。
    可以多次git stash。会被存进: 
    stash@{0} 
    stash@{1} 这类长得像数组的东西里。




# ------------------------------ #
#     git stash apply
# ------------------------------ #
把 stash 栈中, top 位置的 stash 应用起来, 将它的内容恢复到 work 中;
同时这个 stash 不被删除

一次调用只能处理 顶层那一个 stash, 而不是全部的;

# 这些恢复的修改 会返回 Unstaged 中;

    此时如果再次调用 git stash apply 会报错, 因为此时 stash中 和 Unstaged中 都修改了这个文件, 冲突了;

# git stash apply stash@{i} -- 指定处理栈中的某个 stash


# ------------------------------ #
#     git stash pop
# ------------------------------ #

和 git stash apply 不同, 本指令在恢复 top stash 修改的同时, 还将这次 stash 删掉了

连续调用 git stash pop, 可以将多个 stash 恢复回去;
    但是:
        如果前后两个 stash, 修改了同一个文件, 连续 pop 就会出现冲突;
        这个冲突会一直存在;

# 从这个角度看, 多个 stash 之间 是相互独立的;


# git stash pop stash@{i} -- 指定处理栈中的某个 stash


# ------------------------------ #
#     git stash drop
# ------------------------------ #
一次删除一个 栈顶的 stash


# git stash drop stash@{i} -- 指定处理栈中的某个 stash



# ------------------------------ #
#     git stash list
# ------------------------------ #
打印栈中所有 stash 的信息:
    如:
    stash@{0}: On main: 003_1                   -- 手动命名的 stash
    stash@{1}: WIP on main: d038b0a kkk         -- 自动生成名     "WIP": work in progress
    stash@{2}: WIP on main: d038b0a kkk         -- 自动生成名



# ------------------------------ #
#  如果先 stash 了文件 a.txt, 
#  然后又本地修改了 文件 a, 
#  此时如果 恢复这个 stash
# ------------------------------ #

# 会报错:     
    On branch main
    Your branch is up to date with 'origin/main'.

    Changes not staged for commit:
    (use "git add <file>..." to update what will be committed)
    (use "git restore <file>..." to discard changes in working directory)
        modified:   a.txt

    no changes added to commit (use "git add" and/or "git commit -a")
    The stash entry is kept in case you need it again.

    error: Your local changes to the following files would be overwritten by merge:
        a.txt
    Please commit your changes or stash them before you merge.
    Aborting
    =======
    毕竟 stash 中保存的内容,  和 当前 work 中保存的 a.txt  不一致了;  git 不知道用哪份


# ------------------------------ #
#  如果先 stash 了文件 a.txt, 
#  然后又本地修改了 文件 a,  然后把这个修改 add and commit 了
#  此时如果 恢复这个 stash
# ------------------------------ #

# 会报错:   
    Auto-merging a.txt
    CONFLICT (content): Merge conflict in a.txt
    On branch main
    Your branch is ahead of 'origin/main' by 2 commits.
    (use "git push" to publish your local commits)          -- 这条无关

    Changes to be committed:
    (use "git restore --staged <file>..." to unstage)
        new file:   local002.txt

    Unmerged paths:
    (use "git restore --staged <file>..." to unstage)
    (use "git add <file>..." to mark resolution)
        both modified:   main_01.txt

    The stash entry is kept in case you need it again.
    ===
    这是因为 stash 和 总分支中的 a.txt 不同了

#   此时 fork 会跳出一个 conflict 选择让你选, 



















