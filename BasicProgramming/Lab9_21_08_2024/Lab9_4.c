#include <stdio.h>

void display_menu(){
    printf("\n+------------------------+\n");
    printf("|           MENU         |\n");
    printf("+------------------------+\n");
    printf("| 1. Menu 1              |\n");
    printf("| 2. Menu 2              |\n");
    printf("| 3. Menu 3              |\n");
    printf("| 4. Menu 4              |\n");
    printf("| 5. Exit                |\n");
    printf("+------------------------+\n");
    printf("Please choose: ");
}

int get_choice(){
    int choice;
    char c;
    
    while(1){
        if(scanf("%d", &choice) != 1){
            while ((c = getchar()) != '\n' && c != EOF); 
            printf("Entered incorrectly, re-enter: ");
        }else if(choice >= 1 && choice <= 5){
            return choice;
        }else{
            printf("Entered incorrectly, re-enter: ");
        }
    }
}

void process_choice(int choice){
    switch (choice)
    {
    case 1:
        printf("doing menu 1... \n");
        break;
    case 2:
        printf("doing menu 2... \n");
        break;
    case 3:
        printf("doing menu 3... \n");
        break;
    case 4:
        printf("doing menu 4... \n");
        break;
    case 5:
        printf("Exit... \n");
        break;
    default:
        break;
    }
}

int main(){
    int choice;
    do{
        display_menu();
        choice = get_choice();
        process_choice(choice);
    }while(choice != 5);
    return 0;
}