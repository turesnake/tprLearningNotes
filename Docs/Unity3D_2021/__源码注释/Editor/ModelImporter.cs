#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using UnityEngine;

namespace UnityEditor
{

    /*
        摘要:
        Model importer lets you modify import settings from editor scripts.



    */
    [NativeHeaderAttribute("Modules/Animation/ScriptBindings/AvatarBuilder.bindings.h")]
    [NativeHeaderAttribute("Modules/AssetPipelineEditor/Public/ModelImporting/ModelImporter.bindings.h")]
    [NativeTypeAttribute(Header = "Modules/AssetPipelineEditor/Public/ModelImporting/ModelImporter.h")]
    public class ModelImporter//ModelImporter__RR
        : AssetImporter
    {
        public ModelImporter();

        //
        // 摘要:
        //     Optimize the order of polygons in the mesh to make better use of the GPUs internal
        //     caches to improve rendering performance.
        public bool optimizeMeshPolygons { get; set; }
        //
        // 摘要:
        //     Mesh compression setting.
        public ModelImporterMeshCompression meshCompression { get; set; }
        //
        // 摘要:
        //     Removes constant animation curves with values identical to the object initial
        //     scale value.
        public bool removeConstantScaleCurves { get; set; }
        //
        // 摘要:
        //     Is import of tangents supported by this importer.
        public bool isTangentImportSupported { get; }
        //
        // 摘要:
        //     If set to false, the importer will not resample curves when possible. Read more
        //     about. Notes: - Some unsupported FBX features (such as PreRotation or PostRotation
        //     on transforms) will override this setting. In these situations, animation curves
        //     will still be resampled even if the setting is disabled. For best results, avoid
        //     using PreRotation, PostRotation and GetRotationPivot. - This option was introduced
        //     in Version 5.3. Prior to this version, Unity's import behaviour was as if this
        //     option was always enabled. Therefore enabling the option gives the same behaviour
        //     as pre-5.3 animation import.
        public bool resampleCurves { get; set; }

        /*
        [Obsolete("use resampleCurves instead.")]public bool resampleRotations { get; set; }
        */

        //
        // 摘要:
        //     Is Bake Inverse Kinematics (IK) supported by this importer.
        public bool isBakeIKSupported { get; }
        //
        // 摘要:
        //     Bake Inverse Kinematics (IK) when importing.
        public bool bakeIK { get; set; }
        //
        // 摘要:
        //     Vertex tangent import options.
        public ModelImporterTangents importTangents { get; set; }
        //
        // 摘要:
        //     Normal generation options for ModelImporter.
        public ModelImporterNormalCalculationMode normalCalculationMode { get; set; }
        //
        // 摘要:
        //     Blend shape normal import options.
        public ModelImporterNormals importBlendShapeNormals { get; set; }
        //
        // 摘要:
        //     Source of smoothing information for calculation of normals.
        public ModelImporterNormalSmoothingSource normalSmoothingSource { get; set; }
        //
        // 摘要:
        //     Vertex normal import options.
        public ModelImporterNormals importNormals { get; set; }


        /*
        // 摘要:
        //     Tangents import mode.
        [Obsolete("tangentImportMode is deprecated. Use importTangents instead")]
        public ModelImporterTangentSpaceMode tangentImportMode { get; set; }
        //
        // 摘要:
        //     Normals import mode.
        [Obsolete("normalImportMode is deprecated. Use importNormals instead")]
        public ModelImporterTangentSpaceMode normalImportMode { get; set; }
        */

        //
        // 摘要:
        //     Minimum bone weight to keep.
        public float minBoneWeight { get; set; }
        //
        // 摘要:
        //     The maximum number of bones per vertex stored in this mesh data.
        public int maxBonesPerVertex { get; set; }
        //
        // 摘要:
        //     Skin weights import options.
        public ModelImporterSkinWeights skinWeights { get; set; }
        //
        // 摘要:
        //     Import animation from file.
        public bool importAnimation { get; set; }
        //
        // 摘要:
        //     Animation optimization setting.
        public bool optimizeGameObjects { get; set; }
        //
        // 摘要:
        //     Animation optimization setting.
        public string[] extraExposedTransformPaths { get; set; }
        //
        // 摘要:
        //     Additional properties to treat as user properties.
        public string[] extraUserProperties { get; set; }
        //
        // 摘要:
        //     Sorts the gameObject hierarchy by name.
        public bool sortHierarchyByName { get; set; }
        //
        // 摘要:
        //     When disabled, imported material albedo colors are converted to gamma space.
        //     This property should be disabled when using linear color space in Player rendering
        //     settings. The default value is true.
        public bool useSRGBMaterialColor { get; set; }


        /*
            Generate a list of all default animation clip based on "TakeInfo".

        */
        public ModelImporterClipAnimation[] defaultClipAnimations { get; }


        /*
            Animation clips to split animation into.

            When you import a file for the first time clipAnimations will be always empty. 
            If you need to populate(填入) clipAnimations before the first import 
            you can use an "AssetPostprocessor" and override "AssetPostprocessor.OnPreprocessAnimation()".
        */
        public ModelImporterClipAnimation[] clipAnimations { get; set; }

        

        /*
        [Obsolete("splitAnimations has been deprecated please use clipAnimations instead.", true)]
        public bool splitAnimations { get; set; }
        */


        //
        // 摘要:
        //     The human description that is used to generate an Avatar during the import process.
        public HumanDescription humanDescription { get; set; }
        //
        // 摘要:
        //     Imports the HumanDescription from the given Avatar.
        public Avatar sourceAvatar { get; set; }
        //
        // 摘要:
        //     The Avatar generation of the imported model.
        public ModelImporterAvatarSetup avatarSetup { get; set; }

        /*
        // 摘要:
        //     Vertex optimization setting.
        [Obsolete("optimizeMesh is deprecated. Use optimizeMeshPolygons and/or optimizeMeshVertices instead.  Note that optimizeMesh false equates to optimizeMeshPolygons true and optimizeMeshVertices false while optimizeMesh true equates to both true")]
        public bool optimizeMesh { get; set; }
        */

        //
        // 摘要:
        //     The path of the transform used to generation the motion of the animation.
        public string motionNodeName { get; set; }
        //
        // 摘要:
        //     Animator generation mode.
        public ModelImporterAnimationType animationType { get; set; }
        //
        // 摘要:
        //     The default wrap mode for the generated animation clips.
        public WrapMode animationWrapMode { get; set; }
        //
        // 摘要:
        //     Allowed error of animation scale compression.
        public float animationScaleError { get; set; }
        //
        // 摘要:
        //     Allowed error of animation position compression.
        public float animationPositionError { get; set; }
        //
        // 摘要:
        //     Allowed error of animation rotation compression.
        public float animationRotationError { get; set; }
        //
        // 摘要:
        //     Import animation constraints.
        public bool importConstraints { get; set; }
        //
        // 摘要:
        //     Import animated custom properties from file.
        public bool importAnimatedCustomProperties { get; set; }
        //
        // 摘要:
        //     Animation compression setting.
        public ModelImporterAnimationCompression animationCompression { get; set; }
        //
        // 摘要:
        //     Controls how much oversampling is used when importing humanoid animations for
        //     retargeting.
        public ModelImporterHumanoidOversampling humanoidOversampling { get; set; }
        //
        // 摘要:
        //     Optimize the order of vertices in the mesh to make better use of the GPUs internal
        //     caches to improve rendering performance.
        public bool optimizeMeshVertices { get; set; }
        //
        // 摘要:
        //     Generate auto mapping if no avatarSetup is provided when importing humanoid animation.
        public bool autoGenerateAvatarMappingIfUnspecified { get; set; }
        //
        // 摘要:
        //     Options to control the optimization of mesh data during asset import.
        public MeshOptimizationFlags meshOptimizationFlags { get; set; }
        //
        // 摘要:
        //     Smoothing angle (in degrees) for calculating normals.
        public float normalSmoothingAngle { get; set; }
        //
        // 摘要:
        //     Add to imported meshes.
        public bool addCollider { get; set; }
        //
        // 摘要:
        //     Controls import of lights. Note that because light are defined differently in
        //     DCC tools, some light types or properties may not be exported. Basic properties
        //     like color and intensity can be animated.
        public bool importLights { get; set; }
        //
        // 摘要:
        //     Controls import of cameras. Basic properties like field of view, near plane distance
        //     and far plane distance can be animated.
        public bool importCameras { get; set; }
        //
        // 摘要:
        //     Controls import of BlendShapes.
        public bool importBlendShapes { get; set; }

        /*
        // 摘要:
        //     Is FileScale used when importing.
        [Obsolete("Use useFileScale instead")]public bool isFileScaleUsed { get; }
        */


        //
        // 摘要:
        //     Use FileScale when importing.
        public bool useFileScale { get; set; }
        //
        // 摘要:
        //     Scaling factor used when useFileScale is set to true (Read-only).
        public float fileScale { get; }
        //
        // 摘要:
        //     Detect file units and import as 1FileUnit=1UnityUnit, otherwise it will import
        //     as 1cm=1UnityUnit.
        public bool useFileUnits { get; set; }
        //
        // 摘要:
        //     Use visibility properties to enable or disable MeshRenderer components.
        public bool importVisibility { get; set; }
        //
        // 摘要:
        //     Is useFileUnits supported for this asset.
        public bool isUseFileUnitsSupported { get; }
        //
        // 摘要:
        //     Global scale factor for importing.
        public float globalScale { get; set; }
        //
        // 摘要:
        //     Material import location options.
        public ModelImporterMaterialLocation materialLocation { get; set; }
        //
        // 摘要:
        //     Existing material search setting.
        public ModelImporterMaterialSearch materialSearch { get; set; }
        //
        // 摘要:
        //     Material naming setting.
        public ModelImporterMaterialName materialName { get; set; }

        /*
        // 摘要:
        //     Import materials from file.
        [Obsolete("importMaterials has been  removed. Use materialImportMode instead.", true)]
        public bool importMaterials { get; }
        //
        // 摘要:
        //     Material generation options.
        [Obsolete("generateMaterials has been  removed. Use materialImportMode, materialName and materialSearch instead.", true)]
        public ModelImporterGenerateMaterials generateMaterials { get; }
        */


        //
        // 摘要:
        //     Material creation options.
        public ModelImporterMaterialImportMode materialImportMode { get; set; }
        //
        // 摘要:
        //     Swap primary and secondary UV channels when importing.
        public bool swapUVChannels { get; set; }


        /*
        // 摘要:
        //     Should tangents be split across UV seams.
        [Obsolete("Please use tangentImportMode instead")]public bool splitTangentsAcrossSeams { get; set; }
        */


        //
        // 摘要:
        //     Computes the axis conversion on geometry and animation for Models defined in
        //     an axis system that differs from Unity's (left handed, Z forward, Y-up). When
        //     enabled, Unity transforms the geometry and animation data in order to convert
        //     the axis. When disabled, Unity transforms the root GameObject of the hierarchy
        //     in order to convert the axis.
        public bool bakeAxisConversion { get; set; }
        //
        // 摘要:
        //     Are mesh vertices and indices accessible from script?
        public bool isReadable { get; set; }
        //
        // 摘要:
        //     Generates the list of all imported Animations.
        public string[] referencedClips { get; }
        //
        // 摘要:
        //     Generates the list of all imported Transforms.
        public string[] transformPaths { get; }
        //
        // 摘要:
        //     Generates the list of all imported take.
        public TakeInfo[] importedTakeInfos { get; }
        //
        // 摘要:
        //     Animation generation options.
        public ModelImporterGenerateAnimations generateAnimations { get; set; }
        //
        // 摘要:
        //     The minimum object scale that the associated model is expected to have.
        public float secondaryUVMinObjectScale { get; set; }
        //
        // 摘要:
        //     The minimum lightmap resolution in texels per unit that the associated model
        //     is expected to have.
        public float secondaryUVMinLightmapResolution { get; set; }
        //
        // 摘要:
        //     Combine vertices that share the same position in space.
        public bool weldVertices { get; set; }
        //
        // 摘要:
        //     Margin to be left between charts when packing secondary UV.
        public float secondaryUVPackMargin { get; set; }
        //
        // 摘要:
        //     Hard angle (in degrees) for generating secondary UV.
        public float secondaryUVHardAngle { get; set; }
        //
        // 摘要:
        //     Threshold for area distortion when generating secondary UV.
        public float secondaryUVAreaDistortion { get; set; }
        //
        // 摘要:
        //     Threshold for angle distortion (in degrees) when generating secondary UV.
        public float secondaryUVAngleDistortion { get; set; }
        //
        // 摘要:
        //     Generate secondary UV set for lightmapping.
        public bool generateSecondaryUV { get; set; }
        //
        // 摘要:
        //     If true, always create an explicit Prefab root. Otherwise, if the model has a
        //     single root, it is reused as the Prefab root.
        public bool preserveHierarchy { get; set; }
        //
        // 摘要:
        //     Format of the imported mesh index buffer data.
        public ModelImporterIndexFormat indexFormat { get; set; }
        //
        // 摘要:
        //     If this is true, any quad faces that exist in the mesh data before it is imported
        //     are kept as quads instead of being split into two triangles, for the purposes
        //     of tessellation. Set this to false to disable this behavior.
        public bool keepQuads { get; set; }
        //
        // 摘要:
        //     Only import bones where they are connected to vertices.
        public bool optimizeBones { get; set; }
        //
        // 摘要:
        //     Method to use for handling margins when generating secondary UV.
        public ModelImporterSecondaryUVMarginMethod secondaryUVMarginMethod { get; set; }

        //
        // 摘要:
        //     Creates a mask that matches the model hierarchy, and applies it to the provided
        //     ModelImporterClipAnimation.
        //
        // 参数:
        //   clip:
        //     Clip to which the mask will be applied.
        public void CreateDefaultMaskForClip(ModelImporterClipAnimation clip);
        //
        // 摘要:
        //     Extracts the embedded textures from a model file (such as FBX or SketchUp).
        //
        // 参数:
        //   folderPath:
        //     The directory where the textures will be extracted.
        //
        // 返回结果:
        //     Returns true if the textures are extracted successfully, otherwise false.
        public bool ExtractTextures(string folderPath);
        //
        // 摘要:
        //     Search the project for matching materials and use them instead of the internal
        //     materials.
        //
        // 参数:
        //   nameOption:
        //     The name matching option.
        //
        //   searchOption:
        //     The search type option.
        //
        // 返回结果:
        //     Returns false if the source file is empty or invalid. Returns true otherwise.
        public bool SearchAndRemapMaterials(ModelImporterMaterialName nameOption, ModelImporterMaterialSearch searchOption);
    }
}

