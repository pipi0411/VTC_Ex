#include <stdio.h>

int main(){
   int arr[5];
   int *prt;
   prt = arr;
   printf("Nhap du lieu cho mang: \n");
   for(int i = 0; i < 5; i++){
       printf("arr[%d] = ", i);
       scanf("%d", prt + i);
   }
    printf("In mang: \n");
    for(int i = 0; i < 5; i++){
        printf("arr[%d] = %d\n", i, *(prt + i));
    }
    return 0;
}