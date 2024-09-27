#include <stdio.h>
#include <string.h>

#define MAX_PRODUCTS 5
#define MAX_NAME_LENGTH 50


typedef struct {
    char name[MAX_NAME_LENGTH];
    int quantity;
    int price;
    int total;
} Product;

int main() {
    Product products[MAX_PRODUCTS];
    int grandTotal = 0;

    for (int i = 0; i < MAX_PRODUCTS; i++) {
        printf("Nhap thong tin cho san pham thu %d:\n", i + 1);

        printf("Ten san pham: ");
        fgets(products[i].name, MAX_NAME_LENGTH, stdin);
        products[i].name[strcspn(products[i].name, "\n")] = 0;

        printf("So luong: ");
        scanf("%d", &products[i].quantity);

        printf("Don gia: ");
        scanf("%d", &products[i].price);

        products[i].total = products[i].quantity * products[i].price;
        grandTotal += products[i].total;


        while (getchar() != '\n');
    }

    printf("\nDANH MUC SAN PHAM\n");
    printf("%-5s%-20s%-10s%-10s%-10s\n", "STT", "Ten san pham", "So luong", "Don gia", "Tong tien");

    for (int i = 0; i < MAX_PRODUCTS; i++) {
        printf("%-5d%-20s%-10d%-10d%-10d\n", i + 1, products[i].name, products[i].quantity, products[i].price, products[i].total);
    }

    printf("Tong cong: %d\n", grandTotal);

    return 0;
}
