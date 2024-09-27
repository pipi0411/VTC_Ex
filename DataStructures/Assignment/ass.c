// Xây dựng một chương trình quản lý sách trong thư viện sử dụng các cấu trúc dữ liệu cơ bản như: mảng, danh sách liên kết, stack và queue.:

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define MAX 10
#define MAX_BOOK 3

//Khởi tạo mảng tĩnh chứa danh sách 10 cuốn sách
struct Book{
    char id_book[5];
    char name[50];
    char author[50];
    int year;
};
// Hàm danh sách liên kết đơn quản lý danh sách mượn sách của người dùng
typedef struct User{
    char id_user[5];
    char name[50];
    char borrowed_book[MAX_BOOK][5];
    struct User *next;
} User;

void deleteInput(){
    char c;
    while((c = getchar()) != '\n' && c != EOF);
}

// Hàm tạo cuốn sách tĩnh
void createdBook(struct Book books[MAX]){
    struct Book tempBooks[MAX] = {
        {"B001", "The Great Gatsby", "F. Scott Fitzgerald", 1925},
        {"B002", "To Kill a Mockingbird", "Harper Lee", 1960},
        {"B003", "1984", "George Orwell", 1949},
        {"B004", "Pride and Prejudice", "Jane Austen", 1813},
        {"B005", "The Catcher in the Rye", "J.D. Salinger", 1951},
        {"B006", "Moby Dick", "Herman Melville", 1851},
        {"B007", "War and Peace", "Leo Tolstoy", 1869},
        {"B008", "The Odyssey", "Homer", -800},
        {"B009", "Crime and Punishment", "Fyodor Dostoevsky", 1866},
        {"B010", "Brave New World", "Aldous Huxley", 1932}
    };
    // copy tempBooks vào books
    for(int i = 0; i < MAX; i++){
        books[i] = tempBooks[i]; 
    }
    printf("+-------+---------------------------+-----------------------+--------------+\n"); 
    printf("|  ID   |          Name             |        Author         | Publish Year |\n");
    printf("+-------+---------------------------+-----------------------+--------------+\n");
    
    for(int i = 0; i < MAX; i++){
        printf("| %-5s | %-25s | %-21s | %-12d |\n",
        books[i].id_book, books[i].name, books[i].author, books[i].year); 
    }
    printf("+-------+---------------------------+-----------------------+--------------+\n");
}

// Hàm tìm kiếm sách theo mã sách
void searchBook(struct Book books[], int n, char id_book[]){  //Hàm tìm kiếm sách theo mã sách trong danh sách sách books có n cuốn sách và mã sách id_book
    int flag = 0; //Biến kiểm tra sách có tồn tại hay không
    for(int i = 0; i < n; i++){  //Duyệt qua từ đầu đến cuối danh sách sách để tìm kiếm
        if( 
            strcmp(books[i].id_book, id_book) == 0
        ){ // Nếu tìm thấy sách thì in ra thông tin sách và kết thúc hàm
            printf("+-------+---------------------------+-----------------------+--------------+\n"); 
            printf("|  ID   |          Name             |        Author         | Publish Year |\n");
            printf("+-------+---------------------------+-----------------------+--------------+\n");
            printf("| %-5s | %-25s | %-21s | %-12d |\n",
            books[i].id_book, books[i].name, books[i].author, books[i].year); 
            printf("+-------+---------------------------+-----------------------+--------------+\n");
            flag = 1;
            break;
        }
    }
    if(flag == 0){ //Nếu không tìm thấy sách thì in ra thông báo không tìm thấy
            printf("Not found book with id: %s\n", id_book);
    }
}
// Khởi tạo danh sách liên kết đơn
struct User *head = NULL; // Khai báo biến head cho danh sách liên kết đơn

// Hàm thêm người dùng mới
void addUser(char user_id[], char name[], char borrowed_book[MAX_BOOK][5]){
    struct User *newUser = (struct User*)malloc(sizeof(struct User)); // Cấp phát bộ nhớ cho người dùng mới

    strcpy(newUser->id_user, user_id); // Gán giá trị id_user
    strcpy(newUser->name, name); // Gán giá trị name

    for(int i = 0; i < MAX_BOOK; i++){ // Duyệt qua danh sách sách mượn
        strcpy(newUser->borrowed_book[i], borrowed_book[i]); // Gán giá trị sách mượn
    }
    newUser->next = NULL; // Gán giá trị next
    if(head == NULL){ // Nếu danh sách rỗng
        head = newUser; // Gán head bằng người dùng mới
    }else{ // Nếu danh sách không rỗng
        struct User *temp = head; // Khai báo biến tạm temp
        while(temp->next != NULL){ // Duyệt qua danh sách liên kết đơn
            temp = temp->next; // Di chuyển tới phần tử tiếp theo
        }
        temp->next = newUser; // Gán giá trị người dùng mới vào phần tử tiếp theo
    }
    printf("Add user successfully\n");
}

// Hàm xóa người dùng theo id
void deleteUser(char id_user[]){
    struct User *temp = head; // Khai báo biến tạm temp
    struct User *prev = NULL; // Khai báo biến tạm prev

    // Nếu danh sách rỗng
    if(temp == NULL){
        printf("No user to delete.\n");
        return;
    }
    // Nếu người dùng cần xóa là người đầu tiên
    if(strcmp(temp->id_user, id_user) == 0){ // So sánh id_user với id_user
        head = temp->next; // Gán head bằng phần tử tiếp theo
        free(temp); // Giải phóng bộ nhớ
        printf("Delete user successfully\n");
        return;
    } 
    // Tìm kiếm người dùng cần xóa
    while(temp != NULL && strcmp(temp->id_user, id_user) != 0){ // So sánh id_user với id_user
        prev = temp; // Gán giá trị temp cho prev
        temp = temp->next; // Di chuyển tới phần tử tiếp theo
    }

    // Nếu không tìm thấy người dùng cần xóa
    if(temp == NULL){
        printf("No user to delete.\n");
        return;
    }
    // Xóa người dùng khỏi danh sách
    prev->next = temp->next; // Gán giá trị phần tử tiếp theo cho prev
    free(temp); // Giải phóng bộ nhớ
    printf("Delete user successfully\n");
}


// Display brrowed book
void displayBorrowed(){
    int choice;
    char id_user[5];
    char name[50];
    char borrowed_book[MAX_BOOK][5];

    do{
        printf("-----------Library Borrow Management-----------\n");
        printf("===============================================\n");
        printf("1. Add user\n");
        printf("2. Delete user\n");
        printf("3. Display borrowed book\n");
        printf("0. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);
        deleteInput();
        switch(choice){
            case 1:
                printf("Enter user ID: ");
                scanf("%s", id_user);
                deleteInput();
                printf("Enter user name: ");
                scanf("%s", name);
                deleteInput();
                for(int i = 0; i < MAX_BOOK; i++){
                    printf("Enter borrowed book %d: ", i+1);
                    scanf("%s", borrowed_book[i]);
                    deleteInput();
                }
                addUser(id_user, name, borrowed_book);
                break;
            case 2:
                printf("Enter user ID: ");
                scanf("%s", id_user);
                deleteInput();
                deleteUser(id_user);
                break;
            case 3:
                struct User *temp = head;
                if(temp == NULL){
                    printf("No user to display\n");
                }else{
                    printf("+-------+---------------------------+-----------------------+--------------+\n"); 
                    printf("|  ID   |          Name             |        Borrowed Book  |              |\n");
                    printf("+-------+---------------------------+-----------------------+--------------+\n");
                    while(temp != NULL){
                        printf("| %-5s | %-25s | %-21s | %-12d |\n",
                        temp->id_user, temp->name, temp->borrowed_book, temp->next); 
                        temp = temp->next;
                    }
                    printf("+-------+---------------------------+-----------------------+--------------+\n");
                }
                break;
            case 0:
                printf("Exit program\n");
                break;
            default:
                printf("Invalid choice\n");
                break;
        }
    }while(choice != 0);

}

int main(){
    struct Book books[MAX]; // Khai báo mảng books chứa thông tin sách
    int choice; // Biến lựa chọn chức năng
    createdBook(books); // Tạo danh sách sách tĩnh
    do{
        printf("-----------Library Management-----------\n");
        printf("=======================================\n");
        printf("1. Search book\n");
        printf("2. Customer borrow book\n");
        printf("3. Customer return book\n");
        printf("0. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);
        deleteInput();
        switch(choice){
            case 1:
                char id_book[5];
                printf("Enter book ID: ");
                scanf("%s", id_book);
                deleteInput();
                searchBook(books, MAX, id_book);
                break;
            case 2:
                displayBorrowed();
                break;
            case 3:
                break;
            case 0:
                printf("Exit program\n");
                break;
            default:
                printf("Invalid choice\n");
                break;
        }

    }while(choice != 0);


    return 0;
    
}