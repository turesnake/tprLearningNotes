# ================================================================//
#                         C# 使用技巧
# ================================================================//

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
#            多行字符串
# ---------------------------------------------- #
string str = @"1111
				2222
				3333";


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
string path = 
	System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
	




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


# ---------------------------------------------- #
#            TimeSpan
#            Stopwatch
# ---------------------------------------------- #
时间库，尤其适用于 测试一段代码的运行时间























