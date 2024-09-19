// Bài tập 2: Quản lý thứ tự hành động của nhân vật trong game
// Nội dung bài tập:
// Xây dựng hệ thống hàng đợi để quyết định thứ tự các nhân vật hành động dựa trên tốc độ của họ.

// Hướng giải quyết:
// - Tạo hàng đợi ưu tiên dựa trên tốc độ của nhân vật.
// - Nhân vật có tốc độ cao hơn sẽ được xếp ở trước để hành động trước.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>

typedef struct Character {
    int speed;
    char name[20];
    struct Character *next;
} Character;

typedef struct Queue {
    Character *front;
} Queue;

Queue *createQueue() {
    Queue *q = (Queue *)malloc(sizeof(Queue));
    q->front = NULL;
    return q;
}

void enqueue(Queue *q, char *name, int speed) {
    Character *newChar = (Character *)malloc(sizeof(Character));
    newChar->speed = speed;
    strcpy(newChar->name, name);
    newChar->next = NULL;
    
    if (q->front == NULL || q->front->speed < speed) {
        newChar->next = q->front;
        q->front = newChar;
    } else {
        Character *temp = q->front;
        while (temp->next != NULL && temp->next->speed >= speed)
            temp = temp->next;
        newChar->next = temp->next;
        temp->next = newChar;
    }
}

void processQueue(Queue *q) {
    while (q->front != NULL) {
        printf("%s acts with speed %d\n", q->front->name, q->front->speed);
        Character *temp = q->front;
        q->front = q->front->next;
        free(temp);
    }
}

int main() {
    Queue *q = createQueue();
    enqueue(q, "Warrior", 10);
    enqueue(q, "Mage", 7);
    enqueue(q, "Archer", 12);
    
    processQueue(q);
    return 0;
}