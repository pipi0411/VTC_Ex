#include <stdio.h>

int main(){
    float i , j, ex;
    printf("Nhập i: \n");
    scanf("%f", &i);
    printf("Nhập j: \n");
    scanf("%f", &j);
    ex = i / j;
    printf("ex = %.7f", ex);
    return 0;
}