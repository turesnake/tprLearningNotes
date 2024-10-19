



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




# 重启服务器:
    sudo reboot     -- 最简单的


# 杀死进程
sudo kill 12345


sudo kill -9 12345
    -9 表示强行杀死这个进程


# ========================================= #
#                 todo
# ========================================= #

# 待学习指令:
iftop、nload、vnstat、ip 和 netstat







