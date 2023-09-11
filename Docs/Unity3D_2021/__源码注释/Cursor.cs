#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine;

//
// Summary:
//     Cursor API for setting the cursor (mouse pointer).
[NativeHeader("Runtime/Export/Input/Cursor.bindings.h")]
public class Cursor
{
    //
    // Summary:
    //     Determines whether the hardware pointer is visible or not.
    public static extern bool visible
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Determines whether the hardware pointer is locked to the center of the view,
    //     constrained to the window, or not constrained at all.
    public static extern CursorLockMode lockState
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    private static void SetCursor(Texture2D texture, CursorMode cursorMode)
    {
        SetCursor(texture, Vector2.zero, cursorMode);
    }

    //
    // Summary:
    //     Specify a custom cursor that you wish to use as a cursor.
    //
    // Parameters:
    //   texture:
    //     The texture to use for the cursor. To use a texture, you must first import it
    //     with `Read/Write`enabled. Alternatively, you can use the default cursor import
    //     setting. If you created your cursor texture from code, it must be in RGBA32 format,
    //     have alphaIsTransparency enabled, and have no mip chain. To use the default cursor,
    //     set the texture to `Null`.
    //
    //   hotspot:
    //     The offset from the top left of the texture to use as the target point (must
    //     be within the bounds of the cursor).
    //
    //   cursorMode:
    //     Allow this cursor to render as a hardware cursor on supported platforms, or force
    //     software cursor.
    public static void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
    {
        SetCursor_Injected(texture, ref hotspot, cursorMode);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetCursor_Injected(Texture2D texture, ref Vector2 hotspot, CursorMode cursorMode);
}

