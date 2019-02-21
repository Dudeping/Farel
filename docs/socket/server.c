#include <stdio.h>
#include <string.h>

#include <sys/types.h>          /* See NOTES */
#include <sys/socket.h>
#include <netinet/in.h>
#include <netinet/ip.h>

int main()
{
	int ret;
	int listenfd;
	int connfd;
	socklen_t addrlen;
	struct sockaddr_in srv_addr;
	struct sockaddr_in cli_addr;


	listenfd = socket(AF_INET, SOCK_STREAM, 0);
	if (listenfd == -1) {
		perror("server->socket");
		return -1;
	}
	printf("listenfd = %d\n", listenfd);

	memset(&srv_addr, 0, sizeof(struct sockaddr_in));
	srv_addr.sin_family = AF_INET;
	srv_addr.sin_port = htons(8888);
	srv_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	ret = bind(listenfd, (const struct sockaddr *)&srv_addr, sizeof(struct sockaddr));
	if (ret == -1) {
		perror("server->bind");
		close(listenfd);
		return -1;
	}
	printf("bind success !\n");

	ret = listen(listenfd, 5);
	if (ret == -1) {
		perror("server->listen");
		close(listenfd);
		return -1;
	}
	printf("listen success !\n");

	addrlen = sizeof(struct sockaddr_in);
	connfd = accept(listenfd, (struct sockaddr *)&cli_addr, &addrlen);
	if (connfd == -1) {
		perror("server->accept");
		close(listenfd);
		return -1;
	}

	printf("connfd = %d\n", connfd);

	//

	close(connfd);
	close(listenfd);
	return 0;
}
