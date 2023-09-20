#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     Asynchronous operation coroutine.
[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Runtime/Export/Scripting/AsyncOperation.bindings.h")]
[RequiredByNativeCode]
[NativeHeader("Runtime/Misc/AsyncOperation.h")]
public class AsyncOperation : YieldInstruction
{
    internal IntPtr m_Ptr;

    private Action<AsyncOperation> m_completeCallback;

    //
    // Summary:
    //     Has the operation finished? (Read Only)
    public extern bool isDone
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("IsDone")]
        get;
    }

    //
    // Summary:
    //     What's the operation's progress. (Read Only)
    public extern float progress
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetProgress")]
        get;
    }

    //
    // Summary:
    //     Priority lets you tweak in which order async operation calls will be performed.
    public extern int priority
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetPriority")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetPriority")]
        set;
    }

    //
    // Summary:
    //     Allow Scenes to be activated as soon as it is ready.
    public extern bool allowSceneActivation
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetAllowSceneActivation")]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("SetAllowSceneActivation")]
        set;
    }

    public event Action<AsyncOperation> completed
    {
        add
        {
            if (isDone)
            {
                value(this);
            }
            else
            {
                m_completeCallback = (Action<AsyncOperation>)Delegate.Combine(m_completeCallback, value);
            }
        }
        remove
        {
            m_completeCallback = (Action<AsyncOperation>)Delegate.Remove(m_completeCallback, value);
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsThreadSafe = true)]
    [StaticAccessor("AsyncOperationBindings", StaticAccessorType.DoubleColon)]
    private static extern void InternalDestroy(IntPtr ptr);

    ~AsyncOperation()
    {
        InternalDestroy(m_Ptr);
    }

    [RequiredByNativeCode]
    internal void InvokeCompletionEvent()
    {
        if (m_completeCallback != null)
        {
            m_completeCallback(this);
            m_completeCallback = null;
        }
    }
}
