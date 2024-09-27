//viết chương trình in ra màn hình các chia hết cho 9 nằm trong khoảng từ 200 đến 300.
#include <stdio.h>
int main(){
    for (int i = 200; i <= 300; i++){
        if (i % 9 == 0){
            printf("%d\n", i);
        }
    }
    return 0;
}