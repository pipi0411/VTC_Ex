// /*Phần 1 : Đóng gói (Encapsulation)
// 1. Lớp sinh viên */

// using System;
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

// /*2. Lớp hình chữ nhật */

// public class HinhChuNhat{
//     private double width;
//     private double height;

//     // Phương thức khởi tạo
//     public HinhChuNhat(double width, double height){
//         this.width = width;
//         this.height = height;
//     }

//     // Property ChieuDai
//     public double Width{
//         get { return width; }
//         set { 
//             if (value > 0){
//                 width = value;
//             }else{
//                 throw new ArgumentException("Chiều dài phải lớn hơn 0.");
//             }
//         }
//     }

//     // Property ChieuRong
//     public double Height{
//         get { return height; }
//         set { 
//             if (value > 0){
//                 height = value;
//             }else{
//                 throw new ArgumentException("Chiều rộng phải lớn hơn 0.");
//             }
//          }
//     }
//     // Phương thức tính diện tích
//     public double Area(){
//         return width * height;
//     }
//     // Phương thức tính chu vi
//     public double Perimeter(){
//         return (width + height) * 2;
//     }
//     // Phương thức in thông tin
//     public void Display(){
//         Console.WriteLine($"Chiều dài: {width}, Chiều rộng: {height}, Diện tích: {Area()}, Chu vi: {Perimeter()}");
//     }
// }

// public class Program {
//     public static void Main(){
//         try {
//             HinhChuNhat hcn = new HinhChuNhat(4, 5);
//             hcn.Display();
//         }catch (Exception ex){
//             Console.WriteLine(ex.Message);
//         }
//     }
// }

// ### **Bài Tập 3: Lớp Ngân Hàng**

// - **Nội dung:**  
//   Tạo lớp `TaiKhoan` với thuộc tính `SoDu` (double). Thêm phương thức `NapTien(double soTien)` và `RutTien(double soTien`), đảm bảo không cho phép `SoDu` bị âm. Đóng gói thuộc tính `SoDu`.

// - **Lời giải:**

// ```csharp
// using System;

// public class TaiKhoan
// {
//     private double soDu;

//     // Constructor
//     public TaiKhoan(double soDuBanDau)
//     {
//         SoDu = soDuBanDau;
//     }

//     // Property SoDu
//     public double SoDu
//     {
//         get { return soDu; }
//         private set
//         {
//             if (value >= 0)
//                 soDu = value;
//             else
//                 throw new InvalidOperationException("Số dư không thể âm.");
//         }
//     }

//     // Phương thức nạp tiền
//     public void NapTien(double soTien)
//     {
//         if (soTien > 0)
//         {
//             SoDu += soTien;
//             Console.WriteLine($"Đã nạp {soTien}. Số dư hiện tại: {SoDu}");
//         }
//         else
//         {
//             throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");
//         }
//     }

//     // Phương thức rút tiền
//     public void RutTien(double soTien)
//     {
//         if (soTien > 0)
//         {
//             if (SoDu >= soTien)
//             {
//                 SoDu -= soTien;
//                 Console.WriteLine($"Đã rút {soTien}. Số dư hiện tại: {SoDu}");
//             }
//             else
//             {
//                 throw new InvalidOperationException("Số dư không đủ để rút.");
//             }
//         }
//         else
//         {
//             throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
//         }
//     }

//     // Phương thức hiển thị số dư
//     public void HienThiSoDu()
//     {
//         Console.WriteLine($"Số dư hiện tại: {SoDu}");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         try
//         {
//             TaiKhoan tk = new TaiKhoan(1000);
//             tk.HienThiSoDu();
//             tk.NapTien(500);
//             tk.RutTien(300);
//             tk.RutTien(1500); // Sẽ gây lỗi
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }
// ```

// - **Nội dung học được:**
//   - Thực hành đóng gói dữ liệu và kiểm soát truy cập thông qua các phương thức.
//   - Xử lý các tình huống ngoại lệ khi thao tác với dữ liệu.
//   - Hiểu cách bảo vệ dữ liệu quan trọng khỏi việc thay đổi không kiểm soát.

// ---

// ### **Bài Tập 4: Lớp Xe**

// - **Nội dung:**  
//   Tạo lớp `Xe` với các thuộc tính `Hang` (string), `MauSac` (string), `Gia` (double). Đảm bảo các thuộc tính được đóng gói và thêm phương thức `HienThiThongTin()` để hiển thị thông tin xe.

// - **Lời giải:**

// ```csharp
// using System;

// public class Xe
// {
//     private string hang;
//     private string mauSac;
//     private double gia;

//     // Constructor
//     public Xe(string hang, string mauSac, double gia)
//     {
//         this.Hang = hang;
//         this.MauSac = mauSac;
//         this.Gia = gia;
//     }

//     // Property Hang
//     public string Hang
//     {
//         get { return hang; }
//         set
//         {
//             if (!string.IsNullOrEmpty(value))
//                 hang = value;
//             else
//                 throw new ArgumentException("Hãng xe không được để trống.");
//         }
//     }

//     // Property MauSac
//     public string MauSac
//     {
//         get { return mauSac; }
//         set
//         {
//             if (!string.IsNullOrEmpty(value))
//                 mauSac = value;
//             else
//                 throw new ArgumentException("Màu sắc không được để trống.");
//         }
//     }

//     // Property Gia
//     public double Gia
//     {
//         get { return gia; }
//         set
//         {
//             if (value >= 0)
//                 gia = value;
//             else
//                 throw new ArgumentException("Giá xe không thể âm.");
//         }
//     }

//     // Phương thức hiển thị thông tin xe
//     public void HienThiThongTin()
//     {
//         Console.WriteLine($"Hãng: {Hang}, Màu sắc: {MauSac}, Giá: {Gia:C}");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         try
//         {
//             Xe xe1 = new Xe("Toyota", "Đỏ", 500000000);
//             xe1.HienThiThongTin();

//             Xe xe2 = new Xe("Honda", "Xanh", 450000000);
//             xe2.HienThiThongTin();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }
// ```

// - **Nội dung học được:**
//   - Thực hành đóng gói các thuộc tính với kiểm tra dữ liệu.
//   - Hiển thị thông tin thông qua các phương thức lớp.
//   - Áp dụng định dạng tiền tệ trong hiển thị dữ liệu.

// ---

// ### **Bài Tập 5: Lớp Sản Phẩm**

// - **Nội dung:**  
//   Tạo lớp `SanPham` với thuộc tính `TenSP` (string), `Gia` (double), `SoLuong` (int). Thêm phương thức `TinhTongGiaTri()` để tính tổng giá trị tồn kho (Gia * SoLuong) và phương thức `HienThiThongTin()`.

// - **Lời giải:**

// ```csharp
// using System;

// public class SanPham
// {
//     private string tenSP;
//     private double gia;
//     private int soLuong;

//     // Constructor
//     public SanPham(string tenSP, double gia, int soLuong)
//     {
//         this.TenSP = tenSP;
//         this.Gia = gia;
//         this.SoLuong = soLuong;
//     }

//     // Property TenSP
//     public string TenSP
//     {
//         get { return tenSP; }
//         set
//         {
//             if (!string.IsNullOrEmpty(value))
//                 tenSP = value;
//             else
//                 throw new ArgumentException("Tên sản phẩm không được để trống.");
//         }
//     }

//     // Property Gia
//     public double Gia
//     {
//         get { return gia; }
//         set
//         {
//             if (value >= 0)
//                 gia = value;
//             else
//                 throw new ArgumentException("Giá sản phẩm không thể âm.");
//         }
//     }

//     // Property SoLuong
//     public int SoLuong
//     {
//         get { return soLuong; }
//         set
//         {
//             if (value >= 0)
//                 soLuong = value;
//             else
//                 throw new ArgumentException("Số lượng không thể âm.");
//         }
//     }

//     // Phương thức tính tổng giá trị tồn kho
//     public double TinhTongGiaTri()
//     {
//         return Gia * SoLuong;
//     }

//     // Phương thức hiển thị thông tin sản phẩm
//     public void HienThiThongTin()
//     {
//         Console.WriteLine($"Tên SP: {TenSP}, Giá: {Gia:C}, Số lượng: {SoLuong}, Tổng giá trị: {TinhTongGiaTri():C}");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         try
//         {
//             SanPham sp1 = new SanPham("Laptop", 20000000, 10);
//             sp1.HienThiThongTin();

//             SanPham sp2 = new SanPham("Điện thoại", 10000000, 20);
//             sp2.HienThiThongTin();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }
// ```

// - **Nội dung học được:**
//   - Kỹ năng đóng gói và quản lý nhiều thuộc tính trong một lớp.
//   - Tính toán dựa trên các thuộc tính lớp.
//   - Hiển thị dữ liệu với định dạng tiền tệ.

// ---

// ## **Phần 2: Kế thừa (Inheritance)**

// ### **Bài Tập 6: Lớp Động Vật Cơ Bản**

// - **Nội dung:**  
//   Tạo lớp cơ sở `DongVat` với thuộc tính `Ten` (string) và phương thức `An()`. Tạo lớp kế thừa `Cho` và `Meo`, mỗi lớp có thêm phương thức riêng `Keu()`.

// - **Lời giải:**

// ```csharp
// using System;

// // Lớp cơ sở DongVat
// public class DongVat
// {
//     public string Ten { get; set; }

//     // Constructor
//     public DongVat(string ten)
//     {
//         Ten = ten;
//     }

//     // Phương thức An
//     public void An()
//     {
//         Console.WriteLine($"{Ten} đang ăn.");
//     }
// }

// // Lớp kế thừa Cho
// public class Cho : DongVat
// {
//     // Constructor
//     public Cho(string ten) : base(ten)
//     {
//     }

//     // Phương thức Keu
//     public void Keu()
//     {
//         Console.WriteLine($"{Ten} đang sủa.");
//     }
// }

// // Lớp kế thừa Meo
// public class Meo : DongVat
// {
//     // Constructor
//     public Meo(string ten) : base(ten)
//     {
//     }

//     // Phương thức Keu
//     public void Keu()
//     {
//         Console.WriteLine($"{Ten} đang meo meo.");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         Cho cho = new Cho("Chó Cảnh");
//         cho.An();
//         cho.Keu();

//         Meo meo = new Meo("Mèo Nhà");
//         meo.An();
//         meo.Keu();
//     }
// }

// - **Nội dung học được:**
//   - Hiểu về khái niệm kế thừa trong OOP.
//   - Kế thừa thuộc tính và phương thức từ lớp cơ sở.
//   - Mở rộng lớp cơ sở bằng cách thêm các phương thức riêng trong lớp con.

// ---

// ### **Bài Tập 7: Lớp Nhân Viên và Quản Lý**

// - **Nội dung:**  
//   Tạo lớp `NhanVien` với thuộc tính `Ten` (string), `Luong` (double). Tạo lớp `QuanLy` kế thừa từ `NhanVien` và thêm thuộc tính `PhanQuyen` (string).

// - **Lời giải:**

// ```csharp
// using System;

// // Lớp cơ sở NhanVien
// public class NhanVien
// {
//     public string Ten { get; set; }
//     public double Luong { get; set; }

//     // Constructor
//     public NhanVien(string ten, double luong)
//     {
//         Ten = ten;
//         Luong = luong;
//     }

//     // Phương thức hiển thị thông tin
//     public virtual void HienThiThongTin()
//     {
//         Console.WriteLine($"Tên NV: {Ten}, Lương: {Luong:C}");
//     }
// }

// // Lớp kế thừa QuanLy
// public class QuanLy : NhanVien
// {
//     public string PhanQuyen { get; set; }

//     // Constructor
//     public QuanLy(string ten, double luong, string phanQuyen) : base(ten, luong)
//     {
//         PhanQuyen = phanQuyen;
//     }

//     // Override phương thức hiển thị thông tin
//     public override void HienThiThongTin()
//     {
//         base.HienThiThongTin();
//         Console.WriteLine($"Phân quyền: {PhanQuyen}");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         NhanVien nv = new NhanVien("Nguyễn Văn B", 15000000);
//         nv.HienThiThongTin();

//         QuanLy ql = new QuanLy("Trần Thị C", 25000000, "Quản lý phòng ban");
//         ql.HienThiThongTin();
//     }
// }
// ```

// - **Nội dung học được:**
//   - Sử dụng kế thừa để mở rộng lớp cơ sở.
//   - Sử dụng từ khóa `base` để truy cập thành phần của lớp cơ sở.
//   - Áp dụng tính đa hình thông qua việc ghi đè (override) phương thức trong lớp con.

// ---

// ### **Bài Tập 8: Lớp Hình Tròn và Hình Tròn Đặc Biệt**

// - **Nội dung:**  
//   Tạo lớp cơ sở `HinhTron` với thuộc tính `BanKinh` (double) và phương thức `TinhDienTich()`. Tạo lớp `HinhTronDacBiet` kế thừa từ `HinhTron` và thêm thuộc tính `MauSac` (string).

// - **Lời giải:**

// ```csharp
// using System;

// // Lớp cơ sở HinhTron
// public class HinhTron
// {
//     public double BanKinh { get; set; }

//     // Constructor
//     public HinhTron(double banKinh)
//     {
//         BanKinh = banKinh;
//     }

//     // Phương thức tính diện tích
//     public virtual double TinhDienTich()
//     {
//         return Math.PI * BanKinh * BanKinh;
//     }

//     // Phương thức hiển thị thông tin
//     public virtual void HienThiThongTin()
//     {
//         Console.WriteLine($"Hình Tròn: Bán kính = {BanKinh}, Diện tích = {TinhDienTich():F2}");
//     }
// }

// // Lớp kế thừa HinhTronDacBiet
// public class HinhTronDacBiet : HinhTron
// {
//     public string MauSac { get; set; }

//     // Constructor
//     public HinhTronDacBiet(double banKinh, string mauSac) : base(banKinh)
//     {
//         MauSac = mauSac;
//     }

//     // Override phương thức hiển thị thông tin
//     public override void HienThiThongTin()
//     {
//         Console.WriteLine($"Hình Tròn Đặc Biệt: Bán kính = {BanKinh}, Diện tích = {TinhDienTich():F2}, Màu sắc = {MauSac}");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         HinhTron ht = new HinhTron(5.0);
//         ht.HienThiThongTin();

//         HinhTronDacBiet htdb = new HinhTronDacBiet(7.0, "Xanh");
//         htdb.HienThiThongTin();
//     }
// }
// ```

// - **Nội dung học được:**
//   - Kế thừa các thuộc tính và phương thức từ lớp cơ sở.
//   - Ghi đè (override) phương thức để mở rộng chức năng trong lớp con.
//   - Thêm các thuộc tính riêng trong lớp kế thừa.

// ---

// ## **Phần 3: Đa hình (Polymorphism)**

// ### **Bài Tập 9: Đa hình với Phương thức Keu**

// - **Nội dung:**  
//   Sử dụng các lớp `DongVat`, `Cho`, `Meo` từ bài tập trước. Tạo danh sách các đối tượng `DongVat` chứa cả `Cho` và `Meo`. Gọi phương thức `Keu()` cho từng đối tượng trong danh sách bằng cách sử dụng đa hình.

// - **Lời giải:**

// ```csharp
using System;
using System.Collections.Generic;

// Lớp cơ sở DongVat
// public class DongVat
// {
//     public string Ten { get; set; }

//     // Constructor
//     public DongVat(string ten)
//     {
//         Ten = ten;
//     }

//     // Phương thức An
//     public void An()
//     {
//         Console.WriteLine($"{Ten} đang ăn.");
//     }

//     // Phương thức Keu (ảo để ghi đè)
//     public virtual void Keu()
//     {
//         Console.WriteLine($"{Ten} phát ra tiếng kêu chung.");
//     }
// }

// // Lớp kế thừa Cho
// public class Cho : DongVat
// {
//     // Constructor
//     public Cho(string ten) : base(ten)
//     {
//     }

//     // Override phương thức Keu
//     public override void Keu()
//     {
//         Console.WriteLine($"{Ten} đang sủa.");
//     }
// }

// // Lớp kế thừa Meo
// public class Meo : DongVat
// {
//     // Constructor
//     public Meo(string ten) : base(ten)
//     {
//     }

//     // Override phương thức Keu
//     public override void Keu()
//     {
//         Console.WriteLine($"{Ten} đang meo meo.");
//     }
// }

// // Ví dụ sử dụng
// public class Program
// {
//     public static void Main()
//     {
//         List<DongVat> danhSachDongVat = new List<DongVat>
//         {
//             new Cho("Chó Cảnh"),
//             new Meo("Mèo Nhà"),
//             new Cho("Chó Hoang"),
//             new Meo("Mèo Hoang")
//         };

//         foreach (var dv in danhSachDongVat)
//         {
//             dv.An();
//             dv.Keu(); // Gọi phương thức Keu đa hình
//             Console.WriteLine();
//         }
//     }
// }
// ```

// - **Nội dung học được:**
//   - Hiểu về tính đa hình và cách triển khai nó trong C#.
//   - Sử dụng phương thức ảo (`virtual`) và ghi đè (`override`) để tùy biến hành vi của phương thức trong lớp con.
//   - Quản lý danh sách các đối tượng thuộc lớp cơ sở nhưng thực thể là lớp con.

// ---

// ### **Bài Tập 10: Đa hình với Hình Học**

// - **Nội dung:**  
//   Tạo lớp cơ sở `HinhHoc` với phương thức `TinhDienTich()` và `HienThiThongTin()`. Tạo các lớp kế thừa như `HinhTron`, `HinhVuong`, `HinhChuNhat` và triển khai phương thức `TinhDienTich()`. Tạo danh sách các đối tượng `HinhHoc` và tính tổng diện tích.

// - **Lời giải:**

// ```csharp
using System;
using System.Collections.Generic;

// Lớp cơ sở HinhHoc
public abstract class HinhHoc
{
    public string TenHinh { get; set; }

    // Constructor
    public HinhHoc(string tenHinh)
    {
        TenHinh = tenHinh;
    }

    // Phương thức trừu tượng tính diện tích
    public abstract double TinhDienTich();

    // Phương thức hiển thị thông tin
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Hình: {TenHinh}, Diện tích: {TinhDienTich():F2}");
    }
}

// Lớp HinhTron
public class HinhTron : HinhHoc
{
    public double BanKinh { get; set; }

    // Constructor
    public HinhTron(double banKinh) : base("Hình Tròn")
    {
        BanKinh = banKinh;
    }

    public override double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }
}

// Lớp HinhVuong
public class HinhVuong : HinhHoc
{
    public double Canh { get; set; }

    // Constructor
    public HinhVuong(double canh) : base("Hình Vuông")
    {
        Canh = canh;
    }

    public override double TinhDienTich()
    {
        return Canh * Canh;
    }
}

// Lớp HinhChuNhat
public class HinhChuNhat : HinhHoc
{
    public double ChieuDai { get; set; }
    public double ChieuRong { get; set; }

    // Constructor
    public HinhChuNhat(double chieuDai, double chieuRong) : base("Hình Chữ Nhật")
    {
        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public override double TinhDienTich()
    {
        return ChieuDai * ChieuRong;
    }
}

// Ví dụ sử dụng
public class Program
{
    public static void Main()
    {
        List<HinhHoc> danhSachHinh = new List<HinhHoc>
        {
            new HinhTron(5.0),
            new HinhVuong(4.0),
            new HinhChuNhat(3.0, 6.0),
            new HinhTron(2.5),
            new HinhVuong(7.0)
        };

        double tongDienTich = 0;

        foreach (var hinh in danhSachHinh)
        {
            hinh.HienThiThongTin();
            tongDienTich += hinh.TinhDienTich();
            Console.WriteLine();
        }

        Console.WriteLine($"Tổng diện tích tất cả các hình: {tongDienTich:F2}");
    }
}
// ```

// - **Nội dung học được:**
//   - Sử dụng lớp trừu tượng (`abstract class`) để định nghĩa các phương