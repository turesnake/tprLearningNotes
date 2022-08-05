# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&//
# hlsl:
#           shader model 5 Assembly  za
# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&//



# ======================================================= #
#       Vertex Shader Register Modifiers    
#           寄存器修饰符          
# ======================================================= #


# ------------------------------ #
# Source Register Swizzling (HLSL VS reference)

在一个指令被执行之前, 源寄存器中的数据会被复制到一个 临时寄存器中; 

Swizzling 指的是能 源寄存器的任意分量, 分配到 临时寄存器的任意分量的能力; (所有才叫这个名, 有种 "随意布置" 的意思)

# -- Component Swizzling
    使用格式如下:
    r.[xyzw][xyzw][xyzw][xyzw]

    此处 r 是一个有效的 vertex shader 输入寄存器,

---
    总是会复制 4 个分量, 如果修饰符指定的分量少于 4个,最后一个被指定的分量会被重复, 直到填满四个;
    比如
        x 等同于 (.xxxx)

---
    分量放置顺序随意; v0.ywx 等同于 v0.ywxx;
---
    xyzw, rgba 都能使用;
---
    以下指令实现了 源寄存器的 单分量 swizzles:
        exp, expp, log, logp, pow, rcp, rsq.
    这些指令的计算结果, 被复制到 目标寄存器 dest 的全部4个分量中;
    (也就是说, 访问 xyzw 都是可以的, 都是相同值)

Swizzling 不能被用于:
    m3x2 - vs, 
    m3x3 - vs, 
    m4x3 - vs,
    m4x4 - vs instructions.


# ------------------------------ #
#   Destination Register Masking

指令计算的结果最终会写入 dest 寄存器,
mask 控制了最终能改写哪几个 bits;

texture 寄存器 和 其它寄存器 存在不一样的 规则;


# --- Destination Register Masking:
    r.{x}{y}{z}{w}
    --
    上例中, r是一个有效的 vertex shader 寄存器;

---
    通常, 指定 dest 寄存器的 mask 修饰符, 是个好习惯;
---
    ...
--- 
    输出寄存器: oPts, oFog; 只能使用一个分量, 
    要用 mask 来指定;
---
    如下指令要求 dest 寄存器 用 mask 指定单个分量:
        exp, expp, log, logp, pow, rcp, and rsq.
---
    frc 指令:
    version 1.0 中, 若想使用 "组合式mask", 则必须使用如下之一:
        .x or .y or .xy
        (非组合的 mask 则使用随意, 比如 .x, .y, .z 都可以)
    version 2.0 不再有此限制;

---
    sincos 指令 (对, 这是一个单独的指令) 若想使用 "组合式mask", 则必须使用如下之一:
        .x or .y or .xyz.
        (非组合的 mask 则使用随意, 比如 .x, .y, .z 都可以)
---
    m3x2 指令需要设置 mask: .xy
---
    m3x3, m4x3 指令需要设置 mask: .xyz
--- 
    m3x4, m4x4 指令需要设置 mask: .xyz 或 default(.xyzw)


# --- Texture Register Masks:
texture 寄存器的要求更严格:

---
    如果 oTn 要被写入, 则所有之前的寄存器: (oTn-1 ~ oT0)
    也都要被写入;
    (但是各个 oT# 的mask, 可以是各自独立的)
---
    任何 oT# 寄存器 若想使用 "组合式mask", 则必须使用如下之一:
    .x
    .xy
    .xyz
    .xyzw (等同于 default, 即 不写 mask)
    (非组合的 mask 则使用随意, 比如 .x, .y, .z 都可以)

# 示范:
以下都是正确的 texture 寄存器 mask:

    oT1.y  
    oT0.y  
    oT2  
    oT0.xz  
    oT1.x

或
    oT0.xyz  
    oT1.xy  
    oT2.xyzw  


# ======================================================= #
#          Instruction modifiers 
#            指令修饰符
# ======================================================= #
Instruction modifiers affect the result of the instruction before it is written to the register. 

在 "指令结果" 被写入 寄存器之前, 指令修饰符 能影响这个 "结果值";




# ------------------ #
#   _sat:
Saturate    (sm4)
(作用于: 指令结果)

    Clamps the result of a single or double precision floating point 
    arithmetic operation to [0.0f...1.0f] range.

    将一个 "float/double 算术运算 的结果" clamp 到 [0,1] 区间;

    _sat(NaN) returns 0, by the rules for min and max.



# ------------------ #
#   _abs:
Absolute Value  (sm4)
(作用于: 源操作数)


    仅用于 单/双精度浮点数指令;
    能将值 变正, 包括 INF 值;
    ---
    Applying _abs on NaN preserves NaN, 
    although the particular NaN bit pattern that results is not defined.
    ---
    此修饰符 可以和 负号 "-"修饰符 结合使用;

# ------------------ #
#   负号: -:
Negate      (sm4)   
(作用于: 源操作数)

    Flips the sign of the value of a source operand 
    used in an arithmetic operation.
    ---
    将一个 算术指令的 源操作数的值, 翻转正负;
    ---
    也能翻转 INF,
    ---
    Applying negate on NaN preserves NaN, 
    although the particular NaN bit pattern that results is not defined.
    ---
    针对 int 类型, 此修饰符得到 源操作数的 补码 (2's complement);


# ------------------ #
#   precise:
(sm4,5; 不能用于 4.1)
(作用于: 指令结果)

    precise (component mask)

    此修饰符依赖 global shader flag: "REFACTORING_ALLOWED".
    当此 flag 存在时:

        可使用此修饰符;

        编译器或驱动 可强制 "单个指令的单个分量结果" 保持精确或不可重构。

        如果 mad 指令的组件被标记为 precise，则硬件必须执行 mad 指令或完全等效的指令，
        并且不能将 这个 mad 拆分为乘法和加法。

        同样, "先乘后加", 这两个操作中, 任意一个被标记为 precise, 就不能将其合并为单一一个 mad;

    当此 flag 不存在时:
        
        则不能使用此修饰符;

        因为它是不需要的, 此时所有指令都不会被 重构 (修改),
    -------

    本修饰符能影响所有指令, 不仅仅是 算术指令;



























