
// ================================================================//
//                  recv / recvfrom / recvmsg
// ================================================================//




#include  <sys/socket.h>

ssize_t recv( int sockfd, void *buf, size_t nbytes, int flags );

ssize_t recvfrom( int sockfd, void *restrict buf, size_t len, int flags,
                struct sockaddr *restrict addr,
                socklen_t *restrict addrlen );

ssize_t recvmsg( int sockfd, struct msghdr *msg, int flags );

















