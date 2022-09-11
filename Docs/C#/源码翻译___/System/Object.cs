#region 程序集 mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// mscorlib.dll
#endregion

using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class Object
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public Object();

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        ~Object();

        public static bool Equals(Object objA, Object objB);

        /*
            true if objA is the same instance as objB or if both are null; otherwise, false.
            ---
            判断两个 引用 是否相同;

            和 Equals method and the equality operator 不同, 本函数不能被覆写;

            -- 当两参数为 值类型, 本函数可能会判断出错, 因为中间涉及把 值类型 boxed 这么一个过程;
            -- 当两个参数为 string 类型时, 
                --
                如果两参数为 "interned", (猜测为类似 const int 的立即字符串), 比如:
                    a1 = "KOKO";
                    a2 = "KOKO";
                那么这两参数 调用本函数 将得到 true;

                --
                如果不是 "interned", 比如:
                    string m = "pp";
                    a1 = "KOKO" + m;
                    a2 = "KOKO" + m;
                那么这两参数 调用本函数 将得到 false;
        */
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static bool ReferenceEquals(Object objA, Object objB);



        public virtual bool Equals(Object obj);
        public virtual int GetHashCode();

        // Gets the Type of the current instance.
        //如果调用者为 null, 会报错;
        [SecuritySafeCritical]public Type GetType();


        public virtual string ToString();
        [SecuritySafeCritical]
        protected Object MemberwiseClone();
    }
}

