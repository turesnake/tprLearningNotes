#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion

using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
    [__DynamicallyInvokableAttribute]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterfaceAttribute(typeof(_FieldInfo))]
    [ComVisible(true)]
    public abstract class FieldInfo//FieldInfo__RR
        : MemberInfo, _FieldInfo
    {

        protected FieldInfo();

        [__DynamicallyInvokableAttribute]public abstract RuntimeFieldHandle FieldHandle { get; }

        [__DynamicallyInvokableAttribute]public bool IsPublic { get; }
        [__DynamicallyInvokableAttribute]public bool IsPrivate { get; }
        [__DynamicallyInvokableAttribute]public bool IsFamily { get; }
        [__DynamicallyInvokableAttribute]public bool IsAssembly { get; }
        [__DynamicallyInvokableAttribute]public bool IsFamilyAndAssembly { get; }
        [__DynamicallyInvokableAttribute]public bool IsFamilyOrAssembly { get; }
        [__DynamicallyInvokableAttribute]public bool IsStatic { get; }
        [__DynamicallyInvokableAttribute]public bool IsInitOnly { get; }
        [__DynamicallyInvokableAttribute]public bool IsLiteral { get; }

        public bool IsNotSerialized { get; }

        [__DynamicallyInvokableAttribute]public bool IsSpecialName { get; }

        public bool IsPinvokeImpl { get; }
        public virtual bool IsSecurityCritical { get; }

        [__DynamicallyInvokableAttribute]public abstract FieldAttributes Attributes { get; }

        [__DynamicallyInvokableAttribute]public abstract Type FieldType { get; }

        public virtual bool IsSecurityTransparent { get; }
        public override MemberTypes MemberType { get; }
        public virtual bool IsSecuritySafeCritical { get; }

        [__DynamicallyInvokableAttribute]
        [ComVisible(false)]
        public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType);

        [__DynamicallyInvokableAttribute]public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle);

        [__DynamicallyInvokableAttribute]public override bool Equals(object obj);

        [__DynamicallyInvokableAttribute]public override int GetHashCode();

        public virtual Type[] GetOptionalCustomModifiers();
        public virtual object GetRawConstantValue();
        public virtual Type[] GetRequiredCustomModifiers();

        /*
            When overridden in a derived class, returns the value of a field supported by a given object.
            ---
            本类的派生类要重写此函数, 返回参数 obj 这个对象的 本 field 的值;
            比如:
                FieldInfo fld = typeof(AAA).GetField("fval");
                AAAe e1 = new AAA(){ fval = 0.133f };
                float outt = fld.GetValue( e1 ); // 得到 0.133;

            注意在此例中, FieldInfo fld 描述了 class "AAA" 拥有一个名为 "fval" 的成员变量; (严格的说, 是个 field)
            但是这只是个描述, 目前尚未绑定某个具体的 AAA 的实例;

            但是 fld.GetValue( e1 ) 就实现了这个绑定, AAA 实例 e1 是通过本函数的 参数传入的;
            ------

            如果要查询的 field 是 static 的, 那么 参数 obj 将被忽略;
            如果目标 field 不是 static, 则参数 obj 必须为目标 Type 或其派生类的 实例;

            注意, 本函数的返回值类型为 object;
        */
        [__DynamicallyInvokableAttribute]public abstract object GetValue(object obj);

        [CLSCompliant(false)]public virtual object GetValueDirect(TypedReference obj);

        [__DynamicallyInvokableAttribute]
        [DebuggerHidden]
        [DebuggerStepThrough]
        public void SetValue(object obj, object value);

        public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);

        [CLSCompliant(false)]public virtual void SetValueDirect(TypedReference obj, object value);

        [__DynamicallyInvokableAttribute]public static bool operator ==(FieldInfo left, FieldInfo right);
        [__DynamicallyInvokableAttribute]public static bool operator !=(FieldInfo left, FieldInfo right);
    }
}

