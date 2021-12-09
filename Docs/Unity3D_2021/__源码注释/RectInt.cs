
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine
{
    /*
        A 2D Rectangle defined by x, y, width, height with integers.
        
    */
    [UsedByNativeCodeAttribute]
    public struct RectInt//RectInt__RR
        : IEquatable<RectInt>, IFormattable
    {
        public RectInt(Vector2Int position, Vector2Int size);
        public RectInt(int xMin, int yMin, int width, int height);

        //
        // 摘要:
        //     Center coordinate of the rectangle.
        public Vector2 center { get; }
        //
        // 摘要:
        //     Shows the minimum X value of the RectInt.
        public int xMin { get; set; }
        //
        // 摘要:
        //     Height of the rectangle.
        public int height { get; set; }
        //
        // 摘要:
        //     Width of the rectangle.
        public int width { get; set; }
        //
        // 摘要:
        //     The upper right corner of the rectangle; which is the maximal position of the
        //     rectangle along the x- and y-axes, when it is aligned to both axes.
        public Vector2Int max { get; set; }
        //
        // 摘要:
        //     The lower left corner of the rectangle; which is the minimal position of the
        //     rectangle along the x- and y-axes, when it is aligned to both axes.
        public Vector2Int min { get; set; }
        //
        // 摘要:
        //     A RectInt.PositionCollection that contains all positions within the RectInt.
        public PositionEnumerator allPositionsWithin { get; }
        //
        // 摘要:
        //     Top coordinate of the rectangle.
        public int y { get; set; }
        //
        // 摘要:
        //     Shows the maximum X value of the RectInt.
        public int xMax { get; set; }
        //
        // 摘要:
        //     Show the minimum Y value of the RectInt.
        public int yMin { get; set; }
        //
        // 摘要:
        //     Shows the maximum Y value of the RectInt.
        public int yMax { get; set; }
        //
        // 摘要:
        //     Returns the position (x, y) of the RectInt.
        public Vector2Int position { get; set; }
        //
        // 摘要:
        //     Returns the width and height of the RectInt.
        public Vector2Int size { get; set; }
        //
        // 摘要:
        //     Left coordinate of the rectangle.
        public int x { get; set; }

        //
        // 摘要:
        //     Clamps the position and size of the RectInt to the given bounds.
        //
        // 参数:
        //   bounds:
        //     Bounds to clamp the RectInt.
        public void ClampToBounds(RectInt bounds);
        //
        // 摘要:
        //     Returns true if the given position is within the RectInt.
        //
        // 参数:
        //   position:
        //     Position to check.
        //
        // 返回结果:
        //     Whether the position is within the RectInt.
        public bool Contains(Vector2Int position);
        //
        // 摘要:
        //     Returns true if the given RectInt is equal to this RectInt.
        //
        // 参数:
        //   other:
        public bool Equals(RectInt other);
        //
        // 摘要:
        //     RectInts overlap if each RectInt Contains a shared point.
        //
        // 参数:
        //   other:
        //     Other rectangle to test overlapping with.
        //
        // 返回结果:
        //     True if the other rectangle overlaps this one.
        public bool Overlaps(RectInt other);
        //
        // 摘要:
        //     Sets the bounds to the min and max value of the rect.
        //
        // 参数:
        //   minPosition:
        //
        //   maxPosition:
        public void SetMinMax(Vector2Int minPosition, Vector2Int maxPosition);
        //
        // 摘要:
        //     Returns the x, y, width and height of the RectInt.
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
        //     Returns the x, y, width and height of the RectInt.
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
        //     Returns the x, y, width and height of the RectInt.
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
        //     An iterator that allows you to iterate over all positions within the RectInt.
        public struct PositionEnumerator : IEnumerator<Vector2Int>, IEnumerator, IDisposable
        {
            public PositionEnumerator(Vector2Int min, Vector2Int max);

            //
            // 摘要:
            //     Current position of the enumerator.
            public Vector2Int Current { get; }

            //
            // 摘要:
            //     Returns this as an iterator that allows you to iterate over all positions within
            //     the RectInt.
            //
            // 返回结果:
            //     This RectInt.PositionEnumerator.
            public PositionEnumerator GetEnumerator();
            //
            // 摘要:
            //     Moves the enumerator to the next position.
            //
            // 返回结果:
            //     Whether the enumerator has successfully moved to the next position.
            public bool MoveNext();
            //
            // 摘要:
            //     Resets this enumerator to its starting state.
            public void Reset();
        }
    }
}

