
# 源自:
https://docs-multiplayer.unity3d.com/netcode/1.4.0/learn/listen-server-host-architecture/




# ------
You still need to set up matchmaking for your player to join together to play. 
A listen server game requires redirecting players to the client-hosted server.


redirecting players：指的是将其他玩家的连接请求引导到这个客户端托管的服务器上。这通常意味着需要一些机制或步骤来确保其他玩家能够找到并连接到这个特定的服务器。

Client-hosted server：如前所述，指的是由一个玩家的设备托管的服务器。

综合起来，这句话的意思是，在一个“监听服务器”游戏中，其他玩家需要通过某种方式（例如，输入IP地址、使用游戏内的服务器浏览功能等）来连接到那个由某个玩家托管的服务器。
这种设置通常需要确保所有参与者都能正确找到并连接到这个服务器，以便顺利进行游戏。



# ============================================= #
#         Connecting to a listen server
# ============================================= #

Personal computers are hidden behind NATs (Network Address Translation devices) and routers to protect them from direct access. 
To connect to a listen server, you may choose an option such as: 
    `port forwarding` 
    `relay server`
    `NAT punch-through`
    `NAT punch with relay fallback`

# ----------------------- #
#     port forwarding     
#         不推荐
# ----------------------- #
With port forwarding, the host can allow another player to connect to a listen server by forwarding a public port on their router to a machine in their local network.


要顾虑的:
- It has risks. By opening ports, you create direct pathways for hackers and malware attacks to access your system.

- The host must manually open the ports on their router, and this requires some technical knowledge the average user may not have.

- The host may not always have access to their router and would not be able to open a port. 
    For example, the host may be using a mobile device, a corporate network (公司网络), or public WiFi.

Port forwarding may not be a viable option for a released game but can be useful for development. 
For more information about port forwarding, see https://portforward.com/.

是个研发阶段, 不适合已发布的游戏, 有安全风险;


# ----------------------- #
#     relay server    中继服务器
# ----------------------- #
A dedicated server has ports already forwarded for players to connect anytime. These servers can run in the cloud or a data center. 
The relay server option uses these servers to send data between players.


In a listen server relay scenario, the host and all clients connect to the same listen server. 
Clients send packets to the relay server, which then redirects these packets to the intended recipient.
client 将数据发给 中继服务器, 中继服务器 再把这个数据发给 目标 client


优势:
- Compared to direct connecting through port forwarding, a relay server should always work for any client.
- A relay server knows when the host client disconnects and can inform the other clients or start a host migration 移民 process.
    当 host client 下线时, 中继服务器 能通知其他人, 或者执行 移民程序 (比如把另一个 client 当 host)


劣势:
- A relay server costs money
- the round trip times for packet exchange may be higher because they have to go through the relay server instead of being sent directly to the other client.
    转包时长可能高于 client 间直连;


# ----------------------- #
#     NAT punch-through
#     NAT punchthrough
# ----------------------- #

# gpt:
NAT punch-through 是一种网络技术，主要用于解决在网络地址转换（NAT）环境下的点对点（P2P）连接问题。以下是详细解释：

NAT（网络地址转换）:
    NAT 是一种网络技术，允许多个设备通过一个公共IP地址访问互联网。它通常用于家庭或小型办公室网络中，路由器将内部设备的私有IP地址转换为公共IP地址。

# 路由器 就是一种 NAT 设备;

问题:
    在 NAT 环境中，设备之间的直接连接可能会受到限制。因为NAT会阻止外部设备直接访问内部设备的私有IP地址。这使得点对点连接（如在线游戏、视频通话等）变得复杂，因为设备无法直接找到彼此。

NAT Punch-through 的工作原理:
- 建立连接：当两个设备（例如，玩家的电脑）希望建立直接连接时，它们首先会通过一个公共服务器（通常称为 `信令服务器` ）进行通信。这个服务器的作用是帮助设备交换彼此的 公共 IP 地址 和 端口信息。

- 发送数据包：每个设备向 信令服务器 发送数据包，服务器记录下这些数据包的 来源IP地址 和 端口。然后，服务器将这些信息发送给对方设备。

- 打开端口：在 NAT 设备（如路由器）中，发送数据包会在设备的NAT表中创建一个映射，允许外部设备通过这个映射发送数据包。

- 直接连接：一旦两个设备都知道对方的 公共IP地址 和 端口 ，它们可以开始直接发送数据包。由于 NAT 设备已经为这些数据包打开了端口，连接就可以成功建立。


优点:
-    减少延迟：通过直接连接，数据传输的延迟通常会降低，因为数据不需要经过中间服务器。
-    节省带宽：直接连接可以减少对中间服务器的依赖，从而节省带宽和资源。

应用场景:
-   NAT punch-through 技术广泛应用于在线游戏、视频会议、文件共享等需要点对点连接的应用中。它使得用户能够在NAT环境下顺利进行实时通信和数据交换。


# 原文: ----------------------

Network Address Translation (NAT) punch-through, also known as `hole punching`, opens a direct connection without port forwarding. 
When successful, clients are directly connected to each other to exchange packets. 
However, depending on the NAT types among the clients, NAT punching often fails.


Because of its high rate of failure, `NAT punch-through` is typically only used with a `relay fallback`.
    由于其高失败率，`NAT punch-through` 通常只与 `relay fallback` 一起使用.
    (就是下一节要介绍的)


# Ways to NAT punch:
- `STUN`: Session Traversal Utilities for NAT STUN: -------------------------------------

    gpt:
    STUN 的工作原理:
    STUN 协议的主要目的是帮助设备发现其 公共IP地址 和 NAT 类型，从而能够建立P2P连接。其工作流程如下：

        -1- STUN 服务器：首先，设备需要连接到一个公共的 STUN 服务器。这个服务器通常位于互联网上，能够被所有设备访问。

        -2- 发送请求：设备向 STUN 服务器发送一个请求，询问其 公共IP地址 和 端口。这个请求是通过 UDP 发送的。

        -3- 响应：STUN服务器 接收到请求后，会记录下请求的 来源IP地址 和 端口，并将这些信息作为响应发送回设备。响应中包含了设备的 公共IP地址 和 端口。

        -4- NAT类型检测：通过与 STUN服务器 的交互，设备还可以确定其 NAT类型（如全锥型、受限锥型、端口受限锥型或 对称NAT）。这有助于设备了解如何与其他设备建立连接。

        -5- 建立连接：一旦设备知道了自己的 公共IP地址 和 端口，它可以将这些信息发送给其他设备（通常通过 信令服务器 ），从而尝试建立直接的P2P连接。

    优点:
        - 简化连接建立：STUN 协议简化了在 NAT环境 中建立P2P连接的过程，使得设备能够更容易地找到彼此。

        - 实时通信：STUN 被广泛应用于实时通信应用，如 VoIP（语音通信）、视频会议 和 在线游戏，能够提高连接的可靠性和性能。

    应用场景:
        STUN 协议通常与其他协议（如 TURN 和 ICE）结合使用，以实现更复杂的网络连接管理。它在WebRTC（Web实时通信）中也得到了广泛应用，帮助浏览器之间建立直接的音视频连接。

    总结
    STUN 是一种重要的网络协议，帮助设备在NAT环境中发现公共IP地址和端口，从而实现点对点连接。它在现代网络通信中扮演着关键角色，尤其是在需要实时数据传输的应用中。


- `ICE`: Interactive Connectivity Establishment ICE  ------------------------------------- 感觉比 STUN 高级

    gpt:
    是一种网络协议，旨在帮助设备在复杂的网络环境中（尤其是涉及网络地址转换（NAT）和防火墙的情况下）建立和维护点对点（P2P）连接。以下是详细解释：

    背景:
        在许多网络环境中，设备通过 NAT路由器 连接到互联网，这使得设备之间的直接连接变得复杂。ICE 协议的设计目的是解决这些问题，确保设备能够顺利建立连接，尤其是在实时通信（如 VoIP 和 视频会议 ）中。

    ICE 的工作原理
    ICE 协议的工作流程可以分为几个主要步骤：

    -1- 候选地址收集：
        在连接建立的初始阶段，每个设备（通常称为“候选者”）会收集多个候选地址。这些地址可以是：
            - 设备的 公共IP地址 （通过STUN服务器获取）。
            - 设备的 私有IP地址 （在局域网内）。
            - 通过 TURN服务器 获取的 中继地址 （用于在无法直接连接时使用）。
    
    -2- 信令：
        设备通过信令通道（通常是一个 公共服务器 ）交换候选地址。这一步骤确保每个设备都知道对方的 候选地址。

    -3- 连接测试：
        一旦候选地址被交换，ICE 会进行连接测试。设备会尝试通过每个候选地址对其他设备进行连接测试，以确定哪些地址可以成功建立连接。
        这通常涉及发送 “连接请求” 数据包，并等待响应。
    
    -4- 优先级选择：
        ICE 会根据连接测试的结果和候选地址的优先级选择最佳的连接路径。优先级通常基于地址类型（如 公共地址 优先于 私有地址 ）和连接测试的成功率。
    
    -5- 建立连接：
        一旦确定了最佳的连接路径，设备就可以开始通过这个路径进行数据传输。

    优点
        灵活性：ICE 协议能够处理多种网络环境，包括不同类型的 NAT 和 防火墙 ，确保设备能够找到最佳的连接路径。

        提高连接成功率：通过候选地址的收集和连接测试，ICE 提高了在复杂网络环境中成功建立连接的可能性。

        实时通信支持：ICE 被广泛应用于实时通信应用，如 WebRTC、VoIP 和 视频会议，能够确保低延迟和高质量的数据传输。

    应用场景:
        ICE 协议通常与其他协议（如 STUN 和 TURN ）结合使用，以实现更复杂的网络连接管理。它在现代网络通信中扮演着关键角色，尤其是在需要实时数据传输的应用中。


- `(UDP) hole punching`: User Datagram Protocol (UDP) hole punching ------------------------------------- 感觉更简单

    gpt:
    是一种网络技术，主要用于在网络地址转换（NAT）环境中建立点对点（P2P）连接。它利用 UDP 协议的特性，帮助两个设备在 NAT后面直接通信。以下是详细解释：

    UDP 协议
    UDP（用户数据报协议） 是一种无连接的网络协议，适用于需要快速传输数据但不需要保证数据完整性的应用。UDP不进行连接建立和维护，因此在某些情况下，它可以更快地传输数据。

    UDP Hole Punching 的工作原理
    UDP hole punching 的工作流程通常包括以下几个步骤：

        -1- 连接到公共服务器：
            两个设备（例如，A 和 B ）首先连接到一个公共的 信令服务器。这个服务器的作用是帮助设备交换彼此的 公共IP地址 和 端口信息。
        
        -2- 发送初始数据包：
            设备 A 和 B 分别向 信令服务器 发送一个 UDP数据包，服务器记录下 A 和 B 的 公共IP地址 和 端口。

        -3- 交换信息：
            信令服务器将 A 和 B 的 公共IP地址和端口信息相互发送给对方。

        -4- 发送数据包以打开NAT：
            设备 A 和 B 分别向对方的 公共IP地址 和 端口 发送 UDP数据包。这一步骤的目的是在各自的 NAT设备 中打开一个端口，以便后续的直接通信。

        -5- 建立直接连接：
            一旦 NAT设备 接收到来自对方的 UDP数据包，它会在 NAT表 中创建一个 映射，允许 外部设备 通过这个 映射 发送数据包。此时，A 和 B 之间的直接连接就建立起来了。
    
    优点:
        - 快速建立连接：UDP hole punching 可以快速建立点对点连接，适合需要低延迟的实时应用。

        - 减少对中间服务器的依赖：通过直接连接，数据传输不需要经过中间服务器，从而节省带宽和资源。

    应用场景:
        UDP hole punching 广泛应用于实时通信、在线游戏、文件共享等需要点对点连接的应用中。它能够在 NAT环境 中有效地建立连接，确保用户能够顺利进行实时数据传输。


# ----------------------- #
#     NAT punch with relay fallback
# ----------------------- #

This option combines `NAT punching` with a `relay fallback`. 
Clients first try to connect to the host by `NAT punching` and default back to the relay server on failure. 
This reduces the workload on the relay server while allowing clients to still connect to the host.

It is widely used because it reduces the hosting costs of relay servers.

# 说白了就是先尝试 `NAT punching`, 若失败就改用 `relay server` (中继服务器) 方案, 以提高连接成功率;


# gpt:
它结合了NAT穿透技术和中继（relay）服务器的使用，以确保在不同网络条件下的连接可靠性。以下是详细解释：


Relay Fallback:
    Relay Fallback 是指在尝试建立直接P2P连接失败时，使用 中继服务器 作为备选方案。中继服务器充当数据传输的中介，确保即使在无法直接连接的情况下，设备之间仍然可以通信。

工作原理:
-1- 尝试 NAT Punching：
    两个设备（例如，A 和 B）首先尝试通过 NAT穿透技术 建立直接连接。它们会连接到一个公共的 信令服务器，交换彼此的公共IP地址和端口信息，并尝试直接发送数据包。

-2- 连接测试：
    设备A和B会进行连接测试，尝试通过各自的 公共IP地址 和 端口 建立连接。如果连接成功，数据传输将直接进行。

-3- 检测连接失败：
    如果在一定时间内未能成功建立直接连接（例如，由于 NAT类型不兼容 或 防火墙设置），设备将检测到连接失败。

-4- 使用中继服务器：
    一旦检测到连接失败，设备将自动切换到使用 中继服务器。设备 A 和 B 会通过 信令服务器 获取 中继服务器 的地址，并开始通过 中继服务器 进行数据传输。

-5- 数据传输：
    在中继模式下，所有数据将通过 中继服务器 进行转发。虽然这种方式可能会增加延迟和带宽消耗，但它确保了设备之间的通信不会中断。


优点:
    提高连接成功率：通过结合 NAT穿透 和 中继服务器，确保在各种网络条件下都能建立连接。

    灵活性：能够适应不同的 NAT类型 和 防火墙 设置，提供更好的用户体验。

    实时通信支持：适用于需要实时数据传输的应用，如视频会议和在线游戏。


应用场景:
    NAT punch with relay fallback 技术广泛应用于实时通信、在线游戏、文件共享等需要点对点连接的应用中。它能够在复杂的网络环境中有效地建立连接，确保用户能够顺利进行实时数据传输。
























