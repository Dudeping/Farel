#include <stdio.h>
#include <string.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

int main()
{
	int fd;
	int ret;
	char buf[128];

	fd = open("1.c", O_RDWR | O_CREAT | O_APPEND, 0777);
	if (fd == -1) {
		perror("open");
		return -1;
	}

	printf("fd = %d\n", fd);

	memset(buf, 0, sizeof(buf));
	memcpy(buf, "leilei", 7);
	ret = write(fd, buf, sizeof(buf));
	if (ret == -1) {
		perror("read");
		return -1;
	}
	printf("ret = %d\n", ret);
	printf("buf : %s\n", buf);

	close(fd);
	return 0;
}
