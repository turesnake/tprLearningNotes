# ================================================================ #
#            HttpWebRequest   微软文档 
# ================================================================ #
https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest?view=net-6.0


# 继承关系:
Object ->
    MarshalByRefObject ->
        WebRequest ->
            HttpWebRequest


#
Provides an HTTP-specific implementation of the "WebRequest" class.

下面例子, 演示如何为 URI: http://www.contoso.com/ 创建一个 本 class 实例:
    HttpWebRequest myReq =
    (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");



# 不推荐为新研发使用 本类, 改用: System.Net.Http.HttpClient 


# --
The HttpWebRequest class provides support for the properties and methods defined in WebRequest and for additional properties and methods that enable the user to interact directly with servers using HTTP.
---

不要使用 HttpWebRequest 的构造函数; 改用 WebRequest.Create() 来新建实例;

如果 URI 是 http:// or https:// 开头, Create() 返回一个 HttpWebRequest 对象;


# ------
GetResponse() 函数 对 RequestUri 属性中指定的资源发出 同步请求，并返回 包含响应对象的HttpWebResponse 实例;

通过使用 GetResponseStream() 返回的 stream, 可获得 response 数据;

如果 response object 或 response stream 被关闭了, 剩余数据将被没收;

若满足以下条件, 剩余数据会被 外流, socket 会被后续 request 复用:
    它是一个 keep-alive 的 request, 或一个 pipelined request;
    只有很小的数据需要被接收,
    或: 剩余数据在一个小的时间间隔内接收。

若以上任一条件都不满足, 或 超过排水时间, socket 会被关闭;

对于 keep-alive or pipelined connections, 我们强烈建议 app read the streams 直到 EOF;

这确保了 socket 将被重新用于后续请求，从而获得更好的性能和更少的资源使用。


When you want to send data to the resource, the GetRequestStream method returns a Stream object to use to send data. The BeginGetRequestStream and EndGetRequestStream methods provide asynchronous access to the send data stream.

当你想 发生数据到 resource, GetRequestStream() 能返回一个 Stream 实例, 可用来 send 数据;

BeginGetRequestStream() 和 EndGetRequestStream() 提供 同步访问 send data stream 的方法;

对于使用 HttpWebRequest 的客户端身份验证，the client certificate must be installed in the My certificate store of the current user. 
客户端证书必须安装在当前用户的我的证书存储中。


The "HttpWebRequest" class throws a "WebException" when errors occur while accessing a resource.
--- 
    后面都是有关报错的详情...

...



# ========================================= #
#        BeginGetResponse()
# ========================================= #









# ========================================= #
#        EndGetResponse()
# ========================================= #
public override System.Net.WebResponse EndGetResponse (IAsyncResult asyncResult);




























