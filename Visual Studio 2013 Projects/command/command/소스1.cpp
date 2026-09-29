#include <stdio.h>
#include <stdlib.h>

int main(){
	char s[100] = "";
	for (;;){
		scanf("%100s", s);
		system(s);
	}
	return 0;
}