local function map(a, f) -- 用 f 对 a 中元素逐个处理一遍;
    for i = 1, #a do
        a[i] = f(a[i])
    end
    return a
end
local prefix = "[DEBUG]"
local function printlist(a) -- 单纯把 a 中元素按照一定格式都打印出来
    local c = table.concat(a, ", ")
    local s = string.format("%s {%s}", prefix, c)
    print(s)
end
local function test()
    local a = map({1, 2, 3}, function(e) 
        return e * 2 
    end)
    printlist(a)
end
test()

