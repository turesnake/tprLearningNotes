# ================================================ #
#          ui 面向 camera
# ================================================ #


# ---------------------------- #
# 方法 -1-:
#          ui 元素放在 world-space 中
# ---------------------------- #

    Transform tf_; // 要处理的 ui 元素
    var tgtCamera = Camera.main;
    tf_.LookAt( tf_.position + tgtCamera.transform.rotation * Vector3.back, tgtCamera.transform.rotation * Vector3.up);
    tf_.Rotate( 0f, 180f, 0f );

# ---------------------------- #
# 方法 -2-:
#          ui 元素放在 ui-space 中
# ---------------------------- #

# 这个方案的问题在于, 如果相机使用了 cinemachine, 计算出来的 uipos 会抖动;
# 以下是处理方案:

# -1-
    RectTransform uiTF_;  // ui 元素
    Transform pointTF_;   // world-space 中要放置的位置

    var tgtCamera = Camera.main;
    float w = (float)Screen.width;
    float h = (float)Screen.height;

    Vector3 uiPos = tgtCamera.WorldToScreenPoint( pointTF_.position );

    uiPos.x = uiPos.x - 0.5f * w;
    uiPos.y = uiPos.y - 0.5f * h;
    uiPos.z = 4f;

    Debug.Log( uiPos.ToString() );

    uiTF_.anchoredPosition = new Vector2( uiPos.x, uiPos.y );

# -2-
    上述计算放在 LateUpdate() 中

# -3-
    同时 在 project settings - Script Execution Order 面板中, 添加本脚本, 
	将本脚本时序排在 cinemachine 的后面;
    ( 也可以修改 meta 文件, 或添加 [DefaultExecutionOrder(115)] attribute 来实现 )















































