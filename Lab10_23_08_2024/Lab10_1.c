#include <stdio.h>
#include <string.h>
#include "Lab10_2.c"

int main(){
    char str[100];
    printf("Enter a string: ");
    fgets(str, sizeof(str), stdin);
    char c;
    printf("Enter a character: ");
    scanf("%c", &c);

    int count = 0;
    for(int i = 0; i < strlen(str); i++){
        if(str[i] == c){
            count++;
        }
    }
    printf("So lan xuat hien cua %c la: %d\n", c, count);
    return 0;
}