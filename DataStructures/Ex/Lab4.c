//4: Kiểm tra số chẵn và lẻ 
// Yêu cầu :Nhập 1 số nguyên và kiểm tra xem nó là chẵn hay lẻ

#include <stdio.h>

int main(){
    int num;
    printf("Nhap vao 1 so nguyen: ");
    scanf("%d", &num);
    if(num % 2 == 0){
        printf("%d la so chan\n", num);
    }else{
        printf("%d la so le\n", num);
    }
    return 0;

}