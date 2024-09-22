using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
    脚本 Koko 的 配置文件;
    Koko 里直接开放 参数的缺点是, play模式运行时, 动态调整的参数无法及时保存;
    但在 ScriptableObject 配置文件里就可以; 而且还能被别的 Koko组件 复用;
    ---
    缺点就是 用户还需额外 新建一个 KokoData 配置文件, 然后在手动绑定它;
    所以我们改用 KokoEditor 来让这个过程变得便捷;
*/
[CreateAssetMenu(fileName = "volumetricCloudData", menuName = "KokoData")]
public class KokoData : ScriptableObject 
{


    [Header("--- 模块1 ---")]

    [Tooltip("控制云的疏密")]
    [SerializeField, Range(0f,3f)] float noiseStrength = 1f;

    
    static int _NoiseStrength = Shader.PropertyToID("_NoiseStrength");


    public void SetProperties(Material turbulenceMat)
    {
        turbulenceMat.SetFloat(_NoiseStrength, noiseStrength);
    }

}


