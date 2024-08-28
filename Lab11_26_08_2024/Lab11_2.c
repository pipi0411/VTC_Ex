#include <stdio.h>
#include <string.h>

typedef struct product{
    char name[80];
    char amount[5];
    float price;
} Product;


int main(){
    for(int i = 0; i < 5; i++){
        Product p;
        printf("Product name: ");
        fgets(p.name, 80, stdin);
        p.name[strcspn(p.name, "\n")] = '\0';
        printf("Amount: ");
        fgets(p.amount, 5, stdin);
        p.amount[strcspn(p.amount, "\n")] = '\0';
        printf("Price: ");
        scanf("%f", &p.price);
        char ch;
        while((ch = getchar()) != '\n' && ch != EOF);
   
    }
    printf("DANH MUC SAN PHAM\n");

    return 0;
}
