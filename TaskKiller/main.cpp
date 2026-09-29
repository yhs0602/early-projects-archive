#include <cstdlib>
#include <iostream>
#include <windows.h>

using namespace std;

int main(int argc, char *argv[])
{
    char input[40];
    char command[40];
    char processname;
    int pid=0;
    
    while(1){
             fgets(input,39,stdin);
             if(strncmp(input,"quit",4)==0) {
                                       break;
             }
             
             if(strncmp(input,"kill",4)==0){
                                          pid=strtod(input+4,NULL);
                                          sprintf(command,"sc stop %d",pid);
                                          system(command);
                                          printf("killed %d\n",pid);
             }
             if(strncmp(input,"system",6)==0){
                                              system(input+6);
             
             }
             
    }
    
    return EXIT_SUCCESS;
}
