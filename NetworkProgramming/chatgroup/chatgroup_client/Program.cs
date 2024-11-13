using System;
using System.Net.Sockets;
using System.Text;

namespace SimpleChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 8080);
            Console.WriteLine("Connected to server");

            NetworkStream stream = client.GetStream();
            string username = "User" + new Random().Next(1000);

            // Gửi tên người dùng đến server
            byte[] usernameBuffer = Encoding.ASCII.GetBytes(username);
            stream.Write(usernameBuffer, 0, usernameBuffer.Length);

            // Bắt đầu thread để nhận tin nhắn từ server
            var receiveThread = new System.Threading.Thread(ReceiveMessages);
            receiveThread.Start(stream);

            while (true)
            {
                string message = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        static void ReceiveMessages(object obj)
        {
            NetworkStream stream = (NetworkStream)obj;
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
            }
        }
    }
}
