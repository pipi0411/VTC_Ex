// Bài tập: Hệ thống tương tác giữa các đối tượng trong game
//    - Nội dung: Xây dựng hệ thống tương tác giữa các đối tượng trong game (ví dụ: va chạm giữa nhân vật và vật cản). Khi hai đối tượng tương tác, thông tin về đối tượng sẽ được lưu vào stack để xử lý sau.
   
//    - Hướng giải quyết:
//      - Mỗi khi có một tương tác xảy ra (ví dụ: va chạm), thông tin về hai đối tượng sẽ được lưu vào stack.
//      - Khi cần xử lý, pop tương tác gần nhất từ stack và tiến hành xử lý.

//    - Lời giải cụ thể:

     #include <stdio.h>
     #include <stdlib.h>

     typedef struct Interaction {
         int object1;            // Đối tượng 1
         int object2;            // Đối tượng 2
         struct Interaction* next; // Con trỏ tới tương tác tiếp theo
     } Interaction;

     Interaction* top = NULL;

     // Thêm một tương tác vào stack
     void pushInteraction(int obj1, int obj2) {
         Interaction* newInteraction = (Interaction*)malloc(sizeof(Interaction));
         newInteraction->object1 = obj1;
         newInteraction->object2 = obj2;
         newInteraction->next = top;
         top = newInteraction;
         printf("Tương tác giữa đối tượng %d và %d đã được thêm.\n", obj1, obj2);
     }

     // Xử lý tương tác gần nhất
     void processInteraction() {
         if (top == NULL) {
             printf("Không có tương tác nào để xử lý.\n");
             return;
         }
         Interaction* temp = top;
         printf("Xử lý tương tác giữa đối tượng %d và %d.\n", top->object1, top->object2);
         top = top->next;
         free(temp);
     }

     // Hiển thị các tương tác hiện tại
     void displayInteractions() {
         if (top == NULL) {
             printf("Không có tương tác nào.\n");
             return;
         }
         Interaction* temp = top;
         printf("Danh sách các tương tác:\n");
         while (temp != NULL) {
             printf("Tương tác giữa đối tượng %d và %d\n", temp->object1, temp->object2);
             temp = temp->next;
         }
     }

     int main() {
         pushInteraction(1, 2);
         pushInteraction(3, 4);
         pushInteraction(5, 6);
         displayInteractions();
         processInteraction(); // Xử lý tương tác gần nhất
         displayInteractions();
         return 0;
     }