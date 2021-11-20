#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine
{
    /*
        摘要:
        The type of motion vectors that should be generated.
    */
    public enum MotionVectorGenerationMode
    {
        
        // 摘要:
        //     Use only camera movement to track motion.
        Camera = 0,
        
        // 摘要:
        //     Use a specific pass (if required) to track motion.
        Object = 1,
        
        // 摘要:
        //     Do not track motion. Motion vectors will be 0.
        ForceNoMotion = 2
    }
}

