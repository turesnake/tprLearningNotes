#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Shader tag ids are used to refer to various names in shaders.


        在很多资料中, 此类实例, 和 shader pass tag: "LightMode" 的值 (key-value 中的 value) 相互绑定;
        比如:

            ShaderTagId id = new ShaderTagId( "SRPDefaultUnlit" ),

        此处的参数 "SRPDefaultUnlit", 就是 "LightMode" 的一种可选值;
        通过这个方式, 就能在 cpu脚本端, 获得对应的一个 shader pass 的使用权;
        ---
        即, 一个 ShaderTagId 实例, 绑定一个具体的 shader pass;
        
        ===
        但是在 ScriptableRenderContext.DrawRenderers() 函数的参数 renderTypes 中, 
        好像也拿 本类实例, 去对应 SubShader tag: "RenderType" 的值... 

        甚至在 Shader.FindPassTagValue() 函数中, 甚至拿本类实例, 去绑定一个 "shader pass tag";
        (这反而更像是本类的 原始用途)

    */
    public struct ShaderTagId : IEquatable<ShaderTagId>//ShaderTagId__
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
