-- newmod.lua
local M = {}
local hotfix = require "hotfix"
-- 缓存的最大长度，这是新的upvalue
local maxlen = 5
-- 这里表示cachelist和pop_from_cache将使用旧模块的值
local cachelist = hotfix.OUV
local pop_from_cache = hotfix.OUV
-- 将值压入缓存
local function push_to_cache(v)
    -- 增加最大长度判断
    if #cachelist < maxlen then
        table.insert(cachelist, v)
    end
end
-- 新建一个点
function M.new_point(x, y)
    -- 这个pop_from_cache将是旧模块的函数
    local p = pop_from_cache()
    if not p then
        p = {x = x, y = y}
    else
        -- 这里是新加的代码
        p.x = x
        p.y = y
    end
    return p
end
-- 释放这个点
function M.free_point(p)
    push_to_cache(p)
end

return M