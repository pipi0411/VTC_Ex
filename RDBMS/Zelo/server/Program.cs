using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

class Server
{
    static string connectionString = "server=127.0.0.1;uid=root;password=Duyanh0612;database=zelo";
    static ConcurrentDictionary<string, int> activeUsers = new ConcurrentDictionary<string, int>(); // Thread-safe storage for online users
    static HMACSHA256Algorithm algorithm = new HMACSHA256Algorithm(); 
    static IJsonSerializer serializer = new JsonNetSerializer();
    static IDateTimeProvider provider = new UtcDateTimeProvider(); 
    static IJwtValidator validator = new JwtValidator(serializer, provider);
    static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder(); 
    static IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
    static IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 1234);
        server.Start();
        Console.WriteLine("Server is listening...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");
            HandleClient(client);
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Request from client: {request}");

        string[] parts = request.Split("|");
        if (parts.Length < 3)
        {
            SendResponse(stream, "INVALID REQUEST! Missing parameters.");
            client.Close();
            return;
        }

        if (request.StartsWith("REGISTER"))
        {
            string username = parts[1];
            string password = parts[2];
            if (RegisterUser(username, password))
            {
                SendResponse(stream, "REGISTER SUCCESS!");
            }
            else
            {
                SendResponse(stream, "REGISTER FAIL! Username is already taken.");
            }
        }
        else if (request.StartsWith("LOGIN"))
        {
            string username = parts[1];
            string password = parts[2];
            if (LoginUser(username, password, out string token))
            {
                SendResponse(stream, $"LOGIN SUCCESS!|{token}");
                activeUsers[username] = GetUserId(username);
            }
            else
            {
                SendResponse(stream, "LOGIN FAIL! Invalid username or password.");
            }
        }
        else if (request.StartsWith("SEND_MESSAGE"))
        {
            if (parts.Length < 5)
            {
                SendResponse(stream, "SEND MESSAGE FAIL! Missing parameters.");
                client.Close();
                return;
            }

            string sender = parts[1];
            string receiver = parts[2];
            string message = parts[3];
            string token = parts[4];

            if (ValidateToken(token, out string validateUsername))
            {
                if (activeUsers.ContainsKey(validateUsername))
                {
                    if (ValidateUserExists(receiver))
                    {
                        try
                        {
                            SaveMessage(sender, receiver, message);
                            SendResponse(stream, "SEND MESSAGE SUCCESS!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error while saving message: {ex.Message}");
                            SendResponse(stream, "SEND MESSAGE FAIL! Server error.");
                        }
                    }
                    else
                    {
                        SendResponse(stream, "SEND MESSAGE FAIL! Receiver does not exist.");
                    }
                }
                else
                {
                    SendResponse(stream, "SEND MESSAGE FAIL! Sender is not online.");
                }
            }
            else
            {
                SendResponse(stream, "SEND MESSAGE FAIL! Invalid token.");
            }
        }
        else
        {
            SendResponse(stream, "INVALID REQUEST!");
        }
        client.Close();
    }

    static bool RegisterUser(string username, string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string sql = "INSERT INTO users (username, password) VALUES (@username, @password)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during user registration: {ex.Message}");
                    return false;
                }
            }
        }
    }

    static bool LoginUser(string username, string password, out string token)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT password FROM users WHERE username = @username";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                var storedPassword = cmd.ExecuteScalar()?.ToString();
                if (storedPassword != null && BCrypt.Net.BCrypt.Verify(password, storedPassword))
                {
                    token = GenerateJWT(username);
                    return true;
                }
                else
                {
                    token = null;
                    return false;
                }
            }
        }
    }

    static string GenerateJWT(string username)
    {
        var payload = new Dictionary<string, object>
        {
            { "username", username },
            { "exp", DateTime.UtcNow.AddHours(1).ToString() }
        };
        return encoder.Encode(payload, "Duyanh0612");
    }

    static bool ValidateToken(string token, out string username)
    {
        try
        {
            var payload = decoder.DecodeToObject<Dictionary<string, object>>(token, "Duyanh0612", verify: true);
            username = payload["username"].ToString();
            return DateTime.Parse(payload["exp"].ToString()) > DateTime.UtcNow;
        }
        catch
        {
            username = null;
            return false;
        }
    }

    static void SaveMessage(string sender, string receiver, string message)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string senderIdQuery = "SELECT id FROM users WHERE username = @sender";
            string receiverIdQuery = "SELECT id FROM users WHERE username = @receiver";

            int? senderId = null;
            int? receiverId = null;

            using (var senderCmd = new MySqlCommand(senderIdQuery, conn))
            {
                senderCmd.Parameters.AddWithValue("@sender", sender);
                senderId = senderCmd.ExecuteScalar() as int?;
            }

            using (var receiverCmd = new MySqlCommand(receiverIdQuery, conn))
            {
                receiverCmd.Parameters.AddWithValue("@receiver", receiver);
                receiverId = receiverCmd.ExecuteScalar() as int?;
            }

            if (senderId == null || receiverId == null)
            {
                throw new Exception("Sender or receiver does not exist.");
            }

            string sql = "INSERT INTO messages (sender_id, receiver_id, message) VALUES (@senderId, @receiverId, @message)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@senderId", senderId);
                cmd.Parameters.AddWithValue("@receiverId", receiverId);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.ExecuteNonQuery();
            }
        }
    }

    static bool ValidateUserExists(string username)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM users WHERE username = @username";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }

    static void SendResponse(NetworkStream stream, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }

    static int GetUserId(string username)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT id FROM users WHERE username = @username";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
