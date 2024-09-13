//5: Tính số lớn nhất trong 2 số
//Yêu cầu: Nhập 2 số và in ra số lớn nhất

#include <stdio.h>

int main(){
    int num1, num2;
    printf("Nhap vao 2 so nguyen: ");
    scanf("%d %d", &num1, &num2);
    if(num1 > num2){
        printf("%d la so lon nhat\n", num1);
    }else{
        printf("%d la so lon nhat\n", num2);
    }
    return 0;

}