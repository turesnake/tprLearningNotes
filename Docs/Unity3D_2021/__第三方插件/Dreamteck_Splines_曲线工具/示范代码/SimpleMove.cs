using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Dreamteck.Splines;

/*
    让物体沿着 spline 匀速运动

    仅使用 SplineComputer 即可实现;
*/

public class SimpleMove : MonoBehaviour
{
    public SplineComputer computer;
    public float speed = 1f;
    float splineLength;
    bool isMoving = false;


    void Start()
    {
        Debug.Assert( computer  );
        splineLength = computer.CalculateLength();
    }


    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Q) && isMoving == false )
        {
            StartCoroutine( Move2() );
        }
    }

    IEnumerator Move2() 
    {
        isMoving = true;
        for( float t = 0f; t<=1.0f;  t += speed * Time.deltaTime )
        {
            double travel = computer.Travel(0.0, splineLength * t, Spline.Direction.Forward); // 内部 t 值
            Vector3 pos = computer.EvaluatePosition(travel);
            transform.position = pos;
            yield return null;
        }
        isMoving = false;
    }
    
}
