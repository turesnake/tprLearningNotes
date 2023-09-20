#region Assembly UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking;

//
// Summary:
//     Asynchronous operation object returned from UnityWebRequest.SendWebRequest().
//     You can yield until it continues, register an event handler with AsyncOperation.completed,
//     or manually check whether it's done (AsyncOperation.isDone) or progress (AsyncOperation.progress).
[StructLayout(LayoutKind.Sequential)]
[UsedByNativeCode]
[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
[NativeHeader("UnityWebRequestScriptingClasses.h")]
public class UnityWebRequestAsyncOperation : AsyncOperation
{
    //
    // Summary:
    //     Returns the associated UnityWebRequest that created the operation.
    public UnityWebRequest webRequest { get; internal set; }
}



