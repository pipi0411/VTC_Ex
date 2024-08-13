//viết chương trình yêu cầu nhập vào 2 số nguyên n, m và in ra những số chia
//hết cho 7 trong khoảng 2 số vừa nhập.
#include <stdio.h>

int main(){
    int n, m;
    printf("Nhap so nguyen n: ");
    scanf("%d", &n);
    printf("Nhap so nguyen m: ");
    scanf("%d", &m);
    for (int i = n; i <= m; i++){
        if (i % 7 == 0){
            printf("%d la so chia het cho 7 \n", i);
        }
    }
    return 0;
}