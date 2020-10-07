//
//========================= socketfunc.h ==========================
//                         -- NET --
//                                        创建 -- 2018.06.12
//                                        修改 -- 2018.06.12
//----------------------------------------------------------
//   专门存放 socket 模块的 函数
//    这些函数大部分是祖传的，需要充分熟悉它们
//
//----------------------------
#ifndef _NET_SOCKETFUNC_H_
#define _NET_SOCKETFUNC_H_


//------- 置空 restrict 关键词 ------
#include "../restrict.h" 


#include  <sys/socket.h>

//int socket( int domain, int type, int protocol );

int shutdown( int sockfd, int how );


//int bind( int sockfd, const struct sockaddr *addr, socklen_t len );

int getsockname( int sockfd, struct sockaddr *restrict addr,
                socklen_t *restrict alenp );

int getpeername( int sockfd, struct sockaddr *restrict addr,
                socklen_t * restrict alenp );


//int connect( int sockfd, const struct sockaddr *addr, socklen_t len );

//int listen( int sockfd, int backlog );

//int accept( int sockfd, struct sockaddr *restrict addr,
//            socklen_t *restrict len );


//ssize_t send( int sockfd, const void *buf, size_t nbytes, int flags );

//ssize_t sendto( int sockfd, const void *buf, size_t nbytes, int flags,
//                const struct sockaddr *destaddr, socklen_t destlen );

//ssize_t sendmsg( int sockfd, const struct msghdr *msg, int flags );



//ssize_t recv( int sockfd, void *buf, size_t nbytes, int flags );

//ssize_t recvfrom( int sockfd, void *restrict buf, size_t len, int flags,
//                struct sockaddr *restrict addr,
//                socklen_t *restrict addrlen );

//ssize_t recvmsg( int sockfd, struct msghdr *msg, int flags );



int setsockopt( int sockfd, int level, int option, const void *val,
                socklen_t len );

int getsockopt( int sockfd, int level, int option, void *restrict val,
                socklen_t *restrict lenp );

int sockatmark( int sockfd );




#include  <netdb.h>

struct hostent *gethostent(void);

void sethostent( int stayopen );
void endhostent();

//-----

struct netent *getnetbyaddr( uint32_t net, int type );
struct netent *getnetbyname( const char *name );
struct netent *getnetent();

void setnetent( int stayopen );
void endnetent();

//-----

struct protoent *getprotobyname( const char *name );
struct protoent *getprotobynumber( int proto );
struct protoent *getprotoent();

void setprotoent( int stayopen );
void endprotoent();

//-----

struct servent *getservbyname( const char *name, const char *proto );
struct servent *getservbyport( int port, const char *proto );
struct servent *getservent();

void setservent( int stayopen );
void endservent();

//-----

const char *gai_strerror( int error );




//-------------------------------------------------
//  必须同时包含 两个 h文件的 函数

#include  <sys/socket.h>
#include  <netdb.h>

int getaddrinfo( const char *restrict host,
                const char *restrict service,
                const struct addrinfo *restrict hint,
                struct addrinfo **restrict res );

void freeaddrinfo( struct addrinfo *ai );


int getnameinfo( const struct sockaddr *restrict addr, socklen_t alen,
                char *restrict host, socklen_t hostlen,
                char *restrict service, socklen_t servlen, int flags );










#endif



