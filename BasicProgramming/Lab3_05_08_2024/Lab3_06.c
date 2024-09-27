// #include <stdio.h>

// int main(){
// printf("Nhập 6 chữ số: ");
// int n, a1, a2, a3, a4, a5, a6;
// scanf("%d", &n);
// a1 = n % 10;
// a2 = (n / 10) % 10;
// a3 = (n / 100) % 10;
// a4 = (n / 1000) % 10;
// a5 = (n / 10000) % 10;
// a6 = (n / 100000) % 10;
// printf("6 chữ số đảo ngược: %d%d%d%d%d%d", a1, a2, a3, a4, a5, a6);
// return 0;

// }
#include <stdio.h>
 
int main(){
    int n, tmp;
    printf("Nhap 6 chữ số: ");
    scanf("%d", &n);
    int res = 0;
    while(n > 0){
        tmp = n % 10;
        res = res * 10 + tmp;
        n = n / 10;
    }
    printf("6 chữ số đảo ngược: %d", res);
    return 0;
}
