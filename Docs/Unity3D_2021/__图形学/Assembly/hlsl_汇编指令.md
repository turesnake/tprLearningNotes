# =======================================================//
#        shader model 4 Assembly  汇编指令 本身:
# =======================================================//

在 微软文档中, model 4, model 5 的指令 是不重合的 (5部分猜测是 新增指令)


# ++++++++++++++++++++++++++++++++ #
#   dp2:    
#   dp3:
#   dp4:
(sm4)
    计算两个向量的 点积运算; 2分量,3分量,4分量 的;

    
    dp2[_sat]  dest[.mask],             // 目的地址
            [-]src0[_abs][.swizzle],    // 操作数
            [-]src1[_abs][.swizzle]     // 操作数


注意看公式, 可用 mask 来影响 写入;

---- 
    可用于: vs, gs, fs



# ++++++++++++++++++++++++++++++++ #
#   frc:
(sm4)
    逐分量执行: 提取小数部分:
    dest = src0 - round_ni(src0);

    frc[_sat]   dest[.mask], 
            [-] src0[_abs][.swizzle]

# 特殊值:
    src: -inf    -> dest: NaN
    src: -F      -> dest: [+0,1)
    src: -denorm -> dest: +0
    src: -0      -> dest: +0
    src: +0      -> dest: +0
    src: +denorm -> dest: +0
    src: +F      -> dest: [+0,1)
    src: +inf    -> dest: NaN
    src: NaN     -> dest: NaN
( F 指 有限实数)

---- 
    可用于: vs, gs, fs



# ++++++++++++++++++++++++++++++++ #
#   lt:
(sm4)
    逐分量执行: 小于等于 比较运算:
    (src0 < src1) 
    若为 true, 向 dest 的对应分量写入: 0xFFFFFFFF
                            否则写入: 0x0000000

    lt     dest[.mask], 
        [-]src0[_abs][.swizzle], 
        [-]src1[_abs][.swizzle]

    Denorms are flushed before comparison; 
    original source registers are untouched.
    ---
    Denorms 在比较之前被刷新；原始的 源寄存器 不会被触及;

+0 equals -0.

和 NaN 比较总能得到 false;

---- 
    可用于: vs, gs, fs




# ++++++++++++++++++++++++++++++++ #
#   mad:
(sm4)
    逐分量执行: 先乘后加:
    dest = src0 * src1 + src2;

    mad[_sat]      dest[.mask], 
                [-]src0[_abs][.swizzle], 
                [-]src1[_abs][.swizzle], 
                [-]src2[_abs][.swizzle]

---- 
    可用于: vs, gs, fs



# ++++++++++++++++++++++++++++++++ #
#   mul:
(sm4)
    逐分量执行 乘法:
    dest = src0 * src1;

    mul[_sat]      dest[.mask], 
                [-]src0[_abs][.swizzle], 
                [-]src1[_abs][.swizzle]

# 存在表, 描述 +-inf, NaN, +-0 等数值进行此指令运算后的结果...

---- 
    可用于: vs, gs, fs




# ++++++++++++++++++++++++++++++++ #
#   mov:
(sm4)
    
    逐分量执行: move 操作: dest = src0

    mov[_sat]   dest[.mask], 
             [-]src0[_abs][.swizzle]

除了 swizzle 以外的修饰符, 都假设数据是 浮点数;

The absence of modifiers just moves data without altering bits.
---
修饰符的缺席, 只移动数据, 不修改 bits ???


---- 
    可用于: vs, gs, fs



# ++++++++++++++++++++++++++++++++ #
#   movc:
(sm4 - asm)

    逐分量执行: 附带条件的 move 操作;

    movc[_sat]  dest[.mask],            // 移动地址
                src0[.swizzle],         // 被测试的数据
             [-]src1[_abs][.swizzle],   // 被移动数据
             [-]src2[_abs][.swizzle],   // 被移动数据
    
    (逐分量执行) 若 src0 成立, 则移动 src1 到 dest, 否则移动 src2 到 dest;

---- 
    可用于: vs, gs, fs


# ++++++++++++++++++++++++++++++++ #
#   round_ne:
#   round_ni:
#   round_pi:
#   round_z:
(sm4)
    逐分量执行: 取整运算:
    将一个 浮点数, 省略为一个 float 类型的的整数;

    round_ne[_sat]     dest[.mask], 
                    [-]src0[_abs][.swizzle]

# _ne:
    向 nearest even (最近的偶数) 取整;
# _ni:
    向 -inf 取整; 类似 floor();
# _pi:
    向 +inf 取整; 类似 ceil();
# _z:
    向 0 取整;

# 特殊值: 有表, 在此略...

---- 
    可用于: vs, gs, fs

























