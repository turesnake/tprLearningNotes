#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

using System;
using UnityEngine.Internal;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine
{
    //
    // 摘要:
    //     AvatarMask is used to mask out humanoid body parts and transforms.
    [MovedFrom(true, "UnityEditor.Animations", "UnityEditor", null)]
    [NativeHeaderAttribute("Modules/Animation/AvatarMask.h")]
    [NativeHeaderAttribute("Modules/Animation/ScriptBindings/Animation.bindings.h")]
    [UsedByNativeCodeAttribute]
    public sealed class AvatarMask//AvatarMask__RR
        : Object
    {
        //
        // 摘要:
        //     Creates a new AvatarMask.
        public AvatarMask();


        /*
        //     The number of humanoid body parts.
        [Obsolete("AvatarMask.humanoidBodyPartCount is deprecated, use AvatarMaskBodyPart.LastBodyPart instead.")]
        public int humanoidBodyPartCount { get; }
        */


        //
        // 摘要:
        //     Number of transforms.
        public int transformCount { get; set; }

        public void AddTransformPath(Transform transform);
        //
        // 摘要:
        //     Adds a transform path into the AvatarMask.
        //
        // 参数:
        //   transform:
        //     The transform to add into the AvatarMask.
        //
        //   recursive:
        //     Whether to also add all children of the specified transform.
        public void AddTransformPath([NotNullAttribute("ArgumentNullException")] Transform transform, [DefaultValue("true")] bool recursive);
        //
        // 摘要:
        //     Returns true if the humanoid body part at the given index is active.
        //
        // 参数:
        //   index:
        //     The index of the humanoid body part.
        [NativeMethodAttribute("GetBodyPart")]
        public bool GetHumanoidBodyPartActive(AvatarMaskBodyPart index);
        //
        // 摘要:
        //     Returns true if the transform at the given index is active.
        //
        // 参数:
        //   index:
        //     The index of the transform.
        public bool GetTransformActive(int index);
        //
        // 摘要:
        //     Returns the path of the transform at the given index.
        //
        // 参数:
        //   index:
        //     The index of the transform.
        public string GetTransformPath(int index);
        public void RemoveTransformPath(Transform transform);
        //
        // 摘要:
        //     Removes a transform path from the AvatarMask.
        //
        // 参数:
        //   transform:
        //     The Transform that should be removed from the AvatarMask.
        //
        //   recursive:
        //     Whether to also remove all children of the specified transform.
        public void RemoveTransformPath([NotNullAttribute("ArgumentNullException")] Transform transform, [DefaultValue("true")] bool recursive);
        //
        // 摘要:
        //     Sets the humanoid body part at the given index to active or not.
        //
        // 参数:
        //   index:
        //     The index of the humanoid body part.
        //
        //   value:
        //     Active or not.
        [NativeMethodAttribute("SetBodyPart")]
        public void SetHumanoidBodyPartActive(AvatarMaskBodyPart index, bool value);
        //
        // 摘要:
        //     Sets the tranform at the given index to active or not.
        //
        // 参数:
        //   index:
        //     The index of the transform.
        //
        //   value:
        //     Active or not.
        public void SetTransformActive(int index, bool value);
        //
        // 摘要:
        //     Sets the path of the transform at the given index.
        //
        // 参数:
        //   index:
        //     The index of the transform.
        //
        //   path:
        //     The path of the transform.
        public void SetTransformPath(int index, string path);
    }
}

