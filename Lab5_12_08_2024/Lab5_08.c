//viết chương trình nhập vào một số nguyên trong khoảng 0 → 31. Chuyển số
//nguyên đó sang dạng nhị phân(lưuý không dùng hàm itoa()). Ví dụ: Nếu nhập vào số 12 thì chương trình sẽ in ra 1100.
#include <stdio.h>

int main(){
    int n, s = 0;
    printf("Nhap so nguyen n(0 -> 31): ");
    scanf("%d", &n);
    if (n < 0 || n > 31){
        printf("So nguyen n khong hop le");
        return 1;
    }
    for (int i = 31; i >= 0; i--){
        if ((n >> i) & 1){
            s = 1;
        }
        if (s){
            printf("%d", (n >> i) & 1);
        }
    }
    return 0;
}