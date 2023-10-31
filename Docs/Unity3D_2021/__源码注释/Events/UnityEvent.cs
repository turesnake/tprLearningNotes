#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine.Events;

//
// Summary:
//     A zero argument persistent callback that can be saved with the Scene.
[Serializable]
public class UnityEvent : UnityEventBase
{
    private object[] m_InvokeArray = null;

    //
    // Summary:
    //     Constructor.
    [RequiredByNativeCode]
    public UnityEvent()
    {
    }

    //
    // Summary:
    //     Add a non persistent listener to the UnityEvent.
    //
    // Parameters:
    //   call:
    //     Callback function.
    public void AddListener(UnityAction call)
    {
        AddCall(GetDelegate(call));
    }

    //
    // Summary:
    //     Remove a non persistent listener from the UnityEvent. If you have added the same
    //     listener multiple times, this method will remove all occurrences of it.
    //
    // Parameters:
    //   call:
    //     Callback function.
    public void RemoveListener(UnityAction call)
    {
        RemoveListener(call.Target, call.Method);
    }

    protected override MethodInfo FindMethod_Impl(string name, Type targetObjType)
    {
        return UnityEventBase.GetValidMethodInfo(targetObjType, name, new Type[0]);
    }

    internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
    {
        return new InvokableCall(target, theFunction);
    }

    private static BaseInvokableCall GetDelegate(UnityAction action)
    {
        return new InvokableCall(action);
    }

    //
    // Summary:
    //     Invoke all registered callbacks (runtime and persistent).
    public void Invoke()
    {
        List<BaseInvokableCall> list = PrepareInvoke();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] is InvokableCall invokableCall)
            {
                invokableCall.Invoke();
                continue;
            }

            if (list[i] is InvokableCall invokableCall2)
            {
                invokableCall2.Invoke();
                continue;
            }

            BaseInvokableCall baseInvokableCall = list[i];
            if (m_InvokeArray == null)
            {
                m_InvokeArray = new object[0];
            }

            baseInvokableCall.Invoke(m_InvokeArray);
        }
    }

    internal void AddPersistentListener(UnityAction call)
    {
        AddPersistentListener(call, UnityEventCallState.RuntimeOnly);
    }

    internal void AddPersistentListener(UnityAction call, UnityEventCallState callState)
    {
        int persistentEventCount = GetPersistentEventCount();
        AddPersistentListener();
        RegisterPersistentListener(persistentEventCount, call);
        SetPersistentListenerState(persistentEventCount, callState);
    }

    internal void RegisterPersistentListener(int index, UnityAction call)
    {
        if (call == null)
        {
            Debug.LogWarning("Registering a Listener requires an action");
        }
        else
        {
            RegisterPersistentListener(index, call.Target as Object, call.Method.DeclaringType, call.Method);
        }
    }
}
