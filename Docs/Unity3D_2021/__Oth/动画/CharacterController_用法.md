# ============================================================ #
#                CharacterController
# ============================================================ #


# -------------------------- #
#  绑定了 CharacterController 的 go, 无需再绑定 collider 组件

CharacterController 本身就含有一个 碰撞范围;


# ---------------- #
#    skinWidth:
# ---------------- #
当角色运动方向 和 碰撞方向 夹角足够小时, skinWidth 就会起作用, 增加碰撞体的尺寸;
比如: 如果 skinWidth 设置为 1:
    -- 当角色正面撞向墙壁时, 角色和墙壁之间会隔着 1 米的无法通过区;
    -- 当角色斜着靠近墙壁时, 角色和墙壁之间 间隔的区域 会远远小于 1 米;

unity 推荐此值设置为 碰撞体半径的 1/10, 可以有效防止角色和墙壁卡死;













