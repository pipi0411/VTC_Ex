using System;
namespace QuanLyTruongHoc{
    public class Program{
        public static void Main(string[] args){
            // Khởi tạo các Manager
            StudentManager studentManager = new StudentManager();
            LecturerManager lecturerManager = new LecturerManager();
            SubjectManager subjectManager = new SubjectManager();
            GradeManager gradeManager = new GradeManager();
            ClassManager classManager = new ClassManager();

            bool isExit = false;
            while (!isExit){
                Console.WriteLine("\n--- Hệ Thống Quản Lý Trường Học ---");
                Console.WriteLine("1. Quản lý sinh viên");
                Console.WriteLine("2. Quản lý giảng viên");
                Console.WriteLine("3. Quản lý môn học");
                Console.WriteLine("4. Quản lý lớp học");
                Console.WriteLine("5. Quản lý điểm");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn chức năng: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice){
                    case 1:
                        StudentManagement.StudentManagers(studentManager);
                        break;
                    case 2:
                        LecturerManagement.LecturerManagers(lecturerManager);
                        break;
                    case 3:
                        SubjectManagement.SubjectManagers(subjectManager);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại");
                        break;
                }
            }
        }
    }
}