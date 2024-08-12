#include <stdio.h>

int main(){
    int n;
    do{
        printf("SO THICH CA NHAN\n");
        printf("=================\n");
        printf("1. Doc sach\n");
        printf("2. Nghe nhac\n");
        printf("3. Choi the thao\n");
        printf("4. May tinh\n");
        printf("5. Thoat\n");
        printf("=================\n");
        printf("Chon so thich cua ban: ");
        scanf("%d", &n);
    switch (n){
        case 1: printf("Ban thich doc sach\n"); 
        break;
        case 2: printf("Ban thich nghe nhac\n");
        break;
        case 3: printf("Ban thich choi the thao\n");
        break;
        case 4: printf("Ban thich may tinh\n");
        break;
        case 5: printf("Ban chon thoat\n");
        break;
        default: printf("Moi chon lai\n");
    }
    }while(n != 5);
    return 0;
}