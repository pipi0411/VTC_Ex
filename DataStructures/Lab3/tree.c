// Binary Tree
//20-09-2024

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Định nghĩa một cấu trúc `Node` để biểu diễn một nút trong cây nhị phân với các thành phần `value`, `left`, và `right`.
typedef struct Node {
    int value;
    struct Node *left;
    struct Node *right;
} Node;

// Khởi tạo cây nhị phân với một nút có giá trị `value` cho trước.
Node *createNode (int value){
    Node *newNode = (Node *)malloc(sizeof(Node)); // Cấp phát bộ nhớ cho nút mới.
    newNode->value = value; // Gán giá trị cho nút mới.
    newNode->left = NULL; // Khởi tạo con trái của nút mới là `NULL`.
    newNode->right = NULL; // Khởi tạo con phải của nút mới là `NULL`.
    return newNode; // Trả về nút mới.
}

//Duyệt cây nhị phân tiền tự (Preorder Traversal) (root-left-right).
void preOrder(Node *root){
    if (root != NULL) {
        printf("%d ", root->value); // In ra giá trị của nút hiện tại.
        preOrder(root->left); // Duyệt sang con trái.
        preOrder(root->right); // Duyệt sang con phải.
    }
}

//Duyệt cây nhị phân trung tự (Inorder Traversal) (left-root-right).
void inOrder(Node *root){
    if(root != NULL){
        inOrder(root->left); // Duyệt sang con trái.
        printf("%d ", root->value); // In ra giá trị của nút hiện tại.
        inOrder(root->right); // Duyệt sang con phải.
    }
}

//Duyệt cây nhị phân hậu tự (Postorder Traversal) (left-right-root).
void postOrder(Node *root){
    if(root !=NULL){
        postOrder(root->left);
        postOrder(root->right);
        printf("%d", root->value);
    }
}

//Thêm một nút mới vào cây nhị phân.
void insertNode(Node **root, int value){
    if(*root == NULL){ // Nếu cây rỗng.
        *root = createNode(value); // Tạo một nút mới với giá trị `value`.
    } else if(value < (*root)->value){ // Nếu `value` nhỏ hơn giá trị của nút hiện tại.
        insertNode(&(*root)->left, value); // Thêm nút mới vào cây con bên trái.
    } else if(value > (*root)->value){ // Nếu `value` lớn hơn giá trị của nút hiện tại.
        insertNode(&(*root)->right, value); // Thêm nút mới vào cây con bên phải.
    }
}

//Hủy toàn bộ cây nhị phân.
void deleteTree(Node *root){
    if(root != NULL){
        deleteTree(root->left);
        deleteTree(root->right);
        free(root);
    }
}

// Định nghĩa cấu trúc cây nhị phân tìm kiếm với các quy tắc so sánh giá trị để duy trì cây.
typedef struct BinarySearchTree {
    Node *root;
} BinarySearchTree;

// Khởi tạo cây nhị phân tìm kiếm.
BinarySearchTree *createBinarySearchTree(){
    BinarySearchTree *tree = (BinarySearchTree *)malloc(sizeof(BinarySearchTree)); // Cấp phát bộ nhớ cho cây mới.
    tree->root = NULL; // Khởi tạo nút gốc của cây là `NULL`.
    return tree; // Trả về cây mới.
}

// Thêm một giá trị vào cây nhị phân tìm kiếm.
Node *insert(Node *root, int value){
    if(root == NULL) return createNode(value); // Nếu cây rỗng, thêm giá trị vào cây.
    if(value < root->value) root->left = insert(root->left, value); // Nếu giá trị nhỏ hơn giá trị của nút hiện tại, thêm giá trị vào cây con bên trái.
    else if(value > root->value) root->right = insert(root->right, value); // Nếu giá trị lớn hơn giá trị của nút hiện tại, thêm giá trị vào cây con bên phải.
    return root; // Trả về nút hiện tại.
}

// Tìm kiếm phần tử trong cây nhị phân tìm kiếm

Node *search(Node *root, int value){
    if (root == NULL || root->value == value) return root; // Nếu cây rỗng hoặc giá trị của nút hiện tại bằng giá trị cần tìm, trả về nút hiện tại.
    if(root->value < value) return search(root->right, value); // Nếu giá trị của nút hiện tại nhỏ hơn giá trị cần tìm, tìm kiếm ở cây con bên phải.
    else return search(root->left, value); // Tìm kiếm ở cây con bên trái.
}

//Tìm phần tử nhỏ nhất trong cây nhị phân tìm kiếm
Node *findMin(Node *root){
    while (root->left != NULL) root = root->left; // Tìm nút trái nhất của cây.
    return root; // Trả về nút trái nhất.
}

//Xóa một nút trong cây nhị phân tìm kiếm
Node *deleteNode(Node *root, int value){
    if(root == NULL) return root; // Nếu cây rỗng, trả về.
    if(value < root->value){
        root->left = deleteNode(root->left, value); // Nếu giá trị cần xóa nhỏ hơn giá trị của nút hiện tại, xóa nút trong cây con bên trái.
    }else if(value > root->value){
        root->right = deleteNode(root->right, value); // Nếu giá trị cần xóa lớn hơn giá trị của nút hiện tại, xóa nút trong cây con bên phải.
    }else{
        if(root->left == NULL){
            Node *temp = root->right; // Lưu trữ con phải của nút hiện tại.
            free(root); // Giải phóng nút hiện tại.
            return temp; // Trả về con phải của nút hiện tại.
        }else if (root->right == NULL){
            Node *temp = root->left; // Lưu trữ con trái của nút hiện tại.
            free(root); // Giải phóng nút hiện tại.
            return temp; // Trả về con trái của nút hiện tại.
        }
        Node *temp = findMin(root->right); // Tìm nút nhỏ nhất trong cây con bên phải.
        root->value = temp->value; // Gán giá trị của nút nhỏ nhất vào nút hiện tại.
        root->right = deleteNode(root->right, temp->value); // Xóa nút nhỏ nhất trong cây con bên phải.
    }
    
}

//Độ sâu của cây nhị phân
int depth(Node *root){
    if(root == NULL) return 0; // Nếu cây rỗng, trả về 0.
    int leftDepth = depth(root->left); // Đệ quy tìm độ sâu của cây con bên trái.
    int rightDepth = depth(root->right); // Đệ quy tìm độ sâu của cây con bên phải.
    return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1; // Trả về độ sâu lớn nhất của hai cây con cộng thêm 1.
}

//Kiểm tra cây nhị phân có cân bằng không
int isBalanced(Node *root){
    if (root = NULL) return 1; // Nếu cây rỗng, trả về 1.
    int leftDepth = depth(root->left); // Tính độ sâu của cây con bên trái.
    int rightDepth = depth(root->right); // Tính độ sâu của cây con bên phải.
    return abs(leftDepth - rightDepth) <= 1 && isBalanced(root->left) && isBalanced(root->right); // Trả về 1 nếu độ sâu của hai cây con không chênh lệch quá 1 và cả hai cây con đều cân bằng.
}