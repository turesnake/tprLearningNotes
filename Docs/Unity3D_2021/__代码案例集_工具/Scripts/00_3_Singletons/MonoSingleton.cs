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
            Destroy(gameObject);
        }
    }
}

