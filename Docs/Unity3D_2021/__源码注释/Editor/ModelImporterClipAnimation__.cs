#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using UnityEngine;

namespace UnityEditor
{
    /*
        摘要:
        Animation clips to split animation into.




    */
    [NativeHeaderAttribute("Modules/AssetPipelineEditor/Public/ModelImporting/ModelImporter.bindings.h")]
    [NativeTypeAttribute(CodegenOptions = UnityEngine.Bindings.CodegenOptions.Custom, IntermediateScriptingStructName = "MonoClipAnimationInfo")]
    [UsedByNativeCodeAttribute]
    public sealed class ModelImporterClipAnimation//ModelImporterClipAnimation__
    {
        public ModelImporterClipAnimation();

       
        //     Enable to make the motion loop seamlessly.
        // 启用以使运动循环无缝。
        public bool loopPose { get; set; }

       
        //     Returns true when the source AvatarMask has changed. This only happens when "ModelImporterClipAnimation.maskType"
        //     is set to "ClipAnimationMaskType.CopyFromOther" To force a reload of the mask,
        //     simply set ModelImporterClipAnimation.maskSource to the desired AvatarMask.
        public bool maskNeedsUpdating { get; }

      
        //     Additionnal curves that will be that will be added during the import process. 将在导入过程中添加的附加曲线。
        //   They are automatically binded to the "animator controller parameter" that have the same name.
        public ClipAnimationInfoCurve[] curves { get; set; }

        
        //     AnimationEvents that will be added during the import process.
        public AnimationEvent[] events { get; set; }

        //
        // 摘要:
        //     The AvatarMask used to mask transforms during the import process.
        public AvatarMask maskSource { get; set; }
        

        //     Define mask type.
        // A mask can be used to discard transform when importing a clip to reduce memory footprint for this clip.
        // 导入剪辑时可以使用蒙版丢弃变换，以减少此剪辑的内存占用。
        public ClipAnimationMaskType maskType { get; set; }

        
        //     Mirror left and right in this clip.
        public bool mirror { get; set; }

        
        //     Keeps the feet aligned with the root transform position.
        public bool heightFromFeet { get; set; }

       
        // 保持在源文件中创作的 水平位置。
        public bool keepOriginalPositionXZ { get; set; }

        
        //     Keeps the vertical position as it is authored in the source file.
        // keepOriginalPositionY
        public bool keepOriginalPositionY { get; set; }


        // 保持源文件中设置的 朝向
        public bool keepOriginalOrientation { get; set; }

        
        //     Enable to make horizontal root motion be baked into the movement of the bones.
        //           启用 以使水平根部运动 被烘焙到骨骼的运动中。
        //     Disable to make horizontal root motion be stored as root motion.
        //           禁用 以使水平根运动 存储为根运动。
        public bool lockRootPositionXZ { get; set; }


        
        //     Enable to make vertical root motion be baked into the movement of the bones.
        //          启用以使 垂直根部运动 被烘焙到骨骼的运动中。
        //     Disable to make vertical root motion be stored as root motion.
        //          禁用以使 垂直根运动  存储为根运动。
        public bool lockRootHeightY { get; set; }



        //     Enable to make root rotation be baked into the movement of the bones. 
        //     Disable to make root rotation be stored as root motion.
        public bool lockRootRotation { get; set; }


    
        //     Enable to defines an additive reference pose.  启用以定义附加参考姿势。
        public bool hasAdditiveReferencePose { get; set; }

      
        //     Enable to make the clip loop.
        public bool loopTime { get; set; }

       
        //     Offset to the cycle of a looping animation, if a different time in it is desired to be the start.
        //  如果希望以不同的时间作为开始，则偏移到循环动画的周期。
        public float cycleOffset { get; set; }

       
        //     Offset to the vertical root position.
        public float heightOffset { get; set; }
        

        //     Offset in degrees to the root rotation.
        public float rotationOffset { get; set; }
        

        //     Is the clip a looping animation?
        public bool loop { get; set; }

        /*
            The wrap mode of the animation.
            enum: Once, Loop, PingPong, Default, ClampForever
        */
        public WrapMode wrapMode { get; set; }

        
        //     Last frame of the clip.
        public float lastFrame { get; set; }
        

        //     First frame of the clip.
        public float firstFrame { get; set; }

        
        //     Clip name.
        public string name { get; set; }
        

        //     Take name.
        public string takeName { get; set; }

        /*
            The additive "reference pose frame".
            额外的 "参考姿势帧"

            The allow frame range is defines by the imported take time which mean that the "reference pose frame" 
            could be lower than "firstFrame" or greater than "lastFrame" time range.
            If you want to use another animation clip to define your reference pose you need to use "AnimationUtility.SetAdditiveReferencePose".

        */
        public float additiveReferencePoseFrame { get; set; }

        /*
            Copy the mask settings from an "AvatarMask" to the clip configuration.

            When writing an "AssetPostprocessor", use this method to copy an "AvatarMask" to your clip configuration.

            See also: ModelImporterClipAnimation.ConfigureMaskFromClip.

        // 参数:
        //   mask:
        //     AvatarMask from which the mask settings will be imported.
        */
        public void ConfigureClipFromMask(AvatarMask mask);


        /*
            Copy the current masking settings from the clip to an "AvatarMask".

            When writing an "AssetPostprocessor", use this method to copy the "AvatarMask" from your clip configuration so that you can modify it.

            Note: you will need to use "ModelImporterClipAnimation.ConfigureClipFromMask" to apply the "AvatarMask" back 
            on the "ModelImporterClipAnimation"

            See also: "ModelImporterClipAnimation.ConfigureClipFromMask".

        */
        public void ConfigureMaskFromClip(ref AvatarMask mask);



        public override bool Equals(object o);
        public override int GetHashCode();
    }
}

