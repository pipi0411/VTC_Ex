//viết chương trình nhập một số nguyên dương bất kỳ, tính tổng các chữ số của nó.
#include <stdio.h>

int main(){
    int n, sum = 0;
    printf("Nhap so nguyen duong n: ");
    scanf("%d", &n);
    while (n > 0){
        sum += n % 10;
        n /= 10;
    }
    printf("Tong cac chu so cua n la: %d", sum);
    return 0;
}