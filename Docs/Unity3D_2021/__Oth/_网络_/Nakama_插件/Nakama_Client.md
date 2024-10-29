


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













