using System;
using System.Collections;
using System.Collections.Generic;

class Ex1{
    static void Main(string[], agrs){
        //  1. HashTable - Thêm và Xóa Phần Tử
        Hashtable student = new Hashtable();
        student.Add("1", "Nguyen Van A");
        student.Add("2", "Nguyen Van B");
        student.Add("3", "Nguyen Van C");
        student.Remove("1");
        //  2. HashTable - Tìm Kiếm Phần Tử
        if (student.ContainsKey("2")){
        Console.WriteLine("Found: " + student["2"]);
        } else {
        Console.WriteLine("Not found");
        }
        // 3. HashTable - Đếm Số Phần Tử
        int count = student.Count;
        Console.WriteLine("Số sinh viên: " + count);
        // 4. HashTable - Kiểm Tra Giá Trị
        if (student.ContainsValue("Nguyen Van B")){
        Console.WriteLine("Found");
       }else{
       Console.WriteLine("Not found");
       }
// Nội dung học được: Kiểm tra xem một giá trị có tồn tại trong `HashTable` hay không.
// 5. HashTable - Sao Chép Sang Dictionary
Dictionary<string, string> studentDict = new Dictionary<string, string>();
foreach (DictionaryEntry item in student){
    studentDict.Add(item.Key.ToString(), item.Value.ToString());
}
//Nội dung học được: Chuyển đổi dữ liệu từ `HashTable` sang `Dictionary`.
//  6. HashTable - Lấy Danh Sách Khóa
ICollection keys = student.Keys;
foreach (var key in keys){
    Console.WriteLine(key);
}
// Nội dung học được: Sử dụng thuộc tính `Keys` để lấy danh sách các khóa trong `HashTable`.
//  7. HashTable - In Ra Các Phần Tử
foreach (DictionaryEntry item in student){
    Console.WriteLine(item.Key + " - " + item.Value);
}
//Nội dung học được: Cách duyệt qua và in ra các phần tử trong `HashTable`.

//8. HashTable - Tìm Kiếm Sản Phẩm 
Hashtable products = new Hashtable();
products.Add("1", "Iphone 12");
if (products.ContainsKey("1")){
    Console.WriteLine("Product: " + products["1"]);
}else{
    Console.WriteLine("Not found");
}
//Nội dung học được: Cách sử dụng `HashTable` để lưu trữ và truy xuất thông tin sản phẩm.
//  9. HashTable - Cập Nhật Giá Trị
products["1"] = "Iphone 13";
Console.WriteLine("Updated product: " + products["1"]);
//Nội dung học được: Cách cập nhật giá trị của một khóa trong `HashTable`.
//  10. HashTable - Xóa Khóa
prodcucts.Remove("1");
Console.WriteLine(products.ContainsKey("1") ? "Exists" : "Dose not exist");
// Nội dung học được: Cách xóa một khóa và kiểm tra sự tồn tại của nó trong `HashTable`.

    }
}

//  11. SortedList - Thêm Phần Tử
SortedList<int , string> cities = new SortedList<int, string>();
cities.Add(1, "Ha Noi");
// Nội dung học được: Cách thêm các phần tử vào `SortedList` và tự động sắp xếp theo khóa.
//12. SortedList - Xóa Phần Tử
cities.Remove(1);
// Nội dung học được: Cách xóa một phần tử trong `SortedList`.