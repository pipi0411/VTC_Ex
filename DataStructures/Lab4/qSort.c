// Quick Sort
#include <stdio.h>

// Sắp xếp mảng số nguyên bằng thuật toán Quick Sort.
void sawp(int *a, int *b){
    int temp = *a;
    *a = *b;
    *b = temp;
}

// Hàm chia mảng làm 2 phần, trả về chỉ số phần tử chia mảng.
int partition(int arr[], int low, int high){
    int pivot = arr[high]; // Chọn phần tử cuối cùng làm pivot.
    int i = low - 1; // Chỉ số của phần tử nhỏ hơn pivot.
    for(int j = low; j < high; j++){
        if(arr[j] < pivot){ // Nếu phần tử thứ j nhỏ hơn pivot.
            i++;  // Tăng chỉ số phần tử nhỏ hơn pivot.
            sawp(&arr[i], &arr[j]); // Đổi chỗ 2 phần tử.
        }
    }
    sawp(&arr[i + 1], &arr[high]); // Đổi chỗ phần tử sau chỉ số i với pivot.
    return i + 1; // Trả về chỉ số của pivot.
}

// Hàm sắp xếp mảng số nguyên theo thứ tự tăng dần.
void quickSort(int arr[], int low, int high){
    if(low < high){
        int pi = partition(arr, low, high); // Chia mảng làm 2 phần.
        quickSort(arr, low, pi - 1); // Sắp xếp phần trước pivot.
        quickSort(arr, pi + 1, high); // Sắp xếp phần sau pivot.
    }
}


void printArr(int arr[], int n){
    for(int i = 0; i < n; i++){
        printf("%d ", arr[i]);
    }
    printf("\n");
}

int main(){
    int arr[] = {10, 7, 8, 15, 16, 20};
    int n = sizeof(arr) / sizeof(arr[0]); // Số phần tử của mảng.
    quickSort(arr, 0, n - 1); // Sắp xếp mảng.
    printf("Sorted array: \n");
    printArr(arr, n); // In mảng đã sắp xếp.
    return 0;
}