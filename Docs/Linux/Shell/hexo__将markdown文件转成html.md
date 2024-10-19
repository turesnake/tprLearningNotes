
Hexo 是一个基于 Node.js 的静态博客框架

官方网站
https://hexo.io/docs/



# ----------------------------------- #
#            安装:
# ----------------------------------- #
sudo apt update 
sudo apt install nodejs npm      -- 安装 Node.js 和 npm 


# 检查安装是否成功:
node -v  
npm -v 

# 使用 npm 全局安装 Hexo：
sudo npm install -g hexo-cli  



# ----------------------------------- #
#             制作网页
# ----------------------------------- #

选择一个目录来存放您的 Hexo 博客，然后创建一个新的 Hexo 项目：
# 创建博客目录  
mkdir ~/my-blog  
cd ~/my-blog  

# 初始化 Hexo  
sudo hexo init       -- 后面可以跟指定目录, 此处不跟表示在当前目录下
sudo npm install     -- 这句话必须在 hexo 目标博客目录内执行



# ----------------------------------- #
#         快速生成一个站点
# ----------------------------------- #
sudo hexo g         -- 必须在 博客目录 下;
    它能把 markdown 格式文章, 转换为一个静态页面;
    放到 博客目录/public 目录下


在 ~/my-blog/_config.yml 文件中，您可以配置博客的基本信息，例如标题、描述、作者等。
nano _config.yml

# ----------------------------------- #
#       快速启动本地服务器     (临时测试)
# ----------------------------------- #
sudo hexo s
    它会提示我们在 http://localhost:4000/ 本地端口开了个网页, 
    现在可以去访问之; (实践发现访问不了)
    ---

如何杀死这个后台进程:
先找到它的 pid:
sudo lsof -i :4000
    查看占用 4000 端口的程序, 找到 hexo程序的 pid, 比如 6698

sudo kill -9 6698   
    强行杀死这个进程


# ----------------------------------- #
#   正式用 nginx 来部署这个 blog:   (推荐)
# ----------------------------------- #

# -1- 先将上文 blog目录/public/ 下的所有内容,  
    cd public
    sudo cp -rf * /usr/share/nginx/html/     -- 递归复制所有内容

# -2- 再次打开 localhost 页面, 就能看到内容了






# ----------------------------------- #
#      其它 gpt 的教程内容:
# ----------------------------------- #


生成静态文件并启动 Hexo 服务器：
# 生成静态文件  
sudo hexo generate  

# 启动本地服务器  
sudo hexo server

默认情况下，Hexo 服务器将在 http://localhost:4000 上运行。您可以在浏览器中访问这个地址查看您的博客。



# --------------- #
#     部署
# --------------- #

如果您希望将博客部署到远程服务器或 GitHub Pages，您需要配置部署设置。在 ~/my-blog/_config.yml 中找到 deploy 部分并进行配置。

例如，使用 GitHub Pages 部署：
deploy:  
  type: git  
  repo: https://github.com/username/repo.git  
  branch: gh-pages

然后安装 Hexo 部署插件：
npm install hexo-deployer-git --save

最后，使用以下命令进行部署：
hexo deploy


# --------------- #
#     其他命令
# --------------- #

创建新文章：    hexo new post "文章标题"
生成静态文件：  hexo generate
启动服务器：    hexo server
部署博客：      hexo deploy


# --------------- #
#     访问博客
# --------------- #
如果您在本地服务器上运行 Hexo，您可以通过浏览器访问 http://your-server-ip:4000 来查看您的博客。

















