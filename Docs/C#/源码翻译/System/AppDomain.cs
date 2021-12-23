#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Policy;
using System.Security.Principal;

namespace System
{
    /*
        Represents an application domain, which is an isolated environment where applications execute. This class cannot be inherited.
        这是应用程序执行的隔离环境。

        Application domains, which are represented by AppDomain objects, 
        help provide isolation, unloading, and security boundaries for executing managed code.


    */
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(_AppDomain))]
    [ComVisible(true)]
    public sealed class AppDomain//AppDomain__RR
    : MarshalByRefObject, IEvidenceFactory, _AppDomain
    {
        public static long MonitoringSurvivedProcessMemorySize { get; }

        // Gets the current application domain for the current Thread.
        public static AppDomain CurrentDomain { get; }


        public static bool MonitoringIsEnabled { get; set; }
        public TimeSpan MonitoringTotalProcessorTime { get; }
        public ActivationContext ActivationContext { get; }
        public string RelativeSearchPath { get; }
        public AppDomainSetup SetupInformation { get; }
        public bool ShadowCopyFiles { get; }
        public long MonitoringSurvivedMemorySize { get; }
        public bool IsHomogenous { get; }
        public bool IsFullyTrusted { get; }
        public int Id { get; }
        public string FriendlyName { get; }
        public Evidence Evidence { get; }
        public string DynamicDirectory { get; }
        public AppDomainManager DomainManager { get; }
        public string BaseDirectory { get; }
        public ApplicationTrust ApplicationTrust { get; }
        public ApplicationIdentity ApplicationIdentity { get; }
        public long MonitoringTotalAllocatedMemorySize { get; }
        public PermissionSet PermissionSet { get; }

        public event UnhandledExceptionEventHandler UnhandledException;
        public event ResolveEventHandler AssemblyResolve;
        public event EventHandler DomainUnload;
        public event EventHandler<FirstChanceExceptionEventArgs> FirstChanceException;
        public event EventHandler ProcessExit;
        public event ResolveEventHandler ReflectionOnlyAssemblyResolve;
        public event ResolveEventHandler ResourceResolve;
        public event AssemblyLoadEventHandler AssemblyLoad;
        public event ResolveEventHandler TypeResolve;

        public static AppDomain CreateDomain(string friendlyName, Evidence securityInfo, string appBasePath, string appRelativeSearchPath, bool shadowCopyFiles, AppDomainInitializer adInit, string[] adInitArgs);
        public static AppDomain CreateDomain(string friendlyName, Evidence securityInfo, string appBasePath, string appRelativeSearchPath, bool shadowCopyFiles);
        public static AppDomain CreateDomain(string friendlyName, Evidence securityInfo, AppDomainSetup info, PermissionSet grantSet, params StrongName[] fullTrustAssemblies);
        [SecuritySafeCritical]
        public static AppDomain CreateDomain(string friendlyName, Evidence securityInfo, AppDomainSetup info);
        public static AppDomain CreateDomain(string friendlyName, Evidence securityInfo);
        public static AppDomain CreateDomain(string friendlyName);

        /*
        [Obsolete("AppDomain.GetCurrentThreadId has been deprecated because it does not provide a stable Id when managed threads are running on fibers (aka lightweight threads). To get a stable identifier for a managed thread, use the ManagedThreadId property on Thread.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
        public static int GetCurrentThreadId();
        */

        [ReliabilityContract(Consistency.MayCorruptAppDomain, Cer.MayFail)]
        [SecuritySafeCritical]
        public static void Unload(AppDomain domain);

        /*
        [Obsolete("AppDomain.AppendPrivatePath has been deprecated. Please investigate the use of AppDomainSetup.PrivateBinPath instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void AppendPrivatePath(string path);
        */

        [ComVisible(false)]
        public string ApplyPolicy(string assemblyName);

        /*
        [Obsolete("AppDomain.ClearPrivatePath has been deprecated. Please investigate the use of AppDomainSetup.PrivateBinPath instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void ClearPrivatePath();

        [Obsolete("AppDomain.ClearShadowCopyPath has been deprecated. Please investigate the use of AppDomainSetup.ShadowCopyDirectories instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void ClearShadowCopyPath();
        */


        public ObjectHandle CreateComInstanceFrom(string assemblyName, string typeName);
        public ObjectHandle CreateComInstanceFrom(string assemblyFile, string typeName, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm);
        public ObjectHandle CreateInstance(string assemblyName, string typeName);
        public ObjectHandle CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes);
        
        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstance which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public ObjectHandle CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes);
        */
        
        public ObjectHandle CreateInstance(string assemblyName, string typeName, object[] activationAttributes);
        public object CreateInstanceAndUnwrap(string assemblyName, string typeName);
        public object CreateInstanceAndUnwrap(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes);
        
        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstanceAndUnwrap which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public object CreateInstanceAndUnwrap(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes);
        */

        public object CreateInstanceAndUnwrap(string assemblyName, string typeName, object[] activationAttributes);
        public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName, object[] activationAttributes);
        public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes);
        public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName);
        
        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstanceFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes);
        */

        public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName);
        public object CreateInstanceFromAndUnwrap(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes);
        
        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstanceFromAndUnwrap which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes);
        */
        
        public object CreateInstanceFromAndUnwrap(string assemblyName, string typeName, object[] activationAttributes);
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access);
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder> assemblyAttributes);
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder> assemblyAttributes, SecurityContextSource securityContextSource);
        
        /*
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default.  See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions);
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default.  See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, Evidence evidence);
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions);
        */
        
        
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir);

        /*
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions);
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of DefineDynamicAssembly which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkId=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence);
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default.  Please see http://go.microsoft.com/fwlink/?LinkId=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions);
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions, bool isSynchronized);
        [Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, Evidence evidence, PermissionSet requiredPermissions, PermissionSet optionalPermissions, PermissionSet refusedPermissions, bool isSynchronized, IEnumerable<CustomAttributeBuilder> assemblyAttributes);
        */
        
        [SecuritySafeCritical]
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, string dir, bool isSynchronized, IEnumerable<CustomAttributeBuilder> assemblyAttributes);
        public void DoCallBack(CrossAppDomainDelegate callBackDelegate);
        public int ExecuteAssembly(string assemblyFile, string[] args, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm);
        public int ExecuteAssembly(string assemblyFile, string[] args);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssembly which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssembly(string assemblyFile, Evidence assemblySecurity, string[] args);
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssembly which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssembly(string assemblyFile, Evidence assemblySecurity, string[] args, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm);
        */
        
        public int ExecuteAssembly(string assemblyFile);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssembly which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssembly(string assemblyFile, Evidence assemblySecurity);
        */

        public int ExecuteAssemblyByName(AssemblyName assemblyName, params string[] args);
        public int ExecuteAssemblyByName(string assemblyName);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssemblyByName which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssemblyByName(string assemblyName, Evidence assemblySecurity);
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssemblyByName which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssemblyByName(string assemblyName, Evidence assemblySecurity, params string[] args);
        */

        public int ExecuteAssemblyByName(string assemblyName, params string[] args);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of ExecuteAssemblyByName which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        public int ExecuteAssemblyByName(AssemblyName assemblyName, Evidence assemblySecurity, params string[] args);
        */


        // Gets the assemblies that have been loaded into the execution context of this application domain.
        public Assembly[] GetAssemblies();


        [SecuritySafeCritical]
        public object GetData(string name);
        public Type GetType();
        [SecurityCritical]
        public override object InitializeLifetimeService();
        public bool? IsCompatibilitySwitchSet(string value);
        public bool IsDefaultAppDomain();
        [SecuritySafeCritical]
        public bool IsFinalizingForUnload();

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public Assembly Load(string assemblyString, Evidence assemblySecurity);
        */

        [SecuritySafeCritical]
        public Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkId=155570 for more information.")]
        [SecuritySafeCritical]
        public Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence);
        */

        [SecuritySafeCritical]
        public Assembly Load(AssemblyName assemblyRef);

        /*
        [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecuritySafeCritical]
        public Assembly Load(AssemblyName assemblyRef, Evidence assemblySecurity);
        */

        [SecuritySafeCritical]
        public Assembly Load(string assemblyString);
        [SecuritySafeCritical]
        public Assembly Load(byte[] rawAssembly);
        public Assembly[] ReflectionOnlyGetAssemblies();

        /*
        [Obsolete("AppDomain policy levels are obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
        [SecurityCritical]
        public void SetAppDomainPolicy(PolicyLevel domainPolicy);
        [Obsolete("AppDomain.SetCachePath has been deprecated. Please investigate the use of AppDomainSetup.CachePath instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void SetCachePath(string path);
        */

        [SecurityCritical]
        public void SetData(string name, object data);
        [SecurityCritical]
        public void SetData(string name, object data, IPermission permission);

        /*
        [Obsolete("AppDomain.SetDynamicBase has been deprecated. Please investigate the use of AppDomainSetup.DynamicBase instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void SetDynamicBase(string path);
        */

        [SecuritySafeCritical]
        public void SetPrincipalPolicy(PrincipalPolicy policy);

        /*
        [Obsolete("AppDomain.SetShadowCopyFiles has been deprecated. Please investigate the use of AppDomainSetup.ShadowCopyFiles instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void SetShadowCopyFiles();
        [Obsolete("AppDomain.SetShadowCopyPath has been deprecated. Please investigate the use of AppDomainSetup.ShadowCopyDirectories instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        [SecurityCritical]
        public void SetShadowCopyPath(string path);
        */


        [SecuritySafeCritical]
        public void SetThreadPrincipal(IPrincipal principal);
        [SecuritySafeCritical]
        public override string ToString();
    }
}

