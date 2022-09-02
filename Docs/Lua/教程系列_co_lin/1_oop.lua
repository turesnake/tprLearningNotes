-- rtl.lua
local rtl = {} -- 模块 table 
local ksuper = {}   -- 作为查找父类的key -- 没看懂, 为啥是个表, 有啥意义吗 ?


-- 使用本函数来 定义一个 新的 Class
-- 参数: super, 基类，若为 nil, 表示没有基类;
function rtl.class(super)

    local klass = {}        -- 这就是 新建的 Class 本身 

    klass[ksuper] = super   -- 把父类table保存起来 -- 没看懂 这个 key 为啥是个 table
    klass.__index = klass   -- __index设为自己


    local _class_metatable = rtl._class_metatable   -- 这是类的元表，所有类都设置同一个元表, 
    -- 此处的 初始化 只会执行一遍, 一旦 rtl._class_metatable 有了值, 下方代码就不需要再执行了
    if not _class_metatable then -- 此时确实为 nil,
        _class_metatable = 
        {
            -- 因为在 t 自己身上找不到 k 元素, 才回来调用 __index, 此时就直接去 基类中找
            __index = function (t, k)
                local super = rawget(t, ksuper) -- 取得类的父类
                if super then
                    -- 然后继续访问k，如果找不到还会触发这个__index，一直往上追溯
                    return super[k]
                else
                    return nil
                end
            end,

            -- 假设一个 class: Cat, 可通过调用本函数来 实例化一个新对象:
            -- local cat1 = Cat("tom")
            -- 参数: cls:  Class本身
            -- 参数: ...   任意 构造函数参数
            __call = function (cls, ...)
                -- obj 就是本次要实例化的对象
                local obj = {}
                -- 将 cls 设为 obj 的元表，找不到 obj 的字段时，就会触发 klass.__index
                -- 而__index指向 kclass 自己，所以相当于在 kclass 上访问字段。
                setmetatable(obj, cls)

                -- 约定_init为类的构造函数，所以这里会调用构造函数
                -- 在调用本函数之前, 如果 cls 实现了自己的 _init() 函数; 此处就会调用之
                local _init = cls._init
                if _init then
                    _init(obj, ...)
                end
                -- 最后返回这个对象
                return obj
            end  
        }
        rtl._class_metatable = _class_metatable
    end
    -- 设置类的元表
    setmetatable(klass, _class_metatable) 
    -- 最后返回类
    return klass
end
--return rtl


------------------------------------------------------
-- animal.lua
--local rtl = require("rtl")
local Animal = rtl.class() -- 新建一个 class: Animal
function Animal.say(self)
    error("I don't known who i am ")
end
--return Animal



------------------------------------------------------
-- test.lua
--local rtl = require("rtl")
--local Animal = require("animal")

local Cat = rtl.class(Animal) -- 新建一个 class: Cat, 继承于 Animal
-- 构造函数
function Cat._init(self, name)
    self.name = name
end
-- 覆盖父类的方法
function Cat.say(self)
    print(string.format("I am a cat, my name is %s", self.name))
end

local Dog = rtl.class(Animal) -- 新建一个 class: Dog, 继承于 Animal



------------------------------------------------------
-- 创建一个Cat对象，并调用say，注意调用时用:，让cat对象作为第1个参数传入函数
local cat = Cat("tom")
cat:say()       --> I am a cat, my name is tom


-- 创建一个Dog对象，调用say，因为Dog并没有实现say函数，因此调用到Animal的say函数。最终抛出一个错误
local dog = Dog()
dog:say()       --> .\animal.lua:6: I don't known who i am



-- for k,v in pairs(ksuper) do 
--     print(k,v)
-- end


