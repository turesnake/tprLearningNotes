
# ======================================================================= #
#             每日快速启动 本机的 ubunut nakama server
# ======================================================================= #
目的是 开发 nakama server lua scripts, 在本机上快速迭代功能;


# =================== #
#   常用指令
# =================== #



nakama_pid
nakama_stop
nakama_restart
nakama_log
nakama_delete_log

---
nakama_log
nakama_stop
nakama_restart




cd /usr/local/bin/nakama/data/modules/
code .



# -------------------------------------------------------------------- #
# -------------------------- 启动 Nakama 流程 -------------------------

# -0-
    (假定各种工具都已经安装好了. 每日开机后的快速启动流程:)


# -1- 进入 本机 ubuntu, 后台启动 cockroach
    cockroach start-single-node --insecure --listen-addr=172.21.249.213:26257 --http-port=8080 --sql-addr=172.21.249.213:26258 --background

  (我们直接使用它的默认 db: `defaultdb`)


# -2- sudo 查看 Nakama 配置文件:
  cd /usr/local/bin/nakama
  sudo nano nakama_config_1.yml

  (确保 `/usr/local/bin/nakama/nakama_config_1.yml`  中使用 defaultdb)
  (确保 `/usr/local/bin/nakama/nakama_config_1.yml`  中 logger.level 为 `info` )

  ----
  此步的目的是为了使用 sudo, 要不然后面的 .. & 操作会出问题


# -2- Nakama 迁徙 db:
  cd /usr/local/bin/nakama
  ./nakama migrate up --database.address root:@172.21.249.213:26258/defaultdb



# -3- 开启 Nakama:
    cd /usr/local/bin/nakama
    nohup sudo ./nakama --config nakama_config_1.yml &
    


# -4- 测试; 登录  http://172.21.249.213:7351


# -------------------------------------------------------------------- #
# -------------------------- 关闭 Nakama 流程 -------------------------

# -5- 删除所有 nakama 进程:
  `nakama_stop`

  内容为:
    ps aux | grep nakama | grep -v grep | awk '{print $2}' | xargs -r sudo kill -9



# -------------------------------------------------------------------- #
# -------------- 开发 Lua 脚本后 (--`新, vscode版, 推荐`--) ---------------


# -- 准备工作 (一次性)
    -- 确保 windows11 上已安装 vscode wsl 插件

    -- 开启目录写入权限
        sudo chmod -R 777 /usr/local/bin/nakama/data/modules/


# -- 直接用 vscode 打开 ubuntu 目录
  cd /usr/local/bin/nakama/data/modules/
  code .


# -------------------------------------------------------------------- #


# -- 检测 目的地 目录 是否正确:
    cd /usr/local/bin/nakama/data/modules/ 
    


# -- 重启 nakama: (`脚本版`:)
  ` nakama_restart`

    ---
    脚本写法见本文下方


# -- 重启 nakama:  (`手动版`, 不推荐)
        cd /usr/local/bin/nakama
    删除:
        ps aux | grep nakama | grep -v grep | awk '{print $2}' | xargs -r sudo kill -9 
    重启:
        nohup sudo ./nakama --config nakama_config_1.yml & 





# -------------------------------------------------------------------- #
# -------------------------- 查看 Nakama Log -------------------------

# 查看:
  `nakama_log`
  
  内容:
    nano /usr/local/bin/nakama/logfile_01.log


# 删除:
  `nakama_delete_log`

  内容:
    sudo rm -rf /usr/local/bin/nakama/logfile_01.log





# -------------------------------------------------------------------- #
# -------------- 开发 Lua 脚本后 (--`旧, 手动版, 不推荐-`-) ---------------


# -- 开发
  在 `E:\__TPR_CODE__\FishTank\Server_Luas\ForOut` 中放置需要的 lua 脚本



# -- 先清空 ForOut 目录, 后 传输整个目录的脚本:
  ssh root@172.21.249.213 'rm -rf /usr/local/bin/nakama/data/modules/ForOut' && scp -r E:\__TPR_CODE__\FishTank\Server_Luas\ForOut root@172.21.249.213:/usr/local/bin/nakama/data/modules/

  这里其实有两句话:
    ssh root@172.21.249.213 'rm -rf /usr/local/bin/nakama/data/modules/ForOut'  
    scp -r E:\__TPR_CODE__\FishTank\Server_Luas\ForOut root@172.21.249.213:/usr/local/bin/nakama/data/modules/ 



# ==================================== #
#         如何编写   restart_nakama.sh
# ==================================== #

参考 bash_脚本__0.md  文件教程, 写入如下内容:

写在 `/usr/local/bin/restart_nakama.sh`

# --- restart_nakama.sh 文件内容:

    #!/bin/bash 

    # 切换到 Nakama 目录  
    cd /usr/local/bin/nakama || exit  

    echo "Done: cd to nakama bin folder." 

    # 查找并杀掉正在运行的 Nakama 进程  (排除本 bash 进程)
    #   ps aux：列出所有运行中的进程。
    #   grep nakama：过滤出包含 "nakama" 的进程。
    #   grep -v grep：排除包含 "grep" 的行，以避免将 grep 自身包含在内。
    #   grep -v "$current_pid": 排除掉 本 bash 进程;
    #   awk '{print $2}'：提取第二列，即 PID。
    #   xargs -r sudo kill -9：将找到的 PID 传递给 kill -9 命令，强制终止这些进程。
    ps aux | grep nakama | grep -v "$current_pid" | awk '{print $2}' | xargs -r sudo kill -9 

    echo "Done: kill nakamas" 

    # 使用指定的配置文件启动 Nakama  
    nohup sudo ./nakama --config nakama_config_1.yml &  

    echo "Done: Nakama Server has been Restarted." 


# 容易出错点:
  删除进程 那一行, 容易杀不干净, 最好查看下 nakama log 确认下 有没有报错;





















