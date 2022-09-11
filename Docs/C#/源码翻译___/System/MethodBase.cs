#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection
{


    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(_MethodBase))]
    [ComVisible(true)]
    public abstract class MethodBase//MethodBase__RR
        : MemberInfo, _MethodBase
    {
        protected MethodBase();

        public bool IsFamily { get; }
        public bool IsFamilyAndAssembly { get; }
        public bool IsFamilyOrAssembly { get; }
        public bool IsFinal { get; }
        public virtual bool IsGenericMethod { get; }
        public virtual bool IsGenericMethodDefinition { get; }
        public bool IsHideBySig { get; }
        public bool IsPrivate { get; }
        public bool IsPublic { get; }
        public virtual bool IsSecurityCritical { get; }
        public virtual bool IsSecuritySafeCritical { get; }
        public virtual bool IsSecurityTransparent { get; }
        public bool IsSpecialName { get; }
        public bool IsStatic { get; }
        public bool IsVirtual { get; }
        [ComVisible(true)]
        public bool IsConstructor { get; }
        public abstract RuntimeMethodHandle MethodHandle { get; }
        public bool IsAssembly { get; }
        public virtual bool ContainsGenericParameters { get; }
        public bool IsAbstract { get; }
        public virtual MethodImplAttributes MethodImplementationFlags { get; }
        public virtual CallingConventions CallingConvention { get; }
        public abstract MethodAttributes Attributes { get; }

        public static MethodBase GetCurrentMethod();
        [ComVisible(false)]
        public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle, RuntimeTypeHandle declaringType);
        public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle);
        public override bool Equals(object obj);
        [ComVisible(true)]
        public virtual Type[] GetGenericArguments();
        public override int GetHashCode();
        [SecuritySafeCritical]
        public virtual MethodBody GetMethodBody();
        public abstract MethodImplAttributes GetMethodImplementationFlags();
        public abstract ParameterInfo[] GetParameters();



        public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
        
        [DebuggerHidden]
        [DebuggerStepThrough]
        public object Invoke(object obj, object[] parameters);

        public static bool operator ==(MethodBase left, MethodBase right);
        public static bool operator !=(MethodBase left, MethodBase right);
    }
}

