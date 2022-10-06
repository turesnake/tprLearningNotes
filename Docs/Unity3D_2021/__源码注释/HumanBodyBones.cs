#region 程序集 UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AnimationModule.dll
#endregion

namespace UnityEngine
{
    /*
        Human Body Bones.

        Animator.GetBoneTransform() 的参数, 用来找到各个 骨骼的 transform 信息;

    */
    public enum HumanBodyBones
    {
        //
        // 摘要:
        //     This is the Hips bone. -- 臀部, (tpr, 有点 root 的概念, 是不是 root 不知道)
        Hips = 0,
        //
        // 摘要:
        //     This is the Left Upper Leg bone.
        LeftUpperLeg = 1,
        //
        // 摘要:
        //     This is the Right Upper Leg bone.
        RightUpperLeg = 2,
        //
        // 摘要:
        //     This is the Left Knee bone.
        LeftLowerLeg = 3,
        //
        // 摘要:
        //     This is the Right Knee bone.
        RightLowerLeg = 4,
        //
        // 摘要:
        //     This is the Left Ankle bone.
        LeftFoot = 5,
        //
        // 摘要:
        //     This is the Right Ankle bone.
        RightFoot = 6,
        //
        // 摘要:
        //     This is the first Spine bone. -- 脊柱的第一节; hips 的上面一节;
        Spine = 7,
        //
        // 摘要:
        //     This is the Chest bone. -- 脊柱的第二节, Spine 的上面一节
        Chest = 8,
        //
        // 摘要:
        //     This is the Neck bone. -- 脖子,  头部和 body 连接的那一节;
        Neck = 9,
        //
        // 摘要:
        //     This is the Head bone. -- 
        Head = 10,
        //
        // 摘要:
        //     This is the Left Shoulder bone. -- 左肩
        LeftShoulder = 11,
        //
        // 摘要:
        //     This is the Right Shoulder bone. -- 右肩
        RightShoulder = 12,
        //
        // 摘要:
        //     This is the Left Upper Arm bone.
        LeftUpperArm = 13,
        //
        // 摘要:
        //     This is the Right Upper Arm bone.
        RightUpperArm = 14,
        //
        // 摘要:
        //     This is the Left Elbow bone.
        LeftLowerArm = 15,
        //
        // 摘要:
        //     This is the Right Elbow bone.
        RightLowerArm = 16,
        //
        // 摘要:
        //     This is the Left Wrist bone.
        LeftHand = 17,
        //
        // 摘要:
        //     This is the Right Wrist bone.
        RightHand = 18,
        //
        // 摘要:
        //     This is the Left Toes bone. -- 左 足尖
        LeftToes = 19,
        //
        // 摘要:
        //     This is the Right Toes bone. -- 右 足尖
        RightToes = 20,
        //
        // 摘要:
        //     This is the Left Eye bone.
        LeftEye = 21,
        //
        // 摘要:
        //     This is the Right Eye bone.
        RightEye = 22,
        //
        // 摘要:
        //     This is the Jaw bone. -- 下巴, 下颌
        Jaw = 23,
        //
        // 摘要:
        //     This is the left thumb 1st phalange.
        LeftThumbProximal = 24,
        //
        // 摘要:
        //     This is the left thumb 2nd phalange.
        LeftThumbIntermediate = 25,
        //
        // 摘要:
        //     This is the left thumb 3rd phalange.
        LeftThumbDistal = 26,
        //
        // 摘要:
        //     This is the left index 1st phalange.
        LeftIndexProximal = 27,
        //
        // 摘要:
        //     This is the left index 2nd phalange.
        LeftIndexIntermediate = 28,
        //
        // 摘要:
        //     This is the left index 3rd phalange.
        LeftIndexDistal = 29,
        //
        // 摘要:
        //     This is the left middle 1st phalange.
        LeftMiddleProximal = 30,
        //
        // 摘要:
        //     This is the left middle 2nd phalange.
        LeftMiddleIntermediate = 31,
        //
        // 摘要:
        //     This is the left middle 3rd phalange.
        LeftMiddleDistal = 32,
        //
        // 摘要:
        //     This is the left ring 1st phalange.
        LeftRingProximal = 33,
        //
        // 摘要:
        //     This is the left ring 2nd phalange.
        LeftRingIntermediate = 34,
        //
        // 摘要:
        //     This is the left ring 3rd phalange.
        LeftRingDistal = 35,
        //
        // 摘要:
        //     This is the left little 1st phalange.
        LeftLittleProximal = 36,
        //
        // 摘要:
        //     This is the left little 2nd phalange.
        LeftLittleIntermediate = 37,
        //
        // 摘要:
        //     This is the left little 3rd phalange.
        LeftLittleDistal = 38,
        //
        // 摘要:
        //     This is the right thumb 1st phalange.
        RightThumbProximal = 39,
        //
        // 摘要:
        //     This is the right thumb 2nd phalange.
        RightThumbIntermediate = 40,
        //
        // 摘要:
        //     This is the right thumb 3rd phalange.
        RightThumbDistal = 41,
        //
        // 摘要:
        //     This is the right index 1st phalange.
        RightIndexProximal = 42,
        //
        // 摘要:
        //     This is the right index 2nd phalange.
        RightIndexIntermediate = 43,
        //
        // 摘要:
        //     This is the right index 3rd phalange.
        RightIndexDistal = 44,
        //
        // 摘要:
        //     This is the right middle 1st phalange.
        RightMiddleProximal = 45,
        //
        // 摘要:
        //     This is the right middle 2nd phalange.
        RightMiddleIntermediate = 46,
        //
        // 摘要:
        //     This is the right middle 3rd phalange.
        RightMiddleDistal = 47,
        //
        // 摘要:
        //     This is the right ring 1st phalange.
        RightRingProximal = 48,
        //
        // 摘要:
        //     This is the right ring 2nd phalange.
        RightRingIntermediate = 49,
        //
        // 摘要:
        //     This is the right ring 3rd phalange.
        RightRingDistal = 50,
        //
        // 摘要:
        //     This is the right little 1st phalange.
        RightLittleProximal = 51,
        //
        // 摘要:
        //     This is the right little 2nd phalange.
        RightLittleIntermediate = 52,
        //
        // 摘要:
        //     This is the right little 3rd phalange.
        RightLittleDistal = 53,
        //
        // 摘要:
        //     This is the Upper Chest bone. -- 脊柱第三节, Chest 的上面一节
        UpperChest = 54,

        
        // 摘要:
        //     This is the Last bone index delimiter. -- 猜测只是一个 尾元素识别符
        LastBone = 55
    }
}