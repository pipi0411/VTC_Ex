//viết chương trình liệt kê N số nguyên tố đầu tiên(N nhập từ bàn phím).
#include <stdio.h>

int main(){
    int n, count = 0, i = 2;
    printf("Nhap so nguyen n: ");
    scanf("%d", &n);
    while (count < n){
        int isPrime = 1;
        for (int j = 2; j < i; j++){
            if (i % j == 0){
                isPrime = 0;
                break;
            }
        }
        if (isPrime){
            printf("%d ", i);
            count++;
        }
        i++;
    }
    return 0;

}