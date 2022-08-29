# ======================================================================== #
#                         Lua   Bugs
# ======================================================================== #



# ---------------------------------------------- #
#     "attempt to index a nil value"
# ---------------------------------------------- #
https://stackoverflow.com/questions/57207287/how-to-fix-attempt-to-index-a-nil-value

案例:
    local a = dog.name

这个错误的核心就在这个 '.' 访问符上, 如果变量 dog 是 nil, 那么对它使用 '.' 就会报这个错;



# ---------------------------------------------- #
#     'GetEntityCompByType'
# ---------------------------------------------- #

LuaException: [string "Game.Utils.GameUtils"]:1829: attempt to index a nil value (local 'entity')
stack traceback:
	[string "Game.Utils.GameUtils"]:1829: in field 'GetEntityCompByType'
	[string "Game.Entry.AppService"]:773: in method 'OnTrialUpdate'
	[string "Game.Entry.AppService"]:765: in method 'OnUpdateHandler'
	[string "Game.Entry.AppService"]:561: in function <[string "Game.Entry.AppService"]:560>

XLua.LuaEnv.ThrowExceptionFromError (System.Int32 oldTop) (at Assets/XLua/Src/LuaEnv.cs:441)
XLuaGenDelegateImpl0.__Gen_Delegate_Imp1 () (at <6733e21e3ab94a89b36cd6bda81329d6>:0)
Engine.Network.KNManager.Update () (at Assets/Engine/Engine.Network/TCP/KNManager.cs:429)

# ----
暂未能找到原因....


# ---------------------------------------------- #
#     "Thread group size must be above zero"
# ---------------------------------------------- #

调用 ComputeShader.Dispatch() 时, size 参数必须都是整形


























