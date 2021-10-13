# ================================================================//
#                      string
# ================================================================//


# ---------------------------------------------- #
#             Split(...)
# ---------------------------------------------- #
有多个重载函数:
https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-5.0

入门用法:
# ==:
    string ss = "aa bb cc";   
    string[] words = ss.Split(' ');  
# --
    此时, words 中含有 { "aa", "bb", "cc" }


# 指定的分割符可以有多个, 甚至可先组成一个 array 后再作为参数传递进来

# 即便如此还是会得到很多 空元素, 
    此时可用 可选参数:
    StringSplitOptions.RemoveEmptyEntries 来过滤掉它们


# ---------------------------------------------- #
#     如何从一段文本 string 中提取各个单词
# ---------------------------------------------- #
阅读:
https://docs.microsoft.com/en-us/dotnet/standard/base-types/divide-up-strings

# -1- Split法:
# ==:
    string s = "You win some.   You lose some.";
    char[] separators = new char[] { ' ', '.' };
    string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

# --




















