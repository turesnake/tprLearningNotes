



# -5- 注册path
    打开文件:
        sudo nano ~/.bashrc
    最下方增加:
        export PATH=$PATH:/usr/local/bin/cockroach
        ---
        上面的 path 是个目录的 path;


    保存退出;
    运行以下命令以使更改立即生效：
        source ~/.bashrc

    现在, 直接尝试下:
        cockroach version 

    查看正在使用哪里的 cockroach
        which cockroach











