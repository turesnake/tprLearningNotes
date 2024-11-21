


# client-server 间发送信息的主力应该是 `Server: match_loop()的messages_参数` + `Client: socket.SendMatchStateAsync()`
    它似乎就是为了支持 client-server 之间高频通信 而设计的; 比如每帧的大量数据的传递;



# --------- match_loop() ---------

https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/match-handler/#match_loop


function MatchHandlerTest.match_loop(context, dispatcher, tick, state_, messages_ ) 

    -- Messages format:
	-- {
	--   {
	--     sender = {
	--       user_id = "user unique ID",
	--       session_id = "session ID of the user's current connection",
	--       username = "user's unique username",
	--       node = "name of the Nakama node the user is connected to"
	--     },
	--     op_code = 1, -- numeric op code set by the sender.
	--     data = "any string data set by the sender" -- may be nil.
	--   },
	--   ...
	-- }

end

# match_loop() 的 messages_ 是个 list, 存储了从 client 端发来的数据; 
测试表明:
    如果在 server match loop 帧率很低, 但 client 帧率很高; 导致在一次 loop 之后, client 发来了很多帧的数据;
    Messages 参数是能全部接收的;

    Messages 中也允许存在 同一个 client 发来的很多段数据;



























