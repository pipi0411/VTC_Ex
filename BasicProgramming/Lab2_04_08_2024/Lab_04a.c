#include <stdio.h>
#include <math.h>

int main()
{
    printf("Nhập n: ");
    int n;
    scanf("%d", &n);
    if (n <= 0)
    {
        printf("N phải lớn hơn 0.\n");
        return 1;
    }
    int m = 0;
    int sum = 0;
    while (sum + (m + 1) <= n)
    {
        m++;
        sum += m;
    }

    printf("Số m sao cho 1 + 2 + 3 + ... + m <= %d là %d\n", n, m);
    return 0;
}