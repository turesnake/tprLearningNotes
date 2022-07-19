#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        Represents an opaque identifier of a specific Pass in a Shader.

        主要内容是两个 idx, 然后一对 比较运算符;
    */
    [NativeHeaderAttribute("Runtime/Shaders/PassIdentifier.h")]
    [UsedByNativeCodeAttribute]
    public readonly struct PassIdentifier : IEquatable<PassIdentifier>
    {
        //
        // 摘要:
        //     The index of the subshader within the shader (Read Only).
        public uint SubshaderIndex { get; }
        //
        // 摘要:
        //     The index of the pass within the subshader (Read Only).
        public uint PassIndex { get; }

        public override bool Equals(object o);
        public bool Equals(PassIdentifier rhs);
        public override int GetHashCode();

        public static bool operator ==(PassIdentifier lhs, PassIdentifier rhs);
        public static bool operator !=(PassIdentifier lhs, PassIdentifier rhs);
    }
}

