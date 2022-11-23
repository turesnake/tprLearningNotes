#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Globalization;

namespace System
{
    public readonly struct Int32 : 
                                IComparable, 
                                IComparable<Int32>, 
                                IConvertible, 
                                IEquatable<Int32>, 
                                IFormattable
    {
        public const Int32 MaxValue = 2147483647;
        public const Int32 MinValue = -2147483648;


        /*
            Converts the string representation of a number to its 32-bit signed integer equivalent. 
            若参数无法转换, 将抛出异常;
        */
        public static Int32 Parse(string s, IFormatProvider provider);
        public static Int32 Parse(string s, NumberStyles style, IFormatProvider provider);
        public static Int32 Parse(string s);
        public static Int32 Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider provider = null);
        public static Int32 Parse(string s, NumberStyles style);

        /*
            Converts the string representation of a number to its 32-bit signed integer equivalent. 
            A return value indicates whether the conversion succeeded.
            ---
            ret:
                When this method returns, contains the 32-bit signed integer value equivalent of the number contained in s, if the conversion succeeded, 
                or zero if the conversion failed. 
                The conversion fails if the s parameter is null or Empty, is not of the correct format, or represents a number less than Int32.MinValue or greater than Int32.MaxValue. 
                This parameter is passed uninitialized; any value originally supplied in result will be overwritten.
            ===
            出现异常时会返回 false, 而不是抛出异常
        
        */
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Int32 result);
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out Int32 result);
        public static bool TryParse(ReadOnlySpan<char> s, out Int32 result);
        public static bool TryParse(string s, out Int32 result); // 最常用

        /*
            ret:
                This instance is less than value.       --> ret < 0;
                This instance is equal to value.        --> ret   0;
                This instance is greater than value.    --> ret > 0;
            ------
            这个返回值规则非常类似 Comparison<> 委托的规则;
        */
        public Int32 CompareTo(object value);
        public Int32 CompareTo(Int32 value);


        public override bool Equals(object obj);
        public bool Equals(Int32 obj);
        public override Int32 GetHashCode();
        public TypeCode GetTypeCode();
        public override string ToString();
        public string ToString(IFormatProvider provider);
        public string ToString(string format);
        public string ToString(string format, IFormatProvider provider);
        public bool TryFormat(Span<char> destination, out Int32 charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null);
    }
}

