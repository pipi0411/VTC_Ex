// Bài tập: Hệ thống quản lý cảnh trong game
//    - Nội dung: Xây dựng hệ thống quản lý các cảnh trong game. Mỗi khi người chơi di chuyển qua các cảnh (screen), cảnh hiện tại sẽ được lưu vào stack. Khi cần quay lại cảnh trước, cảnh gần nhất sẽ được pop ra từ stack.
   
//    - Hướng giải quyết:
//      - Mỗi khi di chuyển qua cảnh mới, lưu cảnh hiện tại vào stack.
//      - Khi người chơi muốn quay lại cảnh trước, pop cảnh gần nhất từ stack.

//    - Lời giải cụ thể:

     #include <stdio.h>
     #include <stdlib.h>
     #include <string.h>

     typedef struct Scene {
         char name[100];          // Tên cảnh
         struct Scene* next;      // Con trỏ tới cảnh tiếp theo
     } Scene;

     Scene* top = NULL;

     // Thêm cảnh vào stack
     void pushScene(char* name) {
         Scene* newScene = (Scene*)malloc(sizeof(Scene));
         strcpy(newScene->name, name);
         newScene->next = top;
         top = newScene;
         printf("Đã di chuyển đến cảnh: %s\n", name);
     }

     // Quay lại cảnh trước
     void backToPreviousScene() {
         if (top == NULL) {
             printf("Không có cảnh để quay lại.\n");
             return;
         }
         Scene* temp = top;
         printf("Quay lại cảnh: %s\n", top->name);
         top = top->next;
         free(temp);
     }

     // Hiển thị các cảnh hiện tại
     void displayScenes() {
         if (top == NULL) {


             printf("Không có cảnh nào hiện tại.\n");
             return;
         }
         Scene* temp = top;
         printf("Danh sách các cảnh hiện tại:\n");
         while (temp != NULL) {
             printf("%s\n", temp->name);
             temp = temp->next;
         }
     }

     int main() {
         pushScene("Cảnh 1");
         pushScene("Cảnh 2");
         pushScene("Cảnh 3");
         displayScenes();
         backToPreviousScene(); // Quay lại cảnh trước
         displayScenes();
         return 0;
     }