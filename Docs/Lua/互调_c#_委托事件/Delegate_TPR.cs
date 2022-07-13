using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using XLua;


[LuaCallCSharp]
public class Delegate_TPR
{
    public delegate void ActionString(string arg);
    public ActionString actionString1;

    public void AddAction(ActionString action)
    {
        Debug.Log("添加了一个委托");
        this.actionString1 = action;
        actionString1("C# Call");
    }

    // 下面这几个委托, 会被 lua 层调用;
    public ActionString actionString10 = (arg) =>
    {
        Debug.Log("actionString10:" + arg);
    };

    public ActionString actionString11 = (arg) =>
    {
        Debug.Log("actionString11:" + arg);
    };

    public ActionString actionString12 = (arg) =>
    {
        Debug.Log("actionString12:" + arg);
    };
}

