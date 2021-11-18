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
        Shader scripts used for all rendering.

        多数 高级渲染 都由 Material class 来控制;

        Shader class 仅用来:
        -- 检查 一个 shader 是否可在 用户硬件上运行 (本类的 isSupported property),
        -- 设置 global shader properties and keywords
        -- finding shaders by name (本类的: Find method).
    */
    [NativeHeaderAttribute("Runtime/Shaders/Shader.h")]
    [NativeHeaderAttribute("Runtime/Shaders/GpuPrograms/ShaderVariantCollection.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Misc/ResourceManager.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ShaderNameRegistry.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    public sealed class Shader : Object
    {

        /*
            摘要:
            Render pipeline currently in use.

            This value is used to filter(过滤) sub shaders based on the "RenderPipeline" tag. 
            If a sub shader uses the "RenderPipeline" tag, it is used if and only if globalRenderPipeline 
            matches the value completely. 
            A sub shader that doesn't use the "RenderPipeline" tag will match all render pipelines. 
            A matching sub shader is selected for all shaders when this value changes.
            ---
            如果一个 subshader 它定义了 tag: "RenderPipeline" = "XXX", 那么这个值 "XXX" 就会拿来和本变量做比较;
            只有在两者相同时, 这个 subshader 才会被启用; 否则, 这个 subshader 就会被忽略;

            如果一个 subshader 没有定义 tag: "RenderPipeline", 那么这个 subshader 可以被任何渲染管线使用;

            当本值发生改变时, 将为所有 shader 做这个过滤工作; (可看作是一次刷新)

            猜测:
                因为一个 渲染管线只有一个 "RenderPipeline" value, 比如: "UniversalPipeline", "HDRenderPipeline",
                所以这个变量 被实现为 static;

                但用户切换 渲染管线时, 猜测此值会发生改变, 进而触动 subshader 筛选工作的更新;
        */
        public static string globalRenderPipeline { get; set; }


        /*
        // 摘要:
        //     Shader hardware tier classification for current device.
        [Obsolete("Use Graphics.activeTier instead (UnityUpgradable) -> UnityEngine.Graphics.activeTier", false)]
        public static ShaderHardwareTier globalShaderHardwareTier { get; set; }
        */


        /*
            摘要:
            Shader LOD level for all shaders.

            "Shader LOD":
                为 subshader 排列执行的 优先级的; 
                和 物体的 LOD 不是同一个概念;
                具体可在笔记中查找: "assigning a LOD value to a SubShader"
        */
        [NativePropertyAttribute("GlobalMaximumShaderLOD")]
        public static int globalMaximumLOD { get; set; }


        /*
            摘要:
            Returns the number of shader passes on the active SubShader.
            在 active SubShader 中, pass 的数量;
        */
        public int passCount { get; }


        /*
            摘要:
            Shader LOD level for this shader.

            "Shader LOD":
                为 subshader 排列执行的 优先级的; 
                和 物体的 LOD 不是同一个概念;
                具体可在笔记中查找: "assigning a LOD value to a SubShader"
        */
        [NativePropertyAttribute("MaximumShaderLOD")]
        public int maximumLOD { get; set; }


        /*
            摘要:
            Render queue of this shader. (Read Only)

            猜测:
                直接读取 active subshader 的 tag: "Queue" 的值;
                
            这个值可被 Material.renderQueue 覆写; (可查看此 class 的翻译文件)
        */
        public int renderQueue { get; }


        /*
            摘要:
            Can this shader run on the end-users graphics card (终端用户显卡) ? (Read Only)

            当 shader 自身代码, 或者设置在 fallbacks 中的 shaders 支持, 则本变量返回 true;
            通常本变量被用于 特殊效果时;
        */
        public bool isSupported { get; }


        /*
            摘要:
            Disables/Enables a global shader keyword.

            就是: #pragma shader_feature, #pragma multi_compile 中声明的那些 keywords

            启用一个 keyword, 会让 unity 去选择符合要求的 shader variant;
            
            参数:
            keyword:
                The name of the local shader keyword to disable/enable.
        */
        [FreeFunctionAttribute("ShaderScripting::DisableKeyword")]
        public static void DisableKeyword(string keyword);

        [FreeFunctionAttribute("ShaderScripting::EnableKeyword")]
        public static void EnableKeyword(string keyword);


        /*
            摘要:
            Finds a shader with the given name.

            Shader.Find can be used to switch to another shader without having to keep a reference to the shader. 
            Note that a shader might be not included into the player build if nothing references it! 

            简而言之, 用 Find 来得到 shader 不是个好方法; 它在 editor 模式可能是有效的, 但在 build app 中
            可能会绑定失败;

            所以, 官方更推荐在 material inspector 中手动绑定一个 shader 的引用;

            为了确保一个 shader 一定被包含进一个 build app 中, 使用如下方式之一:
            1) reference it from some of the materials used in your Scene, 
            2) add it under "Always Included Shaders" list in ProjectSettings - Graphics
            3) put shader or something that references it (e.g. a Material) into a "Resources" folder.

            参数:
            name:
                "Hidden/InternalErrorShader" 这种的,
                就是每个 shader 第一行定义的 路径名
        */
        public static Shader Find(string name);


        /*
            摘要:
            Gets a global color property for all shaders previously set using SetGlobalColor.
            
            本函数只是 GetGlobalVector() 的变体, 把返回值从 vector 自动转换为 Color;
            本函数中不存在任何 sRGB-linear 颜色空间转换;

            参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public static Color GetGlobalColor(int nameID);
        public static Color GetGlobalColor(string name);


        // 摘要:
        //     Gets a global float property for all shaders previously set using SetGlobalFloat.
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public static float GetGlobalFloat(int nameID);
        public static float GetGlobalFloat(string name);


        
        /*
            摘要:
            Gets a global float array for all shaders previously set using SetGlobalFloatArray.

            针对后两个重置函数:
                如果目标 floatarray 存在,  参数values 会被 resize 为指定的尺寸;
                如果目标 floatarray 不存在, 参数values 会被 cleared;

                在这两个函数体内, 一定不会执行任何 内存分配工作;

        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        */
        public static float[] GetGlobalFloatArray(int nameID);
        public static float[] GetGlobalFloatArray(string name);
        public static void GetGlobalFloatArray(int nameID, List<float> values);
        public static void GetGlobalFloatArray(string name, List<float> values);



        /*
        //     This method is deprecated. Use GetGlobalFloat or GetGlobalInteger instead.
        public static int GetGlobalInt(int nameID);
        public static int GetGlobalInt(string name);
        */


        
        // 摘要:
        //     Gets a global integer property for all shaders previously set using SetGlobalInteger.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public static int GetGlobalInteger(int nameID);
        public static int GetGlobalInteger(string name);



        // 摘要:
        //     Gets a global matrix property for all shaders previously set using SetGlobalMatrix.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public static Matrix4x4 GetGlobalMatrix(string name);
        public static Matrix4x4 GetGlobalMatrix(int nameID);


        
        /*
            摘要:
            Gets a global matrix array for all shaders previously set using SetGlobalMatrixArray.
            
            针对后两个重置函数:
                如果目标 floatarray 存在,  参数values 会被 resize 为指定的尺寸;
                如果目标 floatarray 不存在, 参数values 会被 cleared;

                在这两个函数体内, 一定不会执行任何 内存分配工作;

        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        */
        public static Matrix4x4[] GetGlobalMatrixArray(string name);
        public static Matrix4x4[] GetGlobalMatrixArray(int nameID);
        public static void GetGlobalMatrixArray(string name, List<Matrix4x4> values);
        public static void GetGlobalMatrixArray(int nameID, List<Matrix4x4> values);


      
        // 摘要:
        //     Gets a global texture property for all shaders previously set using SetGlobalTexture.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public static Texture GetGlobalTexture(string name);
        public static Texture GetGlobalTexture(int nameID);


        
        // 摘要:
        //     Gets a global vector property for all shaders previously set using SetGlobalVector.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        public static Vector4 GetGlobalVector(int nameID);
        public static Vector4 GetGlobalVector(string name);


        /*
            摘要:
            Gets a global vector array for all shaders previously set using SetGlobalVectorArray.
            
            针对后两个重置函数:
                如果目标 floatarray 存在,  参数values 会被 resize 为指定的尺寸;
                如果目标 floatarray 不存在, 参数values 会被 cleared;

                在这两个函数体内, 一定不会执行任何 内存分配工作;

            参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        */
        public static Vector4[] GetGlobalVectorArray(int nameID);
        public static Vector4[] GetGlobalVectorArray(string name);
        public static void GetGlobalVectorArray(int nameID, List<Vector4> values);
        public static void GetGlobalVectorArray(string name, List<Vector4> values);


        /*
            摘要:
            Checks whether a global shader keyword is enabled for this material.
        
            参数:
            keyword:
                The name of the global shader keyword to check.
            
            返回结果:
                Returns true if the given global shader keyword is enabled. Otherwise, returns false.
        */
        [FreeFunctionAttribute("ShaderScripting::IsKeywordEnabled")]
        public static bool IsKeywordEnabled(string keyword);


        /*
            摘要:
            Gets unique identifier for a shader property name.
            
            十分常用; 

            unity 会为每一个 shader property (比如 "_MainTex") 分配一个全游戏唯一的 id值;

            但是这个 id 值尽在 本次 app运行期间 是恒定且唯一的, 在不同次运行中, 在不同机器上,
            同一个 name 被分配到的 id 可能是不同的;

            所以不要将这个 id 值存储到硬盘, 也不要在 多个游戏设备中传递这个 id值 
            (在别的机器上就失效了)

            参数:
            name:
                Shader property name.
            
            返回结果:
                Unique integer for the name.
                就是很多函数的参数: nameId
        */
        [FreeFunctionAttribute(Name = "ShaderScripting::PropertyToID", IsThreadSafe = true)]
        public static int PropertyToID(string name);


        /*
            摘要:
            Sets a global buffer property for all shaders.
            
            Global properties are used if a shader needs them but the material does not have them defined 
            (for example, if the shader does not expose them in Properties block).

        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The buffer to set.
        */
        public static void SetGlobalBuffer(string name, GraphicsBuffer value);
        public static void SetGlobalBuffer(int nameID, GraphicsBuffer value);
        public static void SetGlobalBuffer(string name, ComputeBuffer value);
        public static void SetGlobalBuffer(int nameID, ComputeBuffer value);


        /*
            摘要:
            Sets a global color property for all shaders.

            如果你有一系列 自定义 shaders, 它们都使用同一个 全局颜色;
            此时, 你就可以定义一个 全局颜色 property, 而不用在每一个 shader 的 material 中去一一设置那个 颜色值

            注意:
            和 Material.SetColor() 不同, 本函数不执行 颜色空间转换, 他仅仅是 SetGlobalVector() 的小变体

            参数:
            nameID:
                The name ID of the property retrieved by Shader.PropertyToID.
            name:
                The name of the property.
            
            value:
        */
        public static void SetGlobalColor(string name, Color value);
        public static void SetGlobalColor(int nameID, Color value);


        /*
            摘要:
            Sets a ComputeBuffer or GraphicsBuffer as a "named constant buffer" for all shader types.


            
            参数:
            nameID:
                The name ID of the constant buffer retrieved by Shader.PropertyToID.
            name:
                The name of the constant buffer to override.
            
            value:
                The buffer to override the constant buffer values with, or null to remove binding.
                用这个 buffer 的值去覆盖 constant buffer 的值,
                若此参数为 null, 则执行解除绑定的操作
            
            offset:
                Offset in bytes from the beginning of the buffer to bind. Must be a multiple
                of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
            
            size:
                The number of bytes to bind.
        */
        public static void SetGlobalConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size);
        public static void SetGlobalConstantBuffer(string name, GraphicsBuffer value, int offset, int size);
        public static void SetGlobalConstantBuffer(int nameID, ComputeBuffer value, int offset, int size);
        public static void SetGlobalConstantBuffer(string name, ComputeBuffer value, int offset, int size);


        //
        // 摘要:
        //     Sets a global float property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        public static void SetGlobalFloat(string name, float value);
        public static void SetGlobalFloat(int nameID, float value);


        
        //
        // 摘要:
        //     Sets a global float array property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   values:
        public static void SetGlobalFloatArray(int nameID, List<float> values);
        public static void SetGlobalFloatArray(int nameID, float[] values);
        public static void SetGlobalFloatArray(string name, List<float> values);
        public static void SetGlobalFloatArray(string name, float[] values);


        /*
        //     This method is deprecated. Use SetGlobalFloat or SetGlobalInteger instead.
        public static void SetGlobalInt(int nameID, int value);
        public static void SetGlobalInt(string name, int value);
        */


        //
        // 摘要:
        //     Sets a global integer property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        public static void SetGlobalInteger(int nameID, int value);
        public static void SetGlobalInteger(string name, int value);


        //
        // 摘要:
        //     Sets a global matrix property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        public static void SetGlobalMatrix(string name, Matrix4x4 value);
        public static void SetGlobalMatrix(int nameID, Matrix4x4 value);


        //
        // 摘要:
        //     Sets a global matrix array property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   values:
        public static void SetGlobalMatrixArray(int nameID, Matrix4x4[] values);
        public static void SetGlobalMatrixArray(string name, Matrix4x4[] values);
        public static void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values);
        public static void SetGlobalMatrixArray(string name, List<Matrix4x4> values);


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("SetGlobalTexGenMode is not supported anymore. Use programmable shaders to achieve the same effect.", true)]
        public static void SetGlobalTexGenMode(string propertyName, TexGenMode mode);
        */


        //
        // 摘要:
        //     Sets a global texture property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        //     The texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public static void SetGlobalTexture(string name, Texture value);
        public static void SetGlobalTexture(int nameID, Texture value);
        public static void SetGlobalTexture(int nameID, RenderTexture value, RenderTextureSubElement element);
        public static void SetGlobalTexture(string name, RenderTexture value, RenderTextureSubElement element);


        /*
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("SetGlobalTextureMatrixName is not supported anymore. Use programmable shaders to achieve the same effect.", true)]
        public static void SetGlobalTextureMatrixName(string propertyName, string matrixName);
        */


        //
        // 摘要:
        //     Sets a global vector property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   value:
        public static void SetGlobalVector(string name, Vector4 value);
        public static void SetGlobalVector(int nameID, Vector4 value);


        //
        // 摘要:
        //     Sets a global vector array property for all shaders.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        //
        //   values:
        public static void SetGlobalVectorArray(int nameID, Vector4[] values);
        public static void SetGlobalVectorArray(string name, List<Vector4> values);
        public static void SetGlobalVectorArray(string name, Vector4[] values);
        public static void SetGlobalVectorArray(int nameID, List<Vector4> values);


        //
        // 摘要:
        //     Prewarms all shader variants of all Shaders currently in memory.
        [FreeFunctionAttribute]
        public static void WarmupAllShaders();
        //
        // 摘要:
        //     Search for the pass tag specified by tagName on the shader's active SubShader
        //     and returns the value of the tag.
        //
        // 参数:
        //   passIndex:
        //     The index of the pass.
        //
        //   tagName:
        //     The name of the pass tag.
        public ShaderTagId FindPassTagValue(int passIndex, ShaderTagId tagName);
        //
        // 摘要:
        //     Finds the index of a shader property by its name.
        //
        // 参数:
        //   propertyName:
        //     The name of the shader property.
        public int FindPropertyIndex(string propertyName);
        public bool FindTextureStack(int propertyIndex, out string stackName, out int layerIndex);
        //
        // 摘要:
        //     Returns the dependency shader.
        //
        // 参数:
        //   name:
        //     The name of the dependency to query.
        public Shader GetDependency(string name);
        //
        // 摘要:
        //     Returns an array of strings containing attributes of the shader property at the
        //     specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public string[] GetPropertyAttributes(int propertyIndex);
        //
        // 摘要:
        //     Returns the number of properties in this Shader.
        public int GetPropertyCount();
        //
        // 摘要:
        //     Returns the default float value of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public float GetPropertyDefaultFloatValue(int propertyIndex);
        //
        // 摘要:
        //     Returns the default Vector4 value of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public Vector4 GetPropertyDefaultVectorValue(int propertyIndex);
        //
        // 摘要:
        //     Returns the description string of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public string GetPropertyDescription(int propertyIndex);
        //
        // 摘要:
        //     Returns the ShaderPropertyFlags of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public ShaderPropertyFlags GetPropertyFlags(int propertyIndex);
        //
        // 摘要:
        //     Returns the name of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public string GetPropertyName(int propertyIndex);
        //
        // 摘要:
        //     Returns the nameId of the shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public int GetPropertyNameId(int propertyIndex);
        //
        // 摘要:
        //     Returns the min and max limits for a <a href="Rendering.ShaderPropertyType.Range.html">Range</a>
        //     property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public Vector2 GetPropertyRangeLimits(int propertyIndex);
        //
        // 摘要:
        //     Returns the default Texture name of a <a href="Rendering.ShaderPropertyType.Texture.html">Texture</a>
        //     shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public string GetPropertyTextureDefaultName(int propertyIndex);
        //
        // 摘要:
        //     Returns the TextureDimension of a <a href="Rendering.ShaderPropertyType.Texture.html">Texture</a>
        //     shader property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public TextureDimension GetPropertyTextureDimension(int propertyIndex);
        //
        // 摘要:
        //     Returns the ShaderPropertyType of the property at the specified index.
        //
        // 参数:
        //   propertyIndex:
        //     The index of the shader property.
        public ShaderPropertyType GetPropertyType(int propertyIndex);
    }
}

