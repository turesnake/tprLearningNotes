using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateShow : MonoBehaviour
{
    void OnDrawGizmos()  
    {  
        float radiusAxis = 0.2f;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right*radiusAxis);  
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up*radiusAxis);  
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward*radiusAxis); 
    }
}



