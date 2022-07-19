#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*
        MonoBehaviour.StartCoroutine() returns a Coroutine. Instances of this class are
        only used to reference these coroutines, and do not hold any exposed properties
        or functions.
        ---
        本 class 没有任何暴露的 属性或方法;

        A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes.
        ---
        协程是个函数, 可以暂停自己的执行(yield) 直到给定的 YieldInstruction 结束;

        通常的调用方式为:

            IEnumerator BBB()
            {
                ...
            }

            IEnumerator AAA()
            {
                ...
                yield return StartCoroutine("BBB");
                ...
            }

        StartCoroutine() 要么返回的东西被 yield return, 要么不处理 StartCoroutine() 返回的东西;
    */
    [NativeHeaderAttribute("Runtime/Mono/Coroutine.h")]
    [RequiredByNativeCodeAttribute]
    public sealed class Coroutine : YieldInstruction
    {
        ~Coroutine();
    }
}


