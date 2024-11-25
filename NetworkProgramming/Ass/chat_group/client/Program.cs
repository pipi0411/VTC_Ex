using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

class ChatClient
{
    static TcpClient client; // TcpClient để kết nối đến server
    static NetworkStream stream; // Luồng dữ liệu giữa client và server
    static byte[] key = Encoding.ASCII.GetBytes("1234567890abcdef"); // Key để mã hóa dữ liệu
    static byte[] iv = Encoding.ASCII.GetBytes("1234567890abcdef"); // IV để mã hóa dữ liệu
    static string username; // Tên của client
    static void Main(string[] args)
    {
        Console.Write("Enter host: "); // Nhập địa chỉ IP hoặc tên miền của server
        string host = Console.ReadLine();
        Console.Write("Enter port: "); // Nhập cổng để kết nối đến server
        int port = int.Parse(Console.ReadLine());
        Console.Write("Enter username: "); // Nhập tên của client
        username = Console.ReadLine();

        client = new TcpClient(host, port); // Kết nối đến server
        stream = client.GetStream(); // Lấy luồng dữ liệu từ server

        // Tạo luồng mới để nhận tin nhắn từ server
        Thread receiveThread = new Thread(ReceiveMessage);
        receiveThread.Start();
        Console.WriteLine("Connected to server. Start typing messages.");

        // Gửi tin nhắn đến server
        while (true)
    {
    string message = Console.ReadLine(); // Nhập tin nhắn từ bàn phím
    string fullMessage = $"{username}: {message}"; // Thêm tên client vào tin nhắn
    byte[] encryptedMessage = EncryptMessage(fullMessage); // Mã hóa tin nhắn để gửi đi
    
    Console.SetCursorPosition(0, Console.CursorTop); // Di chuyển con trỏ về đầu dòng hiện tại
    Console.Write(new string(' ', Console.WindowWidth)); // Xóa dòng hiện tại (nếu cần)
    Console.SetCursorPosition(0, Console.CursorTop - 1); // Di chuyển con trỏ lên dòng trước đó
    Console.WriteLine($"You: {message}"); // Hiển thị tin nhắn đã gửi
    
    stream.Write(encryptedMessage, 0, encryptedMessage.Length); // Gửi dữ liệu đi
    }

    }

    // Phương thức nhận tin nhắn từ server
    static void ReceiveMessage()
    {
        byte[] buffer = new byte[1024]; // Buffer để đọc dữ liệu từ server
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = DecryptMessage(buffer, bytesRead); // Chuyển dữ liệu từ byte sang chuỗi
                Console.WriteLine(message); // Hiển thị tin nhắn từ server
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error receiving message: " + ex.Message);
        }
        finally
        {
            client.Close(); // Đảm bảo đóng kết nối khi có lỗi
        }
    }

    // Phương thức mã hóa tin nhắn từ client
    static byte[] EncryptMessage(string message)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;  // Tạo key để mã hóa dữ liệu
            aes.IV = iv;  // Tạo IV để mã hóa dữ liệu

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV); // Tạo đối tượng mã hóa dữ liệu từ key và IV đã tạo 
            byte[] messageBytes = Encoding.ASCII.GetBytes(message); // Chuyển tin nhắn từ chuỗi sang dạng byte để mã hóa
            return encryptor.TransformFinalBlock(messageBytes, 0, messageBytes.Length); // Mã hóa tin nhắn từ byte 
        }
    }

    // Phương thức giải mã tin nhắn từ server
    static string DecryptMessage(byte[] encryptedMessage, int length)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key; // Tạo key để giải mã dữ liệu
            aes.IV = iv; // Tạo IV để giải mã dữ liệu

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV); // Tạo đối tượng giải mã dữ liệu từ key và IV đã tạo
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedMessage, 0, length); // Giải mã dữ liệu từ byte
            return Encoding.ASCII.GetString(decryptedBytes); // Chuyển dữ liệu từ byte sang chuỗi
        }
    }
}
