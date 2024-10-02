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
Console.WriteLine("Nhap so can kiem tra: ");
int n = int.Parse(Console.ReadLine());
bool isPrime = true;

if (n < 2){
        isPrime = false;
}

for (int i = 2; i <= Math.Sqrt(n); i++){
        if (n % i == 0){
                isPrime = false;
                break;
        }
}

if (isPrime){
        Console.WriteLine(n + " la so nguyen to.");
}else{
        Console.WriteLine(n + " khong phai la so nguyen to.");
}


