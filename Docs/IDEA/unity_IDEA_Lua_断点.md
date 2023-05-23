# ============================================================ #
#       unity  IDEA lua xlua 断点 调试
# ============================================================ #


# ---------------------
# 首先按照此教程:
    https://blog.csdn.net/qq_15505341/article/details/118928406?utm_medium=distribute.pc_relevant.none-task-blog-2~default~baidujs_baidulandingword~default-1-118928406-blog-124110692.235^v36^pc_relevant_default_base3&spm=1001.2101.3001.4242.1&utm_relevant_index=4
    
    =======
    -- 按照 IDEA
    -- 按照 EmmyLua 插件
    -- 新建项目, 关联到 游戏项目的 lua工程
    

# ---------------------
# 找到 游戏项目的 lua 代码入口,
    比如 Main.lua, 
    在其最上方, 写入代码:

    package.cpath = package.cpath .. ';C:/Users/Administrator/AppData/Roaming/JetBrains/IdeaIC2023.1/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'
    local dbg = require('emmy_core')
    dbg.tcpConnect('localhost', 9966)


# ---------------------
# 在 游戏项目的 c# 工程中, 找到如 LuaEnv.cs, 
    在其 DoString() 函数头部添加代码:

    chunkName = chunkName.Replace(".", "/"); 


# ---------------------
# 用 idea 打开那个 关联了 游戏lua 项目的 项目, 点击 debug 按钮 (右上角虫子图标)
    此按钮上会显示:
        'Debug Unnamed'

    此时 idea 的 console 界面会显示:
        Server(localhost:9966) open successfully, wait for connection...

    表示 idea 开始等待 unity 的启动


# ---------------------
# 在 unity editor 中点击 play, 运行游戏

    此时 idea 的 console 会显示:
        Connected.

    表示 idea 和 unity 已经连接成功了;


# ---------------------
# 此时就可以开始 断点 debug 了

    在 idea 中给代码打断点, 
    然后unity 运行到此处就会停下;

    点击 'F8' 就会 运行下一行代码




















