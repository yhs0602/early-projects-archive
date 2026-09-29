#include <stdlib.h>
#include <stdio.h>
#define CONSTANT 255

using namespace std;


class Poly{
public:
	double quotient;
	unsigned int degree;
	unsigned char var;
	Poly *next;
	Poly *multi;

	//////////////////////////////////생성자/////////////////////////////////

	//생성자 구분이 모호함
	/*
	Poly(unsigned char var1, unsigned int degree1, double quotient1)
	{
		var = var1;
		degree = degree1;
		quotient = quotient1;
		next = NULL;
		multi = NULL;
	}
	*/

	//기본 생성자
	Poly(){
		next = NULL;
		multi = NULL;
	}

	
	//상수함수
	Poly(double quotient){
		next = NULL;
		multi = NULL;
		this->quotient = quotient;
		var = CONSTANT;
	}

	//일차함수
	Poly(unsigned char var, double quotient1, double quotient2){
		Poly p;
		p.quotient = quotient1;
		p.var = var;
		p.degree = 1;
		p.next = &Poly(quotient2);
		*this = p;
	}

	//이차함수
	Poly(unsigned char var, double quotient1, double quotient2, double quotient3){
		Poly p = Poly(var, 2, quotient1);
		p.next = &Poly(var, 1, quotient2);
		p.next->next = &Poly(quotient3);
		*this = p;
	}

	//3차함수
	Poly(unsigned char var, double quotient1, double quotient2, double quotient3, double quotient4){
		Poly p = Poly(var, 3, quotient1);
		p.next = &Poly(var, 2, quotient2);
		p.next->next = &Poly(var, 1, quotient3);
		p.next->next->next = &Poly(quotient4);
		*this = p;
	}

	/*
	//에러가 많아 포기한 부분입니다.
	Poly(unsigned char var, int maxdegree, double quotient1,double quotient2,...){
		int *t = &maxdegree + 1;
		double * p = (double *) t;
		int counter;
		Poly a, ret = a = Poly(var, maxdegree, p[0]) ,temp;
		printf("new created:");
		for (counter = maxdegree - 1; counter >= 0; counter--){
			a.next = &Poly(var, counter, p[maxdegree - counter]);
			ret.next = a.next;
			a=*(a.next);
		}
		*this = a;
	}

	*/

	/////////////////////////////////////////생성자//////////////////////////////////////////////
	/*
	//덧셈 함수
	Poly  operator+(const Poly &a){
		Poly temp;
		Poly p = Poly(var, degree, quotient);
		if (degree == a.degree && var == a.var){
			p.quotient = a.quotient + quotient;
		}
		else{
			temp = (p+ a);
			p = temp;
		}
		if (next != NULL){
			temp = p + *this;
			p = temp;
		}
		if (a.next != NULL){
			temp = p+ a;
			p = temp;
		}
		return p;
	}

	//뺄셈 함수
	Poly operator-(const Poly &a){
		//모든 quotient에 대해 -1을 곱해 +를 수행한다.
		
	}

	//제곱 함수
	Poly PowerBinaryPoly(int deg){
		//이항정리

	}

	//나눗셈 함수
	Poly operator/(const Poly &a){
		//약분
	}

	//대입 함수
	Poly GetResult(unsigned char var, double x){


	}

*/
	void PrintPoly(){
		if (this == NULL)return;
		if (quotient!=0)
			printf("%lf %c^%d ",quotient, var, degree);
		if (next != NULL)next->PrintPoly();
	}

	Poly  operator+(const Poly &a){
		Poly temp;
		Poly p = Poly(var, degree, quotient);
		if (degree == a.degree && var == a.var){
			p.quotient = a.quotient + quotient;
		}
		else{
			temp = (p + a);
			p = temp;
		}
		if (next != NULL){
			temp = p + *this;
			p = temp;
		}
		if (a.next != NULL){
			temp = p + a;
			p = temp;
		}
		return p;
	}

	Poly operator=(const Poly &a){
		return Poly();
	}
	
	Poly operator- (const Poly &a)
	{
		return Poly();
		
	}

	Poly operator/ (const Poly &a)
	{
		return Poly();

	}

	Poly PowerBinaryPoly(int x){
		Poly temp;
		if (x == 1)
			return *this;
		else if (x == 3){
			temp = Poly(this->var, quotient*quotient*quotient, 3 * quotient*quotient*(this->next->quotient), 3 * quotient*(this->next->quotient)*(this->next->quotient), (this->next->quotient)*(this->next->quotient)*(this->next->quotient));
			temp.next->multi = &Poly(this->next->var, 1, 0);
			temp.next->next->multi = &Poly(this->next->var, 1, 0,0);
			temp.next->next->next->multi = &Poly(this->next->var, 1, 0,0,0);
			return temp;
		}
		return NULL;
			
	}

	Poly GetResult(unsigned char var, double f){
		return Poly();
	}

};

