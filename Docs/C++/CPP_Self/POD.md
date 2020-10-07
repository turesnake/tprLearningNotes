

# ----------------------------------------------#
#                   POD
# ----------------------------------------------#
bool b = std::is_trivial<T>::value; // 是否平凡
bool b = std::is_standard_layout<T>::value; // 是否标准布局
bool b = std::is_pod<T>::value;
===================
总结：
-- 不能使用 {} 来初始化类内成员变量
-- 类内成员变量，不能为 stl容器
-- 类内成员变量，可为 指向 stl容器 的普通指针
-- 类内成员变量，不能为 智能指针
-- 类内成员变量，不能放入 std::function 制作的函数对象
-- 类内成员变量，也都应该为 POD（致命）
++ 可以使用 T()=default;


例子：
#----------------------
struct SA{
    int val {};
};
	----
	SA is Not Trivial;
	SA is Standard Layout;
	SA is Not POD;
	====
	所以，一个 POD，不应该使用 {} 来初始化类内成员变量

#----------------------
struct SA{
    std::vector<int> iv;
};
	----
	SA is Not Trivial;
	SA is Standard Layout;
	SA is Not POD;
	====
	stl容器 不要直接放进 POD 内


#----------------------
struct SA{
    std::vector<int> *ivPtr;
};
	----
	SA is Trivial;
	SA is Standard Layout;
	SA is POD;
	====
	但是可以使用 指针来指向某个 stl容器

#----------------------
struct SA{
    std::unique_ptr<int> bbUPtr;
};
	----
	SA is Not Trivial;
	SA is Standard Layout;
	SA is Not POD;
	====
	不能放入 智能指针(shared_ptr 一样)

#----------------------
using F_void = std::function<void()>;
struct SA{
    F_void funPtr;
};
	----
	SA is Not Trivial;
	SA is Standard Layout;
	SA is Not POD;
	====
	不能放入 std::function 制作的 函数对象


#----------------------
struct SA{
    SA()=default;
    int tmp;
};
	----
	SA is Trivial;
	SA is Standard Layout;
	SA is POD;
	====
	可以使用 T()=default;
	

#----------------------
class Ent{
    int tmp {};
};
struct SA{
    Ent ent;
};
	---
	SA is Not Trivial;
	SA is Standard Layout;
	SA is Not POD;
	====
	所有 成员变量类型，也都应该为 POD







