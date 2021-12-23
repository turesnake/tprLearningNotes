
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        Determines how time is treated outside of "the keyframed range" of an "AnimationClip" or "AnimationCurve".

        The WrapMode that the animation system uses for a specific animation is determined this way:
            You can set the WrapMode of an "AnimationClip" in the import settings of the clip. 
            This is the recommended way to control the WrapMode.
            When an "AnimationState" is created, it inherits its WrapMode from the "AnimationClip" it is created from, 
            but you can also change it from code.
            If the WrapMode of an "AnimationState" is set to Default, 
            the animation system will use the WrapMode from the Animation component.


        enum: Default, Once, Clamp, Loop, PingPong, ClampForever;
    */
    public enum WrapMode//WrapMode__
    {
        /*
            Reads the default repeat mode set higher up.

            If you haven't changed wrapMode on "AnimationClip" or on "Animation", 
            then WrapMode.Default resolves to WrapMode.Once.
        */
        Default = 0,
        /*
            When time reaches the end of the animation clip, 
            the clip will automatically stop playing and time will be reset to beginning of the clip.

            Note that when playing backwards(倒放) and when the time reaches the beginning the clip will automatically stop playing, 
            but the time won't be reset to the end - it will be kept at the beginning.
        */
        Once = 1,
        Clamp = 1,

        /*
            When time reaches the end of the animation clip, time will continue at the beginning.

            When playing backwards(倒放) it will do the opposite - 
            it will jump to the end of the clip and continue from there. The animation will never automatically stop playing.
        */
        Loop = 2,

        /*
            When time reaches the end of the animation clip, time will ping pong back between beginning and end.

            It has same behaviour when playing backwards(倒放) - when time reaches the beginning of the animation clip, 
            time will ping pong back between beginning and end. The animation will never automatically stop playing.
        */
        PingPong = 4,

        /*
            Plays back the animation. 
            When it reaches the end, it will keep playing the last frame and never stop playing.

            When playing backwards(倒放) it will reach the first frame and will keep playing that. 
            This is useful for additive animations, which should never be stopped when they reach the maximum.
        */
        ClampForever = 8
    }
}

