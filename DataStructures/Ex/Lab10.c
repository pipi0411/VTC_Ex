//10: Tạo hàm tính tổng của 2 số
// Yêu cầu: Viết hàm Sum để tính tổng của 2 số nguyên 

#include <stdio.h>

int Sum(int a, int b){
    return a + b;
}

int main(){
    int num1, num2;
    printf("Nhap vao 2 so nguyen: ");
    scanf("%d %d", &num1, &num2);

    printf("Tong cua %d va %d la: %d\n", num1, num2, Sum(num1, num2));
    return 0;

}