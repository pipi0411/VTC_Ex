#include <stdio.h>
#include <math.h>

int main(){
    float x , y, ex;
    printf("Nhập x: \n");
    scanf("%f", &x);
    printf("Nhập y: \n");
    scanf("%f", &y);
    ex = x * x * x + 3 * x * x * y + 3 * x * y * y + y * y * y;
    printf("ex = %f", ex);
    return 0;
}