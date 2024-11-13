// 1. Mã hóa và giải mã dữ liệu sử dụng AES

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program{
    public static void Main(){
        // Chuỗi ban đầu cần mã hóa
        string original = "Hello, World!";
        // Tạo đối tượng AES và tự động tạo Key và IV
        using (Aes aes = Aes.Create()){
            aes.KeySize = 128; // Độ dài key 128 bit
            aes.GenerateKey(); // Tạo key ngẫu nhiên
            aes.GenerateIV(); // Tạo IV ngẫu nhiên
            // Mã hóa dữ liệu
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted;
            using (MemoryStream ms = new MemoryStream()){
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) // Tạo CryptoStream để mã hóa dữ liệu 
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                     sw.Write(original); // Ghi dữ liệu vào CryptoStream
                    }
                }
                encrypted = ms.ToArray(); // Lấy dữ liệu đã mã hóa từ bộ nhớ đệm
            } // Tạo bộ nhớ đệm để lưu dữ liệu đã mã hóa 
           
            // Hiển thị dữ liệu đã mã hóa
            Console.WriteLine("Original: {0}", original); // Hiển thị dữ liệu ban đầu 
            Console.WriteLine("Encrypted (Base64): {0}", Convert.ToBase64String(encrypted)); // Hiển thị dữ liệu đã mã hóa dưới dạng Base64 
            // Giải mã dữ liệu
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (MemoryStream msDecrypt = new MemoryStream(encrypted)) // Tạo bộ nhớ đệm để lưu dữ liệu đã mã hóa
            {
                using (CryptoStream scDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) // Tạo CryptoStream để giải mã dữ liệu
                {
                    using (StreamReader srDecrypt = new StreamReader(scDecrypt)) // Tạo StreamReader để đọc dữ liệu từ CryptoStream
                    {
                        string decrypted = srDecrypt.ReadToEnd(); // Đọc dữ liệu đã giải mã
                        // Hiển thị dữ liệu đã giải mã
                        Console.WriteLine("Decrypted: {0}", decrypted); // Hiển thị dữ liệu đã giải mã
                    }
                }
            }
                 
        }
    }
}
/*Nội dung học được:
- Cách sử dụng `AES` để mã hóa và giải mã một chuỗi trong C#.
- Sử dụng `MemoryStream` và `CryptoStream` để xử lý mã hóa và giải mã dữ liệu trong luồng. */
