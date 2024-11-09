


# Nakama .NET Client SDK:
https://dotnet.docs.heroiclabs.com/html/index.html


# Nakama Unity Client Guide:
https://heroiclabs.com/docs/nakama/client-libraries/unity/#session-variables





# ================================================= #
#     
# ================================================= #




# ------------------------------------ #
#            Client
# ------------------------------------ #
The Nakama `Client` class instance connects to a Nakama Server and is the entry point to access Nakama features. 
It is recommended to have one client per server per game.



# ------------------------------------ #
#         Nakama.UnityLogger
# ------------------------------------ #

When working with Nakama you can configure the client to use a custom logger. 
This logger will then be passed down to the HTTP adapter where it will be used to log errors received from API calls.


# ------------------------------------ #
#             Socket
# ------------------------------------ #
The Nakama Socket is used for gameplay and real-time latency-sensitive 时延敏感 features such as chat, parties, matches and RPCs.


# useMainThread:
    var socket = client.NewSocket(useMainThread: false);
    --
    这样设置后, 将不使用 unity 主线程来 dispatch (分发) events




# ------------------------------------ #
#          RetryConfiguration
# ------------------------------------ #

请求发送失败后, 重试几次, 如何重试, 配置这些参数的 class



# ------------------------------------ #
#       UnityEngine.PlayerPrefs
# ------------------------------------ #




# ------------------------------------ #
#            Session
# ------------------------------------ #

# 概念:
# Session / Game Session
（游戏会话）指的是玩家在游戏中进行的一次完整的互动过程，从开始游戏到结束游戏的整个时间段。这个概念通常用于描述玩家的游戏体验和状态管理;




# ------------------------------------ #
#           Account
# ------------------------------------ #

# 玩家账户
https://heroiclabs.com/docs/nakama/concepts/user-accounts/#user-metadata




# ------------------------------------ #
#          Match    (Room)
# ------------------------------------ #
match 类似一个 room;



# ---- 如何知道 room 中其它玩家:
    -1- 创建 match 的第一时间, 访问 match.Presences 得知 room 中已经存在的其它 client
    -2- 绑定 socket.ReceivedMatchPresence 来得知 "新加入", "新离开" 的 client




# ------------------------------------ #
#      普通的 数据库访问
# ------------------------------------ #

# Storage Engine
https://heroiclabs.com/docs/nakama/client-libraries/unity/#storage-engine


能满足绝大部分需求, 但是它应该不适合 帧同步 这种更专业的要求; 比较适合场景的 资源管理;




# ------------------------------------ #
#           Op codes
# ------------------------------------ #
https://heroiclabs.com/docs/nakama/concepts/multiplayer/relayed/#op-codes








# ========================================== #
#     如何用 nakama 来构建多人游戏
# ========================================== #

# Nakama Multiplayer Engine
https://heroiclabs.com/docs/nakama/concepts/multiplayer/


# -1- clients 之间交换数据, server 充当信息转发器, 类似 p2p
https://heroiclabs.com/docs/nakama/concepts/multiplayer/relayed/


# -2- server 里写业务逻辑, 来处理 client 传来的数据
https://heroiclabs.com/docs/nakama/concepts/multiplayer/authoritative/


# Session-based Multiplayer
https://heroiclabs.com/docs/nakama/concepts/multiplayer/session-based/






