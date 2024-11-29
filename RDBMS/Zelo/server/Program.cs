using System;
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
    static Dictionary<string, int> activeUsers = new Dictionary<string, int>();// Luu tru cac user dang online
    static IJWTAlgorithm algorithm = new HMACSHA256Algorithm(); // Ma hoa JWT
    static IJsonSerializer serializer = new JsonNetSerializer(); // Serialize JWT
    static IDateTimeProvider provider = new UtcDateTimeProvider(); // Thoi gian hien tai
    static IJwtValidator validator = new JwtValidator(serializer, provider); // Validate JWT
    static IJwtEncoder encoder = new JwtEncoder(algorithm, serializer); // Encode JWT 
    static IJwtDecoder decoder = new JwtDecoder(serializer, validator,algorithm); // Decode JWT

    static void Main(){
        TcpListener server = new TcpListener(IPAddress.Any,1234);
        server.Start();
        Console.WriteLine("Server is listening...");

        while(true){
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected !");
            HandleClient(client);
        }
    }

    static void HandleClient(TcpClient client){
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer,0,buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Request from client: {request}");

        if(request.StartsWith("REGISTER"))
        {
            string[] parts = request.Split("|");
            string username = parts[1];
            string password = parts[2];
            if (RegisterUser(username, password)){
                SendResponse(stream, "REGISTER SUCCESS!");
            }else{
                SendResponse(stream, "REGISTER FAIL!");
            }
        }
    }
}