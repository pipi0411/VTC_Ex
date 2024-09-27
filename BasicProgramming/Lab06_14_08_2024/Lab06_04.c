//Khai báo một mảng số nguyên có 5 phần tử, yêu cầu người
//dùng nhập vào từ bàn phím số nguyên tố, nếu không phải là số nguyên tố yêu cầu nhập lại.
#include <stdio.h>

int main(){
    int n[5];
    int count = 0;
    int flag = 0;

    printf("Nhập 5 số nguyên tố:\n");
    for (int i = 0; i < 5; i++){
        do{
            flag = 0;
            scanf("%d", &n[i]);
            if (n[i] < 2){
                printf("Nhập lại số nguyên tố: ");
                flag = 1;
            }else{
                for (int j = 2; j < n[i]; j++){
                    if (n[i] % j == 0){
                        printf("Nhập lại số nguyên tố: ");
                        flag = 1;
                        break;
                    }
                }
            }
        }while(flag == 1);
    }

    printf("5 số nguyên tố vừa nhập là: ");
    for (int i = 0; i < 5; i++){
        printf("%d ", n[i]);
    }
    return 0;
}