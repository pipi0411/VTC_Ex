// viết chương trình C nhập vào 4 số thực a, b, c, d thực hiện tính và in kết quả số lớn nhất (max) và nhỏ nhất (min) ra màn hình.
#include <stdio.h>

int main(){
    float a, b , c, d;
    printf("Nhập a, b, c, d: \n");
    scanf("%f%f%f%f", &a, &b, &c, &d);
    if (a >= b && a >= c && a >= d){
        printf("Max a = %.2f\n", a);
    } else if (b >= a && b >= c && b >= d){
        printf("Max b = %.2f\n", b);
    } else if (c >= a && c >= b && c >= d){
        printf("Max c = %.2f\n", c);
    } else{
        printf("Max d = %.2f\n", d);
    }
    if( a <= b && a <= c && a <= d){
        printf("Min a = %.2f\n", a);
    } else if (b <= a && b <= c && b <= d){
        printf("Min b = %.2f\n", b);
    } else if (c <= a && c <= b && c <= d){
        printf("Min c = %.2f\n", c);
    } else{
        printf("Min d = %.2f\n", d);
    }
    
return 0;

}