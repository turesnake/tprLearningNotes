#region Assembly UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.Bindings;
using UnityEngineInternal;

namespace UnityEngine.Networking;

//
// Summary:
//     Provides methods to communicate with web servers.
[StructLayout(LayoutKind.Sequential)]
[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequest.h")]
public class UnityWebRequest : IDisposable
{
    internal enum UnityWebRequestMethod
    {
        Get,
        Post,
        Put,
        Head,
        Custom
    }

    internal enum UnityWebRequestError
    {
        OK,
        Unknown,
        SDKError,
        UnsupportedProtocol,
        MalformattedUrl,
        CannotResolveProxy,
        CannotResolveHost,
        CannotConnectToHost,
        AccessDenied,
        GenericHttpError,
        WriteError,
        ReadError,
        OutOfMemory,
        Timeout,
        HTTPPostError,
        SSLCannotConnect,
        Aborted,
        TooManyRedirects,
        ReceivedNoData,
        SSLNotSupported,
        FailedToSendData,
        FailedToReceiveData,
        SSLCertificateError,
        SSLCipherNotAvailable,
        SSLCACertError,
        UnrecognizedContentEncoding,
        LoginFailed,
        SSLShutdownFailed,
        NoInternetConnection
    }

    //
    // Summary:
    //     Defines codes describing the possible outcomes of a UnityWebRequest.
    public enum Result
    {
        //
        // Summary:
        //     The request hasn't finished yet.
        InProgress,
        //
        // Summary:
        //     The request succeeded.
        Success,
        //
        // Summary:
        //     Failed to communicate with the server. For example, the request couldn't connect
        //     or it could not establish a secure channel.
        ConnectionError,
        //
        // Summary:
        //     The server returned an error response. The request succeeded in communicating
        //     with the server, but received an error as defined by the connection protocol.
        ProtocolError,
        //
        // Summary:
        //     Error processing data. The request succeeded in communicating with the server,
        //     but encountered an error when processing the received data. For example, the
        //     data was corrupted 损坏 or not in the correct format.
        DataProcessingError
    }

    [NonSerialized]
    internal IntPtr m_Ptr;

    [NonSerialized]
    internal DownloadHandler m_DownloadHandler;

    [NonSerialized]
    internal UploadHandler m_UploadHandler;

    [NonSerialized]
    internal CertificateHandler m_CertificateHandler;

    [NonSerialized]
    internal Uri m_Uri;

    //
    // Summary:
    //     The string "GET", commonly used as the verb for an HTTP GET request.
    public const string kHttpVerbGET = "GET";

    //
    // Summary:
    //     The string "HEAD", commonly used as the verb for an HTTP HEAD request.
    public const string kHttpVerbHEAD = "HEAD";

    //
    // Summary:
    //     The string "POST", commonly used as the verb for an HTTP POST request.
    public const string kHttpVerbPOST = "POST";

    //
    // Summary:
    //     The string "PUT", commonly used as the verb for an HTTP PUT request.
    public const string kHttpVerbPUT = "PUT";

    //
    // Summary:
    //     The string "CREATE", commonly used as the verb for an HTTP CREATE request.
    public const string kHttpVerbCREATE = "CREATE";

    //
    // Summary:
    //     The string "DELETE", commonly used as the verb for an HTTP DELETE request.
    public const string kHttpVerbDELETE = "DELETE";

    //
    // Summary:
    //     If true, any CertificateHandler attached to this UnityWebRequest will have CertificateHandler.Dispose
    //     called automatically when UnityWebRequest.Dispose is called.
    public bool disposeCertificateHandlerOnDispose { get; set; }

    //
    // Summary:
    //     If true, any DownloadHandler attached to this UnityWebRequest will have DownloadHandler.Dispose
    //     called automatically when UnityWebRequest.Dispose is called.
    public bool disposeDownloadHandlerOnDispose { get; set; }

    //
    // Summary:
    //     If true, any UploadHandler attached to this UnityWebRequest will have UploadHandler.Dispose
    //     called automatically when UnityWebRequest.Dispose is called.
    public bool disposeUploadHandlerOnDispose { get; set; }

    //
    // Summary:
    //     Defines the HTTP verb used by this UnityWebRequest, such as GET or POST.
    public string method
    {
        get
        {
            return GetMethod() switch
            {
                UnityWebRequestMethod.Get => "GET",
                UnityWebRequestMethod.Post => "POST",
                UnityWebRequestMethod.Put => "PUT",
                UnityWebRequestMethod.Head => "HEAD",
                _ => GetCustomMethod(),
            };
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Cannot set a UnityWebRequest's method to an empty or null string");
            }

            switch (value.ToUpper())
            {
                case "GET":
                    InternalSetMethod(UnityWebRequestMethod.Get);
                    break;
                case "POST":
                    InternalSetMethod(UnityWebRequestMethod.Post);
                    break;
                case "PUT":
                    InternalSetMethod(UnityWebRequestMethod.Put);
                    break;
                case "HEAD":
                    InternalSetMethod(UnityWebRequestMethod.Head);
                    break;
                default:
                    InternalSetCustomMethod(value.ToUpper());
                    break;
            }
        }
    }

    //
    // Summary:
    //     A human-readable string describing any system errors encountered by this UnityWebRequest
    //     object while handling HTTP requests or responses. (Read Only)
    public string error
    {
        get
        {
            switch (result)
            {
                case Result.InProgress:
                case Result.Success:
                    return null;
                case Result.ProtocolError:
                    return $"HTTP/1.1 {responseCode} {GetHTTPStatusString(responseCode)}";
                default:
                    return GetWebErrorString(GetError());
            }
        }
    }

    private extern bool use100Continue
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
        [MethodImpl(MethodImplOptions.InternalCall)]
        set;
    }

    //
    // Summary:
    //     Determines whether this UnityWebRequest will include Expect: 100-Continue in
    //     its outgoing request headers. (Default: true).
    public bool useHttpContinue
    {
        get
        {
            return use100Continue;
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent and its 100-Continue setting cannot be altered");
            }

            use100Continue = value;
        }
    }

    //
    // Summary:
    //     Defines the target URL for the UnityWebRequest to communicate with.
    public string url
    {
        get
        {
            return GetUrl();
        }
        set
        {
            string localUrl = "http://localhost/";
            InternalSetUrl(WebRequestUtils.MakeInitialUrl(value, localUrl));
        }
    }

    //
    // Summary:
    //     Defines the target URI for the UnityWebRequest to communicate with.
    public Uri uri
    {
        get
        {
            return new Uri(GetUrl());
        }
        set
        {
            if (!value.IsAbsoluteUri)
            {
                throw new ArgumentException("URI must be absolute");
            }

            InternalSetUrl(WebRequestUtils.MakeUriString(value, value.OriginalString, prependProtocol: false));
            m_Uri = value;
        }
    }

    //
    // Summary:
    //     The numeric HTTP response code returned by the server, such as 200, 404 or 500.
    //     (Read Only)
    public extern long responseCode
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Returns a floating-point value between 0.0 and 1.0, indicating the progress of
    //     uploading body data to the server.
    public float uploadProgress
    {
        get
        {
            if (!IsExecuting() && !isDone)
            {
                return -1f;
            }

            return GetUploadProgress();
        }
    }

    //
    // Summary:
    //     Returns true while a UnityWebRequest’s configuration properties can be altered.
    //     (Read Only)
    public extern bool isModifiable
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("IsModifiable")]
        get;
    }

    //
    // Summary:
    //     Returns true after the UnityWebRequest has finished communicating with the remote
    //     server. (Read Only)
    public bool isDone => result != Result.InProgress;

    //
    // Summary:
    //     Returns true after this UnityWebRequest encounters a system error. (Read Only)
    // [Obsolete("UnityWebRequest.isNetworkError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ConnectionError) instead.", false)]
    // public bool isNetworkError => result == Result.ConnectionError;

    //
    // Summary:
    //     Returns true after this UnityWebRequest receives an HTTP response code indicating
    //     an error. (Read Only)
    // [Obsolete("UnityWebRequest.isHttpError is deprecated. Use (UnityWebRequest.result == UnityWebRequest.Result.ProtocolError) instead.", false)]
    // public bool isHttpError => result == Result.ProtocolError;

    //
    // Summary:
    //     The result of this UnityWebRequest.
    public extern Result result
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [NativeMethod("GetResult")]
        get;
    }

    //
    // Summary:
    //     Returns a floating-point value between 0.0 and 1.0, indicating the progress of
    //     downloading body data from the server. (Read Only)
    public float downloadProgress
    {
        get
        {
            if (!IsExecuting() && !isDone)
            {
                return -1f;
            }

            return GetDownloadProgress();
        }
    }

    //
    // Summary:
    //     Returns the number of bytes of body data the system has uploaded to the remote
    //     server. (Read Only)
    public extern ulong uploadedBytes
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Returns the number of bytes of body data the system has downloaded from the remote
    //     server. (Read Only)
    public extern ulong downloadedBytes
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        get;
    }

    //
    // Summary:
    //     Indicates the number of redirects which this UnityWebRequest will follow before
    //     halting with a “Redirect Limit Exceeded” system error.
    public int redirectLimit
    {
        get
        {
            return GetRedirectLimit();
        }
        set
        {
            SetRedirectLimitFromScripting(value);
        }
    }

    //
    // Summary:
    //     **Deprecated.**. HTTP2 and many HTTP1.1 servers don't support this; we recommend
    //     leaving it set to false (default).
    // [Obsolete("HTTP/2 and many HTTP/1.1 servers don't support this; we recommend leaving it set to false (default).", false)]
    // public bool chunkedTransfer
    // {
    //     get
    //     {
    //         return GetChunked();
    //     }
    //     set
    //     {
    //         if (!isModifiable)
    //         {
    //             throw new InvalidOperationException("UnityWebRequest has already been sent and its chunked transfer encoding setting cannot be altered");
    //         }

    //         UnityWebRequestError unityWebRequestError = SetChunked(value);
    //         if (unityWebRequestError != 0)
    //         {
    //             throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
    //         }
    //     }
    // }

    //
    // Summary:
    //     Holds a reference to the UploadHandler object which manages body data to be uploaded
    //     to the remote server.
    public UploadHandler uploadHandler
    {
        get
        {
            return m_UploadHandler;
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the upload handler");
            }

            UnityWebRequestError unityWebRequestError = SetUploadHandler(value);
            if (unityWebRequestError != 0)
            {
                throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
            }

            m_UploadHandler = value;
        }
    }

    //
    // Summary:
    //     Holds a reference to a DownloadHandler object, which manages body data received
    //     from the remote server by this UnityWebRequest.
    public DownloadHandler downloadHandler
    {
        get
        {
            return m_DownloadHandler;
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the download handler");
            }

            UnityWebRequestError unityWebRequestError = SetDownloadHandler(value);
            if (unityWebRequestError != 0)
            {
                throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
            }

            m_DownloadHandler = value;
        }
    }

    //
    // Summary:
    //     Holds a reference to a CertificateHandler object, which manages certificate validation
    //     for this UnityWebRequest.
    public CertificateHandler certificateHandler
    {
        get
        {
            return m_CertificateHandler;
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the certificate handler");
            }

            UnityWebRequestError unityWebRequestError = SetCertificateHandler(value);
            if (unityWebRequestError != 0)
            {
                throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
            }

            m_CertificateHandler = value;
        }
    }

    //
    // Summary:
    //     Sets UnityWebRequest to attempt to abort after the number of seconds in timeout
    //     have passed.
    public int timeout
    {
        get
        {
            return GetTimeoutMsec() / 1000;
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
            }

            value = Math.Max(value, 0);
            UnityWebRequestError unityWebRequestError = SetTimeoutMsec(value * 1000);
            if (unityWebRequestError != 0)
            {
                throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
            }
        }
    }

    internal bool suppressErrorsToConsole
    {
        get
        {
            return GetSuppressErrorsToConsole();
        }
        set
        {
            if (!isModifiable)
            {
                throw new InvalidOperationException("UnityWebRequest has already been sent; cannot modify the timeout");
            }

            UnityWebRequestError unityWebRequestError = SetSuppressErrorsToConsole(value);
            if (unityWebRequestError != 0)
            {
                throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
            }
        }
    }

    // [Obsolete("UnityWebRequest.isError has been renamed to isNetworkError for clarity. (UnityUpgradable) -> isNetworkError", false)]
    // public bool isError => isNetworkError;

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsThreadSafe = true)]
    [NativeConditional("ENABLE_UNITYWEBREQUEST")]
    private static extern string GetWebErrorString(UnityWebRequestError err);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [VisibleToOtherModules]
    internal static extern string GetHTTPStatusString(long responseCode);

    //
    // Summary:
    //     Clears stored cookies from the cache.
    //
    // Parameters:
    //   domain:
    //     An optional URL to define which cookies are removed. Only cookies that apply
    //     to this URL will be removed from the cache.
    public static void ClearCookieCache()
    {
        ClearCookieCache(null, null);
    }

    public static void ClearCookieCache(Uri uri)
    {
        if (uri == null)
        {
            ClearCookieCache(null, null);
            return;
        }

        string host = uri.Host;
        string text = uri.AbsolutePath;
        if (text == "/")
        {
            text = null;
        }

        ClearCookieCache(host, text);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void ClearCookieCache(string domain, string path);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern IntPtr Create();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsThreadSafe = true)]
    private extern void Release();

    internal void InternalDestroy()
    {
        if (m_Ptr != IntPtr.Zero)
        {
            Abort();
            Release();
            m_Ptr = IntPtr.Zero;
        }
    }

    private void InternalSetDefaults()
    {
        disposeDownloadHandlerOnDispose = true;
        disposeUploadHandlerOnDispose = true;
        disposeCertificateHandlerOnDispose = true;
    }

    //
    // Summary:
    //     Creates a UnityWebRequest with the default options and no attached DownloadHandler
    //     or UploadHandler. Default method is GET.
    //
    // Parameters:
    //   url:
    //     The target URL with which this UnityWebRequest will communicate. Also accessible
    //     via the url property.
    //
    //   uri:
    //     The target URI to which form data will be transmitted.
    //
    //   method:
    //     HTTP GET, POST, etc. methods.
    //
    //   downloadHandler:
    //     Replies from the server.
    //
    //   uploadHandler:
    //     Upload data to the server.
    public UnityWebRequest()
    {
        m_Ptr = Create();
        InternalSetDefaults();
    }

    public UnityWebRequest(string url)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.url = url;
    }

    public UnityWebRequest(Uri uri)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.uri = uri;
    }

    public UnityWebRequest(string url, string method)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.url = url;
        this.method = method;
    }

    public UnityWebRequest(Uri uri, string method)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.uri = uri;
        this.method = method;
    }

    public UnityWebRequest(string url, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.url = url;
        this.method = method;
        this.downloadHandler = downloadHandler;
        this.uploadHandler = uploadHandler;
    }

    public UnityWebRequest(Uri uri, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler)
    {
        m_Ptr = Create();
        InternalSetDefaults();
        this.uri = uri;
        this.method = method;
        this.downloadHandler = downloadHandler;
        this.uploadHandler = uploadHandler;
    }

    

    ~UnityWebRequest()
    {
        DisposeHandlers();
        InternalDestroy();
    }

    //
    // Summary:
    //     Signals that this UnityWebRequest is no longer being used, and should clean up
    //     any resources it is using.
    public void Dispose()
    {
        DisposeHandlers();
        InternalDestroy();
        GC.SuppressFinalize(this);
    }

    private void DisposeHandlers()
    {
        if (disposeDownloadHandlerOnDispose)
        {
            downloadHandler?.Dispose();
        }

        if (disposeUploadHandlerOnDispose)
        {
            uploadHandler?.Dispose();
        }

        if (disposeCertificateHandlerOnDispose)
        {
            certificateHandler?.Dispose();
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    internal extern UnityWebRequestAsyncOperation BeginWebRequest();

    //
    // Summary:
    //     Begin communicating with the remote server.
    //
    // Returns:
    //     An AsyncOperation indicating the progress/completion state of the UnityWebRequest.
    //     Yield this object to wait until the UnityWebRequest is done.
    // [Obsolete("Use SendWebRequest.  It returns a UnityWebRequestAsyncOperation which contains a reference to the WebRequest object.", false)]
    // public AsyncOperation Send()
    // {
    //     return SendWebRequest();
    // }

    //
    // Summary:
    //     Begin communicating with the remote server.
    public UnityWebRequestAsyncOperation SendWebRequest()
    {
        UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = BeginWebRequest();
        if (unityWebRequestAsyncOperation != null)
        {
            unityWebRequestAsyncOperation.webRequest = this;
        }

        return unityWebRequestAsyncOperation;
    }

    //
    // Summary:
    //     If in progress, halts the UnityWebRequest as soon as possible.
    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod(IsThreadSafe = true)]
    public extern void Abort();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetMethod(UnityWebRequestMethod methodType);

    internal void InternalSetMethod(UnityWebRequestMethod methodType)
    {
        if (!isModifiable)
        {
            throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
        }

        UnityWebRequestError unityWebRequestError = SetMethod(methodType);
        if (unityWebRequestError != 0)
        {
            throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetCustomMethod(string customMethodName);

    internal void InternalSetCustomMethod(string customMethodName)
    {
        if (!isModifiable)
        {
            throw new InvalidOperationException("UnityWebRequest has already been sent and its request method can no longer be altered");
        }

        UnityWebRequestError unityWebRequestError = SetCustomMethod(customMethodName);
        if (unityWebRequestError != 0)
        {
            throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern UnityWebRequestMethod GetMethod();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string GetCustomMethod();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError GetError();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string GetUrl();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetUrl(string url);

    private void InternalSetUrl(string url)
    {
        if (!isModifiable)
        {
            throw new InvalidOperationException("UnityWebRequest has already been sent and its URL cannot be altered");
        }

        UnityWebRequestError unityWebRequestError = SetUrl(url);
        if (unityWebRequestError != 0)
        {
            throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
        }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern float GetUploadProgress();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool IsExecuting();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern float GetDownloadProgress();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern int GetRedirectLimit();

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeThrows]
    private extern void SetRedirectLimitFromScripting(int limit);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetChunked();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetChunked(bool chunked);

    //
    // Summary:
    //     Retrieves the value of a custom request header.
    //
    // Parameters:
    //   name:
    //     Name of the custom request header. Case-insensitive.
    //
    // Returns:
    //     The value of the custom request header. If no custom header with a matching name
    //     has been set, returns an empty string.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern string GetRequestHeader(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [NativeMethod("SetRequestHeader")]
    internal extern UnityWebRequestError InternalSetRequestHeader(string name, string value);

    //
    // Summary:
    //     Set a HTTP request header to a custom value.
    //
    // Parameters:
    //   name:
    //     The key of the header to be set. Case-sensitive.
    //
    //   value:
    //     The header's intended value.
    public void SetRequestHeader(string name, string value)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Cannot set a Request Header with a null or empty name");
        }

        if (value == null)
        {
            throw new ArgumentException("Cannot set a Request header with a null");
        }

        if (!isModifiable)
        {
            throw new InvalidOperationException("UnityWebRequest has already been sent and its request headers cannot be altered");
        }

        UnityWebRequestError unityWebRequestError = InternalSetRequestHeader(name, value);
        if (unityWebRequestError != 0)
        {
            throw new InvalidOperationException(GetWebErrorString(unityWebRequestError));
        }
    }

    //
    // Summary:
    //     Retrieves the value of a response header from the latest HTTP response received.
    //
    //
    // Parameters:
    //   name:
    //     The name of the HTTP header to retrieve. Case-insensitive.
    //
    // Returns:
    //     The value of the HTTP header from the latest HTTP response. If no header with
    //     a matching name has been received, or no responses have been received, returns
    //     null.
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern string GetResponseHeader(string name);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string[] GetResponseHeaderKeys();

    //
    // Summary:
    //     Retrieves a dictionary containing all the response headers received by this UnityWebRequest
    //     in the latest HTTP response.
    //
    // Returns:
    //     A dictionary containing all the response headers received in the latest HTTP
    //     response. If no responses have been received, returns null.
    public Dictionary<string, string> GetResponseHeaders()
    {
        string[] responseHeaderKeys = GetResponseHeaderKeys();
        if (responseHeaderKeys == null || responseHeaderKeys.Length == 0)
        {
            return null;
        }

        Dictionary<string, string> dictionary = new Dictionary<string, string>(responseHeaderKeys.Length, StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < responseHeaderKeys.Length; i++)
        {
            string responseHeader = GetResponseHeader(responseHeaderKeys[i]);
            dictionary.Add(responseHeaderKeys[i], responseHeader);
        }

        return dictionary;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetUploadHandler(UploadHandler uh);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetDownloadHandler(DownloadHandler dh);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetCertificateHandler(CertificateHandler ch);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern int GetTimeoutMsec();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetTimeoutMsec(int timeout);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetSuppressErrorsToConsole();

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern UnityWebRequestError SetSuppressErrorsToConsole(bool suppress);

    //
    // Summary:
    //     Create a UnityWebRequest for HTTP GET.
    //
    // Parameters:
    //   uri:
    //     The URI of the resource to retrieve via HTTP GET.
    //
    // Returns:
    //     An object that retrieves data from the uri.
    public static UnityWebRequest Get(string uri)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
    }

    //
    // Summary:
    //     Create a UnityWebRequest for HTTP GET.
    //
    // Parameters:
    //   uri:
    //     The URI of the resource to retrieve via HTTP GET.
    //
    // Returns:
    //     An object that retrieves data from the uri.
    public static UnityWebRequest Get(Uri uri)
    {
        return new UnityWebRequest(uri, "GET", new DownloadHandlerBuffer(), null);
    }

    //
    // Summary:
    //     Creates a UnityWebRequest configured for HTTP DELETE.
    //
    // Parameters:
    //   uri:
    //     The URI to which a DELETE request should be sent.
    //
    // Returns:
    //     A UnityWebRequest configured to send an HTTP DELETE request.
    public static UnityWebRequest Delete(string uri)
    {
        return new UnityWebRequest(uri, "DELETE");
    }

    public static UnityWebRequest Delete(Uri uri)
    {
        return new UnityWebRequest(uri, "DELETE");
    }

    //
    // Summary:
    //     Creates a UnityWebRequest configured to send a HTTP HEAD request.
    //
    // Parameters:
    //   uri:
    //     The URI to which to send a HTTP HEAD request.
    //
    // Returns:
    //     A UnityWebRequest configured to transmit a HTTP HEAD request.
    public static UnityWebRequest Head(string uri)
    {
        return new UnityWebRequest(uri, "HEAD");
    }

    public static UnityWebRequest Head(Uri uri)
    {
        return new UnityWebRequest(uri, "HEAD");
    }

    //
    // Summary:
    //     Creates a UnityWebRequest intended to download an image via HTTP GET and create
    //     a Texture based on the retrieved data.
    //
    // Parameters:
    //   uri:
    //     The URI of the image to download.
    //
    //   nonReadable:
    //     If true, the texture's raw data will not be accessible to script. This can conserve
    //     memory. Default: false.
    //
    // Returns:
    //     A UnityWebRequest properly configured to download an image and convert it to
    //     a Texture.
    // [Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // public static UnityWebRequest GetTexture(string uri)
    // {
    //     throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
    // }

    //
    // Summary:
    //     Creates a UnityWebRequest intended to download an image via HTTP GET and create
    //     a Texture based on the retrieved data.
    //
    // Parameters:
    //   uri:
    //     The URI of the image to download.
    //
    //   nonReadable:
    //     If true, the texture's raw data will not be accessible to script. This can conserve
    //     memory. Default: false.
    //
    // Returns:
    //     A UnityWebRequest properly configured to download an image and convert it to
    //     a Texture.
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestTexture.GetTexture(*)", true)]
    // public static UnityWebRequest GetTexture(string uri, bool nonReadable)
    // {
    //     throw new NotSupportedException("UnityWebRequest.GetTexture is obsolete. Use UnityWebRequestTexture.GetTexture instead.");
    // }

    //
    // Summary:
    //     OBSOLETE. Use UnityWebRequestMultimedia.GetAudioClip().
    //
    // Parameters:
    //   uri:
    //
    //   audioType:
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAudioClip is obsolete. Use UnityWebRequestMultimedia.GetAudioClip instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestMultimedia.GetAudioClip(*)", true)]
    // public static UnityWebRequest GetAudioClip(string uri, AudioType audioType)
    // {
    //     return null;
    // }

    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
    // public static UnityWebRequest GetAssetBundle(string uri)
    // {
    //     return null;
    // }

    //
    // Summary:
    //     Deprecated. Replaced by UnityWebRequestAssetBundle.GetAssetBundle.
    //
    // Parameters:
    //   uri:
    //
    //   crc:
    //
    //   version:
    //
    //   hash:
    //
    //   cachedAssetBundle:
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
    // public static UnityWebRequest GetAssetBundle(string uri, uint crc)
    // {
    //     return null;
    // }

    //
    // Summary:
    //     Deprecated. Replaced by UnityWebRequestAssetBundle.GetAssetBundle.
    //
    // Parameters:
    //   uri:
    //
    //   crc:
    //
    //   version:
    //
    //   hash:
    //
    //   cachedAssetBundle:
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
    // public static UnityWebRequest GetAssetBundle(string uri, uint version, uint crc)
    // {
    //     return null;
    // }

    //
    // Summary:
    //     Deprecated. Replaced by UnityWebRequestAssetBundle.GetAssetBundle.
    //
    // Parameters:
    //   uri:
    //
    //   crc:
    //
    //   version:
    //
    //   hash:
    //
    //   cachedAssetBundle:
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
    // public static UnityWebRequest GetAssetBundle(string uri, Hash128 hash, uint crc)
    // {
    //     return null;
    // }

    //
    // Summary:
    //     Deprecated. Replaced by UnityWebRequestAssetBundle.GetAssetBundle.
    //
    // Parameters:
    //   uri:
    //
    //   crc:
    //
    //   version:
    //
    //   hash:
    //
    //   cachedAssetBundle:
    // [EditorBrowsable(EditorBrowsableState.Never)]
    // [Obsolete("UnityWebRequest.GetAssetBundle is obsolete. Use UnityWebRequestAssetBundle.GetAssetBundle instead (UnityUpgradable) -> [UnityEngine] UnityWebRequestAssetBundle.GetAssetBundle(*)", true)]
    // public static UnityWebRequest GetAssetBundle(string uri, CachedAssetBundle cachedAssetBundle, uint crc)
    // {
    //     return null;
    // }

    //
    // Summary:
    //     Creates a UnityWebRequest configured to upload raw data to a remote server via
    //     HTTP PUT.
    //
    // Parameters:
    //   uri:
    //     The URI to which the data will be sent.
    //
    //   bodyData:
    //     The data to transmit to the remote server. If a string, the string will be converted
    //     to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
    //
    //
    // Returns:
    //     A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT.
    public static UnityWebRequest Put(string uri, byte[] bodyData)
    {
        return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
    }

    public static UnityWebRequest Put(Uri uri, byte[] bodyData)
    {
        return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyData));
    }

    //
    // Summary:
    //     Creates a UnityWebRequest configured to upload raw data to a remote server via
    //     HTTP PUT.
    //
    // Parameters:
    //   uri:
    //     The URI to which the data will be sent.
    //
    //   bodyData:
    //     The data to transmit to the remote server. If a string, the string will be converted
    //     to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
    //
    //
    // Returns:
    //     A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT.
    public static UnityWebRequest Put(string uri, string bodyData)
    {
        return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
    }

    public static UnityWebRequest Put(Uri uri, string bodyData)
    {
        return new UnityWebRequest(uri, "PUT", new DownloadHandlerBuffer(), new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyData)));
    }

    //
    // Summary:
    //     Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
    //
    //
    // Parameters:
    //   uri:
    //     The target URI to which form data will be transmitted.
    //
    //   postData:
    //     Form body data. Will be URLEncoded prior to transmission.
    //
    // Returns:
    //     A UnityWebRequest configured to send form data to uri via POST.
    public static UnityWebRequest Post(string uri, string postData)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, postData);
        return request;
    }

    public static UnityWebRequest Post(Uri uri, string postData)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, postData);
        return request;
    }

    private static void SetupPost(UnityWebRequest request, string postData)
    {
        request.downloadHandler = new DownloadHandlerBuffer();
        if (!string.IsNullOrEmpty(postData))
        {
            byte[] array = null;
            string s = WWWTranscoder.DataEncode(postData, Encoding.UTF8);
            array = Encoding.UTF8.GetBytes(s);
            request.uploadHandler = new UploadHandlerRaw(array);
            request.uploadHandler.contentType = "application/x-www-form-urlencoded";
        }
    }

    //
    // Summary:
    //     Create a UnityWebRequest configured to send form data to a server via HTTP POST.
    //
    //
    // Parameters:
    //   uri:
    //     The target URI to which form data will be transmitted.
    //
    //   formData:
    //     Form fields or files encapsulated in a WWWForm object, for formatting and transmission
    //     to the remote server.
    //
    // Returns:
    //     A UnityWebRequest configured to send form data to uri via POST.
    public static UnityWebRequest Post(string uri, WWWForm formData)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, formData);
        return request;
    }

    public static UnityWebRequest Post(Uri uri, WWWForm formData)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, formData);
        return request;
    }

    private static void SetupPost(UnityWebRequest request, WWWForm formData)
    {
        request.downloadHandler = new DownloadHandlerBuffer();
        if (formData == null)
        {
            return;
        }

        byte[] array = null;
        array = formData.data;
        if (array.Length == 0)
        {
            array = null;
        }

        if (array != null)
        {
            request.uploadHandler = new UploadHandlerRaw(array);
        }

        Dictionary<string, string> headers = formData.headers;
        foreach (KeyValuePair<string, string> item in headers)
        {
            request.SetRequestHeader(item.Key, item.Value);
        }
    }

    public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections)
    {
        byte[] boundary = GenerateBoundary();
        return Post(uri, multipartFormSections, boundary);
    }

    public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections)
    {
        byte[] boundary = GenerateBoundary();
        return Post(uri, multipartFormSections, boundary);
    }

    public static UnityWebRequest Post(string uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, multipartFormSections, boundary);
        return request;
    }

    public static UnityWebRequest Post(Uri uri, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, multipartFormSections, boundary);
        return request;
    }

    private static void SetupPost(UnityWebRequest request, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
    {
        request.downloadHandler = new DownloadHandlerBuffer();
        byte[] array = null;
        if (multipartFormSections != null && multipartFormSections.Count != 0)
        {
            array = SerializeFormSections(multipartFormSections, boundary);
        }

        if (array != null)
        {
            UploadHandler uploadHandler = new UploadHandlerRaw(array);
            uploadHandler.contentType = "multipart/form-data; boundary=" + Encoding.UTF8.GetString(boundary, 0, boundary.Length);
            request.uploadHandler = uploadHandler;
        }
    }

    public static UnityWebRequest Post(string uri, Dictionary<string, string> formFields)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, formFields);
        return request;
    }

    public static UnityWebRequest Post(Uri uri, Dictionary<string, string> formFields)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        SetupPost(request, formFields);
        return request;
    }

    private static void SetupPost(UnityWebRequest request, Dictionary<string, string> formFields)
    {
        request.downloadHandler = new DownloadHandlerBuffer();
        byte[] array = null;
        if (formFields != null && formFields.Count != 0)
        {
            array = SerializeSimpleForm(formFields);
        }

        if (array != null)
        {
            UploadHandler uploadHandler = new UploadHandlerRaw(array);
            uploadHandler.contentType = "application/x-www-form-urlencoded";
            request.uploadHandler = uploadHandler;
        }
    }

    //
    // Summary:
    //     Escapes characters in a string to ensure they are URL-friendly.
    //
    // Parameters:
    //   s:
    //     A string with characters to be escaped.
    //
    //   e:
    //     The text encoding to use.
    public static string EscapeURL(string s)
    {
        return EscapeURL(s, Encoding.UTF8);
    }

    //
    // Summary:
    //     Escapes characters in a string to ensure they are URL-friendly.
    //
    // Parameters:
    //   s:
    //     A string with characters to be escaped.
    //
    //   e:
    //     The text encoding to use.
    public static string EscapeURL(string s, Encoding e)
    {
        if (s == null)
        {
            return null;
        }

        if (s == "")
        {
            return "";
        }

        if (e == null)
        {
            return null;
        }

        byte[] bytes = e.GetBytes(s);
        byte[] bytes2 = WWWTranscoder.URLEncode(bytes);
        return e.GetString(bytes2);
    }

    //
    // Summary:
    //     Converts URL-friendly escape sequences back to normal text.
    //
    // Parameters:
    //   s:
    //     A string containing escaped characters.
    //
    //   e:
    //     The text encoding to use.
    public static string UnEscapeURL(string s)
    {
        return UnEscapeURL(s, Encoding.UTF8);
    }

    //
    // Summary:
    //     Converts URL-friendly escape sequences back to normal text.
    //
    // Parameters:
    //   s:
    //     A string containing escaped characters.
    //
    //   e:
    //     The text encoding to use.
    public static string UnEscapeURL(string s, Encoding e)
    {
        if (s == null)
        {
            return null;
        }

        if (s.IndexOf('%') == -1 && s.IndexOf('+') == -1)
        {
            return s;
        }

        byte[] bytes = e.GetBytes(s);
        byte[] bytes2 = WWWTranscoder.URLDecode(bytes);
        return e.GetString(bytes2);
    }

    public static byte[] SerializeFormSections(List<IMultipartFormSection> multipartFormSections, byte[] boundary)
    {
        if (multipartFormSections == null || multipartFormSections.Count == 0)
        {
            return null;
        }

        byte[] bytes = Encoding.UTF8.GetBytes("\r\n");
        byte[] bytes2 = WWWForm.DefaultEncoding.GetBytes("--");
        int num = 0;
        foreach (IMultipartFormSection multipartFormSection in multipartFormSections)
        {
            num += 64 + multipartFormSection.sectionData.Length;
        }

        List<byte> list = new List<byte>(num);
        foreach (IMultipartFormSection multipartFormSection2 in multipartFormSections)
        {
            string text = "form-data";
            string sectionName = multipartFormSection2.sectionName;
            string fileName = multipartFormSection2.fileName;
            string text2 = "Content-Disposition: " + text;
            if (!string.IsNullOrEmpty(sectionName))
            {
                text2 = text2 + "; name=\"" + sectionName + "\"";
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                text2 = text2 + "; filename=\"" + fileName + "\"";
            }

            text2 += "\r\n";
            string contentType = multipartFormSection2.contentType;
            if (!string.IsNullOrEmpty(contentType))
            {
                text2 = text2 + "Content-Type: " + contentType + "\r\n";
            }

            list.AddRange(bytes);
            list.AddRange(bytes2);
            list.AddRange(boundary);
            list.AddRange(bytes);
            list.AddRange(Encoding.UTF8.GetBytes(text2));
            list.AddRange(bytes);
            list.AddRange(multipartFormSection2.sectionData);
        }

        list.AddRange(bytes);
        list.AddRange(bytes2);
        list.AddRange(boundary);
        list.AddRange(bytes2);
        list.AddRange(bytes);
        return list.ToArray();
    }

    //
    // Summary:
    //     Generate a random 40-byte array for use as a multipart form boundary.
    //
    // Returns:
    //     40 random bytes, guaranteed to contain only printable ASCII values.
    public static byte[] GenerateBoundary()
    {
        byte[] array = new byte[40];
        for (int i = 0; i < 40; i++)
        {
            int num = Random.Range(48, 110);
            if (num > 57)
            {
                num += 7;
            }

            if (num > 90)
            {
                num += 6;
            }

            array[i] = (byte)num;
        }

        return array;
    }

    public static byte[] SerializeSimpleForm(Dictionary<string, string> formFields)
    {
        string text = "";
        foreach (KeyValuePair<string, string> formField in formFields)
        {
            if (text.Length > 0)
            {
                text += "&";
            }

            text = text + WWWTranscoder.DataEncode(formField.Key) + "=" + WWWTranscoder.DataEncode(formField.Value);
        }

        return Encoding.UTF8.GetBytes(text);
    }
}

