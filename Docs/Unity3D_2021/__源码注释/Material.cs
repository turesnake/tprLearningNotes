#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Rendering;

namespace UnityEngine
{
    //
    // 摘要:
    //     The material class.
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Shaders/Material.h")]
    public class Material : Object
    {
        //
        // 摘要:
        //     Create a temporary Material.
        //
        // 参数:
        //   shader:
        //     Create a material with a given Shader.
        //
        //   source:
        //     Create a material by copying all properties from another material.
        public Material(Shader shader);
        //
        // 摘要:
        //     Create a temporary Material.
        //
        // 参数:
        //   shader:
        //     Create a material with a given Shader.
        //
        //   source:
        //     Create a material by copying all properties from another material.
        [RequiredByNativeCodeAttribute]
        public Material(Material source);
        //
        // 参数:
        //   contents:
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", false)]
        public Material(string contents);

        //
        // 摘要:
        //     An array containing the names of the local shader keywords that are currently
        //     enabled for this material.
        public string[] shaderKeywords { get; set; }
        //
        // 摘要:
        //     Gets and sets whether GPU instancing is enabled for this material.
        [NativePropertyAttribute("EnableInstancingVariants")]
        public bool enableInstancing { get; set; }
        //
        // 摘要:
        //     Gets and sets whether the Double Sided Global Illumination setting is enabled
        //     for this material.
        public bool doubleSidedGI { get; set; }
        //
        // 摘要:
        //     Defines how the material should interact with lightmaps and lightprobes.
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


        //
        // 摘要:
        //     The scale of the main texture.
        public Vector2 mainTextureScale { get; set; }
        //
        // 摘要:
        //     The offset of the main texture.
        public Vector2 mainTextureOffset { get; set; }
        //
        // 摘要:
        //     The main texture.
        public Texture mainTexture { get; set; }
        //
        // 摘要:
        //     The main color of the Material.
        public Color color { get; set; }
        //
        // 摘要:
        //     The shader used by the material.
        public Shader shader { get; set; }
        //
        // 摘要:
        //     How many passes are in this material (Read Only).
        public int passCount { get; }

        [Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.", false)]
        public static Material Create(string scriptContents);
        //
        // 摘要:
        //     Computes a CRC hash value from the content of the material.
        public int ComputeCRC();
        //
        // 摘要:
        //     Copy properties from other material into this material.
        //
        // 参数:
        //   mat:
        [FreeFunctionAttribute("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = true)]
        public void CopyPropertiesFromMaterial(Material mat);
        //
        // 摘要:
        //     Disables a local shader keyword for this material.
        //
        // 参数:
        //   keyword:
        //     The name of the local shader keyword to disable.
        public void DisableKeyword(string keyword);
        //
        // 摘要:
        //     Enables a local shader keyword for this material.
        //
        // 参数:
        //   keyword:
        //     The name of the local shader keyword to enable.
        public void EnableKeyword(string keyword);
        //
        // 摘要:
        //     Returns the index of the pass passName.
        //
        // 参数:
        //   passName:
        public int FindPass(string passName);
        //
        // 摘要:
        //     Get a named color value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Color GetColor(int nameID);
        //
        // 摘要:
        //     Get a named color value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Color GetColor(string name);
        //
        // 摘要:
        //     Get a named color array.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Color[] GetColorArray(string name);
        public void GetColorArray(int nameID, List<Color> values);
        public void GetColorArray(string name, List<Color> values);
        //
        // 摘要:
        //     Get a named color array.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Color[] GetColorArray(int nameID);
        //
        // 摘要:
        //     Get a named float value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public float GetFloat(string name);
        //
        // 摘要:
        //     Get a named float value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public float GetFloat(int nameID);
        public void GetFloatArray(int nameID, List<float> values);
        public void GetFloatArray(string name, List<float> values);
        //
        // 摘要:
        //     Get a named float array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public float[] GetFloatArray(int nameID);
        //
        // 摘要:
        //     Get a named float array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public float[] GetFloatArray(string name);
        //
        // 摘要:
        //     This method is deprecated. Use GetFloat or GetInteger instead.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public int GetInt(string name);
        //
        // 摘要:
        //     This method is deprecated. Use GetFloat or GetInteger instead.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public int GetInt(int nameID);
        //
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
        //
        // 摘要:
        //     Get a named integer value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public int GetInteger(int nameID);
        //
        // 摘要:
        //     Get a named matrix value from the shader.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Matrix4x4 GetMatrix(string name);
        //
        // 摘要:
        //     Get a named matrix value from the shader.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Matrix4x4 GetMatrix(int nameID);
        public void GetMatrixArray(int nameID, List<Matrix4x4> values);
        public void GetMatrixArray(string name, List<Matrix4x4> values);
        //
        // 摘要:
        //     Get a named matrix array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public Matrix4x4[] GetMatrixArray(int nameID);
        //
        // 摘要:
        //     Get a named matrix array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public Matrix4x4[] GetMatrixArray(string name);
        //
        // 摘要:
        //     Returns the name of the shader pass at index pass.
        //
        // 参数:
        //   pass:
        public string GetPassName(int pass);
        //
        // 摘要:
        //     Checks whether a given Shader pass is enabled on this Material.
        //
        // 参数:
        //   passName:
        //     Shader pass name (case insensitive).
        //
        // 返回结果:
        //     True if the Shader pass is enabled.
        [FreeFunctionAttribute("MaterialScripting::GetShaderPassEnabled", HasExplicitThis = true)]
        public bool GetShaderPassEnabled(string passName);
        //
        // 摘要:
        //     Get the value of material's shader tag.
        //
        // 参数:
        //   tag:
        //
        //   searchFallbacks:
        //
        //   defaultValue:
        public string GetTag(string tag, bool searchFallbacks);
        //
        // 摘要:
        //     Get the value of material's shader tag.
        //
        // 参数:
        //   tag:
        //
        //   searchFallbacks:
        //
        //   defaultValue:
        public string GetTag(string tag, bool searchFallbacks, string defaultValue);
        //
        // 摘要:
        //     Get a named texture.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Texture GetTexture(int nameID);
        //
        // 摘要:
        //     Get a named texture.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Texture GetTexture(string name);
        //
        // 摘要:
        //     Gets the placement offset of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector2 GetTextureOffset(string name);
        //
        // 摘要:
        //     Gets the placement offset of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector2 GetTextureOffset(int nameID);
        //
        // 摘要:
        //     Return the name IDs of all texture properties exposed on this material.
        //
        // 参数:
        //   outNames:
        //     IDs of all texture properties exposed on this material.
        //
        // 返回结果:
        //     IDs of all texture properties exposed on this material.
        [FreeFunctionAttribute("MaterialScripting::GetTexturePropertyNameIDs", HasExplicitThis = true)]
        public int[] GetTexturePropertyNameIDs();
        public void GetTexturePropertyNameIDs(List<int> outNames);
        //
        // 摘要:
        //     Returns the names of all texture properties exposed on this material.
        //
        // 参数:
        //   outNames:
        //     Names of all texture properties exposed on this material.
        //
        // 返回结果:
        //     Names of all texture properties exposed on this material.
        [FreeFunctionAttribute("MaterialScripting::GetTexturePropertyNames", HasExplicitThis = true)]
        public string[] GetTexturePropertyNames();
        public void GetTexturePropertyNames(List<string> outNames);
        //
        // 摘要:
        //     Gets the placement scale of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector2 GetTextureScale(int nameID);
        //
        // 摘要:
        //     Gets the placement scale of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector2 GetTextureScale(string name);
        //
        // 摘要:
        //     Get a named vector value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector4 GetVector(string name);
        //
        // 摘要:
        //     Get a named vector value.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector4 GetVector(int nameID);
        //
        // 摘要:
        //     Get a named vector array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public Vector4[] GetVectorArray(string name);
        //
        // 摘要:
        //     Get a named vector array.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        public Vector4[] GetVectorArray(int nameID);
        public void GetVectorArray(string name, List<Vector4> values);
        public void GetVectorArray(int nameID, List<Vector4> values);
        //
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a ComputeBuffer property
        //     with the given name.
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
        public bool HasBuffer(int nameID);
        //
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a ComputeBuffer property
        //     with the given name.
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
        public bool HasBuffer(string name);
        //
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Color property with
        //     the given name.
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
        public bool HasColor(int nameID);
        //
        // 摘要:
        //     Checks if the ShaderLab file assigned to the Material has a Color property with
        //     the given name.
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
        public bool HasColor(string name);
        //
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
        //
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
        public bool HasConstantBuffer(int nameID);
        //
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
        //
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
        public bool HasFloat(string name);
        //
        // 摘要:
        //     This method is deprecated. Use HasFloat or HasInteger instead.
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
        public bool HasInt(int nameID);
        //
        // 摘要:
        //     This method is deprecated. Use HasFloat or HasInteger instead.
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
        public bool HasInt(string name);
        //
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
        //
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
        public bool HasInteger(string name);
        //
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
        //
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
        public bool HasMatrix(int nameID);
        //
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
        //
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
        [NativeNameAttribute("HasPropertyFromScript")]
        public bool HasProperty(int nameID);
        //
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
        //
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
        public bool HasTexture(string name);
        //
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
        //
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
        public bool HasVector(string name);
        //
        // 摘要:
        //     Checks whether a local shader keyword is enabled for this material.
        //
        // 参数:
        //   keyword:
        //     The name of the local shader keyword to check.
        //
        // 返回结果:
        //     Returns true if the given local shader keyword is enabled for this material.
        //     Otherwise, returns false.
        public bool IsKeywordEnabled(string keyword);
        //
        // 摘要:
        //     Interpolate properties between two materials.
        //
        // 参数:
        //   start:
        //
        //   end:
        //
        //   t:
        [FreeFunctionAttribute("MaterialScripting::Lerp", HasExplicitThis = true)]
        [NativeThrowsAttribute]
        public void Lerp(Material start, Material end, float t);
        //
        // 摘要:
        //     Sets a named buffer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer value to set.
        public void SetBuffer(int nameID, ComputeBuffer value);
        //
        // 摘要:
        //     Sets a named buffer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer value to set.
        public void SetBuffer(string name, ComputeBuffer value);
        //
        // 摘要:
        //     Sets a named buffer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer value to set.
        public void SetBuffer(int nameID, GraphicsBuffer value);
        //
        // 摘要:
        //     Sets a named buffer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer value to set.
        public void SetBuffer(string name, GraphicsBuffer value);
        //
        // 摘要:
        //     Sets a named color value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_Color".
        //
        //   value:
        //     Color value to set.
        public void SetColor(int nameID, Color value);
        //
        // 摘要:
        //     Sets a named color value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_Color".
        //
        //   value:
        //     Color value to set.
        public void SetColor(string name, Color value);
        //
        // 摘要:
        //     Sets a color array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Array of values to set.
        public void SetColorArray(string name, Color[] values);
        public void SetColorArray(string name, List<Color> values);
        public void SetColorArray(int nameID, List<Color> values);
        //
        // 摘要:
        //     Sets a color array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   values:
        //     Array of values to set.
        public void SetColorArray(int nameID, Color[] values);


        /*
            摘要:
            Sets a ComputeBuffer or GraphicsBuffer as a "named constant buffer" for the material.


            可使用此函数来 覆写: 居住在 "给定名字的 constant buffer" 中的所有 shader 参数;

You can use this method to override all the shader parameters that reside in a constant buffer with a given name. 


The parameters are overridden with the contents of the given buffer. To use this method, the following must be true: The ComputeBuffer or GraphicsBuffer must have been created with a corresponding ComputeBufferType.Constant or GraphicsBuffer.Target.Constant flag. The data layout of the constant buffer must match exactly with the data provided in the buffer. All the different shader variants for this Material must se the same constant buffer layout for the given constant buffer.

        
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
            
            size:
                The number of bytes to bind.
                要绑定的内容的 字节数
        */
        public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size);
        public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size);


        //
        // 摘要:
        //     Sets a named float value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Float value to set.
        //
        //   name:
        //     Property name, e.g. "_Glossiness".
        public void SetFloat(int nameID, float value);
        //
        // 摘要:
        //     Sets a named float value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Float value to set.
        //
        //   name:
        //     Property name, e.g. "_Glossiness".
        public void SetFloat(string name, float value);
        //
        // 摘要:
        //     Sets a float array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Array of values to set.
        public void SetFloatArray(int nameID, float[] values);
        //
        // 摘要:
        //     Sets a float array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   nameID:
        //     Property name ID. Use Shader.PropertyToID to get this ID.
        //
        //   values:
        //     Array of values to set.
        public void SetFloatArray(string name, float[] values);
        public void SetFloatArray(int nameID, List<float> values);
        public void SetFloatArray(string name, List<float> values);
        //
        // 摘要:
        //     This method is deprecated. Use SetFloat or SetInteger instead.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Integer value to set.
        //
        //   name:
        //     Property name, e.g. "_SrcBlend".
        public void SetInt(int nameID, int value);
        //
        // 摘要:
        //     This method is deprecated. Use SetFloat or SetInteger instead.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Integer value to set.
        //
        //   name:
        //     Property name, e.g. "_SrcBlend".
        public void SetInt(string name, int value);
        //
        // 摘要:
        //     Sets a named integer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Integer value to set.
        //
        //   name:
        //     Property name, e.g. "_SrcBlend".
        public void SetInteger(string name, int value);
        //
        // 摘要:
        //     Sets a named integer value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   value:
        //     Integer value to set.
        //
        //   name:
        //     Property name, e.g. "_SrcBlend".
        public void SetInteger(int nameID, int value);
        //
        // 摘要:
        //     Sets a named matrix for the shader.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_CubemapRotation".
        //
        //   value:
        //     Matrix value to set.
        public void SetMatrix(string name, Matrix4x4 value);
        //
        // 摘要:
        //     Sets a named matrix for the shader.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_CubemapRotation".
        //
        //   value:
        //     Matrix value to set.
        public void SetMatrix(int nameID, Matrix4x4 value);
        //
        // 摘要:
        //     Sets a matrix array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   values:
        //     Array of values to set.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        public void SetMatrixArray(string name, Matrix4x4[] values);
        public void SetMatrixArray(int nameID, List<Matrix4x4> values);
        public void SetMatrixArray(string name, List<Matrix4x4> values);
        //
        // 摘要:
        //     Sets a matrix array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   values:
        //     Array of values to set.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        public void SetMatrixArray(int nameID, Matrix4x4[] values);
        //
        // 摘要:
        //     Sets an override tag/value on the material.
        //
        // 参数:
        //   tag:
        //     Name of the tag to set.
        //
        //   val:
        //     Name of the value to set. Empty string to clear the override flag.
        public void SetOverrideTag(string tag, string val);
        //
        // 摘要:
        //     Activate the given pass for rendering.
        //
        // 参数:
        //   pass:
        //     Shader pass number to setup.
        //
        // 返回结果:
        //     If false is returned, no rendering should be done.
        [FreeFunctionAttribute("MaterialScripting::SetPass", HasExplicitThis = true)]
        public bool SetPass(int pass);
        //
        // 摘要:
        //     Enables or disables a Shader pass on a per-Material level.
        //
        // 参数:
        //   passName:
        //     Shader pass name (case insensitive).
        //
        //   enabled:
        //     Flag indicating whether this Shader pass should be enabled.
        [FreeFunctionAttribute("MaterialScripting::SetShaderPassEnabled", HasExplicitThis = true)]
        public void SetShaderPassEnabled(string passName, bool enabled);
        //
        // 摘要:
        //     Sets a named texture.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(string name, Texture value);
        //
        // 摘要:
        //     Sets a named texture.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int nameID, Texture value);
        //
        // 摘要:
        //     Sets a named texture.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Sets a named texture.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Sets the placement offset of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, for example: "_MainTex".
        //
        //   value:
        //     Texture placement offset.
        public void SetTextureOffset(int nameID, Vector2 value);
        //
        // 摘要:
        //     Sets the placement offset of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, for example: "_MainTex".
        //
        //   value:
        //     Texture placement offset.
        public void SetTextureOffset(string name, Vector2 value);
        //
        // 摘要:
        //     Sets the placement scale of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture placement scale.
        public void SetTextureScale(int nameID, Vector2 value);
        //
        // 摘要:
        //     Sets the placement scale of texture propertyName.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_MainTex".
        //
        //   value:
        //     Texture placement scale.
        public void SetTextureScale(string name, Vector2 value);
        //
        // 摘要:
        //     Sets a named vector value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_WaveAndDistance".
        //
        //   value:
        //     Vector value to set.
        public void SetVector(string name, Vector4 value);
        //
        // 摘要:
        //     Sets a named vector value.
        //
        // 参数:
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        //
        //   name:
        //     Property name, e.g. "_WaveAndDistance".
        //
        //   value:
        //     Vector value to set.
        public void SetVector(int nameID, Vector4 value);
        public void SetVectorArray(int nameID, List<Vector4> values);
        //
        // 摘要:
        //     Sets a vector array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   values:
        //     Array of values to set.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        public void SetVectorArray(string name, Vector4[] values);
        //
        // 摘要:
        //     Sets a vector array property.
        //
        // 参数:
        //   name:
        //     Property name.
        //
        //   values:
        //     Array of values to set.
        //
        //   nameID:
        //     Property name ID, use Shader.PropertyToID to get it.
        public void SetVectorArray(int nameID, Vector4[] values);
        public void SetVectorArray(string name, List<Vector4> values);
    }
}

