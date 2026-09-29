#include <cstdlib>
#include <string.h>
#include <iostream>
#include <windows.h>

using namespace std;

int main(int argc, char *argv[])
{
    char a[10];
    char b[10];
    char e[10];
    int i;
    puts("시작 PID 종료PID 내 PID"); 
    scanf("%s %s %s",a,b,e);
    int c=atoi(a);
    int d=atoi(b);
    int f=atoi(e);
    
    for(i=c;i<=d;i++){
            if(i!=f)TerminateProcess(OpenProcess(PROCESS_ALL_ACCESS,TRUE,i),0);
    }
    system("PAUSE");
    return EXIT_SUCCESS;
}
