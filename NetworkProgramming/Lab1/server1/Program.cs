using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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

// static async Task<string> SendPostRequestAsync(string url, string jsonData) {
//     using (HttpClient client = new HttpClient()) {
//         try {
//             HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
//             HttpResponseMessage response = await client.PostAsync(url, content);
//             response.EnsureSuccessStatusCode(); // Kiểm tra trạng thái phản hồi

//             string responseBody = await response.Content.ReadAsStringAsync();
//             return responseBody;
//         } catch (HttpRequestException e) {
//             Console.WriteLine($"Request error: {e.Message}");
//             return null;
//         }
//     }
// }

// static void Main(string[] args){
//     // string url = "https://postman-echo.com/post";
//     // string jsonData = "{\"name\": \"John Doe\"}";

//     // string response = SendPostRequestAsync(url, jsonData).Result;
//     // Console.WriteLine(response);
// }

static async Task<string> GetHttpResponseAsync(string url) {
    using (HttpClient client = new HttpClient()) {
        try {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công không
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        } catch (HttpRequestException e) {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }
}

static void Main(string[] args){
    string url = "https://postman-echo.com/get?foo1=bar1&foo2=bar2";
    string response = GetHttpResponseAsync(url).Result;
    Console.WriteLine(response);
}
}