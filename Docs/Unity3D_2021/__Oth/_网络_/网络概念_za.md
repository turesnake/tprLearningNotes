


# =================================== #
#            反向代理
# =================================== #

是一种服务器配置方式，它位于客户端和目标服务器之间，充当中介。
反向代理服务器 接收来自 客户端 的请求，然后将这些请求转发给 目标服务器，并将 目标服务器 的响应返回给 客户端。反向代理的主要功能包括：

- 负载均衡：将 客户端 请求分配到多台 服务器 上，以均衡负载，提高系统的性能和可靠性。

- 安全性：隐藏内部 服务器 的真实IP地址，保护 服务器 免受直接攻击。

- 缓存：缓存来自 目标服务器 的内容，以减少 服务器 负载和提高响应速度。

- SSL加密：处理 SSL加密 和 解密，减轻 目标服务器 的负担。

- 压缩：对响应内容进行压缩，以减少带宽使用。


反向代理常用于大型网站和应用程序中，以提高性能、安全性和可扩展性。常见的反向代理软件包括 Nginx、Apache HTTP Server 和 HAProxy 等

































