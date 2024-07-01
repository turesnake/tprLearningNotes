# ======================================================== #
#        mesh  计算每个顶点的法线
# ======================================================== #

# 假设有张面片, 上面的每个顶点做随机运动,  如何计算每个顶点的法线呢 ?

gpt-4o:

求得一个平面网格（mesh）每个顶点在随机上下位移后的法线方向（normal），可以按照以下步骤进行：

1. **顶点颜色和位置变换**:
   - 对每个顶点进行随机的上下位移操作，获取每个顶点新的位置。

2. **重新计算每一面的法线**:
   - 对于一个三角形面片，我们取其三个顶点：\(v1\), \(v2\), \(v3\)。
   - 计算两个边向量：\( \text{edge1} = v2 - v1 \) 和 \( \text{edge2} = v3 - v1 \)。
   - 使用向量叉积来计算法线向量： \( \text{normal} = \text{normalize}(\text{edge1} \times \text{edge2}) \)，这里的 \(\times\) 表示叉积运算，\(\text{normalize}\) 表示向量的归一化操作，确保法线向量的单位长度为1。

3. **顶点法线的平均**:
   - 每个顶点可能属于多个三角形面片，因此最终的顶点法线是所有属于该顶点的面片法线的归一化平均值。
   - 具体方法是：
     - 初始化每个顶点的法线向量为零向量：\(\text{normal}_i = \mathbf{0}\)。
     - 遍历每个面片，计算出面片的法线后，将其加到该面片的三个顶点的法线上去：\(\text{normal}_i + = \text{normal}_{\text{face}}\)。
     - 遍历所有顶点，对每个顶点的法线进行归一化处理：\(\text{normal}_i = \text{normalize}(\text{normal}_i)\)。

以下为一个伪代码示例：

```python
# 假设vertices是顶点列表，faces是面的列表，每个face是三个顶点的索引
import numpy as np

vertices = np.array([...])
faces = np.array([...])

# 随机位移每个顶点
displacement = (np.random.rand(vertices.shape[0], 3) - 0.5) * 2  # [-1, 1] 范围
vertices += displacement

# 初始化法线为0
normals = np.zeros_like(vertices)

for face in faces:
    v1, v2, v3 = vertices[face[0]], vertices[face[1]], vertices[face[2]]
    edge1 = v2 - v1
    edge2 = v3 - v1
    face_normal = np.cross(edge1, edge2)
    face_normal = face_normal / np.linalg.norm(face_normal)  # 归一化法线

    normals[face[0]] += face_normal
    normals[face[1]] += face_normal
    normals[face[2]] += face_normal

# 对每个顶点的法线进行归一化处理
normals = normals / np.linalg.norm(normals, axis=1, keepdims=True)
```

这段伪代码演示了如何计算顶点的法线。实际操作可能需要根据具体的网格数据结构进行调整。

# ------------------------------------------------------------------------------

上述方法要求向 顶点法线容器 实施累加, 






# ======================================================== #
#        mesh  计算每个顶点的 法线 切线
# ======================================================== #

# 问:
一张平面mesh, 每个顶点在随机做上下位移, 如何求得每个顶点的法线方向 normal 和 tangent

# gpt:
求得一张平面网格（mesh）每个顶点在随机上下位移后的法线（normal）和切线（tangent）方向，可以按照以下步骤进行：

1. **顶点上下位移变换**。
2. **重新计算每个面的法线和切线**。
3. **平均贡献到每个顶点**。

### 1. 顶点上下位移变换
对每个顶点进行随机的上下位移操作，获取每个顶点新的位置。

### 2. 计算每个面的法线和切线
对于每个三角形面片，计算面片的法线和切线。

### 3. 平均贡献到每个顶点
每个顶点的法线和切线是所有包含该顶点的三角形面片法线和切线的归一化平均值。

以下是一个详细的示例：

### 顶点上升变换和法线切线计算代码

#### C# 脚本

使用 MeshFilter 和 MeshRenderer 来获取和设置网格信息：

```csharp
using System.Collections;
using UnityEngine;

public class MeshNormalsAndTangents : MonoBehaviour
{
    public float displacementAmount = 0.1f;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        // 随机上下位移顶点
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y += Random.Range(-displacementAmount, displacementAmount);
        }

        // 更新顶点位置
        mesh.vertices = vertices;
        mesh.RecalculateBounds();

        // 计算法线和切线
        Vector3[] normals = new Vector3[vertices.Length];
        Vector4[] tangents = new Vector4[vertices.Length];
        Vector3[] binormals = new Vector3[vertices.Length];
        
        for (int i = 0; i < vertices.Length; i++)
        {
            normals[i] = Vector3.zero;
            tangents[i] = Vector4.zero;
            binormals[i] = Vector3.zero;
        }

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int index0 = triangles[i];
            int index1 = triangles[i + 1];
            int index2 = triangles[i + 2];

            Vector3 v0 = vertices[index0];
            Vector3 v1 = vertices[index1];
            Vector3 v2 = vertices[index2];

            Vector3 edge1 = v1 - v0;
            Vector3 edge2 = v2 - v0;

            // 计算面法线
            Vector3 faceNormal = Vector3.Cross(edge1, edge2).normalized;

            // 计算面切线和副法线
            Vector2 uv0 = mesh.uv[index0];
            Vector2 uv1 = mesh.uv[index1];
            Vector2 uv2 = mesh.uv[index2];

            float deltaU1 = uv1.x - uv0.x;
            float deltaV1 = uv1.y - uv0.y;
            float deltaU2 = uv2.x - uv0.x;
            float deltaV2 = uv2.y - uv0.y;

            float f = 1.0f / (deltaU1 * deltaV2 - deltaU2 * deltaV1);

            Vector3 faceTangent = new Vector3(
                f * (deltaV2 * edge1.x - deltaV1 * edge2.x),
                f * (deltaV2 * edge1.y - deltaV1 * edge2.y),
                f * (deltaV2 * edge1.z - deltaV1 * edge2.z)
            ).normalized;

            Vector3 faceBinormal = Vector3.Cross(faceNormal, faceTangent).normalized;

            // 累加到顶点
            normals[index0] += faceNormal;
            normals[index1] += faceNormal;
            normals[index2] += faceNormal;

            tangents[index0] += new Vector4(faceTangent.x, faceTangent.y, faceTangent.z, 0);
            tangents[index1] += new Vector4(faceTangent.x, faceTangent.y, faceTangent.z, 0);
            tangents[index2] += new Vector4(faceTangent.x, faceTangent.y, faceTangent.z, 0);

            binormals[index0] += faceBinormal;
            binormals[index1] += faceBinormal;
            binormals[index2] += faceBinormal;
        }

        // 归一化累加的法线和切线
        for (int i = 0; i < vertices.Length; i++)
        {
            normals[i].Normalize();
            tangents[i] = new Vector4(tangents[i].x, tangents[i].y, tangents[i].z, 0).normalized;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            tangents[i].w = (Vector3.Dot(Vector3.Cross(normals[i], (Vector3)tangents[i]), binormals[i]) < 0.0f) ? -1.0f : 1.0f;
        }

        // 设置法线和切线
        mesh.normals = normals;
        mesh.tangents = tangents;
    }
}
```

这段代码实现了对 mesh 顶点的随机上下位移，并计算每个顶点的法线和切线。具体步骤如下：

1. **随机上下位移顶点**: 对每个顶点的 y 轴进行随机位移来模拟地形或曲面扰动。
2. **初始化法线和切线数组**: 创建法线和切线数组，并初始化为零向量。
3. **遍历三角形面片**: 对于每个三角形面片，计算其面法线、切线和副切线。
4. **累加到顶点法线和切线**: 将面法线、面切线和面副切线累加到对应顶点的法线和切线。
5. **归一化累加结果**: 归一化累加后的顶点法线和切线，并计算切线的 w 分量用于决定切线方向。

最终将计算得到的法线和切线应用到 Mesh 上。

这样，每个顶点的法线和切线方向都会同时考虑其相邻面的影响，确保结果的连续和光滑。

































