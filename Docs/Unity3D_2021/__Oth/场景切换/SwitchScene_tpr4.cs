using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



// 用一个按钮不停地切换 sceneNames 列表中的场景

// 这版特色: 原初场景没有被卸载;

// 最后准备一个 新的场景来扮演 "原初场景", 且不要把它放入 sceneNames 中;


// 潜在的问题: 切换一次场景后按钮失效, 因为没有把原始场景中的 EventSystem 移动到 DontDestroyOnLoad 场景中...
// 但是因为 在这一版实现中, 原初那个场景始终存在, 使得 EventSystem 一直能发挥作用


public class SwitchScene_tpr4 : MonoBehaviour
{


    public Button btn;
    public List<string> sceneNames = new List<string>();
    int idx = 0;

    void Start()
    {
        Debug.Log( btn );
        for( int i=sceneNames.Count-1; i>=0; i-- )
        {
            var s = sceneNames[i];
            if( s=="" )
            {
                Debug.LogError( "sceneNames 中出现空 字符串, 请检测" );
                sceneNames.RemoveAt(i);
            }
        }
        Debug.Assert( sceneNames.Count > 0 );


        //---:
        idx = 0;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(btn.transform.parent.gameObject);
        btn.onClick.AddListener(  WhenPushBtn );
        SceneManager.sceneLoaded += ChangedActiveScene;
    }

    void Update() 
    {
        if( Input.GetKeyDown(KeyCode.K) )
        {
            WhenPushBtn();
        }    
    }


    void WhenPushBtn() 
    {
        var newSceneStr = sceneNames[idx];

        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(newSceneStr, LoadSceneMode.Additive);

        for( int i=SceneManager.sceneCount-1; i>=0; i-- )
        {
            var se = SceneManager.GetSceneAt(i);
            if( se.name != newSceneStr )
            {
                SceneManager.UnloadSceneAsync(se.name);
            }
        }

        //---:
        idx++;
        if( idx > sceneNames.Count-1 )
        {
            idx = 0;
        }
    }


    void ChangedActiveScene(Scene scene_, LoadSceneMode mode_ )
    {
        SceneManager.SetActiveScene( scene_ );   
    }

}
