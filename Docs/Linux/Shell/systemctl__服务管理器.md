
systemd 用于启动和管理 系统服务、处理 系统启动过程、管理系统状态 等。以下是一些基本的 systemd 使用方法：



# sudo systemctl start nginx
    启动服务

# sudo systemctl stop nginx
    停止服务

# sudo systemctl restart nginx 
    重启服务

# sudo systemctl status uginx
    查看服务状态

# sudo systemctl enable nginx
# sudo systemctl disable nginx
    启用服务（开机自启动）
    禁用服务（不再开机自启动）

# sudo systemctl list-units --type=service
    查看所有服务

# journalctl -u nginx
    查看服务的日志



# sudo systemctl daemon-reload
    重新加载 `systemd` 配置

# sudo systemctl poweroff
    关闭系统

# sudo systemctl reboot
    重启系统



# 创建自定义服务
    要创建自定义服务，可以创建一个 `.service` 文件，通常放在 `/etc/systemd/system/` 目录下。以下是一个简单的示例：

```ini
[Unit]
Description=My Custom Service

[Service]
ExecStart=/usr/bin/my-custom-script.sh

[Install]
WantedBy=multi-user.target
```


创建后，使用以下命令重新加载 `systemd` 配置：
```bash
sudo systemctl daemon-reload
```
然后可以启动和启用该服务：
```bash
sudo systemctl start my-custom-service
sudo systemctl enable my-custom-service
```













































