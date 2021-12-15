
#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace UnityEngine.Assertions
{
    /*
        The Assert class contains assertion methods for setting invariants in the code.
        ---

        unity 为我们准备的一系列 assert 函数 (断言);

    */
    [DebuggerStepThrough]
    public static class Assert//Assert__RR
    {
        //
        // 摘要:
        //     Set to true to throw an exception when assertion methods fail and false if otherwise.
        //     This value defaults to true.
        [Obsolete("Future versions of Unity are expected to always throw exceptions and not have this field.")]
        public static bool raiseExceptions;

        //
        // 摘要:
        //     Assert the values are approximately equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message);
        //
        // 摘要:
        //     Assert the values are approximately equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, float tolerance);
        //
        // 摘要:
        //     Assert the values are approximately equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual);
        //
        // 摘要:
        //     Assert the values are approximately equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreApproximatelyEqual(float expected, float actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ushort expected, ushort actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ushort expected, ushort actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(byte expected, byte actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(uint expected, uint actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(char expected, char actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(char expected, char actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(sbyte expected, sbyte actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(sbyte expected, sbyte actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(int expected, int actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(int expected, int actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(uint expected, uint actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(byte expected, byte actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(short expected, short actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(short expected, short actual);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual, string message);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual<T>(T expected, T actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ulong expected, ulong actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(ulong expected, ulong actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(Object expected, Object actual, string message);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(long expected, long actual);
        //
        // 摘要:
        //     Assert that the values are equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreEqual(long expected, long actual, string message);
        //
        // 摘要:
        //     Asserts that the values are approximately not equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, string message);
        //
        // 摘要:
        //     Asserts that the values are approximately not equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message);
        //
        // 摘要:
        //     Asserts that the values are approximately not equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance);
        //
        // 摘要:
        //     Asserts that the values are approximately not equal.
        //
        // 参数:
        //   tolerance:
        //     Tolerance of approximation.
        //
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotApproximatelyEqual(float expected, float actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(short expected, short actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(short expected, short actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(long expected, long actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(uint expected, uint actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ushort expected, ushort actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ushort expected, ushort actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(int expected, int actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(int expected, int actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(long expected, long actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(uint expected, uint actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(sbyte expected, sbyte actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(char expected, char actual);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual, string message);
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(char expected, char actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(Object expected, Object actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(byte expected, byte actual, string message);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(byte expected, byte actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ulong expected, ulong actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(sbyte expected, sbyte actual);
        //
        // 摘要:
        //     Assert that the values are not equal.
        //
        // 参数:
        //   expected:
        //     The assumed Assert value.
        //
        //   actual:
        //     The exact Assert value.
        //
        //   message:
        //     The string used to describe the Assert.
        //
        //   comparer:
        //     Method to compare expected and actual arguments have the same value.
        [Conditional("UNITY_ASSERTIONS")]
        public static void AreNotEqual(ulong expected, ulong actual, string message);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Assert.Equals should not be used for Assertions", true)]
        public static bool Equals(object obj1, object obj2);
        //
        // 摘要:
        //     Return true when the condition is false. Otherwise return false.
        //
        // 参数:
        //   condition:
        //     true or false.
        //
        //   message:
        //     The string used to describe the result of the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition, string message);
        //
        // 摘要:
        //     Return true when the condition is false. Otherwise return false.
        //
        // 参数:
        //   condition:
        //     true or false.
        //
        //   message:
        //     The string used to describe the result of the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsFalse(bool condition);



        



        /*
            Assert that the value is not null.
            检查参数 value 是否 "不为null";

            若为 null, 抛出异常;
            
        // 参数:
        //   value:
        //     The Object or type being checked for. 要检测的对象
        //
        //   message:
        //     The string used to describe the Assert.
        */
        [Conditional("UNITY_ASSERTIONS")]public static void IsNotNull<T>(T value) where T : class;
        [Conditional("UNITY_ASSERTIONS")]public static void IsNotNull(Object value, string message);
        [Conditional("UNITY_ASSERTIONS")]public static void IsNotNull<T>(T value, string message) where T : class;



        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull<T>(T value, string message) where T : class;
        //
        // 摘要:
        //     Assert the value is null.
        //
        // 参数:
        //   value:
        //     The Object or type being checked for.
        //
        //   message:
        //     The string used to describe the Assert.
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull(Object value, string message);
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsNull<T>(T value) where T : class;
        //
        // 摘要:
        //     Asserts that the condition is true.
        //
        // 参数:
        //   message:
        //     The string used to describe the Assert.
        //
        //   condition:
        //     true or false.
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition, string message);
        //
        // 摘要:
        //     Asserts that the condition is true.
        //
        // 参数:
        //   message:
        //     The string used to describe the Assert.
        //
        //   condition:
        //     true or false.
        [Conditional("UNITY_ASSERTIONS")]
        public static void IsTrue(bool condition);
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Assert.ReferenceEquals should not be used for Assertions", true)]
        public static bool ReferenceEquals(object obj1, object obj2);
    }
}

