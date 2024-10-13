
主要摘选自:
https://docs-multiplayer.unity3d.com/netcode/1.4.0/basics/networkvariable/



# ==================================================== #
#           NetworkVariable System
# ==================================================== #
A NetworkVariable is most commonly used to synchronize state between both `connected` and `late joining clients`. 
The `NetworkVariable` system only supports non-nullable value `type`s, but also provides support for `INetworkSerializable` implementations as well you can create your own `NetworkVariable` class by deriving from the `NetworkVariableBase` abstract class. 

If you want something to always be synchronized with current and late-joining clients, then it's likely a good NetworkVariable candidate.


# -------
At a high level, a `NetworkVariable` is a way to synchronize a property ("variable") between a server and client(s) without having to use custom messages or RPCs.


NetworkVariable 只是数据的一个容器, 需要使用 NetworkVariable.Value 来访问数据本体;


-- 新登录的 client 会自动获得 NetworkVariable 的当前同步数据
-- 已经登录的 client 通过订阅 NetworkVariable.OnValueChanged(旧值, 新值) 来获知目标数据的最新改写
    看起来, 就算不登记 OnValueChanged, 这个值也会自动同步为最新值; 所以 OnValueChanged() 不是用来在本地手动改写 NetworkVariable 值用的



# ---
NetworkVariable 必须在 NetworkBehaviour 内被使用

A NetworkVariable's value can only be set when:
    Initializing the property (either when it's declared or within the Awake method)
    While the associated `NetworkObject` is spawned (upon being spawned or any time while it's still spawned).

# !!!
When a client first connects, it will be synchronized with the current value of the NetworkVariable. 
Typically, clients should register for `NetworkVariable.OnValueChanged` within the `OnNetworkSpawn` method.

    为什么呢?

A NetworkBehaviour's `Start` and `OnNetworkSpawn` methods are invoked based on the type of NetworkObject the NetworkBehaviour is associated with:

--- In-Scene Placed: Since the instantiation occurs via the scene loading mechanism(s), the `Start` method is invoked before `OnNetworkSpawn`.
    先 Awake()
    先 Start()
    后 OnNetworkSpawn()

--- Dynamically Spawned: Since `OnNetworkSpawn` is invoked immediately (that is, within the same relative call-stack) after instantiation, the `Start` method is invoked after OnNetworkSpawn.
    先 Awake()
    先 OnNetworkSpawn()
    后 Start()           因为 Start() 并不属于 instantiation 阶段, 而是 Update 阶段的开始;
    ---
    


# ------------------------- #
#   Permissions
# ------------------------- #

每个 NetworkVariable 实例在声明的时候, 可以设置自己的 读写权限:

public NetworkVariable(
    T value = default, 
    NetworkVariableReadPermission readPerm = NetworkVariableReadPermission.Everyone, 
    NetworkVariableWritePermission writePerm = NetworkVariableWritePermission.Server
);






