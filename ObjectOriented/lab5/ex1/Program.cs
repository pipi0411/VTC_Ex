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
class EX5{
    static void Main(string[] args){
        // Khởi tạo một ArrayList
        ArrayList numbers = new ArrayList() {75, 45, 12, 56};
        Console.WriteLine("Danh sách trước khi sắp xếp: ");
        PrintArrayList(numbers);
        // sắp xếp danh sách
        numbers.Sort();
        Console.WriteLine("Danh sách sau khi sắp xếp: ");
        PrintArrayList(numbers);
    }
    static void PrintArrayList(ArrayList list){
        foreach (int number in list){
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}