#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>


#define MAX_NAME_LENGTH 50
#define MAX_ACCOUNT_NUMBER_LENGTH 15
#define MAX_PIN_LENGTH 7
#define MAX_BALANCE 100000000000
#define FILE_NAME "account-number.dat"
#ifdef _WIN32
      #include <direct.h>
      #define MKDIR(dir) _mkdir(dir)
#else
        #include <sys/stat.h>
        #include <sys/types.h>
        #define MKDIR(dir) mkdir(dir, 0777)
#endif

typedef struct Account{
    char accountName[MAX_NAME_LENGTH];
    char accountNumber[MAX_ACCOUNT_NUMBER_LENGTH];
    char pinCode[MAX_PIN_LENGTH];
    long int accBalance;
} Account;

Account *accList;
size_t accListSize = 0;

void init_accList() {
    accList = (Account *)malloc(sizeof(Account));

    FILE *file = fopen(FILE_NAME, "r");

    while(!feof(file)) {
        accList = (Account *)realloc(accList, (accListSize + 1) * sizeof(Account));
        fgets(accList[accListSize].accountName, MAX_NAME_LENGTH, file);
        accList[accListSize].accountName[strcspn(accList[accListSize].accountName, "\n")] = '\0';

        fgets(accList[accListSize].accountNumber, MAX_ACCOUNT_NUMBER_LENGTH + 1, file);
        accList[accListSize].accountNumber[strcspn(accList[accListSize].accountNumber, "\n")] = '\0';

        fgets(accList[accListSize].pinCode, MAX_PIN_LENGTH + 1, file);
        accList[accListSize].pinCode[strcspn(accList[accListSize].pinCode, "\n")] = '\0';

        fscanf(file, "%ld\n", &accList[accListSize].accBalance);
        
        accListSize++;
    }

    fclose(file);
}

void deleteInput(){
    int ch;
    while((ch = getchar()) != '\n' && ch != EOF);
}


void displayMenu(){
    printf("==================================\n");
    printf("\tVTC Academy Bank\n");
    printf("==================================\n");
    printf("\t1. Check account balance\n");
    printf("\t2. Withdraw cash\n");
    printf("\t3. Transfer money\n");
    printf("\t4. Change PIN\n");
    printf("\t5. Exit\n");
    printf("==================================\n");
    printf("Please choice: ");
}

void printAcc(Account *acc) {
    printf("Account Loaded:\n");
    printf("Name: %s\n", acc->accountName);
    printf("Number: %s\n", acc->accountNumber);
    printf("PIN: %s\n", acc->pinCode);
    printf("Balance: %lld\n", acc->accBalance);
}

int validateAccount(Account *acc, const char *accountNumber, const char *pinCode){
    return strcmp(acc->accountNumber, accountNumber) == 0 && strcmp(acc->pinCode, pinCode) == 0;
}

void checkBalance(Account *acc) {
    printf("Your current balance is: %ld VND\n", acc->accBalance);
}

void withdrawCash(Account *acc) {
    long int amount;
    printf("Enter the amount you want to withdraw: ");
    scanf("%ld", &amount);
    deleteInput();
    if (amount > 0 && amount <= acc->accBalance) {
        acc->accBalance -= amount;
       printf("Withdrawal successful! New balance: %ld VND\n", acc->accBalance);
    } else {
        printf("Invalid amount or insufficient balance!\n");
    }
}

void transferMoney(Account *acc){
    char destinationAccount[MAX_ACCOUNT_NUMBER_LENGTH];
    long int amount;
    printf("Enter destination account number: ");
    fgets(destinationAccount, MAX_ACCOUNT_NUMBER_LENGTH, stdin);
    destinationAccount[strcspn(destinationAccount, "\n")] = '\0';
    printf("Enter the amount you want to transfer: ");
    scanf("%ld", &amount);
    deleteInput();
    if (amount > 0 && amount <= acc->accBalance) {
        acc->accBalance -= amount;
        printf("Transfer successful! New balance: %ld VND\n", acc->accBalance);
    } else {
        printf("Invalid amount or insufficient balance!\n");
    }
}

void changePin(Account *acc){
    char newPin[MAX_PIN_LENGTH];
    printf("Enter new PIN(6 digits): ");
    fgets(newPin, MAX_PIN_LENGTH, stdin);
    newPin[strcspn(newPin, "\n")] = '\0';
    if (strlen(newPin) == 6 && strspn(newPin, "0123456789") == 6) {
        strcpy(acc->pinCode, newPin);
        printf("Change PIN successful!\n");
    } else {
        printf("Invalid PIN!\n");
    }
}

void saveAccountToFile(Account *acc, const char *filename){
    FILE *file = fopen(filename, "w");
    if (!file) {
        printf("Could not open file %s\n", filename);
        exit(1);
    }
    fprintf(file, "%s\n%s\n%s\n%ld\n", acc->accountName, acc->accountNumber, acc->pinCode, acc->accBalance);
    fclose(file);
}

void loginATM(){
    init_accList();
    int acc_index = -1;

    char accountNumber[MAX_ACCOUNT_NUMBER_LENGTH + 1];
    char pinCode[MAX_PIN_LENGTH + 1];
    char buffer[100];

   

    while(1) {
        printf("Enter account number: ");
        fgets(buffer, 99, stdin);
        buffer[strcspn(buffer, "\n")] = '\0';
        
        sprintf(accountNumber, "%s", buffer);
        accountNumber[MAX_ACCOUNT_NUMBER_LENGTH] = '\0';
       

        int valid_acc = 0;
        for(int i = 0; i < accListSize; i++) {
            if(strcmp(accountNumber, accList[i].accountNumber) == 0) valid_acc = 1;
        }

        if(valid_acc) break;
        else {
            printf("Invalid account number! Do you want to try again? (Y/N): ");
            char c;
            scanf("%c", &c);
            deleteInput();

            if(c == 'N' || c == 'n') return;
        }
    }

    while (1)
    {
        printf("Enter PIN: ");
        fgets(buffer, 99, stdin);
        buffer[strcspn(buffer, "\n")] = '\0';

        sprintf(pinCode, "%s", buffer);
        pinCode[MAX_PIN_LENGTH] = '\0';


        int valid_pin = 0;
        for(int i = 0; i < accListSize; i++) {
            if(strcmp(pinCode, accList[i].pinCode) == 0) {
                valid_pin = 1;
                acc_index = i;
            }
        }

        if(valid_pin) break;
        else {
            printf("Invalid PIN! Do you want to try again? (Y/N): ");
            char c;
            scanf("%c", &c);
            deleteInput();

            if(c == 'N' || c == 'n') return;
        }
    }

    
    printf("Login successful!\n");

    while(1) {
        getchar();
        break;
    }

    // int choice;
    // do{
    //     displayMenu();
    //     scanf("%d", &choice);
    //     deleteInput();
    //     switch (choice)
    //     {
    //         case 1:
    //         checkBalance(&acc);
    //         break;
    //         case 2:
    //         withdrawCash(&acc);
    //         break;
    //         case 3:
    //         transferMoney(&acc);
    //         break;
    //         case 4:
    //         changePin(&acc);
    //         break;
    //         case 5:
    //         printf("Exiting...\n");
    //         break;
    //         default:
    //         printf("Invalid choice! Please try again.\n");
    //         break;
    //     }
    // }
    // while(choice != 5);
    // saveAccountToFile(&acc, FILE_NAME);
}