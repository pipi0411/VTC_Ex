#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define MAX_NAME_LENGTH 50
#define MAX_ACCOUNT_NUMBER_LENGTH 15
#define MAX_PIN_LENGTH 7
#define MAX_BALANCE 100000000000
#define FILE_NAME "account-number.dat"

typedef struct {
    char accountName[MAX_NAME_LENGTH];
    char accountNumber[MAX_ACCOUNT_NUMBER_LENGTH];
    char pinCode[MAX_PIN_LENGTH];
    long int accBalance;
} Account;

void deleInput()
{
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

void loadAccount(Account *acc, const char *filename){
    FILE *file = fopen(filename, "r");
    if (!file) {
        printf("Could not open file %s\n", filename);
        exit(1);
    }
    fgets(acc->accountName, MAX_NAME_LENGTH, file);
    acc->accountName[strcspn(acc->accountName, "\n")] = '\0';
    fgets(acc->accountNumber, MAX_ACCOUNT_NUMBER_LENGTH, file);
    acc->accountNumber[strcspn(acc->accountNumber, "\n")] = '\0';
    fgets(acc->pinCode, MAX_PIN_LENGTH, file);
    acc->pinCode[strcspn(acc->pinCode, "\n")] = '\0';
    fscanf(file, "%ld", &acc->accBalance);
    fclose(file);
}
