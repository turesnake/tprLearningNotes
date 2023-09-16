#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion


namespace System
{
    public abstract class Enum : ValueType, IComparable, IConvertible, IFormattable
    {
        protected Enum();

        public static string Format(Type enumType, object value, string format);
        public static string GetName(Type enumType, object value);
        public static string[] GetNames(Type enumType);
        public static Type GetUnderlyingType(Type enumType);



        /*
            遍历 enum 里的每个元素:
            
            var ss = Enum.GetValues(typeof(DirtyType));
            foreach( DirtyType k in ss ) 
            {
                ...
            }

        */
        public static Array GetValues(Type enumType);
        public static bool IsDefined(Type enumType, object value);
        public static object Parse(Type enumType, string value);
        public static object Parse(Type enumType, string value, bool ignoreCase);
        public static TEnum Parse<TEnum>(string value) where TEnum : struct;
        public static TEnum Parse<TEnum>(string value, bool ignoreCase) where TEnum : struct;
        [CLSCompliant(false)]
        public static object ToObject(Type enumType, uint value);
        [CLSCompliant(false)]
        public static object ToObject(Type enumType, ulong value);
        [CLSCompliant(false)]
        public static object ToObject(Type enumType, sbyte value);
        public static object ToObject(Type enumType, long value);
        public static object ToObject(Type enumType, object value);
        [CLSCompliant(false)]
        public static object ToObject(Type enumType, ushort value);
        public static object ToObject(Type enumType, int value);
        public static object ToObject(Type enumType, byte value);
        public static object ToObject(Type enumType, short value);
        public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct;
        public static bool TryParse(Type enumType, string value, bool ignoreCase, out object result);
        public static bool TryParse(Type enumType, string value, out object result);
        public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct;
        public int CompareTo(object target);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public TypeCode GetTypeCode();
        public bool HasFlag(Enum flag);
        public override string ToString();

        // [Obsolete("The provider argument is not used. Please use ToString().")]
        // public string ToString(IFormatProvider provider);

        public string ToString(string format);

        // [Obsolete("The provider argument is not used. Please use ToString(String).")]
        // public string ToString(string format, IFormatProvider provider);
    }
}