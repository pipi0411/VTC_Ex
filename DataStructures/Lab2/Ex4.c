// Bài tập 4: Hàng đợi xử lý hành động của quái vật
// Nội dung bài tập:
// Trong trò chơi, mỗi quái vật có một hàng đợi các hành động (di chuyển, tấn công) cần thực hiện. Xây dựng hệ thống hàng đợi để quản lý các hành động của từng quái vật.

// Hướng giải quyết:
// - Mỗi quái vật có một hàng đợi riêng để lưu hành động (ví dụ: "Di chuyển", "Tấn công").
// - Mỗi hành động được thêm vào hàng đợi và xử lý theo thứ tự.

// Lời giải cụ thể:

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Action {
    char description[20];
    struct Action *next;
} Action;

typedef struct Monster {
    char name[20];
    Action *front, *rear;
} Monster;

Monster *createMonster(char *name) {
    Monster *m = (Monster *)malloc(sizeof(Monster));
    strcpy(m->name, name);
    m->front = m->rear = NULL;
    return m;
}

void addAction(Monster *m, char *desc) {
    Action *newAction = (Action *)malloc(sizeof(Action));
    strcpy(newAction->description, desc);
    newAction->next = NULL;
    if (m->rear == NULL) {
        m->front = m->rear = newAction;
        return;
    }
    m->rear->next = newAction;
    m->rear = newAction;
}

void processAction(Monster *m) {
    if (m->front == NULL) return;
    Action *temp = m->front;
    printf("Monster %s performs: %s\n", m->name, temp->description);
    m->front = m->front->next;
    if (m->front == NULL) m->rear = NULL;
    free(temp);
}

int main() {
    Monster *goblin = createMonster("Goblin");
    addAction(goblin, "Move");
    addAction(goblin, "Attack");
    addAction(goblin, "Defend");

    processAction(goblin); // Goblin performs Move
    processAction(goblin); // Goblin performs Attack
    processAction(goblin); // Goblin performs Defend

    return 0;
}