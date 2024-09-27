//viết chương trình khai bảo một mảng số nguyên gồm 10 phần tử, nhập dữ liệu
//cho mảng này rồi in ra màn hình giá trị lớn nhất, nhỏ nhất và số lần xuất hiện của chúng
//trong mảng.

#include <stdio.h>

int main(){
    int n[10] = {1,110,110,1,2,5,8,9,10,11};

    int max = n[0];
    int min = n[0];
    int countMax = 0;
    int countMin = 0;

    for (int i = 0; i < 10; i++){
        if (n[i] > max){
            max = n[i];
        }
        if (n[i] < min){
            min = n[i];
        }
    }

    for (int i = 0; i < 10; i++){
        if (n[i] == max){
            countMax++;
        }
        if (n[i] == min){
            countMin++;
        }
    }

    printf("Max = %d\n", max);
    printf("Min = %d\n", min);
    printf("CountMax = %d\n", countMax);
    printf("CountMin = %d\n", countMin);
    return 0;
}

