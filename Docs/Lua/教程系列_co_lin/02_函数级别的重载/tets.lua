-- test.lua
local oldmod = require("oldmod")
-- 对旧模块执行热更新
local newmod = require("newmod")
local hotfix = require("hotfix")
hotfix.run(oldmod, newmod)

local points = {}
for i = 1, 10 do
    points[#points+1] = oldmod.new_point(i, i)
end
for _, p in ipairs(points) do
    oldmod.free_point(p)
end
oldmod.print_cache()

p = oldmod.new_point(20, 1)
print("point=", p.x, p.y)

