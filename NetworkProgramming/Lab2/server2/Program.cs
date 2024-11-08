using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;

namespace NetworkApplication{
    class Program{
        static async Task Main(string[] args){
            int choice = 0;
            do{
                Console.WriteLine("====ỨNG DỤNG MẠNG TỔNG HỢP====");
                Console.WriteLine("1. Kiểm tra kết nối mạng");
                Console.WriteLine("2. Gửi yêu cầu HTTP GET");
                Console.WriteLine("3. Gửi yêu cầu HTTP POST");
                Console.WriteLine("4. Gửi email");
                Console.WriteLine("5. Đọc email");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn chức năng(1-6): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        CheckInternetConnection();
                        break;
                    case 2:
                        await SendHttpGetRequest();
                        break;
                    case 3:
                        await SendHttpPostRequest();
                        break;
                    case 4:
                        SendEmail();
                        break;
                    case 5:
                        ReadEmail();
                        break;
                    case 6:
                        Console.WriteLine("Kết thúc chương trình!");
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ!");
                        break;
                }
                Console.WriteLine();
            }while (choice != 6);
        }

        // Kiểm tra kết nối mạng
        static void CheckInternetConnection(){
            try{
                Ping ping = new Ping();
                Console.Write("Nhập tên miền để kiểm tra kết nối Internet: ");
                string host = Console.ReadLine();
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = ping.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Máy tính có kết nối Internet.");
                }else{
                    Console.WriteLine("Máy tính không có kết nối Internet.");
                }
            }
            catch (Exception e){
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
        // Gửi yêu cầu HTTP GET
        static async Task SendHttpGetRequest(){
            Console.Write("Nhập URL để gửi yêu cầu GET: ");
            string url = Console.ReadLine();
            using (HttpClient client = new HttpClient()){
                try{
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công không
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Kết quả: " + responseBody);
                }
                catch (HttpRequestException e){
                    Console.WriteLine("Lỗi yêu cầu: " + e.Message);
                }
                catch (Exception e){
                    Console.WriteLine("Lỗi chung: " + e.Message);
                }
            }
        }
        // Gửi yêu cầu HTTP POST
        static async Task SendHttpPostRequest(){
            Console.Write("Nhập URL để gửi yêu cầu POST: ");
            string url = Console.ReadLine();
            Console.Write("Nhập dữ liệu JSON: ");
            string jsonData = Console.ReadLine();

            using (HttpClient client = new HttpClient()){
                try{
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode(); // Kiểm tra trạng thái phản hồi
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Kết quả: " + responseBody);
                }
                catch (HttpRequestException e){
                    Console.WriteLine("Lỗi yêu cầu: " + e.Message);
                }
                catch (Exception e){
                    Console.WriteLine("Lỗi chung: " + e.Message);
                }
            }
        }

        // Gửi email
        static void SendEmail(){
            try{
                Console.Write("Nhập email người nhận: ");
                string to = Console.ReadLine();
                Console.Write("Nhập chủ để: ");
                string subject = Console.ReadLine();
                Console.Write("Nhập nội dung: ");
                string body = Console.ReadLine();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@example.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                Console.Write("Bạn có muốn đính kèm tệp tin? (y/n): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y"){
                    Console.Write("Nhập đường dẫn tệp tin: ");
                    string filePath = Console.ReadLine();
                    if (System.IO.File.Exists(filePath)){
                        Attachment attachment = new Attachment(filePath);
                        mail.Attachments.Add(attachment);
                    }else{
                        Console.WriteLine("Tệp tin không tồn tại!");
                    }
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Cổng mặc định của Gmail
                    Credentials = new NetworkCredential("your-email@example.com",
                    "your-password"),
                    EnableSsl = true // Kích hoạt giao thức SSL
                };
                smtp.Send(mail);
                Console.WriteLine("Email đã được gửi thành công!");
            }
            catch (SmtpFailedRecipientsException e){
                foreach(SmtpFailedRecipientException t in e.InnerExceptions){
                    SmtpStatusCode status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable){
                        Console.WriteLine("Thử lại sau vài phút.");
                    }else{
                        Console.WriteLine("Lỗi: " + t.FailedRecipient);
                    }
                }
            }
            catch (SmtpException e){
                Console.WriteLine("Lỗi STMP: " + e.StatusCode + e.Message);
            }
            catch (Exception e){
                Console.WriteLine("Lỗi Khi Gửi EMail: " + e.Message);
            }
        }

        // Đọc email
        static void ReadEmail(){
            try{
                using (var client = new ImapClient()){
                    client.Connect("imap.gmail.com", 993,
                    MailKit.Security.SecureSocketOptions.SslOnConnect);
                    client.Authenticate("your-email@example.com", "your-password");

                    // Mở thư mục Inbox
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    Console.WriteLine("Tổng số email: " + inbox.Count);

                    // Đọc email
                    for (int i = 0; i < inbox.Count; i++){
                        var message = inbox.GetMessage(i);
                        Console.WriteLine("===============================");
                        Console.WriteLine("Email số: " + (i + 1));
                        Console.WriteLine("Chủ đề: " + message.Subject);
                        Console.WriteLine("Người gửi: " + message.From);
                        Console.WriteLine("Ngày gửi: " + message.Date);
                        Console.WriteLine("Nội dung: " + message.TextBody);
                    }
                    client.Disconnect(true); // Đóng kết nối
                }
            }
            catch (Exception e){
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
    }
}