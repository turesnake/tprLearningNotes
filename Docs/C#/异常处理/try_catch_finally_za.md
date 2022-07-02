# ================================================================ #
#                try catch finally  za
# ================================================================ #

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally


# 粒子, 让一个 string obj 转换为 int 类型, 诱发其抛出异常;

        int i = 9;
        string s = "ss";
        object o = s;

        try
        {
            i = (int)o;
        }
        catch(InvalidCastException e)
        {
            Debug.Log("catch InvalidCastException");
        }
        finally
        {
            Debug.Log("finally");
        }
---------
上述代码的最终打印为:
    "catch InvalidCastException;"
    "finally"

可以看到, catch 段先被执行, finally 段后被执行



# ------------------------------------------- #
#
# ------------------------------------------- #








