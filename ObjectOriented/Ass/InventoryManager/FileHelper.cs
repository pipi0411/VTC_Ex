using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
namespace InventoryManager{
    public static class FileHelper{
        // Đọc dữ liệu từ file và trả về danh sách sản phẩm
        public static List<Product> ReadFromFile(string filePath){
            try{
                if (!File.Exists(filePath)){
                    Console.WriteLine("File not found. Create new file");
                    File.WriteAllText(filePath, "[]"); // Tạo file mới nếu chưa tồn tại
                }
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>(); // Trả về danh sách sản phẩm từ file hoặc danh sách rỗng nếu file trống 
            }catch (Exception e){
                Console.WriteLine($"Error: " + e.Message);
                return new List<Product>();
            }
        }
        // Ghi danh sách sản phẩm vào file
        public static void WriteToFile(string filePath, List<Product> products){
            try{
                var json = JsonSerializer.Serialize(products);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Write file successfully!");
            }catch (Exception e){
                Console.WriteLine($"Error: " + e.Message);
            }
        }   
    }
}