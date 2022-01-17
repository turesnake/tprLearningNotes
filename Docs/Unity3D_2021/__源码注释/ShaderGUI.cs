#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using UnityEngine;

namespace UnityEditor
{
    /*
        Abstract class to derive from for defining custom GUI for shader properties 
        and for extending the material preview.

        Derive from this class for controlling how shader properties should be presented. 
        For a shader to use this custom GUI use the 'CustomEditor' property in the shader. 
        
        Note that CustomEditor can also be used for classes deriving from MaterialEditor 
        (search for: Custom Material Editors). 
        
        Note: Only the ShaderGUI approach works with Substance materials this is therefore the recommended approach 
        to custom gui for shaders. 
        只有 ShaderGUI 方法适用于 Substance 材质，因此这是为着色器自定义 gui 的推荐方法。
        
        See "ShaderGUI.OnGUI", 
            "ShaderGUI.OnMaterialPreviewGUI", 
            "ShaderGUI.OnMaterialPreviewSettingsGUI"

    */
    public abstract class ShaderGUI//ShaderGUI__RR
    {

        protected ShaderGUI();

        //
        // 摘要:
        //     Find shader properties.
        //
        // 参数:
        //   propertyName:
        //     Name of the material property.
        //
        //   properties:
        //     The array of available properties.
        //
        //   propertyIsMandatory:
        //     If true then this method will throw an exception if a property with propertyName
        //     was not found.
        //
        // 返回结果:
        //     The material property found, otherwise null.
        protected static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties);

        //
        // 摘要:
        //     Find shader properties.
        //
        // 参数:
        //   propertyName:
        //     Name of the material property.
        //
        //   properties:
        //     The array of available properties.
        //
        //   propertyIsMandatory:
        //     If true then this method will throw an exception if a property with propertyName
        //     was not found.
        //
        // 返回结果:
        //     The material property found, otherwise null.
        protected static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties, bool propertyIsMandatory);

        //
        // 摘要:
        //     This method is called when a new shader has been selected for a Material.
        //
        // 参数:
        //   material:
        //     The material the newShader should be assigned to.
        //
        //   oldShader:
        //     Previous shader.
        //
        //   newShader:
        //     New shader to assign to the material.
        public virtual void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader);
        //
        // 摘要:
        //     This method is called when the ShaderGUI is being closed.
        //
        // 参数:
        //   material:
        public virtual void OnClosed(Material material);


        /*
            To define a custom shader GUI use the methods of materialEditor to render controls for the properties array.


        */
        // 参数:
        //   materialEditor:
        //     The MaterialEditor that are calling this OnGUI (the 'owner').
        //
        //   properties:
        //     Material properties of the current selected shader.
        public virtual void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties);


        public virtual void OnMaterialInteractivePreviewGUI(MaterialEditor materialEditor, Rect r, GUIStyle background);
        //
        // 摘要:
        //     Override for extending the rendering of the Preview area or completly replace
        //     the preview (by not calling base.OnMaterialPreviewGUI).
        //
        // 参数:
        //   materialEditor:
        //     The MaterialEditor that are calling this method (the 'owner').
        //
        //   r:
        //     Preview rect.
        //
        //   background:
        //     Style for the background.
        public virtual void OnMaterialPreviewGUI(MaterialEditor materialEditor, Rect r, GUIStyle background);
        //
        // 摘要:
        //     Override for extending the functionality of the toolbar of the preview area or
        //     completly replace the toolbar by not calling base.OnMaterialPreviewSettingsGUI.
        //
        // 参数:
        //   materialEditor:
        //     The MaterialEditor that are calling this method (the 'owner').
        public virtual void OnMaterialPreviewSettingsGUI(MaterialEditor materialEditor);
    }
}

