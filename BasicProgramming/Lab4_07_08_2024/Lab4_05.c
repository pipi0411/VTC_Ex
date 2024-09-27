// viết chương trình: Nhập vào tọa độ ba điểm A(xA, yA), B(xB, yB) và C(xC, yC) kiểm tra xem ba điểm đó có thẳng hàng hay không.
#include <stdio.h>
#include <math.h>

int main() {
    float xA, yA, xB, yB, xC, yC;
    float S;

    // Nhập tọa độ của ba điểm
    printf("Nhập tọa độ điểm thứ nhất (xA, yA): ");
    scanf("%f %f", &xA, &yA);
    printf("Nhập tọa độ điểm thứ hai (xB, yB): ");
    scanf("%f %f", &xB, &yB);
    printf("Nhập tọa độ điểm thứ ba (xC, yC): ");
    scanf("%f %f", &xC, &yC);

    // Tính diện tích tam giác
    S = 0.5 * fabs(xA * (yB - yC) + xB * (yC - yA) + xC * (yA - yB));

    // Kiểm tra diện tích có bằng 0 hay không
    if (S == 0) {
        printf("Ba điểm A, B, C thẳng hàng\n");
    } else {
        printf("Ba điểm A, B, C không thẳng hàng\n");
    }

    return 0;
}
