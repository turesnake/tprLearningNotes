

Nakama 是由 Heroic Labs 开发的开源后端服务器，专为游戏和应用程序设计，提供了强大的实时功能和社交功能。
它可以与 Unity 无缝集成，为开发者提供一个灵活且可扩展的解决方案。以下是 Nakama 的一些关键特性和功能：



# 官网:
https://heroiclabs.com/docs/nakama/client-libraries/unity/#full-api-documentation

https://heroiclabs.com/docs/nakama/getting-started/




# ================================================= #
#     -1- 在 ubuntu server 中直接安装 nakam
# ================================================= #


# -------------------------------------- #
# -1-
    按照文档 cockroach__0_.md 的流程, 先安装好 cockroach 数据库

# -------------------------------------- #
# -2-
    下载文件:
    https://github.com/heroiclabs/nakama/releases
    下载
        nakama-3.24.2-linux-amd64.tar.gz
    将其放入 win11 的 D:\_server_cactus\ 中

# -------------------------------------- #
# -3-
    将这个文件 scp 传输到 ubuntu server 上去:
    scp -r D:\_server_cactus\nakama-3.24.2-linux-amd64.tar.gz tapir@1.1.1.1:/home/tapir/tmp/


# -------------------------------------- #
# -4- 安装目录: /usr/local/bin/nakama
    进入 ubuntu server, 新建目录:
        sudo mkdir /usr/local/bin/nakama

    cd ~/tmp/

    sudo cp nakama-3.24.2-linux-amd64.tar.gz /usr/local/bin/nakama

    cd /usr/local/bin/nakama

    sudo tar -xzvf nakama-3.24.2-linux-amd64.tar.gz


# -------------------------------------- #
# -5-
    把 nakama 注册到全局 path 上去...


# -------------------------------------- #
# -6-
    启动 cockroach 数据库, 目前按照 cockroach__0_.md 里的试验流程走的;
    这个 数据库的配置如下:
        CockroachDB node starting at 2024-10-26 07:12:39.883169814 +0000 UTC m=+1.254234134 (took 0.8s)
        build:               CCL v24.2.4 @ 2024/10/14 17:20:56 (go1.22.5 X:nocoverageredesign)
        webui:               http://172.21.249.213:8080
        sql:                 postgresql://root@172.21.249.213:26258/defaultdb?sslmode=disable
        sql (JDBC):          jdbc:postgresql://172.21.249.213:26258/defaultdb?sslmode=disable&user=root
        RPC client flags:    cockroach <client cmd> --host=172.21.249.213:26257 --insecure
        logs:                /home/tapir/t3_dbtest/cockroach-data/logs
        temp dir:            /home/tapir/t3_dbtest/cockroach-data/cockroach-temp1680688590
        external I/O path:   /home/tapir/t3_dbtest/cockroach-data/extern
        store[0]:            path=/home/tapir/t3_dbtest/cockroach-data
        storage engine:      pebble
        clusterID:           a0c6ec01-e63d-4ddc-aeb4-54453052432f
        status:              restarted pre-existing node
        nodeID:              1
        ------

    有用的信息如下:
        CockroachDB 正在运行在 IP 地址 172.21.249.213，使用的 PostgreSQL 兼容模式，监听的端口为 26258。
        你还提到了使用 postgres:password@127.0.0.1:5432，这是一个 PostgreSQL 的连接字符串。要将其更改为指向你的 CockroachDB 实例，


# -------------------------------------- #
# -7- Nakama migrations  迁徙
    cd /usr/local/bin/nakama
        进入 nakama 程序所在目录;

    ./nakama migrate up --database.address root:@172.21.249.213:26258/defaultdb
        基于上文的 数据库信息, 执行数据迁徙
        --- 记得更换最后的 /defaultdb 为 你指定的 databace instance name;

    运行成功, 得到了:
        {
            "level":"info",
            "ts":"2024-10-26T16:07:03.061+0800",
            "caller":"server/db.go:140",
            "msg":"Database information",
            "version":"CockroachDB CCL v24.2.4 (x86_64-pc-linux-gnu, built 2024/10/14 17:20:56, go1.22.5 X:nocoverageredesign)"
        }
        {
            "level":"info",
            "ts":"2024-10-26T16:07:03.061+0800",
            "caller":"migrate/migrate.go:109",
            "msg":"Applying database migrations",       这条日志表示 Nakama 正在应用数据库迁移。一些库和框架在应用更改（如模式更改、表的增加等）时使用迁移。
            "limit":-1                                  limit: 这个参数的值是 -1，表示没有限制应用的迁移数量。
        }
        {
            "level":"info",
            "ts":"2024-10-26T16:07:05.692+0800",
            "caller":"migrate/migrate.go:116",
            "msg":"Successfully applied migration",
            "count":14                                  count: 显示成功应用的迁移数量，这里为 14，表示一共成功执行了 14 次数据库迁移。
        }

    你的命令行操作成功地连接到了 CockroachDB 数据库，并执行了所需的迁移，升级了数据库的结构到要支持 Nakama 的最新版本。
    这是成功设置 Nakama 服务器的一步重要过程，接下来你可以继续配置和使用 Nakama 进行开发或服务。


# -------------------------------------- #
# -8-  启动(start) Nakama server     -- (不推荐)
#      临时指令版, 非配置版

测试版:
    sudo ./nakama --database.address "root:@172.21.249.213:26258/defaultdb" --console.username "tapir" --console.password "tapir12345"


    这个启动是在 前端启动的, 
        -- 可用 Ctrl + C 退出本次启动的程序
        -- 前方加 nohup 来改为 后团启动;

后台版:
    sudo nohup ./nakama --database.address "root:@172.21.249.213:26258/defaultdb" --console.username "tapir" --console.password "tapir12345"

    得到信息有:
        ...

        每个组件的启动日志，显示服务端口，包括：
            gRPC 请求的 API 服务器（端口 7349）
            HTTP 请求的 API 服务器（端口 7350）
            gRPC 请求的控制台服务器（端口 7348）
            HTTP 请求的控制台服务器（端口 7351）        -- 可用 浏览器访问

        从这些信息来看，Nakama 已经成功启动并可以接受请求。你可以通过以下方式进行连接和测试：

            API 端点: 访问 http://172.21.249.213:7350 用于 HTTP 请求。
            控制台: 访问控制台的 gRPC 和 HTTP 服务，通常使用默认的端口 7348 和 7351。

    后续步骤
        修改默认参数: 为了安全起见，建议你对提到的默认参数（例如控制台的用户名和密码等）进行更改。
        测试服务: 通过发送 API 请求来确认 Nakama 的功能是否正常工作。
        查看日志: 监控运行中的 Nakama 日志，确保没有错误并且服务持续稳定运行。


# -------------------------------------- #
# -8-  启动(start) Nakama server 
#      正式 config.yml 配置版

# 配置文件 具体教程:
https://heroiclabs.com/docs/nakama/getting-started/configuration/


    cd /usr/local/bin/nakama
        进入 nakama 程序所在目录;

    sudo nano nakama_config_1.yml
        新建这个配置文件, 然后把本目录下 nakama_config_示范.yml 文件的内容适当修改后, 复制进去


# -- 写法 -1-:    (-不推荐-)
    sudo nohup ./nakama --config nakama_config_1.yml > /home/tapir/nakama_logs/nakama.log 2>&1 &
        通过配置文件启动 nakama;
        nohup 意味着退出console 后程序依然运行
        & 表示后台运行
        > nakama.log: 将标准输出重定向到 nakama.log 文件。
        2>&1: 将标准错误输出也重定向到同一个文件。 (不是整个 nakama 的log, 仅仅是这句指令引发的log)

# -- 写法 -2-:    (-推荐-)
    nohup sudo ./nakama --config nakama_config_1.yml &  
        
        

# 如何删除这些 进程:
    找到它们的 pid:
        ps aux | grep nakama

    使用 kill 杀死它们:
        sudo kill -9 xxx1 xxx2

    
# 快捷删除:  (推荐)
    ps aux | grep nakama | grep -v grep | awk '{print $2}' | xargs -r sudo kill -9  

    一行指令 完成整个删除工作:
        ps aux：列出所有运行中的进程。
        grep nakama：过滤出包含 "nakama" 的进程。
        grep -v grep：排除包含 "grep" 的行，以避免将 grep 自身包含在内。
        awk '{print $2}'：提取第二列，即 PID。
        xargs -r sudo kill -9：将找到的 PID 传递给 kill -9 命令，强制终止这些进程。




# -------------------------------------- #
# -9- 一切成功, 可通过控制台访问了
    登录  http://172.21.249.213:7351  
    然后输入账号密码:
        tapir
        xxxxxxx




# ============================================ #
#                  oths
# ============================================ #


# 小游戏
https://heroiclabs.com/docs/nakama/tutorials/unity/fishgame/index.html



























