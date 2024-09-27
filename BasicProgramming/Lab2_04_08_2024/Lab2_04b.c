#include <stdio.h>
#include <math.h>

int main()
{
    printf("Nhập n: ");
    int n, S;
    scanf("%d", &n);
    if (n <= 0)
    {
        printf("N phải lớn hơn 0.\n");
        return 1;
    }
    S = 1;
    if (n % 2 == 0)
    {
        for (int i = 2; i <= n; i += 2)
        {
            S *= i;
        }
    }
    else
    {
        for (int i = 1; i <= n; i += 2)
        {
            S *= i;
        }
    }
    printf("S = %d\n", S);
    return 0;
}