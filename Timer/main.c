#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    unsigned long count=0; 
  for(;;){
          sleep(300000);
          count++;
          if(count%9==0){
                         beep();
          }
          else if(count%15==0){
               beep();
          }
  }
  system("PAUSE");	
  return 0;
}