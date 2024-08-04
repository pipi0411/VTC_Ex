#include <stdio.h>
#include <math.h>
int main()
{
    printf("Nhập a , b: ");
    int a, b;
    scanf("%d %d", &a, &b);
    printf("a + b = %d\n", a + b);
    printf("a - b = %d\n", a - b);
    printf("a * b = %d\n", a * b);
    if (b = !0)
    {
        printf("a / b = %.2f\n", (float)a / b);
    }
    else
    {
        printf("Không thể chia cho 0\n");
    }
    return 0;
}