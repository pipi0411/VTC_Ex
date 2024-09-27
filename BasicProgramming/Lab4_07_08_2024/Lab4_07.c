//Thông báo ra màn hình môn học tương ứng với lựa chọn(chọn 1-6 từ bàn phím), nếu người
//dùng nhập khác 1-6 thì thông báo chọn sai.
#include <stdio.h>

int main(){
    printf("         Menu\n");
    printf("====================\n");
    printf("1. CF\n");
    printf("2. C\n");
    printf("3. HDJ\n");
    printf("4. DreamWeaver\n");
    printf("5. RDBMS\n");
    printf("6. Learn Java By Example\n");
    printf("====================\n");
    char n;
    printf("Chon mon hoc tuong ung (1-6): ");
    scanf("%c", &n);
    switch (n)
    {
    case 1:
        printf("Ban chon CF\n");
        break;
    case 2:
        printf("Ban chon C\n");
        break;
    case 3:
        printf("Ban chon HDJ\n");
        break;
    case 4:
        printf("Ban chon DreamWeaver\n");
        break;
    case 5:
        printf("Ban chon RDBMS\n");
        break;
    case 6:
        printf("Ban chon Learn Java By Example\n");
        break;
    default:        
        printf("Chon sai\n");
        break;
    }
    return 0;
}