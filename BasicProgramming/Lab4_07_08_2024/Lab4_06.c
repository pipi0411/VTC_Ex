//Viết chương trình cho phép nhập một ký tự Alphabet(A-Z, a-z) từ bàn phím, nếu ký tự
//không thuộc bảng Alphabet thì thông báo không thuộc bảng chữ cái, nếu ký tự thuộc bảng
//chữ cái thì xác định xem nó là Nguyên âm(A, E, I, O, U, a, e, i, o, u) hay Phụ âm(các chữ cái
//còn lại).
#include <stdio.h>

int main(){
    char ch;
    printf("\nEnter a lower cased alphabet (a - z): ");
    scanf("%c", &ch);
    if (ch < 'a' || ch > 'z'){
        printf("Character not a lower cased alphabet\n");
    }else{
        switch (ch)
        {
        case 'a': case 'e': case 'i': case 'o': case 'u':
            printf("Character is vowel\n");
            break;
        case 'z':
            printf("Last alphabet\n");
            break;
        
        default:
            printf("Character is consonant\n");
            break;
        }
    }
    return 0;
}