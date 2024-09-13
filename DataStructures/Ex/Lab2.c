//2:Tính tổng 2 số nguyên 
// Yêu cầu : Nhập vào 2 số nguyên và in tổng của chúng

#include <stdio.h>

int main(){
    int a, b;
    printf("Nhap vao 2 so nguyen: ");
    scanf("%d %d", &a, &b);
    int sum = a + b;
    printf("Tong cua %d va %d so nguyen la: %d\n",a , b ,sum);
    return 0;
}
