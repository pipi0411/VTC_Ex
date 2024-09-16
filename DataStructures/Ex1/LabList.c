// List 

#include <stdio.h>
#include <stdlib.h>

#define MAX 100

typedef struct {
    int data[MAX];
    int size;
} List;

void initList(List *list){
    list->size = 0;
}

// Thêm phần tử vào danh sách
void add(List *list , int value){
    if(list->size < MAX){
        list->data[list->size++] = value;
    }else{
        printf("List is full\n");
    }
}

//Xóa phần tử trong danh sách
void delete(List *list, int index){
    if(index < 0 || index >= list->size){
        printf("Invalid index\n");
        return;
    }
    for(int i = index; i < list->size; i++){
        list->data[i] = list->data[i+1];
    }
    list->size--;
}

// chèn phần tử vào danh sách
void insert(List *list, int index, int value){
    if(index < 0 || index > list->size || list->size >= MAX){
        printf("Invalid index\n");
        return;
    }
    for(int i = list->size; i > index; i--){
        list->data[i] = list->data[i-1];
    }
    list->data[index] = value;
    list->size++;
}

//Tìm phần tử trong danh sách
int find(List *list, int value){
    for(int i = 0; i < list->size; i++){
        if(list->data[i] == value){
            return i;
        }
    }
     return -1; // Không tìm thấy
}

//Sắp xếp danh sách tăng dần
void sortList(List *list){
    for(int i = 0; i < list->size - 1; i++){
        for(int j = i + 1; j < list->size; j++){
            if(list->data[i] > list->data[j]){
                int temp = list->data[i];
                list->data[i] = list->data[j];
                list->data[j] = temp;
            }
        }
    }
}

// Đảo ngược danh sách
void reverseList(List *list){
    int start = 0;
    int end = list->size -1;
    while(start < end){
        int temp = list->data[start];
        list->data[start] = list->data[end];
        list->data[end] = temp;
        start++;
        end--;
    }
}

void printList(List *list){
    for(int i = 0; i < list->size; i++){
        printf("%d ", list->data[i]);
    }
    printf("\n");
}

int main(){
    List list;
    initList(&list);
    add(&list, 1);
    add(&list, 2);
    add(&list, 3);
    add(&list, 4);
    add(&list, 5);
    printList(&list);
    delete(&list, 2);
    printList(&list);
    insert(&list, 2, 10);
    printList(&list);
    int index = find(&list, 10);
    if(index != -1){
        printf("Found at index %d\n", index);
    }else{
        printf("Not found\n");
    }
    sortList(&list);
    printList(&list);
    reverseList(&list);
    printList(&list);
    return 0;
}




