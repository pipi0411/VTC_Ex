#include <stdio.h>

int main(){
    double km;
    double m = 0.000621371192;
    double mile;
    printf("1 meter = 0.000621371192 mile\n-----------------------------\n");
    printf("Nhập số km: ");
    scanf("%lf", &km);
    printf("Kết quả:\n");

    mile = km * m * 1000;
    printf("%.2f km = %.7f mile", km, mile);
    return 0;
}