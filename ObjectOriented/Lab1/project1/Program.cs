//1 Tính tổng 2 số 
        // Console.WriteLine("Nhap so thu nhat: ");
        // int a = int.Parse(Console.ReadLine());

        // Console.WriteLine("Nhap so thu hai: ");
        // int b = int.Parse(Console.ReadLine());

        // int sum = a + b;
        // Console.WriteLine("Tong cua 2 so la: " + sum);


// 2. Kiểm tra số chẵn lẻ 
        // Console.WriteLine("Nhap so can kiem tra: ");
        // int number = int.Parse(Console.ReadLine());

        // if (number % 2 == 0){
        //         Console.WriteLine(number + " la so chan.");
        // }else{
        //         Console.WriteLine(number + " la so le.");
        // }

// 3. Tính diện tích hình chữ nhật 
        // Console.WriteLine("Nhap chieu dai: ");
        // float length = float.Parse(Console.ReadLine());

        // Console.WriteLine("Nhap chieu rong: ");
        // float width = float.Parse(Console.ReadLine());

        // float area = length * width;
        // Console.WriteLine("Dien tich hinh chu nhat la: " + area);

// 4. Tính tổng từ 1 đến n
// Console.WriteLine("Nhap so n: ");
// int n = int.Parse(Console.ReadLine());
// int sum = 0;

// for (int i = 1; i <= n ; i++){
//     sum += i;
// }

// Console.WriteLine("Tong tu 1 den " + n + " la: " + sum);

// 5. In các số chẵn tử 1 đến 100
// for (int i = 1; i <= 100; i++){
//     if (i % 2 == 0){
//         Console.WriteLine(i);
//     }
// }

//6. Tính giai thừa của n
// Console.WriteLine("Nhap so n: ");
// int n = int.Parse(Console.ReadLine());
// int factorial = 1;
// for (int i = 1; i <= n; i++){
//         factorial *= i;
// }
// Console.WriteLine("Giai thua cua " + n + " la: " + factorial);

//7. Kiểm tra số nguyên tố
// Console.WriteLine("Nhap so can kiem tra: ");
// int n = int.Parse(Console.ReadLine());
// bool isPrime = true;

// if (n < 2){
//         isPrime = false;
// }

// for (int i = 2; i <= Math.Sqrt(n); i++){
//         if (n % i == 0){
//                 isPrime = false;
//                 break;
//         }
// }

// if (isPrime){
//         Console.WriteLine(n + " la so nguyen to.");
// }else{
//         Console.WriteLine(n + " khong phai la so nguyen to.");
// }

//8. Tính tổng các phần tử trong mảng
// Console.WriteLine("Nhap so phan tu cua mang: ");
// int n = int.Parse(Console.ReadLine());
// int[] arr = new int[n];
// int sum = 0;

// for (int i = 0; i < n; i++){
//         Console.WriteLine("Nhap phan tu thu " + (i + 1) + ": ");
//         arr[i] = int.Parse(Console.ReadLine());
//         sum += arr[i];
// }
// Console.WriteLine("Tong cac phan tu trong mang la: " + sum);


//    Bài 9: In số Fibonacci từ 1 đến n
//    Nội dung học được: Vòng lặp `for`, chuỗi số Fibonacci.
   
//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());
//    int a = 0, b = 1, next;

//    for (int i = 1; i <= n; i++)
//    {
//        Console.WriteLine(a);
//        next = a + b;
//        a = b;
//        b = next;
//    }
   

// ---

//    Bài 10: Đếm số nguyên âm và dương trong mảng
//    Nội dung học được: Mảng, vòng lặp `foreach`, câu lệnh điều kiện.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int positiveCount = 0, negativeCount = 0;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());

//        if (array[i] > 0)
//            positiveCount++;
//        else if (array[i] < 0)
//            negativeCount++;
//    }

//    Console.WriteLine("Số lượng số dương: " + positiveCount);
//    Console.WriteLine("Số lượng số âm: " + negativeCount);
   

// ---

//    Bài 11: Kiểm tra chuỗi palindrome
//    Nội dung học được: Chuỗi, vòng lặp `for`, so sánh ký tự.
   
//    Console.WriteLine("Nhập chuỗi:");
//    string input = Console.ReadLine();
//    bool isPalindrome = true;

//    for (int i = 0; i < input.Length / 2; i++)
//    {
//        if (input[i] != input[input.Length - i - 1])
//        {
//            isPalindrome = false;
//            break;
//        }
//    }

//    if (isPalindrome)
//        Console.WriteLine("Chuỗi là palindrome.");
//    else
//        Console.WriteLine("Chuỗi không phải là palindrome.");
   

// ---

//    Bài 12: Tính tổng các chữ số của một số nguyên
//    Nội dung học được: Xử lý số nguyên, vòng lặp `while`.
   
//    Console.WriteLine("Nhập một số nguyên:");
//    int n = int.Parse(Console.ReadLine());
//    int sum = 0;

//    while (n != 0)
//    {
//        sum += n % 10;
//        n /= 10;
//    }

//    Console.WriteLine("Tổng các chữ số là: " + sum);
   

// ---

//    Bài 13: Tìm phần tử lớn nhất trong mảng
//    Nội dung học được: Mảng, vòng lặp `for`, so sánh giá trị.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int max = int.MinValue;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());

//        if (array[i] > max)
//            max = array[i];
//    }

//    Console.WriteLine("Phần tử lớn nhất là: " + max);
   

// ---

//    Bài 14: Đảo ngược một chuỗi
//    Nội dung học được: Chuỗi, vòng lặp `for`.
   
//    Console.WriteLine("Nhập

//  chuỗi:");
//    string input = Console.ReadLine();
//    string reversed = "";

//    for (int i = input.Length - 1; i >= 0; i--)
//    {
//        reversed += input[i];
//    }

//    Console.WriteLine("Chuỗi đảo ngược: " + reversed);
   

// ---

//    Bài 15: Kiểm tra năm nhuận
//    Nội dung học được: Câu lệnh điều kiện `if`, phép chia lấy dư.
   
//    Console.WriteLine("Nhập năm:");
//    int year = int.Parse(Console.ReadLine());

//    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
//        Console.WriteLine(year + " là năm nhuận.");
//    else
//        Console.WriteLine(year + " không phải là năm nhuận.");
   

// ---

//    Bài 16: Tính tổng dãy số lẻ từ 1 đến n
//    Nội dung học được: Vòng lặp `for`, điều kiện `if`.
   
//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());
//    int sum = 0;

//    for (int i = 1; i <= n; i++)
//    {
//        if (i % 2 != 0)
//        {
//            sum += i;
//        }
//    }

//    Console.WriteLine("Tổng dãy số lẻ từ 1 đến " + n + " là: " + sum);
   

// ---

//    Bài 17: Tính tổng các số chia hết cho 5 từ 1 đến n
//    Nội dung học được: Vòng lặp `for`, điều kiện `if`.
   
//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());
//    int sum = 0;

//    for (int i = 1; i <= n; i++)
//    {
//        if (i % 5 == 0)
//        {
//            sum += i;
//        }
//    }

//    Console.WriteLine("Tổng các số chia hết cho 5 từ 1 đến " + n + " là: " + sum);
   

// ---

//    Bài 18: Tìm số lớn thứ hai trong mảng
//    Nội dung học được: Mảng, vòng lặp `for`, so sánh giá trị.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int max = int.MinValue;
//    int secondMax = int.MinValue;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());

//        if (array[i] > max)
//        {
//            secondMax = max;
//            max = array[i];
//        }
//        else if (array[i] > secondMax && array[i] != max)
//        {
//            secondMax = array[i];
//        }
//    }

//    Console.WriteLine("Số lớn thứ hai là: " + secondMax);
   

// ---

//    Bài 19: Tính lũy thừa của một số
//    Nội dung học được: Phép tính lũy thừa, vòng lặp `for`.
   
//    Lời giải:
//    csharp
//    Console.WriteLine("Nhập cơ số:");
//    int baseNumber = int.Parse(Console.ReadLine());

//    Console.WriteLine("Nhập số mũ:");
//    int exponent = int.Parse(Console.ReadLine());

//    int result = 1;

//    for (int i = 0; i < exponent; i++)
//    {
//        result *= baseNumber;
//    }

//    Console.WriteLine(baseNumber + " ^ " + exponent + " = " + result);
   

// ---

//    Bài 20: Tính trung bình cộng các phần tử trong mảng
//    Nội dung học được: Mảng, vòng lặp `for`, phép chia.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int sum = 0;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());
//        sum += array[i];
//    }

//    double average = (double)sum / n;
//    Console.WriteLine("Trung bình cộng các phần tử là: " + average);
   

// ---

//    Bài 21: Tìm giá trị nhỏ nhất trong mảng
//    Nội dung học được: Mảng, vòng lặp `for`, so sánh giá trị.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int min = int.MaxValue;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());

//        if (array[i] < min)
//            min = array[i];
//    }

//    Console.WriteLine("Giá trị nhỏ nhất trong mảng là: " + min);
   

// ---

//    Bài 22: Đếm số lần xuất hiện của một phần tử trong mảng
//    Nội dung học được: Mảng, vòng lặp `foreach`, biến đếm.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());
//    }

//    Console.WriteLine("Nhập giá trị cần đếm:");
//    int value = int.Parse(Console.ReadLine());
//    int count = 0;

//    foreach (int num in array)
//    {
//        if (num == value)
//            count++;
//    }

//    Console.WriteLine("Số lần xuất hiện của " + value + " là: " + count);
   

// ---

//    Bài 23: Tính tổng các số chia hết cho 3 từ 1 đến n
//    Nội dung học được: Vòng lặp `for`, điều kiện `if`.
   
//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());
//    int sum = 0;

//    for (int i = 1; i <= n; i++)
//    {
//        if (i % 3 == 0)
//        {
//            sum += i;
//        }
//    }

//    Console.WriteLine("Tổng các số chia hết cho 3 từ 1 đến " + n + " là: " + sum);
   

// ---

//    Bài 24: Đảo ngược mảng
//    Nội dung học được: Mảng, vòng lặp `for`, đảo ngược mảng.
   
//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());
//    }

//    Console.WriteLine("Mảng sau khi đảo ngược là:");
//    for (int i = n - 1; i >= 0; i--)
//    {
//        Console.WriteLine(array[i]);
//    }
   

// ---

//    Bài 25: In tam giác số theo chiều giảm dần
//    Nội dung học được: Vòng lặp lồng nhau `for`.
   
//    Console.WriteLine("Nhập chiều cao của tam giác:");
//    int height = int.Parse(Console.ReadLine());

//    for (int i = height; i >= 1; i--)
//    {
//        for (int j = 1; j <= i; j++)
//        {
//            Console.Write(j + " ");
//        }
//        Console.WriteLine();
//    }
   

// ---

//    Bài 26: In bảng cửu chương của một số
//    Nội dung học được: Vòng lặp `for`, phép nhân.
   
//    Console.WriteLine("Nhập số cần in bảng cửu chương:");
//    int num = int.Parse(Console.ReadLine());

//    for (int i = 1; i <= 10; i++)
//    {
//        Console.WriteLine(num + " x " + i + " = " + num * i);
//    }
   

// ---

//    Bài 27: Tính số Fibonacci bằng đệ quy
//    Nội dung học được: Hàm đệ quy.
   
//    static int Fibonacci(int n)
//    {
//        if (n <= 1)
//            return n;
//        return Fibonacci(n - 1) + Fibonacci(n - 2);
//    }

//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine(Fibonacci(i));
//    }
   

// ---

//    Bài 28: Kiểm tra số hoàn hảo
//    Nội dung học được: Vòng lặp `for`, phép chia lấy dư.
   
//    Console.WriteLine("Nhập số n:");
//    int n = int.Parse(Console.ReadLine());
//    int sum = 0;

//    for (int i = 1; i < n; i++)
//    {
//        if (n % i == 0)
//        {
//            sum += i;
//        }
//    }

//    if (sum == n)
//        Console.WriteLine(n + " là số hoàn hảo.");
//    else
//        Console.WriteLine(n + " không phải là số hoàn hảo.");
   

// ---

//    Bài 29: Tìm số âm lớn nhất trong mảng
//    Nội dung học được: Mảng, vòng lặp `for`, so sánh giá trị.

//    Console.WriteLine("Nhập số phần tử của mảng:");
//    int n = int.Parse(Console.ReadLine());
//    int[] array = new int[n];
//    int maxNegative = int.MinValue;
//    bool foundNegative = false;

//    for (int i = 0; i < n; i++)
//    {
//        Console.WriteLine("Nhập phần tử thứ " + (i + 1) + ":");
//        array[i] = int.Parse(Console.ReadLine());

//        if (array[i] < 0 && array[i] > maxNegative)
//        {
//            maxNegative = array[i];
//            foundNegative = true;
//        }
//    }

//    if (foundNegative)
//        Console.WriteLine("Số âm lớn nhất là: " + maxNegative);
//    else
//        Console.WriteLine("Không có số âm nào trong mảng.");
   

// ---

//    Bài 30: Tính chu vi và diện tích hình tròn
//    Nội dung học được: Định nghĩa biến, sử dụng hằng số `Math.PI`, phép toán cơ bản.
   

//    Console.WriteLine("Nhập bán kính hình tròn:");
//    double radius = double.Parse(Console.ReadLine());

//    double perimeter = 2 * Math.PI * radius;
//    double area = Math.PI * radius * radius;

//    Console.WriteLine("Chu vi hình tròn là: " + perimeter);
//    Console.WriteLine("Diện tích hình tròn là: " + area);
   
