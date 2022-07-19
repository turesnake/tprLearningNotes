#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections;
using UnityEngine.Internal;

namespace UnityEngine
{
    //
    // 摘要:
    //     MonoBehaviour is the base class from which every Unity script derives.
    [ExtensionOfNativeClassAttribute]
    [NativeHeaderAttribute("Runtime/Scripting/DelayedCallUtility.h")]
    [NativeHeaderAttribute("Runtime/Mono/MonoBehaviour.h")]
    [RequiredByNativeCodeAttribute]
    public class MonoBehaviour : Behaviour
    {
        public MonoBehaviour();

        //
        // 摘要:
        //     Disabling this lets you skip the GUI layout phase.
        public bool useGUILayout { get; set; }
        //
        // 摘要:
        //     Allow a specific instance of a MonoBehaviour to run in edit mode (only available
        //     in the editor).
        public bool runInEditMode { get; set; }

        //
        // 摘要:
        //     Logs message to the Unity Console (identical to Debug.Log).
        //
        // 参数:
        //   message:
        public static void print(object message);
        //
        // 摘要:
        //     Cancels all Invoke calls with name methodName on this behaviour.
        //
        // 参数:
        //   methodName:
        public void CancelInvoke(string methodName);
        //
        // 摘要:
        //     Cancels all Invoke calls on this MonoBehaviour.
        public void CancelInvoke();
        //
        // 摘要:
        //     Invokes the method methodName in time seconds.
        //
        // 参数:
        //   methodName:
        //
        //   time:
        public void Invoke(string methodName, float time);
        //
        // 摘要:
        //     Invokes the method methodName in time seconds, then repeatedly every repeatRate
        //     seconds.
        //
        // 参数:
        //   methodName:
        //
        //   time:
        //
        //   repeatRate:
        public void InvokeRepeating(string methodName, float time, float repeatRate);
        //
        // 摘要:
        //     Is any invoke on methodName pending?
        //
        // 参数:
        //   methodName:
        public bool IsInvoking(string methodName);
        //
        // 摘要:
        //     Is any invoke pending on this MonoBehaviour?
        public bool IsInvoking();
        //
        // 摘要:
        //     Starts a coroutine named methodName.
        //
        // 参数:
        //   methodName:
        //
        //   value:
        [ExcludeFromDocs]
        public Coroutine StartCoroutine(string methodName);
        //
        // 摘要:
        //     Starts a Coroutine.
        //
        // 参数:
        //   routine:
        public Coroutine StartCoroutine(IEnumerator routine);
        //
        // 摘要:
        //     Starts a coroutine named methodName.
        //
        // 参数:
        //   methodName:
        //
        //   value:
        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);
        [Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", false)]
        public Coroutine StartCoroutine_Auto(IEnumerator routine);
        //
        // 摘要:
        //     Stops all coroutines running on this behaviour.
        public void StopAllCoroutines();



        /*
            Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.
            ---
            要么用 string name 找到的第一个 协程;
            要么存储在本 behaviour 的 routine 内的协程;

            StopCoroutine takes one of three arguments which specify which coroutine is stopped:

            
            Note: 
            Do not mix the three arguments. If a string is used as the argument in StartCoroutine, use the string in StopCoroutine. 
            Similarly, use the IEnumerator in both StartCoroutine and StopCoroutine. 
            Finally, use StopCoroutine with the Coroutine used for creation.
            ---
            本函数选用哪个版本, 要和对应的 StartCoroutine() 一一对应;

            例如:
            ===== 1: IEnumerator 版参数 =====:
                public IEnumerator WAAA( int i )
                {
                    ...
                }
                IEnumerator coroutine = WAAA( 15 );

                StartCoroutine(coroutine);
                ...
                StopCoroutine(coroutine);

            
            ===== 2: Coroutine 版参数 =====:
                IEnumerator WAAA()
                {
                    ...
                }

                Coroutine c = StartCoroutine(WAAA());
                ...
                StopCoroutine( c );

            参数:
            methodName:
                Name of coroutine.
            
            routine:
                Name of the function in code, including coroutines.
        */
        public void StopCoroutine(IEnumerator routine); // The IEnumerator variable used earlier to create the coroutine.
        public void StopCoroutine(Coroutine routine); // 参数是 StartCoroutine() 的返回值
        public void StopCoroutine(string methodName); // A string function naming the active coroutine


    }
}








