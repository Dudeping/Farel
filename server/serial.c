#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <assert.h>
#include <termios.h>

int serial_init(const char *devpath, int baudrate)
{
	int fd;
	struct termios oldtio, newtio;

	assert(devpath != NULL);

	fd = open(devpath, O_RDWR | O_NOCTTY); 
	if (fd == -1) {
		perror("serial->open");
		return -1;
	}

	tcgetattr(fd, &oldtio);		/* save current port settings */

	memset(&newtio, 0, sizeof(newtio));
	newtio.c_cflag = baudrate | CS8 | CLOCAL | CREAD;
	newtio.c_iflag = IGNPAR;
	newtio.c_oflag = 0;

	newtio.c_lflag = 0;		/* set input mode (non-canonical, no echo,...) */

	newtio.c_cc[VTIME] = 40;	/* set timeout value, n * 0.1 S */
	newtio.c_cc[VMIN] = 0;

	tcflush(fd, TCIFLUSH);
	tcsetattr(fd, TCSANOW, &newtio);

	return fd;
}

ssize_t serial_recv(int fd, void *buf, size_t count)
{
	ssize_t ret;

	assert(buf != NULL);

	ret = read(fd, buf, count);
	if (ret == -1)
		perror("serial->send");

	return ret;
}

ssize_t serial_send(int fd, const void *buf, size_t count)
{
	ssize_t ret;

	assert(buf != NULL);

	ret = write(fd, buf, count);
	if (ret == -1)
		perror("serial->send");

	return ret;
}

ssize_t serial_recv_exact_nbytes(int fd, void *buf, size_t count)
{
	ssize_t ret;
	ssize_t total = 0;

	assert(buf != NULL);

	while (total != count) {
		ret = read(fd, buf + total, count - total);
		if (ret == -1) {
			perror("serial->recv");
			break;
		} else if (ret == 0) {
			fprintf(stdout, "serial->recv: timeout or end-of-file\n");
			break;
		} else
			total += ret;
	}

	return total;
}

ssize_t serial_send_exact_nbytes(int fd, const void *buf, size_t count)
{
	ssize_t ret;
	ssize_t total = 0;

	assert(buf != NULL);

	while (total != count) {
		ret = write(fd, buf + total, count - total);
		if (ret == -1) {
			perror("serial->send");
			break;
		} else
			total += ret;
	}

	return total;
}

int serial_exit(int fd)
{
	if (close(fd)) {
		perror("serial->exit");
		return -1;
	}

	return 0;
}
