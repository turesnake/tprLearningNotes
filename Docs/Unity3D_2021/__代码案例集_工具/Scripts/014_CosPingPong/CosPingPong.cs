using UnityEngine;  



// pingpong 运动, 但是带有速度变化:Cos



public class CosPingPong : MonoBehaviour  
{  
    [Header("运动体")]
    public Transform target;
    [Header("起点终点")]
    public Transform startTF, endTF; 

    [Header("从起点走到终点的时长")]
    public float duration = 2f;  

    Vector3 startPosition;  
    Vector3 endPosition;  

    float elapsedTime = 0f;  
    bool isForward = true;  


    void Start()  
    {  
        startPosition = startTF.position;
        endPosition = endTF.position;
        // 初始化位置  
        target.position = startPosition;  
    }  

    void Update()  
    {  
        // 计算每帧的时间增量  
        elapsedTime += Time.deltaTime;  

        // 计算动画进度  
        float progress = elapsedTime / duration;  

        // 使用缓动函数计算当前进度  
        float easedProgress = EaseInOutSine(progress);  // [0f,1f]

        // 更新目标位置  
        target.position = Vector3.Lerp(startPosition, endPosition, easedProgress);  

        // 检查是否需要反转方向  
        if (progress >= 1f)  
        {  
            elapsedTime = 0f;  
            isForward = !isForward;  
            // 交换起始和结束位置  
            Vector3 temp = startPosition;  
            startPosition = endPosition;  
            endPosition = temp;  
        }  
    }  

    // 自定义缓动函数  
    // ret: [0f,1f]
    // 这么拗口地实现是为了保证在初始阶段, 一定先从 start 移动向 end;
    private float EaseInOutSine(float t)  
    {  
        return -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;  
    }  
}
