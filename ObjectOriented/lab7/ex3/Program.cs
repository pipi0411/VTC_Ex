
using System;
using System.IO;

// class Ex1{
//     static void Main(){
//         string filePath = @"C:\Users\pipi\Downloads\vtc_file\hello.txt";
//         //Kiểm tra sự tồn tại của file
//             if (File.Exists(filePath)){
//                 Console.WriteLine("File exists");
//             }else{
//                 Console.WriteLine("File does not exist");
//             }
//     //  - Nội dung học được:
//     //  - Cách sử dụng `File.Exists` để kiểm tra sự tồn tại của file.
//     //  - Thao tác với các điều kiện kiểm tra trong C#.
//     //  - Phương thức xử lý file đơn giản để xây dựng các chương trình dựa trên file.
        
//         // Tạo và ghi file đơn giản
//         string content = "Hung dep trai\n";

//         File.WriteAllText(filePath, content);
//         Console.WriteLine("Write file successfully!");
//     //  - Nội dung học được: 
//     //  - Cách tạo file bằng `File.WriteAllText`.
//     //  - Ghi đè nội dung vào file nếu file đã tồn tại.
//     //  - Kiến thức về cơ bản sử dụng thư viện `System.IO` để xử lý file trong C#.

//         // Ghi thêm nội dung vào file
//         try{
//             string newContent = "Hello World!";
//             using (StreamWriter sw = new StreamWriter(filePath, append: true)){
//                 sw.WriteLine(newContent);
//             }
//             Console.WriteLine("Write file successfully!");
//         }catch (Exception e){
//             Console.WriteLine("Error: " + e.Message);
//         }
//     //  - Nội dung học được:
//     //  - Sử dụng `StreamWriter` với tham số `append: true` để ghi thêm nội dung vào file thay vì ghi đè.
//     //  - Tạo và ghi nhật ký (log) vào file một cách tuần tự.


//         // Đọc file từng dòng
//         try{
//             using (StreamReader sr = new StreamReader(filePath)){
//                 string line;
//                 while ((line = sr.ReadLine()) != null){
//                     Console.WriteLine(line);
//                 }
//             }
//         }catch (Exception e){
//             Console.WriteLine("Error: " + e.Message);
//         }
//     //  - Nội dung học được:
//     //  - Cách sử dụng `StreamReader` để đọc từng dòng dữ liệu từ file.
//     //  - Quản lý tài nguyên sử dụng `using` để tự động giải phóng tài nguyên khi không còn cần thiết.
//     //  - Kiến thức về xử lý file kích thước lớn theo từng phần.
        
//         Console.ReadKey();
//     }
// }

// class Ex2{
//     static void Main(){
//         string filePath = @"C:\Users\pipi\Downloads\vtc_file\data.bin";
//         // Ghi dữ liệu vào file nhị phân
//         using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create))){
//             bw.Write(10);
//             bw.Write(20);
//         }
//         // Đọc dữ liệu từ file nhị phân
//         using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open))){
//             int num1 = br.ReadInt32();
//             int num2 = br.ReadInt32();
//             Console.WriteLine("Number 1: " + num1);
//             Console.WriteLine("Number 2: " + num2);
//         }
//     }
// }

// Sao chép file 
class Ex3{
    static void Main(){
        string sourcePath = @"C:\Users\pipi\Downloads\vtc_file\hello.txt";
        string destPath = @"C:\Users\pipi\Downloads\vtc_file\dest.txt";
        if (File.Exists(sourcePath)){
        try{
            File.Copy(sourcePath, destPath, true); // true: ghi đè file nếu file đã tồn tại
            Console.WriteLine("Copy file successfully!");
        }catch (Exception e){
            Console.WriteLine("Error: " + e.Message);
        }
        }else{
            Console.WriteLine("File does not exist");
        }
    }
}

//    - Nội dung học được:
//      - Sử dụng `File.Copy` để sao chép file từ vị trí này sang vị trí khác.
//      - Tìm hiểu tham số `overwrite` để kiểm soát ghi đè lên file đích.
//      - Quản lý file trên hệ thống tập tin với khả năng sao lưu dữ liệu.


