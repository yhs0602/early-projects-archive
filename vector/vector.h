///////////////////////////////º¤ÅÍ ¿µ¿ª///////////////////////////////////// 
typedef struct{
        double x, y, z, total;
}Vector;

#define SubVector(a,b) AddVector(a,NegateVector(b))

Vector *AddVector(Vector* a, Vector* b);
Vector *MulVectorNum(Vector *a, double num);
Vector *DivVectorNum(Vector *a, double num);
Vector *NegateVector(Vector *a);
Vector *Normalize(Vector *v);

