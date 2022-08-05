#region 程序集 System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// System.dll
#endregion

using System.ComponentModel;
using System.IO;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace System.Net
{
    public class HttpWebRequest : WebRequest, ISerializable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
        public HttpWebRequest();
        [Obsolete("Serialization is obsoleted for this type.  http://go.microsoft.com/fwlink/?linkid=14202")]
        protected HttpWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext);

        public static RequestCachePolicy DefaultCachePolicy { get; set; }
        public static int DefaultMaximumErrorResponseLength { get; set; }
        public static int DefaultMaximumResponseHeadersLength { get; set; }
        public DateTime Date { get; set; }
        public string Expect { get; set; }
        public virtual bool HaveResponse { get; }
        public override WebHeaderCollection Headers { get; set; }
        public string Host { get; set; }
        public DateTime IfModifiedSince { get; set; }
        public bool KeepAlive { get; set; }
        public int MaximumAutomaticRedirections { get; set; }
        public int MaximumResponseHeadersLength { get; set; }
        public string MediaType { get; set; }
        public override string Method { get; set; }
        public bool Pipelined { get; set; }
        public override bool PreAuthenticate { get; set; }
        public Version ProtocolVersion { get; set; }
        public override IWebProxy Proxy { get; set; }
        public int ReadWriteTimeout { get; set; }
        public string Referer { get; set; }
        public override Uri RequestUri { get; }

        /*
            Gets or sets a value that indicates whether to send data in segments to the Internet resource.
            将数据分段发送到 Internet 资源。

            true to send data to the Internet resource in segments; otherwise, false. The default value is false.

            The Internet resource must support receiving chunked data.

            Changing the SendChunked property after the request has been started by calling the GetRequestStream, 
            BeginGetRequestStream, GetResponse, or BeginGetResponse method throws an InvalidOperationException.
            ---
            在 得到 request 实例之后立刻就要将本值设为 true;

        */
        public bool SendChunked { get; set; }
        public RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }
        public ServicePoint ServicePoint { get; }
        public virtual bool SupportsCookieContainer { get; }
        public override int Timeout { get; set; }

        /*
             Gets or sets the value of the Transfer-encoding HTTP header.

            比如可设置为 "gzip"

             Before you can set the TransferEncoding property, you must first set the SendChunked property to true. 
             Clearing TransferEncoding by setting it to null has no effect on the value of SendChunked.

             Values assigned to the TransferEncoding property replace any existing contents.

             The value for this property is stored in WebHeaderCollection. 
             If WebHeaderCollection is set, the property value is lost.
        */
        public string TransferEncoding { get; set; }



        public bool UnsafeAuthenticatedConnectionSharing { get; set; }
        public override ICredentials Credentials { get; set; }
        public virtual CookieContainer CookieContainer { get; set; }
        public int ContinueTimeout { get; set; }
        public HttpContinueDelegate ContinueDelegate { get; set; }
        public override bool UseDefaultCredentials { get; set; }
        public string Accept { get; set; }
        public Uri Address { get; }
        public virtual bool AllowAutoRedirect { get; set; }
        public virtual bool AllowReadStreamBuffering { get; set; }
        public virtual bool AllowWriteStreamBuffering { get; set; }
        public string UserAgent { get; set; }
        public X509CertificateCollection ClientCertificates { get; set; }
        public string Connection { get; set; }
        public override string ConnectionGroupName { get; set; }
        public override long ContentLength { get; set; }
        public override string ContentType { get; set; }
        public DecompressionMethods AutomaticDecompression { get; set; }

        public override void Abort();



        /* 
            Adds a byte range header to a request for a specific range from the beginning or end of the requested data.
            从请求数据的开头或结尾向特定范围的请求添加字节范围标头。

            adds a byte range header to the request.

            参数:
                ----------------------------------
                range: 
                    The starting or ending point of the range.
                    ---
                    若为 正值, 则指定了 starting point of the range, 
                    需要传输的数据, 从这个点开始一直到 整个数据尾端;

                    若为 负值, 则指定了 ending point of the range,
                    需要传输的数据, 从整个数据的开头, 到 range 指定的位置;
                    ---
                    若想传输 0-99 这100个字节, 参数 range 需要设置为: -99;
                    (注意, 这里的 99 也是从头部开始算起的)

            Since all HTTP entities are represented in HTTP messages as sequences of bytes, 
            the concept of a byte range is meaningful for any HTTP entity. 
            However, not all clients and servers need to support byte-range operations.

                -------------------------------------
                from, to:
                    若想传输 0-99 这 100 个字节的数据, 可将 from 设为 0, to 设为 99;


                ----------------------------------
                rangeSpecifier:
                    The description of the range.
                    ---
                    通常设为 "bytes",  这是最广泛的, 一般不做修改;

        */
        public void AddRange(int range);
        public void AddRange(int from, int to);
        public void AddRange(long range);
        public void AddRange(long from, long to);
        public void AddRange(string rangeSpecifier, int range);
        public void AddRange(string rangeSpecifier, long from, long to);
        public void AddRange(string rangeSpecifier, long range);
        public void AddRange(string rangeSpecifier, int from, int to);




        public override IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state);


        /*
            参数:
                callback:


                state:
                    The state object for this request.

            ret:
                An IAsyncResult that references the asynchronous request for a response.

        */
        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state);


        public Stream EndGetRequestStream(IAsyncResult asyncResult, out TransportContext context);
        public override Stream EndGetRequestStream(IAsyncResult asyncResult);
        public override WebResponse EndGetResponse(IAsyncResult asyncResult);
        public override Stream GetRequestStream();
        public Stream GetRequestStream(out TransportContext context);
        public override WebResponse GetResponse();
        protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext);
    }
}