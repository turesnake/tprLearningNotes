using UnityEngine;
using XLua;


/*

在访问C#事件的时候需要生成代码，所以必须要为事件的委托类型加上一个Attribute：
[CSharpCallLua]，关于为什么这里需要加 [CSharpCallLua] 而不是 [LuaCallCSharp]，
GitHub:https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/faq.md#luacallsharp以及csharpcalllua

看调用者和被调用者，比如要在lua调用C#的GameObject.Find函数，或者调用gameobject的实例方法，属性等，GameObject类要加 LuaCallSharp，
而想把一个 lua 函数挂到 UI 回调，这是调用者是 C#，被调用的是一个 lua 函数，所以回调声明的 delegate 要加 CSharpCallLua。

有时会比较迷惑人，比如List.Find(Predicate match)的调用，List当然是加LuaCallSharp，而Predicate却要加CSharpCallLua，
因为match的调用者在C#，被调用的是一个lua函数。
*/



[LuaCallCSharp]
public class Event_TPR
{
    [CSharpCallLua]
    public delegate void TestDelegate();

    // event 本身, 将在 lua 中被添加多个成员;
    public event TestDelegate Events;


    // 这两个函数, 将在 lua 中被添加到 event 中
    public TestDelegate action1 = () =>
    {
        Debug.Log("触发了action1");
    };
    public TestDelegate action2 = () =>
    {
        Debug.Log("触发了action2");
    };


    // 将在 lua 中被触发 event
    public void TriggerEvent()
    {
        Events();
    }
}


