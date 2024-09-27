//Bubble Sort
#include <stdio.h>

//Sắp xếp một mảng số nguyên bằng thuật toán Bubble Sort.
void bubbleSort(int arr[], int n){
    for(int i = 0; i < n - 1; i++){  //Vòng lặp ngoài
        for(int j = 0; j < n - i - 1; j++){ //Vòng lặp trong
            if(arr[j] > arr[j + 1]){  //Nếu phần tử thứ j lớn hơn phần tử thứ j + 1 thì đổi chỗ 2 phần tử đó.
                int temp = arr[j];  //Sử dụng biến tạm để đổi chỗ 2 phần tử.
                arr[j] = arr[j + 1];  //Đổi chỗ 2 phần tử.
                arr[j + 1] = temp; //Đổi chỗ 2 phần tử.
            }
        }
    }
}

// Tìm phần tử lớn nhất trong mảng số nguyên.
int findMax(int arr[], int n){
    int max = arr[0]; //Gán phần tử đầu tiên của mảng cho biến max.
    for( int i = 1; i < n; i++){ //Duyệt qua các phần tử của mảng.
        if(arr[i] > max){ //Nếu phần tử thứ i lớn hơn max thì gán max bằng phần tử thứ i.
            max = arr[i];
        }
    }
    return max; //Trả về phần tử lớn nhất.
}

//Chèn phần tử vào mảng
void insertElement(int arr[], int *n, int pos, int value) { //pos là vị trí cần chèn, value là giá trị cần chèn.
    for(int i = *n; i >= pos; i--){  
        arr[i] = arr[i-1]; //Dịch chuyển các phần tử từ vị trí pos đến cuối mảng sang phải một vị trí.
    }
    arr[pos-1] = value; 
    (*n)++;
}

// Xóa phần tử trong mảng
void deleteElement(int arr[], int *n, int pos){ //pos là vị trí cần xóa.
    for(int i = pos-1; i < *n-1; i++){
        arr[i] = arr[i+1]; //Dịch chuyển các phần tử từ vị trí pos đến cuối mảng sang trái một vị trí.
    }
    (*n)--; //Giảm số lượng phần tử của mảng đi 1.
}

//In mảng số nguyên.
void printArray(int arr[], int n){
    for(int i = 0; i < n; i++){
        printf("%d ", arr[i]);
    }
    printf("\n");
}

int main(){
    int arr[] = {64, 34, 25, 12, 22, 11, 90}; //Mảng số nguyên cần sắp xếp.
    int n = sizeof(arr)/sizeof(arr[0]); //Số lượng phần tử của mảng.
    bubbleSort(arr, n); //Sắp xếp mảng số nguyên.
    printf("Sorted array: \n"); // Xuất thông báo.
    printArray(arr, n); //In mảng số nguyên đã sắp xếp.
    printf("Max element in array: %d\n", findMax(arr, n)); //Tìm phần tử lớn nhất trong mảng số nguyên.
    insertElement(arr, &n, 4, 4); // Chèn phần tử 4 vào vị trí thứ 4 của mảng.
    printf("Array after inserting element: \n");
    printArray(arr, n);
    deleteElement(arr, &n, 4); // Xóa phần tử ở vị trí thứ 4 của mảng.
    printf("Array after deleting element: \n");
    printArray(arr, n);
    return 0;
}