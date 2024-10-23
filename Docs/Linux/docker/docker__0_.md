

# ================================================ #
#        阿里云 ubuntu server 安装 docker
# ================================================ #

# sudo apt update
# sudo apt upgrade -y

# sudo apt install -y docker.io

# sudo systemctl start docker
# sudo systemctl enable docker

# sudo systemctl status docker   -- 查看状态

# sudo apt install -y docker-compose
    Nakama需要 Docker Compose 来管理容器。安装 Docker Compose

# sudo apt install postgresql postgresql-contrib
    Nakama需要 PostgreSQL作为数据库。您可以通过以下命令安装

# 因为国内的缘故, 可能 pull 不到 postgres
    此时需要:
        
# sudo touch /etc/docker/daemon.json 
# sudo nano /etc/docker/daemon.json 
然后向其写入:

{
   "registry-mirrors": ["https://qvm2weup.mirror.aliyuncs.com"]
}


# ================================================ #
#            添加 镜像地址
# ================================================ #

# sudo nano /etc/docker/daemon.json
写入:

{
"registry-mirrors": [
    "https://qvm2weup.mirror.aliyuncs.com",
    "https://docker.m.daocloud.io",
    "https://dockerproxy.com",
    "https://registry.docker-cn.com",
    "https://docker.mirrors.ustc.edu.cn",
    "https://hub-mirror.c.163.com",
    "https://hub.uuuadc.top",
    "https://docker.anyhub.us.kg",
    "https://dockerhub.jobcher.com",
    "https://dockerhub.icu",
    "https://docker.ckyl.me",
    "https://docker.awsl9527.cn",
    "https://mirror.baidubce.com"
  ]
}

"https://registry.cn-hangzhou.aliyuncs.com",
"https://hub-mirror.c.163.com",
"https://mirror.ccs.tencentyun.com",
"https://www.daocloud.io/mirror",


# sudo systemctl daemon-reload
# sudo systemctl restart docker 

然后再次尝试之前的指令, 比如: 
    sudo docker-compose up -d
    ---
    -d 表示在后台运行

# ================================================ #
#   克服 docker pull 拉取失败的问题
# ================================================ #

直接使用镜像文件如果以上方法都无法解决问题，可以考虑直接下载 Docker 镜像文件（.tar 格式），然后在本地加载：
docker load < your-image.tar













