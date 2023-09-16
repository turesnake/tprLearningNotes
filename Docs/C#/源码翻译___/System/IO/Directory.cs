#region Assembly mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\UnityReferenceAssemblies\unity-4.8-api\mscorlib.dll
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;

namespace System.IO
{
    [ComVisible(true)]
    public static class Directory
    {
        [SecuritySafeCritical]
        public static DirectoryInfo CreateDirectory(string path);
        [SecuritySafeCritical]
        public static DirectoryInfo CreateDirectory(string path, DirectorySecurity directorySecurity);
        [SecuritySafeCritical]
        public static void Delete(string path);
        [SecuritySafeCritical]
        public static void Delete(string path, bool recursive);
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public static IEnumerable<string> EnumerateDirectories(string path);
        public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
        public static IEnumerable<string> EnumerateFiles(string path);
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern);
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public static IEnumerable<string> EnumerateFileSystemEntries(string path);
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        [SecuritySafeCritical]
        public static bool Exists(string path);
        public static DirectorySecurity GetAccessControl(string path);
        public static DirectorySecurity GetAccessControl(string path, AccessControlSections includeSections);
        public static DateTime GetCreationTime(string path);
        public static DateTime GetCreationTimeUtc(string path);
        [SecuritySafeCritical]
        public static string GetCurrentDirectory();
        public static string[] GetDirectories(string path);
        public static string[] GetDirectories(string path, string searchPattern);
        public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        public static string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        [SecuritySafeCritical]
        public static string GetDirectoryRoot(string path);
        public static string[] GetFiles(string path, string searchPattern);
        public static string[] GetFiles(string path);
        public static string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
        public static string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        public static string[] GetFileSystemEntries(string path);
        public static string[] GetFileSystemEntries(string path, string searchPattern);
        public static string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public static DateTime GetLastAccessTime(string path);
        public static DateTime GetLastAccessTimeUtc(string path);
        public static DateTime GetLastWriteTime(string path);
        public static DateTime GetLastWriteTimeUtc(string path);
        [SecuritySafeCritical]
        public static string[] GetLogicalDrives();
        public static DirectoryInfo GetParent(string path);
        [SecuritySafeCritical]
        public static void Move(string sourceDirName, string destDirName);
        [SecuritySafeCritical]
        public static void SetAccessControl(string path, DirectorySecurity directorySecurity);
        public static void SetCreationTime(string path, DateTime creationTime);
        [SecuritySafeCritical]
        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        [SecuritySafeCritical]
        public static void SetCurrentDirectory(string path);
        public static void SetLastAccessTime(string path, DateTime lastAccessTime);
        [SecuritySafeCritical]
        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        public static void SetLastWriteTime(string path, DateTime lastWriteTime);
        [SecuritySafeCritical]
        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }
}