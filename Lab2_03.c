#include <stdio.h>
#include <math.h>

int main()
{
    printf("Nhập a , b: ");
    float a, b;
    scanf("%f%f", &a, &b);
    if (a == 0)
    {
        if (b == 0)
        {
            printf("Phương trình vô số nghiệm\n");
        }
        else
        {
            printf("Phương trình vô nghiệm\n");
        }
    }
    else
    {
        printf("Phương trình có nghiệm duy nhất x = %.2f\n", -b / a);
    }
}