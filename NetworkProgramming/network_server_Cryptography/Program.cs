using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

class Server
{
    static void Main(string[] args)
    {
        TcpListener server = null;
        try
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            server = new TcpListener(ipAddress, port);

            server.Start();
            Console.WriteLine("Server started...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            NetworkStream stream = client.GetStream();
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                // Sử dụng khóa và IV của server
                byte[] key = Encoding.ASCII.GetBytes("12345678");
                byte[] iv = Encoding.ASCII.GetBytes("12345678");
                des.Key = key;
                des.IV = iv;

                while (true)
                {
                    // Nhận tin nhắn từ client
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    if (bytesRead == 0) break; // Kết thúc nếu client ngắt kết nối

                    try
                    {
                        // Giải mã tin nhắn
                        byte[] encryptedData = Convert.FromBase64String(Encoding.ASCII.GetString(data, 0, bytesRead));
                        ICryptoTransform decryptor = des.CreateDecryptor();
                        byte[] decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                        string receivedMessage = Encoding.ASCII.GetString(decryptedData);
                        Console.WriteLine("Client: " + receivedMessage);

                        // Gửi tin nhắn trả lời
                        Console.Write("Server: ");
                        string responseMessage = Console.ReadLine();
                        byte[] responseBytes = Encoding.ASCII.GetBytes(responseMessage);
                        ICryptoTransform encryptor = des.CreateEncryptor();
                        byte[] encryptedResponse = encryptor.TransformFinalBlock(responseBytes, 0, responseBytes.Length);
                        string encryptedResponseMessage = Convert.ToBase64String(encryptedResponse);
                        stream.Write(Encoding.ASCII.GetBytes(encryptedResponseMessage), 0, encryptedResponseMessage.Length);
                    }
                    catch (CryptographicException ce)
                    {
                        Console.WriteLine("Decryption failed: " + ce.Message);
                        // Có thể gửi thông báo lỗi tới client hoặc tiếp tục chờ tin nhắn mới
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine("Invalid data format: " + fe.Message);
                        // Xử lý dữ liệu không hợp lệ
                    }
                }
            }

            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        finally
        {
            server.Stop();
        }
    }
}
