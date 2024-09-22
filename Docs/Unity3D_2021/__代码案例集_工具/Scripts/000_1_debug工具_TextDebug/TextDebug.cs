using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Engine.I18N;
using TMPro;



/*
    在屏幕上打印 log 信息, 无需在场景中准备 GameObjs 或 prefab;
    
    直接调用: 
        TextDebug.SetText( 3, "koko" );  
    即可;

    支持 TextDebug.textNum 行信息;
*/
public class TextDebug : MonoBehaviour
{
    List<TextMeshProUGUI> textComps = new List<TextMeshProUGUI>();

    // ================ Static ================= //
    public static bool isActive = true; // 能将本 class 的所有功能变哑

    static TextDebug textDebug = null; // 本地缓存引用
    public static int textNum = 14;
    static float totalScale = 1f; 
    static float fontSize = 35f;
    static float textLineHeight = 60f; // pix, 考虑进了行间距
    static float textLineWidthScale = 1f;

    // 将屏幕映射为一个 [-1,1] 坐标系: 左下角为 (-1,-1), 右上角为 (1,1)
    // 然后,
    // 用户可用本变量 设置 text绘制区域的 左上角的坐标; 以便让 text绘制区出现在屏幕上合适的位置;
    // 修改此值并不会修改 textDebugCanvas 尺寸, 只会移动 textDebugCanvas;
    static Vector2 leftTopUIPos = new Vector2( -0.9f, 0.9f );


    /// <summary>
    /// 在屏幕上打印信息
    /// </summary>
    /// <param name="idx_">行下标, 0-based</param>
    /// <param name="info_">要打印的信息</param>
    public static void SetText( int idx_, string info_ )
    {
        if( isActive == false )
        {
            return;
        }
        //---:
        TextDebug comp = FindOrCreate();
        if( idx_ >= comp.textComps.Count )
        {
            Debug.LogError( "idx过大: " + idx_ );
            return;
        }
        comp.textComps[idx_].text = info_;
    }



    static TextDebug FindOrCreate()
    {
        if( textDebug != null )
        {
            return textDebug;
        }
        Canvas uiCanvas = FindOrCreateUICanvas();
        textDebug = FindOrCreateTextDebugCanvas( uiCanvas.transform );
        return textDebug;
    }



    static Canvas FindOrCreateUICanvas()
    {
        /*
                uiCanvas_ForDebug 默认为全屏 canvas;
        */
        GameObject newGo = GameObject.Find("/uiCanvas_ForDebug"); // 非递归地在 root 层查找
        if( newGo == null )
        {
            newGo = new GameObject( "uiCanvas_ForDebug" );
        }
        newGo.layer = LayerMask.NameToLayer("UI");
        var canvasComp = KTool.GetOrAddComponent<Canvas>(newGo);
        var CanvasScalerComp = KTool.GetOrAddComponent<CanvasScaler>(newGo);
        canvasComp.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasComp.sortingOrder = 500; // 尽可能排在前面
        DontDestroyOnLoad(newGo);  // todo: 有待商榷
        return canvasComp;
    }


    static TextDebug FindOrCreateTextDebugCanvas( Transform parent_ )
    {
        /*
            textDebugCanvas 以自己的 左上角为 anchor, 且可通过设置 leftTopUIPos 来修改它在屏幕上的位置;
        */
        TextDebug textDebugComp = null;
        Transform textDebugCanvasTF = parent_.Find("textDebugCanvas");
        if( textDebugCanvasTF == null )
        {
            var newGo = new GameObject( "textDebugCanvas" );
            newGo.transform.parent = parent_;
            newGo.layer = LayerMask.NameToLayer("UI");

            Canvas textDebugCanvas = KTool.GetOrAddComponent<Canvas>(newGo);
            textDebugComp = KTool.GetOrAddComponent<TextDebug>(newGo);
            // ---:
            RectTransform canvasRTF = textDebugCanvas.transform as RectTransform;
            canvasRTF.sizeDelta = new Vector2( Screen.width * totalScale, Screen.height * totalScale ); // 全屏基础上缩放一定比例

            // 以 左上角 为 anchor, 
            canvasRTF.anchorMin = new Vector2( 0f, 1f );
            canvasRTF.anchorMax = new Vector2( 0f, 1f );
            canvasRTF.pivot = new Vector2( 0f, 1f );
            // 然后就能通过 RTF.anchoredPosition 来得到左上角的 posSS
            canvasRTF.anchoredPosition = GetLeftTopPosSS();

            for( int i=0; i<textNum; i++ )
            {
                textDebugComp.textComps.Add( CreateTextNode( textDebugCanvas, i ) );
            }
        }
        else 
        {   
            textDebugComp = textDebugCanvasTF.GetComponent<TextDebug>();
        }
        Debug.Assert( textDebugComp );
        return textDebugComp;
    }



    static TextMeshProUGUI CreateTextNode( Canvas parentCanvas_, int idx_ )
    {
        float topH = Screen.height * totalScale * 0.5f;
        float h = topH - (idx_+1) * textLineHeight;

        var newGo = new GameObject( "info_" + idx_.ToString() );
        newGo.transform.SetParent( parentCanvas_.transform );
        newGo.layer = LayerMask.NameToLayer("UI");

        var textComp = KTool.GetOrAddComponent<TextMeshProUGUI>(newGo);
        textComp.fontSize = fontSize;
        textComp.text = "-" + idx_ + ":";
        textComp.color = Color.white;
        textComp.alignment = TextAlignmentOptions.MidlineLeft;

        RectTransform rtf = textComp.transform as RectTransform;
        rtf.anchoredPosition3D = new Vector3( 0f, h, 0f );
        rtf.sizeDelta = new Vector2( Screen.width * textLineWidthScale, textLineHeight );

        return textComp;
    }


    static Vector2 GetLeftTopPosSS() 
    {
        Vector2 p = new Vector2(
            KTool.Remap( -1f, 1f, 0f, Screen.width,  Mathf.Clamp(leftTopUIPos.x,-1f,1f) ),
            KTool.Remap( -1f, 1f, 0f, Screen.height, Mathf.Clamp(leftTopUIPos.y,-1f,1f) )
        );
        return p - new Vector2(0f,Screen.height);
    }

    

}



