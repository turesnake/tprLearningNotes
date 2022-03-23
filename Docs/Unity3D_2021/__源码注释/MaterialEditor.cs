
#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using UnityEngine;

namespace UnityEditor
{
    /*
        The Unity Material Editor.

        Extend this class to write your own custom material editor. 
        For more detailed information see:
            https://docs.unity3d.com/2021.1/Documentation/Manual/SL-CustomEditor.html
            https://docs.unity3d.com/2021.1/Documentation/Manual/SL-Shader.html

    */
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Material))]
    public class MaterialEditor//MaterialEditor__RR
        : Editor
    {
        //
        // 摘要:
        //     Useful for indenting shader properties that need the same indent as mini texture
        //     field.
        public const int kMiniTextureFieldLabelIndentLevel = 2;

        public MaterialEditor();

        //
        // 摘要:
        //     Is the current material expanded.
        public bool isVisible { get; }
        //
        // 摘要:
        //     Returns the custom ShaderGUI implemented by the shader.
        public ShaderGUI customShaderGUI { get; }

        //
        // 摘要:
        //     Apply initial MaterialPropertyDrawer values.
        //
        // 参数:
        //   material:
        //
        //   targets:
        public static void ApplyMaterialPropertyDrawers(UnityEngine.Object[] targets);
        //
        // 摘要:
        //     Apply initial MaterialPropertyDrawer values.
        //
        // 参数:
        //   material:
        //
        //   targets:
        public static void ApplyMaterialPropertyDrawers(Material material);
        //
        // 摘要:
        //     Returns a properly set global illlumination flag based on the passed in flag
        //     and the given color.
        //
        // 参数:
        //   col:
        //     Emission color.
        //
        //   flags:
        //     Current global illumination flag.
        //
        // 返回结果:
        //     The fixed up flag.
        public static MaterialGlobalIlluminationFlags FixupEmissiveFlag(Color col, MaterialGlobalIlluminationFlags flags);
        //
        // 摘要:
        //     Properly sets up the globalIllumination flag on the given Material depending
        //     on the current flag's state and the material's emission property.
        //
        // 参数:
        //   mat:
        //     The material to be fixed up.
        public static void FixupEmissiveFlag(Material mat);
        //
        // 摘要:
        //     Calculate height needed for the property, ignoring custom drawers.
        //
        // 参数:
        //   prop:
        public static float GetDefaultPropertyHeight(MaterialProperty prop);
        //
        // 摘要:
        //     Utility method for GUI layouting ShaderGUI. Used e.g for the rect after a left
        //     aligned Color field.
        //
        // 参数:
        //   r:
        //     Field Rect.
        //
        // 返回结果:
        //     A sub rect of the input Rect.
        public static Rect GetFlexibleRectBetweenFieldAndRightEdge(Rect r);
        //
        // 摘要:
        //     Utility method for GUI layouting ShaderGUI.
        //
        // 参数:
        //   r:
        //     Field Rect.
        //
        // 返回结果:
        //     A sub rect of the input Rect.
        public static Rect GetFlexibleRectBetweenLabelAndField(Rect r);
        //
        // 摘要:
        //     Utility method for GUI layouting ShaderGUI.
        //
        // 参数:
        //   r:
        //     Field Rect.
        //
        // 返回结果:
        //     A sub rect of the input Rect.
        public static Rect GetLeftAlignedFieldRect(Rect r);
        //
        // 摘要:
        //     Get shader property information of the passed materials.
        //
        // 参数:
        //   mats:
        public static MaterialProperty[] GetMaterialProperties(UnityEngine.Object[] mats);
        //
        // 摘要:
        //     Get information about a single shader property.
        //
        // 参数:
        //   mats:
        //     Selected materials.
        //
        //   name:
        //     Property name.
        //
        //   propertyIndex:
        //     Property index.
        public static MaterialProperty GetMaterialProperty(UnityEngine.Object[] mats, string name);
        //
        // 摘要:
        //     Get information about a single shader property.
        //
        // 参数:
        //   mats:
        //     Selected materials.
        //
        //   name:
        //     Property name.
        //
        //   propertyIndex:
        //     Property index.
        public static MaterialProperty GetMaterialProperty(UnityEngine.Object[] mats, int propertyIndex);
        //
        // 摘要:
        //     Utility method for GUI layouting ShaderGUI. This is the rect after the label
        //     which can be used for multiple properties. The input rect can be fetched by calling:
        //     EditorGUILayout.GetControlRect.
        //
        // 参数:
        //   r:
        //     Line Rect.
        //
        // 返回结果:
        //     A sub rect of the input Rect.
        public static Rect GetRectAfterLabelWidth(Rect r);
        //
        // 摘要:
        //     Utility method for GUI layouting ShaderGUI.
        //
        // 参数:
        //   r:
        //     Field Rect.
        //
        // 返回结果:
        //     A sub rect of the input Rect.
        public static Rect GetRightAlignedFieldRect(Rect r);
        public static Renderer PrepareMaterialPropertiesForAnimationMode(MaterialProperty[] properties, bool isMaterialEditable);
        //
        // 摘要:
        //     TODO.
        //
        // 参数:
        //   position:
        //
        //   scaleOffset:
        //
        //   partOfTexturePropertyControl:
        public static Vector4 TextureScaleOffsetProperty(Rect position, Vector4 scaleOffset);
        //
        // 摘要:
        //     TODO.
        //
        // 参数:
        //   position:
        //
        //   scaleOffset:
        //
        //   partOfTexturePropertyControl:
        public static Vector4 TextureScaleOffsetProperty(Rect position, Vector4 scaleOffset, bool partOfTexturePropertyControl);
        //
        // 摘要:
        //     Called when the Editor is woken up.
        public virtual void Awake();
        //
        // 摘要:
        //     Creates a Property wrapper, useful for making regular GUI controls work with
        //     MaterialProperty.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use for the control, including label if applicable.
        //
        //   prop:
        //     The MaterialProperty to use for the control.
        public void BeginAnimatedCheck(Rect totalPosition, MaterialProperty prop);
        //
        // 摘要:
        //     Creates a Property wrapper, useful for making regular GUI controls work with
        //     MaterialProperty.
        //
        // 参数:
        //   totalPosition:
        //     Rectangle on the screen to use for the control, including label if applicable.
        //
        //   prop:
        //     The MaterialProperty to use for the control.
        public void BeginAnimatedCheck(MaterialProperty prop);
        //
        // 摘要:
        //     Draw a property field for a color shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   position:
        //
        //   prop:
        public Color ColorProperty(Rect position, MaterialProperty prop, string label);
        //
        // 摘要:
        //     Draw a property field for a color shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   position:
        //
        //   prop:
        public Color ColorProperty(MaterialProperty prop, string label);

        /*
        [Obsolete("Use ColorProperty with MaterialProperty instead.")]
        public Color ColorProperty(string propertyName, string label);
        */

        //
        // 摘要:
        //     Default handling of preview area for materials.
        //
        // 参数:
        //   r:
        //
        //   background:
        public void DefaultPreviewGUI(Rect r, GUIStyle background);
        //
        // 摘要:
        //     Default toolbar for material preview area.
        public void DefaultPreviewSettingsGUI();
        //
        // 摘要:
        //     Handles UI for one shader property ignoring any custom drawers.
        //
        // 参数:
        //   prop:
        //
        //   label:
        //
        //   position:
        public void DefaultShaderProperty(MaterialProperty prop, string label);
        //
        // 摘要:
        //     Handles UI for one shader property ignoring any custom drawers.
        //
        // 参数:
        //   prop:
        //
        //   label:
        //
        //   position:
        public void DefaultShaderProperty(Rect position, MaterialProperty prop, string label);

        /*
        //     Display UI for editing a material's Double Sided Global Illumination setting.
        //     Returns true if the UI is indeed displayed i.e. the material supports the Double
        //     Sided Global Illumination setting. +See Also: Material.doubleSidedGI.

                显示 material inspector 中的 "Double Sided Global Illumination" 一栏;
        
        // 返回结果:
        //     True if the UI is displayed, false otherwise.
        */
        public bool DoubleSidedGIField();

        //
        // 摘要:
        //     This function will draw the UI for controlling whether emission is enabled or
        //     not on a material.
        //
        // 返回结果:
        //     Returns true if enabled, or false if disabled or mixed due to multi-editing.
        public bool EmissionEnabledProperty();
        
        //
        // 摘要:
        //     Display UI for editing material's render queue setting.
        public bool EnableInstancingField();
        //
        // 摘要:
        //     Display UI for editing material's render queue setting within the specified rect.
        //
        // 参数:
        //   r:
        public void EnableInstancingField(Rect r);

        //
        // 摘要:
        //     Ends a Property wrapper started with BeginAnimatedCheck.
        public void EndAnimatedCheck();
        //
        // 摘要:
        //     Draw a property field for a float shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //
        //   position:
        public float FloatProperty(MaterialProperty prop, string label);

        /*
        [Obsolete("Use FloatProperty with MaterialProperty instead.")]
        public float FloatProperty(string propertyName, string label);
        */ 

        //
        // 摘要:
        //     Draw a property field for a float shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //
        //   position:
        public float FloatProperty(Rect position, MaterialProperty prop, string label);

        /*
        [Obsolete("Use GetMaterialProperty instead.")]
        public Color GetColor(string propertyName, out bool hasMixedValue);
        [Obsolete("Use GetMaterialProperty instead.")]
        public float GetFloat(string propertyName, out bool hasMixedValue);
        */ 

        //
        // 摘要:
        //     Calculate height needed for the property.
        //
        // 参数:
        //   prop:
        //
        //   label:
        public float GetPropertyHeight(MaterialProperty prop);
        //
        // 摘要:
        //     Calculate height needed for the property.
        //
        // 参数:
        //   prop:
        //
        //   label:
        public float GetPropertyHeight(MaterialProperty prop, string label);

        /*
        [Obsolete("Use GetMaterialProperty instead.")]
        public Texture GetTexture(string propertyName, out bool hasMixedValue);
        [Obsolete("Use MaterialProperty instead.")]
        public Vector2 GetTextureOffset(string propertyName, out bool hasMixedValueX, out bool hasMixedValueY);
        */ 

        //
        // 摘要:
        //     Returns the free rect below the label and before the large thumb object field.
        //     Is used for e.g. tiling and offset properties.
        //
        // 参数:
        //   position:
        //     The total rect of the texture property.
        public Rect GetTexturePropertyCustomArea(Rect position);

        /*
        [Obsolete("Use MaterialProperty instead.")]
        public Vector2 GetTextureScale(string propertyName, out bool hasMixedValueX, out bool hasMixedValueY);
        [Obsolete("Use GetMaterialProperty instead.")]
        public Vector4 GetVector(string propertyName, out bool hasMixedValue);
        */ 

        //
        // 摘要:
        //     Can this component be Previewed in its current state?
        //
        // 返回结果:
        //     True if this component can be Previewed in its current state.
        public sealed override bool HasPreviewGUI();
        //
        // 摘要:
        //     Make a help box with a message and button. Returns true, if button was pressed.
        //
        // 参数:
        //   messageContent:
        //     The message text.
        //
        //   buttonContent:
        //     The button text.
        //
        // 返回结果:
        //     Returns true, if button was pressed.
        public bool HelpBoxWithButton(GUIContent messageContent, GUIContent buttonContent);
        //
        // 摘要:
        //     Draw a property field for an integer shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //
        //   position:
        public int IntegerProperty(Rect position, MaterialProperty prop, string label);
        //
        // 摘要:
        //     Draw a property field for an integer shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //
        //   position:
        public int IntegerProperty(MaterialProperty prop, string label);
        //
        // 摘要:
        //     Determines whether the Enable Instancing checkbox is checked.
        //
        // 返回结果:
        //     Returns true if Enable Instancing checkbox is checked.
        public bool IsInstancingEnabled();
        //
        // 摘要:
        //     Draws the UI for setting the global illumination flag of a material.
        //
        // 参数:
        //   indent:
        //     Level of indentation for the property.
        //
        //   enabled:
        //     True if emission is enabled for the material, false otherwise.
        //
        //   ignoreEmissionColor:
        //     True if property should always be displayed.
        public void LightmapEmissionFlagsProperty(int indent, bool enabled, bool ignoreEmissionColor);
        //
        // 摘要:
        //     Draws the UI for setting the global illumination flag of a material.
        //
        // 参数:
        //   indent:
        //     Level of indentation for the property.
        //
        //   enabled:
        //     True if emission is enabled for the material, false otherwise.
        //
        //   ignoreEmissionColor:
        //     True if property should always be displayed.
        public void LightmapEmissionFlagsProperty(int indent, bool enabled);
        public void LightmapEmissionProperty(Rect position, int labelIndent);
        public void LightmapEmissionProperty(int labelIndent);
        //
        // 摘要:
        //     This function will draw the UI for the lightmap emission property. (None, Realtime,
        //     baked) See Also: MaterialLightmapFlags.
        public void LightmapEmissionProperty();
        //
        // 摘要:
        //     Called when the editor is disabled, if overridden please call the base OnDisable()
        //     to ensure that the material inspector is set up properly.
        public virtual void OnDisable();
        //
        // 摘要:
        //     Called when the editor is enabled, if overridden please call the base OnEnable()
        //     to ensure that the material inspector is set up properly.
        public virtual void OnEnable();
        //
        // 摘要:
        //     Implement specific MaterialEditor GUI code here. If you want to simply extend
        //     the existing editor call the base OnInspectorGUI () before doing any custom GUI
        //     code.
        public override void OnInspectorGUI();
        public override void OnInteractivePreviewGUI(Rect r, GUIStyle background);
        //
        // 摘要:
        //     Custom preview for Image component.
        //
        // 参数:
        //   r:
        //     Rectangle in which to draw the preview.
        //
        //   background:
        //     Background image.
        public override void OnPreviewGUI(Rect r, GUIStyle background);
        public override void OnPreviewSettings();
        //
        // 摘要:
        //     Whenever a material property is changed call this function. This will rebuild
        //     the inspector and validate the properties.
        public void PropertiesChanged();
        //
        // 摘要:
        //     Default rendering of shader properties.
        //
        // 参数:
        //   props:
        //     Array of material properties.
        public void PropertiesDefaultGUI(MaterialProperty[] props);
        //
        // 摘要:
        //     Render the standard material properties. This method will either render properties
        //     using a IShaderGUI instance if found otherwise it uses PropertiesDefaultGUI.
        //
        // 返回结果:
        //     Returns true if any value was changed.
        public bool PropertiesGUI();
        //
        // 摘要:
        //     Draw a range slider for a range shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //     The property to edit.
        //
        //   position:
        //     Position and size of the range slider control.
        public float RangeProperty(Rect position, MaterialProperty prop, string label);
        //
        // 摘要:
        //     Draw a range slider for a range shader property.
        //
        // 参数:
        //   label:
        //     Label for the property.
        //
        //   prop:
        //     The property to edit.
        //
        //   position:
        //     Position and size of the range slider control.
        public float RangeProperty(MaterialProperty prop, string label);

        /*
        [Obsolete("Use RangeProperty with MaterialProperty instead.")]
        public float RangeProperty(string propertyName, string label, float v2, float v3);
        */ 

        //
        // 摘要:
        //     Call this when you change a material property. It will add an undo for the action.
        //
        // 参数:
        //   label:
        //     Undo Label.
        public void RegisterPropertyChangeUndo(string label);

        /*
            Display UI for editing material's render queue setting.
            显示 material inspector 中的 ""Render Queue" 一栏;

        // 参数:
        //   r:
        */
        public void RenderQueueField();
        public void RenderQueueField(Rect r);


        public sealed override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height);
        //
        // 摘要:
        //     Does this edit require to be repainted constantly in its current state?
        public override bool RequiresConstantRepaint();

        /*
        [Obsolete("Use MaterialProperty instead.")]
        public void SetColor(string propertyName, Color value);
        */ 

        //
        // 摘要:
        //     Set EditorGUIUtility.fieldWidth and labelWidth to the default values that PropertiesGUI
        //     uses.
        public void SetDefaultGUIWidths();

        /*
        [Obsolete("Use MaterialProperty instead.")]
        public void SetFloat(string propertyName, float value);
        */ 

        //
        // 摘要:
        //     Set the shader of the material.
        //
        // 参数:
        //   shader:
        //     Shader to set.
        //
        //   registerUndo:
        //     Should undo be registered.
        //
        //   newShader:
        public void SetShader(Shader newShader, bool registerUndo);
        //
        // 摘要:
        //     Set the shader of the material.
        //
        // 参数:
        //   shader:
        //     Shader to set.
        //
        //   registerUndo:
        //     Should undo be registered.
        //
        //   newShader:
        public void SetShader(Shader shader);

        /*
        [Obsolete("Use MaterialProperty instead.")]
        public void SetTexture(string propertyName, Texture value);
        */ 

       
        /*
        [Obsolete("Use MaterialProperty instead.")]
        public void SetTextureOffset(string propertyName, Vector2 value, int coord);
        */ 
        
        /*
        [Obsolete("Use MaterialProperty instead.")]
        public void SetTextureScale(string propertyName, Vector2 value, int coord);
        [Obsolete("Use MaterialProperty instead.")]
        public void SetVector(string propertyName, Vector4 value);
        */ 

        /*
             Handes UI for one shader property.
        */
        public void ShaderProperty(Rect position, MaterialProperty prop, string label, int labelIndent);
        public void ShaderProperty(Rect position, MaterialProperty prop, GUIContent label, int labelIndent);
        public void ShaderProperty(Rect position, MaterialProperty prop, GUIContent label);
        
        public void ShaderProperty(Rect position, MaterialProperty prop, string label);
        public void ShaderProperty(MaterialProperty prop, GUIContent label, int labelIndent);
        public void ShaderProperty(MaterialProperty prop, string label, int labelIndent);
        public void ShaderProperty(MaterialProperty prop, GUIContent label);
        public void ShaderProperty(MaterialProperty prop, string label);



        /*
        [Obsolete("Use ShaderProperty that takes MaterialProperty parameter instead.")]
        public void ShaderProperty(Shader shader, int propertyIndex);
        */ 

       
        
        //
        // 摘要:
        //     Checks if particular property has incorrect type of texture specified by the
        //     material, displays appropriate warning and suggests the user to automatically
        //     fix the problem.
        //
        // 参数:
        //   prop:
        //     The texture property to check and display warning for, if necessary.
        public void TextureCompatibilityWarning(MaterialProperty prop);
        //
        // 摘要:
        //     Draw a property field for a texture shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   scaleOffset:
        //     Draw scale / offset.
        //
        //   prop:
        //
        //   position:
        //
        //   tooltip:
        public Texture TextureProperty(Rect position, MaterialProperty prop, string label, bool scaleOffset);
        //
        // 摘要:
        //     Draw a property field for a texture shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   scaleOffset:
        //     Draw scale / offset.
        //
        //   prop:
        //
        //   position:
        //
        //   tooltip:
        public Texture TextureProperty(Rect position, MaterialProperty prop, string label);
        //
        // 摘要:
        //     Draw a property field for a texture shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   scaleOffset:
        //     Draw scale / offset.
        //
        //   prop:
        //
        //   position:
        //
        //   tooltip:
        public Texture TextureProperty(Rect position, MaterialProperty prop, string label, string tooltip, bool scaleOffset);
        //
        // 摘要:
        //     Draw a property field for a texture shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   scaleOffset:
        //     Draw scale / offset.
        //
        //   prop:
        //
        //   position:
        //
        //   tooltip:
        public Texture TextureProperty(MaterialProperty prop, string label);

        /*
        [Obsolete("Use TextureProperty with MaterialProperty instead.")]
        public Texture TextureProperty(string propertyName, string label, ShaderUtil.ShaderPropertyTexDim texDim, bool scaleOffset);
        */ 

        //
        // 摘要:
        //     Draw a property field for a texture shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   scaleOffset:
        //     Draw scale / offset.
        //
        //   prop:
        //
        //   position:
        //
        //   tooltip:
        public Texture TextureProperty(MaterialProperty prop, string label, bool scaleOffset);

        /*
        [Obsolete("Use TextureProperty with MaterialProperty instead.")]
        public Texture TextureProperty(string propertyName, string label, ShaderUtil.ShaderPropertyTexDim texDim);
        */ 

        //
        // 摘要:
        //     Draw a property field for a texture shader property that only takes up a single
        //     line height.
        //
        // 参数:
        //   position:
        //     Rect that this control should be rendered in.
        //
        //   label:
        //     Label for the field.
        //
        //   prop:
        //
        //   tooltip:
        //
        // 返回结果:
        //     Returns total height used by this control.
        public Texture TexturePropertyMiniThumbnail(Rect position, MaterialProperty prop, string label, string tooltip);
        //
        // 摘要:
        //     Method for showing a texture property control with additional inlined properites.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   extraProperty1:
        //     First optional property inlined after the texture property.
        //
        //   extraProperty2:
        //     Second optional property inlined after the extraProperty1.
        //
        // 返回结果:
        //     Returns the Rect used.
        public Rect TexturePropertySingleLine(GUIContent label, MaterialProperty textureProp);
        //
        // 摘要:
        //     Method for showing a texture property control with additional inlined properites.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   extraProperty1:
        //     First optional property inlined after the texture property.
        //
        //   extraProperty2:
        //     Second optional property inlined after the extraProperty1.
        //
        // 返回结果:
        //     Returns the Rect used.
        public Rect TexturePropertySingleLine(GUIContent label, MaterialProperty textureProp, MaterialProperty extraProperty1);
        //
        // 摘要:
        //     Method for showing a texture property control with additional inlined properites.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   extraProperty1:
        //     First optional property inlined after the texture property.
        //
        //   extraProperty2:
        //     Second optional property inlined after the extraProperty1.
        //
        // 返回结果:
        //     Returns the Rect used.
        public Rect TexturePropertySingleLine(GUIContent label, MaterialProperty textureProp, MaterialProperty extraProperty1, MaterialProperty extraProperty2);
        //
        // 摘要:
        //     Method for showing a compact layout of properties.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   extraProperty1:
        //     First extra property inlined after the texture property.
        //
        //   label2:
        //     Label for the second extra property (on a new line and indented).
        //
        //   extraProperty2:
        //     Second property on a new line below the texture.
        //
        // 返回结果:
        //     Returns the Rect used.
        public Rect TexturePropertyTwoLines(GUIContent label, MaterialProperty textureProp, MaterialProperty extraProperty1, GUIContent label2, MaterialProperty extraProperty2);
        
        //
        // 摘要:
        //     Method for showing a texture property control with a HDR color field and its
        //     color brightness float field.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   colorProperty:
        //     The color property (will be treated as a HDR color).
        //
        //   showAlpha:
        //     If false then the alpha channel information will be hidden in the GUI.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     Return the Rect used.
        /*
        [Obsolete("Use TexturePropertyWithHDRColor(GUIContent label, MaterialProperty textureProp, MaterialProperty colorProperty, bool showAlpha)")]
        public Rect TexturePropertyWithHDRColor(GUIContent label, MaterialProperty textureProp, MaterialProperty colorProperty, ColorPickerHDRConfig hdrConfig, bool showAlpha);
        */ 

        //
        // 摘要:
        //     Method for showing a texture property control with a HDR color field and its
        //     color brightness float field.
        //
        // 参数:
        //   label:
        //     The label used for the texture property.
        //
        //   textureProp:
        //     The texture property.
        //
        //   colorProperty:
        //     The color property (will be treated as a HDR color).
        //
        //   showAlpha:
        //     If false then the alpha channel information will be hidden in the GUI.
        //
        //   hdrConfig:
        //
        // 返回结果:
        //     Return the Rect used.
        public Rect TexturePropertyWithHDRColor(GUIContent label, MaterialProperty textureProp, MaterialProperty colorProperty, bool showAlpha);
        public void TextureScaleOffsetProperty(MaterialProperty property);
        //
        // 摘要:
        //     Draws tiling and offset properties for a texture.
        //
        // 参数:
        //   position:
        //     Rect to draw this control in.
        //
        //   property:
        //     Property to draw.
        //
        //   partOfTexturePropertyControl:
        //     If this control should be rendered under large texture property control use 'true'.
        //     If this control should be shown seperately use 'false'.
        public float TextureScaleOffsetProperty(Rect position, MaterialProperty property, bool partOfTexturePropertyControl);
        //
        // 摘要:
        //     Draws tiling and offset properties for a texture.
        //
        // 参数:
        //   position:
        //     Rect to draw this control in.
        //
        //   property:
        //     Property to draw.
        //
        //   partOfTexturePropertyControl:
        //     If this control should be rendered under large texture property control use 'true'.
        //     If this control should be shown seperately use 'false'.
        public float TextureScaleOffsetProperty(Rect position, MaterialProperty property);
        public virtual void UndoRedoPerformed();
        //
        // 摘要:
        //     Draw a property field for a vector shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   prop:
        //
        //   position:
        public Vector4 VectorProperty(MaterialProperty prop, string label);
        //
        // 摘要:
        //     Draw a property field for a vector shader property.
        //
        // 参数:
        //   label:
        //     Label for the field.
        //
        //   prop:
        //
        //   position:
        public Vector4 VectorProperty(Rect position, MaterialProperty prop, string label);

        /*
        [Obsolete("Use VectorProperty with MaterialProperty instead.")]
        public Vector4 VectorProperty(string propertyName, string label);
        */ 

        protected override void OnHeaderGUI();
        //
        // 摘要:
        //     A callback that is invoked when a Material's Shader is changed in the Inspector.
        protected virtual void OnShaderChanged();
    }
}

