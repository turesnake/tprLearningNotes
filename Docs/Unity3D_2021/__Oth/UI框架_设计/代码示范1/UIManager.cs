

using System.Collections.Generic;
using UnityEngine;


/*
    使用说明:
    将 UIManager 挂到场景空物体，指定 uiRoot 为 Canvas 的变换节点
    将所有页面 prefab 和弹窗 prefab 放到 Resources 目录（示例简化加载方式）
    页面预制体上挂 UIPage 或继承类组件，弹窗挂 UIPopup
    通过 UIManager.Instance.OpenPage("PagePrefabName") 和 OpenPopup("PopupPrefabName") 来控制UI显示和切换
    关闭页面调 UIManager.Instance.ClosePage()，关闭弹窗用 UIManager.Instance.ClosePopup()

    这个示例框架简单明了，能满足基本页面和弹窗的切换管理，你可以扩展异步加载、动画过渡、缓存复用等功能。
    
*/
public class UIManager : MonoBehaviour
{
    // 单例模式，方便全局访问
    public static UIManager Instance;

    private Stack<UIPage> pageStack = new Stack<UIPage>();
    private List<UIPopup> popupList = new List<UIPopup>();

    // 所有预制体建议预先拖入管理或动态加载，这里简化为Resources加载
    public Transform uiRoot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 打开页面，关闭当前页并入栈新页面
    public void OpenPage(string pagePrefabName, object param = null)
    {
        if (pageStack.Count > 0)
        {
            var current = pageStack.Peek();
            current.OnHide();
        }

        var prefab = Resources.Load<GameObject>(pagePrefabName);
        var pageGO = Instantiate(prefab, uiRoot);
        var page = pageGO.GetComponent<UIPage>();

        pageStack.Push(page);
        page.OnShow(param);
    }

    // 关闭当前页面，显示上一个页面
    public void ClosePage()
    {
        if (pageStack.Count == 0) return;

        var topPage = pageStack.Pop();
        topPage.OnHide();
        Destroy(topPage.gameObject);

        if (pageStack.Count > 0)
        {
            var prev = pageStack.Peek();
            prev.OnShow();
        }
    }

    // 打开弹窗，支持多个弹窗叠加
    public void OpenPopup(string popupPrefabName, object param = null)
    {
        var prefab = Resources.Load<GameObject>(popupPrefabName);
        var popupGO = Instantiate(prefab, uiRoot);
        var popup = popupGO.GetComponent<UIPopup>();
        popupList.Add(popup);
        popup.OnShow(param);
    }

    // 关闭指定弹窗（默认关闭最上层弹窗）
    public void ClosePopup(UIPopup popup = null)
    {
        if (popupList.Count == 0) return;

        if (popup == null)
            popup = popupList[popupList.Count - 1];

        if (popupList.Contains(popup))
        {
            popup.OnHide();
            popupList.Remove(popup);
            Destroy(popup.gameObject);
        }
    }
}

