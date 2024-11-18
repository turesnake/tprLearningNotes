


# lua runtime
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/


# Function Reference  几乎所有 lua 函数
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/





# ================================= #
#     nakama server 脚本
# ================================= #

https://heroiclabs.com/docs/nakama/server-framework/introduction/index.html


# lua 脚本范例:
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/#develop-code



# An example project template on how to set up and write custom logic in Nakama server.
https://github.com/heroiclabs/nakama-project-template


# lua code example:
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/code-samples/




# ================================= #
#        尝试 流程
# ================================= #

# lua 脚本目录: /usr/local/bin/nakama/data/modules 




# ================================= #
#            log
# ================================= #

local nk = require("nakama")


# debug: 最详细的日志信息，适合调试。
# info: 一般信息，适合生产环境。
# warn: 警告信息，表示潜在问题。
# error: 错误信息，表示发生了问题。
# fatal: 严重错误，通常会导致程序退出。

nk.logger_debug("---aa---")
nk.logger_info("---aa---")
nk.logger_warn("---bb---")
nk.logger_error("---bb---")





# ================================= #
#       Match    (room)
# ================================= #

Match Handler Reference
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/match-handler/


Match Runtime Reference
https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/match-runtime/





















