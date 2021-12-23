#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Runtime.InteropServices;

namespace System.Reflection
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(_MethodInfo))]
    [ComVisible(true)]
    public abstract class MethodInfo//MethodInfo__RR
        : MethodBase, _MethodInfo
    {
        protected MethodInfo();

        public override MemberTypes MemberType { get; }
        public virtual ParameterInfo ReturnParameter { get; }
        public virtual Type ReturnType { get; }
        public abstract ICustomAttributeProvider ReturnTypeCustomAttributes { get; }

        public virtual Delegate CreateDelegate(Type delegateType);
        public virtual Delegate CreateDelegate(Type delegateType, object target);
        public override bool Equals(object obj);
        public abstract MethodInfo GetBaseDefinition();
        [ComVisible(true)]
        public override Type[] GetGenericArguments();
        [ComVisible(true)]
        public virtual MethodInfo GetGenericMethodDefinition();
        public override int GetHashCode();
        public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments);

        public static bool operator ==(MethodInfo left, MethodInfo right);
        public static bool operator !=(MethodInfo left, MethodInfo right);
    }
}

