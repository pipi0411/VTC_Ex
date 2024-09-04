#include <stdio.h>
#include "topic1.c"
#include "topic2.c"

void display_menu(){
    printf("==================================\n");
    printf("\tVTC Academy Bank\n");
    printf("==================================\n");
    printf("\t      ATM        \n");
    printf("----------------------------------\n");
    printf("1. Create new ATM card\n");
    printf("2. Login ATM\n");
    printf("3. Exit\n");
    printf("==================================\n");
    printf("Please choose: ");
}

int get_choice(){
    int choice;
    char c;
    
    while(1){
        if(scanf("%d", &choice) != 1){
            while ((c = getchar()) != '\n' && c != EOF); 
            printf("Entered incorrectly, re-enter: ");
        }else if(choice >= 1 && choice <= 3){
            deleInput();
            return choice;
        }else{
            printf("Entered incorrectly, re-enter: ");
        }
    }
    
}


int main(){
    int choice;
    do{
        display_menu();
        choice = get_choice();
        switch(choice){
            case 1:
                created_ATM();
                break;
            case 2:
                loginATM();
                break;
            case 3:
                break;
        }
    }while(choice != 3);
    return 0;
}