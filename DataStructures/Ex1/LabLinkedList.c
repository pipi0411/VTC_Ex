//Linked List
#include <stdio.h>
#include <stdlib.h>


typedef struct Node{
    int data;
    struct Node *next;
} Node;

//Tạo một node mới
Node *createNode(int value){
    Node *newNode = (Node*)malloc(sizeof(Node));
    newNode->data = value;
    newNode->next = NULL;
    return newNode;
}
//Thêm một phần tử vào đầu danh sách liên kết
void insertAtHead(Node **head, int value){
    Node* newNode = createNode(value);
    newNode->next = *head;
    *head = newNode;
}

//Thêm một phần tử vào cuối danh sách liên kết
void insertAtEnd(Node **head, int value){
    Node *newNode = createNode(value);
    if(*head == NULL){
        *head = newNode;
        return;
    }
    Node *temp = *head;
    while(temp->next != NULL){
        temp = temp->next;
    }
    temp->next = newNode;
}

//Chèn 1 phần tử vào vị trí cụ thể trong danh sách liên kết
void insertAtIndex(Node **head, int value, int index) {
    if (index < 0) {
        return;  // Index không hợp lệ
    }
    
    Node *newNode = createNode(value);
    
    // Nếu muốn chèn vào đầu danh sách
    if (index == 0) {
        newNode->next = *head; // newNode trỏ đến head
        *head = newNode;
        return;
    }
    
    Node *temp = *head;
    
    // Di chuyển `temp` đến vị trí (index - 1)
    for (int i = 0; i < index - 1; i++) {
        if (temp == NULL) {  // Nếu đến cuối danh sách mà không đủ phần tử
            return;
        }
        temp = temp->next;
    }
    
    // Kiểm tra nếu vị trí không hợp lệ
    if (temp == NULL) {
        return;
    }
    
    // Chèn newNode vào vị trí chỉ định
    newNode->next = temp->next;
    temp->next = newNode;
}

//Xóa phần tử đầu danh sách liên kết 
void deleteHead(Node **head){
    if (*head == NULL){
        return;
    }
    Node *temp = *head;
    *head = (*head)->next;
    free(temp);
}

//Xóa phần tử cuối danh sách liên kết 
void deleteEnd(Node **head){
    if(*head == NULL){
        return;
    }
    if((*head)->next == NULL){
        free(*head);
        *head = NULL;
        return;
    }
    Node* temp = *head;
    while(temp->next->next != NULL){
        temp = temp->next;
    }
    free(temp->next);
    temp->next = NULL;
}
// Tìm phần tử trong danh sách liên kết 
int findElement(Node *head, int value){
    int index = 0;
    Node *temp = head;
    while (temp != NULL){
        if(temp->data == value){
            return index;
        }
        temp = temp->next;
        index++;
    }
    return -1; //Không tìm thấy
}

//Duyệt danh sách liên kết
void printList(Node *head){
    Node *temp = head;
    while(temp != NULL){
        printf("%d -> ", temp->data);
        temp = temp->next;
    }
    printf("NULL\n");
}

int main(){
    Node *head = NULL;
    insertAtHead(&head, 3);
    insertAtHead(&head, 2);
    insertAtHead(&head, 1);
    printList(head);
    insertAtEnd(&head, 4);
    insertAtEnd(&head, 5);
    printList(head);
    deleteHead(&head);
    printList(head);   
    deleteEnd(&head);
    printList(head);
    printf("Index of value 3: %d\n", findElement(head, 3));
    insertAtIndex(&head, 2, 1);
    printList(head);
    return 0;
}

