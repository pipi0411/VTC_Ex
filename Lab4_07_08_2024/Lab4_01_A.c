#include <stdio.h>
int main(){
    float a , b , x;
    printf("Nhập a: \n");
    scanf("%f", &a);
    printf("Nhập b: \n");
    scanf("%f", &b);
    if ( a == 0 ){
        if ( b == 0 ){
            printf("Phương trình có vô số nghiệm\n");
        }else{
            printf("Phương trình vô nghiệm\n");
        }
    } else{
        x = -b/a;
        printf("Phương trình có nghiệm x = %.2f\n", x);
    }
    return 0;

}