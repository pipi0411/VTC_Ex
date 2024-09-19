
//   Bài tập: Xử lý sự kiện tấn công của người chơi
//    - Nội dung: Trong game, người chơi có thể liên tục tấn công. Mỗi lần tấn công sẽ được lưu vào stack. Sau đó hệ thống sẽ xử lý tấn công theo thứ tự gần nhất trước (Last In, First Out - LIFO).
   
//    - Hướng giải quyết:
//      - Mỗi lần tấn công được lưu vào stack, cùng với loại tấn công và mức độ sát thương.
//      - Khi xử lý, ta pop sự kiện tấn công gần nhất từ stack và thực thi nó.

//    - Lời giải cụ thể:

     #include <stdio.h>
     #include <stdlib.h>
     #include <string.h>

     typedef struct Attack {
         char type[100];         // Loại tấn công
         int damage;             // Sát thương gây ra
         struct Attack* next;    // Con trỏ tới tấn công tiếp theo
     } Attack;

     Attack* top = NULL;

     // Thêm sự kiện tấn công vào stack
     void pushAttack(char* type, int damage) {
         Attack* newAttack = (Attack*)malloc(sizeof(Attack));
         strcpy(newAttack->type, type);
         newAttack->damage = damage;
         newAttack->next = top;
         top = newAttack;
         printf("Tấn công '%s' với sát thương %d đã được thêm.\n", type, damage);
     }

     // Xử lý sự kiện tấn công gần nhất
     void processAttack() {
         if (top == NULL) {
             printf("Không có sự kiện tấn công để xử lý.\n");
             return;
         }
         Attack* temp = top;
         printf("Xử lý tấn công '%s' với sát thương %d.\n", top->type, top->damage);
         top = top->next;
         free(temp);
     }

     // Hiển thị các sự kiện tấn công hiện tại
     void displayAttacks() {
         if (top == NULL) {
             printf("Không có sự kiện tấn công nào.\n");
             return;
         }
         Attack* temp = top;
         printf("Danh sách các sự kiện tấn công:\n");
         while (temp != NULL) {
             printf("Tấn công '%s' với sát thương %d\n", temp->type, temp->damage);
             temp = temp->next;
         }
     }

     int main() {
         pushAttack("Chém", 100);
         pushAttack("Đấm", 50);
         pushAttack("Đá", 75);
         displayAttacks();
         processAttack(); // Xử lý sự kiện tấn công gần nhất
         displayAttacks();
         return 0;
     }