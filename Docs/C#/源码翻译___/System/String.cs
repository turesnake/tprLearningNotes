
#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

/*
    --------------------- 如何从一段文本 string 中提取各个单词 --------------------------
    阅读:
    https://docs.microsoft.com/en-us/dotnet/standard/base-types/divide-up-strings

    # -1- Split法:
    # ==:
        string s = "You win some.   You lose some.";
        char[] separators = new char[] { ' ', '.' };
        string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
*/


namespace System
{
    [ComVisible(true)]
    [DefaultMember("Chars")]
    public sealed class String : IEnumerable<char>, IEnumerable, ICloneable, IComparable, IComparable<String>, IConvertible, IEquatable<String>
    {
        public static readonly String Empty;

        [CLSCompliant(false)]
        [SecurityCritical]
        public String(char* value);
        [SecuritySafeCritical]
        public String(char[] value);
        [CLSCompliant(false)]
        [SecurityCritical]
        public String(sbyte* value);
        public String(ReadOnlySpan<char> value);
        [SecuritySafeCritical]
        public String(char c, int count);
        [CLSCompliant(false)]
        [SecurityCritical]
        public String(char* value, int startIndex, int length);
        [SecuritySafeCritical]
        public String(char[] value, int startIndex, int length);
        [CLSCompliant(false)]
        [SecurityCritical]
        public String(sbyte* value, int startIndex, int length);
        [CLSCompliant(false)]
        [SecurityCritical]
        public String(sbyte* value, int startIndex, int length, Encoding enc);

        public char this[int index] { get; }

        public int Length { get; }


        public static int Compare(String strA, int indexA, String strB, int indexB, int length, bool ignoreCase, CultureInfo culture);
        public static int Compare(String strA, int indexA, String strB, int indexB, int length, CultureInfo culture, CompareOptions options);
        [SecuritySafeCritical]
        public static int Compare(String strA, int indexA, String strB, int indexB, int length, StringComparison comparisonType);
        public static int Compare(String strA, String strB);
        public static int Compare(String strA, String strB, bool ignoreCase);
        public static int Compare(String strA, String strB, bool ignoreCase, CultureInfo culture);
        public static int Compare(String strA, String strB, CultureInfo culture, CompareOptions options);
        [SecuritySafeCritical]
        public static int Compare(String strA, String strB, StringComparison comparisonType);
        public static int Compare(String strA, int indexA, String strB, int indexB, int length, bool ignoreCase);
        public static int Compare(String strA, int indexA, String strB, int indexB, int length);


        [SecuritySafeCritical]
        public static int CompareOrdinal(String strA, int indexA, String strB, int indexB, int length);
        public static int CompareOrdinal(String strA, String strB);


        [SecuritySafeCritical]
        public static String Concat(String str0, String str1, String str2);
        [ComVisible(false)]
        public static String Concat<T>(IEnumerable<T> values);
        public static String Concat(params String[] values);
        [SecuritySafeCritical]
        public static String Concat(String str0, String str1, String str2, String str3);
        [SecuritySafeCritical]
        public static String Concat(String str0, String str1);
        public static String Concat(params object[] args);
        [CLSCompliant(false)]
        public static String Concat(object arg0, object arg1, object arg2, object arg3);
        public static String Concat(object arg0, object arg1, object arg2);
        public static String Concat(object arg0, object arg1);
        public static String Concat(object arg0);
        [ComVisible(false)]
        public static String Concat(IEnumerable<String> values);


        [SecuritySafeCritical]
        public static String Copy(String str);


        public static String Create<TState>(int length, TState state, SpanAction<char, TState> action);


        public static bool Equals(String a, String b);
        [SecuritySafeCritical]
        public static bool Equals(String a, String b, StringComparison comparisonType);


        public static String Format(String format, object arg0);
        public static String Format(IFormatProvider provider, String format, object arg0, object arg1);
        public static String Format(String format, object arg0, object arg1, object arg2);
        public static String Format(IFormatProvider provider, String format, params object[] args);
        public static String Format(IFormatProvider provider, String format, object arg0, object arg1, object arg2);
        public static String Format(String format, params object[] args);
        public static String Format(String format, object arg0, object arg1);
        public static String Format(IFormatProvider provider, String format, object arg0);


        // Retrieves the system's reference to the specified String.
        [SecuritySafeCritical]
        public static String Intern(String str);


        // Retrieves a reference to a specified String.
        // ret A reference to str if it is in the common language runtime intern pool; otherwise, null.
        [SecuritySafeCritical]
        public static String IsInterned(String str);


        public static bool IsNullOrEmpty(String value);


        public static bool IsNullOrWhiteSpace(String value);


        [SecuritySafeCritical]
        public static String Join(String separator, String[] value, int startIndex, int count);
        [ComVisible(false)]
        public static String Join<T>(String separator, IEnumerable<T> values);
        public static String Join(char separator, params object[] values);
        public static String Join(char separator, String[] value, int startIndex, int count);
        public static String Join<T>(char separator, IEnumerable<T> values);
        [ComVisible(false)]
        public static String Join(String separator, IEnumerable<String> values);
        [ComVisible(false)]
        public static String Join(String separator, params object[] values);
        public static String Join(char separator, params String[] value);
        public static String Join(String separator, params String[] value);


        public object Clone();


        public int CompareTo(object value);
        public int CompareTo(String strB);


        public bool Contains(char value);
        public bool Contains(char value, StringComparison comparisonType);
        public bool Contains(String value, StringComparison comparisonType);
        public bool Contains(String value);


        [SecuritySafeCritical]
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);


        public bool EndsWith(String value, bool ignoreCase, CultureInfo culture);
        public bool EndsWith(String value);
        public bool EndsWith(char value);
        [ComVisible(false)]
        [SecuritySafeCritical]
        public bool EndsWith(String value, StringComparison comparisonType);


        [SecuritySafeCritical]
        public bool Equals(String value, StringComparison comparisonType);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public bool Equals(String value);
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public override bool Equals(object obj);


        public CharEnumerator GetEnumerator();


        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [SecuritySafeCritical]
        public override int GetHashCode();
        public int GetHashCode(StringComparison comparisonType);


        public TypeCode GetTypeCode();


        public int IndexOf(char value, StringComparison comparisonType);
        public int IndexOf(String value);
        public int IndexOf(char value);
        public int IndexOf(char value, int startIndex);
        public int IndexOf(String value, StringComparison comparisonType);
        public int IndexOf(String value, int startIndex, StringComparison comparisonType);
        [SecuritySafeCritical]
        public int IndexOf(String value, int startIndex, int count, StringComparison comparisonType);
        public int IndexOf(String value, int startIndex, int count);
        public int IndexOf(String value, int startIndex);
        [SecuritySafeCritical]
        public int IndexOf(char value, int startIndex, int count);
        [SecuritySafeCritical]
        public int IndexOfAny(char[] anyOf, int startIndex, int count);
        public int IndexOfAny(char[] anyOf, int startIndex);
        public int IndexOfAny(char[] anyOf);


        [SecuritySafeCritical]
        public String Insert(int startIndex, String value);
        public bool IsNormalized();
        [SecuritySafeCritical]
        public bool IsNormalized(NormalizationForm normalizationForm);


        public int LastIndexOf(String value);
        public int LastIndexOf(char value, int startIndex);
        public int LastIndexOf(String value, StringComparison comparisonType);
        public int LastIndexOf(String value, int startIndex, StringComparison comparisonType);
        [SecuritySafeCritical]
        public int LastIndexOf(String value, int startIndex, int count, StringComparison comparisonType);
        public int LastIndexOf(String value, int startIndex, int count);
        public int LastIndexOf(String value, int startIndex);
        [SecuritySafeCritical]
        public int LastIndexOf(char value, int startIndex, int count);
        public int LastIndexOf(char value);


        public int LastIndexOfAny(char[] anyOf, int startIndex);
        public int LastIndexOfAny(char[] anyOf);
        [SecuritySafeCritical]
        public int LastIndexOfAny(char[] anyOf, int startIndex, int count);


        [SecuritySafeCritical]
        public String Normalize(NormalizationForm normalizationForm);
        public String Normalize();


        public String PadLeft(int totalWidth, char paddingChar);
        public String PadLeft(int totalWidth);


        public String PadRight(int totalWidth, char paddingChar);
        public String PadRight(int totalWidth);


        [SecuritySafeCritical]
        public String Remove(int startIndex, int count);
        public String Remove(int startIndex);


        public String Replace(String oldValue, String newValue);
        public String Replace(String oldValue, String newValue, bool ignoreCase, CultureInfo culture);
        public String Replace(String oldValue, String newValue, StringComparison comparisonType);
        public String Replace(char oldChar, char newChar);

        /*
            --------------------- Split() ------------------------------
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

            # ==:
                string ss = "";   
                string[] words = ss.Split(',');
                --
                此时得到的  words 的元素个数为 1, words[0] 内容为 "";
                即: 无论如何都会得到一个元素

        */
        [ComVisible(false)]
        public String[] Split(char[] separator, StringSplitOptions options);
        public String[] Split(char separator, StringSplitOptions options = StringSplitOptions.None);
        public String[] Split(String separator, int count, StringSplitOptions options = StringSplitOptions.None);
        public String[] Split(String separator, StringSplitOptions options = StringSplitOptions.None);
        public String[] Split(char separator, int count, StringSplitOptions options = StringSplitOptions.None);
        public String[] Split(params char[] separator);
        public String[] Split(char[] separator, int count);
        [ComVisible(false)]
        public String[] Split(char[] separator, int count, StringSplitOptions options);
        [ComVisible(false)]
        public String[] Split(String[] separator, int count, StringSplitOptions options);
        [ComVisible(false)]
        public String[] Split(String[] separator, StringSplitOptions options);



        // 判断 字符串是否以 value 为前缀
        public bool StartsWith(char value);
        [ComVisible(false)]
        [SecuritySafeCritical]
        public bool StartsWith(String value, StringComparison comparisonType);
        public bool StartsWith(String value, bool ignoreCase, CultureInfo culture);
        public bool StartsWith(String value);


        [SecuritySafeCritical]
        public String Substring(int startIndex, int length);
        public String Substring(int startIndex);


        [SecuritySafeCritical]
        public char[] ToCharArray(int startIndex, int length);
        [SecuritySafeCritical]
        public char[] ToCharArray();


        public String ToLower(CultureInfo culture);
        public String ToLower();


        public String ToLowerInvariant();


        public override String ToString();
        public String ToString(IFormatProvider provider);


        public String ToUpper();
        public String ToUpper(CultureInfo culture);
        public String ToUpperInvariant();


        public String Trim(char trimChar);
        public String Trim();
        public String Trim(params char[] trimChars);
        public String TrimEnd(params char[] trimChars);
        public String TrimEnd();
        public String TrimEnd(char trimChar);
        public String TrimStart(params char[] trimChars);
        public String TrimStart();
        public String TrimStart(char trimChar);

        

        public static bool operator ==(String a, String b);
        public static bool operator !=(String a, String b);

        public static implicit operator ReadOnlySpan<char>(String value);
    }
}
