using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

class Client
{
    static void Main(string[] args)
    {
        try
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 8888);

            NetworkStream stream = client.GetStream();
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] key = Encoding.ASCII.GetBytes("123456789");
                byte[] iv = Encoding.ASCII.GetBytes("123456789");
                des.Key = key;
                des.IV = iv;

                while (true)
                {
                    // Gửi tin nhắn đến server
                    Console.Write("Client: ");
                    string message = Console.ReadLine();
                    byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                    ICryptoTransform encryptor = des.CreateEncryptor();
                    byte[] encryptedMessage = encryptor.TransformFinalBlock(messageBytes, 0, messageBytes.Length);
                    string encryptedMessageString = Convert.ToBase64String(encryptedMessage);
                    stream.Write(Encoding.ASCII.GetBytes(encryptedMessageString), 0, encryptedMessageString.Length);

                    // Nhận tin nhắn từ server
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    if (bytesRead == 0) break; // Kết thúc nếu server ngắt kết nối

                    byte[] encryptedData = Convert.FromBase64String(Encoding.ASCII.GetString(data, 0, bytesRead));
                    ICryptoTransform decryptor = des.CreateDecryptor();
                    byte[] decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    string receivedMessage = Encoding.ASCII.GetString(decryptedData);
                    Console.WriteLine("Server: " + receivedMessage);
                }
            }

            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
