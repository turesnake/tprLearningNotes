# ======================================== #
#           nginx  za
# ======================================== #


# ----------------------------- #
#      全局 块
# ----------------------------- #

  
# user www-data www-data;  
    指定 Nginx 工作进程 运行的 用户 和 用户组
    语法：user <user> <group>;
    示例：user www-data;
    说明：通常设置为 www-data 或 nginx，以确保 Nginx 进程具有适当的权限。


# worker_processes auto; 
    指定 Nginx 启动的 工作进程 数量。
    语法：worker_processes <number|auto>;
    说明：可以设置为 auto，Nginx 会根据 CPU 核心数自动调整工作进程数量。


# error_log /var/log/nginx/error.log warn;  
    指定 错误日志 的 路径 和 日志级别
    语法：error_log <file> [<level>];
    说明：日志级别可以是 debug、info、notice、warn、error、crit、alert、emerg。

  
# pid /var/run/nginx.pid;  
    指定 Nginx 主进程的 PID 文件路径。
    语法：pid <file>;
    说明：用于存储 Nginx 主进程的进程 ID，便于管理。


# worker_rlimit_nofile 2048;  
    设置工作进程可以打开的最大文件描述符数量。
    语法：worker_rlimit_nofile <number>;
    说明：通常需要与 worker_connections 配合使用，以确保可以处理足够的连接。
 
# worker_connections 1024;  
    设置工作进程可以打开的最大文件描述符数量
    语法：worker_connections <number>;
    说明：连接数包括所有的 客户端连接 和 与后端服务器的连接。

# include /etc/nginx/conf.d/*.conf;     -- 包含 conf.d 目录下的所有配置文件 
    包含其他配置文件。
    语法：include <file>;
    说明：可以用于组织配置文件，将多个配置文件合并。

# daemon on;  
    指定 Nginx 是否以守护进程方式运行。
    语法：daemon on|off;
    说明：默认值为 on, 默认以守护进程方式运行，如果设置为 off，Nginx 将在前台运行。


# master_process on;  
    指定是否启用主进程。
    语法：master_process on|off;
    说明：默认值为 on，如果设置为 off，Nginx 将不使用主进程。

# env MY_ENV_VAR;  
    设置环境变量。
    语法：env <variable>;
    示例：env MY_ENV_VAR;
    说明：可以在 Nginx 配置中使用的环境变量。

 
# worker_shutdown_timeout 10s;  
    设置工作进程关闭的超时时间。
    语法：worker_shutdown_timeout <time>;
    说明：在关闭工作进程时，允许的最大时间。

# events {...}  
    # 事件处理配置块  

# http {...}
    # HTTP 配置块  




# ----------------------------- #
#      events 块
# ----------------------------- #
events 块中的指令主要用于控制 Nginx 的连接处理和事件管理。通过合理配置这些指令，可以优化 Nginx 的性能，特别是在高并发场景下。

# 一个 配置文件中, 只能配置一个 events 块;

# 完整内容罗列:
events {  
    worker_connections 1024;       # 每个工作进程最大连接数  
    use epoll;                     # 使用 epoll 事件处理模型  
    multi_accept on;               # 允许一次接受多个连接  
    accept_mutex on;               # 启用接受互斥锁  
    accept_mutex_delay 100ms;      # 设置接受互斥锁延迟  
    post_accept_timeout 10s;       # 设置接受连接后的超时时间  
}


# worker_connections：
    定义每个工作进程可以同时打开的最大连接数。
    语法：worker_connections <number>;
    示例：worker_connections 1024;

# use：
    指定 Nginx 使用的事件处理模型。
    语法：use <event_model>;
    可选的事件模型包括：
        epoll： 适用于 Linux，性能较好。
        kqueue：适用于 BSD 系统（如 FreeBSD）。
        select：较老的事件模型，性能较低。
        poll：  类似于 select，但支持更多的文件描述符。
    示例：use epoll;

# multi_accept：
    允许工作进程在一个事件循环中接受多个连接。
    语法：multi_accept on|off;
    默认值为 off，启用后可以提高高并发场景下的性能。
    示例：multi_accept on;

# accept_mutex：
    启用或禁用接受互斥锁，以控制连接的接受顺序。
    语法：accept_mutex on|off;
    启用后，可以防止多个工作进程同时接受连接，从而减少竞争。
    示例：accept_mutex on;
    
# accept_mutex_delay：
    设置接受互斥锁的延迟时间。
    语法：accept_mutex_delay <time>;
    默认值为 500ms，可以根据需要调整。
    示例：accept_mutex_delay 100ms;

# post_accept_timeout：
    设置在接受连接后，等待处理请求的超时时间。
    语法：post_accept_timeout <time>;
    示例：post_accept_timeout 10s;



# ----------------------------- #
#      http 块 中的 全局块
# ----------------------------- #




















