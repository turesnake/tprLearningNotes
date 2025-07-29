#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine;

/*
    Summary:
        Gradient used for animating colors.

        一个颜色轴



*/
[StructLayout(LayoutKind.Sequential)]
[RequiredByNativeCode]
[NativeHeader("Runtime/Export/Math/Gradient.bindings.h")]
public class Gradient : IEquatable<Gradient>
{
    internal IntPtr m_Ptr;

    //
    // Summary:
    //     All color keys defined in the gradient.
    public extern GradientColorKey[] colorKeys
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("Gradient_Bindings::GetColorKeys", IsThreadSafe = true, HasExplicitThis = true)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("Gradient_Bindings::SetColorKeys", IsThreadSafe = true, HasExplicitThis = true)]
        [param: Unmarshalled]
        set;
    }

    //
    // Summary:
    //     All alpha keys defined in the gradient.
    public extern GradientAlphaKey[] alphaKeys
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("Gradient_Bindings::GetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        [FreeFunction("Gradient_Bindings::SetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)]
        [param: Unmarshalled]
        set;
    }

    //
    // Summary:
    //     Control how the gradient is evaluated.
    [NativeProperty(IsThreadSafe = true)]
    public extern GradientMode mode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    [NativeProperty(IsThreadSafe = true)]
    internal Color constantColor
    {
        get
        {
            get_constantColor_Injected(out var ret);
            return ret;
        }
        set
        {
            set_constantColor_Injected(ref value);
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "Gradient_Bindings::Init", IsThreadSafe = true)]
    private static extern IntPtr Init();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "Gradient_Bindings::Cleanup", IsThreadSafe = true, HasExplicitThis = true)]
    private extern void Cleanup();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction("Gradient_Bindings::Internal_Equals", IsThreadSafe = true, HasExplicitThis = true)]
    private extern bool Internal_Equals(IntPtr other);

    //
    // Summary:
    //     Create a new Gradient object.
    [RequiredByNativeCode]
    public Gradient()
    {
        m_Ptr = Init();
    }

    ~Gradient()
    {
        Cleanup();
    }

    //
    // Summary:
    //     Calculate color at a given time.
    //
    // Parameters:
    //   time:
    //     Time of the key (0 - 1).
    [FreeFunction(Name = "Gradient_Bindings::Evaluate", IsThreadSafe = true, HasExplicitThis = true)]
    public Color Evaluate(float time)
    {
        Evaluate_Injected(time, out var ret);
        return ret;
    }

    //
    // Summary:
    //     Setup Gradient with an array of color keys and alpha keys.
    //
    // Parameters:
    //   colorKeys:
    //     Color keys of the gradient (maximum 8 color keys).
    //
    //   alphaKeys:
    //     Alpha keys of the gradient (maximum 8 alpha keys).
    [MethodImpl(MethodImplOptions.InternalCall)]
    [FreeFunction(Name = "Gradient_Bindings::SetKeys", IsThreadSafe = true, HasExplicitThis = true)]
    public extern void SetKeys([Unmarshalled] GradientColorKey[] colorKeys, [Unmarshalled] GradientAlphaKey[] alphaKeys);

    public override bool Equals(object o)
    {
        if (o == null)
        {
            return false;
        }

        if (this == o)
        {
            return true;
        }

        if ((object)o.GetType() != GetType())
        {
            return false;
        }

        return Equals((Gradient)o);
    }

    public bool Equals(Gradient other)
    {
        if (other == null)
        {
            return false;
        }

        if (this == other)
        {
            return true;
        }

        if (m_Ptr.Equals(other.m_Ptr))
        {
            return true;
        }

        return Internal_Equals(other.m_Ptr);
    }

    public override int GetHashCode()
    {
        return m_Ptr.GetHashCode();
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Evaluate_Injected(float time, out Color ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void get_constantColor_Injected(out Color ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [SpecialName]
    private extern void set_constantColor_Injected(ref Color value);
}

