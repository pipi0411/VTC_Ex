using System;
using System.Collections;
// namespace ArrayListDemo{
//     class Program{
//         static void Main(string[] args){
//             ArrayList aList = new ArrayList();
//             Console.WriteLine("Add elements to the list");
//             aList.Add(75);
//             aList.Add(45);
//             aList.Add(12);
//             aList.Add(56);
//             Console.WriteLine("Capacity: {0} ", aList.Capacity);
//             Console.WriteLine("Count: {0} ",aList.Count);
//             Console.WriteLine("Content: ");
//             foreach (int i in aList){
//                 Console.Write(i + " ");
//             }
//             Console.WriteLine();
//             Console.Write("Sorted content: ");
//             aList.Sort();
//             foreach (int i in aList){
//                 Console.Write(i + " ");
//             }
//             Console.WriteLine();
//             Console.ReadKey();
//         }
//     }
// }

// #Bài 1: Tạo và In `ArrayList`

// Mô Tả:
// Tạo một `ArrayList`, thêm các tên của 5 thành phố yêu thích vào đó và in ra danh sách các thành phố.
// class Ex1{
//     static void Main(string[] args){
//         // Khởi tạo một ArrayList
//         ArrayList cities = new ArrayList();
//         // Thêm các thành phố yêu thích vào ArrayList
//         cities.Add("Hanoi");
//         cities.Add("HCMC");
//         cities.Add("Da Nang");
//         cities.Add("Hue");
//         cities.Add("Nha Trang");
//         // In ra danh sách các thành phố
//         Console.WriteLine("List of cities:");
//         foreach (string city in cities){
//             Console.WriteLine(city);
//         }
//     }
// }

// #Bài 2: Thêm và Xoá Phần Tử

// Mô Tả:
// Tạo một `ArrayList` chứa các số từ 1 đến 10. Thêm số 11 vào cuối danh sách và xoá số 5. In danh sách sau các thao tác.
// class Ex2{
//     static void Main(string[] args){
//         // Khởi tạo một ArrayList
//         ArrayList numbers = new ArrayList();
//         // Thêm các số từ 1 đến 10 vào ArrayList
//         for (int i = 1; i <= 10; i++){
//             numbers.Add(i);
//         }

//         // Thêm số 11 vào cuối danh sách
//         numbers.Add(11);
//         // Xoá số 5
//         numbers.Remove(5);
//         //  In ra danh sách sau các thao tác
//         Console.WriteLine("List of numbers:");
//         foreach (int number in numbers){
//             Console.WriteLine(number);
//         }
//     }
// }

// #Bài 3: Truy Cập Phần Tử

// Mô Tả:
// Tạo một `ArrayList` chứa tên các môn học bạn đang học. Yêu cầu người dùng nhập vào một chỉ số và in ra môn học tại vị trí đó. Xử lý ngoại lệ khi chỉ số vượt quá giới hạn.
// class Ex3{
//     static void Main(string[] args){
//         // Khởi tạo một ArrayList
//         ArrayList subjects = new ArrayList() {"Toán", "Lý", "Hóa", "Sinh", "Văn"};
//         Console.Write("Nhập chỉ số môn học (0- {0}):", subjects.Count - 1);
//         string input = Console.ReadLine();
//         try{
//             int index = Convert.ToInt32(input);
//             string subject = (string)subjects[index];
//             Console.WriteLine("Môn học tại vị trí {0} là: {1}", index, subject);
//         }catch(ArgumentOutOfRangeException){
//              Console.WriteLine("Chỉ số vượt quá giới hạn");
//         }catch(FormatException){
//             Console.WriteLine("Chỉ số không hợp lệ");
//         }

//     }
// }
// Nội Dung Học Được:
// - Truy cập phần tử trong `ArrayList` bằng chỉ số.
// - Xử lý ngoại lệ `ArgumentOutOfRangeException` và `FormatException` để đảm bảo chương trình không bị lỗi khi nhập sai.

// #Bài 4: Tìm Kiếm Phần Tử

// Mô Tả:
// Tạo một `ArrayList` chứa các tên động vật. Yêu cầu người dùng nhập tên một động vật và kiểm tra xem nó có trong danh sách không.
// class Ex4{
//     static void Main(string[] args){
//         // Khởi tạo một ArrayList
//         ArrayList animals = new ArrayList() {"Chó", "Mèo", "Heo", "Gà", "Vịt"};
//         Console.Write("Nhập tên động vật cần tìm: ");
//         string input = Console.ReadLine();
//         if (animals.Contains(input)){
//             int index = animals.IndexOf(input);
//             Console.WriteLine("Tìm thấy {0} tại vị trí {1}", input, index);
//         }
//         else{
//             Console.WriteLine("Không tìm thấy {0}", input);
//         }
//     }
// }
// Nội Dung Học Được:
// - Sử dụng phương thức `Contains` để kiểm tra sự tồn tại của một phần tử trong `ArrayList`.
// - Sử dụng phương thức `IndexOf` để tìm vị trí của phần tử trong `ArrayList`.

// #Bài 5: Sắp Xếp `ArrayList`

// Mô Tả:
// Tạo một `ArrayList` chứa các số ngẫu nhiên. Sắp xếp danh sách theo thứ tự tăng dần và in ra kết quả.
// class EX5{
//     static void Main(string[] args){
//         // Khởi tạo một ArrayList
//         ArrayList numbers = new ArrayList() {75, 45, 12, 56};
//         Console.WriteLine("Danh sách trước khi sắp xếp: ");
//         PrintArrayList(numbers);
//         // sắp xếp danh sách
//         numbers.Sort();
//         Console.WriteLine("Danh sách sau khi sắp xếp: ");
//         PrintArrayList(numbers);
//     }
//     static void PrintArrayList(ArrayList list){
//         foreach (int number in list){
//             Console.Write(number + " ");
//         }
//         Console.WriteLine();
//     }
// }
// Nội Dung Học Được:
// - Sử dụng phương thức `Sort` để sắp xếp các phần tử trong `ArrayList`.
// - Hiểu cách `Sort` hoạt động với các phần tử kiểu `int`.

// ### Bài 1: Tạo và In `Stack`
  
//  Mô Tả:
// Tạo một `Stack` chứa các tên của 5 màu sắc yêu thích và in ra danh sách các màu sắc theo thứ tự từ trên xuống dưới.
// class ExStack1{
//     static void Main(string[] args){
//         // Khởi tạo một Stack
//         Stack colors = new Stack();
//         // Thêm các màu sắc yêu thích vào Stack
//         colors.Push("Red");
//         colors.Push("Green");
//         colors.Push("Blue");
//         colors.Push("Yellow");
//         colors.Push("Purple");
//         // In ra danh sách các màu sắc
//         Console.WriteLine("List of colors:");
//         foreach (string color in colors){
//             Console.WriteLine(color);
//         }
//     }
// }
//  Nội Dung Học Được:
// - Cách khởi tạo `Stack`.
// - Sử dụng phương thức `Push` để thêm phần tử vào `Stack`.
// - Duyệt và in các phần tử trong `Stack` bằng vòng lặp `foreach`.

// ### Bài 2: Thêm và Lấy Phần Tử
  
//  Mô Tả:
// Tạo một `Stack` chứa các số từ 1 đến 5. Thêm số 6 vào `Stack`, sau đó lấy phần tử trên cùng ra và in ra.
// class ExStack2{
//     static void Main(string[] args){
//         // Khởi tạo một Stack
//         Stack numbers = new Stack();
//         // Thêm các số từ 1 đến 5 vào Stack
//         for (int i = 1; i <= 5; i++){
//             numbers.Push(i);
//         }
//         // Thêm số 6 vào Stack
//         numbers.Push(6);
//         Console.WriteLine("Sau khi thêm số 6:");
//         // In ra các phần tử trong Stack
//         PrintStack(numbers);
//         // Lấy phần tử trên cùng ra khỏi Stack
//         int top = (int)numbers.Pop();
//         Console.WriteLine("\nPhần tử trên cùng: {0}", top);
//         // In ra các phần tử trong Stack sau khi lấy phần tử trên cùng ra
//         Console.WriteLine("Sau khi lấy phần tử trên cùng ra:");
//         PrintStack(numbers);
//     }
//     static void PrintStack(Stack stack){
//         foreach (int number in stack){
//             Console.Write(number + " ");
//         }
//     }
// }

//  Nội Dung Học Được:
// - Sử dụng phương thức `Push` để thêm phần tử vào `Stack`.
// - Sử dụng phương thức `Pop` để lấy và loại bỏ phần tử trên cùng của `Stack`.
// - Hiểu cách `Stack` hoạt động theo nguyên tắc LIFO (Last-In, First-Out).

// ### Bài 3: Kiểm Tra Phần Tử trên Đỉnh Stack
  
//  Mô Tả:
// Tạo một `Stack` chứa các từ trong một câu. Sử dụng phương thức `Peek` để kiểm tra phần tử trên cùng mà không loại bỏ nó, sau đó in toàn bộ `Stack`.
// class ExStack3{
//     static void Main(string[] args){
//         // Khởi tạo một Stack
//         Stack words = new Stack();
//         // Thêm các từ vào Stack
//         words.Push("Hello");
//         words.Push("World");
//         words.Push("C#");
//         // Kiểm tra phần tử trên cùng
//         string top = (string)words.Peek();
//         Console.WriteLine("Phần tử trên cùng: {0}", top);
//         // In ra các phần tử trong Stack
//         Console.WriteLine("Stack:");
//         PrintStack(words);
//     }
//     static void PrintStack(Stack stack){
//         foreach (string word in stack){
//             Console.WriteLine(word);
//         }
//     }
// }
//  Nội Dung Học Được:
// - Sử dụng phương thức `Peek` để xem phần tử trên cùng của `Stack` mà không loại bỏ nó.
// - Hiểu cách duyệt và in các phần tử trong `Stack`.


// ### Bài 4: Kiểm Tra Stack Rỗng
  
//  Mô Tả:
// Tạo một `Stack`, kiểm tra xem nó có rỗng không, thêm một phần tử vào `Stack`, sau đó kiểm tra lại.
// class ExStack4{
//     static void Main(string[] args){
//         // Khởi tạo một Stack
//         Stack stack = new Stack();
//         // Kiểm tra Stack rỗng
//         Console.WriteLine("Stack rỗng ban đầu: {0}", stack.Count == 0 ? "Có" : "Không");
//         // Thêm một phần tử vào Stack
//         stack.Push("Hello");
//         // Kiểm tra Stack rỗng
//         Console.WriteLine("Stack rỗng sau khi thêm: {0}", stack.Count == 0 ? "Có" : "Không");
//     }
// }
//  Nội Dung Học Được:
// - Sử dụng thuộc tính `Count` để kiểm tra số lượng phần tử trong `Stack`.
// - Hiểu cách kiểm tra `Stack` có rỗng hay không.


// ### Bài 5: Sắp Xếp `Stack`
  
//  Mô Tả:
// Tạo một `Stack` chứa các số ngẫu nhiên. Sắp xếp `Stack` theo thứ tự tăng dần và in ra kết quả.
// class ExStack5{
//     static void Main(string[] args){
//         // Khởi tạo một Stack
//         Stack numbers = new Stack();
//         // Thêm các số ngẫu nhiên vào Stack
//         numbers.Push(75);
//         numbers.Push(45);
//         numbers.Push(12);
//         numbers.Push(56);
//         Console.WriteLine("Danh sách trước khi sắp xếp: ");
//         PrintStack(numbers);
//         // Sắp xếp Stack
//         ArrayList sortedList = new ArrayList(numbers);
//         sortedList.Sort();

//         // Tạo một Stack mới từ ArrayList đã sắp xếp
//         Stack sortedStack = new Stack(sortedList);
//         Console.WriteLine("Danh sách sau khi sắp xếp: ");
//         PrintStack(sortedStack);
//     }
//     static void PrintStack(Stack stack){
//         foreach (int number in stack){
//             Console.Write(number + " ");
//         }
//         Console.WriteLine();
//     }
// }
//  Nội Dung Học Được:
// - Chuyển đổi `Stack` thành `ArrayList` để có thể sắp xếp các phần tử.
// - Sử dụng phương thức `Sort` của `ArrayList` để sắp xếp các phần tử.
// - Tạo `Stack` mới từ `ArrayList` đã sắp xếp.
