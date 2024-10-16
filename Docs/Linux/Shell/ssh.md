



# sudo systemctl enable ssh
    将 ssh 设为 开机启动项



# ---------------------------- #
# 禁用 root 用户的 SSH 登录：
# ---------------------------- #
# 编辑 SSH 配置文件：
    nano /etc/ssh/sshd_config  
    找到以下行：

    plaintext
    PermitRootLogin yes  
    将其更改为：

    plaintext
    PermitRootLogin no  

#    PermitRootLogin yes 的意思是允许以 root 用户身份通过 SSH 登录到服务器。

# 重启 SSH 服务：
    保存文件并退出编辑器后，重启 SSH 服务以应用更改：
    systemctl restart ssh  









