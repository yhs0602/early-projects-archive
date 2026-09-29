#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
  char filename[64];
  int mode, size,i;
  char c;
  FILE *fp;
  
  puts("filename mode character size");
  scanf("%64s %d %c %d",filename,&mode,&c,&size);
  fp=fopen(filename,"wb");
  for(i=0;i<size;i++)
  {
                     fputc(c,fp);
  }
  fclose(fp);
  system("PAUSE");	
  return 0;
}
