-- https://zhuanlan.zhihu.com/p/97322052

local LUA_REFNIL = -1

-- 模拟的两个函数;

local function luaL_ref(tab, obj)
    if obj == nil then
        return LUA_REFNIL
    end
    -- 可用的ref链表
    local freelist = 0      
    -- 取链表头的ref
    local ref = tab[freelist] or 0   
    if ref ~= 0 then
        -- 从链表头弹出ref
        tab[freelist] = tab[ref]
    else
        -- 创建一个新的引用
        ref = #tab + 1;
    end
    -- 关联引用和对象
    tab[ref] = obj
    return ref
end


local function luaL_unref(tab, ref)
    if ref >= 0 then
        local freelist = 0
        -- 将ref的对象删除，并重新加入链表
        tab[ref] = tab[freelist]
        tab[freelist] = ref
    end
end

