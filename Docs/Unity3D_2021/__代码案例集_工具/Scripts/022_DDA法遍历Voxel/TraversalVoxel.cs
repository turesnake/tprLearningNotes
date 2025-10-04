using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;


using GameDebug;



namespace Fire3D
{
    /*
        遍历3d体素box, 将射线穿过的所有 cell 记录下来

        3D DDA: 3D Digital Differential Analyzer; 是体素光线行进（Voxel Ray Marching）中最常用的离散遍历方法之一。
    */
    public class TraversalVoxel : MonoBehaviour
    {
        public Transform cubeTF;

        public Transform rayStartTF, rayEndTF;

        public MeshRenderer meshRenderer;
        Material mat;

        public float cellMeterSize = 0.1f;
        public Vector3Int gridCellNums = new Vector3Int(10, 10, 10);
        int cellTotalNum;
        
        Vector3 cubeRootPos;
        Vector3 cubeMeterSize;

        Matrix4x4 cubeCellMtx;
        Matrix4x4 invCubeCellMtx;

        Transform frontTF, backTF;
        bool isWorking = false;
        List<int> showCellIdxs = new List<int>();

        public Vector3 PosWSToCubeCell(Vector3 posWS) => (Vector3)(cubeCellMtx * new Vector4(posWS.x, posWS.y, posWS.z, 1f));
        public Vector3 PosCubeCellToWS(Vector3 posCube) => (Vector3)(invCubeCellMtx * new Vector4(posCube.x, posCube.y, posCube.z, 1f));


        void Start()
        {
            Application.targetFrameRate = 15;
            Debug.Assert(cubeTF);
            Debug.Assert(rayStartTF);
            Debug.Assert(rayEndTF);
            Debug.Assert(meshRenderer);
            mat = meshRenderer.material;

            cubeMeterSize = new Vector3( gridCellNums.x * cellMeterSize, gridCellNums.y * cellMeterSize, gridCellNums.z * cellMeterSize );
            cubeTF.localScale = cubeMeterSize;
            cubeRootPos = cubeTF.position - cubeTF.localScale * 0.5f;
            cellTotalNum = gridCellNums.x * gridCellNums.y * gridCellNums.z;
            //Debug.LogError($"cubeMeterSize = {cubeMeterSize.ToString()}");

            cubeCellMtx = GetWorldToCubeCellMatrix();
            invCubeCellMtx = cubeCellMtx.inverse;
            //---
            mat.SetInt("_GridCellNumX", gridCellNums.x);
            mat.SetInt("_GridCellNumY", gridCellNums.y);
            mat.SetInt("_GridCellNumZ", gridCellNums.z);
            mat.SetVector("_CubeRootPosWS", (Vector4)cubeRootPos);
            mat.SetVector("_CubeMeterSize", (Vector4)cubeMeterSize);

            // debug
            frontTF = DebugTools.CreatePrimitive(PrimitiveType.Sphere, transform, Vector3.one * 0.05f, Color.black, "front");
            backTF = DebugTools.CreatePrimitive(PrimitiveType.Sphere, transform, Vector3.one * 0.05f, Color.white, "back");
            TextDebug.SetActive(true);
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                isWorking = !isWorking;
            }
            if (!isWorking)
            {
                return;
            }
            // =============
            showCellIdxs.Clear();
            Vector3 ro = PosWSToCubeCell(rayStartTF.position);
            Vector3 re = PosWSToCubeCell(rayEndTF.position);
            Vector3 rd = (re - ro).normalized;
      
            float eps = 1e-4f;
            Vector3 boxMin = Vector3.zero;
            Vector3 boxMax = (Vector3)gridCellNums;
            // ro, rd 已在 CubeCell 坐标，rd 需归一化
            // !! 注意, 此处的 tEnter, tExit 是基于 ro 计算的;
            if (!IntersectAabbFull(ro, rd, boxMin, boxMax, eps, out float tEnter, out float tExit))
            {
                return;
            }
            float t = tEnter; // 一定>=0f;
            Vector3 enterPos = ClampPosCube( ro + rd * t ); // box边界上, 也可能在box体内;
            var (iCellIdx, idx3d) = PosToGridIndex(enterPos); // 得到第一个 cell

            // 几组定值:
            // 步进方向
            int stepX = rd.x > 0f ? 1 : (rd.x < 0f ? -1 : 0);
            int stepY = rd.y > 0f ? 1 : (rd.y < 0f ? -1 : 0);
            int stepZ = rd.z > 0f ? 1 : (rd.z < 0f ? -1 : 0);            
            // 每跨一个 cell 的增量 tDelta
            float txDelta = Mathf.Abs(rd.x) < 1e-6f ? float.PositiveInfinity : 1f / Mathf.Abs(rd.x);
            float tyDelta = Mathf.Abs(rd.y) < 1e-6f ? float.PositiveInfinity : 1f / Mathf.Abs(rd.y);
            float tzDelta = Mathf.Abs(rd.z) < 1e-6f ? float.PositiveInfinity : 1f / Mathf.Abs(rd.z);

            // 下一个栅格面的坐标（以 cell 为单位）
            float nextVoxX = stepX > 0 ? (idx3d.x + 1) : idx3d.x;
            float nextVoxY = stepY > 0 ? (idx3d.y + 1) : idx3d.y;
            float nextVoxZ = stepZ > 0 ? (idx3d.z + 1) : idx3d.z;
            // 到下一个面的 t（如果该轴平行，则设为 +Inf）; 
            // !! 此处的 local t 是基于 enterPos 计算的; 目的是提高浮点数使用精度; (比如当 ro 距box 特别远时, 基于ro的 t值精度就不够高)
            float txLocalMax = Mathf.Abs(rd.x) < 1e-6f ? float.PositiveInfinity : (nextVoxX - enterPos.x) / rd.x;
            float tyLocalMax = Mathf.Abs(rd.y) < 1e-6f ? float.PositiveInfinity : (nextVoxY - enterPos.y) / rd.y;
            float tzLocalMax = Mathf.Abs(rd.z) < 1e-6f ? float.PositiveInfinity : (nextVoxZ - enterPos.z) / rd.z;

            int maxSteps = gridCellNums.x + gridCellNums.y + gridCellNums.z + 10; // 保险上限
            for (int s = 0; s < maxSteps; s++)
            {
                if (t + eps > tExit || IsCellIdx3DOutOfRange(idx3d) ) // 两个版本的终点审查:
                {
                    break;
                }
                showCellIdxs.Add(CellIdx3DTo1D(idx3d));
                
                // 选择最小轴推进:
                if (txLocalMax <= tyLocalMax && txLocalMax <= tzLocalMax)
                {
                    idx3d.x += stepX;
                    t = tEnter + txLocalMax;
                    txLocalMax += txDelta;
                }
                else if (tyLocalMax <= tzLocalMax)
                {
                    idx3d.y += stepY;
                    t = tEnter + tyLocalMax;
                    tyLocalMax += tyDelta;
                }
                else
                {
                    idx3d.z += stepZ;
                    t = tEnter + tzLocalMax;
                    tzLocalMax += tzDelta;
                }
            }
        }

        // =========================================================== //

        Vector3 ClampPosCube(Vector3 posCube_)
        {
            posCube_.x = Mathf.Clamp(posCube_.x, 0f, gridCellNums.x);
            posCube_.y = Mathf.Clamp(posCube_.y, 0f, gridCellNums.y);
            posCube_.z = Mathf.Clamp(posCube_.z, 0f, gridCellNums.z );
            return posCube_;
        }



        // !!! 存在误差, 不能直接用于步进计算
        // 直接在 cubecell 坐标系内计算
        public (int linearIdx, Vector3Int idx3D) PosToGridIndex(Vector3 posCube_)
        {
            const float eps = 1e-7f;
            Vector3 pos = posCube_;
            Vector3 max = gridCellNums;
            if (pos.x < 0f - eps || pos.x > max.x + eps ||
                pos.y < 0f - eps || pos.y > max.y + eps ||
                pos.z < 0f - eps || pos.z > max.z + eps)
            {
                return (-1, new Vector3Int(-1, -1, -1));
            }
            // 仿微小误差:
            pos.x = Mathf.Clamp(pos.x, 0f, max.x);
            pos.y = Mathf.Clamp(pos.y, 0f, max.y);
            pos.z = Mathf.Clamp(pos.z, 0f, max.z);
            //--
            int ix = Mathf.Clamp(Mathf.FloorToInt(pos.x), 0, gridCellNums.x - 1);
            int iy = Mathf.Clamp(Mathf.FloorToInt(pos.y), 0, gridCellNums.y - 1);
            int iz = Mathf.Clamp(Mathf.FloorToInt(pos.z), 0, gridCellNums.z - 1);
            //--
            Vector3Int idx3D = new Vector3Int(ix, iy, iz);
            int linearIdx = CellIdx3DTo1D(ix, iy, iz);
            return (linearIdx, idx3D);
        }

        public Vector3Int CellIdxTo3D(int cellIdx)
        {
            int nx = gridCellNums.x;
            int ny = gridCellNums.y;
            int nz = gridCellNums.z;
            if (cellIdx < 0 || cellIdx >= cellTotalNum)
            {
                Debug.LogError($"cellIdx 异常 = {cellIdx}");
                return new Vector3Int(-1, -1, -1);
            }    
            int ix = cellIdx % nx;
            int iy = (cellIdx / nx) % ny;
            int iz = cellIdx / (nx * ny);
            return new Vector3Int(ix, iy, iz);
        }

        public int CellIdx3DTo1D(Vector3Int i3d_)
        {
            return CellIdx3DTo1D( i3d_.x, i3d_.y, i3d_.z );
        }
        int CellIdx3DTo1D(int x, int y, int z)
        {
            if (IsCellIdx3DOutOfRange(x,y,z))
            {
                Debug.LogError($"out of range; x:{x}, y:{y}, z:{z}");
                return -1;
            }
            return (z * gridCellNums.y + y) * gridCellNums.x + x;
        }

        bool IsCellIdx3DOutOfRange( Vector3Int i3d_ )
        {
            return IsCellIdx3DOutOfRange(i3d_.x, i3d_.y, i3d_.z);
        }
        bool IsCellIdx3DOutOfRange( int x, int y, int z )
        {
            return x < 0 || x >= gridCellNums.x || y < 0 || y >= gridCellNums.y || z < 0 || z >= gridCellNums.z;
        }

        // =============================== // 

        /// 返回一个矩阵 M：posCube = M * float4(posWS, 1)
        /// 在 posCube 坐标中：
        /// - 原点在 Cube 的 left-bottom-near 顶点（-x,-y,-z）
        /// - 单位为“每个 cell 的 xyz 边长”（结果数值表示以 cell 为单位的坐标）
        public Matrix4x4 GetWorldToCubeCellMatrix()
        {
            // 世界尺度（逐分量）
            Vector3 scaleWS = cubeTF.localScale;
            Vector3 lbnWS = cubeTF.position - 0.5f * scaleWS; // 左下近顶点（LBN）在世界空间的位置
            // 每个 cell 的世界长度（逐分量）
            Vector3 cellSizeWS = new Vector3(
                scaleWS.x / gridCellNums.x,
                scaleWS.y / gridCellNums.y,
                scaleWS.z / gridCellNums.z
            );
            // 计算 cell 尺寸的倒数，避免除零
            Vector3 invCellSizeWS = new Vector3(1f / cellSizeWS.x, 1f / cellSizeWS.y, 1f / cellSizeWS.z);
            // 构造矩阵：S(invCellSizeWS) * T(-lbnWS)
            Matrix4x4 T = Matrix4x4.Translate(-lbnWS);
            Matrix4x4 S = Matrix4x4.Scale(invCellSizeWS);
            Matrix4x4 M = S * T;
            return M;
        }

        bool IntersectAabbFull(Vector3 rayOrigin, Vector3 rayDir, Vector3 boxMin, Vector3 boxMax, float eps, out float tEnter, out float tExit)
        {
            tEnter = 0f;
            tExit = float.PositiveInfinity;
            for (int axis = 0; axis < 3; axis++) // {0,1,2}
            {
                float origin = rayOrigin[axis], dir = rayDir[axis], minVal = boxMin[axis], maxVal = boxMax[axis];
                if (Mathf.Abs(dir) < eps)
                {
                    if (origin < minVal || origin > maxVal) return false;
                    continue;
                }
                float inv = 1f / dir;
                float t1 = (minVal - origin) * inv;
                float t2 = (maxVal - origin) * inv;
                if (t1 > t2) { var tmp = t1; t1 = t2; t2 = tmp; }
                tEnter = Mathf.Max(tEnter, t1);
                tExit = Mathf.Min(tExit, t2);
                if (tEnter > tExit) return false;
            }
            return true;
        }

        // ============================================= // 
        void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                return;
            }
            var rayDir = (rayEndTF.position - rayStartTF.position).normalized;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayStartTF.position, rayStartTF.position + rayDir * 10f);
            // 碰撞到的 cells:
            for (int i = 0; i < showCellIdxs.Count; i++)
            {
                int cellIdx = showCellIdxs[i];
                if (cellIdx < 0 || cellIdx >= cellTotalNum)
                {
                    Debug.LogError($"cellIdx = {cellIdx}");
                    return;
                }
                Vector3Int i3d = CellIdxTo3D(cellIdx);
                var pos = cubeRootPos + new Vector3((i3d.x + 0.5f) * cellMeterSize, (i3d.y + 0.5f) * cellMeterSize, (i3d.z + 0.5f) * cellMeterSize);
                Gizmos.DrawWireCube( pos, Vector3.one * cellMeterSize );
            }
        }

    }
}



