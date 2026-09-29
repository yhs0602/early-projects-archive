#include "Poly.h"

/*
void DerivatePoly(unsigned int degree, int quotient)
{
	Poly x = Poly('x', 1, 0);
	Poly h = Poly('h', 1, 0);
	Poly xplush = x + h;
	Poly poweredy0 = xplush.PowerBinaryPoly(degree);
	Poly poweredy1 = Poly('x', quotient, 0);
	Poly sub = poweredy0 - poweredy1;
	Poly DQ = sub / h;
	Poly fin = DQ.GetResult('h',0);
	fin.PrintPoly();
}
*/
void DerivateMissionModule(int degree,double quotient){

	Poly x = Poly('x', 1, 0);
	Poly h = Poly('h', 1, 0);
	Poly xplush = x + h;
	Poly poweredy0 = xplush.PowerBinaryPoly(degree);
	Poly poweredy1;
	if (degree == 1)
		poweredy1 = Poly('x', quotient, 0);
	else if (degree == 3)
		poweredy1 = Poly('x', quotient, 0, 0, 0 );
	Poly sub = poweredy0 - poweredy1;
	Poly DQ = sub / h;
	Poly fin = DQ.GetResult('h', 0);
	fin.PrintPoly();
}


void DerivateMission(double a, double b){
	DerivateMissionModule(3,a);
	DerivateMissionModule(1, b);
}

int main(){
	double x, y;
	scanf_s("%lf %lf", &x, &y);
	DerivateMission(x, y);
	system("pause");
	return 0;
}