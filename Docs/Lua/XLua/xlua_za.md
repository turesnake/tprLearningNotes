# ================================================================ #
#                  xlua za
# ================================================================ #


https://github.com/Tencent/xLua

下载后查看 demo 项目;




#  xlua源码分析
https://blog.csdn.net/Jesse__Zhong/article/details/111744622



# 看懂Xlua实现原理——从宏观到微观（1）传递c#对象到Lua
https://zhuanlan.zhihu.com/p/146377267



# ----------------------------------- #
#   如何查找 xlua 各种 attributes 的使用文档
# ----------------------------------- #
直接去 xlua 源文件, 搜索 "CSharpCallLua"
可找到一个名为: "configure.md" 的文件




# ----------------------------------- #
#      CSharpCallLua
# ----------------------------------- #

    [XLua.CSharpCallLua]
    public interface ICalc {}

    [XLua.CSharpCallLua]
    public delegate double LuaMax(double a, double b);

这些原本是 lua 中的接口或 委托类型;
现在使用 CSharpCallLua, 在 cs 层中再声明一遍;
然后就能把 lua 代码中的 目标委托类型的 委托实例 获取到 cs层中, 然后在 cs 层中调用这个 lua 委托;
比如:

    var max = luaenv.Global.GetInPath<LuaMax>("math.max");

max 就是得到的 lua 函数; 然后就能调用它:

    Debug.Log("max:" + max(32, 12));

建议绑定一次，重复使用。生成了代码的话，调用max是不产生gc alloc的。



    


# [XLua]lua和c#交互
https://blog.fengyiqun.com/?p=779

写得不太好.....




# ----------------------------------- #
#    如何 实例化一个 c# 类对象;   constructor,  New
# ----------------------------------- #

# --- 在 c# 中为:
    var buffer = new ComputeBuffer(128, sizeof(uint));

# --- 翻译到 lua 中则是:
    local buffer = CS.UnityEngine.ComputeBuffer( 128, 4 )





# ----------------------------------- #
#     如何在 lua 中构造 泛型 实例. 比如 List
# ----------------------------------- #
https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/faq.md#%E6%B3%9B%E5%9E%8B%E5%AE%9E%E4%BE%8B%E6%80%8E%E4%B9%88%E6%9E%84%E9%80%A0

    local lst = CS.System.Collections.Generic["List`1[System.String]"]()
    ---
    后面的 圆括号 里是可以传参的

这个文档写的很好.....


# --- List< List<Vector3> >
    版本大于 v2.1.12 的 xlua 可使用:
        local type_1 = CS.System.Collections.Generic.List(CS.UnityEngine.Vector3)
        local type_2 = CS.System.Collections.Generic.List( type_1 )
        ll = type_2()




# ----------------------------------- #
#     如何在 lua 中构造 数组 实例;  array 
# ----------------------------------- #
https://blog.csdn.net/qq_42385019/article/details/108962978


    local ary = CS.System.Array.CreateInstance( typeof(CS.System.Int32), 5 )
    print( ary.Length )
    print( ary[0] )

# 注意, 不能用: 
    for k,v in pairs(ary) do
        ...
    end 
    ---
    去遍历这个 ary, 因为它不是 lua 的 table; 
    只能老老实实用 c# 方式去遍历;




# ----------------------------------- #
#     如何访问 C# 中的 私有 成员
# ----------------------------------- #

在 lua 中写: 
xlua.private_accessible(CS.AA)

然后就能访问 AA 类中的 私有成员了;



# ----------------------------------- #
#     访问 xlua 中 lua 的版本
# ----------------------------------- #

搞一个 lua 脚本, 打印:
    print("当前 lua 的版本: ".._VERSION)

# 目前已经升级为 5.4





