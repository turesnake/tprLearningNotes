

# ============================================= #
#                server 端
# ============================================= #


# register_rpc()
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/#register_rpc



# 范例:

---@param context table @ 提供了关于当前 RPC 调用的上下文信息。包含了多个重要字段，可助于获取有关请求的详细信息
---@param payload table @ json data, c# 端的输入值 
local function _RpcDemoFunc(context, payload)
    -- Run some code.
    nk.logger_error("=====  RpcFuncDemo ======")

    -- context:
    nk.logger_error(" user_id: " .. tostring(context.user_id)) -- string
    nk.logger_error(" session_id: " .. tostring(context.session_id)) -- string
    nk.logger_error(" rpc_id: " .. tostring(context.rpc_id)) -- string
    nk.logger_error(" match_id: " .. tostring(context.match_id)) -- string
    nk.logger_error(" socket_id: " .. tostring(context.socket_id)) -- string

    -- table: 
    -- context.metadata

    -- table:
    --[[
        context.http.method
        context.http.headers
        context.http.body
        context.http.query
        context.http.path
        context.http.remote_addr
    ]]
    -- context.http


    -- payload 是一个 JSON 字符串，包含传入的参数  
    local params = nk.json_decode(payload)  

    nk.logger_error("=== params ===")
    for k,v in pairs(params) do 
        nk.logger_error("---: k:" .. tostring(k) .. "; v:" .. tostring(v))
    end 

    --- 原则上可以返回任意值
    return "this is ret value from server"
end

nk.register_rpc(_RpcDemoFunc, "RpcDemo")






# ============================================= #
#            client 端    (unity)
# ============================================= #


# client.RpcAsync() 
# socket.RpcAsync()
https://heroiclabs.com/docs/nakama/client-libraries/unity/#client-rpcs


    await client.RpcAsync(session, "EquipHat", data.ToJson());

    await socket.RpcAsync("<RpcId>", "<PayloadString>");



# 范例:
async void CallRpc() 
{
    try
    {
        SelfPrint("call rpc");
        var payload = new Dictionary<string, string> {{ "item", "cowboy" }};
        IApiRpc response = await _client.RpcAsync(_session, "RpcDemo", payload.ToJson());
        SelfPrint("New hat equipped successfully; ret Payload: " + response.Payload); // server 端的返回值存储在 Payload 中
    }
    catch (ApiResponseException ex)
    {
        Debug.LogFormat("Error: {0}", ex.Message);
    }
}








