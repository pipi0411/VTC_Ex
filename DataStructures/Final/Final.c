#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Khai báo cấu trúc điện thoại di động
typedef struct MobilePhone{
    int mobile_id;
    char name[50];
    char brand[50];
    int price;
    struct MobilePhone *next;
} MobilePhone;

// Hàm lưu thông tin điện thoại di động vào file
void saveMobilePhone(MobilePhone *head){
    FILE *f = fopen("mobilephone.txt", "w");
    if(f == NULL){
        printf("Error opening file\n");
        return;
    }
    MobilePhone* temp = head;
    while(temp != NULL){
        fprintf(f, "%d %s %s %d\n", temp->mobile_id, temp->name, temp->brand, temp->price);
        temp = temp->next;
    }
    fclose(f);
    printf("Mobile phone saved successfully.\n");
}

// Hàm thêm điện thoại di động vào danh sách
void addMobilePhone(MobilePhone **head, int id, char name[], char brand[], int price){
    MobilePhone *newMobile = (MobilePhone *)malloc(sizeof(MobilePhone)); // Cấp phát bộ nhớ cho điện thoại mới
    newMobile->mobile_id = id; // Gán giá trị id cho điện thoại mới
    strcpy(newMobile->name, name); // Gán giá trị name cho điện thoại mới
    strcpy(newMobile->brand, brand); // Gán giá trị brand cho điện thoại mới
    newMobile->price = price; // Gán giá trị price cho điện thoại mới
    newMobile->next = NULL; // Gán giá trị next cho điện thoại mới
    if(*head == NULL){ // Nếu danh sách rỗng
        *head = newMobile; // Gán giá trị head cho điện thoại mới
    }else{
        MobilePhone *temp = *head; // Khai báo biến tạm và gán giá trị head cho biến tạm
        while(temp->next != NULL){ // Duyệt từ đầu đến cuối danh sách
            temp = temp->next; // Cập nhật giá trị temp 
        }
        temp->next = newMobile; // Gán giá trị next của temp cho điện thoại mới
    }
    saveMobilePhone(*head); // Lưu thông tin điện thoại di động vào file
    printf("Mobile phone added successfully.\n");
}

// Hàm xóa điện thoại di động khỏi danh sách
void deleteMobilePhone(MobilePhone **head, int id){
    MobilePhone *temp = *head; // Khai báo biến tạm và gán giá trị head cho biến tạm
    MobilePhone *prev = NULL; // Khai báo biến prev và gán giá trị NULL
    if(temp != NULL && temp->mobile_id == id){ // Nếu điện thoại cần xóa ở đầu danh sách
        *head = temp->next; // Cập nhật giá trị head
        free(temp); // Giải phóng bộ nhớ
        return;
    }
    while(temp != NULL && temp->mobile_id != id){ // Duyệt danh sách
        prev = temp; // Cập nhật giá trị prev
        temp = temp->next; // Cập nhật giá trị temp
    }
    if(temp == NULL){ // Nếu không tìm thấy điện thoại cần xóa
        printf("Mobile phone with ID %d not found.\n", id);
        return;
    }
    printf("Mobile phone with ID %d deleted successfully.\n", id);
    prev->next = temp->next; // Cập nhật giá trị next của prev
    free(temp); // Giải phóng bộ nhớ của temp
    saveMobilePhone(*head); // Lưu thông tin điện thoại di động vào file
}

// Hàm cập nhật thông tin điện thoại di động
void updateMobile(MobilePhone **head, int id, char name[], char brand[], int price) {
    MobilePhone *temp = *head; // Khai báo biến tạm và gán giá trị head cho biến tạm
    while(temp != NULL && temp->mobile_id != id){ // Duyệt danh sách
        temp = temp->next; // Cập nhật giá trị temp
    }
    if(temp == NULL){ // Nếu không tìm thấy điện thoại cần cập nhật
        printf("Mobile phone with ID %d not found.\n", id);
        return;
    }
    temp->mobile_id = id; // Cập nhật giá trị id
    strcpy(temp->name, name);  // Cập nhật giá trị name
    strcpy(temp->brand, brand); // Cập nhật giá trị brand
    temp->price = price; // Cập nhật giá trị price
    saveMobilePhone(*head); // Lưu thông tin điện thoại di động vào file
    printf("Mobile phone with ID %d updated successfully.\n", id);
}

// Hàm hiển thị thông tin của điện thoại di động
void displayMobile(MobilePhone *head){
    MobilePhone* temp = head;
    if (temp == NULL) {
        printf("No mobile phones in the list.\n");
        return;
    }
    
    while (temp != NULL) {
        printf("%d - %s - %s - %d\n", temp->mobile_id, temp->name, temp->brand, temp->price);
        temp = temp->next;
    }
}

void shopMenu(MobilePhone **head);
void deleteInput(){
    char c;
    while((c = getchar()) != '\n' && c != EOF);
}

void shopMenu(MobilePhone **head){
    int choice;
    do{
        printf("-----------Mobile Phone Shop-----------\n");
        printf("=======================================\n");
        printf("Shop reports\n");
        printf("1. Display all mobile phones\n");
        printf("2. Display top 5 hightest price mobile phone\n");
        printf("3. Back to main menu\n");
        printf("=======================================\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);
        deleteInput();
        switch(choice){
            case 1:
                //Display all mobile phones
                displayMobile(*head);
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
    int n ,id;
    MobilePhone* head = NULL;
    char name[50], brand[50];
    int price;
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
        printf("Enter mobile phone ID: ");
        scanf("%d", &id);
        deleteInput();
        printf("Enter mobile phone name: ");
        scanf("%[^\n]", name);
        deleteInput();
        printf("Enter mobile phone brand: ");
        scanf("%[^\n]", brand);
        deleteInput();
        printf("Enter mobile phone price: ");
        scanf("%d", &price);
        deleteInput();
        addMobilePhone(&head, id, name, brand, price);
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
        shopMenu(&head);
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