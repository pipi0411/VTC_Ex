using System.Net.Dns;
using System;

public class Lab1{
//  Dưới đây là đoạn mã mẫu để hiển thị địa chỉ IP của máy:
// static void Main(string[] args){
//     string name = args.Length < 1 ? Dns.GetHostName() : args[0];
//     try{
//         IPAddress[] ips = Dns.Resolve(name).AddressList;
//         foreach(IPAddress ip in ips){
//             Console.WriteLine("{0} : {1}", name, ip);
//         }
//     }
//     catch(Exception e){
//         Console.WriteLine(e.Message);
//     }
// }

  // Tạo máy chủ TCP
  static void Main(string[] args){
    IPAddress address = IPAddress.Parse("10.10.51.23");
    TcpListener server = new TcpListener(address, 1234);
    Console.WriteLine("Server is running on port 1234");
    server.Start();
    while(true){
        
    }
  }

}