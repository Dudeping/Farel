#include <stdio.h>
#include <pthread.h>

int a = 0;
pthread_mutex_t mutex;

void * srv(void *arg)
{
	int count = 1000000;
	while(count--) {
		pthread_mutex_lock(&mutex);
		a++;
		pthread_mutex_unlock(&mutex);
	}
}

int main()
{
	int ret;
	pthread_t srv_thread;
	pthread_t test_thread;
	pthread_t a_thread;

	pthread_mutex_init(&mutex, NULL);
	
	ret = pthread_create(&srv_thread, NULL, srv, NULL);
	if (ret != 0) {
		printf("create error\n");
		return -1;
	}

	ret = pthread_create(&test_thread, NULL, srv, NULL);
	if (ret != 0) {
		printf("create error\n");
		return -1;
	}

	ret = pthread_create(&a_thread, NULL, srv, NULL);
	if (ret != 0) {
		printf("create error\n");
		return -1;
	}

	pthread_join(srv_thread, NULL);
	pthread_join(test_thread, NULL);
	pthread_join(a_thread, NULL);

	printf("a = %d\n", a);
}
