#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

int main()
{
	int fd;
	
	fd = creat("1.c", 0777);
	if (fd == -1) {
		perror("creat");
		return -1;
	}


	fd = open("1.c", O_RDWR);
	if (fd == -1) {
		perror("open");
		return -1;
	}
	printf("fd = %d\n", fd);

	return 0;
}
