#include <stdio.h>
#include <stdlib.h>

// Khai báo các hàm
void themPhanTu(int arr[], int *n);
void suaPhanTu(int arr[], int n);
void xoaPhanTu(int arr[], int *n);
void timKiemTuyenTinh(int arr[], int n);
void timKiemNhiPhan(int arr[], int n);
void sapXepGiamDan(int arr[], int n);
void chenPhanTu(int arr[], int *n);
void hienThiMang(int arr[], int n);

int main() {
    int arr[100];
    int n = 0; // Số phần tử trong mảng
    int choice;

    do {
        printf("\n----------------------\n");
        printf("MENU\n");
        printf("1. Nhap them mot phan tu cho mang\n");
        printf("2. Sua phan tu theo vi tri cua mang\n");
        printf("3. Xoa phan tu mang theo vi tri\n");
        printf("4. Tim kiem tuyen tinh mot phan tu trong mang\n");
        printf("5. Tim kiem nhi phan mot phan tu trong mang\n");
        printf("6. Sap xep theo chieu giam dan\n");
        printf("7. Chen them mot phan tu cho mang sao cho danh sach sap xep van duoc bao toan\n");
        printf("8. Hien thi mang\n");
        printf("0. Thoat chuong trinh\n");
        printf("Moi ban chon: ");
        scanf("%d", &choice);

        switch(choice) {
            case 1:
                themPhanTu(arr, &n);
                break;
            case 2:
                suaPhanTu(arr, n);
                break;
            case 3:
                xoaPhanTu(arr, &n);
                break;
            case 4:
                timKiemTuyenTinh(arr, n);
                break;
            case 5:
                timKiemNhiPhan(arr, n);
                break;
            case 6:
                sapXepGiamDan(arr, n);
                break;
            case 7:
                chenPhanTu(arr, &n);
                break;
            case 8:
                hienThiMang(arr, n);
                break;
            case 0:
                printf("Thoat chuong trinh.\n");
                break;
            default:
                printf("Lua chon khong hop le!\n");
        }
    } while(choice != 0);

    return 0;
}

void themPhanTu(int arr[], int *n) {
    if (*n >= 100) {
        printf("Mang da day!\n");
        return;
    }
    int value;
    printf("Nhap gia tri muon them: ");
    scanf("%d", &value);
    arr[*n] = value;
    (*n)++;
}

void suaPhanTu(int arr[], int n) {
    int index, value;
    printf("Nhap vi tri can sua: ");
    scanf("%d", &index);
    if (index < 0 || index >= n) {
        printf("Vi tri khong hop le!\n");
        return;
    }
    printf("Nhap gia tri moi: ");
    scanf("%d", &value);
    arr[index] = value;
}

void xoaPhanTu(int arr[], int *n) {
    int index;
    printf("Nhap vi tri can xoa: ");
    scanf("%d", &index);
    if (index < 0 || index >= *n) {
        printf("Vi tri khong hop le!\n");
        return;
    }
    for (int i = index; i < *n - 1; i++) {
        arr[i] = arr[i + 1];
    }
    (*n)--;
}

void timKiemTuyenTinh(int arr[], int n) {
    int value;
    printf("Nhap gia tri can tim: ");
    scanf("%d", &value);
    for (int i = 0; i < n; i++) {
        if (arr[i] == value) {
            printf("Tim thay %d tai vi tri %d\n", value, i);
            return;
        }
    }
    printf("Khong tim thay %d trong mang\n", value);
}

void timKiemNhiPhan(int arr[], int n) {
    int value, left = 0, right = n - 1, mid;
    printf("Nhap gia tri can tim: ");
    scanf("%d", &value);
    while (left <= right) {
        mid = (left + right) / 2;
        if (arr[mid] == value) {
            printf("Tim thay %d tai vi tri %d\n", value, mid);
            return;
        } else if (arr[mid] < value) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    printf("Khong tim thay %d trong mang\n", value);
}

void sapXepGiamDan(int arr[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = i + 1; j < n; j++) {
            if (arr[i] < arr[j]) {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    printf("Mang da duoc sap xep giam dan.\n");
}

void chenPhanTu(int arr[], int *n) {
    if (*n >= 100) {
        printf("Mang da day!\n");
        return;
    }
    int value, i;
    printf("Nhap gia tri muon chen: ");
    scanf("%d", &value);

    for (i = *n - 1; (i >= 0 && arr[i] < value); i--) {
        arr[i + 1] = arr[i];
    }

    arr[i + 1] = value;
    (*n)++;
    printf("Da chen phan tu vao mang.\n");
}

void hienThiMang(int arr[], int n) {
    printf("Cac phan tu trong mang la: ");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");
}