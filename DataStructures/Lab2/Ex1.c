// Bài tập 1: Tạo hàng đợi để xử lý sự kiện trong game
// Nội dung bài tập:
// Xây dựng hàng đợi (queue) để lưu trữ các sự kiện của người chơi (di chuyển, tấn công, phòng thủ) và xử lý chúng theo thứ tự.

// Hướng giải quyết:
// - Tạo hàng đợi sử dụng con trỏ để lưu các sự kiện.
// - Mỗi phần tử trong hàng đợi là một sự kiện (có thể là chuỗi hoặc cấu trúc chứa loại sự kiện).
// - Thêm sự kiện vào cuối hàng đợi và xử lý từ đầu hàng đợi.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Event {
    char action[20];
    struct Event *next;
} Event;

typedef struct Queue {
    Event *front, *rear;
} Queue;

Queue *createQueue() {
    Queue *q = (Queue *)malloc(sizeof(Queue));
    q->front = q->rear = NULL;
    return q;
}

void enqueue(Queue *q, char *action) {
    Event *newEvent = (Event *)malloc(sizeof(Event));
    strcpy(newEvent->action, action);
    newEvent->next = NULL;
    if (q->rear == NULL) {
        q->front = q->rear = newEvent;
        return;
    }
    q->rear->next = newEvent;
    q->rear = newEvent;
}

void dequeue(Queue *q) {
    if (q->front == NULL) return;
    Event *temp = q->front;
    q->front = q->front->next;
    if (q->front == NULL) q->rear = NULL;
    free(temp);
}

void processEvents(Queue *q) {
    while (q->front != NULL) {
        printf("Processing event: %s\n", q->front->action);
        dequeue(q);
    }
}

int main() {
    Queue *q = createQueue();
    enqueue(q, "Move");
    enqueue(q, "Attack");
    enqueue(q, "Defend");
    
    processEvents(q);
    
    return 0;
}