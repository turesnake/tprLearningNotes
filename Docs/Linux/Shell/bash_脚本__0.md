
# -------------------------------------------- #
#       如何写 全局 bash 脚本
# -------------------------------------------- #


# -- 直接在 /usr/local/bin/ 中新建 .sh 文件:
    sudo nano /usr/local/bin/xxxx.sh

    --- 
    sudo 是因为 /usr/local/bin/ 这个目录需要权限


# -- 在 .sh 文件里写入内容:
    
#!/bin/bash 
echo "Call bash script: xxxx." 

    ---
    保存文件


# -- 给文件 开通 执行权限:
    sudo chmod a+x /usr/local/bin/xxxx.sh

    ---
    a+x  会给所有用户开通 执行权限


# -- 在任何位置调用
    xxxx.sh


# -- 检查 这个 脚本的位置
    which xxxx.sh
















