#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace System.Text
{
    /*
        https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-6.0


        This class represents a string-like object whose value is a mutable sequence of characters.(可变字符序列)
        ---
        与之对应的, String 类型是 不可变字符序列, 每次对一个 string 做 += 操作, 其实都是在创建一个新的 string 对象;
        而 StringBuilder 在概念上更接近 List<>

        ---
        未见到任何 Dispose() 之类的释放资源的函数; 故不需要做任何 释放资源的操作;        
        
        常见用法:
        sb.Length       -- 获得当前 sb 内包含的 字符串的字节数;
        sb.ToString()   -- 获得当前 sb 内包含的 字符串 本串;
    */
    [DefaultMember("Chars")]
    public sealed class StringBuilder : ISerializable
    {
        /*
            参数:
                value:
                    初始字符串;
                capacity:
                    初始字节数, 就是一开始开辟的空间;
        */
        public StringBuilder();
        public StringBuilder(int capacity);
        public StringBuilder(string value);
        public StringBuilder(int capacity, int maxCapacity);
        public StringBuilder(string value, int capacity);
        public StringBuilder(string value, int startIndex, int length, int capacity);

        public char this[int index] { get; set; }

        // 当前分配的内存大小; 每次扩容都翻倍
        public int Capacity { get; set; }

        // 获得当前 sb 内包含的 字符串的字节数;
        // 若想删除 尾段字符串, 可以简单地将 Length 设置得小一些即可;
        public int Length { get; set; }

        // 最大空间, 只读;
        // 此值默认为  Int32.MaxValue; 也可通过 本class 的构造函数来 显式设置, 查看 maxCapacity 参数;
        // 当打到 max值之后, 还要 Append() 新值, 会引发 ArgumentOutOfRangeException or OutOfMemoryException 异常
        public int MaxCapacity { get; }

        public StringBuilder Append(char value, int repeatCount);
        [CLSCompliant(false)]
        public StringBuilder Append(char* value, int valueCount);
        public StringBuilder Append(byte value);
        public StringBuilder Append(bool value);
        [CLSCompliant(false)]
        public StringBuilder Append(ulong value);
        [CLSCompliant(false)]
        public StringBuilder Append(uint value);
        [CLSCompliant(false)]
        public StringBuilder Append(ushort value);
        public StringBuilder Append(char value);
        public StringBuilder Append(StringBuilder value);
        public StringBuilder Append(string value, int startIndex, int count);

        // 在 sb 实例尾后添加字符串 value;
        public StringBuilder Append(string value);

        public StringBuilder Append(StringBuilder value, int startIndex, int count);

        [CLSCompliant(false)]
        public StringBuilder Append(sbyte value);
        public StringBuilder Append(ReadOnlySpan<char> value);
        public StringBuilder Append(object value);
        public StringBuilder Append(long value);
        public StringBuilder Append(int value);
        public StringBuilder Append(short value);
        public StringBuilder Append(double value);
        public StringBuilder Append(char[] value);
        public StringBuilder Append(char[] value, int startIndex, int charCount);
        public StringBuilder Append(float value);
        public StringBuilder Append(decimal value);

        // 可以添加格式化的字符串, 比如: 
        //    sb.AppendFormat("GHI{0}{1}", 'J', 'k');
        public StringBuilder AppendFormat(string format, params object[] args);
        public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2);
        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2);
        public StringBuilder AppendFormat(string format, object arg0);
        public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args);
        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1);
        public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0);
        public StringBuilder AppendFormat(string format, object arg0, object arg1);


        public StringBuilder AppendJoin<T>(string separator, IEnumerable<T> values);
        public StringBuilder AppendJoin(string separator, params string[] values);
        public StringBuilder AppendJoin(string separator, params object[] values);
        public StringBuilder AppendJoin(char separator, params object[] values);
        public StringBuilder AppendJoin(char separator, params string[] values);
        public StringBuilder AppendJoin<T>(char separator, IEnumerable<T> values);

        public StringBuilder AppendLine();
        public StringBuilder AppendLine(string value);

        // 清空 sb 内所有字符串
        public StringBuilder Clear();

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
        public void CopyTo(int sourceIndex, Span<char> destination, int count);

        public int EnsureCapacity(int capacity);

        public bool Equals(StringBuilder sb);
        public bool Equals(ReadOnlySpan<char> span);


        // 在指定位置 插入字符串;
        [CLSCompliant(false)]
        public StringBuilder Insert(int index, ulong value);
        [CLSCompliant(false)]
        public StringBuilder Insert(int index, uint value);
        [CLSCompliant(false)]
        public StringBuilder Insert(int index, ushort value);
        public StringBuilder Insert(int index, string value, int count);
        public StringBuilder Insert(int index, float value);
        [CLSCompliant(false)]
        public StringBuilder Insert(int index, sbyte value);
        public StringBuilder Insert(int index, ReadOnlySpan<char> value);
        public StringBuilder Insert(int index, string value);
        public StringBuilder Insert(int index, int value);
        public StringBuilder Insert(int index, bool value);
        public StringBuilder Insert(int index, byte value);
        public StringBuilder Insert(int index, long value);
        public StringBuilder Insert(int index, char value);
        public StringBuilder Insert(int index, object value);
        public StringBuilder Insert(int index, char[] value, int startIndex, int charCount);
        public StringBuilder Insert(int index, decimal value);
        public StringBuilder Insert(int index, double value);
        public StringBuilder Insert(int index, short value);
        public StringBuilder Insert(int index, char[] value);

        // 删除指定区间的 字符串
        // 若想删除 尾段字符串, 可以简单地将 Length 设置得小一些即可;
        public StringBuilder Remove(int startIndex, int length);


        // 将目录区域内,所有 旧的字符/字符串, 替换为新的 字符/字符串;
        public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count);
        public StringBuilder Replace(string oldValue, string newValue);
        public StringBuilder Replace(string oldValue, string newValue, int startIndex, int count);
        public StringBuilder Replace(char oldChar, char newChar);


        // 获得当前 sb 内包含的 字符串 本串;
        public override string ToString();
        public string ToString(int startIndex, int length);
    }
}
