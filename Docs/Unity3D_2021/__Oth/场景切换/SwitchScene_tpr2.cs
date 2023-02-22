using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



// 用一个按钮不停地切换 sceneNames 列表中的场景

// 这版特色: 原初场景也会被失去激活后被删除,
// 然后整个运行时只有两个场景: -1- 刚加载的新场景, -2-  DontDestroyOnLoad 场景


// 存在过的问题: 切换一次场景后按钮失效, 因为没有把原始场景中的 EventSystem 移动到 DontDestroyOnLoad 场景中...




public class SwitchScene_tpr2 : MonoBehaviour
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

        // 既然场景中存在 ui canvas, 那就一定存在 EventSystem;
        var eventSystemGO = GameObject.Find("EventSystem");
        Debug.Assert( eventSystemGO );

        //---:
        idx = 0;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(eventSystemGO);
        DontDestroyOnLoad(btn.transform.parent.gameObject);
        btn.onClick.AddListener(  WhenPushBtn );
    }

    void Update() 
    {
        // pc 测试用
        if( Input.GetKeyDown(KeyCode.K) )
        {
            WhenPushBtn();
        }  
    }


    public void WhenPushBtn()
    {
        StartCoroutine( Do() );
    }

    IEnumerator Do() 
    {
        var oldSceneStr = SceneManager.GetActiveScene().name;
        var newSceneStr = sceneNames[idx];
        Debug.Log( "old: " + oldSceneStr + "; new: " + newSceneStr );


        // !!!!!!!
        /*
            此实现目前存在问题:
            如果 新场景里有脚本在 Start() 阶段 new GameObject, 且未设置这个 new go 的 parent
            那么这个 new go 会默认被创建在 旧的 scene 中....

            然后新场景 完成异步加载, 然后删除 old scene, 连带把那些 new go 也都删除了...
        */

        

        // 加载 新场景, 并设为 active
        AsyncOperation ret = SceneManager.LoadSceneAsync(newSceneStr, LoadSceneMode.Additive);
        while( ret.isDone == false )
        {
            yield return null;
        }
        ret.allowSceneActivation = true;

        // 卸载旧场景
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
        yield break;
    }

}



