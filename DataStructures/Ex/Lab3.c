//3: Tính chu vi và diện tích hình chữ nhật
//Yêu cầu : Nhập chiều dài và chiều rộng, tính chu vi và diện tích hình chữ nhật

#include <stdio.h>

int main(){
    int length , width, perimeter, area;
    printf("Nhap vao chieu dai: ");
    scanf("%d", &length);
    printf("Nhap vao chieu rong: ");
    scanf("%d", &width);

    perimeter = (length + width) * 2;
    area = length * width;
    printf("Chu vi hinh chu nhat la: %d\n", perimeter);
    printf("Dien tich hinh chu nhat la: %d\n", area);
    return 0;

}