

public class KTool
{

    /*
        每一帧都要调用:
        让 oldPos_ 跟随在 newPos_ 后边, 理想跟随距离 expectDistance_, 
        isSecondOrder 开启后响应会变快, 能更快地跟随在身后
    */
    public static Vector3 LazyFollow(Vector3 oldPos_, Vector3 newPos_, float expectDistance_, float deltaTime_, float followSpeed_ = 1f, bool isSecondOrder = true)
    {
        var move = newPos_ - oldPos_;
        float pct = isSecondOrder ? (move.sqrMagnitude / (expectDistance_ * expectDistance_)) : (move.magnitude / expectDistance_);
        if (pct > 1f)
        {
            return Vector2.Lerp(oldPos_, newPos_, Mathf.Clamp01(deltaTime_ * followSpeed_ * pct));
        }
        return oldPos_;
    }



}

