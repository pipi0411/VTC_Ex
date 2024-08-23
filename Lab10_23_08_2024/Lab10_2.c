//Viết chương trình nhập một chuỗi từ bạn phím tiến hành chuẩn hóa chuỗi theo yêu cầu sau:
// • Chuyển ký tự đầu tiên thành in hoa (nế nó đang là in thường).
// • Mỗi từ trong chuỗi nhập vào hỉ cách nhau 1 ký tự trắng (chỉ để 1 ký tự trắng giữa hai
// từ).
// • Không có ký tự trắng ở đầu và cuối xâu.

#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main(){
    char str[100];
    printf("Enter a string: ");
    fgets(str, sizeof(str), stdin);
    str[0] = toupper(str[0]);
    for(int i = 1; i < strlen(str); i++){
        str[i] = tolower(str[i]);
    }
    for(int i = 0; i < strlen(str); i++){
        if(str[i] == ' '){
            if(str[i+1] == ' '){
                for(int j = i; j < strlen(str); j++){
                    str[j] = str[j+1];
                }
                i--;
            }
        }
    }

    if(str[strlen(str)-1] == ' '){
        str[strlen(str)-1] = '\0';
    }
    printf("The normalized string: %s\n", str);
    return 0;
}