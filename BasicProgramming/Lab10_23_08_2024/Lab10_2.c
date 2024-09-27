//Viết chương trình nhập một chuỗi từ bạn phím tiến hành chuẩn hóa chuỗi theo yêu cầu sau:
// • Chuyển ký tự đầu tiên thành in hoa (nế nó đang là in thường).
// • Mỗi từ trong chuỗi nhập vào hỉ cách nhau 1 ký tự trắng (chỉ để 1 ký tự trắng giữa hai
// từ).
// • Không có ký tự trắng ở đầu và cuối xâu.

#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main() {
    char str[100];
    printf("Enter a string: ");
    fgets(str, sizeof(str), stdin);

    if (str[strlen(str) - 1] == '\n') {
        str[strlen(str) - 1] = '\0';
    }

    int len = strlen(str);
    int i = 0;
    int j = 0;


    while (isspace(str[i])) {
        i++;
    }

    while (i < len) {

        if (j == 0 || (j > 0 && str[j - 1] == ' ')) {
            str[j] = toupper(str[i]);
        } else {
            str[j] = tolower(str[i]);
        }

        if (isspace(str[i])) {
            while (isspace(str[i + 1])) {
                i++;
            }
        }

        i++;
        j++;
    }

    if (j > 0 && str[j - 1] == ' ') {
        j--;
    }

    str[j] = '\0';

    printf("The normalized string: %s\n", str);

    return 0;
}
