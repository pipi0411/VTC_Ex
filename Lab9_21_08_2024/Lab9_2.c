#include <stdio.h>
#include <math.h>


int inputNumber(char c){
    int n;
    printf("Nhap so nguyen %c: ", c);
    scanf("%d", &n);
    return n;
}

int checkNumber(int num){
    if (num < 2){
        return 0;
    }
    for (int i = 2; i <= sqrt(num); i++){
        if (num % i == 0){
            return 0;
        }
    }
    return 1;
}


int main(){
    int arr[7];
    printf("Nhap du lieu cho mang 7 so nguyen: \n");
    for (int i = 0; i < 7; i++){
        arr[i] = inputNumber('0' + i);
    }
    printf("Cac so nguyen to trong mang: ");
    for (int i = 0; i < 7; i++){
        if (checkNumber(arr[i])){
            printf("%d ", arr[i]);
        }
    }
    return 0;
}