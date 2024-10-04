
/*1. Khai báo và khởi tạo mảng số nguyên
Bài tập: Khai báo một mảng số nguyên và khởi tạo các giá trị từ 1 đến 10.*/

using System.Text.RegularExpressions;

int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

/*2. Truy cập phần tử trong mảng
Bài tập: Lấy phần tử thứ 3 trong mảng `numbers`.*/
int thirdElement = numbers[2];

/*3. Cập nhật giá trị mảng
Bài tập: Cập nhật giá trị phần tử thứ 5 trong mảng thành 20.*/
numbers[4] = 20;

/*4. Duyệt mảng bằng vòng lặp
Bài tập: In ra tất cả các phần tử trong mảng `numbers`.*/
for (int i = 0; i < numbers.Length; i++){
    Console.WriteLine(numbers[i]);
}

/*5. Tính tổng các phần tử trong mảng
Bài tập: Tính tổng tất cả các phần tử trong mảng `numbers`.*/
int sum = 0;
for (int i = 0; i < numbers.Length; i++){
    sum += numbers[i];
}
Console.WriteLine(sum);

/*6. Tìm giá trị lớn nhất trong mảng
Bài tập: Tìm giá trị lớn nhất trong mảng `numbers`.*/
int max = numbers[0];
for (int i = 1; i < numbers.Length; i++){
    if (numbers[i] > max){
        max = numbers[i];
    }
}
Console.WriteLine(max);

/*7. Đảo ngược chuỗi
Bài tập: Viết chương trình đảo ngược chuỗi "Hello World".*/
string str = "Hello World";
char[] arr = str.ToCharArray(); // chuyển chuỗi thành mảng ký tự
Array.Reverse(arr); // đảo ngược mảng
string reversedStr = new string(arr); // chuyển mảng ký tự thành chuỗi
Console.WriteLine(reversedStr); // in

/*8. So sánh hai chuỗi
Bài tập: So sánh hai chuỗi "apple" và "banana".*/
int result = string.Compare("apple", "banana"); // so sánh hai chuỗi
if (result < 0){ // kết quả < 0 nếu chuỗi thứ nhất nhỏ hơn chuỗi thứ hai
    Console.WriteLine("apple < banana");
}else if (result > 0){ // kết quả > 0 nếu chuỗi thứ nhất lớn hơn chuỗi thứ hai
    Console.WriteLine("apple > banana");
} else { // kết quả = 0 nếu hai chuỗi bằng nhau
    Console.WriteLine("apple = banana");
}

/*9. Kết hợp chuỗi
Bài tập: Kết hợp chuỗi "Hello" và "World". */
// string combined = string.Concat("Hello", " World");
string combined = "Hello" + " " + "World";
Console.WriteLine(combined);

/*10. Kiểm tra chuỗi con
Bài tập: Kiểm tra chuỗi "test" có tồn tại trong chuỗi "This is a test".*/
bool contains = "This is a test".Contains("test"); // kiểm tra chuỗi con trong chuỗi lớn 
Console.WriteLine(contains);

/*11.Lấy chuỗi con
Bài tập: Lấy chuỗi con từ vị trí thứ 5 trong chuỗi "Hello World".*/
string subStr = "Hello World".Substring(5); // lấy chuỗi con từ vị trí 5 đến hết
Console.WriteLine(subStr);

/*13. Sử dụng Enum
Bài tập: In ra giá trị tương ứng của `Days.Mon`.*/
int day = (int)Days.Mon; // ép kiểu enum sang int
Console.WriteLine(day); // sử dụng biến 'day'

/*12.Định nghĩa Enum
Bài tập: Tạo enum đại diện cho các ngày trong tuần. */
enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat } // enum ngày trong tuần

/*14. Biểu thức chính quy - Tìm chuỗi bắt đầu bằng ký tự 'S'
Bài tập: Tìm các từ bắt đầu bằng ký tự 'S' trong chuỗi "A Thousand Splendid Suns".*/
// Regex regex = new Regex(@"\bS\S*"); // biểu thức chính quy
// MatchCollection = regex.Matches("A Thousand Splendid Suns"); // tìm chuỗi bắt đầu bằng 'S'




