#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#include <time.h>


#define MAX_NAME_LENGTH 50
#define MAX_ACCOUNT_NUMBER_LENGTH 15
#define MAX_PIN_LENGTH 7
#define MAX_BALANCE 100000000000
#define FILE_NAME "account-number.dat"
#define TRANSACTION_FEE 1000
#define VAT_PERCENTAGE 100
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

void checkBalance(Account *acc) {
    printf("Your current balance is: %ld VND\n", acc->accBalance);
}

char *maskAccountNumber(char *accountNumber){
    static char maskedAccount[20];
    int length = strlen(accountNumber);
    if (length < 8){
        return accountNumber;
    }
    strncpy(maskedAccount, accountNumber, 4);
    maskedAccount[4] = '\0';

    strcat(maskedAccount, "********");

    strcat(maskedAccount, accountNumber + length - 4);
    return maskedAccount;
}


void withdrawCash(Account *acc) {
    int choice;
    long int amount = 0;

    do {
        printf("==================================\n");
        printf("\tVTC Academy Bank\n");
        printf("==================================\n");
        printf("ATM Machine - Withdraw\n");
        printf("1. 100.000 VND\n");
        printf("2. 200.000 VND\n");
        printf("3. 500.000 VND\n");
        printf("4. 1.000.000 VND\n");
        printf("5. 2.000.000 VND\n");
        printf("6. Other amount\n");
        printf("7. Exit\n");
        printf("----------------------------------\n");
        printf("Your choice: ");
        scanf("%d", &choice);
        deleteInput(); 

        switch (choice) {
            case 1:
                amount = 100000;
                break;
            case 2:
                amount = 200000;
                break;
            case 3:
                amount = 500000;
                break;
            case 4:
                amount = 1000000;
                break;
            case 5:
                amount = 2000000;
                break;
            case 6:
                printf("Enter the amount you want to withdraw: ");
                scanf("%ld", &amount);
                deleteInput();
                break;
            case 7:
                return;
            default:
                printf("Invalid choice! Please try again.\n");
                continue;
        }

        if (choice == 6 && amount <= 0) {
            printf("Invalid amount entered! Please enter a positive amount.\n");
            continue;
        }

        long int fee = TRANSACTION_FEE;
        long int vat = VAT_PERCENTAGE;
        long int total = amount + fee + vat;

        if (total > 0 && total <= acc->accBalance) {
            acc->accBalance -= total;
            printf("Withdrawal successful! New balance: %ld VND\n", acc->accBalance);

            char printReceipt;
            printf("Do you want to print a receipt? (Y/N): ");
            scanf(" %c", &printReceipt);
            deleteInput();

            if (printReceipt == 'Y' || printReceipt == 'y') {
                srand(time(NULL));
                int transactionId = rand() % 1000000000;

                time_t now;
                struct tm *timeInfo;
                char buffer[80];
                time(&now);
                timeInfo = localtime(&now);

                strftime(buffer, sizeof(buffer), "%d/%m/%Y %H:%M:%S", timeInfo);

                printf("==================================\n");
                printf("\tVTC Academy Bank\n");
                printf("==================================\n");
                printf("BIEN LAI RUT TIEN TAI ATM\n");
                printf("Ngay gio: %s\n", buffer);
                printf("So the: %s\n", maskAccountNumber(acc->accountNumber));
                printf("Ten tai khoan: %s\n", acc->accountName);
                printf("So giao dich: %09d\n", transactionId);
                printf("So tien: %ld VND\n", amount);
                printf("Noi dung: Rut tien mat tai ATM\n");
                printf("----------------------------------\n"); 
                printf("So du: %ld VND\n", acc->accBalance);
                printf("Le phi: %ld VND\n", fee);
                printf("VAT: %ld VND\n", vat);  
                printf("----------------------------------\n");
                printf("Cam on quy khach da su dung dich vu cua chung toi!\n");
            }
        } else {
            printf("Invalid amount or insufficient balance!\n");
        }

    } while (choice != 7); 
}

void transferMoney(Account *acc){
    char destinationAccount[MAX_ACCOUNT_NUMBER_LENGTH];
    long int amount;
    printf("Enter destination account number: ");
    fgets(destinationAccount, MAX_ACCOUNT_NUMBER_LENGTH, stdin);
    destinationAccount[strcspn(destinationAccount, "\n")] = '\0';\
    deleteInput();
    char *maskedAccount = maskAccountNumber(destinationAccount);

    printf("Enter the amount you want to transfer: ");
    scanf("%ld", &amount);
    deleteInput();

    long int fee = TRANSACTION_FEE;
    long int vat = VAT_PERCENTAGE;
    long int total = amount + fee + vat;

    if ( total > 0 && total <= acc->accBalance) {
        acc->accBalance -= total;
        printf("Transfer successful! New balance: %ld VND\n", acc->accBalance);
        
        char printReceipt;
        printf("Do you want to print a receipt? (Y/N): ");
        scanf(" %c", &printReceipt);
        deleteInput();

        if (printReceipt == 'Y' || printReceipt == 'y') {
            srand(time(NULL));
            int transactionId = rand() % 1000000000;

            time_t now;
            struct tm *timeInfo;
            char buffer[80];
            time(&now);
            timeInfo = localtime(&now);

            strftime(buffer, sizeof(buffer), "%d/%m/%Y %H:%M:%S", timeInfo);

            printf("==================================\n");
            printf("\tVTC Academy Bank\n");
            printf("==================================\n");
            printf("BIEN LAI CHUYEN TIEN TAI ATM\n");
            printf("Ngay gio: %s\n", buffer);
            printf("Tu so the: %s\n", maskAccountNumber(acc->accountNumber));
            printf("Den so the: %s\n", maskAccountNumber(destinationAccount));
            printf("So giao dich: %09d\n", transactionId);
            printf("So tien: %ld VND\n", amount);
            printf("Noi dung: CHUYEN TIEN 24H\n");
            printf("----------------------------------\n"); 
            printf("So du: %ld VND\n", acc->accBalance);
            printf("Le phi: %ld VND\n", fee);
            printf("VAT: %ld VND\n", vat);  
            printf("----------------------------------\n");
            printf("Cam on quy khach da su dung dich vu cua chung toi!\n");
        }
    } else {
        printf("Invalid amount or insufficient balance!\n");
    }
}

void changePin(Account *acc) {
    char currentPin[MAX_PIN_LENGTH];
    char newPin[MAX_PIN_LENGTH];
    char confirmPin[MAX_PIN_LENGTH];

    // Ask for the current PIN
    printf("Enter current PIN: ");
    fgets(currentPin, MAX_PIN_LENGTH, stdin);
    currentPin[strcspn(currentPin, "\n")] = '\0';

    // Validate the current PIN
    if (strcmp(currentPin, acc->pinCode) != 0) {
        printf("Invalid current PIN!\n");
        return;
    }
    deleteInput();

    // Prompt for the new PIN
    printf("Enter new PIN (6 digits): ");
    fgets(newPin, MAX_PIN_LENGTH, stdin);
    newPin[strcspn(newPin, "\n")] = '\0';
    deleteInput();

    // Check if the new PIN is valid
    if (strlen(newPin) != 6 || strspn(newPin, "0123456789") != 6) {
        printf("Invalid PIN format! Please enter exactly 6 digits.\n");
        return;
    }

    // Prompt for confirmation of the new PIN
    printf("Confirm new PIN: ");
    fgets(confirmPin, MAX_PIN_LENGTH, stdin);
    confirmPin[strcspn(confirmPin, "\n")] = '\0';
    deleteInput();

    // Check if the confirmation matches the new PIN
    if (strcmp(newPin, confirmPin) != 0) {
        printf("PIN confirmation does not match. Please try again.\n");
        return;
    }

    // If everything is valid, update the PIN
    strcpy(acc->pinCode, newPin);
    printf("Change PIN successful!\n");
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
        strcpy(accountNumber, buffer);

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

    int choice;
    do{
        displayMenu();
        scanf("%d", &choice);
        deleteInput();
        switch (choice)
        {
            case 1:
            checkBalance(&accList[acc_index]);
            break;
            case 2:
            withdrawCash(&accList[acc_index]);
            saveAccountToFile(&accList[acc_index], FILE_NAME);
            break;
            case 3:
            transferMoney(&accList[acc_index]);
            saveAccountToFile(&accList[acc_index], FILE_NAME);
            break;
            case 4:
            changePin(&accList[acc_index]);
            saveAccountToFile(&accList[acc_index], FILE_NAME);
            break;
            case 5:
            printf("Exiting...\n");
            break;
            default:
            printf("Invalid choice! Please try again.\n");
            break;
        }
    }
    while(choice != 5);
    // saveAccountToFile(&accList[acc_index], FILE_NAME);
}