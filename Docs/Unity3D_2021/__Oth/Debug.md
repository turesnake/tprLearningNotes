

# ----------------------------------------------#
#        Debug.DrawRay()
# ----------------------------------------------#
    void DrawRay(
        Vector3 start, 
        Vector3 dir,    // 虽然名为方向,其实也记录了射线的长度, 所以可以弄长点(远)
        Color color = Color.white, 
        float duration = 0.0f, // 射线存在的时间, 最好设长点
        bool depthTest = true
    );

可用来检测 碰撞点之类的:

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(
                contact.point, 
                contact.normal * 10f, 
                Color.red,
                10f
            );
        }
    }





