

# ============================================= #
#                server 端
# ============================================= #


# register_rpc()
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/#register_rpc









# ============================================= #
#            client 端    (unity)
# ============================================= #


# client.RpcAsync() 
# socket.RpcAsync()
https://heroiclabs.com/docs/nakama/client-libraries/unity/#client-rpcs


    await client.RpcAsync(session, "EquipHat", data.ToJson());

    await socket.RpcAsync("<RpcId>", "<PayloadString>");











