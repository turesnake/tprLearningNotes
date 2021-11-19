#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    /*
        摘要:
        Flags that control how a shader property behaves.


        When the Unity Editor compiles a ShaderLab script, 

        根据你在 shader 文件中为一个 property 编写的 attributes, 比如:
            [NoScaleOffset] _DetailNormalMap("Detail Normals", 2D) = "bump" {}
        
        unity 会在编译时, 为这个 property 对象, 开启一个 本类的 ShaderPropertyFlags.NoScaleOffset flag;

        如果你为这个 shader property 编写了好几个 attributes, 那么 unity编译器就会用 本类的 多个 flag 来组合表达;

    */
    [Flags]
    public enum ShaderPropertyFlags
    {
        
        // 摘要:
        //     No flags are set.
        None = 0,
        
        // 摘要:
        //     Signifies that Unity hides the property in the default Material Inspector.
        //     "[HideInInspector]"
        HideInInspector = 1,
        
        /*
            摘要:
                In the Material Inspector, Unity queries the value for this property from the
                Renderer's MaterialPropertyBlock, instead of from the Material. The value will
                also appear as read-only.
                "[PerRendererData]"
        */
        PerRendererData = 2,

        /*
            摘要:
            Do not show UV scale/offset fields next to Textures in the default Material Inspector.

            仅能被设置给 Texture shader properties, 而且只是取消了 inspector 上 st信息的显示;
            在内部, unity 还是为这个 texture 分配了 "XXX_ST" vector; (也就是 st信息..)

            "[NoScaleOffset]"
        */
        NoScaleOffset = 4,

        /*
            摘要:
            Signifies that values of this property contain Normal (normalized vector) data.

            猜测:
                (应该是 法线贴图,  而不是 归一化数据...)

            若设置了此 attribute, 如果你向这个 property 绑定了 不符合要求的数据, material inspector 上
            将显示 warning 窗口;
            "[Normal]"
        */
        Normal = 8,

        /*
            摘要:
            Signifies that values of this property contain High Dynamic Range (HDR) data.

            若设置了此 attribute, 如果你向这个 property 绑定了 不符合要求的数据, material inspector 上
            将显示 warning 窗口;

            比如, 如果向一个 hdr texture 绑定的数据中有 alpha通道信息, (而 hdr 格式中不支持) 
            就会发生此 warning; 
            "[HDR]"
        */
        HDR = 16,

        /*
            摘要:
            Signifies that values of this property are in gamma space. If the active color
            space is linear, Unity converts the values to linear space values.
            ---
            表示绑定到本 property 的数据是 gamma 的, 如果此时 app 选用了 线性颜色空间,
            那么 unity 会主动对这个 property 中的数据执行 gamma->linear 转换;
            "[Gamma]"
        */
        Gamma = 32,

        /*
            摘要:
            You cannot edit this Texture property in the default Material Inspector.
            The shader importer specifies this flag, and users cannot control it.
        */
        NonModifiableTextureData = 64,


        /*
            摘要:
            Signifies that value of this property contains the main texture of the Material.

            This flag corresponds to the [MainTexture] ShaderLab Properties attribute.

            By default, Unity considers a texture with the property name name "_MainTex" to be the main texture. 
            Use the [MainTexture] ShaderLab Properties attribute to make Unity consider a texture with 
            a different property name to be the main texture.
        */
        MainTexture = 128,

        /*
            摘要:
            Signifies that value of this property contains the main color of the Material.

            This flag corresponds to the [MainColor] ShaderLab Properties attribute.

            By default, Unity considers a color with the property name name "_Color" to be the main color. 
            Use the [MainColor] ShaderLab Properties attribute to make Unity consider a color with 
            a different property name to be the main color.
        */
        MainColor = 256
    }
}

