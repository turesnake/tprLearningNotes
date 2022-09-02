-- hotfix.lua
--- 收集一个函数用到的upvalue
--@param f 函数
--@param uv upvalue信息表
local function collect_upvalue(f, uvmap)
    local i = 1
    while true do
        local name, value = debug.getupvalue(f, i)
        if name == nil then
            break
        end
        local id = debug.upvalueid(f, i) -- 取函数 f 第 i 个 upvalue 的唯一ID (是一个lightuserdata)。
        if uvmap[name] then
            assert(uvmap[name].id == id, string.format("Ambiguous upvalue %s", name))
        else
            uvmap[name] = { func = f, index = i, id = id}
            -- 如果upvalue是函数，还会递归收集
            if type(value) == "function" then
                collect_upvalue(value, uvmap)
            end
        end
        i = i + 1
    end
end


--- 收集一个模块中函数关联到的所有upvalue
--@param mod 模块表
--@return 返回一个table: {name: {func=f, index=i, id=id}}
local function collect_all_upvalue(mod)
    local uvmap = {}
    for _, v in pairs(mod) do
        if type(v) == 'function' then
            collect_upvalue(v, uvmap)
        end
    end
    return uvmap
end




-----------------------------------------------------------------
-- hotfix.lua
local hotfix = {}
hotfix.OUV = {}         -- 常量，表明要关联老的uv


-- hotfix.lua
--- 热更新函数
--@param func 新模块函数
--@param upmap 老模块的upvalue
--@return 返回替换upvalue后的func
local function hotfix_func(func, upmap)
    local i = 1
    while true do
        local name, value = debug.getupvalue(func, i)
        if name == nil then
            break
        elseif value == hotfix.OUV then
            -- 引用老的upvalue
            local old_uv = upmap[name]
            if old_uv then
                debug.upvaluejoin(func, i, old_uv.func, old_uv.index)
            end
        elseif type(value) == "function" then
            -- upvalue为函数，继续patch
            hotfix_func(value, upmap)
        end
        i = i + 1
    end
    return func
end


-- hotfix.lua
--- 执行热更新
-- oldmod是旧模块
-- newmod是新模块，这个模块里只会提供要替换的函数，相当于旧模块的一个子集。
function hotfix.run(oldmod, newmod)
    -- 收集旧模块的所有upvalue
    local uvmap = collect_all_upvalue(oldmod)
    for k, v in pairs(newmod) do
        if type(v) == 'function' then
            -- 这里就是先把新函数的upvalue修正，然后直接替换给旧模块
            oldmod[k] = hotfix_func(v, uvmap)
        end
    end
end
return hotfix



