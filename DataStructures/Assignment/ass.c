#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define MAX 10
#define MAX_BOOK 3
#define STACK_MAX 100
#define QUEUE_MAX 100

// Khởi tạo mảng tĩnh chứa danh sách 10 cuốn sách
struct Book {
    char id_book[5];
    char name[50];
    char author[50];
    int year;
};

// Hàm danh sách liên kết đơn quản lý danh sách mượn sách của người dùng
typedef struct User {
    char id_user[5];
    char name[50];
    char borrowed_book[MAX_BOOK][5];
    struct User *next;
} User;

struct Stack {
    char returnedBooks[STACK_MAX][5];
    int top;
};

struct Queue {
    char waitingUsers[QUEUE_MAX][5];
    int front, rear;
};

struct User *head = NULL;

// Hàm xóa buffer sau khi nhập
void deleteInput() {
    char c;
    while ((c = getchar()) != '\n' && c != EOF);
}

// Hàm tạo danh sách sách tĩnh
void createdBook(struct Book books[MAX]) {
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

    for (int i = 0; i < MAX; i++) {
        books[i] = tempBooks[i];
    }
}

// Hàm hiển thị danh sách sách
void displayBooks(struct Book books[], int n) {
    printf("+-------+---------------------------+-----------------------+--------------+\n"); 
    printf("|  ID   |          Name             |        Author         | Publish Year |\n");
    printf("+-------+---------------------------+-----------------------+--------------+\n");

    for (int i = 0; i < n; i++) {
        printf("| %-5s | %-25s | %-21s | %-12d |\n",
            books[i].id_book, books[i].name, books[i].author, books[i].year);
    }

    printf("+-------+---------------------------+-----------------------+--------------+\n");
}

// Hàm tìm kiếm sách theo mã sách
void searchBook(struct Book books[], int n, char id_book[]) {
    int flag = 0;
    for (int i = 0; i < n; i++) {
        if (strcmp(books[i].id_book, id_book) == 0) {
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
    if (flag == 0) {
        printf("Not found book with id: %s\n", id_book);
    }
}

// Hàm thêm người dùng mới
void addUser(char user_id[], char name[], char borrowed_book[MAX_BOOK][5]) {
    struct User *newUser = (struct User*)malloc(sizeof(struct User));
    strcpy(newUser->id_user, user_id);
    strcpy(newUser->name, name);

    for (int i = 0; i < MAX_BOOK; i++) {
        strcpy(newUser->borrowed_book[i], borrowed_book[i]);
    }

    newUser->next = NULL;
    if (head == NULL) {
        head = newUser;
    } else {
        struct User *temp = head;
        while (temp->next != NULL) {
            temp = temp->next;
        }
        temp->next = newUser;
    }
    printf("User added successfully.\n");
}

// Hàm hiển thị thông tin sách mượn của tất cả người dùng
void displayBorrowed() {
    struct User *temp = head;
    if (temp == NULL) {
        printf("No user to display.\n");
        return;
    }

    printf("+-------+---------------------------+---------------------------------------------+\n"); 
    printf("|  ID   |          Name             |        Borrowed Books                       |\n");
    printf("+-------+---------------------------+---------------------------------------------+\n");

    while (temp != NULL) {
        printf("| %-5s | %-25s |", temp->id_user, temp->name);
        for (int i = 0; i < MAX_BOOK; i++) {
            if (strlen(temp->borrowed_book[i]) > 0) {
                printf(" %-5s ", temp->borrowed_book[i]);
            } else {
                printf(" None  ");
            }
        }
        printf("|\n");
        temp = temp->next;
    }

    printf("+-------+---------------------------+---------------------------------------------+\n");
}

// Hàm khởi tạo stack
void initStack(struct Stack *stack) {
    stack->top = -1;
}

// Hàm thêm sách vào stack (push)
void push(struct Stack *stack, char bookId[]) {
    if (stack->top == STACK_MAX - 1) {
        printf("Stack is full. Cannot push more books.\n");
        return;
    }
    strcpy(stack->returnedBooks[++stack->top], bookId);
    printf("Book %s returned and added to stack.\n", bookId);
}

// Hàm lấy sách khỏi stack (pop)
void pop(struct Stack *stack) {
    if (stack->top == -1) {
        printf("Stack is empty. No book to return.\n");
        return;
    }
    printf("Processing return of book %s\n", stack->returnedBooks[stack->top--]);
}

// Hàm khởi tạo queue
void initQueue(struct Queue *queue) {
    queue->front = queue->rear = -1;
}

// Kiểm tra xem queue có rỗng không
int isEmpty(struct Queue *queue) {
    return queue->front == -1;
}

// Hàm thêm người dùng vào queue (enqueue)
void enqueue(struct Queue *queue, char userId[]) {
    if (queue->rear == QUEUE_MAX - 1) {
        printf("Queue is full. Cannot add more users.\n");
        return;
    }

    if (isEmpty(queue)) {
        queue->front = 0;
    }

    strcpy(queue->waitingUsers[++queue->rear], userId);
    printf("User %s is added to the queue.\n", userId);
}

// Hàm lấy người dùng ra khỏi queue (dequeue)
void dequeue(struct Queue *queue) {
    if (isEmpty(queue)) {
        printf("Queue is empty. No user to process.\n");
        return;
    }

    printf("Processing user %s from the queue.\n", queue->waitingUsers[queue->front]);

    if (queue->front == queue->rear) {
        queue->front = queue->rear = -1;
    } else {
        queue->front++;
    }
}

// Menu chính của chương trình
int main() {
    struct Book books[MAX];
    struct Stack returnedBooks;
    struct Queue waitingUsers;

    initStack(&returnedBooks);
    initQueue(&waitingUsers);
    createdBook(books);

    int choice;
    char id[5], name[50];
    char borrowed_books[MAX_BOOK][5];

    do {
        printf("\n--- Library Management System ---\n");
        printf("1. Display books\n");
        printf("2. Search book by ID\n");
        printf("3. Add user\n");
        printf("4. Display borrowed books\n");
        printf("5. Return a book (stack push)\n");
        printf("6. Process returned book (stack pop)\n");
        printf("7. Add user to waiting queue (enqueue)\n");
        printf("8. Process user in queue (dequeue)\n");
        printf("0. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);
        deleteInput(); // Xóa buffer sau khi nhập

        switch (choice) {
            case 1:
                displayBooks(books, MAX);
                break;
            case 2:
                printf("Enter book ID to search: ");
                fgets(id, sizeof(id), stdin);
                deleteInput();
                id[strcspn(id, "\n")] = '\0';  // Loại bỏ ký tự newline
                searchBook(books, MAX, id);
                break;
            case 3:
                printf("Enter user ID: ");
                fgets(id, sizeof(id), stdin);
                id[strcspn(id, "\n")] = '\0';
                deleteInput();
                printf("Enter user name: ");
                fgets(name, sizeof(name), stdin);
                name[strcspn(name, "\n")] = '\0';
                deleteInput();
                for (int i = 0; i < MAX_BOOK; i++) {
                    printf("Enter book %d ID (or leave empty): ", i + 1);
                    fgets(borrowed_books[i], sizeof(borrowed_books[i]), stdin);
                    borrowed_books[i][strcspn(borrowed_books[i], "\n")] = '\0';
                    deleteInput();
                }
                addUser(id, name, borrowed_books);
                break;
            case 4:
                displayBorrowed();
                break;
            case 5:
                printf("Enter book ID to return: ");
                fgets(id, sizeof(id), stdin);
                id[strcspn(id, "\n")] = '\0';
                deleteInput();
                push(&returnedBooks, id);
                break;
            case 6:
                pop(&returnedBooks);
                break;
            case 7:
                printf("Enter user ID to add to queue: ");
                fgets(id, sizeof(id), stdin);
                id[strcspn(id, "\n")] = '\0';
                deleteInput();
                enqueue(&waitingUsers, id);
                break;
            case 8:
                dequeue(&waitingUsers);
                break;
            case 0:
                printf("Exiting program.\n");
                break;
            default:
                printf("Invalid choice. Please try again.\n");
        }
    } while (choice != 0);

    return 0;
}
