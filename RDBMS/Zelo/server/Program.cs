using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

    // Thành phần cần thiết
    static IJsonSerializer serializer = new JsonNetSerializer();
    static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder(); // Base64 URL Encoder
    static IDateTimeProvider provider = new UtcDateTimeProvider();
    static HMACSHA256Algorithm algorithm = new HMACSHA256Algorithm(); // Thuật toán mã hóa
    static IJwtValidator validator = new JwtValidator(serializer, provider);
    static IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder); // Sửa ở đây
    static IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm); // Sửa ở đây

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
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        string request = reader.ReadLine();
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
            if (parts.Length < 4)
            {
                SendResponse(stream, "SEND MESSAGE FAIL! Missing parameters.");
                client.Close();
                return;
            }

            string receiver = parts[1];
            string message = parts[2];
            string token = parts[3];

            try
            {
                var payload = decoder.DecodeToObject<IDictionary<string, object>>(token, "Duyanh0612", verify: true);
                string sender = payload["sub"].ToString();

                if (activeUsers.ContainsKey(sender))
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating token: {ex.Message}");
                SendResponse(stream, "SEND MESSAGE FAIL! Invalid token.");
            }
        }
        else
        {
            SendResponse(stream, "INVALID REQUEST!");
        }
        client.Close();
    }

    static string GenerateToken(string username)
    {
        var payload = new
        {
            sub = username,
            exp = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds() // Set expiration to 1 hour from now
        };

        return encoder.Encode(payload, "Duyanh0612");
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
                string storedPassword = cmd.ExecuteScalar() as string;

                if (storedPassword != null && BCrypt.Net.BCrypt.Verify(password, storedPassword))
                {
                    token = GenerateToken(username);
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

    static bool ValidateToken(string token, out string username)
    {
        try
        {
            var payload = decoder.DecodeToObject<Dictionary<string, object>>(token, "Duyanh0612", verify: true);
            Console.WriteLine($"Decoded payload: {string.Join(", ", payload.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");

            username = payload["username"].ToString();
            DateTime expTime = DateTime.Parse(payload["exp"].ToString());
            Console.WriteLine($"Token expires at: {expTime}");

            if (expTime > DateTime.UtcNow)
            {
                return true; // Token hợp lệ
            }
            else
            {
                Console.WriteLine("Token has expired.");
                return false; // Token hết hạn
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error validating token: {ex.Message}");
            username = null;
            return false; // Token không hợp lệ
        }
    }

    static void SaveMessage(string sender, string receiver, string message)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string senderIdQuery = "SELECT userId FROM users WHERE username = @sender";
            string receiverIdQuery = "SELECT userId FROM users WHERE username = @receiver";

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
            string sql = "SELECT userId FROM users WHERE username = @username";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
