#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
#endregion

using System.Runtime.InteropServices;

namespace System.Reflection
{
    /*
        Specifies flags that control binding 
        and the way in which the search for members and types is conducted(实施) by reflection.
        ---
        控制绑定, 和 通过反射来搜索 members and types;

        flags 之间可以组合使用;


    */
    [__DynamicallyInvokableAttribute]
    [ComVisible(true)]
    [Flags]
    public enum BindingFlags
    {
        Default = 0,
        IgnoreCase = 1,
        DeclaredOnly = 2,
        
        Instance = 4,//Specifies that instance members are to be included in the search.

        Static = 8,

       
        Public = 16,//Specifies that public members are to be included in the search.

        NonPublic = 32,//Specifies that non-public members are to be included in the search.

        FlattenHierarchy = 64,
        InvokeMethod = 256,
        CreateInstance = 512,
        GetField = 1024,
        SetField = 2048,
        GetProperty = 4096,
        SetProperty = 8192,
        PutDispProperty = 16384,
        PutRefDispProperty = 32768,
        ExactBinding = 65536,
        SuppressChangeType = 131072,
        OptionalParamBinding = 262144,
        IgnoreReturn = 16777216
    }
}

