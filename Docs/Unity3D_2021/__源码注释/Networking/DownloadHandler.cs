#region Assembly UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking;

//
// Summary:
//     Manage and process HTTP response body data received from a remote server.
[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
public class DownloadHandler : IDisposable
{
    [NonSerialized]
    [VisibleToOtherModules]
    internal IntPtr m_Ptr;

    //
    // Summary:
    //     Returns true if this DownloadHandler has been informed by its parent UnityWebRequest
    //     that all data has been received, and this DownloadHandler has completed any necessary
    //     post-download processing. (Read Only)
    public bool isDone => IsDone();

    //
    // Summary:
    //     Error message describing a failure that occurred inside the download handler.
    public string error => GetErrorMsg();

    //
    // Summary:
    //     Provides direct access to downloaded data.
    public NativeArray<byte>.ReadOnly nativeData => GetNativeData().AsReadOnly();

    //
    // Summary:
    //     Returns the raw bytes downloaded from the remote server, or null. (Read Only)
    public byte[] data => GetData();

    //
    // Summary:
    //     Convenience property. Returns the bytes from data interpreted as a UTF8 string.
    //     (Read Only)
    public string text => GetText();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsThreadSafe = true)]
    private extern void Release();

    [VisibleToOtherModules]
    internal DownloadHandler()
    {
    }

    ~DownloadHandler()
    {
        Dispose();
    }

    //
    // Summary:
    //     Signals that this DownloadHandler is no longer being used, and should clean up
    //     any resources it is using.
    public virtual void Dispose()
    {
        if (m_Ptr != IntPtr.Zero)
        {
            Release();
            m_Ptr = IntPtr.Zero;
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool IsDone();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string GetErrorMsg();

    //
    // Summary:
    //     Provides allocation-free access to the downloaded data as a NativeArray.
    //
    // Returns:
    //     NativeArray providing access to downloaded data.
    protected virtual NativeArray<byte> GetNativeData()
    {
        return default(NativeArray<byte>);
    }

    //
    // Summary:
    //     Callback, invoked when the data property is accessed.
    //
    // Returns:
    //     Byte array to return as the value of the data property.
    protected virtual byte[] GetData()
    {
        return InternalGetByteArray(this);
    }

    //
    // Summary:
    //     Callback, invoked when the text property is accessed.
    //
    // Returns:
    //     String to return as the return value of the text property.
    protected unsafe virtual string GetText()
    {
        NativeArray<byte> nativeArray = GetNativeData();
        if (nativeArray.IsCreated && nativeArray.Length > 0)
        {
            return new string((sbyte*)nativeArray.GetUnsafeReadOnlyPtr(), 0, nativeArray.Length, GetTextEncoder());
        }

        return "";
    }

    private Encoding GetTextEncoder()
    {
        string contentType = GetContentType();
        if (!string.IsNullOrEmpty(contentType))
        {
            int num = contentType.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
            if (num > -1)
            {
                int num2 = contentType.IndexOf('=', num);
                if (num2 > -1)
                {
                    string text = contentType.Substring(num2 + 1).Trim().Trim('\'', '"')
                        .Trim();
                    int num3 = text.IndexOf(';');
                    if (num3 > -1)
                    {
                        text = text.Substring(0, num3);
                    }

                    try
                    {
                        return Encoding.GetEncoding(text);
                    }
                    catch (ArgumentException ex)
                    {
                        Debug.LogWarning($"Unsupported encoding '{text}': {ex.Message}");
                    }
                    catch (NotSupportedException ex2)
                    {
                        Debug.LogWarning($"Unsupported encoding '{text}': {ex2.Message}");
                    }
                }
            }
        }

        return Encoding.UTF8;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string GetContentType();

    //
    // Summary:
    //     Callback, invoked as data is received from the remote server.
    //
    // Parameters:
    //   data:
    //     A buffer containing unprocessed data, received from the remote server.
    //
    //   dataLength:
    //     The number of bytes in data which are new.
    //
    // Returns:
    //     True if the download should continue, false to abort.
    [UsedByNativeCode]
    protected virtual bool ReceiveData(byte[] data, int dataLength)
    {
        return true;
    }

    //
    // Summary:
    //     Callback, invoked with a Content-Length header is received.
    //
    // Parameters:
    //   contentLength:
    //     The value of the received Content-Length header.
    [RequiredByNativeCode]
    protected virtual void ReceiveContentLengthHeader(ulong contentLength)
    {
        ReceiveContentLength((int)contentLength);
    }

    //
    // Summary:
    //     Callback, invoked with a Content-Length header is received.
    //
    // Parameters:
    //   contentLength:
    //     The value of the received Content-Length header.
    [Obsolete("Use ReceiveContentLengthHeader")]
    protected virtual void ReceiveContentLength(int contentLength)
    {
    }

    //
    // Summary:
    //     Callback, invoked when all data has been received from the remote server.
    [UsedByNativeCode]
    protected virtual void CompleteContent()
    {
    }

    //
    // Summary:
    //     Callback, invoked when UnityWebRequest.downloadProgress is accessed.
    //
    // Returns:
    //     The return value for UnityWebRequest.downloadProgress.
    [UsedByNativeCode]
    protected virtual float GetProgress()
    {
        return 0f;
    }

    protected static T GetCheckedDownloader<T>(UnityWebRequest www) where T : DownloadHandler
    {
        if (www == null)
        {
            throw new NullReferenceException("Cannot get content from a null UnityWebRequest object");
        }

        if (!www.isDone)
        {
            throw new InvalidOperationException("Cannot get content from an unfinished UnityWebRequest object");
        }

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            throw new InvalidOperationException(www.error);
        }

        return (T)www.downloadHandler;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    [VisibleToOtherModules]
    internal unsafe static extern byte* InternalGetByteArray(DownloadHandler dh, out int length);

    internal static byte[] InternalGetByteArray(DownloadHandler dh)
    {
        NativeArray<byte> nativeArray = dh.GetNativeData();
        if (nativeArray.IsCreated)
        {
            return nativeArray.ToArray();
        }

        return null;
    }

    internal unsafe static NativeArray<byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<byte> nativeArray)
    {
        int length;
        byte* bytes = InternalGetByteArray(dh, out length);
        if (nativeArray.IsCreated)
        {
            if (nativeArray.Length == length)
            {
                return nativeArray;
            }

            DisposeNativeArray(ref nativeArray);
        }

        CreateNativeArrayForNativeData(ref nativeArray, bytes, length);
        return nativeArray;
    }

    internal static void DisposeNativeArray(ref NativeArray<byte> data)
    {
        if (data.IsCreated)
        {
            AtomicSafetyHandle atomicSafetyHandle = NativeArrayUnsafeUtility.GetAtomicSafetyHandle(data);
            AtomicSafetyHandle.Release(atomicSafetyHandle);
            data = default(NativeArray<byte>);
        }
    }

    internal unsafe static void CreateNativeArrayForNativeData(ref NativeArray<byte> data, byte* bytes, int length)
    {
        data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(bytes, length, Allocator.Persistent);
        AtomicSafetyHandle safety = AtomicSafetyHandle.Create();
        NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref data, safety);
    }
}


