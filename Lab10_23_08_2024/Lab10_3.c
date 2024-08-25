#include <stdio.h>
#include <string.h>
#include <ctype.h>

int main(){
    char str[81];
    printf("Enter a string (max 80 characters): ");
    fgets(str, sizeof(str), stdin);

    if(str[strlen(str) - 1] == '\n'){
        str[strlen(str) - 1] = '\0';
    }
    int len = strlen(str);
    int vowel_count = 0;
    int word_count = 0;
    int char_count = 0;
    int in_word = 0;

    for(int i = 0; i < len; i++){
        char current_char = str[i];

        if(isalpha(current_char)){
            char_count++;
            current_char = tolower(current_char);
            if(current_char == 'a' || current_char == 'e' || current_char == 'i' || current_char == 'o' || current_char == 'u'){
                vowel_count++;
            }
        }

        if(isalpha(current_char)){
            if(in_word){
                word_count++;
                in_word = 0;
            }
        }else{
            in_word = 1;
        }
    }
    if(in_word){
        word_count++;
    }

    int i = 0, j = 0;
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

    // Tính tỷ lệ nguyên âm
    float vowel_percentage = (float)vowel_count / char_count * 100;

    // In ra các thông tin thống kê
    printf("Number of characters: %d\n", char_count);
    printf("Number of vowels: %d\n", vowel_count);
    printf("Percentage of vowels: %.2f%%\n", vowel_percentage);
    printf("Number of words: %d\n", word_count);
    printf("Normalized string: %s\n", str);

    return 0;
}