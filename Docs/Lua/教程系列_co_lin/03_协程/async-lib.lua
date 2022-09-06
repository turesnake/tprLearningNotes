
-- PIL(Program In Lua) 中的

-- 简单的异步事件库，所有操作都先压入队列，然后在 runloop 中统一处理
-- 以此模拟异步的效果

local cmdQueue = {} 
local lib = {}

-- 从流中读取一行，读取成功后触发 callback 事件
function lib.readline(stream, callback)
    local nextCmd = function()
        callback(stream:read())
    end
    table.insert(cmdQueue, nextCmd)
end

-- 向流写一行，写完成后触发 callback 事件
function lib.writeline(stream, line, callback)
    local nextCmd = function()
        callback(stream:write(line))
    end
    table.insert(cmdQueue, nextCmd)
end

-- 停止
function lib.stop()
    table.insert(cmdQueue, 'stop')
end

function lib.runloop()
    while true do
        local nextCmd = table.remove(cmdQueue, 1)
        if nextCmd == 'stop' then
            break
        else
            nextCmd()
        end
    end
end

return lib


-----------------------------------------------------------------
-- 原始的 库的使用示范, 很绕, 存在递归, 不够 flat

local lib = require 'async-lib'
local t = {}
local inp = io.input()
local out = io.output()
local i

-- write-line handler
local function putline()
    i = i - 1
    -- 如果写完，就结束
    if i == 0 then -- no more lines?
        lib.stop() -- finish the main loop
    else -- write line and prepare next one
        -- 否则继续写
        lib.writeline(out, t[i] .. '\n', putline) -- 很绕, 把自己套进去了, 变成了一个递归...
        -- 内容为:
        -- local nextCmd = function()
        --     putline(stream:write(line))
        -- end
        -- table.insert(cmdQueue, nextCmd)
    end
end
-- read-line handler
local function getline(line)
    -- 这里把写到每一行都存到 t 中，然后继续读。
    if line then -- not EOF?
        t[#t + 1] = line -- save line
        lib.readline(inp, getline) -- read next one -- 很绕, 把自己套进去了, 变成了一个递归...
    else -- end of file
        -- 读完毕，开始 putline 写
        i = #t + 1 -- prepare write loop
        putline() -- enter write loop
    end
end

lib.readline(inp, getline) -- 在循环之前先预读一行，由于是异步的，所以这里并没有读
lib.runloop()   -- 循环开始，上面的读开始执行，读完之后触发getline





----------------------------------------------------------------------------------------
-- 上面的实现方式 理解起来还是有点绕的，如果读写能像写同步代码那样，那就自然得多了，
-- 使用协程可以做到这一点，下面是使用协程对事件库作的一层包装：

local lib = require 'async-lib'

function run(code)
    -- coroutine.wrap() 和 coroutine.create() 一样创建协程，不同的是它返回一个函数，调用这个函数
    -- 就启动协程，具体差别可以看参考手册。
    local co = coroutine.wrap(function()
        code()     -- 执行传进来的代码(也就是函数)
        lib.stop() -- 完成事件
    end)
    co() -- 开始协程执行
    lib.runloop() -- 开始事件循环
end

function putline(stream, line)
    local co = coroutine.running()
    local callback = (function()
        coroutine.resume(co)
    end)
    lib.writeline(stream, line, callback)
    coroutine.yield()
end

-- 这个代码本身是在 协程内 执行的
function getline(stream)
    local co = coroutine.running()

    -- 这个 callback 会被登记到 runloop 中, 其实是在 主线程的;
    local callback = (function(line)
        coroutine.resume(co, line) -- 在主线程调用 resume, 会进入 协程内
    end)
    lib.readline(stream, callback)

    -- 在协程内, 本语句 先于上面的 resume() 被调用, 然后被挂起停在这儿,
    -- 直到 上面的 resume() 被调用;
    -- 然后主线程会一直停止在这儿, 直到 协程读完那行代码, 然后将 line 从此处的 yield() 返回到主线程;
    local line = coroutine.yield() 
    return line
end


---------------------------------------------------------------------
-- 最后的逻辑代码是这样的：
run(function()
    local t = {}
    local inp = io.input()
    local out = io.output()
    while true do
        local line = getline(inp)
        if not line then
            break
        end
        t[#t + 1] = line
    end
    for i = #t, 1, -1 do
        putline(out, t[i] .. '\n')
    end
end)





























