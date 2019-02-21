#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

int main()
{
	int fd;

	fd = open("1.c", O_RDWR | O_CREAT | O_TRUNC, 0777);
	if (fd == -1) {
		perror("open");
		return -1;
	}

	printf("fd = %d\n", fd);

	return 0;
}
