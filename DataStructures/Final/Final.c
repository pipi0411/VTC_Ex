#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void shopMenu();
void deleteInput(){
    char c;
    while((c = getchar()) != '\n' && c != EOF);
}

void shopMenu(){
    printf("-----------Mobile Phone Shop-----------\n");
    printf("=======================================\n");
    printf("Shop reports\n");
    printf("1. Display all mobile phones\n");
    printf("2. Display top 5 hightest price mobile phone\n");
    printf("3. Back to main menu\n");
    printf("=======================================\n");
    int choice;
    printf("Enter your choice: ");
    scanf("%d", &choice);
    deleteInput();

    do{
        switch(choice){
            case 1:
                //Display all mobile phones
                break;
            case 2:
                //Display top 5 hightest price mobile phone
                break;
            case 3:
                break;
            default:
                printf("Invalid choice\n");
                break;
        }

    }while(choice != 3);
}

int main(){
    int n;
    do{
    printf("-----------Mobile Phone Shop-----------\n");
    printf("=======================================\n");
    printf("1. Add mobile phone\n");
    printf("2. Search mobile phone\n");
    printf("3. Update mobile phone\n");
    printf("4. Delete mobile phone\n");
    printf("5. Shop reports\n");
    printf("6. Exit\n");
    printf("=======================================\n");
    printf("Enter your choice: ");
    scanf(" %d", &n);
    deleteInput();

        switch (n)
    {
    case 1:
        //Add mobile phone
        break;
    case 2:
        //Search mobile phone
        break;
    case 3:
        //Update mobile phone
        break;
    case 4:
        //Delete mobile phone
        break;
    case 5:
        shopMenu();
        break;
    case 6:
        printf("Goodbye\n");
        break;
    default:
        printf("Invalid choice\n");
        break;
    }
    } while (n != 6);
    return 0;
}