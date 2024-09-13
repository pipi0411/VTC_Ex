//7:Kiểm tra năm nhuận 
// Yêu cầu: Nhập 1 năm và kiểm tra xem đó có phải là năm nhuận không

#include <stdio.h>

int main(){
    int year;
    printf("Nhap vao 1 nam: ");
    scanf("%d,", &year);

    if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0){
        printf("%d la nam nhuan\n", year);
    }else{
        printf("%d khong phai la nam nhuan\n", year);
    }
    return 0;
}