#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

namespace UnityEngine;

//
// Summary:
//     How the cursor should behave.
public enum CursorLockMode
{
    //
    // Summary:
    //     Cursor behavior is unmodified.   -- 解锁时选择
    None,
    //
    // Summary:
    //     Lock cursor to the center of the game window.     -- 锁定时选择
    Locked, 
    //
    // Summary:
    //     Confine cursor to the game window.
    Confined
}

