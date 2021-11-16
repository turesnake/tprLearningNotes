#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Shader tag ids are used to refer to various names in shaders.

        目前看就是对一个 shader name(string) 的封装,
        不知道 内部是否执行了啥功能;
        
    */
    public struct ShaderTagId : IEquatable<ShaderTagId>
    {
        

        // 摘要:
        //     Describes a shader tag id not referring to any name.
        public static readonly ShaderTagId none;

        
        // 摘要:
        //     Gets or creates a shader tag id representing the given name.
        //
        // 参数:
        //   name:
        //     The name to represent with the shader tag id.
        public ShaderTagId(string name);


        
        // 摘要:
        //     Gets the name of the tag referred to by the shader tag id.
        public string name { get; }


        public override bool Equals(object obj);
        public bool Equals(ShaderTagId other);
        public override int GetHashCode();

        public static bool operator ==(ShaderTagId tag1, ShaderTagId tag2);
        public static bool operator !=(ShaderTagId tag1, ShaderTagId tag2);


        // 类型转换运算符
        public static explicit operator ShaderTagId(string name);
        public static explicit operator string(ShaderTagId tagId);
    }
}
