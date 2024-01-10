# ================================================================
#                   git log
# ----------------------------------------------------------------
https://blog.csdn.net/u012260238/article/details/81673853



    $ git log 查看仓库的更新记录，从最近到最久。

    $ git log --pretty=oneline  简洁显示，每次更新的信息被压缩到一行。





# ================== 展示内容 ===================:

# 显示 目标 commit 的差异:    --- 实用AAA
    -p
    
    如:
        git log -p --grep="剩余猫球增加"
        ---
    会显示: 当前分支中, 名字含 "剩余猫球增加" 的 commit 的信息, 包含其差异信息;

# 显示 目标 commit 修改了 哪些文件:   --- 实用AAA
    --stat：
        显示每次更新的修改文件的统计信息，每个提交都列出了修改过的文件，以及其中添加和移除的行数，并在最后列出所有增减行数小计


# 显示 目标 commit 修改/添加/删除 了哪些文件;
    --shortstat
    
    只显示 --stat 信息中的最后一行;

    比如显示:
         3 files changed, 96 insertions(+)

#
    --name-only   
    只显示 --stat 信息中, 改动的 文件名字;


# 仅显示 SHA-1 的前几个字符，而非所有的40个字符
    --abbrev-commit

    不常用, 40个字符也是放得下的...


# 使用较短的相对时间显示（例如："two weeks ago"）
    --relative-date

    而不是显示具体的提交日期, 





# ================== 筛选方式 ===================:

# 查看某个文件的 提交记录:
    git log --follow filePath

    比如:
    git log --follow Assets/BundleResources/Prefabs/SpringFestival121401/SpringFestivalMazeMainDialog.prefab


# 按作者   --- 查看某个人的所有 提交记录:
    --author="XXX"
        比如 git log --author=“John"，
        --
        显示John贡献的commit
        注意：作者名不需要精确匹配，只需要包含就行了
        而且：可以使用正则表达式，比如git log --author="John|Mary”，搜索Marry和John贡献的commit
        而且：这个--author不仅包含名还包含email, 所以你可以用这个搜索email


# 按 commit 描述
    --grep="XXX"
        比如：git log --grep="剩余猫球增加"
        而且：可以传入 -i 用来忽略大小写
        注意：如果想同时使用--grep和--author，必须在附加一个--all-match参数
        ---
        传入的参数内容就是我们的 commit 标题;


# 按分支
    --branchName 
        branchName 为任意一个分支名字，查看某个分支上的提交记录
        需要放到参数中的最后位置处
        如果分支名与文件名相同，系统会提示错 误，可通过--选项来指定给定的参数是分支名还是文件名
            比如：在当前分支中有一个名为 v1 的文件，同时还存在一个名为 v1 的分支
            git log v1 --      此时的 v1 代表的是分支名字（ 注意, -- 后边需要是空的）
            git log -- v1      此时的 v1 代表的是名为 v1 的文件
            git log v1 -- v1   代表 v1 分支下的 v1 文件

    --all
        查看所有分支的历史:

            git log --all --grep="剩余猫球增加"
            ---
        上例: 查看所有 分支中, 名字里含有 "剩余猫球增加" 的 commits;



# 按内容
    -S"<string>"、-G"<string>"
        有时你想搜索和新增或删除某行代码相关的 commit. 可以使用这条命令
        假设你想知道 Hello, World! 这句话是什么时候加入到项目里去的，可以用：
            git log -S"Hello,World!"

        另外：如果你想使用正则表达式去匹配而不是字符串, 那么你可以使用 -G 代替 -S.
        这是一个非常有用的 debug 工具, 使用他你可以定位所有跟某行代码相关的 commit. 甚至可以查看某行是什么时候被 copy 的, 什么时候移到另外一个文件中去的
        注：-S后没有"="，与查询内容之间也没有空格符;


# 按范围
    git log <since>..<until>
        这个命令可以查看某个范围的commit
        这个命令非常有用, 当你使用 branch 做为 range 参数的时候. 能很方便的显示 2 个 branch 之间的不同;
        比如：
            git log master..feature，
            ---
        master..feature 这个 range 包含了 "在 feature 有而在 master 没有的所有 commit"，
        同样，如果是 feature..master 包含 "所有 master 有但是 feature 没有的 commit"

        另外，如果是三个点，表示或的意思：
            git log master...test 
            ---
        查询 master 或 test 分支中的提交记录

# 过滤掉merge commit
    --no-merges
        默认情况下 git log 会输出 merge commit.  你可以通过 --no-merges 标记来过滤掉 merge commit，
            git log --no-merges
        
        另外，如果你只对 merge commit 感兴趣可以使用 
            
            —merges，
            
            git log --merges


# 按标签tag
    git log v1.0
        直接这样是查询标签之前的commit
        加两个点git log v1.0.. 查询从v1.0以后的提交历史记录(不包含v1.0)


# 按commit
    git log commit：         查询 commit 之前的记录，包含 commit
    git log commit1 commit2： 查询 commit1 与 commit2 之间的记录，包括 commit1 和 commit2
    git log commit1..commit2：同上，但是不包括commit1

        其中，commit可以是提交 哈希值 的简写模式，也可以使用 HEAD 代替
            HEAD代表最后一次提交，HEAD^为最后一个提交的父提交，等同于HEAD～1
            HEAD～2代表倒数第二次提交


# 显示 cherry-pick 出来的 commit:
    





    

# ----- 
<CATCG-禁止合并>深度交互演示素材   
这个提交中的内容要删除

# -----
记得把 home 角色 prefab 删除















