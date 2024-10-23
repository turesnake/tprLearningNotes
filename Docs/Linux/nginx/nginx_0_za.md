# ======================================== #
#           nginx  za
# ======================================== #



# 官网文档
https://nginx.org/en/docs/




`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#                常用指令
# =========================================== #



# sudo systemctl start nginx
# sudo systemctl stop nginx
#  sudo systemctl restart nginx 
    启动服务
    停止服务
    重启服务

# sudo systemctl status nginx 
# sudo systemctl status nginx.service
    查看服务状况
    ---
    上面两句话是 等效的;
    nginx 是服务的简写名称，systemctl 会自动将其解析为 nginx.service

# sudo nginx -t
    检测配置文件内容是否正确

# sudo journalctl -u nginx
    check the nginx error logs

# sudo systemctl enable nginx
    将 nginx 加入 开机启动项     -- enable it to start automatically on boot

# sudo systemctl disable nginx
    将 nginx 移出 开机启动项
    

# sudo lsof -i :80
    显示当前正在使用 80 端口的进程信息


# sudo netstat -tuln | grep :80
# sudo ss -tuln | grep :80


# ps aux | grep nginx
# ps -ef|grep nginx             -- 更实用点...
    显示与 nginx 相关的进程信息
    这个命令会列出所有与 nginx 相关的进程，包括主进程和工作进程。
    ---
    两句话的区别:
        a：显示所有用户的进程，包括其他用户的进程。
        u：以用户为中心的格式显示进程信息，包括用户、CPU 和内存使用情况等。
        x：显示没有控制终端的进程。

        输出格式
        -e：显示所有进程。
        -f：以完整格式显示进程信息，包括 UID、PID、PPID、C、STIME、TTY、TIME 和 CMD



# sudo lsof -c nginx
    使用 lsof 命令查看打开的文件和网络连接：
    会列出所有与 nginx 相关的打开文件和网络连接



# nginx -V
nginx version: nginx/1.18.0 (Ubuntu)
built with OpenSSL 3.0.2 15 Mar 2022
TLS SNI support enabled
configure arguments: --with-cc-opt='-g -O2 -ffile-prefix-map=/build/nginx-dSlJVq/nginx-1.18.0=. -flto=auto -ffat-lto-objects -flto=auto -ffat-lto-objects -fstack-protector-strong -Wformat -Werror=format-security -fPIC -Wdate-time -D_FORTIFY_SOURCE=2' --with-ld-opt='-Wl,-Bsymbolic-functions -flto=auto -ffat-lto-objects -flto=auto -Wl,-z,relro -Wl,-z,now -fPIC' --prefix=/usr/share/nginx --conf-path=/etc/nginx/nginx.conf --http-log-path=/var/log/nginx/access.log --error-log-path=/var/log/nginx/error.log --lock-path=/var/lock/nginx.lock --pid-path=/run/nginx.pid --modules-path=/usr/lib/nginx/modules --http-client-body-temp-path=/var/lib/nginx/body --http-fastcgi-temp-path=/var/lib/nginx/fastcgi --http-proxy-temp-path=/var/lib/nginx/proxy --http-scgi-temp-path=/var/lib/nginx/scgi --http-uwsgi-temp-path=/var/lib/nginx/uwsgi --with-compat --with-debug --with-pcre-jit --with-http_ssl_module --with-http_stub_status_module --with-http_realip_module --with-http_auth_request_module --with-http_v2_module --with-http_dav_module --with-http_slice_module --with-threads --add-dynamic-module=/build/nginx-dSlJVq/nginx-1.18.0/debian/modules/http-geoip2 --with-http_addition_module --with-http_gunzip_module --with-http_gzip_static_module --with-http_sub_module

    可以看到有关你正在使用的 Nginx 版本及其构建选项的详细信息

Nginx 版本信息
    版本: nginx/1.18.0 (Ubuntu)
    构建日期: 使用了 OpenSSL 3.0.2（日期：2022年3月15日）
    TLS SNI 支持: 已启用

配置参数
以下是 Nginx 在编译时使用的配置选项：

基本路径和文件:
    `nginx 安装目录`:   /usr/share/nginx                -- !!!!
    `配置文件路径`:     /etc/nginx/nginx.conf           -- !!!
    HTTP 日志路径:      /var/log/nginx/access.log
    错误日志路径:       /var/log/nginx/error.log
    PID 文件路径:       /run/nginx.pid
    模块路径:           /usr/lib/nginx/modules


临时文件路径:
    HTTP 客户端主体临时路径:     /var/lib/nginx/body
    HTTP FastCGI 临时路径:      /var/lib/nginx/fastcgi
    HTTP 代理临时路径:          /var/lib/nginx/proxy
    HTTP SCGI 临时路径:         /var/lib/nginx/scgi
    HTTP uWSGI 临时路径:        /var/lib/nginx/uwsgi

编译选项:
    启用了调试信息：            --with-debug
    启用了 PCRE JIT 支持：      --with-pcre-jit
    启用了多种模块支持，包括 SSL 模块、HTTP 状态模块、真实 IP 模块、HTTP/2 支持、HTTP Davioc 错误报告、HTTP 切片模块等。

常用功能
    SSL 支持:   --with-http_ssl_module 使 Nginx 能够处理 HTTPS 请求。
    状态和统计: --with-http_stub_status_module 用于监控 Nginx 状态。
    线程支持:   --with-threads 使 Nginx 能够在多线程环境中运行。



`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#        配置文件  自动改回默认内容
# =========================================== #
发现了这个现象, 但暂时不知道具体原因



# 粗暴解决方案
    查收所有 nginx 进程 pid:  
        ps -ef|grep nginx

    粗暴地把这些进程都杀死
        sudo kill -9 1111 1112 1113





`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#                全局 块
# =========================================== #

  
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



`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#              events 块
# =========================================== #
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



`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#            http 块 中的 全局块
# =========================================== #



# include:          包含其他配置文件。
    include /etc/nginx/mime.types;
    可以使⽤include指令引⼊其他配置⽂件



# default_type:         设置默认的 MIME 类型。
    default_type application/octet-stream;
    默认类型，如果请求的URL没有包含⽂件类型，会使⽤默认类型



# log_format:           定义日志格式。
    log_format main '$remote_addr - $remote_user [$time_local] 
        "$request" '
        '$status $body_bytes_sent "$http_referer" '
        '"$http_user_agent" "$http_x_forwarded_for"';


# access_log:       设置访问日志文件。
    access_log /var/log/nginx/access.log main;
    access_log ⽇志存放路径和类型
    格式为：access_log <path> [format [buffer=size] [gzip[=level]] [flush=time] [if=condition]];


# error_log:        设置错误日志文件。



# sendfile          开启⾼效⽂件传输模式
    sendfile on;


# sendfile_max_chunk     设置sendfile最⼤传输⽚段⼤⼩，默认为0，表示不限制
    sendfile_max_chunk 1m;




# -------------------------------- #
#         服务器块:
# --------------------------------

# server:       定义一个虚拟服务器块，可以包含多个 server 指令。
    server {}
    具体见下方 段落


# -------------------------------- #
#         负载均衡:
# --------------------------------

# upstream:         定义上游服务器组，用于负载均衡。
    具体见下方 段落


# -------------------------------- #
#         请求处理:
# --------------------------------

# client_max_body_size:         设置客户端请求体的最大大小。


# keepalive_timeout:        设置保持连接的超时时间。
    keepalive_timeout 65;

# keepalive_requests        每个连接的请求次数
    keepalive_requests 100;


# send_timeout:         设置发送响应的超时时间。





# -------------------------------- #
#         缓存配置:
# --------------------------------

# proxy_cache_path:         定义缓存路径和参数。
    proxy_cache_path /var/cache/nginx/proxy_cache levels=1:2 keys_zone=my_cache:10m max_size=1g inactive=60m use_temp_path=off;  



# -------------------------------- #
#         Gzip 压缩:
# --------------------------------


# gzip:         启用 Gzip 压缩。
    gzip on;


# gzip_types:       置需要压缩的 MIME 类型。
    gzip_types text/plain application/javascript application/x-javascript text/css application/xml text/javascript application/x-httpd-php image/jpeg image/gif image/png;
    gzip压缩⽂件类型


# gzip_min_length
    gzip_min_length 1k;
    开启 gzip 压缩的最⼩⽂件⼤⼩


# gzip_comp_level       压缩级别
    gzip_comp_level 2;
    gzip压缩级别，1-9，级别越⾼压缩率越⾼，但是消耗CPU资源也越多




# -------------------------------- #
#         CORS 配置:
# --------------------------------

# add_header:       添加 HTTP 响应头，例如 CORS 相关的头部。


# -------------------------------- #
#         SSL/TLS 配置:
# --------------------------------

# ssl_certificate:      设置 SSL 证书文件。

# ssl_certificate_key:      设置 SSL 证书密钥文件。


# -------------------------------- #
#         错误页面:
# --------------------------------

# error_page:       自定义错误页面。



# -------------------------------- #
#         重定向和重写:
# --------------------------------

# rewrite:      URL 重写规则。

# return:       返回特定的 HTTP 状态码或重定向。


# -------------------------------- #
#         限制和安全:
# --------------------------------

# limit_conn:       限制连接数。

# limit_req:        限制请求速率。


# try_files:        尝试访问文件或目录。




`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#        http: upstream 块
# =========================================== #
upstream指令⽤于定义⼀组服务器，⼀般⽤来配置反向代理和负载均衡


upstream www.example.com 
{
    ip_hash;
    server 192.168.50.11:80 weight=3;
    server 192.168.50.12:80;
    server 192.168.50.13:80;
}

 
# ip_hash
    ip_hash指令⽤于设置负载均衡的⽅式，ip_hash表示使⽤客户端的IP进⾏hash，
    这样可以保证同⼀个客户端的请求每次都会分配到同⼀个服务器，解决了session共享的问题


# server
    server 192.168.50.12:80;
    weight ⽤于设置权重，权重越⾼被分配到的⼏率越⼤


`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#        http: server 块
# =========================================== #
server块是配置虚拟主机的，⼀个http块可以包含多个server块，每个server块就是⼀个虚拟主机。


# 例子:
server 
{
    listen 80;
    server_name localhost;
    
    location / {
        root /usr/share/nginx/html; # 根⽬录
        index index.html index.htm; # 默认⽂件
    }
    
    error_page 500 502 503 504 /50x.html; # 错误⻚⾯

    location = /50x.html {
        root /usr/share/nginx/html;
    }
}


# listen 80;
    监听 IP 和 端⼝;
    格式为：
        listen [ip]:port [default_server] [ssl] [http2] [spdy] [proxy_protocol] [setfib=number] [fastopen=number] [backlog=number];
    
    listen指令⾮常灵活，可以指定多个IP和端⼝，也可以使⽤通配符

    下⾯是⼏个实际的例⼦：
        listen 127.0.0.1:80;    # 监听来⾃ 127.0.0.1 的 80 端⼝的请求
        listen 80;              # 监听来⾃所有 IP 的 80 端⼝的请求
        listen *:80;            # 监听来⾃所有 IP 的 80 端⼝的请求，同上
        listen 127.0.0.1;       # 监听来⾃来⾃ 127.0.0.1 的 80 端⼝，因为默认端⼝为 80;  (不写端口就意味着使用默认端口)


# server_name localhost;
    ⽤来指定 虚拟主机 的 域名，可以使⽤ 精确匹配、通配符匹配 和 正则匹配等⽅式

        server_name example.org www.example.org;    # 精确匹配
        server_name *.example.org;                  # 通配符匹配
        server_name ~^www\d+\.example\.net$;        # 正则匹配

# location {...}
    见下方段落;

# error_page
    ⽤于指定错误⻚⾯，可以指定多个，按照优先级从⾼到低依次查找

    error_page 500 502 503 504 /50x.html;   # 错误⻚⾯




`++++++++++++++++++++++++++++++++++++++++++++`
# =========================================== #
#        http: server 块: location块
# =========================================== #
定义请求的处理规则。

# 例子:
location = / 
{  
    root /var/www/html;  
    index index.html;  
} 

location ~ \.php$ 
{  
    include fastcgi_params;  
    fastcgi_pass 127.0.0.1:9000;  
    fastcgi_index index.php;  
    fastcgi_param SCRIPT_FILENAME $document_root$fastcgi_script_name;  
}   

location /api/ 
{  
    proxy_pass http://backend;              # 将请求转发到上游服务器  
    proxy_set_header Host $host;            # 设置 Host 头  
    proxy_set_header X-Real-IP $remote_addr;                        # 设置真实客户端 IP  
    proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;    # 设置 X-Forwarded-For 头  
    proxy_set_header X-Forwarded-Proto $scheme;                     # 设置协议（http 或 https）  
}  




# root: 设置请求的根目录。 可以是绝对路径，也可以是相对路径

# index: 设置默认的索引文件。       ⽤于指定默认⽂件，如果请求的是⽬录，则会在⽬录下查找默认⽂件

# proxy_pass: 将请求转发到其他服务器。

# rewrite: 重写请求的 URI。

# deny/allow: 控制访问权限


# 修饰符:
# -1-   精确匹配的请求  
location = /index.html 
{  
    ...
} 
精确匹配。如果请求的 URI 完全与指定的 URI 匹配，则使用该块。


# -2-   处理以 /images/ 开头的请求  
location ^~ /images/ 
{  
    ...
} 
前缀匹配。如果请求的 URI 以指定的 URI 开头，则使用该块，并且不再检查其他以 location 开头的块。


# -3-   处理以 .php 结尾的请求  
location ~ \.php$ 
{  
    ...
}  
正则表达式匹配。使用正则表达式匹配请求的 URI，区分大小写。


# -4-   处理以 .jpg、.jpeg 或 .png 结尾的请求，忽略大小写 
location ~* \.(jpg|jpeg|png)$ 
{  
    ...
}  
正则表达式匹配，忽略大小写。


# -5-   处理所有其他请求  
location / 
{  
    ...
}  
默认匹配。如果没有其他 location 块匹配请求，则使用该块。








