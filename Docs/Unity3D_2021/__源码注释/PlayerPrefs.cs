#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;


/*
    持久化存储一些数据, 这些数据会存储到本地机器上 (我猜), 就算退出游戏也依然有效;
    可以当作一种存档系统;


*/
//
// Summary:
//     `PlayerPrefs` is a class that stores Player preferences between game sessions.
//     It can store string, float and integer values into the user’s platform registry.
[NativeHeader("Runtime/Utilities/PlayerPrefs.h")]
public class PlayerPrefs
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetInt")]
    private static extern bool TrySetInt(string key, int value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetFloat")]
    private static extern bool TrySetFloat(string key, float value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetString")]
    private static extern bool TrySetSetString(string key, string value);

    //
    // Summary:
    //     Sets a single integer value for the preference identified by the given key. You
    //     can use PlayerPrefs.GetInt to retrieve this value.
    //
    // Parameters:
    //   key:
    //
    //   value:
    public static void SetInt(string key, int value)
    {
        if (!TrySetInt(key, value))
        {
            throw new PlayerPrefsException("Could not store preference value");
        }
    }

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetInt(string key, int defaultValue);

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public static int GetInt(string key)
    {
        return GetInt(key, 0);
    }

    //
    // Summary:
    //     Sets the float value of the preference identified by the given key. You can use
    //     PlayerPrefs.GetFloat to retrieve this value.
    //
    // Parameters:
    //   key:
    //
    //   value:
    public static void SetFloat(string key, float value)
    {
        if (!TrySetFloat(key, value))
        {
            throw new PlayerPrefsException("Could not store preference value");
        }
    }

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float GetFloat(string key, float defaultValue);

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public static float GetFloat(string key)
    {
        return GetFloat(key, 0f);
    }

    //
    // Summary:
    //     Sets a single string value for the preference identified by the given key. You
    //     can use PlayerPrefs.GetString to retrieve this value.
    //
    // Parameters:
    //   key:
    //
    //   value:
    public static void SetString(string key, string value)
    {
        if (!TrySetSetString(key, value))
        {
            throw new PlayerPrefsException("Could not store preference value");
        }
    }

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetString(string key, string defaultValue);

    //
    // Summary:
    //     Returns the value corresponding to key in the preference file if it exists.
    //
    // Parameters:
    //   key:
    //
    //   defaultValue:
    public static string GetString(string key)
    {
        return GetString(key, "");
    }

    //
    // Summary:
    //     Returns true if the given key exists in PlayerPrefs, otherwise returns false.
    //
    //
    // Parameters:
    //   key:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasKey(string key);

    //
    // Summary:
    //     Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey
    //     has no impact.
    //
    // Parameters:
    //   key:
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DeleteKey(string key);

    //
    // Summary:
    //     Removes all keys and values from the preferences. Use with caution.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("DeleteAllWithCallback")]
    public static extern void DeleteAll();

    //
    // Summary:
    //     Writes all modified preferences to disk.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("Sync")]
    public static extern void Save();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetInt")]
    [StaticAccessor("EditorPrefs", StaticAccessorType.DoubleColon)]
    internal static extern void EditorPrefsSetInt(string key, int value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [StaticAccessor("EditorPrefs", StaticAccessorType.DoubleColon)]
    [NativeMethod("GetInt")]
    internal static extern int EditorPrefsGetInt(string key, int defaultValue);
}

