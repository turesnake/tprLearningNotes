#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Globalization;

/*
    描述一个 时间跨度, 一个时间间隔


*/
namespace System
{
    public readonly struct TimeSpan : IComparable, IComparable<TimeSpan>, IEquatable<TimeSpan>, IFormattable
    {
        public const long TicksPerDay = 864000000000;
        public const long TicksPerHour = 36000000000;
        public const long TicksPerMillisecond = 10000;
        public const long TicksPerMinute = 600000000;
        public const long TicksPerSecond = 10000000;
        public static readonly TimeSpan MaxValue;
        public static readonly TimeSpan MinValue;
        public static readonly TimeSpan Zero;

        public TimeSpan(long ticks);
        public TimeSpan(int hours, int minutes, int seconds);
        public TimeSpan(int days, int hours, int minutes, int seconds);
        public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);

        public double TotalMilliseconds { get; }
        public double TotalHours { get; }
        public double TotalDays { get; }
        public long Ticks { get; }
        public int Seconds { get; }
        public int Minutes { get; }
        public int Milliseconds { get; }
        public int Hours { get; }
        public int Days { get; }
        public double TotalMinutes { get; }
        public double TotalSeconds { get; }

        public static int Compare(TimeSpan t1, TimeSpan t2);
        public static bool Equals(TimeSpan t1, TimeSpan t2);
        public static TimeSpan FromDays(double value);
        public static TimeSpan FromHours(double value);
        public static TimeSpan FromMilliseconds(double value);
        public static TimeSpan FromMinutes(double value);
        public static TimeSpan FromSeconds(double value);
        public static TimeSpan FromTicks(long value);
        public static TimeSpan Parse(string input, IFormatProvider formatProvider);
        public static TimeSpan Parse(string s);
        public static TimeSpan Parse(ReadOnlySpan<char> input, IFormatProvider formatProvider = null);
        public static TimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles);
        public static TimeSpan ParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles);
        public static TimeSpan ParseExact(string input, string format, IFormatProvider formatProvider);
        public static TimeSpan ParseExact(ReadOnlySpan<char> input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles = TimeSpanStyles.None);
        public static TimeSpan ParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider formatProvider, TimeSpanStyles styles = TimeSpanStyles.None);
        public static TimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider);
        public static bool TryParse(ReadOnlySpan<char> s, out TimeSpan result);
        public static bool TryParse(string input, IFormatProvider formatProvider, out TimeSpan result);
        public static bool TryParse(string s, out TimeSpan result);
        public static bool TryParse(ReadOnlySpan<char> input, IFormatProvider formatProvider, out TimeSpan result);
        public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
        public static bool TryParseExact(ReadOnlySpan<char> input, string[] formats, IFormatProvider formatProvider, out TimeSpan result);
        public static bool TryParseExact(ReadOnlySpan<char> input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
        public static bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider formatProvider, out TimeSpan result);
        public static bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
        public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles, out TimeSpan result);
        public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, out TimeSpan result);
        public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, out TimeSpan result);
        public TimeSpan Add(TimeSpan ts);
        public int CompareTo(object value);
        public int CompareTo(TimeSpan value);
        public TimeSpan Divide(double divisor);
        public double Divide(TimeSpan ts);
        public TimeSpan Duration();
        public override bool Equals(object value);
        public bool Equals(TimeSpan obj);
        public override int GetHashCode();
        public TimeSpan Multiply(double factor);
        public TimeSpan Negate();
        public TimeSpan Subtract(TimeSpan ts);
        public string ToString(string format, IFormatProvider formatProvider);
        public string ToString(string format);
        public override string ToString();
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider formatProvider = null);

        public static TimeSpan operator +(TimeSpan t);
        public static TimeSpan operator +(TimeSpan t1, TimeSpan t2);
        public static TimeSpan operator -(TimeSpan t);
        public static TimeSpan operator -(TimeSpan t1, TimeSpan t2);
        public static TimeSpan operator *(double factor, TimeSpan timeSpan);
        public static TimeSpan operator *(TimeSpan timeSpan, double factor);
        public static TimeSpan operator /(TimeSpan timeSpan, double divisor);
        public static double operator /(TimeSpan t1, TimeSpan t2);
        public static bool operator ==(TimeSpan t1, TimeSpan t2);
        public static bool operator !=(TimeSpan t1, TimeSpan t2);
        public static bool operator <(TimeSpan t1, TimeSpan t2);
        public static bool operator >(TimeSpan t1, TimeSpan t2);
        public static bool operator <=(TimeSpan t1, TimeSpan t2);
        public static bool operator >=(TimeSpan t1, TimeSpan t2);
    }
}