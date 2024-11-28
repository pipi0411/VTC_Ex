using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

class ChatClient
{
    static TcpClient client;
    static NetworkStream stream;
    static byte[] key = Encoding.ASCII.GetBytes("1234567890abcdef");
    static byte[] iv = Encoding.ASCII.GetBytes("1234567890abcdef");
static void ClearInput()
{
    while (Console.In.Peek() != -1)
    {
        char c = (char)Console.In.Read();
        if (!char.IsWhiteSpace(c)) // Nếu ký tự không phải là dấu cách hoặc xuống dòng
        {
            Console.Out.Write(c);  // In ra lại ký tự
        }
    }
}

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter host: ");
            string host = Console.ReadLine();
            Console.Write("Enter port: ");
            int port = int.Parse(Console.ReadLine());

            client = new TcpClient(host, port);
            stream = client.GetStream();

            Console.WriteLine("Connected to server.");
            Console.Write("Type 'register', 'login', or 'history': ");
            string choice = Console.ReadLine().ToLower();
            SendToServer(choice);

            if (choice == "register")
            {
                Register();
            }
            else if (choice == "login")
            {
                Login();
            }
            else if (choice == "history")
            {
                ViewHistory();
                return;
            }

            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "exit")
                {
                    client.Close();
                    Environment.Exit(0);
                }

                byte[] encryptedMessage = EncryptMessage(message);
                stream.Write(encryptedMessage, 0, encryptedMessage.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        SendToServer(username);

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        ClearInput();
        SendToServer(password);

        ReceiveServerResponse();
    }

static void Login()
{
    Console.Write("Enter username: ");
    string username = Console.ReadLine();
    SendToServer(username);

    Console.Write("Enter password: ");
    string password = Console.ReadLine();
    ClearInput();
    SendToServer(password);

    ReceiveServerResponse();

    // Chuyển sang chế độ gửi/nhận tin nhắn
    Console.WriteLine("You can now send messages. Type 'exit' to quit.");
    Thread receiveThread = new Thread(ReceiveMessage);
    receiveThread.Start();

    while (true)
    {
        string message = Console.ReadLine();
        if (message.ToLower() == "exit")
        {
            client.Close();
            Environment.Exit(0);
        }

        byte[] encryptedMessage = EncryptMessage(message);
        stream.Write(encryptedMessage, 0, encryptedMessage.Length);
    }
}


    static void ViewHistory()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string history = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine(history);
        }
    }

    static void SendToServer(string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }

static void ReceiveServerResponse()
{
    byte[] buffer = new byte[1024];
    int bytesRead;

    try
    {
        bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        Console.WriteLine(response); // Hiển thị phản hồi từ server

        // Thoát nếu đăng nhập thất bại
        if (response.Contains("Login failed"))
        {
            Console.WriteLine("Exiting program due to failed login.");
            Environment.Exit(0);
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine("Error reading response from server: " + ex.Message);
    }
}


    static void ReceiveMessage()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Kiểm tra nếu dữ liệu nhận được không phải là bội số của 16 byte
                if (bytesRead % 16 != 0)
                {
                    Console.WriteLine("Received incomplete block from server.");
                    continue;
                }

                string message = DecryptMessage(buffer, bytesRead);
                Console.WriteLine(message);
            }
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine("Decryption error: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("Connection error: " + ex.Message);
        }
        finally
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            Console.WriteLine("Disconnected from server.");
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

            if (length % aes.BlockSize != 0)
            {
                throw new CryptographicException("The input data is not a complete block.");
            }

            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedMessage, 0, length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
