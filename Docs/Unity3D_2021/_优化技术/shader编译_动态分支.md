# ================================================================ #
#                shader编译 动态分支
# ================================================================ #


# ---------------------------------------------- #
#          收集来的 杂乱信息
# ---------------------------------------------- #

# -- NVIDIA GeForce 6 - 2005
在 vertex shader 中支持 MIMD 架构, 意味着能让 动态分支自由执行;
(多指令多数据)

在 frag shader 中支持 SIMD 架构, 当出现动态分支语句时, 要承担两份开销:
    -1- 分支等待的开销
    -2- if 语句本身也存在开销 (有个说法是需要 6 个以上的指令)


# -- OpenGL ES 2.0 (bgolus)
    此平台永远会把 分支语句 flatten; 




# ---------------------------------------------- #
#       UNITY_BRANCH    hlsl 原生Attribute: [branch]
#       UNITY_FLATTEN   hlsl 原生Attribute: [flatten]
# ---------------------------------------------- #

# =============== #
# UNITY_BRANCH
    就是维持普通的 if else 结构, 但是在 wraps 内的不同 threads 之间存在分歧,
    不同的 thread 根据自己的 fragment 的信息, 进入不同的分支代码;
    
    但由于 frag shader 是 SIMD 架构, 所以当 a分支执行时, 选择走b分支的 thread 得干等,
    反之亦然;

    编译器会自动补上 else 从句,比如:
        if(a){
            x = doA();
        }
    
    等同于:

        if(a){
            x = doA();
        }else{
            x = x;
        }

# 若任一分支从句中存在 求导数操作, 比如 ddx(), ddy(), tex2D(), 此时不能使用 UNITY_BRANCH, 否则会报错;
    但我测试时 没发生...


# ************************************ #
# 何时该主动使用 UNITY_BRANCH ??
# 当大部分 wraps.threads 的 if判断表达式, 计算出来的结果都统一时.
    比如:
        if(  _Smoothness > 0.5 ){
            doA();
        }else{
            doB();
        }
    
    此处的 _Smoothness 是个 material property, 它是 uniform 的;
    也就是说, 在单帧渲染内, 执行此shader 的所有 fragment, 它们 _Smoothness 是同一个值;
    ---
    此时如果 _Smoothness = 0.3; 那么所有的 threads, 都只会执行 doA(); 这个分支, 然后彻底跳过 doB() 这个分支;

    此时, 分支语句 "真的只执行了一部分" !!!!




# =============== #
# UNITY_FLATTEN:
    官方描述就是将两个分支的代码 都执行一遍, 然后根据 if(...) 内的判断句,
    选择正确的那个分支的结果;

    强制要求每一个 thread 都执行所有可能得 分支代码, 最后针对 分支结果 做简单的选择;

    有的时候 分支语句内的 代码很简单, 此时可选择 flatten; 因为 if 语句本身 也存在开销
    (会被编译成 6个指令), 将分支语句展平后, 能节省掉这份开销;



# 若任一分支从句中存在 stream append statement, 或别的存在 side-effects 的指令, 使用 UNITY_FLATTEN 会报错;





# ======= 实例展示 ========= #
以 unity 中的 OpenGL Core 中间码为例:
(d3d 其实差不多, 就是不够直观)

# -1-: 啥也不标注:
    if (_test)
        return _ColorA;
    else
        return _ColorB;

将被编译为:
    
    if(_test != 0) {
        SV_Target0 = _ColorA;
        return;
    } else {
        SV_Target0 = _ColorB;
        return;
    }

-----
可见维持了 动态分支;

# -2- 标注: UNITY_BRANCH
    UNITY_BRANCH
    if (_test)
        return _ColorA;
    else
        return _ColorB;

将被编译为:

    if(_test != 0) {
        SV_Target0 = _ColorA;
        return;
    } else {
        SV_Target0 = _ColorB;
        return;
    }
    return;

-----
和上面的默认配置结果一样;

# -3- 标注: UNITY_FLATTEN:  
    UNITY_FLATTEN
    if (_test)
        return _ColorA;
    else
        return _ColorB;

将被编译为:

    u_xlatb0 = _test!=0;
    SV_Target0 = _ColorA;
    if(u_xlatb0){return;}
    SV_Target0 = _ColorB;
    return;

-----
分支代码给展平, 












