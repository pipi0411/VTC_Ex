// Tuỳ vào lựa chọn của người dùng(+, -, x, :) để thông báo kết quả tương ứng với
// num1+num2, num1-num2, ...
#include <stdio.h>

int main(){
    int num1, num2;
    printf("Nhap so thu nhat:\n");
    scanf("%d", &num1);
    printf("Nhap so thu hai:\n");
    scanf("%d", &num2);
    printf("         Menu\n");
    printf("====================\n");
    printf("+: Cong\n");
    printf("-: Tru\n");
    printf("x: Nhan\n");
    printf("/: Chia\n");
    printf("====================\n");
    char c;
    printf("Chon phep tinh tuong ung (+, -, x, /): ");
    scanf(" %c", &c);
    switch (c)
    {
    case '+':
        printf("Ket qua phep tinh cong: %d + %d = %d\n", num1, num2, num1+num2);
        break;
    case '-':
        printf("Ket qua phep tinh tru: %d - %d = %d\n", num1, num2, num1-num2);
        break;
    case 'x':
        printf("Ket qua phep tinh nhan: %d x %d = %d\n", num1, num2, num1*num2);
        break;
    case '/':
        printf("Ket qua phep tinh chia: %d / %d = %f\n", num1, num2, (float)num1/num2);
        break;
    default:        
        printf("Chon sai\n");
        break;
    }
    return 0;
}