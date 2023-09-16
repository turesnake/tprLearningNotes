#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Collections.Generic;

namespace System.IO
{
    public sealed class DirectoryInfo : FileSystemInfo
    {
        public DirectoryInfo(string path);

        public override string Name { get; }
        public override bool Exists { get; }
        public DirectoryInfo Parent { get; }
        public DirectoryInfo Root { get; }

        public void Create();
        public DirectoryInfo CreateSubdirectory(string path);
        public override void Delete();
        public void Delete(bool recursive);
        public IEnumerable<DirectoryInfo> EnumerateDirectories();
        public IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern);
        public IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption);
        public IEnumerable<FileInfo> EnumerateFiles();
        public IEnumerable<FileInfo> EnumerateFiles(string searchPattern);
        public IEnumerable<FileInfo> EnumerateFiles(string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<FileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption);
        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos();
        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption);
        public DirectoryInfo[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions);
        public DirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption);
        public DirectoryInfo[] GetDirectories(string searchPattern);
        public DirectoryInfo[] GetDirectories();
        public FileInfo[] GetFiles(string searchPattern);
        public FileInfo[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions);
        public FileInfo[] GetFiles(string searchPattern, SearchOption searchOption);
        public FileInfo[] GetFiles();
        public FileSystemInfo[] GetFileSystemInfos();
        public FileSystemInfo[] GetFileSystemInfos(string searchPattern);
        public FileSystemInfo[] GetFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions);
        public FileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption);
        public void MoveTo(string destDirName);
        public override string ToString();
    }
}