# =============================================== #
#                     ufw
# =============================================== #

UFW（Uncomplicated Firewall）是一个用于管理 iptables 防火墙的用户友好界面，主要用于简化防火墙的配置。以下是UFW的详细使用说明：

# 1. 安装 UFW:
    在大多数 Ubuntu 系统中，UFW 默认已安装。如果没有，可以通过以下命令安装：
    sudo apt install ufw  

# 2. 启用 UFW: 
    在使用 UFW 之前，需要先启用它：
    sudo ufw enable  

    启用后，UFW会开始应用默认的规则。

# 3. 查看 UFW 状态:
    要查看UFW的当前状态和规则，可以使用：
    sudo ufw status  

    如果想要查看更详细的信息，可以使用：
    sudo ufw status verbose  

# 4. 允许或拒绝流量
    允许特定端口（例如，允许SSH流量）：
    sudo ufw allow ssh  

    或者指定端口号：
    sudo ufw allow 22 

    拒绝特定端口：
    sudo ufw deny 23  

    允许特定IP地址的流量：
    sudo ufw allow from 192.168.1.100  

    允许特定IP地址访问特定端口：
    sudo ufw allow from 192.168.1.100 to any port 80  

# 5. 删除规则
    如果需要删除某个规则，可以使用：
    sudo ufw delete allow 22  
    
    或者
    sudo ufw delete deny 23  

6. 其他常用命令

# 禁用UFW：
    sudo ufw disable  

# 重置UFW（删除所有规则）：
    sudo ufw reset  

# 查看帮助：
    ufw --help  

7. 进阶配置
UFW还支持更复杂的配置，例如：

# 限制连接（例如，限制SSH连接尝试）：
    sudo ufw limit ssh  

# 使用应用程序配置：
    UFW可以识别已安装的应用程序并允许或拒绝它们的流量。例如：
    sudo ufw app list  
    sudo ufw allow 'Nginx Full'  

8. 日志记录
# 可以启用UFW的日志记录，以便监控流量：
    sudo ufw logging on  

    日志文件通常位于 /var/log/ufw.log

总结:
    UFW是一个强大的工具，可以帮助用户轻松管理防火墙规则。通过上述命令，您可以有效地控制进出系统的流量，增强系统的安全性。






# ----------------------------------------- #
#      将 ssh 端口从 22 改成 2666
# ----------------------------------------- #

要在 Ubuntu 中将 SSH 的端口修改为 2666 ，并在 UFW 中进行相应的配置，你可以按照以下步骤操作：

修改 SSH 配置文件：

# 打开 SSH 配置文件：
    sudo nano /etc/ssh/sshd_config  
    
    找到 #Port 22 行，将其修改为 Port 2666 。如果这一行被注释掉了（前面有 #），请去掉注释。
    保存并退出编辑器（在 nano 中，按 Ctrl + X，然后按 Y 确认保存）。

# 更新 UFW 规则：
    首先，允许新的 SSH 端口 2666 ：
    sudo ufw allow 2666/tcp  

    然后，删除默认的 SSH 端口 22 的规则（如果你不再需要它）：
    sudo ufw delete allow 22/tcp  
    
    重启 SSH 服务：
    sudo systemctl restart ssh  

# 检查 UFW 状态：
    确保新的端口规则已生效：
    sudo ufw status  

# 测试新的 SSH 端口：
    在更改生效后，使用新的端口 2666 进行 SSH 连接测试：
    ssh -p 2666 username@your-server-ip  

请确保在更改 SSH 端口之前，你有其他方式访问服务器（例如，通过控制台访问），以防止由于配置错误而无法连接。
















