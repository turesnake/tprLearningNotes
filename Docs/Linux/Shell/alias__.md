


# -1- 打开配置文件:
    nano ~/.bashrc

# -2- 尾部添加
    alias stop_nakama='ps aux | grep nakama | grep -v grep | awk '\''{print $2}'\'' | xargs -r sudo kill -9'
    ---
    具体写法 让 ai 来转译

# -3- 保存退出后重启:
    source ~/.bashrc

# -4- 测试使用:
    stop_nakama






















