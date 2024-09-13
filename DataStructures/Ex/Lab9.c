//9: Tính giai thừa của 1 số 
//Yêu cầu: Nhập 1 số nguyên dương và tính gia thừa của nó

#include <stdio.h>

int main(){
    int num, i;
    long long factorial = 1;
    printf("Nhap vao 1 so: ");
    scanf("%d", &num);

    if( num < 0){
        printf("Khong the tinh giai thua cua so am\n");
    }else{
        for(i = 1; i <= num; i++){
            factorial *= i;
        }
        printf("Giai thua cua %d la: %lld\n", num, factorial);
    }
    return 0;

}