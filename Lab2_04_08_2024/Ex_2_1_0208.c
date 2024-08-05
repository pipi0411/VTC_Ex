#include<stdio.h>

int main () {
    int size;
    size = sizeof(int);
    printf("\nint : %d bytes\n", size);
    size = sizeof(long int);
    printf("long int : %d bytes\n", size);
    size = sizeof(long long int);
    printf("long long int : %d bytes\n", size);
    size = sizeof(float);
    printf("float : %d bytes\n", size);
    size = sizeof(double);
    printf("double : %d bytes\n", size);
    size = sizeof(long double);
    printf("long double : %d bytes\n", size);
    size = sizeof(char);
    printf("char : %d bytes\n", size);
    return 0;
}