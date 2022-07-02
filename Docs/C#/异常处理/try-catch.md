# ================================================================ #
#                try-catch  微软文档翻译
# ================================================================ #

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch


try-catch 声明包含一个 try代码块, 后面跟随一到多个 catch 代码块; 这些 catch 被用来处理不同类型的 异常;

当一个异常被抛出, the common language runtime (CLR) 查找本层的那些 catch 块, 看看哪一个是正好处理这种异常的; 如果当前层没找到, 就去这个函数的调用者那一层(更上一层) 的 catch 块中去找, 依次向上追溯, 直到找到第一个可以处理本异常的 catch 块;

如果全程都没找到, 则 clr 抛出一个 unhandled exception message, 同时终止程序;

# 为啥要 异常处理呢 ?
如果调用某函数出现一个异常, 而我们又手动处理它了, 那么程序就不会报错, 然后继续运行下去;

# try 代码块:
它包含了受保护的代码, 这些代码中有可能会抛出异常, 这个代码块会被照常执行, 直到遭遇到一个 异常, 或者它的所有代码正常执行完毕; 

# catch:
其实可以写 "无参数和括号" 版的 catch, 比如这样;
    try
    {
        ...
    }
    catch
    {
        ...
    }
但这是不推荐的写法, 最好还是设置一个参数, 它的类型派生于 System.Exception;


# 多个 catch 块:
此时, 如何排列这些 catch 块的顺序很重要; 因为它们会被逐个检查; 应该把更具体的 catach 放前面, 把含糊笼统的 catch 放后面; 

The compiler produces an error if you order your catch blocks so that a later block can never be reached.
---
猜测: 如果把笼统的 catch 放前面, 那么后面的具体的 catch 将永远无法到达; 此时编译器会抛出异常;

# exception filter 异常过滤器:
如下:
    catch (ArgumentException e) when (e.ParamName == "…")
    {
        // recover from exception
    }

如果 异常 e 的条件不符合, 那么 clr 将会继续查找后面的 catch 块;

exception filter 要比: "catch 然后重新 throw" 要更可取, 因为后者往往需要嵌套更多的函数栈; 后者只会在自己抛出异常的那一层报出来, 但你不会知道真正出现问题的 原始层在哪;

exception filter 的一个常见用途是 打log:
You can create a filter that always returns false that also outputs to a log, you can log exceptions as they go by without having to handle them and rethrow.

# re-throw (重抛异常):
可在 catch 中使用 throw 声明, 重新把捕捉到的异常 抛向上层;









