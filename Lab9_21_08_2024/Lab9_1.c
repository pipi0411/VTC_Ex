#include <stdio.h>

int power(int a, int n){
    int result = 1;
    for (int i = 0; i < n; i++){
        result *= a;
    }
    return result;
}

int main(){
    int a,n;
    printf("Nhap 2 so nguyen a và n: ");
    scanf("%d %d", &a, &n);
    printf("%d^%d = %d\n", a, n, power(a, n));
    return 0;

}