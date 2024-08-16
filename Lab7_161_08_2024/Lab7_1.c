//viết chương trình thực hiện nhập một số nguyên n, sau đó nhập dữ liệu cho
//mảng n phần tử. Sắp xếp theo chiều tăng dần của mảng đó và hiển thị dữ liệu lên màn hình.

#include <stdio.h>

int main(){
    int n;
    printf("Nhap so nguyen n: ");
    scanf("%d", &n);
    int arr[n];
    for(int i = 0; i < n; i++ ){
        printf("Nhap phan tu thu %d: ", i+1);
        scanf("%d", &arr[i]);
    }
    int temp;
    for( int i = 0; i < n-1; i++){
        for( int j = 0; j < n-i-1; j++){
            if(arr[j] > arr[j+1]){
                temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
            }
        }

    }
    printf("Mang sau khi sap xep: ");
    for(int i = 0; i < n; i++){
        printf("%d ", arr[i]);
    }
    return 0;
    
}