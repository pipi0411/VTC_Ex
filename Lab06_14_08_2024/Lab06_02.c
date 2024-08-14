//viết chương trình khai báo một mảng số nguyên (int) có 10 phần tử và một
//mảng số thực (float) có 5 phần tử. Nhập dữ liệu cho mảng số thực sau đó gán các phần tử
//của mảng số thực này cho các vị trí lẻ của mảng số nguyên (các phần tử còn lại bằng 0).
//Cuối cùng hiển thị hai mảng này ra màn hình.
#include<stdio.h>

int main(){
    int n[10] = {0};
    float m[5] = {5.2, 10.56, 3.58, 9.36, 15.88};
    int i = 0;
    int j = 1;
    while (j < 10){
        n[j] = m[i];
        i++;
        j += 2;
    }
    for (int i = 0; i < 10; i++){
        printf("n[%d] = %d\n", i, n[i]);
    }
    for (int i = 0; i < 5; i++){
        printf("m[%d] = %.2f\n", i, m[i]);
    }
    return 0;
}