# ====================================================== #
#            git merge 和 git rebase
# ====================================================== #




# =====================================|
                merge
# -------------------------------------|


   $ git merge dog
                    自己身处 main branch, 此指令能将 dog branch 的内容, 合并到 本分支(main)

                    It performs a 'fast-forward merge' if possible, which means that if the current branch is an ancestor(祖先) of the branch being merged, 
                    (如果 main 是 dog 的祖先)
                    Git will simply move the pointer of the current branch to the commit that dog points to. This results in a linear history with no merge commit.

                    这种合并是扁平化的，旧的master位置会成为线轴上的一个点，无分支
                    在历史中，ff是看不出曾经有过分支的。

#                  !!!!!!! 注意:
                    只有当 本分支(main) 啥也没变, 对方分支(dog) 有了新提交
                    此时才会触发 'fast-forward merge'
                    此时执行 merge , 会看到 history 中没有环路, 而是让 本master 直接指到 dog 最新分支上, (以此表示两个分支已经同步了)


    $ git merge --no-ff -m "message" dog 
                    
                    将分支 dog 的内容 合并到当前分支;

                    However, it forces a new merge commit even if a fast-forward merge is possible. 
                    The option --no-ff stands for “no fast-forward” and ensures that a merge commit is created. 
                    The -m "merge-cat-2-main" flag is used to specify the commit message for the merge commit.

                    不使用fast forward模式，  (这其实是 merge 的最基础的 环形结构)
                    将会在旧master和name2之外额外新建一个commit点，
                    然后把合并后的内容放进那个新点，此时的master也指向这个点
                    非扁平化，历史上的name2和旧master形成两个分支。


    
------------------------

`git merge` creates a new commit that combines the changes from two or more branches². 
It preserves the history of each branch and creates a new commit that ties together the histories of both branches². 
This results in a non-destructive(无损的) operation that avoids all of the potential pitfalls of rebasing². 
However, it also means that the feature branch will have an extraneous merge commit every time you need to incorporate upstream changes².
---

用一个额外的 merge commit 来实现数个分支之间的 合并,  avoids all of the potential pitfalls of `rebase`
git merge 没有破坏 src branch, 仅仅是在 dst branch 上新加了一个 commit, 它不是破坏性的;  缺点就是会有很多分支;




# =====================================|
            rebase
# -------------------------------------|

    $ git rebase dog
                    自己身处 main branch, 且 main 上有几个新的 commit;
                    然后此指令 能将 main 上的 额外的新提交, 重建为新的 commit 放到 目标branch dog 的顶部;

#                   !!!!!! 注意:
                    此处 参数的顺序 和  merge 是相反的;                       



`git rebase` moves the entire feature branch to begin on the tip of the main branch, effectively incorporating all of the new commits in main². 
It rewrites the project history by creating "brand new"(全新) commits for each commit in the original branch². 
This results in a perfectly linear project history, making it easier to navigate your project with commands like `git log`, `git bisect`, and `gitk`². 
However, it can be a destructive(破坏性的) operation that throws away one branch, rewriting it on top of the other³.

`git rebase` 将 src branch 中的每一个 commit (dst branch 中没有的) 的内容,  重新制作成一个全新的 commit 添加到 dst branch 中去;









# =====================================|
        merge  和    rebase  的区别
# -------------------------------------|

For more information on merging and rebasing, you can refer to Atlassian's Git Tutorial on [Merging vs. Rebasing](https://www.atlassian.com/git/tutorials/merging-vs-rebasing)².

Source: Conversation with Bing, 2023/9/20
(1) What's the difference between 'git merge' and 'git rebase'? - Answer. https://stackoverflow.com/questions/16666089/whats-the-difference-between-git-merge-and-git-rebase.
(2) Merging vs. Rebasing | Atlassian Git Tutorial. https://www.atlassian.com/git/tutorials/merging-vs-rebasing.
(3) git: difference between merge and rebase - Stack Overflow. https://stackoverflow.com/questions/22638046/git-difference-between-merge-and-rebase.
(4) Differences Between Git Merge and Rebase - Better Programming. https://betterprogramming.pub/differences-between-git-merge-and-rebase-and-why-you-should-care-ae41d96237b6.
(5) Git Merge vs Rebase | Which Is Better? | Perforce. https://www.perforce.com/blog/vcs/git-rebase-vs-merge-which-better.




















