#include <stdio.h>
#include <stdlib.h> // Thư viện cần thiết để sử dụng malloc

int main() {
    int n;
    float *arr; // Khai báo con trỏ để cấp phát bộ nhớ cho mảng số thực

    // Bước 1: Nhập số nguyên n từ bàn phím
    printf("Nhập số phần tử n: ");
    scanf("%d", &n);

    // Bước 2: Cấp phát bộ nhớ cho mảng số thực với n phần tử
    arr = (float *)malloc(n * sizeof(float));
    if (arr == NULL) { // Kiểm tra nếu cấp phát bộ nhớ thất bại
        printf("Không đủ bộ nhớ để cấp phát!\n");
        return 1; // Kết thúc chương trình nếu không cấp phát được bộ nhớ
    }

    // Bước 3: Nhập dữ liệu cho mảng số thực arr
    printf("Nhập các phần tử của mảng:\n");
    for (int i = 0; i < n; i++) {
        printf("Phần tử %d: ", i + 1);
        scanf("%f", &arr[i]);
    }

    // Bước 4: Hiển thị toàn bộ các phần tử vừa nhập
    printf("Các phần tử trong mảng là:\n");
    for (int i = 0; i < n; i++) {
        printf("%.2f ", arr[i]);
    }
    printf("\n");

    // Giải phóng bộ nhớ sau khi sử dụng
    free(arr);

    return 0;
}
