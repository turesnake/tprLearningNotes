


# ----------------------------------- #
#     如何在 lua 中构造 泛型 实例. 比如 List
# ----------------------------------- #
https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/faq.md#%E6%B3%9B%E5%9E%8B%E5%AE%9E%E4%BE%8B%E6%80%8E%E4%B9%88%E6%9E%84%E9%80%A0

    local lst = CS.System.Collections.Generic["List`1[System.String]"]()
    ---
    后面的 圆括号 里是可以传参的

这个文档写的很好.....



# 抄录: -----------------------------------------
## 泛型实例怎么构造

涉及的类型都在mscorlib，Assembly-CSharp程序集的话，泛型实例的构造和普通类型是一样的，都是CS.namespace.typename()，可能比较特殊的是typename的表达，泛型实例的typename的表达包含了标识符非法符号，最后一部分要换成["typename"]，以List<string>为例

~~~lua
local lst = CS.System.Collections.Generic["List`1[System.String]"]()
~~~

如果某个泛型实例的typename不确定，可以在C#测打印下typeof(不确定的类型).ToString()

如果涉及mscorlib，Assembly-CSharp程序集之外的类型的话，可以用C#的反射来做：

~~~lua
local dic = CS.System.Activator.CreateInstance(CS.System.Type.GetType('System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[UnityEngine.Vector3, UnityEngine]],mscorlib'))
dic:Add('a', CS.UnityEngine.Vector3(1, 2, 3))
print(dic:TryGetValue('a'))
~~~

如果你的xLua版本大于v2.1.12，将会有更漂亮的表达方式

~~~lua
-- local List_String = CS.System.Collections.Generic['List<>'](CS.System.String) -- another way
local List_String    = CS.System.Collections.Generic.List(CS.System.String)
local lst = List_String()

local Dictionary_String_Vector3 = CS.System.Collections.Generic.Dictionary(CS.System.String, CS.UnityEngine.Vector3)
local dic = Dictionary_String_Vector3()
dic:Add('a', CS.UnityEngine.Vector3(1, 2, 3))

print(dic:TryGetValue('a')) -- !!!!!!!!!


# -- 可以用: 
    for k,v pairs(dic) do 
    end 
    ---
    来遍历 Dictionary, SortedDictionary;


# !!!! 注意:
    LinkList.First 这种返回类型为 LinkedListNode<T> 的属性, 暂时不知道怎么取到它的值; 
    所以几乎是废的...



# ----------------------------- #
#   支持 嵌套容器
# ----------------------------- #
    local ListT = CS.System.Collections.Generic.List(CS.System.Int32)

    local Dictionary_InstanceID_idxs = CS.System.Collections.Generic.Dictionary(CS.System.Int32, CS.System.Collections.Generic.List(CS.System.Int32))
    local dict = Dictionary_InstanceID_idxs()

    dict:Add( 101, ListT() )
    dict[101]:Add( 1 )
    dict[101]:Add( 2 )
    dict[101]:Add( 3 )


# !!!!!!  这么写是对的;





~~~
# --------------------------------------------------


#  具体尝试:


# --- List< List<Vector3> >
    版本大于 v2.1.12 的 xlua 可使用:
        local type_1 = CS.System.Collections.Generic.List(CS.UnityEngine.Vector3)
        local type_2 = CS.System.Collections.Generic.List( type_1 )
        ll = type_2() -- 构造实例

    之后可以用:

        ll[3] 来访问元素, 和 c# 一样;



# -------------------------------------- #
#       数组, Array
# -------------------------------------- #
    local array = CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)




