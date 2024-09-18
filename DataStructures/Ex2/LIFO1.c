// Stack (LIFO)
// 2018-10-10

// Bài 1: Quản lý đối tượng trong game
//  - Nội dung: Xây dựng một hệ thống quản lý đối tượng (ví dụ: quái vật, item, etc.) trong một game bằng cách sử dụng cấu trúc stack. Khi người chơi tiêu diệt quái vật hoặc thu thập item, các đối tượng này sẽ bị xóa khỏi stack.
//   - Hướng giải quyết:
//      - Sử dụng một cấu trúc `Node` để quản lý đối tượng.
//      - Mỗi đối tượng (quái vật, item) được thêm vào stack thông qua hàm `push()`.
//      - Khi đối tượng bị tiêu diệt hoặc sử dụng, đối tượng sẽ được xóa khỏi stack thông qua hàm `pop()`.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 50

typedef struct Node {
    char name[MAX]; // tên quái vật hoặc item ...
    struct Object *next;
} Object;

Object *top = NULL; // con trỏ top của stack

//Hàm thêm đối tượng vào stack
void push(char *name){
    Object *newObject = (Object *)malloc(sizeof(Object)); // cấp phát bộ nhớ cho đối tượng mới
    strcpy(newObject->name, name); // gán tên cho đối tượng
    newObject->next = top; // cập nhật next của đối tượng mới
    top = newObject; // cập nhật top
    printf("%s da duoc them vao game.\n", name);
}

//Hàm xóa đối tượng khỏi stack
void pop(){
    if(top == NULL){
        printf("Stack rong.\n");
        return;
    }
    Object *temp = top; // con trỏ tạm
    printf("%s da bi tieu diet.\n", top->name); // thông báo xóa đối tượng
    top = top->next; // cập nhật top
    free(temp); // giải phóng bộ nhớ
}

//Hàm hiện thị trong stack
void display(){
    if(top == NULL){
        printf("Stack rong.\n");
        return;
    }
    Object *temp = top; // con trỏ tạm
    printf("Danh sach cac doi tuong trong game:\n");
    while(temp != NULL){
        printf("%s\n", temp->name);
        temp = temp->next; // di chuyển đến đối tượng tiếp theo
    }
}

int main(){
    push("Quai vat hung du");
    push("Ao giap sat");
    push("Quai vat nuoc");
    display();
    pop();
    display();
    pop();
    pop();
    pop();
    return 0;
}

