using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleChatServer
{
    class Program
    {
        private static List<TcpClient> _clients = new List<TcpClient>();
        private static TcpListener _listener;

        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(ipAddress, 8080);
            _listener.Start();
            Console.WriteLine("Server is running...");

            AcceptClients();
        }

        static void AcceptClients()
        {
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                _clients.Add(client);
                Console.WriteLine("Client connected");

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
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
                Console.WriteLine("Received: " + message);

                BroadcastMessage(message, client);
            }

            _clients.Remove(client);
            Console.WriteLine("Client disconnected");
            client.Close();
        }

        static void BroadcastMessage(string message, TcpClient senderClient)
        {
            foreach (TcpClient client in _clients)
            {
                if (client != senderClient)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes(message);
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
            }
        }
    }
}
