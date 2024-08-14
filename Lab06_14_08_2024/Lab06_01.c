//viết chương trình khai báo một mảng số nguyên có 10 phần tử, nhập dữ liệu
//cho mảng này và in ra các phần tử ở vị trí chẵn (0, 2, 4, ...)
#include <stdio.h>

int main(){
    int n[10] = {12, 256, 358, 436, 588, 6446, 78899, 81024, 910025, 100002};
    // for (int i = 0; i < 10; i++){
    //     printf("Nhap phan tu thu %d: ", i);
    //     scanf("%d", &n[i]);
    // }
    for (int i = 0; i < 10; i++){
        if (i % 2 == 0){
            printf("Phan tu thu %d: %d\n", i, n[i]);
        }
    }
    return 0;
}