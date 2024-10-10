

# ==================================================== #
#         Netcode for Game Objects
#         Netcode for Entities   
#         两者区别
# ==================================================== #

# Netcode for Game Objects:
    用于常规的 mono 结构里;


# Netcode for Entities:
    用于 ECS 中;

# --
Netcode for Game Objects and Netcode for Entities are both the latest multiplayer solutions from Unity. However, they serve different purposes. NGO is meant for casual co-op as you have mentioned and with services like Relay or Steam p2p, a dedicated hosting is not required. That does not mean you can't do a large scale multiplayer game and use dedicated servers but Netcode for Entities is designed for large scale competitive games. It is a package based on ECS and provides built-in features like prediction, interpolation, and lag compensation that are used in the server authoritative games.

# --
If you would like to develop coop games (survival games, horror games, puzzle games etc.) or small scale competitive game, (stick fight) you can simply use NGO with relay services without using a dedicated server. If cheating is not your main concern, this is the best option to go. No dedicated server maintance or costs and you are simplifying your high level networking code by making things client authoritative.

However, if you are aiming for a competitive game where cheating is a concern, you would need to have dedicated servers and make your networking code server authoritative. Note that this will add a tremendous level of complexity to your project which requires you to write server authoritive code and implement features like client side prediction, lag compensation etc. to deal with the latency. Even you manage to make things server authoritative and deal with the latency right, you will still need additonal cheat protection tools to prevent things like wall hacks. But, eventually someone will find a way to cheat cause cheaters gonna cheat. This is where moderation comes in to ban the players from the game. Apart from these, you will need to manage a dedicated server fleet which will cost your time and money.

Basically, when developing multiplayer games, you have to figure out your primary concerns and make compromises if necessary.




# 知乎教程系列:
https://zhuanlan.zhihu.com/p/669642159



# ==================================================== #
#                 Rpc
# ==================================================== #

# ----------------------------- #
# ClientRpc
# ----------------------------- #
    在 client 上定义的, 可以被 server 调用的函数
    执行的时候是在 client 上

    服务器可以执行所有客户端上的ClientRpc。

    定义一个 ClientRpc 函数很简单， Rpc 函数上必须要打上 [ClientRpc] 标签， 并且函数的后缀也必须要为 ClientRpc

    该函数必须要定义在继承 NetworkBehaviour 的类中才有效

[ClientRpc]
public void TestClientRpc(int param) 
{
}

A ClientRpc can be used by a server to notify a specific client of a special reconnection key 重连接键 or some other player specific information that doesn't require its state to be synchronized with all current and any future late joining client(s).







# ----------------------------- #
# ServerRpc
# ----------------------------- #
    ServerRpc只能由客户端调用，并且始终只在Host或Server上执行。
    执行的时候是在 server 上

    定义一个ServerRpc函数很简单，Rpc函数上必须要打上[ServerRpc]标签，并且函数的后缀也必须要为ServerRpc

    该函数必须要定义在继承NetworkBehaviour的类中才有效

[ServerRpc]
public void TestServerRpc(int param) 
{
 
}

    ServerRpc调用是有权限控制的，默认情况下，只有Owner才可以调用，当然也可以根据需求设置所有人都有权限执行


[ServerRpc(RequireOwnership = false)]
public void SetDataServerRpc(int nValue, bool Add)
{

}

A ServerRpc can be used by a client to notify the server that the player is trying to use a world object (that is, a door, a vehicle, etc.)
client 调用 ServerRpc, 以通知 server 它正在修改一个 全局obj, 比如门, 车;




# ==================================================== #
#                 Custom Messages
# ==================================================== #
Custom messages provide you with the ability to create your own "netcode message type" to handle scenarios where you might just need to create your own custom message.



















