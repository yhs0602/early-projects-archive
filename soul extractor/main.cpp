#include <cstdlib>
#include <iostream>
#include <windows.h>
#include <stdlib.h>

using namespace std;

int main(int argc, char *argv[])
{
    char s[10];
    for(int i = 0;i<128;i++) 
        for(int j=0;j<128;j++){
                printf("±èÀÌ¾È ¾È³ç \t%d*%d=%d\n \t %c%c\n",i,j,i*j,(char)i,(char)j);
                printf("Hi Kim Ian! \a");
                sprintf(s,"color %x",j);
                system(s);
                Sleep(50);
                if(rand()%500==rand()%500)
                {
                      system("cls");
                      i=0;j=0;
                }
        }
    system("PAUSE");
    return EXIT_SUCCESS;
}
