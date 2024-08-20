#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define File_Name "C:/Users/pipi/Documents/File Bank/account-number.dat"

typedef struct {
    char accountName[100];
    char accountNumber[15];
    char pinCode[7];
    float accountBalance;
} Account;

int validateAccountNumber(char *accountNumber){
    return strlen(accountNumber) == 14;
}

int validatePinCode(char *pinCode){
    return strlen(pinCode) == 6;
}

int validateAccountBalance(float accountBalance){
    return accountBalance >= 50000.0;
}

void intputAccountInfo(Account *account){
    printf("Enter account name: ");
    fgets(account->accountName, 100, stdin);
    account->accountName[strcspn(account->accountName, "\n")] = 0;

    do{
        printf("Enter account number (14 digits): ");
        fgets(account->accountNumber, 15, stdin);
        account->accountNumber[strcspn(account->accountNumber, "\n")] = 0;
        if (!validateAccountNumber(account->accountNumber)){
            printf("Invalid account number\n");
        }
    }while(!validateAccountNumber(account->accountNumber));

    getchar();

    do {
        printf("Enter pin code (6 digits): ");
        fgets(account->pinCode, 7, stdin);
        account->pinCode[strcspn(account->pinCode, "\n")] = 0;
        if (!validatePinCode(account->pinCode)){
            printf("Invalid pin code\n");
        }
    }while(!validatePinCode(account->pinCode));

    do {
        printf("Enter account balance (>= 50000): ");
        scanf("%f", &account->accountBalance);
        if (!validateAccountBalance(account->accountBalance)){
            printf("Invalid account balance\n");
        }
    }while(!validateAccountBalance(account->accountBalance));

    printf("Create ATM successfully\n");
    printf("Do you want to create another ATM account (Y/N)? ");
    char choice;
    scanf(" %c", &choice);
    if (choice == 'Y' || choice == 'y'){
        getchar();
        // intputAccountInfo(account);
    }
    else{
        printf("Goodbye\n");
    }
}

void saveAccountInfo(Account *account){
    FILE *file = fopen(File_Name, "a");
    if (file == NULL){
        printf("Cannot open file\n");
        return;
    }
    fprintf(file, "Tên tài khoản: %s\n", account->accountName);
    fprintf(file, "Số tài khoản: %s\n", account->accountNumber);
    fprintf(file, "Mã PIN: %s\n", account->pinCode);
    fprintf(file, "Số dư tài khoản: %.2f VND\n", account->accountBalance);
    fclose(file);
    printf("Đã lưu thông tin tài khoản vào tệp %s\n", File_Name);
}


int main(){
    Account account;
    printf("============================\n");
    printf("VTC ACADEMY BANK\n");
    printf("============================\n");
    printf("Create ATM account\n");
    printf("----------------------------\n");
    intputAccountInfo(&account);
    printf("----------------------------\n");
    saveAccountInfo(&account);
    return 0;
    
}