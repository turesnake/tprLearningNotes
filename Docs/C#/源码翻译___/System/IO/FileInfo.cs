#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion


namespace System.IO
{
    public sealed class FileInfo : FileSystemInfo
    {
        public FileInfo(string fileName);

        public bool IsReadOnly { get; set; }
        public override bool Exists { get; }
        public string DirectoryName { get; }
        public DirectoryInfo Directory { get; }
        public long Length { get; }     // bytes
        public override string Name { get; }

        public StreamWriter AppendText();
        public FileInfo CopyTo(string destFileName);
        public FileInfo CopyTo(string destFileName, bool overwrite);
        public FileStream Create();
        public StreamWriter CreateText();
        public void Decrypt();
        public override void Delete();
        public void Encrypt();
        public void MoveTo(string destFileName);
        public FileStream Open(FileMode mode, FileAccess access, FileShare share);
        public FileStream Open(FileMode mode, FileAccess access);
        public FileStream Open(FileMode mode);
        public FileStream OpenRead();
        public StreamReader OpenText();
        public FileStream OpenWrite();
        public FileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
        public FileInfo Replace(string destinationFileName, string destinationBackupFileName);
        public override string ToString();
    }
}