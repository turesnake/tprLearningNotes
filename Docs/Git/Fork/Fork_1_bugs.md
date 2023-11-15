# ================================================================ #
#                  Fork  bugs
# ================================================================ #



# -------------------------------------- #
fatal: unable to access 'https://github.com/turesnake/winProject-01.git/': OpenSSL SSL_read: Connection was reset, errno 10054
Pushing to https://github.com/turesnake/winProject-01.git

此 bug 发生在 "将本地代码 push 到全局库 时",
一个原因是网络不稳定, 尝试 关闭代理后, 再 push;






# -------------------------------------------- #
#      突然发现  fork Changs 里面内容全丢了
# -------------------------------------------- #


从 cmd 进去, 会发现:
# Administrator@tapirBook MINGW64 /e/__XXX__/cat_XXX (oversea|REBASE)

它处于 `(oversea|REBASE)` 状态,

调用:
    git rebase --abort

将它退回: `(oversea)`
就好了;

# gpt 解释:
`git rebase --abort` is a command used to abort an ongoing rebase operation and return the repository to its previous state. 

When you perform a `git rebase` operation, Git creates a new branch with the changes from the branch you are rebasing onto, 
and then applies your changes on top of it. However, if there are conflicts between the changes in your branch and the changes in the branch you are rebasing onto, 
Git may pause the rebase operation and prompt you to resolve the conflicts manually. 

If you decide that you do not want to continue with the rebase operation, you can use `git rebase --abort` to stop the operation 
and return the repository to its previous state before the rebase started. 
This command discards all changes made during the rebase operation and restores the original branch, allowing you to start over or try a different approach.

It's important to note that using `git rebase --abort` will discard all changes made during the rebase operation, so it should be used with caution. 
If you have made any changes that you want to keep, you should commit them before aborting the rebase operation.




















