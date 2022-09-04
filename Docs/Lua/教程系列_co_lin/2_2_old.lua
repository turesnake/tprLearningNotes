-- oldmod.lua
local M = {}

-- 缓存列表
local cachelist = {}

-- 将值压入缓存
local function push_to_cache(v)
    table.insert(cachelist, v)
end

-- 从缓存取出值
local function pop_from_cache()
    if #cachelist > 0 then
        local v = cachelist[#cachelist]
        cachelist[#cachelist] = nil
        return v
    end
end

-- 新建一个点
function M.new_point(x, y)
    local p = pop_from_cache()
    if not p then
        p = {x = x, y = y}
    end
    return p
end

-- 释放这个点
function M.free_point(p)
    push_to_cache(p)
end

-- 打印点的缓存 
function M.print_cache()
    for _, p in ipairs(cachelist) do
        print(p.x, p.y)
    end
end

return M

