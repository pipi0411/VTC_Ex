//8: Đổi nhiệt độ từ độ C sang độ F
// Yêu cầu: Nhập nhiệt độ độ C và đổi sang độ F

#include <stdio.h>

int main(){
    float celsius, fahrenheit;

    printf("Nhap vao do C: ");
    scanf("%f", &celsius);

    fahrenheit = (celsius * 9 / 5) + 32;

    printf("Nhiet do tuong duong (do F): %.2f\n", fahrenheit);
    return 0;

}