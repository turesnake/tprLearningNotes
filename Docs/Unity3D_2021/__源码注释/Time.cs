#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    //
    // 摘要:
    //     Provides an interface to get time information from Unity.
    [NativeHeaderAttribute("Runtime/Input/TimeManager.h")]
    [StaticAccessorAttribute("GetTimeManager()", Bindings.StaticAccessorType.Dot)]
    public class Time//Time__RR
    {
        public Time();

        //
        // 摘要:
        //     Slows your application’s playback time to allow Unity to save screenshots in
        //     between frames.
        public static float captureDeltaTime { get; set; }
        //
        // 摘要:
        //     The real time in seconds since the game started (Read Only). Double precision
        //     version of Time.realtimeSinceStartup.
        [NativePropertyAttribute("Realtime")]
        public static double realtimeSinceStartupAsDouble { get; }
        //
        // 摘要:
        //     The real time in seconds since the game started (Read Only).
        [NativePropertyAttribute("Realtime")]
        public static float realtimeSinceStartup { get; }
        [NativePropertyAttribute("RenderFrameCount")]
        public static int renderedFrameCount { get; }
        //
        // 摘要:
        //     The total number of frames since the start of the game (Read Only).
        public static int frameCount { get; }

        
        /*     
            The scale at which time passes.
            缩放游戏运动时间的 缩放因子. 
            若为1, 游戏正常运行, 若为0.5, 游戏世界运动速度慢一倍
            将影响 deltaTime
        */
        public static float timeScale { get; set; }


        //
        // 摘要:
        //     The maximum time a frame can spend on particle updates. If the frame takes longer
        //     than this, then updates are split into multiple smaller updates.
        public static float maximumParticleDeltaTime { get; set; }
        //
        // 摘要:
        //     A smoothed out Time.deltaTime (Read Only).
        public static float smoothDeltaTime { get; }
        //
        // 摘要:
        //     The maximum value of Time.deltaTime in any given frame. This is a time in seconds
        //     that limits the increase of Time.time between two frames.
        public static float maximumDeltaTime { get; set; }
        //
        // 摘要:
        //     The interval in seconds at which physics and other fixed frame rate updates (like
        //     MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.
        public static float fixedDeltaTime { get; set; }
        //
        // 摘要:
        //     The timeScale-independent interval in seconds from the last MonoBehaviour.FixedUpdate
        //     phase to the current one (Read Only).
        public static float fixedUnscaledDeltaTime { get; }


        /*     
            The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
            不受 Time.timeScale 的影响, 彻底正确的 deltaTime, 可用来测 fps 
        */
        public static float unscaledDeltaTime { get; }


        //
        // 摘要:
        //     The double precision timeScale-independent time at the beginning of the last
        //     MonoBehaviour.FixedUpdate (Read Only). This is the time in seconds since the
        //     start of the game.
        [NativePropertyAttribute("FixedUnscaledTime")]
        public static double fixedUnscaledTimeAsDouble { get; }
        //
        // 摘要:
        //     The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate
        //     phase (Read Only). This is the time in seconds since the start of the game.
        public static float fixedUnscaledTime { get; }
        //
        // 摘要:
        //     The double precision timeScale-independent time for this frame (Read Only). This
        //     is the time in seconds since the start of the game.
        [NativePropertyAttribute("UnscaledTime")]
        public static double unscaledTimeAsDouble { get; }
        //
        // 摘要:
        //     The timeScale-independent time for this frame (Read Only). This is the time in
        //     seconds since the start of the game.
        public static float unscaledTime { get; }
        //
        // 摘要:
        //     The double precision time since the last MonoBehaviour.FixedUpdate started (Read
        //     Only). This is the time in seconds since the start of the game.
        [NativePropertyAttribute("FixedTime")]
        public static double fixedTimeAsDouble { get; }
        //
        // 摘要:
        //     The time since the last MonoBehaviour.FixedUpdate started (Read Only). This is
        //     the time in seconds since the start of the game.
        public static float fixedTime { get; }
        

        /*     
            The interval in seconds from the last frame to the current one (Read Only).
            会受到 Time.timeScale 的影响; 
        */
        public static float deltaTime { get; }


        //
        // 摘要:
        //     The double precision time since this frame started (Read Only). This is the time
        //     in seconds since the last non-additive scene has finished loading.
        [NativePropertyAttribute("TimeSinceSceneLoad")]
        public static double timeSinceLevelLoadAsDouble { get; }
        //
        // 摘要:
        //     The time since this frame started (Read Only). This is the time in seconds since
        //     the last non-additive scene has finished loading.
        [NativePropertyAttribute("TimeSinceSceneLoad")]
        public static float timeSinceLevelLoad { get; }
        //
        // 摘要:
        //     The double precision time at the beginning of this frame (Read Only). This is
        //     the time in seconds since the start of the game.
        [NativePropertyAttribute("CurTime")]
        public static double timeAsDouble { get; }
        //
        // 摘要:
        //     The time at the beginning of this frame (Read Only).
        [NativePropertyAttribute("CurTime")]
        public static float time { get; }
        //
        // 摘要:
        //     The reciprocal of Time.captureDeltaTime.
        public static int captureFramerate { get; set; }
        //
        // 摘要:
        //     Returns true if called inside a fixed time step callback (like MonoBehaviour's
        //     MonoBehaviour.FixedUpdate), otherwise returns false.
        public static bool inFixedTimeStep { get; }
    }
}
