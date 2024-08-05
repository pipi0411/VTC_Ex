#include <stdio.h>

int main(){
    int sum1, sum2 , temp;
    printf("Nhập sum1: \n");
    scanf("%d", &sum1);
    printf("Nhập sum2: \n");
    scanf("%d", &sum2);
    //hoán đổi giá trị của sum1 và sum2
    temp = sum1;
    sum1 = sum2;
    sum2 = temp;

    sum1++;
    sum2++;

    printf("sum1 = %d, sum2 = %d", sum1, sum2);
    return 0;

}