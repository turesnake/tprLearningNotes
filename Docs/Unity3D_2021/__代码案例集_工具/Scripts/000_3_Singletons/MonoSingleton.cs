using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    让 new bing 写的, 没细看, 有空看;
*/
public class MonoSingleton : MonoBehaviour
{
    private static MonoSingleton _instance;

    public static MonoSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MonoSingleton>();
                if (_instance == null)
                {
                    Debug.LogError("需手动在场景中配置 MonoSingleton 实例"); // !!! 若有需要的话
                    GameObject newgo = new GameObject();
                    _instance = newgo.AddComponent<MonoSingleton>();
                    newgo.name = "(MonoSingleton) " + typeof(MonoSingleton).ToString();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("禁止重复的 MonoSingleton 实例");
            Destroy(gameObject);
        }
    }
}

