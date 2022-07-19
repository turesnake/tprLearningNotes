#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Runtime.InteropServices;

namespace System
{
    // 用于: String.IndexOf() 中做为参数类型, 指定查找字符串的规则
    [ComVisible(true)]
    public enum StringComparison
    {
        CurrentCulture = 0,
        CurrentCultureIgnoreCase = 1,
        InvariantCulture = 2,
        InvariantCultureIgnoreCase = 3,


        // An operation that uses ordinal sort rules performs a comparison based on the numeric value (Unicode code point) of each Char in the string. 
        // An ordinal comparison is fast but culture-insensitive. 
        // When you use ordinal sort rules to sort strings that start with Unicode characters (U+), the string U+xxxx comes before the string U+yyyy 
        // if the value of xxxx is numerically less than yyyy.
        // ----
        // 基于 Unicode numeric value 来比较;
        Ordinal = 4,
        OrdinalIgnoreCase = 5
    }
}


