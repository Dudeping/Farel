#include <stdio.h>
#include <string.h>

#include <sys/types.h>          /* See NOTES */
#include <sys/socket.h>
#include <netinet/in.h>
#include <netinet/ip.h>

int main()
{
	int ret;
	int sockfd;
	socklen_t addrlen;
	struct sockaddr_in srv_addr;

	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if (sockfd == -1) {
		perror("client->socket");
		return -1;
	}

	memset(&srv_addr, 0, sizeof(struct sockaddr_in));
	srv_addr.sin_family = AF_INET;
	srv_addr.sin_port = htons(8888);
	srv_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	ret = connect(sockfd, (const struct sockaddr *)&srv_addr, sizeof(struct sockaddr));
	if (ret == -1) {
		perror("client->connect");
		close(sockfd);
		return -1;
	}
	printf("sockd = %d\n", sockfd);

//
	
	close(sockfd);
	return 0;
}
