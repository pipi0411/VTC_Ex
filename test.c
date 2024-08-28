#include <stdio.h>
#include <string.h>

struct Books
{
    char isbn[15];
    char title[50];
    char author[50];
    float price;
};

// int main(){
//     struct Books book1;
//     struct Books book2;


//     strcpy(book1.isbn, "123456789");
//     strcpy(book1.title, "C Programming");
//     strcpy(book1.author, "Nuha Ali");
//     book1.price = 50000;

//     strcpy(book2.isbn, "987654321");
//     strcpy(book2.title, "Telecom Billing");
//     strcpy(book2.author, "Zara Ali");
//     book2.price = 150000;

//     printf("Book 1 ISBN: %s\n", book1.isbn);
//     printf("Book 1 Title: %s\n", book1.title);
//     printf("Book 1 Author: %s\n", book1.author);
//     printf("Book 1 Price: %.2f\n", book1.price);

//     printf("Book 2 ISBN: %s\n", book2.isbn);
//     printf("Book 2 Title: %s\n", book2.title);
//     printf("Book 2 Author: %s\n", book2.author);
//     printf("Book 2 Price: %.2f\n", book2.price);
//     return 0;
// }



// void printBook(struct Books book);

// int main(){
//     struct Books book1;
//     struct Books book2;


//     strcpy(book1.isbn, "123456789");
//     strcpy(book1.title, "C Programming");
//     strcpy(book1.author, "Nuha Ali");
//     book1.price = 50000;

//     strcpy(book2.isbn, "987654321");
//     strcpy(book2.title, "Telecom Billing");
//     strcpy(book2.author, "Zara Ali");
//     book2.price = 150000;

//     printBook(book1);
//     printBook(book2);

//     return 0;
// }

// void printBook(struct Books book){
//     printf("Book ISBN: %s\n", book.isbn);
//     printf("Book Title: %s\n", book.title);
//     printf("Book Author: %s\n", book.author);
//     printf("Book Price: %.2f\n", book.price);
// }


void printBook(struct Books book);
struct Books getBook();
void getString(char *str, int length);
void printLine();
void printTitle();

int main(){
    struct Books books[3] =
    {
        {"123456789", "The programming", "Nuha Ali", 50000},
        {"987654321", "Telecom Billing", "Zara Ali", 150000}
    };
    int i, count = 3;
    printf("Input book 3:\n");

    printLine();
    return 0;
}

struct Books getBook(){
    struct Books book;
    printf("Enter ISBN: ");
    getString(book.isbn, 14);
    printf("Enter Title: ");
    getString(book.title, 50);
    printf("Enter Author: ");
    getString(book.author, 50);
    printf("Enter Price: ");
    scanf("%f", &book.price);
    return book;
}

void printBook(struct Books book){
    printf("| %-14s | %-26s | %-20s | %6.2f |\n", book.isbn, book.title, book.author, book.price);
}

void printLine(){
    printf("+-%-14s-+-%-26s-+-%-20s-+-%-6s-+\n", "----------------",
    "--------------------------", "--------------------", "------");
}

void printTitle(){
    printLine();
    printf("| %-14s | %-26s | %-20s | %-6s |\n", "isbn", "title", "author", "price");
    printLine();
}

void getString(char *str, int length){
    //clear keyboard buffer on Linux
    fseek(stdin, 0, SEEK_END);
    //clear keyboard buffer on Windows
    fflush(stdin);
    //input string
    fgets(str, length, stdin);
    str[strlen(str)-1] = '\0';
    //clear keyboard buffer on Linux
    fseek(stdin, 0, SEEK_END);
    //clear keyboard buffer on Windows  
    fflush(stdin);

}
