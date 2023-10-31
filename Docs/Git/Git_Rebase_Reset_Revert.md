# ================================================================= #
#                    Git  Rebase
#                    Git  Reset
#                    Git  Revert
# ================================================================= #

# chatgpt-3.5:

In Git, "rebase", "reset", and "revert" are three different commands used for different purposes:

1. Rebase: 
   - `git rebase` is used to integrate (整合) changes from one branch into another branch by moving or combining commits.
   - It allows you to modify the commit history by applying each commit of the current branch on top of another branch.
   - It is commonly used to keep the commit history clean and linear, especially when working with feature branches.
   - Be cautious when using rebase on shared branches, as it can modify the commit history and cause conflicts for other collaborators.
   ---

   和 merge 对应的一个功能

2. Reset:
   - `git reset` is used to move the current branch to a specific commit, effectively resetting the branch to that state.
   - It allows you to undo commits by discarding or moving them to a different state without creating new commits.
   - There are three modes of reset: soft, mixed, and hard. Soft reset keeps the changes in the staging area, mixed reset keeps the changes in the working directory, and hard reset discards all changes.
   - It is commonly used to undo local commits or move the branch pointer to a previous state.
    ---

    将当前时间点重新指向本 branch 之前的某次 commit 上去;
    ---
    使用 Reset 可以撤销一条 "cherry-pick 到本地, 但没提交到总库" 的 commit
    


3. Revert:
   - `git revert` is used to create a new commit that undoes the changes made by a specific commit.
   - It allows you to keep the commit history intact by creating a new commit that undoes the changes made by a previous commit.
   - Revert is a safe way to undo commits, especially on shared branches, as it creates a new commit instead of modifying the existing commit history.
   - It is commonly used to undo changes in a public branch without affecting other collaborators.
    ---

    通过 新增一条 revert commit 来撤销之前一条 commit 的内容




In summary, rebase is used to modify the commit history, reset is used to move the branch pointer to a specific commit, and revert is used to create a new commit that undoes the changes made by a specific commit. The choice of command depends on the situation and the desired outcome.
























