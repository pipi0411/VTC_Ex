//6: Tính giá trị tuyệt đối của 1 số 
// Yêu cầu :Nhập 1 số và tính giá trị tuyệt đối

#include <stdio.h>

int main(){
    int num, absValue;
    printf("Nhap vao 1 so nguyen: ");
    scanf("%d", &num);
    absValue = num < 0 ? -num : num;
    printf("Gia tri tuyet doi cua %d la: %d\n", num, absValue);
    return 0;
}