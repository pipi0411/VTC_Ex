using System;
using System.Threading;

class Program{
    static int count = 0;
    static object _lock = new object();
    static void Main(){
        // Khởi tạo một luồng đơn giản
        Thread t1 = new Thread(() => 
        { 
            // Luồng này sẽ ngủ 1 giây rồi in ra "Hello"
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        });
        Thread t2 = new Thread(() => {
            // Luồng này sẽ ngủ 1 giây rồi in ra "World"
            Thread.Sleep(3000);
            Console.WriteLine("World");
            });
        // Tham số truyền vào luồng t3
        Thread t3 = new Thread(PrintName);
        //Sử dụng khóa `lock` để tránh xung đột dữ liệu
        Thread t4 = new Thread(Increment);
        
        // Khởi động luồng
        t1.Start();
        t2.Start();
        t3.Start("John");
        t4.Start();

        // Chờ luồng kết thúc với "Join()"
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("Count: " + count);

        Console.ReadKey();
    }
    static void PrintName(object? name){ // Thêm '?' để chỉ định name có thể null
        Thread.Sleep(4000);
        if (name == null){
            Console.WriteLine("Name is null");
        }
        else{
            Console.WriteLine("Hello " + name);
        }
    }
    static void Increment(){
        for (int i = 0; i < 1000; i++){
            lock (_lock){
                count++;
            }
        }
    }
}