#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Runtime.Serialization;

namespace System.IO
{
    /*
        想要 fullpath, 直接访问 .FullName
    */
    public abstract class FileSystemInfo : MarshalByRefObject, ISerializable
    {
        protected string FullPath;
        protected string OriginalPath;

        protected FileSystemInfo();
        protected FileSystemInfo(SerializationInfo info, StreamingContext context);

        public DateTime LastWriteTime { get; set; }
        public DateTime LastAccessTimeUtc { get; set; } // Utc time 是全球统一时间, 没事不要用这个

        // 最后一次打开文件的时间
        // 就算是视频文件也起效
        public DateTime LastAccessTime { get; set; }
        public virtual string FullName { get; }         // 这个就是 FullPath
        public string Extension { get; }
        public abstract bool Exists { get; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTimeUtc { get; set; } // Utc time 是全球统一时间, 没事不要用这个
        public FileAttributes Attributes { get; set; }
        public DateTime CreationTimeUtc { get; set; } // Utc time 是全球统一时间, 没事不要用这个
        public abstract string Name { get; }

        public abstract void Delete();
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
        public void Refresh();
        public override string ToString();
    }
}