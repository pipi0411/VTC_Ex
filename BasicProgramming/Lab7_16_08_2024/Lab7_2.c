#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main () {

int arr[100];

srand(time(NULL));
    for (int i = 0; i < 100; i++)
    {
        arr[i] = rand()%1000;
    }
    printf("Mảng đầu tiên:\n");
    for (int i = 0; i < 100; i++)
    {

        printf("%4d",arr[i]);
        if((i+1)%10==0) {
            printf("\n");
        }

    }
     for (int i = 0; i < 100; i++)
    {
        for (int j = 0; j < 100 - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }

    printf("Mảng sắp xếp tăng dần:\n");
    for (int i = 0; i < 100; i++)
    {

        printf("%4d",arr[i]);
        if((i+1)%10==0) {
            printf("\n");
        }

    }
    return 0;
}
