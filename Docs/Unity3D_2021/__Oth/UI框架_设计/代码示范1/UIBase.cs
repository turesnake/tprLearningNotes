using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    /// <summary>
    /// 界面显示时调用，params用于传入参数
    /// </summary>
    public virtual void OnShow(object param = null)
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 界面隐藏时调用
    /// </summary>
    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }
}