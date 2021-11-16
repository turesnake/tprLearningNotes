#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Shader tag ids are used to refer to various names in shaders.

        ShaderTagId 的这个名字, 要和 shader pass 的一个 tag: LightMode 的值一样才行;

        这样, unity 就能把 cpu脚本端的 ShaderTagId 实例, 和 shader 中的某个 pass 绑定到一起;

        但是在 ScriptableRenderContext.DrawRenderers() 函数的参数 renderTypes 中, 
        好像也拿去对应 SubShader tag: "RenderType" 的值... 


        
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
