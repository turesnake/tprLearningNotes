# ================================================================ #
#                  xlua za
# ================================================================ #



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








