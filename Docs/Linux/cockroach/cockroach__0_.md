cockroach
CockroachDB 是一个开源的分布式数据库，旨在提供高可用性、水平扩展性和强一致性。它的设计灵感来自 Google 的 Spanner 数据库，主要用于处理大规模的数据存储和事务处理。

unity 网络插件 Nakama 需要用到 Cockroach, 所以我们就装一个:



# ============================================ #
#                  安装
# ============================================ #

# 安装教程
https://www.cockroachlabs.com/docs/v24.2/install-cockroachdb-linux


# -1-  
    按照上面教程, 到: https://www.cockroachlabs.com/docs/releases/ 下载一个 Full Binary 压缩包: 
    cockroach-v24.2.4.linux-amd64.tgz
    将其放入 win11 的 D:\_server_cactus\ 中

# -2-
    将这个文件 scp 传输到 ubuntu server 上去:
    scp -r D:\_server_cactus\cockroach-v24.2.4.linux-amd64.tgz tapir@1.1.1.1:/home/tapir/tmp/

# -3-
    进入 ubuntu server, 新建目录:
        sudo mkdir /usr/local/bin/cockroach

    将压缩包 移动到这里:
        sudo mv cockroach-v24.2.4.linux-amd64.tgz /usr/local/bin/cockroach

        cd /usr/local/bin/cockroach

    解压缩:
        sudo tar -xzvf cockroach-v24.2.4.linux-amd64.tgz

    现在, 这个目录里得到了一个名为 cockroach-v24.2.4.linux-amd64 的目录
    将其名字改短些
        sudo mv cockroach-v24.2.4.linux-amd64 src  

    进入这个目录下, 尝试下这个 bin 文件是否正常:
        cd src
        ./cockroach version

    如果能运行, 就是ok的

# -4- 将这些文件 移出 src 目录 (到上层)
    sudo mv LICENSE.txt ../
    sudo mv THIRD-PARTY-NOTICES.txt ../
    sudo mv cockroach ../
    sudo mv lib ../


# -4- 移动 动态库文件
    cd lib
    sudo mkdir /usr/local/lib/cockroach/
    sudo cp -i libgeos.so /usr/local/lib/cockroach/
    sudo cp -i libgeos_c.so /usr/local/lib/cockroach/


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




# ============================================ #
#       初始化 节点证书 等
# ============================================ #

# -1-
    mkdir -p /home/tapir/.config/cockroach

    cockroach cert create-ca --certs-dir=/home/tapir/.config/cockroach --ca-key=/home/tapir/.config/cockroach/ca.key --overwrite

    hostname -I
        得到本 server ip: 1.1.1.1

    cockroach cert create-node 1.1.1.1 --certs-dir=/home/tapir/.config/cockroach --ca-key=/home/tapir/.config/cockroach/ca.key --overwrite

    (ip 也可用 localhost)

# -2-
    现在, /home/tapir/.config/cockroach/ 目录下已经拥有:
        ca.crt      -- CA 证书
        ca.key
        node.crt    -- 节点证书
        node.key    -- 节点密钥

    
    生成客户端证书（如果未生成）：
    如果没有 client.root.crt 和 client.root.key 文件，你需要为 root 用户生成客户端证书

        cockroach cert create-client root --certs-dir=/home/tapir/.config/cockroach --ca-key=/home/tapir/.config/cockroach/ca.key --overwrite

    现在, 目录中又多了:
        client.root.crt
        client.root.key

# -3- 启动 CockroachDB   (不要这么写... )
    确保 CockroachDB 实例正在运行。可以通过以下命令启动 CockroachDB
        
    cockroach start --certs-dir=/home/tapir/.config/cockroach --advertise-addr=172.21.249.213 --join=172.21.249.213:26257 --background

    --advertise-addr: 这是节点在集群中报告的地址。
    --join: 如果这是一个新节点并且需要加入的集群，请使用此选项。如果你是第一个节点，您可以省略该选项。


# -4- 检查防火墙
    检查端口是否监听
        netstat -tuln | grep 26257

# -5- init:  (不要这么写... )
    cockroach init --certs-dir=/home/tapir/.config/cockroach --host=172.21.249.213:26257

    会得到 Cluster successfully initialized



# ============================================ #
#             开始使用
# ============================================ #





# ============================================ #
#                  指令
# ============================================ #

# 指令指南
https://www.cockroachlabs.com/docs/v24.2/cockroach-commands


# ps -ef|grep cockroach
    查看是否有正在运行的 cockroach 程序


# sudo lsof -i :26257
    显示当前正在使用 26257 端口的进程信息

# netstat -tuln | grep 26257
    检查端口是否监听



# ---------------------------------- #
#    cockroach start     (在 init 之前执行)
# ---------------------------------- #
功能: 启动 CockroachDB 服务器。
用途: 该命令用于启动一个 CockroachDB 实例，可以是 单节点 或 多节点集群。它会监听指定的 地址 和 端口，接受客户端连接。
参数: 可以使用多个参数来配置服务器的行为，例如 --insecure（不使用 TLS）、--listen-addr（指定监听地址和端口）等。

# cockroach start --insecure --listen-addr=172.21.249.213:26257 --http-port=8080

这条命令启动了一个不安全的 CockroachDB 实例，监听本地的 26257 端口用于数据库连接，同时在 8080 端口提供 HTTP 服务以便于管理和监控。

    start: 这是一个子命令，用于启动 CockroachDB 实例。

    --insecure: 这个标志表示以不安全的模式启动数据库。在不安全模式下，CockroachDB 不会使用 TLS 加密连接，这在开发和测试环境中是常见的做法，但在生产环境中不推荐使用。

    --listen-addr=localhost:26257: 这个选项指定了 CockroachDB 实例监听的地址和端口。在这里，localhost 表示数据库将只接受来自本地计算机的连接，
        而 26257 是 CockroachDB 的默认端口。其他机器无法通过网络访问这个数据库实例。

    --http-port=8080: 这个选项指定了 CockroachDB 的 HTTP 服务监听的端口。在这里，8080 是用于访问 CockroachDB 的 Web 界面的端口。用户可以通过浏览器访问 http://localhost:8080 来查看数据库的状态和管理界面。


# 异常:
    CockroachDB 实例时没有提供 --join 标志。--join 标志用于指定其他 CockroachDB 节点的地址，以便新启动的节点能够加入到现有的集群中。
    在 CockroachDB 中，节点之间需要通过 --join 标志来建立连接，以便它们能够相互识别并形成一个集群;

    如果你是在单节点模式下运行 CockroachDB（例如在开发或测试环境中），可以使用下方的 start-single-node


# ---------------------------------- #
#    cockroach start-single-node     (在 init 之前执行)
# ---------------------------------- #

https://www.cockroachlabs.com/docs/v24.2/cockroach-start-single-node


# 测试版:
# cockroach start-single-node --insecure --listen-addr=172.21.249.213:26257 --http-port=8080 --sql-addr=172.21.249.213:26258

    注意, --listen-addr 和 --sql-addr 要使用两个不同的端口

    现在这是在前台执行; 如果想在后台执行, 可(1)在指令末尾添加 " &";  也可在尾部使用 --background

    想要退出, 可直接 Ctrl+C，这将发送中断信号，停止 CockroachDB 的运行。

# 后台版:
# cockroach start-single-node --insecure --listen-addr=172.21.249.213:26257 --http-port=8080 --sql-addr=172.21.249.213:26258 --background



如果成功, 会得到:
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



# ---------------------------------- #
#    cockroach init     (在 start 之后执行)
# ---------------------------------- #
功能: 初始化一个新的 CockroachDB 集群。
用途: 该命令用于在 集群 中创建系统数据库 和 初始化元数据。通常在启动一个新的集群时使用，尤其是在多节点环境中。
前提条件: 在执行 cockroach init 之前，必须至少有一个 CockroachDB 实例正在运行（通常是通过 cockroach start 启动的）。

# cockroach init --insecure --host=172.21.249.213:26257

    但是在我执行了上了 cockroach start-single-node 之后, 直接执行本指令, 会得到: 
        ERROR: cluster has already been initialized
        Failed running "init"


# ---------------------------------- #
#    cockroach sql
# ---------------------------------- #

开启一个 SQL 接口，允许用户通过 SQL 语句与数据库进行交互

# cockroach sql --insecure --host=172.21.249.213:26258
    注意这里的 port 是上面的 --sql-addr 里的那个 !!!

    此时你会发现你进入了 sql 命令行状态;   (输入 \q 可以退出)

    具体指令, 可以查看 cockroach_sql.md 内的内容;


# CREATE DATABASE db_nakama;
    新建一个 db 实例, 为 nakama 所用;      







