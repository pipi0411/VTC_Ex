using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using ChatApp;

class ChatServer
{
    static TcpListener listener;
    static List<TcpClient> clients = new List<TcpClient>();
    static Dictionary<TcpClient, string> authenticatedUsers = new Dictionary<TcpClient, string>();
    static DbHelper dbHelper = new DbHelper();
    static byte[] key = Encoding.ASCII.GetBytes("1234567890abcdef");
    static byte[] iv = Encoding.ASCII.GetBytes("1234567890abcdef");

    static void ClearInput()
    {
        while (Console.In.Peek() != -1 && Console.In.Peek() != '\n')
        {
            Console.In.Read();
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter port: ");
        int port = int.Parse(Console.ReadLine());

        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server started on port {port}. Waiting for connections...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            clients.Add(client);
            Console.WriteLine("Client connected.");

            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client);
        }
    }

    static void HandleClient(object clientObj)
{
    TcpClient client = (TcpClient)clientObj;
    NetworkStream stream = client.GetStream();
    byte[] buffer = new byte[1024];
    int bytesRead;

    try
    {
        // Yêu cầu người dùng chọn hành động
        stream.Write(Encoding.UTF8.GetBytes("Type 'register', 'login', or 'history': "));
        bytesRead = stream.Read(buffer, 0, buffer.Length);
        string choice = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim().ToLower();

        if (choice == "register")
        {
            HandleRegistration(client, stream);
            return; // Kết thúc sau khi đăng ký
        }
        else if (choice == "login")
        {
            bool loginSuccessful = HandleLogin(client, stream);
            if (!loginSuccessful) return; // Kết thúc nếu đăng nhập thất bại
        }
        else if (choice == "history")
        {
            SendChatHistory(stream);
            client.Close();
            return; // Kết thúc sau khi gửi lịch sử
        }

        // Sau khi đăng nhập thành công, server chuyển sang chế độ nhận/gửi tin nhắn
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = DecryptMessage(buffer, bytesRead);
            string username = authenticatedUsers[client];
            Console.WriteLine($"{username}: {message}");

            dbHelper.SaveMessage(username, message);

            byte[] encryptedMessage = EncryptMessage($"{username}: {message}");
            BroadcastMessage(encryptedMessage, client);
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine("Client disconnected unexpectedly: " + ex.Message);
    }
    finally
    {
        if (authenticatedUsers.ContainsKey(client))
        {
            Console.WriteLine($"User {authenticatedUsers[client]} disconnected.");
            authenticatedUsers.Remove(client);
        }

        clients.Remove(client);
        client.Close();
        Console.WriteLine("Connection closed.");
    }
}

    static void HandleRegistration(TcpClient client, NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            stream.Write(Encoding.UTF8.GetBytes("Enter username: "));
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string username = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            stream.Write(Encoding.UTF8.GetBytes("Enter password: "));
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string password = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            if (dbHelper.RegisterUser(username, password))
            {
                stream.Write(Encoding.UTF8.GetBytes("Registration successful. Type 'login' to log in.\n"));
                Console.WriteLine($"User {username} registered successfully.");
            }
            else
            {
                stream.Write(Encoding.UTF8.GetBytes("Registration failed. Username may already exist.\n"));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during registration: " + ex.Message);
        }
    }

    static bool HandleLogin(TcpClient client, NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            stream.Write(Encoding.UTF8.GetBytes("Enter username: "));
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string username = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            stream.Write(Encoding.UTF8.GetBytes("Enter password: "));
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string password = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            if (dbHelper.AuthenticateUser(username, password))
            {
                authenticatedUsers[client] = username;
                stream.Write(Encoding.UTF8.GetBytes("Login successful! You can now send messages.\n"));
                Console.WriteLine($"User {username} logged in.");
                return true;
            }
            else
            {
                stream.Write(Encoding.UTF8.GetBytes("Login failed. Invalid username or password.\n"));
                return false;
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error during login: " + ex.Message);
            return false;
        }
    }

    static void SendChatHistory(NetworkStream stream)
    {
        List<string> messages = dbHelper.GetChatHistory();
        foreach (string message in messages)
        {
            stream.Write(Encoding.UTF8.GetBytes(message + "\n"));
        }
    }

    static void BroadcastMessage(byte[] message, TcpClient sender)
    {
        foreach (TcpClient client in clients)
        {
            if (client != sender)
            {
                NetworkStream stream = client.GetStream();
                try
                {
                    stream.Write(message, 0, message.Length);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error sending message to a client: " + ex.Message);
                }
            }
        }
    }

    static byte[] EncryptMessage(string message)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            return encryptor.TransformFinalBlock(messageBytes, 0, messageBytes.Length);
        }
    }

    static string DecryptMessage(byte[] encryptedMessage, int length)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Kiểm tra xem độ dài dữ liệu có phải là bội số của kích thước khối hay không
            if (length % aes.BlockSize != 0)
            {
                throw new CryptographicException("The input data is not a complete block.");
            }

            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedMessage, 0, length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
