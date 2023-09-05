#region Assembly mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\UnityReferenceAssemblies\unity-4.8-api\mscorlib.dll
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    [ComVisible(true)]
    public static class File
    {
        public static void AppendAllLines(string path, IEnumerable<string> contents);
        public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        public static void AppendAllText(string path, string contents);
        public static void AppendAllText(string path, string contents, Encoding encoding);
        public static Task AppendAllTextAsync(string path, string contents, CancellationToken cancellationToken = default);
        public static Task AppendAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);
        public static StreamWriter AppendText(string path);
        public static void Copy(string sourceFileName, string destFileName, bool overwrite);
        public static void Copy(string sourceFileName, string destFileName);
        public static FileStream Create(string path, int bufferSize, FileOptions options);
        public static FileStream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity);
        public static FileStream Create(string path);
        public static FileStream Create(string path, int bufferSize);
        public static StreamWriter CreateText(string path);
        [SecuritySafeCritical]
        public static void Decrypt(string path);
        [SecuritySafeCritical]
        public static void Delete(string path);
        [SecuritySafeCritical]
        public static void Encrypt(string path);
        [SecuritySafeCritical]
        public static bool Exists(string path);
        public static FileSecurity GetAccessControl(string path);
        public static FileSecurity GetAccessControl(string path, AccessControlSections includeSections);
        [SecuritySafeCritical]
        public static FileAttributes GetAttributes(string path);
        [SecuritySafeCritical]
        public static DateTime GetCreationTime(string path);
        [SecuritySafeCritical]
        public static DateTime GetCreationTimeUtc(string path);
        [SecuritySafeCritical]
        public static DateTime GetLastAccessTime(string path);
        [SecuritySafeCritical]
        public static DateTime GetLastAccessTimeUtc(string path);
        [SecuritySafeCritical]
        public static DateTime GetLastWriteTime(string path);
        [SecuritySafeCritical]
        public static DateTime GetLastWriteTimeUtc(string path);
        [SecuritySafeCritical]
        public static void Move(string sourceFileName, string destFileName);
        public static FileStream Open(string path, FileMode mode);
        public static FileStream Open(string path, FileMode mode, FileAccess access);
        public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share);
        public static FileStream OpenRead(string path);
        public static StreamReader OpenText(string path);
        public static FileStream OpenWrite(string path);
        [SecuritySafeCritical]
        public static byte[] ReadAllBytes(string path);
        public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);
        public static string[] ReadAllLines(string path, Encoding encoding);
        public static string[] ReadAllLines(string path);
        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
        [SecuritySafeCritical]
        public static string ReadAllText(string path);
        [SecuritySafeCritical]
        public static string ReadAllText(string path, Encoding encoding);
        public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);
        public static Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
        public static IEnumerable<string> ReadLines(string path);
        public static IEnumerable<string> ReadLines(string path, Encoding encoding);
        public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);
        public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
        [SecuritySafeCritical]
        public static void SetAccessControl(string path, FileSecurity fileSecurity);
        [SecuritySafeCritical]
        public static void SetAttributes(string path, FileAttributes fileAttributes);
        public static void SetCreationTime(string path, DateTime creationTime);
        [SecuritySafeCritical]
        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        public static void SetLastAccessTime(string path, DateTime lastAccessTime);
        [SecuritySafeCritical]
        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        public static void SetLastWriteTime(string path, DateTime lastWriteTime);
        [SecuritySafeCritical]
        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
        [SecuritySafeCritical]
        public static void WriteAllBytes(string path, byte[] bytes);
        public static Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);
        public static void WriteAllLines(string path, string[] contents, Encoding encoding);
        public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
        public static void WriteAllLines(string path, IEnumerable<string> contents);
        public static void WriteAllLines(string path, string[] contents);
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        [SecuritySafeCritical]
        public static void WriteAllText(string path, string contents);
        [SecuritySafeCritical]
        public static void WriteAllText(string path, string contents, Encoding encoding);
        public static Task WriteAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);
        public static Task WriteAllTextAsync(string path, string contents, CancellationToken cancellationToken = default);
    }
}