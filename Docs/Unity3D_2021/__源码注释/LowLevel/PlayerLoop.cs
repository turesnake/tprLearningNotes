#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.LowLevel;

//
// Summary:
//     The class representing the player loop in Unity.
[MovedFrom("UnityEngine.Experimental.LowLevel")]
public class PlayerLoop
{
    //
    // Summary:
    //     Returns the default update order of all engine systems in Unity.
    public static PlayerLoopSystem GetDefaultPlayerLoop()
    {
        PlayerLoopSystemInternal[] defaultPlayerLoopInternal = GetDefaultPlayerLoopInternal();
        int offset = 0;
        return InternalToPlayerLoopSystem(defaultPlayerLoopInternal, ref offset);
    }

    //
    // Summary:
    //     Returns the current update order of all engine systems in Unity.
    public static PlayerLoopSystem GetCurrentPlayerLoop()
    {
        PlayerLoopSystemInternal[] currentPlayerLoopInternal = GetCurrentPlayerLoopInternal();
        int offset = 0;
        return InternalToPlayerLoopSystem(currentPlayerLoopInternal, ref offset);
    }

    //
    // Summary:
    //     Set a new custom update order of all engine systems in Unity.
    //
    // Parameters:
    //   loop:
    public static void SetPlayerLoop(PlayerLoopSystem loop)
    {
        List<PlayerLoopSystemInternal> internalSys = new List<PlayerLoopSystemInternal>();
        PlayerLoopSystemToInternal(loop, ref internalSys);
        SetPlayerLoopInternal(internalSys.ToArray());
    }

    private static int PlayerLoopSystemToInternal(PlayerLoopSystem sys, ref List<PlayerLoopSystemInternal> internalSys)
    {
        int count = internalSys.Count;
        PlayerLoopSystemInternal playerLoopSystemInternal = default(PlayerLoopSystemInternal);
        playerLoopSystemInternal.type = sys.type;
        playerLoopSystemInternal.updateDelegate = sys.updateDelegate;
        playerLoopSystemInternal.updateFunction = sys.updateFunction;
        playerLoopSystemInternal.loopConditionFunction = sys.loopConditionFunction;
        playerLoopSystemInternal.numSubSystems = 0;
        PlayerLoopSystemInternal playerLoopSystemInternal2 = playerLoopSystemInternal;
        internalSys.Add(playerLoopSystemInternal2);
        if (sys.subSystemList != null)
        {
            for (int i = 0; i < sys.subSystemList.Length; i++)
            {
                playerLoopSystemInternal2.numSubSystems += PlayerLoopSystemToInternal(sys.subSystemList[i], ref internalSys);
            }
        }

        internalSys[count] = playerLoopSystemInternal2;
        return playerLoopSystemInternal2.numSubSystems + 1;
    }

    private static PlayerLoopSystem InternalToPlayerLoopSystem(PlayerLoopSystemInternal[] internalSys, ref int offset)
    {
        PlayerLoopSystem playerLoopSystem = default(PlayerLoopSystem);
        playerLoopSystem.type = internalSys[offset].type;
        playerLoopSystem.updateDelegate = internalSys[offset].updateDelegate;
        playerLoopSystem.updateFunction = internalSys[offset].updateFunction;
        playerLoopSystem.loopConditionFunction = internalSys[offset].loopConditionFunction;
        playerLoopSystem.subSystemList = null;
        PlayerLoopSystem result = playerLoopSystem;
        int num = offset++;
        if (internalSys[num].numSubSystems > 0)
        {
            List<PlayerLoopSystem> list = new List<PlayerLoopSystem>();
            while (offset <= num + internalSys[num].numSubSystems)
            {
                list.Add(InternalToPlayerLoopSystem(internalSys, ref offset));
            }

            result.subSystemList = list.ToArray();
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsFreeFunction = true)]
    private static extern PlayerLoopSystemInternal[] GetDefaultPlayerLoopInternal();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsFreeFunction = true)]
    private static extern PlayerLoopSystemInternal[] GetCurrentPlayerLoopInternal();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsFreeFunction = true)]
    private static extern void SetPlayerLoopInternal(PlayerLoopSystemInternal[] loop);
}
