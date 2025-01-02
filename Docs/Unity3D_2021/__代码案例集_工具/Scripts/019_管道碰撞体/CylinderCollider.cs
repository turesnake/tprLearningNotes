
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TprCylinderCollider : MonoBehaviour
{
    public int segmentNum = 6;
    public float innRadius = 0.5f,
                outRadius = 1f;
    public float zLen = 2f; // z轴深度

    

    void Start()
    {
        CreateCylinderColliders( transform, innRadius, outRadius, zLen, zLen*0.5f, segmentNum );
    }


    /*
        ---------------------------------------------------------
        沿着  rootTF_ 的 z轴生成一组 box collider, 组成一个 pipe;
    */
    public static void CreateCylinderColliders( Transform rootTF_, float innRadius_, float outRadius_, float zLen_, float zOffset_, int segmentNum_ )
    {
        Vector3 centerPos = rootTF_.position + rootTF_.forward * zOffset_;
        Quaternion rotation = rootTF_.rotation;

        List<Vector3> outPoses = new List<Vector3>();

        float angleStep = 360f / segmentNum_;  
        for (int i = 1; i <= segmentNum_; i++)  
        {  
            float angle = i * angleStep * Mathf.Deg2Rad;  
            Vector3 newPoint = centerPos + rotation * new Vector3(Mathf.Cos(angle) * outRadius_, Mathf.Sin(angle) * outRadius_, 0f); // 在local xy 平面上绘制椭圆  
            outPoses.Add(newPoint);
        } 
        Debug.Assert( outPoses.Count > 2 );

        float width = (outPoses[0] - outPoses[1]).magnitude * 1f;
        // ---
        float thickness = 0f;
        {
            Vector3 aPos = outPoses[0];
            Vector3 bPos = outPoses[1];
            Vector3 abMidPos = (aPos+bPos)*0.5f;
            thickness = (abMidPos-centerPos).magnitude - innRadius_;
            thickness = Mathf.Max( thickness, 0.01f );
        }

        outPoses.Add(outPoses[0]);
        for( int i=0; i<outPoses.Count-1; i++ )// i,i+1
        {
            Vector3 pos = (outPoses[i] + outPoses[i+1]) * 0.5f;
            Vector3 toInnDir = (centerPos-pos).normalized;
            // create:
            GameObject newgo = GameObject.CreatePrimitive( PrimitiveType.Cube ); // 自带 BoxCollider
            newgo.name = "cylinderBox_" + i;
            var tf = newgo.transform;
            tf.SetParent( rootTF_ );
            tf.position = pos + toInnDir * thickness * 0.5f;
            tf.rotation = Quaternion.LookRotation( rootTF_.forward, (pos-centerPos).normalized );
            tf.localScale =  new Vector3( width, thickness, zLen_ ); // !! 可能要设全局的 ?
        }  
    }


}


