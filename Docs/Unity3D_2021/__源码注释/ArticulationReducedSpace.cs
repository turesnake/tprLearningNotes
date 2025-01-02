#region Assembly UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using UnityEngine.Bindings;

namespace UnityEngine;

//
// Summary:
//     Coordinates in reduced space.
/*

    在机器人仿真中，“Reduced Space”通常指的是一种简化的状态空间或控制空间，用于降低计算复杂性和提高仿真效率。以下是对“Reduced Space”概念的详细解释：

    1. 状态空间的简化
    在机器人仿真中，状态空间是描述机器人所有可能状态的集合。对于复杂的机器人，状态空间可能非常高维，包含位置、速度、加速度、关节角度等多个参数。通过“Reduced Space”，我们可以：

    降低维度：通过选择最重要的状态变量，忽略不必要的细节，从而减少计算量。例如，在某些情况下，可以只关注机器人的末端执行器的位置，而忽略其他关节的状态。
    使用主成分分析（PCA）：通过统计方法提取主要成分，减少数据维度，同时保留大部分信息。
    
    2. 控制空间的简化
    控制空间是指机器人可以采取的所有控制输入的集合。在高维控制空间中，计算控制策略可能非常复杂。通过“Reduced Space”，可以：

    简化控制输入：只考虑对机器人行为影响最大的控制输入，减少控制策略的复杂性。
    使用低维控制策略：例如，使用策略梯度方法或其他优化算法在简化的控制空间中进行学习和优化。

    3. 应用场景
    路径规划：在路径规划中，使用“Reduced Space”可以加快搜索算法的速度，尤其是在高维空间中。
    运动控制：在运动控制中，简化的状态和控制空间可以使得控制算法更高效，减少计算延迟。
    仿真和优化：在进行机器人仿真和优化时，使用“Reduced Space”可以显著提高效率，尤其是在实时应用中。
    
    4. 示例
    关节空间 vs. 任务空间：在机器人操作中，通常可以选择在关节空间（每个关节的角度）或任务空间（末端执行器的位置和姿态）中进行控制。使用任务空间可以减少控制的复杂性，因为它直接与机器人的目标任务相关。
    模型简化：在某些情况下，可以通过简化机器人的物理模型（例如，忽略某些关节或连接）来创建“Reduced Space”，从而加快仿真速度。



*/
[NativeHeader("Modules/Physics/ArticulationBody.h")]
public struct ArticulationReducedSpace
{
    private unsafe fixed float x[3];

    //
    // Summary:
    //     The number of degrees of freedom of a body.
    public int dofCount;

    public unsafe float this[int i]
    {
        get
        {
            if (i < 0 || i >= dofCount)
            {
                throw new IndexOutOfRangeException();
            }

            return x[i];
        }
        set
        {
            if (i < 0 || i >= dofCount)
            {
                throw new IndexOutOfRangeException();
            }

            x[i] = value;
        }
    }

    //
    // Summary:
    //     Stores coordinates in reduced space.
    //
    // Parameters:
    //   a:
    //     Coordinate of the first degree of freedom.
    //
    //   b:
    //     Coordinate of the second degree of freedom.
    //
    //   c:
    //     Coordinate of the third degree of freedom.
    public unsafe ArticulationReducedSpace(float a)
    {
        x[0] = a;
        dofCount = 1;
    }

    //
    // Summary:
    //     Stores coordinates in reduced space.
    //
    // Parameters:
    //   a:
    //     Coordinate of the first degree of freedom.
    //
    //   b:
    //     Coordinate of the second degree of freedom.
    //
    //   c:
    //     Coordinate of the third degree of freedom.
    public unsafe ArticulationReducedSpace(float a, float b)
    {
        x[0] = a;
        x[1] = b;
        dofCount = 2;
    }

    //
    // Summary:
    //     Stores coordinates in reduced space.
    //
    // Parameters:
    //   a:
    //     Coordinate of the first degree of freedom.
    //
    //   b:
    //     Coordinate of the second degree of freedom.
    //
    //   c:
    //     Coordinate of the third degree of freedom.
    public unsafe ArticulationReducedSpace(float a, float b, float c)
    {
        x[0] = a;
        x[1] = b;
        x[2] = c;
        dofCount = 3;
    }
}

