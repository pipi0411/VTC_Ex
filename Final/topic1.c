#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#ifdef _WIN32
      #include <direct.h>
      #define MKDIR(dir) _mkdir(dir)
#else
        #include <sys/stat.h>
        #include <sys/types.h>
        #define MKDIR(dir) mkdir(dir, 0777)
#endif


#define MAX_NUM 14
#define MAX_PIN 6
int isValidAccountNumber(char *accountNumber){
    return strlen(accountNumber) == 14 && strspn(accountNumber,"0123456789") ==14;
}
void toUpperCase(char *str){
    for (int i = 0; i < strlen(str); i++) {
        str[i] = toupper(str[i]);
    }
}

int isValidPinCode(char *pinCode){
    return strlen(pinCode) == 6 && strspn(pinCode,"0123456789") == 6;
}
void deleInput()
{
    int ch;
    while((ch = getchar()) != '\n' && ch != EOF);
}

int isValidAccountName(char *accountName)
{
    for (int i = 0; i < strlen(accountName); i++) {
        if (!isalpha(accountName[i]) && !isspace(accountName[i])) {
            return 0;
        }
    }
    return 1;
}

int isDuplicateAccount(char *accountNumber){
    FILE *file = fopen("account-number.dat", "r");
    if (file == NULL)
    {
        return 0;
    }
    char line[256];
    while (fgets(line, sizeof(line), file))
    {
        if(strstr(line, "So tai khoan") && strstr(line, accountNumber))
        {
            fclose(file);
            return 1;

        }
    }
    fclose(file);
    return 0;
}


void saveToFile(char *accountName, char *accountNumber, char *pinCode, long int accBalance)
{
    FILE *file = fopen("account-number.dat", "a");
    if (file == NULL)
    {
        printf("Cannot open file!\n");
        return;
    }
    fprintf(file, "%s\n", accountName);
    fprintf(file, "%s\n", accountNumber);
    fprintf(file, "%s\n", pinCode);
    fprintf(file, "%ld\n", accBalance);
    fclose(file);
    printf("Đa luu thong tin tai khoan vao file account-number.dat\n");
}


void created_ATM()
{
    char accountName[50];
    char accountNumber[MAX_NUM+2];
    char pinCode[MAX_PIN+2];
    long int accBalance;
    char saveChoice;

    printf("==================================\n");
    printf("\tVTC Academy Bank\n");
    printf("==================================\n");
    printf("\tCreate ATM Cards\n");
    printf("----------------------------------\n");

    printf("Input Account Name: ");
    do {
        fgets(accountName, sizeof(accountName), stdin);
        accountName[strcspn(accountName, "\n")] = '\0';
        toUpperCase(accountName);
        if (!isValidAccountName(accountName)) {
            printf("Invalid account name, re-enter: ");
        }
    } while (!isValidAccountName(accountName));

    printf("Input Account No(14 digital): ");
do
{
    fgets(accountNumber, sizeof(accountNumber), stdin);
    if (strlen(accountNumber) > MAX_NUM && accountNumber[MAX_NUM] != '\n')
    {
        deleInput(0);
        printf("Invalid account number, re-enter: ");
        continue;
    } 
    accountNumber[strcspn(accountNumber, "\n")] = '\0';
    if (!isValidAccountNumber(accountNumber))
    {
        printf("Invalid account number, re-enter: ");
    }
    if (isDuplicateAccount(accountNumber))
    {
        printf("Account number is duplicated, re-enter: ");
        deleInput(0);
    }
} while (!isValidAccountNumber(accountNumber));

printf("Input Code(6 number): ");
do
{
    fgets(pinCode, sizeof(pinCode), stdin);
    if (strlen(pinCode) > MAX_PIN && pinCode[MAX_PIN] != '\n')
    {
        deleInput(0);
        printf("Invalid Pin code, re-enter:");
        continue;
    }
    pinCode[strcspn(pinCode, "\n")] = '\0';
    if (!isValidPinCode(pinCode))
    {
        printf("Invalid Pin code, re-enter:");
    }
} while (!isValidPinCode(pinCode));

do
{
    printf("Input balance (>50000): ");
    scanf("%ld", &accBalance);
} while (accBalance < 50000);

printf("----------------------------------\n");
printf("Create ATM successfully\n");
printf("Do you want to create another ATM account (Y/N)? ");
deleInput(0);
saveChoice = getchar();
if ( saveChoice == 'Y' || saveChoice == 'y')
  {
    saveToFile(accountName, accountNumber, pinCode, accBalance);
  }else
  {
    printf("Goodbye\n");
  }
}