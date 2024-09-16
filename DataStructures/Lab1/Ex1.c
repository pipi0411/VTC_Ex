//Use a recursive algorithm to write a program to print numbers between 1 and 100. 
#include <stdio.h>

void printNumbers(int n){
    if(n > 100){
        return;
    }
    printf("%d\n", n);
    printNumbers(n+1); // Recursive call
}

int main(){
    printNumbers(1); // Call the function with 1 as the first argument
    return 0;
}

