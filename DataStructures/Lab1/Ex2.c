//Write a program to display the Fibonacci sequence of n Fibonacci numbers (using Recursive Algorithm).

#include <stdio.h>

int fibonacci(int n){
    if(n == 0){
        return 0;
    }
    else if(n == 1){
        return 1;
    }else{
        return fibonacci(n-1) + fibonacci(n-2);
    }
}

void printFibonacci(int n){
    for(int i = 0; i < n; i++){
        printf("%d\n", fibonacci(i));
    }
}

int main(){
    int n;
    printf("Nhap so luong so Fibonacci can in ra: ");
    scanf("%d", &n);

    printf("Day Fibonacci co %d so la: \n", n);
    printFibonacci(n);
    return 0;
}
