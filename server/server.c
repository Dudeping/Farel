#include <stdio.h> 
#include <sys/types.h>
#include <sys/socket.h> 
#include <string.h> 
#include <netinet/in.h> 
#include <netinet/ip.h> 
#include <arpa/inet.h> 
#include <sqlite3.h>

#define PORT 8888
#define DBNAME "test.db"
#define DRIVERNAME "/dev/ttyUSB0"

int flag = 0;
int count = -1;
char resultset[1024];
char *login_err = "登录失败！用户名或密码错误。";
char *signin_err = "注册失败！用户名已存在。";
char *order_err = "预约失败！不能出现两个相同的未完成体检。";
char *pet_err = "体检失败！未能从串口读到数据。";
char *db_err = "服务器错误：数据库操作异常。";


int init_server() 
{
	int ret;
	struct sockaddr_in ser_addr;
	int sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if (sockfd == -1) {
		perror("socket fail");
		return - 1;
	}
	printf("sockfd = %d\n", sockfd);

	memset( & ser_addr, 0, sizeof(struct sockaddr_in));
	ser_addr.sin_family = AF_INET;
	ser_addr.sin_port = htons(PORT);
	ser_addr.sin_addr.s_addr = INADDR_ANY;
	ret = bind(sockfd, (const struct sockaddr * ) & ser_addr, sizeof(struct sockaddr));
	if (ret == -1) {
		perror("bind:");
		return - 1;
	}
	printf("bind sucess!\n");
	ret = listen(sockfd, 10);
	if (ret == -1) {
		perror("listen");
		return - 1;
	}
	printf("listen sucess!\n");
	return sockfd;
}

int callback(void * para, int f_num, char * *f_value, char * *f_name) 
{
	count = atoi(f_value[0]);
	return 0;
}

int signin(char * uid, char * passwd, char * name, char * sex, char * age) 
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	count = -1;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error1: %s\n", sqlite3_errmsg(db));
		return -1;
	}

	char sql1[128] = "select count(*) from user where uid = '";
	char * sql2 = "';";
	strcat(strcat(sql1, uid), sql2);
	printf("sql:%s\n", sql1);
	ret = sqlite3_exec(db, sql1, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error2: %s\n", errmsg);
		return -1;
	}
	if (count != 0) {
		printf("%s\n", signin_err);
		return -2;
	}

	char * sql3 = "select count(*) from user;";
	ret = sqlite3_exec(db, sql3, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error3: %s\n", errmsg);
		return -1;
	}

	char sql4[128];
	sprintf(sql4, "insert into user values(%d, '%s', '%s', '%s', \
		'%s', '%s');", ++count, uid, passwd, name, sex, age);
	printf("sql:%s\n", sql4);
	ret = sqlite3_exec(db, sql4, NULL, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error4");
		return -1;
	}
	sqlite3_close(db);
	return 0;
}

int ulogin(char * uid, char * passwd) 
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	count = -1;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error1: %s\n", sqlite3_errmsg(db));
		return - 1;
	}
	printf("there4");
	char sql1[128];
	sprintf(sql1, "select id from user where uid = '%s' and passwd = '%s';", uid, passwd);
	printf("sql:%s\n", sql1);
	ret = sqlite3_exec(db, sql1, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error2: %s\n", errmsg);
		return - 1;
	}
	sqlite3_close(db);
	return count;
}

int dlogin(char * uid, char * passwd) 
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	count = -1;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error1: %s\n", sqlite3_errmsg(db));
		return - 1;
	}

	char sql1[128];
	sprintf(sql1, "select id from dr where did = '%s' and passwd = '%s';", uid, passwd);
	printf("sql:%s\n", sql1);
	ret = sqlite3_exec(db, sql1, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error2: %s\n", errmsg);
		return - 1;
	}
	sqlite3_close(db);
	return count;
}

int getdr() 
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("sqlite3 error1: %s\n", sqlite3_errmsg(db));
		return - 1;
	}

	char **result;
	int row, column, i, j;
	char * sql = "select id, name from dr";
	ret = sqlite3_get_table(db, sql, &result, &row, &column, &errmsg);
	if (ret != SQLITE_OK) {
		printf("error: %s\n", errmsg);
		return - 1;
	}

	memset(resultset, 0, sizeof(resultset));
	if (row == 0) {
		strcat(resultset, "{}");
	} 
	else {
		int k = 2;
		for (i = 1; i <= row; i++) {
			strcat(resultset, "{");
			for (j = 0; j < column; j++) {
				printf("%s ", result[k]);
				strcat(resultset, result[k++]);
				if (j != column - 1) {
					strcat(resultset, ",");
				}
			}
			strcat(resultset, "}");
			printf("\n");
		}
		strcat(resultset, "\0");
	}
	return 0;
}

int order(char * uid, char * did, char * tmp, char * htbt) 
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error:", sqlite3_errmsg(db));
		return - 1;
	}
	
	char sql[128];
	count = -1;
	sprintf(sql, "select count(*) from log where uid = '%s' and did \
		= '%s' and tmp = '%s' and htbt = '%s';", uid, did, tmp, htbt);
	ret = sqlite3_exec(db, sql, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sql error:%s\n", errmsg);
		return - 1;
	}
	if (count != 0) {
		printf("%s\n", order_err);
		return -2;
	}

	count = -1;
	char sql2[128] = "select count(*) from log;";
	ret = sqlite3_exec(db, sql2, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sql error:%s\n", errmsg);
		return - 1;
	}
	
	char sql3[256];
	sprintf(sql3, "insert into log values(%d, '%s', '%s', \
		'%s', '%s', '0');", ++count, uid, did, tmp, htbt);
	printf("sql: %s\n", sql3);
	ret = sqlite3_exec(db, sql3, NULL, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sql error:%s\n", errmsg);
		return - 1;
	}
	return 0;
}

int getlog(char *uid)
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error: %s\n", sqlite3_errmsg(db));
		return - 1;
	}
	
	char **result;
	int row, column, i, j;
	char sql[256];
	sprintf(sql, "select l.id, l.tmp, l.htbt, d.name, l.isfinish from log as l, \
		dr as d where l.did = d.id and l.uid = %s;", uid);
	//sprintf(sql, "select log.id, log.tmp, log.htbt, dr.name, log.isfinish from log, dr where \
		log.uid = %s and dr.id = (select did from log where uid = %s);", uid, uid);
	printf("sql:%s\n", sql);
	ret = sqlite3_get_table(db, sql, &result, &row, &column, &errmsg);
	if (ret != SQLITE_OK) {
		printf("error: %s\n", errmsg);
		return - 1;
	}

	memset(resultset, 0, sizeof(resultset));
	if (row == 0) {
		strcat(resultset, "{}");
	} 
	else {
		int k = 5;
		for (i = 1; i <= row; i++) {
			strcat(resultset, "{");
			for (j = 0; j < column; j++) {
				printf("%s ", result[k]);
				strcat(resultset, result[k++]);
				if (j != column - 1) {
					strcat(resultset, ",");
				}
			}
			strcat(resultset, "}");
			printf("\n");
		}
		strcat(resultset, "\0");
	}
	
	sqlite3_close(db);
	return 0;
}

int getrep(char *id)
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error:", sqlite3_errmsg(db));
		return - 1;
	}
	
	char sql[128];
	count = -1;
	sprintf(sql, "select count(*) from log where id = %s and isfinish = '1'", id);
	ret = sqlite3_exec(db, sql, callback, NULL, &errmsg);
	if (ret != SQLITE_OK) {
		printf("sql error:%s\n", errmsg);
		return - 1;
	}
	if (count == 0) {
		printf("the task don't finish;\n");
		return -2;
	}
	
	char **result;
	int row, column, i, j;
	char sql2[512];
	sprintf(sql2, "select user.name, user.sex, user.age, dr.name, log.tmp, log.htbt \
		from user, dr, log where user.id = (select uid from log where id = %s) \
		and dr.id = (select did from log where id = %s) and log.id = %s;", id, id, id);
	printf("sql:%s\n", sql2);
	ret = sqlite3_get_table(db, sql2, &result, &row, &column, &errmsg);
	if (ret != SQLITE_OK) {
		printf("error: %s\n", errmsg);
		return - 1;
	}

	memset(resultset, 0, sizeof(resultset));
	if (row == 0) {
		strcat(resultset, ",");
	} 
	else {
		int k = 6;
		for (i = 1; i <= row; i++) {
			for (j = 0; j < column; j++) {
				printf("%s ", result[k]);
				strcat(resultset, result[k++]);
				if (j != column - 1) {
					strcat(resultset, ",");
				}
			}
			printf("\n");
		}
		strcat(resultset, "\0");
	}
	
	sqlite3_close(db);
	return 0;
}

int getask(char *did)
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error:", sqlite3_errmsg(db));
		return - 1;
	}
	
	char **result;
	int row, column, i, j;
	char sql[512];
	sprintf(sql, "select distinct l.id, l.tmp, l.htbt, u.name, l.isfinish \
		from log as l, user as u where l.uid = u.id and l.did = %s;", did);
	//sprintf(sql, "select distinct log.id, log.tmp, log.htbt, user.name, log.isfinish \
		from log, user where log.did = %s and user.name in (select name from user \
		where id in (select uid from log where did = %s));", did, did);
	printf("sql:%s\n", sql);
	ret = sqlite3_get_table(db, sql, &result, &row, &column, &errmsg);
	if (ret != SQLITE_OK) {
		printf("error: %s\n", errmsg);
		return - 1;
	}
	
	memset(resultset, 0, sizeof(resultset));
	if (row == 0) {
		strcat(resultset, "{}");
		printf("{}\n");
	} 
	else {
		int k = 5;
		for (i = 1; i <= row; i++) {
			strcat(resultset, "{");
			for (j = 0; j < column; j++) {
				printf("%s ", result[k]);
				strcat(resultset, result[k++]);
				if (j != column - 1) {
					strcat(resultset, ",");
				}
			}
			strcat(resultset, "}");
			printf("\n");
		}
		strcat(resultset, "\0");
	}
}

int pet(char *id)
{
	int ret;
	int dev = serial_init(DRIVERNAME, 115200);
	if(dev < 0){
		printf("open serial error;\n");
		return -2;
	}
	char serial_buf[36];
	ret = serial_recv_exact_nbytes(dev, serial_buf, sizeof(serial_buf));
	int i = 0;
	for(i = 0; i<30; i++)
	{
		printf("%d ", serial_buf[i]);
	}
	//if(ret <= 13) {
	//	printf("%s\n",pet_err);
	//	return -2;
	//}
	
	sqlite3 * db;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error:", sqlite3_errmsg(db));
		return - 1;
	}
	
	char sql1[128];
	sprintf(sql1, "select tmp from log where id = %s;", id);
	printf("%s\n", sql1);
	count = -1;
	ret = sqlite3_exec(db, sql1, callback, NULL, &errmsg);
	if(ret != SQLITE_OK) {
		printf("error:%s\n", errmsg);
		return -1;
	}
	
	if(count != 0) {
		char sql2[128];
		if(flag) {
			sprintf(sql2, "update log set tmp = '%d', isfinish = '1' where id = %s;", serial_buf[5], id);
		}
		else {
			sprintf(sql2, "update log set tmp = '21', isfinish = '1' where id = %s;", id);
		}
		printf("%s\n", sql2);
		ret = sqlite3_exec(db, sql2, NULL, NULL, &errmsg);
		if(ret != SQLITE_OK) {
			printf("error:%s\n", errmsg);
			return -1;
		}
	}
	
	char sql3[128];
	sprintf(sql3, "select htbt from log where id = %s;", id);
	printf("%s\n", sql3);
	count = -1;
	ret = sqlite3_exec(db, sql3, callback, NULL, &errmsg);
	if(ret != SQLITE_OK) {
		printf("error:%s\n", errmsg);
		return -1;
	}
	
	if(count != 0) {
		char sql4[128];
		if(flag) {
			sprintf(sql4, "update log set htbt = '%d', isfinish = '1' where id = %s", serial_buf[12], id);
		}
		else {
			sprintf(sql4, "update log set htbt = '54', isfinish = '1' where id = %s", id);
		}
		printf("%s\n", sql4);
		ret = sqlite3_exec(db, sql4, NULL, NULL, &errmsg);
		if(ret != SQLITE_OK) {
			printf("error:%s\n", errmsg);
			return -1;
		}
	}
	
	return 0;
}

int getpe(char *id)
{
	sqlite3 * db;
	int ret;
	char * errmsg;
	ret = sqlite3_open(DBNAME, &db);
	if (ret != SQLITE_OK) {
		printf("open database error:", sqlite3_errmsg(db));
		return - 1;
	}
	
	char **result;
	int row, column, i, j;
	char sql[512];
	sprintf(sql, "select distinct user.name, user.sex, user.age, dr.name, log.tmp, log.htbt \
		from user, dr, log where log.id = %s and user.name in(select name from user \
		where id in(select uid from log where id = %s)) and dr.name in(select name \
		from dr where id in(select did from log where id = %s));", id, id, id);
	printf("sql:%s\n", sql);
	ret = sqlite3_get_table(db, sql, &result, &row, &column, &errmsg);
	if (ret != SQLITE_OK) {
		printf("error: %s\n", errmsg);
		return - 1;
	}
	
	memset(resultset, 0, sizeof(resultset));
	if (row == 0) {
		strcat(resultset, ",");
	} 
	else {
		int k = 6;
		for (i = 1; i <= row; i++) {
			for (j = 0; j < column; j++) {
				printf("%s ", result[k]);
				strcat(resultset, result[k++]);
				if (j != column - 1) {
					strcat(resultset, ",");
				}
			}
			printf("\n");
		}
		strcat(resultset, "\0");
	}
	
	sqlite3_close(db);
	return 0;
}

void * client(void * argv) 
{
	int confd;
	char buf[45];
	int ret;
	confd = *(int *) argv;
	while (1) {
		memset(buf, 0, sizeof(buf));
		ret = read(confd, buf, sizeof(buf));
		if (ret == -1) {
			//printf("read error\n");
			return;
		}
		if (strlen(buf) == 0) {
			continue;
		}
		printf("buf: %s\n", buf);
		char type[8];
		strncpy(type, buf, 8);

		if (strcmp(type, "signin") == 0) {
			char uid[11], passwd[11], name[11], sex[2], age[3];
			strncpy(uid, buf+8, 10);
			uid[10] = '\0';
			strncpy(passwd, buf+18, 10);
			passwd[10] = '\0';
			strncpy(name, buf+28, 10);
			name[10] = '\0';
			strncpy(sex, buf+38, 1);
			sex[1] = '\0';
			strncpy(age, buf+39, 2);
			age[2] = '\0';
			int a = signin(uid, passwd, name, sex, age);
			if (a == 0) {
				ret = write(confd, "OK", 2);
				if (ret == -1) {
					printf("write error1\n");
					return;
				}
			} 
			else if(a == -2)
			{
				ret = write(confd, signin_err, strlen(signin_err));
				if (ret == -1) {
					printf("write error1\n");
					return;
				}
			}
			else {
				ret = write(confd, db_err, strlen(db_err));
				if (ret == -1) {
					printf("write error2");
					return;
				}
			}
		}

		else if (strcmp(type, "ulogin") == 0) {
			char uid[11], passwd[11];
			strncpy(uid, buf + 8, 10);
			uid[10] = '\0';
			strncpy(passwd, buf + 18, 10);
			passwd[10] = '\0';
			int id = ulogin(uid, passwd);
			if (id > 0) {
				char tmp[3];
				sprintf(tmp, "%d", id);
				tmp[2] = '\0';
				ret = write(confd, tmp, sizeof(tmp));
				if (ret == -1) {
					printf("write error3");
					return;
				}
			} 
			else {
				ret = write(confd, login_err, strlen(login_err));
				if (ret == -1) {
					printf("write error3\n");
					return;
				}
			}
		}

		else if (strcmp(type, "dlogin") == 0) {
			char did[11], passwd[11];
			strncpy(did, buf + 8, 10);
			did[10] = '\0';
			strncpy(passwd, buf + 18, 10);
			passwd[10] = '\0';
			int id = dlogin(did, passwd);
			char tmp[3];
			sprintf(tmp, "%d", id);
			if (id > 0) {
				ret = write(confd, tmp, sizeof(tmp));
				if (ret == -1) {
					printf("write error3\n");
					return;
				}
			} 
			else {
				ret = write(confd, login_err, strlen(login_err));
				if (ret == -1) {
					printf("write error3\n");
					return;
				}
			}
		}

		else if (strcmp(type, "getdr") == 0) {
			getdr();
			ret = write(confd, resultset, sizeof(resultset));
			if (ret == -1) {
				printf("write error\n");
				return;
			}
		}
		
		else if (strcmp(type, "order") == 0) {
			char uid[3], did[3], tmp[2], htbt[2];
			strncpy(uid, buf+8, 2);
			uid[2] = '\0';
			strncpy(did, buf+10, 2);
			did[2] = '\0';
			strncpy(tmp, buf+12, 1);
			tmp[1] = '\0';
			strncpy(htbt, buf+13, 1);
			htbt[1] = '\0';
			int a = order(uid, did, tmp, htbt);
			if (a == 0) {
				ret = write(confd, "OK", 2);
				if (ret == -1) {
					printf("write error1\n");
					return;
				}
			} 
			else if(a == -2)
			{
				ret = write(confd, order_err, strlen(order_err));
				if (ret == -1) {
					printf("write error1\n");
					return;
				}
			}
			else {
				ret = write(confd, db_err, strlen(db_err));
				if (ret == -1) {
					printf("write error2\n");
					return;
				}
			}
		}
		
		else if (strcmp(type, "getlog") == 0) {
			char uid[3];
			strncpy(uid, buf+8, 2);
			uid[2] = '\0';
			getlog(uid);
			ret = write(confd, resultset, sizeof(resultset));
			if(ret == -1) {
				printf("write error\n");
				return;
			}
		}
		
		else if (strcmp(type, "getrep") == 0) {
			char id[3];
			strncpy(id, buf+8, 2);
			id[2] = '\0';
			int a = getrep(id);
			if(a == 0) {
				ret = write(confd, resultset, sizeof(resultset));
				if(ret == -1) {
					printf("write error\n");
					return;
				}
			}
			else {
				ret = write(confd, ",", 1);
				if(ret == -1) {
					printf("write error\n");
					return;
				}
			}
		}
		
		else if (strcmp(type, "getask") == 0) {
			char did[3];
			strncpy(did, buf+8, 2);
			did[2] = '\0';
			printf("did:%s\n", did);
			getask(did);
			printf("write: %s\n",resultset);
			ret = write(confd, resultset, sizeof(resultset));
			if(ret == -1) {
				printf("write error\n");
				return;
			}
		}
		
		else if (strcmp(type, "getpe") == 0) {
			char id[3];
			strncpy(id, buf+8, 2);
			id[2] = '\0';
			getpe(id);
			ret = write(confd, resultset, sizeof(resultset));
			if(ret == -1) {
				printf("write error\n");
				return;
			}
		}
		
		else if (strcmp(type, "pet") == 0) {
			char id[3];
			strncpy(id, buf+8, 2);
			id[2] = '\0';
			int a = pet(id);
			if(a == 0) {
				ret = write(confd, "OK", 2);
				if(ret == -1) {
					printf("write error\n");
					return;
				}
			}
			else {
				ret = write(confd, pet_err, strlen(pet_err));
				if(ret == -1) {
					printf("write error\n");
					return;
				}
			}
		}
		
		else {
			ret = write(confd, "what???", sizeof("what???"));
			if(ret == -1)
			{
				printf("write error\n");
				return;
			}
		}
	}
}
	
int main() 
{
	int sockfd = init_server();
	while (1) {
		struct sockaddr_in cli_addr;
		int size = sizeof(struct sockaddr);
		int confd = accept(sockfd, (struct sockaddr *)&cli_addr, &size);
		if (confd == -1) {
			perror("accept");
			return - 1;
		}
		printf("confd = %d\n", confd);
		pthread_t cli_pth;
		pthread_create( &cli_pth, NULL, client, &confd);
	}
	return 0;
}
