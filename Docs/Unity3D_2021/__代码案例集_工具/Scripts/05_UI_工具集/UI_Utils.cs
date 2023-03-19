using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Engine.Lib;




public class UI_Utils
{
    
    public static bool IsInScreen( Vector2 anchoredPosition_, float deadZoneWidth_ )
    {
        float halfW = 0.5f * (float)Screen.width - deadZoneWidth_;
        float halfH = 0.5f * (float)Screen.height - deadZoneWidth_;

        bool isOuter = (   
                    anchoredPosition_.x < -halfW
                ||  anchoredPosition_.x >  halfW
                ||  anchoredPosition_.y < -halfH
                ||  anchoredPosition_.y >  halfH
        );
        return !isOuter;
    }



    /// <summary>
    ///   计算出 anchoredPosition: 屏幕中间为 {0,0}, 单位为屏幕像素;
    ///   此方法存在一个问题: anchoredPosition 仅仅是 ui 元素的 local pos, 当它的 父节点发生偏移, 子 ui 也会受到影响
    ///   推荐使用下方的 CalculateUIGlobalPosition()
    /// </summary>
    /// <param name="tgtCamera_"></param>
    /// <param name="targetPos_"></param>
    /// <param name="heightOffset_"></param>
    /// <returns></returns>
    public static Vector2 CalculateAnchoredPosition( Camera tgtCamera_, Vector3 targetPos_, float heightOffset_ ) 
    {
        Vector3 posWS = targetPos_;
        posWS.y = posWS.y + heightOffset_;
        Vector3 uiPos = tgtCamera_.WorldToScreenPoint( posWS );
        uiPos.x = uiPos.x - 0.5f * (float)Screen.width; // 居中
        uiPos.y = uiPos.y - 0.5f * (float)Screen.height; // 居中
        return new Vector2( uiPos.x, uiPos.y );
    }


    /// <summary>
    ///  找到一个 ui 元素的 顶层 canvas, 然后得到它所在的 quad (长方体) 的四个 corner 的 posWS
    /// </summary>
    /// <param name="ui_">目标 ui 元素</param>
    /// <param name="leftBottomPosWS_"> root canvas quad left-bottom posWS </param>
    /// <param name="rightTopPosWS_"> root canvas quad right-top posWS </param>
    public static void GetRootCanvasCornersInfo( RectTransform ui_, out Vector3 leftBottomPosWS_, out Vector3 rightTopPosWS_  ) 
    {
        Canvas rootCanvas = ui_.GetComponentInParent<Canvas>().rootCanvas;
        Debug.Assert( rootCanvas, "ui 元素的父层级里 怎么可能没找到 Canvas ???" );
        Vector3[] rootCanvasFourCorners = new Vector3[4];
        rootCanvas.rectTransform().GetWorldCorners( rootCanvasFourCorners );
        leftBottomPosWS_ = rootCanvasFourCorners[0];
        rightTopPosWS_   = rootCanvasFourCorners[2];
    }


    /// <summary>
    /// 将世界坐标 targetPos_ 转换为 ui-space pos (的 posWS 版表达), 然后直接将返回值设置给 ui.transform.position 即可;
    /// 本函数是 CalculateUILocalAnchoredPosition() 的改良版; 可有效克服 ui元素的 父节点存在偏移 而导致的问题;
    /// ---
    /// 实现思路是找到 ui元素的 顶层 canvas, 基于这个 canvas 的四个顶点, 手动计算出 ui元素的 transform.position
    /// </summary>
    /// <param name="tgtCamera_"></param>
    /// <param name="targetPos_"></param>
    /// <param name="heightOffset_"> 在 targetPos_ 基础上做 y 轴偏移 </param>
    /// <param name="rootCanvasleftBottomPosWS_"> ui元素所在的 root canvas 的 quad 的左下角 posWS </param>
    /// <param name="rootCanvasrightTopPosWS_"> ui元素所在的 root canvas 的 quad 的右上角 posWS </param>
    /// <returns></returns>
    public static Vector3 CalculateUIGlobalPositionWS( Camera tgtCamera_, Vector3 targetPos_, float heightOffset_, 
        Vector3 rootCanvasleftBottomPosWS_, Vector3 rootCanvasrightTopPosWS_ 
    ){
        Vector3 posWS = targetPos_;
        posWS.y = posWS.y + heightOffset_;
        Vector3 uiPos = tgtCamera_.WorldToScreenPoint( posWS );
        uiPos.x /= (float)Screen.width;
        uiPos.y /= (float)Screen.height;
        uiPos.z = 0f;
        // new uiPos: [0f,1f]

        Vector3 rootCanvasDiagonalOffset = rootCanvasrightTopPosWS_ - rootCanvasleftBottomPosWS_;
        return rootCanvasleftBottomPosWS_ + 
                new Vector3( 
                    rootCanvasDiagonalOffset.x * uiPos.x,
                    rootCanvasDiagonalOffset.y * uiPos.y,
                    rootCanvasDiagonalOffset.z * uiPos.z
                 );
    }


}


