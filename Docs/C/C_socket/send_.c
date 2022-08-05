
// ================================================================ #
//                   send / sendto / sendmsg
// ================================================================ #



#include  <sys/socket.h>



ssize_t send( int sockfd, const void *buf, size_t nbytes, int flags );

ssize_t sendto( int sockfd, const void *buf, size_t nbytes, int flags,
                const struct sockaddr *destaddr, socklen_t destlen );

ssize_t sendmsg( int sockfd, const struct msghdr *msg, int flags );











