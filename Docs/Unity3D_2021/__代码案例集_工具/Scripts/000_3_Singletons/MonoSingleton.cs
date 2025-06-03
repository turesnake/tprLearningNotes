using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    让 new bing 写的, 没细看,
    简易项目实践中;
*/
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    var TClassName = typeof(T).ToString(); // "NameSpace.ClassName"
                    Debug.LogWarning("手动在场景中新建 MonoSingleton 实例: "+TClassName);
                    GameObject newgo = new GameObject();
                    _instance = newgo.AddComponent<T>();
                    newgo.name = "[MonoSingleton]." + TClassName; // "[MonoSingleton].NameSpace.ClassName"
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("禁止重复的 MonoSingleton 实例");
            Destroy(gameObject);
        }
    }
}

