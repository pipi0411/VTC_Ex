using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using BCrypt.Net;

namespace ChatApp
{
    public class DbHelper
    {
        private string connectionString = "server=127.0.0.1;uid=root;password=Duyanh0612;database=chatapp";

        // Register user
        public bool RegisterUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registered successfully.");
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        Console.WriteLine("Username already exists.");
                    }
                    else
                    {
                        Console.WriteLine("Error registering user: " + ex.Message);
                    }
                    return false;
                }
            }
        }

        // Authenticate user
        public bool AuthenticateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Password FROM Users WHERE Username = @Username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    conn.Open();
                    string storedPassword = cmd.ExecuteScalar()?.ToString();
                    if (storedPassword != null)
                    {
                        return BCrypt.Net.BCrypt.Verify(password, storedPassword);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error authenticating user: " + ex.Message);
                }
                return false;
            }
        }

        // Save message to database
        public bool SaveMessage(string username, string message)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO Messages (SenderId, MessageText)
                    VALUES (
                        (SELECT UserId FROM Users WHERE Username = @Username),
                        @MessageText
                    )";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@MessageText", message);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Message saved successfully.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving message: " + ex.Message);
                    return false;
                }
            }
        }

        // Retrieve chat history
        public List<string> GetChatHistory()
        {
            List<string> messages = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT u.Username, m.MessageText, m.Timestamp
                    FROM Messages m
                    JOIN Users u ON m.SenderId = u.UserId
                    ORDER BY m.Timestamp";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = $"{reader["Timestamp"]} - {reader["Username"]}: {reader["MessageText"]}";
                            messages.Add(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving chat history: " + ex.Message);
                }
            }
            return messages;
        }
    }
}
