#include <stdio.h>

int main(){
    int a, b;
    int *p1, *p2;
    printf("Nhap a: ");
    scanf("%d", &a);
    printf("Nhap b: ");
    scanf("%d", &b);
    p1 = &a;
    p2 = &b;
    printf("Gia tri a %d\n", *p1);
    printf("Gia tri b %d\n", *p2);
    printf("Dia chi a %p\n", p1);
    printf("Dia chi b %p\n", p2);
    int *temp ;
    temp = p1;
    p1 = p2;
    p2 = temp;

    printf("Gia tri a = %d, Dia chi a = %p\n", *p1, p1);
    printf("Gia tri b = %d, Dia chi b = %p", *p2 , p2);
    return 0;
}