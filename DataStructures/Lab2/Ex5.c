// Bài tập 5: Quản lý đạn bay trong game bắn súng
// Nội dung bài tập:
// Trong game bắn súng, cần quản lý số lượng đạn mà nhân vật bắn ra. Sử dụng hàng đợi để theo dõi vị trí của các viên đạn và xử lý khi chúng biến mất khỏi màn hình.

// Hướng giải quyết:
// - Tạo hàng đợi để lưu vị trí và trạng thái của các viên đạn.
// - Xóa đạn khỏi hàng đợi khi chúng vượt ra ngoài màn hình.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>

typedef struct Bullet {
    int position;
    struct Bullet *next;
} Bullet;

typedef struct Queue {
    Bullet *front, *rear;
} Queue;

Queue *createQueue() {
    Queue *q = (Queue *)malloc(sizeof(Queue));
    q->front = q->rear = NULL;
    return q;
}

void shootBullet(Queue *q, int position) {
    Bullet *newBullet = (Bullet *)malloc(sizeof(Bullet));
    newBullet->position = position;
    newBullet->next = NULL;
    if (q->rear == NULL) {
        q->front = q->rear = newBullet;
        return;
    }
    q->rear->next = newBullet;
    q->rear = newBullet;
}

void updateBullets(Queue *q, int limit) {
    Bullet *temp = q->front;
    while (temp != NULL) {
        temp->position += 1;
        printf("Bullet at position: %d\n", temp->position);
        if (temp->position > limit) {
            printf("Bullet removed\n");
            Bullet *old = temp;
            q->front = q->front->next;
            free(old);
            if (q->front == NULL) q->rear = NULL;
        }
        temp = temp->next;
    }
}

int main() {
    Queue *bulletQueue = createQueue();
    shootBullet(bulletQueue, 0);
    shootBullet(bulletQueue, 1);
    
    updateBullets(bulletQueue, 10);  // Cập nhật vị trí đạn

    return 0;
}
