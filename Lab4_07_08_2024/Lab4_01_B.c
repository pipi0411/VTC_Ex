#include <stdio.h>

int main(){
    int a ,b ,c;
    printf("Nhập a: \n");
    scanf("%d", &a);
    printf("Nhập b: \n");
    scanf("%d", &b);
    printf("Nhập c: \n");
    scanf("%d", &c);
    if(a >= b && a >= c){
        printf("Max a: %d\n", a);
    }else if(b >= a && b >= c){
        printf("Max b: %d\n", b);
    }else{
        printf("Max c: %d\n", c);
    }
    return 0;
}