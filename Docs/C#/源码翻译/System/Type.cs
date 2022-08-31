#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
    /*


    
     
    */
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterfaceAttribute(typeof(_Type))]
    [ComVisible(true)]
    public abstract class Type//Type__RR
        : MemberInfo, IReflect, _Type
    {
        public static readonly char Delimiter;
        public static readonly Type[] EmptyTypes;
        public static readonly MemberFilter FilterAttribute;
        public static readonly MemberFilter FilterName;
        public static readonly MemberFilter FilterNameIgnoreCase;
        public static readonly object Missing;

        protected Type();

        public static Binder DefaultBinder { get; }
        public bool IsAutoClass { get; }
        public bool IsAutoLayout { get; }
        public bool IsByRef { get; }
        public bool IsClass { get; }
        public bool IsCOMObject { get; }
        public virtual bool IsEnum { get; }
        public bool IsContextful { get; }
        public bool IsArray { get; }
        public bool IsExplicitLayout { get; }
        public virtual bool IsGenericParameter { get; }


        /*
            whether the current type is a generic type.
            示例:
            -- typeof(Derived<>)                            -- true
            -- typeof(Derived<>).BaseType                   -- true
            -- Derived<int>[]                               -- false
            -- typeof(Base<,>).GetGenericArguments()[0]     -- false
            -- typeof(Derived<>).GetField("F").FieldType    -- true
            -- typeof(Derived<>.Nested)                     -- true
        */
        public virtual bool IsGenericType { get; }


        public virtual bool IsConstructedGenericType { get; }
        public bool IsAnsiClass { get; }
        public virtual Type[] GenericTypeArguments { get; }
        public bool HasElementType { get; }
        public abstract Guid GUID { get; }


        /*
            whether the current Type represents a "generic type definition", from which other generic types can be constructed.
            ---
            判断 调用者 是否为 "generic type definition" 类型;
            可参考下方 GetGenericTypeDefinition() 中的描述;
        */
        public virtual bool IsGenericTypeDefinition { get; }



        public virtual int GenericParameterPosition { get; }
        public virtual GenericParameterAttributes GenericParameterAttributes { get; }
        public abstract string FullName { get; }
        public override Type DeclaringType { get; }
        public virtual MethodBase DeclaringMethod { get; }
        public virtual bool ContainsGenericParameters { get; }

        /*
            return The Type from which the "current Type" directly inherits,
            or null if the "current Type" represents the Object class or an interface.
            ---
            返回调用者的 基类, 
            如果 调用者 类型为 Object 或 interface, 本值则返回 null; 
            如果 调用者 没有显式继承任何类, 将返回 System.Object 类型;
            ---
            关于泛型, 文档还有更多描述...
        */
        public abstract Type BaseType { get; }


        public TypeAttributes Attributes { get; }
        public abstract string AssemblyQualifiedName { get; }

        
        // whether the Type is abstract and must be overridden.
        // 是否为 抽象类
        public bool IsAbstract { get; }


        public bool IsImport { get; }
        public bool IsMarshalByRef { get; }
        public bool IsLayoutSequential { get; }
        public virtual RuntimeTypeHandle TypeHandle { get; }
        public virtual StructLayoutAttribute StructLayoutAttribute { get; }
        public override Type ReflectedType { get; }
        public abstract string Namespace { get; }
        public abstract Module Module { get; }
        public override MemberTypes MemberType { get; }
        public bool IsVisible { get; }
        public bool IsValueType { get; }
        public bool IsUnicodeClass { get; }
        public bool IsSpecialName { get; }
        public virtual bool IsSerializable { get; }
        public virtual bool IsSecurityTransparent { get; }
        public virtual bool IsSecuritySafeCritical { get; }
        public virtual bool IsSecurityCritical { get; }
        public bool IsSealed { get; }
        public bool IsPublic { get; }
        public bool IsPrimitive { get; }
        public bool IsPointer { get; }
        public bool IsNotPublic { get; }
        public bool IsNestedPublic { get; }
        public bool IsNestedPrivate { get; }
        public bool IsNestedFamORAssem { get; }
        public bool IsNestedFamily { get; }
        public bool IsNestedFamANDAssem { get; }
        public bool IsNestedAssembly { get; }
        public bool IsNested { get; }
        public abstract Assembly Assembly { get; }
        public bool IsInterface { get; }
        [ComVisible(true)]
        public ConstructorInfo TypeInitializer { get; }
        public abstract Type UnderlyingSystemType { get; }

        public static Type GetType(string typeName);
        public static Type GetType(string typeName, bool throwOnError);
        public static Type GetType(string typeName, bool throwOnError, bool ignoreCase);
        public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver);
        public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError);
        public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError, bool ignoreCase);
        public static Type[] GetTypeArray(object[] args);
        public static TypeCode GetTypeCode(Type type);
        [SecuritySafeCritical]
        public static Type GetTypeFromCLSID(Guid clsid);
        [SecuritySafeCritical]
        public static Type GetTypeFromCLSID(Guid clsid, bool throwOnError);
        [SecuritySafeCritical]
        public static Type GetTypeFromCLSID(Guid clsid, string server);
        [SecuritySafeCritical]
        public static Type GetTypeFromCLSID(Guid clsid, string server, bool throwOnError);
        [SecuritySafeCritical]
        public static Type GetTypeFromHandle(RuntimeTypeHandle handle);
        [SecurityCritical]
        public static Type GetTypeFromProgID(string progID, string server, bool throwOnError);
        [SecurityCritical]
        public static Type GetTypeFromProgID(string progID, string server);
        [SecurityCritical]
        public static Type GetTypeFromProgID(string progID, bool throwOnError);
        [SecurityCritical]
        public static Type GetTypeFromProgID(string progID);
        public static RuntimeTypeHandle GetTypeHandle(object o);
        public static Type ReflectionOnlyGetType(string typeName, bool throwIfNotFound, bool ignoreCase);
        public virtual bool Equals(Type o);
        public override bool Equals(object o);
        public virtual Type[] FindInterfaces(TypeFilter filter, object filterCriteria);
        public virtual MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria);
        public virtual int GetArrayRank();
        [ComVisible(true)]
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
        [ComVisible(true)]
        public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);
        [ComVisible(true)]
        public ConstructorInfo GetConstructor(Type[] types);
        [ComVisible(true)]
        public ConstructorInfo[] GetConstructors();
        [ComVisible(true)]
        public abstract ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);
        public virtual MemberInfo[] GetDefaultMembers();
        public abstract Type GetElementType();
        public virtual string GetEnumName(object value);
        public virtual string[] GetEnumNames();
        public virtual Type GetEnumUnderlyingType();
        public virtual Array GetEnumValues();
        public abstract EventInfo GetEvent(string name, BindingFlags bindingAttr);
        public EventInfo GetEvent(string name);
        public abstract EventInfo[] GetEvents(BindingFlags bindingAttr);
        public virtual EventInfo[] GetEvents();

        // 得到本类型的 目标 field 的信息;
        // 参数 name 为 目标field 的名字
        public FieldInfo GetField(string name);

        public abstract FieldInfo GetField(string name, BindingFlags bindingAttr);

        /*
            Gets the fields of the current Type.
            Returns all the public fields of the current Type.
            ---

            如果 type 没有 public fields, 就返回 An empty array;
            返回元素的顺序 没有规则;

        */
        public FieldInfo[] GetFields();

        /*
            When overridden in a derived class, searches for the fields defined for the current Type, 
            using the specified binding constraints.
        */
        public abstract FieldInfo[] GetFields(BindingFlags bindingAttr);


        public virtual Type[] GetGenericArguments();
        public virtual Type[] GetGenericParameterConstraints();


        /*
            Returns a Type object that represents a "generic type definition"
            from which the current generic type can be constructed.
            ---
            得到 调用者 的 "泛型类型的描述类"; ("generic type definition")
            如果 调用者 自己不是 泛型类型, 调用本函数将抛出异常;
            原文不好理解, 直白描述即: 一个 "List<int>" 对象调用本函数, 将返回一个 "List<T>" 类型的对象;

            通常, 使用:
                -- typeof(a)
                -- a.GetType()
            得到的 对象, 都能用来调用本函数;
            ---
            比如: 
                Dictionary<string, Test> dic = new Dictionary<string, Test>();
                Type a1 = dic.GetType();
                Type a2 = a1.GetGenericTypeDefinition();

            a1 类型为 -- Dictionary< string, Test >
            a2 类型为 -- Dictionary< TKey,   TValue >

            a1.IsGenericTypeDefinition -- false;
            a2.IsGenericTypeDefinition -- true;

            a1.IsGenericType    -- true
            a2.IsGenericType    -- true
        */
        public virtual Type GetGenericTypeDefinition();



        public override int GetHashCode();
        public Type GetInterface(string name);
        public abstract Type GetInterface(string name, bool ignoreCase);
        [ComVisible(true)]
        public virtual InterfaceMapping GetInterfaceMap(Type interfaceType);
        public abstract Type[] GetInterfaces();
        public virtual MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr);
        public MemberInfo[] GetMember(string name);
        public virtual MemberInfo[] GetMember(string name, BindingFlags bindingAttr);
        public MemberInfo[] GetMembers();
        public abstract MemberInfo[] GetMembers(BindingFlags bindingAttr);


        public MethodInfo GetMethod(string name);
        public MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers);
        public MethodInfo GetMethod(string name, Type[] types);
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr);
        public abstract MethodInfo[] GetMethods(BindingFlags bindingAttr);
        public MethodInfo[] GetMethods();

        
        public abstract Type GetNestedType(string name, BindingFlags bindingAttr);
        public Type GetNestedType(string name);
        public abstract Type[] GetNestedTypes(BindingFlags bindingAttr);
        public Type[] GetNestedTypes();
        public PropertyInfo[] GetProperties();
        public abstract PropertyInfo[] GetProperties(BindingFlags bindingAttr);
        public PropertyInfo GetProperty(string name, Type[] types);
        public PropertyInfo GetProperty(string name);
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr);
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);
        public PropertyInfo GetProperty(string name, Type returnType);
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types);
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers);
        public Type GetType();
        public abstract object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);
        [DebuggerHidden]
        [DebuggerStepThrough]
        public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture);
        [DebuggerHidden]
        [DebuggerStepThrough]
        public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args);
        public virtual bool IsAssignableFrom(Type c);
        public virtual bool IsEnumDefined(object value);
        public virtual bool IsEquivalentTo(Type other);
        public virtual bool IsInstanceOfType(object o);

        /*
            Determines whether the "current Type" derives from the 参数Type c.
            ---
            必须是派生类才返回 true, 如果 "current Type" 和 Type c 是同类型, 也返回 false;

            参数c为 null 将抛出异常;
        */
        [ComVisible(true)]public virtual bool IsSubclassOf(Type c);


        public virtual Type MakeArrayType(int rank);
        public virtual Type MakeArrayType();
        public virtual Type MakeByRefType();
        public virtual Type MakeGenericType(params Type[] typeArguments);
        public virtual Type MakePointerType();
        public override string ToString();
        protected abstract TypeAttributes GetAttributeFlagsImpl();
        protected abstract ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
        protected abstract MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
        protected abstract PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);
        protected virtual TypeCode GetTypeCodeImpl();
        protected abstract bool HasElementTypeImpl();
        protected abstract bool IsArrayImpl();
        protected abstract bool IsByRefImpl();
        protected abstract bool IsCOMObjectImpl();
        protected virtual bool IsContextfulImpl();
        protected virtual bool IsMarshalByRefImpl();
        protected abstract bool IsPointerImpl();
        protected abstract bool IsPrimitiveImpl();
        protected virtual bool IsValueTypeImpl();

        [SecuritySafeCritical]
        public static bool operator ==(Type left, Type right);
        [SecuritySafeCritical]
        public static bool operator !=(Type left, Type right);
    }
}

