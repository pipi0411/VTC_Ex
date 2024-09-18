//Stack LIFO
//18-09-2024

//Bài 2:Undo hàng động của người chơi 
// - Nội dung: Xây dựng một hệ thống "undo" để người chơi có thể quay lại các hành động trước đó (di chuyển, tấn công, v.v.) trong một game bằng cách sử dụng stack.
   
// - Hướng giải quyết:
//     - Mỗi hành động của người chơi sẽ được lưu vào stack bằng hàm `push()`.
//     - Khi người chơi chọn "undo", hành động gần nhất sẽ được loại bỏ khỏi stack bằng hàm `pop()`, và hành động đó sẽ được "đảo ngược".

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 100

typedef struct {
    char action[MAX]; //Lưu hành động của người chơi
    struct Action* next;  //Con trỏ trỏ đến hành động tiếp theo
} Action;

Action *top = NULL; //Khởi tạo stack
//Hàm thêm hành động vào stack
void push(char *action){
    Action *newAction = (Action*)malloc(sizeof(Action)); //Cấp phát bộ nhớ cho hành động mới
    strcpy(newAction->action, action); //Copy hành động vào stack
    newAction->next = top; //Con trỏ next trỏ đến top
    top = newAction; //top trỏ đến hành động mới
    printf("Hanh dong '%s' da duoc thuc hien\n", action);
}

//Hàm undo hành động trong stack
void undo(){
    if(top == NULL){
        printf("Khong co hanh dong de undo\n");
        return;
    }
    Action *temp = top; //Con trỏ tạm thời trỏ đến top
    printf("Hanh dong '%s' da duoc undo\n", top->action);
    top = top->next; //top trỏ đến hành động tiếp theo
    free(temp); //Giải phóng bộ nhớ của hành động bị xóa
}

//Hàm hiển thị các hành động trong stack
void display(){
    if(top == NULL){
        printf("Khong co hanh dong nao\n");
        return;
    }
    Action *temp = top; //Con trỏ tạm thời trỏ đến top
    printf("Cac hanh dong hien tai: \n");
    while(temp != NULL){
        printf("%s\n", temp->action);
        temp = temp->next; //Con trỏ trỏ đến hành động tiếp theo
    }
}

int main(){
    push("Di chuyen len");
    push("Di chuyen xuong");
    push("Di chuyen trai");
    push("Di chuyen phai");
    display();
    undo(); //Undo hành động phải
    display();
    undo(); //Undo hành động trái
    undo(); //Undo hành động xuống
    undo(); //Undo hành động lên
    undo(); //Không có hành động để undo
    return 0;
}