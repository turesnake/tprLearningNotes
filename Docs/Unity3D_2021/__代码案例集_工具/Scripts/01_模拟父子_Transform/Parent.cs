using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    在场景中新建两个 go: goParent 和 goChild; 两者为平级关系. 
    为 goChild 加载本脚本, 并将 m_parent 手动设置为 goParent
    ---
    在运行时, 当在 scene 界面 平移/旋转/缩放 goParent, 
    goChild 将会做出 符合父子层级关系的变化
    ---
    缺陷:
    goChild 自身的 local 属性, 以及最初与 goParent 间的关系信息,
    在一开始被写死在了 变量中, 暂不支持 运行时 动态修改 goChild 的这些信息
*/

public class Parent : MonoBehaviour
{
    [SerializeField]
    Transform m_parent;

    // 一开始就被写死的信息
    Vector3 m_localPosition; // m_parent.pos -> self.pos (未归一化)
    Vector3 m_localScale;    // self.localScale

    void Start()
    {
        m_localPosition = transform.position - m_parent.position;
        m_localScale = transform.localScale;
    }


    void Update()
    {
        // 这三项的先后顺序 相互独立 

        // ----- rotation ----- //
        transform.localRotation = m_parent.transform.localRotation * Quaternion.Euler(m_localPosition);

        // ----- scale ----- //
        transform.localScale = Vector3.Scale( m_parent.localScale, m_localScale );

        // ----- position ----- //
        transform.localPosition = m_parent.localPosition +
            m_parent.localRotation * 
            Vector3.Scale( m_parent.localScale, m_localPosition );
    }
}
