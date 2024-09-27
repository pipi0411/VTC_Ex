#include <stdio.h>
#include <math.h>

int main(){
    double r , h , v, sd, pi = 3.14159265359;
    printf("Enter the radius of the cylinder: ");
    scanf("%lf", &r);
    printf("Enter the height of the cylinder: ");
    scanf("%lf", &h);
    sd = pi * r * r;
    v = sd * h;
    printf("The surface area of the cylinder is: %2.lf\n", sd);
    printf("The volume of the cylinder is: %.2lf\n", v);
    return 0;
}