#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine.Internal;



namespace UnityEngine
{
    //
    // 摘要:
    //     Class containing methods to ease debugging while developing a game.
    [NativeHeaderAttribute("Runtime/Export/Debug/Debug.bindings.h")]
    public class Debug
    {
        public Debug();

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Debug.logger is obsolete. Please use Debug.unityLogger instead (UnityUpgradable) -> unityLogger")]
        // public static ILogger logger { get; }

        //
        // 摘要:
        //     Reports whether the development console is visible. The development console cannot
        //     be made to appear using:
        public static bool developerConsoleVisible { get; set; }
        //
        // 摘要:
        //     Get default debug logger.
        public static ILogger unityLogger { get; }
        //
        // 摘要:
        //     In the Build Settings dialog there is a check box called "Development Build".
        [NativePropertyAttribute(TargetType = Bindings.TargetType.Field)]
        [StaticAccessorAttribute("GetBuildSettings()", Bindings.StaticAccessorType.Dot)]
        public static bool isDebugBuild { get; }

        // [Conditional("UNITY_ASSERTIONS")]
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // [Obsolete("Assert(bool, string, params object[]) is obsolete. Use AssertFormat(bool, string, params object[]) (UnityUpgradable) -> AssertFormat(*)", true)]
        // public static void Assert(bool condition, string format, params object[] args);


        /*
            Assert a condition and logs an error message to the Unity console on failure.

            Note that these methods work only if "UNITY_ASSERTIONS" symbol is defined. 
            This means that if you are building assemblies externally, you need to define this symbol otherwise the call becomes a no-op.

            打包表明, 若不手动定义 UNITY_ASSERTIONS, 在 release 包体中, 本函数体内的 代码会被彻底忽视掉;
            
            参数:
            condition:
                Condition you expect to be true.
            
            context:
                Object to which the message applies.
            
            message:
                String or object to be converted to string representation for display.
        */
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition, string message, Object context);
        
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition);
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition, object message, Object context);
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition, string message);
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition, object message);
        [Conditional("UNITY_ASSERTIONS")]
        public static void Assert(bool condition, Object context);



        //
        // 摘要:
        //     Assert a condition and logs a formatted error message to the Unity console on
        //     failure.
        //
        // 参数:
        //   condition:
        //     Condition you expect to be true.
        //
        //   format:
        //     A composite format string.
        //
        //   args:
        //     Format arguments.
        //
        //   context:
        //     Object to which the message applies.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AssertFormat(bool condition, Object context, string format, params object[] args);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AssertFormat(bool condition, string format, params object[] args);


        //
        // 摘要:
        //     Pauses the editor.
        [FreeFunctionAttribute("PauseEditor")]
        public static void Break();


        //
        // 摘要:
        //     Clears errors from the developer console.
        public static void ClearDeveloperConsole();

        public static void DebugBreak();


        //
        // 摘要:
        //     Draws a line between specified start and end points.
        //
        // 参数:
        //   start:
        //     Point in world space where the line should start.
        //
        //   end:
        //     Point in world space where the line should end.
        //
        //   color:
        //     Color of the line.
        //
        //   duration:
        //     How long the line should be visible for.
        //
        //   depthTest:
        //     Should the line be obscured by objects closer to the camera?
        [ExcludeFromDocs]
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration);

        [ExcludeFromDocs]
        public static void DrawLine(Vector3 start, Vector3 end, Color color);

        [ExcludeFromDocs]
        public static void DrawLine(Vector3 start, Vector3 end);

        [FreeFunctionAttribute("DebugDrawLine", IsThreadSafe = true)]
        public static void DrawLine(Vector3 start, Vector3 end, [Internal.DefaultValue("Color.white")] Color color, [Internal.DefaultValue("0.0f")] float duration, [Internal.DefaultValue("true")] bool depthTest);
        
        
        //
        // 摘要:
        //     Draws a line from start to start + dir in world coordinates.
        //
        // 参数:
        //   start:
        //     Point in world space where the ray should start.
        //
        //   dir:
        //     Direction and length of the ray.
        //
        //   color:
        //     Color of the drawn line.
        //
        //   duration:
        //     How long the line will be visible for (in seconds).
        //
        //   depthTest:
        //     Should the line be obscured by other objects closer to the camera?
        [ExcludeFromDocs]
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration);

        [ExcludeFromDocs]
        public static void DrawRay(Vector3 start, Vector3 dir, Color color);

        public static void DrawRay(Vector3 start, Vector3 dir, [Internal.DefaultValue("Color.white")] Color color, [Internal.DefaultValue("0.0f")] float duration, [Internal.DefaultValue("true")] bool depthTest);

        [ExcludeFromDocs]
        public static void DrawRay(Vector3 start, Vector3 dir);


        //
        // 摘要:
        //     Populate an unmanaged buffer with the current managed call stack as a sequence
        //     of UTF-8 bytes, without allocating GC memory. Returns the number of bytes written
        //     into the buffer.
        //
        // 参数:
        //   buffer:
        //     Target buffer to receive the callstack text
        //
        //   bufferMax:
        //     Max number of bytes to write
        //
        //   projectFolder:
        //     Project folder path, to clean up path names
        [ThreadSafeAttribute]
        public static int ExtractStackTraceNoAlloc(byte* buffer, int bufferMax, string projectFolder);

        //
        // 摘要:
        //     Logs a message to the Unity Console.
        //
        // 参数:
        //   message:
        //     String or object to be converted to string representation for display.
        //
        //   context:
        //     Object to which the message applies.
        public static void Log(object message, Object context);
        public static void Log(object message);


        //
        // 摘要:
        //     A variant of Debug.Log that logs an assertion message to the console.
        //
        // 参数:
        //   message:
        //     String or object to be converted to string representation for display.
        //
        //   context:
        //     Object to which the message applies.
        [Conditional("UNITY_ASSERTIONS")]
        public static void LogAssertion(object message, Object context);
        [Conditional("UNITY_ASSERTIONS")]
        public static void LogAssertion(object message);


        //
        // 摘要:
        //     Logs a formatted assertion message to the Unity console.
        //
        // 参数:
        //   format:
        //     A composite format string.
        //
        //   args:
        //     Format arguments.
        //
        //   context:
        //     Object to which the message applies.
        [Conditional("UNITY_ASSERTIONS")]
        public static void LogAssertionFormat(Object context, string format, params object[] args);
        [Conditional("UNITY_ASSERTIONS")]
        public static void LogAssertionFormat(string format, params object[] args);


        //
        // 摘要:
        //     A variant of Debug.Log that logs an error message to the console.
        //
        // 参数:
        //   message:
        //     String or object to be converted to string representation for display.
        //
        //   context:
        //     Object to which the message applies.
        public static void LogError(object message);
        public static void LogError(object message, Object context);

        //
        // 摘要:
        //     Logs a formatted error message to the Unity console.
        //
        // 参数:
        //   format:
        //     A composite format string.
        //
        //   args:
        //     Format arguments.
        //
        //   context:
        //     Object to which the message applies.
        public static void LogErrorFormat(string format, params object[] args);
        public static void LogErrorFormat(Object context, string format, params object[] args);

        //
        // 摘要:
        //     A variant of Debug.Log that logs an error message to the console.
        //
        // 参数:
        //   context:
        //     Object to which the message applies.
        //
        //   exception:
        //     Runtime Exception.
        public static void LogException(Exception exception);
        public static void LogException(Exception exception, Object context);


        //
        // 摘要:
        //     Logs a formatted message to the Unity Console.
        //
        // 参数:
        //   format:
        //     A composite format string.
        //
        //   args:
        //     Format arguments.
        //
        //   context:
        //     Object to which the message applies.
        //
        //   logType:
        //     Type of message e.g. warn or error etc.
        //
        //   logOptions:
        //     Option flags to treat the log message special.
        public static void LogFormat(Object context, string format, params object[] args);
        public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args);
        public static void LogFormat(string format, params object[] args);


        //
        // 摘要:
        //     A variant of Debug.Log that logs a warning message to the console.
        //
        // 参数:
        //   message:
        //     String or object to be converted to string representation for display.
        //
        //   context:
        //     Object to which the message applies.
        public static void LogWarning(object message, Object context);
        public static void LogWarning(object message);


        //
        // 摘要:
        //     Logs a formatted warning message to the Unity Console.
        //
        // 参数:
        //   format:
        //     A composite format string.
        //
        //   args:
        //     Format arguments.
        //
        //   context:
        //     Object to which the message applies.
        public static void LogWarningFormat(Object context, string format, params object[] args);
        public static void LogWarningFormat(string format, params object[] args);
    }
}

