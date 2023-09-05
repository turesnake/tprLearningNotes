#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Globalization;
using System.Runtime.Serialization;

namespace System
{
    public readonly struct DateTime : IComparable, IComparable<DateTime>, IConvertible, IEquatable<DateTime>, IFormattable, ISerializable
    {
        public static readonly DateTime MaxValue;
        public static readonly DateTime MinValue;
        public static readonly DateTime UnixEpoch;

        public DateTime(long ticks);
        public DateTime(long ticks, DateTimeKind kind);
        public DateTime(int year, int month, int day);
        public DateTime(int year, int month, int day, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second);
        public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind);
        public DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar);
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind);

        public static DateTime Now { get; }
        public static DateTime Today { get; }
        public static DateTime UtcNow { get; }
        public long Ticks { get; }
        public int Second { get; }
        public DateTime Date { get; }
        public int Month { get; }
        public int Minute { get; }
        public int Millisecond { get; }
        public DateTimeKind Kind { get; }
        public int Hour { get; }
        public int DayOfYear { get; }
        public DayOfWeek DayOfWeek { get; }
        public int Day { get; }
        public TimeSpan TimeOfDay { get; }
        public int Year { get; }

        public static int Compare(DateTime t1, DateTime t2);
        public static int DaysInMonth(int year, int month);
        public static bool Equals(DateTime t1, DateTime t2);
        public static DateTime FromBinary(long dateData);
        public static DateTime FromFileTime(long fileTime);
        public static DateTime FromFileTimeUtc(long fileTime);
        public static DateTime FromOADate(double d);
        public static bool IsLeapYear(int year);
        public static DateTime Parse(string s, IFormatProvider provider);
        public static DateTime Parse(string s);
        public static DateTime Parse(ReadOnlySpan<char> s, IFormatProvider provider = null, DateTimeStyles styles = DateTimeStyles.None);
        public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles);
        public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style);
        public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style);
        public static DateTime ParseExact(string s, string format, IFormatProvider provider);
        public static DateTime ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider provider, DateTimeStyles style = DateTimeStyles.None);
        public static DateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider provider, DateTimeStyles style = DateTimeStyles.None);
        public static DateTime SpecifyKind(DateTime value, DateTimeKind kind);
        public static bool TryParse(string s, out DateTime result);
        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result);
        public static bool TryParse(ReadOnlySpan<char> s, out DateTime result);
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, DateTimeStyles styles, out DateTime result);
        public static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        public static bool TryParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        public DateTime Add(TimeSpan value);
        public DateTime AddDays(double value);
        public DateTime AddHours(double value);
        public DateTime AddMilliseconds(double value);
        public DateTime AddMinutes(double value);
        public DateTime AddMonths(int months);
        public DateTime AddSeconds(double value);
        public DateTime AddTicks(long value);
        public DateTime AddYears(int value);
        public int CompareTo(object value);
        public int CompareTo(DateTime value);
        public bool Equals(DateTime value);
        public override bool Equals(object value);
        public string[] GetDateTimeFormats();
        public string[] GetDateTimeFormats(char format, IFormatProvider provider);
        public string[] GetDateTimeFormats(char format);
        public string[] GetDateTimeFormats(IFormatProvider provider);
        public override int GetHashCode();
        public TypeCode GetTypeCode();
        public bool IsDaylightSavingTime();
        public DateTime Subtract(TimeSpan value);
        public TimeSpan Subtract(DateTime value);
        public long ToBinary();
        public long ToFileTime();
        public long ToFileTimeUtc();
        public DateTime ToLocalTime();
        public string ToLongDateString();
        public string ToLongTimeString();
        public double ToOADate();
        public string ToShortDateString();
        public string ToShortTimeString();
        public string ToString(string format, IFormatProvider provider);
        public string ToString(string format);
        public string ToString(IFormatProvider provider);
        public override string ToString();
        public DateTime ToUniversalTime();
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null);

        public static DateTime operator +(DateTime d, TimeSpan t);
        public static TimeSpan operator -(DateTime d1, DateTime d2);
        public static DateTime operator -(DateTime d, TimeSpan t);
        public static bool operator ==(DateTime d1, DateTime d2);
        public static bool operator !=(DateTime d1, DateTime d2);
        public static bool operator <(DateTime t1, DateTime t2);
        public static bool operator >(DateTime t1, DateTime t2);
        public static bool operator <=(DateTime t1, DateTime t2);
        public static bool operator >=(DateTime t1, DateTime t2);
    }
}