/*Phần 1 : Đóng gói (Encapsulation)
1. Lớp sinh viên */

using System;
// public class SinhVien {
//     private string maSV;
//     private string hoTen;
//     private double diemTB;

//     // Phương thức khởi tạo
//     public SinhVien(string maSV, string hoTen, double diemTB){
//         this.maSV = maSV;
//         this.hoTen = hoTen;
//         this.DiemTB = diemTB;
//     }
//     // Property MaSV
//     public string MaSV{
//         get { return maSV; }
//         set { maSV = value;}
//     }
//     // Property HoTen
//     public string HoTen{
//         get { return hoTen; }
//         set { hoTen = value; }
//     }
//     // Property DiemTB kiểm tra giá trị hợp lệ
//       public double DiemTB
//     {
//         get { return diemTB; }
//         set
//         {
//             if (value >= 0 && value <= 10)
//                 diemTB = value;
//             else
//                 throw new ArgumentException("Điểm TB phải từ 0 đến 10.");
//         }
//     }
//     // Phương thức in thông tin sinh viên
//     public void Display(){
//         Console.WriteLine($"Ma SV: {maSV}, Ho ten: {hoTen}, Diem TB: {diemTB}");
//     }

// }
// public class Program{
//         public static void Main(){
//             try {
//                 SinhVien sv = new SinhVien("SV01", "Nguyen Van A", 8.5);
//                 sv.Display();
//             }catch (Exception ex){
//                 Console.WriteLine(ex.Message);
//             }
//         }
//     }

/*2. Lớp hình chữ nhật */

public class HinhChuNhat{
    private double width;
    private double height;

    // Phương thức khởi tạo
    public HinhChuNhat(double width, double height){
        this.width = width;
        this.height = height;
    }

    // Property ChieuDai
    public double Width{
        get { return width; }
        set { 
            if (value > 0){
                width = value;
            }else{
                throw new ArgumentException("Chiều dài phải lớn hơn 0.");
            }
        }
    }

    // Property ChieuRong
    public double Height{
        get { return height; }
        set { 
            if (value > 0){
                height = value;
            }else{
                throw new ArgumentException("Chiều rộng phải lớn hơn 0.");
            }
         }
    }
    // Phương thức tính diện tích
    public double Area(){
        return width * height;
    }
    // Phương thức tính chu vi
    public double Perimeter(){
        return (width + height) * 2;
    }
    // Phương thức in thông tin
    public void Display(){
        Console.WriteLine($"Chiều dài: {width}, Chiều rộng: {height}, Diện tích: {Area()}, Chu vi: {Perimeter()}");
    }
}

public class Program {
    public static void Main(){
        try {
            HinhChuNhat hcn = new HinhChuNhat(4, 5);
            hcn.Display();
        }catch (Exception ex){
            Console.WriteLine(ex.Message);
        }
    }
}