








# ===================================================== #
#     如何 在 Ubuntu 中开启 22 端口  (通常用于 SSH 服务)
# ===================================================== #

gpt:
在 server shell 上:
-1- 安装 OpenSSH 服务器（如果尚未安装）：
    sudo apt update  
    sudo apt install openssh-server  

-2- 检查 SSH 服务状态：
    确保 SSH 服务正在运行：
    sudo systemctl status ssh  

-3- 开启防火墙的 22 端口：
    如果你使用 ufw（Uncomplicated Firewall），可以通过以下命令允许 22 端口：
    sudo ufw allow 22  

    或者，你也可以使用更具体的命令：
    sudo ufw allow ssh  

-4- 启用防火墙（如果尚未启用）：
    sudo ufw enable  

-5- 检查防火墙状态：
    确认 22 端口已被允许：
    sudo ufw status  

-6- 防火墙允许 ssh 连接
    sudo ufw allow ssh


完成以上步骤后，22 端口应该已经开启，可以通过 SSH 进行远程连接。








# =============================== #
#      杂乱指令 罗列:
# =============================== #





# 
sudo apt install openssh-server




# 登出
logout


# 更新 软件包列表
sudo apt update  


# 升级已安装的软件包：
sudo apt upgrade  


# 安装软件: 如 nginx
sudo apt install nginx  


# 启动服务, 如 nginx
sudo systemctl start nginx  

# 停止服务,
sudo systemctl stop nginx  


# 重启服务:
sudo systemctl restart nginx  

# 查看服务状况
sudo systemctl status nginx  



# 添加新用户
sudo adduser username 

# 删除用户
sudo deluser username  


# ping 网络连接
ping www.baidu.com

ctl + c 来终止;



# 查看当前内存使用情况
free -h


# 复制文件：
cp source_file destination_file  


# 移动文件：
mv source_file destination_file 


# 删除文件
rm filename  


























