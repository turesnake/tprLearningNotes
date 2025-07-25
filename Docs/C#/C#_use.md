# ================================================================ #
#                         C# 使用技巧
# ================================================================ #

2019 现在的 c# .net core 已经支持 win/mac/ubuntu 等多平台。
可以尝试利用 c# 来支援一些 纯 C++ 项目。

# ---------------------------------------------- #
#            Mac .Net vscode 
# ---------------------------------------------- #
-- 安装 .Net core (SDK)
-- cd "项目"dir
-- dotnet new console
-- 进入 vscode 编辑项目

-- 在 "XXX.csproj" 中，添加
	<RuntimeIdentifiers>win10-x64;osx-x64;linux-x64</RuntimeIdentifiers>
	---
	支持 三个 主流平台

-- dotnet publish -c Release -r win10-x64
-- dotnet publish -c Release -r osx-x64
-- dotnet publish -c Release -r linux-x64
	-----
	这样就生成了 exe 可执行文件


# ---------------------------------------------- #
#           win10 .Net vscode 
# ---------------------------------------------- #


# ---------------------------------------------- #
#            多行字符串
# ---------------------------------------------- #
string str = @"1111
				2222
				3333";

# ---------------------------------------------- #
#         float 值 小数点后保留两位 
#           (通常是打印的时候)
#           浮点数精度
# ---------------------------------------------- #
float val = 0.1234567f;
string output = val.ToString("0.00");



# ---------------------------------------------- #
#           C#_app_with_CPP_libs
# ---------------------------------------------- #
使用 P/Invoke：


========= 调用 C++ 函数 =========
	[DllImport("somelib")]
    private static extern void outFunc(int _val);
    -------
    在新版实现中，不需要写 dll 后缀，有利于跨平台


==== 将 C# 函数，当做 callback 传递给 CPP ====
	private delegate int del_CSFunc(int _val);

	[DllImport("somelib")]
    private static extern void callbackFunc(del_CSFunc _del_func);

    private static int csFunc_1(int _val){
        return _val * 3;
    }
    ----------
    测试表明，c#函数指针，可以被传递给 cpp。
    （在 官方案例中，这个函数指针，是一个 static 成员函数）
    cpp 可以长久保存这枚指针。
    在以后的某个时间段，cpp主动调用这个指针。


# ---------------------------------------------- #
#            识别当前 OS
# ---------------------------------------------- #
System.OperatingSystem class

using System;
OperatingSystem os = Environment.OSVersion;

os.Platform:
	Win32NT
	MacOSX  (在 .net core, 这个值会被 Unix 替代)
	Unix
	----------
	综上来看，对比 Win32NT 即可



# ---------------------------------------------- #
#        查看 dll 符号表
# ---------------------------------------------- #
win：
	dumpbin /exports xxx.dll
osx：
	nm ...
	(很麻烦的一个工具...)




# ---------------------------------------------- #
#        获得  所在目录 的 path
# ---------------------------------------------- #
string path = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);




# ---------------------------------------------- #
#            ArrayList (不推荐)
# ---------------------------------------------- #
不推荐使用，
对于 混杂元素的存储，推荐   List<object>
对于 单类型元素的存储，推荐 List<T>

ArrayList 的性能也欠佳

支持 null 作为有效元素。




# ---------------------------------------------- #
#           ReadOnlyCollection<T>
# ---------------------------------------------- #
建立一个 集合的 read-only wrapper。
可用于返回值。

public ReadOnlyCollection<int> get_val(){
	return new ReadOnlyCollection<int>(innCollection);
}

public ReadOnlyCollection<int> rets{
	get { return new ReadOnlyCollection<int>(innCollection) };
}

...

# ---------------------------------------------- #
#               Action<T>
#               Func<TResult>
#               Predicate<T>
# ---------------------------------------------- #
System 自带的一组 delegate。
官方推荐使用这组默认的委托，尽量不要自定义。

public delegate void Action<in T>(T obj);

public delegate TResult Func<out TResult>();

public delegate bool Predicate<in T>(T obj);

--------
如果要委托的方法没有参数也没有返回值就用  Action
有参数但没有返回值就用  Action<T>
无参数有返回值、有参数且有返回值就用  Func<T>
有bool类型的返回值，多用在比较器的方法，要委托这个方法就用 Predicate<T>



# ---------------------------------------------- #
#            P/Invoke -- C++
# ---------------------------------------------- #
想要让 c++ 中的 函数符号，被外部访问到，需要注意。
举例：
	int outFunc();
	在这个函数的 定义文件 .cpp 中，
	务必需要 #include "cpp_2_cs.h" 



# ---------------------------------------------- #
#            P/Invoke 开销
# ---------------------------------------------- #
每次 P/Invoke 调用，消耗 10～30个 x86指令周期。
潜在的更大的消耗，在于 marshaling。
尤其是 blittable类型，和 non-blittable类型 之间的 转换。

----
在实际测试中：
++ P/Invoke 可以几乎忽略不计。

----
当 cpp，cs都开启优化时。
++ 所有类型的调用，一律提速4倍

----
当 cpp 未开启优化，cs 开启优化时：
++ 纯 cs调用 得到 提速
++ cpp 调用 cs函数 得到 提速。
-- 纯 cpp调用 维持 原速
-- cs 调用 cpp函数 维持 原速。

=========
目前来看，最大的 开销挑战 还是 marshaling。

由于 cs 代码更为安全，更容易开启优化
而 cpp编译器的 优化要激进很多。
建议将更多代码 移植到 cs 层。
---
在一种保守策略中，cpp将为此未优化，而cs 则始终开启优化。



时间库，尤其适用于 测试一段代码的运行时间





# ---------------------------------------------- #
#            local const   局部常量
#            member const  成员常量
#            static        静态量
# ---------------------------------------------- #

# -- local const 局部常量
声明在 方法内部,

必须得在声明时立刻初始化, 且要用 明确得值(简单类型得) 或这些值组成的表达式 来初始化.
这些值 必须在编译期 是确定的.
引用类型的, 可以被初始化为 null, 但不能被初始化为一个 某个对象的引用. 毕竟在编译器,这个对象是不存在的.

一旦被初始化, 之后不能再被修改


# -- static 静态量
和 c++ 中一致, 就是个 class 层级的变量.


# -- member const  成员常量
声明在 class 中, 而不是 方法内.

必须得在声明时立刻初始化, 且要用 明确得值(简单类型得) 或这些值组成的表达式 来初始化.
这些值 必须在编译期 是确定的.

一旦被初始化, 之后不能再被修改

和 static 变量相似, 可在外部用 class 名直接访问,比如: X.val 

和 static 变量不同的是:
在编译期, 所有 member const 变量都会被立刻替换为一个 具体的值, 即, 这个变量消失了.





# ---------------------------------------------- #
#        表达式函数体成员  (C# 6.0, c# 7.0)
#                =>
# ---------------------------------------------- #
具体可查阅 <图解教程> p-526

如果一个函数体, 是由单个表达式 构成的, 就能被简写为 "表达式函数体成员"

# --
c# 6.0 中, 可用于: 方法, 属性的get, 
c# 7.0 中, 增加了: 构造函数, 终结函数(finalizer), 属性set, 索引器

# -- 声明一个 方法:
float Add(float a, float b) => a+b;

# -- 声明一个 只读属性 get:
string SampleName => this.bufferName;



# ---------------------------------------------- #
#        using static ClassA;
# ---------------------------------------------- #
和 using nameSpace; 指令差不多, 不过不是针对 namespace,而是针对一个 类型. 

It makes all constant, static, and type members of a class or struct 
directly accessible without fully qualifying them.

让目标类中, 所有的 const, static 变量/函数 都可直接调用( 无需写为 ClassA.Foo() )



# ---------------------------------------------- #
#       null-coalescing operator: ?? 空接合运算符
# ---------------------------------------------- #
用 catlike srp 教程中代码举例:

	CameraSettings Settings => settings ?? (settings = new CameraSettings());

这是一个 只读属性, 内置一个 getter. 意思为:
# 返回变量 settings, 如果它为 null, 就立刻给它新建一个实例, 然后再返回它.
相等于:
	CameraSettings Settings =>
		settings == null ? settings = new CameraSettings() : settings;

也相等于:
	CameraSettings Settings {
		get {
			if (settings == null) {
				settings = new CameraSettings();
			}
			return settings;
		}
	}


# ================================================ #
#   Nullable Types   			可空对象
# 	Null Conditional Operator 	空条件运算符
# ------------------------------------------------ #




# --------------------------- #
# Null Conditional Operator 	空条件运算符
# ==:
	int[] nums = null;
	int n1 = nums.Length; 	// 会产生异常,进而报错
	var e1 = nums[0];		// 会产生异常,进而报错

	int? n2 = nums?.Length;
	var e2 = nums?[0];
# --
首先检查目标变量是否为 null, 若为null, "?." 运算返回的也是一个 null,
否则,执行正常的 . 访问运算;

# 注意: int? n2 = nums?.Length;
因为 右侧返回的内容可能为 null, 左侧用 int 去接是不可行的, 
此时要用 可空类型 int? 去接;


# 空条件运算符 最常用的场合是 delegate 的调用:
不再需要写:
	if(handler != null){       
		handler(this, args);   
	}

可以改写为:
	handler?.Invoke(this, args);

# 可空参数:
	void KKK( int? expectSize_ = null )
	{
		...
	}
	---
	以上函数的 expectSize_ 参数就是可以不用填的;



# === 空条件运算符 与 空接合运算符 的联合使用 ==

	int studentCount = Students?.Count ?? 0;

-1- 若 Students为空, 中间获得 null, 被 ?? 接住后, 自动新建值 0 并返回
-2- 若 Students不为空, 但 Count 为空, 被 ?? 接住后, 自动新建值 0 并返回
-3- Students?.Count 获得非空值, 直接返回这个值


# ----------:
# HasValue:
# Value 

int? kk;
if( kk.HasValue == false )
{
	kk = 123;
}

# If a value of type T has not been assigned to the Nullable<T> object, you can compare it to null and retrieve its `HasValue` property, 
# but you cannot access its `Value` property or call its other members.



# ---------------------------------------------- #
#    C# 8.0 的 Null 合并赋值运算符（null-coalescing assignment operator）
# ---------------------------------------------- #

_GpuVertices ??= m_Mesh.GetVertexBuffer(0);

只有当左侧的 _GpuVertices 为 null 时, 才执行本句的 赋值运算, 将右侧的值赋值给左侧;




# ---------------------------------------------- #
#       float 最大值
# ---------------------------------------------- #
float.MaxValue


# ---------------------------------------------- #
#       default(T) 表达式
# ---------------------------------------------- #

T t = default(T);

# 猜测:
感觉这句话的意思就是 初始化一个 所有变量成员都为默认值 的 实例;

catlike 使用此语句来偷懒, 它是这么用的:
	var k = default(T).doSome();

等同于:
	var k = new T().doSome();



# ---------------------------------------------- #
#       Extension Methods   扩展方法
# ---------------------------------------------- #
可在不修改 原class 代码的前提下, 扩展这个 class 的 method, 非常有用; 

假设已经存在一个 class A;
可为其实现 扩展方法:

	static class A_Extensions
	{
		public static foo( this A a )
		{...}
	}

之后, 我们就能直接调用: 

	A an = new A();
	an.foo();

# 注意, 这里的 static class 的名字可以自定义, 就比如上面的 A_Extensions


# 离谱的是, 我们甚至能为 Enum 类型实现 Extension Methods
# 这样一来, enum instance 也能调用自己的函数了,
# 通常在这种代码中, 实现 enum instance 到某种具体类型实例的 转换





# ---------------------------------------------- #
#       internal
# ---------------------------------------------- #
	class AsyncOperation : YieldInstruction
	{
		internal IntPtr m_Ptr;
	}
	---
	the internal keyword is an access modifier that specifies that a method or class is only accessible within the same assembly.
	只能在本程序集内被访问



# ---------------------------------------------- #
#       extern
# ---------------------------------------------- #
	class AsyncOperation : YieldInstruction
	{
		public extern bool isDone
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("IsDone")]
			get;
		}
	}
	---
	 The extern keyword, on the other hand, is used to declare a method that is implemented externally
	 本函数在外部被实现
	When you use the extern keyword, you are telling the compiler that the method is implemented outside of C# code. 
	This is useful when you are using Interop services to call into unmanaged code


# ---------------------------------------------- #
#      标准 Dispose 模式
# ---------------------------------------------- #
如果你的 class 中存在 未托管资源, 并且想在某个时间点及时释放它,
此时不该用 析构函数 (因为析构函数的调用时间不确定)
此时该用 Dispose 模式;

如果 class 包含了未托管资源, 此 class 应实现 IDisposable 接口;
此接口包含:
	void Dispose();

	所有释放 未托管资源 的代码, 都要写在 Dispose() 中;

# Dispose 函数 应该被你自己的代码调用, 系统不会调用它;

# 你还应该为你的 class 实现一个 析构函数, 并在里面调用 Dispose()
	以防止在此之前并未成功释放 资源时, 最后的GC阶段, 能调用 Dispose();

但是因为资源不能被重复释放, 所以还需一点代码来让 GC 在调用析构函数中的
Dispose() 时, 知道资源是否被释放, 自己要不要负责释放资源;

# 图解一书 给出了编写示范, 可以参考...




# ---------------------------------------------- #
#      class Enum;
# ---------------------------------------------- #
using System;

是所有 enum 类型的 通用 基类; 有时会当作 通用参数/返回值类型 来使用,

可使用类型转换操作:
	(TypeA)someVal;

# 当转换的目标类型, 不是我们想要的类型时, 并不会报错

# 如果原 enum 值, 在转换的错误的新类型中, 是越界的, 
	那么打印的时候只会显示 数字

# 如果越界的同时, 新类型还标记了 [Flags], 那么这个错误的值,
# 会被当成 组合值来理解
	此时若打印, 可能会显示好几个值;
	(系统将其理解成了数个 enum值的 位与 运算的结果)



# 如何得到一个 enum class 元素个数:
	using System;
	enum Fruits { Apple, Orange, Peach }
	public int FruitCount = Enum.GetNames(typeof(Fruits)).Length;



# ---------------------------------------------- #
#   c#8.0   using var
# ---------------------------------------------- #
using 常被用来保障非托管资源的释放:
# ==:
	void Foo(){
		using (var a = ...)
		{
			// do something a...

			using (var b = ...)
			{
				// do something b...

				using (var c = ...)
				{
					// do something c...

				}// c 资源被释放
			}// b 资源被释放
		}// a 资源被释放
	}
# --code-end

但是如果想上图这样嵌套多个资源, 容易让代码缩进太过厉害;

c#8.0 中引入了新的用法, 支持没有 {} 的写法, 上面的代码可变成:
# ==:
	void Foo(){
		using var a = ...;
			// do something a...

		using var b = ...;
			// do something b...


		using var c = ...;
			// do something c...
	}
	// 资源 c,b,a, 被释放
# --code-end
代码变得工整很多



# ---------------------------------------------- #
#      ref 传参
# ---------------------------------------------- #
不是只有 引用类型实例参数 才可通过 ref 传入, 值类型也可以;
而且 值类型其实更适合;

	int a = 100;

	void Change( ref int e )
	{
		e--;
	}

	print( ref a ); // 将得到 99;
	----

此处虽然 a 是值类型, 也是可以被 函数 Change() 改写的;

# 数组作为参数时...

	void Foo( int[] nums );
	---
	此时就算不使用 ref, 也能在函数体内修改 数组内的内容...



# ---------------------------------------------- #
#     实现 swap 功能: 交换两元素
# ---------------------------------------------- #

借用 tuple 来实现:

	(a,b) = (b,a);


# ---------------------------------------------- #
#     数组元素内有两值时, 如何写排序
# ---------------------------------------------- #

	Array.Sort(
		nums,
		(a,b)=>(a[0]!=b[0] ?
				a[0].CompareTo(b[0]) : // 优先按照 第一个元素做 升序排序
				a[1].CompareTo(b[1]))  // 其次按照 第二个元素做 升序排序
	);



# ---------------------------------------------- #
#     运算符重载 ==, !=
# ---------------------------------------------- #

public class A 
{
    public string keyStr;

    public static bool operator == ( A a, A b )
    {
        if( (object)a == null && (object)b == null ) // 此处的 == 使用的是 object 类型的;
        {
            return true;
        }
        if( (object)a == null || (object)b == null ) // 此处的 == 使用的是 object 类型的;
        {
            return false;
        }
        return a.keyStr == b.keyStr;
    }
    public static bool operator != ( A a, A b )
    {
        return !(a == b);
    }
}


# ---------------------------------------------- #
#     as 运算符 返回值
# ---------------------------------------------- #

	class Base{}
	class CC : Base{}
	class DD : Base{}
	//---
	CC c = new CC();
	Base cb = c;

	var ret = cb as DD;

上例中, ret 值为 null, 因为它无法被转换为 DD 类型;
可用此方法来做一些检测;




# ---------------------------------------------- #
#              is
# ---------------------------------------------- #

# --1--
	if (value is Transform )
	{
		//...
	}
	---
	is 判断 左侧表达式的返回值的类型 是否与 右侧类型 "匹配" (compatible)
	The is operator checks if the result of an expression is compatible with a given type.


# --2--
	if ( iBoxed is int a )
	{
		Console.WriteLine(a);
	}
	---
	不关做判断, 如果为 true, 还会初始化变量 a, 
	关键词:
		Declaration and type patterns
		Declaration pattern

	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#declaration-and-type-patterns
	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#is-operator



# ---------------------------------------------- #
#   如何得到一个 变量的 type
# ---------------------------------------------- #

# 使用: val.GetType()

	Transform tf = ...;
	Type type = tf.GetType();

	就能得到 Type 信息;


# ---------------------------------------------- #
#   如何判断一个 变量的 type 是不是属于某个 TypeA
# ---------------------------------------------- #

	Texture asset;
    typeof(Texture).IsInstanceOfType(asset)




# ---------------------------------------------- #
#  在 基类 里如何得知 派生类 的名字
# ---------------------------------------------- #

# this.GetType().Name

	public class MyBaseClass
	{
		public string GetDerivedClassName()
		{
			return this.GetType().Name;
		}
	}

	public class MyDerivedClass : MyBaseClass
	{
	}



# ---------------------------------------------- #
#        NaN
# ---------------------------------------------- #

# 一个浮点数 减去一个 NaN, 得到的还是 NaN;




# ---------------------------------------------- #
#      sizeof(char)
# ---------------------------------------------- #

有时得到 2 .....
需要有空查下



# ---------------------------------------------- #
#          params object[] args
# ---------------------------------------------- #
可变参数列表，你可以传 0～N 个任意类型的参数，方法内部会把它们当作一个 object[] 数组处理。


void Func(object[] args)
{
    int score  = (int)args[0];
    string id  = (string)args[1];
    bool  flag = (bool)args[2];
    // …处理逻辑…
}

主要缺点有两方面：可维护性（类型安全）和性能。

类型安全／可维护性问题

	调用方和接收方之间没有编译期契约，完全靠“约定”来解析 object[]，容易出错。
	参数顺序、类型、数量都得记清楚，改动难追踪、易出运行时异常 (InvalidCastException)。
	不利于 IDE 智能提示，也不便于文档化。

性能开销

	数组分配
	每次调用都会在堆上 new 一个 object[]，增加 GC 压力。
	装箱／拆箱
	值类型（int／float／struct）要丢进 object 里会先装箱，接收方再拆箱，CPU 开销和额外分配都不少。
	调用开销
	虽然不算 reflection 那么慢，但内部还是要把可变参数收集到数组里，遍历、拆箱也都有额外指令。










