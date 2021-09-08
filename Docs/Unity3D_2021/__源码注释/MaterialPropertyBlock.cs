#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine
{
    /* 摘要:
        A block of material values to apply.

        此 class 被 Graphics.DrawMesh  Renderer.SetPropertyBlock 使用; 
        如果你希望绘制数个物体, 它们使用相同的 material, 但每个物体都希望拥有自己的 properties 时
        可用本 class. 

        unity terrain engine 使用本类来绘制 树木, 每棵树都使用相同的 material, 但各自持有独立的 properties. 

        被传入  Graphics.DrawMesh or Renderer.SetPropertyBlock 的本 class 实例 将被执行值复制,
        所以, 推荐的用法是, 创建一个  MaterialPropertyBlock 实例(比如是 static 的), 然后反复使用它. 

    */
    [NativeHeaderAttribute("Runtime/Shaders/ShaderPropertySheet.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Math/SphericalHarmonicsL2.h")]
    public sealed class MaterialPropertyBlock
    {
        public MaterialPropertyBlock();

        ~MaterialPropertyBlock();

        //
        // 摘要:
        //     Is the material property block empty? (Read Only)
        public bool isEmpty { get; }

        [Obsolete("Use SetColor instead (UnityUpgradable) -> SetColor(*)", false)]
        public void AddColor(int nameID, Color value);
        [Obsolete("Use SetColor instead (UnityUpgradable) -> SetColor(*)", false)]
        public void AddColor(string name, Color value);
        [Obsolete("Use SetFloat instead (UnityUpgradable) -> SetFloat(*)", false)]
        public void AddFloat(string name, float value);
        [Obsolete("Use SetFloat instead (UnityUpgradable) -> SetFloat(*)", false)]
        public void AddFloat(int nameID, float value);
        [Obsolete("Use SetMatrix instead (UnityUpgradable) -> SetMatrix(*)", false)]
        public void AddMatrix(string name, Matrix4x4 value);
        [Obsolete("Use SetMatrix instead (UnityUpgradable) -> SetMatrix(*)", false)]
        public void AddMatrix(int nameID, Matrix4x4 value);
        [Obsolete("Use SetTexture instead (UnityUpgradable) -> SetTexture(*)", false)]
        public void AddTexture(string name, Texture value);
        [Obsolete("Use SetTexture instead (UnityUpgradable) -> SetTexture(*)", false)]
        public void AddTexture(int nameID, Texture value);
        [Obsolete("Use SetVector instead (UnityUpgradable) -> SetVector(*)", false)]
        public void AddVector(int nameID, Vector4 value);
        [Obsolete("Use SetVector instead (UnityUpgradable) -> SetVector(*)", false)]
        public void AddVector(string name, Vector4 value);
        //
        // 摘要:
        //     Clear material property values.
        public void Clear();
        public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes, int sourceStart, int destStart, int count);
        //
        // 摘要:
        //     This function copies the entire source array into a Vector4 property array named
        //     unity_ProbesOcclusion for use with instanced rendering.
        //
        // 参数:
        //   occlusionProbes:
        //     The array of probe occlusion values to copy from.
        public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes);
        public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes);
        //
        // 摘要:
        //     This function copies the source array into a Vector4 property array named unity_ProbesOcclusion
        //     with the specified source and destination range for use with instanced rendering.
        //
        // 参数:
        //   occlusionProbes:
        //     The array of probe occlusion values to copy from.
        //
        //   sourceStart:
        //     The index of the first element in the source array to copy from.
        //
        //   destStart:
        //     The index of the first element in the destination MaterialPropertyBlock array
        //     to copy to.
        //
        //   count:
        //     The number of elements to copy.
        public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes, int sourceStart, int destStart, int count);
        //
        // 摘要:
        //     This function converts and copies the source array into 7 Vector4 property arrays
        //     named unity_SHAr, unity_SHAg, unity_SHAb, unity_SHBr, unity_SHBg, unity_SHBb
        //     and unity_SHC with the specified source and destination range for use with instanced
        //     rendering.
        //
        // 参数:
        //   lightProbes:
        //     The array of SH values to copy from.
        //
        //   sourceStart:
        //     The index of the first element in the source array to copy from.
        //
        //   destStart:
        //     The index of the first element in the destination MaterialPropertyBlock array
        //     to copy to.
        //
        //   count:
        //     The number of elements to copy.
        public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes, int sourceStart, int destStart, int count);
        public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes, int sourceStart, int destStart, int count);
        //
        // 摘要:
        //     This function converts and copies the entire source array into 7 Vector4 property
        //     arrays named unity_SHAr, unity_SHAg, unity_SHAb, unity_SHBr, unity_SHBg, unity_SHBb
        //     and unity_SHC for use with instanced rendering.
        //
        // 参数:
        //   lightProbes:
        //     The array of SH values to copy from.
        public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes);
        public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes);
        //
        // 摘要:
        //     Get a color from the property block.
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
        //     Get a color from the property block.
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
        //     Get a float from the property block.
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
        //     Get a float from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public float GetFloat(int nameID);
        //
        // 摘要:
        //     Get a float array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public float[] GetFloatArray(string name);
        //
        // 摘要:
        //     Get a float array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public float[] GetFloatArray(int nameID);
        public void GetFloatArray(string name, List<float> values);
        public void GetFloatArray(int nameID, List<float> values);
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
        //     Get an integer from the property block.
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
        //     Get an integer from the property block.
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
        //     Get a matrix from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Matrix4x4 GetMatrix(int nameID);
        //
        // 摘要:
        //     Get a matrix from the property block.
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
        //     Get a matrix array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Matrix4x4[] GetMatrixArray(int nameID);
        public void GetMatrixArray(string name, List<Matrix4x4> values);
        public void GetMatrixArray(int nameID, List<Matrix4x4> values);
        //
        // 摘要:
        //     Get a matrix array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Matrix4x4[] GetMatrixArray(string name);
        //
        // 摘要:
        //     Get a texture from the property block.
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
        //     Get a texture from the property block.
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
        //     Get a vector from the property block.
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
        //     Get a vector from the property block.
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
        //     Get a vector array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector4[] GetVectorArray(int nameID);
        public void GetVectorArray(string name, List<Vector4> values);
        public void GetVectorArray(int nameID, List<Vector4> values);
        //
        // 摘要:
        //     Get a vector array from the property block.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The name of the property.
        public Vector4[] GetVectorArray(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ComputeBuffer property with the given
        //     name or name ID. To set the property, use SetBuffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasBuffer(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ComputeBuffer property with the given
        //     name or name ID. To set the property, use SetBuffer.
        //
        // 参数:
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        //   name:
        //     The name of the property.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasBuffer(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Color property with the given name or
        //     name ID. To set the property, use SetColor.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasColor(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Color property with the given name or
        //     name ID. To set the property, use SetColor.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasColor(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ConstantBuffer property with the given
        //     name or name ID. To set the property, use SetConstantBuffer.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasConstantBuffer(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ConstantBuffer property with the given
        //     name or name ID. To set the property, use SetConstantBuffer.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasConstantBuffer(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Float property with the given name or
        //     name ID. To set the property, use SetFloat.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasFloat(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Float property with the given name or
        //     name ID. To set the property, use SetFloat.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasFloat(string name);
        //
        // 摘要:
        //     This method is deprecated. Use HasFloat or HasInteger instead.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasInt(string name);
        //
        // 摘要:
        //     This method is deprecated. Use HasFloat or HasInteger instead.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasInt(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Integer property with the given name
        //     or name ID. To set the property, use SetInteger.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasInteger(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Integer property with the given name
        //     or name ID. To set the property, use SetInteger.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasInteger(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Matrix property with the given name or
        //     name ID. This also works with the Matrix Array property. To set the property,
        //     use SetMatrix.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasMatrix(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Matrix property with the given name or
        //     name ID. This also works with the Matrix Array property. To set the property,
        //     use SetMatrix.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasMatrix(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the property with the given name or name
        //     ID. To set the property, use one of the Set methods for MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasProperty(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the property with the given name or name
        //     ID. To set the property, use one of the Set methods for MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasProperty(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Texture property with the given name
        //     or name ID. To set the property, use SetTexture.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasTexture(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Texture property with the given name
        //     or name ID. To set the property, use SetTexture.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasTexture(int nameID);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Vector property with the given name or
        //     name ID. This also works with the Vector Array property. To set the property,
        //     use SetVector.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasVector(string name);
        //
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Vector property with the given name or
        //     name ID. This also works with the Vector Array property. To set the property,
        //     use SetVector.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property. Use Shader.PropertyToID to get this ID.
        //
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasVector(int nameID);
        //
        // 摘要:
        //     Set a buffer property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer to set.
        public void SetBuffer(string name, ComputeBuffer value);
        //
        // 摘要:
        //     Set a buffer property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer to set.
        public void SetBuffer(int nameID, ComputeBuffer value);
        //
        // 摘要:
        //     Set a buffer property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer to set.
        public void SetBuffer(string name, GraphicsBuffer value);
        //
        // 摘要:
        //     Set a buffer property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The ComputeBuffer or GraphicsBuffer to set.
        public void SetBuffer(int nameID, GraphicsBuffer value);
        //
        // 摘要:
        //     Set a color property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Color value to set.
        public void SetColor(int nameID, Color value);
        //
        // 摘要:
        //     Set a color property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Color value to set.
        public void SetColor(string name, Color value);
        //
        // 摘要:
        //     Sets a ComputeBuffer or GraphicsBuffer as a named constant buffer for the MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the constant buffer to override.
        //
        //   value:
        //     The buffer to override the constant buffer values with.
        //
        //   offset:
        //     Offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        //
        //   nameID:
        //     The shader property ID of the constant buffer to override.
        public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or GraphicsBuffer as a named constant buffer for the MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the constant buffer to override.
        //
        //   value:
        //     The buffer to override the constant buffer values with.
        //
        //   offset:
        //     Offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        //
        //   nameID:
        //     The shader property ID of the constant buffer to override.
        public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or GraphicsBuffer as a named constant buffer for the MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the constant buffer to override.
        //
        //   value:
        //     The buffer to override the constant buffer values with.
        //
        //   offset:
        //     Offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        //
        //   nameID:
        //     The shader property ID of the constant buffer to override.
        public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size);
        //
        // 摘要:
        //     Sets a ComputeBuffer or GraphicsBuffer as a named constant buffer for the MaterialPropertyBlock.
        //
        // 参数:
        //   name:
        //     The name of the constant buffer to override.
        //
        //   value:
        //     The buffer to override the constant buffer values with.
        //
        //   offset:
        //     Offset in bytes from the beginning of the buffer to bind. Must be a multiple
        //     of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
        //
        //   size:
        //     The number of bytes to bind.
        //
        //   nameID:
        //     The shader property ID of the constant buffer to override.
        public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size);
        //
        // 摘要:
        //     Set a float property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The float value to set.
        public void SetFloat(string name, float value);
        //
        // 摘要:
        //     Set a float property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The float value to set.
        public void SetFloat(int nameID, float value);
        public void SetFloatArray(int nameID, List<float> values);
        public void SetFloatArray(string name, List<float> values);
        //
        // 摘要:
        //     Set a float array property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   values:
        //     The array to set.
        public void SetFloatArray(string name, float[] values);
        //
        // 摘要:
        //     Set a float array property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   values:
        //     The array to set.
        public void SetFloatArray(int nameID, float[] values);
        //
        // 摘要:
        //     This method is deprecated. Use SetFloat or SetInteger instead.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The int value to set.
        public void SetInt(string name, int value);
        //
        // 摘要:
        //     This method is deprecated. Use SetFloat or SetInteger instead.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The int value to set.
        public void SetInt(int nameID, int value);
        //
        // 摘要:
        //     Adds a property to the block. If an integer property with the given name already
        //     exists, the old value is replaced.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The integer value to set.
        public void SetInteger(string name, int value);
        //
        // 摘要:
        //     Adds a property to the block. If an integer property with the given name already
        //     exists, the old value is replaced.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The integer value to set.
        public void SetInteger(int nameID, int value);
        //
        // 摘要:
        //     Set a matrix property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The matrix value to set.
        public void SetMatrix(int nameID, Matrix4x4 value);
        //
        // 摘要:
        //     Set a matrix property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The matrix value to set.
        public void SetMatrix(string name, Matrix4x4 value);
        //
        // 摘要:
        //     Set a matrix array property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   values:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   nameID:
        //     The array to set.
        public void SetMatrixArray(int nameID, Matrix4x4[] values);
        //
        // 摘要:
        //     Set a matrix array property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   values:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   nameID:
        //     The array to set.
        public void SetMatrixArray(string name, Matrix4x4[] values);
        public void SetMatrixArray(int nameID, List<Matrix4x4> values);
        public void SetMatrixArray(string name, List<Matrix4x4> values);
        //
        // 摘要:
        //     Set a texture property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(string name, Texture value);
        //
        // 摘要:
        //     Set a texture property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int nameID, Texture value);
        //
        // 摘要:
        //     Set a texture property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Set a texture property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element);
        //
        // 摘要:
        //     Set a vector property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Vector4 value to set.
        public void SetVector(int nameID, Vector4 value);
        //
        // 摘要:
        //     Set a vector property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Vector4 value to set.
        public void SetVector(string name, Vector4 value);
        public void SetVectorArray(int nameID, List<Vector4> values);
        //
        // 摘要:
        //     Set a vector array property.
        //
        // 参数:
        //   nameID:
        //     The name of the property.
        //
        //   values:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The array to set.
        public void SetVectorArray(int nameID, Vector4[] values);
        //
        // 摘要:
        //     Set a vector array property.
        //
        // 参数:
        //   nameID:
        //     The name of the property.
        //
        //   values:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   name:
        //     The array to set.
        public void SetVectorArray(string name, Vector4[] values);
        public void SetVectorArray(string name, List<Vector4> values);
    }
}
