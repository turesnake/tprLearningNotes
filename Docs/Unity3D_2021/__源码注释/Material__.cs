#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /*
        摘要:
        The material class.

        本类暴露了 material 的所有 properties, 以便你可以为它们设置动画;

        还能用本类来设置那些 无法在 material inspector 中可见的 自定义 shader property 的信息;
        ( 比如矩阵 )

        使用 Renderer.material 来得到一个物体所用的 material 实例;
    */
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Shaders/Material.h")]
    public class Material : Object
    {

        /*
            摘要:
            Create a temporary Material.

            如果你想在一个 脚本文件内实现一个 自定义特殊效果, 你可以使用 shaders 和 materials 
            来实现几乎所有 graphic setup 工作;

            使用本函数来生成一个 自定义 material 实例;
            然后使用:
                SetColor(), SetTexture(), SetFloat(), SetVector(), SetMatrix()
            等函数来设置 shader property 的值;            

            参数:
            shader:
                Create a material with a given Shader.
            
            source:
                Create a material by copying all properties from another material.
        */
        public Material(Shader shader);
        [RequiredByNativeCodeAttribute]
        public Material(Material source);

        /*
        // 参数:
        //   contents:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", false)]
        public Material(string contents);
        */



        /*
            摘要:
            An array containing the "names of the local shader keywords" that are currently enabled for this material.

            必须是在当前状态 开启的 local keywords, 才会被收录;

            local shader keywords:
                就是使用:
                    #pragma shader_feature_local
                    #pragma multi_compile_local
                在 shader 程序中定义的 keywords
        */
        public string[] shaderKeywords { get; set; }


        
        // 摘要:
        //     Gets and sets whether GPU instancing is enabled for this material.
        [NativePropertyAttribute("EnableInstancingVariants")]
        public bool enableInstancing { get; set; }


        /*
            摘要:
            Gets and sets whether the Double Sided Global Illumination setting is enabled for this material.

            当开启时, lightmap 会考虑几何体的 前后两面信息;
            此时, backfaces 不会被渲染进 lightmap, but get treated as valid when seen from other objects;
            当选用 Progressive Lightmapper, backfaces 也能像 frontfaces 一样去自发光和反射 albedo;

            奇怪的是, 大部分时候, 这个选项好像都是不开启的... 为何 
        */
        public bool doubleSidedGI { get; set; }


        /*
            摘要:
            Defines how the material should interact with lightmaps and lightprobes.

            A custom shader GUI will usually set these values based on user input.
            自定义 shader GUI 通常会设置这些值, 基于用户的 输入
        */
        public MaterialGlobalIlluminationFlags globalIlluminationFlags { get; set; }


        /*
            摘要:
            Render queue of this material.

            默认:
                Shader.renderQueue 变量直接读取它的 active subshader 的 tag: "Queue" 的值;
                而 material 则会直接使用它所绑定的 shader 的 这个值;
                (其实也就是 class RenderQueue 描述的信息)

            此外:
                可以手动改写 materail.renderQueue, (在 inspector 上也能改写)
                以此来 覆写 shader 中的原始值;

            注意:
            如果 material 重绑定了新的 shader, 那么 renderQueue 还是会被重置为 新 shader 的值;
            (猜测此时, 本变量值为 -1, 失去覆写功能)

            Render queue 的值应该位于区间: [0..5000]; 
            
            如果本变量被设为 -1:
                就意味着要沿用  shader 中的值;
        */
        public int renderQueue { get; set; }


        /*
            摘要:
            The scale / offset of the main texture.

            就是 "_MainTex" 的 st 数据, 可以设置, 也能读取;
        */
        public Vector2 mainTextureScale { get; set; }
        public Vector2 mainTextureOffset { get; set; }


        
        // 摘要:
        //     The main texture. "_MainTex"
        public Texture mainTexture { get; set; }

        
        // 摘要:
        //     The main color of the Material. "_Color"
        public Color color { get; set; }

        
        // 摘要:
        //     The shader used by the material.
        public Shader shader { get; set; }


        /*
            摘要:
            How many passes are in this material (Read Only).

            This returns the number of passes made such as in direct drawing code. 
            For example, drawing 3D primitives with GL.Begin(), GL.End(), 
            and also drawing meshes using Graphics.DrawMeshNow().
        */
        public int passCount { get; }


        /*
        [Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.", false)]
        public static Material Create(string scriptContents);
        */


        /*
            摘要:
            Computes a CRC hash value from the content of the material.

            The computation of CRC values may change in future Unity releases. 
            Therefore, do not use CRC values for serialization.
        */
        public int ComputeCRC();


        /*
            摘要:
            Copy properties from other material into this material.

            This function copies 
                -- property values (both serialized and set at runtime),
                -- "shader keywords", 
                -- "render queue" 
                -- "global illumination flags" 
            from the other material. 
            
            Material's shader is not changed.
        */
        [FreeFunctionAttribute("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = true)]
        public void CopyPropertiesFromMaterial(Material mat);


        /*
            摘要:
            Disables a local shader keyword for this material.

            详细查看下方的 EnableKeyword() 中的解释;
            
        // 参数:
        //   keyword:
        //     The name of the local shader keyword to disable.
        */
        public void DisableKeyword(string keyword);


        /*
            摘要:
            Enables a "local shader keyword" for this material.
            注意:
                是 "local" shader keyword;

            tpr:
                -1-:
                    必须在 shader 代码中使用: 
                        #pragma multi_compile_local     (局部)
                        #pragma shader_feature_local    (局部)
                        #pragma multi_compile           (全局)
                        #pragma shader_feature          (全局)
                    声明了目标 keyword 才行, 这样编译器才会真的生成两路 shader variants;
                    关于 global keyword:
                        如果一个 shader, 没有此名字的 local keyword, 但是有同名的 global keyword,
                        本函数也是能改写的;
                    ---
                -2-:
                    在 shader 代码中, 使用这个 kayword 来获得不同的效果;
                    ---
                -3-:
                    在 任意脚本代码中, 不管是在 Start() 还是 Update() 中,
                    只要调用本函数,都会立即启用这个 keyword; 
                    然后,
                    unity 会针对这个 material 所绑定的 shaders, 
                    去寻找它们的 variants 中支持这个 keyword 的版本, 并调用这些 variants;
                    ---

        // 参数:
        //   keyword:
        //     The name of the local shader keyword to enable.
        */
        public void EnableKeyword(string keyword);


        
        // 摘要:
        //     Returns the index of the pass. return -1 if it does not exist.
        public int FindPass(string passName);


        /*
            摘要:
            Get a named color value.

            color values are be converted from sRGB to Linear value, when using linear color space
        
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public Color GetColor(int nameID);
        public Color GetColor(string name);


        /*
            摘要:
            Get a named color array.

            本函数只是  GetVectorArray() 的简单变种,
            本函数中不包含 gamma-linear 空间转换
        
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public Color[] GetColorArray(string name);
        public Color[] GetColorArray(int nameID);
        public void GetColorArray(int nameID, List<Color> values);
        public void GetColorArray(string name, List<Color> values);
        


        
        // 摘要:
        //     Get a named float value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public float GetFloat(string name);
        public float GetFloat(int nameID);
        


        /*
            摘要:
            Get a named float array.

            The list will be resized to the array size, 
            or cleared if such property doesn't exist.

            Memory allocation is guaranteed not to happen during the function call.
        
        // 参数:
        //   name:
        //     The name of the property.
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        */
        public void GetFloatArray(int nameID, List<float> values);
        public void GetFloatArray(string name, List<float> values);
        public float[] GetFloatArray(int nameID);
        public float[] GetFloatArray(string name);


        /*
        // 摘要:
        //     This method is deprecated. Use GetFloat or GetInteger instead.
        public int GetInt(string name);
        public int GetInt(int nameID);
        */


        
        // 摘要:
        //     Get a named integer value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public int GetInteger(string name);
        public int GetInteger(int nameID);


        /*
            摘要:
            Get a named matrix value from the shader.

            本函数主要用于 自定义shader, 当它们需要自己的 矩阵数据时;
            矩阵是不会暴露在 material inspector 中的, 只能通过函数来读写
            
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public Matrix4x4 GetMatrix(string name);
        public Matrix4x4 GetMatrix(int nameID);
        

        /*
            摘要:
            Get a named matrix array.

            The list will be resized to the array size, 
            or cleared if such property doesn't exist. 
            Memory allocation is guaranteed not to happen during the function call.
        
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        */
        public void GetMatrixArray(int nameID, List<Matrix4x4> values);
        public void GetMatrixArray(string name, List<Matrix4x4> values);
        public Matrix4x4[] GetMatrixArray(int nameID);
        public Matrix4x4[] GetMatrixArray(string name);


        /*
            摘要:
            Returns the name of the shader pass at index pass.
            It will return an empty string if the pass does not exist.
        
        // 参数:
        //   pass:
        */
        public string GetPassName(int pass);


        /*
            摘要:
            Checks whether a given Shader pass is enabled on this Material.

            默认, 所有 shader passes 都是 enabled;

            如果目标 pass 通过 Material.SetShaderPassEnabled() 被禁用了, 此函数才会返回 false;

            如果在 本 material 当前使用的 shader 中, 没有找到目标 pass, 但是没有对这个 "不存在的" pass 调用
            Material.SetShaderPassEnabled() 来禁用之.  此时本函数还是会返回 true...
        
        // 参数:
        //   passName:
        //     Shader pass name (case insensitive).
        //
        // 返回结果:
        //     True if the Shader pass is enabled.
        */
        [FreeFunctionAttribute("MaterialScripting::GetShaderPassEnabled", HasExplicitThis = true)]
        public bool GetShaderPassEnabled(string passName);


        /*
            摘要:
            Get the value of material's shader tag.

            如果 本material 的 shaders 不包含目标 tag, 就返回 参数 defaultValue 值;

            可以为每一个 subshader 设置一个同名的 tag, 然后为其设置不同的值(value);
            然后设置参数 searchFallbacks 为 false, 此时调用本函数, 就能查出来,
            当前 active 的 subshader 到底是哪一个;

            参数:
            tag:
                tag name (key)
        
            searchFallbacks:
                若为 true, 则在所有 subshaders 和 fallbacks 中查找,
                若为 false. 则不会在 fallbacks 中查找
        
            defaultValue:
                
        */
        public string GetTag(string tag, bool searchFallbacks);
        public string GetTag(string tag, bool searchFallbacks, string defaultValue);


        
        // 摘要:
        //     Get a named texture.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public Texture GetTexture(int nameID);
        public Texture GetTexture(string name);


        /*
            摘要:
            Gets the placement offset of texture propertyName.

            _ST 中的 offset 数据
        
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public Vector2 GetTextureOffset(string name);
        public Vector2 GetTextureOffset(int nameID);


        
        // 摘要:
        //     Return the name IDs of all texture properties exposed on this material.
        //
        // 返回结果:
        //     IDs of all texture properties exposed on this material.
        [FreeFunctionAttribute("MaterialScripting::GetTexturePropertyNameIDs", HasExplicitThis = true)]
        public int[] GetTexturePropertyNameIDs();
        public void GetTexturePropertyNameIDs(List<int> outNames);


        
        // 摘要:
        //     Returns the names of all texture properties exposed on this material.
        //
        // 返回结果:
        //     Names of all texture properties exposed on this material.
        [FreeFunctionAttribute("MaterialScripting::GetTexturePropertyNames", HasExplicitThis = true)]
        public string[] GetTexturePropertyNames();
        public void GetTexturePropertyNames(List<string> outNames);


        
        // 摘要:
        //     Gets the placement scale of texture propertyName.
        //     _ST 中的 scale 数据
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public Vector2 GetTextureScale(int nameID);
        public Vector2 GetTextureScale(string name);


        /*
            摘要:
            Get a named vector value.


        
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public Vector4 GetVector(string name);
        public Vector4 GetVector(int nameID);


        /*
            摘要:
            Get a named vector array.
        
            The list will be resized to the array size, 
            or cleared if such property doesn't exist.
            Memory allocation is guaranteed not to happen during the function call.

        // 参数:
        //   name:
        //     The name of the property.
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        */
        public Vector4[] GetVectorArray(string name);
        public Vector4[] GetVectorArray(int nameID);
        public void GetVectorArray(string name, List<Vector4> values);
        public void GetVectorArray(int nameID, List<Vector4> values);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a "ComputeBuffer" property
        //     with the given name.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasBuffer(int nameID);
        public bool HasBuffer(string name);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Color property with
        //     the given name.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasColor(int nameID);
        public bool HasColor(string name);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a ConstantBuffer property
        //     with the given name.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasConstantBuffer(string name);
        public bool HasConstantBuffer(int nameID);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Float property with
        //     the given name. This also works with the Float Array property.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasFloat(int nameID);
        public bool HasFloat(string name);


        /*
        // 摘要:
        //     This method is deprecated. Use HasFloat or HasInteger instead.
        public bool HasInt(int nameID);
        public bool HasInt(string name);
        */


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has an Integer property
        //     with the given name.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasInteger(int nameID);
        public bool HasInteger(string name);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Matrix property with
        //     the given name. This also works with the Matrix Array property.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasMatrix(string name);
        public bool HasMatrix(int nameID);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a property with the
        //     given name.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasProperty(string name);
        [NativeNameAttribute("HasPropertyFromScript")]
        public bool HasProperty(int nameID);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Texture property
        //     with the given name.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasTexture(int nameID);
        public bool HasTexture(string name);


        
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Vector property with
        //     the given name. This also works with the Vector Array property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if the ShaderLab file assigned to the Material has this property.
        public bool HasVector(int nameID);
        public bool HasVector(string name);


        
        // 摘要:
        //     Checks whether a "local shader keyword" is enabled for this material.
        //
        // 参数:
        //   keyword:
        //     The name of the local shader keyword to check.
        //
        // 返回结果:
        //     Returns true if the given local shader keyword is enabled for this material.
        //     Otherwise, returns false.
        public bool IsKeywordEnabled(string keyword);


        /*
            摘要:
            Interpolate properties between two materials.

            将material 中所有的 color 和 vector 值进行插值;
            得到的结果存到 本函数的 调用者 this material 身上;
            除此之外的其它数据, 都不修改;

        */
        [FreeFunctionAttribute("MaterialScripting::Lerp", HasExplicitThis = true)]
        [NativeThrowsAttribute]
        public void Lerp(Material start, Material end, float t);


        
        // 摘要:
        //     Sets a named buffer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer value to set.
        public void SetBuffer(int nameID, ComputeBuffer value);
        public void SetBuffer(string name, ComputeBuffer value);
        public void SetBuffer(int nameID, GraphicsBuffer value);
        public void SetBuffer(string name, GraphicsBuffer value);


        /*
            摘要:
            Sets a named color value.

            当 material 绑定的是 standard shader 时, 要注意, 要在设置颜色的同时,
            还是用 EnableKeyword() 去开启对应的 keyword, 才能彻底起效;
            更多细节查看:
            https://docs.unity3d.com/2021.1/Documentation/Manual/MaterialsAccessingViaScript.html
        
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name, e.g. "_Color".
        //
        //   value:
        //     Color value to set.
        */
        public void SetColor(int nameID, Color value);
        public void SetColor(string name, Color value);


        /*
            摘要:
            Sets a color array property.

            No sRGB-linear conversion is done during the function call.

            The array length can't be changed once it has been added to the block. 
            如果下一次想要传入 更长的数据, 多出来的部分数据会被截断丢弃
            如果下一次想要传入 更短的数据, 尾部那个区域会保留原来的数据;

        // 参数:
        //   name:
        //     Property name.
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Array of values to set.
        */
        public void SetColorArray(string name, Color[] values);
        public void SetColorArray(string name, List<Color> values);
        public void SetColorArray(int nameID, List<Color> values);
        public void SetColorArray(int nameID, Color[] values);


        /*
            摘要:
            Sets a ComputeBuffer or GraphicsBuffer as a "named constant buffer" for the material.

            可使用此函数来 覆写: 居住在 "给定名字的 constant buffer" 中的所有 shader 参数;

            猜测:
                就是用一个 ComputeBuffer / GraphicsBuffer 中的数据, 一股脑改写 "目标 constant buffer"
                中的全部数据;

                ComputeBuffer / GraphicsBuffer 可以比 "目标 constant buffer" 大, 只提供自己体内的一段数据,
                就能覆写整个 constant buffer;


            想要使用此函数:
                -- ComputeBuffer / GraphicsBuffer 在被创建时, 必须在 Target 类型上启用
                    ComputeBufferType.Constant 或 GraphicsBuffer.Target.Constant flag. 
                    (也就是开启 Constant 位)

                -- 写入的 buffer 和被覆写的 buffer 的 内部结构必须一致 
                    (可理解为有相同的 struct 内部结构, 大概这个意思)
                    
                -- 本 material 的所有 shader variants 必须设置相同的 constant buffer layout;
                    猜测:
                        这些 shader variants 的 目标 constant buffer 都会被覆写;

            当使用一个 非null ComputeBuffer 调用本函数之后, 后续所有的 Material.SetFloat() (或类似函数)
            如果它们要改修的数据 恰好位于 本次 "给定名字的 constant buffer" 之中, 
            这些后续的 设置函数都将无效; 
        
            参数:
            name:
                The name of the constant buffer to override.
            nameID:
                The shader property ID of the constant buffer to override.
        
            value:
                The ComputeBuffer to override the constant buffer values with, or null to remove binding.
            
            offset:
                从 buffer 的起始位置, 到绑定位置的 offset, 必须是 SystemInfo.constantBufferOffsetAlignment 的整数倍,
                当然也可设置为0, 意为绑定在 buffer 的起始位置
                ---
                猜测此时的 "buffer", 应该是提供数据的 ComputeBuffer/GraphicsBuffer;
                毕竟, 受体 constant buffer 体内的全部数据都要被覆写
            
            size:
                The number of bytes to bind.
                要绑定的内容的 字节数
        */
        public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size);
        public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size);


        /*
            摘要:
            Sets a named float value.

            当 material 绑定的是 standard shader 时, 要注意, 要在设置颜色的同时,
            还是用 EnableKeyword() 去开启对应的 keyword, 才能彻底起效;
            更多细节查看:
            https://docs.unity3d.com/2021.1/Documentation/Manual/MaterialsAccessingViaScript.html
        
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Float value to set.
        //
        //   name:
        //     Property name, e.g. "_Glossiness".
        */
        public void SetFloat(int nameID, float value);
        public void SetFloat(string name, float value);


        /*
            摘要:
            Sets a float array property.
        
            The array length can't be changed once it has been added to the block. 
            如果下一次想要传入 更长的数据, 多出来的部分数据会被截断丢弃
            如果下一次想要传入 更短的数据, 尾部那个区域会保留原来的数据;

        // 参数:
        //   name:
        //     Property name.
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Array of values to set.
        */
        public void SetFloatArray(int nameID, float[] values);
        public void SetFloatArray(string name, float[] values);
        public void SetFloatArray(int nameID, List<float> values);
        public void SetFloatArray(string name, List<float> values);


        /*
        // 摘要:
        //     This method is deprecated. Use SetFloat or SetInteger instead.
        public void SetInt(int nameID, int value);
        public void SetInt(string name, int value);
        */


        /*
            摘要:
            Sets a named integer value.
        
            当 material 绑定的是 standard shader 时, 要注意, 要在设置变量的同时,
            还是用 EnableKeyword() 去开启对应的 keyword, 才能彻底起效;
            更多细节查看:
            https://docs.unity3d.com/2021.1/Documentation/Manual/MaterialsAccessingViaScript.html

        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   value:
        //     Integer value to set.
        //
        //   name:
        //     Property name, e.g. "_SrcBlend".
        */
        public void SetInteger(string name, int value);
        public void SetInteger(int nameID, int value);


        
        // 摘要:
        //     Sets a named matrix for the shader.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name, e.g. "_CubemapRotation".
        //
        //   value:
        //     Matrix value to set.
        public void SetMatrix(string name, Matrix4x4 value);
        public void SetMatrix(int nameID, Matrix4x4 value);


        /*
            摘要:
            Sets a matrix array property.
        
            The array length can't be changed once it has been added to the block. 
            如果下一次想要传入 更长的数据, 多出来的部分数据会被截断丢弃
            如果下一次想要传入 更短的数据, 尾部那个区域会保留原来的数据;

        // 参数:
        //   name:
        //     Property name.
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Array of values to set.
        */
        public void SetMatrixArray(string name, Matrix4x4[] values);
        public void SetMatrixArray(int nameID, List<Matrix4x4> values);
        public void SetMatrixArray(string name, List<Matrix4x4> values);
        public void SetMatrixArray(int nameID, Matrix4x4[] values);


        /*
            摘要:
            Sets an override tag/value on the material.

            Will set a tag/value on the material that overrides the value of said tag from the shader. 
            This can be used to make sure replacement shaders (such as rendering DepthNormals) work 
            even if the original shader only supports a certain render type. 
            
            For example if a shader only supports a specific render type but renders in many ways using keywords, 
            SetOverrideTag() can be used fom a custom material inspector to ensure that the material 
            renders correctly even if the shader is replaced.

        // 参数:
        //   tag:
        //     Name of the tag to set.
        //
        //   val:
        //     Name of the value to set. Empty string to clear the override flag.
        */
        public void SetOverrideTag(string tag, string val);


        /*
            摘要:
            Activate the given pass for rendering.
        
            Pass indices 区间:[0, material.passCount);

            如果本函数返回 false, 则不应该执行任何渲染;
            This is typically the case for special pass types 
            that aren't meant for rendering, like GrabPass.

        // 参数:
        //   pass:
        //     Shader pass number to setup.
        //
        // 返回结果:
        //     If false is returned, no rendering should be done.
        */
        [FreeFunctionAttribute("MaterialScripting::SetPass", HasExplicitThis = true)]
        public bool SetPass(int pass);


        /*
            摘要:
            Enables or disables a Shader pass on a per-Material level.

            默认, 所有 shader passes 都是 enabled;

            通过 pass 的 pass tag: "LightMode" 的值 (也就是参数 passName 提供的) 找到 material
            体内对应的 shader pass; 然后可以开启/禁用它;

        // 参数:
        //   passName:
        //     Shader pass name (case insensitive).(不区分大小写)
        //
        //   enabled:
        //     Flag indicating whether this Shader pass should be enabled.
        */
        [FreeFunctionAttribute("MaterialScripting::SetShaderPassEnabled", HasExplicitThis = true)]
        public void SetShaderPassEnabled(string passName, bool enabled);


        /*
            摘要:
            Sets a named texture.

            当 material 绑定的是 standard shader 时, 要注意, 要在设置变量的同时,
            还是用 EnableKeyword() 去开启对应的 keyword, 才能彻底起效;
            更多细节查看:
            https://docs.unity3d.com/2021.1/Documentation/Manual/MaterialsAccessingViaScript.html
        
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        */
        public void SetTexture(string name, Texture value);
        public void SetTexture(int nameID, Texture value);
        public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element);
        public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element);


        /*
            摘要:
            Sets the placement offset / scale of texture propertyName.

            _ST 数据
        
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name, for example: "_MainTex".
        //
        //   value:
        //     Texture placement offset.
        */
        public void SetTextureOffset(int nameID, Vector2 value);
        public void SetTextureOffset(string name, Vector2 value);
        public void SetTextureScale(int nameID, Vector2 value);
        public void SetTextureScale(string name, Vector2 value);


        
        // 摘要:
        //     Sets a named vector value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //   name:
        //     Property name, e.g. "_WaveAndDistance".
        //
        //   value:
        //     Vector value to set.
        public void SetVector(string name, Vector4 value);
        public void SetVector(int nameID, Vector4 value);



        
        /*
            摘要:
            Sets a vector array property.

            The array length can't be changed once it has been added to the block. 
            如果下一次想要传入 更长的数据, 多出来的部分数据会被截断丢弃
            如果下一次想要传入 更短的数据, 尾部那个区域会保留原来的数据;

        // 参数:
        //   name:
        //     Property name.
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        
        //   values:
        //     Array of values to set.
        */
        public void SetVectorArray(int nameID, List<Vector4> values);
        public void SetVectorArray(string name, Vector4[] values);
        public void SetVectorArray(int nameID, Vector4[] values);
        public void SetVectorArray(string name, List<Vector4> values);
    }
}

