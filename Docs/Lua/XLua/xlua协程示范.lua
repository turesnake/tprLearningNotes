-- 
-- XLua 自带的协程 和 unity 配合的用法
-- 


--local cs_coroutine = (require 'cs_coroutine')
local cs_coroutine = require('XLua.cs_coroutine')

local a = cs_coroutine.start(function()
    print('coroutine a started')

    coroutine.yield(cs_coroutine.start(function() 
        print('coroutine b stated inside cotoutine a')
        coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
        print('i am coroutine b')
    end))

    print('coroutine b finish')

    while true do
        coroutine.yield(CS.UnityEngine.WaitForSeconds(1))
        print('i am coroutine a')
    end
end)


cs_coroutine.start(function()
    print('stop coroutine a after 5 seconds')
    coroutine.yield(CS.UnityEngine.WaitForSeconds(5))
    cs_coroutine.stop(a)
    print('coroutine a stoped')
end)










































