//viết mã lệnh thực hiện chương trình cho phép nhập các ký tự từ bàn phím,
//thông báo ký tự vừa nhập là chữ cái, chữ số hay ký tự đặc biệt. Chương trình sẽ dừng khi
//nhập vào ký tự trắng.
//  Created on: 12/08/2024
// #include <ctype.h>

// int main(){
//     char n;
//     while (1){
//         printf("Nhập ký tự: ");
//         scanf("%c", &n);
//         if( n == ' '){
//             break;
//         }else if(isalpha(n)){
//             printf("Ký tự vừa nhập là chữ cái\n");
//         }else if(isalnum(n)){
//             printf("Ký tự vừa nhập là chữ số\n");
//         }else{
//             printf("Ký tự vừa nhập là ký tự đặc biệt\n");
//         }
//         while(getchar() != '\n');
//     }
//     printf("Kết thúc chương trình\n");
//     return 0;
// }
#include <stdio.h>

int main(){
    char n;
    
    printf("Nhập ký tự (space để thoát):\n");

    while(1){
        scanf("%c", &n);
        if( n == '\n'){
            continue;
        }
        if ((n == ' ') || (n == '\0') || (n == '\a') || (n == '\b') || (n == '\t')) {
            break;
        }else if((n >= 'a' && n <= 'z') || (n >= 'A' && n <= 'Z')){
            printf("%c là chữ cái.\n", n);
        }else if(n >= '0' && n <= '9'){
            printf("%c là chữ số.\n", n);
        }else{
            printf("%c là ký tự đặc biệt.\n", n);
        }
    }
    printf("Kết thúc chương trình\n");
    return 0;
}