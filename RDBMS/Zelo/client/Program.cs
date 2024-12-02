using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static string serverAddress = "127.0.0.1";
    static int port = 1234;
    static string token = null;

    static void Main()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Choices: ");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            if (token != null)
            {
                Console.WriteLine("3. Send message");
                Console.WriteLine("4. Send file");
                Console.WriteLine("5. Logout");
            }

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    if (token != null) SendMessage();
                    else Console.WriteLine("Please login first!");
                    break;
                case "4":
                    if (token != null) SendFile();
                    else Console.WriteLine("Please login first!");
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string request = $"REGISTER|{username}|{password}";
        string response = SendRequest(request);
        Console.WriteLine(response);
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string request = $"LOGIN|{username}|{password}";
        string response = SendRequest(request);
        if (response != null && response.StartsWith("LOGIN SUCCESS!"))
        {
            token = response.Split("|")[1];
            Console.WriteLine("Login success!");
        }
        else
        {
            Console.WriteLine(response);
        }
    }

    static void SendMessage()
    {
        Console.Write("Enter receiver: ");
        string receiver = Console.ReadLine();
        Console.Write("Enter message: ");
        string message = Console.ReadLine();

        string request = $"SEND_MESSAGE|{receiver}|{message}|{token}";
        string response = SendRequest(request);
        Console.WriteLine(response);
    }

    static void SendFile()
    {
        Console.Write("Enter receiver: ");
        string receiver = Console.ReadLine();
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();
        Console.Write("Enter file content: ");
        string fileContent = Console.ReadLine();

        string request = $"SEND_FILE|{receiver}|{fileName}|{fileContent}|{token}";
        string response = SendRequest(request);
        Console.WriteLine(response);
    }

    static string SendRequest(string request)
    {
        try
        {
            using (TcpClient client = new TcpClient(serverAddress, port))
            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = Encoding.UTF8.GetBytes(request);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return response;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null;
        }
    }
}
