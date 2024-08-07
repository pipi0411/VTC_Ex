// viết chương trình C giải bài toán nhập vào ba số a, b, c. Kiểm tra xem đó có phải là ba cạnh của một tam giác hay không.
#include <stdio.h>
 
int main(){
    printf("Nhập a, b, c: \n");
    int a, b, c;
    scanf("%d%d%d", &a, &b, &c);
    if(a + b > c && a + c > b && b + c > a){
        printf("Ba cạnh của một tam giác là: %d, %d, %d", a, b, c);
    
    }else{
        printf("a, b, c không phải là ba cạnh của một tam giác\n");
    }
    return 0;
}