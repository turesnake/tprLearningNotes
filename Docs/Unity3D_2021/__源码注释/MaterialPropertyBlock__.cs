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
            catlike 中使用到了后者: SetPropertyBlock(...)
        如果你希望绘制数个物体, 它们使用相同的 material, 但每个物体都希望拥有自己的 properties 时
        可用本 class. 

        unity terrain engine 使用本类来绘制 树木, 每棵树都使用相同的 material, 但各自持有独立的 properties. 

        被传入  Graphics.DrawMesh or Renderer.SetPropertyBlock 的本 class 实例 将被执行值复制,
        所以, 推荐的用法是, 创建一个  MaterialPropertyBlock 实例(比如是 static 的), 然后反复使用它. 

        使用 MaterialPropertyBlock 的物体, 无法被 SRP Batcher 批处理;

    */
    [NativeHeaderAttribute("Runtime/Shaders/ShaderPropertySheet.h")]
    [NativeHeaderAttribute("Runtime/Shaders/ComputeShader.h")]
    [NativeHeaderAttribute("Runtime/Graphics/ShaderScriptBindings.h")]
    [NativeHeaderAttribute("Runtime/Math/SphericalHarmonicsL2.h")]
    public sealed class MaterialPropertyBlock//MaterialPropertyBlock__
    {
        public MaterialPropertyBlock();
        ~MaterialPropertyBlock();
        
        // 摘要:
        //     Is the material property block empty? (Read Only)
        public bool isEmpty { get; }

        /*
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
        */

        /*
            摘要:
                Clear material property values.
                清理掉后还能设置新值, 继续使用这个 本类实例
        */
        public void Clear();


        /*
            摘要:
                This function copies the entire source array into a Vector4 property array named
                "unity_ProbesOcclusion" for use with instanced rendering.
                ---
                后两个版本 with the specified source and destination range;
                ---
                此处的 probe occlusion 就是 light probe(occlusion)

                如果 本 MaterialPropertyBlock 实例中, 并不存在目标 array property, 本函数将自动生成一个新的:
                对于前两个函数重置, 使用 source array 的尺寸;
                对于后两个函数重置, 使用 参数指定的长度 作为尺寸;

                调用 LightProbes.CalculateInterpolatedLightAndOcclusionProbes() 
                来计算 给定 posWS 上的 probe occlusion 的值,

                如果指定的 复制起始位置和区间 参数 是无效的, 将抛出异常;

                注意, 所有 MaterialPropertyBlock 的 array, 最多都只能由 1023个元素;
                如果 src array 中的元素超出此上界, 将爆出 Warning, 且超出的元素将被忽略;
            
            参数:
            occlusionProbes:
                The array of probe occlusion values to copy from.
                若为 null, 将抛出异常;

            sourceStart:
                The index of the first element in the source array to copy from.
            
            destStart:
                The index of the first element in the destination MaterialPropertyBlock array to copy to.
            
            count:
                The number of elements to copy.
        */
        public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes);
        public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes);
        public void CopyProbeOcclusionArrayFrom(List<Vector4> occlusionProbes, int sourceStart, int destStart, int count);
        public void CopyProbeOcclusionArrayFrom(Vector4[] occlusionProbes, int sourceStart, int destStart, int count);
        

        /*
            摘要:
                This function converts and copies the source array into 7 Vector4 property arrays
                named unity_SHAr, unity_SHAg, unity_SHAb, unity_SHBr, unity_SHBg, unity_SHBb
                and unity_SHC for use with instanced rendering.

                后两个函数重置 只复制一部分数据, 所以要额外指定 复制的区域;

                如果 本 MaterialPropertyBlock 实例中, 并不存在目标 array property, 本函数将自动生成一个新的:
                对于前两个函数重置, 使用 source array 的尺寸;
                对于后两个函数重置, 使用 参数指定的长度 作为尺寸;

                如果指定的 复制起始位置和区间 参数 是无效的, 将抛出异常;

                注意, 所有 MaterialPropertyBlock 的 array, 最多都只能由 1023个元素;
                如果 src array 中的元素超出此上界, 将爆出 Warning, 且超出的元素将被忽略;
            
            参数:
            lightProbes:
                The array of SH values to copy from.
                若为 null, 将抛出异常;
            
            sourceStart:
                The index of the first element in the source array to copy from.
            
            destStart:
                The index of the first element in the destination MaterialPropertyBlock array
                to copy to.
            
            count:
                The number of elements to copy.
        */
        public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes);
        public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes);
        public void CopySHCoefficientArraysFrom(SphericalHarmonicsL2[] lightProbes, int sourceStart, int destStart, int count);
        public void CopySHCoefficientArraysFrom(List<SphericalHarmonicsL2> lightProbes, int sourceStart, int destStart, int count);
        
        /*
            摘要:
                Get a color from the property block.
                没找到就返回 (0,0,0,0); 
                
                If the value is previously set using SetColor, 
                the returned value is converted from the currently active color space back to the sRGB color space.
        */
        public Color GetColor(string name);
        public Color GetColor(int nameID);


        // 摘要:
        //     Get a float from the property block.
        //     没找到就返回 0.0;
        public float GetFloat(string name);
        public float GetFloat(int nameID);

        
        /*
            摘要:
                 Get a float array from the property block.
                 没找到就返回 null;

                参数 values will be resized to the array size, 
                or cleared if such property doesn't exist. 
                Memory allocation is guaranteed not to happen during the function call. 
        */
        public float[] GetFloatArray(string name);
        public float[] GetFloatArray(int nameID);
        public void GetFloatArray(string name, List<float> values);
        public void GetFloatArray(int nameID, List<float> values);

        
        /*
            文档显示 此函数已废弃;
            摘要:
                This method is deprecated. Use GetFloat or GetInteger instead.
        public int GetInt(string name);
        public int GetInt(int nameID);
        */

        // 摘要:
        //     Get an integer from the property block.
        //     没找到就返回 0
        public int GetInteger(string name);
        public int GetInteger(int nameID);

        
        // 摘要:
        //     Get a matrix from the property block.
        //     没找到就返回 单位矩阵
        public Matrix4x4 GetMatrix(int nameID);
        public Matrix4x4 GetMatrix(string name);

        /*
            摘要:
                Get a matrix array from the property block.
                没找到就返回 null

                参数 values will be resized to the array size, 
                or cleared if such property doesn't exist. 
                Memory allocation is guaranteed not to happen during the function call. 
        */
        public Matrix4x4[] GetMatrixArray(int nameID);
        public void GetMatrixArray(string name, List<Matrix4x4> values);
        public void GetMatrixArray(int nameID, List<Matrix4x4> values);
        public Matrix4x4[] GetMatrixArray(string name);

        

        // 摘要:
        //     Get a texture from the property block.
        //     没找到就返回 null
        public Texture GetTexture(int nameID);
        public Texture GetTexture(string name);

        /*
            摘要:
                Get a vector from the property block.
                没找到就返回 zero vector;

            If the value is previously set using SetColor, 
            the returned vector value is the sRGB color value converted for the active color space.
        */
        public Vector4 GetVector(int nameID);
        public Vector4 GetVector(string name);
        
        /*
            摘要:
                Get a vector array from the property block.
                没找到就返回 null;

                参数 values will be resized to the array size, 
                or cleared if such property doesn't exist. 
                Memory allocation is guaranteed not to happen during the function call.   
        */
        public Vector4[] GetVectorArray(int nameID);
        public void GetVectorArray(string name, List<Vector4> values);
        public void GetVectorArray(int nameID, List<Vector4> values);
        public Vector4[] GetVectorArray(string name);

        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ComputeBuffer property with the given
        //     name or name ID. To set the property, use SetBuffer.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasBuffer(int nameID);
        public bool HasBuffer(string name);


        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Color property with the given name or
        //     name ID. To set the property, use SetColor.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasColor(string name);
        public bool HasColor(int nameID);

        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the ConstantBuffer property with the given
        //     name or name ID. To set the property, use SetConstantBuffer.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasConstantBuffer(int nameID);
        public bool HasConstantBuffer(string name);


        // 摘要:
        //     Checks if MaterialPropertyBlock has the Float property with the given name or
        //     name ID. To set the property, use SetFloat.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasFloat(int nameID);
        public bool HasFloat(string name);
        
        /*
            文档说 已废弃
        public bool HasInt(string name);
        public bool HasInt(int nameID);
        */

        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Integer property with the given name
        //     or name ID. To set the property, use SetInteger.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasInteger(string name);
        public bool HasInteger(int nameID);

        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Matrix property with the given name or
        //     name ID. This also works with the Matrix Array property. To set the property,
        //     use SetMatrix.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasMatrix(string name);
        public bool HasMatrix(int nameID);
        

        // 摘要:
        //     Checks if MaterialPropertyBlock has the property with the given name or name
        //     ID. To set the property, use one of the Set methods for MaterialPropertyBlock.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasProperty(int nameID);
        public bool HasProperty(string name);
        

        // 摘要:
        //     Checks if MaterialPropertyBlock has the Texture property with the given name
        //     or name ID. To set the property, use SetTexture.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasTexture(string name);
        public bool HasTexture(int nameID);

        
        // 摘要:
        //     Checks if MaterialPropertyBlock has the Vector property with the given name or
        //     name ID. This also works with the Vector Array property. To set the property,
        //     use SetVector.
        // 返回结果:
        //     Returns true if MaterialPropertyBlock has this property.
        public bool HasVector(string name);
        public bool HasVector(int nameID);
        

        // 摘要:
        //     Set a buffer property.
        //     Adds a property to the block. 
        //     If a buffer property with the given name already exists, the old value is replaced.
        //
        // 参数:
        //   value:
        //     The ComputeBuffer or GraphicsBuffer to set.
        public void SetBuffer(string name, ComputeBuffer value);
        public void SetBuffer(int nameID, ComputeBuffer value);
        public void SetBuffer(string name, GraphicsBuffer value);
        public void SetBuffer(int nameID, GraphicsBuffer value);

        /*
            摘要:
                Set a color property.
                Adds a property to the block. 
                If a color property with the given name already exists, the old value is replaced.

                The color value is considered to be always set in sRGB space 
                and is converted to linear if the active color space is linear. 
                You need manual updating of the color value if you switch between color spaces.
            
            参数:
            value:
                The Color value to set.
        */
        public void SetColor(int nameID, Color value);
        public void SetColor(string name, Color value);

        
        /*
            摘要:
                Sets a ComputeBuffer or GraphicsBuffer as a named constant buffer for the MaterialPropertyBlock.
            
            参数:
            name/nameID:
                The name of the constant buffer to override.
            
            value:
                The buffer to override the constant buffer values with.
            
            offset:
                Offset in bytes from the beginning of the buffer to bind. Must be a multiple
                of SystemInfo.constantBufferOffsetAlignment, or 0 if that value is 0.
            
            size:
                The number of bytes to bind.
        */
        public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size);
        public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size);
        public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size);
        

        /*
        // 摘要:
        //     Set a float property.
        //
        // 参数:
        //   name:
        //     The name of the property.
        //     Adds a property to the block. \
                If a float property with the given name already exists, the old value is replaced.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The float value to set.
        */
        public void SetFloat(string name, float value);
        public void SetFloat(int nameID, float value);


        /*
        // 摘要:
            Set a float array property.

            Adds a float array property to the block. 
            If a float array property with the given name already exists, the old value is replaced.

            此次设置的这个 array property 的 length 一旦设置无法被更改, 
            在未来, 
            如果向这个 property 写入一个尺寸更大的 array; 超出的写入数据将被丢弃;
            如果向这个 property 写入一个尺寸更小的 array; 尾部区域的原始数据将被保留;

        // 参数:
        //   name:
        //     The name of the property.
        //
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   values:
        //     The array to set.
        */
        public void SetFloatArray(int nameID, List<float> values);
        public void SetFloatArray(string name, List<float> values);
        public void SetFloatArray(string name, float[] values);
        public void SetFloatArray(int nameID, float[] values);

        /*
            文档说已废弃
        public void SetInt(string name, int value);
        public void SetInt(int nameID, int value);
        */

        
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
        public void SetInteger(int nameID, int value);

        
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
        public void SetMatrix(string name, Matrix4x4 value);

        /*
            摘要:
            Set a matrix array property.

            此次设置的这个 array property 的 length 一旦设置无法被更改, 
            在未来, 
            如果向这个 property 写入一个尺寸更大的 array; 超出的写入数据将被丢弃;
            如果向这个 property 写入一个尺寸更小的 array; 尾部区域的原始数据将被保留;
        
        // 参数:
        //   name:
        //     The name of the property.
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //   values:
        //     The array to set.
        */
        public void SetMatrixArray(int nameID, Matrix4x4[] values);
        public void SetMatrixArray(string name, Matrix4x4[] values);
        public void SetMatrixArray(int nameID, List<Matrix4x4> values);
        public void SetMatrixArray(string name, List<Matrix4x4> values);

        
        /*
        // 摘要:
        //     Set a texture property.

                By specifying a `RenderTextureSubElement`, 
                you can indicate which type of data to set from the RenderTexture. 
                The possible options are: 
                -- RenderTextureSubElement.Color, 
                -- RenderTextureSubElement.Depth,
                -- RenderTextureSubElement.Stencil.
        
        // 参数:
        //   name:
        //     The name of the property.
        //   nameID:
        //     The name ID of the property retrieved by Shader.PropertyToID.
        //
        //   value:
        //     The Texture to set.
        //
        //   element:
        //     Optional parameter that specifies the type of data to set from the RenderTexture.
        */
        public void SetTexture(string name, Texture value);
        public void SetTexture(int nameID, Texture value);
        public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element);
        public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element);
        

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
        public void SetVector(string name, Vector4 value);

        /*
            此次设置的这个 array property 的 length 一旦设置无法被更改, 
            在未来, 
            如果向这个 property 写入一个尺寸更大的 array; 超出的写入数据将被丢弃;
            如果向这个 property 写入一个尺寸更小的 array; 尾部区域的原始数据将被保留;
        */
        public void SetVectorArray(int nameID, List<Vector4> values);
        public void SetVectorArray(int nameID, Vector4[] values);
        public void SetVectorArray(string name, Vector4[] values);
        public void SetVectorArray(string name, List<Vector4> values);
    }
}
