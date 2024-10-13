# ======================================== #
#                 scp
# ======================================== #

scp（Secure Copy Protocol


# 基本语法
    scp [options] [source] [destination]  

# 常用选项
#  -r：递归复制整个目录。
    示例：
    scp -r username@server_ip:/path/to/remote/directory /path/to/local/destination  

#  -P port：指定 SSH 连接的端口（注意是大写的 P）。
    示例：
    scp -P 2222 username@server_ip:/path/to/remote/file /path/to/local/destination  

#  -i identity_file：指定用于身份验证的私钥文件。
    示例：
    scp -i /path/to/private/key username@server_ip:/path/to/remote/file /path/to/local/destination  

#  -v：详细模式，显示调试信息，适用于调试连接问题。
    示例：
    scp -v username@server_ip:/path/to/remote/file /path/to/local/destination  

#  -C：启用压缩，适用于大文件传输，可以加快传输速度。
    示例：
    scp -C username@server_ip:/path/to/remote/file /path/to/local/destination  

# 常用命令示例:
#  从远程服务器复制文件到本地：
    scp username@server_ip:/path/to/remote/file /path/to/local/destination  

#  从本地复制文件到远程服务器：
    scp /path/to/local/file username@server_ip:/path/to/remote/destination  

#  递归复制整个目录到远程服务器：
    scp -r /path/to/local/directory username@server_ip:/path/to/remote/destination  

#  从远程服务器复制整个目录到本地：
    scp -r username@server_ip:/path/to/remote/directory /path/to/local/destination  

#  使用指定的 SSH 端口复制文件：
    scp -P 2222 username@server_ip:/path/to/remote/file /path/to/local/destination  

# -------------
注意事项
- 确保您有权限访问远程服务器和文件。
- 如果使用 SSH 密钥进行身份验证，请确保密钥文件的权限设置正确（通常为 600）。
- scp 命令在传输过程中会加密数据，确保安全性。































