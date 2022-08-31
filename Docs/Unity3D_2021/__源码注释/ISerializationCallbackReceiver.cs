#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion


namespace UnityEngine
{
    /*

        Interface to receive callbacks upon serialization and deserialization.
        ---
        在 序列化 和 反序列化 时接收 callbacks 的接口。

        Unity's serializer is able to serialize most datatypes, but not all of them. In these cases, 
        there are two callbacks available for you to manually process these datatypes so that Unity can serialize and deserialise them.
        ---
        unity 的序列化器 可以 序列化大部分 数据类型, 但不是所有;
        此时就能用 本 class 提供的两种 callbacks 来手动处理这些 数据类型, 以便 unity 序列化 和 反序列化 它们;


        Care needs to be taken whilst within these callbacks, as Unity's serializer runs on a different thread to most of the Unity API. 
        It is advisable to only process fields directly owned by the object, keeping the processing burden as low as possible.
        ---
        由于 unity 的 序列化器 运行在另一个线程(和 unity 的大部分线程都不相同的线程), 此时要注意这些 callbacks 的使用;
        建议只处理 这个 obj 直接拥有的 fields，尽可能降低处理负担。

        Serialization can occur during all kinds of operations. 
        For example, when using Instantiate() to clone an object, Unity serializes and deserializes the original object in order to find internal references 
        to the original object, so that it can replace them with references to the cloned object. 
        In this situation, you can also employ the callbacks to update any internal references using types that Unity can't serialize.
        ---
        系列化 可能在任何操作时被触发;
        比如: 当调用 Instantiate() 复制一个 obj 时, unity 会序列化和反序列化 原始obj, 以便找到对 原始obj 的内部引用, 以便将这些引用重定位到 新的 obj 身上去;
        此时, 您还可以使用 回调 来 更新任何 "使用了 Unity 无法序列化的类型" 的内部引用,


        The callback interface only works with classes. It does not work with structs.
        This interface is supported on objects that are referenced by "SerializeReference". 
        The order of callback execution is not guaranteed between such objects. 
        However it is guaranteed that the main object's OnBeforeSerialize() callback would be invoked before those implemented by the referenced objects. 
        And OnAfterDeserialize() on the main object would be invoked after it is called on all the referenced objects.
        ---
        只能作用于 class, 不能用于 structs;

        这些objs 之间, 谁先调用 callbacks 的次序是不确定的;
        但可以确定的是, 主obj 的 OnBeforeSerialize() 要先于 引用对象,
        主obj 的 OnAfterDeserialize() 要晚于 引用对象,


        此文中有介绍:
        https://zhuanlan.zhihu.com/p/76247383


        其实c#也有类似的接口，如果不想走.Net提供的序列化方法，可以通过实现 ISerializable自定义序列化和反序列化过程

    */
    [RequiredByNativeCodeAttribute]
    public interface ISerializationCallbackReceiver
    {
        //
        // 摘要:
        //     Implement this method to receive a callback after Unity deserializes your object.
        [RequiredByNativeCodeAttribute]
        void OnAfterDeserialize();
        //
        // 摘要:
        //     Implement this method to receive a callback before Unity serializes your object.
        [RequiredByNativeCodeAttribute]
        void OnBeforeSerialize();
    }
}


