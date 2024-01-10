
# ================================================================
#                        最常用的 指令
# ----------------------------------------------------------------


# -------------------------------- #
#   如何在 win11 安装 git 环境
https://nerdschalk.com/how-to-install-and-use-git-on-windows-11/





# ================================================================
- git clone git@github.com:UserName/xxxx.git
    将 远程库 项目 clone 到当前目录（下的子目录）
    此时，cwd 应该是 目标目录的 父目录
    ---
    若想指定 克隆的分支, 可写:
    git clone -b dev git@github.com:UserName/xxxx.git
    ---
    这里的 "-b dev" 就制定了 dev 分支;
    

- git add file
  git add dir/
  git add .
    第三句最实用，add 全部 文件

- git commit -m "xxx"
    正式 commit （但是仅仅到本地）

- git push origin master
    将本地更新，推送到 远程库

- git pull <远程主机名> <远程分支名>:<本地分支名>
    用于从远程获取代码并合并本地的版本。
    常用：
    -1-:
    将远程主机 origin 的 master 分支拉取过来，
    与本地的 brantest 分支合并
        git pull origin master:brantest
    -2-:
    如果本地分支也是 master，可简写为：
        git pull origin master
        或：
        git pull origin


- git remote -v
    查看本 git项目 的远程库 地址



# ------------------------------
# Learn Git in Y minutes
https://learnxinyminutes.com/docs/git/





# ================================================================

[快捷键] ctl + z 可以从进程中退出来！！
git存在三个空间
1.working directory (工作区)-（比方说例中的learngit文件夹）
2.repository (版本库): -（工作区里隐藏一个目录：.git）
    2-1.stage/index (暂存区)（需要提交的东西统统放这个，add）
    2-2.master (当前分支)（一次性提交暂存区里的所有修改。commit）
    2-3.HEAD （指向master的一个指针）

# =====================================|
                config
# -------------------------------------|
    $ git config --global user.name "tom"  统一名字
    $ git config --global user.email "tom@xxx.com" 统一邮箱。


# =====================================|
                init
# -------------------------------------|
    $ git init  把当前目录新建为git管理的仓库
            如果我们是通过 github 创建项目的，
            那么这条指令 就不常被用到


# =====================================
                add
# -------------------------------------|

（我们把某文件‘filename1.txt’ 放到上文的仓库文件夹中）
    $ git add filename1.txt 把某文件添加进仓库（把文件添加进暂存区stage）

    $ git add /xxx/
    添加整个目录的文件

    $ git add .
        添加当前目录下的所有 子目录和文件
        最实用

# =====================================|
                commit
# -------------------------------------|
    $ git commit -m "a test" 把文件提交到仓库（让仓库记住这文件）。
                                    把暂存区stage的内容提交到当前分支master
                                    提交的同时附带一个说明

（可以add很多文件，然后统一commit）
（每次修改都需要 add 和 commit 操作 ）

# =====================================|
                status
# -------------------------------------|
    $ git status 查看仓库的状态（看看哪些文件被修改了但没提交）



# ===========================================================|
#                       log
# -----------------------------------------------------------|
# 查看另一个文件... 



# =====================================|
                reset
# -------------------------------------|
    $ git reset --hard HEAD^ 回退到上一次修改时的状态
                        这里的HEAD指向当前版本
                        HEAD^ 指向上一版本
                        HEAD^^指向上上版本
                        HEAD~100指向上100版本

    $ git reset --hard 2addecd 回退到版本号（commit id）为2addecd 的那次修改

    $ git reflog  显示用户的每次git操作，顺带显示相应的版本号（commit id）

    $ git diff HEAD -- filename.txt 查看工作区（working derictory）和版本库(repository)里面最新版本的区别

    $ git checkout -- filename.txt 把文件在工作区的修改全部撤销
                                （用版本区里的版本替换工作区里的版本。）
        1.文件自修改后尚未add到暂存区，此时checkout将会把文件改回版本库一样的状态
        2.文件已经add到暂存区，然后又做了修改，此时checkout将把文件改回暂存区的状态
总之就是让文件回到最近一次 add 或 commit 时的状态。
如果没有--标识符，将表示另一个意思：切换到另一个分支。


    $ git reset HEAD filename.txt 可以把暂存区的修改撤销掉（unstage）.重新放回工作区
        此时工作区文件的修改还在，版本库里暂存区stage里的暂存没有了。
        然后可以配合$ git checkout -- filename.txt 的方法来删除工作区的修改。
    当改乱了工作区文件的内容，想直接丢弃工作区里的修改。
        用： $ git checkout -- filename.txt 用版本区里的版本替换工作区里的版本。

    当不但改了工作区，还add到了版本库里的暂存区stage里。分两步：
        用： $ git reset HEAD filename.txt  将暂存区修改退回工作区
        用： $ git checkout -- filename.txt 用版本库里的版本替换工作区里的版本。

    当把暂存区stage里的修改commit到了版本库分支master。执行版本回退，
        用： $ git reflog
        或： $ git log --pretty=oneline 来查看和获取之前历次修改的版本号commit_id
        然后用： $ git reset --hard commit_id 来跳回某个版本号的状态。


# =====================================|
        git cherry-pick
# -------------------------------------|
http://www.ruanyifeng.com/blog/2020/04/git-cherry-pick.html

将分支a 上的一次提交, 复制一份移植到 分支b 上去;


# fork 工具:
在 fork 工具上, 先进入 b 分支, 然后选中需要移植的 commit, 右键点击 cherry-pick commit 就行;

面板选项内保持原始配置: 
    勾选 commit the changes; 
    不勾选 Append origin to commit message

然后点击 submit 即可;

有时需要连续 移植好几个 commit;

最后记得 push 到总库;



#  代码实现
有时在 fork 中, 我们无法从时间图中看到 另一个分支的某次提交;
此时可到左侧的 搜索栏, 查找出目标 commit, 找到它的 SHA 码, 提取前面若干位数字,
然后在 命令行中输入:

    git cherry-pick 121f6d96c2e7e98

此指令会自动创建一个 commit, 此时只要再去点击 push 就可以了;



# =====================================|
       分支 不同步 问题
# -------------------------------------|

如果在 main 分支中, commit-a 删除了资源, 然后又回退了这条 commit (revert), 记做 commit-b
然后在 beta 分支中, 只拉取了 commit-a;

最后, 我们又希望在 main 分支中, 也和beta一样, 该怎么做:
#:
    把 beta 中的 commit-a, 再 cherry-pick 回 main 分支; 就好了






# ================================================================
                      如何 访问 github
# ----------------------------------------------------------------
    $ ssh-keygen

        然后一路回车
        新的 钥匙会存储在 /Users/tom/.ssh/id_rsa.pub

        如果电脑尚未创建，需要创建一个。
        此时需要一个 ssh 密码...

        ...

        当创建好后，可以 cat /Users/tom/.ssh/id_rsa.pub
        获得一个:
            ssh-rsa AAAAB...
            ...
            ...bW14Lvv tom@XXX.com
        格式的数据串。
        -----------

        进入 github 网站 -->
        个人 Settings -->
        SSH and GPG keys -->
        new SSH keys :
            写好 title
            将 上文的 key串，复制到 Key 框中
        Add SSH key
        成功添加 ssh key
        -----------

        回到本机 git_repository 目录
        （或者任何 想要成为 目标项目的 父目录 的 目录）
        输入：

    $ git clone git@github.com:tom/git_test_2018.git

        具体 网址 可以从 github 具体项目的 
            clone and download
        中查到

        这个指令会把 整个项目 下载到当前 目录下。


================================================================

当和github远程版本库绑定后。
以后每次做本地提交commit。可以再输入一句：

# =====================================|
                push
# -------------------------------------|
    $ git push origin master  
        
        把本地master分支的最新修改推送到github。


# =====================================|
                clone
# -------------------------------------|
    $ git clone git@github.com:UserName/repositoryname.git
        将github中的某个远程库 克隆到本地。


# =====================================|
                branch
# -------------------------------------|
    $ git branch 查看当前分支

    $ git branch <name1> 创建名为 name1 的新分支

    $ git branch -a 
        查看 本机 和 远程 的所有分支

    $ git branch -d <name3> 
        删除名为name3 的分支

# =====================================|
                checkout
# -------------------------------------|
    $ git checkout <name1> 切换到名为 name1 的分支 

    $ git checkout -b <name> 创建并切换到名为name1 的新分支

    $ git checkout -b name2 origin/<name2> 创建远程origin的name2分支到本地
                                    远程版本库已经存在这个名为name2的分支
                                    现在创建一个本地的分支，这个分支是从这个远程分支
                                    分过来的。


# =====================================|
                merge
                rebase
# -------------------------------------|
# 见文件: Git_Merge_Rebase.md


# =====================================|
                stash
# -------------------------------------|
# 见文件: Git_Stash.md

------------------------------------------------------------

# =====================================|
                remote
# -------------------------------------|
    $ git remote 查看远程库的信息

    $ git remote -v 查看远程库的信息，详细模式

    $ git branch --set-upstream-to=origin/<name1> name2
                设置本地分支name2和远程分支origin/<name1> 的链接。
                可以设置任意一个本地分支和远处分支的链接


# =====================================|
                pull
# -------------------------------------|
    $ git pull 把远程库中的内容抓取到本地。



-----------------------------------------------------------
    $ git tag v1.0 给当前的分支（主要是在master上）打一个标签：v1.0
                    标签不是按时间顺序排列的，是按字母顺序排列的

    $ git tag v0.9 <commit_id>  给历史中的某个分支点打标签。

    $ git tag -a v0.1 -m "a explain" <commit_id>
                        一种更完整的打标签格式
                        -a 后面跟标签tag
                        -m 后面跟说明文本
                        最后附上具体的分支点id

    $ git tag  查看已有的标签。

    $ git show v0.9 查看某个标签的信息

    $ git push origin v0.9  将某个标签推送到远端

    $ git push origin --tags 一次性推送所有微推送到远端的本地标签

    $ git tag -d v0.1 删除某个标签

    $ git push origin :refs/tags/v0.9 删除远端的某个标签。



# ================================================================
#         添加 .gitignore 文件来屏蔽某些 文件的 上传／共享
# ----------------------------------------------------------------

-- 在项目根目录 添加文件 .gitignore

-- 若想屏蔽 .DS_Store 文件。
    可以在 .gitignore 文件内写入：

        .DS_Store
        */.DS_Store

    表示，屏蔽任意目录下的 .DS_Store 文件

-- 创建文件 ~/.gitignore_global
    写入同样的内容

    也可以用一个 快捷指令来 实现：

        echo .DS_Store >> ~/.gitignore_global


-- git config --global core.excludesfile /Users/tom/.gitignore_global
    将 .gitignore_global 添加进 git 配置表。

    也可以在 ~/.gitignore_global 文件中手动添加:
    [core]
        excludesfile = /Users/tom/.gitignore_global

-- git config --list



# ================================================================
#              删除 git 项目中的 文件
# ----------------------------------------------------------------
比如，我们要删除整个项目中的 .DS_Store

-- 进入 项目根目录

-- find . -name .DS_Store -print0 | xargs -0 git rm -f --ignore-unmatch
    先将本地目录中，所有 .DS_Store 文件删除

-- git add .
   git commit -m "xxx" 

    ...

---------------
想要单独删除某个文件 

-- git rm --cached .DS_Store



# ================================================================
#                替换掉整个目录
# ----------------------------------------------------------------
# 需求:
    假设存在两分支 dev 和 art, 现在 art 中的相对目录 Assets/BundleResources/Shaders/ 中的文件严重落后于主线进度, 
    已经没办法通过 cherr-pick 来一点点同步两个分支中的内容了, 此时就需要将整个 Shaders/ 目录替换成 dev 分支中的那个;

# 实施:
    cmd 进入 art 工程目录, 输入:
        git checkout origin/dev Assets/BundleResources/Shaders/Scene/

注意, 此处指定的 branch 必须写: "origin/dev"; 它指向远端库中的 dev 分支, 而不是本地的,
否则如果写了 "dev", 则只会同步到本地 dev分支的当下时间节点,  如果 本地 dev 没有被拉到最新, 则会导致本次同步并不彻底;

运行成功后, 可看到: 

    Updated 22 paths from xxxxx

表示更新了 目标目录中 22 个文件;



# ================================================================
#      在两个分支之间 移动 文件
# ----------------------------------------------------------------

# 如何将 分支:master 的文件 aaa.txt 复制到 分支:Beta

    git checkout Beta                               -- 切到 分支:Beta
    git checkout master aaa.txt                     -- 将 分支:master 的文件 aaa.txt 复制过来 (如果本地有同路径文件, 则取代本地文件)
    git commit -m 'xxxxxxxxx'                       -- 提交 commit
    git push                                        -- push
    ---


# git checkout --theirs foo

    记得 yajie 使用了:
        git co --theirs filepath
        git add filepath
    ---
    suppose you are on branchA and you want to merge branchB into it, but there is a conflict in a file named foo. 
    To resolve the conflict by keeping the version of foo from branchB, you can use this command;
    This will overwrite the file foo in your working directory with the version from branchB. You still need to add and commit the file to complete the merge.
    ---
    "--theirs" option 意味着当发生 conflict 时, 使用 "对方" 分支的文件, 类似的还有 "--ours" 选项 (使用本分支的)





# ================================================================
#     bug:
#   fatal: unable to access 'aaa/bbb/': Failed to connect to xxx.net port 8888 after 2081 ms: Couldn't connect to server
# ----------------------------------------------------------------

此时是域名错了, 

可在项目的 .git/config 文件内修改, 

此时可以到 gitlab 的工程里, 找到 clone 位置 (想想 github 里的 clone) 找到 clone 的 ssh 地址, 换用下



  
# ================================================================
#          待看
# ----------------------------------------------------------------

git rm .gitattributes







