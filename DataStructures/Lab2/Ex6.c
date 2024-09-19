// Bài tập 6: Hàng đợi xử lý hiệu ứng âm thanh
// Nội dung bài tập:
// Xây dựng một hàng đợi để xử lý hiệu ứng âm thanh (sound effects) trong game. Khi người chơi thực hiện hành động như tấn công, nhảy, bắn, âm thanh tương ứng sẽ được phát ra theo thứ tự.

// Hướng giải quyết:
// - Tạo hàng đợi để lưu trữ các hiệu ứng âm thanh.
// - Phát âm thanh theo thứ tự từ hàng đợi.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct SoundEffect {
    char effect[20];
    struct SoundEffect *next;
} SoundEffect;

typedef struct Queue {
    SoundEffect *front, *rear;
} Queue;

Queue *createQueue() {
    Queue *q = (Queue *)malloc(sizeof(Queue));
    q->front = q->rear = NULL;
    return q;
}

void enqueueSound(Queue *q, char *effect) {
    SoundEffect *newSound = (SoundEffect *)malloc(sizeof(SoundEffect));
    strcpy(newSound->effect, effect);
    newSound->next = NULL;
    if (q->rear == NULL) {
        q->front = q->rear = newSound;
        return;
    }
    q->rear->next = newSound;
    q->rear = newSound;
}

void processSounds(Queue *q) {
    while (q->front != NULL) {
        printf("Playing sound: %s\n", q->front->effect);
        SoundEffect *temp = q->front;
        q->front = q->front->next;
        free(temp);
        if (q->front == NULL) q->rear = NULL;
    }
}

int main() {
    Queue *soundQueue = createQueue();
    enqueueSound(soundQueue, "Jump");
    enqueueSound(soundQueue, "Attack");
    enqueueSound(soundQueue, "Hit");

    processSounds(soundQueue);  // Phát các hiệu ứng âm thanh theo thứ tự

    return 0;
}