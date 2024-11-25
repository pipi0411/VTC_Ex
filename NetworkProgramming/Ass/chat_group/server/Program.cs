using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

class ChatServer
{
    static TcpListener listener; // TcpListener để lắng nghe kết nối từ client
    static List<TcpClient> clients = new List<TcpClient>(); // Danh sách client kết nối đến server
    static byte[] key = Encoding.ASCII.GetBytes("1234567890abcdef"); // Key để mã hóa dữ liệu
    static byte[] iv = Encoding.ASCII.GetBytes("1234567890abcdef"); // IV để mã hóa dữ liệu

    static void Main(string[] args)
    {
        Console.Write("Enter port: "); // Nhập cổng để lắng nghe kết nối từ client
        int port = int.Parse(Console.ReadLine());

        listener = new TcpListener(IPAddress.Any, port); // Tạo TcpListener để lắng nghe kết nối từ client
        listener.Start(); // Bắt đầu lắng nghe kết nối từ client
        Console.WriteLine($"Server started on port {port}. Waiting for connections...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient(); // Chấp nhận kết nối từ client
            clients.Add(client); // Thêm client vào danh sách
            Console.WriteLine("Client connected");

            // Tạo một luồng mới để xử lý kết nối từ client
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client); // Khởi động luồng mới và truyền client vào phương thức xử lý
        }
    }

    // Phương thức xử lý kết nối từ client
    static void HandleClient(object clientObj)
    {
        TcpClient client = (TcpClient)clientObj;
        NetworkStream stream = client.GetStream(); // Lấy luồng dữ liệu từ client
        byte[] buffer = new byte[1024]; // Buffer để đọc dữ liệu từ client
        int bytesRead;

        try
        {
            // Phương thức gửi tin nhắn đến tất cả client khác
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = DecryptMessage(buffer, bytesRead); // Giải mã tin nhắn từ client
                Console.WriteLine("Received: " + message); // Hiển thị tin nhắn từ client

                byte[] encryptedMessage = EncryptMessage(message); // Mã hóa tin nhắn để gửi đi
                BroadcastMessage(encryptedMessage, client); // Gửi tin nhắn đến tất cả client khác
            }
        }
        catch (IOException ex)
        {
            // Lỗi khi kết nối bị đóng đột ngột
            Console.WriteLine("Client disconnected unexpectedly: " + ex.Message);
        }
        finally
        {
            // Khi client ngắt kết nối
            clients.Remove(client); // Xóa client khỏi danh sách
            client.Close(); // Đóng kết nối
            Console.WriteLine("Client disconnected");
        }
    }

    static void BroadcastMessage(byte[] message, TcpClient sender)
    {
        foreach (TcpClient client in clients)
        {
            if (client != sender) // Không gửi tin nhắn đến client gửi tin nhắn
            {
                NetworkStream stream = client.GetStream(); // Lấy luồng dữ liệu từ client
                stream.Write(message, 0, message.Length); // Gửi dữ liệu đi
            }
        }
    }

    // Phương thức mã hóa tin nhắn từ client
    static byte[] EncryptMessage(string message)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key; // Tạo key cho AES
            aes.IV = iv; // Tạo IV cho AES
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV); // Tạo đối tượng mã hóa từ key và IV
            byte[] messageBytes = Encoding.ASCII.GetBytes(message); // Chuyển tin nhắn sang dạng byte để mã hóa

            return encryptor.TransformFinalBlock(messageBytes, 0, messageBytes.Length); // Mã hóa tin nhắn và trả về dữ liệu đã mã hóa
        }
    }

    // Phương thức giải mã tin nhắn từ client
    static string DecryptMessage(byte[] encryptedMessage, int length)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key; // Tạo key cho AES
            aes.IV = iv; // Tạo IV cho AES
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV); // Tạo đối tượng giải mã từ key và IV
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedMessage, 0, length); // Giải mã tin nhắn

            return Encoding.ASCII.GetString(decryptedBytes); // Chuyển dữ liệu đã giải mã sang chuỗi
        }
    }
}
