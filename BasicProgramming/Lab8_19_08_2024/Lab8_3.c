#include <stdio.h>

int main(){
    int a[5];
    int b[5];
    int *p1, *p2;
    printf("Nhap du lieu cho mang a: \n");
    for(int i = 0; i < 5; i++){
        printf("a[%d] = ", i);
        scanf("%d", a + i);
    }
    printf("Nhap du lieu cho mang b: \n");
    for(int i = 0; i < 5; i++){
        printf("b[%d] = ", i);
        scanf("%d", b + i);
    }
    int c[5];

    for(int i = 0; i < 5; i++) {
        *(c + i) = *(a + i) + *(b + i);
        printf("c[%d] = %d\n", i, *(c + i));
    }
    return 0;
}