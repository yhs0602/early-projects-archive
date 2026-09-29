#include<stdio.h>
#include<stdlib.h>

#define PROGRESS
/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char** argv)
{
	int bottle=5000;
	int got,recycled;
	int sum=0;
	int i;
	for(i=0; i<100000; ++i)
	{
		got=(int)((float)bottle*8/10);
		recycled=(int)((float)got*9/10);
		sum+=recycled;
#ifdef PROGRESS
		printf("got:%d recycled: %d sum:%d\n",got,recycled,sum);
#endif
		bottle=recycled;
		if(recycled==0)
		{
			break;
		}
	}
	printf("i:%d sum:%d recycled:%d",i,sum,recycled);
	system("pause");
	return 0;
}
