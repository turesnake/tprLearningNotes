using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.LowLevel;



/*
    用户可向 playerLoop.subSystemList 数组中插入自定义的 PlayerLoopSystem, 来新增一个指定的 CustomUpdate();

    同这个方法可以将某些 update 代码拆分出来, 并指定它的执行时序;

    !! 但是这个方法无法修改各个 Update() 的帧率;

*/

public class CustomPlayLoopDemo : MonoBehaviour
{
    void Start()
    {
        // 在游戏开始时注册自定义的更新方法  
        RegisterCustomUpdate();          
    }

    void RegisterCustomUpdate()  
    {  
        // ===== 获取当前的 PlayerLoopSystem  =====
        var playerLoop = PlayerLoop.GetCurrentPlayerLoop();  

        // ===== 创建一个新的 PlayerLoopSystem =====
        var customSystem = new PlayerLoopSystem  
        {  
            type = typeof(CustomPlayLoopDemo),  
            updateDelegate = CustomUpdate  
        };  

        // ===== 将自定义系统添加到 PlayerLoop 中 =====
        var systems = playerLoop.subSystemList;  
        var newSystems = new PlayerLoopSystem[systems.Length + 1];  
        systems.CopyTo(newSystems, 0);  
        newSystems[systems.Length] = customSystem;  

        playerLoop.subSystemList = newSystems;  

        // ===== 设置更新循环 =====
        PlayerLoop.SetPlayerLoop(playerLoop);  
    }  

    void CustomUpdate()  
    {  
        // 这里是你的自定义更新逻辑  
        Debug.Log("Custom Update Logic");  
    }  
}







