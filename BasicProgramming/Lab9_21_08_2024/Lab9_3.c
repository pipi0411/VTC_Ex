#include <stdio.h>

int fibonacci(int n){
    if (n == 0){
        return 0;
    }
    if (n == 1){
        return 1;
    }   
    int a = 0, b = 1, fib = 1;
    for (int i = 1; i < n; i++){
        fib = a + b;
        a = b;
        b = fib;
    }
    return fib;
}

int main(){
    int n;
    printf("Nhap n: ");
    scanf("%d", &n);

    printf("So Fibonacci thu %d la %d\n", n,  fibonacci(n));
    return 0;

}