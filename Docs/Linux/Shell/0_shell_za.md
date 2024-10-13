



# 新建用户
adduser <newName>
    --
    顺带会问你要 登录密码


# 将用户添加到 sudo 组（可选）：
如果您希望 xxx 用户具有 sudo 权限，可以将其添加到 sudo 组：
usermod -aG sudo xxx


# 切换用户 (1)
su - xxxx
---
这将提示您输入 tapir 用户的密码。

# 切换用户 (2) from root
sudo -i -u xxxx
---
这将直接切换到 tapir 用户，而不需要输入密码（前提是您已经以 root 用户身份登录）。











