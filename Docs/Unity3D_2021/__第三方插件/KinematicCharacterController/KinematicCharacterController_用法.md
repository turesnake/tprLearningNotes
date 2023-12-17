# =================================================================== #
#          KinematicCharacterController 用法
# =================================================================== #


# 官方文档:
https://docs.google.com/document/d/1sdWOHE6vJcsOLE2jxHLVs_Y170NT309C4DbPmmdmqAM/edit?pli=1#heading=h.71hwyqucpo32




# 源码注释:
目前 注释直接写在: 
    ThirdPerson_urp_1B3_KController

    项目中,  未来再拿出来


# 整个系统一共就 3 个 MonoBehaviour:
    KinematicCharacterSystem
    KinematicCharacterMotor
    PhysicsMover





# ------------------------- #
#     术语: `Ledge`
# ------------------------- #
gpt-3.5:
    In gaming, a "ledge" typically refers to a narrow platform or edge that a player can walk on or jump to. 
    It is often used as a tactical element in platforming games, where players must carefully navigate ledges to progress through the level. 
    Ledges can also be used as a hiding spot or vantage point in stealth or action games.
    ----

# 阅读源码可知:
    目前来看, 墙壁, 悬崖, 台阶 等可以打断当前连续前进的, 就可以算 Ledge;
    不太确定, 还需继续看;
    

#   出现在 `HitStabilityReport` class 中




# ------------------------- #
#     术语: `stable`   稳定
# ------------------------- #
源码中多处出现 `stable`,  直观理解是 "如果失去稳定, 角色将倒下";  但实际可能并非如此;  而是类似 "斜坡角度太大, 角色无法站在上面, 会滑落"  的这种 lost stable

有待进一步验证;



# ------------------------- #
#     术语: `Overlap`
# ------------------------- #

和 角色控制器的 capsule collider 重叠的 另一个 collider, 的信息被记录为一份 OverlapResult


# ------------------------- #
#     术语: `obstructionNormal`
# ------------------------- #

当 角色和一个 collider 碰撞, 将得到一个 hit normal;

-- 如果 hit对象 是缓坡,      则 obstructionNormal 就是原始的 hit normal
-- 如果 hit对象 是陡坡/物体, 则 obstructionNormal 就是一个垂直于 当前地面的, 阻挡角色运动的 平面; (它会和 角色up 方向平面)
( 上面这句描述有点混乱, 但大概是这个意思)



# ------------------------- #
#     术语: `sweep`
# ------------------------- #
扫, 其实就是 Physics.CapsuleCastNonAlloc() 等函数中, cast 这个动作;  就是拿着一个 collider 扫过一段距离(区域);




# =================================================================== #
#                         执行时序
# =================================================================== #

# KinematicCharacterSystem 的 Execution Order 为 90

# cinemachine brain 的 Execution Order 为 100

如果想让 角色跟随点的位移 写在 K控制器 之后, vcam brain 的 lateupdate 之前

就需要是现在 90 之后的 update 中;

# 否则就会造成卡顿




















