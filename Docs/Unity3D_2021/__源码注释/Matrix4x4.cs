#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Reflection;

namespace UnityEngine
{
    //
    // 摘要:
    //     A standard 4x4 transformation matrix.
    [DefaultMember("Item")]
    [Il2CppEagerStaticClassConstructionAttribute]
    [NativeClassAttribute("Matrix4x4f")]
    [NativeHeaderAttribute("Runtime/Math/MathScripting.h")]
    [NativeTypeAttribute(Header = "Runtime/Math/Matrix4x4.h")]
    [RequiredByNativeCodeAttribute(Optional = true, GenerateProxy = true)]
    public struct Matrix4x4//Matrix4x4__RR
        : IEquatable<Matrix4x4>, IFormattable
    {
        [NativeNameAttribute("m_Data[0]")]public float m00;     
        [NativeNameAttribute("m_Data[15]")]public float m33;    
        [NativeNameAttribute("m_Data[14]")]public float m23;
        [NativeNameAttribute("m_Data[13]")]public float m13;
        [NativeNameAttribute("m_Data[12]")]public float m03;
        [NativeNameAttribute("m_Data[11]")]public float m32;
        [NativeNameAttribute("m_Data[10]")]public float m22;
        [NativeNameAttribute("m_Data[8]")]public float m02;
        [NativeNameAttribute("m_Data[9]")]public float m12; 
        [NativeNameAttribute("m_Data[6]")]public float m21;
        [NativeNameAttribute("m_Data[5]")]public float m11;
        [NativeNameAttribute("m_Data[4]")]public float m01;  //  左值为 row-idx, 右值为 col-idx; 和 [0,1] 是相同的 
        [NativeNameAttribute("m_Data[3]")]public float m30;
        [NativeNameAttribute("m_Data[2]")]public float m20;
        [NativeNameAttribute("m_Data[1]")]public float m10;
        [NativeNameAttribute("m_Data[7]")]public float m31;

        public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3);

        public float this[int index] { get; set; }
        public float this[int row, int column] { get; set; }

        //
        // 摘要:
        //     Returns a matrix with all elements set to zero (Read Only).
        public static Matrix4x4 zero { get; }
        //
        // 摘要:
        //     Returns the identity matrix (Read Only).
        public static Matrix4x4 identity { get; }
        //
        // 摘要:
        //     Attempts to get a rotation quaternion from this matrix.
        public Quaternion rotation { get; }
        //
        // 摘要:
        //     Attempts to get a scale value from the matrix. (Read Only)
        public Vector3 lossyScale { get; }
        //
        // 摘要:
        //     Checks whether this is an identity matrix. (Read Only)
        public bool isIdentity { get; }
        //
        // 摘要:
        //     The determinant of the matrix. (Read Only)
        public float determinant { get; }
        //
        // 摘要:
        //     Returns the transpose of this matrix (Read Only).
        public Matrix4x4 transpose { get; }
        //
        // 摘要:
        //     This property takes a projection matrix and returns the six plane coordinates
        //     that define a projection frustum.
        public FrustumPlanes decomposeProjection { get; }
        //
        // 摘要:
        //     The inverse of this matrix. (Read Only)
        public Matrix4x4 inverse { get; }

        public static float Determinant(Matrix4x4 m);
        //
        // 摘要:
        //     This function returns a projection matrix with viewing frustum that has a near
        //     plane defined by the coordinates that were passed in.
        //
        // 参数:
        //   left:
        //     The X coordinate of the left side of the near projection plane in view space.
        //
        //   right:
        //     The X coordinate of the right side of the near projection plane in view space.
        //
        //   bottom:
        //     The Y coordinate of the bottom side of the near projection plane in view space.
        //
        //   top:
        //     The Y coordinate of the top side of the near projection plane in view space.
        //
        //   zNear:
        //     Z distance to the near plane from the origin in view space.
        //
        //   zFar:
        //     Z distance to the far plane from the origin in view space.
        //
        //   frustumPlanes:
        //     Frustum planes struct that contains the view space coordinates of that define
        //     a viewing frustum.
        //
        //   fp:
        //
        // 返回结果:
        //     A projection matrix with a viewing frustum defined by the plane coordinates passed
        //     in.
        [FreeFunctionAttribute("MatrixScripting::Frustum", IsThreadSafe = true)]
        public static Matrix4x4 Frustum(float left, float right, float bottom, float top, float zNear, float zFar);
        //
        // 摘要:
        //     This function returns a projection matrix with viewing frustum that has a near
        //     plane defined by the coordinates that were passed in.
        //
        // 参数:
        //   left:
        //     The X coordinate of the left side of the near projection plane in view space.
        //
        //   right:
        //     The X coordinate of the right side of the near projection plane in view space.
        //
        //   bottom:
        //     The Y coordinate of the bottom side of the near projection plane in view space.
        //
        //   top:
        //     The Y coordinate of the top side of the near projection plane in view space.
        //
        //   zNear:
        //     Z distance to the near plane from the origin in view space.
        //
        //   zFar:
        //     Z distance to the far plane from the origin in view space.
        //
        //   frustumPlanes:
        //     Frustum planes struct that contains the view space coordinates of that define
        //     a viewing frustum.
        //
        //   fp:
        //
        // 返回结果:
        //     A projection matrix with a viewing frustum defined by the plane coordinates passed
        //     in.
        public static Matrix4x4 Frustum(FrustumPlanes fp);
        [FreeFunctionAttribute("MatrixScripting::Inverse", IsThreadSafe = true)]
        public static Matrix4x4 Inverse(Matrix4x4 m);
        [FreeFunctionAttribute("MatrixScripting::Inverse3DAffine", IsThreadSafe = true)]
        public static bool Inverse3DAffine(Matrix4x4 input, ref Matrix4x4 result);
        //
        // 摘要:
        //     Create a "look at" matrix.
        //
        // 参数:
        //   from:
        //     The source point.
        //
        //   to:
        //     The target point.
        //
        //   up:
        //     The vector describing the up direction (typically Vector3.up).
        //
        // 返回结果:
        //     The resulting transformation matrix.
        [FreeFunctionAttribute("MatrixScripting::LookAt", IsThreadSafe = true)]
        public static Matrix4x4 LookAt(Vector3 from, Vector3 to, Vector3 up);
        //
        // 摘要:
        //     Create an orthogonal projection matrix.
        //
        // 参数:
        //   left:
        //     Left-side x-coordinate.
        //
        //   right:
        //     Right-side x-coordinate.
        //
        //   bottom:
        //     Bottom y-coordinate.
        //
        //   top:
        //     Top y-coordinate.
        //
        //   zNear:
        //     Near depth clipping plane value.
        //
        //   zFar:
        //     Far depth clipping plane value.
        //
        // 返回结果:
        //     The projection matrix.
        [FreeFunctionAttribute("MatrixScripting::Ortho", IsThreadSafe = true)]
        public static Matrix4x4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar);
        //
        // 摘要:
        //     Create a perspective projection matrix.
        //
        // 参数:
        //   fov:
        //     Vertical field-of-view in degrees.
        //
        //   aspect:
        //     Aspect ratio (width divided by height).
        //
        //   zNear:
        //     Near depth clipping plane value.
        //
        //   zFar:
        //     Far depth clipping plane value.
        //
        // 返回结果:
        //     The projection matrix.
        [FreeFunctionAttribute("MatrixScripting::Perspective", IsThreadSafe = true)]
        public static Matrix4x4 Perspective(float fov, float aspect, float zNear, float zFar);
        //
        // 摘要:
        //     Creates a rotation matrix.
        //
        // 参数:
        //   q:
        public static Matrix4x4 Rotate(Quaternion q);


        /*
            Creates a scaling matrix.
            Returned matrix is such that scales along coordinate axes by a vector v.

            比如传入参数 (1,2,1), 则让矩阵在 y轴方向拉伸 2倍;
            传入参数 (1,1,-1), 则让矩阵在 z轴 方向翻转;
        */
        public static Matrix4x4 Scale(Vector3 vector);


        //
        // 摘要:
        //     Creates a translation matrix.
        //
        // 参数:
        //   vector:
        public static Matrix4x4 Translate(Vector3 vector);
        [FreeFunctionAttribute("MatrixScripting::Transpose", IsThreadSafe = true)]
        public static Matrix4x4 Transpose(Matrix4x4 m);
        //
        // 摘要:
        //     Creates a translation, rotation and scaling matrix.
        //
        // 参数:
        //   pos:
        //
        //   q:
        //
        //   s:
        [FreeFunctionAttribute("MatrixScripting::TRS", IsThreadSafe = true)]
        public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s);
        public override bool Equals(object other);
        public bool Equals(Matrix4x4 other);
        //
        // 摘要:
        //     Get a column of the matrix.
        //
        // 参数:
        //   index:
        public Vector4 GetColumn(int index);
        public override int GetHashCode();
        //
        // 摘要:
        //     Returns a row of the matrix.
        //
        // 参数:
        //   index:
        public Vector4 GetRow(int index);
        //
        // 摘要:
        //     Transforms a position by this matrix (generic).
        //
        // 参数:
        //   point:
        public Vector3 MultiplyPoint(Vector3 point);
        //
        // 摘要:
        //     Transforms a position by this matrix (fast).
        //
        // 参数:
        //   point:
        public Vector3 MultiplyPoint3x4(Vector3 point);
        //
        // 摘要:
        //     Transforms a direction by this matrix.
        //
        // 参数:
        //   vector:
        public Vector3 MultiplyVector(Vector3 vector);
        //
        // 摘要:
        //     Sets a column of the matrix.
        //
        // 参数:
        //   index:
        //
        //   column:
        public void SetColumn(int index, Vector4 column);
        //
        // 摘要:
        //     Sets a row of the matrix.
        //
        // 参数:
        //   index:
        //
        //   row:
        public void SetRow(int index, Vector4 row);
        //
        // 摘要:
        //     Sets this matrix to a translation, rotation and scaling matrix.
        //
        // 参数:
        //   pos:
        //
        //   q:
        //
        //   s:
        public void SetTRS(Vector3 pos, Quaternion q, Vector3 s);
        //
        // 摘要:
        //     Returns a formatted string for this matrix.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format, IFormatProvider formatProvider);
        //
        // 摘要:
        //     Returns a formatted string for this matrix.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public override string ToString();
        //
        // 摘要:
        //     Returns a formatted string for this matrix.
        //
        // 参数:
        //   format:
        //     A numeric format string.
        //
        //   formatProvider:
        //     An object that specifies culture-specific formatting.
        public string ToString(string format);
        //
        // 摘要:
        //     Returns a plane that is transformed in space.
        //
        // 参数:
        //   plane:
        public Plane TransformPlane(Plane plane);
        //
        // 摘要:
        //     Checks if this matrix is a valid transform matrix.
        [ThreadSafeAttribute]
        public bool ValidTRS();

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 vector);
        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs);
        public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs);
        public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs);
    }
}
