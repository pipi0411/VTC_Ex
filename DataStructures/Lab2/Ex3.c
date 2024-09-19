// Bài tập 3: Xử lý thứ tự đánh theo lượt (Turn-based combat)
// Nội dung bài tập:
// Trong một trò chơi đánh theo lượt, sử dụng hàng đợi để quyết định thứ tự tấn công của các nhân vật.

// Hướng giải quyết:
// - Tạo hàng đợi để lưu trữ danh sách nhân vật.
// - Mỗi nhân vật lần lượt tấn công và được đưa trở lại cuối hàng đợi.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>

typedef struct Character {
    char name[20];
    struct Character *next;
} Character;

typedef struct Queue {
    Character *front, *rear;
} Queue;

Queue *createQueue() {
    Queue *q = (Queue *)malloc(sizeof(Queue));
    q->front = q->rear = NULL;
    return q;
}

void enqueue(Queue *q, char *name) {
    Character *newChar = (Character *)malloc(sizeof(Character));
    strcpy(newChar->name, name);
    newChar->next = NULL;
    if (q->rear == NULL) {
        q->front = q->rear = newChar;
        return;
    }
    q->rear->next = newChar;
    q->rear = newChar;
}

void rotate(Queue *q) {
    if (q->front == NULL) return;
    Character *temp = q->front;
    enqueue(q, q->front->name);  // Move current front to the rear
    q->front = q->front->next;
    free(temp);
}

void processTurns(Queue *q, int turns) {
    for (int i = 0; i < turns; i++) {
        printf("%s attacks!\n", q->front->name);
        rotate(q);
    }
}

int main() {
    Queue *q = createQueue();
    enqueue(q, "Warrior");
    enqueue(q, "Mage");
    enqueue(q, "Archer");

    processTurns(q, 5);
    return 0;
}